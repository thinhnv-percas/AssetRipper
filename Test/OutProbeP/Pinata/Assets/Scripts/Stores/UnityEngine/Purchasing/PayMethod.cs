using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000022")]
	internal class PayMethod
	{
		[Token(Token = "0x6000091")]
		[Address(RVA = "0xC68084", Offset = "0xC68084", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EF0FA0]);\n\tv39 = *([v38 @ X8_v55]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, authGlobal, transactionId, hashKey, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202338A]) = v54;\nL_0023:\n\tgoto L_002D;\n\tv61 = *([v57 @ X0_v2+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_002D;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, authGlobal, transactionId, hashKey, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_002D:\n\tUnityEngine.Debug::Log(\"CloudMoolah PayWebView is being opened\");\n\tv73 = UnityEngine.Application::get_platform();\n\tv83 = v73 != 0xB;\n\tif (v83) goto L_010E;\n\tv87 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v87, \"com.cm.androidforunity.PaymentActivity\");\n\t// 73 NewArr v239 @ X0_v11 (System.Object[]), typeof(System.Object[]), 0\n\tv249 = UnityEngine.AndroidJavaObject::CallStatic(v87, \"instance\", v239);\n\t// 88 NewArr v255 @ X0_v67 (System.Object[]), typeof(System.Object[]), 5\n\tv281 = paymentURL == 0;\n\tif (v281) goto L_0064;\n\t// 97 IsInst v288 @ X0_v83, typeof(System.Object), paymentURL @ X0 (System.String)\n\tv290 = v288 == 0;\n\tif (v290) goto L_0129;\nL_0064:\n\tv535 = v255.Length;\n\tv277 = v255.Length == 0;\n\tif (v277) goto L_0113;\n\tv255[0] = paymentURL;\n\tv324 = authGlobal == 0;\n\tif (v324) goto L_0071;\n\t// 109 IsInst v368 @ X0_v81, typeof(System.Object), authGlobal @ X1 (System.String)\n\tv369 = v368 == 0;\n\tif (v369) goto L_012D;\n\tv535 = v255.Length;\nL_0071:\n\tv371 = v535 < 1;\n\tv314 = ~v371;\n\tv312 = v535 - 1;\n\tv308 = v312 == 0;\n\tv372 = ~v314;\n\tv298 = v372 | v308;\n\tif (v298) goto L_0117;\n\tv255[1] = authGlobal;\n\tv408 = transactionId == 0;\n\tif (v408) goto L_0087;\n\t// 131 IsInst v434 @ X0_v79, typeof(System.Object), transactionId @ X2 (System.String)\n\tv435 = v434 == 0;\n\tif (v435) goto L_0131;\n\tv535 = v255.Length;\nL_0087:\n\tv437 = v535 < 2;\n\tv395 = ~v437;\n\tv393 = v535 - 2;\n\tv389 = v393 == 0;\n\tv438 = ~v395;\n\tv379 = v438 | v389;\n\tif (v379) goto L_011B;\n\tv255[2] = transactionId;\n\tv474 = hashKey == 0;\n\tif (v474) goto L_009D;\n\t// 153 IsInst v500 @ X0_v77, typeof(System.Object), hashKey @ X3 (System.String)\n\tv501 = v500 == 0;\n\tif (v501) goto L_0135;\n\tv535 = v255.Length;\nL_009D:\n\tv503 = v535 < 3;\n\tv461 = ~v503;\n\tv459 = v535 - 3;\n\tv455 = v459 == 0;\n\tv504 = ~v461;\n\tv445 = v504 | v455;\n\tif (v445) goto L_011F;\n\tv255[3] = hashKey;\n\tv540 = customID == 0;\n\tif (v540) goto L_00B3;\n\t// 175 IsInst v566 @ X0_v75, typeof(System.Object), customID @ X4 (System.String)\n\tv567 = v566 == 0;\n\tif (v567) goto L_0139;\n\tv535 = v255.Length;\nL_00B3:\n\tv569 = v535 < 4;\n\tv527 = ~v569;\n\tv525 = v535 - 4;\n\tv521 = v525 == 0;\n\tv570 = ~v527;\n\tv511 = v570 | v521;\n\tif (v511) goto L_0123;\n\tv255[4] = customID;\n\tUnityEngine.AndroidJavaObject::Call(v249, \"JavaShowPayWebView\", v255);\nL_00D1:\n\tgoto L_00F8;\n\tv650 = *([v645 @ X8_v15+B0]);\n\tv651 = 0;\n\tv652 = v650 + 8;\n\tv654 = *([v683 @ X11_v7-8]);\n\tv697 = v654 == v648;\n\tif (v697) goto L_00F1;\n\tv656 = v682 + 1;\n\tv703 = v656 < v647;\n\tv676 = ~v703;\n\tv658 = v683 + 0x10;\n\tv660 = ~v676;\n\tif (v660) goto L_FFFFFFFF;\n\tv677 = v166;\n\tv678 = 0;\n\tv679 = 0x8909C4(v677, v648, v678, v109, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00F8;\nL_00F1:\n\tv704 = *([v683 @ X11_v7]);\n\tv705 = v704 << 4;\n\tv706 = v645 + v705;\n\tv707 = v706 + 0x130;\nL_00F8:\n\tSystem.IDisposable::Dispose(v87);\n\tv155 = v158 + 1;\n\tv137 = v155 == 0;\n\tv122 = ~v137;\n\tif (v122) goto L_010E;\nL_0100:\n\tv717 = v160 == 0;\n\tv154 = ~v717;\n\tif (v154) goto L_0140;\nL_010E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv267 = new System.NullReferenceException();\nL_0113:\n\tv280 = new System.IndexOutOfRangeException();\n\tthrow v280;\nL_0117:\n\tv323 = new System.IndexOutOfRangeException();\n\tthrow v323;\nL_011B:\n\tv404 = new System.IndexOutOfRangeException();\n\tthrow v404;\nL_011F:\n\tv470 = new System.IndexOutOfRangeException();\n\tthrow v470;\nL_0123:\n\tv536 = new System.IndexOutOfRangeException();\n\tthrow v536;\n\tv359 = new System.NullReferenceException();\nL_0129:\n\tv364 = new System.ArrayTypeMismatchException();\n\tthrow v364;\nL_012D:\n\tv430 = new System.ArrayTypeMismatchException();\n\tthrow v430;\nL_0131:\n\tv496 = new System.ArrayTypeMismatchException();\n\tthrow v496;\nL_0135:\n\tv562 = new System.ArrayTypeMismatchException();\n\tthrow v562;\nL_0139:\n\tv595 = new System.ArrayTypeMismatchException();\n\tthrow v595;\nL_0140:\n\tv620 = new System.TypeLoadException();\n\tgoto L_0152;\n\tgoto L_0152;\n\tgoto L_0152;\n\tgoto L_0152;\n\tgoto L_0152;\n\tgoto L_0152;\n\tgoto L_0152;\nL_0152:\n\tgoto L_015A;\n\tv702 = 0x6D2BC0(v620, 0, 0, v193, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv160 = *([v702 @ X0_v23]);\n\tv638 = 0x6D2490(v702, 0, 0, v193, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv640 = v87 == 0;\n\tif (v640) goto L_0100;\n\tgoto L_00D1;\nL_015A:\n\tv221 = 0x6D2380(v620, 0, 0, v193, customID, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\treturn;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void showPayWebView(string paymentURL, string authGlobal, string transactionId, string hashKey, string customID)
		{
			//IL_00e4: Expected O, but got I4
			//IL_045c: Expected O, but got I
			//IL_04ba: Expected O, but got I
			//IL_016c: Expected O, but got I4
			//IL_0518: Expected O, but got I
			//IL_01da: Expected O, but got I4
			//IL_0576: Expected O, but got I
			//IL_0248: Expected O, but got I4
			//IL_02e9: Expected I, but got O
			//IL_02b6: Expected O, but got I4
			Debug.Log("CloudMoolah PayWebView is being opened");
			RuntimePlatform platform = Application.platform;
			if (platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.cm.androidforunity.PaymentActivity");
			object[] args = new object[0];
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("instance", args);
			object[] array = new object[5];
			if (paymentURL != null)
			{
				object obj = paymentURL as object;
				bool flag = obj == null;
				IntPtr intPtr = (IntPtr)0;
				if (flag)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = paymentURL;
				if (authGlobal != null)
				{
					object obj3 = authGlobal as object;
					bool flag2 = obj3 == null;
					IntPtr intPtr = (IntPtr)0;
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
					array[1] = authGlobal;
					if (transactionId != null)
					{
						object obj5 = transactionId as object;
						bool flag7 = obj5 == null;
						IntPtr intPtr = (IntPtr)0;
						if (flag7)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
						obj2 = array.Length;
					}
					bool flag8 = (long)(IntPtr)obj2 < 2L;
					bool flag9 = !flag8;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag10 = obj6 == null;
					bool flag11 = !flag9;
					if (!(flag11 || flag10))
					{
						array[2] = transactionId;
						if (hashKey != null)
						{
							object obj7 = hashKey as object;
							bool flag12 = obj7 == null;
							IntPtr intPtr = (IntPtr)0;
							if (flag12)
							{
								ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
								throw ex4;
							}
							obj2 = array.Length;
						}
						bool flag13 = (long)(IntPtr)obj2 < 3L;
						bool flag14 = !flag13;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag15 = obj8 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[3] = hashKey;
							if (customID != null)
							{
								object obj9 = customID as object;
								bool flag17 = obj9 == null;
								IntPtr intPtr = (IntPtr)0;
								if (flag17)
								{
									ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
									throw ex5;
								}
								obj2 = array.Length;
							}
							bool flag18 = (long)(IntPtr)obj2 < 4L;
							bool flag19 = !flag18;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag20 = obj10 == null;
							bool flag21 = !flag19;
							if (!(flag21 || flag20))
							{
								array[4] = customID;
								androidJavaObject.Call("JavaShowPayWebView", array);
								IntPtr intPtr = (IntPtr)null;
								int num = 0;
								int num2 = 0;
								((IDisposable)androidJavaClass).Dispose();
								if (num + 1 == 0 && num2 != 0)
								{
									TypeLoadException ex6 = new TypeLoadException();
									Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
								}
								return;
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
				IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
				throw ex10;
			}
			IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
			throw ex11;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0xC672D0", Offset = "0xC672D0", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF5910]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202338B]) = v41;\nL_0015:\n\tv43 = UnityEngine.Application::get_platform();\n\tv54 = v43 != 0xB;\n\tif (v54) goto L_008F;\n\tv58 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v58, \"com.cm.androidforunity.PaymentActivity\");\n\t// 48 NewArr v199 @ X0_v9 (System.Object[]), typeof(System.Object[]), 0\n\tv209 = UnityEngine.AndroidJavaObject::CallStatic(v58, \"instance\", v199);\n\t// 63 NewArr v215 @ X0_v32 (System.Object[]), typeof(System.Object[]), 0\n\tv250 = UnityEngine.AndroidJavaObject::Call(v209, \"getDeviceID\", v215);\nL_0054:\n\tgoto L_007B;\n\tv286 = *([v280 @ X8_v9+B0]);\n\tv287 = 0;\n\tv288 = v286 + 8;\n\tv290 = *([v318 @ X11_v7-8]);\n\tv332 = v290 == v283;\n\tif (v332) goto L_0074;\n\tv292 = v317 + 1;\n\tv337 = v292 < v282;\n\tv312 = ~v337;\n\tv294 = v318 + 0x10;\n\tv296 = ~v312;\n\tif (v296) goto L_FFFFFFFF;\n\tv313 = v134;\n\tv314 = 0;\n\tv315 = 0x8909C4(v313, v283, v314, v80, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_007B;\nL_0074:\n\tv338 = *([v318 @ X11_v7]);\n\tv339 = v338 << 4;\n\tv340 = v280 + v339;\n\tv341 = v340 + 0x130;\nL_007B:\n\tSystem.IDisposable::Dispose(v58);\n\tv129 = v77 + 1;\n\tv114 = v129 == 0;\n\tv96 = ~v114;\n\tif (v96) goto L_008F;\nL_0083:\n\tv351 = v86 == 0;\n\tv128 = ~v351;\n\tif (v128) goto L_0097;\nL_008F:\n\treturn v97;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0097:\n\tv242 = new System.TypeLoadException();\n\tgoto L_00A5;\n\tgoto L_00A5;\n\tgoto L_00A5;\nL_00A5:\n\tgoto L_00AE;\n\tv285 = UnityEngine.AndroidJavaObject::Call(v242, 0, 0);\n\tv86 = *([v285 @ X0_v21 (System.String)]);\n\tv275 = UnityEngine.AndroidJavaObject::Call(v285, 0, 0);\n\tv277 = v58 == 0;\n\tif (v277) goto L_0083;\n\tgoto L_0054;\nL_00AE:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v242, 0, 0);\n\treturn returnVal2;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string getDeviceID()
		{
			//IL_007a: Expected I, but got O
			RuntimePlatform platform = Application.platform;
			bool flag = platform != RuntimePlatform.Android;
			string result = null;
			if (!flag)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.cm.androidforunity.PaymentActivity");
				object[] args = new object[0];
				AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("instance", args);
				object[] args2 = new object[0];
				string text = androidJavaObject.Call<string>("getDeviceID", args2);
				int num = 0;
				IntPtr intPtr = (IntPtr)null;
				result = text;
				((IDisposable)androidJavaClass).Dispose();
				if (num + 1 == 0)
				{
					if (intPtr != (IntPtr)0)
					{
						TypeLoadException ex = new TypeLoadException();
						return ((AndroidJavaObject)(object)ex).Call<string>((string)null, (object[])null);
					}
					result = null;
				}
			}
			return result;
		}
	}
}
