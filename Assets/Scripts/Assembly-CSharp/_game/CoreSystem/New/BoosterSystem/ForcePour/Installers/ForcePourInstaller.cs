using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Configs;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Core;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;

namespace _game.CoreSystem.New.BoosterSystem.ForcePour.Installers
{
	[CreateAssetMenu(fileName = "ForcePourInstaller", menuName = "Sand Out/ForcePour/Installer")]
	[Token(Token = "0x200048E")]
	public class ForcePourInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200048F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000EF2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000EF3")]
			public static Func<Instancer, ForcePourTargeter> _003C_003E9__2_0;

			[Token(Token = "0x4000EF4")]
			public static Func<Instancer, HammerBoosterBridge> _003C_003E9__2_1;

			[Token(Token = "0x60012EF")]
			[Address(RVA = "0x3CE1B14", Offset = "0x3CE1B14", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60012F0")]
			[Address(RVA = "0x3CE1B78", Offset = "0x3CE1B78", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal ForcePourTargeter _003CInstallBindings_003Eb__2_0(Instancer x)
			{
				ForcePourTargeter instance = new ForcePourTargeter();
				return x.InjectInstance(instance);
			}

			internal HammerBoosterBridge _003CInstallBindings_003Eb__2_1(Instancer x)
			{
				HammerBoosterBridge instance = new HammerBoosterBridge();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000EF0")]
		[FieldOffset(Offset = "0x18")]
		private ForcePourConfigSO m_config;

		[SerializeField]
		[Token(Token = "0x4000EF1")]
		[FieldOffset(Offset = "0x20")]
		private ForcePourController m_controllerPrefab;

		[Token(Token = "0x60012ED")]
		[Address(RVA = "0x3CE1794", Offset = "0x3CE1794", Length = "0x370")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			if (m_config != null)
			{
				containerBuilder.AddSingleton(m_config);
			}
			int num = 187441152 + 2784;
			Func<Instancer, ForcePourTargeter> _003C_003E9__2_ = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				_003C_003E9__2_ = (_003C_003Ec._003C_003E9__2_0 = delegate(Instancer x)
				{
					ForcePourTargeter instance = new ForcePourTargeter();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			if (m_controllerPrefab != null)
			{
				ForcePourController forcePourController = UnityEngine.Object.Instantiate(m_controllerPrefab);
				ForcePourController controller = forcePourController;
				Func<Instancer, ForcePourController> factory = delegate(Instancer x)
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
			}
			int num2 = 187441152 + 2920;
			Func<Instancer, HammerBoosterBridge> _003C_003E9__2_2 = _003C_003Ec._003C_003E9__2_1;
			if (_003C_003Ec._003C_003E9__2_1 == null)
			{
				_003C_003E9__2_2 = (_003C_003Ec._003C_003E9__2_1 = delegate(Instancer x)
				{
					HammerBoosterBridge instance = new HammerBoosterBridge();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60012EE")]
		[Address(RVA = "0x3CE1B0C", Offset = "0x3CE1B0C", Length = "0x8")]
		public ForcePourInstaller()
		{
		}
	}
}
