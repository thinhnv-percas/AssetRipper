using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers.EditMode
{
	[Token(Token = "0x2000196")]
	public class SandCubeInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000197")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000524")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000525")]
			public static Func<Instancer, SandCubeVisualHandler_Editor> _003C_003E9__1_0;

			[Token(Token = "0x6000794")]
			[Address(RVA = "0x3E6B668", Offset = "0x3E6B668", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers.EditMode.SandCubeInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000795")]
			[Address(RVA = "0x3E6B6CC", Offset = "0x3E6B6CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandCubeVisualHandler_Editor _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				SandCubeVisualHandler_Editor instance = new SandCubeVisualHandler_Editor();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000523")]
		[FieldOffset(Offset = "0x18")]
		private SandCubeConfig m_config;

		[Token(Token = "0x6000792")]
		[Address(RVA = "0x3E6B3E8", Offset = "0x3E6B3E8", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tgoto L_004D;\nL_005D:\n\t// 93 NewArr v99 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_006A;\nL_006A:\n\tv130 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeVisualHandler);\n\tv140 = v130 == 0;\n\tif (v140) goto L_007D;\n\tv184 = 0x21C11D0(v130, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = v184 == 0;\n\tif (v188) goto L_00CA;\nL_007D:\n\tv99[0] = v130;\n\tv286 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.EditMode.SandCubeVisualHandler_Editor);\n\tv287 = v286 == 0;\n\tif (v287) goto L_0097;\n\tv277 = 0x21C11D0(v286, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv279 = v277 == 0;\n\tif (v279) goto L_00CA;\nL_0097:\n\tv99[1] = v286;\n\tv298 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.ITopGridVisualHandler);\n\tv299 = v298 == 0;\n\tif (v299) goto L_00B7;\n\tv278 = 0x21C11D0(v298, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = v278 == 0;\n\tif (v280) goto L_00CA;\nL_00B7:\n\tv99[2] = v298;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v95, v99);\n\treturn;\nL_00CA:\n\tv283 = new System.ArrayTypeMismatchException();\n\tthrow v283;\nL_0031:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_003E;\nL_003E:\n\tv95 = v70.<>9__1_0;\n\tv72 = v70.<>9__1_0 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_005D;\nL_004D:\n\tv110 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.EditMode.SandCubeVisualHandler_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.EditMode.SandCubeVisualHandler_Editor>::.ctor(v110, v105.<>9, Il2CppMethodInfo);\n\tv134.<>9__1_0 = v110;\n\tv95 = v110;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_config);
			Func<Instancer, SandCubeVisualHandler_Editor> factory = _003C_003Ec._003C_003E9__1_0;
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__1_0 = delegate(Instancer x)
				{
					SandCubeVisualHandler_Editor instance = new SandCubeVisualHandler_Editor();
					return x.InjectInstance(instance);
				});
			}
			Type[] array = new Type[3];
			Type typeFromHandle = typeof(SandCubeVisualHandler);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0172;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(SandCubeVisualHandler_Editor);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0172;
				}
			}
			array[1] = typeFromHandle2;
			Type typeFromHandle3 = typeof(ITopGridVisualHandler);
			if ((object)typeFromHandle3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0172;
				}
			}
			array[2] = typeFromHandle3;
			containerBuilder.AddSingleton(factory, array);
			return;
			IL_0172:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000793")]
		[Address(RVA = "0x3E6B660", Offset = "0x3E6B660", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SandCubeInstaller_EditMode()
		{
		}
	}
}
