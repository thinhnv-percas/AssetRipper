using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000017")]
	public static class GraphColoring
	{
		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xE2EE6C", Offset = "0xE2EE6C", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EC9AC8]);\n\tv37 = *([v36 @ X8_v20]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, constraintIndices, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2024686]) = v55;\nL_0021:\n\tv60 = constraintIndices.Length - 1;\n\tv62 = constraintIndices.Length == 1;\n\tif (v62) goto L_01D6;\n\t// 38 NewArr v226 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v60 @ X22_v2 (System.Int32)\n\t// 45 NewArr v234 @ X0_v11 (System.Boolean[]), typeof(System.Boolean[]), v60 @ X22_v2 (System.Int32)\n\tv332 = v60 < 1;\n\tif (v332) goto L_01E6;\nL_0040:\n\tv409 = v139 < constraintIndices.Length;\n\tv410 = ~v409;\n\tif (v410) goto L_01E7;\n\tv130 = v139 + 1;\n\tv418 = v130 < constraintIndices.Length;\n\tv192 = ~v418;\n\tif (v192) goto L_01E7;\n\tv125 = v139 << 2;\n\tv564 = constraintIndices + v125;\n\tv121 = *([v564 @ X8_v12+24]) - constraintIndices[v139 @ X24_v5 (System.Int32)];\n\tSystem.Array::Sort(particleIndices, constraintIndices[v139 @ X24_v5 (System.Int32)], v121);\n\tv219 = v130 - 1;\n\tv566 = v219 < v226.Length;\n\tv193 = ~v566;\n\tif (v193) goto L_01E7;\n\tv226[v139 @ X24_v5 (System.Int32)] = 0xFFFFFFFF;\n\tv567 = v219 < v234.Length;\n\tv540 = ~v567;\n\tif (v540) goto L_01E7;\n\tv234[v139 @ X24_v5 (System.Int32)] = 1;\n\tv139 = v219 + 1;\n\tv386 = v139 < v60;\n\tif (v386) goto L_0040;\n\tv355 = v60 < 1;\n\tif (v355) goto L_01E6;\nL_009B:\n\tv80 = v220 + 1;\n\tv601 = constraintIndices + 0x20;\n\tv603 = v80 << 2;\n\tv76 = v601 + v603;\n\tv604 = v220 << 2;\n\tv72 = v601 + v604;\n\tgoto L_0159;\nL_00A4:\n\tv633 = v80 < constraintIndices.Length;\n\tv541 = ~v633;\n\tif (v541) goto L_01E7;\n\tv343 = v84 + 1;\n\tv685 = v343 < constraintIndices.Length;\n\tv542 = ~v685;\n\tif (v542) goto L_01E7;\n\tv98 = constraintIndices[v343 @ X15_v6 (System.Int32)] - constraintIndices[v84 @ X16_v6 (System.Int32)];\n\tv639 = v98 < 1;\n\tif (v639) goto L_0167;\n\tv199 = *([v76 @ X13_v5]) - *([v72 @ X14_v6]);\n\tv144 = v199 < 1;\n\tif (v144) goto L_0167;\nL_00DD:\n\tv420 = constraintIndices[v84 @ X16_v6 (System.Int32)] + v434;\n\tv745 = v420 << 2;\n\tv746 = particleIndices + v745;\n\tv419 = v746 + 0x20;\nL_00E1:\n\tv432 = *([v72 @ X14_v6]) + v442;\n\tv776 = v432 < particleIndices.Length;\n\tv543 = ~v776;\n\tif (v543) goto L_01E7;\n\tv780 = v420 < particleIndices.Length;\n\tv544 = ~v780;\n\tif (v544) goto L_01E7;\n\tv794 = particleIndices[v432 @ X7_v9 (System.Int32)] > *([v419 @ X6_v9]);\n\tif (v794) goto L_0117;\n\tv451 = particleIndices[v432 @ X7_v9 (System.Int32)] >= *([v419 @ X6_v9]);\n\tif (v451) goto L_0131;\n\tv442 = v442 + 1;\n\tv640 = v442 < v199;\n\tif (v640) goto L_00E1;\n\tgoto L_0167;\nL_0117:\n\tv434 = v434 + 1;\n\tv641 = v434 >= v98;\n\tif (v641) goto L_0167;\n\tv642 = v442 < v199;\n\tif (v642) goto L_00DD;\n\tgoto L_0167;\nL_0131:\n\tv798 = v84 < v226.Length;\n\tv545 = ~v798;\n\tif (v545) goto L_01E7;\n\tv802 = v226[v84 @ X16_v6 (System.Int32)] & 0x80000000;\n\tv803 = v802 == 0;\n\tv559 = ~v803;\n\tif (v559) goto L_0167;\n\tv804 = v226[v84 @ X16_v6 (System.Int32)] < v234.Length;\n\tv546 = ~v804;\n\tif (v546) goto L_01E7;\n\tv635 = v234 + v226[v84 @ X16_v6 (System.Int32)];\n\t*([v635 @ X16_v11+20]) = 0;\n\tgoto L_0167;\nL_0159:\n\tv449 = v220 != v84;\n\tif (v449) goto L_00A4;\n\tv343 = v84 + 1;\nL_0167:\n\tv452 = v343 < v60;\n\tif (v452) goto L_0159;\n\tv686 = v220 < v226.Length;\n\tv547 = ~v686;\n\tif (v547) goto L_01E7;\n\tv347 = v220 << 2;\n\tv691 = v226 + v347;\n\tv427 = v691 + 0x20;\n\t*([v427 @ X12_v8]) = 0;\n\tv692 = v220 < v226.Length;\n\tv548 = ~v692;\n\tif (v548) goto L_01E7;\nL_018D:\n\tv453 = v424 >= v60;\n\tif (v453) goto L_FFFFFFFF;\n\tv718 = v424 < v234.Length;\n\tv549 = ~v718;\n\tif (v549) goto L_01E7;\n\tv747 = v234[v424 @ X13_v8 (System.Int32)] == 0;\n\tv562 = ~v747;\n\tif (v562) goto L_FFFFFFFF;\n\tv424 = v424 + 1;\n\t*([v427 @ X12_v8]) = v424;\n\tv777 = v220 < v226.Length;\n\tv550 = ~v777;\n\tv454 = ~v550;\n\tif (v454) goto L_018D;\n\tgoto L_01E7;\nL_01AF:\n\tv766 = v428 < v234.Length;\n\tv551 = ~v766;\n\tif (v551) goto L_01E7;\n\tv234[v428 @ X12_v10 (System.Int32)] = 1;\n\tv428 = v428 + 1;\n\tv749 = v428 < v60;\n\tif (v749) goto L_01AF;\n\tv220 = v220 + 1;\n\tv356 = v220 < v60;\n\tif (v356) goto L_009B;\n\tgoto L_01E6;\nL_01D6:\n\t// 470 NewArr v228 @ X0_v8 (System.Int32[]), typeof(System.Int32[]), 0\nL_01E6:\n\treturn v380;\nL_01E7:\n\tv563 = new System.IndexOutOfRangeException();\n\tthrow v563;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 351 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int[] Colorize(int[] particleIndices, int[] constraintIndices)
		{
			//IL_00da: Expected O, but got I
			//IL_07dc: Expected O, but got I
			//IL_07f8: Expected O, but got I
			//IL_0814: Expected O, but got I
			//IL_02a7: Expected I4, but got O
			//IL_0506: Expected O, but got I
			//IL_0515: Expected O, but got I
			//IL_051e: Expected O, but got I4
			//IL_0763: Expected O, but got I
			//IL_0772: Expected O, but got I
			//IL_0703: Unknown result type (might be due to invalid IL or missing references)
			//IL_0708: Expected I4, but got Unknown
			//IL_05c6: Expected O, but got I4
			//IL_0412: Expected I4, but got I8
			//IL_0483: Expected O, but got I
			int num = constraintIndices.Length - 1;
			int[] result;
			if (constraintIndices.Length != 1)
			{
				int[] array = new int[num];
				bool[] array2 = new bool[num];
				bool flag = num < 1;
				result = array;
				if (!flag)
				{
					int num2 = 0;
					while (true)
					{
						if (num2 < constraintIndices.Length)
						{
							int num3 = num2 + 1;
							if (num3 < constraintIndices.Length)
							{
								int num4 = num2 << 2;
								object obj = (long)(IntPtr)constraintIndices + (long)num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v12+24]");
								int length = (int)(-constraintIndices[num2]);
								Array.Sort(particleIndices, constraintIndices[num2], length);
								int num5 = num3 - 1;
								if (num5 < array.Length)
								{
									array[num2] = -1;
									if (num5 < array2.Length)
									{
										array2[num2] = true;
										num2 = num5 + 1;
										if (num2 < num)
										{
											continue;
										}
										bool flag2 = num < 1;
										result = array;
										if (flag2)
										{
											break;
										}
										int num6 = 0;
										while (true)
										{
											int num7 = num6 + 1;
											object obj2 = (long)(IntPtr)constraintIndices + 32L;
											int num8 = num7 << 2;
											object obj3 = (long)(IntPtr)obj2 + (long)num8;
											int num9 = num6 << 2;
											object obj4 = (long)(IntPtr)obj2 + (long)num9;
											int num10 = 0;
											while (true)
											{
												int num11;
												if (num6 != num10)
												{
													if (num7 >= constraintIndices.Length)
													{
														break;
													}
													num11 = num10 + 1;
													if (num11 >= constraintIndices.Length)
													{
														break;
													}
													int num12 = constraintIndices[num11] - constraintIndices[num10];
													if (num12 >= 1)
													{
														int num13 = obj3 - obj4;
														if (num13 >= 1)
														{
															int num14 = 0;
															int num15 = 0;
															while (true)
															{
																int num16 = constraintIndices[num10] + num14;
																int num17 = num16 << 2;
																object obj5 = (long)(IntPtr)particleIndices + (long)num17;
																object obj6 = (long)(IntPtr)obj5 + 32L;
																while (true)
																{
																	int num18 = obj4 + num15;
																	if (num18 >= particleIndices.Length || num16 >= particleIndices.Length)
																	{
																		break;
																	}
																	if ((long)particleIndices[num18] > (long)(IntPtr)obj6)
																	{
																		goto IL_0380;
																	}
																	if ((long)particleIndices[num18] < (long)(IntPtr)obj6)
																	{
																		num15++;
																		if (num15 < num13)
																		{
																			continue;
																		}
																	}
																	else
																	{
																		if (num10 >= array.Length)
																		{
																			break;
																		}
																		if ((int)(array[num10] & 0x80000000L) == 0)
																		{
																			if (array[num10] >= array2.Length)
																			{
																				break;
																			}
																			object obj7 = (long)(IntPtr)array2 + (long)array[num10];
																			_ = 0;
																		}
																	}
																	goto IL_06d7;
																}
																break;
																IL_0380:
																num14++;
																if (num14 < num12 && num15 < num13)
																{
																	continue;
																}
																goto IL_06d7;
															}
															break;
														}
													}
												}
												else
												{
													num11 = num10 + 1;
												}
												goto IL_06d7;
												IL_06d7:
												bool flag3 = num11 < num;
												num10 = num11;
												if (flag3)
												{
													continue;
												}
												goto IL_04c0;
											}
											break;
											IL_0649:
											num6++;
											if (num6 < num)
											{
												continue;
											}
											goto IL_0673;
											IL_04c0:
											if (num6 >= array.Length)
											{
												break;
											}
											int num19 = num6 << 2;
											object obj8 = (long)(IntPtr)array + (long)num19;
											object obj9 = (long)(IntPtr)obj8 + 32L;
											obj9 = 0;
											if (num6 >= array.Length)
											{
												break;
											}
											int num20 = 0;
											while (num20 < num)
											{
												if (num20 >= array2.Length)
												{
													goto end_IL_07bf;
												}
												if (array2[num20])
												{
													break;
												}
												num20++;
												obj9 = num20;
												if (num6 >= array.Length)
												{
													goto end_IL_07bf;
												}
											}
											int num21 = 0;
											while (num21 < array2.Length)
											{
												array2[num21] = true;
												num21++;
												if (num21 < num)
												{
													continue;
												}
												goto IL_0649;
											}
											break;
											continue;
											end_IL_07bf:
											break;
										}
									}
								}
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
						IL_0673:
						result = array;
						break;
					}
				}
			}
			else
			{
				int[] array3 = new int[0];
				result = array3;
			}
			return result;
		}
	}
}
