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

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.HeadlessMode
{
	[Token(Token = "0x200016F")]
	public class SnakeInstaller_Headless : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000170")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000482")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000483")]
			public static Func<Instancer, SandReconcile_SnakeShiftSystem> _003C_003E9__1_0;

			[Token(Token = "0x4000484")]
			public static Func<Instancer, SandReconcile_SnakeBodySplitSystem> _003C_003E9__1_1;

			[Token(Token = "0x4000485")]
			public static Func<Instancer, SnakeBodyCondition> _003C_003E9__1_2;

			[Token(Token = "0x4000486")]
			public static Func<Instancer, SnakeEditorMutations> _003C_003E9__1_3;

			[Token(Token = "0x4000487")]
			public static Func<Instancer, SnakeRemoveHook> _003C_003E9__1_4;

			[Token(Token = "0x60006F3")]
			[Address(RVA = "0x3E59898", Offset = "0x3E59898", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.HeadlessMode.SnakeInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006F4")]
			[Address(RVA = "0x3E598FC", Offset = "0x3E598FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandReconcile_SnakeShiftSystem _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SandReconcile_SnakeShiftSystem instance = new SandReconcile_SnakeShiftSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_SnakeBodySplitSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_SnakeBodySplitSystem instance = new SandReconcile_SnakeBodySplitSystem();
				return x.InjectInstance(instance);
			}

			internal SnakeBodyCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__1_2");
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
		[Token(Token = "0x4000481")]
		[FieldOffset(Offset = "0x18")]
		private SnakeBlockerConfig m_config;

		[Token(Token = "0x60006F1")]
		[Address(RVA = "0x3E590B4", Offset = "0x3E590B4", Length = "0x7DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0065;\n\tgoto L_0081;\nL_0091:\n\t// 145 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_009E;\nL_009E:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00B1;\n\tv241 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv245 = v241 == 0;\n\tif (v245) goto L_0264;\nL_00B1:\n\tv107[0] = v138;\n\tv391 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv395 = v391 == 0;\n\tif (v395) goto L_00CB;\n\tv367 = 0x21C11D0(v391, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v367 == 0;\n\tif (v374) goto L_0264;\nL_00CB:\n\tv107[1] = v391;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00D8;\nL_00D8:\n\tv437 = 0xB27E000 + 0x748;\n\tv231 = v428.<>9__1_1;\n\tv430 = v428.<>9__1_1 == 0;\n\tv431 = ~v430;\n\tif (v431) goto L_0103;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_00F3;\nL_0103:\n\t// 259 NewArr v460 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0110;\n\tv502 = v209 == 0;\n\tif (v502) goto L_0121;\n\tv368 = 0x21C11D0(v209, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v368 == 0;\n\tif (v375) goto L_0264;\nL_0121:\n\tv460[0] = v209;\n\tv517 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv518 = v517 == 0;\n\tif (v518) goto L_013B;\n\tv369 = 0x21C11D0(v517, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v369 == 0;\n\tif (v376) goto L_0264;\nL_013B:\n\tv460[1] = v517;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v460);\n\tgoto L_0148;\nL_0148:\n\tv542 = 0xB27E000 + 0xAC0;\n\tv232 = v536.<>9__1_2;\n\tv538 = v536.<>9__1_2 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_0173;\n\tgoto L_015B;\nL_015B:\n\tgoto L_0163;\nL_0173:\n\t// 371 NewArr v564 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_017E;\nL_017E:\n\tv210 = System.Type::GetTypeFromHandle(*([v542 @ X22_v33 (System.Int32)]));\n\tv592 = v210 == 0;\n\tif (v592) goto L_0191;\n\tv370 = 0x21C11D0(v210, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v370 == 0;\n\tif (v377) goto L_0264;\nL_0191:\n\tv564[0] = v210;\n\tv603 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv604 = v603 == 0;\n\tif (v604) goto L_01AB;\n\tv371 = 0x21C11D0(v603, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = v371 == 0;\n\tif (v378) goto L_0264;\nL_01AB:\n\tv564[1] = v603;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v232, v564);\n\tgoto L_01B8;\nL_01B8:\n\t;\n\tv649 = v622.<>9__1_3;\n\tv624 = v622.<>9__1_3 == 0;\n\tv625 = ~v624;\n\tif (v625) goto L_01E4;\n\tgoto L_01CB;\nL_01CB:\n\tgoto L_01D3;\nL_01E4:\n\tv655 = _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.HeadlessMode.SnakeInstaller_Headless+<>c::<InstallBindings>b__1_4(containerBuilder, v649);\n\tgoto L_01EA;\nL_01EA:\n\tv686 = 0xB27E000 + 0xAE0;\n\tv233 = v676.<>9__1_4;\n\tv678 = v676.<>9__1_4 == 0;\n\tv679 = ~v678;\n\tif (v679) goto L_0215;\n\tgoto L_01FD;\nL_01FD:\n\tgoto L_0205;\nL_0215:\n\t// 533 NewArr v708 @ X0_v74 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0220;\nL_0220:\n\tv211 = System.Type::GetTypeFromHandle(*([v686 @ X22_v23 (System.Int32)]));\n\tv738 = v211 == 0;\n\tif (v738) goto L_0233;\n\tv372 = 0x21C11D0(v211, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v372 == 0;\n\tif (v379) goto L_0264;\nL_0233:\n\tv708[0] = v211;\n\tv749 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv750 = v749 == 0;\n\tif (v750) goto L_024D;\n\tv373 = 0x21C11D0(v749, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv380 = v373 == 0;\n\tif (v380) goto L_0264;\nL_024D:\n\tv708[1] = v749;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v233, v708);\n\treturn;\nL_0264:\n\tv388 = new System.ArrayTypeMismatchException();\n\tthrow v388;\nL_0065:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0072;\nL_0072:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0091;\nL_0081:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_00F3:\n\tv484 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem>::.ctor(v484, v479.<>9, Il2CppMethodInfo);\n\tv500.<>9__1_1 = v484;\n\tv231 = v484;\nL_0110:\n\tv209 = System.Type::GetTypeFromHandle(*([v437 @ X22_v39 (System.Int32)]));\nL_0163:\n\tv582 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>::.ctor(v582, v577.<>9, Il2CppMethodInfo);\n\tv590.<>9__1_2 = v582;\n\tv232 = v582;\nL_01D3:\n\tv673 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeEditorMutations>::.ctor(v673, v668.<>9, Il2CppMethodInfo);\n\tv711.<>9__1_3 = v673;\n\tv649 = v673;\nL_0205:\n\tv728 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeRemoveHook>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.EditMode.SnakeRemoveHook>::.ctor(v728, v723.<>9, Il2CppMethodInfo);\n\tv736.<>9__1_4 = v728;\n\tv233 = v728;\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x60006F2")]
		[Address(RVA = "0x3E59890", Offset = "0x3E59890", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SnakeInstaller_Headless()
		{
		}
	}
}
