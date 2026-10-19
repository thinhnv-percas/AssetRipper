using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.Import.Structure.Assembly.Managers;

namespace AssetRipper.Tests;

/// <summary>
/// Which bodies of a saved assembly are replaced so that a runtime can execute it.
/// </summary>
/// <remarks>
/// SandOut's DLL export ran into every failure this guards against: a body returning an object reference where an
/// integer is declared is accepted by a release JIT and crashes the process later; the same verifier also reports
/// rules a runtime does not enforce, and replacing those would throw away bodies that run fine.
/// </remarks>
public sealed class RuntimeSafeBodiesTests
{
	private static (BaseManager manager, AssemblyDefinition probe) Build()
	{
		BaseManager manager = new(static _ => { });
		manager.Read(new MemoryStream(File.ReadAllBytes(typeof(object).Assembly.Location)), "System.Private.CoreLib.dll");

		ModuleDefinition module = new("Probe.dll", KnownCorLibs.SystemPrivateCoreLib_v8_0_0_0);
		AssemblyDefinition assembly = new("Probe", new Version(1, 0, 0, 0));
		assembly.Modules.Add(module);

		TypeDefinition type = new("Probe", "Sample", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Abstract,
			module.CorLibTypeFactory.Object.Type);
		module.TopLevelTypes.Add(type);

		type.Methods.Add(Method(module, "Good", body => body.Instructions.Add(CilOpCodes.Ldc_I4_1)));
		// An object reference returned as an integer: verification error StackUnexpected, and a crash in waiting.
		type.Methods.Add(Method(module, "ReturnsReferenceAsInteger", body => body.Instructions.Add(CilOpCodes.Ldnull)));
		// A local without localsinit is unverifiable and runs exactly as written.
		type.Methods.Add(Method(module, "UninitialisedLocals", body =>
		{
			body.InitializeLocals = false;
			body.LocalVariables.Add(new CilLocalVariable(module.CorLibTypeFactory.Int32));
			body.Instructions.Add(CilOpCodes.Ldc_I4_2);
			body.Instructions.Add(CilOpCodes.Stloc_0);
			body.Instructions.Add(CilOpCodes.Ldloc_0);
		}));

		manager.Add(assembly);
		return (manager, assembly);
	}

	private static MethodDefinition Method(ModuleDefinition module, string name, Action<CilMethodBody> fill)
	{
		MethodDefinition method = new(name, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig,
			MethodSignature.CreateStatic(module.CorLibTypeFactory.Int32));
		CilMethodBody body = new() { InitializeLocals = true };
		method.CilMethodBody = body;
		fill(body);
		body.Instructions.Add(CilOpCodes.Ret);
		return method;
	}

	private static IList<CilInstruction> BodyOf(ModuleDefinition module, string name)
		=> module.TopLevelTypes.Single(type => type.Name == "Sample").Methods.Single(method => method.Name == name).CilMethodBody!.Instructions;

	[Test]
	public void OnlyTheBodyARuntimeCannotTrustIsReplaced()
	{
		(BaseManager manager, AssemblyDefinition probe) = Build();
		RuntimeSafeBodies safety = new(manager);

		ModuleDefinition written = ModuleDefinition.FromBytes(safety.Neutralise(probe));
		RuntimeSafeBodies.AssemblyReport report = safety.Reports.Single();

		Assert.Multiple(() =>
		{
			Assert.That(report.Methods, Is.EqualTo(3));
			Assert.That(report.Replaced.Select(static body => body.Method), Is.EqualTo(new[] { "Probe.Sample::ReturnsReferenceAsInteger" }));
			Assert.That(report.Replaced.Single().Reason, Does.StartWith("StackUnexpected"));
			Assert.That(BodyOf(written, "ReturnsReferenceAsInteger").Any(static instruction => instruction.OpCode == CilOpCodes.Ldnull), Is.False,
				"the replacement returns the default of int, not a reference");
			Assert.That(BodyOf(written, "Good").Select(static instruction => instruction.OpCode), Is.EqualTo(new[] { CilOpCodes.Ldc_I4_1, CilOpCodes.Ret }));
			Assert.That(BodyOf(written, "UninitialisedLocals").Count, Is.EqualTo(4), "InitLocals is a rule of verification, not of execution");
		});
	}

	[Test]
	public void AListedAssemblyHasEveryBodyReplaced()
	{
		(BaseManager manager, AssemblyDefinition probe) = Build();
		RuntimeSafeBodies safety = new(manager);

		ModuleDefinition written = ModuleDefinition.FromBytes(safety.Neutralise(probe, stubEverything: true));
		RuntimeSafeBodies.AssemblyReport report = safety.Reports.Single();

		Assert.Multiple(() =>
		{
			Assert.That(report.Replaced, Has.Count.EqualTo(3));
			Assert.That(report.Replaced.Select(static body => body.Reason), Is.All.EqualTo(RuntimeSafeBodies.StubbedByRequest));
			Assert.That(BodyOf(written, "Good").Any(static instruction => instruction.OpCode == CilOpCodes.Ldc_I4_1), Is.False,
				"a listed assembly keeps none of its bodies, sound or not");
		});
	}

	[TestCase("Facebook.Unity.IOS", "Elephant*;Facebook.*", true)]
	[TestCase("Elephant", "Elephant*;Facebook.*", true)]
	[TestCase("ElephantUniTask.Linq", "Elephant*", true)]
	[TestCase("Assembly-CSharp", "Elephant*;Facebook.*", false)]
	[TestCase("Unity.Services.Core", "unity.services.*", true)]
	[TestCase("Unity.Entities", "", false)]
	public void PatternsMatchWholeNamesWithWildcards(string name, string patterns, bool listed)
	{
		Assert.That(RuntimeSafeBodies.IsListed(name, patterns), Is.EqualTo(listed));
	}
}
