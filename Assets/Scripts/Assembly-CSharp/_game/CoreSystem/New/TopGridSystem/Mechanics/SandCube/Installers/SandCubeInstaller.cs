using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers
{
	[Token(Token = "0x2000193")]
	public class SandCubeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000194")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400051F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000520")]
			public static Func<Instancer, SandCubeVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x4000521")]
			public static Func<Instancer, SandReconcile_TapEventSystem> _003C_003E9__1_1;

			[Token(Token = "0x600078C")]
			[Address(RVA = "0x3E6B250", Offset = "0x3E6B250", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers.SandCubeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600078D")]
			[Address(RVA = "0x3E6B2B4", Offset = "0x3E6B2B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandCubeVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SandCubeVisualHandler instance = new SandCubeVisualHandler();
				return x.InjectInstance(instance);
			}

			internal SandReconcile_TapEventSystem _003CInstallBindings_003Eb__1_1(Instancer x)
			{
				SandReconcile_TapEventSystem instance = new SandReconcile_TapEventSystem();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x400051E")]
		[FieldOffset(Offset = "0x18")]
		private SandCubeConfig m_config;

		[Token(Token = "0x600078A")]
		[Address(RVA = "0x3E6AE30", Offset = "0x3E6AE30", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tgoto L_005B;\nL_006B:\n\t// 107 NewArr v103 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0078;\nL_0078:\n\tv134 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler);\n\tv145 = v134 == 0;\n\tif (v145) goto L_0089;\n\tv224 = 0x21C11D0(v134, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv228 = v224 == 0;\n\tif (v228) goto L_014A;\nL_0089:\n\tv103[0] = v134;\n\tv355 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler);\n\tv358 = v355 == 0;\n\tif (v358) goto L_00A3;\n\tv340 = 0x21C11D0(v355, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv344 = v340 == 0;\n\tif (v344) goto L_014A;\nL_00A3:\n\tv103[1] = v355;\n\tv369 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv370 = v369 == 0;\n\tif (v370) goto L_00C3;\n\tv341 = 0x21C11D0(v369, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv345 = v341 == 0;\n\tif (v345) goto L_014A;\nL_00C3:\n\tv103[2] = v369;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v99, v103);\n\tgoto L_00D0;\nL_00D0:\n\tv395 = 0xB27E000 + 0x758;\n\tv216 = v389.<>9__1_1;\n\tv391 = v389.<>9__1_1 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00FB;\n\tgoto L_00E3;\nL_00E3:\n\tgoto L_00EB;\nL_00FB:\n\t// 251 NewArr v418 @ X0_v39 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0108;\n\tv448 = v202 == 0;\n\tif (v448) goto L_011B;\n\tv342 = 0x21C11D0(v202, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv346 = v342 == 0;\n\tif (v346) goto L_014A;\nL_011B:\n\tv418[0] = v202;\n\tv459 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv460 = v459 == 0;\n\tif (v460) goto L_0135;\n\tv343 = 0x21C11D0(v459, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv347 = v343 == 0;\n\tif (v347) goto L_014A;\nL_0135:\n\tv418[1] = v459;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v216, v418);\n\treturn;\nL_014A:\n\tv352 = new System.ArrayTypeMismatchException();\n\tthrow v352;\nL_003F:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_004C;\nL_004C:\n\tv99 = v74.<>9__1_0;\n\tv76 = v74.<>9__1_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_006B;\nL_005B:\n\tv114 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler>::.ctor(v114, v109.<>9, Il2CppMethodInfo);\n\tv138.<>9__1_0 = v114;\n\tv99 = v114;\nL_00EB:\n\tv436 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_TapEventSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_TapEventSystem>::.ctor(v436, v431.<>9, Il2CppMethodInfo);\n\tv446.<>9__1_1 = v436;\n\tv216 = v436;\nL_0108:\n\tv202 = System.Type::GetTypeFromHandle(*([v395 @ X22_v14 (System.Int32)]));\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeInstaller::InstallBindings");
		}

		[Token(Token = "0x600078B")]
		[Address(RVA = "0x3E6B248", Offset = "0x3E6B248", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SandCubeInstaller()
		{
		}
	}
}
