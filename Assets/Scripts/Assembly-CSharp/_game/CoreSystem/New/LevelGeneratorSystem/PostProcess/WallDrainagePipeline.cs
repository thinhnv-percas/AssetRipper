using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x2000337")]
	public static class WallDrainagePipeline
	{
		[Token(Token = "0x2000338")]
		public readonly struct Stats
		{
			[Token(Token = "0x4000990")]
			[FieldOffset(Offset = "0x0")]
			public readonly WallDrainageRepairResult Drain1;

			[Token(Token = "0x4000991")]
			[FieldOffset(Offset = "0x8")]
			public readonly int Extended;

			[Token(Token = "0x4000992")]
			[FieldOffset(Offset = "0x10")]
			public readonly WallDrainageRepairResult Drain2;

			[Token(Token = "0x4000993")]
			[FieldOffset(Offset = "0x18")]
			public readonly int Reverted;

			[Token(Token = "0x4000994")]
			[FieldOffset(Offset = "0x1C")]
			public readonly bool FinalDrains;

			[Token(Token = "0x6000DB8")]
			[Address(RVA = "0x3EF9790", Offset = "0x3EF9790", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Drain1 = drain1;\n\tthis.Drain2 = drain2;\n\tthis.Extended = extended;\n\tthis.Reverted = reverted;\n\tthis.FinalDrains = finalDrains;\n\treturn;\n")]
			public Stats(WallDrainageRepairResult drain1, int extended, WallDrainageRepairResult drain2, int reverted, bool finalDrains)
			{
				Drain1 = drain1;
				Drain2 = drain2;
				Extended = extended;
				Reverted = reverted;
				FinalDrains = finalDrains;
			}

			[Token(Token = "0x6000DB9")]
			[Address(RVA = "0x3EF97F0", Offset = "0x3EF97F0", Length = "0x1F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv53 = this.Drain1 == 0;\n\tif (v53) goto L_002D;\n\tv109 = 0x21C11D0(this.Drain1, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv113 = v109 == 0;\n\tif (v113) goto L_00B0;\nL_002D:\n\tv47[0] = this.Drain1;\n\tv163 = this.Extended;\n\tv161 = 0xB7D5000 + 0x538;\n\tv246 = \"il2cpp_vm_object_box\"(*([v161 @ X22_v5 (System.Int32)+48]), &v163 @ stack_-34_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv247 = v246 == 0;\n\tif (v247) goto L_0049;\n\tv229 = 0x21C11D0(v246, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv233 = v229 == 0;\n\tif (v233) goto L_00B0;\nL_0049:\n\tv47[1] = v246;\n\tv255 = this.Drain2 == 0;\n\tif (v255) goto L_0064;\n\tv230 = 0x21C11D0(this.Drain2, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv234 = v230 == 0;\n\tif (v234) goto L_00B0;\nL_0064:\n\tv47[2] = this.Drain2;\n\tv124 = this.Reverted;\n\tv267 = \"il2cpp_vm_object_box\"(*([v161 @ X22_v5 (System.Int32)+48]), &v124 @ stack_-38_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv268 = v267 == 0;\n\tif (v268) goto L_007E;\n\tv231 = 0x21C11D0(v267, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv235 = v231 == 0;\n\tif (v235) goto L_00B0;\nL_007E:\n\tv47[3] = v267;\n\tv122 = this.FinalDrains;\n\tv279 = \"il2cpp_vm_object_box\"(*([v161 @ X22_v5 (System.Int32)+28]), &v122 @ stack_-39_v4 (System.Boolean), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = v279 == 0;\n\tif (v280) goto L_00A0;\n\tv232 = 0x21C11D0(v279, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv236 = v232 == 0;\n\tif (v236) goto L_00B0;\nL_00A0:\n\tv47[4] = v279;\n\treturnVal2 = System.String::Format(\"drain1=({0}) extended={1} drain2=({2}) reverted={3} drains={4}\", v47);\n\treturn returnVal2;\nL_00B0:\n\tv241 = new System.ArrayTypeMismatchException();\n\tthrow v241;\nL_001B:\n\t// 27 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 5\n")]
			public override string ToString()
			{
				object[] array = new object[5];
				if (Drain1 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_0251;
					}
				}
				array[0] = Drain1;
				int extended = Extended;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj3 = default(object);
					if (obj3 == null)
					{
						goto IL_0251;
					}
				}
				array[1] = obj2;
				if (Drain2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj4 = default(object);
					if (obj4 == null)
					{
						goto IL_0251;
					}
				}
				array[2] = Drain2;
				int reverted = Reverted;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj5 = default(object);
				if (obj5 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj6 = default(object);
					if (obj6 == null)
					{
						goto IL_0251;
					}
				}
				array[3] = obj5;
				bool finalDrains = FinalDrains;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj7 = default(object);
				if (obj7 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj8 = default(object);
					if (obj8 == null)
					{
						goto IL_0251;
					}
				}
				array[4] = obj7;
				return string.Format("drain1=({0}) extended={1} drain2=({2}) reverted={3} drains={4}", array);
				IL_0251:
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}

		[Token(Token = "0x6000DB7")]
		[Address(RVA = "0x3EF7CF4", Offset = "0x3EF7CF4", Length = "0x7B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv570 = 0xB28F000 + 0xAE8;\n\tv74 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallDrainageRepair::Apply(actions, gridSize, 0, log);\n\tv202 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallExtensionPass::ApplyAndCollect(actions, gridSize, log);\n\tgoto L_0077;\n\tv325 = v311.Unresolved == 0;\n\tif (v325) goto L_0217;\n\tv392 = v202.Count > 0;\n\tif (v392) goto L_00AD;\n\tv459 = v311.Adds;\n\tv485 = v459.Count < 1;\n\tif (v485) goto L_0217;\nL_00AD:\n\tv603 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v202);\n\tv123 = v123._list;\n\tv345 = v123._list;\n\tv822 = log;\n\tv441 = 0;\n\tv720 = v123.Current;\n\tgoto L_00F3;\n\tgoto L_0124;\n\tv712 = log == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v712) goto L_00C0;\n\tv667 = v123.Current;\n\tv1274 = 0xB7D5000 + 0x538;\n\tv1277 = \"il2cpp_vm_object_box\"(*([v1274 @ X22_v17 (System.Int32)+48]), &v667 @ stack_-C4_v10 (_game.CoreSystem.New.GridEcsBinding.GridCoord), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv666 = v720.y;\n\tv1292 = \"il2cpp_vm_object_box\"(*([v1274 @ X22_v17 (System.Int32)+48]), &v666 @ stack_-C8_v10 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1300 = System.String::Format(\"[wall-ext] revert {0},{1}\", v1277, v1292);\n\tSystem.Action`1<System.String>::Invoke(log, v1300);\n\tv822 = 0;\n\tv441 = log.method;\n\tgoto L_00C0;\nL_014A:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Dispose(&v345 @ stack_-A0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv1071 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v311.Adds);\n\tv345 = v1071;\n\tv1151 = v1071.Current;\n\tgoto L_0197;\n\tgoto L_01C8;\n\tv1143 = log == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v1143) goto L_0164;\n\tv667 = v1071.Current;\n\tv1365 = 0xB7D5000 + 0x538;\n\tv1368 = \"il2cpp_vm_object_box\"(*([v1365 @ X22_v14 (System.Int32)+48]), &v667 @ stack_-C4_v10 (_game.CoreSystem.New.GridEcsBinding.GridCoord), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv666 = v1151.y;\n\tv1372 = \"il2cpp_vm_object_box\"(*([v1365 @ X22_v14 (System.Int32)+48]), &v666 @ stack_-C8_v10 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1378 = System.String::Format(\"[wall-drain] revert fill {0},{1}\", v1368, v1372);\n\tSystem.Action`1<System.String>::Invoke(log, v1378);\n\tv822 = 0;\n\tv441 = log.method;\n\tgoto L_0164;\nL_01F0:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Dispose(&v345 @ stack_-A0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv350 = v1071._list;\n\tv386 = returnBuffer;\n\tv433 = v202;\n\tv468 = v311;\n\tv836 = actions->klass;\n\tv975 = actions->klass->interface_offsets_count;\n\tv838 = *([v836 @ X8_v20 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions>)+12E]) == 0;\n\tif (v838) goto L_0213;\n\tv974 = *([v836 @ X8_v20 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions>)+B0]) + 8;\n\tv974 = v974 + 0x10;\n\tv873 = v975 - 1;\n\tv853 = v975 != 1;\n\tv975 = v873;\n\tif (v853) goto L_01F9;\nL_0213:\n\tv1041 = 0x220C5E0(actions, *([v570 @ X27_v7 (System.Int32)]), 3, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv441 = 3;\n\tgoto L_0225;\nL_0217:\n\tv575 = actions->klass;\n\tv631 = actions->klass->interface_offsets_count;\n\tv509 = *([v575 @ X8_v16 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions>)+12E]) == 0;\n\tv510 = ~v509;\n\tv350 = 0;\n\tv386 = returnBuffer;\n\tv433 = v202;\n\tv438 = log;\n\tv441 = 0;\n\tv568 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions;\n\tv468 = v311;\n\tif (v510) goto L_022C;\n\tv744 = returnBuffer;\n\tv768 = v311;\n\tgoto L_024B;\nL_021E:\n\tv1036 = *([v974 @ X10_v15]) + 3;\n\tv1037 = v1036 << 4;\n\tv1038 = v836 + v1037;\n\tv1041 = v1038 + 0x138;\nL_022C:\n\tv427 = *([v575 @ X8_v16 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions>)+B0]) + 8;\n\tv427 = v427 + 0x10;\n\tv614 = v631 - 1;\n\tv604 = v631 != 1;\n\tv744 = v386;\n\tv768 = v468;\n\tv631 = v614;\n\tif (v604) goto L_022D;\nL_024B:\n\tv452 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::CheckWallDrainage(actions);\nL_025C:\n\tv942 = log == 0;\n\tif (v942) goto L_0275;\n\tv1020 = v775;\n\t// 616 Box v1024 @ X0_v39 (System.Object), typeof(_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallDrainagePipeline+Stats), &v1020 @ stack_-C0_v7 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallDrainageRepairResult)\n\tv1075 = System.String::Format(\"[wall-pipeline] {0}\", v1024);\n\tSystem.Action`1<System.String>::Invoke(log, v1075);\nL_0286:\n\tv430 = *([v427 @ X10_v8]) + 0x27;\n\tv388 = v430 << 4;\n\tv659 = v575 + v388;\n\tv660 = v659 + 0x138;\n\t*([v660 @ X0_v50])(v450, actions, *([v660 @ X0_v50+8]), v441, v438, v43, v44, v45, v46, v350, v1071.Current, v49, v50, v51, v52, v53, v54);\n\tv662 = v433 == 0;\n\tv453 = ~v662;\n\tv744 = v386;\n\tv768 = v468;\n\tif (v453) goto L_025C;\n\tthrow System.NullReferenceException;\nL_0293:\n\tv193 = 0xB28B000 + 0x600;\n\tv203 = new v193();\n\tv214 = 0xB307000 + 0x418;\n\tSystem.ArgumentNullException::.ctor(v203, v214);\n\tthrow v203;\nL_003D:\n\tv64 = actions == 0;\n\tif (v64) goto L_0293;\nL_0077:\n\tv306 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::RefreshFrameData(actions);\n\tv311 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallDrainageRepair::Apply(actions, gridSize, 0, log);\nL_00F3:\n\tv710 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::IsWallAt(actions, v123.Current);\n\tv713 = v710 == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v713) goto L_00C0;\nL_0124:\n\tv708 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::RemoveWallAt(actions, v123.Current);\n\tv1221 = v708 & 1;\n\tv714 = v1221 == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v714) goto L_00C0;\nL_00C0:\n\tv723 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v345 @ stack_-A0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv840 = v723 == 0;\n\tif (v840) goto L_014A;\nL_0197:\n\tv1141 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::IsWallAt(actions, v1071.Current);\n\tv1144 = v1141 == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v1144) goto L_0164;\nL_01C8:\n\tv1139 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::RemoveWallAt(actions, v1071.Current);\n\tv1362 = v1139 & 1;\n\tv1145 = v1362 == 0;\n\tv822 = 0;\n\tv441 = v957;\n\tif (v1145) goto L_0164;\nL_0164:\n\tv1154 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>::MoveNext(&v345 @ stack_-A0_v8 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>));\n\tv830 = v1154 == 0;\n\tif (v830) goto L_01F0;\nL_01F9:\n\t;\n\tv980 = *([v974 @ X10_v15-8]) == *([v570 @ X27_v7 (System.Int32)]);\n\tif (v980) goto L_021E;\nL_0225:\n\t*([v1041 @ X0_v54])(v572, actions, *([v1041 @ X0_v54+8]), v441, v822, v43, v44, v45, v46, v350,\n// ... truncated")]
		public static Stats Run(IGeneratorActions actions, Vector2Int gridSize, Action<string> log = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallDrainagePipeline::Run");
			return default;
		}
	}
}
