using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004DA")]
	public class SRDebuggerHealthInstaller : SRDebuggerOptionInstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20004DB")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400103C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400103D")]
			public static Func<Instancer, HealthSRDebuggerSetupService> _003C_003E9__0_0;

			[Token(Token = "0x600146E")]
			[Address(RVA = "0x3CF54A4", Offset = "0x3CF54A4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600146F")]
			[Address(RVA = "0x3CF5508", Offset = "0x3CF5508", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HealthSRDebuggerSetupService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerHealthInstaller._003C_003Ec::_003CInstallSRDebuggerBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x600146C")]
		[Address(RVA = "0x3CF5374", Offset = "0x3CF5374", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerHealthInstaller::InstallSRDebuggerBindings");
		}

		[Token(Token = "0x600146D")]
		[Address(RVA = "0x3CF549C", Offset = "0x3CF549C", Length = "0x8")]
		public SRDebuggerHealthInstaller()
		{
		}
	}
}
