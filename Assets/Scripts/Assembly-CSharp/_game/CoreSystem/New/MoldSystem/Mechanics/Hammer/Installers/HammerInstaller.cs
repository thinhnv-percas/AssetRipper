using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings;
using _game.CoreSystem.New.MoldSystem.Visual;

namespace _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.Installers
{
	[Token(Token = "0x20002BD")]
	public class HammerInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002BE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400088C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400088D")]
			public static Func<Instancer, HammerVisualHandler> _003C_003E9__1_0;

			[Token(Token = "0x6000C3E")]
			[Address(RVA = "0x3ED3960", Offset = "0x3ED3960", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.Installers.HammerInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C3F")]
			[Address(RVA = "0x3ED39C4", Offset = "0x3ED39C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal HammerVisualHandler _003CInstallBindings_003Eb__1_0(Instancer x)
			{
				HammerVisualHandler instance = new HammerVisualHandler();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x400088B")]
		[FieldOffset(Offset = "0x18")]
		private HammerConfig m_config;

		[Token(Token = "0x6000C3C")]
		[Address(RVA = "0x3ED36F4", Offset = "0x3ED36F4", Length = "0x264")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tgoto L_004A;\nL_005A:\n\t// 90 NewArr v99 @ X0_v7 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0067;\nL_0067:\n\tv130 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler);\n\tv137 = v130 == 0;\n\tif (v137) goto L_0078;\n\tv181 = 0x21C11D0(v130, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv185 = v181 == 0;\n\tif (v185) goto L_00C5;\nL_0078:\n\tv99[0] = v130;\n\tv281 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler);\n\tv282 = v281 == 0;\n\tif (v282) goto L_0092;\n\tv272 = 0x21C11D0(v281, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv274 = v272 == 0;\n\tif (v274) goto L_00C5;\nL_0092:\n\tv99[1] = v281;\n\tv293 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler);\n\tv294 = v293 == 0;\n\tif (v294) goto L_00B2;\n\tv273 = 0x21C11D0(v293, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv275 = v273 == 0;\n\tif (v275) goto L_00C5;\nL_00B2:\n\tv99[2] = v293;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v95, v99);\n\treturn;\nL_00C5:\n\tv278 = new System.ArrayTypeMismatchException();\n\tthrow v278;\nL_002E:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\tgoto L_003B;\nL_003B:\n\tv95 = v70.<>9__1_0;\n\tv72 = v70.<>9__1_0 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_005A;\nL_004A:\n\tv110 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.UnityBindings.HammerVisualHandler>::.ctor(v110, v105.<>9, Il2CppMethodInfo);\n\tv133.<>9__1_0 = v110;\n\tv95 = v110;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_config);
			Func<Instancer, HammerVisualHandler> factory = _003C_003Ec._003C_003E9__1_0;
			if (_003C_003Ec._003C_003E9__1_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__1_0 = delegate(Instancer x)
				{
					HammerVisualHandler instance = new HammerVisualHandler();
					return x.InjectInstance(instance);
				});
			}
			Type[] array = new Type[3];
			Type typeFromHandle = typeof(HammerVisualHandler);
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
			Type typeFromHandle2 = typeof(HammerVisualHandler);
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
			Type typeFromHandle3 = typeof(IMoldVisualHandler);
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

		[Token(Token = "0x6000C3D")]
		[Address(RVA = "0x3ED3958", Offset = "0x3ED3958", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public HammerInstaller()
		{
		}
	}
}
