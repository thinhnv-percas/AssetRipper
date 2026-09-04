using AssetRipper.Import.Configuration;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Assembly.Managers;
using Cpp2IL.Core.Api;
using Cpp2IL.Core.InstructionSets;
using LibCpp2IL;
using System.Runtime.CompilerServices;

namespace AssetRipper.Tests;

/// <summary>
/// Guards the wiring that decides whether IL2Cpp method bodies can be recovered at all.
/// </summary>
/// <remarks>
/// The failure this covers is silent: an instruction set that produces no ISIL gives the same file set,
/// the same signatures and the same attributes as a working run, with every method body empty. Nothing
/// short of asserting the wiring catches it.
/// </remarks>
internal sealed class Il2CppRecoverySetupTests
{
	[OneTimeSetUp]
	public void RegisterInstructionSets()
	{
		// Registration happens in IL2CppManager's static constructor, which nothing here would otherwise trigger.
		RuntimeHelpers.RunClassConstructor(typeof(IL2CppManager).TypeHandle);
	}

	[TearDown]
	public void RestoreStockBehaviour() => Il2CppRecoverySetup.Uninstall();

	/// <summary>
	/// The exact defect: Cpp2IL's long-standing ARM64 implementation returns an empty instruction list
	/// for every method, so IL recovery has nothing to convert and falls back to a stub body.
	/// </summary>
	[Test]
	public void TheLegacyArm64ImplementationCannotProduceBodies()
	{
		Assert.Multiple(() =>
		{
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(new Arm64InstructionSet()), Is.False);
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(new NewArmV8InstructionSet()), Is.True);
		});
	}

	/// <summary>
	/// ARMv7 and WebAssembly have no ISIL lifter at all in this version of Cpp2IL, and no second
	/// implementation to switch to. Recovery on those binaries cannot work, and has to say so.
	/// </summary>
	[Test]
	public void ArmV7AndWasmCannotProduceBodies()
	{
		Assert.Multiple(() =>
		{
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(new ArmV7InstructionSet()), Is.False);
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(new WasmInstructionSet()), Is.False);
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(new X86InstructionSet()), Is.True);
		});
	}

	[Test]
	public void Arm64IsRegisteredThroughTheSelector()
	{
		// A concrete implementation here would pin one behaviour for every content level.
		Assert.That(InstructionSetRegistry.GetInstructionSet(DefaultInstructionSets.ARM_V8),
			Is.InstanceOf<Arm64InstructionSetSelector>());
	}

	[Test]
	public void InstallingRecoveryMakesArm64CapableOfBodies()
	{
		Cpp2IlInstructionSet arm64 = InstructionSetRegistry.GetInstructionSet(DefaultInstructionSets.ARM_V8);
		Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(arm64), Is.False,
			"stock behaviour, which every level below Level3 keeps");

		Il2CppRecoverySetup.Install(structDbDirectory: null);

		Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(arm64), Is.True,
			"recovery is pointless if the instruction set cannot lift native code to ISIL");
	}

	[Test]
	public void UninstallingPutsArm64Back()
	{
		Cpp2IlInstructionSet arm64 = InstructionSetRegistry.GetInstructionSet(DefaultInstructionSets.ARM_V8);

		Il2CppRecoverySetup.Install(structDbDirectory: null);
		Il2CppRecoverySetup.Uninstall();

		Assert.Multiple(() =>
		{
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(arm64), Is.False);
			Assert.That(IL2CppManager.RecoveryProcessingLayers, Is.Null);
			Assert.That(IL2CppManager.RecoveryOutputFormat, Is.Null);
		});
	}

	/// <summary>
	/// Level 3 is the only level that installs anything. The others must come out of Apply untouched.
	/// </summary>
	[Test]
	public void OnlyLevelThreeInstallsRecovery()
	{
		Cpp2IlInstructionSet arm64 = InstructionSetRegistry.GetInstructionSet(DefaultInstructionSets.ARM_V8);

		foreach (ScriptContentLevel level in (ScriptContentLevel[])
			[ScriptContentLevel.Level0, ScriptContentLevel.Level1, ScriptContentLevel.Level2])
		{
			Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = level });

			Assert.Multiple(() =>
			{
				Assert.That(IL2CppManager.RecoveryProcessingLayers, Is.Null, $"{level} must not install recovery");
				Assert.That(IL2CppManager.RecoveryOutputFormat, Is.Null, $"{level} must not install recovery");
				Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(arm64), Is.False, $"{level} must not swap the instruction set");
			});
		}

		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3 });

		Assert.Multiple(() =>
		{
			Assert.That(IL2CppManager.RecoveryProcessingLayers, Is.Not.Null);
			Assert.That(IL2CppManager.RecoveryOutputFormat, Is.InstanceOf<Il2CppIlRecoveryOutputFormat>());
			Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.CanProduceMethodBodies(arm64), Is.True);
		});
	}

	/// <summary>
	/// Which assemblies recovery attempts. Cpp2IL stubs the framework ones by design, so a reader
	/// looking at UnityEngine.CoreModule sees empty bodies however well recovery went — and this
	/// predicate is what the diagnostics use to name the assemblies worth opening.
	/// </summary>
	[Test]
	public void FrameworkAssembliesAreTheOnesCpp2IlStubs()
	{
		Assert.Multiple(() =>
		{
			foreach (string stubbed in (string[])
				["UnityEngine", "UnityEngine.CoreModule", "Unity.TextMeshPro", "System", "System.Core", "mscorlib", "netstandard"])
			{
				Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.IsFrameworkAssembly(stubbed), Is.True, stubbed);
			}

			foreach (string attempted in (string[])
				["Assembly-CSharp", "Assembly-CSharp-firstpass", "SandLoop.Core", "DOTween", "Firebase.App"])
			{
				Assert.That(Il2CppRecoveryDiagnosticsProcessingLayer.IsFrameworkAssembly(attempted), Is.False, attempted);
			}
		});
	}

	/// <summary>
	/// The diagnostics go first, so a binary that cannot be recovered is reported before attribute
	/// analysis spends minutes on it. Attribute analysis then precedes the layers that append to the
	/// lists it creates.
	/// </summary>
	[Test]
	public void DiagnosticsRunBeforeAnythingExpensive()
	{
		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3 });

		List<string> ids = [.. IL2CppManager.RecoveryProcessingLayers!.Select(layer => layer.Id)];
		string attributeAnalysis = new Cpp2IL.Core.ProcessingLayers.AttributeAnalysisProcessingLayer().Id;

		Assert.Multiple(() =>
		{
			Assert.That(ids[0], Is.EqualTo("recoverydiagnostics"));
			Assert.That(ids, Does.Contain(attributeAnalysis));
			Assert.That(ids.IndexOf(attributeAnalysis), Is.LessThan(ids.IndexOf("structdb")));
		});
	}
}
