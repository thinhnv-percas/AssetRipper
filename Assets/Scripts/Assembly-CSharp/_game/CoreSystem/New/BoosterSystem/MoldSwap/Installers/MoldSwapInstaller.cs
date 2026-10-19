using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Configs;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Core;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.PlayMode.Debug;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Installers
{
	[CreateAssetMenu(fileName = "MoldSwapInstaller", menuName = "Sand Out/MoldSwap/Installer")]
	[Token(Token = "0x2000480")]
	public class MoldSwapInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000481")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000E94")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000E95")]
			public static Func<Instancer, MoldSwapScorer> _003C_003E9__3_0;

			[Token(Token = "0x4000E96")]
			public static Func<Instancer, MoldSwapAnimator> _003C_003E9__3_1;

			[Token(Token = "0x4000E97")]
			public static Func<Instancer, MoldSwapBridge> _003C_003E9__3_2;

			[Token(Token = "0x60012A7")]
			[Address(RVA = "0x3CD7878", Offset = "0x3CD7878", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60012A8")]
			[Address(RVA = "0x3CD78DC", Offset = "0x3CD78DC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal MoldSwapScorer _003CInstallBindings_003Eb__3_0(Instancer x)
			{
				MoldSwapScorer instance = new MoldSwapScorer();
				return x.InjectInstance(instance);
			}

			internal MoldSwapAnimator _003CInstallBindings_003Eb__3_1(Instancer x)
			{
				MoldSwapAnimator instance = new MoldSwapAnimator();
				return x.InjectInstance(instance);
			}

			internal MoldSwapBridge _003CInstallBindings_003Eb__3_2(Instancer x)
			{
				MoldSwapBridge instance = new MoldSwapBridge();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000E91")]
		[FieldOffset(Offset = "0x18")]
		private MoldSwapConfigSO m_config;

		[SerializeField]
		[Token(Token = "0x4000E92")]
		[FieldOffset(Offset = "0x20")]
		private MoldSwapController m_controllerPrefab;

		[SerializeField]
		[Token(Token = "0x4000E93")]
		[FieldOffset(Offset = "0x28")]
		private MoldSwapTester m_testerPrefab;

		[Token(Token = "0x60012A5")]
		[Address(RVA = "0x3CD7300", Offset = "0x3CD7300", Length = "0x560")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			if (m_config != null)
			{
				containerBuilder.AddSingleton(m_config);
			}
			int num = 187441152 + 3216;
			Func<Instancer, MoldSwapScorer> _003C_003E9__3_ = _003C_003Ec._003C_003E9__3_0;
			if (_003C_003Ec._003C_003E9__3_0 == null)
			{
				_003C_003E9__3_ = (_003C_003Ec._003C_003E9__3_0 = delegate(Instancer x)
				{
					MoldSwapScorer instance = new MoldSwapScorer();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 3192;
			Func<Instancer, MoldSwapAnimator> _003C_003E9__3_2 = _003C_003Ec._003C_003E9__3_1;
			if (_003C_003Ec._003C_003E9__3_1 == null)
			{
				_003C_003E9__3_2 = (_003C_003Ec._003C_003E9__3_1 = delegate(Instancer x)
				{
					MoldSwapAnimator instance = new MoldSwapAnimator();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			UnityEngine.Object testerPrefab;
			if (!(m_controllerPrefab != null))
			{
				testerPrefab = m_testerPrefab;
			}
			else
			{
				MoldSwapController moldSwapController = UnityEngine.Object.Instantiate(m_controllerPrefab);
				MoldSwapController controller = moldSwapController;
				Func<Instancer, MoldSwapController> factory = delegate(Instancer x)
				{
					bool flag = x.TryResolve<GameplayContainerRoot>(out var result);
					if (result != null && result.Transform != null)
					{
						Transform transform = controller.transform;
						transform.SetParent(result.Transform, worldPositionStays: false);
					}
					return x.InjectMono(controller);
				};
				containerBuilder.AddSingleton(factory);
				testerPrefab = m_testerPrefab;
			}
			if (testerPrefab != null)
			{
				MoldSwapTester moldSwapTester = UnityEngine.Object.Instantiate(m_testerPrefab);
				MoldSwapTester tester = moldSwapTester;
				Func<Instancer, MoldSwapTester> factory2 = delegate(Instancer x)
				{
					bool flag = x.TryResolve<GameplayContainerRoot>(out var result);
					if (result != null && result.Transform != null)
					{
						Transform transform = tester.transform;
						transform.SetParent(result.Transform, worldPositionStays: false);
					}
					return x.InjectMono(tester);
				};
				containerBuilder.AddSingleton(factory2);
			}
			int num3 = 187441152 + 3200;
			Func<Instancer, MoldSwapBridge> _003C_003E9__3_3 = _003C_003Ec._003C_003E9__3_2;
			if (_003C_003Ec._003C_003E9__3_2 == null)
			{
				_003C_003E9__3_3 = (_003C_003Ec._003C_003E9__3_2 = delegate(Instancer x)
				{
					MoldSwapBridge instance = new MoldSwapBridge();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60012A6")]
		[Address(RVA = "0x3CD7870", Offset = "0x3CD7870", Length = "0x8")]
		public MoldSwapInstaller()
		{
		}
	}
}
