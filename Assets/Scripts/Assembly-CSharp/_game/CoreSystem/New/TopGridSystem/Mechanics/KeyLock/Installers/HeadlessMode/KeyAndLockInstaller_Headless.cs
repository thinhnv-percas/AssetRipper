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
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.HeadlessMode
{
	[Token(Token = "0x20001F6")]
	public class KeyAndLockInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001F7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000648")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000649")]
			public static Func<Instancer, LockGroupHandler> _003C_003E9__1_0;

			[Token(Token = "0x400064A")]
			public static Func<Instancer, SandReconcile_UnlockSystem> _003C_003E9__1_1;

			[Token(Token = "0x400064B")]
			public static Func<Instancer, LockCondition> _003C_003E9__1_2;

			[Token(Token = "0x400064C")]
			public static Func<Instancer, LockRemoveHook> _003C_003E9__1_3;

			[Token(Token = "0x400064D")]
			public static Func<Instancer, LockTunnelSpawnHandler> _003C_003E9__1_4;

			[Token(Token = "0x400064E")]
			public static Func<Instancer, KeyTunnelSpawnHandler> _003C_003E9__1_5;

			[Token(Token = "0x60008F5")]
			[Address(RVA = "0x3E8B078", Offset = "0x3E8B078", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.HeadlessMode.KeyAndLockInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60008F6")]
			[Address(RVA = "0x3E8B0DC", Offset = "0x3E8B0DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal LockGroupHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				LockGroupHandler instance = new LockGroupHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_UnlockSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_UnlockSystem instance = new SandReconcile_UnlockSystem();
				return x.InjectInstance(instance);
			}

			internal LockCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				LockCondition instance = new LockCondition();
				return x.InjectInstance(instance);
			}

			internal LockRemoveHook _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				LockRemoveHook instance = new LockRemoveHook();
				return x.InjectInstance(instance);
			}

			internal LockTunnelSpawnHandler _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_4");
				return default;
			}

			internal KeyTunnelSpawnHandler _003CInstallBindings_003Eb__1_5(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_5");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000647")]
		[FieldOffset(Offset = "0x18")]
		private KeyAndLockConfig m_config;

		[Token(Token = "0x60008F3")]
		[Address(RVA = "0x3E8A6E8", Offset = "0x3E8A6E8", Length = "0x988")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0074;\nL_007A:\n\t;\n\tv103 = v72.<>9__1_0;\n\tv74 = v72.<>9__1_0 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_00A6;\n\tgoto L_008D;\nL_008D:\n\tgoto L_0095;\nL_00A6:\n\tv109 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Installers.HeadlessMode.KeyAndLockInstaller_Headless+<>c::<InstallBindings>b__1_1(containerBuilder, v103);\n\tgoto L_00B3;\n\tgoto L_00C2;\nL_00D2:\n\t// 210 NewArr v174 @ X0_v11 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00DF;\nL_00DF:\n\tv207 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.SandReconcile_UnlockSystem);\n\tv218 = v207 == 0;\n\tif (v218) goto L_00F2;\n\tv323 = 0x21C11D0(v207, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv327 = v323 == 0;\n\tif (v327) goto L_02E5;\nL_00F2:\n\tv174[0] = v207;\n\tv491 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv495 = v491 == 0;\n\tif (v495) goto L_010C;\n\tv461 = 0x21C11D0(v491, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv470 = v461 == 0;\n\tif (v470) goto L_02E5;\nL_010C:\n\tv174[1] = v491;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v170, v174);\n\tgoto L_0119;\nL_0119:\n\tv543 = 0xB27D000 + 0xA60;\n\tv312 = v528.<>9__1_2;\n\tv530 = v528.<>9__1_2 == 0;\n\tv531 = ~v530;\n\tif (v531) goto L_0144;\n\tgoto L_012C;\nL_012C:\n\tgoto L_0134;\nL_0144:\n\t// 324 NewArr v560 @ X0_v37 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0151;\n\tv602 = v288 == 0;\n\tif (v602) goto L_0164;\n\tv462 = 0x21C11D0(v288, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv471 = v462 == 0;\n\tif (v471) goto L_02E5;\nL_0164:\n\tv560[0] = v288;\n\tv622 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv625 = v622 == 0;\n\tif (v625) goto L_017E;\n\tv463 = 0x21C11D0(v622, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv472 = v463 == 0;\n\tif (v472) goto L_02E5;\nL_017E:\n\tv560[1] = v622;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v312, v560);\n\tgoto L_018B;\nL_018B:\n\tv654 = 0xB27D000 + 0xA80;\n\tv313 = v643.<>9__1_3;\n\tv645 = v643.<>9__1_3 == 0;\n\tv646 = ~v645;\n\tif (v646) goto L_01B6;\n\tgoto L_019E;\nL_019E:\n\tgoto L_01A6;\nL_01B6:\n\t// 438 NewArr v671 @ X0_v55 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01C1;\nL_01C1:\n\tv289 = System.Type::GetTypeFromHandle(*([v654 @ X22_v38 (System.Int32)]));\n\tv699 = v289 == 0;\n\tif (v699) goto L_01D4;\n\tv464 = 0x21C11D0(v289, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv473 = v464 == 0;\n\tif (v473) goto L_02E5;\nL_01D4:\n\tv671[0] = v289;\n\tv710 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv711 = v710 == 0;\n\tif (v711) goto L_01EE;\n\tv465 = 0x21C11D0(v710, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv474 = v465 == 0;\n\tif (v474) goto L_02E5;\nL_01EE:\n\tv671[1] = v710;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v313, v671);\n\tgoto L_01FB;\nL_01FB:\n\tv740 = 0xB27D000 + 0xA88;\n\tv314 = v729.<>9__1_4;\n\tv731 = v729.<>9__1_4 == 0;\n\tv732 = ~v731;\n\tif (v732) goto L_0226;\n\tgoto L_020E;\nL_020E:\n\tgoto L_0216;\nL_0226:\n\t// 550 NewArr v757 @ X0_v74 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0231;\nL_0231:\n\tv290 = System.Type::GetTypeFromHandle(*([v740 @ X22_v33 (System.Int32)]));\n\tv785 = v290 == 0;\n\tif (v785) goto L_0244;\n\tv466 = 0x21C11D0(v290, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv475 = v466 == 0;\n\tif (v475) goto L_02E5;\nL_0244:\n\tv757[0] = v290;\n\tv796 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv797 = v796 == 0;\n\tif (v797) goto L_025E;\n\tv467 = 0x21C11D0(v796, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv476 = v467 == 0;\n\tif (v476) goto L_02E5;\nL_025E:\n\tv757[1] = v796;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v314, v757);\n\tgoto L_026B;\nL_026B:\n\tv827 = 0xB27D000 + 0x850;\n\tv315 = v815.<>9__1_5;\n\tv817 = v815.<>9__1_5 == 0;\n\tv818 = ~v817;\n\tif (v818) goto L_0296;\n\tgoto L_027E;\nL_027E:\n\tgoto L_0286;\nL_0296:\n\t// 662 NewArr v844 @ X0_v93 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_02A3;\n\tv874 = v291 == 0;\n\tif (v874) goto L_02B4;\n\tv468 = 0x21C11D0(v291, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv477 = v468 == 0;\n\tif (v477) goto L_02E5;\nL_02B4:\n\tv844[0] = v291;\n\tv884 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnHandler);\n\tv885 = v884 == 0;\n\tif (v885) goto L_02CE;\n\tv469 = 0x21C11D0(v884, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv478 = v469 == 0;\n\tif (v478) goto L_02E5;\nL_02CE:\n\tv844[1] = v884;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v315, v844);\n\treturn;\nL_02E5:\n\tv488 = new System.ArrayTypeMismatchException();\n\tthrow v488;\nL_0074:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_007A;\nL_0095:\n\tv134 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.LockGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.LockGroupHandler>::.ctor(v134, v129.<>9, Il2CppMethodInfo);\n\tv178.<>9__1_0 = v134;\n\tv103 = v134;\nL_00B3:\n\tv170 = v142.<>9__1_1;\n\tv144 = v142.<>9__1_1 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_00D2;\nL_00C2:\n\tv187 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.SandReconcile_UnlockSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.SandReconcile_UnlockSystem>::.ctor(v187, v182.<>9, Il2CppMethodInfo);\n\tv211.<>9__1_1 = v187;\n\tv170 = v187;\nL_0134:\n\tv584 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Conditions.LockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.Conditions.LockCondition>::.ctor(v584, v579.<>9, Il2CppMethodInfo);\n\tv600.<>9__1_2 = v584;\n\tv312 = v584;\nL_0151:\n\tv288 = System.Type::GetTypeFromHandle(*([v543 @ X22_v44 (System.Int32)]));\nL_01A6:\n\tv689 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.EditMode.LockRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Key\n// ... truncated")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyAndLockInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x60008F4")]
		[Address(RVA = "0x3E8B070", Offset = "0x3E8B070", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public KeyAndLockInstaller_Headless()
		{
		}
	}
}
