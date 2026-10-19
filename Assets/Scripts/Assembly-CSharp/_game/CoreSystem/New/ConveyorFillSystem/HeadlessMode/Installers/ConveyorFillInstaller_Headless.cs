using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Core;

namespace _game.CoreSystem.New.ConveyorFillSystem.HeadlessMode.Installers
{
	[Token(Token = "0x2000436")]
	public class ConveyorFillInstaller_Headless : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000437")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000D39")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000D3A")]
			public static Func<Instancer, ConveyorUnitSpawnSystem_Headless> _003C_003E9__0_0;

			[Token(Token = "0x4000D3B")]
			public static Func<Instancer, ConveyorOccupancySystem_Headless> _003C_003E9__0_1;

			[Token(Token = "0x4000D3C")]
			public static Func<Instancer, MoldFillFromUnitsSystem_Headless> _003C_003E9__0_2;

			[Token(Token = "0x4000D3D")]
			public static Func<Instancer, ConveyorTerminalSystem_Headless> _003C_003E9__0_3;

			[Token(Token = "0x6001198")]
			[Address(RVA = "0x3CC2B40", Offset = "0x3CC2B40", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001199")]
			[Address(RVA = "0x3CC2BA4", Offset = "0x3CC2BA4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal ConveyorUnitSpawnSystem_Headless _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				ConveyorUnitSpawnSystem_Headless instance = new ConveyorUnitSpawnSystem_Headless();
				return x.InjectInstance(instance);
			}

			internal ConveyorOccupancySystem_Headless _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				ConveyorOccupancySystem_Headless instance = new ConveyorOccupancySystem_Headless();
				return x.InjectInstance(instance);
			}

			internal MoldFillFromUnitsSystem_Headless _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				MoldFillFromUnitsSystem_Headless instance = new MoldFillFromUnitsSystem_Headless();
				return x.InjectInstance(instance);
			}

			internal ConveyorTerminalSystem_Headless _003CInstallBindings_003Eb__0_3(Instancer x)
			{
				ConveyorTerminalSystem_Headless instance = new ConveyorTerminalSystem_Headless();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6001196")]
		[Address(RVA = "0x3CC27B4", Offset = "0x3CC27B4", Length = "0x38C")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2640;
			Func<Instancer, ConveyorUnitSpawnSystem_Headless> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					ConveyorUnitSpawnSystem_Headless instance = new ConveyorUnitSpawnSystem_Headless();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 2624;
			Func<Instancer, ConveyorOccupancySystem_Headless> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer x)
				{
					ConveyorOccupancySystem_Headless instance = new ConveyorOccupancySystem_Headless();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num3 = 187441152 + 3136;
			Func<Instancer, MoldFillFromUnitsSystem_Headless> _003C_003E9__0_3 = _003C_003Ec._003C_003E9__0_2;
			if (_003C_003Ec._003C_003E9__0_2 == null)
			{
				_003C_003E9__0_3 = (_003C_003Ec._003C_003E9__0_2 = delegate(Instancer x)
				{
					MoldFillFromUnitsSystem_Headless instance = new MoldFillFromUnitsSystem_Headless();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num4 = 187441152 + 2632;
			Func<Instancer, ConveyorTerminalSystem_Headless> _003C_003E9__0_4 = _003C_003Ec._003C_003E9__0_3;
			if (_003C_003Ec._003C_003E9__0_3 == null)
			{
				_003C_003E9__0_4 = (_003C_003Ec._003C_003E9__0_3 = delegate(Instancer x)
				{
					ConveyorTerminalSystem_Headless instance = new ConveyorTerminalSystem_Headless();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001197")]
		[Address(RVA = "0x3CB96EC", Offset = "0x3CB96EC", Length = "0x8")]
		public ConveyorFillInstaller_Headless()
		{
		}
	}
}
