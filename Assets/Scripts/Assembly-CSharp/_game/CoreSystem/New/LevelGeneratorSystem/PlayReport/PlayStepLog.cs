using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x2000353")]
	public static class PlayStepLog
	{
		[Token(Token = "0x6000DF4")]
		[Address(RVA = "0x3F009BC", Offset = "0x3F009BC", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_FFFFFFFF:\n\tv91 = \"— (no break)\";\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv91 = color;\n\tv102 = v99 == 0;\n\tif (v102) goto L_005A;\n\tv155 = 0x21C11D0(v99, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv159 = v155 == 0;\n\tif (v159) goto L_00FE;\nL_005A:\n\tv94[0] = v99;\n\tv174 = step;\n\tv244 = 0xB7D5000 + 0x538;\n\tv325 = \"il2cpp_vm_object_box\"(*([v244 @ X25_v7 (System.Int32)+48]), &v174 @ stack_-68_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv326 = v325 == 0;\n\tif (v326) goto L_0075;\n\tv306 = 0x21C11D0(v325, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv311 = v306 == 0;\n\tif (v311) goto L_00FE;\nL_0075:\n\tv94[1] = v325;\n\tv172 = x;\n\tv336 = \"il2cpp_vm_object_box\"(*([v244 @ X25_v7 (System.Int32)+48]), &v172 @ stack_-6C_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv337 = v336 == 0;\n\tif (v337) goto L_0094;\n\tv307 = 0x21C11D0(v336, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv312 = v307 == 0;\n\tif (v312) goto L_00FE;\nL_0094:\n\tv94[2] = v336;\n\tv170 = y;\n\tv348 = \"il2cpp_vm_object_box\"(*([v244 @ X25_v7 (System.Int32)+48]), &v170 @ stack_-70_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv349 = v348 == 0;\n\tif (v349) goto L_00AD;\n\tv308 = 0x21C11D0(v348, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv313 = v308 == 0;\n\tif (v313) goto L_00FE;\nL_00AD:\n\tv94[3] = v348;\n\tv357 = v91 == 0;\n\tif (v357) goto L_00C7;\n\tv309 = 0x21C11D0(v91, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv314 = v309 == 0;\n\tif (v314) goto L_00FE;\nL_00C7:\n\tv94[4] = v91;\n\tv168 = occupancy;\n\tv368 = \"il2cpp_vm_object_box\"(*([v244 @ X25_v7 (System.Int32)+48]), &v168 @ stack_-74_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv369 = v368 == 0;\n\tif (v369) goto L_00E8;\n\tv310 = 0x21C11D0(v368, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv315 = v310 == 0;\n\tif (v315) goto L_00FE;\nL_00E8:\n\tv94[5] = v368;\n\treturnVal2 = System.String::Format(\"[PlayTestRecorder] {0} · step {1} · ({2},{3}) · {4} · occ {5}\", v94);\n\treturn returnVal2;\nL_00FE:\n\tv321 = new System.ArrayTypeMismatchException();\n\tthrow v321;\nL_0030:\n\tv68 = System.String::IsNullOrEmpty(color);\n\tv77 = v68 == 0;\n\tv82 = ~v77;\n\tv83 = ~v82;\n\tif (v83) goto L_FFFFFFFF;\nL_0044:\n\t// 68 NewArr v94 @ X0_v5 (System.Object[]), typeof(System.Object[]), 6\n\tv96 = mode;\n\t// 73 Box v99 @ X0_v7, typeof(_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.LevelPlayMode), &v96 @ stack_-64_v1 (_game.CoreSystem.New.LevelGeneratorSystem.PlayReport.LevelPlayMode)\n")]
		public static string Format(LevelPlayMode mode, int step, int x, int y, string color, int occupancy)
		{
			string text = ((!string.IsNullOrEmpty(color)) ? color : "— (no break)");
			object[] array = new object[6];
			object obj = mode;
			if (obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_02d9;
				}
			}
			array[0] = obj;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_02d9;
				}
			}
			array[1] = obj3;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj5 = default(object);
			if (obj5 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					goto IL_02d9;
				}
			}
			array[2] = obj5;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj7 = default(object);
			if (obj7 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj8 = default(object);
				if (obj8 == null)
				{
					goto IL_02d9;
				}
			}
			array[3] = obj7;
			if (text != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj9 = default(object);
				if (obj9 == null)
				{
					goto IL_02d9;
				}
			}
			array[4] = text;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj10 = default(object);
			if (obj10 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj11 = default(object);
				if (obj11 == null)
				{
					goto IL_02d9;
				}
			}
			array[5] = obj10;
			return string.Format("[PlayTestRecorder] {0} · step {1} · ({2},{3}) · {4} · occ {5}", array);
			IL_02d9:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
	}
}
