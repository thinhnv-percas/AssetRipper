using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000082")]
	public class GameplayFeedbackInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000083")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000153")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000154")]
			public static Func<Instancer, SoundMoldWiring> _003C_003E9__0_0;

			[Token(Token = "0x4000155")]
			public static Func<Instancer, HapticGameplayWiring> _003C_003E9__0_1;

			[Token(Token = "0x6000234")]
			[Address(RVA = "0x3C75558", Offset = "0x3C75558", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.GameplayFeedbackInstaller+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000235")]
			[Address(RVA = "0x3C755BC", Offset = "0x3C755BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal SoundMoldWiring _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				SoundMoldWiring instance = new SoundMoldWiring();
				return x.InjectInstance(instance);
			}

			internal HapticGameplayWiring _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				HapticGameplayWiring instance = new HapticGameplayWiring();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x3C7535C", Offset = "0x3C7535C", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv77 = 0xB2C2000 + 0xD58;\n\tv88 = v54.<>9__0_0;\n\tv56 = v54.<>9__0_0 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_005F;\n\tgoto L_0046;\nL_0046:\n\tgoto L_004E;\nL_005F:\n\tv94 = 0x3C7CEBC(containerBuilder, v88, *([v77 @ X23_v9 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0065;\nL_0065:\n\tv144 = 0xB2C2000 + 0xB70;\n\tv155 = v121.<>9__0_1;\n\tv123 = v121.<>9__0_1 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_009A;\n\tgoto L_0078;\nL_0078:\n\tgoto L_0080;\nL_009A:\n\tv169 = 0x3C7CEBC(containerBuilder, v155, *([v144 @ X23_v4 (System.Int32)]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_004E:\n\tv118 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SoundMoldWiring>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.SoundMoldWiring>::.ctor(v118, v113.<>9, Il2CppMethodInfo);\n\tv175.<>9__0_0 = v118;\n\tv88 = v118;\nL_0080:\n\tv192 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.HapticGameplayWiring>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.HapticGameplayWiring>::.ctor(v192, v187.<>9, Il2CppMethodInfo);\n\tv199.<>9__0_1 = v192;\n\tv155 = v192;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3416;
			Func<Instancer, SoundMoldWiring> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					SoundMoldWiring instance = new SoundMoldWiring();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 2928;
			Func<Instancer, HapticGameplayWiring> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer x)
				{
					HapticGameplayWiring instance = new HapticGameplayWiring();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6000233")]
		[Address(RVA = "0x3C75550", Offset = "0x3C75550", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameplayFeedbackInstaller()
		{
		}
	}
}
