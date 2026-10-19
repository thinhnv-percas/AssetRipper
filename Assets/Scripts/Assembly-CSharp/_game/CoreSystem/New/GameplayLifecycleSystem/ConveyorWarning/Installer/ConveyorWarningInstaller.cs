using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.ConveyorWarning.Installer
{
	[Token(Token = "0x2000429")]
	public class ConveyorWarningInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200042A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000D20")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000D21")]
			public static Func<Instancer, ConveyorWarningDetector> _003C_003E9__0_0;

			[Token(Token = "0x6001165")]
			[Address(RVA = "0x3CC0878", Offset = "0x3CC0878", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001166")]
			[Address(RVA = "0x3CC08DC", Offset = "0x3CC08DC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal ConveyorWarningDetector _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorWarningInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001163")]
		[Address(RVA = "0x3CC066C", Offset = "0x3CC066C", Length = "0x20C")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorWarningInstaller::InstallBindings");
		}

		[Token(Token = "0x6001164")]
		[Address(RVA = "0x3CB11D8", Offset = "0x3CB11D8", Length = "0x8")]
		public ConveyorWarningInstaller()
		{
		}
	}
}
