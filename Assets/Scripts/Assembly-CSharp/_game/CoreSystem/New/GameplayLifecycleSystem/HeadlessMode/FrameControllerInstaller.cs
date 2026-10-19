using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.FrameSystem;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000403")]
	internal class FrameControllerInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000404")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CB7")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CB8")]
			public static Func<Instancer, FrameController> _003C_003E9__0_0;

			[Token(Token = "0x60010D9")]
			[Address(RVA = "0x3CB9B70", Offset = "0x3CB9B70", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010DA")]
			[Address(RVA = "0x3CB9BD4", Offset = "0x3CB9BD4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal FrameController _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				FrameController instance = new FrameController();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010D7")]
		[Address(RVA = "0x3CB9A48", Offset = "0x3CB9A48", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2792;
			Func<Instancer, FrameController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					FrameController instance = new FrameController();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60010D8")]
		[Address(RVA = "0x3CB96DC", Offset = "0x3CB96DC", Length = "0x8")]
		public FrameControllerInstaller()
		{
		}
	}
}
