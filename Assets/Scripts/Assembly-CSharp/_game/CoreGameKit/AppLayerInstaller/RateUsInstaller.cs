using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreGameKit.AppLayerInstaller
{
	[Token(Token = "0x20006F5")]
	public class RateUsInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20006F6")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400175A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400175B")]
			public static Func<Instancer, RateUsController> _003C_003E9__0_0;

			[Token(Token = "0x6001D67")]
			[Address(RVA = "0x3D78150", Offset = "0x3D78150", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001D68")]
			[Address(RVA = "0x3D781B4", Offset = "0x3D781B4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal RateUsController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				RateUsController instance = new RateUsController();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6001D65")]
		[Address(RVA = "0x3D78020", Offset = "0x3D78020", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3272;
			Func<Instancer, RateUsController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					RateUsController instance = new RateUsController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001D66")]
		[Address(RVA = "0x3D78148", Offset = "0x3D78148", Length = "0x8")]
		public RateUsInstaller()
		{
		}
	}
}
