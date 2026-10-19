using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreGameKit.Tracking.Tools.Logging;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x200069F")]
	public class BaseLayerServiceInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006A0")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400168F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001690")]
			public static Func<Instancer, BaseLayerSessionController> _003C_003E9__0_0;

			[Token(Token = "0x6001C11")]
			[Address(RVA = "0x3D679D0", Offset = "0x3D679D0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C12")]
			[Address(RVA = "0x3D67A34", Offset = "0x3D67A34", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal BaseLayerSessionController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				BaseLayerSessionController instance = new BaseLayerSessionController();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6001C0F")]
		[Address(RVA = "0x3D67328", Offset = "0x3D67328", Length = "0x6A0")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerServiceInstaller::InstallBindings");
		}

		[Token(Token = "0x6001C10")]
		[Address(RVA = "0x3D679C8", Offset = "0x3D679C8", Length = "0x8")]
		public BaseLayerServiceInstaller()
		{
		}
	}
}
