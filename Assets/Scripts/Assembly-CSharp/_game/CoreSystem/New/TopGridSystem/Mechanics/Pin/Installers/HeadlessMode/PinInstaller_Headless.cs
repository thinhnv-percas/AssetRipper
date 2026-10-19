using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.HeadlessMode
{
	[Token(Token = "0x20001A9")]
	public class PinInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001AA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000531")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000532")]
			public static Func<Instancer, PinBlockCondition> _003C_003E9__1_0;

			[Token(Token = "0x4000533")]
			public static Func<Instancer, SandReconcile_PinTriggerSystem> _003C_003E9__1_1;

			[Token(Token = "0x4000534")]
			public static Func<Instancer, SandReconcile_PinResolveSystem> _003C_003E9__1_2;

			[Token(Token = "0x4000535")]
			public static Func<Instancer, PinEditorMutations> _003C_003E9__1_3;

			[Token(Token = "0x4000536")]
			public static Func<Instancer, PinRemoveHook> _003C_003E9__1_4;

			[Token(Token = "0x60007B0")]
			[Address(RVA = "0x3E6CFD8", Offset = "0x3E6CFD8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.HeadlessMode.PinInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60007B1")]
			[Address(RVA = "0x3E6D03C", Offset = "0x3E6D03C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal PinBlockCondition _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal SandReconcile_PinTriggerSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_PinTriggerSystem instance = new SandReconcile_PinTriggerSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_PinResolveSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				SandReconcile_PinResolveSystem instance = new SandReconcile_PinResolveSystem();
				return x.InjectInstance(instance);
			}

			internal PinEditorMutations _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				PinEditorMutations instance = new PinEditorMutations();
				return x.InjectInstance(instance);
			}

			internal PinRemoveHook _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_4");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000530")]
		[FieldOffset(Offset = "0x18")]
		private PinBlockerConfig m_config;

		[Token(Token = "0x60007AE")]
		[Address(RVA = "0x3E6C774", Offset = "0x3E6C774", Length = "0x85C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0068;\n\tgoto L_0084;\nL_0094:\n\t// 148 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00A1;\nL_00A1:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00B4;\n\tv252 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv256 = v252 == 0;\n\tif (v256) goto L_028B;\nL_00B4:\n\tv107[0] = v138;\n\tv411 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv415 = v411 == 0;\n\tif (v415) goto L_00CE;\n\tv384 = 0x21C11D0(v411, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv392 = v384 == 0;\n\tif (v392) goto L_028B;\nL_00CE:\n\tv107[1] = v411;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00DB;\nL_00DB:\n\tv457 = 0xB27E000 + 0x740;\n\tv241 = v448.<>9__1_1;\n\tv450 = v448.<>9__1_1 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_0106;\n\tgoto L_00EE;\nL_00EE:\n\tgoto L_00F6;\nL_0106:\n\t// 262 NewArr v480 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0113;\n\tv522 = v215 == 0;\n\tif (v522) goto L_0126;\n\tv385 = 0x21C11D0(v215, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv393 = v385 == 0;\n\tif (v393) goto L_028B;\nL_0126:\n\tv480[0] = v215;\n\tv541 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv542 = v541 == 0;\n\tif (v542) goto L_0140;\n\tv386 = 0x21C11D0(v541, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv394 = v386 == 0;\n\tif (v394) goto L_028B;\nL_0140:\n\tv480[1] = v541;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v241, v480);\n\tgoto L_014D;\nL_014D:\n\tv566 = 0xB27E000 + 0x738;\n\tv242 = v560.<>9__1_2;\n\tv562 = v560.<>9__1_2 == 0;\n\tv563 = ~v562;\n\tif (v563) goto L_0178;\n\tgoto L_0160;\nL_0160:\n\tgoto L_0168;\nL_0178:\n\t// 376 NewArr v588 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0183;\nL_0183:\n\tv216 = System.Type::GetTypeFromHandle(*([v566 @ X22_v35 (System.Int32)]));\n\tv616 = v216 == 0;\n\tif (v616) goto L_0194;\n\tv387 = 0x21C11D0(v216, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv395 = v387 == 0;\n\tif (v395) goto L_028B;\nL_0194:\n\tv588[0] = v216;\n\tv626 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv627 = v626 == 0;\n\tif (v627) goto L_01AE;\n\tv388 = 0x21C11D0(v626, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv396 = v388 == 0;\n\tif (v396) goto L_028B;\nL_01AE:\n\tv588[1] = v626;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v242, v588);\n\tgoto L_01BB;\nL_01BB:\n\tv651 = 0xB27E000 + 0x78;\n\tv243 = v645.<>9__1_3;\n\tv647 = v645.<>9__1_3 == 0;\n\tv648 = ~v647;\n\tif (v648) goto L_01E6;\n\tgoto L_01CE;\nL_01CE:\n\tgoto L_01D6;\nL_01E6:\n\t// 486 NewArr v673 @ X0_v70 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_01F1;\nL_01F1:\n\tv217 = System.Type::GetTypeFromHandle(*([v651 @ X22_v30 (System.Int32)]));\n\tv701 = v217 == 0;\n\tif (v701) goto L_0204;\n\tv389 = 0x21C11D0(v217, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv397 = v389 == 0;\n\tif (v397) goto L_028B;\nL_0204:\n\tv673[0] = v217;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v243, v673);\n\tgoto L_0211;\nL_0211:\n\tv725 = 0xB27E000 + 0x98;\n\tv244 = v719.<>9__1_4;\n\tv721 = v719.<>9__1_4 == 0;\n\tv722 = ~v721;\n\tif (v722) goto L_023C;\n\tgoto L_0224;\nL_0224:\n\tgoto L_022C;\nL_023C:\n\t// 572 NewArr v747 @ X0_v83 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0247;\nL_0247:\n\tv218 = System.Type::GetTypeFromHandle(*([v725 @ X22_v25 (System.Int32)]));\n\tv775 = v218 == 0;\n\tif (v775) goto L_025A;\n\tv390 = 0x21C11D0(v218, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv398 = v390 == 0;\n\tif (v398) goto L_028B;\nL_025A:\n\tv747[0] = v218;\n\tv786 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv787 = v786 == 0;\n\tif (v787) goto L_0274;\n\tv391 = 0x21C11D0(v786, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv399 = v391 == 0;\n\tif (v399) goto L_028B;\nL_0274:\n\tv747[1] = v786;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v244, v747);\n\treturn;\nL_028B:\n\tv408 = new System.ArrayTypeMismatchException();\n\tthrow v408;\nL_0068:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0075;\nL_0075:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0094;\nL_0084:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_00F6:\n\tv504 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem>::.ctor(v504, v499.<>9, Il2CppMethodInfo);\n\tv520.<>9__1_1 = v504;\n\tv241 = v504;\nL_0113:\n\tv215 = System.Type::GetTypeFromHandle(*([v457 @ X22_v41 (System.Int32)]));\nL_0168:\n\tv606 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem>::.ctor(v606, v601.<>9, Il2CppMethodInfo);\n\tv614.<>9__1_2 = v606;\n\tv242 = v606;\nL_01D6:\n\tv691 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinEditorMutations>::.ctor(v691, v686.<>9, Il2CppMethodInfo);\n\tv699.<>9__1_3 = v691;\n\tv243 = v691;\nL_022C:\n\tv765 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.EditMode.PinRemoveHook>::.ctor(v765, v760.<>9, Il2CppMethodInfo);\n\tv773.<>9__1_4 = v765;\n\tv244 = v765;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x60007AF")]
		[Address(RVA = "0x3E6CFD0", Offset = "0x3E6CFD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public PinInstaller_Headless()
		{
		}
	}
}
