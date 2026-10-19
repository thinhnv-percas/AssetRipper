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
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.EditMode
{
	[Token(Token = "0x2000171")]
	public class SnakeInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000172")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000489")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400048A")]
			public static Func<Instancer, SnakeBlockerVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400048B")]
			public static Func<Instancer, SandReconcile_SnakeShiftSystem> _003C_003E9__1_1;

			[Token(Token = "0x400048C")]
			public static Func<Instancer, SnakeBodyCondition> _003C_003E9__1_2;

			[Token(Token = "0x400048D")]
			public static Func<Instancer, SnakeEditorMutations> _003C_003E9__1_3;

			[Token(Token = "0x400048E")]
			public static Func<Instancer, SnakeRemoveHook> _003C_003E9__1_4;

			[Token(Token = "0x60006FC")]
			[Address(RVA = "0x3E5A47C", Offset = "0x3E5A47C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.EditMode.SnakeInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006FD")]
			[Address(RVA = "0x3E5A4E0", Offset = "0x3E5A4E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SnakeBlockerVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SnakeBlockerVisualHandler instance = new SnakeBlockerVisualHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_SnakeShiftSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_SnakeShiftSystem instance = new SandReconcile_SnakeShiftSystem();
				return x.InjectInstance(instance);
			}

			internal SnakeBodyCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_2");
				return default;
			}

			internal SnakeEditorMutations _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SnakeEditorMutations instance = new SnakeEditorMutations();
				return x.InjectInstance(instance);
			}

			internal SnakeRemoveHook _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				SnakeRemoveHook instance = new SnakeRemoveHook();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000488")]
		[FieldOffset(Offset = "0x18")]
		private SnakeBlockerConfig m_config;

		[Token(Token = "0x60006FA")]
		[Address(RVA = "0x3E59C8C", Offset = "0x3E59C8C", Length = "0x7E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0066;\n\tgoto L_0082;\nL_0092:\n\t// 146 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_009F;\nL_009F:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_00B2;\n\tv234 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv238 = v234 == 0;\n\tif (v238) goto L_0265;\nL_00B2:\n\tv103[0] = v134;\n\tv381 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv385 = v381 == 0;\n\tif (v385) goto L_00CC;\n\tv357 = 0x21C11D0(v381, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv364 = v357 == 0;\n\tif (v364) goto L_0265;\nL_00CC:\n\tv103[1] = v381;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00D9;\nL_00D9:\n\tv427 = 0xB27E000 + 0x750;\n\tv224 = v418.<>9__1_1;\n\tv420 = v418.<>9__1_1 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_0104;\n\tgoto L_00EC;\nL_00EC:\n\tgoto L_00F4;\nL_0104:\n\t// 260 NewArr v450 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0111;\n\tv492 = v202 == 0;\n\tif (v492) goto L_0124;\n\tv358 = 0x21C11D0(v202, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv365 = v358 == 0;\n\tif (v365) goto L_0265;\nL_0124:\n\tv450[0] = v202;\n\tv511 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv512 = v511 == 0;\n\tif (v512) goto L_013E;\n\tv359 = 0x21C11D0(v511, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = v359 == 0;\n\tif (v366) goto L_0265;\nL_013E:\n\tv450[1] = v511;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v224, v450);\n\tgoto L_014B;\nL_014B:\n\tv536 = 0xB27E000 + 0xAC0;\n\tv225 = v530.<>9__1_2;\n\tv532 = v530.<>9__1_2 == 0;\n\tv533 = ~v532;\n\tif (v533) goto L_0176;\n\tgoto L_015E;\nL_015E:\n\tgoto L_0166;\nL_0176:\n\t// 374 NewArr v558 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0181;\nL_0181:\n\tv203 = System.Type::GetTypeFromHandle(*([v536 @ X22_v33 (System.Int32)]));\n\tv586 = v203 == 0;\n\tif (v586) goto L_0194;\n\tv360 = 0x21C11D0(v203, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv367 = v360 == 0;\n\tif (v367) goto L_0265;\nL_0194:\n\tv558[0] = v203;\n\tv597 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv598 = v597 == 0;\n\tif (v598) goto L_01AE;\n\tv361 = 0x21C11D0(v597, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv368 = v361 == 0;\n\tif (v368) goto L_0265;\nL_01AE:\n\tv558[1] = v597;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v225, v558);\n\tgoto L_01BB;\nL_01BB:\n\t;\n\tv643 = v616.<>9__1_3;\n\tv618 = v616.<>9__1_3 == 0;\n\tv619 = ~v618;\n\tif (v619) goto L_01E7;\n\tgoto L_01CE;\nL_01CE:\n\tgoto L_01D6;\nL_01E7:\n\tv649 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.EditMode.SnakeInstaller_EditMode+<>c::<InstallBindings>b__1_4(containerBuilder, v643);\n\tgoto L_01ED;\nL_01ED:\n\tv680 = 0xB27E000 + 0xAE0;\n\tv226 = v670.<>9__1_4;\n\tv672 = v670.<>9__1_4 == 0;\n\tv673 = ~v672;\n\tif (v673) goto L_0218;\n\tgoto L_0200;\nL_0200:\n\tgoto L_0208;\nL_0218:\n\t// 536 NewArr v702 @ X0_v74 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0223;\nL_0223:\n\tv204 = System.Type::GetTypeFromHandle(*([v680 @ X22_v23 (System.Int32)]));\n\tv732 = v204 == 0;\n\tif (v732) goto L_0236;\n\tv362 = 0x21C11D0(v204, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv369 = v362 == 0;\n\tif (v369) goto L_0265;\nL_0236:\n\tv702[0] = v204;\n\tv743 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv744 = v743 == 0;\n\tif (v744) goto L_0250;\n\tv363 = 0x21C11D0(v743, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv370 = v363 == 0;\n\tif (v370) goto L_0265;\nL_0250:\n\tv702[1] = v743;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v226, v702);\n\treturn;\nL_0265:\n\tv378 = new System.ArrayTypeMismatchException();\n\tthrow v378;\nL_0066:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0073;\nL_0073:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0092;\nL_0082:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00F4:\n\tv474 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>::.ctor(v474, v469.<>9, Il2CppMethodInfo);\n\tv490.<>9__1_1 = v474;\n\tv224 = v474;\nL_0111:\n\tv202 = System.Type::GetTypeFromHandle(*([v427 @ X22_v39 (System.Int32)]));\nL_0166:\n\tv576 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>::.ctor(v576, v571.<>9, Il2CppMethodInfo);\n\tv584.<>9__1_2 = v576;\n\tv225 = v576;\nL_01D6:\n\tv667 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations>::.ctor(v667, v662.<>9, Il2CppMethodInfo);\n\tv705.<>9__1_3 = v667;\n\tv643 = v667;\nL_0208:\n\tv722 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeRemoveHook>::.ctor(v722, v717.<>9, Il2CppMethodInfo);\n\tv730.<>9__1_4 = v722;\n\tv226 = v722;\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60006FB")]
		[Address(RVA = "0x3E5A474", Offset = "0x3E5A474", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SnakeInstaller_EditMode()
		{
		}
	}
}
