using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed.Installers
{
	[Token(Token = "0x2000417")]
	public class GameplaySpeedInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000418")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CE2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CE3")]
			public static Func<Instancer, GameplaySpeedController> _003C_003E9__0_0;

			[Token(Token = "0x6001120")]
			[Address(RVA = "0x3CBD000", Offset = "0x3CBD000", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001121")]
			[Address(RVA = "0x3CBD064", Offset = "0x3CBD064", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal GameplaySpeedController _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				GameplaySpeedController instance = new GameplaySpeedController();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x600111E")]
		[Address(RVA = "0x3CBCED8", Offset = "0x3CBCED8", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2888;
			Func<Instancer, GameplaySpeedController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					GameplaySpeedController instance = new GameplaySpeedController();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600111F")]
		[Address(RVA = "0x3CB11B8", Offset = "0x3CB11B8", Length = "0x8")]
		public GameplaySpeedInstaller()
		{
		}
	}
}
