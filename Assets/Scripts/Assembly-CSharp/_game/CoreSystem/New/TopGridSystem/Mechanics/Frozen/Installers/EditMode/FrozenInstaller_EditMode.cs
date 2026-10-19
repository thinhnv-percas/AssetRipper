using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Installers.EditMode
{
	[Token(Token = "0x2000241")]
	public class FrozenInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000242")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40006ED")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40006EE")]
			public static Func<Instancer, FrozenVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x40006EF")]
			public static Func<Instancer, FrozenBlockCondition> _003C_003E9__1_1;

			[Token(Token = "0x60009D3")]
			[Address(RVA = "0x3E9C0E0", Offset = "0x3E9C0E0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Installers.EditMode.FrozenInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009D4")]
			[Address(RVA = "0x3E9C144", Offset = "0x3E9C144", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal FrozenVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrozenInstaller_EditMode._003C_003Ec::_003CInstallBindings_003Eb__1_0");
				return default;
			}

			internal FrozenBlockCondition _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				FrozenBlockCondition instance = new FrozenBlockCondition();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x40006EC")]
		[FieldOffset(Offset = "0x18")]
		private FrozenConfig m_config;

		[Token(Token = "0x60009D1")]
		[Address(RVA = "0x3E9BD04", Offset = "0x3E9BD04", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tgoto L_005B;\nL_006B:\n\t// 107 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0078;\nL_0078:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_008B;\n\tv204 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = v204 == 0;\n\tif (v208) goto L_012C;\nL_008B:\n\tv103[0] = v134;\n\tv313 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv316 = v313 == 0;\n\tif (v316) goto L_00A5;\n\tv301 = 0x21C11D0(v313, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv304 = v301 == 0;\n\tif (v304) goto L_012C;\nL_00A5:\n\tv103[1] = v313;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00B2;\nL_00B2:\n\tv340 = 0xB27C000 + 0xCF8;\n\tv196 = v334.<>9__1_1;\n\tv336 = v334.<>9__1_1 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_00DD;\n\tgoto L_00C5;\nL_00C5:\n\tgoto L_00CD;\nL_00DD:\n\t// 221 NewArr v363 @ X0_v33 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00EA;\n\tv393 = v182 == 0;\n\tif (v393) goto L_00FD;\n\tv302 = 0x21C11D0(v182, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv305 = v302 == 0;\n\tif (v305) goto L_012C;\nL_00FD:\n\tv363[0] = v182;\n\tv404 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv405 = v404 == 0;\n\tif (v405) goto L_0117;\n\tv303 = 0x21C11D0(v404, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv306 = v303 == 0;\n\tif (v306) goto L_012C;\nL_0117:\n\tv363[1] = v404;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v196, v363);\n\treturn;\nL_012C:\n\tv310 = new System.ArrayTypeMismatchException();\n\tthrow v310;\nL_003F:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_004C;\nL_004C:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_006B;\nL_005B:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00CD:\n\tv381 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions.FrozenBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.Conditions.FrozenBlockCondition>::.ctor(v381, v376.<>9, Il2CppMethodInfo);\n\tv391.<>9__1_1 = v381;\n\tv196 = v381;\nL_00EA:\n\tv182 = System.Type::GetTypeFromHandle(*([v340 @ X22_v15 (System.Int32)]));\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrozenInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x60009D2")]
		[Address(RVA = "0x3E9C0D8", Offset = "0x3E9C0D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public FrozenInstaller_EditMode()
		{
		}
	}
}
