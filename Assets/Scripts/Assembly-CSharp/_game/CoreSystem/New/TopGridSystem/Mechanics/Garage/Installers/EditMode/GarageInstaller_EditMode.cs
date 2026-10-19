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
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.EditMode
{
	[Token(Token = "0x200022C")]
	public class GarageInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200022D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006C8")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006C9")]
			public static Func<Instancer, GarageVisualHandler_Editor> _003C_003E9__1_0;

			[Token(Token = "0x40006CA")]
			public static Func<Instancer, GarageGroupHandler> _003C_003E9__1_1;

			[Token(Token = "0x40006CB")]
			public static Func<Instancer, SandReconcile_GarageCounterSystem> _003C_003E9__1_2;

			[Token(Token = "0x40006CC")]
			public static Func<Instancer, GarageBlockCondition> _003C_003E9__1_3;

			[Token(Token = "0x60009A4")]
			[Address(RVA = "0x3E98E88", Offset = "0x3E98E88", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.EditMode.GarageInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009A5")]
			[Address(RVA = "0x3E98EEC", Offset = "0x3E98EEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal GarageVisualHandler_Editor _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				GarageVisualHandler_Editor instance = new GarageVisualHandler_Editor();
				return x.InjectInstance(instance);
			}

			internal GarageGroupHandler _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				GarageGroupHandler instance = new GarageGroupHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_GarageCounterSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				SandReconcile_GarageCounterSystem instance = new SandReconcile_GarageCounterSystem();
				return x.InjectInstance(instance);
			}

			internal GarageBlockCondition _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GarageInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_3");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x40006C7")]
		[FieldOffset(Offset = "0x18")]
		private GarageConfig m_config;

		[Token(Token = "0x60009A2")]
		[Address(RVA = "0x3E987D0", Offset = "0x3E987D0", Length = "0x6B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005A;\n\tgoto L_0076;\nL_0086:\n\t// 134 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0093;\nL_0093:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00A6;\n\tv239 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v239 == 0;\n\tif (v243) goto L_020F;\nL_00A6:\n\tv103[0] = v134;\n\tv391 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageVisualHandler_Editor);\n\tv395 = v391 == 0;\n\tif (v395) goto L_00C0;\n\tv370 = 0x21C11D0(v391, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v370 == 0;\n\tif (v376) goto L_020F;\nL_00C0:\n\tv103[1] = v391;\n\tv415 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv419 = v415 == 0;\n\tif (v419) goto L_00E0;\n\tv371 = 0x21C11D0(v415, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v371 == 0;\n\tif (v377) goto L_020F;\nL_00E0:\n\tv103[2] = v415;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00ED;\nL_00ED:\n\t;\n\tv454 = v452.<>9__1_1 == 0;\n\tif (v454) goto L_010D;\n\tv468 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.EditMode.GarageInstaller_EditMode+<>c::<InstallBindings>b__1_2(containerBuilder, v452.<>9__1_1);\n\tgoto L_00FA;\nL_00FA:\n\tv531 = 0xB27E000 + 0x718;\n\tv230 = v510.<>9__1_2;\n\tv512 = v510.<>9__1_2 == 0;\n\tv513 = ~v512;\n\tif (v513) goto L_0150;\n\tgoto L_0138;\nL_010D:\n\tgoto L_0115;\n\tv576 = _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Installers.EditMode.GarageInstaller_EditMode+<>c::<InstallBindings>b__1_2(containerBuilder, v490);\n\tgoto L_00FA;\nL_0138:\n\tgoto L_0140;\nL_0150:\n\t// 336 NewArr v554 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_015D;\n\tv597 = v212 == 0;\n\tif (v597) goto L_0170;\n\tv372 = 0x21C11D0(v212, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = v372 == 0;\n\tif (v378) goto L_020F;\nL_0170:\n\tv554[0] = v212;\n\tv608 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv609 = v608 == 0;\n\tif (v609) goto L_018A;\n\tv373 = 0x21C11D0(v608, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v373 == 0;\n\tif (v379) goto L_020F;\nL_018A:\n\tv554[1] = v608;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v230, v554);\n\tgoto L_0197;\nL_0197:\n\tv633 = 0xB27C000 + 0xE98;\n\tv231 = v627.<>9__1_3;\n\tv629 = v627.<>9__1_3 == 0;\n\tv630 = ~v629;\n\tif (v630) goto L_01C2;\n\tgoto L_01AA;\nL_01AA:\n\tgoto L_01B2;\nL_01C2:\n\t// 450 NewArr v655 @ X0_v57 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01CD;\nL_01CD:\n\tv213 = System.Type::GetTypeFromHandle(*([v633 @ X22_v19 (System.Int32)]));\n\tv683 = v213 == 0;\n\tif (v683) goto L_01E0;\n\tv374 = 0x21C11D0(v213, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv380 = v374 == 0;\n\tif (v380) goto L_020F;\nL_01E0:\n\tv655[0] = v213;\n\tv694 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv695 = v694 == 0;\n\tif (v695) goto L_01FA;\n\tv375 = 0x21C11D0(v694, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv381 = v375 == 0;\n\tif (v381) goto L_020F;\nL_01FA:\n\tv655[1] = v694;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v655);\n\treturn;\nL_020F:\n\tv388 = new System.ArrayTypeMismatchException();\n\tthrow v388;\nL_005A:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0067;\nL_0067:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0086;\nL_0076:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageVisualHandler_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.EditMode.GarageVisualHandler_Editor>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_0115:\n\tv490 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.GarageGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.GarageGroupHandler>::.ctor(v490, v484.<>9, Il2CppMethodInfo);\n\tv558.<>9__1_1 = v490;\nL_0140:\n\tv584 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem>::.ctor(v584, v579.<>9, Il2CppMethodInfo);\n\tv595.<>9__1_2 = v584;\n\tv230 = v584;\nL_015D:\n\tv212 = System.Type::GetTypeFromHandle(*([v531 @ X22_v25 (System.Int32)]));\nL_01B2:\n\tv673 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions.GarageBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.Conditions.GarageBlockCondition>::.ctor(v673, v668.<>9, Il2CppMethodInfo);\n\tv681.<>9__1_3 = v673;\n\tv231 = v673;\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60009A3")]
		[Address(RVA = "0x3E98E80", Offset = "0x3E98E80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public GarageInstaller_EditMode()
		{
		}
	}
}
