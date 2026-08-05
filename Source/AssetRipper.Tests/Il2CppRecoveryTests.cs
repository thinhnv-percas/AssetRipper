using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Import.Structure.Assembly.Recovery;

namespace AssetRipper.Tests;

/// <summary>
/// The Il2Cpp recovery benchmark reads its outcome off the generated method body, so these tests
/// pin down that classification against hand built bodies matching what Cpp2IL emits.
/// </summary>
public sealed class Il2CppRecoveryTests
{
	private static MethodDefinition CreateMethod(string moduleName, params CilInstruction[] instructions)
	{
		ModuleDefinition module = new(moduleName);
		MethodDefinition method = new("TestMethod", MethodAttributes.Public | MethodAttributes.Static,
			MethodSignature.CreateStatic(module.CorLibTypeFactory.Void));
		module.GetOrCreateModuleType().Methods.Add(method);

		CilMethodBody body = new();
		foreach (CilInstruction instruction in instructions)
		{
			body.Instructions.Add(instruction);
		}
		method.CilMethodBody = body;

		return method;
	}

	[Test]
	public void MethodWithoutBodyIsReportedAsNoBody()
	{
		ModuleDefinition module = new("Assembly-CSharp.dll");
		MethodDefinition method = new("Abstract", MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual,
			MethodSignature.CreateInstance(module.CorLibTypeFactory.Void));
		module.GetOrCreateModuleType().Methods.Add(method);

		var result = MethodBodyClassifier.Classify("Assembly-CSharp.dll", method);

		Assert.That(result.Outcome, Is.EqualTo(MethodRecoveryOutcome.NoBody));
	}

	[Test]
	public void ThrowingBodyIsReportedAsFailedWithItsMessage()
	{
		MethodDefinition method = CreateMethod("Assembly-CSharp.dll",
			new CilInstruction(CilOpCodes.Ldstr, "Unsupported ISIL opcode"),
			new CilInstruction(CilOpCodes.Newobj),
			new CilInstruction(CilOpCodes.Throw));

		var result = MethodBodyClassifier.Classify("Assembly-CSharp.dll", method);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(result.Outcome, Is.EqualTo(MethodRecoveryOutcome.Failed));
			Assert.That(result.FailureMessage, Is.EqualTo("Unsupported ISIL opcode"));
		}
	}

	[TestCase(CilCode.Ret)]
	[TestCase(CilCode.Ldnull)]
	[TestCase(CilCode.Ldc_I4_0)]
	public void DefaultValueBodyIsReportedAsMinimal(CilCode code)
	{
		CilOpCode opCode = code is CilCode.Ret ? CilOpCodes.Ret
			: code is CilCode.Ldnull ? CilOpCodes.Ldnull
			: CilOpCodes.Ldc_I4_0;

		MethodDefinition method = code is CilCode.Ret
			? CreateMethod("Assembly-CSharp.dll", new CilInstruction(CilOpCodes.Ret))
			: CreateMethod("Assembly-CSharp.dll", new CilInstruction(opCode), new CilInstruction(CilOpCodes.Ret));

		var result = MethodBodyClassifier.Classify("Assembly-CSharp.dll", method);

		Assert.That(result.Outcome, Is.EqualTo(MethodRecoveryOutcome.Minimal));
	}

	[Test]
	public void BodyContainingRealInstructionsIsReportedAsRecovered()
	{
		MethodDefinition method = CreateMethod("Assembly-CSharp.dll",
			new CilInstruction(CilOpCodes.Ldc_I4_1),
			new CilInstruction(CilOpCodes.Ldc_I4_2),
			new CilInstruction(CilOpCodes.Add),
			new CilInstruction(CilOpCodes.Pop),
			new CilInstruction(CilOpCodes.Ret));

		var result = MethodBodyClassifier.Classify("Assembly-CSharp.dll", method);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(result.Outcome, Is.EqualTo(MethodRecoveryOutcome.Recovered));
			Assert.That(result.InstructionCount, Is.EqualTo(5));
		}
	}

	/// <summary>
	/// An excluded assembly gets a minimal body too, but it must not be counted as an analysis result.
	/// </summary>
	[TestCase("UnityEngine.CoreModule.dll")]
	[TestCase("Unity.TextMeshPro.dll")]
	[TestCase("System.Core.dll")]
	[TestCase("System")]
	[TestCase("mscorlib.dll")]
	public void ExcludedAssembliesAreNotCountedAsAnalyzed(string moduleName)
	{
		MethodDefinition method = CreateMethod(moduleName, new CilInstruction(CilOpCodes.Ret));

		var result = MethodBodyClassifier.Classify(moduleName, method);

		Assert.That(result.Outcome, Is.EqualTo(MethodRecoveryOutcome.Excluded));
	}

	[TestCase("Assembly-CSharp.dll")]
	[TestCase("Unityscript.dll")]
	[TestCase("SystemHelper.dll")]
	public void GameAssembliesAreAnalyzed(string moduleName)
	{
		Assert.That(MethodBodyClassifier.IsExcludedFromAnalysis(moduleName), Is.False);
	}

	[Test]
	public void FailuresAreGroupedByTheShapeOfTheirMessage()
	{
		MethodRecoveryRecord[] records =
		[
			new("A.dll", "M1", MethodRecoveryOutcome.Failed, 3, "Failed to convert instruction at 0x1A2B3C"),
			new("A.dll", "M2", MethodRecoveryOutcome.Failed, 3, "Failed to convert instruction at 0xFFEE01"),
			new("A.dll", "M3", MethodRecoveryOutcome.Failed, 3, "Unknown calling convention"),
			new("A.dll", "M4", MethodRecoveryOutcome.Recovered, 12, null),
		];

		List<(string Reason, int Count)> reasons = Il2CppRecoveryReport.GetTopFailureReasons(records, 10);

		using (Assert.EnterMultipleScope())
		{
			// The two differing addresses must collapse into one reason.
			Assert.That(reasons, Has.Count.EqualTo(2));
			Assert.That(reasons[0].Count, Is.EqualTo(2));
			Assert.That(reasons[1].Count, Is.EqualTo(1));
			Assert.That(reasons[1].Reason, Is.EqualTo("Unknown calling convention"));
		}
	}

	[Test]
	public void ReportWritesOneRowPerMethodAndEscapesFields()
	{
		Il2CppRecoveryReport.Clear();
		try
		{
			Il2CppRecoveryReport.Add(new MethodRecoveryRecord("A.dll", "System.Void M(System.Int32)", MethodRecoveryOutcome.Recovered, 7, null));
			Il2CppRecoveryReport.Add(new MethodRecoveryRecord("A.dll", "M2", MethodRecoveryOutcome.Failed, 3, "Bad \"quoted\", comma'd\nmessage"));

			string directory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(directory);
			try
			{
				string? path = Il2CppRecoveryReport.TryWriteCsv(directory);
				Assert.That(path, Is.Not.Null);

				string[] lines = File.ReadAllLines(path!);
				using (Assert.EnterMultipleScope())
				{
					// Header plus one row per method, with the embedded newline flattened.
					Assert.That(lines, Has.Length.EqualTo(3));
					Assert.That(lines[0], Is.EqualTo("Assembly,Method,Outcome,InstructionCount,FailureMessage"));
					Assert.That(lines[1], Is.EqualTo("\"A.dll\",\"System.Void M(System.Int32)\",\"Recovered\",7,\"\""));
					Assert.That(lines[2], Does.Contain("\"\"quoted\"\""));
				}
			}
			finally
			{
				Directory.Delete(directory, true);
			}
		}
		finally
		{
			Il2CppRecoveryReport.Clear();
		}
	}
}
