using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000018")]
	public class DrawOrderTimeline : Timeline
	{
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x10")]
		internal float[] frames;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x18")]
		private int[][] drawOrders;

		[Token(Token = "0x1700002A")]
		public int PropertyId
		{
			[Token(Token = "0x600007F")]
			[Address(RVA = "0x1525B0C", Offset = "0x1525B0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x8000000;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return 134217728;
			}
		}

		[Token(Token = "0x1700002B")]
		public int FrameCount
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x1525B14", Offset = "0x1525B14", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\treturn v2.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float[] array = Frames;
				return array.Length;
			}
		}

		[Token(Token = "0x1700002C")]
		public float[] Frames
		{
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x1525B30", Offset = "0x1525B30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000082")]
			[Address(RVA = "0x1525B38", Offset = "0x1525B38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x1700002D")]
		public int[][] DrawOrders
		{
			[Token(Token = "0x6000083")]
			[Address(RVA = "0x1525B40", Offset = "0x1525B40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.drawOrders;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DrawOrders;
			}
			[Token(Token = "0x6000084")]
			[Address(RVA = "0x1525B48", Offset = "0x1525B48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.drawOrders = value;\n\treturn;\n")]
			set
			{
				DrawOrders = value;
			}
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x1525A80", Offset = "0x1525A80", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = System.Int32[][];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.Single[];\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, frameCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37AE4]) = v45;\nL_001D:\n\tSystem.Object::.ctor(this);\n\t// 32 NewArr v52 @ X0_v4 (System.Single[]), typeof(System.Single[]), frameCount @ X1 (System.Int32)\n\tthis.frames = v52;\n\t// 36 NewArr v55 @ X0_v6 (System.Int32[][]), typeof(System.Int32[][]), frameCount @ X1 (System.Int32)\n\tthis.drawOrders = v55;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawOrderTimeline(int frameCount)
		{
			float[] array = new float[frameCount];
			Frames = array;
			int[][] array2 = new int[frameCount][];
			DrawOrders = array2;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x1525B50", Offset = "0x1525B50", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv2[frameIndex @ X1 (System.Int32)] = time;\n\tv45 = this.drawOrders;\n\tv45[frameIndex @ X1 (System.Int32)] = drawOrder;\n\treturn;\n\tv46 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, int[] drawOrder)
		{
			float[] array = Frames;
			array[frameIndex] = time;
			int[][] array2 = DrawOrders;
			array2[frameIndex] = drawOrder;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1525BA0", Offset = "0x1525BA0", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = skeleton.slots;\n\tv19 = skeleton.drawOrder;\n\tv30 = direction != 1;\n\tif (v30) goto L_001D;\n\tv167 = blend == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_00CA;\n\tgoto L_00DE;\nL_001D:\n\tv72 = this.frames;\n\tv349 = v72[0] <= time;\n\tif (v349) goto L_003E;\n\tv373 = blend < 1;\n\tv272 = ~v373;\n\tv267 = blend - 1;\n\tv257 = v267 == 0;\n\tv374 = ~v272;\n\tv233 = v374 | v257;\n\tif (v233) goto L_00DE;\n\tgoto L_00CA;\nL_003E:\n\tv69 = v72.Length - 1;\n\tv378 = v72[v69 @ X8_v8 (System.Int32)] < time;\n\tv140 = ~v378;\n\tv133 = v72[v69 @ X8_v8 (System.Int32)] - time;\n\tv119 = v133 == 0;\n\tv379 = ~v140;\n\tv82 = v379 | v119;\n\tif (v82) goto L_0051;\n\tv381 = Spine.Animation::BinarySearch(v72, time);\n\tv69 = v381 - 1;\nL_0051:\n\tv48 = this.drawOrders;\n\tv40 = v48[v69 @ X8_v8 (System.Int32)];\n\tv294 = v48[v69 @ X8_v8 (System.Int32)] == 0;\n\tif (v294) goto L_00DE;\n\tv234 = v40.Length < 1;\n\tif (v234) goto L_00CA;\n\tv142 = v19.Items;\n\tv144 = v18.Items;\nL_0090:\n\tv392 = v144[v40[v36 @ X25_v8 (System.Int32)]] == 0;\n\tif (v392) goto L_00AA;\n\t// 149 IsInst v183 @ X0_v16, typeof(Spine.Slot), v144[v40[v36 @ X25_v8 (System.Int32)]]\n\tv198 = v183 == 0;\n\tif (v198) goto L_00E1;\nL_00AA:\n\tv259 = v40.Length == v34;\n\tv142[v36 @ X25_v8 (System.Int32)] = v144[v40[v36 @ X25_v8 (System.Int32)]];\n\tif (v259) goto L_00CA;\n\tv398 = v34 < v40.Length;\n\tv370 = ~v398;\n\tv352 = v34 + 1;\n\tv355 = ~v370;\n\tif (v355) goto L_0090;\n\tthrow System.IndexOutOfRangeException;\nL_00CA:\n\treturn;\nL_00DE:\n\tSystem.Array::Copy(v18.Items, 0, v19.Items, 0, v18.Count);\n\treturn;\n\tv154 = new System.NullReferenceException();\nL_00E1:\n\tv199 = new System.ArrayTypeMismatchException();\n\tthrow v199;\n\treturn;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			ExposedList<Slot> slots = skeleton.Slots;
			ExposedList<Slot> drawOrder = skeleton.DrawOrder;
			if (direction == MixDirection.Out)
			{
				if (blend != MixBlend.Setup)
				{
					return;
				}
			}
			else
			{
				float[] array = Frames;
				if (array[0] > time)
				{
					bool flag = blend < MixBlend.First;
					bool flag2 = !flag;
					int num = (int)(blend - 1);
					bool flag3 = num == 0;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						return;
					}
				}
				else
				{
					int num2 = array.Length - 1;
					bool flag5 = array[num2] < time;
					bool flag6 = !flag5;
					float num3 = array[num2] - time;
					bool flag7 = num3 == 0f;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						int num4 = Animation.BinarySearch(array, time);
						num2 = num4 - 1;
					}
					int[][] array2 = DrawOrders;
					int[] array3 = array2[num2];
					if (array2[num2] != null)
					{
						if (array3.Length < 1)
						{
							return;
						}
						Slot[] items = drawOrder.Items;
						Slot[] items2 = slots.Items;
						int num5 = 1;
						int num6 = 0;
						while (true)
						{
							if (items2[array3[num6]] != null)
							{
								object obj = items2[array3[num6]] as Slot;
								if (obj == null)
								{
									break;
								}
							}
							bool flag9 = array3.Length == num5;
							items[num6] = items2[array3[num6]];
							if (!flag9)
							{
								bool flag10 = num5 < array3.Length;
								bool flag11 = !flag10;
								int num7 = num5 + 1;
								bool flag12 = !flag11;
								num5 = num7;
								num6 = num7;
								if (!flag12)
								{
									throw new IndexOutOfRangeException();
								}
								continue;
							}
							return;
						}
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
			}
			Array.Copy(slots.Items, 0, drawOrder.Items, 0, slots.Count);
		}
	}
}
