using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.EditMode
{
	[Token(Token = "0x20001F8")]
	public class KeyAndLockInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001F9")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000650")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000651")]
			public static Func<Instancer, KeyVisualHandler_Editor> _003C_003E9__1_0;

			[Token(Token = "0x4000652")]
			public static Func<Instancer, LockVisualHandler_Editor> _003C_003E9__1_1;

			[Token(Token = "0x4000653")]
			public static Func<Instancer, LockGroupHandler> _003C_003E9__1_2;

			[Token(Token = "0x4000654")]
			public static Func<Instancer, SandReconcile_UnlockSystem> _003C_003E9__1_3;

			[Token(Token = "0x4000655")]
			public static Func<Instancer, LockCondition> _003C_003E9__1_4;

			[Token(Token = "0x4000656")]
			public static Func<Instancer, LockRemoveHook> _003C_003E9__1_5;

			[Token(Token = "0x4000657")]
			public static Func<Instancer, LockTunnelSpawnHandler> _003C_003E9__1_6;

			[Token(Token = "0x4000658")]
			public static Func<Instancer, KeyTunnelSpawnHandler> _003C_003E9__1_7;

			[Token(Token = "0x60008FF")]
			[Address(RVA = "0x3E8C1BC", Offset = "0x3E8C1BC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.EditMode.KeyAndLockInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000900")]
			[Address(RVA = "0x3E8C220", Offset = "0x3E8C220", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal KeyVisualHandler_Editor _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				KeyVisualHandler_Editor instance = new KeyVisualHandler_Editor();
				return x.InjectInstance(instance);
			}

			internal LockVisualHandler_Editor _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				LockVisualHandler_Editor instance = (LockVisualHandler_Editor)new LockVisualHandler();
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

			internal LockRemoveHook _003CInstallBindings_003Eb__1_5(Instancer x)
			{
				LockRemoveHook instance = new LockRemoveHook();
				return x.InjectInstance(instance);
			}

			internal LockTunnelSpawnHandler _003CInstallBindings_003Eb__1_6(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_6");
				return default;
			}

			internal KeyTunnelSpawnHandler _003CInstallBindings_003Eb__1_7(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_7");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x400064F")]
		[FieldOffset(Offset = "0x18")]
		private KeyAndLockConfig m_config;

		[Token(Token = "0x60008FD")]
		[Address(RVA = "0x3E8B41C", Offset = "0x3E8B41C", Length = "0xD98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0095;\n\tgoto L_00B1;\nL_00C1:\n\t// 193 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_00CE;\nL_00CE:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.KeyVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00E1;\n\tv311 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv315 = v311 == 0;\n\tif (v315) goto L_0430;\nL_00E1:\n\tv107[0] = v138;\n\tv552 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.EditMode.KeyVisualHandler_Editor);\n\tv556 = v552 == 0;\n\tif (v556) goto L_00FB;\n\tv504 = 0x21C11D0(v552, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv519 = v504 == 0;\n\tif (v519) goto L_0430;\nL_00FB:\n\tv107[1] = v552;\n\tv576 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv580 = v576 == 0;\n\tif (v580) goto L_011B;\n\tv505 = 0x21C11D0(v576, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv520 = v505 == 0;\n\tif (v520) goto L_0430;\nL_011B:\n\tv107[2] = v576;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_0128;\nL_0128:\n\tv623 = 0xB27D000 + 0xA90;\n\tv298 = v614.<>9__1_1;\n\tv616 = v614.<>9__1_1 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_0153;\n\tgoto L_013B;\nL_013B:\n\tgoto L_0143;\nL_0153:\n\t// 339 NewArr v646 @ X0_v39 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0160;\n\tv688 = v266 == 0;\n\tif (v688) goto L_0173;\n\tv506 = 0x21C11D0(v266, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv521 = v506 == 0;\n\tif (v521) goto L_0430;\nL_0173:\n\tv646[0] = v266;\n\tv708 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.EditMode.LockVisualHandler_Editor);\n\tv712 = v708 == 0;\n\tif (v712) goto L_018B;\n\tv507 = 0x21C11D0(v708, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv522 = v507 == 0;\n\tif (v522) goto L_0430;\nL_018B:\n\tv646[1] = v708;\n\tv731 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv735 = v731 == 0;\n\tif (v735) goto L_01AB;\n\tv508 = 0x21C11D0(v731, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv523 = v508 == 0;\n\tif (v523) goto L_0430;\nL_01AB:\n\tv646[2] = v731;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v298, v646);\n\tgoto L_01B8;\nL_01B8:\n\t;\n\tv771 = v769.<>9__1_2 == 0;\n\tif (v771) goto L_01D8;\n\tv787 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.EditMode.KeyAndLockInstaller_EditMode+<>c::<InstallBindings>b__1_3(containerBuilder, v769.<>9__1_2);\n\tgoto L_01C5;\nL_01C5:\n\tv850 = 0xB27E000 + 0x768;\n\tv299 = v829.<>9__1_3;\n\tv831 = v829.<>9__1_3 == 0;\n\tv832 = ~v831;\n\tif (v832) goto L_021B;\n\tgoto L_0203;\nL_01D8:\n\tgoto L_01E0;\n\tv895 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.EditMode.KeyAndLockInstaller_EditMode+<>c::<InstallBindings>b__1_3(containerBuilder, v809);\n\tgoto L_01C5;\nL_0203:\n\tgoto L_020B;\nL_021B:\n\t// 539 NewArr v873 @ X0_v63 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0228;\n\tv916 = v267 == 0;\n\tif (v916) goto L_023B;\n\tv509 = 0x21C11D0(v267, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv524 = v509 == 0;\n\tif (v524) goto L_0430;\nL_023B:\n\tv873[0] = v267;\n\tv927 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv928 = v927 == 0;\n\tif (v928) goto L_0255;\n\tv510 = 0x21C11D0(v927, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv525 = v510 == 0;\n\tif (v525) goto L_0430;\nL_0255:\n\tv873[1] = v927;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v299, v873);\n\tgoto L_0262;\nL_0262:\n\tv952 = 0xB27D000 + 0xA60;\n\tv300 = v946.<>9__1_4;\n\tv948 = v946.<>9__1_4 == 0;\n\tv949 = ~v948;\n\tif (v949) goto L_028D;\n\tgoto L_0275;\nL_0275:\n\tgoto L_027D;\nL_028D:\n\t// 653 NewArr v975 @ X0_v81 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_029A;\n\tv1005 = v268 == 0;\n\tif (v1005) goto L_02AD;\n\tv511 = 0x21C11D0(v268, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv526 = v511 == 0;\n\tif (v526) goto L_0430;\nL_02AD:\n\tv975[0] = v268;\n\tv1016 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv1017 = v1016 == 0;\n\tif (v1017) goto L_02C7;\n\tv512 = 0x21C11D0(v1016, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv527 = v512 == 0;\n\tif (v527) goto L_0430;\nL_02C7:\n\tv975[1] = v1016;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v300, v975);\n\tgoto L_02D4;\nL_02D4:\n\tv1041 = 0xB27D000 + 0xA80;\n\tv301 = v1035.<>9__1_5;\n\tv1037 = v1035.<>9__1_5 == 0;\n\tv1038 = ~v1037;\n\tif (v1038) goto L_02FF;\n\tgoto L_02E7;\nL_02E7:\n\tgoto L_02EF;\nL_02FF:\n\t// 767 NewArr v1064 @ X0_v99 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_030C;\n\tv1094 = v269 == 0;\n\tif (v1094) goto L_031F;\n\tv513 = 0x21C11D0(v269, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv528 = v513 == 0;\n\tif (v528) goto L_0430;\nL_031F:\n\tv1064[0] = v269;\n\tv1105 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv1106 = v1105 == 0;\n\tif (v1106) goto L_0339;\n\tv514 = 0x21C11D0(v1105, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv529 = v514 == 0;\n\tif (v529) goto L_0430;\nL_0339:\n\tv1064[1] = v1105;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v301, v1064);\n\tgoto L_0346;\nL_0346:\n\tv1130 = 0xB27D000 + 0xA88;\n\tv302 = v1124.<>9__1_6;\n\tv1126 = v1124.<>9__1_6 == 0;\n\tv1127 = ~v1126;\n\tif (v1127) goto L_0371;\n\tgoto L_0359;\nL_0359:\n\tgoto L_0361;\nL_0371:\n\t// 881 NewArr v1152 @ X0_v117 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_037C;\nL_037C:\n\tv270 = System.Type::GetTypeFromHandle(*([v1130 @ X22_v42 (System.Int32)]));\n\tv1180 = v270 == 0;\n\tif (v1180) goto L_038F;\n\tv515 = 0x21C11D0(v270, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv530 = v515 == 0;\n\tif (v530) goto L_0430;\nL_038F:\n\tv1152[0] = v270;\n\tv1191 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSp\n// ... truncated")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60008FE")]
		[Address(RVA = "0x3E8C1B4", Offset = "0x3E8C1B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public KeyAndLockInstaller_EditMode()
		{
		}
	}
}
