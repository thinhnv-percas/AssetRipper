using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers
{
	[Token(Token = "0x200016D")]
	public class SnakeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200016E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400047C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400047D")]
			public static Func<Instancer, SnakeBlockerVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400047E")]
			public static Func<Instancer, SandReconcile_SnakeShiftSystem> _003C_003E9__1_1;

			[Token(Token = "0x400047F")]
			public static Func<Instancer, SandReconcile_SnakeBodySplitSystem> _003C_003E9__1_2;

			[Token(Token = "0x4000480")]
			public static Func<Instancer, SnakeBodyCondition> _003C_003E9__1_3;

			[Token(Token = "0x60006EB")]
			[Address(RVA = "0x3E58CB8", Offset = "0x3E58CB8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Installers.SnakeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60006EC")]
			[Address(RVA = "0x3E58D1C", Offset = "0x3E58D1C", Length = "0x8")]
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

			internal SandReconcile_SnakeBodySplitSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				SandReconcile_SnakeBodySplitSystem instance = new SandReconcile_SnakeBodySplitSystem();
				return x.InjectInstance(instance);
			}

			internal SnakeBodyCondition _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_3");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x400047B")]
		[FieldOffset(Offset = "0x18")]
		private SnakeBlockerConfig m_config;

		[Token(Token = "0x60006E9")]
		[Address(RVA = "0x3E585A0", Offset = "0x3E585A0", Length = "0x710")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tgoto L_0078;\nL_0088:\n\t// 136 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0095;\nL_0095:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00A8;\n\tv241 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv245 = v241 == 0;\n\tif (v245) goto L_0229;\nL_00A8:\n\tv107[0] = v138;\n\tv391 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv395 = v391 == 0;\n\tif (v395) goto L_00C2;\n\tv367 = 0x21C11D0(v391, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v367 == 0;\n\tif (v374) goto L_0229;\nL_00C2:\n\tv107[1] = v391;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00CF;\nL_00CF:\n\tv437 = 0xB27E000 + 0x750;\n\tv231 = v428.<>9__1_1;\n\tv430 = v428.<>9__1_1 == 0;\n\tv431 = ~v430;\n\tif (v431) goto L_00FA;\n\tgoto L_00E2;\nL_00E2:\n\tgoto L_00EA;\nL_00FA:\n\t// 250 NewArr v460 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0107;\n\tv498 = v209 == 0;\n\tif (v498) goto L_011A;\n\tv368 = 0x21C11D0(v209, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v368 == 0;\n\tif (v375) goto L_0229;\nL_011A:\n\tv460[0] = v209;\n\tv509 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv510 = v509 == 0;\n\tif (v510) goto L_0134;\n\tv369 = 0x21C11D0(v509, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v369 == 0;\n\tif (v376) goto L_0229;\nL_0134:\n\tv460[1] = v509;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v460);\n\tgoto L_0141;\nL_0141:\n\tv534 = 0xB27E000 + 0x748;\n\tv232 = v528.<>9__1_2;\n\tv530 = v528.<>9__1_2 == 0;\n\tv531 = ~v530;\n\tif (v531) goto L_016C;\n\tgoto L_0154;\nL_0154:\n\tgoto L_015C;\nL_016C:\n\t// 364 NewArr v556 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0177;\nL_0177:\n\tv210 = System.Type::GetTypeFromHandle(*([v534 @ X22_v27 (System.Int32)]));\n\tv584 = v210 == 0;\n\tif (v584) goto L_0188;\n\tv370 = 0x21C11D0(v210, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v370 == 0;\n\tif (v377) goto L_0229;\nL_0188:\n\tv556[0] = v210;\n\tv594 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv595 = v594 == 0;\n\tif (v595) goto L_01A2;\n\tv371 = 0x21C11D0(v594, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = v371 == 0;\n\tif (v378) goto L_0229;\nL_01A2:\n\tv556[1] = v594;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v232, v556);\n\tgoto L_01AF;\nL_01AF:\n\tv619 = 0xB27E000 + 0xAC0;\n\tv233 = v613.<>9__1_3;\n\tv615 = v613.<>9__1_3 == 0;\n\tv616 = ~v615;\n\tif (v616) goto L_01DA;\n\tgoto L_01C2;\nL_01C2:\n\tgoto L_01CA;\nL_01DA:\n\t// 474 NewArr v641 @ X0_v70 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01E5;\nL_01E5:\n\tv211 = System.Type::GetTypeFromHandle(*([v619 @ X22_v22 (System.Int32)]));\n\tv669 = v211 == 0;\n\tif (v669) goto L_01F8;\n\tv372 = 0x21C11D0(v211, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = v372 == 0;\n\tif (v379) goto L_0229;\nL_01F8:\n\tv641[0] = v211;\n\tv680 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv681 = v680 == 0;\n\tif (v681) goto L_0212;\n\tv373 = 0x21C11D0(v680, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv380 = v373 == 0;\n\tif (v380) goto L_0229;\nL_0212:\n\tv641[1] = v680;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v233, v641);\n\treturn;\nL_0229:\n\tv388 = new System.ArrayTypeMismatchException();\n\tthrow v388;\nL_005C:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0069;\nL_0069:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0088;\nL_0078:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Blocker.SnakeBlockerVisualHandler>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_00EA:\n\tv484 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem>::.ctor(v484, v479.<>9, Il2CppMethodInfo);\n\tv496.<>9__1_1 = v484;\n\tv231 = v484;\nL_0107:\n\tv209 = System.Type::GetTypeFromHandle(*([v437 @ X22_v33 (System.Int32)]));\nL_015C:\n\tv574 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem>::.ctor(v574, v569.<>9, Il2CppMethodInfo);\n\tv582.<>9__1_2 = v574;\n\tv232 = v574;\nL_01CA:\n\tv659 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.Conditions.SnakeBodyCondition>::.ctor(v659, v654.<>9, Il2CppMethodInfo);\n\tv667.<>9__1_3 = v659;\n\tv233 = v659;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeInstaller::InstallBindings");
		}

		[Token(Token = "0x60006EA")]
		[Address(RVA = "0x3E58CB0", Offset = "0x3E58CB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SnakeInstaller()
		{
		}
	}
}
