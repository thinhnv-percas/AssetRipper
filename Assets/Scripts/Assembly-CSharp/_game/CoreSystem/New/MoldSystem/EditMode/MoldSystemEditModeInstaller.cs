using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode;
using _game.CoreSystem.New.MoldSystem.Visual;
using _game.CoreSystem.New.MoldSystem.Visual.EditMode;

namespace _game.CoreSystem.New.MoldSystem.EditMode
{
	[Token(Token = "0x20002DD")]
	public class MoldSystemEditModeInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002DE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40008CB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40008CC")]
			public static Func<Instancer, MoldEditorMutations> _003C_003E9__0_0;

			[Token(Token = "0x40008CD")]
			public static Func<Instancer, MoldCmdProcessor_Editor> _003C_003E9__0_1;

			[Token(Token = "0x40008CE")]
			public static Func<Instancer, MoldVisualCreator_Editor> _003C_003E9__0_2;

			[Token(Token = "0x40008CF")]
			public static Func<Instancer, MoldReconcileTick_Editor> _003C_003E9__0_3;

			[Token(Token = "0x6000CA3")]
			[Address(RVA = "0x3EDCEE8", Offset = "0x3EDCEE8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.EditMode.MoldSystemEditModeInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000CA4")]
			[Address(RVA = "0x3EDCF4C", Offset = "0x3EDCF4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal MoldEditorMutations _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				return x.InjectInstance(MoldEditorMutations.Instance = new MoldEditorMutations());
			}

			internal MoldCmdProcessor_Editor _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				MoldCmdProcessor_Editor instance = new MoldCmdProcessor_Editor();
				return x.InjectInstance(instance);
			}

			internal MoldVisualCreator_Editor _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				MoldVisualCreator_Editor componentInChildren = result.GetComponentInChildren<MoldVisualCreator_Editor>(includeInactive: true);
				return x.InjectMono(componentInChildren);
			}

			internal MoldReconcileTick_Editor _003CInstallBindings_003Eb__0_3(Instancer x)
			{
				bool flag = x.TryResolve<MoldSceneReferenceHub>(out var result);
				MoldReconcileTick_Editor componentInChildren = result.GetComponentInChildren<MoldReconcileTick_Editor>(includeInactive: true);
				return x.InjectMono(componentInChildren);
			}
		}

		[Token(Token = "0x6000CA1")]
		[Address(RVA = "0x3EDC97C", Offset = "0x3EDC97C", Length = "0x564")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\t;\n\tv92 = v58.<>9__0_0;\n\tv60 = v58.<>9__0_0 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0082;\n\tgoto L_0069;\nL_0069:\n\tgoto L_0071;\nL_0082:\n\tv98 = _game.CoreSystem.New.MoldSystem.EditMode.MoldSystemEditModeInstaller+<>c::<InstallBindings>b__0_1(containerBuilder, v92);\n\tgoto L_008F;\n\tgoto L_009E;\nL_00AE:\n\t// 174 NewArr v163 @ X0_v8 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00BB;\nL_00BB:\n\tv196 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor);\n\tv207 = v196 == 0;\n\tif (v207) goto L_00CE;\n\tv277 = 0x21C11D0(v196, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv281 = v277 == 0;\n\tif (v281) goto L_01A7;\nL_00CE:\n\tv163[0] = v196;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v159, v163);\n\tgoto L_00DB;\nL_00DB:\n\tv438 = 0xB27D000 + 0xCE0;\n\tv269 = v421.<>9__0_2;\n\tv423 = v421.<>9__0_2 == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_0106;\n\tgoto L_00EE;\nL_00EE:\n\tgoto L_00F6;\nL_0106:\n\t// 262 NewArr v453 @ X0_v28 (System.Type[]), typeof(System.Type[]), 3\n\tgoto L_0113;\n\tv494 = v260 == 0;\n\tif (v494) goto L_0126;\n\tv396 = 0x21C11D0(v260, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv399 = v396 == 0;\n\tif (v399) goto L_01A7;\nL_0126:\n\tv453[0] = v260;\n\tv505 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldVisualCreator_Editor);\n\tv506 = v505 == 0;\n\tif (v506) goto L_0140;\n\tv397 = 0x21C11D0(v505, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv400 = v397 == 0;\n\tif (v400) goto L_01A7;\nL_0140:\n\tv453[1] = v505;\n\tv517 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Visual.IMoldVisualHandler);\n\tv518 = v517 == 0;\n\tif (v518) goto L_0160;\n\tv398 = 0x21C11D0(v517, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv401 = v398 == 0;\n\tif (v401) goto L_01A7;\nL_0160:\n\tv453[2] = v517;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v269, v453);\n\tgoto L_016D;\nL_016D:\n\tv552 = 0xB2C2000 + 0xC70;\n\tv561 = v538.<>9__0_3;\n\tv540 = v538.<>9__0_3 == 0;\n\tv541 = ~v540;\n\tif (v541) goto L_01A4;\n\tgoto L_0180;\nL_0180:\n\tgoto L_0188;\nL_01A4:\n\tv375 = 0x3C7CEBC(containerBuilder, v561, *([v552 @ X22_v16 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_01A7:\n\tv405 = new System.ArrayTypeMismatchException();\n\tthrow v405;\nL_0071:\n\tv123 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.EditMode.MoldEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.EditMode.MoldEditorMutations>::.ctor(v123, v118.<>9, Il2CppMethodInfo);\n\tv167.<>9__0_0 = v123;\n\tv92 = v123;\nL_008F:\n\tv159 = v131.<>9__0_1;\n\tv133 = v131.<>9__0_1 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_00AE;\nL_009E:\n\tv176 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode.MoldCmdProcessor_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode.MoldCmdProcessor_Editor>::.ctor(v176, v171.<>9, Il2CppMethodInfo);\n\tv200.<>9__0_1 = v176;\n\tv159 = v176;\nL_00F6:\n\tv477 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldVisualCreator_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Visual.EditMode.MoldVisualCreator_Editor>::.ctor(v477, v472.<>9, Il2CppMethodInfo);\n\tv492.<>9__0_2 = v477;\n\tv269 = v477;\nL_0113:\n\tv260 = System.Type::GetTypeFromHandle(*([v438 @ X22_v22 (System.Int32)]));\nL_0188:\n\tv579 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode.MoldReconcileTick_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.EditMode.MoldReconcileTick_Editor>::.ctor(v579, v574.<>9, Il2CppMethodInfo);\n\tv584.<>9__0_3 = v579;\n\tv561 = v579;\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSystemEditModeInstaller::InstallBindings");
		}

		[Token(Token = "0x6000CA2")]
		[Address(RVA = "0x3EDCEE0", Offset = "0x3EDCEE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldSystemEditModeInstaller()
		{
		}
	}
}
