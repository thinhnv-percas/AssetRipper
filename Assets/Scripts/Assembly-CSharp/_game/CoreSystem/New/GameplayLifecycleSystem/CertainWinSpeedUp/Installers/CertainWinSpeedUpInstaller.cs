using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.CertainWinSpeedUp.Installers
{
	[Token(Token = "0x200042E")]
	public class CertainWinSpeedUpInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200042F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000D29")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000D2A")]
			public static Func<Instancer, CertainWinDetector> _003C_003E9__0_0;

			[Token(Token = "0x4000D2B")]
			public static Func<Instancer, CertainWinSpeedupBridge> _003C_003E9__0_1;

			[Token(Token = "0x4000D2C")]
			public static Func<Instancer, CertainWinSpeedUpBehavior> _003C_003E9__0_2;

			[Token(Token = "0x6001178")]
			[Address(RVA = "0x3CC1310", Offset = "0x3CC1310", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001179")]
			[Address(RVA = "0x3CC1374", Offset = "0x3CC1374", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal CertainWinDetector _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				CertainWinDetector instance = new CertainWinDetector();
				return x.InjectInstance(instance);
			}

			internal CertainWinSpeedupBridge _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				CertainWinSpeedupBridge instance = new CertainWinSpeedupBridge();
				return x.InjectInstance(instance);
			}

			internal CertainWinSpeedUpBehavior _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				CertainWinSpeedUpBehavior instance = new CertainWinSpeedUpBehavior();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6001176")]
		[Address(RVA = "0x3CC1050", Offset = "0x3CC1050", Length = "0x2C0")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2600;
			Func<Instancer, CertainWinDetector> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					CertainWinDetector instance = new CertainWinDetector();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 2616;
			Func<Instancer, CertainWinSpeedupBridge> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer x)
				{
					CertainWinSpeedupBridge instance = new CertainWinSpeedupBridge();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num3 = 187441152 + 2608;
			Func<Instancer, CertainWinSpeedUpBehavior> _003C_003E9__0_3 = _003C_003Ec._003C_003E9__0_2;
			if (_003C_003Ec._003C_003E9__0_2 == null)
			{
				_003C_003E9__0_3 = (_003C_003Ec._003C_003E9__0_2 = delegate(Instancer x)
				{
					CertainWinSpeedUpBehavior instance = new CertainWinSpeedUpBehavior();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001177")]
		[Address(RVA = "0x3CB11C8", Offset = "0x3CB11C8", Length = "0x8")]
		public CertainWinSpeedUpInstaller()
		{
		}
	}
}
