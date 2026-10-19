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

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.HeadlessMode
{
	[Token(Token = "0x200015B")]
	public class TunnelInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200015C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400045D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400045E")]
			public static Func<Instancer, SandReconcile_TunnelSystem> _003C_003E9__1_0;

			[Token(Token = "0x400045F")]
			public static Func<Instancer, TunnelRemoveHook> _003C_003E9__1_1;

			[Token(Token = "0x4000460")]
			public static Func<Instancer, TunnelSpawnAnimator_Editor> _003C_003E9__1_2;

			[Token(Token = "0x4000461")]
			public static Func<Instancer, SandCubeTunnelSpawnHandler> _003C_003E9__1_3;

			[Token(Token = "0x60006AD")]
			[Address(RVA = "0x3E53A08", Offset = "0x3E53A08", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.HeadlessMode.TunnelInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006AE")]
			[Address(RVA = "0x3E53A6C", Offset = "0x3E53A6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandReconcile_TunnelSystem _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SandReconcile_TunnelSystem instance = new SandReconcile_TunnelSystem();
				return x.InjectInstance(instance);
			}

			internal TunnelRemoveHook _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				TunnelRemoveHook instance = new TunnelRemoveHook();
				return x.InjectInstance(instance);
			}

			internal TunnelSpawnAnimator_Editor _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				TunnelSpawnAnimator_Editor instance = new TunnelSpawnAnimator_Editor();
				return x.InjectInstance(instance);
			}

			internal SandCubeTunnelSpawnHandler _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SandCubeTunnelSpawnHandler instance = new SandCubeTunnelSpawnHandler();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x400045C")]
		[FieldOffset(Offset = "0x18")]
		private TunnelConfig tunnelConfig;

		[Token(Token = "0x60006AB")]
		[Address(RVA = "0x3DBA6DC", Offset = "0x3DBA6DC", Length = "0x71C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005D;\n\tgoto L_0079;\nL_0089:\n\t// 137 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0096;\nL_0096:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00A9;\n\tv234 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv238 = v234 == 0;\n\tif (v238) goto L_022A;\nL_00A9:\n\tv103[0] = v134;\n\tv381 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv385 = v381 == 0;\n\tif (v385) goto L_00C3;\n\tv357 = 0x21C11D0(v381, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv364 = v357 == 0;\n\tif (v364) goto L_022A;\nL_00C3:\n\tv103[1] = v381;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00D0;\nL_00D0:\n\tv427 = 0xB27E000 + 0xF98;\n\tv224 = v418.<>9__1_1;\n\tv420 = v418.<>9__1_1 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_00FB;\n\tgoto L_00E3;\nL_00E3:\n\tgoto L_00EB;\nL_00FB:\n\t// 251 NewArr v450 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0108;\n\tv491 = v202 == 0;\n\tif (v491) goto L_011B;\n\tv358 = 0x21C11D0(v202, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv365 = v358 == 0;\n\tif (v365) goto L_022A;\nL_011B:\n\tv450[0] = v202;\n\tv502 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv503 = v502 == 0;\n\tif (v503) goto L_0135;\n\tv359 = 0x21C11D0(v502, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = v359 == 0;\n\tif (v366) goto L_022A;\nL_0135:\n\tv450[1] = v502;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v224, v450);\n\tgoto L_0142;\nL_0142:\n\tv527 = 0xB27E000 + 0xFA8;\n\tv225 = v521.<>9__1_2;\n\tv523 = v521.<>9__1_2 == 0;\n\tv524 = ~v523;\n\tif (v524) goto L_016D;\n\tgoto L_0155;\nL_0155:\n\tgoto L_015D;\nL_016D:\n\t// 365 NewArr v549 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0178;\nL_0178:\n\tv203 = System.Type::GetTypeFromHandle(*([v527 @ X22_v27 (System.Int32)]));\n\tv577 = v203 == 0;\n\tif (v577) goto L_018B;\n\tv360 = 0x21C11D0(v203, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv367 = v360 == 0;\n\tif (v367) goto L_022A;\nL_018B:\n\tv549[0] = v203;\n\tv588 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnAnimator);\n\tv589 = v588 == 0;\n\tif (v589) goto L_01A5;\n\tv361 = 0x21C11D0(v588, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv368 = v361 == 0;\n\tif (v368) goto L_022A;\nL_01A5:\n\tv549[1] = v588;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v225, v549);\n\tgoto L_01B2;\nL_01B2:\n\tv613 = 0xB27E000 + 0x6C0;\n\tv226 = v607.<>9__1_3;\n\tv609 = v607.<>9__1_3 == 0;\n\tv610 = ~v609;\n\tif (v610) goto L_01DD;\n\tgoto L_01C5;\nL_01C5:\n\tgoto L_01CD;\nL_01DD:\n\t// 477 NewArr v635 @ X0_v70 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01E8;\nL_01E8:\n\tv204 = System.Type::GetTypeFromHandle(*([v613 @ X22_v22 (System.Int32)]));\n\tv663 = v204 == 0;\n\tif (v663) goto L_01FB;\n\tv362 = 0x21C11D0(v204, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv369 = v362 == 0;\n\tif (v369) goto L_022A;\nL_01FB:\n\tv635[0] = v204;\n\tv674 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv675 = v674 == 0;\n\tif (v675) goto L_0215;\n\tv363 = 0x21C11D0(v674, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv370 = v363 == 0;\n\tif (v370) goto L_022A;\nL_0215:\n\tv635[1] = v674;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v226, v635);\n\treturn;\nL_022A:\n\tv378 = new System.ArrayTypeMismatchException();\n\tthrow v378;\nL_005D:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.tunnelConfig);\n\tgoto L_006A;\nL_006A:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0089;\nL_0079:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00EB:\n\tv474 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode.TunnelRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.EditMode.TunnelRemoveHook>::.ctor(v474, v469.<>9, Il2CppMethodInfo);\n\tv489.<>9__1_1 = v474;\n\tv224 = v474;\nL_0108:\n\tv202 = System.Type::GetTypeFromHandle(*([v427 @ X22_v33 (System.Int32)]));\nL_015D:\n\tv567 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnAnimator_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnAnimator_Editor>::.ctor(v567, v562.<>9, Il2CppMethodInfo);\n\tv575.<>9__1_2 = v567;\n\tv225 = v567;\nL_01CD:\n\tv653 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler>::.ctor(v653, v648.<>9, Il2CppMethodInfo);\n\tv661.<>9__1_3 = v653;\n\tv226 = v653;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x60006AC")]
		[Address(RVA = "0x3DBADF8", Offset = "0x3DBADF8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TunnelInstaller_Headless()
		{
		}
	}
}
