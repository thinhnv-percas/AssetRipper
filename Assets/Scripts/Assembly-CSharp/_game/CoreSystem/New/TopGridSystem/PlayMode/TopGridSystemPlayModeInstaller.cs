using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Runtime;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.PlayMode
{
	[Token(Token = "0x2000146")]
	public class TopGridSystemPlayModeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000147")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400042C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400042D")]
			public static Func<Instancer, TopGridCmdProcessor> _003C_003E9__2_0;

			[Token(Token = "0x600066A")]
			[Address(RVA = "0x3DB6334", Offset = "0x3DB6334", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.PlayMode.TopGridSystemPlayModeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600066B")]
			[Address(RVA = "0x3DB6398", Offset = "0x3DB6398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal TopGridCmdProcessor _003CInstallBindings_003Eb__2_0(Instancer x)
			{
				TopGridCmdProcessor instance = new TopGridCmdProcessor();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x400042A")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualHandler m_visualHandlerPrefab;

		[SerializeField]
		[Token(Token = "0x400042B")]
		[FieldOffset(Offset = "0x20")]
		private TopGridReconcileTick_Runtime m_reconcileTickPrefab;

		[Token(Token = "0x6000667")]
		[Address(RVA = "0x3DB5F4C", Offset = "0x3DB5F4C", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tgoto L_005C;\nL_006C:\n\t// 108 NewArr v101 @ X0_v6 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0079;\nL_0079:\n\tv132 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor);\n\tv143 = v132 == 0;\n\tif (v143) goto L_0090;\n\tv195 = 0x21C11D0(v132, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = v195 == 0;\n\tif (v199) goto L_0108;\nL_0090:\n\tv101[0] = v132;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v97, v101);\n\tgoto L_00A3;\n\tv168._ownedBySpawn = 1;\n\t// 173 NewArr v320 @ X0_v27 (System.Type[]), typeof(System.Type[]), 1\n\tv169 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler);\n\tv322 = v169 == 0;\n\tif (v322) goto L_00C8;\n\tv247 = 0x21C11D0(v169, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv250 = v247 == 0;\n\tif (v250) goto L_0108;\nL_00C8:\n\tv320[0] = v169;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v168, v320);\n\tv338 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Runtime.TopGridReconcileTick_Runtime>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Runtime.TopGridReconcileTick_Runtime>::.ctor(v338, this, Il2CppMethodInfo);\n\t// 217 NewArr v342 @ X0_v38 (System.Type[]), typeof(System.Type[]), 1\n\tv170 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Runtime.TopGridReconcileTick_Runtime);\n\tv344 = v170 == 0;\n\tif (v344) goto L_00F0;\n\tv248 = 0x21C11D0(v170, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv251 = v248 == 0;\n\tif (v251) goto L_0108;\nL_00F0:\n\tv342[0] = v170;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v338, v342);\n\treturn;\nL_0108:\n\tv258 = new System.ArrayTypeMismatchException();\n\tthrow v258;\nL_0045:\n\tgoto L_004D;\nL_005C:\n\tv112 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridCmdProcessor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridCmdProcessor>::.ctor(v112, v107.<>9, Il2CppMethodInfo);\n\tv136.<>9__2_0 = v112;\n\tv97 = v112;\nL_00A3:\n\tv168 = UnityEngine.Object::Instantiate(this.m_visualHandlerPrefab);\nL_004D:\n\tv97 = v72.<>9__2_0;\n\tv74 = v72.<>9__2_0 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_006C;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, TopGridCmdProcessor> factory = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__2_0 = delegate(Instancer x)
				{
					TopGridCmdProcessor instance = new TopGridCmdProcessor();
					return x.InjectInstance(instance);
				});
			}
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(ITopGridCmdProcessor);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_01e3;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(factory, array);
			TopGridVisualHandler topGridVisualHandler = UnityEngine.Object.Instantiate(m_visualHandlerPrefab);
			topGridVisualHandler._ownedBySpawn = true;
			Type[] array2 = new Type[1];
			Type typeFromHandle2 = typeof(TopGridVisualHandler);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_01e3;
				}
			}
			array2[0] = typeFromHandle2;
			containerBuilder.AddSingleton(topGridVisualHandler, array2);
			Func<Instancer, TopGridReconcileTick_Runtime> factory2 = (Instancer x) => x.Instantiate(m_reconcileTickPrefab);
			Type[] array3 = new Type[1];
			Type typeFromHandle3 = typeof(TopGridReconcileTick_Runtime);
			if ((object)typeFromHandle3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_01e3;
				}
			}
			array3[0] = typeFromHandle3;
			containerBuilder.AddSingleton(factory2, array3);
			return;
			IL_01e3:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000668")]
		[Address(RVA = "0x3DB62C4", Offset = "0x3DB62C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TopGridSystemPlayModeInstaller()
		{
		}
	}
}
