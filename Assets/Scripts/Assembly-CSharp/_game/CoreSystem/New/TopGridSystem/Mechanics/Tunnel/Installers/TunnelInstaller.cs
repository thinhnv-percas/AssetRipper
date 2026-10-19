using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers
{
	[Token(Token = "0x2000159")]
	public class TunnelInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200015A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000457")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000458")]
			public static Func<Instancer, TunnelVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x4000459")]
			public static Func<Instancer, SandReconcile_TunnelSystem> _003C_003E9__1_1;

			[Token(Token = "0x400045A")]
			public static Func<Instancer, TunnelSpawnAnimator> _003C_003E9__1_2;

			[Token(Token = "0x400045B")]
			public static Func<Instancer, SandCubeTunnelSpawnHandler> _003C_003E9__1_3;

			[Token(Token = "0x60006A5")]
			[Address(RVA = "0x3DBA450", Offset = "0x3DBA450", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.Installers.TunnelInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006A6")]
			[Address(RVA = "0x3DBA4B4", Offset = "0x3DBA4B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal TunnelVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				TunnelVisualHandler instance = new TunnelVisualHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_TunnelSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_TunnelSystem instance = new SandReconcile_TunnelSystem();
				return x.InjectInstance(instance);
			}

			internal TunnelSpawnAnimator _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				TunnelSpawnAnimator instance = new TunnelSpawnAnimator();
				return x.InjectInstance(instance);
			}

			internal SandCubeTunnelSpawnHandler _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SandCubeTunnelSpawnHandler instance = new SandCubeTunnelSpawnHandler();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000456")]
		[FieldOffset(Offset = "0x18")]
		private TunnelConfig tunnelConfig;

		[Token(Token = "0x60006A3")]
		[Address(RVA = "0x3DB9CE8", Offset = "0x3DB9CE8", Length = "0x760")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005D;\n\tgoto L_0079;\nL_0089:\n\t// 137 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0096;\nL_0096:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00A7;\n\tv254 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv258 = v254 == 0;\n\tif (v258) goto L_0248;\nL_00A7:\n\tv103[0] = v134;\n\tv423 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler);\n\tv427 = v423 == 0;\n\tif (v427) goto L_00C1;\n\tv396 = 0x21C11D0(v423, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv404 = v396 == 0;\n\tif (v404) goto L_0248;\nL_00C1:\n\tv103[1] = v423;\n\tv447 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv451 = v447 == 0;\n\tif (v451) goto L_00E1;\n\tv397 = 0x21C11D0(v447, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv405 = v397 == 0;\n\tif (v405) goto L_0248;\nL_00E1:\n\tv103[2] = v447;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00EE;\nL_00EE:\n\tv493 = 0xB27E000 + 0x760;\n\tv244 = v485.<>9__1_1;\n\tv487 = v485.<>9__1_1 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_0119;\n\tgoto L_0101;\nL_0101:\n\tgoto L_0109;\nL_0119:\n\t// 281 NewArr v516 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0126;\n\tv546 = v222 == 0;\n\tif (v546) goto L_0139;\n\tv398 = 0x21C11D0(v222, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv406 = v398 == 0;\n\tif (v406) goto L_0248;\nL_0139:\n\tv516[0] = v222;\n\tv557 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv558 = v557 == 0;\n\tif (v558) goto L_0153;\n\tv399 = 0x21C11D0(v557, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv407 = v399 == 0;\n\tif (v407) goto L_0248;\nL_0153:\n\tv516[1] = v557;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v244, v516);\n\tgoto L_0160;\nL_0160:\n\tv582 = 0xB27E000 + 0xFA0;\n\tv245 = v576.<>9__1_2;\n\tv578 = v576.<>9__1_2 == 0;\n\tv579 = ~v578;\n\tif (v579) goto L_018B;\n\tgoto L_0173;\nL_0173:\n\tgoto L_017B;\nL_018B:\n\t// 395 NewArr v604 @ X0_v57 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0196;\nL_0196:\n\tv223 = System.Type::GetTypeFromHandle(*([v582 @ X22_v26 (System.Int32)]));\n\tv632 = v223 == 0;\n\tif (v632) goto L_01A9;\n\tv400 = 0x21C11D0(v223, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv408 = v400 == 0;\n\tif (v408) goto L_0248;\nL_01A9:\n\tv604[0] = v223;\n\tv643 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnAnimator);\n\tv644 = v643 == 0;\n\tif (v644) goto L_01C3;\n\tv401 = 0x21C11D0(v643, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv409 = v401 == 0;\n\tif (v409) goto L_0248;\nL_01C3:\n\tv604[1] = v643;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v245, v604);\n\tgoto L_01D0;\nL_01D0:\n\tv668 = 0xB27E000 + 0x6C0;\n\tv246 = v662.<>9__1_3;\n\tv664 = v662.<>9__1_3 == 0;\n\tv665 = ~v664;\n\tif (v665) goto L_01FB;\n\tgoto L_01E3;\nL_01E3:\n\tgoto L_01EB;\nL_01FB:\n\t// 507 NewArr v690 @ X0_v76 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0206;\nL_0206:\n\tv224 = System.Type::GetTypeFromHandle(*([v668 @ X22_v21 (System.Int32)]));\n\tv718 = v224 == 0;\n\tif (v718) goto L_0219;\n\tv402 = 0x21C11D0(v224, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv410 = v402 == 0;\n\tif (v410) goto L_0248;\nL_0219:\n\tv690[0] = v224;\n\tv729 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv730 = v729 == 0;\n\tif (v730) goto L_0233;\n\tv403 = 0x21C11D0(v729, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv411 = v403 == 0;\n\tif (v411) goto L_0248;\nL_0233:\n\tv690[1] = v729;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v246, v690);\n\treturn;\nL_0248:\n\tv420 = new System.ArrayTypeMismatchException();\n\tthrow v420;\nL_005D:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.tunnelConfig);\n\tgoto L_006A;\nL_006A:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0089;\nL_0079:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_0109:\n\tv534 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem>::.ctor(v534, v529.<>9, Il2CppMethodInfo);\n\tv544.<>9__1_1 = v534;\n\tv244 = v534;\nL_0126:\n\tv222 = System.Type::GetTypeFromHandle(*([v493 @ X22_v32 (System.Int32)]));\nL_017B:\n\tv622 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnAnimator>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.TunnelSpawnAnimator>::.ctor(v622, v617.<>9, Il2CppMethodInfo);\n\tv630.<>9__1_2 = v622;\n\tv245 = v622;\nL_01EB:\n\tv708 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.SandCubeTunnelSpawnHandler>::.ctor(v708, v703.<>9, Il2CppMethodInfo);\n\tv716.<>9__1_3 = v708;\n\tv246 = v708;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelInstaller::InstallBindings");
		}

		[Token(Token = "0x60006A4")]
		[Address(RVA = "0x3DBA448", Offset = "0x3DBA448", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TunnelInstaller()
		{
		}
	}
}
