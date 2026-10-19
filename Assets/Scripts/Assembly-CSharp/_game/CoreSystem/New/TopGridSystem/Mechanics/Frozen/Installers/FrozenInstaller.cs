using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Installers
{
	[Token(Token = "0x200023F")]
	public class FrozenInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000240")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006E8")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006E9")]
			public static Func<Instancer, FrozenVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x40006EA")]
			public static Func<Instancer, SandReconcile_FrozenVisualSystem> _003C_003E9__1_1;

			[Token(Token = "0x40006EB")]
			public static Func<Instancer, FrozenBlockCondition> _003C_003E9__1_2;

			[Token(Token = "0x60009CC")]
			[Address(RVA = "0x3E9BA08", Offset = "0x3E9BA08", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Installers.FrozenInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009CD")]
			[Address(RVA = "0x3E9BA6C", Offset = "0x3E9BA6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal FrozenVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrozenInstaller._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal SandReconcile_FrozenVisualSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_FrozenVisualSystem instance = new SandReconcile_FrozenVisualSystem();
				return x.InjectInstance(instance);
			}

			internal FrozenBlockCondition _003CInstallBindings_003Eb__1_2(Instancer x)
			{
				FrozenBlockCondition instance = new FrozenBlockCondition();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x40006E7")]
		[FieldOffset(Offset = "0x18")]
		private FrozenConfig m_config;

		[Token(Token = "0x60009CA")]
		[Address(RVA = "0x3E9B488", Offset = "0x3E9B488", Length = "0x578")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004E;\n\tgoto L_006A;\nL_007A:\n\t// 122 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0087;\nL_0087:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_009A;\n\tv219 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv223 = v219 == 0;\n\tif (v223) goto L_01AB;\nL_009A:\n\tv103[0] = v134;\n\tv347 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv351 = v347 == 0;\n\tif (v351) goto L_00B4;\n\tv329 = 0x21C11D0(v347, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv334 = v329 == 0;\n\tif (v334) goto L_01AB;\nL_00B4:\n\tv103[1] = v347;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00C1;\nL_00C1:\n\tv389 = 0xB27E000 + 0x710;\n\tv210 = v383.<>9__1_1;\n\tv385 = v383.<>9__1_1 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00EC;\n\tgoto L_00D4;\nL_00D4:\n\tgoto L_00DC;\nL_00EC:\n\t// 236 NewArr v412 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00F9;\n\tv442 = v192 == 0;\n\tif (v442) goto L_010C;\n\tv330 = 0x21C11D0(v192, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv335 = v330 == 0;\n\tif (v335) goto L_01AB;\nL_010C:\n\tv412[0] = v192;\n\tv453 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv454 = v453 == 0;\n\tif (v454) goto L_0126;\n\tv331 = 0x21C11D0(v453, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv336 = v331 == 0;\n\tif (v336) goto L_01AB;\nL_0126:\n\tv412[1] = v453;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v210, v412);\n\tgoto L_0133;\nL_0133:\n\tv478 = 0xB27C000 + 0xCF8;\n\tv211 = v472.<>9__1_2;\n\tv474 = v472.<>9__1_2 == 0;\n\tv475 = ~v474;\n\tif (v475) goto L_015E;\n\tgoto L_0146;\nL_0146:\n\tgoto L_014E;\nL_015E:\n\t// 350 NewArr v500 @ X0_v51 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0169;\nL_0169:\n\tv193 = System.Type::GetTypeFromHandle(*([v478 @ X22_v18 (System.Int32)]));\n\tv528 = v193 == 0;\n\tif (v528) goto L_017C;\n\tv332 = 0x21C11D0(v193, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv337 = v332 == 0;\n\tif (v337) goto L_01AB;\nL_017C:\n\tv500[0] = v193;\n\tv539 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv540 = v539 == 0;\n\tif (v540) goto L_0196;\n\tv333 = 0x21C11D0(v539, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv338 = v333 == 0;\n\tif (v338) goto L_01AB;\nL_0196:\n\tv500[1] = v539;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v211, v500);\n\treturn;\nL_01AB:\n\tv344 = new System.ArrayTypeMismatchException();\n\tthrow v344;\nL_004E:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_005B;\nL_005B:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_007A;\nL_006A:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00DC:\n\tv430 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems.SandReconcile_FrozenVisualSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems.SandReconcile_FrozenVisualSystem>::.ctor(v430, v425.<>9, Il2CppMethodInfo);\n\tv440.<>9__1_1 = v430;\n\tv210 = v430;\nL_00F9:\n\tv192 = System.Type::GetTypeFromHandle(*([v389 @ X22_v24 (System.Int32)]));\nL_014E:\n\tv518 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions.FrozenBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions.FrozenBlockCondition>::.ctor(v518, v513.<>9, Il2CppMethodInfo);\n\tv526.<>9__1_2 = v518;\n\tv211 = v518;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenInstaller::InstallBindings");
		}

		[Token(Token = "0x60009CB")]
		[Address(RVA = "0x3E9BA00", Offset = "0x3E9BA00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public FrozenInstaller()
		{
		}
	}
}
