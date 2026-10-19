using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode
{
	[Token(Token = "0x20002C8")]
	public class MoldFillDisplayInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002C9")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40008A0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40008A1")]
			public static Func<Instancer, MoldFillDisplayConfig> _003C_003E9__0_0;

			[Token(Token = "0x40008A2")]
			public static Func<Instancer, MoldFillDisplayCore> _003C_003E9__0_1;

			[Token(Token = "0x6000C5F")]
			[Address(RVA = "0x3ED5A70", Offset = "0x3ED5A70", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode.MoldFillDisplayInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C60")]
			[Address(RVA = "0x3ED5AD4", Offset = "0x3ED5AD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal MoldFillDisplayConfig _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				MoldFillDisplayCore componentInChildren = result.GetComponentInChildren<MoldFillDisplayCore>(includeInactive: true);
				return new MoldFillDisplayConfig
				{
					TextPrefab = componentInChildren.m_textPrefab,
					StopFillFrameThreshold = componentInChildren.m_stopFillFrameThreshold
				};
			}

			internal MoldFillDisplayCore _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				MoldFillDisplayCore componentInChildren = result.GetComponentInChildren<MoldFillDisplayCore>(includeInactive: true);
				return x.InjectMono(componentInChildren);
			}
		}

		[Token(Token = "0x6000C5D")]
		[Address(RVA = "0x3ED53F0", Offset = "0x3ED53F0", Length = "0x468")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tSystem.Object::.ctor(v70);\n\t// 86 NewArr v81 @ X0_v7 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0063;\nL_0063:\n\tv100 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCleaner);\n\tv109 = v100 == 0;\n\tif (v109) goto L_0076;\n\tv147 = 0x21C11D0(v100, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = v147 == 0;\n\tif (v151) goto L_0149;\nL_0076:\n\tv81[0] = v100;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v60, v81);\n\t// 128 NewArr v214 @ X0_v25 (System.Type[]), typeof(System.Type[]), 1\n\tv123 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplayCreator);\n\tv256 = v123 == 0;\n\tif (v256) goto L_0099;\n\tv189 = 0x21C11D0(v123, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv192 = v189 == 0;\n\tif (v192) goto L_0149;\nL_0099:\n\tv214[0] = v123;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v70, v214);\n\tv269 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplaySystem();\n\tSystem.Object::.ctor(v269);\n\t// 168 NewArr v273 @ X0_v36 (System.Type[]), typeof(System.Type[]), 1\n\tv124 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces.IMoldFillDisplaySystem);\n\tv275 = v124 == 0;\n\tif (v275) goto L_00C1;\n\tv190 = 0x21C11D0(v124, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv193 = v190 == 0;\n\tif (v193) goto L_0149;\nL_00C1:\n\tv273[0] = v124;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v269, v273);\n\tv292 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayState();\n\t_game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayState::.ctor(v292);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v292);\n\tgoto L_00D6;\nL_00D6:\n\tv312 = 0xB2C2000 + 0xC30;\n\tv304 = v302.<>9__0_0 == 0;\n\tif (v304) goto L_00F6;\n\tv318 = 0x3C7CEBC(containerBuilder, v302.<>9__0_0, *([v312 @ X22_v21 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E3;\nL_00E3:\n\tv394 = 0xB2C2000 + 0xC38;\n\tv233 = v360.<>9__0_1;\n\tv362 = v360.<>9__0_1 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_0145;\n\tgoto L_0121;\nL_00F6:\n\tgoto L_00FE;\n\tv419 = 0x3C7CEBC(containerBuilder, v340, *([v312 @ X22_v21 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E3;\nL_0121:\n\tgoto L_0129;\n\tv233 = v427;\nL_0149:\n\tv201 = new System.ArrayTypeMismatchException();\n\tthrow v201;\nL_004B:\n\tv60 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode.RuntimeMoldFillDisplayCleaner();\n\tSystem.Object::.ctor(v60);\n\tv70 = new _game.CoreSystem.New.MoldSystem.FillDisplaySystem.PlayMode.RuntimeMoldFillDisplayCreator();\nL_0145:\n\tv235 = 0x3C7CEBC(containerBuilder, v233, *([v394 @ X22_v11 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_00FE:\n\tv340 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayConfig>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayConfig>::.ctor(v340, v334.<>9, Il2CppMethodInfo);\n\tv404.<>9__0_0 = v340;\nL_0129:\n\tv427 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCore>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.MoldFillDisplayCore>::.ctor(v427, v422.<>9, Il2CppMethodInfo);\n\tv433.<>9__0_1 = v427;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			RuntimeMoldFillDisplayCleaner instance = new RuntimeMoldFillDisplayCleaner();
			RuntimeMoldFillDisplayCreator instance2 = new RuntimeMoldFillDisplayCreator();
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(IMoldFillDisplayCleaner);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0293;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(instance, array);
			Type[] array2 = new Type[1];
			Type typeFromHandle2 = typeof(IMoldFillDisplayCreator);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0293;
				}
			}
			array2[0] = typeFromHandle2;
			containerBuilder.AddSingleton(instance2, array2);
			MoldFillDisplaySystem instance3 = new MoldFillDisplaySystem();
			Type[] array3 = new Type[1];
			Type typeFromHandle3 = typeof(IMoldFillDisplaySystem);
			if ((object)typeFromHandle3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0293;
				}
			}
			array3[0] = typeFromHandle3;
			containerBuilder.AddSingleton(instance3, array3);
			MoldFillDisplayState instance4 = new MoldFillDisplayState();
			containerBuilder.AddSingleton(instance4);
			int num = 187441152 + 3120;
			if (_003C_003Ec._003C_003E9__0_0 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, MoldFillDisplayConfig> _003C_003E9__0_ = delegate(Instancer x)
				{
					bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
					MoldFillDisplayCore componentInChildren = result.GetComponentInChildren<MoldFillDisplayCore>(includeInactive: true);
					return new MoldFillDisplayConfig
					{
						TextPrefab = componentInChildren.m_textPrefab,
						StopFillFrameThreshold = componentInChildren.m_stopFillFrameThreshold
					};
				};
				_003C_003Ec._003C_003E9__0_0 = _003C_003E9__0_;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num2 = 187441152 + 3128;
			Func<Instancer, MoldFillDisplayCore> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer x)
				{
					bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
					MoldFillDisplayCore componentInChildren = result.GetComponentInChildren<MoldFillDisplayCore>(includeInactive: true);
					return x.InjectMono(componentInChildren);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			return;
			IL_0293:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000C5E")]
		[Address(RVA = "0x3ED5A68", Offset = "0x3ED5A68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldFillDisplayInstaller()
		{
		}
	}
}
