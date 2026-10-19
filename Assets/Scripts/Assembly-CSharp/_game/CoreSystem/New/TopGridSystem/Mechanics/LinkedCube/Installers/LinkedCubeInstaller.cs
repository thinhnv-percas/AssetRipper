using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.SandSystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers
{
	[Token(Token = "0x20001D0")]
	public class LinkedCubeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001D1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400059B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400059C")]
			public static Func<Instancer, LinkedCubeVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400059D")]
			public static Func<Instancer, SandReconcile_LinkedBreakSystem> _003C_003E9__1_1;

			[Token(Token = "0x400059E")]
			public static Func<Instancer, SandReconcile_LinkedCoverShareSystem> _003C_003E9__1_2;

			[Token(Token = "0x400059F")]
			public static Func<Instancer, SandReconcile_LinkedReevalShareSystem> _003C_003E9__1_3;

			[Token(Token = "0x6000855")]
			[Address(RVA = "0x3E7A210", Offset = "0x3E7A210", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.Installers.LinkedCubeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000856")]
			[Address(RVA = "0x3E7A274", Offset = "0x3E7A274", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal LinkedCubeVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal SandReconcile_LinkedBreakSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_LinkedBreakSystem instance = new SandReconcile_LinkedBreakSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_LinkedCoverShareSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				SandReconcile_LinkedCoverShareSystem instance = new SandReconcile_LinkedCoverShareSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_LinkedReevalShareSystem _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SandReconcile_LinkedReevalShareSystem instance = new SandReconcile_LinkedReevalShareSystem();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x400059A")]
		[FieldOffset(Offset = "0x18")]
		private LinkedCubeConfig m_config;

		[Token(Token = "0x6000853")]
		[Address(RVA = "0x3E79AC8", Offset = "0x3E79AC8", Length = "0x740")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0059;\n\tgoto L_0075;\nL_0085:\n\t// 133 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0092;\nL_0092:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00A3;\n\tv259 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv263 = v259 == 0;\n\tif (v263) goto L_0242;\nL_00A3:\n\tv107[0] = v138;\n\tv429 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler);\n\tv433 = v429 == 0;\n\tif (v433) goto L_00BD;\n\tv402 = 0x21C11D0(v429, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv410 = v402 == 0;\n\tif (v410) goto L_0242;\nL_00BD:\n\tv107[1] = v429;\n\tv453 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv457 = v453 == 0;\n\tif (v457) goto L_00DD;\n\tv403 = 0x21C11D0(v453, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv411 = v403 == 0;\n\tif (v411) goto L_0242;\nL_00DD:\n\tv107[2] = v453;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00EA;\nL_00EA:\n\tv493 = 0xB27E000 + 0x720;\n\tv249 = v487.<>9__1_1;\n\tv489 = v487.<>9__1_1 == 0;\n\tv490 = ~v489;\n\tif (v490) goto L_0115;\n\tgoto L_00FD;\nL_00FD:\n\tgoto L_0105;\nL_0115:\n\t// 277 NewArr v516 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0122;\n\tv546 = v229 == 0;\n\tif (v546) goto L_0135;\n\tv404 = 0x21C11D0(v229, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv412 = v404 == 0;\n\tif (v412) goto L_0242;\nL_0135:\n\tv516[0] = v229;\n\tv557 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv558 = v557 == 0;\n\tif (v558) goto L_014F;\n\tv405 = 0x21C11D0(v557, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv413 = v405 == 0;\n\tif (v413) goto L_0242;\nL_014F:\n\tv516[1] = v557;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v249, v516);\n\tgoto L_015C;\nL_015C:\n\tv582 = 0xB27E000 + 0x728;\n\tv250 = v576.<>9__1_2;\n\tv578 = v576.<>9__1_2 == 0;\n\tv579 = ~v578;\n\tif (v579) goto L_0187;\n\tgoto L_016F;\nL_016F:\n\tgoto L_0177;\nL_0187:\n\t// 391 NewArr v604 @ X0_v57 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0192;\nL_0192:\n\tv230 = System.Type::GetTypeFromHandle(*([v582 @ X22_v26 (System.Int32)]));\n\tv632 = v230 == 0;\n\tif (v632) goto L_01A3;\n\tv406 = 0x21C11D0(v230, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv414 = v406 == 0;\n\tif (v414) goto L_0242;\nL_01A3:\n\tv604[0] = v230;\n\tv642 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv643 = v642 == 0;\n\tif (v643) goto L_01BD;\n\tv407 = 0x21C11D0(v642, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv415 = v407 == 0;\n\tif (v415) goto L_0242;\nL_01BD:\n\tv604[1] = v642;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v250, v604);\n\tgoto L_01CA;\nL_01CA:\n\tv667 = 0xB27E000 + 0x730;\n\tv251 = v661.<>9__1_3;\n\tv663 = v661.<>9__1_3 == 0;\n\tv664 = ~v663;\n\tif (v664) goto L_01F5;\n\tgoto L_01DD;\nL_01DD:\n\tgoto L_01E5;\nL_01F5:\n\t// 501 NewArr v689 @ X0_v76 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0200;\nL_0200:\n\tv231 = System.Type::GetTypeFromHandle(*([v667 @ X22_v21 (System.Int32)]));\n\tv717 = v231 == 0;\n\tif (v717) goto L_0211;\n\tv408 = 0x21C11D0(v231, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv416 = v408 == 0;\n\tif (v416) goto L_0242;\nL_0211:\n\tv689[0] = v231;\n\tv727 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv728 = v727 == 0;\n\tif (v728) goto L_022B;\n\tv409 = 0x21C11D0(v727, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv417 = v409 == 0;\n\tif (v417) goto L_0242;\nL_022B:\n\tv689[1] = v727;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v251, v689);\n\treturn;\nL_0242:\n\tv426 = new System.ArrayTypeMismatchException();\n\tthrow v426;\nL_0059:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0066;\nL_0066:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0085;\nL_0075:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeVisualHandler>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_0105:\n\tv534 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem>::.ctor(v534, v529.<>9, Il2CppMethodInfo);\n\tv544.<>9__1_1 = v534;\n\tv249 = v534;\nL_0122:\n\tv229 = System.Type::GetTypeFromHandle(*([v493 @ X22_v32 (System.Int32)]));\nL_0177:\n\tv622 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedCoverShareSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedCoverShareSystem>::.ctor(v622, v617.<>9, Il2CppMethodInfo);\n\tv630.<>9__1_2 = v622;\n\tv250 = v622;\nL_01E5:\n\tv707 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedReevalShareSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedReevalShareSystem>::.ctor(v707, v702.<>9, Il2CppMethodInfo);\n\tv715.<>9__1_3 = v707;\n\tv251 = v707;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeInstaller::InstallBindings");
		}

		[Token(Token = "0x6000854")]
		[Address(RVA = "0x3E7A208", Offset = "0x3E7A208", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public LinkedCubeInstaller()
		{
		}
	}
}
