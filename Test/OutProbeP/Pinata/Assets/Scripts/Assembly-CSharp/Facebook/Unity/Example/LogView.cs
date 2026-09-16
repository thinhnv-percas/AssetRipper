using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x2000057")]
	internal class LogView : ConsoleBase
	{
		[Token(Token = "0x400026D")]
		private static string datePatt = "M/d/yyyy hh:mm:ss tt";

		[Token(Token = "0x400026E")]
		private static IList<string> events;

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xA06264", Offset = "0xA06264", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE0568]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CAF]) = v40;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Facebook.Unity.Example.LogView>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = Facebook.Unity.Example.LogView;\nL_0026:\n\tv59 = v57.events;\n\tgoto L_0032;\n\tv64 = *([v58 @ X8_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0032;\n\tv73 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv72 = System.DateTime::get_Now();\n\tv80 = 0xE96214(&v72 @ X0_v6 (System.DateTime), v78.datePatt, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv88 = System.String::Format(\"{0}\\n{1}\\n\", v80, log);\n\tv92 = *([v59 @ X19_v2 (System.Collections.Generic.IList`1<System.String>)]);\n\tv96 = *([v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+126]) == 0;\n\tif (v96) goto L_0069;\n\tv150 = *([v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+B0]) + 8;\nL_0054:\n\tv156 = *([v150 @ X11_v5-8]) == System.Collections.Generic.IList`1<System.String>;\n\tif (v156) goto L_006C;\n\tv151 = v151 + 1;\n\tv211 = v151 < *([v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+126]);\n\tv130 = ~v211;\n\tv150 = v150 + 0x10;\n\tv106 = ~v130;\n\tif (v106) goto L_0054;\nL_0069:\n\tv72 = 0x8909C4(v59, System.Collections.Generic.IList`1<System.String>, 3, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0075;\nL_006C:\n\tv213 = *([v150 @ X11_v5]) + 3;\n\tv214 = v213 << 4;\n\tv215 = v92 + v214;\n\tv72 = v215 + 0x130;\nL_0075:\n\t*([v72 @ X0_v6 (System.DateTime)])(v72, v59, 0, v88, *([v72 @ X0_v6 (System.DateTime)+8]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddLog(string log)
		{
			//IL_0045: Expected I, but got O
			//IL_0080: Expected O, but got I
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0124: Expected O, but got I
			//IL_0133: Expected O, but got I
			//IL_00cc: Expected O, but got I
			IList<string> list = events;
			DateTime now = DateTime.Now;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E96214 (inside System.DateTimeFormat::Format +0x128)");
			object arg = default(object);
			string text = $"{arg}\n{log}\n";
			IntPtr intPtr = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IList<string>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<System.String>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e5;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			now = (DateTime)((long)(IntPtr)obj3 + 304L);
			goto IL_0175;
			IL_00e5:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0175;
			IL_0175:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v72 @ X0_v6 (System.DateTime)] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0xA09460", Offset = "0xA09460", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC1D58]);\n\tv27 = *([v26 @ X8_v54]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021CB0]) = v46;\nL_001A:\n\tv51 = 0x6D26F0(&v48 @ stack_-88, 0, 0x44, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0028;\n\tv61 = v56;\n\tv62 = 0x8907BC(v61, v50, v49, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv65 = *([v56 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0028:\n\tv66 = *([v56 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv67 = v66 == 0;\n\tif (v67) goto L_0049;\n\tv69 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0035;\n\tv91 = v69;\n\tv92 = 0x8907BC(v91, v50, v49, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0035:\n\tv93 = *([v69 @ X20_v17 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv79 = ~v93;\n\tif (v79) goto L_0049;\n\tgoto L_0049;\n\tv108 = v84;\n\tv109 = 0x8907BC(v108, v50, v49, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0049:\n\tgoto L_004F;\n\tv94 = v86;\n\tv95 = 0x8907BC(v94, v50, v49, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_004F:\n\tUnityEngine.GUILayout::BeginVertical(v97.Value);\n\tv107 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Back\");\n\tv113 = v107 == 0;\n\tif (v113) goto L_005A;\n\tFacebook.Unity.Example.ConsoleBase::GoBack(v107);\nL_005A:\n\tv115 = UnityEngine.Input::get_touchCount();\n\tv126 = v115 < 1;\n\tif (v126) goto L_00B5;\n\tv127 = &v204 @ stack_-D0_v3 (System.Int32);\n\tv131 = UnityEngine.Input::GetTouch(0);\n\tv204 = *([v127 @ X8_v45]);\n\tv243 = 0x6D2410(&v48 @ stack_-88, &v204 @ stack_-D0_v3 (System.Int32), 0x44, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\n\tv229 = 0x16717C4(&v48 @ stack_-88, 0, 0x44, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\n\tv207 = v229 != 1;\n\tif (v207) goto L_00B5;\n\tv267 = UnityEngine.Input::GetTouch(0);\n\tv204 = v267.m_FingerId;\n\tv274 = 0x6D2410(&v48 @ stack_-88, &v204 @ stack_-D0_v3 (System.Int32), 0x44, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\n\tv228 = 0x16717AC(&v48 @ stack_-88, 0, 0x44, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\n\tv132 = this.scrollPosition.y + v37;\n\tthis.scrollPosition.x = this.scrollPosition;\n\tthis.scrollPosition.y = v132;\nL_00B5:\n\t// 181 NewArr v240 @ X0_v14 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_00C5;\n\tv252 = *([v247 @ X8_v17+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tgoto L_00C5;\n\tv262 = v247;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v262, v238, v136, v31, v32, v33, v34, v35, v132, v37, v38, v39, v40, v41, v42, v43);\nL_00C5:\n\tv260 = Facebook.Unity.Constants::get_IsMobile();\n\tv264 = v260 == 0;\n\tif (v264) goto L_FFFFFFFF;\n\tv269 = UnityEngine.Screen::get_width();\n\tgoto L_00D0;\nL_00D0:\n\tv280 = UnityEngine.GUILayout::MinWidth(v276);\n\tv284 = v280 == 0;\n\tif (v284) goto L_00DD;\n\t// 217 IsInst v317 @ X0_v64, typeof(UnityEngine.GUILayoutOption), v280 @ X0_v20 (UnityEngine.GUILayoutOption)\nL_00DD:\n\tv324 = v240.Length == 0;\n\tif (v324) goto L_0156;\n\tv240[0] = v280;\n\t// 228 MakeStruct v289 @ AGGA0968C_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.scrollPosition (UnityEngine.Vector2), this.scrollPosition.y (System.Single)\n\tv295 = UnityEngine.GUILayout::BeginScrollView(v289, v240);\n\tthis.scrollPosition = v295;\n\tthis.scrollPosition.y = v295.y;\n\tgoto L_00FB;\n\tv424 = *([v420 @ X0_v32 (Il2CppClass<Facebook.Unity.Example.LogView>)+E0]);\n\tv425 = v424 == 0;\n\tv426 = ~v425;\n\tif (v426) goto L_00FB;\n\tv475 = \"il2cpp_codegen_runtime_class_init\"(v420, v352, v136, v31, v32, v33, v34, v35, v295, v291, v38, v39, v40, v41, v42, v43);\n\tv428 = Facebook.Unity.Example.LogView;\nL_00FB:\n\tv435 = System.Linq.Enumerable::ToArray(v432.events);\n\tv481 = System.String::Join(\"\\n\", v435);\n\tv483 = Facebook.Unity.Example.ConsoleBase::get_TextStyle(this);\n\t// 266 NewArr v486 @ X0_v41 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 2\n\tv303 = UnityEngine.GUILayout::ExpandHeight(1);\n\tv488 = v303 == 0;\n\tif (v488) goto L_011B;\n\t// 279 IsInst v338 @ X0_v60, typeof(UnityEngine.GUILayoutOption), v303 @ X0_v43 (UnityEngine.GUILayoutOption)\nL_011B:\n\tv385 = v486.Length == 0;\n\tif (v385) goto L_0156;\n\tv486[0] = v303;\n\tv493 = Facebook.Unity.Constants::get_IsMobile();\n\tv495 = v493 == 0;\n\tif (v495) goto L_FFFFFFFF;\n\tv497 = UnityEngine.Screen::get_width();\n\tv500 = v497 - 0x1E;\n\tgoto L_012B;\nL_012B:\n\tv505 = UnityEngine.GUILayout::MaxWidth(v331);\n\tv506 = v505 == 0;\n\tif (v506) goto L_0136;\n\t// 306 IsInst v339 @ X0_v56, typeof(UnityEngine.GUILayoutOption), v505 @ X0_v49 (UnityEngine.GUILayoutOption)\nL_0136:\n\tv509 = v486.Length < 1;\n\tv376 = ~v509;\n\tv374 = v486.Length - 1;\n\tv370 = v374 == 0;\n\tv510 = ~v376;\n\tv360 = v510 | v370;\n\tif (v360) goto L_0156;\n\tv486[1] = v505;\n\tv512 = UnityEngine.GUILayout::TextArea(v481, v483, v486);\n\tUnityEngine.GUILayout::EndScrollView();\n\tUnityEngine.GUILayout::EndVertical();\n\treturn;\nL_0156:\n\tv392 = new System.IndexOutOfRangeException();\n\tgoto L_015D;\n\tv313 = new System.NullReferenceException();\n\tv348 = new System.ArrayTypeMismatchException();\nL_015D:\n\tthrow v410;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnGUI()
		{
			//IL_008e: Expected O, but got I4
			//IL_00c2: Expected O, but got I4
			//IL_00d8: Expected I4, but got O
			//IL_03ba: Expected O, but got I4
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X20_v17 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginVertical();
			bool flag = Button("Back");
			if (flag)
			{
				((ConsoleBase)flag).GoBack();
			}
			int touchCount = Input.touchCount;
			if (touchCount >= 1)
			{
				int num = default(int);
				object obj = num;
				Touch touch = Input.GetTouch(0);
				num = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj2 = default(object);
				if ((IntPtr)obj2 == (IntPtr)1)
				{
					num = Input.GetTouch(0).fingerId;
					Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717AC (inside UnityEngine.SendMouseEvents::.cctor +0x18C)");
					object obj3 = default(object);
					float y = scrollPosition.y + (float)obj3;
					scrollPosition.x = scrollPosition.x;
					scrollPosition.y = y;
				}
			}
			GUILayoutOption[] array = new GUILayoutOption[1];
			float minWidth;
			if (Constants.IsMobile)
			{
				int width = Screen.width;
				minWidth = width;
			}
			else
			{
				minWidth = 760f;
			}
			GUILayoutOption gUILayoutOption = GUILayout.MinWidth(minWidth);
			if (gUILayoutOption != null)
			{
				object obj4 = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				Vector2 vector = default(Vector2);
				vector.x = scrollPosition.x;
				vector.y = scrollPosition.y;
				Vector2 vector2 = (scrollPosition = GUILayout.BeginScrollView(vector, array));
				scrollPosition.y = vector2.y;
				string[] value = events.ToArray();
				string text = string.Join("\n", value);
				GUIStyle style = base.TextStyle;
				GUILayoutOption[] array2 = new GUILayoutOption[2];
				GUILayoutOption gUILayoutOption2 = GUILayout.ExpandHeight(expand: true);
				if (gUILayoutOption2 != null)
				{
					object obj5 = gUILayoutOption2 as GUILayoutOption;
				}
				if (array2.Length != 0)
				{
					array2[0] = gUILayoutOption2;
					float maxWidth;
					if (Constants.IsMobile)
					{
						int width2 = Screen.width;
						int num2 = width2 - 30;
						maxWidth = num2;
					}
					else
					{
						maxWidth = 700f;
					}
					GUILayoutOption gUILayoutOption3 = GUILayout.MaxWidth(maxWidth);
					if (gUILayoutOption3 != null)
					{
						object obj6 = gUILayoutOption3 as GUILayoutOption;
					}
					bool flag2 = array2.Length < 1;
					bool flag3 = !flag2;
					object obj7 = array2.Length - 1;
					bool flag4 = obj7 == null;
					bool flag5 = !flag3;
					if (!(flag5 || flag4))
					{
						array2[1] = gUILayoutOption3;
						string text2 = GUILayout.TextArea(text, style, array2);
						GUILayout.EndScrollView();
						GUILayout.EndVertical();
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0xA09800", Offset = "0xA09800", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC1F30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CB1]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tFacebook.Unity.Example.ConsoleBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LogView()
		{
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xA09864", Offset = "0xA09864", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv16 = *([1EF5120]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021CB2]) = v37;\nL_0019:\n\tv43.datePatt = \"M/d/yyyy hh:mm:ss tt\";\n\tv48 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v48);\n\tv54.events = v48;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LogView()
		{
			List<string> list = new List<string>();
			events = list;
		}
	}
}
