using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.SandPhysics.SDF;
using _game.CoreSystem.SandPhysics.Services;

namespace _game.CoreSystem.SandPhysics.PlayMode
{
	[Token(Token = "0x2000114")]
	public class SandPhysicsPlayModeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000115")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000396")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000397")]
			public static Func<Instancer, SandCollisionService> _003C_003E9__2_0;

			[Token(Token = "0x4000398")]
			public static Func<Instancer, MovingCubeRegistry> _003C_003E9__2_1;

			[Token(Token = "0x4000399")]
			public static Func<Instancer, SandBreakEventQueue> _003C_003E9__2_2;

			[Token(Token = "0x400039A")]
			public static Func<Instancer, SandParticleQueries> _003C_003E9__2_3;

			[Token(Token = "0x400039B")]
			public static Func<Instancer, SandPrototypeEntityFactory> _003C_003E9__2_4;

			[Token(Token = "0x400039C")]
			public static Func<Instancer, SandSDFService> _003C_003E9__2_5;

			[Token(Token = "0x400039D")]
			public static Func<Instancer, SandPhysicsBootstrap> _003C_003E9__2_6;

			[Token(Token = "0x60005D1")]
			[Address(RVA = "0x3DAFE58", Offset = "0x3DAFE58", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.SandPhysics.PlayMode.SandPhysicsPlayModeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60005D2")]
			[Address(RVA = "0x3DAFEBC", Offset = "0x3DAFEBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SandCollisionService _003CInstallBindings_003Eb__2_0(Instancer x)
			{
				SandCollisionService instance = new SandCollisionService();
				return x.InjectInstance(instance);
			}

			internal MovingCubeRegistry _003CInstallBindings_003Eb__2_1(Instancer x)
			{
				MovingCubeRegistry instance = new MovingCubeRegistry();
				return x.InjectInstance(instance);
			}

			internal SandBreakEventQueue _003CInstallBindings_003Eb__2_2(Instancer x)
			{
				SandBreakEventQueue instance = new SandBreakEventQueue();
				return x.InjectInstance(instance);
			}

			internal SandParticleQueries _003CInstallBindings_003Eb__2_3(Instancer x)
			{
				SandParticleQueries instance = new SandParticleQueries();
				return x.InjectInstance(instance);
			}

			internal SandPrototypeEntityFactory _003CInstallBindings_003Eb__2_4(Instancer x)
			{
				SandPrototypeEntityFactory instance = new SandPrototypeEntityFactory();
				return x.InjectInstance(instance);
			}

			internal SandSDFService _003CInstallBindings_003Eb__2_5(Instancer x)
			{
				SandSDFService instance = new SandSDFService();
				return x.InjectInstance(instance);
			}

			internal SandPhysicsBootstrap _003CInstallBindings_003Eb__2_6(Instancer x)
			{
				SandPhysicsBootstrap instance = new SandPhysicsBootstrap();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000394")]
		[FieldOffset(Offset = "0x18")]
		private SandRenderingAssetsSO m_renderAssets;

		[SerializeField]
		[Token(Token = "0x4000395")]
		[FieldOffset(Offset = "0x20")]
		private SandSDFConfig m_sdfConfig;

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0x3DAF600", Offset = "0x3DAF600", Length = "0x850")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006E;\nL_007B:\n\tv78 = System.Type::GetTypeFromHandle(_game.CoreSystem.SandPhysics.SandRenderingAssetsSO);\n\tv87 = v78 == 0;\n\tif (v87) goto L_008E;\n\tv126 = 0x21C11D0(v78, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv130 = v126 == 0;\n\tif (v130) goto L_0270;\nL_008E:\n\tv59[0] = v78;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_renderAssets, v59);\n\t// 153 NewArr v193 @ X0_v21 (System.Type[]), typeof(System.Type[]), 1\n\tv103 = System.Type::GetTypeFromHandle(_game.CoreSystem.SandPhysics.SDF.SandSDFConfig);\n\tv239 = v103 == 0;\n\tif (v239) goto L_00B2;\n\tv169 = 0x21C11D0(v103, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv172 = v169 == 0;\n\tif (v172) goto L_0270;\nL_00B2:\n\tv193[0] = v103;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_sdfConfig, v193);\n\tv264 = new _game.CoreSystem.SandPhysics.SandPhysicsBuffers();\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::.ctor(v264);\n\t// 193 NewArr v274 @ X0_v32 (System.Type[]), typeof(System.Type[]), 1\n\tv104 = System.Type::GetTypeFromHandle(_game.CoreSystem.SandPhysics.SandPhysicsBuffers);\n\tv285 = v104 == 0;\n\tif (v285) goto L_00D8;\n\tv170 = 0x21C11D0(v104, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv173 = v170 == 0;\n\tif (v173) goto L_0270;\nL_00D8:\n\tv274[0] = v104;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v264, v274);\n\tgoto L_00E5;\nL_00E5:\n\tv327 = 0xB2C2000 + 0xCF0;\n\tv321 = v319.<>9__2_0 == 0;\n\tif (v321) goto L_0146;\n\tv337 = 0x3C7CEBC(containerBuilder, v319.<>9__2_0, *([v327 @ X22_v59 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00F2;\nL_00F2:\n\tv403 = 0xB2C2000 + 0xCB0;\n\tv381 = v379.<>9__2_1 == 0;\n\tif (v381) goto L_0171;\n\tv415 = 0x3C7CEBC(containerBuilder, v379.<>9__2_1, *([v403 @ X22_v55 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00FF;\nL_00FF:\n\tv494 = 0xB2C2000 + 0xCE8;\n\tv471 = v469.<>9__2_2 == 0;\n\tif (v471) goto L_019C;\n\tv506 = 0x3C7CEBC(containerBuilder, v469.<>9__2_2, *([v494 @ X22_v51 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_010C;\nL_010C:\n\tv585 = 0xB2C2000 + 0xCF8;\n\tv562 = v560.<>9__2_3 == 0;\n\tif (v562) goto L_01C7;\n\tv597 = 0x3C7CEBC(containerBuilder, v560.<>9__2_3, *([v585 @ X22_v47 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0119;\nL_0119:\n\tv676 = 0xB2C2000 + 0xD08;\n\tv653 = v651.<>9__2_4 == 0;\n\tif (v653) goto L_01F2;\n\tv688 = 0x3C7CEBC(containerBuilder, v651.<>9__2_4, *([v676 @ X22_v43 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0126;\nL_0126:\n\tv767 = 0xB2C2000 + 0xD40;\n\tv744 = v742.<>9__2_5 == 0;\n\tif (v744) goto L_021D;\n\tv779 = 0x3C7CEBC(containerBuilder, v742.<>9__2_5, *([v767 @ X22_v39 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0133;\nL_0133:\n\tv861 = 0xB2C2000 + 0xD00;\n\tv212 = v833.<>9__2_6;\n\tv835 = v833.<>9__2_6 == 0;\n\tv836 = ~v835;\n\tif (v836) goto L_026C;\n\tgoto L_0248;\nL_0146:\n\tgoto L_014E;\n\tv449 = 0x3C7CEBC(containerBuilder, v359, *([v327 @ X22_v59 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00F2;\nL_0171:\n\tgoto L_0179;\n\tv540 = 0x3C7CEBC(containerBuilder, v447, *([v403 @ X22_v55 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00FF;\nL_019C:\n\tgoto L_01A4;\n\tv631 = 0x3C7CEBC(containerBuilder, v538, *([v494 @ X22_v51 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_010C;\nL_01C7:\n\tgoto L_01CF;\n\tv722 = 0x3C7CEBC(containerBuilder, v629, *([v585 @ X22_v47 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0119;\nL_01F2:\n\tgoto L_01FA;\n\tv813 = 0x3C7CEBC(containerBuilder, v720, *([v676 @ X22_v43 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0126;\nL_021D:\n\tgoto L_0225;\n\tv893 = 0x3C7CEBC(containerBuilder, v811, *([v767 @ X22_v39 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0133;\nL_0248:\n\tgoto L_0250;\n\tv212 = v901;\nL_0270:\n\tv180 = new System.ArrayTypeMismatchException();\n\tthrow v180;\nL_006E:\n\t// 110 NewArr v59 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_007B;\nL_026C:\n\tv216 = 0x3C7CEBC(containerBuilder, v212, *([v861 @ X22_v9 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_014E:\n\tv359 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandCollisionService>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandCollisionService>::.ctor(v359, v353.<>9, Il2CppMethodInfo);\n\tv432.<>9__2_0 = v359;\nL_0179:\n\tv447 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.MovingCubeRegistry>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.MovingCubeRegistry>::.ctor(v447, v441.<>9, Il2CppMethodInfo);\n\tv523.<>9__2_1 = v447;\nL_01A4:\n\tv538 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandBreakEventQueue>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandBreakEventQueue>::.ctor(v538, v532.<>9, Il2CppMethodInfo);\n\tv614.<>9__2_2 = v538;\nL_01CF:\n\tv629 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandParticleQueries>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandParticleQueries>::.ctor(v629, v623.<>9, Il2CppMethodInfo);\n\tv705.<>9__2_3 = v629;\nL_01FA:\n\tv720 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandPrototypeEntityFactory>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SandPhysics.Services.SandPrototypeEntityFactory>::.ctor(v720, v714.<>9, Il2CppMethodInfo);\n// ... truncated")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(SandRenderingAssetsSO);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0411;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(m_renderAssets, array);
			Type[] array2 = new Type[1];
			Type typeFromHandle2 = typeof(SandSDFConfig);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0411;
				}
			}
			array2[0] = typeFromHandle2;
			containerBuilder.AddSingleton(m_sdfConfig, array2);
			SandPhysicsBuffers instance = new SandPhysicsBuffers();
			Type[] array3 = new Type[1];
			Type typeFromHandle3 = typeof(SandPhysicsBuffers);
			if ((object)typeFromHandle3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj3 = default(object);
				if (obj3 == null)
				{
					goto IL_0411;
				}
			}
			array3[0] = typeFromHandle3;
			containerBuilder.AddSingleton(instance, array3);
			int num = 187441152 + 3312;
			if (_003C_003Ec._003C_003E9__2_0 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, SandCollisionService> _003C_003E9__2_ = delegate(Instancer x)
				{
					SandCollisionService instance2 = new SandCollisionService();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_0 = _003C_003E9__2_;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num2 = 187441152 + 3248;
			if (_003C_003Ec._003C_003E9__2_1 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, MovingCubeRegistry> _003C_003E9__2_2 = delegate(Instancer x)
				{
					MovingCubeRegistry instance2 = new MovingCubeRegistry();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_1 = _003C_003E9__2_2;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num3 = 187441152 + 3304;
			if (_003C_003Ec._003C_003E9__2_2 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, SandBreakEventQueue> _003C_003E9__2_3 = delegate(Instancer x)
				{
					SandBreakEventQueue instance2 = new SandBreakEventQueue();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_2 = _003C_003E9__2_3;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num4 = 187441152 + 3320;
			if (_003C_003Ec._003C_003E9__2_3 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, SandParticleQueries> _003C_003E9__2_4 = delegate(Instancer x)
				{
					SandParticleQueries instance2 = new SandParticleQueries();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_3 = _003C_003E9__2_4;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num5 = 187441152 + 3336;
			if (_003C_003Ec._003C_003E9__2_4 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, SandPrototypeEntityFactory> _003C_003E9__2_5 = delegate(Instancer x)
				{
					SandPrototypeEntityFactory instance2 = new SandPrototypeEntityFactory();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_4 = _003C_003E9__2_5;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num6 = 187441152 + 3392;
			if (_003C_003Ec._003C_003E9__2_5 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, SandSDFService> _003C_003E9__2_6 = delegate(Instancer x)
				{
					SandSDFService instance2 = new SandSDFService();
					return x.InjectInstance(instance2);
				};
				_003C_003Ec._003C_003E9__2_5 = _003C_003E9__2_6;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num7 = 187441152 + 3328;
			Func<Instancer, SandPhysicsBootstrap> _003C_003E9__2_7 = _003C_003Ec._003C_003E9__2_6;
			if (_003C_003Ec._003C_003E9__2_6 == null)
			{
				_003C_003E9__2_7 = (_003C_003Ec._003C_003E9__2_6 = delegate(Instancer x)
				{
					SandPhysicsBootstrap instance2 = new SandPhysicsBootstrap();
					return x.InjectInstance(instance2);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			return;
			IL_0411:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60005D0")]
		[Address(RVA = "0x3DAFE50", Offset = "0x3DAFE50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SandPhysicsPlayModeInstaller()
		{
		}
	}
}
