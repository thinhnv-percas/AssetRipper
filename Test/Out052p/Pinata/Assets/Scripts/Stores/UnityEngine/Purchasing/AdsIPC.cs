using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000055")]
	internal class AdsIPC
	{
		[Token(Token = "0x40000FA")]
		private static string adsAdvertisementClassName = "UnityEngine.Advertisements.Purchasing,UnityEngine.Advertisements.";

		[Token(Token = "0x40000FB")]
		private static string adsMessageSendName = "SendEvent";

		[Token(Token = "0x40000FC")]
		private static Type adsAdvertisementType = null;

		[Token(Token = "0x40000FD")]
		private static MethodInfo adsMessageSend = null;

		[Token(Token = "0x6000141")]
		[Address(RVA = "0xC56EE8", Offset = "0xC56EE8", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1ED3898]);\n\tv19 = *([v18 @ X8_v38]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20232DD]) = v38;\nL_001B:\n\tgoto L_0042;\n\tv48 = *([v41 @ X8_v3+B0]);\n\tv49 = 0;\n\tv50 = v48 + 8;\n\tv52 = *([v101 @ X11_v13-8]);\n\tv106 = v52 == v44;\n\tif (v106) goto L_003B;\n\tv82 = v100 + 1;\n\tv182 = v82 < v43;\n\tv79 = ~v182;\n\tv85 = v101 + 0x10;\n\tv55 = ~v79;\n\tif (v55) goto L_FFFFFFFF;\n\tv87 = v12;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v44, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0042;\nL_003B:\n\tv183 = *([v101 @ X11_v13]);\n\tv184 = v183 << 4;\n\tv185 = v41 + v184;\n\tv186 = v185 + 0x130;\nL_0042:\n\tv207 = Uniject.IUtil::get_platform(util);\n\tv217 = v207 != 8;\n\tif (v217) goto L_0061;\n\tgoto L_FFFFFFFF;\n\tv228 = *([v220 @ X0_v31+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_FFFFFFFF;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v220, v205, v189, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_00A9;\nL_0061:\n\tgoto L_0088;\n\tv237 = *([v224 @ X8_v17+B0]);\n\tv238 = 0;\n\tv239 = v237 + 8;\n\tv241 = *([v309 @ X11_v8-8]);\n\tv314 = v241 == v225;\n\tif (v314) goto L_0081;\n\tv261 = v308 + 1;\n\tv325 = v261 < v226;\n\tv259 = ~v325;\n\tv263 = v309 + 0x10;\n\tv243 = ~v259;\n\tif (v243) goto L_FFFFFFFF;\n\tv264 = v12;\n\tv265 = 0;\n\tv266 = 0x8909C4(v264, v225, v265, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0088;\nL_0081:\n\tv326 = *([v309 @ X11_v8]);\n\tv327 = v326 << 4;\n\tv328 = v224 + v327;\n\tv329 = v328 + 0x130;\nL_0088:\n\tv343 = Uniject.IUtil::get_platform(util);\n\tv271 = v343 != 0xB;\n\tif (v271) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv362 = *([v355 @ X0_v25+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\tif (v364) goto L_FFFFFFFF;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v355, v283, v270, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A9:\n\tv297 = System.String::Concat(v295.adsAdvertisementClassName, *([v290 @ X8_v7 (System.String)]));\n\tv320.adsAdvertisementClassName = v297;\n\tgoto L_00B7;\n\tv345 = *([v321 @ X0_v11 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]);\n\tv346 = v345 == 0;\n\tv347 = ~v346;\n\tgoto L_00B7;\n\tv349 = \"il2cpp_codegen_runtime_class_init\"(v321, v158, v122, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00B7:\n\tv352 = UnityEngine.Purchasing.AdsIPC::VerifyMethodExists();\n\tv361 = v352 == 0;\n\tif (v361) goto L_00C1;\n\tgoto L_00DA;\nL_00C1:\n\tgoto L_00CC;\n\tv374 = *([v370 @ X0_v14 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_00CC;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v370, v158, v122, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv378 = UnityEngine.Purchasing.AdsIPC;\nL_00CC:\n\tv174.adsAdvertisementClassName = \"UnityEngine.Advertisements.Purchasing,UnityEngine.Advertisements\";\n\treturnVal3 = UnityEngine.Purchasing.AdsIPC::VerifyMethodExists();\n\treturn returnVal3;\nL_00DA:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool InitAdsIPC(IUtil util)
		{
			RuntimePlatform platform = util.platform;
			string text;
			if (platform == RuntimePlatform.IPhonePlayer)
			{
				text = "iOS";
			}
			else
			{
				RuntimePlatform platform2 = util.platform;
				if (platform2 != RuntimePlatform.Android)
				{
					return false;
				}
				text = "Android";
			}
			string text2 = adsAdvertisementClassName + text;
			adsAdvertisementClassName = text2;
			if (VerifyMethodExists())
			{
				return true;
			}
			adsAdvertisementClassName = "UnityEngine.Advertisements.Purchasing,UnityEngine.Advertisements";
			return VerifyMethodExists();
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xC570F4", Offset = "0xC570F4", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EEAF88]);\n\tv17 = *([v16 @ X8_v22]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20232DE]) = v37;\nL_0018:\n\tgoto L_0027;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = UnityEngine.Purchasing.AdsIPC;\nL_0027:\n\tgoto L_002F;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002F;\n\tv71 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v71, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002F:\n\tv187 = 0x181A000 + 0x308;\n\tv70 = 0x8D83FC(v53.adsAdvertisementClassName, v187, v184, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv77 = System.Type::GetType(v70);\n\tv73 = v77 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0038;\n\tv77 = System.Type::GetType(v53.adsAdvertisementClassName);\nL_0038:\n\tv78 = UnityEngine.Purchasing.AdsIPC;\n\tv79.adsAdvertisementType = v77;\n\tv140 = v80.adsAdvertisementType;\n\tv82 = v80.adsAdvertisementType == 0;\n\tif (v82) goto L_FFFFFFFF;\n\tv84 = *([v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+12F]) & 2;\n\tv85 = v84 == 0;\n\tif (v85) goto L_0050;\n\tv136 = *([v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]) == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0050;\n\tv140 = v139.adsAdvertisementType;\n\tv143 = v139.adsAdvertisementType == 0;\n\tif (v143) goto L_005A;\nL_0050:\n\tv126 = System.Type::GetMethod(v140, v138.adsMessageSendName);\n\tv123.adsMessageSend = v126;\n\tv129 = v171.adsMessageSend == 0;\n\tif (v129) goto L_FFFFFFFF;\n\tgoto L_007C;\nL_005A:\n\tv199 = new System.NullReferenceException();\n\tgoto L_0067;\n\tgoto L_0067;\nL_0067:\n\tv87 = v187 != 1;\n\tif (v87) goto L_0088;\n\tv203 = 0x6D2BC0(v199, v187, v184, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv131 = *([v203 @ X0_v25]);\n\tv214 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v131 @ X8_v17]), v184, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv215 = v214 & 1;\n\tv128 = v215 == 0;\n\tif (v128) goto L_007E;\n\tv125 = 0x6D2490(v214, *([v131 @ X8_v17]), v184, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_007C:\n\treturn returnVal1;\nL_007E:\n\tv217 = 0x6D1E60(8, *([v131 @ X8_v17]), v184, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\t*([v217 @ X0_v29]) = *([v203 @ X0_v25]);\n\tv187 = 0x1E8A000 + 0x870;\n\tv219 = 0x6D2A00(v217, v187, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv207 = 0x6D2490(v219, v187, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0088:\n\tv211 = 0x6D2380(v197, v187, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal2 = 0x846AA4(v211, v187, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool VerifyMethodExists()
		{
			//IL_0079: Expected I, but got O
			int num = 25272320 + 776;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D83FC");
			string typeName = default(string);
			Type type = Type.GetType(typeName);
			if ((object)type == null)
			{
				type = Type.GetType(adsAdvertisementClassName);
			}
			IntPtr intPtr = (IntPtr)typeof(AdsIPC);
			adsAdvertisementType = type;
			Type type2 = adsAdvertisementType;
			if ((object)adsAdvertisementType != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						type2 = adsAdvertisementType;
						if ((object)adsAdvertisementType == null)
						{
							NullReferenceException ex = new NullReferenceException();
							bool flag = num != 1;
							NullReferenceException ex2 = ex;
							if (!flag)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
								object obj2 = default(object);
								object obj = obj2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj3 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
									goto IL_020c;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
								object obj4 = obj2;
								num = 32022528 + 2160;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								NullReferenceException ex3 = default(NullReferenceException);
								ex2 = ex3;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
							bool result = default(bool);
							return result;
						}
					}
				}
				MethodInfo method = type2.GetMethod(adsMessageSendName);
				adsMessageSend = method;
				if ((object)adsMessageSend != null)
				{
					return true;
				}
			}
			goto IL_020c;
			IL_020c:
			return false;
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xC57288", Offset = "0xC57288", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED7560]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20232DF]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = UnityEngine.Purchasing.AdsIPC;\nL_0023:\n\tv56 = v54.adsMessageSend == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_0035;\n\tv62 = *([v50 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.AdsIPC>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0035;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv114 = UnityEngine.Purchasing.AdsIPC;\n\tv69 = *([v114 @ X8_v18+B8]);\n\tv71 = *([v69 @ X8_v19+18]);\nL_0035:\n\t// 53 NewArr v76 @ X0_v8 (System.Object[]), typeof(System.String[]), 1\n\tv115 = json == 0;\n\tif (v115) goto L_0042;\n\t// 62 IsInst v120 @ X0_v23, typeof(System.Object), json @ X0 (System.String)\nL_0042:\n\tv126 = v76.Length == 0;\n\tif (v126) goto L_0057;\n\tv76[0] = json;\n\tv139 = System.Reflection.MethodBase::Invoke(v54.adsMessageSend, 0, v76);\n\tgoto L_0055;\nL_0055:\n\treturn returnVal1;\n\tv116 = new System.NullReferenceException();\nL_0057:\n\tv131 = new System.IndexOutOfRangeException();\n\tgoto L_005E;\n\tv134 = new System.NullReferenceException();\n\tv137 = new System.ArrayTypeMismatchException();\nL_005E:\n\tthrow v142;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SendEvent(string json)
		{
			if ((object)adsMessageSend != null)
			{
				object[] array = new string[1];
				if (json != null)
				{
					object obj = json as object;
				}
				if (array.Length != 0)
				{
					array[0] = json;
					object obj2 = adsMessageSend.Invoke(null, array);
					return true;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			return false;
		}
	}
}
