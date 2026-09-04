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
	/// Attribute analysis has to run before the layers that append to the lists it creates, and the
	/// diagnostics have to run before anything spends time on a binary that cannot be recovered.
	/// </summary>
	[Test]
	public void LayerOrderIsAttributeAnalysisFirst()
	{
		Il2CppRecoverySetup.Apply(new ImportSettings { ScriptContentLevel = ScriptContentLevel.Level3 });

		List<string> ids = [.. IL2CppManager.RecoveryProcessingLayers!.Select(layer => layer.Id)];
		Assert.Multiple(() =>
		{
			Assert.That(ids[0], Is.EqualTo(new Cpp2IL.Core.ProcessingLayers.AttributeAnalysisProcessingLayer().Id));
			Assert.That(ids, Does.Contain("recoverydiagnostics"));
			Assert.That(ids, Does.Contain("structdb"));
			Assert.That(ids.IndexOf("recoverydiagnostics"), Is.LessThan(ids.IndexOf("structdb")));
		});
	}
}
