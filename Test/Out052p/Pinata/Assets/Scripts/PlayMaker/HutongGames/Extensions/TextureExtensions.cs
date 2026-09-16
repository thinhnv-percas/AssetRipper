using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.Extensions
{
	[Token(Token = "0x2000087")]
	public static class TextureExtensions
	{
		[StructLayout((LayoutKind)0, Size = 4)]
		[Token(Token = "0x200009B")]
		public struct Point
		{
			[Token(Token = "0x400038E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public short x;

			[Token(Token = "0x400038F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2")]
			public short y;

			[Token(Token = "0x60006B7")]
			[Address(RVA = "0x846F6C", Offset = "0x846F6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.Extensions.TextureExtensions+Point)+10]) = aX;\n\t*([this @ X0 (HutongGames.Extensions.TextureExtensions+Point)+12]) = aY;\n\treturn;\n")]
			public Point(short aX, short aY)
			{
			}

			[Token(Token = "0x60006B8")]
			[Address(RVA = "0x846F78", Offset = "0x846F78", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.Extensions.TextureExtensions+Point)+10]) = aX;\n\t*([this @ X0 (HutongGames.Extensions.TextureExtensions+Point)+12]) = aY;\n\treturn;\n\tX8 = *([X0+28]);\n\tX0 = *([X8]);\n\t// 5 IndirectJump X0, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tif (TEMP) goto L_000A;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\nL_000A:\n\t// 10 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Point(int aX, int aY)
			{
			}
		}

		[Token(Token = "0x6000684")]
		[Address(RVA = "0x9C778C", Offset = "0x9C778C", Length = "0x678")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv56 = *([1EDA670]);\n\tv57 = *([v56 @ X8_v74]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, aX, aY, aFillColor, methodInfo, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv73 = 0 | 1;\n\t*([20219BF]) = v73;\nL_0026:\n\tv74 = aTex == 0;\n\tif (v74) goto L_02BF;\n\tv79 = UnityEngine.Texture::get_width(aTex);\n\tv85 = UnityEngine.Texture::get_height(aTex);\n\tv89 = UnityEngine.Texture2D::GetPixels32(aTex);\n\tv314 = v89 == 0;\n\tif (v314) goto L_02BF;\n\tv393 = v79 * aY;\n\tv394 = aX + v393;\n\tv395 = v394 < v89.Length;\n\tv283 = ~v395;\n\tif (v283) goto L_02BA;\n\tv247 = v394 << 2;\n\tv396 = v89 + v247;\n\tv244 = UnityEngine.Color32::op_Implicit(*([v396 @ X8_v9+20]));\n\tv297 = new System.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>();\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::.ctor(v297);\n\tv300 = v297 == 0;\n\tif (v300) goto L_02BF;\n\tv847 = aY & 0xFFFF;\n\tv848 = v847 << 0x10;\n\tv849 = aX & 0xFFFF;\n\tv850 = v849 | v848;\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Enqueue(v297, v850);\n\tv865 = v297._size < 1;\n\tif (v865) goto L_02B8;\n\tv670 = aFillColor & 0xFFFFFFFF;\nL_0080:\n\tv992 = System.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Dequeue(v984);\n\tv1003 = v992 >= v987;\n\tif (v1003) goto L_018D;\n\tv529 = v992 >> 0x10;\n\tv1005 = v992 & 0xFFFF0000;\n\tv527 = v529 + 1;\n\tv1006 = v1005 - 0x10000;\n\tv1007 = v529 - 1;\n\tv1008 = v527 << 0x10;\n\tv518 = v529 * v79;\n\tv523 = v79 * v527;\n\tv1010 = v79 * v1007;\nL_009E:\n\t;\n\tv681 = v518 + v520;\n\tv1114 = v681 < v89.Length;\n\tv633 = ~v1114;\n\tif (v633) goto L_02BA;\n\tv572 = v681 << 2;\n\tv1179 = v89 + v572;\n\tv668 = v1179 + 0x20;\n\tv1058 = UnityEngine.Color32::op_Implicit(*([v668 @ X20_v17]));\n\tv1084 = UnityEngine.Color::op_Inequality(v1058, v244);\n\tv1196 = v1084 == 0;\n\tv1087 = ~v1196;\n\tif (v1087) goto L_018D;\n\tv1199 = UnityEngine.Color32::op_Implicit(v670);\n\tv656 = UnityEngine.Color::op_Equality(v1058, v1199);\n\tv1209 = v656 == 0;\n\tv662 = ~v1209;\n\tif (v662) goto L_018D;\n\tv1214 = v681 < v89.Length;\n\tv634 = ~v1214;\n\tif (v634) goto L_02BA;\n\t*([v668 @ X20_v17]) = aFillColor;\n\tv537 = v527 >= v85;\n\tif (v537) goto L_013C;\n\tv675 = v523 + v520;\n\tv1229 = v675 < v89.Length;\n\tv635 = ~v1229;\n\tif (v635) goto L_02BA;\n\tv1255 = v675 << 2;\n\tv1276 = v89 + v1255;\n\tv1254 = UnityEngine.Color32::op_Implicit(*([v1276 @ X8_v68+20]));\n\tv1270 = UnityEngine.Color::op_Equality(v1254, v244);\n\tv1273 = v1270 == 0;\n\tif (v1273) goto L_013C;\n\tv1455 = UnityEngine.Color32::op_Implicit(v670);\n\tv1271 = UnityEngine.Color::op_Inequality(v1254, v1455);\n\tv1272 = v1271 == 0;\n\tif (v1272) goto L_013C;\n\tv1275 = v520 & 0xFFFF;\n\tv1264 = v1275 | v1008;\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Enqueue(v297, v1264);\nL_013C:\n\tv538 = v529 < 1;\n\tif (v538) goto L_0180;\n\tv676 = v1010 + v520;\n\tv1299 = v676 < v89.Length;\n\tv636 = ~v1299;\n\tif (v636) goto L_02BA;\n\tv1325 = v676 << 2;\n\tv1345 = v89 + v1325;\n\tv1324 = UnityEngine.Color32::op_Implicit(*([v1345 @ X8_v62+20]));\n\tv1339 = UnityEngine.Color::op_Equality(v1324, v244);\n\tv1342 = v1339 == 0;\n\tif (v1342) goto L_0180;\n\tv1464 = UnityEngine.Color32::op_Implicit(v670);\n\tv1340 = UnityEngine.Color::op_Inequality(v1324, v1464);\n\tv1341 = v1340 == 0;\n\tif (v1341) goto L_0180;\n\tv1344 = v520 & 0xFFFF;\n\tv1334 = v1344 | v1006;\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Enqueue(v297, v1334);\nL_0180:\n\tv1039 = v520 + 1;\n\tv1044 = v1039 < v79;\n\tif (v1044) goto L_009E;\nL_018D:\n\tv1092 = v992 << 0x10;\n\tv1103 = v1092 < 0x10000;\n\tif (v1103) goto L_029E;\n\tv519 = v992 >> 0x10;\n\tv530 = v519 + 1;\n\tv669 = v992 - 1;\n\tv1118 = v992 & 0xFFFF0000;\n\tv1119 = v1118 - 0x10000;\n\tv1120 = v519 - 1;\n\tv1121 = v530 << 0x10;\n\tv672 = v519 * v79;\n\tv524 = v79 * v530;\n\tv528 = v79 * v1120;\n\tgoto L_01B3;\nL_01AF:\n\tv1448 = v669 & 0xFFFF;\n\tv1438 = v1448 | v1119;\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Enqueue(v297, v1438);\n\tgoto L_028C;\nL_01B3:\n\t;\n\tv682 = v672 + v669;\n\tv1191 = v682 < v89.Length;\n\tv637 = ~v1191;\n\tif (v637) goto L_02BA;\n\tv575 = v682 << 2;\n\tv1193 = v89 + v575;\n\tv522 = v1193 + 0x20;\n\tv1147 = UnityEngine.Color32::op_Implicit(*([v522 @ X24_v11]));\n\tv1169 = UnityEngine.Color::op_Inequality(v1147, v244);\n\tv1201 = v1169 == 0;\n\tv1171 = ~v1201;\n\tif (v1171) goto L_029E;\n\tv1207 = UnityEngine.Color32::op_Implicit(v670);\n\tv659 = UnityEngine.Color::op_Equality(v1147, v1207);\n\tv1216 = v659 == 0;\n\tv665 = ~v1216;\n\tif (v665) goto L_029E;\n\tv1227 = v682 < v89.Length;\n\tv638 = ~v1227;\n\tif (v638) goto L_02BA;\n\t*([v522 @ X24_v11]) = aFillColor;\n\tv540 = v530 >= v85;\n\tif (v540) goto L_0251;\n\tv679 = v524 + v669;\n\tv1349 = v679 < v89.Length;\n\tv639 = ~v1349;\n\tif (v639) goto L_02BA;\n\tv1375 = v679 << 2;\n\tv1396 = v89 + v1375;\n\tv1374 = UnityEngine.Color32::op_Implicit(*([v1396 @ X8_v45+20]));\n\tv1390 = UnityEngine.Color::op_Equality(v1374, v244);\n\tv1393 = v1390 == 0;\n\tif (v1393) goto L_0251;\n\tv1466 = UnityEngine.Color32::op_Implicit(v670);\n\tv1391 = UnityEngine.Color::op_Inequality(v1374, v1466);\n\tv1392 = v1391 == 0;\n\tif (v1392) goto L_0251;\n\tv1395 = v669 & 0xFFFF;\n\tv1384 = v1395 | v1121;\n\tSystem.Collections.Generic.Queue`1<HutongGames.Extensions.TextureExtensions+Point>::Enqueue(v297, v1384);\nL_0251:\n\tv541 = v519 < 1;\n\tif (v541) goto L_028C;\n\tv680 = v528 + v669;\n\tv1410 = v680 < v89.Length;\n\tv640 = ~v1410;\n\tif (v640) goto L_02BA;\n\tv1436 = v680 << 2;\n\tv1447 = v89 + v1436;\n\tv1435 = UnityEngine.Color32::op_Implicit(*([v1447 @ X8_v39+20]));\n\tv1443 = UnityEngine.Color::op_Equality(v1435, v244);\n\tv1446 = v1443 == 0;\n\tif (v1446) goto L_028C;\n\tv1478 = UnityEngine.Color32::op_Implicit(v670);\n\tv1441 = UnityEngine.Color::op_Inequality(v1435, v1478);\n\tv1492 = v1441 == 0;\n\tv1445 = ~v1492;\n\tif (v1445) goto L_01AF;\nL_028C:\n\tv669 = v669 - 1;\n\tv1449 = v669 & 0x80000000;\n\tv1170 = v1449 == 0;\n\tif (v1170) goto L_01B3;\nL_029E:\n\tv905 = v297._size > 0;\n\tif (v905) goto L_0080;\nL_02B8:\n\tUnityEngine.Texture2D::SetPixels32(aTex, v89);\n\treturn;\nL_02BA:\n\tv683 = new System.IndexOutOfRangeException();\n\tthrow v683;\nL_02BF:\n\tthrow System.NullReferenceException;\n\t*([X0]) = X1;\n\t*([X0+2]) = X2;\n\treturn;\n// 512 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void FloodFillArea(this Texture2D aTex, int aX, int aY, Color32 aFillColor)
		{
			//IL_00a8: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_012d: Expected O, but got I4
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected I4, but got Unknown
			//IL_0587: Expected I4, but got O
			//IL_0184: Expected I4, but got O
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected I4, but got Unknown
			//IL_05b2: Expected I4, but got O
			//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ce: Expected O, but got Unknown
			//IL_05db: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e0: Expected I4, but got Unknown
			//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a80: Expected O, but got Unknown
			//IL_0673: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_06b9: Expected O, but got I
			//IL_06c8: Expected O, but got I
			//IL_0283: Expected O, but got I4
			//IL_071d: Expected O, but got I4
			//IL_0550: Unknown result type (might be due to invalid IL or missing references)
			//IL_0555: Expected I4, but got Unknown
			//IL_056b: Expected O, but got I4
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_09d1: Expected O, but got I
			//IL_09e4: Expected I4, but got I8
			//IL_07bf: Expected O, but got I
			//IL_0446: Unknown result type (might be due to invalid IL or missing references)
			//IL_044b: Expected O, but got Unknown
			//IL_08e8: Expected O, but got I
			//IL_036a: Expected O, but got I
			//IL_037c: Expected O, but got I
			//IL_0805: Expected O, but got I
			//IL_0817: Expected O, but got I
			//IL_0491: Expected O, but got I
			//IL_04a3: Expected O, but got I
			//IL_092e: Expected O, but got I
			//IL_0940: Expected O, but got I
			//IL_03bc: Expected O, but got I4
			//IL_0857: Expected O, but got I4
			//IL_04e3: Expected O, but got I4
			//IL_0980: Expected O, but got I4
			//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Expected I4, but got Unknown
			//IL_040e: Expected O, but got I4
			//IL_0652: Expected O, but got I4
			//IL_08aa: Expected O, but got I4
			//IL_0523: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Expected I4, but got Unknown
			//IL_0535: Expected O, but got I4
			Color32[] pixels;
			if ((object)aTex != null)
			{
				int width = aTex.width;
				int height = aTex.height;
				pixels = aTex.GetPixels32();
				if (pixels != null)
				{
					int num = width * aY;
					int num2 = aX + num;
					if (num2 < pixels.Length)
					{
						int num3 = num2 << 2;
						object obj = (long)(IntPtr)pixels + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ X8_v9+20]");
						Color color = (Color32)0;
						Queue<Point> queue = new Queue<Point>();
						if (queue == null)
						{
							goto IL_0a6c;
						}
						int num4 = aY & 0xFFFF;
						int num5 = num4 << 16;
						int num6 = aX & 0xFFFF;
						int num7 = num6 | num5;
						queue.Enqueue((Point)num7);
						if (queue.Count < 1)
						{
							goto IL_0a33;
						}
						int num8 = (int)(aFillColor & 0xFFFFFFFFL);
						Queue<Point> queue2 = queue;
						int num9 = width;
						while (true)
						{
							Point point = queue2.Dequeue();
							if ((long)(IntPtr)point < (long)num9)
							{
								int num10 = (object)point >> 16;
								int num11 = (int)(point & 0xFFFF0000L);
								int num12 = num10 + 1;
								int num13 = num11 - 65536;
								int num14 = num10 - 1;
								int num15 = num12 << 16;
								int num16 = num10 * width;
								int num17 = width * num12;
								int num18 = width * num14;
								Point point2 = point;
								while (true)
								{
									object obj2 = num16 + point2;
									if ((long)(IntPtr)obj2 >= (long)pixels.Length)
									{
										break;
									}
									int num19 = (int)((long)(IntPtr)obj2 << 2);
									object obj3 = (long)(IntPtr)pixels + (long)num19;
									object obj4 = (long)(IntPtr)obj3 + 32L;
									Color color2 = (Color32)obj4;
									if (!(color2 != color))
									{
										Color color3 = (Color32)num8;
										if (!(color2 == color3))
										{
											if ((long)(IntPtr)obj2 >= (long)pixels.Length)
											{
												break;
											}
											obj4 = aFillColor;
											if (num12 < height)
											{
												object obj5 = num17 + point2;
												if ((long)(IntPtr)obj5 >= (long)pixels.Length)
												{
													break;
												}
												int num20 = (int)((long)(IntPtr)obj5 << 2);
												object obj6 = (long)(IntPtr)pixels + (long)num20;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v68+20]");
												Color color4 = (Color32)0;
												if (color4 == color)
												{
													Color color5 = (Color32)num8;
													if (color4 != color5)
													{
														int num21 = point2 & 0xFFFF;
														Point item = (Point)(num21 | num15);
														queue.Enqueue(item);
													}
												}
											}
											if (num10 >= 1)
											{
												object obj7 = num18 + point2;
												if ((long)(IntPtr)obj7 >= (long)pixels.Length)
												{
													break;
												}
												int num22 = (int)((long)(IntPtr)obj7 << 2);
												object obj8 = (long)(IntPtr)pixels + (long)num22;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1345 @ X8_v62+20]");
												Color color6 = (Color32)0;
												if (color6 == color)
												{
													Color color7 = (Color32)num8;
													if (color6 != color7)
													{
														int num23 = point2 & 0xFFFF;
														Point item2 = (Point)(num23 | num13);
														queue.Enqueue(item2);
													}
												}
											}
											int num24 = point2 + 1;
											bool flag = num24 < width;
											point2 = (Point)num24;
											if (flag)
											{
												continue;
											}
										}
									}
									goto IL_0579;
								}
								break;
							}
							goto IL_0579;
							IL_0579:
							int num25 = (object)point << 16;
							if (num25 >= 65536)
							{
								int num26 = (object)point >> 16;
								int num27 = num26 + 1;
								object obj9 = point - 1;
								int num28 = (int)(point & 0xFFFF0000L);
								int num29 = num28 - 65536;
								int num30 = num26 - 1;
								int num31 = num27 << 16;
								int num32 = num26 * width;
								int num33 = width * num27;
								int num34 = width * num30;
								while (true)
								{
									object obj10 = (long)num32 + (long)(IntPtr)obj9;
									if ((long)(IntPtr)obj10 >= (long)pixels.Length)
									{
										break;
									}
									int num35 = (int)((long)(IntPtr)obj10 << 2);
									object obj11 = (long)(IntPtr)pixels + (long)num35;
									object obj12 = (long)(IntPtr)obj11 + 32L;
									Color color8 = (Color32)obj12;
									if (!(color8 != color))
									{
										Color color9 = (Color32)num8;
										if (!(color8 == color9))
										{
											if ((long)(IntPtr)obj10 >= (long)pixels.Length)
											{
												break;
											}
											obj12 = aFillColor;
											if (num27 < height)
											{
												object obj13 = (long)num33 + (long)(IntPtr)obj9;
												if ((long)(IntPtr)obj13 >= (long)pixels.Length)
												{
													break;
												}
												int num36 = (int)((long)(IntPtr)obj13 << 2);
												object obj14 = (long)(IntPtr)pixels + (long)num36;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1396 @ X8_v45+20]");
												Color color10 = (Color32)0;
												if (color10 == color)
												{
													Color color11 = (Color32)num8;
													if (color10 != color11)
													{
														int num37 = (int)((long)(IntPtr)obj9 & 0xFFFFL);
														Point item3 = (Point)(num37 | num31);
														queue.Enqueue(item3);
													}
												}
											}
											if (num26 >= 1)
											{
												object obj15 = (long)num34 + (long)(IntPtr)obj9;
												if ((long)(IntPtr)obj15 >= (long)pixels.Length)
												{
													break;
												}
												int num38 = (int)((long)(IntPtr)obj15 << 2);
												object obj16 = (long)(IntPtr)pixels + (long)num38;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1447 @ X8_v39+20]");
												Color color12 = (Color32)0;
												if (color12 == color)
												{
													Color color13 = (Color32)num8;
													if (color12 != color13)
													{
														int num39 = (int)((long)(IntPtr)obj9 & 0xFFFFL);
														Point item4 = (Point)(num39 | num29);
														queue.Enqueue(item4);
													}
												}
											}
											obj9 = (long)(IntPtr)obj9 - 1L;
											if ((int)((long)(IntPtr)obj9 & 0x80000000L) == 0)
											{
												continue;
											}
										}
									}
									goto IL_0a01;
								}
								break;
							}
							goto IL_0a01;
							IL_0a01:
							bool flag2 = queue.Count > 0;
							queue2 = queue;
							num9 = width;
							if (flag2)
							{
								continue;
							}
							goto IL_0a33;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			goto IL_0a6c;
			IL_0a33:
			aTex.SetPixels32(pixels);
			return;
			IL_0a6c:
			throw new NullReferenceException();
		}
	}
}
