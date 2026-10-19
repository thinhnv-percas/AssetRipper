using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.PlayMode
{
	[Token(Token = "0x2000419")]
	public class FailCheckInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200041A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CE4")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CE5")]
			public static Func<Instancer, FailSnapshotBuilder> _003C_003E9__0_0;

			[Token(Token = "0x4000CE6")]
			public static Func<Instancer, FailDetector> _003C_003E9__0_1;

			[Token(Token = "0x4000CE7")]
			public static Func<Instancer, FailGraceTimer> _003C_003E9__0_2;

			[Token(Token = "0x4000CE8")]
			public static Func<Instancer, FailCheckSuppressor> _003C_003E9__0_3;

			[Token(Token = "0x4000CE9")]
			public static Func<Instancer, FailCheckBehavior> _003C_003E9__0_4;

			[Token(Token = "0x4000CEA")]
			public static Func<Instancer, FailCheckStateBridge> _003C_003E9__0_5;

			[Token(Token = "0x4000CEB")]
			public static Func<Instancer, FailSuppressRequestBridge> _003C_003E9__0_6;

			[Token(Token = "0x6001125")]
			[Address(RVA = "0x3CBD7F8", Offset = "0x3CBD7F8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001126")]
			[Address(RVA = "0x3CBD85C", Offset = "0x3CBD85C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal FailSnapshotBuilder _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FailCheckInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}

			internal FailDetector _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				FailDetector instance = new FailDetector();
				return x.InjectInstance(instance);
			}

			internal FailGraceTimer _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				FailGraceTimer instance = new FailGraceTimer();
				return x.InjectInstance(instance);
			}

			internal FailCheckSuppressor _003CInstallBindings_003Eb__0_3(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FailCheckInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_3");
				return default;
			}

			internal FailCheckBehavior _003CInstallBindings_003Eb__0_4(Instancer x)
			{
				FailCheckBehavior instance = new FailCheckBehavior();
				return x.InjectInstance(instance);
			}

			internal FailCheckStateBridge _003CInstallBindings_003Eb__0_5(Instancer x)
			{
				FailCheckStateBridge instance = new FailCheckStateBridge();
				return x.InjectInstance(instance);
			}

			internal FailSuppressRequestBridge _003CInstallBindings_003Eb__0_6(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FailCheckInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_6");
				return default;
			}
		}

		[Token(Token = "0x6001123")]
		[Address(RVA = "0x3CBD0F0", Offset = "0x3CBD0F0", Length = "0x708")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailCheckInstaller::InstallBindings");
		}

		[Token(Token = "0x6001124")]
		[Address(RVA = "0x3CB11A8", Offset = "0x3CB11A8", Length = "0x8")]
		public FailCheckInstaller()
		{
		}
	}
}
