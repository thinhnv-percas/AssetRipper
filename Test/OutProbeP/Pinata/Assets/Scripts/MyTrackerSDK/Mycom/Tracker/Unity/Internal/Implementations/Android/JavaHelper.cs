using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Mycom.Tracker.Unity.Internal.Implementations.Android
{
	[Token(Token = "0x200000E")]
	internal static class JavaHelper
	{
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x161A73C", Offset = "0x161A73C", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAC170]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2C7]) = v42;\nL_0015:\n\tv43 = value == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaStringMap(value);\n\t// 31 NewArr v53 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\tv174 = v45 == 0;\n\tif (v174) goto L_002C;\n\t// 40 IsInst v180 @ X0_v35, typeof(System.Object), v45 @ X0_v5 (UnityEngine.AndroidJavaObject)\n\tv184 = v180 == 0;\n\tif (v184) goto L_008C;\nL_002C:\n\tv187 = v53.Length == 0;\n\tif (v187) goto L_0088;\n\tv53[0] = v45;\n\tv218 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v218, \"org.json.JSONObject\", v53);\n\tv269 = v45 == 0;\n\tif (v269) goto L_006F;\nL_0045:\n\tgoto L_006E;\n\tv329 = *([v299 @ X8_v12+B0]);\n\tv330 = 0;\n\tv331 = v329 + 8;\n\tv333 = *([v371 @ X11_v11-8]);\n\tv377 = v333 == v302;\n\tif (v377) goto L_0067;\n\tv355 = v372 + 1;\n\tv382 = v355 < v301;\n\tv351 = ~v382;\n\tv353 = v371 + 0x10;\n\tv335 = ~v351;\n\tif (v335) goto L_FFFFFFFF;\n\tv356 = v49;\n\tv357 = 0;\n\tv358 = 0x8909C4(v356, v302, v357, v286, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006E;\n\tgoto L_0081;\nL_0067:\n\tv383 = *([v371 @ X11_v11]);\n\tv384 = v383 << 4;\n\tv385 = v299 + v384;\n\tv386 = v385 + 0x130;\nL_006E:\n\tSystem.IDisposable::Dispose(v45);\nL_006F:\n\tv110 = v97 + 1;\n\tv76 = v110 == 0;\n\tv61 = ~v76;\n\tif (v61) goto L_0081;\n\tv359 = v103 == 0;\n\tv109 = ~v359;\n\tif (v109) goto L_0087;\nL_0081:\n\treturn v114;\n\tthrow System.NullReferenceException;\nL_0087:\n\tv214 = new System.TypeLoadException();\nL_0088:\n\tv242 = new System.IndexOutOfRangeException();\n\tthrow v242;\nL_008C:\n\tv258 = new System.ArrayTypeMismatchException();\n\tthrow v258;\n\tgoto L_009C;\n\tgoto L_009C;\nL_009C:\n\tif (1) goto L_00A6;\n\tv360 = 0x6D2BC0(v266, 0, 0, v157, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv289 = *([v360 @ X0_v13]);\n\tv292 = 0x6D2490(v360, 0, 0, v157, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv390 = v45 == 0;\n\tv294 = ~v390;\n\tif (v294) goto L_0045;\n\tgoto L_006F;\nL_00A6:\n\treturnVal2 = 0x6D2380(v266, 0, 0, v157, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidJavaObject CreateJavaJsonObbject(IDictionary<string, string> value)
		{
			AndroidJavaObject result;
			if (value != null)
			{
				AndroidJavaObject androidJavaObject = CreateJavaStringMap(value);
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
					AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("org.json.JSONObject", array);
					bool flag = androidJavaObject == null;
					int num = 0;
					int num2 = 0;
					result = androidJavaObject2;
					if (!flag)
					{
						((IDisposable)androidJavaObject).Dispose();
						num = 0;
						num2 = 0;
						result = androidJavaObject2;
					}
					if (num + 1 != 0 || num2 == 0)
					{
						goto IL_0123;
					}
					TypeLoadException ex2 = new TypeLoadException();
				}
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
			}
			result = null;
			goto IL_0123;
			IL_0123:
			return result;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x161AFE4", Offset = "0x161AFE4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EECF38]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A2C8]) = v42;\nL_0016:\n\tv44 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(value);\n\tv46 = value == 0;\n\tif (v46) goto L_003C;\n\t// 30 NewArr v51 @ X0_v29 (System.Object[]), typeof(System.Object[]), 1\n\tv185 = v44 == 0;\n\tif (v185) goto L_002B;\n\t// 39 IsInst v257 @ X0_v35, typeof(System.Object), v44 @ X0_v3 (UnityEngine.AndroidJavaObject)\n\tv261 = v257 == 0;\n\tif (v261) goto L_0089;\nL_002B:\n\tv63 = v51.Length == 0;\n\tif (v63) goto L_0085;\n\tv51[0] = v44;\n\tv344 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v344, \"org.json.JSONObject\", v51);\nL_003C:\n\tv70 = v44 == 0;\n\tif (v70) goto L_006C;\nL_0044:\n\tgoto L_006B;\n\tv215 = *([v133 @ X8_v8+B0]);\n\tv216 = 0;\n\tv217 = v215 + 8;\n\tv219 = *([v298 @ X11_v10-8]);\n\tv304 = v219 == v136;\n\tif (v304) goto L_0064;\n\tv241 = v299 + 1;\n\tv348 = v241 < v135;\n\tv237 = ~v348;\n\tv239 = v298 + 0x10;\n\tv221 = ~v237;\n\tif (v221) goto L_FFFFFFFF;\n\tv242 = v45;\n\tv243 = 0;\n\tv244 = 0x8909C4(v242, v136, v243, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006B;\nL_0064:\n\tv349 = *([v298 @ X11_v10]);\n\tv350 = v349 << 4;\n\tv351 = v133 + v350;\n\tv352 = v351 + 0x130;\nL_006B:\n\tSystem.IDisposable::Dispose(v44);\nL_006C:\n\tv179 = v166 + 1;\n\tv181 = v179 == 0;\n\tv184 = ~v181;\n\tif (v184) goto L_007E;\n\tv245 = v170 == 0;\n\tv210 = ~v245;\n\tif (v210) goto L_0082;\nL_007E:\n\treturn v176;\nL_0082:\n\tthrow System.TypeLoadException;\n\tv214 = new System.NullReferenceException();\nL_0085:\n\tv287 = new System.IndexOutOfRangeException();\n\tthrow v287;\nL_0089:\n\tv368 = new System.ArrayTypeMismatchException();\n\tthrow v368;\n\tgoto L_0099;\n\tgoto L_0099;\nL_0099:\n\tif (1) goto L_00A3;\n\tv372 = 0x6D2BC0(v370, 0, 0, v117, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv121 = *([v372 @ X0_v12]);\n\tv125 = 0x6D2490(v372, 0, 0, v117, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv373 = v44 == 0;\n\tv127 = ~v373;\n\tif (v127) goto L_0044;\n\tgoto L_006C;\nL_00A3:\n\treturnVal2 = 0x6D2380(v370, 0, 0, v117, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidJavaObject CreateJavaJsonObbject(string value)
		{
			AndroidJavaObject androidJavaObject = CreateJavaString(value);
			bool flag = value == null;
			string text = value;
			if (!flag)
			{
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
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				array[0] = androidJavaObject;
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("org.json.JSONObject", array);
				text = (string)(object)androidJavaObject2;
			}
			bool flag2 = androidJavaObject == null;
			int num = 0;
			int num2 = 0;
			string result = text;
			if (!flag2)
			{
				((IDisposable)androidJavaObject).Dispose();
				num = 0;
				num2 = 0;
				result = text;
			}
			if (num + 1 != 0 || num2 == 0)
			{
				return (AndroidJavaObject)(object)result;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x161B198", Offset = "0x161B198", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC4368]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A2C9]) = v38;\nL_0013:\n\tv39 = value == 0;\n\tif (v39) goto L_0038;\n\t// 25 NewArr v44 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 32 IsInst v85 @ X0_v12, typeof(System.Object), value @ X0 (System.String)\n\tv87 = v85 == 0;\n\tif (v87) goto L_003A;\n\tv44[0] = value;\n\tv52 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v52, \"java.lang.String\", v44);\nL_0038:\n\treturn v55;\n\tv86 = new System.NullReferenceException();\nL_003A:\n\tv92 = new System.ArrayTypeMismatchException();\n\tgoto L_003F;\n\tv97 = new System.IndexOutOfRangeException();\nL_003F:\n\tthrow v99;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidJavaObject CreateJavaString(string value)
		{
			bool flag = value == null;
			string result = value;
			if (!flag)
			{
				object[] array = new object[1];
				object obj = value as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
					throw ex2;
				}
				array[0] = value;
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.String", array);
				result = (string)(object)androidJavaObject;
			}
			return (AndroidJavaObject)(object)result;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x161B264", Offset = "0x161B264", Length = "0x810")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1EADE98]);\n\tv34 = *([v33 @ X8_v97]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202A2CA]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-80;\n\tv57 = values == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tv61 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v61, \"java.lang.reflect.Array\");\n\tv177 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v177, \"java.lang.String\");\n\t// 56 NewArr v247 @ X0_v10 (System.Object[]), typeof(System.Object[]), 2\n\tv250 = v177 == 0;\n\tif (v250) goto L_0045;\n\t// 65 IsInst v310 @ X0_v143, typeof(System.Object), v177 @ X0_v7 (UnityEngine.AndroidJavaClass)\n\tv314 = v310 == 0;\n\tif (v314) goto L_0227;\nL_0045:\n\tv317 = v247.Length == 0;\n\tif (v317) goto L_021D;\n\tv247[0] = v177;\n\tgoto L_0077;\n\tv410 = *([v347 @ X8_v38+B0]);\n\tv411 = 0;\n\tv412 = v410 + 8;\n\tv414 = *([v501 @ X11_v53-8]);\n\tv507 = v414 == v350;\n\tif (v507) goto L_0070;\n\tv436 = v502 + 1;\n\tv556 = v436 < v349;\n\tv432 = ~v556;\n\tv434 = v501 + 0x10;\n\tv416 = ~v432;\n\tif (v416) goto L_FFFFFFFF;\n\tv437 = v27;\n\tv438 = 0;\n\tv439 = 0x8909C4(v437, v350, v438, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0077;\n\tgoto L_0315;\nL_0070:\n\tv557 = *([v501 @ X11_v53]);\n\tv558 = v557 << 4;\n\tv559 = v347 + v558;\n\tv560 = v559 + 0x130;\nL_0077:\n\tv566 = System.Collections.Generic.ICollection`1<System.String>::get_Count(values);\n\t*([v21 @ X29-54]) = v566;\n\tv570 = &v21 @ X29 - 0x54;\n\t// 126 Box v572 @ X0_v66, typeof(System.Int32), v570 @ X1_v33\n\tv579 = v572 == 0;\n\tif (v579) goto L_0089;\n\t// 133 IsInst v550 @ X0_v138, typeof(System.Object), v572 @ X0_v66\n\tv552 = v550 == 0;\n\tif (v552) goto L_022B;\nL_0089:\n\tv684 = v247.Length < 1;\n\tv466 = ~v684;\n\tv464 = v247.Length - 1;\n\tv460 = v464 == 0;\n\tv685 = ~v466;\n\tv450 = v685 | v460;\n\tif (v450) goto L_0221;\n\tv247[1] = v572;\n\tv697 = UnityEngine.AndroidJavaObject::CallStatic(v61, \"newInstance\", v247);\n\t*([v21 @ X29-60]) = v177;\nL_00AC:\n\tgoto L_00D3;\n\tv804 = *([v757 @ X8_v49+B0]);\n\tv805 = 0;\n\tv806 = v804 + 8;\n\tv808 = *([v847 @ X11_v48-8]);\n\tv853 = v808 == v761;\n\tif (v853) goto L_00CC;\n\tv830 = v848 + 1;\n\tv950 = v830 < v759;\n\tv826 = ~v950;\n\tv828 = v847 + 0x10;\n\tv810 = ~v826;\n\tif (v810) goto L_FFFFFFFF;\n\tv831 = v27;\n\tv832 = 0;\n\tv833 = 0x8909C4(v831, v761, v832, v717, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00D3;\nL_00CC:\n\tv951 = *([v847 @ X11_v48]);\n\tv952 = v951 << 4;\n\tv953 = v757 + v952;\n\tv954 = v953 + 0x130;\nL_00D3:\n\tv901 = System.Collections.Generic.ICollection`1<System.String>::get_Count(values);\n\tv867 = v292 >= v901;\n\tif (v867) goto L_0205;\n\tv1041 = \"SzArrayNew\"(*([v635 @ X27_v18 (Il2CppClass<System.Object[]>)]), 1, 0, v862, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0111;\n\tv1188 = *([v1129 @ X8_v53+B0]);\n\tv1189 = 0;\n\tv1190 = v1188 + 8;\n\tv1192 = *([v1254 @ X11_v43-8]);\n\tv1260 = v1192 == v1133;\n\tif (v1260) goto L_0109;\n\tv1214 = v1255 + 1;\n\tv1273 = v1214 < v1131;\n\tv1210 = ~v1273;\n\tv1212 = v1254 + 0x10;\n\tv1194 = ~v1210;\n\tif (v1194) goto L_FFFFFFFF;\n\tv1215 = v27;\n\tv1216 = 0;\n\tv1217 = 0x8909C4(v1215, v1133, v1216, v717, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0111;\nL_0109:\n\tv1274 = *([v1254 @ X11_v43]);\n\tv1275 = v1274 << 4;\n\tv1276 = v1129 + v1275;\n\tv1277 = v1276 + 0x130;\nL_0111:\n\tv1285 = System.Collections.Generic.IList`1<System.String>::get_Item(values, v292);\n\tv1288 = v1285 == 0;\n\tif (v1288) goto L_011E;\n\t// 282 IsInst v1294 @ X0_v130, typeof(System.Object), v1285 @ X0_v78 (System.String)\n\tv1298 = v1294 == 0;\n\tif (v1298) goto L_0217;\nL_011E:\n\tv1301 = v1041.Length == 0;\n\tif (v1301) goto L_020F;\n\tv1041[0] = v1285;\n\tv1310 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v1310, \"java.lang.String\", v1041);\n\tv1362 = \"SzArrayNew\"(*([v635 @ X27_v18 (Il2CppClass<System.Object[]>)]), 3, v1041, 0, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv667 = v1362 == 0;\n\tif (v667) goto L_01CD;\n\tv1363 = v697 == 0;\n\tif (v1363) goto L_013C;\n\t// 312 IsInst v1367 @ X0_v126, typeof(System.Object), v697 @ X0_v69 (UnityEngine.AndroidJavaObject)\n\tv671 = v1367 == 0;\n\tif (v671) goto L_01DE;\nL_013C:\n\tv668 = v1362.Length == 0;\n\tif (v668) goto L_01CF;\n\tv1362[0] = v697;\n\t*([v21 @ X29-58]) = v292;\n\tv1375 = &v21 @ X29 - 0x58;\n\t// 324 Box v1376 @ X0_v102, typeof(System.Int32), v1375 @ X1_v53\n\tv1379 = v1376 == 0;\n\tif (v1379) goto L_014E;\n\t// 331 IsInst v1382 @ X0_v122, typeof(System.Object), v1376 @ X0_v102\n\tv672 = v1382 == 0;\n\tif (v672) goto L_01E3;\nL_014E:\n\tv678 = v1362.Length;\n\tv1386 = v1362.Length < 1;\n\tv625 = ~v1386;\n\tv621 = v1362.Length - 1;\n\tv613 = v621 == 0;\n\tv1387 = ~v625;\n\tv593 = v1387 | v613;\n\tif (v593) goto L_01D4;\n\tv1362[1] = v1376;\n\tv1388 = v1310 == 0;\n\tif (v1388) goto L_FFFFFFFF;\n\t// 355 IsInst v1394 @ X0_v118, typeof(System.Object), v1310 @ X0_v92 (UnityEngine.AndroidJavaObject)\n\tv673 = v1394 == 0;\n\tif (v673) goto L_01E8;\n\tv678 = v1362.Length;\n\tgoto L_016A;\nL_016A:\n\tv1400 = v678 < 2;\n\tv626 = ~v1400;\n\tv622 = v678 - 2;\n\tv614 = v622 == 0;\n\tv1401 = ~v626;\n\tv594 = v1401 | v614;\n\tif (v594) goto L_01D9;\n\tv1362[2] = v1310;\n\tUnityEngine.AndroidJavaObject::CallStatic(v61, \"set\", v1362);\n\tv227 = v227 + 1;\n\t*([v54 @ X28_v1+v227 @ X20_v7*4]) = 0x90;\nL_0181:\n\tv1410 = v1310 == 0;\n\tif (v1410) goto L_01B1;\n\tgoto L_01B0;\n\tv1451 = *([v1411 @ X8_v81+B0]);\n\tv1452 = 0;\n\tv1453 = v1451 + 8;\n\tv1455 = *([v1503 @ X11_v38-8]);\n\tv1509 = v1455 == v1415;\n\tif (v1509) goto L_01A9;\n\tv1477 = v1504 + 1;\n\tv1517 = v1477 < v1413;\n\tv1473 = ~v1517;\n\tv1475 = v1503 + 0x10;\n\tv1457 = ~v1473;\n\tif (v1457) goto L_FFFFFFFF;\n\tv1478 = v583;\n\tv1479 = 0;\n\tv1480 = 0x8909C4(v1478, v1415, v1479, v718, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01B0;\nL_01A9:\n\tv1518 = *([v1503 @ X11_v38]);\n\tv1519 = v1518 << 4;\n\tv1520 = v1411 + v1519;\n\tv1521 = v1520 + 0x130;\nL_01B0:\n\tSystem.IDisposable::Dispose(v1310);\nL_01B1:\n\tv1446 = v227 + 1;\n\tv1448 = v1446 == 0;\n\tif (v1448) goto L_01C9;\n\tv1491 = *([v54 @ X28_v1+v227 @ X20_v7*4]) != 0x90;\n\tif (v1491) goto L_01C9;\n\tv1515 = 0xFFFFFFFF ^ v227;\n\tv227 = v227 + v1515;\n\tgoto L_01CA;\nL_01C9:\n\tgoto L_0216;\nL_01CA:\n\tv292 = v292 + 1;\n\tgoto L_00AC;\nL_01CD:\n\tv658 = new System.NullReferenceException();\n\tgoto L_022F;\nL_01CF:\n\tv1377 = new System.IndexOutOfRangeException();\n\tthrow v1377;\n\tgoto L_022F;\nL_01D4:\n\tv1389 = new System.IndexOutOfRangeException();\n\tthrow v1389;\n\tgoto L_022F;\nL_01D9:\n\tv1408 = new System.IndexOutOfRangeException();\n\tthrow v1408;\n\tgoto L_022F;\nL_01DE:\n\tv1378 = new System.ArrayTypeMismatchException();\n\tthrow v1378;\n\tgoto L_022F;\nL_01E3:\n\tv1390 = new System.ArrayTypeMismatchException();\n\tthrow v1390;\n\tgoto L_022F;\nL_01E8:\n\tv1402 = new System.ArrayTypeMismatchException();\n\tthrow v1402;\n\tgoto L_022F;\n\tgoto L_01F1;\n\tgoto L_01F1;\n\tgoto L_01F1;\n\tgoto L_01F1;\nL_01F1:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0245;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX27 = *([1EFE3C0]);\n\tgoto L_0181;\nL_0205:\n\tv892 = *([v21 @ X29-60]);\n\tv898 = v227 + 1;\n\t*([v54 @ X28_v1+v898 @ X20_v12*4]) = 0xB6;\n\tv1042 = *([v21 @ X29-60]) == 0;\n\tv903 = ~v1042;\n\tif (v903) goto L_025E;\n\tgoto L_0286;\n\tv1290 = new System.NullReferenceException();\nL_020F:\n\tv1306 = new System.IndexOutOfRangeException();\n\tthrow v1306;\nL_0216:\n\tv1338 = new System.TypeLoadException();\nL_0217:\n\tv1341 = new System.ArrayTypeMismatchException();\n\tthrow v1341;\n\tv306 = new System.NullReferenceException();\nL_021D:\n\tv345 = new System.IndexOutOfRangeException();\n\tthrow v345;\nL_0221:\n\tv487 = new System.IndexOutOfRangeException();\n\tthrow v487;\n\tv404 = new System.NullReferenceException();\nL_0227:\n\tv409 = new System.ArrayTypeMismatchException();\n\tthrow v409;\nL_022B:\n\tv555 = new System.ArrayTypeMismatchException();\n\tthrow v555;\nL_022F:\n\tgoto L_0245;\n\t// 560 Jump @b\n// ... truncated")]
		internal static AndroidJavaObject CreateJavaStringArray(IList<string> values)
		{
			//IL_008e: Expected O, but got I8
			//IL_093b: Expected O, but got I
			//IL_0944: Expected I4, but got O
			//IL_013f: Expected O, but got I4
			//IL_0105: Expected O, but got I8
			//IL_01ba: Expected I, but got O
			//IL_01d0: Expected O, but got I8
			//IL_05a3: Expected O, but got I
			//IL_05b2: Expected O, but got I
			//IL_05df: Expected I, but got O
			//IL_05fb: Expected I, but got O
			//IL_0a85: Expected O, but got I
			//IL_0798: Expected O, but got I8
			//IL_0b19: Expected O, but got I
			//IL_08ec: Expected O, but got I4
			//IL_07c3: Expected O, but got I8
			//IL_0806: Expected O, but got I4
			//IL_0812: Expected I, but got O
			//IL_0823: Expected O, but got I4
			//IL_0a54: Expected O, but got I
			//IL_0331: Expected O, but got I
			//IL_033a: Expected I4, but got O
			//IL_0692: Expected O, but got I4
			//IL_069e: Expected I, but got O
			//IL_06b0: Expected O, but got I4
			//IL_038f: Expected O, but got I4
			//IL_03bb: Expected O, but got I4
			//IL_06d5: Expected I, but got O
			//IL_06ea: Expected I, but got O
			//IL_0474: Expected I, but got O
			//IL_09d0: Expected O, but got I
			//IL_04ac: Expected O, but got I
			//IL_0453: Expected O, but got I4
			//IL_0461: Expected I, but got O
			//IL_0a14: Expected O, but got I
			//IL_04f7: Expected I4, but got I8
			//IL_0505: Expected O, but got I
			//IL_0522: Expected I, but got O
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			AndroidJavaObject result;
			if (values != null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.reflect.Array");
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("java.lang.String");
				object[] array = new object[2];
				object obj5;
				if (androidJavaClass2 != null)
				{
					object obj4 = androidJavaClass2 as object;
					bool flag = obj4 == null;
					obj5 = 4294967295L;
					if (flag)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				array[0] = androidJavaClass2;
				int count = values.Count;
				object obj6 = (long)(IntPtr)obj - 84L;
				object obj7 = (int)obj6;
				if (obj7 != null)
				{
					object obj8 = obj7 as object;
					bool flag2 = obj8 == null;
					obj5 = 4294967295L;
					if (flag2)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						int num = 0;
						throw ex3;
					}
				}
				bool flag3 = array.Length < 1;
				bool flag4 = !flag3;
				object obj9 = array.Length - 1;
				bool flag5 = obj9 == null;
				bool flag6 = !flag4;
				if (flag6 || flag5)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array[1] = obj7;
				AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("newInstance", array);
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)typeof(object[]);
				int num2 = 0;
				obj5 = 4294967295L;
				object[] array2 = default(object[]);
				object[] array3 = default(object[]);
				IntPtr intPtr5;
				object obj21;
				while (true)
				{
					int count2 = values.Count;
					int num;
					IDisposable disposable;
					AndroidJavaObject androidJavaObject3;
					NullReferenceException ex14;
					int num4;
					IntPtr intPtr3;
					AndroidJavaObject androidJavaObject6;
					object obj20;
					IntPtr intPtr4;
					if (num2 < count2)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
						string text = values.get_Item(num2);
						if (text != null)
						{
							object obj10 = text as object;
							if (obj10 == null)
							{
								goto IL_062c;
							}
						}
						if (array2.Length == 0)
						{
							IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
							throw ex5;
						}
						array2[0] = text;
						AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.String", array2);
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
						if (array3 != null)
						{
							if (androidJavaObject != null)
							{
								object obj11 = androidJavaObject as object;
								if (obj11 == null)
								{
									ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
									throw ex6;
								}
							}
							if (array3.Length != 0)
							{
								array3[0] = androidJavaObject;
								object obj12 = (long)(IntPtr)obj - 88L;
								object obj13 = (int)obj12;
								if (obj13 != null)
								{
									object obj14 = obj13 as object;
									if (obj14 == null)
									{
										ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
										throw ex7;
									}
								}
								object obj15 = array3.Length;
								bool flag7 = array3.Length < 1;
								bool flag8 = !flag7;
								object obj16 = array3.Length - 1;
								bool flag9 = obj16 == null;
								bool flag10 = !flag8;
								if (!(flag10 || flag9))
								{
									array3[1] = obj13;
									if (androidJavaObject2 != null)
									{
										object obj17 = androidJavaObject2 as object;
										if (obj17 == null)
										{
											ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
											throw ex8;
										}
										obj15 = array3.Length;
										intPtr2 = (IntPtr)typeof(object[]);
									}
									else
									{
										intPtr2 = (IntPtr)typeof(object[]);
									}
									bool flag11 = (long)(IntPtr)obj15 < 2L;
									bool flag12 = !flag11;
									object obj18 = (long)(IntPtr)obj15 - 2L;
									bool flag13 = obj18 == null;
									bool flag14 = !flag12;
									if (!(flag14 || flag13))
									{
										array3[2] = androidJavaObject2;
										androidJavaClass.CallStatic("set", array3);
										obj5 = (long)(IntPtr)obj5 + 1L;
										_ = 144;
										((IDisposable)androidJavaObject2)?.Dispose();
										object obj19 = (long)(IntPtr)obj5 + 1L;
										if (obj19 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X28_v1+v227 @ X20_v7*4]");
											if ((IntPtr)0 == (IntPtr)144)
											{
												int num3 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj5);
												obj5 = (long)(IntPtr)obj5 + (long)num3;
												num2++;
												intPtr = (IntPtr)null;
												continue;
											}
										}
										TypeLoadException ex9 = new TypeLoadException();
										goto IL_062c;
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
						NullReferenceException ex13 = new NullReferenceException();
						num = 3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						disposable = (IDisposable)0;
						if (3 != 1)
						{
							androidJavaObject3 = null;
							ex14 = ex13;
							num4 = 3;
							goto IL_0aa2;
						}
						AndroidJavaObject androidJavaObject4 = ((AndroidJavaObject)(object)ex13).CallStatic<AndroidJavaObject>((string)3, (object[])(object)ex13);
						intPtr3 = (IntPtr)androidJavaObject4;
						AndroidJavaObject androidJavaObject5 = androidJavaObject4.CallStatic<AndroidJavaObject>((string)3, (object[])(object)ex13);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						bool flag15 = (IntPtr)0 == (IntPtr)0;
						intPtr = (IntPtr)null;
						androidJavaObject6 = null;
						obj20 = obj5;
						intPtr4 = (IntPtr)androidJavaObject4;
						androidJavaObject3 = null;
						if (flag15)
						{
							goto IL_0a76;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						disposable = (IDisposable)0;
						obj20 = (long)(IntPtr)obj5 + 1L;
						_ = 182;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						bool flag16 = (IntPtr)0 == (IntPtr)0;
						bool flag17 = !flag16;
						intPtr3 = (IntPtr)null;
						androidJavaObject6 = androidJavaObject;
						if (!flag17)
						{
							intPtr4 = (IntPtr)null;
							androidJavaObject3 = androidJavaObject;
							obj5 = obj20;
							goto IL_0a76;
						}
					}
					disposable.Dispose();
					intPtr4 = intPtr3;
					androidJavaObject3 = androidJavaObject6;
					obj5 = obj20;
					goto IL_0a76;
					IL_0aa2:
					if (num4 == 1)
					{
						AndroidJavaObject androidJavaObject7 = ((AndroidJavaObject)(object)ex14).CallStatic<AndroidJavaObject>((string)num, (object[])(object)ex14);
						intPtr4 = (IntPtr)androidJavaObject7;
						AndroidJavaObject androidJavaObject8 = androidJavaObject7.CallStatic<AndroidJavaObject>((string)num, (object[])(object)ex14);
						goto IL_082c;
					}
					return ((AndroidJavaObject)(object)ex14).CallStatic<AndroidJavaObject>((string)num, (object[])(object)ex14);
					IL_082c:
					bool flag18 = androidJavaClass == null;
					intPtr5 = intPtr4;
					result = androidJavaObject3;
					obj21 = obj5;
					if (flag18)
					{
						break;
					}
					goto IL_0b36;
					IL_0a76:
					object obj22 = (long)(IntPtr)obj5 + 1L;
					if (obj22 != null)
					{
						if (intPtr4 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X28_v1+v227 @ X20_v7*4]");
							if ((IntPtr)0 != (IntPtr)182)
							{
								goto IL_07c8;
							}
						}
						goto IL_082c;
					}
					if (intPtr4 != (IntPtr)0)
					{
						goto IL_07c8;
					}
					bool flag19 = androidJavaClass == null;
					bool flag20 = !flag19;
					obj5 = 4294967295L;
					if (!flag20)
					{
						intPtr5 = intPtr4;
						result = androidJavaObject3;
						obj21 = 4294967295L;
						break;
					}
					goto IL_0b36;
					IL_07c8:
					TypeLoadException ex15 = new TypeLoadException();
					num = 0;
					ex14 = (NullReferenceException)(object)ex15;
					num4 = 0;
					goto IL_0aa2;
					IL_062c:
					ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
					throw ex16;
					IL_0b36:
					((IDisposable)androidJavaClass).Dispose();
					intPtr5 = intPtr4;
					result = androidJavaObject3;
					obj21 = obj5;
					break;
				}
				object obj23 = (long)(IntPtr)obj21 + 1L;
				if (obj23 != null)
				{
					if (intPtr5 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X28_v1+v147 @ X20_v6*4]");
						if ((IntPtr)0 != (IntPtr)182)
						{
							goto IL_08a8;
						}
					}
				}
				else if (intPtr5 != (IntPtr)0)
				{
					goto IL_08a8;
				}
			}
			else
			{
				result = null;
			}
			return result;
			IL_08a8:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x161A8FC", Offset = "0x161A8FC", Length = "0x6E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1EA3A30]);\n\tv34 = *([v33 @ X8_v80]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202A2CB]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-80;\n\tv57 = value == 0;\n\tif (v57) goto L_FFFFFFFF;\n\t// 36 NewArr v62 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tgoto L_0055;\n\tv197 = *([v65 @ X8_v6+B0]);\n\tv198 = 0;\n\tv199 = v197 + 8;\n\tv201 = *([v295 @ X11_v54-8]);\n\tv301 = v201 == v69;\n\tif (v301) goto L_004E;\n\tv223 = v296 + 1;\n\tv306 = v223 < v68;\n\tv219 = ~v306;\n\tv221 = v295 + 0x10;\n\tv203 = ~v219;\n\tif (v203) goto L_FFFFFFFF;\n\tv224 = v27;\n\tv225 = 0;\n\tv226 = 0x8909C4(v224, v69, v225, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0055;\n\tgoto L_02BE;\nL_004E:\n\tv307 = *([v295 @ X11_v54]);\n\tv308 = v307 << 4;\n\tv309 = v65 + v308;\n\tv310 = v309 + 0x130;\nL_0055:\n\tv331 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(value);\n\t*([v21 @ X29-54]) = v331;\n\tv334 = &v21 @ X29 - 0x54;\n\t// 92 Box v337 @ X0_v10 (UnityEngine.AndroidJavaObject), typeof(System.Int32), v334 @ X1_v5\n\tv340 = v337 == 0;\n\tif (v340) goto L_0069;\n\t// 101 IsInst v404 @ X0_v108, typeof(System.Object), v337 @ X0_v10 (UnityEngine.AndroidJavaObject)\n\tv408 = v404 == 0;\n\tif (v408) goto L_0249;\nL_0069:\n\tv411 = v62.Length == 0;\n\tif (v411) goto L_0246;\n\tv62[0] = v337;\n\tv390 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v390, \"java.util.HashMap\", v62);\n\tv556 = UnityEngine.AndroidJavaObject::GetRawClass(v390);\n\tv564 = UnityEngine.AndroidJNIHelper::GetMethodID(v556, \"put\", \"(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;\");\n\tgoto L_00B2;\n\tv571 = *([v566 @ X8_v26+B0]);\n\tv572 = 0;\n\tv573 = v571 + 8;\n\tv575 = *([v611 @ X11_v49-8]);\n\tv617 = v575 == v569;\n\tif (v617) goto L_00AB;\n\tv597 = v612 + 1;\n\tv622 = v597 < v568;\n\tv593 = ~v622;\n\tv595 = v611 + 0x10;\n\tv577 = ~v593;\n\tif (v577) goto L_FFFFFFFF;\n\tv598 = v27;\n\tv599 = 0;\n\tv600 = 0x8909C4(v598, v569, v599, v448, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00B2;\nL_00AB:\n\tv623 = *([v611 @ X11_v49]);\n\tv624 = v623 << 4;\n\tv625 = v566 + v624;\n\tv626 = v625 + 0x130;\nL_00B2:\n\tv630 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::GetEnumerator(value);\n\tgoto L_020D;\nL_00BF:\n\tgoto L_00E6;\n\tv805 = *([v764 @ X8_v41+B0]);\n\tv806 = 0;\n\tv807 = v805 + 8;\n\tv809 = *([v898 @ X11_v39-8]);\n\tv904 = v809 == v768;\n\tif (v904) goto L_00DF;\n\tv831 = v899 + 1;\n\tv930 = v831 < v766;\n\tv827 = ~v930;\n\tv829 = v898 + 0x10;\n\tv811 = ~v827;\n\tif (v811) goto L_FFFFFFFF;\n\tv832 = v173;\n\tv833 = 0;\n\tv834 = 0x8909C4(v832, v768, v833, v641, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00E6;\nL_00DF:\n\tv931 = *([v898 @ X11_v39]);\n\tv932 = v931 << 4;\n\tv933 = v764 + v932;\n\tv934 = v933 + 0x130;\nL_00E6:\n\tv955 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Current(v630);\n\tv957 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(v955);\n\tv968 = Mycom.Tracker.Unity.Internal.Implementations.Android.JavaHelper::CreateJavaString(0);\n\tv971 = UnityEngine.AndroidJavaObject::GetRawObject(v390);\n\t// 245 NewArr v976 @ X0_v54 (System.Object[]), typeof(System.Object[]), 2\n\tv977 = v976 == 0;\n\tif (v977) goto L_01C0;\n\tv978 = v957 == 0;\n\tif (v978) goto L_0101;\n\t// 254 IsInst v984 @ X0_v95, typeof(System.Object), v957 @ X0_v48 (UnityEngine.AndroidJavaObject)\n\tv988 = v984 == 0;\n\tif (v988) goto L_01D1;\nL_0101:\n\tv1050 = v976.Length;\n\tv991 = v976.Length == 0;\n\tif (v991) goto L_01C2;\n\tv976[0] = v957;\n\tv992 = v968 == 0;\n\tif (v992) goto L_010E;\n\t// 266 IsInst v1055 @ X0_v91, typeof(System.Object), v968 @ X0_v50 (UnityEngine.AndroidJavaObject)\n\tv1047 = v1055 == 0;\n\tif (v1047) goto L_01D6;\n\tv1050 = v976.Length;\nL_010E:\n\tv1059 = v1050 < 1;\n\tv1030 = ~v1059;\n\tv1027 = v1050 - 1;\n\tv1021 = v1027 == 0;\n\tv1060 = ~v1030;\n\tv1006 = v1060 | v1021;\n\tif (v1006) goto L_01CC;\n\tv976[1] = v968;\n\tv1065 = UnityEngine.AndroidJNIHelper::CreateJNIArgArray(v976);\n\tv1072 = UnityEngine.AndroidJNI::CallObjectMethod(v971, v564, v1065);\n\tv1208 = v638 + 1;\n\t*([v54 @ X27_v1+v1208 @ X28_v18*4]) = 0xA2;\nL_0126:\n\tv1074 = v968 == 0;\n\tif (v1074) goto L_0156;\n\tgoto L_0155;\n\tv1118 = *([v1075 @ X8_v66+B0]);\n\tv1119 = 0;\n\tv1120 = v1118 + 8;\n\tv1122 = *([v1161 @ X11_v34-8]);\n\tv1167 = v1122 == v1079;\n\tif (v1167) goto L_014E;\n\tv1144 = v1162 + 1;\n\tv1199 = v1144 < v1077;\n\tv1140 = ~v1199;\n\tv1142 = v1161 + 0x10;\n\tv1124 = ~v1140;\n\tif (v1124) goto L_FFFFFFFF;\n\tv1145 = v236;\n\tv1146 = 0;\n\tv1147 = 0x8909C4(v1145, v1079, v1146, v353, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0155;\nL_014E:\n\tv1200 = *([v1161 @ X11_v34]);\n\tv1201 = v1200 << 4;\n\tv1202 = v1075 + v1201;\n\tv1203 = v1202 + 0x130;\nL_0155:\n\tSystem.IDisposable::Dispose(v968);\nL_0156:\n\tv1113 = v1208 + 1;\n\tv1115 = v1113 == 0;\n\tif (v1115) goto L_016F;\n\tv1148 = v776 == 0;\n\tif (v1148) goto L_016B;\n\tv1182 = *([v54 @ X27_v1+v1208 @ X28_v18*4]) != 0xA2;\n\tif (v1182) goto L_01CA;\nL_016B:\n\tv1194 = v957 == 0;\n\tv1195 = ~v1194;\n\tif (v1195) goto L_017C;\n\tgoto L_01A4;\nL_016F:\n\tv1149 = v776 == 0;\n\tv1150 = ~v1149;\n\tif (v1150) goto L_01CA;\nL_0174:\n\tv1219 = v957 == 0;\n\tif (v1219) goto L_01A4;\nL_017C:\n\tgoto L_01A3;\n\tv1260 = *([v1221 @ X8_v60+B0]);\n\tv1261 = 0;\n\tv1262 = v1260 + 8;\n\tv1264 = *([v1302 @ X11_v28-8]);\n\tv1308 = v1264 == v1225;\n\tif (v1308) goto L_019C;\n\tv1286 = v1303 + 1;\n\tv1314 = v1286 < v1223;\n\tv1282 = ~v1314;\n\tv1284 = v1302 + 0x10;\n\tv1266 = ~v1282;\n\tif (v1266) goto L_FFFFFFFF;\n\tv1287 = v238;\n\tv1288 = 0;\n\tv1289 = 0x8909C4(v1287, v1225, v1288, v353, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01A3;\nL_019C:\n\tv1315 = *([v1302 @ X11_v28]);\n\tv1316 = v1315 << 4;\n\tv1317 = v1221 + v1316;\n\tv1318 = v1317 + 0x130;\nL_01A3:\n\tSystem.IDisposable::Dispose(v957);\nL_01A4:\n\tv671 = v638 + 1;\n\tv1257 = v671 == 0;\n\tif (v1257) goto L_01BC;\n\tv646 = *([v54 @ X27_v1+v638 @ X28_v9*4]) != 0xA2;\n\tif (v646) goto L_01BC;\n\tv673 = 0xFFFFFFFF ^ v638;\n\tv638 = v638 + v673;\n\tgoto L_020D;\nL_01BC:\n\tv392 = v346 == 0;\n\tif (v392) goto L_020D;\n\tgoto L_0243;\nL_01C0:\n\tv980 = new System.NullReferenceException();\n\tgoto L_024E;\nL_01C2:\n\tv993 = new System.IndexOutOfRangeException();\n\tthrow v993;\n\tgoto L_024E;\nL_01CA:\n\tv1041 = new System.TypeLoadException();\n\tgoto L_024E;\nL_01CC:\n\tv1066 = new System.IndexOutOfRangeException();\n\tthrow v1066;\n\tgoto L_024E;\nL_01D1:\n\tv1052 = new System.ArrayTypeMismatchException();\n\tthrow v1052;\n\tgoto L_024E;\nL_01D6:\n\tv1068 = new System.ArrayTypeMismatchException();\n\tthrow v1068;\n\tgoto L_024E;\n\tgoto L_01E0;\n\tgoto L_01E4;\n\tgoto L_01E4;\n\tgoto L_01E4;\n\tgoto L_01E0;\nL_01E0:\n\tX8 = X1;\n\tX2 = X0;\n\tgoto L_01F6;\n\tgoto L_01E4;\nL_01E4:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01F6;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0126;\nL_01F6:\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0260;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0174;\n\tgoto L_01E0;\nL_020D:\n\tgoto L_0234;\n\tv680 = *([v674 @ X8_v30+B0]);\n\tv681 = 0;\n\tv682 = v680 + 8;\n\tv684 = *([v720 @ X11_v44-8]);\n\tv726 = v684 == v678;\n\tif (v726) goto L_022D;\n\tv706 = v721 + 1;\n\tv731 = v706 < v676;\n\tv702 = ~v731;\n\tv704 = v720 + 0x10;\n\tv686 = ~v702;\n\tif (v686) goto L_FFFFFFFF;\n\tv707 = v173;\n\tv708 = 0;\n\tv709 = 0x8909C4(v707, v678, v708, v641, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0234;\nL_022D:\n\tv732 = *([v720 @ X11_v44]);\n\tv733\n// ... truncated")]
		internal static AndroidJavaObject CreateJavaStringMap(IDictionary<string, string> value)
		{
			//IL_05fb: Expected O, but got I
			//IL_0604: Expected I4, but got O
			//IL_00f5: Expected O, but got I8
			//IL_0107: Expected O, but got I4
			//IL_0441: Expected O, but got I
			//IL_0801: Expected O, but got I
			//IL_018d: Expected O, but got I4
			//IL_04c2: Expected I4, but got O
			//IL_04f2: Expected O, but got I8
			//IL_04ff: Expected O, but got I8
			//IL_0507: Expected I4, but got O
			//IL_067e: Expected O, but got I
			//IL_025c: Expected O, but got I
			//IL_020f: Expected O, but got I4
			//IL_06c2: Expected O, but got I
			//IL_03ed: Expected O, but got I4
			//IL_0799: Expected O, but got I8
			//IL_07af: Expected O, but got I8
			//IL_06fc: Expected O, but got I
			//IL_03a3: Expected O, but got I4
			//IL_035e: Expected I4, but got I8
			//IL_036c: Expected O, but got I
			//IL_037d: Expected O, but got I4
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			AndroidJavaObject result2;
			if (value != null)
			{
				object[] array = new object[1];
				int count = value.Count;
				object obj4 = (long)(IntPtr)obj - 84L;
				AndroidJavaObject androidJavaObject = (AndroidJavaObject)(object)(int)obj4;
				if (androidJavaObject != null)
				{
					object obj5 = androidJavaObject as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						goto IL_081e;
					}
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					goto IL_081e;
				}
				array[0] = androidJavaObject;
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.HashMap", array);
				IntPtr rawClass = androidJavaObject2.GetRawClass();
				IntPtr methodID = AndroidJNIHelper.GetMethodID(rawClass, "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
				IEnumerator<KeyValuePair<string, string>> enumerator = value.GetEnumerator();
				object obj6 = 4294967295L;
				int num = 0;
				object obj7 = 0;
				object obj15;
				int num5;
				object obj17 = default(object);
				AndroidJavaObject result = default(AndroidJavaObject);
				while (true)
				{
					int num3;
					int num4;
					NullReferenceException ex7;
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, string> current = enumerator.Current;
						AndroidJavaObject androidJavaObject3 = CreateJavaString((string)current);
						AndroidJavaObject androidJavaObject4 = CreateJavaString(null);
						IntPtr rawObject = androidJavaObject2.GetRawObject();
						object[] array2 = new object[2];
						if (array2 != null)
						{
							if (androidJavaObject3 != null)
							{
								object obj8 = androidJavaObject3 as object;
								if (obj8 == null)
								{
									ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
									throw ex3;
								}
							}
							object obj9 = array2.Length;
							if (array2.Length != 0)
							{
								array2[0] = androidJavaObject3;
								if (androidJavaObject4 != null)
								{
									object obj10 = androidJavaObject4 as object;
									if (obj10 == null)
									{
										ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
										throw ex4;
									}
									obj9 = array2.Length;
								}
								bool flag = (long)(IntPtr)obj9 < 1L;
								bool flag2 = !flag;
								object obj11 = (long)(IntPtr)obj9 - 1L;
								bool flag3 = obj11 == null;
								bool flag4 = !flag2;
								if (!(flag4 || flag3))
								{
									array2[1] = androidJavaObject4;
									jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(array2);
									IntPtr intPtr = AndroidJNI.CallObjectMethod(rawObject, methodID, args);
									object obj12 = (long)(IntPtr)obj6 + 1L;
									_ = 162;
									((IDisposable)androidJavaObject4)?.Dispose();
									object obj13 = (long)(IntPtr)obj12 + 1L;
									int num2;
									if (obj13 != null)
									{
										if (num != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v1208 @ X28_v18*4]");
											if ((IntPtr)0 != (IntPtr)162)
											{
												goto IL_03db;
											}
										}
										bool flag5 = androidJavaObject3 == null;
										bool flag6 = !flag5;
										num2 = num;
										if (!flag6)
										{
											num3 = num;
											obj6 = obj12;
											goto IL_06ed;
										}
									}
									else
									{
										if (num != 0)
										{
											goto IL_03db;
										}
										bool flag7 = androidJavaObject3 == null;
										num2 = 0;
										obj12 = 4294967295L;
										num3 = 0;
										obj6 = 4294967295L;
										if (flag7)
										{
											goto IL_06ed;
										}
									}
									((IDisposable)androidJavaObject3).Dispose();
									num3 = num2;
									obj6 = obj12;
									goto IL_06ed;
								}
								IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
								throw ex5;
							}
							IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
							throw ex6;
						}
						ex7 = new NullReferenceException();
						num4 = 2;
						goto IL_0754;
					}
					object obj14 = (long)(IntPtr)obj6 + 1L;
					_ = 182;
					if (enumerator == null)
					{
						obj15 = obj14;
						num5 = num;
						break;
					}
					goto IL_0824;
					IL_06ed:
					object obj16 = (long)(IntPtr)obj6 + 1L;
					if (obj16 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v638 @ X28_v9*4]");
						if ((IntPtr)0 == (IntPtr)162)
						{
							int num6 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
							obj6 = (long)(IntPtr)obj6 + (long)num6;
							num = num3;
							obj7 = 0;
							continue;
						}
					}
					bool flag8 = num3 == 0;
					num = 0;
					obj7 = 0;
					if (flag8)
					{
						continue;
					}
					throw new TypeLoadException();
					IL_0824:
					enumerator.Dispose();
					obj15 = obj14;
					num5 = num;
					break;
					IL_0754:
					if (num4 == 1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						num = (int)obj17;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						bool flag9 = enumerator == null;
						obj14 = 4294967295L;
						obj15 = 4294967295L;
						num5 = (int)obj17;
						if (flag9)
						{
							break;
						}
						goto IL_0824;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					return result;
					IL_03db:
					TypeLoadException ex8 = new TypeLoadException();
					obj7 = 0;
					num4 = 0;
					ex7 = (NullReferenceException)(object)ex8;
					goto IL_0754;
				}
				object obj18 = (long)(IntPtr)obj15 + 1L;
				if (obj18 != null)
				{
					bool flag10 = num5 == 0;
					result2 = androidJavaObject2;
					if (!flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X27_v1+v89 @ X28_v10*4]");
						bool flag11 = (IntPtr)0 == (IntPtr)182;
						result2 = androidJavaObject2;
						if (!flag11)
						{
							goto IL_081e;
						}
					}
				}
				else
				{
					bool flag12 = num5 == 0;
					bool flag13 = !flag12;
					result2 = androidJavaObject2;
					if (flag13)
					{
						goto IL_081e;
					}
				}
			}
			else
			{
				result2 = null;
			}
			return result2;
			IL_081e:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x161BA74", Offset = "0x161BA74", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAF2D0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A2CC]) = v38;\nL_0014:\n\tv40 = javaArray == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv43 = UnityEngine.AndroidJavaObject::GetRawObject(javaArray);\n\tv49 = 0xDC4DC4(&v45 @ stack_-28_v5 (System.IntPtr), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = v49 == 0;\n\tif (v51) goto L_FFFFFFFF;\n\treturnVal1 = UnityEngine.AndroidJNIHelper::ConvertFromJNIArray(v45);\n\tgoto L_002B;\nL_002B:\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string[] CreateStringArray(AndroidJavaObject javaArray)
		{
			if (javaArray != null)
			{
				IntPtr rawObject = javaArray.GetRawObject();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC4DC4 (inside System.IntPtr::get_Size +0x148)");
				object obj = default(object);
				IntPtr array = default(IntPtr);
				if (obj != null)
				{
					return AndroidJNIHelper.ConvertFromJNIArray<string[]>(array);
				}
			}
			return null;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x161BB00", Offset = "0x161BB00", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EFDFA8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodName, args, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A2CD]) = v44;\nL_001F:\n\tv52 = UnityEngine.AndroidJavaObject::Call(javaObject, methodName, args);\n\tv55 = v52 == 0;\n\tif (v55) goto L_0030;\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(javaObject, methodName, args);\nL_0030:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string GetString(this AndroidJavaObject javaObject, string methodName, params object[] args)
		{
			AndroidJavaObject androidJavaObject = javaObject.Call<AndroidJavaObject>(methodName, args);
			bool flag = androidJavaObject == null;
			string result = (string)(object)androidJavaObject;
			if (!flag)
			{
				result = javaObject.Call<string>(methodName, args);
			}
			return result;
		}
	}
}
