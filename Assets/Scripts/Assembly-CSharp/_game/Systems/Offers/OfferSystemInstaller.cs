using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.Systems.Offers
{
	[Token(Token = "0x2000768")]
	public class OfferSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000769")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40018BB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40018BC")]
			public static Func<Instancer, OfferService> _003C_003E9__0_0;

			[Token(Token = "0x6001F3E")]
			[Address(RVA = "0x3D8D698", Offset = "0x3D8D698", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001F3F")]
			[Address(RVA = "0x3D8D6FC", Offset = "0x3D8D6FC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal OfferService _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("OfferSystemInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001F3C")]
		[Address(RVA = "0x3D8D568", Offset = "0x3D8D568", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferSystemInstaller::InstallBindings");
		}

		[Token(Token = "0x6001F3D")]
		[Address(RVA = "0x3D8D690", Offset = "0x3D8D690", Length = "0x8")]
		public OfferSystemInstaller()
		{
		}
	}
}
