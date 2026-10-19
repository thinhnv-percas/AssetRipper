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
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.EditMode
{
	[Token(Token = "0x20001AB")]
	public class PinInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001AC")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000538")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000539")]
			public static Func<Instancer, PinBlockerVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400053A")]
			public static Func<Instancer, PinBlockCondition> _003C_003E9__1_1;

			[Token(Token = "0x400053B")]
			public static Func<Instancer, SandReconcile_PinTriggerSystem> _003C_003E9__1_2;

			[Token(Token = "0x400053C")]
			public static Func<Instancer, SandReconcile_PinResolveSystem> _003C_003E9__1_3;

			[Token(Token = "0x400053D")]
			public static Func<Instancer, PinEditorMutations> _003C_003E9__1_4;

			[Token(Token = "0x400053E")]
			public static Func<Instancer, PinRemoveHook> _003C_003E9__1_5;

			[Token(Token = "0x60007B9")]
			[Address(RVA = "0x3E6DE28", Offset = "0x3E6DE28", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.EditMode.PinInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60007BA")]
			[Address(RVA = "0x3E6DE8C", Offset = "0x3E6DE8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal PinBlockerVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				PinBlockerVisualHandler instance = new PinBlockerVisualHandler();
				return x.InjectInstance(instance);
			}

			internal PinBlockCondition _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_1");
				return default;
			}

			internal SandReconcile_PinTriggerSystem _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				SandReconcile_PinTriggerSystem instance = new SandReconcile_PinTriggerSystem();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_PinResolveSystem _003CInstallBindings_003Eb__1_3(Instancer x)
			{
				SandReconcile_PinResolveSystem instance = new SandReconcile_PinResolveSystem();
				return x.InjectInstance(instance);
			}

			internal PinEditorMutations _003CInstallBindings_003Eb__1_4(Instancer x)
			{
				PinEditorMutations instance = new PinEditorMutations();
				return x.InjectInstance(instance);
			}

			internal PinRemoveHook _003CInstallBindings_003Eb__1_5(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_5");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000537")]
		[FieldOffset(Offset = "0x18")]
		private PinBlockerConfig m_config;

		[Token(Token = "0x60007B7")]
		[Address(RVA = "0x3E6D418", Offset = "0x3E6D418", Length = "0xA08")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0077;\n\tgoto L_0093;\nL_00A3:\n\t// 163 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00B0;\nL_00B0:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00C3;\n\tv267 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv271 = v267 == 0;\n\tif (v271) goto L_030C;\nL_00C3:\n\tv107[0] = v138;\n\tv445 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv449 = v445 == 0;\n\tif (v449) goto L_00DD;\n\tv412 = 0x21C11D0(v445, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv422 = v412 == 0;\n\tif (v422) goto L_030C;\nL_00DD:\n\tv107[1] = v445;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00EA;\nL_00EA:\n\tv491 = 0xB27E000 + 0x60;\n\tv255 = v482.<>9__1_1;\n\tv484 = v482.<>9__1_1 == 0;\n\tv485 = ~v484;\n\tif (v485) goto L_0115;\n\tgoto L_00FD;\nL_00FD:\n\tgoto L_0105;\nL_0115:\n\t// 277 NewArr v514 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0122;\n\tv556 = v225 == 0;\n\tif (v556) goto L_0135;\n\tv413 = 0x21C11D0(v225, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv423 = v413 == 0;\n\tif (v423) goto L_030C;\nL_0135:\n\tv514[0] = v225;\n\tv576 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv580 = v576 == 0;\n\tif (v580) goto L_014F;\n\tv414 = 0x21C11D0(v576, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv424 = v414 == 0;\n\tif (v424) goto L_030C;\nL_014F:\n\tv514[1] = v576;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v255, v514);\n\tgoto L_015C;\nL_015C:\n\tv615 = 0xB27E000 + 0x740;\n\tv256 = v609.<>9__1_2;\n\tv611 = v609.<>9__1_2 == 0;\n\tv612 = ~v611;\n\tif (v612) goto L_0187;\n\tgoto L_016F;\nL_016F:\n\tgoto L_0177;\nL_0187:\n\t// 391 NewArr v637 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0192;\nL_0192:\n\tv226 = System.Type::GetTypeFromHandle(*([v615 @ X22_v45 (System.Int32)]));\n\tv665 = v226 == 0;\n\tif (v665) goto L_01A5;\n\tv415 = 0x21C11D0(v226, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv425 = v415 == 0;\n\tif (v425) goto L_030C;\nL_01A5:\n\tv637[0] = v226;\n\tv676 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv677 = v676 == 0;\n\tif (v677) goto L_01BF;\n\tv416 = 0x21C11D0(v676, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv426 = v416 == 0;\n\tif (v426) goto L_030C;\nL_01BF:\n\tv637[1] = v676;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v256, v637);\n\tgoto L_01CC;\nL_01CC:\n\tv701 = 0xB27E000 + 0x738;\n\tv257 = v695.<>9__1_3;\n\tv697 = v695.<>9__1_3 == 0;\n\tv698 = ~v697;\n\tif (v698) goto L_01F7;\n\tgoto L_01DF;\nL_01DF:\n\tgoto L_01E7;\nL_01F7:\n\t// 503 NewArr v723 @ X0_v70 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0202;\nL_0202:\n\tv227 = System.Type::GetTypeFromHandle(*([v701 @ X22_v40 (System.Int32)]));\n\tv751 = v227 == 0;\n\tif (v751) goto L_0213;\n\tv417 = 0x21C11D0(v227, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv427 = v417 == 0;\n\tif (v427) goto L_030C;\nL_0213:\n\tv723[0] = v227;\n\tv761 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv762 = v761 == 0;\n\tif (v762) goto L_022D;\n\tv418 = 0x21C11D0(v761, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv428 = v418 == 0;\n\tif (v428) goto L_030C;\nL_022D:\n\tv723[1] = v761;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v257, v723);\n\tgoto L_023A;\nL_023A:\n\tv786 = 0xB27E000 + 0x78;\n\tv258 = v780.<>9__1_4;\n\tv782 = v780.<>9__1_4 == 0;\n\tv783 = ~v782;\n\tif (v783) goto L_0265;\n\tgoto L_024D;\nL_024D:\n\tgoto L_0255;\nL_0265:\n\t// 613 NewArr v809 @ X0_v89 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0272;\n\tv839 = v228 == 0;\n\tif (v839) goto L_0285;\n\tv419 = 0x21C11D0(v228, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv429 = v419 == 0;\n\tif (v429) goto L_030C;\nL_0285:\n\tv809[0] = v228;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v258, v809);\n\tgoto L_0292;\nL_0292:\n\tv863 = 0xB27E000 + 0x98;\n\tv259 = v857.<>9__1_5;\n\tv859 = v857.<>9__1_5 == 0;\n\tv860 = ~v859;\n\tif (v860) goto L_02BD;\n\tgoto L_02A5;\nL_02A5:\n\tgoto L_02AD;\nL_02BD:\n\t// 701 NewArr v885 @ X0_v101 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_02C8;\nL_02C8:\n\tv229 = System.Type::GetTypeFromHandle(*([v863 @ X22_v29 (System.Int32)]));\n\tv913 = v229 == 0;\n\tif (v913) goto L_02DB;\n\tv420 = 0x21C11D0(v229, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv430 = v420 == 0;\n\tif (v430) goto L_030C;\nL_02DB:\n\tv885[0] = v229;\n\tv924 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.EditMode.IEntityRemoveHook);\n\tv925 = v924 == 0;\n\tif (v925) goto L_02F5;\n\tv421 = 0x21C11D0(v924, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv431 = v421 == 0;\n\tif (v431) goto L_030C;\nL_02F5:\n\tv885[1] = v924;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v259, v885);\n\treturn;\nL_030C:\n\tv442 = new System.ArrayTypeMismatchException();\n\tthrow v442;\nL_0077:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0084;\nL_0084:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_00A3;\nL_0093:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_0105:\n\tv538 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>::.ctor(v538, v533.<>9, Il2CppMethodInfo);\n\tv554.<>9__1_1 = v538;\n\tv255 = v538;\nL_0122:\n\tv225 = System.Type::GetTypeFromHandle(*([v491 @ X22_v51 (System.Int32)]));\nL_0177:\n\tv655 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSy\n// ... truncated")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60007B8")]
		[Address(RVA = "0x3E6DE20", Offset = "0x3E6DE20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public PinInstaller_EditMode()
		{
		}
	}
}
