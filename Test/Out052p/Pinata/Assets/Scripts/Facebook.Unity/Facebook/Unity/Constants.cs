using System;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x200000A")]
	public static class Constants
	{
		[Token(Token = "0x400001D")]
		private static FacebookUnityPlatform? currentPlatform;

		[Token(Token = "0x1700000C")]
		public static Uri GraphUrl
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0xD25204", Offset = "0xD25204", Length = "0x1F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EADA88]);\n\tv21 = *([v20 @ X8_v47]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023BA5]) = v41;\nL_001A:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv56 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 40 NewArr v63 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tgoto L_003B;\n\tv71 = *([v67 @ X8_v10+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_003B;\n\tv82 = v67;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v82, v60, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003B:\n\tgoto L_0046;\n\tv84 = *([1F0A0F8]);\n\tv85 = *([v84 @ X8_v43]);\n\tv86 = \"il2cpp_codegen_initialize_method\"(v85, v60, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv89 = 0 | 1;\n\t*([2023CAC]) = v89;\nL_0046:\n\tgoto L_0051;\n\tv94 = *([v90 @ X0_v10 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\t// 74 Jump @b43\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v90, v60, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = Facebook.Unity.FB;\nL_0051:\n\tv105 = v103.facebookDomain == 0;\n\tif (v105) goto L_005A;\n\t// 86 IsInst v150 @ X0_v38, typeof(System.Object), v103.facebookDomain (System.String)\nL_005A:\n\tv157 = v63.Length == 0;\n\tif (v157) goto L_00A5;\n\tv63[0] = v103.facebookDomain;\n\tgoto L_006C;\n\tv234 = *([1EDFFC0]);\n\tv235 = *([v234 @ X8_v37]);\n\tv236 = \"il2cpp_codegen_initialize_method\"(v235, v151, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv239 = 0 | 1;\n\t*([2023CAA]) = v239;\nL_006C:\n\tgoto L_0075;\n\tv246 = *([v240 @ X0_v23 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tgoto L_0075;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v240, v151, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv250 = Facebook.Unity.FB;\nL_0075:\n\tv254 = v253.graphApiVersion == 0;\n\tif (v254) goto L_007E;\n\t// 122 IsInst v227 @ X0_v32, typeof(System.Object), v253.graphApiVersion (System.String)\nL_007E:\n\tv258 = v63.Length < 1;\n\tv179 = ~v258;\n\tv177 = v63.Length - 1;\n\tv173 = v177 == 0;\n\tv259 = ~v179;\n\tv163 = v259 | v173;\n\tif (v163) goto L_00A5;\n\tv63[1] = v253.graphApiVersion;\n\tv265 = System.String::Format(v56, \"https://graph.{0}/{1}/\", v63);\n\tv270 = new System.Uri();\n\tSystem.Uri::.ctor(v270, v265);\n\treturn v270;\nL_00A5:\n\tv190 = new System.IndexOutOfRangeException();\n\tgoto L_00AA;\n\tv232 = new System.ArrayTypeMismatchException();\nL_00AA:\n\tthrow v245;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00d2: Expected O, but got I4
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				object[] array = new object[2];
				if (FB.facebookDomain != null)
				{
					object obj = FB.facebookDomain as object;
				}
				if (array.Length != 0)
				{
					array[0] = FB.facebookDomain;
					if (FB.graphApiVersion != null)
					{
						object obj2 = FB.graphApiVersion as object;
					}
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj3 = array.Length - 1;
					bool flag3 = obj3 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = FB.graphApiVersion;
						string uriString = string.Format(invariantCulture, "https://graph.{0}/{1}/", array);
						return new Uri(uriString);
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
		}

		[Token(Token = "0x1700000D")]
		public static string GraphApiUserAgent
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0xD1D3C4", Offset = "0xD1D3C4", Length = "0x1C0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEE318]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023BA6]) = v39;\nL_0019:\n\tgoto L_0020;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0020;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv54 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 39 NewArr v73 @ X0_v8 (System.Object[]), typeof(System.Object[]), 2\n\tgoto L_0036;\n\tv69 = *([v65 @ X8_v12+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0036;\n\tv77 = v65;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0036:\n\tv76 = Facebook.Unity.FB::get_FacebookImpl();\n\tv81 = *([v76 @ X0_v9 (Facebook.Unity.IFacebook)]);\n\tv85 = *([v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+126]) == 0;\n\tif (v85) goto L_005E;\n\tv217 = *([v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]) + 8;\nL_0049:\n\tv223 = *([v217 @ X11_v7-8]) == Facebook.Unity.IFacebook;\n\tif (v223) goto L_0061;\n\tv218 = v218 + 1;\n\tv228 = v218 < *([v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+126]);\n\tv162 = ~v228;\n\tv217 = v217 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_0049;\nL_005E:\n\tv234 = 0x8909C4(v76, Facebook.Unity.IFacebook, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0068;\nL_0061:\n\tv230 = *([v217 @ X11_v7]) + 3;\n\tv231 = v230 << 4;\n\tv232 = v81 + v231;\n\tv234 = v232 + 0x130;\nL_0068:\n\t*([v234 @ X0_v15])(v200, v76, *([v234 @ X0_v15+8]), 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv282 = v200 == 0;\n\tif (v282) goto L_0075;\n\t// 113 IsInst v288 @ X0_v22, typeof(System.Object), v200 @ X0_v17\nL_0075:\n\tv293 = v73.Length == 0;\n\tif (v293) goto L_009E;\n\tv73[0] = v200;\n\tv294 = Facebook.Unity.Constants::get_UnitySDKUserAgent();\n\tv324 = v294 == 0;\n\tif (v324) goto L_0083;\n\t// 127 IsInst v318 @ X0_v30, typeof(System.Object), v294 @ X0_v25 (System.String)\nL_0083:\n\tv329 = v73.Length < 1;\n\tv262 = ~v329;\n\tv260 = v73.Length - 1;\n\tv256 = v260 == 0;\n\tv330 = ~v262;\n\tv246 = v330 | v256;\n\tif (v246) goto L_009E;\n\tv73[1] = v294;\n\treturnVal2 = System.String::Format(v54, \"{0} {1}\", v73);\n\treturn returnVal2;\nL_009E:\n\tv313 = new System.IndexOutOfRangeException();\n\tgoto L_00A3;\n\tv323 = new System.ArrayTypeMismatchException();\nL_00A3:\n\tthrow v326;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003c: Expected I, but got O
				//IL_0077: Expected O, but got I
				//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f9: Expected O, but got Unknown
				//IL_0116: Expected O, but got I
				//IL_0125: Expected O, but got I
				//IL_00c3: Expected O, but got I
				//IL_01ef: Expected O, but got I4
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				object[] array = new object[2];
				IFacebook facebookImpl = FB.FacebookImpl;
				IntPtr intPtr = (IntPtr)facebookImpl;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00dc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X11_v7-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IFacebook))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v15 (Il2CppClass<Facebook.Unity.IFacebook>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00dc;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0293;
				IL_00dc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0293;
				IL_0293:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v234 @ X0_v15] (should have been resolved before IL gen)");
				object obj5 = default(object);
				if (obj5 != null)
				{
					object obj6 = obj5 as object;
				}
				if (array.Length != 0)
				{
					array[0] = obj5;
					string unitySDKUserAgent = UnitySDKUserAgent;
					if (unitySDKUserAgent != null)
					{
						object obj7 = unitySDKUserAgent as object;
					}
					bool flag3 = array.Length < 1;
					bool flag4 = !flag3;
					object obj8 = array.Length - 1;
					bool flag5 = obj8 == null;
					bool flag6 = !flag4;
					if (!(flag6 || flag5))
					{
						array[1] = unitySDKUserAgent;
						return string.Format(invariantCulture, "{0} {1}", array);
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
		}

		[Token(Token = "0x1700000E")]
		public static bool IsMobile
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0xD25544", Offset = "0xD25544", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv12 = v6 == 1;\n\tif (v12) goto L_001D;\n\tv17 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv31 = v17 - 2;\n\tv27 = v31 == 0;\nL_001D:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookUnityPlatform facebookUnityPlatform = CurrentPlatform;
				bool flag = facebookUnityPlatform == FacebookUnityPlatform.Android;
				bool result = (byte)facebookUnityPlatform != 0;
				if (!flag)
				{
					FacebookUnityPlatform facebookUnityPlatform2 = CurrentPlatform;
					int num = (int)(facebookUnityPlatform2 - 2);
					bool flag2 = num == 0;
					result = flag2;
				}
				return result;
			}
		}

		[Token(Token = "0x1700000F")]
		public static bool IsEditor
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0xD2556C", Offset = "0xD2556C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_isEditor();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Application.isEditor;
			}
		}

		[Token(Token = "0x17000010")]
		public static bool IsWeb
		{
			[Token(Token = "0x6000034")]
			[Address(RVA = "0xD25574", Offset = "0xD25574", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv10 = v6 - 3;\n\tv12 = v10 == 0;\n\treturn v12;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookUnityPlatform facebookUnityPlatform = CurrentPlatform;
				int num = (int)(facebookUnityPlatform - 3);
				return num == 0;
			}
		}

		[Token(Token = "0x17000011")]
		public static bool IsGameroom
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0xD25590", Offset = "0xD25590", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv10 = v6 - 4;\n\tv12 = v10 == 0;\n\treturn v12;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookUnityPlatform facebookUnityPlatform = CurrentPlatform;
				int num = (int)(facebookUnityPlatform - 4);
				return num == 0;
			}
		}

		[Token(Token = "0x17000012")]
		public static string UnitySDKUserAgentSuffixLegacy
		{
			[Token(Token = "0x6000036")]
			[Address(RVA = "0xD255AC", Offset = "0xD255AC", Length = "0x11C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F103D0]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2023BA7]) = v41;\nL_001A:\n\tgoto L_0021;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0021;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv56 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 41 NewArr v64 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_003B;\n\tv72 = *([1EE6770]);\n\tv73 = *([v72 @ X8_v23]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, v60, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\t*([2023C31]) = v61;\nL_003B:\n\tv81 = \"7.18.0\" == 0;\n\tif (v81) goto L_0044;\n\t// 64 IsInst v87 @ X0_v19, typeof(System.Object), \"7.18.0\"\nL_0044:\n\tv94 = v64.Length == 0;\n\tif (v94) goto L_0058;\n\tv64[0] = \"7.18.0\";\n\treturnVal1 = System.String::Format(v56, \"Unity.{0}\", v64);\n\treturn returnVal1;\n\tv83 = new System.NullReferenceException();\nL_0058:\n\tv100 = new System.IndexOutOfRangeException();\n\tgoto L_005D;\n\tv114 = new System.ArrayTypeMismatchException();\nL_005D:\n\tthrow v117;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				object[] array = new object[1];
				if ("7.18.0" != null)
				{
					object obj = "7.18.0" as object;
				}
				if (array.Length != 0)
				{
					array[0] = "7.18.0";
					return string.Format(invariantCulture, "Unity.{0}", array);
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
		}

		[Token(Token = "0x17000013")]
		public static string UnitySDKUserAgent
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0xD254CC", Offset = "0xD254CC", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EFFEB8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BA8]) = v35;\nL_0016:\n\tgoto L_0027;\n\tv42 = *([1EE6770]);\n\tv43 = *([v42 @ X8_v8]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv47 = 0 | 1;\n\t*([2023C31]) = v47;\nL_0027:\n\treturnVal1 = Facebook.Unity.Utilities::GetUserAgent(\"FBUnitySDK\", \"7.18.0\");\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Utilities.GetUserAgent("FBUnitySDK", "7.18.0");
			}
		}

		[Token(Token = "0x17000014")]
		public static bool DebugMode
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0xD256C8", Offset = "0xD256C8", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED29D0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BA9]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\treturnVal1 = UnityEngine.Debug::get_isDebugBuild();\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Debug.isDebugBuild;
			}
		}

		[Token(Token = "0x17000015")]
		public unsafe static FacebookUnityPlatform CurrentPlatform
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0xD1D2F0", Offset = "0xD1D2F0", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = *([1F02340]);\n\tv15 = *([v14 @ X8_v20]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BAA]) = v35;\nL_0013:\n\tv38 = Facebook.Unity.Constants;\n\tv39 = *([v38 @ X8_v3 (Il2CppClass<Facebook.Unity.Constants>)+B8]);\n\tv41 = *([v39 @ X9_v1 (Il2CppStaticFields<Facebook.Unity.Constants>)+4]) == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_007A;\n\tv44 = UnityEngine.Application::get_platform();\n\tv104 = v44 - 8;\n\tv105 = v104 < 0;\n\tv106 = v104 == 0;\n\tv107 = v44 ^ 8;\n\tv108 = v44 ^ v104;\n\tv109 = v107 & v108;\n\tv110 = v109 < 0;\n\tv115 = v105 == v110;\n\tv116 = ~v106;\n\tv117 = v115 & v116;\n\tv118 = ~v117;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tv126 = v105 == v110;\n\tv127 = ~v106;\n\tv128 = v126 & v127;\n\tv129 = ~v128;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tv132 = v105 == v110;\n\tv56 = ~v106;\n\tv133 = v132 & v56;\n\tv134 = ~v133;\n\tif (v134) goto L_FFFFFFFF;\n\tv65 = 2 + 1;\n\tgoto L_0044;\nL_0044:\n\tv137 = v105 == v110;\n\tv138 = ~v137;\n\tv59 = v138 | v106;\n\tv139 = ~v59;\n\tif (v139) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_005A:\n\tv155 = v44 != v124;\n\tif (v155) goto L_FFFFFFFF;\n\tgoto L_0069;\nL_0069:\n\tv53 = v44 != v62;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tv94 = System.Nullable`1<Facebook.Unity.FacebookUnityPlatform>::.ctor(&v48 @ stack_-18_v3 (System.Nullable`1<Facebook.Unity.FacebookUnityPlatform>), v51);\n\tv164.currentPlatform = v48;\nL_007A:\n\treturnVal1 = System.Nullable`1<Facebook.Unity.FacebookUnityPlatform>::get_Value(v95.currentPlatform);\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0169: Expected I, but got O
				//IL_0172: Expected I, but got O
				IntPtr intPtr = (IntPtr)typeof(Constants);
				IntPtr intPtr2 = (IntPtr)(void*)currentPlatform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X9_v1 (Il2CppStaticFields<Facebook.Unity.Constants>)+4]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					RuntimePlatform platform = Application.platform;
					int num = (int)(platform - 8);
					bool flag = num < 0;
					bool flag2 = num == 0;
					int num2 = (int)(platform ^ RuntimePlatform.IPhonePlayer);
					int num3 = (int)platform ^ num;
					int num4 = num2 & num3;
					bool flag3 = num4 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					int num5 = ((!(flag4 && flag5)) ? 8 : 17);
					bool flag6 = flag == flag3;
					bool flag7 = !flag2;
					int num6 = ((!(flag6 && flag7)) ? 2 : 11);
					bool flag8 = flag == flag3;
					bool flag9 = !flag2;
					int num7 = ((!(flag8 && flag9)) ? 2 : (2 + 1));
					bool flag10 = flag == flag3;
					bool flag11 = !flag10;
					int num8 = ((!(flag11 || flag2)) ? 1 : 4);
					int num9 = ((platform == (RuntimePlatform)num5) ? num7 : 0);
					FacebookUnityPlatform value = (FacebookUnityPlatform)((platform != (RuntimePlatform)num6) ? num9 : num8);
					FacebookUnityPlatform? facebookUnityPlatform = value;
					currentPlatform = facebookUnityPlatform;
				}
				return currentPlatform.Value;
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0xD25728", Offset = "0xD25728", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Application::get_platform();\n\tv10 = v7 - 8;\n\tv11 = v10 < 0;\n\tv12 = v10 == 0;\n\tv13 = v7 ^ 8;\n\tv14 = v7 ^ v10;\n\tv15 = v13 & v14;\n\tv16 = v15 < 0;\n\tv21 = v11 == v16;\n\tv22 = ~v12;\n\tv23 = v21 & v22;\n\tv24 = ~v23;\n\tif (v24) goto L_FFFFFFFF;\n\tgoto L_001D;\nL_001D:\n\tv29 = v11 == v16;\n\tv30 = ~v12;\n\tv31 = v29 & v30;\n\tv32 = ~v31;\n\tif (v32) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\tv36 = v11 == v16;\n\tv37 = ~v12;\n\tv38 = v36 & v37;\n\tv39 = ~v38;\n\tif (v39) goto L_FFFFFFFF;\n\tv42 = 2 + 1;\n\tgoto L_002F;\nL_002F:\n\tv43 = v11 == v16;\n\tv44 = ~v43;\n\tv45 = v44 | v12;\n\tv46 = ~v45;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv59 = v7 != v27;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0050;\nL_0050:\n\tv72 = v7 != v35;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_0059;\nL_0059:\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FacebookUnityPlatform GetCurrentPlatform()
		{
			RuntimePlatform platform = Application.platform;
			int num = (int)(platform - 8);
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = (int)(platform ^ RuntimePlatform.IPhonePlayer);
			int num3 = (int)platform ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? 8 : 17);
			bool flag6 = flag == flag3;
			bool flag7 = !flag2;
			int num6 = ((!(flag6 && flag7)) ? 2 : 11);
			bool flag8 = flag == flag3;
			bool flag9 = !flag2;
			int num7 = ((!(flag8 && flag9)) ? 2 : (2 + 1));
			bool flag10 = flag == flag3;
			bool flag11 = !flag10;
			int result = ((!(flag11 || flag2)) ? 1 : 4);
			int result2 = ((platform == (RuntimePlatform)num5) ? num7 : 0);
			if (platform == (RuntimePlatform)num6)
			{
				return (FacebookUnityPlatform)result;
			}
			return (FacebookUnityPlatform)result2;
		}
	}
}
