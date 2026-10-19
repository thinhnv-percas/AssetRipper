using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.Installers
{
	[Token(Token = "0x2000415")]
	public class GameSpeedInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000416")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CE0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CE1")]
			public static Func<Instancer, GameSpeedController> _003C_003E9__0_0;

			[Token(Token = "0x600111B")]
			[Address(RVA = "0x3CBCD70", Offset = "0x3CBCD70", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600111C")]
			[Address(RVA = "0x3CBCDD4", Offset = "0x3CBCDD4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal GameSpeedController _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001119")]
		[Address(RVA = "0x3CBCC48", Offset = "0x3CBCC48", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameSpeedInstaller::InstallBindings");
		}

		[Token(Token = "0x600111A")]
		[Address(RVA = "0x3CB11B0", Offset = "0x3CB11B0", Length = "0x8")]
		public GameSpeedInstaller()
		{
		}
	}
}
