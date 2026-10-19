using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.HeadlessMode
{
	[Token(Token = "0x200024C")]
	public class TopGridSystemInstaller_Headless : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200024D")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400070A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400070B")]
			public static Func<Instancer, TopGridEditorMutations> _003C_003E9__0_0;

			[Token(Token = "0x400070C")]
			public static Func<Instancer, TopGridCmdProcessor_Headless> _003C_003E9__0_1;

			[Token(Token = "0x400070D")]
			public static Func<Instancer, TopGridReconcileTick_Headless> _003C_003E9__0_2;

			[Token(Token = "0x60009FF")]
			[Address(RVA = "0x3E9E9D0", Offset = "0x3E9E9D0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.HeadlessMode.TopGridSystemInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000A00")]
			[Address(RVA = "0x3E9EA34", Offset = "0x3E9EA34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal TopGridEditorMutations _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				TopGridEditorMutations instance = new TopGridEditorMutations();
				return x.InjectInstance(instance);
			}

			internal TopGridCmdProcessor_Headless _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				TopGridCmdProcessor_Headless instance = new TopGridCmdProcessor_Headless();
				return x.InjectInstance(instance);
			}

			internal TopGridReconcileTick_Headless _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				TopGridReconcileTick_Headless instance = new TopGridReconcileTick_Headless();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60009FD")]
		[Address(RVA = "0x3E9E670", Offset = "0x3E9E670", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\t;\n\tv88 = v54.<>9__0_0;\n\tv56 = v54.<>9__0_0 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_006E;\n\tgoto L_0055;\nL_0055:\n\tgoto L_005D;\nL_006E:\n\tv94 = _game.CoreSystem.New.TopGridSystem.HeadlessMode.TopGridSystemInstaller_Headless+<>c::<InstallBindings>b__0_1(containerBuilder, v88);\n\tgoto L_007B;\n\tgoto L_008A;\nL_009A:\n\t// 154 NewArr v159 @ X0_v8 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00A7;\nL_00A7:\n\tv192 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor);\n\tv203 = v192 == 0;\n\tif (v203) goto L_00BA;\n\tv211 = 0x21C11D0(v192, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv215 = v211 == 0;\n\tif (v215) goto L_0100;\nL_00BA:\n\tv159[0] = v192;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v155, v159);\n\tgoto L_00C7;\nL_00C7:\n\tv300 = 0xB2C2000 + 0xD90;\n\tv270 = v256.<>9__0_2;\n\tv258 = v256.<>9__0_2 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_00FC;\n\tgoto L_00DA;\nL_00DA:\n\tgoto L_00E2;\n\tv270 = v326;\nL_0100:\n\tv239 = new System.ArrayTypeMismatchException();\n\tthrow v239;\nL_005D:\n\tv119 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations>::.ctor(v119, v114.<>9, Il2CppMethodInfo);\n\tv163.<>9__0_0 = v119;\n\tv88 = v119;\nL_007B:\n\tv155 = v127.<>9__0_1;\n\tv129 = v127.<>9__0_1 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_009A;\nL_008A:\n\tv172 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode.TopGridCmdProcessor_Headless>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode.TopGridCmdProcessor_Headless>::.ctor(v172, v167.<>9, Il2CppMethodInfo);\n\tv196.<>9__0_1 = v172;\n\tv155 = v172;\nL_00FC:\n\tv278 = 0x3C7CEBC(containerBuilder, v270, *([v300 @ X22_v10 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_00E2:\n\tv326 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode.TopGridReconcileTick_Headless>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode.TopGridReconcileTick_Headless>::.ctor(v326, v321.<>9, Il2CppMethodInfo);\n\tv331.<>9__0_2 = v326;\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSystemInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x60009FE")]
		[Address(RVA = "0x3E9E9C8", Offset = "0x3E9E9C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridSystemInstaller_Headless()
		{
		}
	}
}
