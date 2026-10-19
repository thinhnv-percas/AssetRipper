using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace Unco.RealTimeSystem.Runtime
{
	[Token(Token = "0x20007F5")]
	public class RealTimeTaskInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20007F6")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001A85")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001A86")]
			public static Func<Instancer, RealTimeTaskController> _003C_003E9__0_0;

			[Token(Token = "0x60021AF")]
			[Address(RVA = "0x3DC8DA0", Offset = "0x3DC8DA0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60021B0")]
			[Address(RVA = "0x3DC8E04", Offset = "0x3DC8E04", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal RealTimeTaskController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x60021AD")]
		[Address(RVA = "0x3DC8C70", Offset = "0x3DC8C70", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RealTimeTaskInstaller::InstallBindings");
		}

		[Token(Token = "0x60021AE")]
		[Address(RVA = "0x3DC8D98", Offset = "0x3DC8D98", Length = "0x8")]
		public RealTimeTaskInstaller()
		{
		}
	}
}
