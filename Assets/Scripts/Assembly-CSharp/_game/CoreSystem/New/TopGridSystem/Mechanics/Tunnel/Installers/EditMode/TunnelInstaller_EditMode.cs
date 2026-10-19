using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.EditMode
{
	[Token(Token = "0x200015D")]
	public class TunnelInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200015E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000463")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000464")]
			public static Func<Instancer, TunnelVisualHandler_Editor> _003C_003E9__1_0;

			[Token(Token = "0x4000465")]
			public static Func<Instancer, SandReconcile_TunnelSystem> _003C_003E9__1_1;

			[Token(Token = "0x4000466")]
			public static Func<Instancer, TunnelRemoveHook> _003C_003E9__1_2;

			[Token(Token = "0x4000467")]
			public static Func<Instancer, TunnelSpawnAnimator_Editor> _003C_003E9__1_3;

			[Token(Token = "0x4000468")]
			public static Func<Instancer, SandCubeTunnelSpawnHandler> _003C_003E9__1_4;

			[Token(Token = "0x60006B5")]
			[Address(RVA = "0x3E545C4", Offset = "0x3E545C4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.EditMode.TunnelInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006B6")]
			[Address(RVA = "0x3E54628", Offset = "0x3E54628", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal TunnelVisualHandler_Editor _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				TunnelVisualHandler_Editor instance = new TunnelVisualHandler_Editor();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_TunnelSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_TunnelSystem instance = new SandReconcile_TunnelSystem();
				return x.InjectInstance(instance);
			}

			internal TunnelRemoveHook _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				TunnelRemoveHook instance = new TunnelRemoveHook();
				return x.InjectInstance(instance);
			}

			internal TunnelSpawnAnimator_Editor _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				TunnelSpawnAnimator_Editor instance = new TunnelSpawnAnimator_Editor();
				return x.InjectInstance(instance);
			}

			internal SandCubeTunnelSpawnHandler _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				SandCubeTunnelSpawnHandler instance = new SandCubeTunnelSpawnHandler();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000462")]
		[FieldOffset(Offset = "0x18")]
		private TunnelConfig tunnelConfig;

		[Token(Token = "0x60006B3")]
		[Address(RVA = "0x3E53CA4", Offset = "0x3E53CA4", Length = "0x918")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006F;\n\tgoto L_008B;\nL_009B:\n\t// 155 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_00A8;\nL_00A8:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00BB;\n\tv269 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv273 = v269 == 0;\n\tif (v273) goto L_02CC;\nL_00BB:\n\tv103[0] = v134;\n\tv459 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.EditMode.TunnelVisualHandler_Editor);\n\tv463 = v459 == 0;\n\tif (v463) goto L_00D5;\n\tv426 = 0x21C11D0(v459, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv436 = v426 == 0;\n\tif (v436) goto L_02CC;\nL_00D5:\n\tv103[1] = v459;\n\tv483 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv487 = v483 == 0;\n\tif (v487) goto L_00F5;\n\tv427 = 0x21C11D0(v483, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv437 = v427 == 0;\n\tif (v437) goto L_02CC;\nL_00F5:\n\tv103[2] = v483;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_0102;\nL_0102:\n\tv530 = 0xB27E000 + 0x760;\n\tv258 = v521.<>9__1_1;\n\tv523 = v521.<>9__1_1 == 0;\n\tv524 = ~v523;\n\tif (v524) goto L_012D;\n\tgoto L_0115;\nL_0115:\n\tgoto L_011D;\nL_012D:\n\t// 301 NewArr v553 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_013A;\n\tv595 = v232 == 0;\n\tif (v595) goto L_014D;\n\tv428 = 0x21C11D0(v232, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv438 = v428 == 0;\n\tif (v438) goto L_02CC;\nL_014D:\n\tv553[0] = v232;\n\tv611 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv612 = v611 == 0;\n\tif (v612) goto L_0167;\n\tv429 = 0x21C11D0(v611, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv439 = v429 == 0;\n\tif (v439) goto L_02CC;\nL_0167:\n\tv553[1] = v611;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v258, v553);\n\tgoto L_0174;\nL_0174:\n\tv636 = 0xB27E000 + 0xF98;\n\tv259 = v630.<>9__1_2;\n\tv632 = v630.<>9__1_2 == 0;\n\tv633 = ~v632;\n\tif (v633) goto L_019F;\n\tgoto L_0187;\nL_0187:\n\tgoto L_018F;\nL_019F:\n\t// 415 NewArr v658 @ X0_v57 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01AA;\nL_01AA:\n\tv233 = System.Type::GetTypeFromHandle(*([v636 @ X22_v37 (System.Int32)]));\n\tv686 = v233 == 0;\n\tif (v686) goto L_01BD;\n\tv430 = 0x21C11D0(v233, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv440 = v430 == 0;\n\tif (v440) goto L_02CC;\nL_01BD:\n\tv658[0] = v233;\n\tv697 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv698 = v697 == 0;\n\tif (v698) goto L_01D7;\n\tv431 = 0x21C11D0(v697, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv441 = v431 == 0;\n\tif (v441) goto L_02CC;\nL_01D7:\n\tv658[1] = v697;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v259, v658);\n\tgoto L_01E4;\nL_01E4:\n\tv722 = 0xB27E000 + 0xFA8;\n\tv260 = v716.<>9__1_3;\n\tv718 = v716.<>9__1_3 == 0;\n\tv719 = ~v718;\n\tif (v719) goto L_020F;\n\tgoto L_01F7;\nL_01F7:\n\tgoto L_01FF;\nL_020F:\n\t// 527 NewArr v744 @ X0_v76 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_021A;\nL_021A:\n\tv234 = System.Type::GetTypeFromHandle(*([v722 @ X22_v32 (System.Int32)]));\n\tv772 = v234 == 0;\n\tif (v772) goto L_022D;\n\tv432 = 0x21C11D0(v234, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv442 = v432 == 0;\n\tif (v442) goto L_02CC;\nL_022D:\n\tv744[0] = v234;\n\tv783 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnAnimator);\n\tv784 = v783 == 0;\n\tif (v784) goto L_0247;\n\tv433 = 0x21C11D0(v783, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv443 = v433 == 0;\n\tif (v443) goto L_02CC;\nL_0247:\n\tv744[1] = v783;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v260, v744);\n\tgoto L_0254;\nL_0254:\n\tv808 = 0xB27E000 + 0x6C0;\n\tv261 = v802.<>9__1_4;\n\tv804 = v802.<>9__1_4 == 0;\n\tv805 = ~v804;\n\tif (v805) goto L_027F;\n\tgoto L_0267;\nL_0267:\n\tgoto L_026F;\nL_027F:\n\t// 639 NewArr v830 @ X0_v95 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_028A;\nL_028A:\n\tv235 = System.Type::GetTypeFromHandle(*([v808 @ X22_v27 (System.Int32)]));\n\tv858 = v235 == 0;\n\tif (v858) goto L_029D;\n\tv434 = 0x21C11D0(v235, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv444 = v434 == 0;\n\tif (v444) goto L_02CC;\nL_029D:\n\tv830[0] = v235;\n\tv869 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv870 = v869 == 0;\n\tif (v870) goto L_02B7;\n\tv435 = 0x21C11D0(v869, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv445 = v435 == 0;\n\tif (v445) goto L_02CC;\nL_02B7:\n\tv830[1] = v869;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v261, v830);\n\treturn;\nL_02CC:\n\tv456 = new System.ArrayTypeMismatchException();\n\tthrow v456;\nL_006F:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.tunnelConfig);\n\tgoto L_007C;\nL_007C:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_009B;\nL_008B:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.EditMode.TunnelVisualHandler_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.EditMode.TunnelVisualHandler_Editor>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_011D:\n\tv577 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>::.ctor(v577, v572.<>9, Il2CppMethodInfo);\n\tv593.<>9__1_1 = v577;\n\tv258 = v577;\nL_013A:\n\tv232 = System.Type::GetTypeFromHandle(*([v530 @ X22_v43 (System.Int32)]));\nL_018F:\n\tv676 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode.TunnelRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode.TunnelRemoveHook>::.ctor(v676, v671.<>9, \n// ... truncated")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60006B4")]
		[Address(RVA = "0x3E545BC", Offset = "0x3E545BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TunnelInstaller_EditMode()
		{
		}
	}
}
