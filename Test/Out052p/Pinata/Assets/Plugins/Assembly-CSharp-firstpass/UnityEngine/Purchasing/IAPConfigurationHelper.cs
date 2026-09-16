using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000007")]
	public static class IAPConfigurationHelper
	{
		[Token(Token = "0x6000037")]
		[Address(RVA = "0x160A888", Offset = "0x160A888", Length = "0xB1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = &v23 @ X29;\n\t*([v23 @ X29-70]) = builder;\n\tgoto L_001F;\n\tv36 = *([1F0E420]);\n\tv37 = *([v36 @ X8_v116]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, catalog, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202A208]) = v55;\nL_001F:\n\t*([v23 @ X29-68]) = &v57 @ stack_-90;\n\tv62 = UnityEngine.Purchasing.ProductCatalog::get_allValidProducts(catalog);\n\tgoto L_0056;\n\tv257 = *([v184 @ X8_v22+B0]);\n\tv258 = 0;\n\tv259 = v257 + 8;\n\tv261 = *([v366 @ X11_v96-8]);\n\tv372 = v261 == v187;\n\tif (v372) goto L_004F;\n\tv283 = v367 + 1;\n\tv440 = v283 < v186;\n\tv279 = ~v440;\n\tv281 = v366 + 0x10;\n\tv263 = ~v279;\n\tif (v263) goto L_FFFFFFFF;\n\tv284 = v146;\n\tv285 = 0;\n\tv286 = 0x8909C4(v284, v187, v285, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0056;\nL_004F:\n\tv441 = *([v366 @ X11_v96]);\n\tv442 = v441 << 4;\n\tv443 = v184 + v442;\n\tv444 = v443 + 0x130;\nL_0056:\n\tv465 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.ProductCatalogItem>::GetEnumerator(v62);\n\t*([v23 @ X29-58]) = 0;\nL_0062:\n\tv668 = *([v465 @ X0_v37 (System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>)]);\n\tv671 = *([v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]) == 0;\n\tif (v671) goto L_0084;\n\tv768 = *([v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+B0]) + 8;\nL_006F:\n\tv774 = *([v768 @ X11_v91-8]) == *([v201 @ X28_v12 (Il2CppClass<System.Collections.IEnumerator>)]);\n\tif (v774) goto L_0087;\n\tv769 = v769 + 1;\n\tv808 = v769 < *([v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]);\n\tv698 = ~v808;\n\tv768 = v768 + 0x10;\n\tv682 = ~v698;\n\tif (v682) goto L_006F;\nL_0084:\n\t;\n\tgoto L_008D;\nL_0087:\n\t;\nL_008D:\n\tv833 = System.Collections.IEnumerator::MoveNext(v465);\n\tv834 = v833 & 1;\n\tv835 = v834 == 0;\n\tif (v835) goto L_03A3;\n\tv892 = *([v465 @ X0_v37 (System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>)]);\n\tv895 = *([v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]) == 0;\n\tif (v895) goto L_00B3;\n\tv1152 = *([v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+B0]) + 8;\nL_009E:\n\tv1158 = *([v1152 @ X11_v86-8]) == *([v254 @ X20_v14 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)]);\n\tif (v1158) goto L_00B6;\n\tv1153 = v1153 + 1;\n\tv1222 = v1153 < *([v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]);\n\tv1044 = ~v1222;\n\tv1152 = v1152 + 0x10;\n\tv1028 = ~v1044;\n\tif (v1028) goto L_009E;\nL_00B3:\n\t;\n\tgoto L_00BC;\nL_00B6:\n\t;\nL_00BC:\n\tv740 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>::get_Current(v465);\n\tv800 = UnityEngine.Purchasing.ProductCatalogItem::get_allStoreIDs(v740);\n\tgoto L_00F3;\n\tv1284 = *([v1278 @ X8_v38+B0]);\n\tv1285 = 0;\n\tv1286 = v1284 + 8;\n\tv1288 = *([v1324 @ X11_v81-8]);\n\tv1330 = v1288 == v1282;\n\tif (v1330) goto L_00EC;\n\tv1310 = v1325 + 1;\n\tv1335 = v1310 < v1280;\n\tv1306 = ~v1335;\n\tv1308 = v1324 + 0x10;\n\tv1290 = ~v1306;\n\tif (v1290) goto L_FFFFFFFF;\n\tv1311 = v782;\n\tv1312 = 0;\n\tv1313 = 0x8909C4(v1311, v1282, v1312, v207, v195, v67, v43, v44, v199, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00F3;\nL_00EC:\n\tv1336 = *([v1324 @ X11_v81]);\n\tv1337 = v1336 << 4;\n\tv1338 = v1278 + v1337;\n\tv1339 = v1338 + 0x130;\nL_00F3:\n\tv1354 = System.Collections.Generic.ICollection`1<UnityEngine.Purchasing.StoreID>::get_Count(v800);\n\tv221 = v1354 < 1;\n\tif (v221) goto L_FFFFFFFF;\n\tv1359 = new UnityEngine.Purchasing.IDs();\n\tUnityEngine.Purchasing.IDs::.ctor(v1359);\n\tv247 = UnityEngine.Purchasing.ProductCatalogItem::get_allStoreIDs(v740);\n\tgoto L_013D;\n\tv1396 = *([v1390 @ X8_v81+B0]);\n\tv1397 = 0;\n\tv1398 = v1396 + 8;\n\tv1400 = *([v1442 @ X11_v76-8]);\n\tv1448 = v1400 == v1394;\n\tif (v1448) goto L_0136;\n\tv1422 = v1443 + 1;\n\tv1483 = v1422 < v1392;\n\tv1418 = ~v1483;\n\tv1420 = v1442 + 0x10;\n\tv1402 = ~v1418;\n\tif (v1402) goto L_FFFFFFFF;\n\tv1423 = v213;\n\tv1424 = 0;\n\tv1425 = 0x8909C4(v1423, v1394, v1424, v207, v195, v67, v43, v44, v199, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_013D;\n\tgoto L_0241;\nL_0136:\n\tv1484 = *([v1442 @ X11_v76]);\n\tv1485 = v1484 << 4;\n\tv1486 = v1390 + v1485;\n\tv1487 = v1486 + 0x130;\nL_013D:\n\tv1508 = System.Collections.Generic.IEnumerable`1<UnityEngine.Purchasing.StoreID>::GetEnumerator(v247);\nL_013F:\n\tv598 = v1508 == 0;\n\tif (v598) goto L_01C5;\n\tv1562 = *([v1508 @ X0_v127 (System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>)]);\n\tv1565 = *([v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]) == 0;\n\tif (v1565) goto L_0163;\n\tv1619 = *([v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+B0]) + 8;\nL_014E:\n\tv1625 = *([v1619 @ X11_v71-8]) == *([v201 @ X28_v12 (Il2CppClass<System.Collections.IEnumerator>)]);\n\tif (v1625) goto L_0166;\n\tv1620 = v1620 + 1;\n\tv1660 = v1620 < *([v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]);\n\tv1595 = ~v1660;\n\tv1619 = v1619 + 0x10;\n\tv1579 = ~v1595;\n\tif (v1579) goto L_014E;\nL_0163:\n\t;\n\tgoto L_016C;\nL_0166:\n\t;\nL_016C:\n\tv1685 = System.Collections.IEnumerator::MoveNext(v1508);\n\tv1686 = v1685 & 1;\n\tv1687 = v1686 == 0;\n\tif (v1687) goto L_01BF;\n\tgoto L_019D;\n\tv1745 = *([v1709 @ X8_v99+B0]);\n\tv1746 = 0;\n\tv1747 = v1745 + 8;\n\tv1749 = *([v1797 @ X11_v66-8]);\n\tv1803 = v1749 == v1713;\n\tif (v1803) goto L_0196;\n\tv1771 = v1798 + 1;\n\tv1879 = v1771 < v1711;\n\tv1767 = ~v1879;\n\tv1769 = v1797 + 0x10;\n\tv1751 = ~v1767;\n\tif (v1751) goto L_FFFFFFFF;\n\tv1772 = v395;\n\tv1773 = 0;\n\tv1774 = 0x8909C4(v1772, v1713, v1773, v389, v195, v67, v43, v44, v199, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_019D;\nL_0196:\n\tv1880 = *([v1797 @ X11_v66]);\n\tv1881 = v1880 << 4;\n\tv1882 = v1709 + v1881;\n\tv1883 = v1882 + 0x130;\nL_019D:\n\tv1887 = System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>::get_Current(v1508);\n\tv599 = v1887 == 0;\n\tif (v599) goto L_01C8;\n\t// 422 NewArr v2009 @ X0_v147 (System.String[]), typeof(System.String[]), 1\n\tv600 = v2009 == 0;\n\tif (v600) goto L_01CB;\n\tv2090 = v1887.store == 0;\n\tif (v2090) goto L_01B4;\n\t// 432 IsInst v2102 @ X0_v157, typeof(System.String), v1887.store (System.String)\n\tv603 = v2102 == 0;\n\tif (v603) goto L_01D5;\nL_01B4:\n\tv601 = v2009.Length == 0;\n\tif (v601) goto L_01CD;\n\tv2009[0] = v1887.store;\n\tv602 = v1359 == 0;\n\tif (v602) goto L_01D3;\n\tUnityEngine.Purchasing.IDs::Add(v1359, v1887.id, v2009);\n\tgoto L_013F;\nL_01BF:\n\tv1715 = *([v23 @ X29-68]);\n\tv1060 = v1060 + 1;\n\t*([v1715 @ X8_v88+v1060 @ X27_v4*4]) = 0x7A;\n\tgoto L_01F5;\nL_01C5:\n\tv588 = new System.NullReferenceException();\n\tgoto L_03C4;\nL_01C8:\n\tv589 = new System.NullReferenceException();\n\tgoto L_03C4;\nL_01CB:\n\tv590 = new System.NullReferenceException();\n\tgoto L_03C4;\nL_01CD:\n\tv2110 = new System.IndexOutOfRangeException();\n\tthrow v2110;\n\tgoto L_03C4;\nL_01D3:\n\tv592 = new System.NullReferenceException();\n\tgoto L_03C4;\nL_01D5:\n\tv2115 = new System.ArrayTypeMismatchException();\n\tthrow v2115;\n\tgoto L_03C4;\n\tgoto L_01DC;\n\tgoto L_01DC;\nL_01DC:\n\tX21 = 0x1EAE000;\n\tX21 = *([1EAE898]);\n\tgoto L_01E2;\n\tgoto L_01E2;\n\tgoto L_01E2;\n\tgoto L_01E2;\nL_01E2:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_03F1;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\t*([X29-58]) = X8;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01F5:\n\tv1775 = v1508 == 0;\n\tif (v1775) goto L_0223;\n\tv1808 = *([v1508 @ X0_v127 (System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>)]);\n\tv1811 = *([v1808 @ X8_v95 (Il2CppClass<System.Collections.Generic.IEnumerator`1\n// ... truncated")]
		public static void PopulateConfigurationBuilder(ref ConfigurationBuilder builder, ProductCatalog catalog)
		{
			//IL_0b4a: Expected I, but got O
			//IL_0b58: Expected I, but got O
			//IL_0b65: Expected O, but got I8
			//IL_0b74: Expected I, but got O
			//IL_0031: Expected I, but got O
			//IL_0baa: Expected O, but got I4
			//IL_006c: Expected O, but got I
			//IL_08e1: Expected O, but got I
			//IL_08f1: Expected O, but got I
			//IL_0900: Expected O, but got I
			//IL_09e4: Expected I, but got O
			//IL_00e8: Expected I, but got O
			//IL_094e: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_0a1f: Expected O, but got I
			//IL_0e5d: Expected O, but got I
			//IL_0123: Expected O, but got I
			//IL_0a6b: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_0ac0: Expected O, but got I
			//IL_0722: Expected I4, but got O
			//IL_03e9: Expected I4, but got O
			//IL_01e6: Expected I, but got O
			//IL_06c7: Expected O, but got I
			//IL_06d6: Expected O, but got I
			//IL_0c9b: Expected O, but got I4
			//IL_0221: Expected O, but got I
			//IL_03be: Expected O, but got I
			//IL_03cd: Expected O, but got I
			//IL_09bd: Expected I, but got O
			//IL_0e23: Expected O, but got I
			//IL_0745: Expected I4, but got O
			//IL_0d3d: Expected O, but got I
			//IL_026d: Expected O, but got I
			//IL_079a: Expected O, but got I
			//IL_04a7: Expected I, but got O
			//IL_040c: Expected I4, but got O
			//IL_0858: Expected O, but got I
			//IL_0975: Expected I4, but got O
			//IL_0566: Expected O, but got I
			//IL_08a7: Expected I, but got O
			//IL_08b5: Expected I, but got O
			//IL_08cc: Expected I, but got O
			//IL_07d5: Expected I4, but got I8
			//IL_07e3: Expected O, but got I
			//IL_04e2: Expected O, but got I
			//IL_042b: Expected O, but got I4
			//IL_0433: Expected I4, but got O
			//IL_0778: Expected I4, but got O
			//IL_05a1: Expected I4, but got I8
			//IL_05af: Expected O, but got I
			//IL_052e: Expected O, but got I
			//IL_031f: Expected I4, but got O
			//IL_045f: Expected O, but got I4
			//IL_0467: Expected I4, but got O
			object obj = obj;
			ICollection<ProductCatalogItem> allValidProducts = catalog.allValidProducts;
			IEnumerator<ProductCatalogItem> enumerator = allValidProducts.GetEnumerator();
			_ = 0;
			IntPtr intPtr = (IntPtr)typeof(IEnumerator);
			IntPtr intPtr2 = (IntPtr)typeof(IDisposable);
			object obj2 = 4294967295L;
			IntPtr intPtr3 = (IntPtr)typeof(IEnumerator<ProductCatalogItem>);
			object obj11;
			object obj12;
			object obj17 = default(object);
			while (true)
			{
				IntPtr intPtr4 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+B0]");
					object obj3 = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X11_v91-8]");
						if ((IntPtr)0 != intPtr)
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj3 = (long)(IntPtr)obj3 + 16L;
							continue;
						}
						break;
					}
					while (!flag2);
				}
				object obj4 = enumerator.MoveNext();
				ProductCatalogItem current;
				IDs ds;
				IEnumerator<StoreID> enumerator2;
				string text;
				int num7;
				IDs ds3;
				IEnumerator<ProductCatalogItem> enumerator3;
				IDs ds2;
				ProductType productType;
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					IntPtr intPtr5 = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+B0]");
						object obj5 = 0L + 8L;
						int num3 = 0;
						bool flag4;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1152 @ X11_v86-8]");
							if ((IntPtr)0 != intPtr3)
							{
								num3++;
								int num4 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v35 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
								bool flag3 = (long)num4 < 0L;
								flag4 = !flag3;
								obj5 = (long)(IntPtr)obj5 + 16L;
								continue;
							}
							break;
						}
						while (!flag4);
					}
					current = enumerator.Current;
					ICollection<StoreID> allStoreIDs = current.allStoreIDs;
					int count = allStoreIDs.Count;
					if (count >= 1)
					{
						ds = new IDs();
						ICollection<StoreID> allStoreIDs2 = current.allStoreIDs;
						enumerator2 = allStoreIDs2.GetEnumerator();
						text = null;
						while (enumerator2 != null)
						{
							IntPtr intPtr6 = (IntPtr)enumerator2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+B0]");
								object obj6 = 0L + 8L;
								int num5 = 0;
								bool flag6;
								do
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ X11_v71-8]");
									if ((IntPtr)0 != intPtr)
									{
										num5++;
										int num6 = num5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1562 @ X8_v85 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]");
										bool flag5 = (long)num6 < 0L;
										flag6 = !flag5;
										obj6 = (long)(IntPtr)obj6 + 16L;
										continue;
									}
									break;
								}
								while (!flag6);
							}
							object obj7 = enumerator2.MoveNext();
							if ((int)((long)(IntPtr)obj7 & 1L) == 0)
							{
								goto IL_03ae;
							}
							StoreID current2 = enumerator2.Current;
							if (current2 == null)
							{
								goto IL_03f6;
							}
							string[] array = new string[1];
							if (array == null)
							{
								goto IL_0419;
							}
							bool flag7 = current2.store == null;
							num7 = 1;
							if (!flag7)
							{
								object obj8 = current2.store as string;
								bool flag8 = obj8 == null;
								num7 = (int)typeof(string);
								if (flag8)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							if (array.Length != 0)
							{
								array[0] = current2.store;
								if (ds != null)
								{
									ds.Add(current2.id, array);
									ds2 = null;
									text = current2.id;
									continue;
								}
								goto IL_044e;
							}
							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
							throw ex2;
						}
						NullReferenceException ex3 = new NullReferenceException();
						productType = (ProductType)ex3;
						enumerator3 = enumerator;
						goto IL_0d0e;
					}
					ds3 = null;
					goto IL_0c4e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-58]");
				object obj10 = 0;
				obj2 = (long)(IntPtr)obj2 + 1L;
				_ = 264;
				bool flag9 = enumerator == null;
				bool flag10 = !flag9;
				enumerator3 = enumerator;
				if (!flag10)
				{
					obj11 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-58]");
					obj12 = 0;
					break;
				}
				goto IL_09dc;
				IL_03ae:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
				object obj13 = 0;
				obj2 = (long)(IntPtr)obj2 + 1L;
				_ = 122;
				if (enumerator2 != null)
				{
					IntPtr intPtr7 = (IntPtr)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ X8_v95 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ X8_v95 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+B0]");
						object obj14 = 0L + 8L;
						int num8 = 0;
						bool flag12;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2021 @ X11_v60-8]");
							if ((IntPtr)0 != intPtr2)
							{
								num8++;
								int num9 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1808 @ X8_v95 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.StoreID>>)+126]");
								bool flag11 = (long)num9 < 0L;
								flag12 = !flag11;
								obj14 = (long)(IntPtr)obj14 + 16L;
								continue;
							}
							break;
						}
						while (!flag12);
					}
					enumerator2.Dispose();
				}
				object obj15 = (long)(IntPtr)obj2 + 1L;
				if (obj15 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
					object obj16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1918 @ X8_v91+v1060 @ X27_v4*4]");
					if ((IntPtr)0 == (IntPtr)122)
					{
						int num10 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
						obj2 = (long)(IntPtr)obj2 + (long)num10;
						ds3 = ds;
						goto IL_0c4e;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-58]");
				bool flag13 = (IntPtr)0 == (IntPtr)0;
				bool flag14 = !flag13;
				enumerator3 = enumerator;
				if (!flag14)
				{
					_ = 0;
					ds3 = ds;
					goto IL_0c4e;
				}
				TypeLoadException ex4 = new TypeLoadException();
				text = null;
				productType = (ProductType)ex4;
				goto IL_0d0e;
				IL_072f:
				NullReferenceException ex5 = new NullReferenceException();
				text = null;
				productType = (ProductType)ex5;
				enumerator3 = enumerator;
				goto IL_0d0e;
				IL_03f6:
				NullReferenceException ex6 = new NullReferenceException();
				text = null;
				productType = (ProductType)ex6;
				enumerator3 = enumerator;
				goto IL_0d0e;
				IL_0d0e:
				if ((IntPtr)text == (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					obj10 = obj17;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					bool flag15 = enumerator3 == null;
					intPtr2 = (IntPtr)typeof(IDisposable);
					obj11 = obj2;
					obj12 = obj17;
					if (flag15)
					{
						break;
					}
					goto IL_09dc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				return;
				IL_0752:
				NullReferenceException ex7 = new NullReferenceException();
				IEnumerable<PayoutDefinition> enumerable = null;
				string data;
				ds2 = (IDs)(object)data;
				string typeString;
				text = typeString;
				productType = (ProductType)ex7;
				enumerator3 = enumerator;
				goto IL_0d0e;
				IL_06b7:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
				object obj18 = 0;
				obj2 = (long)(IntPtr)obj2 + 1L;
				_ = 214;
				IEnumerator<ProductCatalogPayout> enumerator4;
				enumerator4?.Dispose();
				object obj19 = (long)(IntPtr)obj2 + 1L;
				List<PayoutDefinition> list;
				if (obj19 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2042 @ X8_v61+v1060 @ X27_v4*4]");
					if ((IntPtr)0 == (IntPtr)214)
					{
						int num11 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
						obj2 = (long)(IntPtr)obj2 + (long)num11;
						if (list == null)
						{
							throw new NullReferenceException();
						}
						goto IL_0848;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-58]");
				bool flag16 = (IntPtr)0 == (IntPtr)0;
				bool flag17 = !flag16;
				enumerator3 = enumerator;
				if (!flag17)
				{
					goto IL_0848;
				}
				throw new TypeLoadException();
				IL_0c4e:
				list = new List<PayoutDefinition>();
				IList<ProductCatalogPayout> payouts = current.Payouts;
				enumerator4 = payouts.GetEnumerator();
				PayoutDefinition payoutDefinition = null;
				while (enumerator4 != null)
				{
					if (!enumerator4.MoveNext())
					{
						goto IL_06b7;
					}
					ProductCatalogPayout current3 = enumerator4.Current;
					if (current3 == null)
					{
						goto IL_072f;
					}
					typeString = current3.typeString;
					string subtype = current3.subtype;
					double quantity = current3.quantity;
					data = current3.data;
					PayoutDefinition payoutDefinition2 = new PayoutDefinition(typeString, subtype, quantity, data);
					if (list != null)
					{
						list.Add(payoutDefinition2);
						enumerable = null;
						ds2 = (IDs)(object)data;
						payoutDefinition = payoutDefinition2;
						continue;
					}
					goto IL_0752;
				}
				NullReferenceException ex8 = new NullReferenceException();
				text = (string)(object)payoutDefinition;
				productType = (ProductType)ex8;
				enumerator3 = enumerator;
				goto IL_0d0e;
				IL_0848:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-70]");
				object obj21 = 0;
				PayoutDefinition[] array2 = list.ToArray();
				ConfigurationBuilder configurationBuilder = ((ConfigurationBuilder)obj21).AddProduct(current.id, current.type, ds3, (IEnumerable<PayoutDefinition>)array2);
				enumerable = array2;
				intPtr = (IntPtr)typeof(IEnumerator);
				intPtr2 = (IntPtr)typeof(IDisposable);
				ds2 = ds3;
				intPtr3 = (IntPtr)typeof(IEnumerator<ProductCatalogItem>);
				continue;
				IL_09dc:
				IntPtr intPtr8 = (IntPtr)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ X8_v12 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ X8_v12 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+B0]");
					object obj22 = 0L + 8L;
					int num12 = 0;
					bool flag19;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1240 @ X11_v8-8]");
						if ((IntPtr)0 != intPtr2)
						{
							num12++;
							int num13 = num12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ X8_v12 (Il2CppClass<System.Collections.Generic.IEnumerator`1<UnityEngine.Purchasing.ProductCatalogItem>>)+126]");
							bool flag18 = (long)num13 < 0L;
							flag19 = !flag18;
							obj22 = (long)(IntPtr)obj22 + 16L;
							continue;
						}
						break;
					}
					while (!flag19);
				}
				enumerator3.Dispose();
				obj11 = obj2;
				obj12 = obj10;
				break;
				IL_044e:
				NullReferenceException ex9 = new NullReferenceException();
				text = (string)num7;
				productType = (ProductType)ex9;
				enumerator3 = enumerator;
				goto IL_0d0e;
				IL_0419:
				NullReferenceException ex10 = new NullReferenceException();
				text = (string)1;
				productType = (ProductType)ex10;
				enumerator3 = enumerator;
				goto IL_0d0e;
			}
			object obj23 = (long)(IntPtr)obj11 + 1L;
			if (obj23 != null)
			{
				if (obj12 == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X29-68]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1251 @ X8_v8+v1100 @ X27_v1*4]");
				if ((IntPtr)0 == (IntPtr)264)
				{
					return;
				}
			}
			else if (obj12 == null)
			{
				return;
			}
			throw new TypeLoadException();
		}
	}
}
