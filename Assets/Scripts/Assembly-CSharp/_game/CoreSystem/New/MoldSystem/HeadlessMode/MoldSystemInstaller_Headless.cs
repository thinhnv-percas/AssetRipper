using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation;
using _game.CoreSystem.New.MoldSystem.Core.Reconciliation.HeadlessMode;
using _game.CoreSystem.New.MoldSystem.EditMode;

namespace _game.CoreSystem.New.MoldSystem.HeadlessMode
{
	[Token(Token = "0x20002C6")]
	public class MoldSystemInstaller_Headless : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20002C7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400089D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400089E")]
			public static Func<Instancer, MoldEditorMutations> _003C_003E9__0_0;

			[Token(Token = "0x400089F")]
			public static Func<Instancer, MoldCmdProcessor_Headless> _003C_003E9__0_1;

			[Token(Token = "0x6000C59")]
			[Address(RVA = "0x3ED51D4", Offset = "0x3ED51D4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.MoldSystem.HeadlessMode.MoldSystemInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000C5A")]
			[Address(RVA = "0x3ED5238", Offset = "0x3ED5238", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal MoldEditorMutations _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				return x.InjectInstance(MoldEditorMutations.Instance = new MoldEditorMutations());
			}

			internal MoldCmdProcessor_Headless _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				MoldCmdProcessor_Headless instance = new MoldCmdProcessor_Headless();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6000C57")]
		[Address(RVA = "0x3ED4F40", Offset = "0x3ED4F40", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\t;\n\tv88 = v54.<>9__0_0;\n\tv56 = v54.<>9__0_0 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0065;\n\tgoto L_004C;\nL_004C:\n\tgoto L_0054;\nL_0065:\n\tv94 = _game.CoreSystem.New.MoldSystem.HeadlessMode.MoldSystemInstaller_Headless+<>c::<InstallBindings>b__0_1(containerBuilder, v88);\n\tgoto L_0072;\n\tgoto L_0081;\nL_0091:\n\t// 145 NewArr v159 @ X0_v8 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_009E;\nL_009E:\n\tv192 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.MoldSystem.Core.Reconciliation.IMoldCmdProcessor);\n\tv203 = v192 == 0;\n\tif (v203) goto L_00B1;\n\tv210 = 0x21C11D0(v192, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv214 = v210 == 0;\n\tif (v214) goto L_00C5;\nL_00B1:\n\tv159[0] = v192;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v155, v159);\n\treturn;\nL_00C5:\n\tv235 = new System.ArrayTypeMismatchException();\n\tthrow v235;\nL_0054:\n\tv119 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.EditMode.MoldEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.EditMode.MoldEditorMutations>::.ctor(v119, v114.<>9, Il2CppMethodInfo);\n\tv163.<>9__0_0 = v119;\n\tv88 = v119;\nL_0072:\n\tv155 = v127.<>9__0_1;\n\tv129 = v127.<>9__0_1 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0091;\nL_0081:\n\tv172 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.HeadlessMode.MoldCmdProcessor_Headless>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.MoldSystem.Core.Reconciliation.HeadlessMode.MoldCmdProcessor_Headless>::.ctor(v172, v167.<>9, Il2CppMethodInfo);\n\tv196.<>9__0_1 = v172;\n\tv155 = v172;\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSystemInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x6000C58")]
		[Address(RVA = "0x3ED51CC", Offset = "0x3ED51CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldSystemInstaller_Headless()
		{
		}
	}
}
