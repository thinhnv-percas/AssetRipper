using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.SandSystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.EditMode
{
	[Token(Token = "0x20001D4")]
	public class LinkedCubeInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001D5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40005A6")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40005A7")]
			public static Func<Instancer, LinkedCubeVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x40005A8")]
			public static Func<Instancer, SandReconcile_LinkedBreakSystem> _003C_003E9__1_1;

			[Token(Token = "0x40005A9")]
			public static Func<Instancer, LinkedCubeEditorMutations> _003C_003E9__1_2;

			[Token(Token = "0x40005AA")]
			public static Func<Instancer, LinkedCubeRemoveHook> _003C_003E9__1_3;

			[Token(Token = "0x6000864")]
			[Address(RVA = "0x3E7B370", Offset = "0x3E7B370", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.EditMode.LinkedCubeInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000865")]
			[Address(RVA = "0x3E7B3D4", Offset = "0x3E7B3D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal LinkedCubeVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal SandReconcile_LinkedBreakSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_LinkedBreakSystem instance = new SandReconcile_LinkedBreakSystem();
				return x.InjectInstance(instance);
			}

			internal LinkedCubeEditorMutations _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				LinkedCubeEditorMutations instance = new LinkedCubeEditorMutations();
				return x.InjectInstance(instance);
			}

			internal LinkedCubeRemoveHook _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_3");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x40005A5")]
		[FieldOffset(Offset = "0x18")]
		private LinkedCubeConfig m_config;

		[Token(Token = "0x6000862")]
		[Address(RVA = "0x3E7ACE0", Offset = "0x3E7ACE0", Length = "0x688")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0057;\n\tgoto L_0073;\nL_0083:\n\t// 131 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0090;\nL_0090:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00A1;\n\tv239 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v239 == 0;\n\tif (v243) goto L_0204;\nL_00A1:\n\tv103[0] = v134;\n\tv389 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler);\n\tv393 = v389 == 0;\n\tif (v393) goto L_00BB;\n\tv368 = 0x21C11D0(v389, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v368 == 0;\n\tif (v374) goto L_0204;\nL_00BB:\n\tv103[1] = v389;\n\tv413 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv417 = v413 == 0;\n\tif (v417) goto L_00DB;\n\tv369 = 0x21C11D0(v413, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v369 == 0;\n\tif (v375) goto L_0204;\nL_00DB:\n\tv103[2] = v413;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00E8;\nL_00E8:\n\tv453 = 0xB27E000 + 0x720;\n\tv230 = v447.<>9__1_1;\n\tv449 = v447.<>9__1_1 == 0;\n\tv450 = ~v449;\n\tif (v450) goto L_0113;\n\tgoto L_00FB;\nL_00FB:\n\tgoto L_0103;\nL_0113:\n\t// 275 NewArr v476 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0120;\n\tv506 = v212 == 0;\n\tif (v506) goto L_0133;\n\tv370 = 0x21C11D0(v212, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v370 == 0;\n\tif (v376) goto L_0204;\nL_0133:\n\tv476[0] = v212;\n\tv517 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv518 = v517 == 0;\n\tif (v518) goto L_014D;\n\tv371 = 0x21C11D0(v517, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v371 == 0;\n\tif (v377) goto L_0204;\nL_014D:\n\tv476[1] = v517;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v230, v476);\n\tgoto L_015A;\nL_015A:\n\t;\n\tv563 = v536.<>9__1_2;\n\tv538 = v536.<>9__1_2 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_0186;\n\tgoto L_016D;\nL_016D:\n\tgoto L_0175;\nL_0186:\n\tv569 = _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.EditMode.LinkedCubeInstaller_EditMode+<>c::<InstallBindings>b__1_3(containerBuilder, v563);\n\tgoto L_018C;\nL_018C:\n\tv600 = 0xB27D000 + 0x9C0;\n\tv231 = v590.<>9__1_3;\n\tv592 = v590.<>9__1_3 == 0;\n\tv593 = ~v592;\n\tif (v593) goto L_01B7;\n\tgoto L_019F;\nL_019F:\n\tgoto L_01A7;\nL_01B7:\n\t// 439 NewArr v622 @ X0_v61 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01C2;\nL_01C2:\n\tv213 = System.Type::GetTypeFromHandle(*([v600 @ X22_v18 (System.Int32)]));\n\tv652 = v213 == 0;\n\tif (v652) goto L_01D5;\n\tv372 = 0x21C11D0(v213, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = v372 == 0;\n\tif (v378) goto L_0204;\nL_01D5:\n\tv622[0] = v213;\n\tv663 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv664 = v663 == 0;\n\tif (v664) goto L_01EF;\n\tv373 = 0x21C11D0(v663, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v373 == 0;\n\tif (v379) goto L_0204;\nL_01EF:\n\tv622[1] = v663;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v622);\n\treturn;\nL_0204:\n\tv386 = new System.ArrayTypeMismatchException();\n\tthrow v386;\nL_0057:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0064;\nL_0064:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0083;\nL_0073:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_0103:\n\tv494 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>::.ctor(v494, v489.<>9, Il2CppMethodInfo);\n\tv504.<>9__1_1 = v494;\n\tv230 = v494;\nL_0120:\n\tv212 = System.Type::GetTypeFromHandle(*([v453 @ X22_v29 (System.Int32)]));\nL_0175:\n\tv587 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeEditorMutations>::.ctor(v587, v582.<>9, Il2CppMethodInfo);\n\tv625.<>9__1_2 = v587;\n\tv563 = v587;\nL_01A7:\n\tv642 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeRemoveHook>::.ctor(v642, v637.<>9, Il2CppMethodInfo);\n\tv650.<>9__1_3 = v642;\n\tv231 = v642;\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x6000863")]
		[Address(RVA = "0x3E7B368", Offset = "0x3E7B368", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public LinkedCubeInstaller_EditMode()
		{
		}
	}
}
