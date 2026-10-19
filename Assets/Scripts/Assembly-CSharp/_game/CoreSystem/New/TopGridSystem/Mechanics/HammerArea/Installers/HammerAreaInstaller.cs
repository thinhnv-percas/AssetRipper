using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers
{
	[Token(Token = "0x200020C")]
	public class HammerAreaInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200020D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400067A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400067B")]
			public static Func<Instancer, HammerAreaVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400067C")]
			public static Func<Instancer, HammerAreaGroupHandler> _003C_003E9__1_1;

			[Token(Token = "0x400067D")]
			public static Func<Instancer, HammerAreaReconcile_LandingSystem> _003C_003E9__1_2;

			[Token(Token = "0x400067E")]
			public static Func<Instancer, HammerAreaBlockCondition> _003C_003E9__1_3;

			[Token(Token = "0x600093C")]
			[Address(RVA = "0x3E90B18", Offset = "0x3E90B18", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HammerAreaInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600093D")]
			[Address(RVA = "0x3E90B7C", Offset = "0x3E90B7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal HammerAreaVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				HammerAreaVisualHandler instance = new HammerAreaVisualHandler();
				return x.InjectInstance(instance);
			}

			internal HammerAreaGroupHandler _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				HammerAreaGroupHandler instance = new HammerAreaGroupHandler();
				return x.InjectInstance(instance);
			}

			internal HammerAreaReconcile_LandingSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				HammerAreaReconcile_LandingSystem instance = new HammerAreaReconcile_LandingSystem();
				return x.InjectInstance(instance);
			}

			internal HammerAreaBlockCondition _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_3");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000679")]
		[FieldOffset(Offset = "0x18")]
		private HammerAreaConfig m_config;

		[Token(Token = "0x600093A")]
		[Address(RVA = "0x3E90474", Offset = "0x3E90474", Length = "0x69C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0057;\n\tgoto L_0073;\nL_0083:\n\t// 131 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0090;\nL_0090:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00A1;\n\tv239 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v239 == 0;\n\tif (v243) goto L_020A;\nL_00A1:\n\tv103[0] = v134;\n\tv389 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler);\n\tv393 = v389 == 0;\n\tif (v393) goto L_00BB;\n\tv368 = 0x21C11D0(v389, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v368 == 0;\n\tif (v374) goto L_020A;\nL_00BB:\n\tv103[1] = v389;\n\tv413 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv417 = v413 == 0;\n\tif (v417) goto L_00DB;\n\tv369 = 0x21C11D0(v413, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v369 == 0;\n\tif (v375) goto L_020A;\nL_00DB:\n\tv103[2] = v413;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00E8;\nL_00E8:\n\t;\n\tv449 = v447.<>9__1_1 == 0;\n\tif (v449) goto L_0108;\n\tv463 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HammerAreaInstaller+<>c::<InstallBindings>b__1_2(containerBuilder, v447.<>9__1_1);\n\tgoto L_00F5;\nL_00F5:\n\tv526 = 0xB27C000 + 0xFD0;\n\tv230 = v505.<>9__1_2;\n\tv507 = v505.<>9__1_2 == 0;\n\tv508 = ~v507;\n\tif (v508) goto L_014B;\n\tgoto L_0133;\nL_0108:\n\tgoto L_0110;\n\tv571 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HammerAreaInstaller+<>c::<InstallBindings>b__1_2(containerBuilder, v485);\n\tgoto L_00F5;\nL_0133:\n\tgoto L_013B;\nL_014B:\n\t// 331 NewArr v549 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0158;\n\tv592 = v212 == 0;\n\tif (v592) goto L_016B;\n\tv370 = 0x21C11D0(v212, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v370 == 0;\n\tif (v376) goto L_020A;\nL_016B:\n\tv549[0] = v212;\n\tv603 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv604 = v603 == 0;\n\tif (v604) goto L_0185;\n\tv371 = 0x21C11D0(v603, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v371 == 0;\n\tif (v377) goto L_020A;\nL_0185:\n\tv549[1] = v603;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v230, v549);\n\tgoto L_0192;\nL_0192:\n\tv628 = 0xB27C000 + 0xFA0;\n\tv231 = v622.<>9__1_3;\n\tv624 = v622.<>9__1_3 == 0;\n\tv625 = ~v624;\n\tif (v625) goto L_01BD;\n\tgoto L_01A5;\nL_01A5:\n\tgoto L_01AD;\nL_01BD:\n\t// 445 NewArr v650 @ X0_v57 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01C8;\nL_01C8:\n\tv213 = System.Type::GetTypeFromHandle(*([v628 @ X22_v17 (System.Int32)]));\n\tv678 = v213 == 0;\n\tif (v678) goto L_01DB;\n\tv372 = 0x21C11D0(v213, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = v372 == 0;\n\tif (v378) goto L_020A;\nL_01DB:\n\tv650[0] = v213;\n\tv689 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv690 = v689 == 0;\n\tif (v690) goto L_01F5;\n\tv373 = 0x21C11D0(v689, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v373 == 0;\n\tif (v379) goto L_020A;\nL_01F5:\n\tv650[1] = v689;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v650);\n\treturn;\nL_020A:\n\tv386 = new System.ArrayTypeMismatchException();\n\tthrow v386;\nL_0057:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0064;\nL_0064:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0083;\nL_0073:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_0110:\n\tv485 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>::.ctor(v485, v479.<>9, Il2CppMethodInfo);\n\tv553.<>9__1_1 = v485;\nL_013B:\n\tv579 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem>::.ctor(v579, v574.<>9, Il2CppMethodInfo);\n\tv590.<>9__1_2 = v579;\n\tv230 = v579;\nL_0158:\n\tv212 = System.Type::GetTypeFromHandle(*([v526 @ X22_v23 (System.Int32)]));\nL_01AD:\n\tv668 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>::.ctor(v668, v663.<>9, Il2CppMethodInfo);\n\tv676.<>9__1_3 = v668;\n\tv231 = v668;\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller::InstallBindings");
		}

		[Token(Token = "0x600093B")]
		[Address(RVA = "0x3E90B10", Offset = "0x3E90B10", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public HammerAreaInstaller()
		{
		}
	}
}
