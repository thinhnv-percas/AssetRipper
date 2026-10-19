using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.Installers.EditMode
{
	[Token(Token = "0x20001C1")]
	public class NoPlaceInstaller_EditMode : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001C2")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000574")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000575")]
			public static Func<Instancer, NoPlaceEditorMutations> _003C_003E9__0_0;

			[Token(Token = "0x6000811")]
			[Address(RVA = "0x3E75844", Offset = "0x3E75844", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.Installers.EditMode.NoPlaceInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000812")]
			[Address(RVA = "0x3E758A8", Offset = "0x3E758A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal NoPlaceEditorMutations _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				NoPlaceEditorMutations instance = new NoPlaceEditorMutations();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x600080F")]
		[Address(RVA = "0x3E75688", Offset = "0x3E75688", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tgoto L_0042;\nL_0052:\n\t// 82 NewArr v92 @ X0_v6 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_005F;\nL_005F:\n\tv123 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceEditorMutations);\n\tv130 = v123 == 0;\n\tif (v130) goto L_0072;\n\tv135 = 0x21C11D0(v123, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = v135 == 0;\n\tif (v139) goto L_0086;\nL_0072:\n\tv92[0] = v123;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v88, v92);\n\treturn;\nL_0086:\n\tv160 = new System.ArrayTypeMismatchException();\n\tthrow v160;\nL_002B:\n\tgoto L_0033;\nL_0042:\n\tv103 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.NoPlace.EditMode.NoPlaceEditorMutations>::.ctor(v103, v98.<>9, Il2CppMethodInfo);\n\tv126.<>9__0_0 = v103;\n\tv88 = v103;\nL_0033:\n\tv88 = v63.<>9__0_0;\n\tv65 = v63.<>9__0_0 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0052;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, NoPlaceEditorMutations> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					NoPlaceEditorMutations instance = new NoPlaceEditorMutations();
					return x.InjectInstance(instance);
				});
			}
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(NoPlaceEditorMutations);
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
			containerBuilder.AddSingleton(factory, array);
		}

		[Token(Token = "0x6000810")]
		[Address(RVA = "0x3E7583C", Offset = "0x3E7583C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NoPlaceInstaller_EditMode()
		{
		}
	}
}
