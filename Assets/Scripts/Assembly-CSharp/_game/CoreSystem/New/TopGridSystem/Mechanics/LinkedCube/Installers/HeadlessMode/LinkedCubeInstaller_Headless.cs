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

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.HeadlessMode
{
	[Token(Token = "0x20001D2")]
	public class LinkedCubeInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001D3")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40005A1")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40005A2")]
			public static Func<Instancer, SandReconcile_LinkedBreakSystem> _003C_003E9__1_0;

			[Token(Token = "0x40005A3")]
			public static Func<Instancer, LinkedCubeEditorMutations> _003C_003E9__1_1;

			[Token(Token = "0x40005A4")]
			public static Func<Instancer, LinkedCubeRemoveHook> _003C_003E9__1_2;

			[Token(Token = "0x600085D")]
			[Address(RVA = "0x3E7A9DC", Offset = "0x3E7A9DC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.HeadlessMode.LinkedCubeInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600085E")]
			[Address(RVA = "0x3E7AA40", Offset = "0x3E7AA40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandReconcile_LinkedBreakSystem _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SandReconcile_LinkedBreakSystem instance = new SandReconcile_LinkedBreakSystem();
				return x.InjectInstance(instance);
			}

			internal LinkedCubeEditorMutations _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				LinkedCubeEditorMutations instance = new LinkedCubeEditorMutations();
				return x.InjectInstance(instance);
			}

			internal LinkedCubeRemoveHook _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_2");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x40005A0")]
		[FieldOffset(Offset = "0x18")]
		private LinkedCubeConfig m_config;

		[Token(Token = "0x600085B")]
		[Address(RVA = "0x3E7A520", Offset = "0x3E7A520", Length = "0x4B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tgoto L_0064;\nL_0074:\n\t// 116 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0081;\nL_0081:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem);\n\tv145 = v134 == 0;\n\tif (v145) goto L_0094;\n\tv204 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = v204 == 0;\n\tif (v208) goto L_016D;\nL_0094:\n\tv103[0] = v134;\n\tv313 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv317 = v313 == 0;\n\tif (v317) goto L_00AE;\n\tv301 = 0x21C11D0(v313, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv304 = v301 == 0;\n\tif (v304) goto L_016D;\nL_00AE:\n\tv103[1] = v313;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00BB;\nL_00BB:\n\t;\n\tv345 = v343.<>9__1_1 == 0;\n\tif (v345) goto L_00DB;\n\tv359 = _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.HeadlessMode.LinkedCubeInstaller_Headless+<>c::<InstallBindings>b__1_2(containerBuilder, v343.<>9__1_1);\n\tgoto L_00C8;\nL_00C8:\n\tv422 = 0xB27D000 + 0x9C0;\n\tv196 = v401.<>9__1_2;\n\tv403 = v401.<>9__1_2 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_011E;\n\tgoto L_0106;\nL_00DB:\n\tgoto L_00E3;\n\tv467 = _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.HeadlessMode.LinkedCubeInstaller_Headless+<>c::<InstallBindings>b__1_2(containerBuilder, v381);\n\tgoto L_00C8;\nL_0106:\n\tgoto L_010E;\nL_011E:\n\t// 286 NewArr v445 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_012B;\n\tv488 = v182 == 0;\n\tif (v488) goto L_013E;\n\tv302 = 0x21C11D0(v182, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv305 = v302 == 0;\n\tif (v305) goto L_016D;\nL_013E:\n\tv445[0] = v182;\n\tv499 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv500 = v499 == 0;\n\tif (v500) goto L_0158;\n\tv303 = 0x21C11D0(v499, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv306 = v303 == 0;\n\tif (v306) goto L_016D;\nL_0158:\n\tv445[1] = v499;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v196, v445);\n\treturn;\nL_016D:\n\tv310 = new System.ArrayTypeMismatchException();\n\tthrow v310;\nL_0048:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0055;\nL_0055:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0074;\nL_0064:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00E3:\n\tv381 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeEditorMutations>::.ctor(v381, v375.<>9, Il2CppMethodInfo);\n\tv449.<>9__1_1 = v381;\nL_010E:\n\tv475 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode.LinkedCubeRemoveHook>::.ctor(v475, v470.<>9, Il2CppMethodInfo);\n\tv486.<>9__1_2 = v475;\n\tv196 = v475;\nL_012B:\n\tv182 = System.Type::GetTypeFromHandle(*([v422 @ X22_v15 (System.Int32)]));\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x600085C")]
		[Address(RVA = "0x3E7A9D4", Offset = "0x3E7A9D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public LinkedCubeInstaller_Headless()
		{
		}
	}
}
