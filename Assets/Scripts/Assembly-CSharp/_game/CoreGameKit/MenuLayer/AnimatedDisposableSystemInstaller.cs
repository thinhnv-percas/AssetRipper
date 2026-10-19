using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.BaseLayer.Runtime;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005D4")]
	internal class AnimatedDisposableSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005D5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400143B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400143C")]
			public static Func<Instancer, AnimatedDisposeController> _003C_003E9__0_0;

			[Token(Token = "0x6001920")]
			[Address(RVA = "0x3D452D8", Offset = "0x3D452D8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001921")]
			[Address(RVA = "0x3D4533C", Offset = "0x3D4533C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal AnimatedDisposeController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				AnimatedDisposeController instance = new AnimatedDisposeController();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x600191E")]
		[Address(RVA = "0x3D451A8", Offset = "0x3D451A8", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2560;
			Func<Instancer, AnimatedDisposeController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					AnimatedDisposeController instance = new AnimatedDisposeController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600191F")]
		[Address(RVA = "0x3D452D0", Offset = "0x3D452D0", Length = "0x8")]
		public AnimatedDisposableSystemInstaller()
		{
		}
	}
}
