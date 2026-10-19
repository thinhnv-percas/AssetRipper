using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck.Installers
{
	[Token(Token = "0x20003F3")]
	public class WinCheckInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003F4")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000C88")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000C89")]
			public static Func<Instancer, WinDetector> _003C_003E9__0_0;

			[Token(Token = "0x4000C8A")]
			public static Func<Instancer, WinCheckSuppressor> _003C_003E9__0_1;

			[Token(Token = "0x4000C8B")]
			public static Func<Instancer, WinCheckBehavior> _003C_003E9__0_2;

			[Token(Token = "0x4000C8C")]
			public static Func<Instancer, WinCheckStateBridge> _003C_003E9__0_3;

			[Token(Token = "0x4000C8D")]
			public static Func<Instancer, WinStuckBoosterUsageTracker> _003C_003E9__0_4;

			[Token(Token = "0x4000C8E")]
			public static Func<Instancer, WinStuckReporter> _003C_003E9__0_5;

			[Token(Token = "0x60010A3")]
			[Address(RVA = "0x3CB6B24", Offset = "0x3CB6B24", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010A4")]
			[Address(RVA = "0x3CB6B88", Offset = "0x3CB6B88", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal WinDetector _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				WinDetector instance = new WinDetector();
				return x.InjectInstance(instance);
			}

			internal WinCheckSuppressor _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WinCheckInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_1");
				return default;
			}

			internal WinCheckBehavior _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				WinCheckBehavior instance = new WinCheckBehavior();
				return x.InjectInstance(instance);
			}

			internal WinCheckStateBridge _003CInstallBindings_003Eb__0_3(Instancer x)
			{
				WinCheckStateBridge instance = new WinCheckStateBridge();
				return x.InjectInstance(instance);
			}

			internal WinStuckBoosterUsageTracker _003CInstallBindings_003Eb__0_4(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WinCheckInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_4");
				return default;
			}

			internal WinStuckReporter _003CInstallBindings_003Eb__0_5(Instancer x)
			{
				WinStuckReporter instance = new WinStuckReporter();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010A1")]
		[Address(RVA = "0x3CB64D4", Offset = "0x3CB64D4", Length = "0x650")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinCheckInstaller::InstallBindings");
		}

		[Token(Token = "0x60010A2")]
		[Address(RVA = "0x3CB11A0", Offset = "0x3CB11A0", Length = "0x8")]
		public WinCheckInstaller()
		{
		}
	}
}
