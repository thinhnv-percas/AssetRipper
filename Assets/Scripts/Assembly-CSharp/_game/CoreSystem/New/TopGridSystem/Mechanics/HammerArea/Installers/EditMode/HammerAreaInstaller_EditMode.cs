using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.EditMode
{
	[Token(Token = "0x2000210")]
	public class HammerAreaInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000211")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000684")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000685")]
			public static Func<Instancer, HammerAreaVisualHandler_Editor> _003C_003E9__1_0;

			[Token(Token = "0x4000686")]
			public static Func<Instancer, HammerAreaGroupHandler> _003C_003E9__1_1;

			[Token(Token = "0x4000687")]
			public static Func<Instancer, HammerAreaBlockCondition> _003C_003E9__1_2;

			[Token(Token = "0x600094B")]
			[Address(RVA = "0x3E91A1C", Offset = "0x3E91A1C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.EditMode.HammerAreaInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600094C")]
			[Address(RVA = "0x3E91A80", Offset = "0x3E91A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal HammerAreaVisualHandler_Editor _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				HammerAreaVisualHandler_Editor instance = new HammerAreaVisualHandler_Editor();
				return x.InjectInstance(instance);
			}

			internal HammerAreaGroupHandler _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				HammerAreaGroupHandler instance = new HammerAreaGroupHandler();
				return x.InjectInstance(instance);
			}

			internal HammerAreaBlockCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_2");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000683")]
		[FieldOffset(Offset = "0x18")]
		private HammerAreaConfig m_config;

		[Token(Token = "0x6000949")]
		[Address(RVA = "0x3E91508", Offset = "0x3E91508", Length = "0x50C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tgoto L_0067;\nL_0077:\n\t// 119 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0084;\nL_0084:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_0097;\n\tv224 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv228 = v224 == 0;\n\tif (v228) goto L_0190;\nL_0097:\n\tv103[0] = v134;\n\tv357 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaVisualHandler_Editor);\n\tv361 = v357 == 0;\n\tif (v361) goto L_00B1;\n\tv342 = 0x21C11D0(v357, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv346 = v342 == 0;\n\tif (v346) goto L_0190;\nL_00B1:\n\tv103[1] = v357;\n\tv381 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv384 = v381 == 0;\n\tif (v384) goto L_00D1;\n\tv343 = 0x21C11D0(v381, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv347 = v343 == 0;\n\tif (v347) goto L_0190;\nL_00D1:\n\tv103[2] = v381;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00DE;\nL_00DE:\n\t;\n\tv405 = v403.<>9__1_1 == 0;\n\tif (v405) goto L_00FE;\n\tv419 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.EditMode.HammerAreaInstaller_EditMode+<>c::<InstallBindings>b__1_2(containerBuilder, v403.<>9__1_1);\n\tgoto L_00EB;\nL_00EB:\n\tv482 = 0xB27C000 + 0xFA0;\n\tv216 = v461.<>9__1_2;\n\tv463 = v461.<>9__1_2 == 0;\n\tv464 = ~v463;\n\tif (v464) goto L_0141;\n\tgoto L_0129;\nL_00FE:\n\tgoto L_0106;\n\tv527 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.EditMode.HammerAreaInstaller_EditMode+<>c::<InstallBindings>b__1_2(containerBuilder, v441);\n\tgoto L_00EB;\nL_0129:\n\tgoto L_0131;\nL_0141:\n\t// 321 NewArr v505 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_014E;\n\tv548 = v202 == 0;\n\tif (v548) goto L_0161;\n\tv344 = 0x21C11D0(v202, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv348 = v344 == 0;\n\tif (v348) goto L_0190;\nL_0161:\n\tv505[0] = v202;\n\tv559 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv560 = v559 == 0;\n\tif (v560) goto L_017B;\n\tv345 = 0x21C11D0(v559, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv349 = v345 == 0;\n\tif (v349) goto L_0190;\nL_017B:\n\tv505[1] = v559;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v216, v505);\n\treturn;\nL_0190:\n\tv354 = new System.ArrayTypeMismatchException();\n\tthrow v354;\nL_004B:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0058;\nL_0058:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0077;\nL_0067:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaVisualHandler_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.EditMode.HammerAreaVisualHandler_Editor>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_0106:\n\tv441 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>::.ctor(v441, v435.<>9, Il2CppMethodInfo);\n\tv509.<>9__1_1 = v441;\nL_0131:\n\tv535 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>::.ctor(v535, v530.<>9, Il2CppMethodInfo);\n\tv546.<>9__1_2 = v535;\n\tv216 = v535;\nL_014E:\n\tv202 = System.Type::GetTypeFromHandle(*([v482 @ X22_v16 (System.Int32)]));\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x600094A")]
		[Address(RVA = "0x3E91A14", Offset = "0x3E91A14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public HammerAreaInstaller_EditMode()
		{
		}
	}
}
