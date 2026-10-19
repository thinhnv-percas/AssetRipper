using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.FrameSystem.Debug;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.New.GameplayAreaSystem.Installers
{
	[Token(Token = "0x2000434")]
	public class GameplayAreaInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000435")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000D34")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000D35")]
			public static Func<Instancer, FrameController> _003C_003E9__5_0;

			[Token(Token = "0x4000D36")]
			public static Func<Instancer, ConveyorController> _003C_003E9__5_5;

			[Token(Token = "0x4000D37")]
			public static Func<Instancer, ConveyorUpgradeIntroWiring> _003C_003E9__5_6;

			[Token(Token = "0x4000D38")]
			public static Func<Instancer, DifficultyMaterialController> _003C_003E9__5_7;

			[Token(Token = "0x6001190")]
			[Address(RVA = "0x3CC24B4", Offset = "0x3CC24B4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001191")]
			[Address(RVA = "0x3CC2518", Offset = "0x3CC2518", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal FrameController _003CInstallBindings_003Eb__5_0(Instancer x)
			{
				FrameController instance = new FrameController();
				return x.InjectInstance(instance);
			}

			internal ConveyorController _003CInstallBindings_003Eb__5_5(Instancer x)
			{
				bool flag = x.TryResolve<GameplayAreaController>(out var result);
				bool flag2 = x.TryResolve<SandParticleParams>(out var result2);
				ConveyorController component = result.ConveyorInstance.GetComponent<ConveyorController>();
				component.SetCapacity(result2.ParticlesPerCube);
				return x.InjectMono(component);
			}

			internal ConveyorUpgradeIntroWiring _003CInstallBindings_003Eb__5_6(Instancer x)
			{
				ConveyorUpgradeIntroWiring instance = new ConveyorUpgradeIntroWiring();
				return x.InjectInstance(instance);
			}

			internal DifficultyMaterialController _003CInstallBindings_003Eb__5_7(Instancer x)
			{
				DifficultyMaterialController instance = new DifficultyMaterialController();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000D2F")]
		[FieldOffset(Offset = "0x18")]
		private FramePresetRegistry m_registry;

		[SerializeField]
		[Token(Token = "0x4000D30")]
		[FieldOffset(Offset = "0x20")]
		private GameplayAreaController m_controller;

		[SerializeField]
		[Token(Token = "0x4000D31")]
		[FieldOffset(Offset = "0x28")]
		private MoldBgMono m_moldBgMono;

		[SerializeField]
		[Token(Token = "0x4000D32")]
		[FieldOffset(Offset = "0x30")]
		private FrameVisualizer m_frameVisualizerPrefab;

		[SerializeField]
		[Token(Token = "0x4000D33")]
		[FieldOffset(Offset = "0x38")]
		private FrameStuckDebugProbe m_stuckProbePrefab;

		[Token(Token = "0x6001189")]
		[Address(RVA = "0x3CC1A50", Offset = "0x3CC1A50", Length = "0x7B4")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameplayAreaInstaller::InstallBindings");
		}

		[Token(Token = "0x600118A")]
		[Address(RVA = "0x3CC2204", Offset = "0x3CC2204", Length = "0x8")]
		public GameplayAreaInstaller()
		{
		}
	}
}
