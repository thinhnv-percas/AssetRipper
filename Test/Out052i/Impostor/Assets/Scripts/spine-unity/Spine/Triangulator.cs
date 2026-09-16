using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000064")]
	public class Triangulator
	{
		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x10")]
		private readonly ExposedList<ExposedList<float>> convexPolygons;

		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x18")]
		private readonly ExposedList<ExposedList<int>> convexPolygonsIndices;

		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x20")]
		private readonly ExposedList<int> indicesArray;

		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x28")]
		private readonly ExposedList<bool> isConcaveArray;

		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x30")]
		private readonly ExposedList<int> triangles;

		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x38")]
		private readonly Pool<ExposedList<float>> polygonPool;

		[Token(Token = "0x4000295")]
		[FieldOffset(Offset = "0x40")]
		private readonly Pool<ExposedList<int>> polygonIndicesPool;

		[Token(Token = "0x6000469")]
		[Address(RVA = "0x153E7AC", Offset = "0x153E7AC", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv426 = Il2CppMethodInfo;\n\tv427 = \"il2cpp_codegen_initialize_runtime_metadata\"(v426, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv434 = Il2CppMethodInfo;\n\tv435 = \"il2cpp_codegen_initialize_runtime_metadata\"(v434, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv516 = Il2CppMethodInfo;\n\tv517 = \"il2cpp_codegen_initialize_runtime_metadata\"(v516, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv519 = Il2CppMethodInfo;\n\tv520 = \"il2cpp_codegen_initialize_runtime_metadata\"(v519, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv524 = Il2CppMethodInfo;\n\tv525 = \"il2cpp_codegen_initialize_runtime_metadata\"(v524, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv543 = System.Math;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v543, verticesArray, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37BC2]) = v53;\nL_0036:\n\tv382 = verticesArray.Items;\n\tv353 = verticesArray.Count >> 1;\n\tSpine.ExposedList`1<System.Int32>::Clear(this.indicesArray, 1);\n\tv385 = Spine.ExposedList`1<System.Int32>::Resize(this.indicesArray, v353);\n\tv410 = v385.Items;\n\tv246 = verticesArray.Count < 2;\n\tif (v246) goto L_0088;\n\tv546 = v353 - 1;\n\tv547 = v546 < 0;\n\tv548 = v546 == 0;\n\tv549 = v353 ^ 1;\n\tv550 = v353 ^ v546;\n\tv551 = v549 & v550;\n\tv552 = v551 < 0;\n\tv554 = v547 == v552;\n\tv529 = ~v548;\n\tv555 = v554 & v529;\n\tv528 = ~v555;\n\tif (v528) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0073:\n\tv410[v580 @ X8_v42 (System.Int32)] = v580;\n\tv580 = v580 + 1;\n\tv531 = v527 != v580;\n\tif (v531) goto L_0073;\nL_0088:\n\tv386 = Spine.ExposedList`1<System.Boolean>::Resize(this.isConcaveArray, v353);\n\tv208 = v386.Items;\n\tv570 = verticesArray.Count < 2;\n\tif (v570) goto L_00D8;\n\tv592 = v353 - 1;\n\tv593 = v592 < 0;\n\tv594 = v592 == 0;\n\tv595 = v353 ^ 1;\n\tv596 = v353 ^ v592;\n\tv597 = v595 & v596;\n\tv598 = v597 < 0;\n\tv600 = v593 == v598;\n\tv231 = ~v594;\n\tv601 = v600 & v231;\n\tv223 = ~v601;\n\tif (v223) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_00B0:\n\tv387 = Spine.Triangulator::IsConcave(v201, v353, verticesArray.Items, v410);\n\tv208[v201 @ X25_v12 (System.Int32)] = v387;\n\tv201 = v201 + 1;\n\tv603 = v195 != v201;\n\tif (v603) goto L_00B0;\nL_00D8:\n\tSpine.ExposedList`1<System.Int32>::Clear(this.triangles, 1);\n\tgoto L_00DF;\n\tv1000 = \"il2cpp_codegen_runtime_class_init\"(v991, v988, v989, v63, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00DF:\n\tv1002 = v353 - 2;\n\tv1005 = System.Math::Max(0, v1002);\n\tv361 = v1005 << 2;\n\tSpine.ExposedList`1<System.Int32>::EnsureCapacity(this.triangles, v361);\n\tv250 = verticesArray.Count < 8;\n\tif (v250) goto L_FFFFFFFF;\n\tv420 = v208.Length;\nL_00FA:\n\tv205 = v353 - 1;\nL_0103:\n\tv1054 = ~v208[v183 @ X13_v6 (System.Int32)];\n\tif (v1054) goto L_0140;\nL_0105:\n\tv1082 = v176 == 0;\n\tif (v1082) goto L_02C0;\n\tv1083 = v176 + 1;\n\tv1084 = v1083 / v353;\n\tv1085 = v176 < v420;\n\tv905 = ~v1085;\n\tv964 = v1084 * v353;\n\tv176 = v1083 - v964;\n\tv736 = ~v905;\n\tif (v736) goto L_0103;\n\tgoto L_0328;\nL_0140:\n\tv688 = v410[v216 @ X10_v7 (System.Int32)] << 1;\n\tv682 = v688 | 1;\n\tv714 = v410[v183 @ X13_v6 (System.Int32)] << 1;\n\tv677 = v714 | 1;\n\tv954 = v410[v176 @ X11_v7 (System.Int32)] << 1;\n\tv928 = v954 | 1;\n\tv1188 = v176 + 1;\n\tv939 = v1188 / v353;\n\tv1158 = v939 * v353;\n\tv673 = v1188 - v1158;\n\tv1150 = v673 == v216;\n\tif (v1150) goto L_0231;\n\tv643 = v382[v682 @ X15_v9 (System.Int32)] - v382[v928 @ X1_v26 (System.Int32)];\n\tv639 = v382[v677 @ X16_v9 (System.Int32)] - v382[v682 @ X15_v9 (System.Int32)];\n\tv635 = v382[v928 @ X1_v26 (System.Int32)] - v382[v677 @ X16_v9 (System.Int32)];\nL_01BB:\n\tv966 = ~v208[v673 @ X17_v13 (System.Int32)];\n\tif (v966) goto L_021F;\n\tv691 = v410[v673 @ X17_v13 (System.Int32)] << 1;\n\tv684 = v691 | 1;\n\tv1273 = v382[v684 @ X15_v14 (System.Int32)] - v382[v682 @ X15_v9 (System.Int32)];\n\tv1274 = v382[v928 @ X1_v26 (System.Int32)] - v382[v684 @ X15_v14 (System.Int32)];\n\tv1275 = v382[v954 @ X0_v37 (System.Int32)] * v1273;\n\tv1276 = v382[v688 @ X14_v9 (System.Int32)] * v1274;\n\tv1277 = v1275 + v1276;\n\tv1229 = v643 * v382[v691 @ X14_v18 (System.Int32)];\n\tv1230 = v1229 + v1277;\n\tv1236 = v1230 < 0;\n\tif (v1236) goto L_021F;\n\tv1282 = v382[v684 @ X15_v14 (System.Int32)] - v382[v677 @ X16_v9 (System.Int32)];\n\tv1283 = v382[v682 @ X15_v9 (System.Int32)] - v382[v684 @ X15_v14 (System.Int32)];\n\tv1284 = v382[v688 @ X14_v9 (System.Int32)] * v1282;\n\tv1285 = v382[v714 @ X13_v11 (System.Int32)] * v1283;\n\tv1286 = v1284 + v1285;\n\tv1056 = v639 * v382[v691 @ X14_v18 (System.Int32)];\n\tv1231 = v1056 + v1286;\n\tv1237 = v1231 < 0;\n\tif (v1237) goto L_021F;\n\tv1289 = v382[v684 @ X15_v14 (System.Int32)] - v382[v928 @ X1_v26 (System.Int32)];\n\tv1290 = v382[v677 @ X16_v9 (System.Int32)] - v382[v684 @ X15_v14 (System.Int32)];\n\tv1057 = v382[v714 @ X13_v11 (System.Int32)] * v1289;\n\tv1291 = v382[v954 @ X0_v37 (System.Int32)] * v1290;\n\tv1059 = v1057 + v1291;\n\tv1292 = v635 * v382[v691 @ X14_v18 (System.Int32)];\n\tv1058 = v1292 + v1059;\n\tv1064 = v1058 >= 0;\n\tif (v1064) goto L_0105;\nL_021F:\n\tv1125 = v673 + 1;\n\tv1123 = v1125 / v353;\n\tv1137 = v1123 * v353;\n\tv673 = v1125 - v1137;\n\tv1126 = v673 != v216;\n\tif (v1126) goto L_01BB;\nL_0231:\n\tv1159 = v205 + v949;\n\tv723 = v1159 / v353;\n\tv967 = v723 * v353;\n\tv973 = v1159 - v967;\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[v973 @ X8_v22 (System.Int32)]);\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[v949 @ X26_v10 (System.Int32)]);\n\tv1174 = v949 + 1;\n\tv724 = v1174 / v353;\n\tv968 = v724 * v353;\n\tv975 = v1174 - v968;\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[v975 @ X8_v27 (System.Int32)]);\n\tSpine.ExposedList`1<System.Int32>::RemoveAt(this.indicesArray, v949);\n\tSpine.ExposedList`1<System.Boolean>::RemoveAt(this.isConcaveArray, v949);\n\tv1204 = v949 + v205;\n\tv1205 = v1204 - 1;\n\tv732 = v1205 / v205;\n\tv969 = v732 * v205;\n\tv719 = v1205 - v969;\n\tv726 = v949 != v205;\n\tif (v726) goto L_028F;\n\tgoto L_028F;\nL_028F:\n\tv959 = Spine.Triangulator::IsConcave(v719, v205, verticesArray.Items, v410);\n\tv208[v719 @ X27_v9 (System.Int32)] = v959;\n\tv960 = Spine.Triangulator::IsConcave(v949, v205, verticesArray.Items, v410);\n\tv420 = v208.Length;\n\tv208[v949 @ X26_v10 (System.Int32)] = v960;\n\tv1017 = v353 > 4;\n\tif (v1017) goto L_00FA;\n\tgoto L_02EA;\nL_02C0:\n\tv1086 = v1050 - 1;\n\tv734 = v1086 & v1086;\nL_02CE:\n\tv1108 = ~v208[v949 @ X26_v10 (System.Int32)];\n\tif (v1108) goto L_0231;\n\tv949 = v949 - 1;\n\tv1090 = v949 > 0;\n\tif (v1090) goto L_02CE;\n\tgoto L_0231;\nL_02EA:\n\tv253 = v205 != 3;\n\tif (v253) goto L_0327;\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[2]);\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[0]);\n\tSpine.ExposedList`1<System.Int32>::Add(this.triangles, v410[1]);\nL_0327:\n\treturn this.triangles;\nL_0328:\n\tv384 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 624 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList<int> Triangulate(ExposedList<float> verticesArray)
		{
			float[] items = verticesArray.Items;
			int num = verticesArray.Count >> 1;
			indicesArray.Clear();
			ExposedList<int> exposedList = indicesArray.Resize(num);
			int[] items2 = exposedList.Items;
			if (verticesArray.Count >= 2)
			{
				int num2 = num - 1;
				bool flag = num2 < 0;
				bool flag2 = num2 == 0;
				int num3 = num ^ 1;
				int num4 = num ^ num2;
				int num5 = num3 & num4;
				bool flag3 = num5 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				int num6 = ((!(flag4 && flag5)) ? 1 : num);
				int num7 = 0;
				do
				{
					items2[num7] = num7;
					num7++;
				}
				while (num6 != num7);
			}
			ExposedList<bool> exposedList2 = isConcaveArray.Resize(num);
			bool[] items3 = exposedList2.Items;
			if (verticesArray.Count >= 2)
			{
				int num8 = num - 1;
				bool flag6 = num8 < 0;
				bool flag7 = num8 == 0;
				int num9 = num ^ 1;
				int num10 = num ^ num8;
				int num11 = num9 & num10;
				bool flag8 = num11 < 0;
				bool flag9 = flag6 == flag8;
				bool flag10 = !flag7;
				int num12 = ((!(flag9 && flag10)) ? 1 : num);
				int num13 = 0;
				do
				{
					bool flag11 = IsConcave(num13, num, verticesArray.Items, items2);
					items3[num13] = flag11;
					num13++;
				}
				while (num12 != num13);
			}
			triangles.Clear();
			int val = num - 2;
			int num14 = Math.Max(0, val);
			int min = num14 << 2;
			triangles.EnsureCapacity(min);
			int num16;
			if (verticesArray.Count >= 8)
			{
				int num15 = items3.Length;
				bool flag19;
				do
				{
					num16 = num - 1;
					int num17 = 1;
					int num18 = 0;
					int num19 = num16;
					int num20 = 0;
					int num31;
					while (true)
					{
						if (!items3[num18])
						{
							int num21 = items2[num19] << 1;
							int num22 = num21 | 1;
							int num23 = items2[num18] << 1;
							int num24 = num23 | 1;
							int num25 = items2[num17] << 1;
							int num26 = num25 | 1;
							int num27 = num17 + 1;
							int num28 = num27 / num;
							int num29 = num28 * num;
							int num30 = num27 - num29;
							bool flag12 = num30 == num19;
							num31 = num20;
							if (flag12)
							{
								break;
							}
							float num32 = items[num22] - items[num26];
							float num33 = items[num24] - items[num22];
							float num34 = items[num26] - items[num24];
							while (true)
							{
								if (items3[num30])
								{
									int num35 = items2[num30] << 1;
									int num36 = num35 | 1;
									float num37 = items[num36] - items[num22];
									float num38 = items[num26] - items[num36];
									float num39 = items[num25] * num37;
									float num40 = items[num21] * num38;
									float num41 = num39 + num40;
									float num42 = num32 * items[num35];
									float num43 = num42 + num41;
									if (!(num43 < 0f))
									{
										float num44 = items[num36] - items[num24];
										float num45 = items[num22] - items[num36];
										float num46 = items[num21] * num44;
										float num47 = items[num23] * num45;
										float num48 = num46 + num47;
										float num49 = num33 * items[num35];
										float num50 = num49 + num48;
										if (!(num50 < 0f))
										{
											float num51 = items[num36] - items[num26];
											float num52 = items[num24] - items[num36];
											float num53 = items[num23] * num51;
											float num54 = items[num25] * num52;
											float num55 = num53 + num54;
											float num56 = num34 * items[num35];
											float num57 = num56 + num55;
											if (!(num57 < 0f))
											{
												break;
											}
										}
									}
								}
								int num58 = num30 + 1;
								int num59 = num58 / num;
								int num60 = num59 * num;
								num30 = num58 - num60;
								bool flag13 = num30 != num19;
								num31 = num20;
								if (!flag13)
								{
									goto end_IL_0b81;
								}
							}
						}
						if (num17 != 0)
						{
							int num61 = num17 + 1;
							int num62 = num61 / num;
							bool flag14 = num17 < num15;
							bool flag15 = !flag14;
							int num63 = num62 * num;
							num17 = num61 - num63;
							bool flag16 = !flag15;
							num18 = num17;
							num19 = num20;
							num20 = num17;
							if (!flag16)
							{
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								return (ExposedList<int>)(object)new NullReferenceException();
							}
							continue;
						}
						int num64 = num20 - 1;
						int num65 = num64 & num64;
						num31 = num20;
						while (items3[num31])
						{
							num31--;
							if (num31 <= 0)
							{
								num31 = num65;
								break;
							}
						}
						break;
						continue;
						end_IL_0b81:
						break;
					}
					int num66 = num16 + num31;
					int num67 = num66 / num;
					int num68 = num67 * num;
					int num69 = num66 - num68;
					triangles.Add(items2[num69]);
					triangles.Add(items2[num31]);
					int num70 = num31 + 1;
					int num71 = num70 / num;
					int num72 = num71 * num;
					int num73 = num70 - num72;
					triangles.Add(items2[num73]);
					indicesArray.RemoveAt(num31);
					isConcaveArray.RemoveAt(num31);
					int num74 = num31 + num16;
					int num75 = num74 - 1;
					int num76 = num75 / num16;
					int num77 = num76 * num16;
					int num78 = num75 - num77;
					if (num31 == num16)
					{
						num31 = 0;
					}
					bool flag17 = IsConcave(num78, num16, verticesArray.Items, items2);
					items3[num78] = flag17;
					bool flag18 = IsConcave(num31, num16, verticesArray.Items, items2);
					num15 = items3.Length;
					items3[num31] = flag18;
					flag19 = num > 4;
					num = num16;
				}
				while (flag19);
			}
			else
			{
				num16 = num;
			}
			if (num16 == 3)
			{
				triangles.Add(items2[2]);
				triangles.Add(items2[0]);
				triangles.Add(items2[1]);
			}
			return triangles;
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0x153EDAC", Offset = "0x153EDAC", Length = "0xAC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv774 = Il2CppMethodInfo;\n\tv775 = \"il2cpp_codegen_initialize_runtime_metadata\"(v774, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv789 = Il2CppMethodInfo;\n\tv790 = \"il2cpp_codegen_initialize_runtime_metadata\"(v789, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv904 = Il2CppMethodInfo;\n\tv905 = \"il2cpp_codegen_initialize_runtime_metadata\"(v904, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv909 = Il2CppMethodInfo;\n\tv910 = \"il2cpp_codegen_initialize_runtime_metadata\"(v909, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv925 = Il2CppMethodInfo;\n\tv926 = \"il2cpp_codegen_initialize_runtime_metadata\"(v925, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1208 = Il2CppMethodInfo;\n\tv1209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1208, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1213 = Il2CppMethodInfo;\n\tv1214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1213, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1219 = Il2CppMethodInfo;\n\tv1220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1219, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1222 = Il2CppMethodInfo;\n\tv1223 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1222, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1226 = Il2CppMethodInfo;\n\tv1227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1226, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1230 = Il2CppMethodInfo;\n\tv1231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1230, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv1234 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1234, verticesArray, triangles, methodInfo, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37BC3]) = v70;\nL_004C:\n\tv75 = this.convexPolygons;\n\tv630 = verticesArray.Items;\n\tv787 = v75.Count < 1;\n\tif (v787) goto L_0087;\nL_0060:\n\tv736 = v75.Items;\n\tSpine.Pool`1<Spine.ExposedList`1<System.Single>>::Free(this.polygonPool, v736[v723 @ X21_v8 (System.Int32)]);\n\tv723 = v723 + 1;\n\tv797 = v75.Count != v723;\n\tif (v797) goto L_0060;\nL_0087:\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Single>>::Clear(v75, 1);\n\tv724 = this.convexPolygonsIndices;\n\tv923 = v724.Count < 1;\n\tif (v923) goto L_00C2;\nL_009B:\n\tv738 = v724.Items;\n\tSpine.Pool`1<Spine.ExposedList`1<System.Int32>>::Free(this.polygonIndicesPool, v738[v637 @ X22_v20 (System.Int32)]);\n\tv637 = v637 + 1;\n\tv1191 = v724.Count != v637;\n\tif (v1191) goto L_009B;\nL_00C2:\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::Clear(v724, 1);\n\tv655 = Spine.Pool`1<Spine.ExposedList`1<System.Int32>>::Obtain(this.polygonIndicesPool);\n\tSpine.ExposedList`1<System.Int32>::Clear(v655, 1);\n\tv657 = Spine.Pool`1<Spine.ExposedList`1<System.Single>>::Obtain(this.polygonPool);\n\tSpine.ExposedList`1<System.Single>::Clear(v657, 1);\n\tv410 = triangles.Count < 1;\n\tif (v410) goto L_02F4;\n\tv293 = triangles.Items;\nL_0103:\n\tv265 = v745 + 1;\n\tv768 = v265 + 1;\n\tv728 = v293[v745 @ X8_v60 (System.Int32)] << 1;\n\tv950 = v728 | 1;\n\tv243 = v293[v265 @ X11_v21 (System.Int32)] << 1;\n\tv957 = v243 | 1;\n\tv1510 = v745 + 2;\n\tv715 = v293[v1510 @ X8_v61 (System.Int32)] << 1;\n\tv1182 = v715 | 1;\n\tv412 = v1251 != v728;\n\tif (v412) goto L_0255;\n\tv746 = v1267.Items;\n\tv951 = v1267.Count - 4;\n\tv939 = v1267.Count - 3;\n\tv944 = v1267.Count - 2;\n\tv959 = v1267.Count - 1;\n\tv1594 = v746[v944 @ X12_v20 (System.Int32)] - v746[v951 @ X10_v29 (System.Int32)];\n\tv931 = v746[v959 @ X11_v30 (System.Int32)] - v746[v939 @ X13_v19 (System.Int32)];\n\tv930 = v630[v715 @ X25_v16 (System.Int32)] * v931;\n\tv929 = v630[v1182 @ X8_v65 (System.Int32)] * v1594;\n\tv1595 = v746[v939 @ X13_v19 (System.Int32)] * v1594;\n\tv932 = v930 - v929;\n\tv1596 = v746[v951 @ X10_v29 (System.Int32)] * v931;\n\tv935 = v1595 + v932;\n\tv936 = v935 - v1596;\n\tv1600 = v936 < 0;\n\tv1603 = v936 ^ v936;\n\tv1604 = v936 & v1603;\n\tv1605 = v1604 < 0;\n\tv1606 = v1600 == v1605;\n\tv1607 = ~v1606;\n\tv928 = ~v1607;\n\tif (v928) goto L_FFFFFFFF;\n\tgoto L_0204;\nL_0204:\n\tv1663 = v746[0] - v630[v715 @ X25_v16 (System.Int32)];\n\tv1528 = v630[v1182 @ X8_v65 (System.Int32)] * v1663;\n\tv1664 = v746[1] - v630[v1182 @ X8_v65 (System.Int32)];\n\tv1665 = v1663 * v746[3];\n\tv1531 = v1664 * v746[2];\n\tv1666 = v1531 - v1665;\n\tv1532 = v630[v715 @ X25_v16 (System.Int32)] * v1664;\n\tv1667 = v1528 + v1666;\n\tv1530 = v1667 - v1532;\n\tv1671 = v1530 < 0;\n\tv1674 = v1530 ^ v1530;\n\tv1675 = v1530 & v1674;\n\tv1676 = v1675 < 0;\n\tv1678 = v1671 == v1676;\n\tv1679 = ~v1678;\n\tv1527 = ~v1679;\n\tif (v1527) goto L_FFFFFFFF;\n\tgoto L_0228;\nL_0228:\n\tv1535 = v952 != v1252;\n\tif (v1535) goto L_0255;\n\tv1534 = v1562 != v1252;\n\tif (v1534) goto L_0255;\n\tSpine.ExposedList`1<System.Single>::Add(v1267, v630[v715 @ X25_v16 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v1267, v630[v1182 @ X8_v65 (System.Int32)]);\n\tSpine.ExposedList`1<System.Int32>::Add(v1253, v715);\n\tgoto L_02D9;\nL_0255:\n\tv413 = v1267.Count < 1;\n\tif (v413) goto L_026D;\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Single>>::Add(v75, v1267);\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::Add(v724, v1253);\n\tgoto L_027C;\nL_026D:\n\tSpine.Pool`1<Spine.ExposedList`1<System.Single>>::Free(this.polygonPool, v1267);\n\tSpine.Pool`1<Spine.ExposedList`1<System.Int32>>::Free(this.polygonIndicesPool, v1253);\nL_027C:\n\tv662 = Spine.Pool`1<Spine.ExposedList`1<System.Single>>::Obtain(v278.polygonPool);\n\tSpine.ExposedList`1<System.Single>::Clear(v662, 1);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v728 @ X24_v19 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v950 @ X10_v25 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v243 @ X26_v9 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v957 @ X11_v25 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v715 @ X25_v16 (System.Int32)]);\n\tSpine.ExposedList`1<System.Single>::Add(v662, v630[v1182 @ X8_v65 (System.Int32)]);\n\tv664 = Spine.Pool`1<Spine.ExposedList`1<System.Int32>>::Obtain(v278.polygonIndicesPool);\n\tSpine.ExposedList`1<System.Int32>::Clear(v664, 1);\n\tSpine.ExposedList`1<System.Int32>::Add(v664, v728);\n\tSpine.ExposedList`1<System.Int32>::Add(v664, v243);\n\tSpine.ExposedList`1<System.Int32>::Add(v664, v715);\n\tv1886 = v630[v243 @ X26_v9 (System.Int32)] - v630[v728 @ X24_v19 (System.Int32)];\n\tv1887 = v630[v957 @ X11_v25 (System.Int32)] - v630[v950 @ X10_v25 (System.Int32)];\n\tv1888 = v1887 * v630[v715 @ X25_v16 (System.Int32)];\n\tv1837 = v1886 * v630[v1182 @ X8_v65 (System.Int32)];\n\tv1889 = v630[v950 @ X10_v25 (System.Int32)] * v1886;\n\tv1839 = v1888 - v1837;\n\tv1890 = v1889 + v1839;\n\tv1840 = v630[v728 @ X24_v19 (System.Int32)] * v1887;\n\tv1838 = v1890 - v1840;\n\tv1860 = v1838 < 0;\n\tv1854 = v1838 ^ v1838;\n\tv1852 = v1838 & v1854;\n\tv1850 = v1852 < 0;\n\tv1892 = v1860 == v1850;\n\tv1848 = ~v1892;\n\tv1836 = ~v1848;\n\tif (v1836) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_02D9:\n\tv745 = v768 + 1;\n\tv1258 = v745 < triangles.Count;\n\tif (v1258) goto L_0103;\nL_02F4:\n\tv1288 = v642.Count < 1;\n\tif (v1288) goto L_0302;\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Single>>::Add(v75, v642);\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::Add(v724, v312);\nL_0302:\n\tv246 = v75.Count;\n\tv1322 = v75.Count < 1;\n\tif (v1322) goto L_04F2;\nL_0311:\n\tv755 = v7\n// ... truncated")]
		public ExposedList<ExposedList<float>> Decompose(ExposedList<float> verticesArray, ExposedList<int> triangles)
		{
			//IL_0bc8: Expected I4, but got F4
			//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bd5: Expected I4, but got Unknown
			//IL_0446: Expected I4, but got F4
			//IL_044e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0453: Expected I4, but got Unknown
			//IL_05a1: Expected O, but got F4
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05af: Expected I4, but got Unknown
			//IL_08e6: Expected O, but got F4
			//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f4: Expected I4, but got Unknown
			//IL_0f91: Expected I4, but got F4
			//IL_0f99: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f9e: Expected I4, but got Unknown
			//IL_1362: Expected I4, but got F4
			//IL_136a: Unknown result type (might be due to invalid IL or missing references)
			//IL_136f: Expected I4, but got Unknown
			ExposedList<ExposedList<float>> exposedList = convexPolygons;
			float[] items = verticesArray.Items;
			if (exposedList.Count >= 1)
			{
				int num = 0;
				do
				{
					ExposedList<float>[] items2 = exposedList.Items;
					polygonPool.Free(items2[num]);
					num++;
				}
				while (exposedList.Count != num);
			}
			exposedList.Clear();
			ExposedList<ExposedList<int>> exposedList2 = convexPolygonsIndices;
			if (exposedList2.Count >= 1)
			{
				int num2 = 0;
				do
				{
					ExposedList<int>[] items3 = exposedList2.Items;
					polygonIndicesPool.Free(items3[num2]);
					num2++;
				}
				while (exposedList2.Count != num2);
			}
			exposedList2.Clear();
			ExposedList<int> exposedList3 = polygonIndicesPool.Obtain();
			exposedList3.Clear();
			ExposedList<float> exposedList4 = polygonPool.Obtain();
			exposedList4.Clear();
			bool flag = triangles.Count < 1;
			ExposedList<int> item = exposedList3;
			ExposedList<float> exposedList5 = exposedList4;
			if (!flag)
			{
				int[] items4 = triangles.Items;
				int num3 = -1;
				int num4 = 0;
				ExposedList<int> exposedList6 = exposedList3;
				ExposedList<float> exposedList7 = exposedList4;
				int num5 = 0;
				bool flag8;
				do
				{
					int num6 = num5 + 1;
					int num7 = num6 + 1;
					int num8 = items4[num5] << 1;
					int num9 = num8 | 1;
					int num10 = items4[num6] << 1;
					int num11 = num10 | 1;
					int num12 = num5 + 2;
					int num13 = items4[num12] << 1;
					int num14 = num13 | 1;
					if (num3 == num8)
					{
						float[] items5 = exposedList7.Items;
						int num15 = exposedList7.Count - 4;
						int num16 = exposedList7.Count - 3;
						int num17 = exposedList7.Count - 2;
						int num18 = exposedList7.Count - 1;
						float num19 = items5[num17] - items5[num15];
						float num20 = items5[num18] - items5[num16];
						float num21 = items[num13] * num20;
						float num22 = items[num14] * num19;
						float num23 = items5[num16] * num19;
						float num24 = num21 - num22;
						float num25 = items5[num15] * num20;
						float num26 = num23 + num24;
						float num27 = num26 - num25;
						bool flag2 = num27 < 0f;
						int num28 = num27 ^ num27;
						int num29 = num27 & num28;
						bool flag3 = num29 < 0;
						int num30 = ((flag2 == flag3) ? 1 : (-1));
						float num31 = items5[0] - items[num13];
						float num32 = items[num14] * num31;
						float num33 = items5[1] - items[num14];
						float num34 = num31 * items5[3];
						float num35 = num33 * items5[2];
						float num36 = num35 - num34;
						float num37 = items[num13] * num33;
						float num38 = num32 + num36;
						float num39 = num38 - num37;
						bool flag4 = num39 < 0f;
						object obj = num39 ^ num39;
						int num40 = num39 & (nint)obj;
						bool flag5 = num40 < 0;
						int num41 = ((flag4 == flag5) ? 1 : (-1));
						if (num30 == num4 && num41 == num4)
						{
							exposedList7.Add(items[num13]);
							exposedList7.Add(items[num14]);
							exposedList6.Add(num13);
							goto IL_12bd;
						}
					}
					Triangulator triangulator;
					if (exposedList7.Count >= 1)
					{
						exposedList.Add(exposedList7);
						exposedList2.Add(exposedList6);
						triangulator = this;
					}
					else
					{
						polygonPool.Free(exposedList7);
						polygonIndicesPool.Free(exposedList6);
						triangulator = this;
					}
					ExposedList<float> exposedList8 = triangulator.polygonPool.Obtain();
					exposedList8.Clear();
					exposedList8.Add(items[num8]);
					exposedList8.Add(items[num9]);
					exposedList8.Add(items[num10]);
					exposedList8.Add(items[num11]);
					exposedList8.Add(items[num13]);
					exposedList8.Add(items[num14]);
					ExposedList<int> exposedList9 = triangulator.polygonIndicesPool.Obtain();
					exposedList9.Clear();
					exposedList9.Add(num8);
					exposedList9.Add(num10);
					exposedList9.Add(num13);
					float num42 = items[num10] - items[num8];
					float num43 = items[num11] - items[num9];
					float num44 = num43 * items[num13];
					float num45 = num42 * items[num14];
					float num46 = items[num9] * num42;
					float num47 = num44 - num45;
					float num48 = num46 + num47;
					float num49 = items[num8] * num43;
					float num50 = num48 - num49;
					bool flag6 = num50 < 0f;
					object obj2 = num50 ^ num50;
					int num51 = num50 & (nint)obj2;
					bool flag7 = num51 < 0;
					num4 = ((flag6 == flag7) ? 1 : (-1));
					num3 = num8;
					exposedList6 = exposedList9;
					exposedList7 = exposedList8;
					goto IL_12bd;
					IL_12bd:
					num5 = num7 + 1;
					flag8 = num5 < triangles.Count;
					item = exposedList6;
					exposedList5 = exposedList7;
				}
				while (flag8);
			}
			if (exposedList5.Count >= 1)
			{
				exposedList.Add(exposedList5);
				exposedList2.Add(item);
			}
			int count = exposedList.Count;
			bool flag9 = exposedList.Count < 1;
			Triangulator triangulator2 = this;
			if (!flag9)
			{
				int num52 = -1;
				int num53 = 0;
				do
				{
					ExposedList<int>[] items6 = exposedList2.Items;
					ExposedList<int> exposedList10 = items6[num53];
					if (exposedList10.Count != 0)
					{
						int[] items7 = exposedList10.Items;
						int num54 = exposedList10.Count - 1;
						ExposedList<float>[] items8 = exposedList.Items;
						ExposedList<float> exposedList11 = items8[num53];
						float[] items9 = exposedList11.Items;
						int num55 = exposedList11.Count - 4;
						int num56 = exposedList11.Count - 3;
						int num57 = exposedList11.Count - 2;
						int num58 = exposedList11.Count - 1;
						float num59 = items9[num57] - items9[num55];
						float num60 = items9[num56] * num59;
						float num61 = items9[num58] - items9[num56];
						float num62 = num59 * items9[1];
						float num63 = num61 * items9[0];
						float num64 = num63 - num62;
						float num65 = num60 + num64;
						float num66 = items9[num55] * num61;
						float num67 = num65 - num66;
						bool flag10 = num67 < 0f;
						int num68 = num67 ^ num67;
						int num69 = num67 & num68;
						bool flag11 = num69 < 0;
						float num70;
						int num71;
						float num72;
						float num73;
						float num74;
						int num75;
						int num76;
						if (flag10 != flag11)
						{
							num70 = items9[num58];
							num71 = num52;
							num72 = items9[num55];
							num73 = items9[num56];
							num74 = items9[num57];
							num75 = num52;
							num76 = 0;
						}
						else
						{
							num70 = items9[num58];
							num71 = num52;
							num72 = items9[num55];
							num73 = items9[num56];
							num74 = items9[num57];
							num75 = 1;
							num76 = 0;
						}
						bool flag16;
						do
						{
							float num103;
							float num104;
							float num105;
							float num106;
							if (num76 == num53)
							{
								num76 = num53;
							}
							else
							{
								ExposedList<int>[] items10 = exposedList2.Items;
								ExposedList<int> exposedList12 = items10[num76];
								if (exposedList12.Count == 3)
								{
									int[] items11 = exposedList12.Items;
									ExposedList<float>[] items12 = exposedList.Items;
									ExposedList<float> exposedList13 = items12[num76];
									float[] items13 = exposedList13.Items;
									int num77 = exposedList13.Count - 2;
									int num78 = exposedList13.Count - 1;
									if (items11[0] == items7[0] && items11[1] == items7[num54])
									{
										float num79 = num74 - num72;
										float num80 = num70 - num73;
										float num81 = num73 * num79;
										float num82 = num80 * items13[num77];
										float num83 = num79 * items13[num78];
										float num84 = items9[0] - items13[num77];
										float num85 = items9[1] - items13[num78];
										float num86 = num82 - num83;
										float num87 = items9[2] * num85;
										float num88 = num81 + num86;
										float num89 = items9[3] * num84;
										float num90 = num80 * num72;
										float num91 = num87 - num89;
										float num92 = num88 - num90;
										float num93 = num84 * items13[num78];
										float num94 = items13[num77] * num85;
										float num95 = num93 + num91;
										bool flag12 = num92 < 0f;
										int num96 = num92 ^ num92;
										int num97 = num92 & num96;
										bool flag13 = num97 < 0;
										float num98 = num95 - num94;
										int num99 = ((flag12 == flag13) ? 1 : num71);
										bool flag14 = num98 < 0f;
										int num100 = num98 ^ num98;
										int num101 = num98 & num100;
										bool flag15 = num101 < 0;
										int num102 = ((flag14 == flag15) ? 1 : num71);
										if (num99 == num75 && num102 == num75)
										{
											items12[num76].Clear();
											items10[num76].Clear();
											items8[num53].Add(items13[num77]);
											items8[num53].Add(items13[num78]);
											items6[num53].Add(items11[2]);
											num103 = num70;
											num71 = -1;
											num104 = items13[num78];
											num105 = num74;
											num106 = items13[num77];
											num76 = 0;
											goto IL_13cf;
										}
									}
								}
							}
							num103 = num73;
							num104 = num70;
							num105 = num72;
							num106 = num74;
							goto IL_13cf;
							IL_13cf:
							num76++;
							flag16 = num76 < count;
							num52 = num71;
							num70 = num104;
							num72 = num105;
							num73 = num103;
							num74 = num106;
						}
						while (flag16);
					}
					num53++;
				}
				while (num53 != count);
				count = exposedList.Count;
				triangulator2 = this;
			}
			bool flag17 = count < 1;
			int num107 = count - 1;
			if (!flag17)
			{
				bool flag18;
				do
				{
					ExposedList<float>[] items14 = exposedList.Items;
					ExposedList<float> exposedList14 = items14[num107];
					if (exposedList14.Count == 0)
					{
						exposedList.RemoveAt(num107);
						triangulator2.polygonPool.Free(items14[num107]);
						ExposedList<int>[] items15 = exposedList2.Items;
						exposedList2.RemoveAt(num107);
						triangulator2.polygonIndicesPool.Free(items15[num107]);
					}
					int num108 = num107 - 1;
					flag18 = num107 >= 1;
					num107 = num108;
				}
				while (flag18);
			}
			return exposedList;
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x154FBFC", Offset = "0x154FBFC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = index + vertexCount;\n\tv8 = v4 - 1;\n\tv9 = v8 / vertexCount;\n\tv10 = v9 * vertexCount;\n\tv11 = v8 - v10;\n\tv172 = index + 1;\n\tv38 = v172 / vertexCount;\n\tv171 = v38 * vertexCount;\n\tv78 = v172 - v171;\n\tv170 = indices[v11 @ X8_v4 (System.Int32)] << 1;\n\tv118 = v170 | 1;\n\tv114 = indices[index @ X0 (System.Int32)] << 1;\n\tv113 = v114 | 1;\n\tv167 = indices[v78 @ X9_v5 (System.Int32)] << 1;\n\tv112 = v167 | 1;\n\tv179 = vertices[v112 @ X14_v3 (System.Int32)] - vertices[v113 @ X13_v4 (System.Int32)];\n\tv245 = vertices[v118 @ X11_v5 (System.Int32)] - vertices[v112 @ X14_v3 (System.Int32)];\n\tv246 = vertices[v113 @ X13_v4 (System.Int32)] - vertices[v118 @ X11_v5 (System.Int32)];\n\tv247 = vertices[v170 @ X8_v8 (System.Int32)] * v179;\n\tv189 = vertices[v114 @ X12_v5 (System.Int32)] * v245;\n\tv248 = v247 + v189;\n\tv191 = v246 * vertices[v167 @ X9_v8 (System.Int32)];\n\tv185 = v191 + v248;\n\tv214 = v185 < 0;\n\tv208 = v185 ^ v185;\n\tv206 = v185 & v208;\n\tv204 = v206 < 0;\n\tv250 = v214 == v204;\n\tv202 = ~v250;\n\treturn v202;\n\tv22 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsConcave(int index, int vertexCount, float[] vertices, int[] indices)
		{
			//IL_01f5: Expected O, but got F4
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected I4, but got Unknown
			int num = index + vertexCount;
			int num2 = num - 1;
			int num3 = num2 / vertexCount;
			int num4 = num3 * vertexCount;
			int num5 = num2 - num4;
			int num6 = index + 1;
			int num7 = num6 / vertexCount;
			int num8 = num7 * vertexCount;
			int num9 = num6 - num8;
			int num10 = indices[num5] << 1;
			int num11 = num10 | 1;
			int num12 = indices[index] << 1;
			int num13 = num12 | 1;
			int num14 = indices[num9] << 1;
			int num15 = num14 | 1;
			float num16 = vertices[num15] - vertices[num13];
			float num17 = vertices[num11] - vertices[num15];
			float num18 = vertices[num13] - vertices[num11];
			float num19 = vertices[num10] * num16;
			float num20 = vertices[num12] * num17;
			float num21 = num19 + num20;
			float num22 = num18 * vertices[num14];
			float num23 = num22 + num21;
			bool flag = num23 < 0f;
			object obj = num23 ^ num23;
			int num24 = num23 & (nint)obj;
			bool flag2 = num24 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0x154FD14", Offset = "0x154FD14", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = p3y - p2y;\n\tv3 = p1y - p3y;\n\tv5 = p2y - p1y;\n\tv6 = v0 * p1x;\n\tv8 = v3 * p2x;\n\tv10 = v6 + v8;\n\tv11 = v5 * p3x;\n\tv13 = v11 + v10;\n\tv17 = v13 < 0;\n\tv20 = v13 ^ v13;\n\tv21 = v13 & v20;\n\tv22 = v21 < 0;\n\tv23 = v17 == v22;\n\treturn v23;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool PositiveArea(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
		{
			//IL_0096: Expected O, but got F4
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected I4, but got Unknown
			float num = p3y - p2y;
			float num2 = p1y - p3y;
			float num3 = p2y - p1y;
			float num4 = num * p1x;
			float num5 = num2 * p2x;
			float num6 = num4 + num5;
			float num7 = num3 * p3x;
			float num8 = num7 + num6;
			bool flag = num8 < 0f;
			object obj = num8 ^ num8;
			int num9 = num8 & (nint)obj;
			bool flag2 = num9 < 0;
			return flag == flag2;
		}

		[Token(Token = "0x600046D")]
		[Address(RVA = "0x154FD40", Offset = "0x154FD40", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = p2x - p1x;\n\tv3 = p2y - p1y;\n\tv6 = v3 * p3x;\n\tv8 = v0 * p3y;\n\tv10 = v0 * p1y;\n\tv11 = v6 - v8;\n\tv12 = v3 * p1x;\n\tv13 = v10 + v11;\n\tv14 = v13 - v12;\n\tv18 = v14 < 0;\n\tv21 = v14 ^ v14;\n\tv22 = v14 & v21;\n\tv23 = v22 < 0;\n\tv25 = v18 == v23;\n\tv26 = ~v25;\n\tv27 = ~v26;\n\tif (v27) goto L_FFFFFFFF;\n\tgoto L_001B;\nL_001B:\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int Winding(float p1x, float p1y, float p2x, float p2y, float p3x, float p3y)
		{
			//IL_00a5: Expected O, but got F4
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected I4, but got Unknown
			float num = p2x - p1x;
			float num2 = p2y - p1y;
			float num3 = num2 * p3x;
			float num4 = num * p3y;
			float num5 = num * p1y;
			float num6 = num3 - num4;
			float num7 = num2 * p1x;
			float num8 = num5 + num6;
			float num9 = num8 - num7;
			bool flag = num9 < 0f;
			object obj = num9 ^ num9;
			int num10 = num9 & (nint)obj;
			bool flag2 = num10 < 0;
			if (flag != flag2)
			{
				return -1;
			}
			return 1;
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x154080C", Offset = "0x154080C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004D;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv84 = Il2CppMethodInfo;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv89 = Spine.ExposedList`1<System.Int32>;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv94 = Spine.ExposedList`1<System.Boolean>;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv99 = Spine.ExposedList`1<Spine.ExposedList`1<System.Int32>>;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv104 = Spine.ExposedList`1<Spine.ExposedList`1<System.Single>>;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv109 = Il2CppMethodInfo;\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv114 = Il2CppMethodInfo;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv119 = Spine.Pool`1<Spine.ExposedList`1<System.Single>>;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv124 = Spine.Pool`1<Spine.ExposedList`1<System.Int32>>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37BC4]) = v70;\nL_004D:\n\tv72 = new Spine.ExposedList`1<Spine.ExposedList`1<System.Single>>();\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Single>>::.ctor(v72);\n\tthis.convexPolygons = v72;\n\tv82 = new Spine.ExposedList`1<Spine.ExposedList`1<System.Int32>>();\n\tSpine.ExposedList`1<Spine.ExposedList`1<System.Int32>>::.ctor(v82);\n\tthis.convexPolygonsIndices = v82;\n\tv92 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v92);\n\tthis.indicesArray = v92;\n\tv102 = new Spine.ExposedList`1<System.Boolean>();\n\tSpine.ExposedList`1<System.Boolean>::.ctor(v102);\n\tthis.isConcaveArray = v102;\n\tv112 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v112);\n\tthis.triangles = v112;\n\tv122 = new Spine.Pool`1<Spine.ExposedList`1<System.Single>>();\n\tSpine.Pool`1<Spine.ExposedList`1<System.Single>>::.ctor(v122, 0x10, 0x7FFFFFFF);\n\tthis.polygonPool = v122;\n\tv134 = new Spine.Pool`1<Spine.ExposedList`1<System.Int32>>();\n\tSpine.Pool`1<Spine.ExposedList`1<System.Int32>>::.ctor(v134, 0x10, 0x7FFFFFFF);\n\tthis.polygonIndicesPool = v134;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Triangulator()
		{
			ExposedList<ExposedList<float>> exposedList = new ExposedList<ExposedList<float>>();
			convexPolygons = exposedList;
			ExposedList<ExposedList<int>> exposedList2 = new ExposedList<ExposedList<int>>();
			convexPolygonsIndices = exposedList2;
			ExposedList<int> exposedList3 = new ExposedList<int>();
			indicesArray = exposedList3;
			ExposedList<bool> exposedList4 = new ExposedList<bool>();
			isConcaveArray = exposedList4;
			ExposedList<int> exposedList5 = new ExposedList<int>();
			triangles = exposedList5;
			Pool<ExposedList<float>> pool = new Pool<ExposedList<float>>();
			polygonPool = pool;
			Pool<ExposedList<int>> pool2 = new Pool<ExposedList<int>>();
			polygonIndicesPool = pool2;
		}
	}
}
