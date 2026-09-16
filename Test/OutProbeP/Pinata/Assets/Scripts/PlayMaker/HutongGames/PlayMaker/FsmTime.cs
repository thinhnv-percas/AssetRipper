using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000051")]
	public static class FsmTime
	{
		[Token(Token = "0x400014E")]
		private static bool firstUpdateHasHappened;

		[Token(Token = "0x400014F")]
		private static float totalEditorPlayerPausedTime;

		[Token(Token = "0x4000150")]
		private static float realtimeLastUpdate;

		[Token(Token = "0x4000151")]
		private static int frameCountLastUpdate;

		[Token(Token = "0x1700005F")]
		public static float RealtimeSinceStartup
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0xCADD8C", Offset = "0xCADD8C", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F05D60]);\n\tv17 = *([v16 @ X8_v11]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023668]) = v37;\nL_0018:\n\tv44 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv47 = ~v42.firstUpdateHasHappened;\n\tif (v47) goto L_0031;\n\tv58 = v44 >= v46.totalEditorPlayerPausedTime;\n\tif (v58) goto L_002B;\n\tv46.totalEditorPlayerPausedTime = 0f;\nL_002B:\n\tv61 = UnityEngine.Time::get_realtimeSinceStartup();\n\treturnVal1 = v61 - v86.totalEditorPlayerPausedTime;\n\tgoto L_0038;\nL_0031:\n\tv46.totalEditorPlayerPausedTime = v44;\nL_0038:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				if (firstUpdateHasHappened)
				{
					if (realtimeSinceStartup < totalEditorPlayerPausedTime)
					{
						totalEditorPlayerPausedTime = 0f;
					}
					float realtimeSinceStartup2 = Time.realtimeSinceStartup;
					return realtimeSinceStartup2 - totalEditorPlayerPausedTime;
				}
				totalEditorPlayerPausedTime = realtimeSinceStartup;
				return 0f;
			}
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0xCB6A5C", Offset = "0xCB6A5C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EF85E8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023669]) = v35;\nL_0016:\n\tv40.firstUpdateHasHappened = 1;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RealtimeBugFix()
		{
			firstUpdateHasHappened = true;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0xCB6AB0", Offset = "0xCB6AB0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv16 = *([1EF7DF0]);\n\tv17 = *([v16 @ X8_v10]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202366A]) = v37;\nL_0013:\n\tv39 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv42 = UnityEngine.Time::get_frameCount();\n\tv57 = v42 != v46.frameCountLastUpdate;\n\tif (v57) goto L_002D;\n\tv60 = v39 - v46.realtimeLastUpdate;\n\tv61 = v46.totalEditorPlayerPausedTime + v60;\n\tv46.totalEditorPlayerPausedTime = v61;\nL_002D:\n\tv65 = UnityEngine.Time::get_frameCount();\n\tv67.frameCountLastUpdate = v65;\n\tv69 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv71.realtimeLastUpdate = v69;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Update()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			int frameCount = Time.frameCount;
			if (frameCount == frameCountLastUpdate)
			{
				float num = realtimeSinceStartup - realtimeLastUpdate;
				float num2 = totalEditorPlayerPausedTime + num;
				totalEditorPlayerPausedTime = num2;
			}
			int frameCount2 = Time.frameCount;
			frameCountLastUpdate = frameCount2;
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			realtimeLastUpdate = realtimeSinceStartup2;
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0xCAEF80", Offset = "0xCAEF80", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFC178]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, time, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202366B]) = v38;\nL_0017:\n\tv42 = 0;\n\tv44 = time * 10000000f;\n\tv46 = 0xE93464(&v42 @ stack_-28_v1, v44, 0, v23, v24, v25, v26, v27, v44, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0xE96214(&v42 @ stack_-28_v1, \"mm:ss:ff\", 0, v23, v24, v25, v26, v27, v44, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string FormatTime(float time)
		{
			//IL_000e: Expected O, but got I4
			object obj = 0;
			float num = time * 10000000f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93464 (inside System.DBNull::.cctor +0x8C)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E96214 (inside System.DateTimeFormat::Format +0x128)");
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0xCB6B5C", Offset = "0xCB6B5C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F07040]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202366C]) = v37;\nL_0018:\n\tv45 = v44.frameCountLastUpdate;\n\t// 28 Box v48 @ X0_v3 (System.Object), typeof(System.Int32), &v45 @ X8_v5 (System.Int32)\n\tv55 = System.String::Concat(\"LastFrameCount: \", v48);\n\tgoto L_0034;\n\tv63 = *([v59 @ X8_v11+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0034;\n\tv72 = v59;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v72, v51, v52, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0034:\n\tUnityEngine.Debug::Log(v55);\n\tv78 = v44.totalEditorPlayerPausedTime;\n\t// 61 Box v81 @ X0_v9 (System.Object), typeof(System.Single), &v78 @ X8_v14 (System.Single)\n\tv88 = System.String::Concat(\"PausedTime: \", v81);\n\tUnityEngine.Debug::Log(v88);\n\tv90 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\t// 75 Box v94 @ X0_v13 (System.Object), typeof(System.Single), &v90 @ V0_v1 (System.Single)\n\tv101 = System.String::Concat(\"Realtime: \", v94);\n\tUnityEngine.Debug::Log(v101);\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DebugLog()
		{
			int num = frameCountLastUpdate;
			object obj = num;
			string message = "LastFrameCount: " + obj;
			Debug.Log(message);
			float num2 = totalEditorPlayerPausedTime;
			object obj2 = num2;
			string message2 = "PausedTime: " + obj2;
			Debug.Log(message2);
			float realtimeSinceStartup = RealtimeSinceStartup;
			object obj3 = realtimeSinceStartup;
			string message3 = "Realtime: " + obj3;
			Debug.Log(message3);
		}
	}
}
