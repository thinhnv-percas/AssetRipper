using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.Systems.Offers
{
	[Token(Token = "0x200075C")]
	public class HomeLayerOfferInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200075D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001898")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001899")]
			public static Func<Instancer, HomeOfferConsumer> _003C_003E9__0_0;

			[Token(Token = "0x6001F06")]
			[Address(RVA = "0x3D8AEBC", Offset = "0x3D8AEBC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001F07")]
			[Address(RVA = "0x3D8AF20", Offset = "0x3D8AF20", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HomeOfferConsumer _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				HomeOfferConsumer homeOfferConsumer = new HomeOfferConsumer();
				HomeOfferConsumer homeOfferConsumer2 = instancer.InjectInstance(homeOfferConsumer);
				return homeOfferConsumer;
			}
		}

		[Token(Token = "0x6001F04")]
		[Address(RVA = "0x3D8AD8C", Offset = "0x3D8AD8C", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2968;
			Func<Instancer, HomeOfferConsumer> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					HomeOfferConsumer homeOfferConsumer = new HomeOfferConsumer();
					HomeOfferConsumer homeOfferConsumer2 = instancer.InjectInstance(homeOfferConsumer);
					return homeOfferConsumer;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001F05")]
		[Address(RVA = "0x3D8AEB4", Offset = "0x3D8AEB4", Length = "0x8")]
		public HomeLayerOfferInstaller()
		{
		}
	}
}
