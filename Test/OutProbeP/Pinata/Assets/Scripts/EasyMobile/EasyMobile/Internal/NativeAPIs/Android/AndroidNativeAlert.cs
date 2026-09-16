using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.NativeAPIs.Android
{
	[Token(Token = "0x20000F1")]
	internal static class AndroidNativeAlert
	{
		[Token(Token = "0x4000448")]
		private static readonly string ANDROID_JAVA_UI_CLASS = "com.sglib.easymobile.androidnative.EMNativeUI";

		[Token(Token = "0x60008B2")]
		[Address(RVA = "0xBFFFE0", Offset = "0xBFFFE0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EA36E8]);\n\tv37 = *([v36 @ X8_v30]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, message, button1, button2, button3, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022F8D]) = v52;\nL_0022:\n\tgoto L_002F;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002F;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v55, message, button1, button2, button3, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert;\nL_002F:\n\t// 47 NewArr v72 @ X0_v5 (System.Object[]), typeof(System.Object[]), 5\n\tv76 = title == 0;\n\tif (v76) goto L_003B;\n\t// 56 IsInst v118 @ X0_v29, typeof(System.Object), title @ X0 (System.String)\nL_003B:\n\tv191 = v72.Length;\n\tv125 = v72.Length == 0;\n\tif (v125) goto L_00A8;\n\tv72[0] = title;\n\tv126 = message == 0;\n\tif (v126) goto L_0048;\n\t// 68 IsInst v244 @ X0_v27, typeof(System.Object), message @ X1 (System.String)\n\tv191 = v72.Length;\nL_0048:\n\tv261 = v191 < 1;\n\tv168 = ~v261;\n\tv163 = v191 - 1;\n\tv153 = v163 == 0;\n\tv262 = ~v168;\n\tv128 = v262 | v153;\n\tif (v128) goto L_00A8;\n\tv72[1] = message;\n\tv265 = button1 == 0;\n\tif (v265) goto L_005E;\n\t// 90 IsInst v245 @ X0_v25, typeof(System.Object), button1 @ X2 (System.String)\n\tv191 = v72.Length;\nL_005E:\n\tv268 = v191 < 2;\n\tv169 = ~v268;\n\tv164 = v191 - 2;\n\tv154 = v164 == 0;\n\tv269 = ~v169;\n\tv129 = v269 | v154;\n\tif (v129) goto L_00A8;\n\tv72[2] = button1;\n\tv270 = button2 == 0;\n\tif (v270) goto L_0074;\n\t// 112 IsInst v246 @ X0_v23, typeof(System.Object), button2 @ X3 (System.String)\n\tv191 = v72.Length;\nL_0074:\n\tv273 = v191 < 3;\n\tv170 = ~v273;\n\tv165 = v191 - 3;\n\tv155 = v165 == 0;\n\tv274 = ~v170;\n\tv130 = v274 | v155;\n\tif (v130) goto L_00A8;\n\tv72[3] = button2;\n\tv275 = button3 == 0;\n\tif (v275) goto L_008A;\n\t// 134 IsInst v247 @ X0_v21, typeof(System.Object), button3 @ X4 (System.String)\n\tv191 = v72.Length;\nL_008A:\n\tv278 = v191 < 4;\n\tv171 = ~v278;\n\tv166 = v191 - 4;\n\tv156 = v166 == 0;\n\tv279 = ~v171;\n\tv131 = v279 | v156;\n\tif (v131) goto L_00A8;\n\tv72[4] = button3;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(v67.ANDROID_JAVA_UI_CLASS, \"ShowThreeButtonsAlert\", v72);\n\treturn;\nL_00A8:\n\tv192 = new System.IndexOutOfRangeException();\n\tgoto L_00AD;\n\tv258 = new System.ArrayTypeMismatchException();\nL_00AD:\n\tthrow v264;\n\tthrow System.NullReferenceException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ShowThreeButtonsAlert(string title, string message, string button1, string button2, string button3)
		{
			//IL_003e: Expected O, but got I4
			//IL_0217: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_0275: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_02d3: Expected O, but got I
			//IL_0148: Expected O, but got I4
			//IL_0331: Expected O, but got I
			//IL_0198: Expected O, but got I4
			object[] array = new object[5];
			if (title != null)
			{
				object obj = title as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = title;
				if (message != null)
				{
					object obj3 = message as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = message;
					if (button1 != null)
					{
						object obj5 = button1 as object;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = button1;
						if (button2 != null)
						{
							object obj7 = button2 as object;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = button2;
							if (button3 != null)
							{
								object obj9 = button3 as object;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = button3;
								AndroidUtil.CallJavaStaticMethod(ANDROID_JAVA_UI_CLASS, "ShowThreeButtonsAlert", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008B3")]
		[Address(RVA = "0xC00184", Offset = "0xC00184", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EC40B0]);\n\tv33 = *([v32 @ X8_v27]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, message, button1, button2, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022F8E]) = v49;\nL_0020:\n\tgoto L_002D;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v52, message, button1, button2, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert;\nL_002D:\n\t// 45 NewArr v69 @ X0_v5 (System.Object[]), typeof(System.Object[]), 4\n\tv73 = title == 0;\n\tif (v73) goto L_0039;\n\t// 54 IsInst v115 @ X0_v26, typeof(System.Object), title @ X0 (System.String)\nL_0039:\n\tv175 = v69.Length;\n\tv122 = v69.Length == 0;\n\tif (v122) goto L_008F;\n\tv69[0] = title;\n\tv123 = message == 0;\n\tif (v123) goto L_0046;\n\t// 66 IsInst v225 @ X0_v24, typeof(System.Object), message @ X1 (System.String)\n\tv175 = v69.Length;\nL_0046:\n\tv239 = v175 < 1;\n\tv157 = ~v239;\n\tv153 = v175 - 1;\n\tv145 = v153 == 0;\n\tv240 = ~v157;\n\tv125 = v240 | v145;\n\tif (v125) goto L_008F;\n\tv69[1] = message;\n\tv243 = button1 == 0;\n\tif (v243) goto L_005C;\n\t// 88 IsInst v226 @ X0_v22, typeof(System.Object), button1 @ X2 (System.String)\n\tv175 = v69.Length;\nL_005C:\n\tv246 = v175 < 2;\n\tv158 = ~v246;\n\tv154 = v175 - 2;\n\tv146 = v154 == 0;\n\tv247 = ~v158;\n\tv126 = v247 | v146;\n\tif (v126) goto L_008F;\n\tv69[2] = button1;\n\tv248 = button2 == 0;\n\tif (v248) goto L_0072;\n\t// 110 IsInst v227 @ X0_v20, typeof(System.Object), button2 @ X3 (System.String)\n\tv175 = v69.Length;\nL_0072:\n\tv251 = v175 < 3;\n\tv159 = ~v251;\n\tv155 = v175 - 3;\n\tv147 = v155 == 0;\n\tv252 = ~v159;\n\tv127 = v252 | v147;\n\tif (v127) goto L_008F;\n\tv69[3] = button2;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(v64.ANDROID_JAVA_UI_CLASS, \"ShowTwoButtonsAlert\", v69);\n\treturn;\nL_008F:\n\tv176 = new System.IndexOutOfRangeException();\n\tgoto L_0094;\n\tv236 = new System.ArrayTypeMismatchException();\nL_0094:\n\tthrow v242;\n\tthrow System.NullReferenceException;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ShowTwoButtonsAlert(string title, string message, string button1, string button2)
		{
			//IL_003e: Expected O, but got I4
			//IL_01c7: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_0225: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_0283: Expected O, but got I
			//IL_0148: Expected O, but got I4
			object[] array = new object[4];
			if (title != null)
			{
				object obj = title as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = title;
				if (message != null)
				{
					object obj3 = message as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = message;
					if (button1 != null)
					{
						object obj5 = button1 as object;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = button1;
						if (button2 != null)
						{
							object obj7 = button2 as object;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = button2;
							AndroidUtil.CallJavaStaticMethod(ANDROID_JAVA_UI_CLASS, "ShowTwoButtonsAlert", array);
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008B4")]
		[Address(RVA = "0xC002F4", Offset = "0xC002F4", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EA6220]);\n\tv29 = *([v28 @ X8_v24]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, message, button, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022F8F]) = v46;\nL_001E:\n\tgoto L_002B;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v49, message, button, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert;\nL_002B:\n\t// 43 NewArr v66 @ X0_v5 (System.Object[]), typeof(System.Object[]), 3\n\tv70 = title == 0;\n\tif (v70) goto L_0037;\n\t// 52 IsInst v112 @ X0_v23, typeof(System.Object), title @ X0 (System.String)\nL_0037:\n\tv159 = v66.Length;\n\tv119 = v66.Length == 0;\n\tif (v119) goto L_0076;\n\tv66[0] = title;\n\tv120 = message == 0;\n\tif (v120) goto L_0044;\n\t// 64 IsInst v206 @ X0_v21, typeof(System.Object), message @ X1 (System.String)\n\tv159 = v66.Length;\nL_0044:\n\tv217 = v159 < 1;\n\tv146 = ~v217;\n\tv143 = v159 - 1;\n\tv137 = v143 == 0;\n\tv218 = ~v146;\n\tv122 = v218 | v137;\n\tif (v122) goto L_0076;\n\tv66[1] = message;\n\tv221 = button == 0;\n\tif (v221) goto L_005A;\n\t// 86 IsInst v207 @ X0_v19, typeof(System.Object), button @ X2 (System.String)\n\tv159 = v66.Length;\nL_005A:\n\tv224 = v159 < 2;\n\tv147 = ~v224;\n\tv144 = v159 - 2;\n\tv138 = v144 == 0;\n\tv225 = ~v147;\n\tv123 = v225 | v138;\n\tif (v123) goto L_0076;\n\tv66[2] = button;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(v61.ANDROID_JAVA_UI_CLASS, \"ShowOneButtonAlert\", v66);\n\treturn;\nL_0076:\n\tv160 = new System.IndexOutOfRangeException();\n\tgoto L_007B;\n\tv214 = new System.ArrayTypeMismatchException();\nL_007B:\n\tthrow v220;\n\tthrow System.NullReferenceException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ShowOneButtonAlert(string title, string message, string button)
		{
			//IL_003e: Expected O, but got I4
			//IL_0177: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_01d5: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			object[] array = new object[3];
			if (title != null)
			{
				object obj = title as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = title;
				if (message != null)
				{
					object obj3 = message as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = message;
					if (button != null)
					{
						object obj5 = button as object;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = button;
						AndroidUtil.CallJavaStaticMethod(ANDROID_JAVA_UI_CLASS, "ShowOneButtonAlert", array);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008B5")]
		[Address(RVA = "0xC00438", Offset = "0xC00438", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F06D18]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, longToast, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022F90]) = v43;\nL_001C:\n\tgoto L_0029;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v46, longToast, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = EasyMobile.Internal.NativeAPIs.Android.AndroidNativeAlert;\nL_0029:\n\t// 41 NewArr v63 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv67 = message == 0;\n\tif (v67) goto L_0036;\n\t// 50 IsInst v114 @ X0_v22, typeof(System.Object), message @ X0 (System.String)\nL_0036:\n\tv121 = v63.Length == 0;\n\tif (v121) goto L_0065;\n\tv63[0] = message;\n\t// 63 Box v128 @ X0_v16, typeof(System.Boolean), &longToast @ X1 (System.Boolean)\n\tv201 = v128 == 0;\n\tif (v201) goto L_004A;\n\t// 70 IsInst v194 @ X0_v20, typeof(System.Object), v128 @ X0_v16\nL_004A:\n\tv206 = v63.Length < 1;\n\tv146 = ~v206;\n\tv144 = v63.Length - 1;\n\tv140 = v144 == 0;\n\tv207 = ~v146;\n\tv130 = v207 | v140;\n\tif (v130) goto L_0065;\n\tv63[1] = v128;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(v58.ANDROID_JAVA_UI_CLASS, \"ShowToast\", v63);\n\treturn;\nL_0065:\n\tv158 = new System.IndexOutOfRangeException();\n\tgoto L_006A;\n\tv200 = new System.ArrayTypeMismatchException();\nL_006A:\n\tthrow v203;\n\tthrow System.NullReferenceException;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ShowToast(string message, bool longToast = false)
		{
			//IL_00cd: Expected O, but got I4
			object[] array = new object[2];
			if (message != null)
			{
				object obj = message as object;
			}
			if (array.Length != 0)
			{
				array[0] = message;
				object obj2 = longToast;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj2;
					AndroidUtil.CallJavaStaticMethod(ANDROID_JAVA_UI_CLASS, "ShowToast", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
