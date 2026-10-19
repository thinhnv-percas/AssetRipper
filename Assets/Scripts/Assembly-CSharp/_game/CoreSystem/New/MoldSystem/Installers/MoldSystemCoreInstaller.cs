using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.GameplayLifecycleSystem.Shared;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings;
using _game.CoreSystem.New.MoldSystem.Visual;

namespace _game.CoreSystem.New.MoldSystem.Installers
{
	[Token(Token = "0x20002C4")]
	public class MoldSystemCoreInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002C5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000894")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000895")]
			public static Func<Instancer, GridData<MoldCellData>> _003C_003E9__3_1;

			[Token(Token = "0x4000896")]
			public static Func<Instancer, MoldGridHandler> _003C_003E9__3_2;

			[Token(Token = "0x4000897")]
			public static Func<Instancer, MoldFillHandler> _003C_003E9__3_3;

			[Token(Token = "0x4000898")]
			public static Func<Instancer, MoldLinkedHandler> _003C_003E9__3_4;

			[Token(Token = "0x4000899")]
			public static Func<Instancer, MoldEntitySystemCreator> _003C_003E9__3_5;

			[Token(Token = "0x400089A")]
			public static Func<Instancer, MoldVisualStateInitSystem> _003C_003E9__3_6;

			[Token(Token = "0x400089B")]
			public static Func<Instancer, MoldVisualGridController> _003C_003E9__3_8;

			[Token(Token = "0x400089C")]
			public static Func<Instancer, MoldLinkVisualController> _003C_003E9__3_9;

			[Token(Token = "0x6000C4D")]
			[Address(RVA = "0x3ED4918", Offset = "0x3ED4918", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.Installers.MoldSystemCoreInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C4E")]
			[Address(RVA = "0x3ED497C", Offset = "0x3ED497C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal GridData<MoldCellData> _003CInstallBindings_003Eb__3_1(Instancer x)
			{
				bool flag = x.TryResolve<LevelCreatorData>(out var result);
				return result.moldGrid;
			}

			internal MoldGridHandler _003CInstallBindings_003Eb__3_2(Instancer x)
			{
				MoldGridHandler instance = new MoldGridHandler();
				return x.InjectInstance(instance);
			}

			internal MoldFillHandler _003CInstallBindings_003Eb__3_3(Instancer x)
			{
				MoldFillHandler instance = new MoldFillHandler();
				return x.InjectInstance(instance);
			}

			internal MoldLinkedHandler _003CInstallBindings_003Eb__3_4(Instancer x)
			{
				MoldLinkedHandler instance = new MoldLinkedHandler();
				return x.InjectInstance(instance);
			}

			internal MoldEntitySystemCreator _003CInstallBindings_003Eb__3_5(Instancer x)
			{
				MoldEntitySystemCreator instance = new MoldEntitySystemCreator();
				return x.InjectInstance(instance);
			}

			internal MoldVisualStateInitSystem _003CInstallBindings_003Eb__3_6(Instancer x)
			{
				MoldVisualStateInitSystem instance = new MoldVisualStateInitSystem();
				return x.InjectInstance(instance);
			}

			internal MoldVisualGridController _003CInstallBindings_003Eb__3_8(Instancer x)
			{
				if (x.TryResolve<MoldSceneReferenceHub>(out var result) && result != null && result.GridVisualController != null)
				{
					return x.InjectMono(result.GridVisualController);
				}
				return null;
			}

			internal MoldLinkVisualController _003CInstallBindings_003Eb__3_9(Instancer x)
			{
				if (x.TryResolve<MoldSceneReferenceHub>(out var result) && result != null && result.LinkVisualController != null)
				{
					return x.InjectMono(result.LinkVisualController);
				}
				return null;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000891")]
		[FieldOffset(Offset = "0x18")]
		private MoldConceptRegistry m_moldConceptRegistry;

		[SerializeField]
		[Token(Token = "0x4000892")]
		[FieldOffset(Offset = "0x20")]
		private MoldConfigSO m_moldConfigSO;

		[SerializeField]
		[Token(Token = "0x4000893")]
		[FieldOffset(Offset = "0x28")]
		private MoldSceneReferenceHub m_moldHubPrefab;

		[Token(Token = "0x6000C49")]
		[Address(RVA = "0x3ED3EE0", Offset = "0x3ED3EE0", Length = "0x858")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_007B;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v56.Config);\n\tv109 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.MoldSystem.MoldConceptConfig>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.MoldSystem.MoldConceptConfig>::.ctor(v109, this, Il2CppMethodInfo);\n\tv166 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v109);\n\tgoto L_009A;\nL_009A:\n\tv235 = 0xB2C2000 + 0x9F0;\n\tv248 = v180.<>9__3_1;\n\tv182 = v180.<>9__3_1 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_00C6;\n\tgoto L_00AD;\nL_00AD:\n\tgoto L_00B5;\nL_00C6:\n\tv254 = 0x3C7CEBC(containerBuilder, v248, *([v235 @ X24_v36 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00CC;\nL_00CC:\n\tv302 = 0xB2C2000 + 0xC50;\n\tv315 = v281.<>9__3_2;\n\tv283 = v281.<>9__3_2 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_00F8;\n\tgoto L_00DF;\nL_00DF:\n\tgoto L_00E7;\nL_00F8:\n\tv321 = 0x3C7CEBC(containerBuilder, v315, *([v302 @ X24_v31 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00FE;\nL_00FE:\n\tv371 = 0xB2C2000 + 0xC48;\n\tv384 = v350.<>9__3_3;\n\tv352 = v350.<>9__3_3 == 0;\n\tv353 = ~v352;\n\tif (v353) goto L_012A;\n\tgoto L_0111;\nL_0111:\n\tgoto L_0119;\nL_012A:\n\tv390 = 0x3C7CEBC(containerBuilder, v384, *([v371 @ X24_v26 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0130;\nL_0130:\n\tv440 = 0xB2C2000 + 0xC60;\n\tv453 = v419.<>9__3_4;\n\tv421 = v419.<>9__3_4 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_015C;\n\tgoto L_0143;\nL_0143:\n\tgoto L_014B;\nL_015C:\n\tv459 = 0x3C7CEBC(containerBuilder, v453, *([v440 @ X24_v21 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0162;\nL_0162:\n\tv509 = 0xB2C2000 + 0xC28;\n\tv522 = v488.<>9__3_5;\n\tv490 = v488.<>9__3_5 == 0;\n\tv491 = ~v490;\n\tif (v491) goto L_018E;\n\tgoto L_0175;\nL_0175:\n\tgoto L_017D;\nL_018E:\n\tv528 = 0x3C7CEBC(containerBuilder, v522, *([v509 @ X24_v16 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01A1;\n\tgoto L_01B0;\nL_01C1:\n\tv596 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v591);\n\tv611 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.MoldSceneReferenceHub>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.MoldSceneReferenceHub>::.ctor(v611, this, Il2CppMethodInfo);\n\t// 459 NewArr v627 @ X0_v42 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_01D8;\nL_01D8:\n\tv95 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.MoldSceneReferenceHub);\n\tv648 = v95 == 0;\n\tif (v648) goto L_01EB;\n\tv152 = 0x21C11D0(v95, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv154 = v152 == 0;\n\tif (v154) goto L_026D;\nL_01EB:\n\tv627[0] = v95;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v611, v627);\n\tgoto L_01F8;\nL_01F8:\n\tv681 = 0xB2C2000 + 0xCA0;\n\tv677 = v675.<>9__3_8 == 0;\n\tif (v677) goto L_0218;\n\tv691 = 0x3C7CEBC(containerBuilder, v675.<>9__3_8, *([v681 @ X22_v26 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0205;\nL_0205:\n\tv760 = 0xB2C2000 + 0xC58;\n\tv202 = v733.<>9__3_9;\n\tv735 = v733.<>9__3_9 == 0;\n\tv736 = ~v735;\n\tif (v736) goto L_0269;\n\tgoto L_0243;\nL_0218:\n\tgoto L_0220;\n\tv792 = 0x3C7CEBC(containerBuilder, v713, *([v681 @ X22_v26 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0205;\nL_0243:\n\tgoto L_024B;\n\tv202 = v800;\nL_026D:\n\tv159 = new System.ArrayTypeMismatchException();\n\tthrow v159;\nL_007B:\n\tv56 = this.m_moldConfigSO;\nL_00B5:\n\tv278 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.MoldCellData>>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.LevelCreator.GridData`1<_game.CoreSystem.LevelCreator.MoldCellData>>::.ctor(v278, v273.<>9, Il2CppMethodInfo);\n\tv327.<>9__3_1 = v278;\n\tv248 = v278;\nL_00E7:\n\tv347 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldGridHandler>::.ctor(v347, v342.<>9, Il2CppMethodInfo);\n\tv396.<>9__3_2 = v347;\n\tv315 = v347;\nL_0119:\n\tv416 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldFillHandler>::.ctor(v416, v411.<>9, Il2CppMethodInfo);\n\tv465.<>9__3_3 = v416;\n\tv384 = v416;\nL_014B:\n\tv485 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldLinkedHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldLinkedHandler>::.ctor(v485, v480.<>9, Il2CppMethodInfo);\n\tv534.<>9__3_4 = v485;\n\tv453 = v485;\nL_017D:\n\tv555 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldEntitySystemCreator>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Handlers.MoldEntitySystemCreator>::.ctor(v555, v550.<>9, Il2CppMethodInfo);\n\tv600.<>9__3_5 = v555;\n\tv522 = v555;\nL_01A1:\n\tv591 = v564.<>9__3_6;\n\tv566 = v564.<>9__3_6 == 0;\n\tv567 = ~v566;\n\tif (v567) goto L_01C1;\nL_01B0:\n\tv609 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldVisualStateInitSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldVisualStateInitSystem>::.ctor(v609, v604.<>9, Il2CppMethodInfo);\n\tv623.<>9__3_6 = v609;\n\tv591 = v609;\nL_0269:\n\tv210 = 0x3C7CEBC(containerBuilder, v202, *([v760 @ X22_v16 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0220:\n\tv713 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.MoldVisualGridController>::.ctor(v713, v707.<>9, Il2CppMethodInfo);\n\tv777.<>9__3_8 = v713;\nL_024B:\n\tv800 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.LinkSystem.UnityBindings.MoldLinkVisualController>::.ctor(v800, v795.<>9, Il2CppMethodInfo);\n\tv806.<>9__3_9 = v800;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			MoldConfigSO moldConfigSO = m_moldConfigSO;
			containerBuilder.AddSingleton(moldConfigSO.Config);
			Func<Instancer, MoldConceptConfig> factory = delegate(Instancer x)
			{
				bool flag = x.TryResolve<LevelCreatorData>(out var result);
				return m_moldConceptRegistry.GetConcept(result.moldConceptId);
			};
			containerBuilder.AddSingleton(factory);
			int num = 187441152 + 2544;
			Func<Instancer, GridData<MoldCellData>> _003C_003E9__3_ = _003C_003Ec._003C_003E9__3_1;
			if (_003C_003Ec._003C_003E9__3_1 == null)
			{
				_003C_003E9__3_ = (_003C_003Ec._003C_003E9__3_1 = delegate(Instancer x)
				{
					bool flag = x.TryResolve<LevelCreatorData>(out var result);
					return result.moldGrid;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 3152;
			Func<Instancer, MoldGridHandler> _003C_003E9__3_2 = _003C_003Ec._003C_003E9__3_2;
			if (_003C_003Ec._003C_003E9__3_2 == null)
			{
				_003C_003E9__3_2 = (_003C_003Ec._003C_003E9__3_2 = delegate(Instancer x)
				{
					MoldGridHandler instance = new MoldGridHandler();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num3 = 187441152 + 3144;
			Func<Instancer, MoldFillHandler> _003C_003E9__3_3 = _003C_003Ec._003C_003E9__3_3;
			if (_003C_003Ec._003C_003E9__3_3 == null)
			{
				_003C_003E9__3_3 = (_003C_003Ec._003C_003E9__3_3 = delegate(Instancer x)
				{
					MoldFillHandler instance = new MoldFillHandler();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num4 = 187441152 + 3168;
			Func<Instancer, MoldLinkedHandler> _003C_003E9__3_4 = _003C_003Ec._003C_003E9__3_4;
			if (_003C_003Ec._003C_003E9__3_4 == null)
			{
				_003C_003E9__3_4 = (_003C_003Ec._003C_003E9__3_4 = delegate(Instancer x)
				{
					MoldLinkedHandler instance = new MoldLinkedHandler();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num5 = 187441152 + 3112;
			Func<Instancer, MoldEntitySystemCreator> _003C_003E9__3_5 = _003C_003Ec._003C_003E9__3_5;
			if (_003C_003Ec._003C_003E9__3_5 == null)
			{
				_003C_003E9__3_5 = (_003C_003Ec._003C_003E9__3_5 = delegate(Instancer x)
				{
					MoldEntitySystemCreator instance = new MoldEntitySystemCreator();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			Func<Instancer, MoldVisualStateInitSystem> factory2 = _003C_003Ec._003C_003E9__3_6;
			if (_003C_003Ec._003C_003E9__3_6 == null)
			{
				factory2 = (_003C_003Ec._003C_003E9__3_6 = delegate(Instancer x)
				{
					MoldVisualStateInitSystem instance = new MoldVisualStateInitSystem();
					return x.InjectInstance(instance);
				});
			}
			containerBuilder.AddSingleton(factory2);
			Func<Instancer, MoldSceneReferenceHub> factory3 = delegate(Instancer x)
			{
				bool flag = x.TryResolve<GameplayContainerRoot>(out var result);
				if (result == null || result.Transform == null)
				{
					return (MoldSceneReferenceHub)null;
				}
				MoldSceneReferenceHub moldSceneReferenceHub = UnityEngine.Object.Instantiate(m_moldHubPrefab);
				Transform transform = moldSceneReferenceHub.transform;
				transform.SetParent(result.Transform, worldPositionStays: false);
				return moldSceneReferenceHub;
			};
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(MoldSceneReferenceHub);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(factory3, array);
			int num6 = 187441152 + 3232;
			if (_003C_003Ec._003C_003E9__3_8 != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			else
			{
				Func<Instancer, MoldVisualGridController> _003C_003E9__3_6 = (Instancer x) => (x.TryResolve<MoldSceneReferenceHub>(out var result) && result != null && result.GridVisualController != null) ? x.InjectMono(result.GridVisualController) : null;
				_003C_003Ec._003C_003E9__3_8 = _003C_003E9__3_6;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			}
			int num7 = 187441152 + 3160;
			Func<Instancer, MoldLinkVisualController> _003C_003E9__3_7 = _003C_003Ec._003C_003E9__3_9;
			if (_003C_003Ec._003C_003E9__3_9 == null)
			{
				_003C_003E9__3_7 = (_003C_003Ec._003C_003E9__3_9 = (Instancer x) => (x.TryResolve<MoldSceneReferenceHub>(out var result) && result != null && result.LinkVisualController != null) ? x.InjectMono(result.LinkVisualController) : null);
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6000C4A")]
		[Address(RVA = "0x3ED4738", Offset = "0x3ED4738", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public MoldSystemCoreInstaller()
		{
		}
	}
}
