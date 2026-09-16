using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public class AppsFlyer : MonoBehaviour
{
	[Token(Token = "0x2000005")]
	public enum EmailCryptType
	{
		[Token(Token = "0x4000047")]
		EmailCryptTypeNone = 0,
		[Token(Token = "0x4000048")]
		EmailCryptTypeSHA1 = 1,
		[Token(Token = "0x4000049")]
		EmailCryptTypeMD5 = 2,
		[Token(Token = "0x400004A")]
		EmailCryptTypeSHA256 = 3
	}

	[Token(Token = "0x400003E")]
	private static AndroidJavaClass obj;

	[Token(Token = "0x400003F")]
	private static AndroidJavaObject cls_AppsFlyer;

	[Token(Token = "0x4000040")]
	private static AndroidJavaClass propertiesClass;

	[Token(Token = "0x4000041")]
	private static AndroidJavaClass cls_AppsFlyerHelper;

	[Token(Token = "0x4000042")]
	private static string devKey;

	[Token(Token = "0x4000043")]
	private static AndroidJavaClass cls_UnityShareHelper;

	[Token(Token = "0x4000044")]
	private static AndroidJavaObject ShareHelperInstance;

	[Token(Token = "0x4000045")]
	private static AndroidJavaClass cls_AndroidShare;

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x1661FC4", Offset = "0x1661FC4", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv19 = *([1EFD798]);\n\tv20 = *([v19 @ X8_v4]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([202AF6E]) = v39;\nL_0016:\n\tv42 = 0x16677D4(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0022;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0022;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X20]);\nL_0022:\n\tX9 = 0x1EFE000;\n\tX8 = *([X0+B8]);\n\tX9 = *([1EFE3C0]);\n\tX1 = 0 | 1;\n\tX20 = *([X8+8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0048;\n\tif (TEMP) goto L_0034;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_004D;\nL_0034:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_0049;\n\t*([X21+20]) = X19;\n\tif (TEMP) goto L_004B;\n\tX8 = *([1EB6F60]);\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = *([X8]);\n\tX2 = X21;\n\tX3 = 0;\n\tX21 = stack[0];\n\t// 69 ShiftStack 48\n\tUnityEngine.AndroidJavaObject::Call(X0, X1, X2, X3);\n\treturn;\nL_0048:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0049:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_004E;\nL_004B:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004D:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004E:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setCurrencyCode(string currencyCode)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16677D4 (inside AppsFlyerTrackerCallbacks::.ctor +0xC)");
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x16620B8", Offset = "0x16620B8", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECC6E0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF6F]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = customerUserID == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), customerUserID @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = customerUserID;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setCustomerUserId\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setCustomerUserID(string customerUserID)
	{
		object[] array = new object[1];
		if (customerUserID != null)
		{
			object obj = customerUserID as object;
		}
		if (array.Length != 0)
		{
			array[0] = customerUserID;
			cls_AppsFlyer.Call("setCustomerUserId", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x16621AC", Offset = "0x16621AC", Length = "0x324")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F03F10]);\n\tv25 = *([v24 @ X8_v42]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF70]) = v44;\nL_0019:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.unity3d.player.UnityPlayer\");\n\tv62 = UnityEngine.AndroidJavaObject::GetStatic(v48, \"currentActivity\");\n\tgoto L_003E;\n\tv91 = *([v68 @ X0_v43 (Il2CppClass<AppsFlyer>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_003E;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v68, v59, v60, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv95 = AppsFlyer;\nL_003E:\n\t// 62 NewArr v84 @ X0_v46 (System.Object[]), typeof(System.Object[]), 2\n\tv118 = v62 == 0;\n\tif (v118) goto L_004A;\n\t// 71 IsInst v187 @ X0_v60, typeof(System.Object), v62 @ X0_v42 (UnityEngine.AndroidJavaObject)\n\tv189 = v187 == 0;\n\tif (v189) goto L_00FF;\nL_004A:\n\tv227 = v84.Length;\n\tv110 = v84.Length == 0;\n\tif (v110) goto L_00F1;\n\tv84[0] = v62;\n\tv229 = callbackObject == 0;\n\tif (v229) goto L_0057;\n\t// 83 IsInst v285 @ X0_v58, typeof(System.Object), callbackObject @ X0 (System.String)\n\tv286 = v285 == 0;\n\tif (v286) goto L_0103;\n\tv227 = v84.Length;\nL_0057:\n\tv288 = v227 < 1;\n\tv210 = ~v288;\n\tv208 = v227 - 1;\n\tv204 = v208 == 0;\n\tv289 = ~v210;\n\tv194 = v289 | v204;\n\tif (v194) goto L_00F9;\n\tv84[1] = callbackObject;\n\tUnityEngine.AndroidJavaObject::CallStatic(v88.cls_AppsFlyerHelper, \"createConversionDataListener\", v84);\n\tv332 = v62 == 0;\n\tif (v332) goto L_FFFFFFFF;\nL_0077:\n\tgoto L_009E;\n\tv411 = *([v381 @ X8_v32+B0]);\n\tv412 = 0;\n\tv413 = v411 + 8;\n\tv415 = *([v457 @ X11_v20-8]);\n\tv463 = v415 == v384;\n\tif (v463) goto L_0097;\n\tv437 = v458 + 1;\n\tv536 = v437 < v383;\n\tv433 = ~v536;\n\tv435 = v457 + 0x10;\n\tv417 = ~v433;\n\tif (v417) goto L_FFFFFFFF;\n\tv438 = v65;\n\tv439 = 0;\n\tv440 = 0x8909C4(v438, v384, v439, v326, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_009E;\nL_0097:\n\tv537 = *([v457 @ X11_v20]);\n\tv538 = v537 << 4;\n\tv539 = v381 + v538;\n\tv540 = v539 + 0x130;\nL_009E:\n\tSystem.IDisposable::Dispose(v62);\n\tgoto L_00AA;\n\tgoto L_010A;\nL_00AA:\n\tv445 = v48 == 0;\n\tif (v445) goto L_00DA;\nL_00B2:\n\tgoto L_00D9;\n\tv544 = *([v505 @ X8_v17+B0]);\n\tv545 = 0;\n\tv546 = v544 + 8;\n\tv548 = *([v595 @ X11_v13-8]);\n\tv601 = v548 == v508;\n\tif (v601) goto L_00D2;\n\tv570 = v596 + 1;\n\tv633 = v570 < v507;\n\tv566 = ~v633;\n\tv568 = v595 + 0x10;\n\tv550 = ~v566;\n\tif (v550) goto L_FFFFFFFF;\n\tv571 = v52;\n\tv572 = 0;\n\tv573 = 0x8909C4(v571, v508, v572, v490, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00D9;\nL_00D2:\n\tv634 = *([v595 @ X11_v13]);\n\tv635 = v634 << 4;\n\tv636 = v505 + v635;\n\tv637 = v636 + 0x130;\nL_00D9:\n\tSystem.IDisposable::Dispose(v48);\nL_00DA:\n\tv534 = v163 + 1;\n\tv142 = v534 == 0;\n\tv127 = ~v142;\n\tif (v127) goto L_00EC;\n\tv574 = v177 == 0;\n\tv175 = ~v574;\n\tif (v175) goto L_00F8;\nL_00EC:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv90 = new System.NullReferenceException();\nL_00F1:\n\tv113 = new System.IndexOutOfRangeException();\n\tthrow v113;\nL_00F8:\n\tv183 = new System.TypeLoadException();\nL_00F9:\n\tv228 = new System.IndexOutOfRangeException();\n\tthrow v228;\n\tv274 = new System.NullReferenceException();\nL_00FF:\n\tv281 = new System.ArrayTypeMismatchException();\n\tthrow v281;\nL_0103:\n\tv320 = new System.ArrayTypeMismatchException();\n\tthrow v320;\nL_010A:\n\tv379 = new System.TypeLoadException();\n\tgoto L_012F;\n\tgoto L_0111;\n\tgoto L_0111;\n\tgoto L_0111;\n\t// 271 Jump @b64\n\tgoto L_012F;\nL_0111:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 283 ConditionalJump @b64, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0077;\n\tgoto L_FFFFFFFF;\nL_012F:\n\tgoto L_0137;\n\tv583 = 0x6D2BC0(v379, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv501 = *([v583 @ X0_v9]);\n\tv498 = 0x6D2490(v583, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv641 = v48 == 0;\n\tv500 = ~v641;\n\tif (v500) goto L_00B2;\n\tgoto L_00DA;\nL_0137:\n\tv584 = 0x6D2380(v379, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void loadConversionData(string callbackObject)
	{
		//IL_006d: Expected O, but got I4
		//IL_0298: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[2];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			if (callbackObject != null)
			{
				object obj3 = callbackObject as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = callbackObject;
				cls_AppsFlyerHelper.CallStatic("createConversionDataListener", array);
				((IDisposable)androidJavaObject)?.Dispose();
				int num = 0;
				bool flag5 = androidJavaClass == null;
				int num2 = 0;
				int num3 = num;
				int num4 = 0;
				if (!flag5)
				{
					((IDisposable)androidJavaClass).Dispose();
					num3 = num;
					num4 = num2;
				}
				if (num3 + 1 != 0 || num4 == 0)
				{
					return;
				}
				TypeLoadException ex3 = new TypeLoadException();
			}
			IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
			throw ex4;
		}
		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
		throw ex5;
	}

	[Obsolete]
	[Token(Token = "0x6000005")]
	[Address(RVA = "0x16624D0", Offset = "0x16624D0", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAB758]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callbackMethod, callbackFailedMethod, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF71]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, callbackMethod, callbackFailedMethod, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tAppsFlyer::loadConversionData(callbackObject);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void loadConversionData(string callbackObject, string callbackMethod, string callbackFailedMethod)
	{
		loadConversionData(callbackObject);
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x1662534", Offset = "0x1662534", Length = "0x110")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA7B38]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF72]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &shouldCollect @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setCollectIMEI\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setCollectIMEI(bool shouldCollect)
	{
		object[] array = new object[1];
		array = (object[])(object)shouldCollect;
		if (array != null)
		{
			array = (object[])(array as object);
		}
		if (array.Length != 0)
		{
			array[0] = array;
			cls_AppsFlyer.Call("setCollectIMEI", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x1662644", Offset = "0x1662644", Length = "0x124")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EFABB8]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF73]) = v40;\nL_0018:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs setCollectAndroidID\");\n\tgoto L_002C;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002C;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = AppsFlyer;\nL_002C:\n\t// 44 NewArr v64 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\t// 51 Box v64 @ X0_v6 (System.Object[]), typeof(System.Boolean), &shouldCollect @ X0 (System.Boolean)\n\tv75 = v64 == 0;\n\tif (v75) goto L_0040;\n\t// 60 IsInst v64 @ X0_v6 (System.Object[]), typeof(System.Object), v64 @ X0_v6 (System.Object[])\nL_0040:\n\tv93 = v64.Length == 0;\n\tif (v93) goto L_0055;\n\tv64[0] = v64;\n\tUnityEngine.AndroidJavaObject::Call(v59.cls_AppsFlyer, \"setCollectAndroidID\", v64);\n\treturn;\n\tv85 = new System.NullReferenceException();\nL_0055:\n\tv98 = new System.IndexOutOfRangeException();\n\tgoto L_005A;\n\tv99 = new System.ArrayTypeMismatchException();\nL_005A:\n\tthrow v107;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setCollectAndroidID(bool shouldCollect)
	{
		MonoBehaviour.print("AF.cs setCollectAndroidID");
		object[] array = new object[1];
		array = (object[])(object)shouldCollect;
		if (array != null)
		{
			array = (object[])(array as object);
		}
		if (array.Length != 0)
		{
			array[0] = array;
			cls_AppsFlyer.Call("setCollectAndroidID", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x1662768", Offset = "0x1662768", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F08A00]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callbackObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AF74]) = v41;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callbackObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tAppsFlyer::init(key);\n\tv56 = callbackObject == 0;\n\tif (v56) goto L_003E;\n\tgoto L_0036;\n\tv66 = *([v57 @ X0_v5+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0036;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v57, callbackObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0036:\n\tAppsFlyer::loadConversionData(callbackObject);\n\treturn;\nL_003E:\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void init(string key, string callbackObject)
	{
		init(key);
		if (callbackObject != null)
		{
			loadConversionData(callbackObject);
		}
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x166280C", Offset = "0x166280C", Length = "0x310")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF3D18]);\n\tv23 = *([v22 @ X8_v44]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202AF75]) = v42;\nL_0019:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs init\");\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v49, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv57 = AppsFlyer;\nL_0028:\n\tv60.devKey = key;\n\tv64 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v64, \"com.unity3d.player.UnityPlayer\");\n\tv79 = UnityEngine.AndroidJavaObject::GetStatic(v64, \"currentActivity\");\n\t// 66 NewArr v87 @ X0_v41 (System.Object[]), typeof(System.Object[]), 1\n\tv156 = new UnityEngine.AndroidJavaRunnable();\n\tUnityEngine.AndroidJavaRunnable::.ctor(v156, 0, Il2CppMethodInfo);\n\tv221 = v156 == 0;\n\tif (v221) goto L_005B;\n\t// 87 IsInst v251 @ X0_v54, typeof(System.Object), v156 @ X0_v43 (UnityEngine.AndroidJavaRunnable)\n\tv253 = v251 == 0;\n\tif (v253) goto L_00F2;\nL_005B:\n\tv213 = v87.Length == 0;\n\tif (v213) goto L_00EC;\n\tv87[0] = v156;\n\tUnityEngine.AndroidJavaObject::Call(v79, \"runOnUiThread\", v87);\nL_006F:\n\tgoto L_0096;\n\tv343 = *([v337 @ X8_v36+B0]);\n\tv344 = 0;\n\tv345 = v343 + 8;\n\tv347 = *([v394 @ X11_v19-8]);\n\tv399 = v347 == v340;\n\tif (v399) goto L_008F;\n\tv367 = v393 + 1;\n\tv406 = v367 < v339;\n\tv365 = ~v406;\n\tv369 = v394 + 0x10;\n\tv349 = ~v365;\n\tif (v349) goto L_FFFFFFFF;\n\tv370 = v82;\n\tv371 = 0;\n\tv372 = 0x8909C4(v370, v340, v371, v287, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0096;\nL_008F:\n\tv407 = *([v394 @ X11_v19]);\n\tv408 = v407 << 4;\n\tv409 = v337 + v408;\n\tv410 = v409 + 0x130;\nL_0096:\n\tSystem.IDisposable::Dispose(v79);\n\tgoto L_00A2;\nL_00A0:\n\tgoto L_00F9;\nL_00A2:\n\tv426 = v64 == 0;\n\tif (v426) goto L_00D2;\nL_00AA:\n\tgoto L_00D1;\n\tv516 = *([v486 @ X8_v20+B0]);\n\tv517 = 0;\n\tv518 = v516 + 8;\n\tv520 = *([v558 @ X11_v13-8]);\n\tv563 = v520 == v489;\n\tif (v563) goto L_00CA;\n\tv540 = v557 + 1;\n\tv568 = v540 < v488;\n\tv538 = ~v568;\n\tv542 = v558 + 0x10;\n\tv522 = ~v538;\n\tif (v522) goto L_FFFFFFFF;\n\tv543 = v69;\n\tv544 = 0;\n\tv545 = 0x8909C4(v543, v489, v544, v475, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00D1;\nL_00CA:\n\tv569 = *([v558 @ X11_v13]);\n\tv570 = v569 << 4;\n\tv571 = v486 + v570;\n\tv572 = v571 + 0x130;\nL_00D1:\n\tSystem.IDisposable::Dispose(v64);\nL_00D2:\n\tv515 = v130 + 1;\n\tv111 = v515 == 0;\n\tv96 = ~v111;\n\tif (v96) goto L_00E3;\n\tv546 = v132 == 0;\n\tv143 = ~v546;\n\tif (v143) goto L_00E9;\nL_00E3:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00E9:\n\tthrow System.TypeLoadException;\n\tv188 = new System.NullReferenceException();\nL_00EC:\n\tv217 = new System.IndexOutOfRangeException();\n\tthrow v217;\n\tv247 = new System.NullReferenceException();\nL_00F2:\n\tv278 = new System.ArrayTypeMismatchException();\n\tthrow v278;\nL_00F9:\n\tv335 = new System.TypeLoadException();\n\tgoto L_011C;\n\tgoto L_00FF;\n\tgoto L_00FF;\n\t// 253 Jump @b57\n\tgoto L_011C;\nL_00FF:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 265 ConditionalJump @b57, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00A0;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_006F;\nL_011C:\n\tgoto L_0124;\n\tv404 = 0x6D2BC0(v335, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv477 = *([v404 @ X0_v12]);\n\tv421 = 0x6D2490(v404, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv427 = v64 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_00AA;\n\tgoto L_00D2;\nL_0124:\n\tv405 = 0x6D2380(v335, 0, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void init(string key)
	{
		MonoBehaviour.print("AF.cs init");
		devKey = key;
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[1];
		AndroidJavaRunnable androidJavaRunnable = init_cb;
		if (androidJavaRunnable != null)
		{
			object obj = androidJavaRunnable as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaRunnable;
			androidJavaObject.Call("runOnUiThread", array);
			((IDisposable)androidJavaObject).Dispose();
			int num = 0;
			bool flag = androidJavaClass == null;
			int num2 = 0;
			int num3 = num;
			int num4 = 0;
			if (!flag)
			{
				((IDisposable)androidJavaClass).Dispose();
				num3 = num;
				num4 = num2;
			}
			if (num3 + 1 != 0 || num4 == 0)
			{
				return;
			}
			throw new TypeLoadException();
		}
		IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		throw ex2;
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x1662B1C", Offset = "0x1662B1C", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EFFEC0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF76]) = v35;\nL_0015:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs start tracking\");\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v38, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0026:\n\tAppsFlyer::trackAppLaunch();\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void init_cb()
	{
		MonoBehaviour.print("AF.cs start tracking");
		trackAppLaunch();
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x1663084", Offset = "0x1663084", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = *([1EB4630]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF77]) = v35;\nL_0019:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs setAppsFlyerKey\");\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setAppsFlyerKey(string key)
	{
		MonoBehaviour.print("AF.cs setAppsFlyerKey");
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0x1662B8C", Offset = "0x1662B8C", Length = "0x4F8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED8580]);\n\tv27 = *([v26 @ X8_v74]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202AF78]) = v47;\nL_001B:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs trackAppLaunch\");\n\tv55 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v55, \"com.unity3d.player.UnityPlayer\");\n\tv69 = UnityEngine.AndroidJavaObject::GetStatic(v55, \"currentActivity\");\n\tv77 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003E;\n\tv98 = v77;\n\tv99 = UnityEngine.AndroidJavaObject::GetStatic(v98, v66, v67);\n\tv102 = *([v77 @ X21_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003E:\n\tv103 = *([v77 @ X21_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv104 = v103 == 0;\n\tif (v104) goto L_005F;\n\tv136 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004B;\n\tv175 = v136;\n\tv176 = UnityEngine.AndroidJavaObject::GetStatic(v175, v66, v67);\nL_004B:\n\tv177 = *([v136 @ X21_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv148 = ~v177;\n\tif (v148) goto L_005F;\n\tgoto L_005F;\n\tv240 = v142;\n\tv241 = UnityEngine.AndroidJavaObject::GetStatic(v240, v66, v67);\nL_005F:\n\tgoto L_006D;\n\tv178 = v83;\n\tv179 = UnityEngine.AndroidJavaObject::GetStatic(v178, v66, v67);\nL_006D:\n\tv191 = UnityEngine.AndroidJavaObject::Call(v69, \"getApplication\", v187.Value);\n\tgoto L_0082;\n\tv252 = *([v245 @ X0_v70 (Il2CppClass<AppsFlyer>)+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tif (v254) goto L_0082;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v245, v189, v126, v112, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv256 = AppsFlyer;\nL_0082:\n\t// 130 NewArr v128 @ X0_v73 (System.Object[]), typeof(System.Object[]), 2\n\tv347 = v191 == 0;\n\tif (v347) goto L_008E;\n\t// 139 IsInst v387 @ X0_v94, typeof(System.Object), v191 @ X0_v69 (UnityEngine.AndroidJavaObject)\n\tv389 = v387 == 0;\n\tif (v389) goto L_018D;\nL_008E:\n\tv238 = v128.Length;\n\tv171 = v128.Length == 0;\n\tif (v171) goto L_016F;\n\tv128[0] = v191;\n\tv423 = v229.devKey == 0;\n\tif (v423) goto L_009E;\n\t// 154 IsInst v483 @ X0_v92, typeof(System.Object), v229.devKey (System.String)\n\tv484 = v483 == 0;\n\tif (v484) goto L_0191;\n\tv238 = v128.Length;\nL_009E:\n\tv486 = v238 < 1;\n\tv219 = ~v486;\n\tv216 = v238 - 1;\n\tv210 = v216 == 0;\n\tv487 = ~v219;\n\tv195 = v487 | v210;\n\tif (v195) goto L_0173;\n\tv128[1] = v229.devKey;\n\tUnityEngine.AndroidJavaObject::Call(v132.cls_AppsFlyer, \"startTracking\", v128);\n\t// 185 NewArr v377 @ X0_v78 (System.Object[]), typeof(System.Object[]), 2\n\t// 192 IsInst v416 @ X0_v80, typeof(System.Object), v69 @ X0_v64 (UnityEngine.AndroidJavaObject)\n\tv418 = v416 == 0;\n\tif (v418) goto L_017F;\n\tv594 = v377.Length;\n\tv513 = v377.Length == 0;\n\tif (v513) goto L_0183;\n\tv377[0] = v69;\n\tv696 = v585.devKey == 0;\n\tif (v696) goto L_00D3;\n\t// 207 IsInst v629 @ X0_v90, typeof(System.Object), v585.devKey (System.String)\n\tv631 = v629 == 0;\n\tif (v631) goto L_0195;\n\tv594 = v377.Length;\nL_00D3:\n\tv709 = v594 < 1;\n\tv574 = ~v709;\n\tv572 = v594 - 1;\n\tv568 = v572 == 0;\n\tv710 = ~v574;\n\tv558 = v710 | v568;\n\tif (v558) goto L_0187;\n\tv377[1] = v585.devKey;\n\tUnityEngine.AndroidJavaObject::Call(v381.cls_AppsFlyer, \"trackAppLaunch\", v377);\nL_00F1:\n\tgoto L_0118;\n\tv856 = *([v796 @ X8_v56+B0]);\n\tv857 = 0;\n\tv858 = v856 + 8;\n\tv860 = *([v918 @ X11_v23-8]);\n\tv924 = v860 == v799;\n\tif (v924) goto L_0111;\n\tv882 = v919 + 1;\n\tv937 = v882 < v798;\n\tv878 = ~v937;\n\tv880 = v918 + 0x10;\n\tv862 = ~v878;\n\tif (v862) goto L_FFFFFFFF;\n\tv883 = v72;\n\tv884 = 0;\n\tv885 = 0x8909C4(v883, v799, v884, v670, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0118;\nL_0111:\n\tv938 = *([v918 @ X11_v23]);\n\tv939 = v938 << 4;\n\tv940 = v796 + v939;\n\tv941 = v940 + 0x130;\nL_0118:\n\tSystem.IDisposable::Dispose(v69);\n\tgoto L_0124;\nL_0122:\n\tgoto L_019C;\nL_0124:\n\tv787 = v55 == 0;\n\tif (v787) goto L_0154;\nL_012C:\n\tgoto L_0153;\n\tv826 = *([v790 @ X8_v26+B0]);\n\tv827 = 0;\n\tv828 = v826 + 8;\n\tv830 = *([v897 @ X11_v17-8]);\n\tv903 = v830 == v793;\n\tif (v903) goto L_014C;\n\tv852 = v898 + 1;\n\tv929 = v852 < v792;\n\tv848 = ~v929;\n\tv850 = v897 + 0x10;\n\tv832 = ~v848;\n\tif (v832) goto L_FFFFFFFF;\n\tv853 = v59;\n\tv854 = 0;\n\tv855 = 0x8909C4(v853, v793, v854, v776, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0153;\nL_014C:\n\tv930 = *([v897 @ X11_v17]);\n\tv931 = v930 << 4;\n\tv932 = v790 + v931;\n\tv933 = v932 + 0x130;\nL_0153:\n\tSystem.IDisposable::Dispose(v55);\nL_0154:\n\tv825 = v328 + 1;\n\tv307 = v825 == 0;\n\tv297 = ~v307;\n\tif (v297) goto L_0168;\n\tv886 = v326 == 0;\n\tv340 = ~v886;\n\tif (v340) goto L_017C;\nL_0168:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv134 = new System.NullReferenceException();\nL_016F:\n\tv174 = new System.IndexOutOfRangeException();\n\tthrow v174;\nL_0173:\n\tv239 = new System.IndexOutOfRangeException();\n\tthrow v239;\n\tthrow System.NullReferenceException;\nL_017C:\n\tthrow System.TypeLoadException;\n\tv383 = new System.NullReferenceException();\nL_017F:\n\tv421 = new System.ArrayTypeMismatchException();\n\tthrow v421;\nL_0183:\n\tv516 = new System.IndexOutOfRangeException();\n\tthrow v516;\nL_0187:\n\tv595 = new System.IndexOutOfRangeException();\n\tthrow v595;\n\tv474 = new System.NullReferenceException();\nL_018D:\n\tv479 = new System.ArrayTypeMismatchException();\n\tthrow v479;\nL_0191:\n\tv549 = new System.ArrayTypeMismatchException();\n\tthrow v549;\nL_0195:\n\tv634 = new System.ArrayTypeMismatchException();\n\tthrow v634;\nL_019C:\n\tv693 = new System.TypeLoadException();\n\tgoto L_01BA;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01A7;\n\tgoto L_01BA;\n\tgoto L_01A7;\n\tgoto L_01A7;\nL_01A7:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01BA;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0122;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_00F1;\nL_01BA:\n\tgoto L_01C5;\nL_01C5:\n\tgoto L_01CD;\n\tv711 = UnityEngine.AndroidJavaObject::Call(v693, 0, 0);\n\tv778 = *([v711 @ X0_v10 (UnityEngine.AndroidJavaObject)]);\n\tv714 = UnityEngine.AndroidJavaObject::Call(v711, 0, 0);\n\tv720 = v55 == 0;\n\tv721 = ~v720;\n\tif (v721) goto L_012C;\n\tgoto L_0154;\nL_01CD:\n\tv712 = UnityEngine.AndroidJavaObject::Call(v693, 0, 0);\n\treturn;\n// 259 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void trackAppLaunch()
	{
		//IL_00d5: Expected O, but got I4
		//IL_0469: Expected O, but got I
		//IL_015a: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_04c7: Expected O, but got I
		//IL_0256: Expected O, but got I4
		//IL_0580: Expected I, but got O
		//IL_0585: Expected I, but got O
		MonoBehaviour.print("AF.cs trackAppLaunch");
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X21_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X21_v26 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
		object[] array = new object[2];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			if (devKey != null)
			{
				object obj3 = devKey as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = devKey;
				cls_AppsFlyer.Call("startTracking", array);
				object[] array2 = new object[2];
				object obj5 = androidJavaObject as object;
				if (obj5 != null)
				{
					object obj6 = array2.Length;
					if (array2.Length != 0)
					{
						array2[0] = androidJavaObject;
						if (devKey != null)
						{
							object obj7 = devKey as object;
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
							obj6 = array2.Length;
						}
						bool flag5 = (long)(IntPtr)obj6 < 1L;
						bool flag6 = !flag5;
						object obj8 = (long)(IntPtr)obj6 - 1L;
						bool flag7 = obj8 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array2[1] = devKey;
							cls_AppsFlyer.Call("trackAppLaunch", array2);
							((IDisposable)androidJavaObject).Dispose();
							int num = 0;
							bool flag9 = androidJavaClass == null;
							IntPtr intPtr3 = (IntPtr)null;
							IntPtr intPtr4 = (IntPtr)null;
							int num2 = num;
							if (!flag9)
							{
								((IDisposable)androidJavaClass).Dispose();
								intPtr4 = intPtr3;
								num2 = num;
							}
							if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
							{
								return;
							}
							throw new TypeLoadException();
						}
						IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
						throw ex4;
					}
					IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
					throw ex5;
				}
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
			IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
			throw ex7;
		}
		IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
		throw ex8;
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0x16630D0", Offset = "0x16630D0", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE7570]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF79]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = packageName == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), packageName @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = packageName;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setAppId\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setAppID(string packageName)
	{
		object[] array = new object[1];
		if (packageName != null)
		{
			object obj = packageName as object;
		}
		if (array.Length != 0)
		{
			array[0] = packageName;
			cls_AppsFlyer.Call("setAppId", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0x16631C4", Offset = "0x16631C4", Length = "0x3E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EE27A0]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, callbackMethod, callbackFailedMethod, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202AF7A]) = v50;\nL_001E:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs createValidateInAppListener called\");\n\tv58 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v58, \"com.unity3d.player.UnityPlayer\");\n\tv72 = UnityEngine.AndroidJavaObject::GetStatic(v58, \"currentActivity\");\n\tgoto L_0047;\n\tv101 = *([v78 @ X0_v56 (Il2CppClass<AppsFlyer>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0047;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v78, v69, v70, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv105 = AppsFlyer;\nL_0047:\n\t// 71 NewArr v94 @ X0_v59 (System.Object[]), typeof(System.Object[]), 4\n\tv128 = v72 == 0;\n\tif (v128) goto L_0053;\n\t// 80 IsInst v173 @ X0_v79, typeof(System.Object), v72 @ X0_v55 (UnityEngine.AndroidJavaObject)\n\tv175 = v173 == 0;\n\tif (v175) goto L_013E;\nL_0053:\n\tv415 = v94.Length;\n\tv120 = v94.Length == 0;\n\tif (v120) goto L_0128;\n\tv94[0] = v72;\n\tv180 = aObject == 0;\n\tif (v180) goto L_0060;\n\t// 92 IsInst v293 @ X0_v77, typeof(System.Object), aObject @ X0 (System.String)\n\tv294 = v293 == 0;\n\tif (v294) goto L_0142;\n\tv415 = v94.Length;\nL_0060:\n\tv296 = v415 < 1;\n\tv155 = ~v296;\n\tv152 = v415 - 1;\n\tv146 = v152 == 0;\n\tv297 = ~v155;\n\tv131 = v297 | v146;\n\tif (v131) goto L_012C;\n\tv94[1] = aObject;\n\tv340 = callbackMethod == 0;\n\tif (v340) goto L_0076;\n\t// 114 IsInst v373 @ X0_v75, typeof(System.Object), callbackMethod @ X1 (System.String)\n\tv374 = v373 == 0;\n\tif (v374) goto L_0146;\n\tv415 = v94.Length;\nL_0076:\n\tv376 = v415 < 2;\n\tv317 = ~v376;\n\tv315 = v415 - 2;\n\tv311 = v315 == 0;\n\tv377 = ~v317;\n\tv301 = v377 | v311;\n\tif (v301) goto L_0134;\n\tv94[2] = callbackMethod;\n\tv420 = callbackFailedMethod == 0;\n\tif (v420) goto L_008C;\n\t// 136 IsInst v453 @ X0_v73, typeof(System.Object), callbackFailedMethod @ X2 (System.String)\n\tv454 = v453 == 0;\n\tif (v454) goto L_014A;\n\tv415 = v94.Length;\nL_008C:\n\tv456 = v415 < 3;\n\tv397 = ~v456;\n\tv395 = v415 - 3;\n\tv391 = v395 == 0;\n\tv457 = ~v397;\n\tv381 = v457 | v391;\n\tif (v381) goto L_0138;\n\tv94[3] = callbackFailedMethod;\n\tUnityEngine.AndroidJavaObject::CallStatic(v98.cls_AppsFlyerHelper, \"createValidateInAppListener\", v94);\n\tv501 = v72 == 0;\n\tif (v501) goto L_FFFFFFFF;\nL_00AC:\n\tgoto L_00D3;\n\tv581 = *([v551 @ X8_v40+B0]);\n\tv582 = 0;\n\tv583 = v581 + 8;\n\tv585 = *([v627 @ X11_v23-8]);\n\tv633 = v585 == v554;\n\tif (v633) goto L_00CC;\n\tv607 = v628 + 1;\n\tv707 = v607 < v553;\n\tv603 = ~v707;\n\tv605 = v627 + 0x10;\n\tv587 = ~v603;\n\tif (v587) goto L_FFFFFFFF;\n\tv608 = v75;\n\tv609 = 0;\n\tv610 = 0x8909C4(v608, v554, v609, v495, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00D3;\nL_00CC:\n\tv708 = *([v627 @ X11_v23]);\n\tv709 = v708 << 4;\n\tv710 = v551 + v709;\n\tv711 = v710 + 0x130;\nL_00D3:\n\tSystem.IDisposable::Dispose(v72);\n\tgoto L_00DF;\n\tgoto L_0151;\nL_00DF:\n\tv615 = v58 == 0;\n\tif (v615) goto L_010F;\nL_00E7:\n\tgoto L_010E;\n\tv715 = *([v676 @ X8_v23+B0]);\n\tv716 = 0;\n\tv717 = v715 + 8;\n\tv719 = *([v768 @ X11_v16-8]);\n\tv774 = v719 == v679;\n\tif (v774) goto L_0107;\n\tv741 = v769 + 1;\n\tv808 = v741 < v678;\n\tv737 = ~v808;\n\tv739 = v768 + 0x10;\n\tv721 = ~v737;\n\tif (v721) goto L_FFFFFFFF;\n\tv742 = v62;\n\tv743 = 0;\n\tv744 = 0x8909C4(v742, v679, v743, v660, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_010E;\nL_0107:\n\tv809 = *([v768 @ X11_v16]);\n\tv810 = v809 << 4;\n\tv811 = v676 + v810;\n\tv812 = v811 + 0x130;\nL_010E:\n\tSystem.IDisposable::Dispose(v58);\nL_010F:\n\tv705 = v230 + 1;\n\tv198 = v705 == 0;\n\tv188 = ~v198;\n\tif (v188) goto L_0123;\n\tv745 = v232 == 0;\n\tv228 = ~v745;\n\tif (v228) goto L_0133;\nL_0123:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv100 = new System.NullReferenceException();\nL_0128:\n\tv123 = new System.IndexOutOfRangeException();\n\tthrow v123;\nL_012C:\n\tv169 = new System.IndexOutOfRangeException();\n\tthrow v169;\nL_0133:\n\tv238 = new System.TypeLoadException();\nL_0134:\n\tv336 = new System.IndexOutOfRangeException();\n\tthrow v336;\nL_0138:\n\tv416 = new System.IndexOutOfRangeException();\n\tthrow v416;\n\tv280 = new System.NullReferenceException();\nL_013E:\n\tv289 = new System.ArrayTypeMismatchException();\n\tthrow v289;\nL_0142:\n\tv369 = new System.ArrayTypeMismatchException();\n\tthrow v369;\nL_0146:\n\tv449 = new System.ArrayTypeMismatchException();\n\tthrow v449;\nL_014A:\n\tv489 = new System.ArrayTypeMismatchException();\n\tthrow v489;\nL_0151:\n\tv549 = new System.TypeLoadException();\n\tgoto L_0178;\n\tgoto L_015A;\n\tgoto L_015A;\n\tgoto L_015A;\n\tgoto L_015A;\n\tgoto L_015A;\n\t// 344 Jump @b83\n\tgoto L_0178;\nL_015A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 356 ConditionalJump @b83, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AC;\n\tgoto L_FFFFFFFF;\nL_0178:\n\tgoto L_0180;\n\tv756 = 0x6D2BC0(v549, 0, 0, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv672 = *([v756 @ X0_v10]);\n\tv668 = 0x6D2490(v756, 0, 0, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv816 = v58 == 0;\n\tv670 = ~v816;\n\tif (v670) goto L_00E7;\n\tgoto L_010F;\nL_0180:\n\tv757 = 0x6D2380(v549, 0, 0, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturn;\n// 202 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void createValidateInAppListener(string aObject, string callbackMethod, string callbackFailedMethod)
	{
		//IL_006d: Expected O, but got I4
		//IL_03aa: Expected O, but got I
		//IL_0408: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		//IL_0466: Expected O, but got I
		//IL_0157: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		MonoBehaviour.print("AF.cs createValidateInAppListener called");
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[4];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			if (aObject != null)
			{
				object obj3 = aObject as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = aObject;
				if (callbackMethod != null)
				{
					object obj5 = callbackMethod as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = callbackMethod;
					if (callbackFailedMethod != null)
					{
						object obj7 = callbackFailedMethod as object;
						if (obj7 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
						obj2 = array.Length;
					}
					bool flag9 = (long)(IntPtr)obj2 < 3L;
					bool flag10 = !flag9;
					object obj8 = (long)(IntPtr)obj2 - 3L;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (flag12 || flag11)
					{
						IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
						throw ex5;
					}
					array[3] = callbackFailedMethod;
					cls_AppsFlyerHelper.CallStatic("createValidateInAppListener", array);
					((IDisposable)androidJavaObject)?.Dispose();
					int num = 0;
					bool flag13 = androidJavaClass == null;
					int num2 = 0;
					int num3 = num;
					int num4 = 0;
					if (!flag13)
					{
						((IDisposable)androidJavaClass).Dispose();
						num3 = num;
						num4 = num2;
					}
					if (num3 + 1 != 0 || num4 == 0)
					{
						return;
					}
					TypeLoadException ex6 = new TypeLoadException();
				}
				IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
				throw ex7;
			}
			IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
			throw ex8;
		}
		IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
		throw ex9;
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0x16635A4", Offset = "0x16635A4", Length = "0x660")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv44 = *([1EB1A80]);\n\tv45 = *([v44 @ X8_v99]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, purchaseData, signature, price, currency, extraParams, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([202AF7B]) = v59;\nL_0024:\n\t// 36 NewArr v64 @ X0_v3 (System.String[]), typeof(System.String[]), 6\n\tv70 = \"AF.cs validateReceipt pk = \" == 0;\n\tif (v70) goto L_0032;\n\t// 47 IsInst v74 @ X0_v143, typeof(System.String), \"AF.cs validateReceipt pk = \"\n\tv78 = v74 == 0;\n\tif (v78) goto L_0212;\nL_0032:\n\tv202 = v64.Length;\n\tv81 = v64.Length == 0;\n\tif (v81) goto L_0210;\n\tv64[0] = \"AF.cs validateReceipt pk = \";\n\tv129 = publicKey == 0;\n\tif (v129) goto L_0040;\n\t// 60 IsInst v254 @ X0_v142, typeof(System.String), publicKey @ X0 (System.String)\n\tv260 = v254 == 0;\n\tif (v260) goto L_0212;\n\tv202 = v64.Length;\nL_0040:\n\tv274 = v202 < 1;\n\tv171 = ~v274;\n\tv166 = v202 - 1;\n\tv156 = v166 == 0;\n\tv275 = ~v171;\n\tv131 = v275 | v156;\n\tif (v131) goto L_0210;\n\tv64[1] = publicKey;\n\tv303 = \" data = \" == 0;\n\tif (v303) goto L_0058;\n\t// 84 IsInst v255 @ X0_v140, typeof(System.String), \" data = \"\n\tv261 = v255 == 0;\n\tif (v261) goto L_0212;\n\tv202 = v64.Length;\nL_0058:\n\tv369 = v202 < 2;\n\tv172 = ~v369;\n\tv167 = v202 - 2;\n\tv157 = v167 == 0;\n\tv370 = ~v172;\n\tv132 = v370 | v157;\n\tif (v132) goto L_0210;\n\tv64[2] = \" data = \";\n\tv446 = purchaseData == 0;\n\tif (v446) goto L_006F;\n\t// 107 IsInst v256 @ X0_v139, typeof(System.String), purchaseData @ X1 (System.String)\n\tv262 = v256 == 0;\n\tif (v262) goto L_0212;\n\tv202 = v64.Length;\nL_006F:\n\tv455 = v202 < 3;\n\tv173 = ~v455;\n\tv168 = v202 - 3;\n\tv158 = v168 == 0;\n\tv456 = ~v173;\n\tv133 = v456 | v158;\n\tif (v133) goto L_0210;\n\tv64[3] = purchaseData;\n\tv534 = \"sig = \" == 0;\n\tif (v534) goto L_0087;\n\t// 131 IsInst v257 @ X0_v137, typeof(System.String), \"sig = \"\n\tv263 = v257 == 0;\n\tif (v263) goto L_0212;\n\tv202 = v64.Length;\nL_0087:\n\tv542 = v202 < 4;\n\tv174 = ~v542;\n\tv169 = v202 - 4;\n\tv159 = v169 == 0;\n\tv543 = ~v174;\n\tv134 = v543 | v159;\n\tif (v134) goto L_0210;\n\tv64[4] = \"sig = \";\n\tv613 = signature == 0;\n\tif (v613) goto L_009E;\n\t// 154 IsInst v258 @ X0_v136, typeof(System.String), signature @ X2 (System.String)\n\tv264 = v258 == 0;\n\tif (v264) goto L_0212;\n\tv202 = v64.Length;\nL_009E:\n\tv619 = v202 < 5;\n\tv108 = ~v619;\n\tv105 = v202 - 5;\n\tv99 = v105 == 0;\n\tv620 = ~v108;\n\tv84 = v620 | v99;\n\tif (v84) goto L_0210;\n\tv64[5] = signature;\n\tv664 = System.String::Concat(v64);\n\tUnityEngine.MonoBehaviour::print(v664);\n\tv119 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v119, \"com.unity3d.player.UnityPlayer\");\n\tv776 = UnityEngine.AndroidJavaObject::GetStatic(v119, \"currentActivity\");\n\tv780 = extraParams == 0;\n\tif (v780) goto L_00DA;\n\tgoto L_00D4;\n\tv833 = *([v815 @ X0_v130+E0]);\n\tv834 = v833 == 0;\n\tv835 = ~v834;\n\tif (v835) goto L_00D4;\n\tv837 = \"il2cpp_codegen_runtime_class_init\"(v815, v774, v218, price, currency, extraParams, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_00D4:\n\tv820 = AppsFlyer::ConvertHashMap(extraParams);\nL_00DA:\n\tUnityEngine.MonoBehaviour::print(\"inside cls_activity\");\n\tgoto L_00EE;\n\tv877 = *([v841 @ X0_v95 (Il2CppClass<AppsFlyer>)+E0]);\n\tv878 = v877 == 0;\n\tv879 = ~v878;\n\tgoto L_00EE;\n\tv889 = \"il2cpp_codegen_runtime_class_init\"(v841, v829, v218, price, currency, extraParams, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv881 = AppsFlyer;\nL_00EE:\n\t// 238 NewArr v226 @ X0_v98 (System.Object[]), typeof(System.Object[]), 7\n\tv922 = v776 == 0;\n\tif (v922) goto L_00FA;\n\t// 247 IsInst v724 @ X0_v127, typeof(System.Object), v776 @ X0_v92 (UnityEngine.AndroidJavaObject)\n\tv726 = v724 == 0;\n\tif (v726) goto L_023B;\nL_00FA:\n\tv659 = v226.Length;\n\tv295 = v226.Length == 0;\n\tif (v295) goto L_0219;\n\tv226[0] = v776;\n\tv961 = publicKey == 0;\n\tif (v961) goto L_0107;\n\t// 259 IsInst v760 @ X0_v125, typeof(System.Object), publicKey @ X0 (System.String)\n\tv762 = v760 == 0;\n\tif (v762) goto L_023F;\n\tv659 = v226.Length;\nL_0107:\n\tv967 = v659 < 1;\n\tv429 = ~v967;\n\tv427 = v659 - 1;\n\tv423 = v427 == 0;\n\tv968 = ~v429;\n\tv413 = v968 | v423;\n\tif (v413) goto L_021D;\n\tv226[1] = publicKey;\n\tv1001 = signature == 0;\n\tif (v1001) goto L_011D;\n\t// 281 IsInst v803 @ X0_v123, typeof(System.Object), signature @ X2 (System.String)\n\tv805 = v803 == 0;\n\tif (v805) goto L_0243;\n\tv659 = v226.Length;\nL_011D:\n\tv1007 = v659 < 2;\n\tv515 = ~v1007;\n\tv513 = v659 - 2;\n\tv509 = v513 == 0;\n\tv1008 = ~v515;\n\tv499 = v1008 | v509;\n\tif (v499) goto L_0221;\n\tv226[2] = signature;\n\tv1062 = purchaseData == 0;\n\tif (v1062) goto L_0133;\n\t// 303 IsInst v867 @ X0_v121, typeof(System.Object), purchaseData @ X1 (System.String)\n\tv869 = v867 == 0;\n\tif (v869) goto L_0247;\n\tv659 = v226.Length;\nL_0133:\n\tv1065 = v659 < 3;\n\tv390 = ~v1065;\n\tv388 = v659 - 3;\n\tv384 = v388 == 0;\n\tv1066 = ~v390;\n\tv374 = v1066 | v384;\n\tif (v374) goto L_0229;\n\tv226[3] = purchaseData;\n\tv1068 = v1035 == 0;\n\tif (v1068) goto L_0149;\n\t// 325 IsInst v912 @ X0_v119, typeof(System.Object), v1035 @ X3_v3 (System.String)\n\tv914 = v912 == 0;\n\tif (v914) goto L_024B;\n\tv659 = v226.Length;\nL_0149:\n\tv1081 = v659 < 4;\n\tv476 = ~v1081;\n\tv474 = v659 - 4;\n\tv470 = v474 == 0;\n\tv1082 = ~v476;\n\tv460 = v1082 | v470;\n\tif (v460) goto L_022D;\n\tv226[4] = v1035;\n\tv1085 = currency == 0;\n\tif (v1085) goto L_015F;\n\t// 347 IsInst v951 @ X0_v117, typeof(System.Object), currency @ X4 (System.String)\n\tv953 = v951 == 0;\n\tif (v953) goto L_024F;\n\tv659 = v226.Length;\nL_015F:\n\tv1090 = v659 < 5;\n\tv563 = ~v1090;\n\tv561 = v659 - 5;\n\tv557 = v561 == 0;\n\tv1091 = ~v563;\n\tv547 = v1091 | v557;\n\tif (v547) goto L_0231;\n\tv226[5] = currency;\n\tv1139 = v230 == 0;\n\tif (v1139) goto L_0175;\n\t// 369 IsInst v991 @ X0_v115, typeof(System.Object), v230 @ X26_v24 (System.Collections.Generic.Dictionary`2<System.String, System.String>)\n\tv993 = v991 == 0;\n\tif (v993) goto L_0253;\n\tv659 = v226.Length;\nL_0175:\n\tv1177 = v659 < 6;\n\tv640 = ~v1177;\n\tv638 = v659 - 6;\n\tv634 = v638 == 0;\n\tv1178 = ~v640;\n\tv624 = v1178 | v634;\n\tif (v624) goto L_0235;\n\tv226[6] = v230;\n\tUnityEngine.AndroidJavaObject::Call(v232.cls_AppsFlyer, \"validateAndTrackInAppPurchase\", v226);\n\tv1269 = v776 == 0;\n\tif (v1269) goto L_FFFFFFFF;\nL_0195:\n\tgoto L_01BC;\n\tv1301 = *([v1271 @ X8_v63+B0]);\n\tv1302 = 0;\n\tv1303 = v1301 + 8;\n\tv1305 = *([v1344 @ X11_v29-8]);\n\tv1350 = v1305 == v1274;\n\tif (v1350) goto L_01B5;\n\tv1327 = v1345 + 1;\n\tv1355 = v1327 < v1273;\n\tv1323 = ~v1355;\n\tv1325 = v1344 + 0x10;\n\tv1307 = ~v1323;\n\tif (v1307) goto L_FFFFFFFF;\n\tv1328 = v224;\n\tv1329 = 0;\n\tv1330 = 0x8909C4(v1328, v1274, v1329, v1036, currency, extraParams, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_01BC;\nL_01B5:\n\tv1356 = *([v1344 @ X11_v29]);\n\tv1357 = v1356 << 4;\n\tv1358 = v1271 + v1357;\n\tv1359 = v1358 + 0x130;\nL_01BC:\n\tSystem.IDisposable::Dispose(v776);\n\tgoto L_01C8;\n\tgoto L_025A;\nL_01C8:\n\tv1162 = v119 == 0;\n\tif (v1162) goto L_01F8;\nL_01D0:\n\tgoto L_01F7;\n\tv1204 = *([v1170 @ X8_v27+B0]);\n\tv1205 = 0;\n\tv1206 = v1204 + 8;\n\tv1208 = *([v1245 @ X11_v22-8]);\n\tv1251 = v1208 == v1173;\n\tif (v1251) goto L_01F0;\n\tv1230 = v1246 + 1;\n\tv1261 = v1230 < v1172;\n\tv1226 = ~v1261;\n\tv1228 = v1245 + 0x10;\n\tv1210 = ~v1226;\n\tif (v1210) goto L_FFFFFFFF;\n\tv1231 = v1168;\n\tv1232 = 0;\n\tv1233 = 0x8909C4(v1231, v1173, v1232, v1153, currency, extraParams, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_01F7;\nL_01F0:\n\tv1262 = *([v1245 @ X11_v22]);\n\tv1263 = v1262 << 4;\n\tv1264 = v1170 + v1263;\n\tv1265 = v1264 + 0x130;\nL_01F7:\n\tSystem.IDisposable::Dispose(v1168);\nL_01F8:\n\tv1203 = v608 + 1;\n\tv592 = v1203 == 0;\n\tv587 = ~v592;\n\tif (v587) goto L_020F;\n\tv1234 = v609 == 0;\n\tv607 = ~v1234;\n\tif (v607) goto L_0228;\nL_020F:\n\treturn;\nL_0210:\n\tv203 = new System.IndexOutOfRangeException();\n\tgoto L_0228;\nL_0212:\n\tv271 = new System.ArrayTypeMismatchException();\n\tgoto L_0228;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv235 = new System.NullReferenceException();\nL_0219:\n\tv300 = new System.IndexOutOfRangeException();\n\tthrow v300;\nL_021D:\n\tv445 = new System.IndexOutOfRangeException();\n\tthrow v445;\nL_0221:\n\tv531 = new System.IndexOutOfRangeException();\n\tthrow v531;\nL_0228:\n\tv364 = new System.TypeLoadException();\nL_0229:\n\tv411 = new Syste\n// ... truncated")]
	public static void validateReceipt(string publicKey, string purchaseData, string signature, string price, string currency, Dictionary<string, string> extraParams)
	{
		//IL_0058: Expected O, but got I4
		//IL_0867: Expected O, but got I
		//IL_08c5: Expected O, but got I
		//IL_00db: Expected O, but got I4
		//IL_0923: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0981: Expected O, but got I
		//IL_01ae: Expected O, but got I4
		//IL_09df: Expected O, but got I
		//IL_0218: Expected O, but got I4
		//IL_0281: Expected O, but got I4
		//IL_0376: Expected O, but got I4
		//IL_0a5f: Expected O, but got I
		//IL_0abd: Expected O, but got I
		//IL_0400: Expected O, but got I4
		//IL_0b1b: Expected O, but got I
		//IL_0470: Expected O, but got I4
		//IL_0b79: Expected O, but got I
		//IL_04e0: Expected O, but got I4
		//IL_0bd7: Expected O, but got I
		//IL_0550: Expected O, but got I4
		//IL_0c35: Expected O, but got I
		//IL_05c0: Expected O, but got I4
		//IL_0630: Expected O, but got I4
		string[] array = new string[6];
		if ("AF.cs validateReceipt pk = " != null)
		{
			object obj = "AF.cs validateReceipt pk = " as string;
			if (obj == null)
			{
				goto IL_06d8;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = "AF.cs validateReceipt pk = ";
			if (publicKey != null)
			{
				object obj3 = publicKey as string;
				if (obj3 == null)
				{
					goto IL_06d8;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = publicKey;
				if (" data = " != null)
				{
					object obj5 = " data = " as string;
					if (obj5 == null)
					{
						goto IL_06d8;
					}
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = " data = ";
					if (purchaseData != null)
					{
						object obj7 = purchaseData as string;
						if (obj7 == null)
						{
							goto IL_06d8;
						}
						obj2 = array.Length;
					}
					bool flag9 = (long)(IntPtr)obj2 < 3L;
					bool flag10 = !flag9;
					object obj8 = (long)(IntPtr)obj2 - 3L;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = purchaseData;
						if ("sig = " != null)
						{
							object obj9 = "sig = " as string;
							if (obj9 == null)
							{
								goto IL_06d8;
							}
							obj2 = array.Length;
						}
						bool flag13 = (long)(IntPtr)obj2 < 4L;
						bool flag14 = !flag13;
						object obj10 = (long)(IntPtr)obj2 - 4L;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[4] = "sig = ";
							if (signature != null)
							{
								object obj11 = signature as string;
								if (obj11 == null)
								{
									goto IL_06d8;
								}
								obj2 = array.Length;
							}
							bool flag17 = (long)(IntPtr)obj2 < 5L;
							bool flag18 = !flag17;
							object obj12 = (long)(IntPtr)obj2 - 5L;
							bool flag19 = obj12 == null;
							bool flag20 = !flag18;
							if (!(flag20 || flag19))
							{
								array[5] = signature;
								string message = string.Concat(array);
								MonoBehaviour.print(message);
								AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
								AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
								bool flag21 = extraParams == null;
								Dictionary<string, string> dictionary = extraParams;
								if (!flag21)
								{
									AndroidJavaObject androidJavaObject2 = ConvertHashMap(extraParams);
									dictionary = (Dictionary<string, string>)(object)androidJavaObject2;
								}
								MonoBehaviour.print("inside cls_activity");
								object[] array2 = new object[7];
								if (androidJavaObject != null)
								{
									object obj13 = androidJavaObject as object;
									bool flag22 = obj13 == null;
									AndroidJavaClass androidJavaClass2 = androidJavaClass;
									if (flag22)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										throw ex;
									}
								}
								object obj14 = array2.Length;
								if (array2.Length != 0)
								{
									array2[0] = androidJavaObject;
									if (publicKey != null)
									{
										object obj15 = publicKey as object;
										bool flag23 = obj15 == null;
										AndroidJavaClass androidJavaClass2 = androidJavaClass;
										if (flag23)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
										obj14 = array2.Length;
									}
									bool flag24 = (long)(IntPtr)obj14 < 1L;
									bool flag25 = !flag24;
									object obj16 = (long)(IntPtr)obj14 - 1L;
									bool flag26 = obj16 == null;
									bool flag27 = !flag25;
									if (!(flag27 || flag26))
									{
										array2[1] = publicKey;
										if (signature != null)
										{
											object obj17 = signature as object;
											bool flag28 = obj17 == null;
											AndroidJavaClass androidJavaClass2 = androidJavaClass;
											if (flag28)
											{
												ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
												throw ex3;
											}
											obj14 = array2.Length;
										}
										bool flag29 = (long)(IntPtr)obj14 < 2L;
										bool flag30 = !flag29;
										object obj18 = (long)(IntPtr)obj14 - 2L;
										bool flag31 = obj18 == null;
										bool flag32 = !flag30;
										if (!(flag32 || flag31))
										{
											array2[2] = signature;
											if (purchaseData != null)
											{
												object obj19 = purchaseData as object;
												bool flag33 = obj19 == null;
												AndroidJavaClass androidJavaClass2 = androidJavaClass;
												if (flag33)
												{
													ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
													throw ex4;
												}
												obj14 = array2.Length;
											}
											bool flag34 = (long)(IntPtr)obj14 < 3L;
											bool flag35 = !flag34;
											object obj20 = (long)(IntPtr)obj14 - 3L;
											bool flag36 = obj20 == null;
											bool flag37 = !flag35;
											if (flag37 || flag36)
											{
												goto IL_0710;
											}
											array2[3] = purchaseData;
											string text = default(string);
											if (text != null)
											{
												object obj21 = text as object;
												bool flag38 = obj21 == null;
												AndroidJavaClass androidJavaClass2 = androidJavaClass;
												if (flag38)
												{
													ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
													throw ex5;
												}
												obj14 = array2.Length;
											}
											bool flag39 = (long)(IntPtr)obj14 < 4L;
											bool flag40 = !flag39;
											object obj22 = (long)(IntPtr)obj14 - 4L;
											bool flag41 = obj22 == null;
											bool flag42 = !flag40;
											if (!(flag42 || flag41))
											{
												array2[4] = text;
												if (currency != null)
												{
													object obj23 = currency as object;
													bool flag43 = obj23 == null;
													AndroidJavaClass androidJavaClass2 = androidJavaClass;
													if (flag43)
													{
														ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
														throw ex6;
													}
													obj14 = array2.Length;
												}
												bool flag44 = (long)(IntPtr)obj14 < 5L;
												bool flag45 = !flag44;
												object obj24 = (long)(IntPtr)obj14 - 5L;
												bool flag46 = obj24 == null;
												bool flag47 = !flag45;
												if (!(flag47 || flag46))
												{
													array2[5] = currency;
													if (dictionary != null)
													{
														object obj25 = dictionary as object;
														bool flag48 = obj25 == null;
														AndroidJavaClass androidJavaClass2 = androidJavaClass;
														if (flag48)
														{
															ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
															throw ex7;
														}
														obj14 = array2.Length;
													}
													bool flag49 = (long)(IntPtr)obj14 < 6L;
													bool flag50 = !flag49;
													object obj26 = (long)(IntPtr)obj14 - 6L;
													bool flag51 = obj26 == null;
													bool flag52 = !flag50;
													if (!(flag52 || flag51))
													{
														array2[6] = dictionary;
														cls_AppsFlyer.Call("validateAndTrackInAppPurchase", array2);
														((IDisposable)androidJavaObject)?.Dispose();
														int num = 0;
														bool flag53 = androidJavaClass == null;
														int num2 = 0;
														AndroidJavaClass androidJavaClass2 = androidJavaClass;
														int num3 = num;
														int num4 = 0;
														if (!flag53)
														{
															((IDisposable)androidJavaClass2).Dispose();
															num3 = num;
															num4 = num2;
														}
														if (num3 + 1 != 0 || num4 == 0)
														{
															return;
														}
														goto IL_0cda;
													}
													IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
													throw ex8;
												}
												IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
												throw ex9;
											}
											IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
											throw ex10;
										}
										IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
										throw ex11;
									}
									IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
									throw ex12;
								}
								IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
								throw ex13;
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex14 = new IndexOutOfRangeException();
		goto IL_0cda;
		IL_0710:
		IndexOutOfRangeException ex15 = new IndexOutOfRangeException();
		throw ex15;
		IL_06d8:
		ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
		goto IL_0cda;
		IL_0cda:
		TypeLoadException ex17 = new TypeLoadException();
		goto IL_0710;
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0x1664254", Offset = "0x1664254", Length = "0x380")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED71D8]);\n\tv29 = *([v28 @ X8_v48]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, eventValues, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202AF7C]) = v47;\nL_001B:\n\tv51 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v51, \"com.unity3d.player.UnityPlayer\");\n\tv65 = UnityEngine.AndroidJavaObject::GetStatic(v51, \"currentActivity\");\n\tgoto L_003A;\n\tv96 = *([v71 @ X0_v49+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_003A;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v71, v62, v63, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003A:\n\tv104 = AppsFlyer::ConvertHashMap(eventValues);\n\t// 67 NewArr v87 @ X0_v54 (System.Object[]), typeof(System.Object[]), 3\n\tv193 = v65 == 0;\n\tif (v193) goto L_004F;\n\t// 76 IsInst v236 @ X0_v71, typeof(System.Object), v65 @ X0_v48 (UnityEngine.AndroidJavaObject)\n\tv238 = v236 == 0;\n\tif (v238) goto L_011F;\nL_004F:\n\tv281 = v87.Length;\n\tv115 = v87.Length == 0;\n\tif (v115) goto L_010D;\n\tv87[0] = v65;\n\tv243 = eventName == 0;\n\tif (v243) goto L_005C;\n\t// 88 IsInst v337 @ X0_v69, typeof(System.Object), eventName @ X0 (System.String)\n\tv338 = v337 == 0;\n\tif (v338) goto L_0123;\n\tv281 = v87.Length;\nL_005C:\n\tv340 = v281 < 1;\n\tv213 = ~v340;\n\tv211 = v281 - 1;\n\tv207 = v211 == 0;\n\tv341 = ~v213;\n\tv197 = v341 | v207;\n\tif (v197) goto L_0115;\n\tv87[1] = eventName;\n\tv348 = v104 == 0;\n\tif (v348) goto L_0072;\n\t// 110 IsInst v381 @ X0_v67, typeof(System.Object), v104 @ X0_v52 (UnityEngine.AndroidJavaObject)\n\tv382 = v381 == 0;\n\tif (v382) goto L_0127;\n\tv281 = v87.Length;\nL_0072:\n\tv384 = v281 < 2;\n\tv263 = ~v384;\n\tv261 = v281 - 2;\n\tv257 = v261 == 0;\n\tv385 = ~v263;\n\tv247 = v385 | v257;\n\tif (v247) goto L_0119;\n\tv87[2] = v104;\n\tUnityEngine.AndroidJavaObject::Call(v93.cls_AppsFlyer, \"trackEvent\", v87);\n\tv426 = v65 == 0;\n\tif (v426) goto L_FFFFFFFF;\nL_0092:\n\tgoto L_00B9;\n\tv506 = *([v476 @ X8_v36+B0]);\n\tv507 = 0;\n\tv508 = v506 + 8;\n\tv510 = *([v552 @ X11_v22-8]);\n\tv558 = v510 == v479;\n\tif (v558) goto L_00B2;\n\tv532 = v553 + 1;\n\tv632 = v532 < v478;\n\tv528 = ~v632;\n\tv530 = v552 + 0x10;\n\tv512 = ~v528;\n\tif (v512) goto L_FFFFFFFF;\n\tv533 = v68;\n\tv534 = 0;\n\tv535 = 0x8909C4(v533, v479, v534, v420, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00B9;\nL_00B2:\n\tv633 = *([v552 @ X11_v22]);\n\tv634 = v633 << 4;\n\tv635 = v476 + v634;\n\tv636 = v635 + 0x130;\nL_00B9:\n\tSystem.IDisposable::Dispose(v65);\n\tgoto L_00C5;\n\tgoto L_012E;\nL_00C5:\n\tv540 = v51 == 0;\n\tif (v540) goto L_00F5;\nL_00CD:\n\tgoto L_00F4;\n\tv640 = *([v601 @ X8_v19+B0]);\n\tv641 = 0;\n\tv642 = v640 + 8;\n\tv644 = *([v692 @ X11_v15-8]);\n\tv698 = v644 == v604;\n\tif (v698) goto L_00ED;\n\tv666 = v693 + 1;\n\tv731 = v666 < v603;\n\tv662 = ~v731;\n\tv664 = v692 + 0x10;\n\tv646 = ~v662;\n\tif (v646) goto L_FFFFFFFF;\n\tv667 = v55;\n\tv668 = 0;\n\tv669 = 0x8909C4(v667, v604, v668, v585, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00F4;\nL_00ED:\n\tv732 = *([v692 @ X11_v15]);\n\tv733 = v732 << 4;\n\tv734 = v601 + v733;\n\tv735 = v734 + 0x130;\nL_00F4:\n\tSystem.IDisposable::Dispose(v51);\nL_00F5:\n\tv630 = v186 + 1;\n\tv149 = v630 == 0;\n\tv134 = ~v149;\n\tif (v134) goto L_0108;\n\tv670 = v184 == 0;\n\tv182 = ~v670;\n\tif (v182) goto L_0114;\nL_0108:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv95 = new System.NullReferenceException();\nL_010D:\n\tv119 = new System.IndexOutOfRangeException();\n\tthrow v119;\nL_0114:\n\tv192 = new System.TypeLoadException();\nL_0115:\n\tv232 = new System.IndexOutOfRangeException();\n\tthrow v232;\nL_0119:\n\tv282 = new System.IndexOutOfRangeException();\n\tthrow v282;\n\tv324 = new System.NullReferenceException();\nL_011F:\n\tv333 = new System.ArrayTypeMismatchException();\n\tthrow v333;\nL_0123:\n\tv377 = new System.ArrayTypeMismatchException();\n\tthrow v377;\nL_0127:\n\tv414 = new System.ArrayTypeMismatchException();\n\tthrow v414;\nL_012E:\n\tv474 = new System.TypeLoadException();\n\tgoto L_0154;\n\tgoto L_0136;\n\tgoto L_0136;\n\tgoto L_0136;\n\t// 307 Jump @b74\n\tgoto L_0154;\n\tgoto L_0136;\nL_0136:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 320 ConditionalJump @b74, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0092;\n\tgoto L_FFFFFFFF;\nL_0154:\n\tgoto L_015C;\n\tv680 = 0x6D2BC0(v474, 0, 0, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv596 = *([v680 @ X0_v9]);\n\tv593 = 0x6D2490(v680, 0, 0, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv739 = v51 == 0;\n\tv595 = ~v739;\n\tif (v595) goto L_00CD;\n\tgoto L_00F5;\nL_015C:\n\tv681 = 0x6D2380(v474, 0, 0, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void trackRichEvent(string eventName, Dictionary<string, string> eventValues)
	{
		//IL_008d: Expected O, but got I4
		//IL_0329: Expected O, but got I
		//IL_0387: Expected O, but got I
		//IL_010f: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = ConvertHashMap(eventValues);
		object[] array = new object[3];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			if (eventName != null)
			{
				object obj3 = eventName as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = eventName;
				if (androidJavaObject2 != null)
				{
					object obj5 = androidJavaObject2 as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (flag8 || flag7)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array[2] = androidJavaObject2;
				cls_AppsFlyer.Call("trackEvent", array);
				((IDisposable)androidJavaObject)?.Dispose();
				int num = 0;
				bool flag9 = androidJavaClass == null;
				int num2 = 0;
				int num3 = 0;
				int num4 = num;
				if (!flag9)
				{
					((IDisposable)androidJavaClass).Dispose();
					num3 = num2;
					num4 = num;
				}
				if (num4 + 1 != 0 || num3 == 0)
				{
					return;
				}
				TypeLoadException ex5 = new TypeLoadException();
			}
			IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
			throw ex6;
		}
		IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
		throw ex7;
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x1663C04", Offset = "0x1663C04", Length = "0x650")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv33 = *([1F047E0]);\n\tv34 = *([v33 @ X8_v86]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202AF7D]) = v53;\nL_001D:\n\tv55 = &v56 @ stack_-D0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\tv62 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv67 = v62;\n\tv68 = 0x8907BC(v67, methodInfo, v37, v38, v39, v40, v41, v42, v54, v44, v45, v46, v47, v48, v49, v50);\n\tv71 = *([v62 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv72 = *([v62 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv73 = v72 == 0;\n\tif (v73) goto L_0050;\n\tv75 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv97 = v75;\n\tv98 = 0x8907BC(v97, methodInfo, v37, v38, v39, v40, v41, v42, v54, v44, v45, v46, v47, v48, v49, v50);\nL_003C:\n\tv99 = *([v75 @ X19_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v99;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv118 = v90;\n\tv119 = 0x8907BC(v118, methodInfo, v37, v38, v39, v40, v41, v42, v54, v44, v45, v46, v47, v48, v49, v50);\nL_0050:\n\tgoto L_0058;\n\tv100 = v92;\n\tv101 = 0x8907BC(v100, methodInfo, v37, v38, v39, v40, v41, v42, v54, v44, v45, v46, v47, v48, v49, v50);\nL_0058:\n\tv108 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v108, \"java.util.HashMap\", v104.Value);\n\tv125 = UnityEngine.AndroidJavaObject::GetRawClass(v108);\n\tv207 = UnityEngine.AndroidJNIHelper::GetMethodID(v125, \"put\", \"(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;\");\n\tv330 = dict == 0;\n\tif (v330) goto L_FFFFFFFF;\n\t// 116 NewArr v337 @ X0_v28 (System.Object[]), typeof(System.Object[]), 2\n\tv355 = System.Collections.Generic.Dictionary`2<System.String, System.String>::GetEnumerator(dict);\n\t*([v21 @ X29-60]) = *([v21 @ X29-88]);\n\t*([v21 @ X29-80]) = *([v21 @ X29-A8]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-98]);\nL_0087:\n\tv551 = &v21 @ X29 - 0x80;\n\tv552 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::MoveNext(v551);\n\tv561 = v552 == 0;\n\tif (v561) goto L_01ED;\n\t// 146 NewArr v573 @ X0_v35 (System.Object[]), typeof(System.Object[]), 1\n\tv596 = *([v21 @ X29-70]) == 0;\n\tif (v596) goto L_009F;\n\t// 155 IsInst v602 @ X0_v104, typeof(System.Object), [v21 @ X29-70]\n\tv606 = v602 == 0;\n\tif (v606) goto L_01FB;\nL_009F:\n\tv609 = v573.Length == 0;\n\tif (v609) goto L_01F3;\n\tv573[0] = *([v21 @ X29-70]);\n\tv616 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v616, \"java.lang.String\", v573);\n\t// 176 NewArr v659 @ X0_v52 (System.Object[]), typeof(System.Object[]), 1\n\tv309 = v659 == 0;\n\tif (v309) goto L_0197;\n\tv660 = *([v21 @ X29-68]) == 0;\n\tif (v660) goto L_00BD;\n\t// 185 IsInst v664 @ X0_v100, typeof(System.Object), [v21 @ X29-68]\n\tv315 = v664 == 0;\n\tif (v315) goto L_01B0;\nL_00BD:\n\tv310 = v659.Length == 0;\n\tif (v310) goto L_0199;\n\tv659[0] = *([v21 @ X29-68]);\n\tv670 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v670, \"java.lang.String\", v659);\n\tv311 = v337 == 0;\n\tif (v311) goto L_019F;\n\tv675 = v616 == 0;\n\tif (v675) goto L_00D4;\n\t// 209 IsInst v679 @ X0_v96, typeof(System.Object), v616 @ X0_v49 (UnityEngine.AndroidJavaObject)\n\tv316 = v679 == 0;\n\tif (v316) goto L_01B5;\nL_00D4:\n\tv325 = v337.Length;\n\tv312 = v337.Length == 0;\n\tif (v312) goto L_01A1;\n\tv337[0] = v616;\n\tv684 = v670 == 0;\n\tif (v684) goto L_00E1;\n\t// 221 IsInst v689 @ X0_v92, typeof(System.Object), v670 @ X0_v59 (UnityEngine.AndroidJavaObject)\n\tv317 = v689 == 0;\n\tif (v317) goto L_01BA;\n\tv325 = v337.Length;\nL_00E1:\n\tv693 = v325 < 1;\n\tv248 = ~v693;\n\tv244 = v325 - 1;\n\tv236 = v244 == 0;\n\tv694 = ~v248;\n\tv216 = v694 | v236;\n\tif (v216) goto L_01A6;\n\tv337[1] = v670;\n\tv697 = UnityEngine.AndroidJavaObject::GetRawObject(v108);\n\tv702 = UnityEngine.AndroidJNIHelper::CreateJNIArgArray(v337);\n\tv706 = UnityEngine.AndroidJNI::CallObjectMethod(v697, v207, v702);\n\tv403 = v403 + 1;\n\t*([v55 @ X26_v1+v403 @ X27_v3*4]) = 0xB3;\nL_00FD:\n\tv708 = v670 == 0;\n\tif (v708) goto L_012D;\n\tgoto L_012C;\n\tv752 = *([v709 @ X8_v69+B0]);\n\tv753 = 0;\n\tv754 = v752 + 8;\n\tv756 = *([v795 @ X11_v20-8]);\n\tv801 = v756 == v713;\n\tif (v801) goto L_0125;\n\tv778 = v796 + 1;\n\tv833 = v778 < v711;\n\tv774 = ~v833;\n\tv776 = v795 + 0x10;\n\tv758 = ~v774;\n\tif (v758) goto L_FFFFFFFF;\n\tv779 = v261;\n\tv780 = 0;\n\tv781 = 0x8909C4(v779, v713, v780, v286, v39, v40, v41, v42, v176, v174, v45, v46, v47, v48, v49, v50);\n\tgoto L_012C;\nL_0125:\n\tv834 = *([v795 @ X11_v20]);\n\tv835 = v834 << 4;\n\tv836 = v709 + v835;\n\tv837 = v836 + 0x130;\nL_012C:\n\tSystem.IDisposable::Dispose(v670);\nL_012D:\n\tv747 = v403 + 1;\n\tv749 = v747 == 0;\n\tif (v749) goto L_0146;\n\tv782 = v405 == 0;\n\tif (v782) goto L_0142;\n\tv816 = *([v55 @ X26_v1+v403 @ X27_v3*4]) != 0xB3;\n\tif (v816) goto L_01AE;\nL_0142:\n\tv828 = v616 == 0;\n\tv829 = ~v828;\n\tif (v829) goto L_0153;\n\tgoto L_017B;\nL_0146:\n\tv783 = v405 == 0;\n\tv784 = ~v783;\n\tif (v784) goto L_01AE;\nL_014B:\n\tv853 = v616 == 0;\n\tif (v853) goto L_017B;\nL_0153:\n\tgoto L_017A;\n\tv894 = *([v855 @ X8_v63+B0]);\n\tv895 = 0;\n\tv896 = v894 + 8;\n\tv898 = *([v936 @ X11_v14-8]);\n\tv942 = v898 == v859;\n\tif (v942) goto L_0173;\n\tv920 = v937 + 1;\n\tv948 = v920 < v857;\n\tv916 = ~v948;\n\tv918 = v936 + 0x10;\n\tv900 = ~v916;\n\tif (v900) goto L_FFFFFFFF;\n\tv921 = v319;\n\tv922 = 0;\n\tv923 = 0x8909C4(v921, v859, v922, v286, v39, v40, v41, v42, v176, v174, v45, v46, v47, v48, v49, v50);\n\tgoto L_017A;\nL_0173:\n\tv949 = *([v936 @ X11_v14]);\n\tv950 = v949 << 4;\n\tv951 = v855 + v950;\n\tv952 = v951 + 0x130;\nL_017A:\n\tSystem.IDisposable::Dispose(v616);\nL_017B:\n\tv542 = v530 + 1;\n\tv891 = v542 == 0;\n\tif (v891) goto L_0193;\n\tv506 = *([v55 @ X26_v1+v530 @ X27_v12*4]) != 0xB3;\n\tif (v506) goto L_0193;\n\tv546 = 0xFFFFFFFF ^ v530;\n\tv403 = v530 + v546;\n\tgoto L_0087;\nL_0193:\n\tv543 = v528 == 0;\n\tif (v543) goto L_0087;\n\tgoto L_01FA;\nL_0197:\n\tv299 = new System.NullReferenceException();\n\tgoto L_0201;\nL_0199:\n\tv671 = new System.IndexOutOfRangeException();\n\tthrow v671;\n\tgoto L_0201;\nL_019F:\n\tv301 = new System.NullReferenceException();\n\tgoto L_0201;\nL_01A1:\n\tv685 = new System.IndexOutOfRangeException();\n\tthrow v685;\n\tgoto L_0201;\nL_01A6:\n\tv698 = new System.IndexOutOfRangeException();\n\tthrow v698;\n\tgoto L_0201;\nL_01AE:\n\tv304 = new System.TypeLoadException();\n\tgoto L_0201;\nL_01B0:\n\tv672 = new System.ArrayTypeMismatchException();\n\tthrow v672;\n\tgoto L_0201;\nL_01B5:\n\tv686 = new System.ArrayTypeMismatchException();\n\tthrow v686;\n\tgoto L_0201;\nL_01BA:\n\tv699 = new System.ArrayTypeMismatchException();\n\tthrow v699;\n\tgoto L_0201;\n\tgoto L_01D9;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01C6;\n\tgoto L_01D9;\n\tgoto L_01D9;\n\tgoto L_01C6;\nL_01C6:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01DB;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FD;\n\tgoto L_01D9;\nL_01D9:\n\tX8 = X1;\n\tX2 = X0;\nL_01DB:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0213;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_014B;\n\tgoto L_0246;\nL_01ED:\n\tv403 = v403 + 1;\n\t*([v55 @ X26_v1+v403 @ X27_v3*4]) = 0xCF;\n\tgoto L_021A;\n\tv598 = new System.NullReferenceException();\nL_01F3:\n\tv614 = new System.IndexOutOfRangeException();\n\tthrow v614;\nL_01FA:\n\tv644 = new System.TypeLoadException();\nL_01FB:\n\tv648 = new System.ArrayTypeMismatchException();\n\tthrow v648;\n\tv199 = new System.NullReferenceException();\nL_0201:\n\tgoto L_0213;\n\t// 514 Jump @b131\n\t// 515 Jump @b131\n\t// 516 Jump @b131\n\t// 517 Jump @b131\n\t// 518 Jump @b131\nL_0213:\n\tv349 = v273 != 1;\n\tif (v349) goto L_0247;\n\tv463 = 0x6D2BC0(v298, v273, v298, v283,\n// ... truncated")]
	private unsafe static AndroidJavaObject ConvertHashMap(Dictionary<string, string> dict)
	{
		//IL_0105: Expected O, but got I8
		//IL_0879: Expected O, but got I
		//IL_0626: Expected O, but got I
		//IL_0690: Expected O, but got I
		//IL_06a8: Expected O, but got I
		//IL_015e: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_0553: Expected O, but got I4
		//IL_055c: Expected O, but got I4
		//IL_0231: Expected O, but got I
		//IL_0672: Expected I4, but got O
		//IL_028b: Expected O, but got I
		//IL_0592: Expected O, but got I4
		//IL_0311: Expected O, but got I4
		//IL_07af: Expected O, but got I
		//IL_03ed: Expected O, but got I
		//IL_0393: Expected O, but got I4
		//IL_07f3: Expected O, but got I
		//IL_05cd: Expected O, but got I4
		//IL_05d6: Expected O, but got I4
		//IL_08e6: Expected O, but got I8
		//IL_08fc: Expected O, but got I8
		//IL_082e: Expected O, but got I
		//IL_04ef: Expected I4, but got I8
		//IL_04fd: Expected O, but got I
		object obj = obj;
		object obj3 = default(object);
		object obj2 = obj3;
		_ = 0;
		_ = 0;
		_ = 0;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X19_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.HashMap");
		IntPtr rawClass = androidJavaObject.GetRawClass();
		IntPtr methodID = AndroidJNIHelper.GetMethodID(rawClass, "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
		AndroidJavaObject result2;
		if (dict != null)
		{
			object[] array = new object[2];
			Dictionary<string, string>.Enumerator enumerator = dict.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
			_ = 0;
			object obj4 = 4294967295L;
			int num = 0;
			object obj16 = default(object);
			AndroidJavaObject result = default(AndroidJavaObject);
			while (true)
			{
				Dictionary<string, string>.Enumerator enumerator2 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 128L);
				int num3;
				object obj12;
				object obj13;
				object obj14;
				string text;
				if (((Dictionary<string, string>.Enumerator*)enumerator2)->MoveNext())
				{
					object[] array2 = new object[1];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
						object obj5 = 0 as object;
						if (obj5 == null)
						{
							goto IL_064d;
						}
					}
					if (array2.Length != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
						array2[0] = 0;
						AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.String", array2);
						object[] array3 = new object[1];
						if (array3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
								object obj6 = 0 as object;
								if (obj6 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							if (array3.Length == 0)
							{
								IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
								throw ex2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-68]");
							array3[0] = 0;
							AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.lang.String", array3);
							if (array != null)
							{
								if (androidJavaObject2 != null)
								{
									object obj7 = androidJavaObject2 as object;
									if (obj7 == null)
									{
										ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
										throw ex3;
									}
								}
								object obj8 = array.Length;
								if (array.Length != 0)
								{
									array[0] = androidJavaObject2;
									if (androidJavaObject3 != null)
									{
										object obj9 = androidJavaObject3 as object;
										if (obj9 == null)
										{
											ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
											throw ex4;
										}
										obj8 = array.Length;
									}
									bool flag = (long)(IntPtr)obj8 < 1L;
									bool flag2 = !flag;
									object obj10 = (long)(IntPtr)obj8 - 1L;
									bool flag3 = obj10 == null;
									bool flag4 = !flag2;
									if (!(flag4 || flag3))
									{
										array[1] = androidJavaObject3;
										IntPtr rawObject = androidJavaObject.GetRawObject();
										jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(array);
										IntPtr intPtr3 = AndroidJNI.CallObjectMethod(rawObject, methodID, args);
										obj4 = (long)(IntPtr)obj4 + 1L;
										_ = 179;
										((IDisposable)androidJavaObject3)?.Dispose();
										object obj11 = (long)(IntPtr)obj4 + 1L;
										int num2;
										if (obj11 != null)
										{
											if (num != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v403 @ X27_v3*4]");
												if ((IntPtr)0 != (IntPtr)179)
												{
													goto IL_05bb;
												}
											}
											bool flag5 = androidJavaObject2 == null;
											bool flag6 = !flag5;
											num2 = num;
											if (!flag6)
											{
												num3 = num;
												obj12 = obj4;
												goto IL_081f;
											}
										}
										else
										{
											if (num != 0)
											{
												goto IL_05bb;
											}
											bool flag7 = androidJavaObject2 == null;
											num2 = 0;
											obj4 = 4294967295L;
											num3 = 0;
											obj12 = 4294967295L;
											if (flag7)
											{
												goto IL_081f;
											}
										}
										((IDisposable)androidJavaObject2).Dispose();
										num3 = num2;
										obj12 = obj4;
										goto IL_081f;
									}
									IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
									throw ex5;
								}
								IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
								throw ex6;
							}
							NullReferenceException ex7 = new NullReferenceException();
							obj13 = "java.lang.String";
							obj14 = 0;
							text = (string)(object)ex7;
						}
						else
						{
							NullReferenceException ex8 = new NullReferenceException();
							obj13 = 1;
							obj14 = 0;
							text = (string)(object)ex8;
						}
						goto IL_093d;
					}
					IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
					throw ex9;
				}
				obj4 = (long)(IntPtr)obj4 + 1L;
				_ = 207;
				break;
				IL_081f:
				object obj15 = (long)(IntPtr)obj12 + 1L;
				if (obj15 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v530 @ X27_v12*4]");
					if ((IntPtr)0 == (IntPtr)179)
					{
						int num4 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj12);
						obj4 = (long)(IntPtr)obj12 + (long)num4;
						num = num3;
						continue;
					}
				}
				bool flag8 = num3 == 0;
				obj4 = obj12;
				num = 0;
				if (flag8)
				{
					continue;
				}
				TypeLoadException ex10 = new TypeLoadException();
				goto IL_064d;
				IL_064d:
				ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
				throw ex11;
				IL_05bb:
				TypeLoadException ex12 = new TypeLoadException();
				obj13 = 0;
				obj14 = 0;
				text = (string)(object)ex12;
				goto IL_093d;
				IL_093d:
				if ((IntPtr)obj13 == (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					num = (int)obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				return result;
			}
			Dictionary<string, string>.Enumerator enumerator3 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 128L);
			((Dictionary<string, string>.Enumerator*)enumerator3)->Dispose();
			object obj17 = (long)(IntPtr)obj4 + 1L;
			if (obj17 != null)
			{
				bool flag9 = num == 0;
				result2 = androidJavaObject;
				if (!flag9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X26_v1+v403 @ X27_v3*4]");
					bool flag10 = (IntPtr)0 == (IntPtr)207;
					result2 = androidJavaObject;
					if (!flag10)
					{
						goto IL_0717;
					}
				}
			}
			else
			{
				bool flag11 = num == 0;
				bool flag12 = !flag11;
				result2 = androidJavaObject;
				if (flag12)
				{
					goto IL_0717;
				}
			}
		}
		else
		{
			result2 = null;
		}
		return result2;
		IL_0717:
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0x16645D4", Offset = "0x16645D4", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EFBE50]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF7E]) = v40;\nL_0018:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs setImeiData\");\n\tgoto L_002C;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002C;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = AppsFlyer;\nL_002C:\n\t// 44 NewArr v64 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv68 = imeiData == 0;\n\tif (v68) goto L_0039;\n\t// 53 IsInst v73 @ X0_v19, typeof(System.Object), imeiData @ X0 (System.String)\nL_0039:\n\tv80 = v64.Length == 0;\n\tif (v80) goto L_004D;\n\tv64[0] = imeiData;\n\tUnityEngine.AndroidJavaObject::Call(v59.cls_AppsFlyer, \"setImeiData\", v64);\n\treturn;\n\tv69 = new System.NullReferenceException();\nL_004D:\n\tv85 = new System.IndexOutOfRangeException();\n\tgoto L_0054;\n\tv89 = new System.NullReferenceException();\n\tv92 = new System.ArrayTypeMismatchException();\nL_0054:\n\tthrow v106;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setImeiData(string imeiData)
	{
		MonoBehaviour.print("AF.cs setImeiData");
		object[] array = new object[1];
		if (imeiData != null)
		{
			object obj = imeiData as object;
		}
		if (array.Length != 0)
		{
			array[0] = imeiData;
			cls_AppsFlyer.Call("setImeiData", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0x16646DC", Offset = "0x16646DC", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF7ED8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF7F]) = v40;\nL_0018:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs setImeiData\");\n\tgoto L_002C;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002C;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = AppsFlyer;\nL_002C:\n\t// 44 NewArr v64 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv68 = androidIdData == 0;\n\tif (v68) goto L_0039;\n\t// 53 IsInst v73 @ X0_v19, typeof(System.Object), androidIdData @ X0 (System.String)\nL_0039:\n\tv80 = v64.Length == 0;\n\tif (v80) goto L_004D;\n\tv64[0] = androidIdData;\n\tUnityEngine.AndroidJavaObject::Call(v59.cls_AppsFlyer, \"setAndroidIdData\", v64);\n\treturn;\n\tv69 = new System.NullReferenceException();\nL_004D:\n\tv85 = new System.IndexOutOfRangeException();\n\tgoto L_0054;\n\tv89 = new System.NullReferenceException();\n\tv92 = new System.ArrayTypeMismatchException();\nL_0054:\n\tthrow v106;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setAndroidIdData(string androidIdData)
	{
		MonoBehaviour.print("AF.cs setImeiData");
		object[] array = new object[1];
		if (androidIdData != null)
		{
			object obj = androidIdData as object;
		}
		if (array.Length != 0)
		{
			array[0] = androidIdData;
			cls_AppsFlyer.Call("setAndroidIdData", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0x16647E4", Offset = "0x16647E4", Length = "0x124")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF9118]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF80]) = v40;\nL_0018:\n\tUnityEngine.MonoBehaviour::print(\"AF.cs setDebugLog\");\n\tgoto L_002C;\n\tv51 = *([v47 @ X0_v3 (Il2CppClass<AppsFlyer>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002C;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v47, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv55 = AppsFlyer;\nL_002C:\n\t// 44 NewArr v64 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\t// 51 Box v64 @ X0_v6 (System.Object[]), typeof(System.Boolean), &isDebug @ X0 (System.Boolean)\n\tv75 = v64 == 0;\n\tif (v75) goto L_0040;\n\t// 60 IsInst v64 @ X0_v6 (System.Object[]), typeof(System.Object), v64 @ X0_v6 (System.Object[])\nL_0040:\n\tv93 = v64.Length == 0;\n\tif (v93) goto L_0055;\n\tv64[0] = v64;\n\tUnityEngine.AndroidJavaObject::Call(v59.cls_AppsFlyer, \"setDebugLog\", v64);\n\treturn;\n\tv85 = new System.NullReferenceException();\nL_0055:\n\tv98 = new System.IndexOutOfRangeException();\n\tgoto L_005A;\n\tv99 = new System.ArrayTypeMismatchException();\nL_005A:\n\tthrow v107;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setIsDebug(bool isDebug)
	{
		MonoBehaviour.print("AF.cs setDebugLog");
		object[] array = new object[1];
		array = (object[])(object)isDebug;
		if (array != null)
		{
			array = (object[])(array as object);
		}
		if (array.Length != 0)
		{
			array[0] = array;
			cls_AppsFlyer.Call("setDebugLog", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0x1664908", Offset = "0x1664908", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public static void setIsSandbox(bool isSandbox)
	{
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0x166490C", Offset = "0x166490C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public static void getConversionData()
	{
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0x1664910", Offset = "0x1664910", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public static void handleOpenUrl(string url, string sourceApplication, string annotation)
	{
	}

	[Token(Token = "0x6000018")]
	[Address(RVA = "0x1664914", Offset = "0x1664914", Length = "0x2EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F06330]);\n\tv23 = *([v22 @ X8_v37]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([202AF81]) = v43;\nL_0018:\n\tv47 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v47, \"com.unity3d.player.UnityPlayer\");\n\tv61 = UnityEngine.AndroidJavaObject::GetStatic(v47, \"currentActivity\");\n\tgoto L_003D;\n\tv90 = *([v67 @ X0_v38 (Il2CppClass<AppsFlyer>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_003D;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v67, v58, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv94 = AppsFlyer;\nL_003D:\n\t// 61 NewArr v83 @ X0_v41 (System.Object[]), typeof(System.Object[]), 1\n\tv194 = v61 == 0;\n\tif (v194) goto L_004A;\n\t// 70 IsInst v201 @ X0_v53, typeof(System.Object), v61 @ X0_v37 (UnityEngine.AndroidJavaObject)\n\tv203 = v201 == 0;\n\tif (v203) goto L_00E8;\nL_004A:\n\tv190 = v83.Length == 0;\n\tif (v190) goto L_00E2;\n\tv83[0] = v61;\n\tv265 = UnityEngine.AndroidJavaObject::Call(v87.cls_AppsFlyer, \"getAppsFlyerUID\", v83);\n\tv272 = v61 == 0;\n\tif (v272) goto L_FFFFFFFF;\nL_0063:\n\tgoto L_008A;\n\tv351 = *([v321 @ X8_v29+B0]);\n\tv352 = 0;\n\tv353 = v351 + 8;\n\tv355 = *([v397 @ X11_v19-8]);\n\tv403 = v355 == v324;\n\tif (v403) goto L_0083;\n\tv377 = v398 + 1;\n\tv476 = v377 < v323;\n\tv373 = ~v476;\n\tv375 = v397 + 0x10;\n\tv357 = ~v373;\n\tif (v357) goto L_FFFFFFFF;\n\tv378 = v64;\n\tv379 = 0;\n\tv380 = 0x8909C4(v378, v324, v379, v262, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_008A;\nL_0083:\n\tv477 = *([v397 @ X11_v19]);\n\tv478 = v477 << 4;\n\tv479 = v321 + v478;\n\tv480 = v479 + 0x130;\nL_008A:\n\tSystem.IDisposable::Dispose(v61);\n\tgoto L_0096;\n\tgoto L_00EF;\nL_0096:\n\tv385 = v47 == 0;\n\tif (v385) goto L_00C6;\nL_009E:\n\tgoto L_00C5;\n\tv484 = *([v445 @ X8_v15+B0]);\n\tv485 = 0;\n\tv486 = v484 + 8;\n\tv488 = *([v536 @ X11_v12-8]);\n\tv542 = v488 == v448;\n\tif (v542) goto L_00BE;\n\tv510 = v537 + 1;\n\tv574 = v510 < v447;\n\tv506 = ~v574;\n\tv508 = v536 + 0x10;\n\tv490 = ~v506;\n\tif (v490) goto L_FFFFFFFF;\n\tv511 = v51;\n\tv512 = 0;\n\tv513 = 0x8909C4(v511, v448, v512, v431, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00C5;\nL_00BE:\n\tv575 = *([v536 @ X11_v12]);\n\tv576 = v575 << 4;\n\tv577 = v445 + v576;\n\tv578 = v577 + 0x130;\nL_00C5:\n\tSystem.IDisposable::Dispose(v47);\nL_00C6:\n\tv474 = v139 + 1;\n\tv122 = v474 == 0;\n\tv107 = ~v122;\n\tif (v107) goto L_00D9;\n\tv514 = v143 == 0;\n\tv157 = ~v514;\n\tif (v157) goto L_00E1;\nL_00D9:\n\treturn v145;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00E1:\n\tv163 = new System.TypeLoadException();\nL_00E2:\n\tv193 = new System.IndexOutOfRangeException();\n\tthrow v193;\n\tv231 = new System.NullReferenceException();\nL_00E8:\n\tv256 = new System.ArrayTypeMismatchException();\n\tthrow v256;\nL_00EF:\n\tv319 = new System.TypeLoadException();\n\tgoto L_0115;\n\tgoto L_00F5;\n\tgoto L_00F5;\n\tgoto L_0109;\n\tgoto L_0115;\nL_00F5:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0109;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = 0;\n\tX23 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0063;\n\tgoto L_FFFFFFFF;\nL_0109:\n\tX21 = 0;\nL_0115:\n\tgoto L_011D;\n\tv524 = UnityEngine.AndroidJavaObject::Call(v319, 0, 0);\n\tv432 = *([v524 @ X0_v10 (System.String)]);\n\tv440 = UnityEngine.AndroidJavaObject::Call(v524, 0, 0);\n\tv582 = v47 == 0;\n\tv442 = ~v582;\n\tif (v442) goto L_009E;\n\tgoto L_00C6;\nL_011D:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v319, 0, 0);\n\treturn returnVal2;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string getAppsFlyerId()
	{
		//IL_029d: Expected I, but got O
		//IL_02b2: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[1];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			string text = cls_AppsFlyer.Call<string>("getAppsFlyerUID", array);
			((IDisposable)androidJavaObject)?.Dispose();
			int num = 0;
			bool flag = androidJavaClass == null;
			IntPtr intPtr = (IntPtr)null;
			string text2 = text;
			int num2 = num;
			IntPtr intPtr2 = (IntPtr)null;
			string result = text;
			if (!flag)
			{
				((IDisposable)androidJavaClass).Dispose();
				num2 = num;
				intPtr2 = intPtr;
				result = text2;
			}
			if (num2 + 1 != 0 || intPtr2 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex2 = new TypeLoadException();
		}
		IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
		throw ex3;
	}

	[Token(Token = "0x6000019")]
	[Address(RVA = "0x1664C00", Offset = "0x1664C00", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDE9F0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF82]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = googleGCMNumber == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), googleGCMNumber @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = googleGCMNumber;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setGCMProjectNumber\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setGCMProjectNumber(string googleGCMNumber)
	{
		object[] array = new object[1];
		if (googleGCMNumber != null)
		{
			object obj = googleGCMNumber as object;
		}
		if (array.Length != 0)
		{
			array[0] = googleGCMNumber;
			cls_AppsFlyer.Call("setGCMProjectNumber", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001A")]
	[Address(RVA = "0x1664CF4", Offset = "0x1664CF4", Length = "0x3D4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EE7D58]);\n\tv25 = *([v24 @ X8_v57]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF83]) = v44;\nL_0019:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.appsflyer.AppsFlyerLib\");\n\tv58 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002D;\n\tv63 = v58;\n\tv64 = 0x8907BC(v63, v53, v51, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = *([v58 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002D:\n\tv68 = *([v58 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv69 = v68 == 0;\n\tif (v69) goto L_004E;\n\tv71 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003A;\n\tv93 = v71;\n\tv94 = 0x8907BC(v93, v53, v51, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003A:\n\tv95 = *([v71 @ X20_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv83 = ~v95;\n\tif (v83) goto L_004E;\n\tgoto L_004E;\n\tv115 = v77;\n\tv116 = 0x8907BC(v115, v53, v51, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004E:\n\tgoto L_005C;\n\tv96 = v88;\n\tv97 = 0x8907BC(v96, v53, v51, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005C:\n\tv112 = UnityEngine.AndroidJavaObject::CallStatic(v48, \"getInstance\", v105.Value);\n\tv122 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v122, \"com.unity3d.player.UnityPlayer\");\n\tv187 = UnityEngine.AndroidJavaObject::GetStatic(v122, \"currentActivity\");\n\t// 118 NewArr v157 @ X0_v54 (System.Object[]), typeof(System.Object[]), 2\n\tv298 = v187 == 0;\n\tif (v298) goto L_0082;\n\t// 127 IsInst v305 @ X0_v68, typeof(System.Object), v187 @ X0_v52 (UnityEngine.AndroidJavaObject)\n\tv307 = v305 == 0;\n\tif (v307) goto L_0139;\nL_0082:\n\tv295 = v157.Length;\n\tv177 = v157.Length == 0;\n\tif (v177) goto L_012B;\n\tv157[0] = v187;\n\tv337 = token == 0;\n\tif (v337) goto L_008F;\n\t// 139 IsInst v367 @ X0_v66, typeof(System.Object), token @ X0 (System.String)\n\tv368 = v367 == 0;\n\tif (v368) goto L_013D;\n\tv295 = v157.Length;\nL_008F:\n\tv370 = v295 < 1;\n\tv278 = ~v370;\n\tv276 = v295 - 1;\n\tv272 = v276 == 0;\n\tv371 = ~v278;\n\tv262 = v371 | v272;\n\tif (v262) goto L_0133;\n\tv157[1] = token;\n\tUnityEngine.AndroidJavaObject::Call(v112, \"updateServerUninstallToken\", v157);\n\tv412 = v187 == 0;\n\tif (v412) goto L_FFFFFFFF;\nL_00AF:\n\tgoto L_00D6;\n\tv492 = *([v462 @ X8_v42+B0]);\n\tv493 = 0;\n\tv494 = v492 + 8;\n\tv496 = *([v538 @ X11_v20-8]);\n\tv544 = v496 == v465;\n\tif (v544) goto L_00CF;\n\tv518 = v539 + 1;\n\tv618 = v518 < v464;\n\tv514 = ~v618;\n\tv516 = v538 + 0x10;\n\tv498 = ~v514;\n\tif (v498) goto L_FFFFFFFF;\n\tv519 = v149;\n\tv520 = 0;\n\tv521 = 0x8909C4(v519, v465, v520, v406, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00D6;\nL_00CF:\n\tv619 = *([v538 @ X11_v20]);\n\tv620 = v619 << 4;\n\tv621 = v462 + v620;\n\tv622 = v621 + 0x130;\nL_00D6:\n\tSystem.IDisposable::Dispose(v187);\n\tgoto L_00E2;\n\tgoto L_0144;\nL_00E2:\n\tv526 = v122 == 0;\n\tif (v526) goto L_0112;\nL_00EA:\n\tgoto L_0111;\n\tv626 = *([v587 @ X8_v24+B0]);\n\tv627 = 0;\n\tv628 = v626 + 8;\n\tv630 = *([v677 @ X11_v13-8]);\n\tv683 = v630 == v590;\n\tif (v683) goto L_010A;\n\tv652 = v678 + 1;\n\tv715 = v652 < v589;\n\tv648 = ~v715;\n\tv650 = v677 + 0x10;\n\tv632 = ~v648;\n\tif (v632) goto L_FFFFFFFF;\n\tv653 = v585;\n\tv654 = 0;\n\tv655 = 0x8909C4(v653, v590, v654, v571, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0111;\nL_010A:\n\tv716 = *([v677 @ X11_v13]);\n\tv717 = v716 << 4;\n\tv718 = v587 + v717;\n\tv719 = v718 + 0x130;\nL_0111:\n\tSystem.IDisposable::Dispose(v585);\nL_0112:\n\tv616 = v230 + 1;\n\tv216 = v616 == 0;\n\tv201 = ~v216;\n\tif (v201) goto L_0124;\n\tv656 = v250 == 0;\n\tv248 = ~v656;\n\tif (v248) goto L_0132;\nL_0124:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv164 = new System.NullReferenceException();\nL_012B:\n\tv181 = new System.IndexOutOfRangeException();\n\tthrow v181;\nL_0132:\n\tv258 = new System.TypeLoadException();\nL_0133:\n\tv297 = new System.IndexOutOfRangeException();\n\tthrow v297;\n\tv336 = new System.NullReferenceException();\nL_0139:\n\tv363 = new System.ArrayTypeMismatchException();\n\tthrow v363;\nL_013D:\n\tv400 = new System.ArrayTypeMismatchException();\n\tthrow v400;\nL_0144:\n\tv460 = new System.TypeLoadException();\n\tgoto L_0168;\n\tgoto L_014A;\n\tgoto L_014A;\n\t// 328 Jump @b76\n\tgoto L_0168;\nL_014A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 340 ConditionalJump @b76, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AF;\n\tgoto L_FFFFFFFF;\nL_0168:\n\tgoto L_0170;\n\tv665 = UnityEngine.AndroidJavaObject::CallStatic(v460, 0, 0);\n\tv582 = *([v665 @ X0_v12 (UnityEngine.AndroidJavaObject)]);\n\tv579 = UnityEngine.AndroidJavaObject::CallStatic(v665, 0, 0);\n\tv723 = v122 == 0;\n\tv581 = ~v723;\n\tif (v581) goto L_00EA;\n\tgoto L_0112;\nL_0170:\n\tv666 = UnityEngine.AndroidJavaObject::CallStatic(v460, 0, 0);\n\treturn;\n// 208 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void updateServerUninstallToken(string token)
	{
		//IL_00f9: Expected O, but got I4
		//IL_0369: Expected O, but got I
		//IL_0184: Expected O, but got I4
		//IL_0427: Expected I, but got O
		//IL_043c: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.appsflyer.AppsFlyerLib");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X20_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject2 = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
		object[] array = new object[2];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			bool flag = obj == null;
			AndroidJavaClass androidJavaClass3 = androidJavaClass2;
			if (flag)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			if (token != null)
			{
				object obj3 = token as object;
				bool flag2 = obj3 == null;
				AndroidJavaClass androidJavaClass3 = androidJavaClass2;
				if (flag2)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag3 = (long)(IntPtr)obj2 < 1L;
			bool flag4 = !flag3;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag5 = obj4 == null;
			bool flag6 = !flag4;
			if (!(flag6 || flag5))
			{
				array[1] = token;
				androidJavaObject.Call("updateServerUninstallToken", array);
				((IDisposable)androidJavaObject2)?.Dispose();
				int num = 0;
				bool flag7 = androidJavaClass2 == null;
				IntPtr intPtr3 = (IntPtr)null;
				AndroidJavaClass androidJavaClass3 = androidJavaClass2;
				int num2 = num;
				IntPtr intPtr4 = (IntPtr)null;
				if (!flag7)
				{
					((IDisposable)androidJavaClass3).Dispose();
					num2 = num;
					intPtr4 = intPtr3;
				}
				if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
				{
					return;
				}
				TypeLoadException ex3 = new TypeLoadException();
			}
			IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
			throw ex4;
		}
		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
		throw ex5;
	}

	[Token(Token = "0x600001B")]
	[Address(RVA = "0x16650C8", Offset = "0x16650C8", Length = "0x1A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC8088]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202AF84]) = v42;\nL_0018:\n\tv46 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v46, \"com.appsflyer.AppsFlyerLib\");\n\tv56 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002C;\n\tv61 = v56;\n\tv62 = 0x8907BC(v61, v51, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv65 = *([v56 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002C:\n\tv66 = *([v56 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv67 = v66 == 0;\n\tif (v67) goto L_004D;\n\tv69 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0039;\n\tv91 = v69;\n\tv92 = 0x8907BC(v91, v51, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0039:\n\tv93 = *([v69 @ X21_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv81 = ~v93;\n\tif (v81) goto L_004D;\n\tgoto L_004D;\n\tv130 = v75;\n\tv131 = 0x8907BC(v130, v51, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tgoto L_005B;\n\tv94 = v86;\n\tv95 = 0x8907BC(v94, v51, v49, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005B:\n\tv110 = UnityEngine.AndroidJavaObject::CallStatic(v46, \"getInstance\", v103.Value);\n\t// 98 NewArr v139 @ X0_v18 (System.Object[]), typeof(System.Object[]), 1\n\tv164 = senderId == 0;\n\tif (v164) goto L_006F;\n\t// 107 IsInst v168 @ X0_v22, typeof(System.Object), senderId @ X0 (System.String)\nL_006F:\n\tv160 = v139.Length == 0;\n\tif (v160) goto L_0085;\n\tv139[0] = senderId;\n\tUnityEngine.AndroidJavaObject::Call(v110, \"enableUninstallTracking\", v139);\n\treturn;\n\tv151 = new System.NullReferenceException();\nL_0085:\n\tv163 = new System.IndexOutOfRangeException();\n\tgoto L_008A;\n\tv179 = new System.ArrayTypeMismatchException();\nL_008A:\n\tthrow v178;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void enableUninstallTracking(string senderId)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.appsflyer.AppsFlyerLib");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X21_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		object[] array = new object[1];
		if (senderId != null)
		{
			object obj = senderId as object;
		}
		if (array.Length != 0)
		{
			array[0] = senderId;
			androidJavaObject.Call("enableUninstallTracking", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001C")]
	[Address(RVA = "0x166526C", Offset = "0x166526C", Length = "0x110")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF7A28]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF85]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &state @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setDeviceTrackingDisabled\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setDeviceTrackingDisabled(bool state)
	{
		object[] array = new object[1];
		array = (object[])(object)state;
		if (array != null)
		{
			array = (object[])(array as object);
		}
		if (array.Length != 0)
		{
			array[0] = array;
			cls_AppsFlyer.Call("setDeviceTrackingDisabled", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600001D")]
	[Address(RVA = "0x166537C", Offset = "0x166537C", Length = "0x2E4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EEC978]);\n\tv25 = *([v24 @ X8_v38]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202AF86]) = v44;\nL_0019:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.unity3d.player.UnityPlayer\");\n\tv62 = UnityEngine.AndroidJavaObject::GetStatic(v48, \"currentActivity\");\n\tgoto L_0038;\n\tv138 = *([v68 @ X0_v37+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0038;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v68, v59, v60, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0038:\n\tv146 = AppsFlyer::ConvertHashMap(extraData);\n\t// 65 NewArr v172 @ X0_v42 (System.Object[]), typeof(System.Object[]), 1\n\tv216 = v146 == 0;\n\tif (v216) goto L_004E;\n\t// 74 IsInst v247 @ X0_v53, typeof(System.Object), v146 @ X0_v40 (UnityEngine.AndroidJavaObject)\n\tv249 = v247 == 0;\n\tif (v249) goto L_00E8;\nL_004E:\n\tv208 = v172.Length == 0;\n\tif (v208) goto L_00E2;\n\tv172[0] = v146;\n\tUnityEngine.AndroidJavaObject::Call(v178.cls_AppsFlyer, \"setAdditionalData\", v172);\n\tv334 = v62 == 0;\n\tif (v334) goto L_FFFFFFFF;\nL_0064:\n\tgoto L_008B;\n\tv367 = *([v336 @ X8_v30+B0]);\n\tv368 = 0;\n\tv369 = v367 + 8;\n\tv371 = *([v422 @ X11_v20-8]);\n\tv428 = v371 == v339;\n\tif (v428) goto L_0084;\n\tv393 = v423 + 1;\n\tv493 = v393 < v338;\n\tv389 = ~v493;\n\tv391 = v422 + 0x10;\n\tv373 = ~v389;\n\tif (v373) goto L_FFFFFFFF;\n\tv394 = v65;\n\tv395 = 0;\n\tv396 = 0x8909C4(v394, v339, v395, v284, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_008B;\nL_0084:\n\tv494 = *([v422 @ X11_v20]);\n\tv495 = v494 << 4;\n\tv496 = v336 + v495;\n\tv497 = v496 + 0x130;\nL_008B:\n\tSystem.IDisposable::Dispose(v62);\n\tgoto L_0097;\n\tgoto L_00EF;\nL_0097:\n\tv401 = v48 == 0;\n\tif (v401) goto L_00C7;\nL_009F:\n\tgoto L_00C6;\n\tv501 = *([v461 @ X8_v15+B0]);\n\tv502 = 0;\n\tv503 = v501 + 8;\n\tv505 = *([v550 @ X11_v13-8]);\n\tv556 = v505 == v464;\n\tif (v556) goto L_00BF;\n\tv527 = v551 + 1;\n\tv589 = v527 < v463;\n\tv523 = ~v589;\n\tv525 = v550 + 0x10;\n\tv507 = ~v523;\n\tif (v507) goto L_FFFFFFFF;\n\tv528 = v52;\n\tv529 = 0;\n\tv530 = 0x8909C4(v528, v464, v529, v446, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00C6;\nL_00BF:\n\tv590 = *([v550 @ X11_v13]);\n\tv591 = v590 << 4;\n\tv592 = v461 + v591;\n\tv593 = v592 + 0x130;\nL_00C6:\n\tSystem.IDisposable::Dispose(v48);\nL_00C7:\n\tv490 = v114 + 1;\n\tv95 = v490 == 0;\n\tv80 = ~v95;\n\tif (v80) goto L_00D9;\n\tv531 = v131 == 0;\n\tv129 = ~v531;\n\tif (v129) goto L_00DF;\nL_00D9:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00DF:\n\tthrow System.TypeLoadException;\n\tv180 = new System.NullReferenceException();\nL_00E2:\n\tv212 = new System.IndexOutOfRangeException();\n\tthrow v212;\n\tv243 = new System.NullReferenceException();\nL_00E8:\n\tv275 = new System.ArrayTypeMismatchException();\n\tthrow v275;\nL_00EF:\n\tv333 = new System.TypeLoadException();\n\tgoto L_0113;\n\tgoto L_00F5;\n\t// 242 Jump @b56\n\tgoto L_0113;\n\tgoto L_00F5;\nL_00F5:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\t// 255 ConditionalJump @b56, TEMPCOND\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = 0xFFFFFFFF;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0064;\n\tgoto L_FFFFFFFF;\nL_0113:\n\tgoto L_011B;\n\tv491 = 0x6D2BC0(v333, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv457 = *([v491 @ X0_v9]);\n\tv454 = 0x6D2490(v491, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv588 = v48 == 0;\n\tv456 = ~v588;\n\tif (v456) goto L_009F;\n\tgoto L_00C7;\nL_011B:\n\tv492 = 0x6D2380(v333, 0, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setAdditionalData(Dictionary<string, string> extraData)
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject2 = ConvertHashMap(extraData);
		object[] array = new object[1];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			cls_AppsFlyer.Call("setAdditionalData", array);
			((IDisposable)androidJavaObject)?.Dispose();
			int num = 0;
			bool flag = androidJavaClass == null;
			int num2 = 0;
			int num3 = num;
			int num4 = 0;
			if (!flag)
			{
				((IDisposable)androidJavaClass).Dispose();
				num3 = num;
				num4 = num2;
			}
			if (num3 + 1 != 0 || num4 == 0)
			{
				return;
			}
			throw new TypeLoadException();
		}
		IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		throw ex2;
	}

	[Token(Token = "0x600001E")]
	[Address(RVA = "0x1665660", Offset = "0x1665660", Length = "0x410")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB7630]);\n\tv27 = *([v26 @ X8_v60]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202AF87]) = v46;\nL_001A:\n\tv50 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v50, \"com.unity3d.player.UnityPlayer\");\n\tv64 = UnityEngine.AndroidJavaObject::GetStatic(v50, \"currentActivity\");\n\tv72 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0039;\n\tv93 = v72;\n\tv94 = UnityEngine.AndroidJavaObject::GetStatic(v93, v61, v62);\n\tv97 = *([v72 @ X22_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0039:\n\tv98 = *([v72 @ X22_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv99 = v98 == 0;\n\tif (v99) goto L_005A;\n\tv171 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0046;\n\tv232 = v171;\n\tv233 = UnityEngine.AndroidJavaObject::GetStatic(v232, v61, v62);\nL_0046:\n\tv234 = *([v171 @ X22_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv183 = ~v234;\n\tif (v183) goto L_005A;\n\tgoto L_005A;\n\tv281 = v177;\n\tv282 = UnityEngine.AndroidJavaObject::GetStatic(v281, v61, v62);\nL_005A:\n\tgoto L_0068;\n\tv235 = v78;\n\tv236 = UnityEngine.AndroidJavaObject::GetStatic(v235, v61, v62);\nL_0068:\n\tv277 = UnityEngine.AndroidJavaObject::Call(v64, \"getApplication\", v272.Value);\n\tgoto L_007D;\n\tv331 = *([v287 @ X0_v51 (Il2CppClass<AppsFlyer>)+E0]);\n\tv332 = v331 == 0;\n\tv333 = ~v332;\n\tif (v333) goto L_007D;\n\tv346 = \"il2cpp_codegen_runtime_class_init\"(v287, v275, v221, v208, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv335 = AppsFlyer;\nL_007D:\n\t// 125 NewArr v342 @ X0_v54 (System.Object[]), typeof(System.Object[]), 2\n\t// 133 Box v50 @ X0_v3 (UnityEngine.AndroidJavaClass), typeof(System.Boolean), &isStopTracking @ X0 (System.Boolean)\n\tv410 = v50 == 0;\n\tif (v410) goto L_0091;\n\t// 142 IsInst v50 @ X0_v3 (UnityEngine.AndroidJavaClass), typeof(System.Object), v50 @ X0_v3 (UnityEngine.AndroidJavaClass)\n\tv405 = v50 == 0;\n\tif (v405) goto L_0147;\nL_0091:\n\tv329 = v342.Length;\n\tv263 = v342.Length == 0;\n\tif (v263) goto L_013D;\n\tv342[0] = v50;\n\tv448 = v277 == 0;\n\tif (v448) goto L_009E;\n\t// 154 IsInst v50 @ X0_v3 (UnityEngine.AndroidJavaClass), typeof(System.Object), v277 @ X0_v50 (UnityEngine.AndroidJavaObject)\n\tv443 = v50 == 0;\n\tif (v443) goto L_014B;\n\tv329 = v342.Length;\nL_009E:\n\tv454 = v329 < 1;\n\tv310 = ~v454;\n\tv308 = v329 - 1;\n\tv304 = v308 == 0;\n\tv455 = ~v310;\n\tv294 = v455 | v304;\n\tif (v294) goto L_0141;\n\tv342[1] = v277;\n\tUnityEngine.AndroidJavaObject::Call(v339.cls_AppsFlyer, \"stopTracking\", v342);\nL_00BC:\n\tgoto L_00E3;\n\tv532 = *([v525 @ X8_v44+B0]);\n\tv533 = 0;\n\tv534 = v532 + 8;\n\tv536 = *([v574 @ X11_v21-8]);\n\tv580 = v536 == v528;\n\tif (v580) goto L_00DC;\n\tv558 = v575 + 1;\n\tv625 = v558 < v527;\n\tv554 = ~v625;\n\tv556 = v574 + 0x10;\n\tv538 = ~v554;\n\tif (v538) goto L_FFFFFFFF;\n\tv559 = v67;\n\tv560 = 0;\n\tv561 = 0x8909C4(v559, v528, v560, v483, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00E3;\nL_00DC:\n\tv626 = *([v574 @ X11_v21]);\n\tv627 = v626 << 4;\n\tv628 = v525 + v627;\n\tv629 = v628 + 0x130;\nL_00E3:\n\tSystem.IDisposable::Dispose(v64);\n\tgoto L_00EF;\nL_00ED:\n\tgoto L_0152;\nL_00EF:\n\tv664 = v50 == 0;\n\tif (v664) goto L_011F;\nL_00F7:\n\tgoto L_011E;\n\tv701 = *([v668 @ X8_v18+B0]);\n\tv702 = 0;\n\tv703 = v701 + 8;\n\tv705 = *([v742 @ X11_v15-8]);\n\tv748 = v705 == v671;\n\tif (v748) goto L_0117;\n\tv727 = v743 + 1;\n\tv753 = v727 < v670;\n\tv723 = ~v753;\n\tv725 = v742 + 0x10;\n\tv707 = ~v723;\n\tif (v707) goto L_FFFFFFFF;\n\tv728 = v54;\n\tv729 = 0;\n\tv730 = 0x8909C4(v728, v671, v729, v653, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_011E;\nL_0117:\n\tv754 = *([v742 @ X11_v15]);\n\tv755 = v754 << 4;\n\tv756 = v668 + v755;\n\tv757 = v756 + 0x130;\nL_011E:\n\tSystem.IDisposable::Dispose(v50);\nL_011F:\n\tv700 = v147 + 1;\n\tv123 = v700 == 0;\n\tv108 = ~v123;\n\tif (v108) goto L_0132;\n\tv731 = v163 == 0;\n\tv161 = ~v731;\n\tif (v161) goto L_013A;\nL_0132:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_013A:\n\tthrow System.TypeLoadException;\n\tv231 = new System.NullReferenceException();\nL_013D:\n\tv267 = new System.IndexOutOfRangeException();\n\tthrow v267;\nL_0141:\n\tv330 = new System.IndexOutOfRangeException();\n\tthrow v330;\n\tv378 = new System.NullReferenceException();\nL_0147:\n\tv409 = new System.ArrayTypeMismatchException();\n\tthrow v409;\nL_014B:\n\tv447 = new System.ArrayTypeMismatchException();\n\tthrow v447;\nL_0152:\n\tv507 = new System.TypeLoadException();\n\tgoto L_016E;\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_016E;\n\tgoto L_015B;\nL_015B:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016E;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00ED;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_00BC;\nL_016E:\n\tgoto L_0179;\nL_0179:\n\tgoto L_0181;\n\tv530 = UnityEngine.AndroidJavaObject::Call(v507, 0, 0);\n\tv665 = *([v530 @ X0_v9 (UnityEngine.AndroidJavaObject)]);\n\tv563 = UnityEngine.AndroidJavaObject::Call(v530, 0, 0);\n\tv585 = v50 == 0;\n\tv586 = ~v585;\n\tif (v586) goto L_00F7;\n\tgoto L_011F;\nL_0181:\n\tv531 = UnityEngine.AndroidJavaObject::Call(v507, 0, 0);\n\treturn;\n// 218 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void stopTracking(bool isStopTracking)
	{
		//IL_00d5: Expected O, but got I4
		//IL_0335: Expected O, but got I
		//IL_0158: Expected O, but got I4
		//IL_03ee: Expected I, but got O
		//IL_03fb: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X22_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X22_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
		object[] array = new object[2];
		androidJavaClass = (AndroidJavaClass)(object)isStopTracking;
		if (androidJavaClass != null)
		{
			androidJavaClass = (AndroidJavaClass)(androidJavaClass as object);
			if (androidJavaClass == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaClass;
			if (androidJavaObject2 != null)
			{
				androidJavaClass = (AndroidJavaClass)(androidJavaObject2 as object);
				if (androidJavaClass == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj = array.Length;
			}
			bool flag = (long)(IntPtr)obj < 1L;
			bool flag2 = !flag;
			object obj2 = (long)(IntPtr)obj - 1L;
			bool flag3 = obj2 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = androidJavaObject2;
				cls_AppsFlyer.Call("stopTracking", array);
				((IDisposable)androidJavaObject).Dispose();
				int num = 0;
				bool flag5 = androidJavaClass == null;
				IntPtr intPtr3 = (IntPtr)null;
				int num2 = num;
				IntPtr intPtr4 = (IntPtr)null;
				if (!flag5)
				{
					((IDisposable)androidJavaClass).Dispose();
					num2 = num;
					intPtr4 = intPtr3;
				}
				if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
				{
					return;
				}
				throw new TypeLoadException();
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}
		IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
		throw ex4;
	}

	[Token(Token = "0x600001F")]
	[Address(RVA = "0x1665A70", Offset = "0x1665A70", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED4FA0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF88]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = oneLinkID == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), oneLinkID @ X0 (System.String)\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = oneLinkID;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setAppInviteOneLink\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setAppInviteOneLinkID(string oneLinkID)
	{
		object[] array = new object[1];
		if (oneLinkID != null)
		{
			object obj = oneLinkID as object;
		}
		if (array.Length != 0)
		{
			array[0] = oneLinkID;
			cls_AppsFlyer.Call("setAppInviteOneLink", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000020")]
	[Address(RVA = "0x1665B64", Offset = "0x1665B64", Length = "0x4F0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1F03178]);\n\tv39 = *([v38 @ X8_v73]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, callbackObject, callbackMethod, callbackFailedMethod, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202AF89]) = v55;\nL_0020:\n\tv59 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v59, \"com.unity3d.player.UnityPlayer\");\n\tv73 = UnityEngine.AndroidJavaObject::GetStatic(v59, \"currentActivity\");\n\tv81 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003F;\n\tv102 = v81;\n\tv103 = 0x8907BC(v102, v70, v71, callbackFailedMethod, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv106 = *([v81 @ X25_v19 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003F:\n\tv107 = *([v81 @ X25_v19 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv108 = v107 == 0;\n\tif (v108) goto L_0060;\n\tv138 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004C;\n\tv176 = v138;\n\tv177 = 0x8907BC(v176, v70, v71, callbackFailedMethod, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_004C:\n\tv178 = *([v138 @ X25_v25 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv150 = ~v178;\n\tif (v150) goto L_0060;\n\tgoto L_0060;\n\tv264 = v144;\n\tv265 = 0x8907BC(v264, v70, v71, callbackFailedMethod, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0060:\n\tgoto L_006E;\n\tv179 = v87;\n\tv180 = 0x8907BC(v179, v70, v71, callbackFailedMethod, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_006E:\n\tv193 = UnityEngine.AndroidJavaObject::Call(v73, \"getApplication\", v188.Value);\n\tgoto L_007D;\n\tv315 = *([v270 @ X0_v69+E0]);\n\tv316 = v315 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_007D;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v270, v191, v126, v112, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_007D:\n\tv323 = AppsFlyer::ConvertHashMap(parameters);\n\t// 134 NewArr v128 @ X0_v74 (System.Object[]), typeof(System.Object[]), 5\n\tv374 = v193 == 0;\n\tif (v374) goto L_0092;\n\t// 143 IsInst v419 @ X0_v96, typeof(System.Object), v193 @ X0_v68 (UnityEngine.AndroidJavaObject)\n\tv421 = v419 == 0;\n\tif (v421) goto L_0199;\nL_0092:\n\tv466 = v128.Length;\n\tv171 = v128.Length == 0;\n\tif (v171) goto L_017F;\n\tv128[0] = v193;\n\tv426 = v323 == 0;\n\tif (v426) goto L_009F;\n\t// 155 IsInst v526 @ X0_v94, typeof(System.Object), v323 @ X0_v72 (UnityEngine.AndroidJavaObject)\n\tv527 = v526 == 0;\n\tif (v527) goto L_019D;\n\tv466 = v128.Length;\nL_009F:\n\tv529 = v466 < 1;\n\tv293 = ~v529;\n\tv291 = v466 - 1;\n\tv287 = v291 == 0;\n\tv530 = ~v293;\n\tv277 = v530 | v287;\n\tif (v277) goto L_0187;\n\tv128[1] = v323;\n\tv537 = callbackObject == 0;\n\tif (v537) goto L_00B5;\n\t// 177 IsInst v572 @ X0_v92, typeof(System.Object), callbackObject @ X1 (System.String)\n\tv573 = v572 == 0;\n\tif (v573) goto L_01A1;\n\tv466 = v128.Length;\nL_00B5:\n\tv575 = v466 < 2;\n\tv349 = ~v575;\n\tv347 = v466 - 2;\n\tv343 = v347 == 0;\n\tv576 = ~v349;\n\tv333 = v576 | v343;\n\tif (v333) goto L_018B;\n\tv128[2] = callbackObject;\n\tv580 = callbackMethod == 0;\n\tif (v580) goto L_00CB;\n\t// 199 IsInst v612 @ X0_v90, typeof(System.Object), callbackMethod @ X2 (System.String)\n\tv613 = v612 == 0;\n\tif (v613) goto L_01A5;\n\tv466 = v128.Length;\nL_00CB:\n\tv615 = v466 < 3;\n\tv394 = ~v615;\n\tv392 = v466 - 3;\n\tv388 = v392 == 0;\n\tv616 = ~v394;\n\tv378 = v616 | v388;\n\tif (v378) goto L_018F;\n\tv128[3] = callbackMethod;\n\tv620 = callbackFailedMethod == 0;\n\tif (v620) goto L_00E1;\n\t// 221 IsInst v652 @ X0_v88, typeof(System.Object), callbackFailedMethod @ X3 (System.String)\n\tv653 = v652 == 0;\n\tif (v653) goto L_01A9;\n\tv466 = v128.Length;\nL_00E1:\n\tv655 = v466 < 4;\n\tv446 = ~v655;\n\tv444 = v466 - 4;\n\tv440 = v444 == 0;\n\tv656 = ~v446;\n\tv430 = v656 | v440;\n\tif (v430) goto L_0193;\n\tv128[4] = callbackFailedMethod;\n\tUnityEngine.AndroidJavaObject::Call(v134.ShareHelperInstance, \"createOneLinkInviteListener\", v128);\nL_00FF:\n\tgoto L_0126;\n\tv755 = *([v750 @ X8_v51+B0]);\n\tv756 = 0;\n\tv757 = v755 + 8;\n\tv759 = *([v796 @ X11_v25-8]);\n\tv802 = v759 == v753;\n\tif (v802) goto L_011F;\n\tv781 = v797 + 1;\n\tv817 = v781 < v752;\n\tv777 = ~v817;\n\tv779 = v796 + 0x10;\n\tv761 = ~v777;\n\tif (v761) goto L_FFFFFFFF;\n\tv782 = v76;\n\tv783 = 0;\n\tv784 = 0x8909C4(v782, v753, v783, v693, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0126;\nL_011F:\n\tv818 = *([v796 @ X11_v25]);\n\tv819 = v818 << 4;\n\tv820 = v750 + v819;\n\tv821 = v820 + 0x130;\nL_0126:\n\tSystem.IDisposable::Dispose(v73);\n\tgoto L_0132;\nL_0130:\n\tgoto L_01B0;\nL_0132:\n\tv837 = v59 == 0;\n\tif (v837) goto L_0162;\nL_013A:\n\tgoto L_0161;\n\tv943 = *([v869 @ X8_v24+B0]);\n\tv944 = 0;\n\tv945 = v943 + 8;\n\tv947 = *([v984 @ X11_v19-8]);\n\tv990 = v947 == v872;\n\tif (v990) goto L_015A;\n\tv969 = v985 + 1;\n\tv995 = v969 < v871;\n\tv965 = ~v995;\n\tv967 = v984 + 0x10;\n\tv949 = ~v965;\n\tif (v949) goto L_FFFFFFFF;\n\tv970 = v63;\n\tv971 = 0;\n\tv972 = 0x8909C4(v970, v872, v971, v853, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0161;\nL_015A:\n\tv996 = *([v984 @ X11_v19]);\n\tv997 = v996 << 4;\n\tv998 = v869 + v997;\n\tv999 = v998 + 0x130;\nL_0161:\n\tSystem.IDisposable::Dispose(v59);\nL_0162:\n\tv898 = v255 + 1;\n\tv217 = v898 == 0;\n\tv202 = ~v217;\n\tif (v202) goto L_0178;\n\tv973 = v257 == 0;\n\tv251 = ~v973;\n\tif (v251) goto L_0186;\nL_0178:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv136 = new System.NullReferenceException();\nL_017F:\n\tv175 = new System.IndexOutOfRangeException();\n\tthrow v175;\nL_0186:\n\tv263 = new System.TypeLoadException();\nL_0187:\n\tv314 = new System.IndexOutOfRangeException();\n\tthrow v314;\nL_018B:\n\tv370 = new System.IndexOutOfRangeException();\n\tthrow v370;\nL_018F:\n\tv415 = new System.IndexOutOfRangeException();\n\tthrow v415;\nL_0193:\n\tv467 = new System.IndexOutOfRangeException();\n\tthrow v467;\n\tv511 = new System.NullReferenceException();\nL_0199:\n\tv522 = new System.ArrayTypeMismatchException();\n\tthrow v522;\nL_019D:\n\tv568 = new System.ArrayTypeMismatchException();\n\tthrow v568;\nL_01A1:\n\tv608 = new System.ArrayTypeMismatchException();\n\tthrow v608;\nL_01A5:\n\tv648 = new System.ArrayTypeMismatchException();\n\tthrow v648;\nL_01A9:\n\tv687 = new System.ArrayTypeMismatchException();\n\tthrow v687;\nL_01B0:\n\tv748 = new System.TypeLoadException();\n\tgoto L_01CE;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01CE;\n\tgoto L_01BB;\n\tgoto L_01BB;\nL_01BB:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01CE;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0130;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_00FF;\nL_01CE:\n\tgoto L_01D9;\nL_01D9:\n\tgoto L_01E1;\n\tv831 = 0x6D2BC0(v748, 0, 0, 0, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv866 = *([v831 @ X0_v9]);\n\tv839 = 0x6D2490(v831, 0, 0, 0, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv899 = v59 == 0;\n\tv863 = ~v899;\n\tif (v863) goto L_013A;\n\tgoto L_0162;\nL_01E1:\n\tv832 = 0x6D2380(v748, 0, 0, 0, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\treturn;\n// 259 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void generateUserInviteLink(Dictionary<string, string> parameters, string callbackObject, string callbackMethod, string callbackFailedMethod)
	{
		//IL_00f5: Expected O, but got I4
		//IL_04bd: Expected O, but got I
		//IL_051b: Expected O, but got I
		//IL_0178: Expected O, but got I4
		//IL_0579: Expected O, but got I
		//IL_01e1: Expected O, but got I4
		//IL_05d7: Expected O, but got I
		//IL_024a: Expected O, but got I4
		//IL_02b3: Expected O, but got I4
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X25_v19 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X25_v25 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
		AndroidJavaObject androidJavaObject3 = ConvertHashMap(parameters);
		object[] array = new object[5];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			if (androidJavaObject3 != null)
			{
				object obj3 = androidJavaObject3 as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = androidJavaObject3;
				if (callbackObject != null)
				{
					object obj5 = callbackObject as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (flag8 || flag7)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array[2] = callbackObject;
				if (callbackMethod != null)
				{
					object obj7 = callbackMethod as object;
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
					obj2 = array.Length;
				}
				bool flag9 = (long)(IntPtr)obj2 < 3L;
				bool flag10 = !flag9;
				object obj8 = (long)(IntPtr)obj2 - 3L;
				bool flag11 = obj8 == null;
				bool flag12 = !flag10;
				if (flag12 || flag11)
				{
					IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					throw ex6;
				}
				array[3] = callbackMethod;
				if (callbackFailedMethod != null)
				{
					object obj9 = callbackFailedMethod as object;
					if (obj9 == null)
					{
						ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
						throw ex7;
					}
					obj2 = array.Length;
				}
				bool flag13 = (long)(IntPtr)obj2 < 4L;
				bool flag14 = !flag13;
				object obj10 = (long)(IntPtr)obj2 - 4L;
				bool flag15 = obj10 == null;
				bool flag16 = !flag14;
				if (flag16 || flag15)
				{
					IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
					throw ex8;
				}
				array[4] = callbackFailedMethod;
				ShareHelperInstance.Call("createOneLinkInviteListener", array);
				((IDisposable)androidJavaObject).Dispose();
				int num = 0;
				bool flag17 = androidJavaClass == null;
				int num2 = 0;
				int num3 = num;
				int num4 = 0;
				if (!flag17)
				{
					((IDisposable)androidJavaClass).Dispose();
					num3 = num;
					num4 = num2;
				}
				if (num3 + 1 != 0 || num4 == 0)
				{
					return;
				}
				TypeLoadException ex9 = new TypeLoadException();
			}
			IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
			throw ex10;
		}
		IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
		throw ex11;
	}

	[Token(Token = "0x6000021")]
	[Address(RVA = "0x1666054", Offset = "0x1666054", Length = "0x43C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ECEA48]);\n\tv31 = *([v30 @ X8_v62]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, campaign, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202AF8A]) = v49;\nL_001C:\n\tv53 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v53, \"com.unity3d.player.UnityPlayer\");\n\tv67 = UnityEngine.AndroidJavaObject::GetStatic(v53, \"currentActivity\");\n\tv75 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003B;\n\tv96 = v75;\n\tv97 = UnityEngine.AndroidJavaObject::GetStatic(v96, v64, v65);\n\tv100 = *([v75 @ X23_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003B:\n\tv101 = *([v75 @ X23_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv102 = v101 == 0;\n\tif (v102) goto L_005C;\n\tv130 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0048;\n\tv218 = v130;\n\tv219 = UnityEngine.AndroidJavaObject::GetStatic(v218, v64, v65);\nL_0048:\n\tv220 = *([v130 @ X23_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv142 = ~v220;\n\tif (v142) goto L_005C;\n\tgoto L_005C;\n\tv267 = v136;\n\tv268 = UnityEngine.AndroidJavaObject::GetStatic(v267, v64, v65);\nL_005C:\n\tgoto L_006A;\n\tv221 = v81;\n\tv222 = UnityEngine.AndroidJavaObject::GetStatic(v221, v64, v65);\nL_006A:\n\tv263 = UnityEngine.AndroidJavaObject::Call(v67, \"getApplication\", v258.Value);\n\tgoto L_007F;\n\tv317 = *([v273 @ X0_v57 (Il2CppClass<AppsFlyer>)+E0]);\n\tv318 = v317 == 0;\n\tv319 = ~v318;\n\tif (v319) goto L_007F;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v273, v261, v120, v106, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv321 = AppsFlyer;\nL_007F:\n\t// 127 NewArr v122 @ X0_v60 (System.Object[]), typeof(System.Object[]), 3\n\tv370 = v263 == 0;\n\tif (v370) goto L_008B;\n\t// 136 IsInst v377 @ X0_v76, typeof(System.Object), v263 @ X0_v56 (UnityEngine.AndroidJavaObject)\n\tv379 = v377 == 0;\n\tif (v379) goto L_015C;\nL_008B:\n\tv368 = v122.Length;\n\tv248 = v122.Length == 0;\n\tif (v248) goto L_014E;\n\tv122[0] = v263;\n\tv410 = appId == 0;\n\tif (v410) goto L_0098;\n\t// 148 IsInst v441 @ X0_v74, typeof(System.Object), appId @ X0 (System.String)\n\tv442 = v441 == 0;\n\tif (v442) goto L_0160;\n\tv368 = v122.Length;\nL_0098:\n\tv444 = v368 < 1;\n\tv296 = ~v444;\n\tv294 = v368 - 1;\n\tv290 = v294 == 0;\n\tv445 = ~v296;\n\tv280 = v445 | v290;\n\tif (v280) goto L_0152;\n\tv122[1] = appId;\n\tv449 = campaign == 0;\n\tif (v449) goto L_00AE;\n\t// 170 IsInst v480 @ X0_v72, typeof(System.Object), campaign @ X1 (System.String)\n\tv481 = v480 == 0;\n\tif (v481) goto L_0164;\n\tv368 = v122.Length;\nL_00AE:\n\tv483 = v368 < 2;\n\tv349 = ~v483;\n\tv347 = v368 - 2;\n\tv343 = v347 == 0;\n\tv484 = ~v349;\n\tv333 = v484 | v343;\n\tif (v333) goto L_0156;\n\tv122[2] = campaign;\n\tUnityEngine.AndroidJavaObject::CallStatic(v126.cls_AndroidShare, \"trackCrossPromoteImpression\", v122);\nL_00CC:\n\tgoto L_00F3;\n\tv581 = *([v576 @ X8_v44+B0]);\n\tv582 = 0;\n\tv583 = v581 + 8;\n\tv585 = *([v622 @ X11_v22-8]);\n\tv628 = v585 == v579;\n\tif (v628) goto L_00EC;\n\tv607 = v623 + 1;\n\tv643 = v607 < v578;\n\tv603 = ~v643;\n\tv605 = v622 + 0x10;\n\tv587 = ~v603;\n\tif (v587) goto L_FFFFFFFF;\n\tv608 = v70;\n\tv609 = 0;\n\tv610 = 0x8909C4(v608, v579, v609, v520, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00F3;\nL_00EC:\n\tv644 = *([v622 @ X11_v22]);\n\tv645 = v644 << 4;\n\tv646 = v576 + v645;\n\tv647 = v646 + 0x130;\nL_00F3:\n\tSystem.IDisposable::Dispose(v67);\n\tgoto L_00FF;\nL_00FD:\n\tgoto L_016B;\nL_00FF:\n\tv663 = v53 == 0;\n\tif (v663) goto L_012F;\nL_0107:\n\tgoto L_012E;\n\tv764 = *([v694 @ X8_v20+B0]);\n\tv765 = 0;\n\tv766 = v764 + 8;\n\tv768 = *([v805 @ X11_v16-8]);\n\tv811 = v768 == v697;\n\tif (v811) goto L_0127;\n\tv790 = v806 + 1;\n\tv816 = v790 < v696;\n\tv786 = ~v816;\n\tv788 = v805 + 0x10;\n\tv770 = ~v786;\n\tif (v770) goto L_FFFFFFFF;\n\tv791 = v57;\n\tv792 = 0;\n\tv793 = 0x8909C4(v791, v697, v792, v679, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_012E;\nL_0127:\n\tv817 = *([v805 @ X11_v16]);\n\tv818 = v817 << 4;\n\tv819 = v694 + v818;\n\tv820 = v819 + 0x130;\nL_012E:\n\tSystem.IDisposable::Dispose(v53);\nL_012F:\n\tv723 = v209 + 1;\n\tv173 = v723 == 0;\n\tv158 = ~v173;\n\tif (v158) goto L_0143;\n\tv794 = v211 == 0;\n\tv207 = ~v794;\n\tif (v207) goto L_014D;\nL_0143:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_014D:\n\tv217 = new System.TypeLoadException();\nL_014E:\n\tv253 = new System.IndexOutOfRangeException();\n\tthrow v253;\nL_0152:\n\tv316 = new System.IndexOutOfRangeException();\n\tthrow v316;\nL_0156:\n\tv369 = new System.IndexOutOfRangeException();\n\tthrow v369;\n\tv409 = new System.NullReferenceException();\nL_015C:\n\tv437 = new System.ArrayTypeMismatchException();\n\tthrow v437;\nL_0160:\n\tv476 = new System.ArrayTypeMismatchException();\n\tthrow v476;\nL_0164:\n\tv514 = new System.ArrayTypeMismatchException();\n\tthrow v514;\nL_016B:\n\tv574 = new System.TypeLoadException();\n\tgoto L_0187;\n\tgoto L_0174;\n\tgoto L_0174;\n\tgoto L_0174;\n\tgoto L_0174;\n\tgoto L_0174;\n\tgoto L_0187;\n\tgoto L_0174;\nL_0174:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0187;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FD;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_00CC;\nL_0187:\n\tgoto L_0192;\nL_0192:\n\tgoto L_019A;\n\tv657 = UnityEngine.AndroidJavaObject::Call(v574, 0, 0);\n\tv691 = *([v657 @ X0_v9 (UnityEngine.AndroidJavaObject)]);\n\tv665 = UnityEngine.AndroidJavaObject::Call(v657, 0, 0);\n\tv724 = v53 == 0;\n\tv689 = ~v724;\n\tif (v689) goto L_0107;\n\tgoto L_012F;\nL_019A:\n\tv658 = UnityEngine.AndroidJavaObject::Call(v574, 0, 0);\n\treturn;\n// 226 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void trackCrossPromoteImpression(string appId, string campaign)
	{
		//IL_00d5: Expected O, but got I4
		//IL_03b5: Expected O, but got I
		//IL_0413: Expected O, but got I
		//IL_0158: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_04cc: Expected I, but got O
		//IL_04d9: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X23_v15 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X23_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
		object[] array = new object[3];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			if (appId != null)
			{
				object obj3 = appId as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (flag4 || flag3)
			{
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			array[1] = appId;
			if (campaign != null)
			{
				object obj5 = campaign as object;
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
				obj2 = array.Length;
			}
			bool flag5 = (long)(IntPtr)obj2 < 2L;
			bool flag6 = !flag5;
			object obj6 = (long)(IntPtr)obj2 - 2L;
			bool flag7 = obj6 == null;
			bool flag8 = !flag6;
			if (flag8 || flag7)
			{
				IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
				throw ex5;
			}
			array[2] = campaign;
			cls_AndroidShare.CallStatic("trackCrossPromoteImpression", array);
			((IDisposable)androidJavaObject).Dispose();
			int num = 0;
			bool flag9 = androidJavaClass == null;
			IntPtr intPtr3 = (IntPtr)null;
			int num2 = num;
			IntPtr intPtr4 = (IntPtr)null;
			if (!flag9)
			{
				((IDisposable)androidJavaClass).Dispose();
				num2 = num;
				intPtr4 = intPtr3;
			}
			if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
			{
				return;
			}
			TypeLoadException ex6 = new TypeLoadException();
		}
		IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
		throw ex7;
	}

	[Token(Token = "0x6000022")]
	[Address(RVA = "0x1666490", Offset = "0x1666490", Length = "0x4C0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EC58B8]);\n\tv35 = *([v34 @ X8_v73]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, campaign, customParams, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202AF8B]) = v52;\nL_001E:\n\tv56 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v56, \"com.unity3d.player.UnityPlayer\");\n\tv70 = UnityEngine.AndroidJavaObject::GetStatic(v56, \"currentActivity\");\n\tv78 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003D;\n\tv99 = v78;\n\tv100 = 0x8907BC(v99, v67, v68, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv103 = *([v78 @ X24_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003D:\n\tv104 = *([v78 @ X24_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv105 = v104 == 0;\n\tif (v105) goto L_005E;\n\tv135 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004A;\n\tv173 = v135;\n\tv174 = 0x8907BC(v173, v67, v68, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_004A:\n\tv175 = *([v135 @ X24_v23 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv147 = ~v175;\n\tif (v147) goto L_005E;\n\tgoto L_005E;\n\tv261 = v141;\n\tv262 = 0x8907BC(v261, v67, v68, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005E:\n\tgoto L_006C;\n\tv176 = v84;\n\tv177 = 0x8907BC(v176, v67, v68, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006C:\n\tv190 = UnityEngine.AndroidJavaObject::Call(v70, \"getApplication\", v185.Value);\n\tv265 = customParams == 0;\n\tif (v265) goto L_0085;\n\tgoto L_007D;\n\tv329 = *([v309 @ X0_v89+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_007D;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v309, v188, v123, v109, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007D:\n\tv314 = AppsFlyer::ConvertHashMap(customParams);\nL_0085:\n\tgoto L_0092;\n\tv335 = *([v322 @ X0_v64 (Il2CppClass<AppsFlyer>)+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tgoto L_0092;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v322, v188, v123, v109, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv339 = AppsFlyer;\nL_0092:\n\t// 146 NewArr v125 @ X0_v67 (System.Object[]), typeof(System.Object[]), 4\n\tv389 = v190 == 0;\n\tif (v389) goto L_009E;\n\t// 155 IsInst v434 @ X0_v86, typeof(System.Object), v190 @ X0_v62 (UnityEngine.AndroidJavaObject)\n\tv436 = v434 == 0;\n\tif (v436) goto L_018A;\nL_009E:\n\tv429 = v125.Length;\n\tv168 = v125.Length == 0;\n\tif (v168) goto L_0174;\n\tv125[0] = v190;\n\tv441 = promotedAppId == 0;\n\tif (v441) goto L_00AB;\n\t// 167 IsInst v503 @ X0_v84, typeof(System.Object), promotedAppId @ X0 (System.String)\n\tv504 = v503 == 0;\n\tif (v504) goto L_018E;\n\tv429 = v125.Length;\nL_00AB:\n\tv506 = v429 < 1;\n\tv285 = ~v506;\n\tv283 = v429 - 1;\n\tv279 = v283 == 0;\n\tv507 = ~v285;\n\tv269 = v507 | v279;\n\tif (v269) goto L_017C;\n\tv125[1] = promotedAppId;\n\tv511 = campaign == 0;\n\tif (v511) goto L_00C1;\n\t// 189 IsInst v543 @ X0_v82, typeof(System.Object), campaign @ X1 (System.String)\n\tv544 = v543 == 0;\n\tif (v544) goto L_0192;\n\tv429 = v125.Length;\nL_00C1:\n\tv546 = v429 < 2;\n\tv363 = ~v546;\n\tv361 = v429 - 2;\n\tv357 = v361 == 0;\n\tv547 = ~v363;\n\tv347 = v547 | v357;\n\tif (v347) goto L_0180;\n\tv125[2] = campaign;\n\tv551 = v129 == 0;\n\tif (v551) goto L_00D7;\n\t// 211 IsInst v583 @ X0_v80, typeof(System.Object), v129 @ X23_v17 (System.Collections.Generic.Dictionary`2<System.String, System.String>)\n\tv584 = v583 == 0;\n\tif (v584) goto L_0196;\n\tv429 = v125.Length;\nL_00D7:\n\tv586 = v429 < 3;\n\tv409 = ~v586;\n\tv407 = v429 - 3;\n\tv403 = v407 == 0;\n\tv587 = ~v409;\n\tv393 = v587 | v403;\n\tif (v393) goto L_0184;\n\tv125[3] = v129;\n\tUnityEngine.AndroidJavaObject::Call(v131.ShareHelperInstance, \"trackAndOpenStore\", v125);\nL_00F5:\n\tgoto L_011C;\n\tv686 = *([v681 @ X8_v48+B0]);\n\tv687 = 0;\n\tv688 = v686 + 8;\n\tv690 = *([v727 @ X11_v23-8]);\n\tv733 = v690 == v684;\n\tif (v733) goto L_0115;\n\tv712 = v728 + 1;\n\tv748 = v712 < v683;\n\tv708 = ~v748;\n\tv710 = v727 + 0x10;\n\tv692 = ~v708;\n\tif (v692) goto L_FFFFFFFF;\n\tv713 = v73;\n\tv714 = 0;\n\tv715 = 0x8909C4(v713, v684, v714, v624, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_011C;\nL_0115:\n\tv749 = *([v727 @ X11_v23]);\n\tv750 = v749 << 4;\n\tv751 = v681 + v750;\n\tv752 = v751 + 0x130;\nL_011C:\n\tSystem.IDisposable::Dispose(v70);\n\tgoto L_0128;\nL_0126:\n\tgoto L_019D;\nL_0128:\n\tv768 = v56 == 0;\n\tif (v768) goto L_0158;\nL_0130:\n\tgoto L_0157;\n\tv872 = *([v800 @ X8_v22+B0]);\n\tv873 = 0;\n\tv874 = v872 + 8;\n\tv876 = *([v913 @ X11_v17-8]);\n\tv919 = v876 == v803;\n\tif (v919) goto L_0150;\n\tv898 = v914 + 1;\n\tv924 = v898 < v802;\n\tv894 = ~v924;\n\tv896 = v913 + 0x10;\n\tv878 = ~v894;\n\tif (v878) goto L_FFFFFFFF;\n\tv899 = v60;\n\tv900 = 0;\n\tv901 = 0x8909C4(v899, v803, v900, v784, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0157;\nL_0150:\n\tv925 = *([v913 @ X11_v17]);\n\tv926 = v925 << 4;\n\tv927 = v800 + v926;\n\tv928 = v927 + 0x130;\nL_0157:\n\tSystem.IDisposable::Dispose(v56);\nL_0158:\n\tv829 = v250 + 1;\n\tv214 = v829 == 0;\n\tv199 = ~v214;\n\tif (v199) goto L_016D;\n\tv902 = v252 == 0;\n\tv248 = ~v902;\n\tif (v248) goto L_017B;\nL_016D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv133 = new System.NullReferenceException();\nL_0174:\n\tv172 = new System.IndexOutOfRangeException();\n\tthrow v172;\nL_017B:\n\tv260 = new System.TypeLoadException();\nL_017C:\n\tv306 = new System.IndexOutOfRangeException();\n\tthrow v306;\nL_0180:\n\tv384 = new System.IndexOutOfRangeException();\n\tthrow v384;\nL_0184:\n\tv430 = new System.IndexOutOfRangeException();\n\tthrow v430;\n\tv471 = new System.NullReferenceException();\nL_018A:\n\tv499 = new System.ArrayTypeMismatchException();\n\tthrow v499;\nL_018E:\n\tv539 = new System.ArrayTypeMismatchException();\n\tthrow v539;\nL_0192:\n\tv579 = new System.ArrayTypeMismatchException();\n\tthrow v579;\nL_0196:\n\tv618 = new System.ArrayTypeMismatchException();\n\tthrow v618;\nL_019D:\n\tv679 = new System.TypeLoadException();\n\tgoto L_01BB;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01A8;\n\tgoto L_01BB;\n\tgoto L_01A8;\nL_01A8:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01BB;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0126;\n\tX22 = 0xFFFFFFFF;\n\tgoto L_00F5;\nL_01BB:\n\tgoto L_01C6;\nL_01C6:\n\tgoto L_01CE;\n\tv762 = UnityEngine.AndroidJavaObject::Call(v679, 0, 0);\n\tv796 = *([v762 @ X0_v9 (UnityEngine.AndroidJavaObject)]);\n\tv770 = UnityEngine.AndroidJavaObject::Call(v762, 0, 0);\n\tv830 = v56 == 0;\n\tv794 = ~v830;\n\tif (v794) goto L_0130;\n\tgoto L_0158;\nL_01CE:\n\tv763 = UnityEngine.AndroidJavaObject::Call(v679, 0, 0);\n\treturn;\n// 249 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void trackAndOpenStore(string promotedAppId, string campaign, Dictionary<string, string> customParams)
	{
		//IL_0114: Expected O, but got I4
		//IL_047e: Expected O, but got I
		//IL_04dc: Expected O, but got I
		//IL_0197: Expected O, but got I4
		//IL_053a: Expected O, but got I
		//IL_0200: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_05f3: Expected I, but got O
		//IL_0600: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X24_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ X24_v23 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getApplication", Array.Empty<object>());
		bool flag = customParams == null;
		Dictionary<string, string> dictionary = customParams;
		if (!flag)
		{
			AndroidJavaObject androidJavaObject3 = ConvertHashMap(customParams);
			dictionary = (Dictionary<string, string>)(object)androidJavaObject3;
		}
		object[] array = new object[4];
		if (androidJavaObject2 != null)
		{
			object obj = androidJavaObject2 as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject2;
			if (promotedAppId != null)
			{
				object obj3 = promotedAppId as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
				obj2 = array.Length;
			}
			bool flag2 = (long)(IntPtr)obj2 < 1L;
			bool flag3 = !flag2;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag4 = obj4 == null;
			bool flag5 = !flag3;
			if (!(flag5 || flag4))
			{
				array[1] = promotedAppId;
				if (campaign != null)
				{
					object obj5 = campaign as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
					obj2 = array.Length;
				}
				bool flag6 = (long)(IntPtr)obj2 < 2L;
				bool flag7 = !flag6;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag8 = obj6 == null;
				bool flag9 = !flag7;
				if (flag9 || flag8)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array[2] = campaign;
				if (dictionary != null)
				{
					object obj7 = dictionary as object;
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
					obj2 = array.Length;
				}
				bool flag10 = (long)(IntPtr)obj2 < 3L;
				bool flag11 = !flag10;
				object obj8 = (long)(IntPtr)obj2 - 3L;
				bool flag12 = obj8 == null;
				bool flag13 = !flag11;
				if (flag13 || flag12)
				{
					IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					throw ex6;
				}
				array[3] = dictionary;
				ShareHelperInstance.Call("trackAndOpenStore", array);
				((IDisposable)androidJavaObject).Dispose();
				int num = 0;
				bool flag14 = androidJavaClass == null;
				IntPtr intPtr3 = (IntPtr)null;
				int num2 = num;
				IntPtr intPtr4 = (IntPtr)null;
				if (!flag14)
				{
					((IDisposable)androidJavaClass).Dispose();
					num2 = num;
					intPtr4 = intPtr3;
				}
				if (num2 + 1 != 0 || intPtr4 == (IntPtr)0)
				{
					return;
				}
				TypeLoadException ex7 = new TypeLoadException();
			}
			IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
			throw ex8;
		}
		IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
		throw ex9;
	}

	[Token(Token = "0x6000023")]
	[Address(RVA = "0x1666950", Offset = "0x1666950", Length = "0x154")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EAF928]);\n\tv29 = *([v28 @ X8_v25]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, campaign, siteId, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202AF8C]) = v46;\nL_001E:\n\tgoto L_002B;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v49, campaign, siteId, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = AppsFlyer;\nL_002B:\n\t// 43 NewArr v66 @ X0_v5 (System.Object[]), typeof(System.Object[]), 3\n\tv70 = mediaSource == 0;\n\tif (v70) goto L_0037;\n\t// 52 IsInst v112 @ X0_v26, typeof(System.Object), mediaSource @ X0 (System.String)\nL_0037:\n\tv146 = v66.Length;\n\tv119 = v66.Length == 0;\n\tif (v119) goto L_0079;\n\tv66[0] = mediaSource;\n\tv149 = campaign == 0;\n\tif (v149) goto L_0044;\n\t// 64 IsInst v191 @ X0_v24, typeof(System.Object), campaign @ X1 (System.String)\n\tv146 = v66.Length;\nL_0044:\n\tv202 = v146 < 1;\n\tv167 = ~v202;\n\tv165 = v146 - 1;\n\tv161 = v165 == 0;\n\tv203 = ~v167;\n\tv151 = v203 | v161;\n\tif (v151) goto L_0079;\n\tv66[1] = campaign;\n\tv240 = siteId == 0;\n\tif (v240) goto L_005A;\n\t// 86 IsInst v192 @ X0_v22, typeof(System.Object), siteId @ X2 (System.String)\n\tv146 = v66.Length;\nL_005A:\n\tv243 = v146 < 2;\n\tv137 = ~v243;\n\tv135 = v146 - 2;\n\tv131 = v135 == 0;\n\tv244 = ~v137;\n\tv121 = v244 | v131;\n\tif (v121) goto L_0079;\n\tv66[2] = siteId;\n\tUnityEngine.AndroidJavaObject::Call(v61.cls_AppsFlyer, \"setPreinstallAttribution\", v66);\n\treturn;\nL_0079:\n\tv177 = new System.IndexOutOfRangeException();\n\tgoto L_007E;\n\tv199 = new System.ArrayTypeMismatchException();\nL_007E:\n\tthrow v239;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setPreinstallAttribution(string mediaSource, string campaign, string siteId)
	{
		//IL_003e: Expected O, but got I4
		//IL_017c: Expected O, but got I
		//IL_00a8: Expected O, but got I4
		//IL_01da: Expected O, but got I
		//IL_00f8: Expected O, but got I4
		object[] array = new object[3];
		if (mediaSource != null)
		{
			object obj = mediaSource as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = mediaSource;
			if (campaign != null)
			{
				object obj3 = campaign as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = campaign;
				if (siteId != null)
				{
					object obj5 = siteId as object;
					obj2 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj2 < 2L;
				bool flag6 = !flag5;
				object obj6 = (long)(IntPtr)obj2 - 2L;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = siteId;
					cls_AppsFlyer.Call("setPreinstallAttribution", array);
					return;
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000024")]
	[Address(RVA = "0x1666AA4", Offset = "0x1666AA4", Length = "0x110")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EBFAE0]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF8D]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Int32), &seconds @ X0 (System.Int32)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setMinTimeBetweenSessions\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setMinTimeBetweenSessions(int seconds)
	{
		object[] array = new object[1];
		array = (object[])(object)seconds;
		if (array != null)
		{
			array = (object[])(array as object);
		}
		if (array.Length != 0)
		{
			array[0] = array;
			cls_AppsFlyer.Call("setMinTimeBetweenSessions", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000025")]
	[Address(RVA = "0x1666BB4", Offset = "0x1666BB4", Length = "0x120")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EEDA38]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, hostName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202AF8E]) = v43;\nL_001C:\n\tgoto L_0029;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v46, hostName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = AppsFlyer;\nL_0029:\n\t// 41 NewArr v63 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv67 = hostPrefixName == 0;\n\tif (v67) goto L_0035;\n\t// 50 IsInst v109 @ X0_v23, typeof(System.Object), hostPrefixName @ X0 (System.String)\nL_0035:\n\tv143 = v63.Length;\n\tv116 = v63.Length == 0;\n\tif (v116) goto L_0060;\n\tv63[0] = hostPrefixName;\n\tv146 = hostName == 0;\n\tif (v146) goto L_0042;\n\t// 62 IsInst v165 @ X0_v21, typeof(System.Object), hostName @ X1 (System.String)\n\tv143 = v63.Length;\nL_0042:\n\tv173 = v143 < 1;\n\tv134 = ~v173;\n\tv132 = v143 - 1;\n\tv128 = v132 == 0;\n\tv174 = ~v134;\n\tv118 = v174 | v128;\n\tif (v118) goto L_0060;\n\tv63[1] = hostName;\n\tUnityEngine.AndroidJavaObject::Call(v58.cls_AppsFlyer, \"setHost\", v63);\n\treturn;\nL_0060:\n\tv161 = new System.IndexOutOfRangeException();\n\tgoto L_0065;\n\tv170 = new System.ArrayTypeMismatchException();\nL_0065:\n\tthrow v208;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setHost(string hostPrefixName, string hostName)
	{
		//IL_003e: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_00a8: Expected O, but got I4
		object[] array = new object[2];
		if (hostPrefixName != null)
		{
			object obj = hostPrefixName as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = hostPrefixName;
			if (hostName != null)
			{
				object obj3 = hostName as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = hostName;
				cls_AppsFlyer.Call("setHost", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000026")]
	[Address(RVA = "0x1666CD4", Offset = "0x1666CD4", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EA8308]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF8F]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string getHost()
	{
		return "";
	}

	[Token(Token = "0x6000027")]
	[Address(RVA = "0x1666D1C", Offset = "0x1666D1C", Length = "0x1BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F08380]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, userEmails, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202AF90]) = v43;\nL_0019:\n\tv47 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v47, \"com.appsflyer.AppsFlyerProperties$EmailsCryptType\");\n\tv57 = cryptType == 3;\n\tif (v57) goto L_FFFFFFFF;\n\tv66 = cryptType == 2;\n\tif (v66) goto L_FFFFFFFF;\n\tv81 = cryptType != 1;\n\tif (v81) goto L_FFFFFFFF;\n\tgoto L_0057;\n\tgoto L_0057;\n\tgoto L_0057;\nL_0057:\n\tv146 = UnityEngine.AndroidJavaObject::GetStatic(v47, *([v139 @ X8_v7 (System.String)]));\n\tgoto L_006D;\n\tv216 = *([v178 @ X8_v10 (Il2CppClass<AppsFlyer>)+E0]);\n\tv217 = v216 == 0;\n\tv218 = ~v217;\n\tgoto L_006D;\n\tv250 = v178;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v250, v142, v112, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv224 = AppsFlyer;\nL_006D:\n\t// 109 NewArr v229 @ X0_v8 (System.Object[]), typeof(System.Object[]), 2\n\tv251 = v146 == 0;\n\tif (v251) goto L_0079;\n\t// 118 IsInst v163 @ X0_v17, typeof(System.Object), v146 @ X0_v5 (UnityEngine.AndroidJavaObject)\nL_0079:\n\tv122 = v229.Length;\n\tv291 = v229.Length == 0;\n\tif (v291) goto L_00A4;\n\tv229[0] = v146;\n\tv292 = userEmails == 0;\n\tif (v292) goto L_0086;\n\t// 130 IsInst v164 @ X0_v15, typeof(System.Object), userEmails @ X1 (System.String[])\n\tv122 = v229.Length;\nL_0086:\n\tv297 = v122 < 1;\n\tv108 = ~v297;\n\tv106 = v122 - 1;\n\tv102 = v106 == 0;\n\tv298 = ~v108;\n\tv92 = v298 | v102;\n\tif (v92) goto L_00A4;\n\tv229[1] = userEmails;\n\tUnityEngine.AndroidJavaObject::Call(v226.cls_AppsFlyer, \"setUserEmails\", v229);\n\treturn;\nL_00A4:\n\tv206 = new System.IndexOutOfRangeException();\n\tgoto L_00AB;\n\tv126 = new System.NullReferenceException();\n\tv173 = new System.ArrayTypeMismatchException();\nL_00AB:\n\tthrow v205;\n\tthrow System.NullReferenceException;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setUserEmails(EmailCryptType cryptType, params string[] userEmails)
	{
		//IL_00b3: Expected O, but got I4
		//IL_01de: Expected O, but got I
		//IL_011d: Expected O, but got I4
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.appsflyer.AppsFlyerProperties$EmailsCryptType");
		string fieldName;
		switch (cryptType)
		{
		case EmailCryptType.EmailCryptTypeSHA1:
			fieldName = "SHA1";
			break;
		case EmailCryptType.EmailCryptTypeSHA256:
			fieldName = "SHA256";
			break;
		case EmailCryptType.EmailCryptTypeMD5:
			fieldName = "MD5";
			break;
		default:
			fieldName = "NONE";
			break;
		}
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>(fieldName);
		object[] array = new object[2];
		if (androidJavaObject != null)
		{
			object obj = androidJavaObject as object;
		}
		object obj2 = array.Length;
		if (array.Length != 0)
		{
			array[0] = androidJavaObject;
			if (userEmails != null)
			{
				object obj3 = userEmails as object;
				obj2 = array.Length;
			}
			bool flag = (long)(IntPtr)obj2 < 1L;
			bool flag2 = !flag;
			object obj4 = (long)(IntPtr)obj2 - 1L;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = userEmails;
				cls_AppsFlyer.Call("setUserEmails", array);
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000028")]
	[Address(RVA = "0x1666ED8", Offset = "0x1666ED8", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA6898]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF91]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = userEmails == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), userEmails @ X0 (System.String[])\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = userEmails;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setResolveDeepLinkURLs\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setResolveDeepLinkURLs(params string[] userEmails)
	{
		object[] array = new object[1];
		if (userEmails != null)
		{
			object obj = userEmails as object;
		}
		if (array.Length != 0)
		{
			array[0] = userEmails;
			cls_AppsFlyer.Call("setResolveDeepLinkURLs", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000029")]
	[Address(RVA = "0x1666FCC", Offset = "0x1666FCC", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0F528]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202AF92]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<AppsFlyer>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = AppsFlyer;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = domains == 0;\n\tif (v64) goto L_0034;\n\t// 48 IsInst v69 @ X0_v18, typeof(System.Object), domains @ X0 (System.String[])\nL_0034:\n\tv76 = v60.Length == 0;\n\tif (v76) goto L_0048;\n\tv60[0] = domains;\n\tUnityEngine.AndroidJavaObject::Call(v55.cls_AppsFlyer, \"setOneLinkCustomDomain\", v60);\n\treturn;\n\tv65 = new System.NullReferenceException();\nL_0048:\n\tv81 = new System.IndexOutOfRangeException();\n\tgoto L_004F;\n\tv85 = new System.NullReferenceException();\n\tv88 = new System.ArrayTypeMismatchException();\nL_004F:\n\tthrow v102;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void setOneLinkCustomDomain(params string[] domains)
	{
		object[] array = new object[1];
		if (domains != null)
		{
			object obj = domains as object;
		}
		if (array.Length != 0)
		{
			array[0] = domains;
			cls_AppsFlyer.Call("setOneLinkCustomDomain", array);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x600002A")]
	[Address(RVA = "0x16670C0", Offset = "0x16670C0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AppsFlyer()
	{
	}

	[Token(Token = "0x600002B")]
	[Address(RVA = "0x16670C8", Offset = "0x16670C8", Length = "0x2BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EF5DE8]);\n\tv27 = *([v26 @ X8_v54]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202AF93]) = v47;\nL_001A:\n\tv51 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v51, \"com.appsflyer.AppsFlyerLib\");\n\tv61.obj = v51;\n\tv68 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0036;\n\tv73 = v68;\n\tv74 = 0x8907BC(v73, v56, v54, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv77 = *([v68 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0036:\n\tv78 = *([v68 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv79 = v78 == 0;\n\tif (v79) goto L_0057;\n\tv81 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0043;\n\tv103 = v81;\n\tv104 = 0x8907BC(v103, v56, v54, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0043:\n\tv105 = *([v81 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv93 = ~v105;\n\tif (v93) goto L_0057;\n\tgoto L_0057;\n\tv146 = v87;\n\tv147 = 0x8907BC(v146, v56, v54, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0057:\n\tgoto L_0065;\n\tv106 = v98;\n\tv107 = 0x8907BC(v106, v56, v54, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0065:\n\tv122 = UnityEngine.AndroidJavaObject::CallStatic(v65.obj, \"getInstance\", v115.Value);\n\tv151.cls_AppsFlyer = v122;\n\tv153 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v153, \"com.appsflyer.AppsFlyerProperties\");\n\tv190.propertiesClass = v153;\n\tv192 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v192, \"com.appsflyer.AppsFlyerUnityHelper\");\n\tv199.cls_AppsFlyerHelper = v192;\n\tv201 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v201, \"com.appsflyer.UnityShareHelper\");\n\tv206.cls_UnityShareHelper = v201;\n\tv208 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0097;\n\tv213 = v208;\n\tv214 = UnityEngine.AndroidJavaObject::CallStatic(v213, v133, v135, v121);\n\tv217 = *([v208 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0097:\n\tv218 = *([v208 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv219 = v218 == 0;\n\tif (v219) goto L_00B8;\n\tv221 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00A4;\n\tv241 = v221;\n\tv242 = UnityEngine.AndroidJavaObject::CallStatic(v241, v133, v135, v121);\nL_00A4:\n\tv243 = *([v221 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_00B8;\n\tgoto L_00B8;\n\tv254 = v227;\n\tv255 = UnityEngine.AndroidJavaObject::CallStatic(v254, v133, v135, v121);\nL_00B8:\n\tgoto L_00C2;\n\tv244 = v126;\n\tv245 = UnityEngine.AndroidJavaObject::CallStatic(v244, v133, v135, v121);\nL_00C2:\n\tv253 = UnityEngine.AndroidJavaObject::CallStatic(v129.cls_UnityShareHelper, \"getInstance\", v249.Value);\n\tv259.ShareHelperInstance = v253;\n\tv181 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v181, \"com.appsflyer.share.CrossPromotionHelper\");\n\tv184.cls_AndroidShare = v181;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static AppsFlyer()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.appsflyer.AppsFlyerLib");
		obj = androidJavaClass;
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X20_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject androidJavaObject = obj.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		cls_AppsFlyer = androidJavaObject;
		AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.appsflyer.AppsFlyerProperties");
		propertiesClass = androidJavaClass2;
		AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.appsflyer.AppsFlyerUnityHelper");
		cls_AppsFlyerHelper = androidJavaClass3;
		AndroidJavaClass androidJavaClass4 = new AndroidJavaClass("com.appsflyer.UnityShareHelper");
		cls_UnityShareHelper = androidJavaClass4;
		IntPtr intPtr3 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X20_v5 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X20_v9 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		AndroidJavaObject shareHelperInstance = cls_UnityShareHelper.CallStatic<AndroidJavaObject>("getInstance", Array.Empty<object>());
		ShareHelperInstance = shareHelperInstance;
		AndroidJavaClass androidJavaClass5 = new AndroidJavaClass("com.appsflyer.share.CrossPromotionHelper");
		cls_AndroidShare = androidJavaClass5;
	}
}
