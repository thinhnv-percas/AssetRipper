using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Installers
{
	[Token(Token = "0x2000248")]
	public class TopGridCommonInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000249")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006F2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006F3")]
			public static Func<Instancer, GridData<SandCubeCellData>> _003C_003E9__1_0;

			[Token(Token = "0x40006F4")]
			public static Func<Instancer, TopGridReconcile_CoverSystem> _003C_003E9__1_2;

			[Token(Token = "0x40006F5")]
			public static Func<Instancer, TopGridReconcile_RevealSystem> _003C_003E9__1_3;

			[Token(Token = "0x40006F6")]
			public static Func<Instancer, TopGridReconcile_BlockerCheckSystem> _003C_003E9__1_4;

			[Token(Token = "0x40006F7")]
			public static Func<Instancer, SandReconcile_NeighborDirtySystem> _003C_003E9__1_5;

			[Token(Token = "0x40006F8")]
			public static Func<Instancer, TopGridReconcile_RespCleanupSystem> _003C_003E9__1_6;

			[Token(Token = "0x40006F9")]
			public static Func<Instancer, SandReconcile_PourableEvaluatorSystem> _003C_003E9__1_7;

			[Token(Token = "0x40006FA")]
			public static Func<Instancer, SandReconcile_GridReleaseSystem> _003C_003E9__1_8;

			[Token(Token = "0x40006FB")]
			public static Func<Instancer, SandReconcile_ParticleSpawnSystem> _003C_003E9__1_9;

			[Token(Token = "0x40006FC")]
			public static Func<Instancer, SandReconcile_CellStateSystem> _003C_003E9__1_10;

			[Token(Token = "0x40006FD")]
			public static Func<Instancer, SandReconcile_MaterialSystem> _003C_003E9__1_11;

			[Token(Token = "0x40006FE")]
			public static Func<Instancer, TopGridHandler> _003C_003E9__1_12;

			[Token(Token = "0x40006FF")]
			public static Func<Instancer, TopGridEntitySystemCreator> _003C_003E9__1_13;

			[Token(Token = "0x4000700")]
			public static Func<Instancer, NeighborsFullCondition> _003C_003E9__1_14;

			[Token(Token = "0x4000701")]
			public static Func<Instancer, HiddenBlockCondition> _003C_003E9__1_15;

			[Token(Token = "0x60009E2")]
			[Address(RVA = "0x3E9D5D0", Offset = "0x3E9D5D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Installers.TopGridCommonInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009E3")]
			[Address(RVA = "0x3E9D634", Offset = "0x3E9D634", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal GridData<SandCubeCellData> _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				bool flag = x.TryResolve<LevelCreatorData>(out var result);
				return result.sandCubeGrid;
			}

			internal TopGridReconcile_CoverSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				TopGridReconcile_CoverSystem instance = new TopGridReconcile_CoverSystem();
				return x.InjectInstance(instance);
			}

			internal TopGridReconcile_RevealSystem _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				TopGridReconcile_RevealSystem instance = new TopGridReconcile_RevealSystem();
				return x.InjectInstance(instance);
			}

			internal TopGridReconcile_BlockerCheckSystem _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				TopGridReconcile_BlockerCheckSystem instance = new TopGridReconcile_BlockerCheckSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_NeighborDirtySystem _003CInstallBindings_003Eb__1_5(Instancer x)
			{
				SandReconcile_NeighborDirtySystem instance = new SandReconcile_NeighborDirtySystem();
				return x.InjectInstance(instance);
			}

			internal TopGridReconcile_RespCleanupSystem _003CInstallBindings_003Eb__1_6(Instancer x)
			{
				TopGridReconcile_RespCleanupSystem instance = new TopGridReconcile_RespCleanupSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_PourableEvaluatorSystem _003CInstallBindings_003Eb__1_7(Instancer x)
			{
				SandReconcile_PourableEvaluatorSystem instance = new SandReconcile_PourableEvaluatorSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_GridReleaseSystem _003CInstallBindings_003Eb__1_8(Instancer x)
			{
				SandReconcile_GridReleaseSystem instance = new SandReconcile_GridReleaseSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_ParticleSpawnSystem _003CInstallBindings_003Eb__1_9(Instancer x)
			{
				SandReconcile_ParticleSpawnSystem instance = new SandReconcile_ParticleSpawnSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_CellStateSystem _003CInstallBindings_003Eb__1_10(Instancer x)
			{
				SandReconcile_CellStateSystem instance = new SandReconcile_CellStateSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_MaterialSystem _003CInstallBindings_003Eb__1_11(Instancer x)
			{
				SandReconcile_MaterialSystem instance = new SandReconcile_MaterialSystem();
				return x.InjectInstance(instance);
			}

			internal TopGridHandler _003CInstallBindings_003Eb__1_12(Instancer x)
			{
				TopGridHandler instance = new TopGridHandler();
				return x.InjectInstance(instance);
			}

			internal TopGridEntitySystemCreator _003CInstallBindings_003Eb__1_13(Instancer x)
			{
				TopGridEntitySystemCreator instance = new TopGridEntitySystemCreator();
				return x.InjectInstance(instance);
			}

			internal NeighborsFullCondition _003CInstallBindings_003Eb__1_14(Instancer x)
			{
				NeighborsFullCondition instance = new NeighborsFullCondition();
				return x.InjectInstance(instance);
			}

			internal HiddenBlockCondition _003CInstallBindings_003Eb__1_15(Instancer x)
			{
				HiddenBlockCondition instance = new HiddenBlockCondition();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x40006F1")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualGridController m_visualGridControllerPrefab;

		[Token(Token = "0x60009DF")]
		[Address(RVA = "0x3E9C510", Offset = "0x3E9C510", Length = "0xFF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00C0;\n\tgoto L_00DD;\nL_00EE:\n\tv108 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103);\n\tv121 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController>::.ctor(v121, this, Il2CppMethodInfo);\n\t// 248 NewArr v140 @ X0_v10 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0105;\nL_0105:\n\tv159 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController);\n\tv168 = v159 == 0;\n\tif (v168) goto L_0118;\n\tv239 = 0x21C11D0(v159, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v239 == 0;\n\tif (v243) goto L_04B1;\nL_0118:\n\tv140[0] = v159;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v121, v140);\n\tgoto L_0125;\nL_0125:\n\tv379 = 0xB2C2000 + 0xDA0;\n\tv374 = v372.<>9__1_2 == 0;\n\tif (v374) goto L_01D4;\n\tv391 = 0x3C7CEBC(containerBuilder, v372.<>9__1_2, *([v379 @ X22_v121 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0132;\nL_0132:\n\tv461 = 0xB2C2000 + 0xDB0;\n\tv441 = v439.<>9__1_3 == 0;\n\tif (v441) goto L_01FF;\n\tv478 = 0x3C7CEBC(containerBuilder, v439.<>9__1_3, *([v461 @ X22_v117 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_013F;\nL_013F:\n\tv561 = 0xB2C2000 + 0xD98;\n\tv540 = v538.<>9__1_4 == 0;\n\tif (v540) goto L_022A;\n\tv578 = 0x3C7CEBC(containerBuilder, v538.<>9__1_4, *([v561 @ X22_v113 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_014C;\nL_014C:\n\tv661 = 0xB2C2000 + 0xD28;\n\tv640 = v638.<>9__1_5 == 0;\n\tif (v640) goto L_0255;\n\tv678 = 0x3C7CEBC(containerBuilder, v638.<>9__1_5, *([v661 @ X22_v109 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0159;\nL_0159:\n\tv761 = 0xB2C2000 + 0xDA8;\n\tv740 = v738.<>9__1_6 == 0;\n\tif (v740) goto L_0280;\n\tv778 = 0x3C7CEBC(containerBuilder, v738.<>9__1_6, *([v761 @ X22_v105 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0166;\nL_0166:\n\tv861 = 0xB2C2000 + 0xD38;\n\tv840 = v838.<>9__1_7 == 0;\n\tif (v840) goto L_02AB;\n\tv878 = 0x3C7CEBC(containerBuilder, v838.<>9__1_7, *([v861 @ X22_v101 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0173;\nL_0173:\n\tv961 = 0xB2C2000 + 0xD18;\n\tv940 = v938.<>9__1_8 == 0;\n\tif (v940) goto L_02D6;\n\tv978 = 0x3C7CEBC(containerBuilder, v938.<>9__1_8, *([v961 @ X22_v97 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0180;\nL_0180:\n\tv1061 = 0xB2C2000 + 0xD30;\n\tv1040 = v1038.<>9__1_9 == 0;\n\tif (v1040) goto L_0301;\n\tv1078 = 0x3C7CEBC(containerBuilder, v1038.<>9__1_9, *([v1061 @ X22_v93 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_018D;\nL_018D:\n\tv1161 = 0xB2C2000 + 0xD10;\n\tv1140 = v1138.<>9__1_10 == 0;\n\tif (v1140) goto L_032C;\n\tv1178 = 0x3C7CEBC(containerBuilder, v1138.<>9__1_10, *([v1161 @ X22_v89 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_019A;\nL_019A:\n\tv1261 = 0xB2C2000 + 0xD20;\n\tv1240 = v1238.<>9__1_11 == 0;\n\tif (v1240) goto L_0357;\n\tv1278 = 0x3C7CEBC(containerBuilder, v1238.<>9__1_11, *([v1261 @ X22_v85 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01A7;\nL_01A7:\n\tv1361 = 0xB2C2000 + 0xD88;\n\tv1340 = v1338.<>9__1_12 == 0;\n\tif (v1340) goto L_0382;\n\tv1378 = 0x3C7CEBC(containerBuilder, v1338.<>9__1_12, *([v1361 @ X22_v81 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01B4;\nL_01B4:\n\t;\n\tv1440 = v1438.<>9__1_13 == 0;\n\tif (v1440) goto L_03AD;\n\tv1478 = _game.CoreSystem.New.TopGridSystem.Installers.TopGridCommonInstaller+<>c::<InstallBindings>b__1_14(containerBuilder, v1438.<>9__1_13);\n\tgoto L_01C1;\nL_01C1:\n\tv1563 = 0xB27D000 + 0xDD8;\n\tv230 = v1538.<>9__1_14;\n\tv1540 = v1538.<>9__1_14 == 0;\n\tv1541 = ~v1540;\n\tif (v1541) goto L_03F0;\n\tgoto L_03D8;\nL_01D4:\n\tgoto L_01DC;\n\tv515 = 0x3C7CEBC(containerBuilder, v416, *([v379 @ X22_v121 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0132;\nL_01FF:\n\tgoto L_0207;\n\tv615 = 0x3C7CEBC(containerBuilder, v513, *([v461 @ X22_v117 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_013F;\nL_022A:\n\tgoto L_0232;\n\tv715 = 0x3C7CEBC(containerBuilder, v613, *([v561 @ X22_v113 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_014C;\nL_0255:\n\tgoto L_025D;\n\tv815 = 0x3C7CEBC(containerBuilder, v713, *([v661 @ X22_v109 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0159;\nL_0280:\n\tgoto L_0288;\n\tv915 = 0x3C7CEBC(containerBuilder, v813, *([v761 @ X22_v105 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0166;\nL_02AB:\n\tgoto L_02B3;\n\tv1015 = 0x3C7CEBC(containerBuilder, v913, *([v861 @ X22_v101 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0173;\nL_02D6:\n\tgoto L_02DE;\n\tv1115 = 0x3C7CEBC(containerBuilder, v1013, *([v961 @ X22_v97 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0180;\nL_0301:\n\tgoto L_0309;\n\tv1215 = 0x3C7CEBC(containerBuilder, v1113, *([v1061 @ X22_v93 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_018D;\nL_032C:\n\tgoto L_0334;\n\tv1315 = 0x3C7CEBC(containerBuilder, v1213, *([v1161 @ X22_v\n// ... truncated")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridCommonInstaller::InstallBindings");
		}

		[Token(Token = "0x60009E0")]
		[Address(RVA = "0x3E9D504", Offset = "0x3E9D504", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TopGridCommonInstaller()
		{
		}
	}
}
