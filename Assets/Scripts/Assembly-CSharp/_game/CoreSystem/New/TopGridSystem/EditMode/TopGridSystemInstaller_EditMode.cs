using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.VisualHandlers;

namespace _game.CoreSystem.New.TopGridSystem.EditMode
{
	[Token(Token = "0x2000252")]
	public class TopGridSystemInstaller_EditMode : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000253")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000723")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000724")]
			public static Func<Instancer, TopGridEditorMutations> _003C_003E9__2_0;

			[Token(Token = "0x4000725")]
			public static Func<Instancer, TopGridCmdProcessor_Editor> _003C_003E9__2_1;

			[Token(Token = "0x6000A37")]
			[Address(RVA = "0x3EABBC8", Offset = "0x3EABBC8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSystemInstaller_EditMode+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000A38")]
			[Address(RVA = "0x3EABC2C", Offset = "0x3EABC2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal TopGridEditorMutations _003CInstallBindings_003Eb__2_0(Instancer x)
			{
				TopGridEditorMutations instance = new TopGridEditorMutations();
				return x.InjectInstance(instance);
			}

			internal TopGridCmdProcessor_Editor _003CInstallBindings_003Eb__2_1(Instancer x)
			{
				TopGridCmdProcessor_Editor instance = new TopGridCmdProcessor_Editor();
				return x.InjectInstance(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x4000721")]
		[FieldOffset(Offset = "0x18")]
		private TopGridVisualHandler_Editor m_visualHandlerEditorPrefab;

		[SerializeField]
		[Token(Token = "0x4000722")]
		[FieldOffset(Offset = "0x20")]
		private TopGridReconcileTick_Editor m_reconcileTickEditorPrefab;

		[Token(Token = "0x6000A34")]
		[Address(RVA = "0x3EAB6B0", Offset = "0x3EAB6B0", Length = "0x4A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001C;\nL_001C:\n\t;\n\tv98 = v64.<>9__2_0;\n\tv66 = v64.<>9__2_0 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0082;\n\tgoto L_0069;\nL_0069:\n\tgoto L_0071;\nL_0082:\n\tv104 = _game.CoreSystem.New.TopGridSystem.EditMode.TopGridSystemInstaller_EditMode+<>c::<InstallBindings>b__2_1(containerBuilder, v98);\n\tgoto L_008F;\n\tgoto L_009E;\nL_00AE:\n\t// 174 NewArr v169 @ X0_v8 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00BB;\nL_00BB:\n\tv202 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor);\n\tv213 = v202 == 0;\n\tif (v213) goto L_00D2;\n\tv276 = 0x21C11D0(v202, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = v276 == 0;\n\tif (v280) goto L_0164;\nL_00D2:\n\tv169[0] = v202;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v165, v169);\n\tgoto L_00E5;\n\t_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler::MarkSpawned(v250);\n\t// 239 NewArr v431 @ X0_v29 (System.Type[]), typeof(System.Type[]), 2\n\tv251 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualHandler);\n\tv435 = v251 == 0;\n\tif (v435) goto L_0106;\n\tv343 = 0x21C11D0(v251, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv347 = v343 == 0;\n\tif (v347) goto L_0164;\nL_0106:\n\tv431[0] = v251;\n\tv446 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.EditMode.VisualHandlers.TopGridVisualHandler_Editor);\n\tv447 = v446 == 0;\n\tif (v447) goto L_0124;\n\tv344 = 0x21C11D0(v446, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv348 = v344 == 0;\n\tif (v348) goto L_0164;\nL_0124:\n\tv431[1] = v446;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v250, v431);\n\tv463 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridReconcileTick_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridReconcileTick_Editor>::.ctor(v463, this, Il2CppMethodInfo);\n\t// 309 NewArr v467 @ X0_v46 (System.Type[]), typeof(System.Type[]), 1\n\tv252 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridReconcileTick_Editor);\n\tv469 = v252 == 0;\n\tif (v469) goto L_014C;\n\tv345 = 0x21C11D0(v252, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv349 = v345 == 0;\n\tif (v349) goto L_0164;\nL_014C:\n\tv467[0] = v252;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v463, v467);\n\treturn;\nL_0164:\n\tv357 = new System.ArrayTypeMismatchException();\n\tthrow v357;\nL_0071:\n\tv129 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.EditMode.TopGridEditorMutations>::.ctor(v129, v124.<>9, Il2CppMethodInfo);\n\tv173.<>9__2_0 = v129;\n\tv98 = v129;\nL_008F:\n\tv165 = v137.<>9__2_1;\n\tv139 = v137.<>9__2_1 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_00AE;\nL_009E:\n\tv182 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridCmdProcessor_Editor>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.EditMode.TopGridCmdProcessor_Editor>::.ctor(v182, v177.<>9, Il2CppMethodInfo);\n\tv206.<>9__2_1 = v182;\n\tv165 = v182;\nL_00E5:\n\tv250 = UnityEngine.Object::Instantiate(this.m_visualHandlerEditorPrefab);\n")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridSystemInstaller_EditMode::InstallBindings");
		}

		[Token(Token = "0x6000A35")]
		[Address(RVA = "0x3EABB58", Offset = "0x3EABB58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public TopGridSystemInstaller_EditMode()
		{
		}
	}
}
