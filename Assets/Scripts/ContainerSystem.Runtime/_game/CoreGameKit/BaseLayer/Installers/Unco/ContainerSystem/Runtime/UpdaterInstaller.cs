using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Core;
using UncoPackages.ContainerSystem.Runtime;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime
{
	[Serializable]
	[Token(Token = "0x2000009")]
	public class UpdaterInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400000C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400000D")]
			public static Func<Instancer, UpdateBinder> _003C_003E9__1_0;

			[Token(Token = "0x6000010")]
			[Address(RVA = "0x3F2E7DC", Offset = "0x3F2E7DC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime.UpdaterInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000011")]
			[Address(RVA = "0x3F2E840", Offset = "0x3F2E840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal UpdateBinder _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				UpdateBinder updateBinder = new UpdateBinder();
				UpdateBinder updateBinder2 = x.InjectInstance(updateBinder);
				return updateBinder;
			}
		}

		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private Updater m_updaterPrefab;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3F2E494", Offset = "0x3F2E494", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001A;\nL_001A:\n\tv70 = 0xB2C2000 + 0x9D8;\n\tv152 = v60.<>9__1_0;\n\tv62 = v60.<>9__1_0 == 0;\n\tif (v62) goto L_006F;\n\tv145 = *([v70 @ X24_v11 (System.Int32)]);\n\tv82 = *([v145 @ X22_v5+38]) == 0;\n\tv119 = containerBuilder;\n\tv121 = v145;\n\tv126 = v152;\n\tif (v82) goto L_008B;\nL_0023:\n\tv147 = containerBuilder._builder;\nL_002C:\n\tv159 = *([v145 @ X22_v5+38]);\n\tv162 = Reflex.Core.ContainerBuilder::AddScoped /* +1 sharing this address */(v147, v152, *([v159 @ X8_v19+8]));\n\tv183 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, UncoPackages.ContainerSystem.Runtime.Updater>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, UncoPackages.ContainerSystem.Runtime.Updater>::.ctor(v183, this, Il2CppMethodInfo);\n\tv211 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v183);\n\treturn;\nL_006F:\n\tgoto L_0077;\n\tv145 = *([v70 @ X24_v11 (System.Int32)]);\n\tv224 = *([v145 @ X22_v5+38]) == 0;\n\tv110 = ~v224;\n\tv152 = v137;\n\tv119 = v137;\n\tv121 = v145;\n\tv126 = v137;\n\tif (v110) goto L_0023;\nL_008B:\n\tv128 = 0x220C2B8(v121, v119, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = containerBuilder._builder;\n\tv174 = containerBuilder._builder == 0;\n\tv150 = ~v174;\n\tv145 = v121;\n\tv152 = v126;\n\tif (v150) goto L_002C;\n\tthrow System.NullReferenceException;\nL_0077:\n\tv137 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime.UpdateBinder>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime.UpdateBinder>::.ctor(v137, v131.<>9, Il2CppMethodInfo);\n\tv185.<>9__1_0 = v137;\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UpdaterInstaller::InstallBindings");
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x3F2E660", Offset = "0x3F2E660", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UpdaterInstaller()
		{
		}
	}
}
