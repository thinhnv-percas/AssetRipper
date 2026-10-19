using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers
{
	[Token(Token = "0x20001F4")]
	public class KeyAndLockInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001F5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400063F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000640")]
			public static Func<Instancer, KeyVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x4000641")]
			public static Func<Instancer, LockVisualHandler> _003C_003E9__1_1;

			[Token(Token = "0x4000642")]
			public static Func<Instancer, LockGroupHandler> _003C_003E9__1_2;

			[Token(Token = "0x4000643")]
			public static Func<Instancer, SandReconcile_UnlockSystem> _003C_003E9__1_3;

			[Token(Token = "0x4000644")]
			public static Func<Instancer, LockCondition> _003C_003E9__1_4;

			[Token(Token = "0x4000645")]
			public static Func<Instancer, LockTunnelSpawnHandler> _003C_003E9__1_5;

			[Token(Token = "0x4000646")]
			public static Func<Instancer, KeyTunnelSpawnHandler> _003C_003E9__1_6;

			[Token(Token = "0x60008EA")]
			[Address(RVA = "0x3E8A2C8", Offset = "0x3E8A2C8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.KeyAndLockInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60008EB")]
			[Address(RVA = "0x3E8A32C", Offset = "0x3E8A32C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal KeyVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				KeyVisualHandler instance = new KeyVisualHandler();
				return x.InjectInstance(instance);
			}

			internal LockVisualHandler _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				LockVisualHandler instance = new LockVisualHandler();
				return x.InjectInstance(instance);
			}

			internal LockGroupHandler _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				LockGroupHandler instance = new LockGroupHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_UnlockSystem _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SandReconcile_UnlockSystem instance = new SandReconcile_UnlockSystem();
				return x.InjectInstance(instance);
			}

			internal LockCondition _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				LockCondition instance = new LockCondition();
				return x.InjectInstance(instance);
			}

			internal LockTunnelSpawnHandler _003CInstallBindings_003Eb__1_5(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_5");
				return default;
			}

			internal KeyTunnelSpawnHandler _003CInstallBindings_003Eb__1_6(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_6");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x400063E")]
		[FieldOffset(Offset = "0x18")]
		private KeyAndLockConfig m_config;

		[Token(Token = "0x60008E8")]
		[Address(RVA = "0x3E896FC", Offset = "0x3E896FC", Length = "0xBC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0080;\n\tgoto L_009C;\nL_00AC:\n\t// 172 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_00B9;\nL_00B9:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00CA;\n\tv295 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = v295 == 0;\n\tif (v299) goto L_03A5;\nL_00CA:\n\tv107[0] = v138;\n\tv515 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler);\n\tv519 = v515 == 0;\n\tif (v519) goto L_00E4;\n\tv473 = 0x21C11D0(v515, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv486 = v473 == 0;\n\tif (v486) goto L_03A5;\nL_00E4:\n\tv107[1] = v515;\n\tv539 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv543 = v539 == 0;\n\tif (v543) goto L_0104;\n\tv474 = 0x21C11D0(v539, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv487 = v474 == 0;\n\tif (v487) goto L_03A5;\nL_0104:\n\tv107[2] = v539;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_0111;\nL_0111:\n\tv586 = 0xB27D000 + 0xA90;\n\tv283 = v578.<>9__1_1;\n\tv580 = v578.<>9__1_1 == 0;\n\tv581 = ~v580;\n\tif (v581) goto L_013C;\n\tgoto L_0124;\nL_0124:\n\tgoto L_012C;\nL_013C:\n\t// 316 NewArr v609 @ X0_v39 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0149;\n\tv651 = v255 == 0;\n\tif (v651) goto L_015A;\n\tv475 = 0x21C11D0(v255, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv488 = v475 == 0;\n\tif (v488) goto L_03A5;\nL_015A:\n\tv609[0] = v255;\n\tv670 = System.Type::GetTypeFromHandle(*([v586 @ X27_v10 (System.Int32)]));\n\tv674 = v670 == 0;\n\tif (v674) goto L_0172;\n\tv476 = 0x21C11D0(v670, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv489 = v476 == 0;\n\tif (v489) goto L_03A5;\nL_0172:\n\tv609[1] = v670;\n\tv692 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv693 = v692 == 0;\n\tif (v693) goto L_0192;\n\tv477 = 0x21C11D0(v692, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv490 = v477 == 0;\n\tif (v490) goto L_03A5;\nL_0192:\n\tv609[2] = v692;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v283, v609);\n\tgoto L_019F;\nL_019F:\n\t;\n\tv714 = v712.<>9__1_2 == 0;\n\tif (v714) goto L_01BF;\n\tv728 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.KeyAndLockInstaller+<>c::<InstallBindings>b__1_3(containerBuilder, v712.<>9__1_2);\n\tgoto L_01AC;\nL_01AC:\n\tv791 = 0xB27E000 + 0x768;\n\tv284 = v770.<>9__1_3;\n\tv772 = v770.<>9__1_3 == 0;\n\tv773 = ~v772;\n\tif (v773) goto L_0202;\n\tgoto L_01EA;\nL_01BF:\n\tgoto L_01C7;\n\tv836 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.KeyAndLockInstaller+<>c::<InstallBindings>b__1_3(containerBuilder, v750);\n\tgoto L_01AC;\nL_01EA:\n\tgoto L_01F2;\nL_0202:\n\t// 514 NewArr v814 @ X0_v63 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_020F;\n\tv857 = v256 == 0;\n\tif (v857) goto L_0222;\n\tv478 = 0x21C11D0(v256, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv491 = v478 == 0;\n\tif (v491) goto L_03A5;\nL_0222:\n\tv814[0] = v256;\n\tv868 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv869 = v868 == 0;\n\tif (v869) goto L_023C;\n\tv479 = 0x21C11D0(v868, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv492 = v479 == 0;\n\tif (v492) goto L_03A5;\nL_023C:\n\tv814[1] = v868;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v284, v814);\n\tgoto L_0249;\nL_0249:\n\tv893 = 0xB27D000 + 0xA60;\n\tv285 = v887.<>9__1_4;\n\tv889 = v887.<>9__1_4 == 0;\n\tv890 = ~v889;\n\tif (v890) goto L_0274;\n\tgoto L_025C;\nL_025C:\n\tgoto L_0264;\nL_0274:\n\t// 628 NewArr v916 @ X0_v81 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0281;\n\tv946 = v257 == 0;\n\tif (v946) goto L_0294;\n\tv480 = 0x21C11D0(v257, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv493 = v480 == 0;\n\tif (v493) goto L_03A5;\nL_0294:\n\tv916[0] = v257;\n\tv957 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv958 = v957 == 0;\n\tif (v958) goto L_02AE;\n\tv481 = 0x21C11D0(v957, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv494 = v481 == 0;\n\tif (v494) goto L_03A5;\nL_02AE:\n\tv916[1] = v957;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v285, v916);\n\tgoto L_02BB;\nL_02BB:\n\tv982 = 0xB27D000 + 0xA88;\n\tv286 = v976.<>9__1_5;\n\tv978 = v976.<>9__1_5 == 0;\n\tv979 = ~v978;\n\tif (v979) goto L_02E6;\n\tgoto L_02CE;\nL_02CE:\n\tgoto L_02D6;\nL_02E6:\n\t// 742 NewArr v1005 @ X0_v99 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_02F3;\n\tv1035 = v258 == 0;\n\tif (v1035) goto L_0306;\n\tv482 = 0x21C11D0(v258, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv495 = v482 == 0;\n\tif (v495) goto L_03A5;\nL_0306:\n\tv1005[0] = v258;\n\tv1046 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv1047 = v1046 == 0;\n\tif (v1047) goto L_0320;\n\tv483 = 0x21C11D0(v1046, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv496 = v483 == 0;\n\tif (v496) goto L_03A5;\nL_0320:\n\tv1005[1] = v1046;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v286, v1005);\n\tgoto L_032D;\nL_032D:\n\tv1071 = 0xB27D000 + 0x850;\n\tv287 = v1065.<>9__1_6;\n\tv1067 = v1065.<>9__1_6 == 0;\n\tv1068 = ~v1067;\n\tif (v1068) goto L_0358;\n\tgoto L_0340;\nL_0340:\n\tgoto L_0348;\nL_0358:\n\t// 856 NewArr v1093 @ X0_v117 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0363;\nL_0363:\n\tv259 = System.Type::GetTypeFromHandle(*([v1071 @ X22_v29 (System.Int32)]));\n\tv1121 = v259 == 0;\n\tif (v1121) goto L_0374;\n\tv484 = 0x21C11D0(v259, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv497 = v484 == 0;\n\tif (v497) goto L_03A5;\nL_0374:\n\tv1093[0] = v259;\n\tv1131 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv1132 = v1131 == 0;\n\tif (v1132) goto L_038E;\n\tv485 = 0x21C11D0(v1131, System.Type, clobbered_X2, clobbe\n// ... truncated")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller::InstallBindings");
		}

		[Token(Token = "0x60008E9")]
		[Address(RVA = "0x3E8A2C0", Offset = "0x3E8A2C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public KeyAndLockInstaller()
		{
		}
	}
}
