using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers
{
	[Token(Token = "0x20001A7")]
	public class PinInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001A8")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400052B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400052C")]
			public static Func<Instancer, PinBlockerVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x400052D")]
			public static Func<Instancer, PinBlockCondition> _003C_003E9__1_1;

			[Token(Token = "0x400052E")]
			public static Func<Instancer, SandReconcile_PinTriggerSystem> _003C_003E9__1_2;

			[Token(Token = "0x400052F")]
			public static Func<Instancer, SandReconcile_PinResolveSystem> _003C_003E9__1_3;

			[Token(Token = "0x60007A8")]
			[Address(RVA = "0x3E6C454", Offset = "0x3E6C454", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Installers.PinInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60007A9")]
			[Address(RVA = "0x3E6C4B8", Offset = "0x3E6C4B8", Length = "0x8")]
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
				global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_1");
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
		}

		[SerializeField]
		[Token(Token = "0x400052A")]
		[FieldOffset(Offset = "0x18")]
		private PinBlockerConfig m_config;

		[Token(Token = "0x60007A6")]
		[Address(RVA = "0x3E6BD3C", Offset = "0x3E6BD3C", Length = "0x710")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tgoto L_0078;\nL_0088:\n\t// 136 NewArr v107 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0095;\nL_0095:\n\tv138 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler);\n\tv149 = v138 == 0;\n\tif (v149) goto L_00A8;\n\tv239 = 0x21C11D0(v138, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv243 = v239 == 0;\n\tif (v243) goto L_0229;\nL_00A8:\n\tv107[0] = v138;\n\tv388 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv392 = v388 == 0;\n\tif (v392) goto L_00C2;\n\tv364 = 0x21C11D0(v388, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv371 = v364 == 0;\n\tif (v371) goto L_0229;\nL_00C2:\n\tv107[1] = v388;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v103, v107);\n\tgoto L_00CF;\nL_00CF:\n\tv434 = 0xB27E000 + 0x60;\n\tv229 = v425.<>9__1_1;\n\tv427 = v425.<>9__1_1 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_00FA;\n\tgoto L_00E2;\nL_00E2:\n\tgoto L_00EA;\nL_00FA:\n\t// 250 NewArr v457 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0107;\n\tv495 = v209 == 0;\n\tif (v495) goto L_011A;\n\tv365 = 0x21C11D0(v209, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv372 = v365 == 0;\n\tif (v372) goto L_0229;\nL_011A:\n\tv457[0] = v209;\n\tv506 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv507 = v506 == 0;\n\tif (v507) goto L_0134;\n\tv366 = 0x21C11D0(v506, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv373 = v366 == 0;\n\tif (v373) goto L_0229;\nL_0134:\n\tv457[1] = v506;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v229, v457);\n\tgoto L_0141;\nL_0141:\n\tv531 = 0xB27E000 + 0x740;\n\tv230 = v525.<>9__1_2;\n\tv527 = v525.<>9__1_2 == 0;\n\tv528 = ~v527;\n\tif (v528) goto L_016C;\n\tgoto L_0154;\nL_0154:\n\tgoto L_015C;\nL_016C:\n\t// 364 NewArr v553 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0177;\nL_0177:\n\tv210 = System.Type::GetTypeFromHandle(*([v531 @ X22_v27 (System.Int32)]));\n\tv581 = v210 == 0;\n\tif (v581) goto L_018A;\n\tv367 = 0x21C11D0(v210, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv374 = v367 == 0;\n\tif (v374) goto L_0229;\nL_018A:\n\tv553[0] = v210;\n\tv592 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv593 = v592 == 0;\n\tif (v593) goto L_01A4;\n\tv368 = 0x21C11D0(v592, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = v368 == 0;\n\tif (v375) goto L_0229;\nL_01A4:\n\tv553[1] = v592;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v230, v553);\n\tgoto L_01B1;\nL_01B1:\n\tv617 = 0xB27E000 + 0x738;\n\tv231 = v611.<>9__1_3;\n\tv613 = v611.<>9__1_3 == 0;\n\tv614 = ~v613;\n\tif (v614) goto L_01DC;\n\tgoto L_01C4;\nL_01C4:\n\tgoto L_01CC;\nL_01DC:\n\t// 476 NewArr v639 @ X0_v70 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01E7;\nL_01E7:\n\tv211 = System.Type::GetTypeFromHandle(*([v617 @ X22_v22 (System.Int32)]));\n\tv667 = v211 == 0;\n\tif (v667) goto L_01F8;\n\tv369 = 0x21C11D0(v211, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv376 = v369 == 0;\n\tif (v376) goto L_0229;\nL_01F8:\n\tv639[0] = v211;\n\tv677 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv678 = v677 == 0;\n\tif (v678) goto L_0212;\n\tv370 = 0x21C11D0(v677, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = v370 == 0;\n\tif (v377) goto L_0229;\nL_0212:\n\tv639[1] = v677;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v231, v639);\n\treturn;\nL_0229:\n\tv385 = new System.ArrayTypeMismatchException();\n\tthrow v385;\nL_005C:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_0069;\nL_0069:\n\tv103 = v78.<>9__1_0;\n\tv80 = v78.<>9__1_0 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0088;\nL_0078:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Blocker.PinBlockerVisualHandler>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv142.<>9__1_0 = v118;\n\tv103 = v118;\nL_00EA:\n\tv481 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.Conditions.PinBlockCondition>::.ctor(v481, v476.<>9, Il2CppMethodInfo);\n\tv493.<>9__1_1 = v481;\n\tv229 = v481;\nL_0107:\n\tv209 = System.Type::GetTypeFromHandle(*([v434 @ X22_v33 (System.Int32)]));\nL_015C:\n\tv571 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem>::.ctor(v571, v566.<>9, Il2CppMethodInfo);\n\tv579.<>9__1_2 = v571;\n\tv230 = v571;\nL_01CC:\n\tv657 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem>::.ctor(v657, v652.<>9, Il2CppMethodInfo);\n\tv665.<>9__1_3 = v657;\n\tv231 = v657;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinInstaller::InstallBindings");
		}

		[Token(Token = "0x60007A7")]
		[Address(RVA = "0x3E6C44C", Offset = "0x3E6C44C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public PinInstaller()
		{
		}
	}
}
