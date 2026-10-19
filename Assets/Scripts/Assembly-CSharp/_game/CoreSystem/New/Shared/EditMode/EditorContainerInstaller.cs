using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.Shared.EditMode
{
	[Token(Token = "0x2000285")]
	public class EditorContainerInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000286")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40007F2")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40007F3")]
			public static Func<Instancer, EditorHistory> _003C_003E9__0_0;

			[Token(Token = "0x6000B3D")]
			[Address(RVA = "0x3EC5198", Offset = "0x3EC5198", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.Shared.EditMode.EditorContainerInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000B3E")]
			[Address(RVA = "0x3EC51FC", Offset = "0x3EC51FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal EditorHistory _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				EditorHistory instance = new EditorHistory();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6000B3B")]
		[Address(RVA = "0x3EC5068", Offset = "0x3EC5068", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv77 = 0xB2C2000 + 0xA98;\n\tv88 = v54.<>9__0_0;\n\tv56 = v54.<>9__0_0 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_005F;\n\tgoto L_003D;\nL_003D:\n\tgoto L_0045;\nL_005F:\n\tv102 = 0x3C7CEBC(containerBuilder, v88, *([v77 @ X23_v3 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0045:\n\tv123 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.Shared.EditMode.EditorHistory>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.Shared.EditMode.EditorHistory>::.ctor(v123, v118.<>9, Il2CppMethodInfo);\n\tv130.<>9__0_0 = v123;\n\tv88 = v123;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2712;
			Func<Instancer, EditorHistory> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					EditorHistory instance = new EditorHistory();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6000B3C")]
		[Address(RVA = "0x3EC5190", Offset = "0x3EC5190", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public EditorContainerInstaller()
		{
		}
	}
}
