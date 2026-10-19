using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp.Installers
{
	[Token(Token = "0x20003FB")]
	public class TapHoldSpeedUpInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003FC")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CA2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CA3")]
			public static Func<Instancer, TapHoldSpeedUpBehavior> _003C_003E9__0_0;

			[Token(Token = "0x4000CA4")]
			public static Func<Instancer, TapHoldSpeedUpBridge> _003C_003E9__0_1;

			[Token(Token = "0x60010C2")]
			[Address(RVA = "0x3CB8304", Offset = "0x3CB8304", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010C3")]
			[Address(RVA = "0x3CB8368", Offset = "0x3CB8368", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal TapHoldSpeedUpBehavior _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				TapHoldSpeedUpBehavior instance = new TapHoldSpeedUpBehavior();
				return x.InjectInstance(instance);
			}

			internal TapHoldSpeedUpBridge _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				TapHoldSpeedUpBridge instance = new TapHoldSpeedUpBridge();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010C0")]
		[Address(RVA = "0x3CB8110", Offset = "0x3CB8110", Length = "0x1F4")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3424;
			Func<Instancer, TapHoldSpeedUpBehavior> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					TapHoldSpeedUpBehavior instance = new TapHoldSpeedUpBehavior();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 3432;
			Func<Instancer, TapHoldSpeedUpBridge> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer x)
				{
					TapHoldSpeedUpBridge instance = new TapHoldSpeedUpBridge();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60010C1")]
		[Address(RVA = "0x3CB11D0", Offset = "0x3CB11D0", Length = "0x8")]
		public TapHoldSpeedUpInstaller()
		{
		}
	}
}
