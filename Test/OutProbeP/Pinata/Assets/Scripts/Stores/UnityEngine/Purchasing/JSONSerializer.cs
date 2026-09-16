using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000009")]
	internal class JSONSerializer
	{
		[Token(Token = "0x6000023")]
		[Address(RVA = "0xC62000", Offset = "0xC62000", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = UnityEngine.Purchasing.JSONSerializer::EncodeProductDef(product);\n\treturnVal1 = UnityEngine.Purchasing.MiniJson::JsonEncode(v6);\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SerializeProductDef(ProductDefinition product)
		{
			Dictionary<string, object> json = EncodeProductDef(product);
			return MiniJson.JsonEncode(json);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0xC57530", Offset = "0xC57530", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EAC7A0]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023340]) = v44;\nL_0019:\n\tv48 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v48);\n\tv53 = products == 0;\n\tif (v53) goto L_00C6;\n\tgoto L_004E;\n\tv122 = *([v55 @ X8_v15+B0]);\n\tv123 = 0;\n\tv124 = v122 + 8;\n\tv126 = *([v162 @ X11_v29-8]);\n\tv168 = v126 == v58;\n\tif (v168) goto L_0047;\n\tv148 = v163 + 1;\n\tv183 = v148 < v57;\n\tv144 = ~v183;\n\tv146 = v162 + 0x10;\n\tv128 = ~v144;\n\tif (v128) goto L_FFFFFFFF;\n\tv149 = v18;\n\tv150 = 0;\n\tv151 = 0x8909C4(v149, v58, v150, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004E;\nL_0047:\n\tv184 = *([v162 @ X11_v29]);\n\tv185 = v184 << 4;\n\tv186 = v55 + v185;\n\tv187 = v186 + 0x130;\nL_004E:\n\tv208 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.ProductDefinition>::GetEnumerator(products);\nL_005C:\n\tgoto L_0083;\n\tv346 = *([v301 @ X8_v20+B0]);\n\tv347 = 0;\n\tv348 = v346 + 8;\n\tv350 = *([v467 @ X11_v24-8]);\n\tv473 = v350 == v302;\n\tif (v473) goto L_007C;\n\tv372 = v468 + 1;\n\tv510 = v372 < v303;\n\tv368 = ~v510;\n\tv370 = v467 + 0x10;\n\tv352 = ~v368;\n\tif (v352) goto L_FFFFFFFF;\n\tv373 = v117;\n\tv374 = 0;\n\tv375 = 0x8909C4(v373, v302, v374, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0083;\nL_007C:\n\tv511 = *([v467 @ X11_v24]);\n\tv512 = v511 << 4;\n\tv513 = v301 + v512;\n\tv514 = v513 + 0x130;\nL_0083:\n\tv418 = System.Collections.IEnumerator::MoveNext(v208);\n\tv519 = v418 == 0;\n\tif (v519) goto L_00BD;\n\tgoto L_00B2;\n\tv555 = *([v542 @ X8_v23+B0]);\n\tv556 = 0;\n\tv557 = v555 + 8;\n\tv559 = *([v595 @ X11_v19-8]);\n\tv601 = v559 == v543;\n\tif (v601) goto L_00AB;\n\tv581 = v596 + 1;\n\tv606 = v581 < v544;\n\tv577 = ~v606;\n\tv579 = v595 + 0x10;\n\tv561 = ~v577;\n\tif (v561) goto L_FFFFFFFF;\n\tv582 = v117;\n\tv583 = 0;\n\tv584 = 0x8909C4(v582, v543, v583, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00B2;\nL_00AB:\n\tv607 = *([v595 @ X11_v19]);\n\tv608 = v607 << 4;\n\tv609 = v542 + v608;\n\tv610 = v609 + 0x130;\nL_00B2:\n\tv615 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductDefinition>::get_Current(v208);\n\tv378 = UnityEngine.Purchasing.JSONSerializer::EncodeProductDef(v615);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v48, v378);\n\tgoto L_005C;\nL_00BD:\n\tv546 = v208 == 0;\n\tv420 = ~v546;\n\tif (v420) goto L_00E3;\n\tgoto L_010B;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00C6:\n\tv121 = new System.NullReferenceException();\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\nL_00D5:\n\tv182 = v249 != 1;\n\tif (v182) goto L_0125;\n\tv212 = System.Collections.Generic.List`1<System.Object>::.ctor(v121);\n\tv383 = *([v212 @ X0_v21]);\n\tv300 = System.Collections.Generic.List`1<System.Object>::.ctor(v212);\n\tv308 = v208 == 0;\n\tif (v308) goto L_010B;\nL_00E3:\n\tgoto L_010A;\n\tv478 = *([v425 @ X8_v10+B0]);\n\tv479 = 0;\n\tv480 = v478 + 8;\n\tv482 = *([v530 @ X11_v8-8]);\n\tv536 = v482 == v428;\n\tif (v536) goto L_0103;\n\tv504 = v531 + 1;\n\tv547 = v504 < v427;\n\tv500 = ~v547;\n\tv502 = v530 + 0x10;\n\tv484 = ~v500;\n\tif (v484) goto L_FFFFFFFF;\n\tv505 = v421;\n\tv506 = 0;\n\tv507 = 0x8909C4(v505, v428, v506, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_010A;\nL_0103:\n\tv548 = *([v530 @ X11_v8]);\n\tv549 = v548 << 4;\n\tv550 = v425 + v549;\n\tv551 = v550 + 0x130;\nL_010A:\n\tSystem.IDisposable::Dispose(v421);\nL_010B:\n\tv456 = v220 + 1;\n\tv236 = v456 == 0;\n\tv226 = ~v236;\n\tif (v226) goto L_011F;\n\tv508 = v218 == 0;\n\tv254 = ~v508;\n\tif (v254) goto L_0124;\nL_011F:\n\treturnVal2 = UnityEngine.Purchasing.MiniJson::JsonEncode(v48);\n\treturn returnVal2;\nL_0124:\n\tv252 = new System.TypeLoadException();\nL_0125:\n\treturnVal1 = System.Collections.Generic.List`1<System.Object>::.ctor(v121);\n\treturn returnVal1;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SerializeProductDefs(IEnumerable<ProductDefinition> products)
		{
			//IL_00b6: Expected I4, but got O
			//IL_00e3: Expected I4, but got O
			List<object> list = new List<object>();
			int num;
			int num2;
			IDisposable disposable;
			int num3;
			int num4;
			NullReferenceException ex;
			if (products == null)
			{
				ex = (NullReferenceException)(object)new List<object>();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					goto IL_014f;
				}
				object obj = default(object);
				num = (int)obj;
				IEnumerator<ProductDefinition> enumerator = default(IEnumerator<ProductDefinition>);
				bool flag = enumerator == null;
				num2 = -1;
				disposable = enumerator;
				num3 = (int)obj;
				num4 = -1;
				if (flag)
				{
					goto IL_01d6;
				}
			}
			else
			{
				IEnumerator<ProductDefinition> enumerator = products.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProductDefinition current = enumerator.Current;
					Dictionary<string, object> item = EncodeProductDef(current);
					list.Add(item);
				}
				bool flag2 = enumerator == null;
				bool flag3 = !flag2;
				num = 0;
				num2 = 0;
				disposable = enumerator;
				if (!flag3)
				{
					num3 = 0;
					num4 = 0;
					goto IL_01d6;
				}
			}
			disposable.Dispose();
			num3 = num;
			num4 = num2;
			goto IL_01d6;
			IL_01d6:
			if (num4 + 1 != 0 || num3 == 0)
			{
				return MiniJson.JsonEncode(list);
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_014f;
			IL_014f:
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xC627A4", Offset = "0xC627A4", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EC4F40]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023341]) = v44;\nL_0019:\n\tv48 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v48);\n\tv53 = products == 0;\n\tif (v53) goto L_00C6;\n\tgoto L_004E;\n\tv122 = *([v55 @ X8_v15+B0]);\n\tv123 = 0;\n\tv124 = v122 + 8;\n\tv126 = *([v162 @ X11_v29-8]);\n\tv168 = v126 == v58;\n\tif (v168) goto L_0047;\n\tv148 = v163 + 1;\n\tv183 = v148 < v57;\n\tv144 = ~v183;\n\tv146 = v162 + 0x10;\n\tv128 = ~v144;\n\tif (v128) goto L_FFFFFFFF;\n\tv149 = v18;\n\tv150 = 0;\n\tv151 = 0x8909C4(v149, v58, v150, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_004E;\nL_0047:\n\tv184 = *([v162 @ X11_v29]);\n\tv185 = v184 << 4;\n\tv186 = v55 + v185;\n\tv187 = v186 + 0x130;\nL_004E:\n\tv208 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.Extension.ProductDescription>::GetEnumerator(products);\nL_005C:\n\tgoto L_0083;\n\tv346 = *([v301 @ X8_v20+B0]);\n\tv347 = 0;\n\tv348 = v346 + 8;\n\tv350 = *([v467 @ X11_v24-8]);\n\tv473 = v350 == v302;\n\tif (v473) goto L_007C;\n\tv372 = v468 + 1;\n\tv510 = v372 < v303;\n\tv368 = ~v510;\n\tv370 = v467 + 0x10;\n\tv352 = ~v368;\n\tif (v352) goto L_FFFFFFFF;\n\tv373 = v117;\n\tv374 = 0;\n\tv375 = 0x8909C4(v373, v302, v374, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0083;\nL_007C:\n\tv511 = *([v467 @ X11_v24]);\n\tv512 = v511 << 4;\n\tv513 = v301 + v512;\n\tv514 = v513 + 0x130;\nL_0083:\n\tv418 = System.Collections.IEnumerator::MoveNext(v208);\n\tv519 = v418 == 0;\n\tif (v519) goto L_00BD;\n\tgoto L_00B2;\n\tv555 = *([v542 @ X8_v23+B0]);\n\tv556 = 0;\n\tv557 = v555 + 8;\n\tv559 = *([v595 @ X11_v19-8]);\n\tv601 = v559 == v543;\n\tif (v601) goto L_00AB;\n\tv581 = v596 + 1;\n\tv606 = v581 < v544;\n\tv577 = ~v606;\n\tv579 = v595 + 0x10;\n\tv561 = ~v577;\n\tif (v561) goto L_FFFFFFFF;\n\tv582 = v117;\n\tv583 = 0;\n\tv584 = 0x8909C4(v582, v543, v583, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00B2;\nL_00AB:\n\tv607 = *([v595 @ X11_v19]);\n\tv608 = v607 << 4;\n\tv609 = v542 + v608;\n\tv610 = v609 + 0x130;\nL_00B2:\n\tv615 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.Extension.ProductDescription>::get_Current(v208);\n\tv378 = UnityEngine.Purchasing.JSONSerializer::EncodeProductDesc(v615);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v48, v378);\n\tgoto L_005C;\nL_00BD:\n\tv546 = v208 == 0;\n\tv420 = ~v546;\n\tif (v420) goto L_00E3;\n\tgoto L_010B;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00C6:\n\tv121 = new System.NullReferenceException();\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\n\tgoto L_00D5;\nL_00D5:\n\tv182 = v249 != 1;\n\tif (v182) goto L_0125;\n\tv212 = System.Collections.Generic.List`1<System.Object>::.ctor(v121);\n\tv383 = *([v212 @ X0_v21]);\n\tv300 = System.Collections.Generic.List`1<System.Object>::.ctor(v212);\n\tv308 = v208 == 0;\n\tif (v308) goto L_010B;\nL_00E3:\n\tgoto L_010A;\n\tv478 = *([v425 @ X8_v10+B0]);\n\tv479 = 0;\n\tv480 = v478 + 8;\n\tv482 = *([v530 @ X11_v8-8]);\n\tv536 = v482 == v428;\n\tif (v536) goto L_0103;\n\tv504 = v531 + 1;\n\tv547 = v504 < v427;\n\tv500 = ~v547;\n\tv502 = v530 + 0x10;\n\tv484 = ~v500;\n\tif (v484) goto L_FFFFFFFF;\n\tv505 = v421;\n\tv506 = 0;\n\tv507 = 0x8909C4(v505, v428, v506, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_010A;\nL_0103:\n\tv548 = *([v530 @ X11_v8]);\n\tv549 = v548 << 4;\n\tv550 = v425 + v549;\n\tv551 = v550 + 0x130;\nL_010A:\n\tSystem.IDisposable::Dispose(v421);\nL_010B:\n\tv456 = v220 + 1;\n\tv236 = v456 == 0;\n\tv226 = ~v236;\n\tif (v226) goto L_011F;\n\tv508 = v218 == 0;\n\tv254 = ~v508;\n\tif (v254) goto L_0124;\nL_011F:\n\treturnVal2 = UnityEngine.Purchasing.MiniJson::JsonEncode(v48);\n\treturn returnVal2;\nL_0124:\n\tv252 = new System.TypeLoadException();\nL_0125:\n\treturnVal1 = System.Collections.Generic.List`1<System.Object>::.ctor(v121);\n\treturn returnVal1;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string SerializeProductDescs(IEnumerable<ProductDescription> products)
		{
			//IL_00b6: Expected I4, but got O
			//IL_00e3: Expected I4, but got O
			List<object> list = new List<object>();
			int num;
			int num2;
			IDisposable disposable;
			int num3;
			int num4;
			NullReferenceException ex;
			if (products == null)
			{
				ex = (NullReferenceException)(object)new List<object>();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					goto IL_014f;
				}
				object obj = default(object);
				num = (int)obj;
				IEnumerator<ProductDescription> enumerator = default(IEnumerator<ProductDescription>);
				bool flag = enumerator == null;
				num2 = -1;
				disposable = enumerator;
				num3 = (int)obj;
				num4 = -1;
				if (flag)
				{
					goto IL_01d6;
				}
			}
			else
			{
				IEnumerator<ProductDescription> enumerator = products.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProductDescription current = enumerator.Current;
					Dictionary<string, object> item = EncodeProductDesc(current);
					list.Add(item);
				}
				bool flag2 = enumerator == null;
				bool flag3 = !flag2;
				num = 0;
				num2 = 0;
				disposable = enumerator;
				if (!flag3)
				{
					num3 = 0;
					num4 = 0;
					goto IL_01d6;
				}
			}
			disposable.Dispose();
			num3 = num;
			num4 = num2;
			goto IL_01d6;
			IL_01d6:
			if (num4 + 1 != 0 || num3 == 0)
			{
				return MiniJson.JsonEncode(list);
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_014f;
			IL_014f:
			string result = default(string);
			return result;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xC58D04", Offset = "0xC58D04", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EDC6B8]);\n\tv35 = *([v34 @ X8_v61]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023342]) = v54;\nL_0022:\n\tv62 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0049;\n\tgoto L_FFFFFFFF;\n\tv85 = v85_asT == 0;\n\tif (v85) goto L_0132;\nL_0049:\n\tv121 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::.ctor(v121);\n\tv328 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v62);\nL_006A:\n\t;\n\tv452 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(&v163 @ stack_-A8_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), *([v159 @ X25_v9 (Il2CppMethodInfo)]));\n\tv454 = v452 & 1;\n\tv455 = v454 == 0;\n\tif (v455) goto L_012A;\n\tv474 = *([v386 @ stack_-98 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)]);\n\tv475 = *([v157 @ X26_v9 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv476 = *([v474 @ X8_v25 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]) < *([v475 @ X1_v18 (UnityEngine.Purchasing.Extension.ProductDescription)+128]);\n\tv477 = ~v476;\n\tv485 = ~v477;\n\tif (v485) goto L_012D;\n\tv414 = *([v475 @ X1_v18 (UnityEngine.Purchasing.Extension.ProductDescription)+128]) << 3;\n\tv531 = *([v474 @ X8_v25 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]) + v414;\n\tv416 = *([v531 @ X8_v28-8]) != v475;\n\tif (v416) goto L_012D;\n\tv617 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v386, *([v155 @ X27_v9 (System.String)]), &v220 @ stack_-88_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>));\n\tv673 = v617 == 0;\n\tif (v673) goto L_010B;\n\tv559 = v220 == 0;\n\tif (v559) goto L_00BA;\n\tv560 = *([v220 @ stack_-88_v9 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)]);\n\tv555 = *([v157 @ X26_v9 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv678 = *([v560 @ X8_v51 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]) < *([v555 @ X1_v29 (UnityEngine.Purchasing.Extension.ProductDescription)+128]);\n\tv552 = ~v678;\n\tv536 = ~v552;\n\tif (v536) goto L_0130;\n\tv535 = *([v555 @ X1_v29 (UnityEngine.Purchasing.Extension.ProductDescription)+128]) << 3;\n\tv688 = *([v560 @ X8_v51 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]) + v535;\n\tv537 = *([v688 @ X8_v53-8]) != v555;\n\tif (v537) goto L_0130;\nL_00BA:\n\tv681 = UnityEngine.Purchasing.JSONSerializer::DeserializeMetadata(v220);\n\tv691 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v386, *([v151 @ X24_v9 (System.String)]), &v216 @ stack_-90_v8 (System.String));\n\tv693 = v691 == 0;\n\tif (v693) goto L_0119;\n\tv698 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v386, \"receipt\");\n\tv707 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v386, \"transactionId\");\n\tv376 = new UnityEngine.Purchasing.Extension.ProductDescription();\n\tv378 = v216 == 0;\n\tif (v378) goto L_00F3;\n\tv354 = *([v216 @ stack_-90_v8 (System.String)]) != System.String;\n\tif (v354) goto L_0138;\nL_00F3:\n\tUnityEngine.Purchasing.Extension.ProductDescription::.ctor(v376, v216, v681, v698, v707, 1);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Extension.ProductDescription>::Add(v121, v376);\n\tgoto L_006A;\nL_010B:\n\tgoto L_0111;\n\tv682 = *([v674 @ X0_v44+E0]);\n\tv683 = v682 == 0;\n\tv684 = ~v683;\n\tif (v684) goto L_0111;\n\tv686 = \"il2cpp_codegen_runtime_class_init\"(v674, v615, v404, v406, v128, v130, v126, v43, v161, v45, v46, v47, v48, v49, v50, v51);\nL_0111:\n\t;\n\tUnityEngine.Debug::Log(*([v145 @ X28_v9 (System.String)]));\n\tgoto L_006A;\nL_0119:\n\tgoto L_0121;\n\tv708 = *([v699 @ X0_v52+E0]);\n\tv709 = v708 == 0;\n\tv710 = ~v709;\n\tif (v710) goto L_0121;\n\tv712 = \"il2cpp_codegen_runtime_class_init\"(v699, v660, v336, v338, v128, v130, v126, v43, v161, v45, v46, v47, v48, v49, v50, v51);\nL_0121:\n\treturnVal3 = 0xC713B8(*([v198 @ X19_v10 (Il2CppClass<UnityEngine.Debug>)]), *([v151 @ X24_v9 (System.String)]), &v216 @ stack_-90_v8 (System.String), *([v153 @ X23_v9 (Il2CppMethodInfo)]), v707, 1, 0, v43, v163, v45, v46, v47, v48, v49, v50, v51);\n\treturn returnVal3;\n\tX1 = 0;\n\tUnityEngine.Debug::Log(X0, X1);\n\tgoto L_006A;\nL_012A:\n\tv471 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v163 @ stack_-A8_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_016B;\nL_012D:\n\tthrow System.InvalidCastException;\n\tv514 = new System.NullReferenceException();\nL_0130:\n\tthrow System.InvalidCastException;\nL_0132:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0138:\n\tv384 = new System.InvalidCastException();\n\tgoto L_0143;\n\tgoto L_0143;\n\tgoto L_0143;\n\tgoto L_0143;\n\tgoto L_0143;\n\tgoto L_0150;\n\tgoto L_0143;\n\tgoto L_0143;\n\tgoto L_0143;\nL_0143:\n\tgoto L_0150;\n\tgoto L_0150;\n\tgoto L_0150;\n\tgoto L_0150;\nL_0150:\n\tv465 = System.String != 1;\n\tif (v465) goto L_016C;\n\tv472 = 0x6D2BC0(v384, System.String, &v216 @ stack_-90_v8 (System.String), *([v153 @ X23_v9 (Il2CppMethodInfo)]), v707, 1, 0, v43, v163, v45, v46, v47, v48, v49, v50, v51);\n\tv516 = 0x6D2490(v472, System.String, &v216 @ stack_-90_v8 (System.String), *([v153 @ X23_v9 (Il2CppMethodInfo)]), v707, 1, 0, v43, v163, v45, v46, v47, v48, v49, v50, v51);\n\tv520 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v341 @ stack_-80_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv671 = *([v472 @ X0_v13]) == 0;\n\tv522 = ~v671;\n\tif (v522) goto L_0170;\nL_016B:\n\treturn v581;\nL_016C:\n\tv473 = 0x6D2380(v384, System.String, &v216 @ stack_-90_v8 (System.String), *([v153 @ X23_v9 (Il2CppMethodInfo)]), v707, 1, 0, v43, v163, v45, v46, v47, v48, v49, v50, v51);\nL_0170:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 257 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static List<ProductDescription> DeserializeProductDescriptions(string json)
		{
			//IL_007f: Expected I, but got O
			//IL_009b: Expected I, but got O
			//IL_0491: Expected O, but got I
			//IL_00a8: Expected I, but got O
			//IL_00b0: Expected O, but got I
			//IL_0120: Expected O, but got I
			//IL_01a1: Expected I, but got O
			//IL_01a9: Expected O, but got I
			//IL_0219: Expected O, but got I
			object obj = MiniJson.JsonDecode(json);
			if (obj != null)
			{
				List<object> list = obj as List<object>;
				if (list == null)
				{
					throw new InvalidCastException();
				}
			}
			List<ProductDescription> list2 = new List<ProductDescription>();
			object enumerator = ((List<object>)obj).GetEnumerator();
			string message = "Metadata key not found in product description json";
			string key = "storeSpecificId";
			IntPtr intPtr = (IntPtr)0;
			string key2 = "metadata";
			IntPtr intPtr2 = (IntPtr)typeof(Dictionary<string, object>);
			IntPtr intPtr3 = (IntPtr)0;
			List<ProductDescription> result = list2;
			IntPtr intPtr4 = (IntPtr)typeof(Debug);
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			object obj2 = default(object);
			Dictionary<string, object> dictionary = default(Dictionary<string, object>);
			object obj5 = default(object);
			List<ProductDescription> result2 = default(List<ProductDescription>);
			while (true)
			{
				((List<ProductDescription>)enumerator2).Add((ProductDescription)(long)intPtr3);
				Dictionary<string, object> value;
				if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
				{
					IntPtr intPtr5 = (IntPtr)dictionary;
					ProductDescription productDescription = (ProductDescription)(long)intPtr2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v25 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]");
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X1_v18 (UnityEngine.Purchasing.Extension.ProductDescription)+128]");
					if ((long)intPtr6 >= 0L)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ X1_v18 (UnityEngine.Purchasing.Extension.ProductDescription)+128]");
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v25 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]");
						object obj3 = 0L + (long)num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ X8_v28-8]");
						if ((IntPtr)0 == (IntPtr)productDescription)
						{
							if (dictionary.TryGetValue(key2, out *(object*)(&value)))
							{
								if (value != null)
								{
									IntPtr intPtr7 = (IntPtr)value;
									ProductDescription productDescription2 = (ProductDescription)(long)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X8_v51 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]");
									IntPtr intPtr8 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ X1_v29 (UnityEngine.Purchasing.Extension.ProductDescription)+128]");
									if ((long)intPtr8 >= 0L)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ X1_v29 (UnityEngine.Purchasing.Extension.ProductDescription)+128]");
										int num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X8_v51 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]");
										object obj4 = 0L + (long)num2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ X8_v53-8]");
										if ((IntPtr)0 == (IntPtr)productDescription2)
										{
											goto IL_0242;
										}
									}
									throw new InvalidCastException();
								}
								goto IL_0242;
							}
							Debug.Log(message);
							continue;
						}
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				goto IL_0432;
				IL_0432:
				return result;
				IL_0242:
				ProductMetadata metadata = DeserializeMetadata(value);
				string value2;
				if (dictionary.TryGetValue(key, out *(object*)(&value2)))
				{
					string receipt = dictionary.TryGetString("receipt");
					string transactionId = dictionary.TryGetString("transactionId");
					ProductDescription item = new ProductDescription(value2, metadata, receipt, transactionId, ProductType.NonConsumable);
					if (value2 != null)
					{
						bool flag = (object)value2.GetType() != typeof(string);
						List<object>.Enumerator enumerator3 = enumerator2;
						if (flag)
						{
							InvalidCastException ex = new InvalidCastException();
							if ((IntPtr)typeof(string) == (IntPtr)1)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								enumerator3.Dispose();
								bool flag2 = obj5 == null;
								bool flag3 = !flag2;
								result = list2;
								if (flag3)
								{
									break;
								}
								goto IL_0432;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							break;
						}
					}
					list2.Add(item);
					message = "Metadata key not found in product description json";
					intPtr = (IntPtr)0;
					result = list2;
					continue;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C713B8 (inside UnityEngine.Purchasing.StoreCatalogImpl::handleCachedCatalog +0x1FC)");
				return result2;
			}
			return (List<ProductDescription>)(object)new TypeLoadException();
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xC595E4", Offset = "0xC595E4", Length = "0x49C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1ED3610]);\n\tv35 = *([v34 @ X8_v67]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023343]) = v54;\nL_0020:\n\tv60 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0047;\n\tgoto L_FFFFFFFF;\n\tv83 = v83_asT == 0;\n\tif (v83) goto L_0146;\nL_0047:\n\tv119 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v119);\n\tv248 = v60 == 0;\n\tif (v248) goto L_014C;\n\tv305 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v60);\nL_0067:\n\t;\n\tv379 = System.Collections.Generic.Dictionary`2<System.String, System.String>::Add(&v150 @ stack_-98_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), *([v369 @ X9_v9 (Il2CppMethodInfo)]), v291);\n\tv390 = v379 & 1;\n\tv391 = v390 == 0;\n\tif (v391) goto L_013B;\n\tv416 = *([v341 @ stack_-88]);\n\tv417 = *([v208 @ X21_v9 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv421 = *([v416 @ X8_v25+128]) < *([v417 @ X1_v18 (System.String)+128]);\n\tv422 = ~v421;\n\tv430 = ~v422;\n\tif (v430) goto L_013E;\n\tv473 = *([v417 @ X1_v18 (System.String)+128]) << 3;\n\tv474 = *([v416 @ X8_v25+C8]) + v473;\n\tv485 = *([v474 @ X8_v29-8]) != v417;\n\tif (v485) goto L_013E;\n\tv591 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v341, \"metadata\");\n\tv615 = v591 == 0;\n\tif (v615) goto L_00BC;\n\tv616 = *([v591 @ X0_v47 (System.Collections.Generic.Dictionary`2<System.String, System.Object>)]);\n\tv612 = *([v208 @ X21_v9 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv619 = *([v616 @ X8_v57 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]) < *([v612 @ X1_v44 (System.String)+128]);\n\tv609 = ~v619;\n\tv593 = ~v609;\n\tif (v593) goto L_0140;\n\tv592 = *([v612 @ X1_v44 (System.String)+128]) << 3;\n\tv636 = *([v616 @ X8_v57 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]) + v592;\n\tv594 = *([v636 @ X8_v59-8]) != v612;\n\tif (v594) goto L_0140;\nL_00BC:\n\tv238 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v341, \"storeSpecificId\");\n\tv240 = v238 == 0;\n\tif (v240) goto L_00D2;\n\tv214 = *([v238 @ X0_v49 (System.String)]) != System.String;\n\tif (v214) goto L_0148;\nL_00D2:\n\tv646 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v646);\n\tv502 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v591, \"introductoryPrice\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, \"introductoryPrice\", v502);\n\tv660 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v591, \"introductoryPriceLocale\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, \"introductoryPriceLocale\", v660);\n\tv255 = \"introductoryPriceNumberOfPeriods\";\n\tv667 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v591, *([v255 @ X23_v12 (System.String)]));\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, *([v255 @ X23_v12 (System.String)]), v667);\n\tv674 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v591, \"numberOfUnits\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, \"numberOfUnits\", v674);\n\tv681 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v591, \"unit\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, \"unit\", v681);\n\tv691 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v646, \"numberOfUnits\");\n\tv693 = System.String::IsNullOrEmpty(v691);\n\tv695 = v693 == 0;\n\tv696 = ~v695;\n\tif (v696) goto L_0128;\n\tv702 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v646, \"unit\");\n\tv711 = System.String::IsNullOrEmpty(v702);\n\tv713 = v711 == 0;\n\tif (v713) goto L_0128;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v646, \"unit\", \"0\");\nL_0128:\n\tv291 = UnityEngine.Purchasing.MiniJson::JsonEncode(v646);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v119, v238, v291);\n\tgoto L_0067;\nL_013B:\n\tv400 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v150 @ stack_-98_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_018C;\nL_013E:\n\tthrow System.InvalidCastException;\nL_0140:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0146:\n\tthrow System.InvalidCastException;\nL_0148:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_014C:\n\tv339 = new System.NullReferenceException();\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\n\tgoto L_0171;\nL_0171:\n\tv389 = Il2CppMethodInfo != 1;\n\tif (v389) goto L_018D;\n\tv392 = System.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v339);\n\tv402 = System.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v392);\n\tv406 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v310 @ stack_-80_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv551 = *([v392 @ X0_v13 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]) == 0;\n\tv408 = ~v551;\n\tif (v408) goto L_0191;\nL_018C:\n\treturn v535;\nL_018D:\n\tv393 = System.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v339);\nL_0191:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 278 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Dictionary<string, string> DeserializeSubscriptionDescriptions(string json)
		{
			//IL_008d: Expected I, but got O
			//IL_051c: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_0177: Expected I, but got O
			//IL_017f: Expected O, but got I
			//IL_01ef: Expected O, but got I
			//IL_042c: Expected I, but got O
			object obj = MiniJson.JsonDecode(json);
			if (obj != null)
			{
				List<object> list = obj as List<object>;
				if (list == null)
				{
					throw new InvalidCastException();
				}
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			bool flag = obj == null;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			Dictionary<string, string> result = dictionary;
			if (!flag)
			{
				object enumerator2 = ((List<object>)obj).GetEnumerator();
				IntPtr intPtr = (IntPtr)typeof(Dictionary<string, object>);
				IntPtr intPtr2 = (IntPtr)0;
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				string value = default(string);
				object obj2 = default(object);
				object obj4 = default(object);
				while (true)
				{
					((Dictionary<string, string>)enumerator3).Add((string)(long)intPtr2, value);
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					object obj3 = obj4;
					string text = (string)(long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v25+128]");
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X1_v18 (System.String)+128]");
					Dictionary<string, object> dictionary2;
					if ((long)intPtr3 >= 0L)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X1_v18 (System.String)+128]");
						int num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X8_v25+C8]");
						object obj5 = 0L + (long)num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ X8_v29-8]");
						if ((IntPtr)0 == (IntPtr)text)
						{
							dictionary2 = (Dictionary<string, object>)((Dictionary<string, object>)obj4).get_Item("metadata");
							if (dictionary2 != null)
							{
								IntPtr intPtr4 = (IntPtr)dictionary2;
								string text2 = (string)(long)intPtr;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ X8_v57 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+128]");
								IntPtr intPtr5 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X1_v44 (System.String)+128]");
								if ((long)intPtr5 >= 0L)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X1_v44 (System.String)+128]");
									int num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ X8_v57 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+C8]");
									object obj6 = 0L + (long)num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X8_v59-8]");
									if ((IntPtr)0 == (IntPtr)text2)
									{
										goto IL_0217;
									}
								}
								throw new InvalidCastException();
							}
							goto IL_0217;
						}
					}
					throw new InvalidCastException();
					IL_0217:
					string text3 = (string)((Dictionary<string, object>)obj4).get_Item("storeSpecificId");
					if (text3 == null || (object)text3.GetType() == typeof(string))
					{
						Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
						string value2 = dictionary2.TryGetString("introductoryPrice");
						dictionary3.set_Item("introductoryPrice", value2);
						string value3 = dictionary2.TryGetString("introductoryPriceLocale");
						dictionary3.set_Item("introductoryPriceLocale", value3);
						string key = "introductoryPriceNumberOfPeriods";
						string value4 = dictionary2.TryGetString(key);
						dictionary3.set_Item(key, value4);
						string value5 = dictionary2.TryGetString("numberOfUnits");
						dictionary3.set_Item("numberOfUnits", value5);
						string value6 = dictionary2.TryGetString("unit");
						dictionary3.set_Item("unit", value6);
						string value7 = dictionary3.get_Item("numberOfUnits");
						if (!string.IsNullOrEmpty(value7))
						{
							string value8 = dictionary3.get_Item("unit");
							if (string.IsNullOrEmpty(value8))
							{
								dictionary3.set_Item("unit", "0");
							}
						}
						value = MiniJson.JsonEncode(dictionary3);
						dictionary.Add(text3, value);
						intPtr = (IntPtr)typeof(Dictionary<string, object>);
						intPtr2 = (IntPtr)0;
						continue;
					}
					throw new InvalidCastException();
				}
				enumerator3.Dispose();
				result = dictionary;
				goto IL_04c8;
			}
			NullReferenceException ex = (NullReferenceException)(object)new Dictionary<string, string>();
			if ((IntPtr)0 == (IntPtr)1)
			{
				enumerator.Dispose();
				Dictionary<string, string> dictionary4 = default(Dictionary<string, string>);
				if (dictionary4 == null)
				{
					goto IL_04c8;
				}
			}
			return (Dictionary<string, string>)(object)new TypeLoadException();
			IL_04c8:
			return result;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xC62ED0", Offset = "0xC62ED0", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EBF930]);\n\tv33 = *([v32 @ X8_v40]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023344]) = v52;\nL_001C:\n\tv55 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tv57 = v55 == 0;\n\tif (v57) goto L_0049;\n\tgoto L_FFFFFFFF;\n\tv78 = v78_asT == 0;\n\tif (v78) goto L_0108;\nL_0049:\n\tgoto L_0051;\n\tv173 = *([v114 @ X0_v14+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_0051;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v114, v106, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0051:\n\tv182 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.PurchaseFailureReason);\n\tv263 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v55, \"reason\");\n\tgoto L_006D;\n\tv309 = *([v305 @ X8_v10+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_006D;\n\tv376 = v305;\n\tv314 = \"il2cpp_codegen_runtime_class_init\"(v376, v261, v262, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006D:\n\tv317 = v263 == 0;\n\tif (v317) goto L_007F;\n\tv388 = *([v263 @ X0_v19 (System.Object)]) != System.String;\n\tif (v388) goto L_0106;\nL_007F:\n\tv403 = System.Enum::IsDefined(v182, v263);\n\tv439 = v403 == 0;\n\tif (v439) goto L_FFFFFFFF;\n\tgoto L_0090;\n\tv446 = *([v440 @ X0_v35+E0]);\n\tv447 = v446 == 0;\n\tv448 = ~v447;\n\tif (v448) goto L_0090;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v440, v401, v402, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0090:\n\tv455 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.PurchaseFailureReason);\n\tv480 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v55, \"reason\");\n\tv486 = System.Enum;\n\tv488 = *([v486 @ X8_v25 (Il2CppClass<System.Enum>)+12F]) & 2;\n\tv489 = v488 == 0;\n\tif (v489) goto L_009F;\n\tv495 = *([v486 @ X8_v25 (Il2CppClass<System.Enum>)+E0]) == 0;\n\tif (v495) goto L_0101;\nL_009F:\n\tv498 = v480 == 0;\n\tif (v498) goto L_00B1;\nL_00AC:\n\tv408 = *([v480 @ X0_v40 (System.String)]) != System.String;\n\tif (v408) goto L_0106;\nL_00B1:\n\tv249 = System.Enum::Parse(v455, v480);\n\tv274 = v274_asT == 0;\n\tif (v274) goto L_010C;\n\tv469 = \"il2cpp_vm_object_unbox\"(v249, UnityEngine.Purchasing.PurchaseFailureReason, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv436 = *([v469 @ X0_v44]);\n\tgoto L_00CE;\nL_00CE:\n\tv477 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v55, \"productId\");\n\tv485 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v55, \"message\");\n\tv431 = new UnityEngine.Purchasing.Extension.PurchaseFailureDescription();\n\tv367 = v477 == 0;\n\tif (v367) goto L_00F0;\n\tv409 = *([v477 @ X0_v28 (System.String)]) != System.String;\n\tif (v409) goto L_0106;\nL_00F0:\n\tUnityEngine.Purchasing.Extension.PurchaseFailureDescription::.ctor(v431, v477, v436, v485);\n\treturn v431;\nL_0101:\n\tv510 = v480 == 0;\n\tv501 = ~v510;\n\tif (v501) goto L_00AC;\n\tgoto L_00B1;\nL_0106:\n\tthrow System.InvalidCastException;\nL_0108:\n\tthrow System.InvalidCastException;\n\tv212 = new System.NullReferenceException();\n\tv257 = new System.NullReferenceException();\nL_010C:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PurchaseFailureDescription DeserializeFailureReason(string json)
		{
			//IL_0110: Expected I, but got O
			//IL_01d2: Expected I4, but got O
			//IL_0206: Expected I4, but got O
			object obj = MiniJson.JsonDecode(json);
			if (obj != null)
			{
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				if (dictionary == null)
				{
					throw new InvalidCastException();
				}
			}
			Type typeFromHandle = typeof(PurchaseFailureReason);
			object obj2 = ((Dictionary<string, object>)obj).get_Item("reason");
			if (obj2 != null && (object)obj2.GetType() != typeof(string))
			{
				goto IL_0292;
			}
			Type typeFromHandle2;
			string text;
			if (Enum.IsDefined(typeFromHandle, obj2))
			{
				typeFromHandle2 = typeof(PurchaseFailureReason);
				text = (string)((Dictionary<string, object>)obj).get_Item("reason");
				IntPtr intPtr = (IntPtr)typeof(Enum);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X8_v25 (Il2CppClass<System.Enum>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ X8_v25 (Il2CppClass<System.Enum>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if (text != null)
						{
							goto IL_0185;
						}
						goto IL_01af;
					}
				}
				if (text != null)
				{
					goto IL_0185;
				}
				goto IL_01af;
			}
			int reason = 7;
			goto IL_02d6;
			IL_0185:
			if ((object)text.GetType() == typeof(string))
			{
				goto IL_01af;
			}
			goto IL_0292;
			IL_01af:
			object obj3 = Enum.Parse(typeFromHandle2, text);
			if ((int)((obj3 is PurchaseFailureReason) ? obj3 : null) != 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj4 = default(object);
				reason = (int)obj4;
				goto IL_02d6;
			}
			return (PurchaseFailureDescription)(object)new InvalidCastException();
			IL_0292:
			throw new InvalidCastException();
			IL_02d6:
			string text2 = (string)((Dictionary<string, object>)obj).get_Item("productId");
			string message = ((Dictionary<string, object>)obj).TryGetString("message");
			PurchaseFailureDescription result = new PurchaseFailureDescription(text2, (PurchaseFailureReason)reason, message);
			if (text2 == null || (object)text2.GetType() == typeof(string))
			{
				return result;
			}
			goto IL_0292;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xC62BF8", Offset = "0xC62BF8", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EA4100]);\n\tv29 = *([v28 @ X8_v27]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023345]) = v48;\nL_001F:\n\tv146 = 0;\n\tv58 = 0xEA3E34(&v146 @ stack_-60_v2 (System.Decimal), 0, 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv59 = data == 0;\n\tif (v59) goto L_0073;\n\tv67 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(data, \"localizedPrice\");\n\tgoto L_003B;\n\tv77 = *([v73 @ X0_v35+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_003B;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, v64, v65, v54, v55, v51, v56, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_003B:\n\tv86 = System.Convert::ToDecimal(v67);\nL_0042:\n\tv164 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(data, \"localizedPriceString\");\n\tv175 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(data, \"localizedTitle\");\n\tv182 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(data, \"localizedDescription\");\n\tv240 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(data, \"isoCurrencyCode\");\n\tv250 = new UnityEngine.Purchasing.ProductMetadata();\n\tUnityEngine.Purchasing.ProductMetadata::.ctor(v250, v164, v175, v182, v240, v146);\n\treturn v250;\nL_0073:\n\tv69 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_00A2;\n\tv101 = 0x6D2BC0(v69, 0, 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv157 = *([v101 @ X0_v23]);\n\tv168 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v157 @ X8_v16]), 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv176 = v168 & 1;\n\tv112 = v176 == 0;\n\tif (v112) goto L_0098;\n\tv183 = 0x6D2490(v168, *([v157 @ X8_v16]), 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv154 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v146 @ stack_-60_v2 (System.Decimal), 0);\n\tgoto L_0042;\nL_0098:\n\tv185 = 0x6D1E60(8, *([v157 @ X8_v16]), 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v185 @ X0_v27]) = *([v101 @ X0_v23]);\n\tv104 = 0x1E8A000 + 0x870;\n\tv243 = 0x6D2A00(v185, v104, 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv110 = 0x6D2490(v243, v104, 0, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00A2:\n\tv118 = 0x6D2380(v115, v104, v102, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturnVal1 = 0x846AA4(v118, v104, v102, 0, 0, 1, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ProductMetadata DeserializeMetadata(Dictionary<string, object> data)
		{
			//IL_0089: Expected O, but got I4
			decimal num = default(decimal);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EA3E34 (inside System.DateTimeParse+MatchNumberDelegate::EndInvoke +0x340)");
			if (data != null)
			{
				object value = data.get_Item("localizedPrice");
				decimal num2 = Convert.ToDecimal(value);
				num = num2;
				string priceString = data.TryGetString("localizedPriceString");
				string title = data.TryGetString("localizedTitle");
				string description = data.TryGetString("localizedDescription");
				string currencyCode = data.TryGetString("isoCurrencyCode");
				return new ProductMetadata(priceString, title, description, currencyCode, num);
			}
			NullReferenceException ex = new NullReferenceException();
			object obj = 0;
			int num3 = 0;
			NullReferenceException ex2 = ex;
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			ProductMetadata result = default(ProductMetadata);
			return result;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0xC62018", Offset = "0xC62018", Length = "0x78C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001C;\n\tv33 = *([1ED1E08]);\n\tv34 = *([v33 @ X8_v101]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023346]) = v53;\nL_001C:\n\tv54 = &v55 @ stack_-80;\n\t*([v21 @ X29-54]) = 0;\n\tv60 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v60);\n\tv65 = product == 0;\n\tif (v65) goto L_008A;\n\tv66 = v60 == 0;\n\tif (v66) goto L_008A;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"id\", product.<id>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"storeSpecificId\", product.<storeSpecificId>k__BackingField);\n\tv105 = &v21 @ X29 - 0x54;\n\t*([v21 @ X29-54]) = product.<type>k__BackingField;\n\t// 66 Box v109 @ X0_v57 (Il2CppClass<UnityEngine.Purchasing.ProductDefinition>), typeof(UnityEngine.Purchasing.ProductType), v105 @ X1_v26 (Il2CppMethodInfo)\n\tv260 = *([v109 @ X0_v57 (Il2CppClass<UnityEngine.Purchasing.ProductDefinition>)]);\n\t*([v260 @ X8_v32+160])(v264, v109, *([v260 @ X8_v32+168]), product.<storeSpecificId>k__BackingField, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv266 = \"il2cpp_vm_object_unbox\"(v109, *([v260 @ X8_v32+168]), product.<storeSpecificId>k__BackingField, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([v21 @ X29-54]) = *([v266 @ X0_v61]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"type\", v264);\n\tgoto L_0068;\n\tv381 = *([v342 @ X0_v63+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_0068;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v342, v305, v101, v97, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0068:\n\tv110 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductDefinition);\n\tv464 = System.Type::GetProperty(v110, \"enabled\");\n\tv513 = v464 == 0;\n\tif (v513) goto L_FFFFFFFF;\n\tv521 = System.Reflection.PropertyInfo::GetValue(v464, product, 0);\n\tgoto L_0087;\n\tv535 = *([v525 @ X0_v119+E0]);\n\tv536 = v535 == 0;\n\tv537 = ~v536;\n\tif (v537) goto L_0087;\n\tv539 = \"il2cpp_codegen_runtime_class_init\"(v525, v519, v520, v518, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0087:\n\tv544 = System.Convert::ToBoolean(v521);\n\tgoto L_00A8;\nL_008A:\n\tgoto L_01EF;\n\tgoto L_008C;\nL_008C:\n\tX22 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0280;\n\tX0 = X22;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([X20]);\n\tX9 = *([1EE8350]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_01FD;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A8:\n\tv94 = v544 & 1;\n\tv555 = &v21 @ X29 - 0x58;\n\t*([v21 @ X29-58]) = v94;\n\t// 173 Box v558 @ X0_v70 (System.Object), typeof(System.Boolean), v555 @ X1_v32\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"enabled\", v558);\n\tv565 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v565);\n\tgoto L_00C9;\n\tv671 = *([v665 @ X0_v74+E0]);\n\tv672 = v671 == 0;\n\tv673 = ~v672;\n\tif (v673) goto L_00C9;\n\tv675 = \"il2cpp_codegen_runtime_class_init\"(v665, v633, v102, v98, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00C9:\n\tv111 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductDefinition);\n\tv729 = System.Type::GetProperty(v111, \"payouts\");\n\tv731 = v729 == 0;\n\tif (v731) goto L_00FE;\n\tv772 = *([v729 @ X0_v78 (System.Reflection.PropertyInfo)]);\n\tv176 = *([v772 @ X8_v46 (Il2CppClass<System.Reflection.PropertyInfo>)+2C8]);\n\tv775 = System.Reflection.PropertyInfo::GetValue(v729, product, 0);\n\tv776 = v775 == 0;\n\tif (v776) goto L_00FE;\n\tgoto L_FFFFFFFF;\n\tv479 = v479_asT != 0;\n\tif (v479) goto L_0110;\nL_00FE:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, *([v806 @ X27_v14 (System.String)]), v810);\n\treturn v60;\nL_0110:\n\tv505 = System.Array::GetEnumerator(v775);\n\t*([v21 @ X29-60]) = v505;\n\tv507 = v505 == 0;\n\tif (v507) goto L_01FC;\nL_0117:\n\tv938 = *([v718 @ X21_v3 (System.Collections.IEnumerator)]);\n\tv941 = *([v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v941) goto L_0139;\n\tv983 = *([v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0124:\n\tv988 = *([v983 @ X11_v33-8]) == *([v169 @ X24_v22 (Il2CppClass<System.Collections.IEnumerator>)]);\n\tif (v988) goto L_013C;\n\tv982 = v982 + 1;\n\tv993 = v982 < *([v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv964 = ~v993;\n\tv983 = v983 + 0x10;\n\tv948 = ~v964;\n\tif (v948) goto L_0124;\nL_0139:\n\tv998 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v718, *([v169 @ X24_v22 (Il2CppClass<System.Collections.IEnumerator>)]), 0);\n\tgoto L_0142;\nL_013C:\n\tv995 = *([v983 @ X11_v33]) << 4;\n\tv996 = v938 + v995;\n\tv998 = v996 + 0x130;\nL_0142:\n\t*([v998 @ X0_v82])(v715, v718, *([v998 @ X0_v82+8]), v711, v176, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1002 = v715 & 1;\n\tv717 = v1002 == 0;\n\tif (v717) goto L_01ED;\n\tv1003 = *([v718 @ X21_v3 (System.Collections.IEnumerator)]);\n\tv1006 = *([v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v1006) goto L_0168;\n\tv1048 = *([v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0153:\n\tv1053 = *([v1048 @ X11_v28-8]) == *([v169 @ X24_v22 (Il2CppClass<System.Collections.IEnumerator>)]);\n\tif (v1053) goto L_016B;\n\tv1047 = v1047 + 1;\n\tv1058 = v1047 < *([v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv1029 = ~v1058;\n\tv1048 = v1048 + 0x10;\n\tv1013 = ~v1029;\n\tif (v1013) goto L_0153;\nL_0168:\n\tv1064 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v718, *([v169 @ X24_v22 (Il2CppClass<System.Collections.IEnumerator>)]), 1);\n\tgoto L_0172;\nL_016B:\n\tv1060 = *([v1048 @ X11_v28]) + 1;\n\tv1061 = v1060 << 4;\n\tv1062 = v1003 + v1061;\n\tv1064 = v1062 + 0x130;\nL_0172:\n\t*([v1064 @ X0_v85])(v1069, v718, *([v1064 @ X0_v85+8]), v178, v176, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1072 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v1072);\n\tv220 = System.Object::GetType(v1069);\n\tv253 = System.Type::GetField(v220, \"typeString\");\n\tv294 = System.Reflection.FieldInfo::GetValue(v253, v1069);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v1072, \"t\", v294);\n\tv333 = System.Type::GetField(v220, \"subtype\");\n\tv1088 = System.Reflection.FieldInfo::GetValue(v333, v1069);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v1072, \"st\", v1088);\n\tv374 = System.Type::GetField(v220, \"quantity\");\n\tv1101 = System.Reflection.FieldInfo::GetValue(v374, v1069);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v1072, \"q\", v1101);\n\tv416 = System.Type::GetField(v220, \"data\");\n\tv1114 = System.Reflection.FieldInfo::GetValue(v416, v1069);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v1072, \"d\", v1114);\n\tv718 = *([v21 @ X29-60]);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v565, v1072);\n\tgoto L_0117;\nL_01ED:\n\t*([v54 @ X25_v1]) = 0x1BF;\n\tgoto L_0235;\nL_01EF:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv226 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv301 = new System.NullReferenceException();\n\tv339 = new System.NullReferenceException();\n\tv380 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv460 = new System.NullReferenceException();\nL_01FC:\n\tthrow System.NullReferenceException;\nL_01FD:\n\t;\n\n// ... truncated")]
		internal unsafe static Dictionary<string, object> EncodeProductDef(ProductDefinition product)
		{
			//IL_0083: Expected I, but got O
			//IL_0090: Expected O, but got I
			//IL_06b1: Expected O, but got I
			//IL_06bf: Expected I4, but got O
			//IL_01a9: Expected I, but got O
			//IL_02a3: Expected I, but got O
			//IL_02a8: Expected I, but got O
			//IL_0782: Expected I, but got O
			//IL_033e: Expected O, but got I
			//IL_0343: Expected I, but got O
			//IL_02cb: Expected O, but got I
			//IL_05c2: Expected O, but got I4
			//IL_0380: Expected I, but got O
			//IL_0356: Expected I4, but got O
			//IL_0364: Expected O, but got I
			//IL_0373: Expected O, but got I
			//IL_0432: Expected O, but got I4
			//IL_0432: Expected O, but got I
			//IL_043b: Expected O, but got I4
			//IL_0317: Expected O, but got I
			//IL_03bb: Expected O, but got I
			//IL_0449: Unknown result type (might be due to invalid IL or missing references)
			//IL_044e: Expected O, but got Unknown
			//IL_046b: Expected O, but got I
			//IL_047a: Expected O, but got I
			//IL_0482: Expected O, but got I
			//IL_0407: Expected O, but got I
			//IL_0596: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (product != null && dictionary != null)
			{
				dictionary.Add("id", product.id);
				dictionary.Add("storeSpecificId", product.storeSpecificId);
				IntPtr intPtr = (IntPtr)(void*)((long)(IntPtr)obj - 84L);
				_ = product.type;
				IntPtr intPtr2 = (IntPtr)(object)(ProductType)(long)intPtr;
				object obj4 = (long)intPtr2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v260 @ X8_v32+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object value = default(object);
				dictionary.Add("type", value);
				Type typeFromHandle = typeof(ProductDefinition);
				PropertyInfo property = typeFromHandle.GetProperty("enabled");
				bool flag;
				if ((object)property != null)
				{
					object value2 = property.GetValue(product, null);
					flag = Convert.ToBoolean(value2);
				}
				else
				{
					flag = true;
				}
				int num = (flag ? 1 : 0) & 1;
				object obj5 = (long)(IntPtr)obj - 88L;
				object value3 = (byte)(int)obj5 != 0;
				dictionary.Add("enabled", value3);
				List<object> list = new List<object>();
				Type typeFromHandle2 = typeof(ProductDefinition);
				PropertyInfo property2 = typeFromHandle2.GetProperty("payouts");
				bool flag2 = (object)property2 == null;
				string key = "payouts";
				List<object> value4 = list;
				if (!flag2)
				{
					IntPtr intPtr3 = (IntPtr)property2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ X8_v46 (Il2CppClass<System.Reflection.PropertyInfo>)+2C8]");
					IntPtr intPtr4 = (IntPtr)0;
					Array value5 = (Array)property2.GetValue(product, null);
					bool flag3 = value5 == null;
					key = "payouts";
					value4 = list;
					if (!flag3)
					{
						key = "payouts";
						value4 = list;
						Array array = value5 as Array;
						bool flag4 = array != null;
						key = "payouts";
						value4 = list;
						if (flag4)
						{
							IEnumerator enumerator = value5.GetEnumerator();
							if (enumerator == null)
							{
								throw new NullReferenceException();
							}
							IntPtr intPtr5 = (IntPtr)typeof(IEnumerator);
							IntPtr intPtr6 = (IntPtr)null;
							IEnumerator enumerator2 = enumerator;
							object obj9 = default(object);
							object obj14 = default(object);
							while (true)
							{
								IntPtr intPtr7 = (IntPtr)enumerator2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_0330;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
								object obj6 = 0L + 8L;
								int num2 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v983 @ X11_v33-8]");
									if ((IntPtr)0 == intPtr5)
									{
										break;
									}
									num2++;
									int num3 = num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v938 @ X8_v51 (Il2CppClass<System.Collections.IEnumerator>)+126]");
									bool flag5 = (long)num3 < 0L;
									bool flag6 = !flag5;
									obj6 = (long)(IntPtr)obj6 + 16L;
									if (!flag6)
									{
										continue;
									}
									goto IL_0330;
								}
								int num4 = obj6 << 4;
								object obj7 = (long)intPtr7 + (long)num4;
								object obj8 = (long)(IntPtr)obj7 + 304L;
								goto IL_0707;
								IL_0707:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v998 @ X0_v82] (should have been resolved before IL gen)");
								if ((int)((long)(IntPtr)obj9 & 1L) == 0)
								{
									break;
								}
								IntPtr intPtr8 = (IntPtr)enumerator2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+126]");
								string text;
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
									object obj10 = 0L + 8L;
									int num5 = 0;
									while (true)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ X11_v28-8]");
										if ((IntPtr)0 == intPtr5)
										{
											break;
										}
										num5++;
										int num6 = num5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ X8_v55 (Il2CppClass<System.Collections.IEnumerator>)+126]");
										bool flag7 = (long)num6 < 0L;
										bool flag8 = !flag7;
										obj10 = (long)(IntPtr)obj10 + 16L;
										if (!flag8)
										{
											continue;
										}
										goto IL_0420;
									}
									object obj11 = obj10 + 1;
									int num7 = (int)((long)(IntPtr)obj11 << 4);
									object obj12 = (long)intPtr8 + (long)num7;
									object obj13 = (long)(IntPtr)obj12 + 304L;
									text = (string)(long)intPtr6;
									goto IL_0761;
								}
								goto IL_0420;
								IL_0420:
								((Dictionary<string, object>)enumerator2).set_Item((string)(long)intPtr5, (object)1);
								text = (string)1;
								goto IL_0761;
								IL_0761:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1064 @ X0_v85] (should have been resolved before IL gen)");
								Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
								Type type = obj14.GetType();
								FieldInfo field = type.GetField("typeString");
								object value6 = field.GetValue(obj14);
								dictionary2.set_Item("t", value6);
								FieldInfo field2 = type.GetField("subtype");
								object value7 = field2.GetValue(obj14);
								dictionary2.set_Item("st", value7);
								FieldInfo field3 = type.GetField("quantity");
								object value8 = field3.GetValue(obj14);
								dictionary2.set_Item("q", value8);
								FieldInfo field4 = type.GetField("data");
								object value9 = field4.GetValue(obj14);
								dictionary2.set_Item("d", value9);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
								enumerator2 = (IEnumerator)0;
								list.Add(dictionary2);
								intPtr4 = (IntPtr)0;
								intPtr6 = (IntPtr)0;
								continue;
								IL_0330:
								((Dictionary<string, object>)enumerator2).set_Item((string)(long)intPtr5, (object)null);
								intPtr6 = (IntPtr)null;
								goto IL_0707;
							}
							obj2 = 447;
							key = "payouts";
							int num8 = 0;
							value4 = list;
							(enumerator2 as IDisposable)?.Dispose();
							if (true)
							{
								if (false)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X25_v1+v650 @ X23_v3 (System.Int32)*4]");
									if ((IntPtr)0 != (IntPtr)447)
									{
										goto IL_0659;
									}
								}
							}
							else if (false)
							{
								goto IL_0659;
							}
						}
					}
				}
				dictionary.Add(key, value4);
				return dictionary;
			}
			throw new NullReferenceException();
			IL_0659:
			throw new TypeLoadException();
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0xC62A6C", Offset = "0xC62A6C", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF6A20]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023347]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"storeSpecificId\", product.<storeSpecificId>k__BackingField);\n\tgoto L_003C;\n\tv94 = *([v89 @ X0_v8+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_003C;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v89, v61, v57, v62, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003C:\n\tv78 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.Extension.ProductDescription);\n\tv130 = System.Type::GetField(v78, \"type\");\n\tv131 = v130 == 0;\n\tif (v131) goto L_0057;\n\tv79 = System.Reflection.FieldInfo::GetValue(v130, product);\n\tv146 = System.Object::ToString(v79);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"type\", v146);\nL_0057:\n\tv144 = UnityEngine.Purchasing.JSONSerializer::EncodeProductMeta(product.<metadata>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"metadata\", v144);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"receipt\", product.<receipt>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"transactionId\", product.<transactionId>k__BackingField);\n\treturn v46;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<string, object> EncodeProductDesc(ProductDescription product)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("storeSpecificId", product.storeSpecificId);
			Type typeFromHandle = typeof(ProductDescription);
			FieldInfo field = typeFromHandle.GetField("type");
			if ((object)field != null)
			{
				object value = field.GetValue(product);
				string value2 = value.ToString();
				dictionary.Add("type", value2);
			}
			Dictionary<string, object> value3 = EncodeProductMeta(product.metadata);
			dictionary.Add("metadata", value3);
			dictionary.Add("receipt", product.receipt);
			dictionary.Add("transactionId", product.transactionId);
			return dictionary;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0xC63188", Offset = "0xC63188", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE3388]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023348]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"localizedPriceString\", product.<localizedPriceString>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"localizedTitle\", product.<localizedTitle>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"localizedDescription\", product.<localizedDescription>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"isoCurrencyCode\", product.<isoCurrencyCode>k__BackingField);\n\tgoto L_0051;\n\tv119 = *([v115 @ X0_v10+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_0051;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v115, v110, v106, v108, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tv76 = System.Convert::ToDouble(product.<localizedPrice>k__BackingField);\n\t// 87 Box v132 @ X0_v14 (System.Object), typeof(System.Double), &v76 @ V0_v1 (System.Double)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"localizedPrice\", v132);\n\treturn v46;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<string, object> EncodeProductMeta(ProductMetadata product)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("localizedPriceString", product.localizedPriceString);
			dictionary.Add("localizedTitle", product.localizedTitle);
			dictionary.Add("localizedDescription", product.localizedDescription);
			dictionary.Add("isoCurrencyCode", product.isoCurrencyCode);
			double num = Convert.ToDouble(product.localizedPrice);
			object value = num;
			dictionary.Add("localizedPrice", value);
			return dictionary;
		}
	}
}
