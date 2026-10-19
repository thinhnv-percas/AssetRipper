using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.SwitchSystem;

namespace _game.CoreSystem.New.MoldSystem.PlayMode
{
	[Token(Token = "0x20002B4")]
	public class MoldSystemPlayModeInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002B5")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000858")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000859")]
			public static Func<Instancer, MoldAbsorptionBridge> _003C_003E9__0_0;

			[Token(Token = "0x400085A")]
			public static Func<Instancer, MoldVisualCreator> _003C_003E9__0_1;

			[Token(Token = "0x400085B")]
			public static Func<Instancer, MoldAnimator> _003C_003E9__0_2;

			[Token(Token = "0x400085C")]
			public static Func<Instancer, MoldReconcileTick> _003C_003E9__0_3;

			[Token(Token = "0x400085D")]
			public static Func<Instancer, MoldVisualCmdProcessor> _003C_003E9__0_4;

			[Token(Token = "0x6000C16")]
			[Address(RVA = "0x3ECFEC4", Offset = "0x3ECFEC4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.PlayMode.MoldSystemPlayModeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C17")]
			[Address(RVA = "0x3ECFF28", Offset = "0x3ECFF28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal MoldAbsorptionBridge _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldSystemPlayModeInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_0");
				return default;
			}

			internal MoldVisualCreator _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				return x.InjectMono(result.VisualCreator);
			}

			internal MoldAnimator _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				return x.InjectMono(result.MoldAnimator);
			}

			internal MoldReconcileTick _003CInstallBindings_003Eb__0_3(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				return x.InjectMono(result.ReconcileTick);
			}

			internal MoldVisualCmdProcessor _003CInstallBindings_003Eb__0_4(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				return x.InjectMono(result.CmdProcessor);
			}
		}

		[Token(Token = "0x6000C14")]
		[Address(RVA = "0x3ECF864", Offset = "0x3ECF864", Length = "0x658")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\t;\n\tv92 = v58.<>9__0_0;\n\tv60 = v58.<>9__0_0 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_008B;\n\tgoto L_0072;\nL_0072:\n\tgoto L_007A;\nL_008B:\n\tv98 = _game.CoreSystem.New.MoldSystem.PlayMode.MoldSystemPlayModeInstaller+<>c::<InstallBindings>b__0_1(containerBuilder, v92);\n\tgoto L_0098;\n\tgoto L_00A7;\nL_00B7:\n\t// 183 NewArr v163 @ X0_v8 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00C4;\nL_00C4:\n\tv196 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator);\n\tv207 = v196 == 0;\n\tif (v207) goto L_00D7;\n\tv266 = 0x21C11D0(v196, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv270 = v266 == 0;\n\tif (v270) goto L_01E8;\nL_00D7:\n\tv163[0] = v196;\n\tv375 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler);\n\tv379 = v375 == 0;\n\tif (v379) goto L_00F1;\n\tv363 = 0x21C11D0(v375, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = v363 == 0;\n\tif (v366) goto L_01E8;\nL_00F1:\n\tv163[1] = v375;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v159, v163);\n\tgoto L_00FE;\nL_00FE:\n\tv421 = 0xB2C2000 + 0xC10;\n\tv414 = v412.<>9__0_2 == 0;\n\tif (v414) goto L_012B;\n\tv431 = 0x3C7CEBC(containerBuilder, v412.<>9__0_2, *([v421 @ X22_v34 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_010B;\nL_010B:\n\t;\n\tv481 = v479.<>9__0_3 == 0;\n\tif (v481) goto L_0156;\n\tv517 = _game.CoreSystem.New.MoldSystem.PlayMode.MoldSystemPlayModeInstaller+<>c::<InstallBindings>b__0_4(containerBuilder, v479.<>9__0_3);\n\tgoto L_0118;\nL_0118:\n\tv601 = 0xB27D000 + 0xCD8;\n\tv258 = v571.<>9__0_4;\n\tv573 = v571.<>9__0_4 == 0;\n\tv574 = ~v573;\n\tif (v574) goto L_0199;\n\tgoto L_0181;\nL_012B:\n\tgoto L_0133;\n\tv551 = 0x3C7CEBC(containerBuilder, v456, *([v421 @ X22_v34 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_010B;\nL_0156:\n\tgoto L_015E;\n\tv638 = _game.CoreSystem.New.MoldSystem.PlayMode.MoldSystemPlayModeInstaller+<>c::<InstallBindings>b__0_4(containerBuilder, v549);\n\tgoto L_0118;\nL_0181:\n\tgoto L_0189;\nL_0199:\n\t// 409 NewArr v616 @ X0_v34 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_01A6;\n\tv659 = v247 == 0;\n\tif (v659) goto L_01B9;\n\tv364 = 0x21C11D0(v247, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv367 = v364 == 0;\n\tif (v367) goto L_01E8;\nL_01B9:\n\tv616[0] = v247;\n\tv670 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor);\n\tv671 = v670 == 0;\n\tif (v671) goto L_01D3;\n\tv365 = 0x21C11D0(v670, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv368 = v365 == 0;\n\tif (v368) goto L_01E8;\nL_01D3:\n\tv616[1] = v670;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v258, v616);\n\treturn;\nL_01E8:\n\tv372 = new System.ArrayTypeMismatchException();\n\tthrow v372;\nL_007A:\n\tv123 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.MoldAbsorptionBridge>::.ctor(v123, v118.<>9, Il2CppMethodInfo);\n\tv167.<>9__0_0 = v123;\n\tv92 = v123;\nL_0098:\n\tv159 = v131.<>9__0_1;\n\tv133 = v131.<>9__0_1 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_00B7;\nL_00A7:\n\tv176 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.MoldVisualCreator>::.ctor(v176, v171.<>9, Il2CppMethodInfo);\n\tv200.<>9__0_1 = v176;\n\tv159 = v176;\nL_0133:\n\tv456 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.MoldSystem.MoldAnimator>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.MoldSystem.MoldAnimator>::.ctor(v456, v450.<>9, Il2CppMethodInfo);\n\tv534.<>9__0_2 = v456;\nL_015E:\n\tv549 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileTick>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldReconcileTick>::.ctor(v549, v543.<>9, Il2CppMethodInfo);\n\tv620.<>9__0_3 = v549;\nL_0189:\n\tv646 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldVisualCmdProcessor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.MoldVisualCmdProcessor>::.ctor(v646, v641.<>9, Il2CppMethodInfo);\n\tv657.<>9__0_4 = v646;\n\tv258 = v646;\nL_01A6:\n\tv247 = System.Type::GetTypeFromHandle(*([v601 @ X22_v16 (System.Int32)]));\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSystemPlayModeInstaller::InstallBindings");
		}

		[Token(Token = "0x6000C15")]
		[Address(RVA = "0x3ECFEBC", Offset = "0x3ECFEBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldSystemPlayModeInstaller()
		{
		}
	}
}
