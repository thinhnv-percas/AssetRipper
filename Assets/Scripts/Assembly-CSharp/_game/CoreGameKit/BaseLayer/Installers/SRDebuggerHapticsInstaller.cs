using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Lofelt.NiceVibrations;
using Reflex.Attributes;
using SRDebugger;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.SettingsSyste.Core;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006B2")]
	public class SRDebuggerHapticsInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x20006B3")]
		private class SRDebuggerHapticsSetupService : SRDebuggerOptionServiceBase
		{
			[Token(Token = "0x40016B7")]
			[FieldOffset(Offset = "0x18")]
			private HapticManager _hapticManager;

			[Token(Token = "0x40016B8")]
			[FieldOffset(Offset = "0x20")]
			private readonly SceneConfig _hapticSceneConfig;

			[Token(Token = "0x40016B9")]
			[FieldOffset(Offset = "0x28")]
			private SceneConfig _previousSceneConfig;

			[Token(Token = "0x6001C5C")]
			[Address(RVA = "0x3D6D244", Offset = "0x3D6D244", Length = "0xE0")]
			public SRDebuggerHapticsSetupService(SceneConfig hapticSceneConfig)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerHapticsInstaller.SRDebuggerHapticsSetupService::.ctor");
			}

			[Inject(false)]
			[Token(Token = "0x6001C5D")]
			[Address(RVA = "0x3D6D3B0", Offset = "0x3D6D3B0", Length = "0x28")]
			private void Inject(HapticManager hapticManager)
			{
				_hapticManager = hapticManager;
				SetupHapticOptions();
			}

			[Token(Token = "0x6001C5E")]
			[Address(RVA = "0x3D6D3D8", Offset = "0x3D6D3D8", Length = "0x440")]
			private void SetupHapticOptions()
			{
				Action callback = delegate
				{
					_hapticManager.PlayHapticType(default(HapticPatterns.PresetType));
					Debug.Log("[SRDebugger Haptics] Played: Selection");
				};
				OptionDefinition option = OptionDefinition.FromMethod("Selection", callback, "6. NiceVibrations", 1);
				AddOption(option);
				Action callback2 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.Success);
					Debug.Log("[SRDebugger Haptics] Played: Success");
				};
				OptionDefinition option2 = OptionDefinition.FromMethod("Success", callback2, "6. NiceVibrations", 2);
				AddOption(option2);
				Action callback3 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.Warning);
					Debug.Log("[SRDebugger Haptics] Played: Warning");
				};
				OptionDefinition option3 = OptionDefinition.FromMethod("Warning", callback3, "6. NiceVibrations", 3);
				AddOption(option3);
				Action callback4 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.Failure);
					Debug.Log("[SRDebugger Haptics] Played: Failure");
				};
				OptionDefinition option4 = OptionDefinition.FromMethod("Failure", callback4, "6. NiceVibrations", 4);
				AddOption(option4);
				Action callback5 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.LightImpact);
					Debug.Log("[SRDebugger Haptics] Played: LightImpact");
				};
				OptionDefinition option5 = OptionDefinition.FromMethod("Light Impact", callback5, "6. NiceVibrations", 5);
				AddOption(option5);
				Action callback6 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.MediumImpact);
					Debug.Log("[SRDebugger Haptics] Played: MediumImpact");
				};
				OptionDefinition option6 = OptionDefinition.FromMethod("Medium Impact", callback6, "6. NiceVibrations", 6);
				AddOption(option6);
				Action callback7 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.HeavyImpact);
					Debug.Log("[SRDebugger Haptics] Played: HeavyImpact");
				};
				OptionDefinition option7 = OptionDefinition.FromMethod("Heavy Impact", callback7, "6. NiceVibrations", 7);
				AddOption(option7);
				Action callback8 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.RigidImpact);
					Debug.Log("[SRDebugger Haptics] Played: RigidImpact");
				};
				OptionDefinition option8 = OptionDefinition.FromMethod("Rigid Impact", callback8, "6. NiceVibrations", 8);
				AddOption(option8);
				Action callback9 = delegate
				{
					_hapticManager.PlayHapticType(HapticPatterns.PresetType.SoftImpact);
					Debug.Log("[SRDebugger Haptics] Played: SoftImpact");
				};
				OptionDefinition option9 = OptionDefinition.FromMethod("Soft Impact", callback9, "6. NiceVibrations", 9);
				AddOption(option9);
			}
		}

		[Token(Token = "0x40016B5")]
		private const string Category = "6. NiceVibrations";

		[SerializeField]
		[Token(Token = "0x40016B6")]
		[FieldOffset(Offset = "0x18")]
		private SceneConfig _hapticSceneConfig;

		[Token(Token = "0x6001C59")]
		[Address(RVA = "0x3D6D0F4", Offset = "0x3D6D0F4", Length = "0xA8")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, SRDebuggerHapticsSetupService> factory = delegate(Instancer instancer)
			{
				SRDebuggerHapticsSetupService sRDebuggerHapticsSetupService = new SRDebuggerHapticsSetupService(_hapticSceneConfig);
				SRDebuggerHapticsSetupService sRDebuggerHapticsSetupService2 = instancer.InjectInstance(sRDebuggerHapticsSetupService);
				return sRDebuggerHapticsSetupService;
			};
			containerBuilder.AddSingleton(factory);
		}

		[Token(Token = "0x6001C5A")]
		[Address(RVA = "0x3D6D19C", Offset = "0x3D6D19C", Length = "0x8")]
		public SRDebuggerHapticsInstaller()
		{
		}
	}
}
