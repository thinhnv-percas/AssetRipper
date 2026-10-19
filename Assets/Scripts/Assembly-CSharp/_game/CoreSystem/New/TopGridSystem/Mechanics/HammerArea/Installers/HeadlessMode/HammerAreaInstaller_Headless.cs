using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.Shared;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Tags;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HeadlessMode
{
	[Token(Token = "0x200020E")]
	public class HammerAreaInstaller_Headless : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200020F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400067F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000680")]
			public static Func<Instancer, HammerAreaGroupHandler> _003C_003E9__0_0;

			[Token(Token = "0x4000681")]
			public static Func<Instancer, HammerAreaReconcile_LandingSystem> _003C_003E9__0_1;

			[Token(Token = "0x4000682")]
			public static Func<Instancer, HammerAreaBlockCondition> _003C_003E9__0_2;

			[Token(Token = "0x6000944")]
			[Address(RVA = "0x3E912D8", Offset = "0x3E912D8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HeadlessMode.HammerAreaInstaller_Headless+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000945")]
			[Address(RVA = "0x3E9133C", Offset = "0x3E9133C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal HammerAreaGroupHandler _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				HammerAreaGroupHandler instance = new HammerAreaGroupHandler();
				return x.InjectInstance(instance);
			}

			internal HammerAreaReconcile_LandingSystem _003CInstallBindings_003Eb__0_1(Instancer x)
			{
				HammerAreaReconcile_LandingSystem instance = new HammerAreaReconcile_LandingSystem();
				return x.InjectInstance(instance);
			}

			internal HammerAreaBlockCondition _003CInstallBindings_003Eb__0_2(Instancer x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller_Headless._003C_003Ec::_003CInstallBindings_003Eb__0_2");
				return default;
			}
		}

		[Token(Token = "0x6000942")]
		[Address(RVA = "0x3E90E38", Offset = "0x3E90E38", Length = "0x498")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\t;\n\tv92 = v58.<>9__0_0;\n\tv60 = v58.<>9__0_0 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0079;\n\tgoto L_0060;\nL_0060:\n\tgoto L_0068;\nL_0079:\n\tv98 = _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Installers.HeadlessMode.HammerAreaInstaller_Headless+<>c::<InstallBindings>b__0_1(containerBuilder, v92);\n\tgoto L_0086;\n\tgoto L_0095;\nL_00A5:\n\t// 165 NewArr v163 @ X0_v8 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_00B2;\nL_00B2:\n\tv196 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem);\n\tv207 = v196 == 0;\n\tif (v207) goto L_00C5;\n\tv266 = 0x21C11D0(v196, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv270 = v266 == 0;\n\tif (v270) goto L_0166;\nL_00C5:\n\tv163[0] = v196;\n\tv375 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.IEcsSystem);\n\tv379 = v375 == 0;\n\tif (v379) goto L_00DF;\n\tv363 = 0x21C11D0(v375, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = v363 == 0;\n\tif (v366) goto L_0166;\nL_00DF:\n\tv163[1] = v375;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v159, v163);\n\tgoto L_00EC;\nL_00EC:\n\tv419 = 0xB27C000 + 0xFA0;\n\tv258 = v405.<>9__0_2;\n\tv407 = v405.<>9__0_2 == 0;\n\tv408 = ~v407;\n\tif (v408) goto L_0117;\n\tgoto L_00FF;\nL_00FF:\n\tgoto L_0107;\nL_0117:\n\t// 279 NewArr v434 @ X0_v34 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0124;\n\tv464 = v247 == 0;\n\tif (v464) goto L_0137;\n\tv364 = 0x21C11D0(v247, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv367 = v364 == 0;\n\tif (v367) goto L_0166;\nL_0137:\n\tv434[0] = v247;\n\tv475 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Conditions.IPourableBlockCondition);\n\tv476 = v475 == 0;\n\tif (v476) goto L_0151;\n\tv365 = 0x21C11D0(v475, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv368 = v365 == 0;\n\tif (v368) goto L_0166;\nL_0151:\n\tv434[1] = v475;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v258, v434);\n\treturn;\nL_0166:\n\tv372 = new System.ArrayTypeMismatchException();\n\tthrow v372;\nL_0068:\n\tv123 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaGroupHandler>::.ctor(v123, v118.<>9, Il2CppMethodInfo);\n\tv167.<>9__0_0 = v123;\n\tv92 = v123;\nL_0086:\n\tv159 = v131.<>9__0_1;\n\tv133 = v131.<>9__0_1 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_00A5;\nL_0095:\n\tv176 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem>::.ctor(v176, v171.<>9, Il2CppMethodInfo);\n\tv200.<>9__0_1 = v176;\n\tv159 = v176;\nL_0107:\n\tv452 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.Conditions.HammerAreaBlockCondition>::.ctor(v452, v447.<>9, Il2CppMethodInfo);\n\tv462.<>9__0_2 = v452;\n\tv258 = v452;\nL_0124:\n\tv247 = System.Type::GetTypeFromHandle(*([v419 @ X22_v16 (System.Int32)]));\n")]
		public unsafe void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaInstaller_Headless::InstallBindings");
		}

		[Token(Token = "0x6000943")]
		[Address(RVA = "0x3E912D0", Offset = "0x3E912D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerAreaInstaller_Headless()
		{
		}
	}
}
