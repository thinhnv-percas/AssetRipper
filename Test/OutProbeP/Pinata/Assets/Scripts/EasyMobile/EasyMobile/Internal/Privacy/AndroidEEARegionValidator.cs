using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Privacy
{
	[Token(Token = "0x20000D6")]
	internal class AndroidEEARegionValidator : BaseNativeEEARegionValidator
	{
		[Token(Token = "0x40003C5")]
		protected const string AndroidClassName = "com.sglib.easymobile.androidnative.gdpr.EEARegionChecker";

		[Token(Token = "0x40003C6")]
		protected const string NativeLocaleValidationMethod = "GetCountryCodeViaLocale";

		[Token(Token = "0x40003C7")]
		protected const string NativeTelephonyValidationMethod = "GetCountryCodeViaTelephony";

		[Token(Token = "0x40003C8")]
		protected const string NativeTimezoneValidationMethod = "ValidateEEARegionViaTimezone";

		[Token(Token = "0x40003C9")]
		[FieldOffset(Offset = "0x18")]
		protected AndroidJavaClass nativeValidator;

		[Token(Token = "0x17000229")]
		protected override string GoogleServiceUrl
		{
			[Token(Token = "0x60007A7")]
			[Address(RVA = "0xC07B14", Offset = "0xC07B14", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1F04AF0]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023002]) = v35;\nL_0016:\n\tgoto L_0026;\n\tv42 = *([1F02600]);\n\tv43 = *([v42 @ X8_v12]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv47 = 0 | 1;\n\t*([2023007]) = v47;\nL_0026:\n\tgoto L_0032;\n\tv57 = *([v50 @ X0_v3+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0032;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0032:\n\treturnVal1 = System.Uri::EscapeUriString(\"https://adservice.google.com/getconfig/pubvendors?pubs=%1$s&amp;es=2\");\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Uri.EscapeUriString("https://adservice.google.com/getconfig/pubvendors?pubs=%1$s&amp;es=2");
			}
		}

		[Token(Token = "0x60007A8")]
		[Address(RVA = "0xC07BF0", Offset = "0xC07BF0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F08910]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023003]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v44, \"com.sglib.easymobile.androidnative.gdpr.EEARegionChecker\");\n\tthis.nativeValidator = v44;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidEEARegionValidator()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.sglib.easymobile.androidnative.gdpr.EEARegionChecker");
			nativeValidator = androidJavaClass;
		}

		[Token(Token = "0x60007A9")]
		[Address(RVA = "0xC07C70", Offset = "0xC07C70", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EE9F08]);\n\tv21 = *([v20 @ X8_v33]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023004]) = v40;\nL_0016:\n\tv43 = this.nativeValidator == 0;\n\tif (v43) goto L_00BA;\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv59 = v48;\n\tv60 = 0x8907BC(v59, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv63 = *([v48 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv64 = *([v48 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv65 = v64 == 0;\n\tif (v65) goto L_0046;\n\tv69 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv100 = v69;\n\tv101 = 0x8907BC(v100, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv102 = *([v69 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv79 = ~v102;\n\tif (v79) goto L_0046;\n\tgoto L_0046;\n\tv188 = v84;\n\tv189 = 0x8907BC(v188, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tgoto L_0052;\n\tv103 = v86;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\tv115 = UnityEngine.AndroidJavaObject::CallStatic(this.nativeValidator, \"GetCountryCodeViaLocale\", v107.Value);\n\tv139 = v115 != 0;\n\tif (v139) goto L_FFFFFFFF;\n\tgoto L_006A;\nL_006A:\n\tv223 = System.String::Concat(\"[GetCountryCodeViaLocale]. Response: \", v222);\n\tgoto L_007A;\n\tv233 = *([v227 @ X0_v27+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tgoto L_007A;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v227, v222, v163, v113, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007A:\n\tUnityEngine.Debug::Log(v223);\n\tgoto L_00D1;\n\tgoto L_007F;\n\tgoto L_007F;\n\tgoto L_007F;\nL_007F:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00DF;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00D3;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00DB;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EF6A40]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00B4;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B4;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B4:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::Log(X0, X1);\nL_00BA:\n\tv56 = 0;\n\t// 188 Box v58 @ X0_v5, typeof(EasyMobile.EEARegionStatus), &v56 @ stack_-24_v3\n\tv67 = v58 == 0;\n\tif (v67) goto L_00D2;\n\tv91 = *([v58 @ X0_v5]);\n\t*([v91 @ X8_v7+160])(v95, v58, *([v91 @ X8_v7+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = \"il2cpp_vm_object_unbox\"(v58, *([v91 @ X8_v7+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D1:\n\treturn v172;\nL_00D2:\n\tthrow System.NullReferenceException;\nL_00D3:\n\t;\n\tv183 = *([v58 @ X0_v5]);\n\t*([v119 @ X0_v8]) = v183;\n\tv185 = 0x1E8A000 + 0x870;\n\tv187 = 0x6D2A00(v119, v185, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DB:\n\t;\n\tv221 = new System.NullReferenceException();\n\tv224 = 0x6D2490(v221, v185, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DF:\n\t;\n\tv232 = 0x6D2380(v221, v185, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = 0x846AA4(v232, v185, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string GetCountryCodeViaLocale()
		{
			//IL_00c8: Expected O, but got I4
			//IL_00d1: Expected I4, but got O
			if (nativeValidator != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				string text = nativeValidator.CallStatic<string>("GetCountryCodeViaLocale", Array.Empty<object>());
				string text2 = ((text != null) ? text : "null");
				string message = "[GetCountryCodeViaLocale]. Response: " + text2;
				Debug.Log(message);
				return text;
			}
			object obj = 0;
			object obj2 = (EEARegionStatus)obj;
			if (obj2 != null)
			{
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ X8_v7+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string result = default(string);
				return result;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60007AA")]
		[Address(RVA = "0xC07F00", Offset = "0xC07F00", Length = "0x290")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EC91D8]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023005]) = v40;\nL_0016:\n\tv43 = this.nativeValidator == 0;\n\tif (v43) goto L_00BB;\n\tv48 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv59 = v48;\n\tv60 = 0x8907BC(v59, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv63 = *([v48 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv64 = *([v48 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv65 = v64 == 0;\n\tif (v65) goto L_0046;\n\tv69 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv100 = v69;\n\tv101 = 0x8907BC(v100, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv102 = *([v69 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv79 = ~v102;\n\tif (v79) goto L_0046;\n\tgoto L_0046;\n\tv139 = v84;\n\tv140 = 0x8907BC(v139, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tgoto L_0052;\n\tv103 = v86;\n\tv104 = 0x8907BC(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\tv115 = UnityEngine.AndroidJavaObject::CallStatic(this.nativeValidator, \"GetCountryCodeViaTelephony\", v107.Value);\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v115, \"GetCountryCodeViaTelephony\", v107.Value);\n\treturn returnVal2;\n\tC = X19 < 0;\n\tC = ~C;\n\tTEMP1 = X19 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ 0;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX0 = *([X8]);\n\tX9 = *([1F08000]);\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0068;\n\tX1 = X9;\n\tgoto L_0069;\nL_0068:\n\tX1 = X19;\nL_0069:\n\t;\n\tX2 = 0;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX20 = X0;\n\tX8 = *([1EBC820]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0079;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0079;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0079:\n\tX0 = X20;\n\tX1 = 0;\n\tUnityEngine.Debug::Log(X0, X1);\n\tgoto L_00D2;\n\tgoto L_0080;\n\tgoto L_0080;\n\tgoto L_0080;\nL_0080:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00E0;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00D4;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00DC;\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA74F0]);\n\tX1 = X0;\n\tX2 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2);\n\tX8 = *([1EBC820]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00B5;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B5;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B5:\n\tX0 = X19;\n\tX1 = 0;\n\tUnityEngine.Debug::Log(X0, X1);\nL_00BB:\n\tv56 = 0;\n\t// 189 Box v58 @ X0_v3, typeof(EasyMobile.EEARegionStatus), &v56 @ stack_-24_v2\n\tv67 = v58 == 0;\n\tif (v67) goto L_00D3;\n\tv91 = *([v58 @ X0_v3]);\n\t*([v91 @ X8_v6+160])(v95, v58, *([v91 @ X8_v6+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = \"il2cpp_vm_object_unbox\"(v58, *([v91 @ X8_v6+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D2:\n\treturn v95;\nL_00D3:\n\tthrow System.NullReferenceException;\nL_00D4:\n\t;\n\tv134 = *([v58 @ X0_v3]);\n\t*([v119 @ X0_v6]) = v134;\n\tv136 = 0x1E8A000 + 0x870;\n\tv138 = 0x6D2A00(v119, v136, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DC:\n\t;\n\tv162 = new System.NullReferenceException();\n\tv163 = 0x6D2490(v162, v136, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00E0:\n\t;\n\tv165 = 0x6D2380(v162, v136, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal3 = 0x846AA4(v165, v136, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal3;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string GetCountryCodeViaTelephony()
		{
			//IL_0098: Expected O, but got I4
			//IL_00a1: Expected I4, but got O
			if (nativeValidator != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				string text = nativeValidator.CallStatic<string>("GetCountryCodeViaTelephony", Array.Empty<object>());
				return ((AndroidJavaObject)(object)text).CallStatic<string>("GetCountryCodeViaTelephony", Array.Empty<object>());
			}
			object obj = 0;
			object obj2 = (EEARegionStatus)obj;
			if (obj2 != null)
			{
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ X8_v6+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string result = default(string);
				return result;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60007AB")]
		[Address(RVA = "0xC08190", Offset = "0xC08190", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F0C308]);\n\tv25 = *([v24 @ X8_v59]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023006]) = v44;\nL_0018:\n\tv47 = this.nativeValidator == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv52 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tv270 = *([v52 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\n\tgoto L_0027;\n\tv150 = v52;\n\tv151 = 0x8907BC(v150, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv154 = *([v52 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0027:\n\tv155 = *([v52 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv156 = v155 == 0;\n\tif (v156) goto L_0048;\n\tv207 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0033;\n\tv263 = v207;\n\tv264 = 0x8907BC(v263, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tv270 = *([v207 @ X20_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]);\n\tv265 = *([v207 @ X20_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv217 = ~v265;\n\tif (v217) goto L_0048;\n\tgoto L_0048;\n\tv286 = v222;\n\tv287 = 0x8907BC(v286, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0048:\n\tgoto L_0054;\n\tv266 = v224;\n\tv267 = 0x8907BC(v266, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0054:\n\tv276 = UnityEngine.AndroidJavaObject::CallStatic(this.nativeValidator, \"ValidateEEARegionViaTimezone\", v270.Value);\n\tv88 = v276 == 0;\n\tv68 = ~v88;\n\tv65 = ~v68;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tv293 = System.String::Concat(\"[ValidateViaTimezone]. Response: \", v292);\n\tgoto L_007D;\n\tv299 = *([v295 @ X0_v12+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tgoto L_007D;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v295, v292, v111, v104, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_007D:\n\tUnityEngine.Debug::Log(v293);\n\tv308 = v276 == 0;\n\tif (v308) goto L_00A1;\n\tv310 = 1;\n\t// 134 Box v314 @ X0_v20, typeof(EasyMobile.EEARegionStatus), &v310 @ X8_v23 (System.Int32)\n\tv270 = *([v314 @ X0_v20]);\n\t*([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160])(v330, v314, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv332 = \"il2cpp_vm_object_unbox\"(v314, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv336 = System.String::Equals(v276, v330);\n\tv190 = v336 == 0;\n\tif (v190) goto L_00B7;\n\tgoto L_00B5;\nL_00A1:\n\tgoto L_00AB;\n\tv320 = *([v315 @ X0_v15+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_00AB;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v315, v307, v111, v104, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00AB:\n\tUnityEngine.Debug::Log(\"[ValidateViaTimezone]. Error: native response is null.\");\nL_00B5:\n\treturn returnVal1;\nL_00B7:\n\tv349 = 2;\n\t// 186 Box v345 @ X0_v60, typeof(EasyMobile.EEARegionStatus), &v349 @ X8_v40 (System.Int32)\n\tv270 = *([v345 @ X0_v60]);\n\t*([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160])(v372, v345, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv374 = \"il2cpp_vm_object_unbox\"(v345, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv387 = System.String::Equals(v276, v372);\n\tv191 = v387 == 0;\n\tif (v191) goto L_00D2;\n\tgoto L_00B5;\nL_00D2:\n\tv354 = 0;\n\t// 212 Box v359 @ X0_v68, typeof(EasyMobile.EEARegionStatus), &v354 @ stack_-34_v10\n\tv361 = v359 == 0;\n\tif (v361) goto L_0104;\n\tv270 = *([v359 @ X0_v68]);\n\t*([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160])(v410, v359, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv412 = \"il2cpp_vm_object_unbox\"(v359, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+168]), 0, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv128 = System.String::Equals(v276, v410);\n\tv434 = v128 == 0;\n\tv133 = ~v434;\n\tif (v133) goto L_FFFFFFFF;\n\tv444 = System.String::Concat(\"[ValidateViaTimezone]. Error: unexpected native response: \", v276);\n\tgoto L_00FD;\n\tv450 = *([v446 @ X0_v77+E0]);\n\tv451 = v450 == 0;\n\tv452 = ~v451;\n\tif (v452) goto L_00FD;\n\tv454 = \"il2cpp_codegen_runtime_class_init\"(v446, v443, v113, v104, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00FD:\n\tUnityEngine.Debug::Log(v444);\n\tgoto L_FFFFFFFF;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0104:\n\tv365 = new System.NullReferenceException();\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\n\tgoto L_011D;\nL_011D:\n\tv69 = v245 != 1;\n\tif (v69) goto L_0159;\n\tv376 = UnityEngine.AndroidJavaObject::CallStatic(v365, v245, v378);\n\tv389 = *([v376 @ X0_v29 (System.String)]);\n\tv245 = *([v389 @ X19_v9 (Il2CppClass<System.String>)]);\n\tv393 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v389 @ X19_v9 (Il2CppClass<System.String>)]), v378, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv395 = v393 & 1;\n\tv396 = v395 == 0;\n\tif (v396) goto L_014D;\n\tv398 = UnityEngine.AndroidJavaObject::CallStatic(v393, v245, v378);\n\tv401 = v389 == 0;\n\tif (v401) goto L_0155;\n\tv270 = *([v389 @ X19_v9 (Il2CppClass<System.String>)]);\n\t*([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+180])(v417, v389, *([v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+188]), v378, Il2CppMethodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv423 = System.String::Concat(\"[ValidateViaTimezone]. Error: \", v417);\n\tgoto L_014A;\n\tv435 = *([v144 @ X8_v36+E0]);\n\tv436 = v435 == 0;\n\tv437 = ~v436;\n\tif (v437) goto L_014A;\n\tv445 = v144;\n\tv439 = \"il2cpp_codegen_runtime_class_init\"(v445, v420, v114, v104, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_014A:\n\tUnityEngine.Debug::Log(v423);\n\tgoto L_FFFFFFFF;\nL_014D:\n\tv400 = UnityEngine.AndroidJavaObject::CallStatic(8, *([v389 @ X19_v9 (Il2CppClass<System.String>)]), v378);\n\t*([v400 @ X0_v37 (System.String)]) = *([v376 @ X0_v29 (System.String)]);\n\tv245 = 0x1E8A000 + 0x870;\n\tv406 = UnityEngine.AndroidJavaObject::CallStatic(v400, v245, 0);\nL_0155:\n\tv426 = new System.NullReferenceException();\n\tv380 = UnityEngine.AndroidJavaObject::CallStatic(v426, v245, 0);\nL_0159:\n\tv385 = UnityEngine.AndroidJavaObject::CallStatic(v257, v245, 0);\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v385, v245, 0);\n\treturn returnVal2;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override EEARegionStatus ValidateViaTimezone()
		{
			//IL_0125: Expected I, but got O
			//IL_01c5: Expected I, but got O
			//IL_0228: Expected O, but got I4
			//IL_0231: Expected I4, but got O
			//IL_025a: Expected I, but got O
			//IL_046a: Expected I4, but got O
			//IL_0329: Expected I, but got O
			//IL_0331: Expected O, but got I
			//IL_03ec: Expected O, but got I
			//IL_03ec: Expected O, but got I4
			//IL_0407: Expected O, but got I4
			if (nativeValidator != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X20_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X20_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				string text = nativeValidator.CallStatic<string>("ValidateEEARegionViaTimezone", Array.Empty<object>());
				string text2 = ((text == null) ? "null" : text);
				string message = "[ValidateViaTimezone]. Response: " + text2;
				Debug.Log(message);
				if (text != null)
				{
					int num = 1;
					object obj = (EEARegionStatus)num;
					intPtr2 = (IntPtr)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string value = default(string);
					if (text.Equals(value))
					{
						return EEARegionStatus.InEEA;
					}
					int num2 = 2;
					object obj2 = (EEARegionStatus)num2;
					intPtr2 = (IntPtr)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string value2 = default(string);
					if (text.Equals(value2))
					{
						return EEARegionStatus.NotInEEA;
					}
					object obj3 = 0;
					object obj4 = (EEARegionStatus)obj3;
					if (obj4 == null)
					{
						NullReferenceException ex = new NullReferenceException();
						string text3 = default(string);
						bool flag = (IntPtr)text3 != (IntPtr)1;
						NullReferenceException ex2 = ex;
						if (!flag)
						{
							object[] args = default(object[]);
							string text4 = ((AndroidJavaObject)(object)ex).CallStatic<string>(text3, args);
							IntPtr intPtr4 = (IntPtr)text4;
							text3 = (string)(long)intPtr4;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							AndroidJavaObject androidJavaObject = default(AndroidJavaObject);
							if ((uint)((ulong)(long)(IntPtr)androidJavaObject & 1uL) != 0)
							{
								string text5 = androidJavaObject.CallStatic<string>(text3, args);
								if (intPtr4 != (IntPtr)0)
								{
									intPtr2 = intPtr4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+180] (should have been resolved before IL gen)");
									string text6 = default(string);
									string message2 = "[ValidateViaTimezone]. Error: " + text6;
									Debug.Log(message2);
									goto IL_0193;
								}
							}
							else
							{
								string text7 = ((AndroidJavaObject)8).CallStatic<string>((string)(long)intPtr4, args);
								text7 = text4;
								text3 = (string)(32022528 + 2160);
								string text8 = ((AndroidJavaObject)(object)text7).CallStatic<string>(text3, (object[])null);
							}
							NullReferenceException ex3 = new NullReferenceException();
							string text9 = ((AndroidJavaObject)(object)ex3).CallStatic<string>(text3, (object[])null);
							ex2 = ex3;
						}
						string text10 = ((AndroidJavaObject)(object)ex2).CallStatic<string>(text3, (object[])null);
						return (EEARegionStatus)((AndroidJavaObject)(object)text10).CallStatic<string>(text3, (object[])null);
					}
					intPtr2 = (IntPtr)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v270 @ X8_v13 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+160] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string value3 = default(string);
					if (!text.Equals(value3))
					{
						string message3 = "[ValidateViaTimezone]. Error: unexpected native response: " + text;
						Debug.Log(message3);
					}
				}
				else
				{
					Debug.Log("[ValidateViaTimezone]. Error: native response is null.");
				}
			}
			goto IL_0193;
			IL_0193:
			return default(EEARegionStatus);
		}
	}
}
