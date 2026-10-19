using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.HeadlessMode
{
	[Token(Token = "0x200022A")]
	public class GarageInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200022B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006C3")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006C4")]
			public static Func<Instancer, GarageGroupHandler> _003C_003E9__1_0;

			[Token(Token = "0x40006C5")]
			public static Func<Instancer, SandReconcile_GarageCounterSystem> _003C_003E9__1_1;

			[Token(Token = "0x40006C6")]
			public static Func<Instancer, GarageBlockCondition> _003C_003E9__1_2;

			[Token(Token = "0x600099D")]
			[Address(RVA = "0x3E985A0", Offset = "0x3E985A0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.HeadlessMode.GarageInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600099E")]
			[Address(RVA = "0x3E98604", Offset = "0x3E98604", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal GarageGroupHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				GarageGroupHandler instance = new GarageGroupHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_GarageCounterSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_GarageCounterSystem instance = new SandReconcile_GarageCounterSystem();
				return x.InjectInstance(instance);
			}

			internal GarageBlockCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GarageInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_2");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x40006C2")]
		[FieldOffset(Offset = "0x18")]
		private GarageConfig m_config;

		[Token(Token = "0x600099B")]
		[Address(RVA = "0x3E980F8", Offset = "0x3E980F8", Length = "0x4A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\nL_004E:\n\t;\n\tv99 = v68.<>9__1_0;\n\tv70 = v68.<>9__1_0 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_007A;\n\tgoto L_0061;\nL_0061:\n\tgoto L_0069;\nL_007A:\n\tv105 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.HeadlessMode.GarageInstaller_Headless+<>c::<InstallBindings>b__1_1(containerBuilder, v99);\n\tgoto L_0087;\n\tgoto L_0096;\nL_00A6:\n\t// 166 NewArr v170 @ X0_v11 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00B3;\nL_00B3:\n\tv203 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem);\n\tv214 = v203 == 0;\n\tif (v214) goto L_00C6;\n\tv273 = 0x21C11D0(v203, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv277 = v273 == 0;\n\tif (v277) goto L_0167;\nL_00C6:\n\tv170[0] = v203;\n\tv382 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv385 = v382 == 0;\n\tif (v385) goto L_00E0;\n\tv370 = 0x21C11D0(v382, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv373 = v370 == 0;\n\tif (v373) goto L_0167;\nL_00E0:\n\tv170[1] = v382;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v166, v170);\n\tgoto L_00ED;\nL_00ED:\n\tv415 = 0xB27C000 + 0xE98;\n\tv265 = v403.<>9__1_2;\n\tv405 = v403.<>9__1_2 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_0118;\n\tgoto L_0100;\nL_0100:\n\tgoto L_0108;\nL_0118:\n\t// 280 NewArr v432 @ X0_v37 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0125;\n\tv462 = v251 == 0;\n\tif (v462) goto L_0138;\n\tv371 = 0x21C11D0(v251, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v371 == 0;\n\tif (v374) goto L_0167;\nL_0138:\n\tv432[0] = v251;\n\tv473 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv474 = v473 == 0;\n\tif (v474) goto L_0152;\n\tv372 = 0x21C11D0(v473, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v372 == 0;\n\tif (v375) goto L_0167;\nL_0152:\n\tv432[1] = v473;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v265, v432);\n\treturn;\nL_0167:\n\tv379 = new System.ArrayTypeMismatchException();\n\tthrow v379;\nL_0048:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_004E;\nL_0069:\n\tv130 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.GarageGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.GarageGroupHandler>::.ctor(v130, v125.<>9, Il2CppMethodInfo);\n\tv174.<>9__1_0 = v130;\n\tv99 = v130;\nL_0087:\n\tv166 = v138.<>9__1_1;\n\tv140 = v138.<>9__1_1 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_00A6;\nL_0096:\n\tv183 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem>::.ctor(v183, v178.<>9, Il2CppMethodInfo);\n\tv207.<>9__1_1 = v183;\n\tv166 = v183;\nL_0108:\n\tv450 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions.GarageBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions.GarageBlockCondition>::.ctor(v450, v445.<>9, Il2CppMethodInfo);\n\tv460.<>9__1_2 = v450;\n\tv265 = v450;\nL_0125:\n\tv251 = System.Type::GetTypeFromHandle(*([v415 @ X22_v16 (System.Int32)]));\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x600099C")]
		[Address(RVA = "0x3E98598", Offset = "0x3E98598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public GarageInstaller_Headless()
		{
		}
	}
}
