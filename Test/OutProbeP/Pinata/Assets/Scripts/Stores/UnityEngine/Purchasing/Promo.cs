using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.MiniJSON;
using UnityEngine.Scripting;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200006E")]
	public class Promo
	{
		[Token(Token = "0x4000185")]
		private static JSONStore s_PromoPurchaser = null;

		[Token(Token = "0x4000186")]
		private static IStoreCallback s_Unity = null;

		[Token(Token = "0x4000187")]
		private static RuntimePlatform s_RuntimePlatform;

		[Token(Token = "0x4000188")]
		private static ILogger s_Logger;

		[Token(Token = "0x4000189")]
		private static string s_Version;

		[Token(Token = "0x400018A")]
		private static IUtil s_Util;

		[Token(Token = "0x400018B")]
		private static IAsyncWebUtil s_WebUtil;

		[Token(Token = "0x400018C")]
		private static bool s_IsReady = false;

		[Token(Token = "0x400018D")]
		private static string s_ProductJSON;

		[Preserve]
		[Token(Token = "0x60001C8")]
		[Address(RVA = "0xC6C530", Offset = "0xC6C530", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC0758]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20233A0]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = UnityEngine.Purchasing.Promo;\nL_0024:\n\treturn v49.s_IsReady;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsReady()
		{
			return s_IsReady;
		}

		[Preserve]
		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xC6C144", Offset = "0xC6C144", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBCAB8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20233A1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = UnityEngine.Purchasing.Promo;\nL_0024:\n\treturn v49.s_Version;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string Version()
		{
			return s_Version;
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0xC6C598", Offset = "0xC6C598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Promo()
		{
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xC6C5A0", Offset = "0xC6C5A0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED3B20]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, logger, util, webUtil, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20233A2]) = v47;\nL_001F:\n\tgoto L_0034;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0034;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, logger, util, webUtil, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0034:\n\tUnityEngine.Purchasing.Promo::InitPromo(platform, logger, \"Unknown\", util, webUtil);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void InitPromo(RuntimePlatform platform, ILogger logger, IUtil util, IAsyncWebUtil webUtil)
		{
			InitPromo(platform, logger, "Unknown", util, webUtil);
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xC6C638", Offset = "0xC6C638", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EA75B8]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, logger, version, util, webUtil, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20233A3]) = v50;\nL_0021:\n\tgoto L_0029;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0029;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v53, logger, version, util, webUtil, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = UnityEngine.Purchasing.Promo;\nL_0029:\n\tv64.s_RuntimePlatform = platform;\n\tv65 = logger == 0;\n\tif (v65) goto L_0055;\n\tgoto L_0037;\n\tv74 = *([v60 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0037;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v60, logger, version, util, webUtil, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv78 = UnityEngine.Purchasing.Promo;\nL_0037:\n\tv81.s_Logger = logger;\n\tgoto L_0043;\n\tv91 = *([v77 @ X0_v8 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tgoto L_0043;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v77, logger, version, util, webUtil, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv95 = UnityEngine.Purchasing.Promo;\nL_0043:\n\tv98.s_Version = version;\n\tv99.s_Util = util;\n\tv100.s_WebUtil = webUtil;\n\treturn;\nL_0055:\n\tv73 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v73, \"UnityIAP: Promo initialized with null logger!\");\n\tthrow v73;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void InitPromo(RuntimePlatform platform, ILogger logger, string version, IUtil util, IAsyncWebUtil webUtil)
		{
			s_RuntimePlatform = platform;
			if (logger == null)
			{
				ArgumentException ex = new ArgumentException("UnityIAP: Promo initialized with null logger!");
				throw ex;
			}
			s_Logger = logger;
			s_Version = version;
			s_Util = util;
			s_WebUtil = webUtil;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xC6C758", Offset = "0xC6C758", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE7CB8]);\n\tv23 = *([v22 @ X8_v53]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20233A4]) = v43;\nL_001B:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = UnityEngine.Purchasing.Promo;\nL_0024:\n\tv59 = v57.s_Unity == 0;\n\tif (v59) goto L_00A4;\n\tgoto L_003A;\n\tv123 = *([v53 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_003A;\n\tv284 = UnityEngine.Purchasing.Promo;\n\tv131 = *([v284 @ X8_v48 (Il2CppClass<UnityEngine.Purchasing.Promo>)+B8]);\n\tv132 = v131.s_Unity;\nL_003A:\n\tgoto L_0061;\n\tv148 = *([v134 @ X8_v21+B0]);\n\tv149 = 0;\n\tv150 = v148 + 8;\n\tv152 = *([v296 @ X11_v22-8]);\n\tv301 = v152 == v136;\n\tif (v301) goto L_005A;\n\tv172 = v295 + 1;\n\tv362 = v172 < v135;\n\tv170 = ~v362;\n\tv174 = v296 + 0x10;\n\tv154 = ~v170;\n\tif (v154) goto L_FFFFFFFF;\n\tv175 = v119;\n\tv176 = 0;\n\tv177 = 0x8909C4(v175, v136, v176, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0061;\nL_005A:\n\tv363 = *([v296 @ X11_v22]);\n\tv364 = v363 << 4;\n\tv365 = v134 + v364;\n\tv366 = v365 + 0x130;\nL_0061:\n\tv370 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(v57.s_Unity);\n\tv115 = v370 == 0;\n\tif (v115) goto L_00A4;\n\treturnVal1 = new System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>::.ctor(returnVal1);\n\tgoto L_0080;\n\tv543 = *([v510 @ X0_v30 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv544 = v543 == 0;\n\tv545 = ~v544;\n\t// 117 ConditionalJump @b64, v545 @ TEMP_v45\n\tv549 = \"il2cpp_codegen_runtime_class_init\"(v510, v256, v71, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv546 = UnityEngine.Purchasing.Promo;\nL_0080:\n\tgoto L_00EF;\n\tv554 = *([v550 @ X8_v31+B0]);\n\tv555 = 0;\n\tv556 = v554 + 8;\n\tv558 = *([v595 @ X11_v17-8]);\n\tv600 = v558 == v551;\n\tif (v600) goto L_00E8;\n\tv578 = v594 + 1;\n\tv605 = v578 < v552;\n\tv576 = ~v605;\n\tv580 = v595 + 0x10;\n\tv560 = ~v576;\n\tif (v560) goto L_FFFFFFFF;\n\tv581 = v200;\n\tv582 = 0;\n\tv583 = 0x8909C4(v581, v551, v582, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00EF;\nL_00A4:\n\tgoto L_00AC;\n\tv138 = *([v112 @ X0_v7 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tgoto L_00AC;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v112, v105, v70, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv142 = UnityEngine.Purchasing.Promo;\nL_00AC:\n\tv146 = v145.s_Logger;\n\tv181 = *([v146 @ X19_v7 (UnityEngine.ILogger)]);\n\tv190 = *([v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v190) goto L_00D9;\n\tv382 = *([v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_00C4:\n\tv387 = *([v382 @ X11_v8-8]) == UnityEngine.ILogger;\n\tif (v387) goto L_00DC;\n\tv381 = v381 + 1;\n\tv425 = v381 < *([v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv328 = ~v425;\n\tv382 = v382 + 0x10;\n\tv312 = ~v328;\n\tif (v312) goto L_00C4;\nL_00D9:\n\tv446 = 0x8909C4(v146, UnityEngine.ILogger, 7, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00E5;\nL_00DC:\n\tv427 = *([v382 @ X11_v8]) + 7;\n\tv428 = v427 << 4;\n\tv429 = v181 + v428;\n\tv446 = v429 + 0x130;\nL_00E5:\n\t*([v446 @ X0_v9])(v453, v146, \"UnityIAP Promo\", \"Trying to update list without manager or products ready\", *([v446 @ X0_v9+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0154;\nL_00E8:\n\tv606 = *([v595 @ X11_v17]);\n\tv607 = v606 << 4;\n\tv608 = v550 + v607;\n\tv609 = v608 + 0x130;\nL_00EF:\n\tv262 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(v280.s_Unity);\n\tv260 = v262.m_Products;\n\tv418 = v260.Length;\n\tv624 = v260.Length < 1;\n\tif (v624) goto L_013D;\nL_0105:\n\tv651 = v194 < v418;\n\tv245 = ~v651;\n\tif (v245) goto L_0157;\n\tv201 = v260[v194 @ X22_v8 (System.Int32)];\n\tv655 = ~v201.<availableToPurchase>k__BackingField;\n\tif (v655) goto L_0129;\n\tv277 = v201.<definition>k__BackingField;\n\tv665 = v277.<type>k__BackingField == 0;\n\tif (v665) goto L_0128;\n\tv660 = System.String::IsNullOrEmpty(v201.<transactionID>k__BackingField);\n\tv661 = v660 == 0;\n\tif (v661) goto L_0129;\nL_0128:\n\tv659 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>::Add(returnVal1, v260[v194 @ X22_v8 (System.Int32)]);\nL_0129:\n\tv418 = v260.Length;\n\tv194 = v194 + 1;\n\tv629 = v194 < v260.Length;\n\tif (v629) goto L_0105;\nL_013D:\n\tv486 = returnVal1._count < 0;\n\tv484 = returnVal1._count == 0;\n\tv480 = returnVal1._count ^ returnVal1._count;\n\tv478 = returnVal1._count & v480;\n\tv476 = v478 < 0;\n\tv653 = v486 == v476;\n\tv467 = ~v484;\n\tv474 = v653 & v467;\n\tv464 = ~v474;\n\tif (v464) goto L_FFFFFFFF;\n\tgoto L_0154;\nL_0154:\n\treturn returnVal1;\n\tv361 = new System.NullReferenceException();\nL_0157:\n\tv420 = new System.IndexOutOfRangeException();\n\tthrow v420;\n\treturn returnVal2;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static HashSet<Product> UpdatePromoProductList()
		{
			//IL_0030: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_010f: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_00b7: Expected O, but got I
			HashSet<Product> hashSet;
			if (s_Unity != null)
			{
				ProductCollection products = s_Unity.products;
				if (products != null)
				{
					hashSet = new HashSet<Product>();
					ProductCollection products2 = s_Unity.products;
					Product[] all = products2.all;
					int num = all.Length;
					if (all.Length >= 1)
					{
						int num2 = 0;
						do
						{
							if (num2 < num)
							{
								Product product = all[num2];
								if (product.availableToPurchase)
								{
									ProductDefinition definition = product.definition;
									if (definition.type == ProductType.Consumable || string.IsNullOrEmpty(product.transactionID))
									{
										bool flag = hashSet.Add(all[num2]);
									}
								}
								num = all.Length;
								num2++;
								continue;
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						while (num2 < all.Length);
					}
					bool flag2 = hashSet.Count < 0;
					bool flag3 = hashSet.Count == 0;
					int num3 = hashSet.Count ^ hashSet.Count;
					int num4 = hashSet.Count & num3;
					bool flag4 = num4 < 0;
					bool flag5 = flag2 == flag4;
					bool flag6 = !flag3;
					if (!(flag5 && flag6))
					{
						hashSet = null;
					}
					goto IL_03ed;
				}
			}
			ILogger logger = s_Logger;
			IntPtr intPtr = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00d0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X8_v12 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag7 = (long)num6 < 0L;
				bool flag8 = !flag7;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_00d0;
			}
			object obj2 = obj + 7;
			int num7 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num7;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_03ad;
			IL_03ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ X0_v9] (should have been resolved before IL gen)");
			hashSet = null;
			goto IL_03ed;
			IL_00d0:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_03ad;
			IL_03ed:
			return hashSet;
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xC59238", Offset = "0xC59238", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F0FDC8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, manager, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20233A5]) = v41;\nL_0019:\n\tv46 = purchaser == 0;\n\tif (v46) goto L_0036;\n\tv47 = manager == 0;\n\tif (v47) goto L_0036;\n\tgoto L_0027;\n\tv63 = *([v44 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0027;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v44, manager, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv67 = UnityEngine.Purchasing.Promo;\nL_0027:\n\tv70.s_PromoPurchaser = purchaser;\n\tv72.s_Unity = manager;\n\tv73 = UnityEngine.Purchasing.Promo::UpdatePromoProductList();\n\tUnityEngine.Purchasing.Promo::ProvideProductsToAds(v73);\n\treturn;\nL_0036:\n\tgoto L_003E;\n\tv53 = *([v44 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_003E;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v44, manager, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv57 = UnityEngine.Purchasing.Promo;\nL_003E:\n\tv61 = v60.s_Logger;\n\tv77 = *([v61 @ X19_v2 (UnityEngine.ILogger)]);\n\tv86 = *([v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v86) goto L_006B;\n\tv146 = *([v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0056:\n\tv152 = *([v146 @ X11_v5-8]) == UnityEngine.ILogger;\n\tif (v152) goto L_006E;\n\tv147 = v147 + 1;\n\tv211 = v147 < *([v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv126 = ~v211;\n\tv146 = v146 + 0x10;\n\tv102 = ~v126;\n\tif (v102) goto L_0056;\nL_006B:\n\tv218 = 0x8909C4(v61, UnityEngine.ILogger, 7, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0072;\nL_006E:\n\tv213 = *([v146 @ X11_v5]) + 7;\n\tv214 = v213 << 4;\n\tv215 = v77 + v214;\n\tv218 = v215 + 0x130;\nL_0072:\n\tv160 = *([v218 @ X0_v6]);\n\tv158 = *([v218 @ X0_v6+8]);\n\t// 125 IndirectJump v160 @ X4_v1, v61 @ X19_v2 (UnityEngine.ILogger), v61 @ X19_v2 (UnityEngine.ILogger), \"UnityIAP Promo\", \"Attempt to set promo products without a valid purchaser!\", v158 @ X3_v1, v160 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ProvideProductsToAds(JSONStore purchaser, IStoreCallback manager)
		{
			//IL_0034: Expected I, but got O
			//IL_01b9: Expected O, but got I
			//IL_006f: Expected O, but got I
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_0113: Expected O, but got I
			//IL_0122: Expected O, but got I
			//IL_00bb: Expected O, but got I
			if (purchaser != null && manager != null)
			{
				s_PromoPurchaser = purchaser;
				s_Unity = manager;
				HashSet<Product> productsForAds = UpdatePromoProductList();
				ProvideProductsToAds(productsForAds);
				return;
			}
			ILogger logger = s_Logger;
			IntPtr intPtr = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00d4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X8_v6 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00d4;
			}
			object obj2 = obj + 7;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_01a1;
			IL_00d4:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_01a1;
			IL_01a1:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v160 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xC6CA78", Offset = "0xC6CA78", Length = "0x5F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EE5D40]);\n\tv35 = *([v34 @ X8_v85]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20233A6]) = v54;\nL_0022:\n\tv62 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::.ctor(v62);\n\tv67 = productsForAds == 0;\n\tif (v67) goto L_00C6;\n\tv74 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>::GetEnumerator(productsForAds);\nL_0040:\n\tv142 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::MoveNext(&v73 @ stack_-A0_v6 (System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tv263 = v142 == 0;\n\tif (v263) goto L_010D;\n\tv352 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v352);\n\tv103 = *([v82 @ stack_-90+10]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"productId\", *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]));\n\tv103 = *([v82 @ stack_-90+10]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"iapProductId\", *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]));\n\tv103 = *([v82 @ stack_-90+10]);\n\tv103 = *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+20]);\n\t// 106 Box v697 @ X0_v95, typeof(UnityEngine.Purchasing.ProductType), &v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)\n\tv103 = *([v697 @ X0_v95]);\n\tv216 = *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+160]);\n\t*([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+160])(v758, v697, *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+168]), *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]), Il2CppMethodInfo, v40, v41, v42, v43, v73, v45, v46, v47, v48, v49, v50, v51);\n\tv760 = \"il2cpp_vm_object_unbox\"(v697, *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+168]), *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]), Il2CppMethodInfo, v40, v41, v42, v43, v73, v45, v46, v47, v48, v49, v50, v51);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"productType\", v758);\n\tv103 = *([v82 @ stack_-90+18]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"localizedPriceString\", *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]));\n\tv103 = *([v82 @ stack_-90+18]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"localizedTitle\", *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+18]));\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"imageUrl\", 0);\n\tv103 = *([v82 @ stack_-90+18]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"isoCurrencyCode\", *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+28]));\n\tv103 = *([v82 @ stack_-90+18]);\n\tv216 = *([v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+30]);\n\t// 175 Box v896 @ X0_v106 (System.Object), typeof(System.Decimal), &v216 @ X9_v8 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v352, \"localizedPrice\", v896);\n\tv135 = v62 == 0;\n\tif (v135) goto L_0124;\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::Add(v62, v352);\n\tgoto L_0040;\nL_00C6:\n\tgoto L_00DD;\n\tv96 = *([v77 @ X0_v36 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\t// 202 ConditionalJump @b116, v98 @ TEMP_v31\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v77, v66, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv100 = UnityEngine.Purchasing.Promo;\nL_00DD:\n\tgoto L_0107;\n\tv264 = *([v146 @ X8_v33+B0]);\n\tv265 = 0;\n\tv266 = v264 + 8;\n\tv268 = *([v368 @ X11_v17-8]);\n\tv374 = v268 == v148;\n\tif (v374) goto L_00FD;\n\tv290 = v369 + 1;\n\tv441 = v290 < v153;\n\tv286 = ~v441;\n\tv288 = v368 + 0x10;\n\tv270 = ~v286;\n\tif (v270) goto L_FFFFFFFF;\n\tv291 = 5;\n\tv292 = v104;\n\tv293 = 0x8909C4(v292, v148, v291, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0107;\nL_00FD:\n\tv442 = *([v368 @ X11_v17]);\n\tv443 = v442 + 5;\n\tv444 = v443 << 4;\n\tv445 = v146 + v444;\n\tv446 = v445 + 0x130;\nL_0107:\n\tUnityEngine.ILogger::Log(v103.s_Logger, \"UnityIAP Promo\", \"Clearing promo product metadata\");\n\tgoto L_0158;\nL_010D:\n\tv357 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::Dispose(&v73 @ stack_-A0_v6 (System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tgoto L_0158;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0124:\n\tv431 = new System.NullReferenceException();\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\nL_0149:\n\tv383 = v429 != 1;\n\tif (v383) goto L_01E9;\n\tv883 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v431, v429, v431);\n\tv886 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v883, v429, v431);\n\tv504 = System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>::Dispose(&v73 @ stack_-A0_v6 (System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.Product>+Enumerator<UnityEngine.Purchasing.Product>));\n\tv891 = *([v883 @ X0_v59]) == 0;\n\tv506 = ~v891;\n\tif (v506) goto L_01ED;\nL_0158:\n\tv525 = UnityEngine.Purchasing.MiniJSON.Json::Serialize(v62);\n\tgoto L_0169;\n\tv615 = *([v531 @ X8_v12 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv616 = v615 == 0;\n\tv617 = ~v616;\n\tif (v617) goto L_0169;\n\tv631 = v531;\n\tv619 = \"il2cpp_codegen_runtime_class_init\"(v631, v246, v222, v219, v40, v41, v42, v43, v240, v45, v46, v47, v48, v49, v50, v51);\n\tv621 = UnityEngine.Purchasing.Promo;\nL_0169:\n\tv216.s_ProductJSON = v525;\n\tv165 = v62._size < 1;\n\tif (v165) goto L_01E6;\n\tgoto L_0188;\n\tv672 = *([v258 @ X8_v13 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv673 = v672 == 0;\n\tv674 = ~v673;\n\tif (v674) goto L_0188;\n\tv704 = v258;\n\tv677 = \"il2cpp_codegen_runtime_class_init\"(v704, v246, v222, v219, v40, v41, v42, v43, v240, v45, v46, v47, v48, v49, v50, v51);\n\tv680 = UnityEngine.Purchasing.Promo;\nL_0188:\n\tv216.s_IsReady = 1;\n\tv685 = v62._size;\n\tv260 = v103.s_Logger;\n\tv686 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(&v685 @ X9_v14 (System.Int32), 0, v222);\n\tv248 = System.String::Concat(\"UnityIAP: Promo interface is available for \", v686, \" items\");\n\tv749 = *([v260 @ X19_v9 (UnityEngine.ILogger)]);\n\tv753 = *([v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v753) goto L_01BF;\n\tv839 = *([v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_01AA:\n\tv845 = *([v839 @ X11_v11-8]) == UnityEngine.ILogger;\n\tif (v845) goto L_01C1;\n\tv840 = v840 + 1;\n\tv858 = v840 < *([v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv801 = ~v858;\n\tv839 = v839 + 0x10;\n\tv785 = ~v801;\n\tif (v785) goto L_01AA;\nL_01BF:\n\tv865 = 0x8909C4(v260, UnityEngine.ILogger, 4, 0, \n// ... truncated")]
		private unsafe static void ProvideProductsToAds(HashSet<Product> productsForAds)
		{
			//IL_04ce: Expected I, but got O
			//IL_0055: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_050f: Expected O, but got I
			//IL_050f: Expected O, but got I4
			//IL_031b: Expected I, but got O
			//IL_00c3: Expected I, but got O
			//IL_055d: Expected I, but got O
			//IL_0356: Expected O, but got I
			//IL_0132: Expected O, but got I
			//IL_0161: Expected O, but got I
			//IL_03d7: Expected I, but got O
			//IL_0412: Expected O, but got I
			//IL_03a2: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_01d2: Expected O, but got I
			//IL_02c4: Expected I, but got O
			List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
			IntPtr intPtr3 = default(IntPtr);
			IntPtr intPtr2;
			IntPtr intPtr;
			if (productsForAds != null)
			{
				HashSet<Product>.Enumerator enumerator = productsForAds.GetEnumerator();
				HashSet<Product>.Enumerator enumerator2 = default(HashSet<Product>.Enumerator);
				object value = default(object);
				string text = default(string);
				object obj2 = default(object);
				NullReferenceException ex2 = default(NullReferenceException);
				string key = default(string);
				NullReferenceException value3 = default(NullReferenceException);
				while (true)
				{
					HashSet<Product>.Enumerator enumerator3;
					if (enumerator2.MoveNext())
					{
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+10]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]");
						dictionary.Add("productId", 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+10]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]");
						dictionary.Add("iapProductId", 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+10]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+20]");
						intPtr = (IntPtr)0;
						object obj = (ProductType)(long)intPtr;
						intPtr = (IntPtr)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+160]");
						intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+160] (should have been resolved before IL gen)");
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						dictionary.Add("productType", value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+18]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+10]");
						dictionary.Add("localizedPriceString", 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+18]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+18]");
						dictionary.Add("localizedTitle", 0);
						dictionary.Add("imageUrl", null);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+18]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+28]");
						dictionary.Add("isoCurrencyCode", 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ stack_-90+18]");
						intPtr = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X8_v32 (Il2CppStaticFields<UnityEngine.Purchasing.Promo>)+30]");
						intPtr2 = (IntPtr)0;
						object value2 = (decimal)(long)intPtr2;
						dictionary.Add("localizedPrice", value2);
						if (list != null)
						{
							list.Add(dictionary);
							intPtr3 = (IntPtr)0;
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						if ((IntPtr)text == (IntPtr)1)
						{
							((Dictionary<string, object>)(object)ex).Add(text, (object)ex);
							((Dictionary<string, object>)obj2).Add(text, (object)ex);
							enumerator2.Dispose();
							bool flag = obj2 == null;
							bool flag2 = !flag;
							intPtr3 = (IntPtr)ex;
							enumerator3 = enumerator2;
							if (!flag2)
							{
								break;
							}
						}
						else
						{
							((Dictionary<string, object>)(object)ex2).Add(key, (object)value3);
						}
						throw new TypeLoadException();
					}
					enumerator2.Dispose();
					enumerator3 = enumerator2;
					break;
				}
			}
			else
			{
				s_Logger.Log("UnityIAP Promo", "Clearing promo product metadata");
				intPtr3 = (IntPtr)"Clearing promo product metadata";
			}
			string text2 = Json.Serialize(list);
			s_ProductJSON = text2;
			if (list.Count < 1)
			{
				return;
			}
			s_IsReady = true;
			int count = list.Count;
			ILogger logger = s_Logger;
			((Dictionary<string, object>)count).Add(null, (long)intPtr3);
			string text4 = default(string);
			string text3 = "UnityIAP: Promo interface is available for " + text4 + " items";
			IntPtr intPtr4 = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj3 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ X8_v20 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_03bb;
			}
			intPtr2 = (IntPtr)obj3;
			intPtr2 = (IntPtr)(void*)((long)intPtr2 + 4L);
			int num3 = (int)((long)intPtr2 << 4);
			intPtr = (IntPtr)(void*)((long)intPtr4 + (long)num3);
			object obj4 = (long)intPtr + 304L;
			goto IL_0555;
			IL_0555:
			intPtr = (IntPtr)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v865 @ X0_v23] (should have been resolved before IL gen)");
			EventQueue eventQueue = EventQueue.Instance(s_Util, s_WebUtil);
			bool flag5 = eventQueue.SendEvent(EventDestType.AdsIPC, "{\"type\":\"CatalogUpdated\"}");
			return;
			IL_03bb:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0555;
		}

		[Preserve]
		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xC6D070", Offset = "0xC6D070", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC73E8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20233A7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = UnityEngine.Purchasing.Promo;\nL_0024:\n\treturn v49.s_ProductJSON;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string QueryPromoProducts()
		{
			return s_ProductJSON;
		}

		[Preserve]
		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xC6D0D8", Offset = "0xC6D0D8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDBBB8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20233A8]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = UnityEngine.Purchasing.Promo::InitiatePurchasingCommand(itemRequest);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool InitiatePromoPurchase(string itemRequest)
		{
			return InitiatePurchasingCommand(itemRequest);
		}

		[Preserve]
		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xC6D13C", Offset = "0xC6D13C", Length = "0xA7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = &v15 @ X29;\n\tgoto L_001B;\n\tv27 = *([1ED24F8]);\n\tv28 = *([v27 @ X8_v184]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20233A9]) = v47;\nL_001B:\n\t*([v15 @ X29-38]) = 0;\n\t*([v15 @ X29-50]) = 0;\n\t*([v15 @ X29-48]) = 0;\n\tv50 = System.String::IsNullOrEmpty(command);\n\tv52 = v50 == 0;\n\tif (v52) goto L_006B;\n\tgoto L_0030;\n\tv62 = *([v55 @ X0_v174 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0030;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v55, v49, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv66 = UnityEngine.Purchasing.Promo;\nL_0030:\n\tv248 = v69.s_Logger;\n\tv71 = v69.s_Logger == 0;\n\tif (v71) goto L_FFFFFFFF;\n\tv76 = *([v65 @ X0_v175 (Il2CppClass<UnityEngine.Purchasing.Promo>)+12F]) & 2;\n\tv77 = v76 == 0;\n\tif (v77) goto L_003E;\n\tv270 = *([v65 @ X0_v175 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]) == 0;\n\tif (v270) goto L_00CB;\nL_003E:\n\t// 62 NewArr v277 @ X0_v184 (System.Object[]), typeof(System.Object[]), 0\nL_0041:\n\tv525 = *([v248 @ X19_v29 (UnityEngine.ILogger)]);\n\tv230 = *([v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v230) goto L_0067;\n\tv726 = *([v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_004D:\n\t;\n\tv731 = *([v726 @ X11_v45-8]) == UnityEngine.ILogger;\n\tif (v731) goto L_00B1;\n\tv725 = v725 + 1;\n\tv900 = v725 < *([v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv597 = ~v900;\n\tv726 = v726 + 0x10;\n\tv581 = ~v597;\n\tif (v581) goto L_004D;\nL_0067:\n\tv907 = 0x8909C4(v248, UnityEngine.ILogger, 8, v32, v81, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00BB;\nL_006B:\n\tv61 = UnityEngine.Purchasing.MiniJSON.Json::Deserialize(command);\n\tv73 = v61 == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv412 = v412_asT == 0;\n\tif (v412) goto L_035C;\n\tv766 = &v15 @ X29 - 0x48;\n\tv475 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v61, \"purchaseTrackingUrls\", v766);\n\tv532 = v475 == 0;\n\tif (v532) goto L_0155;\n\tv884 = *([v15 @ X29-48]);\n\tv606 = *([v15 @ X29-48]) == 0;\n\tif (v606) goto L_0152;\n\tv877 = *([v884 @ X8_v158 (System.Int32)]);\n\tv739 = System.Collections.Generic.List`1<System.Object>;\n\tv742 = *([v877 @ X10_v51 (Il2CppClass<System.String>)+128]) < *([v739 @ X9_v67 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+128]);\n\tv743 = ~v742;\n\tif (v743) goto L_00DA;\n\tgoto L_00F2;\nL_00B1:\n\tv902 = *([v726 @ X11_v45]) + 8;\n\tv903 = v902 << 4;\n\tv904 = v525 + v903;\n\tv907 = v904 + 0x130;\nL_00BB:\n\t*([v907 @ X0_v177])(v224, v248, 2, \"Promo received null or empty command\", v218, *([v907 @ X0_v177+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00BD:\n\treturnVal1 = v380 & 1;\n\treturn returnVal1;\nL_00CB:\n\t;\n\tv248 = v512.s_Logger;\n\t// 210 NewArr v516 @ X0_v187 (System.Object[]), typeof(System.Object[]), 0\n\tv574 = v512.s_Logger == 0;\n\tv522 = ~v574;\n\tif (v522) goto L_0041;\n\tthrow System.NullReferenceException;\nL_00DA:\n\tv887 = *([v739 @ X9_v67 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+128]) << 3;\n\tv888 = *([v877 @ X10_v51 (Il2CppClass<System.String>)+C8]) + v887;\n\tv899 = *([v888 @ X10_v53-8]) != System.Collections.Generic.List`1<System.Object>;\n\tif (v899) goto L_FFFFFFFF;\n\tgoto L_00F2;\nL_00F2:\n\tgoto L_00FC;\n\tv998 = *([v952 @ X0_v7 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv999 = v998 == 0;\n\tv1000 = ~v999;\n\tgoto L_00FC;\n\tv1052 = \"il2cpp_codegen_runtime_class_init\"(v952, v947, v766, v759, v751, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv1002 = UnityEngine.Purchasing.Promo;\nL_00FC:\n\tv801 = UnityEngine.Purchasing.EventQueue::Instance(v853.s_Util, v853.s_WebUtil);\n\tv768 = *([v757 @ X22_v3 (System.Int32)+18]) <= 0;\n\tif (v768) goto L_0152;\n\tv1195 = *([v757 @ X22_v3 (System.Int32)+10]);\n\tv1280 = *([v1195 @ X8_v9+20]);\n\tv804 = *([v1195 @ X8_v9+20]) == 0;\n\tif (v804) goto L_0126;\n\tv1271 = *([v1280 @ X8_v11 (System.String)]) != System.String;\n\tif (v1271) goto L_FFFFFFFF;\n\tgoto L_0126;\nL_0126:\n\tv801.EventUrl = v1280;\n\tv767 = *([v757 @ X22_v3 (System.Int32)+18]) <= 1;\n\tif (v767) goto L_0152;\n\tv1338 = *([v757 @ X22_v3 (System.Int32)+10]);\n\tv807 = *([v1338 @ X8_v13+28]);\n\tv802 = *([v1338 @ X8_v13+28]) == 0;\n\tif (v802) goto L_014C;\n\tv1392 = *([v807 @ X8_v15 (System.String)]) != System.String;\n\tif (v1392) goto L_FFFFFFFF;\n\tgoto L_014C;\nL_014C:\n\tv801.TrackingUrl = v807;\nL_0152:\n\tv635 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Remove(v363, *([v642 @ X19_v5 (System.String)]));\nL_0155:\n\tv645 = UnityEngine.Purchasing.MiniJSON.Json::Serialize(v363);\n\tv108 = *([v111 @ X23_v20 (Il2CppMethodInfo)]);\n\tv304 = &v15 @ X29 - 0x38;\n\tv815 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v363, \"request\", v304);\n\tv912 = v815 == 0;\n\tif (v912) goto L_01A3;\n\tv501 = *([v15 @ X29-38]);\n\tv545 = *([v501 @ X0_v90 (System.String)]) != System.String;\n\tif (v545) goto L_035E;\n\tv137 = *([v501 @ X0_v90 (System.String)]) != System.String;\n\tif (v137) goto L_035F;\n\tv1108 = System.String::ToLower(v501);\n\tv1157 = v1108 == 0;\n\tif (v1157) goto L_023F;\n\tv1200 = System.String::op_Equality(v1108, \"purchase\");\n\tv1287 = v1200 == 0;\n\tif (v1287) goto L_01B2;\n\tgoto L_019A;\n\tv1395 = *([v1342 @ X0_v159+E0]);\n\tv1396 = v1395 == 0;\n\tv1397 = ~v1396;\n\tif (v1397) goto L_019A;\n\tv1399 = \"il2cpp_codegen_runtime_class_init\"(v1342, v358, v303, v106, v80, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_019A:\n\tv367 = UnityEngine.Purchasing.Promo::ExecPromoPurchase(v645);\n\tgoto L_00BD;\nL_01A3:\n\tgoto L_01AA;\n\tv1008 = *([v958 @ X0_v85+E0]);\n\tv1009 = v1008 == 0;\n\tv1010 = ~v1009;\n\tif (v1010) goto L_01AA;\n\tv1012 = \"il2cpp_codegen_runtime_class_init\"(v958, v359, v304, v106, v80, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_01AA:\n\tv368 = UnityEngine.Purchasing.Promo::ExecPromoPurchase(v645);\n\tgoto L_00BD;\nL_01B2:\n\tv1351 = System.String::op_Equality(v1108, \"setids\");\n\tv1403 = v1351 == 0;\n\tif (v1403) goto L_01ED;\n\tgoto L_01C5;\n\tv1424 = *([v1417 @ X0_v126 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv1425 = v1424 == 0;\n\tv1426 = ~v1425;\n\tif (v1426) goto L_01C5;\n\tv1444 = \"il2cpp_codegen_runtime_class_init\"(v1417, v1348, v1350, v106, v80, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv1428 = UnityEngine.Purchasing.Promo;\nL_01C5:\n\tv1433 = UnityEngine.Purchasing.ProfileData::Instance(v1431.s_Util);\n\tv1027 = &v15 @ X29 - 0x50;\n\tv1043 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v363, \"gamerToken\", v1027);\n\tv1494 = v1043 == 0;\n\tif (v1494) goto L_029F;\n\tv1560 = *([v15 @ X29-50]);\n\tv1616 = *([v15 @ X29-50]) == 0;\n\tif (v1616) goto L_FFFFFFFF;\n\tv1646 = *([v1560 @ X8_v150 (System.String)]) != System.String;\n\tif (v1646) goto L_FFFFFFFF;\n\tgoto L_01E7;\nL_01E7:\n\tgoto L_0297;\nL_01ED:\n\tv1204 = System.String::op_Equality(v1108, \"close\");\n\tv1206 = v1204 == 0;\n\tif (v1206) goto L_023F;\n\tgoto L_01FF;\n\tv1495 = *([v1448 @ X0_v114 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv1496 = v1495 == 0;\n\tv1497 = ~v1496;\n\tif (v1497) goto L_01FF;\n\tv1566 = \"il2cpp_codegen_runtime_class_init\"(v1448, v1202, v1201, v106, v80, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv1499 = UnityEngine.Purchasing.Promo;\nL_01FF:\n\tv1596 = v1502.s_Logger;\n\tv1504 = v1502.s_Logger == 0;\n\tif (v1504) goto L_FFFFFFFF;\n\tv1568 = *([v1498 @ X0_v115 (Il2CppClass<UnityEngine.Purchasing.Promo>)+12F]) & 2;\n\tv1569 = v1568 == 0;\n\tif (v1569) goto L_0211;\n\tv1620 = *([v1498 @ X0_v115 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]) == 0;\n\tv1621 = ~v1620;\n\tif (v1621) goto L_0211;\n\tv1596 = v1375.s_Logger;\n\tv1372 = v1375.s_Logger == 0;\n\tif (v1372) goto L_0370;\nL_0211:\n\tv1626 = *([v1596 @ X20_v32 (UnityEngine.ILogger)]);\n\tv1599 = *([v1626 @ X8_v102 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v1599) goto L_0237;\n\tv1732 = *([v1626 @ X8_v102 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_0222:\n\tv1737 = *([v1732 @ X11_v36-8]) == UnityEngine.ILogger;\n\tif (v1737) goto L_0350;\n\tv1731 = v1731 + 1;\n\tv1774 = v1731 < *([v1626 @ X8_v102 (Il2CppClass<UnityEng\n// ... truncated")]
		public unsafe static bool InitiatePurchasingCommand(string command)
		{
			//IL_0f44: Expected O, but got I4
			//IL_001b: Expected I, but got O
			//IL_0f6c: Expected I, but got O
			//IL_00a9: Expected O, but got I
			//IL_062b: Expected O, but got I4
			//IL_0540: Expected O, but got I
			//IL_022d: Expected I, but got O
			//IL_0360: Expected O, but got I
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Expected O, but got Unknown
			//IL_02cb: Expected O, but got I
			//IL_02da: Expected O, but got I
			//IL_00f5: Expected O, but got I
			//IL_03e8: Expected O, but got I
			//IL_03f8: Expected O, but got I
			//IL_060c: Expected O, but got I4
			//IL_0466: Expected O, but got I
			//IL_0476: Expected O, but got I
			//IL_0897: Expected I, but got O
			//IL_071f: Expected I, but got O
			//IL_08d2: Expected O, but got I
			//IL_1248: Expected O, but got I4
			//IL_0674: Expected O, but got I
			//IL_09cd: Expected O, but got I
			//IL_0962: Unknown result type (might be due to invalid IL or missing references)
			//IL_0967: Expected O, but got Unknown
			//IL_0984: Expected O, but got I
			//IL_07c4: Expected I, but got O
			//IL_0a5d: Expected O, but got I
			//IL_091e: Expected O, but got I
			//IL_0b00: Expected O, but got I
			//IL_09fb: Expected I4, but got O
			//IL_07ff: Expected O, but got I
			//IL_06d3: Expected O, but got I
			//IL_0b2e: Expected I4, but got O
			//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bc6: Expected O, but got Unknown
			//IL_0be3: Expected O, but got I
			//IL_125b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1260: Expected I4, but got Unknown
			//IL_1278: Expected O, but got I4
			//IL_0abc: Expected O, but got I
			//IL_084b: Expected O, but got I
			//IL_0e90: Expected O, but got I4
			//IL_0b97: Expected O, but got I4
			//IL_0e0a: Expected O, but got I4
			//IL_0e0a: Expected O, but got I4
			//IL_0e2f: Expected O, but got I4
			//IL_0e3d: Expected O, but got I4
			//IL_0e54: Expected O, but got I4
			//IL_0e65: Expected O, but got I4
			//IL_0cbf: Expected O, but got I4
			//IL_0d03: Expected I, but got O
			//IL_0d3e: Expected O, but got I
			//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dc5: Expected O, but got Unknown
			//IL_0de2: Expected O, but got I
			//IL_0df1: Expected O, but got I
			//IL_0d8a: Expected O, but got I
			object obj = obj;
			_ = 0;
			_ = 0;
			_ = 0;
			ILogger logger;
			IntPtr intPtr2;
			object obj3;
			string text4;
			object obj7;
			IntPtr intPtr6;
			if (string.IsNullOrEmpty(command))
			{
				IntPtr intPtr = (IntPtr)typeof(Promo);
				logger = s_Logger;
				if (s_Logger != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X0_v175 (Il2CppClass<UnityEngine.Purchasing.Promo>)+12F]");
					ILogger logger2;
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X0_v175 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							logger = s_Logger;
							object[] array = new object[0];
							bool flag = s_Logger == null;
							bool flag2 = !flag;
							logger2 = (ILogger)(object)array;
							if (!flag2)
							{
								throw new NullReferenceException();
							}
							goto IL_0f64;
						}
					}
					object[] array2 = new object[0];
					logger2 = (ILogger)(object)array2;
					goto IL_0f64;
				}
			}
			else
			{
				object obj2 = Json.Deserialize(command);
				if (obj2 != null)
				{
					Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
					if (dictionary != null)
					{
						bool flag3 = ((Dictionary<string, object>)obj2).TryGetValue("purchaseTrackingUrls", out *(object*)((long)(IntPtr)obj - 72L));
						bool flag4 = !flag3;
						intPtr2 = (IntPtr)0;
						obj3 = obj2;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-48]");
							int num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-48]");
							bool flag5 = (IntPtr)0 == (IntPtr)0;
							intPtr2 = (IntPtr)0;
							obj3 = obj2;
							string key = "purchaseTrackingUrls";
							if (!flag5)
							{
								IntPtr intPtr3 = (IntPtr)num;
								IntPtr intPtr4 = (IntPtr)typeof(List<object>);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ X10_v51 (Il2CppClass<System.String>)+128]");
								IntPtr intPtr5 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ X9_v67 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+128]");
								bool flag6 = (long)intPtr5 < 0L;
								bool flag7 = !flag6;
								intPtr2 = (IntPtr)0;
								obj3 = obj2;
								key = "purchaseTrackingUrls";
								if (!flag7)
								{
									int num2 = 0;
									intPtr2 = (IntPtr)0;
									obj3 = obj2;
									key = "purchaseTrackingUrls";
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ X9_v67 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+128]");
									int num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v877 @ X10_v51 (Il2CppClass<System.String>)+C8]");
									object obj4 = 0L + (long)num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ X10_v53-8]");
									if ((IntPtr)0 == (IntPtr)typeof(List<object>))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-48]");
										int num2 = 0;
									}
									else
									{
										int num2 = 0;
									}
								}
								EventQueue eventQueue = EventQueue.Instance(s_Util, s_WebUtil);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X22_v3 (System.Int32)+18]");
								if (0L > 0L)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X22_v3 (System.Int32)+10]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1195 @ X8_v9+20]");
									string text = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1195 @ X8_v9+20]");
									if ((IntPtr)0 != (IntPtr)0 && (object)text.GetType() != typeof(string))
									{
										text = null;
									}
									eventQueue.EventUrl = text;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X22_v3 (System.Int32)+18]");
									if (0L > 1L)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X22_v3 (System.Int32)+10]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ X8_v13+28]");
										string text2 = (string)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ X8_v13+28]");
										if ((IntPtr)0 != (IntPtr)0 && (object)text2.GetType() != typeof(string))
										{
											text2 = null;
										}
										eventQueue.TrackingUrl = text2;
									}
								}
							}
							bool flag8 = ((Dictionary<string, object>)obj3).Remove(key);
						}
						string itemRequest = Json.Serialize(obj3);
						intPtr6 = intPtr2;
						if (((Dictionary<string, object>)obj3).TryGetValue("request", out *(object*)((long)(IntPtr)obj - 56L)))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-38]");
							string text3 = (string)0;
							if ((object)text3.GetType() != typeof(string))
							{
								goto IL_0c13;
							}
							if ((object)text3.GetType() != typeof(string))
							{
								goto IL_0c21;
							}
							text4 = text3.ToLower();
							if (text4 == null)
							{
								goto IL_1103;
							}
							switch (text4)
							{
							case "purchase":
								break;
							case "close":
								goto IL_0711;
							case "setids":
								goto IL_1004;
							default:
								goto IL_1103;
							}
							bool flag9 = ExecPromoPurchase(itemRequest);
							obj7 = flag9;
						}
						else
						{
							bool flag10 = ExecPromoPurchase(itemRequest);
							obj7 = flag10;
						}
						goto IL_0ff0;
					}
					InvalidCastException ex = new InvalidCastException();
					NullReferenceException ex2 = new NullReferenceException();
					goto IL_0c13;
				}
			}
			goto IL_0f3b;
			IL_1103:
			ILogger logger3 = s_Logger;
			if (s_Logger == null)
			{
				goto IL_0f3b;
			}
			string text5 = "Unknown request received: " + text4;
			IntPtr intPtr7 = (IntPtr)logger3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1437 @ X8_v81 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0937;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1437 @ X8_v81 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj8 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ X11_v29-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1437 @ X8_v81 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag11 = (long)num5 < 0L;
				bool flag12 = !flag11;
				obj8 = (long)(IntPtr)obj8 + 16L;
				if (!flag12)
				{
					continue;
				}
				goto IL_0937;
			}
			object obj9 = obj8 + 6;
			int num6 = (int)((long)(IntPtr)obj9 << 4);
			object obj10 = (long)intPtr7 + (long)num6;
			bool flag13 = (byte)((ulong)(long)(IntPtr)obj10 + 304uL) != 0;
			goto IL_116b;
			IL_0864:
			ILogger logger4;
			bool flag14 = ((Dictionary<string, object>)logger4).TryGetValue((string)(object)typeof(ILogger), out *(object*)4);
			goto IL_10f4;
			IL_10f4:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1781.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_123f;
			IL_0711:
			IntPtr intPtr8 = (IntPtr)typeof(Promo);
			logger4 = s_Logger;
			if (s_Logger != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1498 @ X0_v115 (Il2CppClass<UnityEngine.Purchasing.Promo>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1498 @ X0_v115 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						logger4 = s_Logger;
						bool flag15 = s_Logger == null;
						ref object value = ref *(object*)null;
						string key2 = "close";
						if (flag15)
						{
							NullReferenceException ex3 = new NullReferenceException();
							bool flag16 = (IntPtr)"close" != (IntPtr)1;
							NullReferenceException ex4 = ex3;
							if (!flag16)
							{
								bool flag17 = ((Dictionary<string, object>)(object)ex3).TryGetValue("close", out *(object*)null);
								bool value2 = ((bool*)(flag17 ? 1 : 0))->m_value;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj11 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj11 & 1uL) != 0)
								{
									bool flag18 = ((Dictionary<string, object>)obj11).TryGetValue((string)((bool*)(value2 ? 1 : 0))->m_value, out value);
									ILogger logger5 = s_Logger;
									if (s_Logger == null)
									{
										goto IL_0f3b;
									}
									string text6;
									if (value2)
									{
										bool value3 = ((bool*)(value2 ? 1 : 0))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1825 @ X8_v45 (System.Boolean)+160] (should have been resolved before IL gen)");
										string text7 = default(string);
										text6 = text7;
									}
									else
									{
										text6 = null;
									}
									string text8 = "Exception while processing incoming request: " + text6 + "\n" + (string)(object)typeof(Promo);
									IntPtr intPtr9 = (IntPtr)logger5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1854 @ X8_v41 (Il2CppClass<UnityEngine.ILogger>)+126]");
									if ((IntPtr)0 == (IntPtr)0)
									{
										goto IL_0da3;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1854 @ X8_v41 (Il2CppClass<UnityEngine.ILogger>)+B0]");
									object obj12 = 0L + 8L;
									int num7 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1909 @ X11_v10-8]");
										if ((IntPtr)0 == (IntPtr)typeof(ILogger))
										{
											break;
										}
										num7++;
										int num8 = num7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1854 @ X8_v41 (Il2CppClass<UnityEngine.ILogger>)+126]");
										bool flag19 = (long)num8 < 0L;
										bool flag20 = !flag19;
										obj12 = (long)(IntPtr)obj12 + 16L;
										if (!flag20)
										{
											continue;
										}
										goto IL_0da3;
									}
									object obj13 = obj12 + 7;
									int num9 = (int)((long)(IntPtr)obj13 << 4);
									object obj14 = (long)intPtr9 + (long)num9;
									object obj15 = (long)(IntPtr)obj14 + 304L;
									goto IL_133f;
								}
								bool flag21 = ((Dictionary<string, object>)8).TryGetValue((string)((bool*)(value2 ? 1 : 0))->m_value, out *(object*)null);
								((bool*)(flag21 ? 1 : 0))->m_value = ((bool*)(flag17 ? 1 : 0))->m_value;
								key2 = (string)(32022528 + 2160);
								bool flag22 = ((Dictionary<string, object>)flag21).TryGetValue(key2, out *(object*)null);
								bool flag23 = ((Dictionary<string, object>)flag22).TryGetValue(key2, out *(object*)null);
								value = ref *(object*)null;
								ex4 = (NullReferenceException)flag22;
							}
							bool flag24 = ((Dictionary<string, object>)(object)ex4).TryGetValue(key2, out value);
							return ((Dictionary<string, object>)flag24).TryGetValue(key2, out value);
						}
					}
				}
				IntPtr intPtr10 = (IntPtr)logger4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1626 @ X8_v102 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0864;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1626 @ X8_v102 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj16 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1732 @ X11_v36-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1626 @ X8_v102 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag25 = (long)num11 < 0L;
					bool flag26 = !flag25;
					obj16 = (long)(IntPtr)obj16 + 16L;
					if (!flag26)
					{
						continue;
					}
					goto IL_0864;
				}
				object obj17 = obj16 + 4;
				int num12 = (int)((long)(IntPtr)obj17 << 4);
				object obj18 = (long)intPtr10 + (long)num12;
				flag14 = (byte)((ulong)(long)(IntPtr)obj18 + 304uL) != 0;
				goto IL_10f4;
			}
			goto IL_123f;
			IL_123f:
			obj7 = 1;
			goto IL_0ff0;
			IL_0f64:
			IntPtr intPtr11 = (IntPtr)logger;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_010e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+B0]");
			object obj19 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X11_v45-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILogger))
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v171 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag27 = (long)num14 < 0L;
				bool flag28 = !flag27;
				obj19 = (long)(IntPtr)obj19 + 16L;
				if (!flag28)
				{
					continue;
				}
				goto IL_010e;
			}
			object obj20 = obj19 + 8;
			int num15 = (int)((long)(IntPtr)obj20 << 4);
			object obj21 = (long)intPtr11 + (long)num15;
			object obj22 = (long)(IntPtr)obj21 + 304L;
			goto IL_0f2c;
			IL_0f3b:
			obj7 = 0;
			goto IL_0ff0;
			IL_0f2c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v907 @ X0_v177] (should have been resolved before IL gen)");
			goto IL_0f3b;
			IL_0ff0:
			return (byte)((ulong)(long)(IntPtr)obj7 & 1uL) != 0;
			IL_0c21:
			throw new InvalidCastException();
			IL_010e:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0f2c;
			IL_116b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1612.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_0f3b;
			IL_0c35:
			throw new InvalidCastException();
			IL_1004:
			ProfileData profileData = ProfileData.Instance(s_Util);
			if (((Dictionary<string, object>)obj3).TryGetValue("gamerToken", out *(object*)((long)(IntPtr)obj - 80L)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				string text9 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				string text10;
				if ((IntPtr)0 != (IntPtr)0)
				{
					if ((object)text9.GetType() == typeof(string))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
						text10 = (string)0;
					}
					else
					{
						text10 = null;
					}
				}
				else
				{
					text10 = null;
				}
				if (!string.IsNullOrEmpty(text10))
				{
					profileData.AdsGamerToken = text10;
				}
			}
			intPtr6 = intPtr2;
			object value4;
			if (((Dictionary<string, object>)obj3).TryGetValue("trackingOptOut", out *(object*)((long)(IntPtr)obj - 80L)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				object obj23 = ((((object)0) is bool?) ? ((object)0) : null);
				if (obj23 != null && (int)((obj23 is bool) ? obj23 : null) == 0)
				{
					InvalidCastException ex5 = new InvalidCastException();
					goto IL_0c35;
				}
				bool flag29 = ((Dictionary<string, object>)obj23).TryGetValue((string)(object)typeof(bool), out value4);
				if ((long)(IntPtr)value4 >= 256L)
				{
					profileData.TrackingOptOut = (bool?)value4;
				}
			}
			if (((Dictionary<string, object>)obj3).TryGetValue("gameId", out *(object*)((long)(IntPtr)obj - 80L)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				string text11 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				string text12;
				if ((IntPtr)0 != (IntPtr)0)
				{
					if ((object)text11.GetType() == typeof(string))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
						text12 = (string)0;
					}
					else
					{
						text12 = null;
					}
				}
				else
				{
					text12 = null;
				}
				if (!string.IsNullOrEmpty(text12))
				{
					profileData.AdsGameId = text12;
				}
			}
			intPtr6 = intPtr2;
			if (((Dictionary<string, object>)obj3).TryGetValue("abGroup", out *(object*)((long)(IntPtr)obj - 80L)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X29-50]");
				object obj24 = ((((object)0) is int?) ? ((object)0) : null);
				if (obj24 != null)
				{
					int num16 = (int)((obj24 is int) ? obj24 : null);
					bool flag30 = num16 == 0;
					string key2 = (string)(object)typeof(int);
					if (flag30)
					{
						goto IL_0c35;
					}
				}
				bool flag31 = ((Dictionary<string, object>)obj24).TryGetValue((string)(object)typeof(int), out value4);
				int num17 = (int)(value4 & 0xFF00000000L);
				bool flag32 = num17 == 0;
				obj7 = 1;
				if (!flag32)
				{
					bool flag33 = (long)(IntPtr)value4 < 1L;
					obj7 = 1;
					if (!flag33)
					{
						profileData.AdsABGroup = (int?)value4;
						goto IL_123f;
					}
				}
				goto IL_0ff0;
			}
			goto IL_123f;
			IL_0937:
			flag13 = ((Dictionary<string, object>)s_Logger).TryGetValue((string)(object)typeof(ILogger), out *(object*)6);
			goto IL_116b;
			IL_0c13:
			InvalidCastException ex6 = new InvalidCastException();
			goto IL_0c21;
			IL_0da3:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_133f;
			IL_133f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1928 @ X0_v39] (should have been resolved before IL gen)");
			goto IL_0f3b;
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xC6DBB8", Offset = "0xC6DBB8", Length = "0x65C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBFB50]);\n\tv23 = *([v22 @ X8_v89]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20233AA]) = v42;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = UnityEngine.Purchasing.Promo;\nL_0025:\n\tv59 = ~v57.s_IsReady;\n\tif (v59) goto L_0082;\n\tgoto L_0033;\n\tv75 = *([v53 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0033;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv78 = UnityEngine.Purchasing.Promo;\n\tv81 = *([v78 @ X0_v102+B8]);\nL_0033:\n\tv69 = v80.s_PromoPurchaser == 0;\n\tif (v69) goto L_0082;\n\tv96 = UnityEngine.Purchasing.MiniJSON.Json::Deserialize(itemRequest);\n\tgoto L_FFFFFFFF;\n\tv348 = v348_asT == 0;\n\tif (v348) goto L_0203;\n\tv567 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v96, \"productId\", &v170 @ stack_-38_v14 (System.Object));\n\tv719 = v567 == 0;\n\tif (v719) goto L_00C8;\n\tv765 = v170 == 0;\n\tif (v765) goto L_FFFFFFFF;\n\tv815 = *([v170 @ stack_-38_v14 (System.Object)]) != System.String;\n\tif (v815) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0101;\nL_0082:\n\tgoto L_008A;\n\tv82 = *([v66 @ X0_v28 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_008A;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv86 = UnityEngine.Purchasing.Promo;\nL_008A:\n\tv704 = v89.s_Logger;\n\tv91 = v89.s_Logger == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_009D;\n\tv192 = *([v85 @ X0_v29 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_009D;\n\tv541 = UnityEngine.Purchasing.Promo;\n\tv202 = *([v541 @ X8_v26 (Il2CppClass<UnityEngine.Purchasing.Promo>)+B8]);\n\tv200 = v202.s_Logger;\nL_009D:\n\tv705 = *([v704 @ X19_v11 (UnityEngine.ILogger)]);\n\tv214 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v214) goto L_0200;\n\tv650 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_00B0:\n\tv558 = *([v650 @ X11_v8-8]) == UnityEngine.ILogger;\n\tif (v558) goto L_0261;\n\tv553 = v553 + 1;\n\tv648 = v553 < *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv403 = ~v648;\n\tv650 = v650 + 0x10;\n\tv347 = ~v403;\n\tif (v347) goto L_00B0;\n\tgoto L_0200;\nL_00C8:\n\tgoto L_00D0;\n\tv817 = *([v766 @ X0_v59 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv818 = v817 == 0;\n\tv819 = ~v818;\n\tif (v819) goto L_00D0;\n\tv841 = \"il2cpp_codegen_runtime_class_init\"(v766, v528, v337, v340, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv820 = UnityEngine.Purchasing.Promo;\nL_00D0:\n\tv182 = v538.s_Logger;\n\tv844 = *([v182 @ X19_v22 (UnityEngine.ILogger)]);\n\tv179 = *([v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v179) goto L_00FD;\n\tv893 = *([v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_00E8:\n\tv908 = *([v893 @ X11_v23-8]) == UnityEngine.ILogger;\n\tif (v908) goto L_0173;\n\tv903 = v903 + 1;\n\tv928 = v903 < *([v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv881 = ~v928;\n\tv893 = v893 + 0x10;\n\tv865 = ~v881;\n\tif (v865) goto L_00E8;\nL_00FD:\n\tv935 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v182, UnityEngine.ILogger, 7);\n\tgoto L_017C;\nL_0101:\n\tv840 = System.String::IsNullOrEmpty(v838);\n\tv856 = v840 == 0;\n\tif (v856) goto L_0140;\n\tgoto L_0112;\n\tv914 = *([v853 @ X8_v56 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv915 = v914 == 0;\n\tv916 = ~v915;\n\tif (v916) goto L_0112;\n\tv942 = v853;\n\tv917 = \"il2cpp_codegen_runtime_class_init\"(v942, v622, v337, v340, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv920 = UnityEngine.Purchasing.Promo;\nL_0112:\n\tv704 = v642.s_Logger;\n\tv705 = *([v704 @ X19_v11 (UnityEngine.ILogger)]);\n\tv432 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v432) goto L_0200;\n\tv650 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_012A:\n\tv680 = *([v650 @ X11_v8-8]) == UnityEngine.ILogger;\n\tif (v680) goto L_0261;\n\tv696 = v696 + 1;\n\tv1034 = v696 < *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv405 = ~v1034;\n\tv650 = v650 + 0x10;\n\tv349 = ~v405;\n\tif (v349) goto L_012A;\n\tgoto L_0200;\nL_0140:\n\tgoto L_0152;\n\tv921 = *([v853 @ X8_v56 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv922 = v921 == 0;\n\tv923 = ~v922;\n\t// 324 ConditionalJump @b125, v923 @ TEMP_v82\n\tv948 = v853;\n\tv924 = \"il2cpp_codegen_runtime_class_init\"(v948, v622, v337, v340, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv927 = UnityEngine.Purchasing.Promo;\nL_0152:\n\tgoto L_0185;\n\tv964 = *([v950 @ X8_v59+B0]);\n\tv965 = 0;\n\tv966 = v964 + 8;\n\tv968 = *([v1011 @ X11_v33-8]);\n\tv1026 = v968 == v953;\n\tif (v1026) goto L_017E;\n\tv990 = v1021 + 1;\n\tv1035 = v990 < v952;\n\tv988 = ~v1035;\n\tv970 = v1011 + 0x10;\n\tv972 = ~v988;\n\tif (v972) goto L_FFFFFFFF;\n\tv991 = v600;\n\tv992 = 0;\n\tv993 = 0x8909C4(v991, v953, v992, v340, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0185;\nL_0173:\n\tv930 = *([v893 @ X11_v23]) + 7;\n\tv931 = v930 << 4;\n\tv932 = v844 + v931;\n\tv935 = v932 + 0x130;\nL_017C:\n\tv935.m_value(v176, v182, \"UnityIAP\", \"Promo purchase unable to determine Product ID\", *([v935 @ X0_v61 (System.Boolean)+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_FFFFFFFF;\nL_017E:\n\tv1036 = *([v1011 @ X11_v33]);\n\tv1037 = v1036 << 4;\n\tv1038 = v950 + v1037;\n\tv1039 = v1038 + 0x130;\nL_0185:\n\tv593 = UnityEngine.Purchasing.Extension.IStoreCallback::get_products(v643.s_Unity);\n\tv595 = v170 == 0;\n\tif (v595) goto L_019B;\n\tv570 = *([v170 @ stack_-38_v14 (System.Object)]) != System.String;\n\tif (v570) goto L_020A;\nL_019B:\n\tv631 = UnityEngine.Purchasing.ProductCollection::WithID(v593, v170);\n\tv1058 = v631 == 0;\n\tif (v1058) goto L_01CB;\n\tv641 = v631.<definition>k__BackingField;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v96, \"storeSpecificId\", v641.<storeSpecificId>k__BackingField);\n\tv1076 = UnityEngine.Purchasing.MiniJSON.Json::Serialize(v96);\n\tgoto L_01C4;\n\tv1090 = *([v1083 @ X8_v71 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv1091 = v1090 == 0;\n\tv1092 = ~v1091;\n\t// 439 ConditionalJump @b128, v1092 @ TEMP_v80\n\tv1108 = v1083;\n\tv1094 = \"il2cpp_codegen_runtime_class_init\"(v1108, v749, v724, v726, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv1097 = UnityEngine.Purchasing.Promo;\nL_01C4:\n\tv1109 = UnityEngine.Purchasing.JSONStore::Purchase(v761.s_PromoPurchaser, v631.<definition>k__BackingField, v1076);\n\tgoto L_0273;\nL_01CB:\n\tgoto L_01D3;\n\tv1069 = *([v1059 @ X0_v76 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv1070 = v1069 == 0;\n\tv1071 = ~v1070;\n\tif (v1071) goto L_01D3;\n\tv1077 = \"il2cpp_codegen_runtime_class_init\"(v1059, v589, v336, v340, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv1072 = UnityEngine.Purchasing.Promo;\nL_01D3:\n\tv704 = v644.s_Logger;\n\tv705 = *([v704 @ X19_v11 (UnityEngine.ILogger)]);\n\tv431 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v431) goto L_0200;\n\tv650 = *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_01EB:\n\tv681 = *([v650 @ X11_v8-8]) == UnityEngine.ILogger;\n\tif (v681) goto L_0261;\n\tv697 = v697 + 1;\n\tv1110 = v697 < *([v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv402 = ~v1110;\n\tv650 = v650 + 0x10;\n\tv346 = ~v402;\n\tif (v346) goto L_01EB;\nL_0200:\n\tv715 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v704, v416, 7);\n\tgoto L_026A;\nL_0203:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_020A:\n\tv603 = new System.InvalidCastException();\n\tgoto L_0219;\n\tgoto L_0219;\n\tgoto L_0219;\n\tgoto L_0219;\nL_0219:\n\tv350 = System.String != 1;\n\tif (v350) go\n// ... truncated")]
		internal unsafe static bool ExecPromoPurchase(string itemRequest)
		{
			//IL_00ee: Expected I, but got O
			//IL_011c: Expected I, but got O
			//IL_05c9: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_079c: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a1: Expected O, but got Unknown
			//IL_07be: Expected O, but got I
			//IL_0195: Expected O, but got I
			//IL_01c5: Expected I, but got O
			//IL_01e0: Expected I, but got O
			//IL_021b: Expected O, but got I
			//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Expected O, but got Unknown
			//IL_03d4: Expected O, but got I
			//IL_0267: Expected O, but got I
			//IL_02b8: Expected I, but got O
			//IL_02e7: Expected I, but got O
			//IL_0314: Expected O, but got I
			//IL_04d5: Expected I, but got O
			//IL_0504: Expected I, but got O
			//IL_086b: Expected O, but got I4
			//IL_0360: Expected O, but got I
			//IL_0531: Expected O, but got I
			//IL_0391: Expected I, but got O
			//IL_07e4: Expected O, but got I4
			//IL_0809: Expected O, but got I4
			//IL_0817: Expected O, but got I4
			//IL_057d: Expected O, but got I
			//IL_05a0: Expected I, but got O
			//IL_082e: Expected O, but got I4
			//IL_0840: Expected O, but got I4
			//IL_069d: Expected O, but got I4
			//IL_06ae: Expected I, but got O
			//IL_06dc: Expected I, but got O
			//IL_0709: Expected O, but got I
			//IL_0755: Expected O, but got I
			//IL_0785: Expected I, but got O
			ILogger logger;
			ILogger logger2;
			IntPtr intPtr2;
			IntPtr intPtr3;
			object obj6;
			bool flag3;
			string text;
			string text2;
			if (s_IsReady && s_PromoPurchaser != null)
			{
				object obj = Json.Deserialize(itemRequest);
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				if (dictionary == null)
				{
					throw new InvalidCastException();
				}
				if (!((Dictionary<string, object>)obj).TryGetValue("productId", out object value))
				{
					logger = s_Logger;
					IntPtr intPtr = (IntPtr)logger;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0280;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					object obj2 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ X11_v23-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ILogger))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v844 @ X8_v50 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0280;
					}
					object obj3 = obj2 + 7;
					int num3 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num3;
					flag3 = (byte)((ulong)(long)(IntPtr)obj4 + 304uL) != 0;
					goto IL_095e;
				}
				string value2;
				if (value != null)
				{
					object obj5 = (((object)value.GetType() != typeof(string)) ? null : value);
					value2 = (string)obj5;
				}
				else
				{
					value2 = null;
				}
				if (string.IsNullOrEmpty(value2))
				{
					logger2 = s_Logger;
					intPtr2 = (IntPtr)logger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag4 = (IntPtr)0 == (IntPtr)0;
					text = "Promo product is null or empty!";
					intPtr3 = (IntPtr)typeof(ILogger);
					text2 = "UnityIAP";
					if (flag4)
					{
						goto IL_05b7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					obj6 = 0L + 8L;
					int num4 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X11_v8-8]");
						bool flag5 = (IntPtr)0 == (IntPtr)typeof(ILogger);
						text = "Promo product is null or empty!";
						text2 = "UnityIAP";
						if (flag5)
						{
							break;
						}
						num4++;
						int num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag6 = (long)num5 < 0L;
						bool flag7 = !flag6;
						obj6 = (long)(IntPtr)obj6 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_0379;
					}
				}
				else
				{
					ProductCollection products = s_Unity.products;
					if (value != null)
					{
						bool flag8 = (object)value.GetType() != typeof(string);
						ref object value3 = ref *(object*)null;
						if (flag8)
						{
							InvalidCastException ex = new InvalidCastException();
							bool flag9 = (IntPtr)typeof(string) != (IntPtr)1;
							string key = (string)(object)typeof(string);
							InvalidCastException ex2 = ex;
							if (!flag9)
							{
								bool flag10 = ((Dictionary<string, object>)(object)ex).TryGetValue((string)(object)typeof(string), out *(object*)null);
								bool value4 = ((bool*)(flag10 ? 1 : 0))->m_value;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj7 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
								{
									bool flag11 = ((Dictionary<string, object>)obj7).TryGetValue((string)((bool*)(value4 ? 1 : 0))->m_value, out value3);
									logger2 = s_Logger;
									intPtr2 = (IntPtr)logger2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
									bool flag12 = (IntPtr)0 == (IntPtr)0;
									text = "Promo purchase argument exception";
									intPtr3 = (IntPtr)typeof(ILogger);
									text2 = "UnityIAP";
									if (flag12)
									{
										goto IL_05b7;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]");
									obj6 = 0L + 8L;
									int num6 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X11_v8-8]");
										bool flag13 = (IntPtr)0 == (IntPtr)typeof(ILogger);
										text = "Promo purchase argument exception";
										text2 = "UnityIAP";
										if (flag13)
										{
											break;
										}
										num6++;
										int num7 = num6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
										bool flag14 = (long)num7 < 0L;
										bool flag15 = !flag14;
										obj6 = (long)(IntPtr)obj6 + 16L;
										if (!flag15)
										{
											continue;
										}
										goto IL_076e;
									}
									goto IL_0793;
								}
								string key2 = default(string);
								ref object value5 = default(ref object);
								bool flag16 = ((Dictionary<string, object>)8).TryGetValue(key2, out value5);
								bool flag17 = default(bool);
								((bool*)(flag16 ? 1 : 0))->m_value = ((bool*)(flag17 ? 1 : 0))->m_value;
								key = (string)(32022528 + 2160);
								bool flag18 = ((Dictionary<string, object>)flag16).TryGetValue(key, out *(object*)null);
								bool flag19 = ((Dictionary<string, object>)flag18).TryGetValue(key, out *(object*)null);
								value3 = ref *(object*)null;
								ex2 = (InvalidCastException)flag18;
							}
							bool flag20 = ((Dictionary<string, object>)(object)ex2).TryGetValue(key, out value3);
							return ((Dictionary<string, object>)flag20).TryGetValue(key, out value3);
						}
					}
					Product product = products.WithID((string)value);
					if (product != null)
					{
						ProductDefinition definition = product.definition;
						((Dictionary<string, object>)obj).Add("storeSpecificId", (object)definition.storeSpecificId);
						string developerPayload = Json.Serialize(obj);
						s_PromoPurchaser.Purchase(product.definition, developerPayload);
						return true;
					}
					logger2 = s_Logger;
					intPtr2 = (IntPtr)logger2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag21 = (IntPtr)0 == (IntPtr)0;
					text = "Promo product lookup failed";
					intPtr3 = (IntPtr)typeof(ILogger);
					text2 = "UnityIAP";
					if (flag21)
					{
						goto IL_05b7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]");
					obj6 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X11_v8-8]");
						bool flag22 = (IntPtr)0 == (IntPtr)typeof(ILogger);
						text = "Promo product lookup failed";
						text2 = "UnityIAP";
						if (flag22)
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
						bool flag23 = (long)num9 < 0L;
						bool flag24 = !flag23;
						obj6 = (long)(IntPtr)obj6 + 16L;
						bool flag25 = !flag24;
						text = "Promo product lookup failed";
						intPtr3 = (IntPtr)typeof(ILogger);
						text2 = "UnityIAP";
						if (flag25)
						{
							continue;
						}
						goto IL_05b7;
					}
				}
			}
			else
			{
				logger2 = s_Logger;
				if (s_Logger == null)
				{
					goto IL_0a9c;
				}
				intPtr2 = (IntPtr)logger2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
				bool flag26 = (IntPtr)0 == (IntPtr)0;
				text = "Promo purchase attempted without proper configuration";
				intPtr3 = (IntPtr)typeof(ILogger);
				text2 = "UnityIAP Promo";
				if (flag26)
				{
					goto IL_05b7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				obj6 = 0L + 8L;
				int num10 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X11_v8-8]");
					bool flag27 = (IntPtr)0 == (IntPtr)typeof(ILogger);
					text = "Promo purchase attempted without proper configuration";
					text2 = "UnityIAP Promo";
					if (flag27)
					{
						break;
					}
					num10++;
					int num11 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ X8_v15 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag28 = (long)num11 < 0L;
					bool flag29 = !flag28;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag29)
					{
						continue;
					}
					goto IL_01ae;
				}
			}
			goto IL_0793;
			IL_0280:
			flag3 = ((Dictionary<string, object>)logger).TryGetValue((string)(object)typeof(ILogger), out *(object*)7);
			goto IL_095e;
			IL_076e:
			text = "Promo purchase argument exception";
			intPtr3 = (IntPtr)typeof(ILogger);
			text2 = "UnityIAP";
			goto IL_05b7;
			IL_095e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v935.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_0a9c;
			IL_0379:
			text = "Promo product is null or empty!";
			intPtr3 = (IntPtr)typeof(ILogger);
			text2 = "UnityIAP";
			goto IL_05b7;
			IL_0793:
			object obj8 = obj6 + 7;
			int num12 = (int)((long)(IntPtr)obj8 << 4);
			object obj9 = (long)intPtr2 + (long)num12;
			bool flag30 = (byte)((ulong)(long)(IntPtr)obj9 + 304uL) != 0;
			goto IL_0a19;
			IL_0a9c:
			return false;
			IL_01ae:
			text = "Promo purchase attempted without proper configuration";
			intPtr3 = (IntPtr)typeof(ILogger);
			text2 = "UnityIAP Promo";
			goto IL_05b7;
			IL_05b7:
			flag30 = ((Dictionary<string, object>)logger2).TryGetValue((string)(long)intPtr3, out *(object*)7);
			goto IL_0a19;
			IL_0a19:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v715.m_value (System.Boolean) (should have been resolved before IL gen)");
			goto IL_0a9c;
		}
	}
}
