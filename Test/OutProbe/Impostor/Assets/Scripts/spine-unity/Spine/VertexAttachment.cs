using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200003C")]
	public abstract class VertexAttachment : Attachment
	{
		[Token(Token = "0x4000169")]
		private static int nextID = 0;

		[Token(Token = "0x400016A")]
		private static readonly object nextIdLock;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x18")]
		internal readonly int id;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x20")]
		internal int[] bones;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x28")]
		internal float[] vertices;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x30")]
		internal int worldVerticesLength;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x38")]
		internal VertexAttachment deformAttachment;

		[Token(Token = "0x17000093")]
		public int Id
		{
			[Token(Token = "0x60001ED")]
			[Address(RVA = "0x152FCCC", Offset = "0x152FCCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
		}

		[Token(Token = "0x17000094")]
		public int[] Bones
		{
			[Token(Token = "0x60001EE")]
			[Address(RVA = "0x152FCD4", Offset = "0x152FCD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
			[Token(Token = "0x60001EF")]
			[Address(RVA = "0x152FCDC", Offset = "0x152FCDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.bones = value;\n\treturn;\n")]
			set
			{
				Bones = value;
			}
		}

		[Token(Token = "0x17000095")]
		public float[] Vertices
		{
			[Token(Token = "0x60001F0")]
			[Address(RVA = "0x152FCE4", Offset = "0x152FCE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.vertices;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Vertices;
			}
			[Token(Token = "0x60001F1")]
			[Address(RVA = "0x152FCEC", Offset = "0x152FCEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.vertices = value;\n\treturn;\n")]
			set
			{
				Vertices = value;
			}
		}

		[Token(Token = "0x17000096")]
		public int WorldVerticesLength
		{
			[Token(Token = "0x60001F2")]
			[Address(RVA = "0x152FCF4", Offset = "0x152FCF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.worldVerticesLength;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WorldVerticesLength;
			}
			[Token(Token = "0x60001F3")]
			[Address(RVA = "0x152FCFC", Offset = "0x152FCFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.worldVerticesLength = value;\n\treturn;\n")]
			set
			{
				WorldVerticesLength = value;
			}
		}

		[Token(Token = "0x17000097")]
		public VertexAttachment DeformAttachment
		{
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x152FD04", Offset = "0x152FD04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.deformAttachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DeformAttachment;
			}
			[Token(Token = "0x60001F5")]
			[Address(RVA = "0x152FD0C", Offset = "0x152FD0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.deformAttachment = value;\n\treturn;\n")]
			set
			{
				DeformAttachment = value;
			}
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x152EFF0", Offset = "0x152EFF0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = 0x1854CA0(this, name, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\treturn;\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0016;\n\tX0 = *([1946768]);\n\tX0 = 0xAD9498(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 1;\n\t*([1A37B4A]) = X8;\nL_0016:\n\tX0 = X20;\n\tX1 = X19;\n\tX2 = 0;\n\tSpine.Attachment::.ctor(X0, X1, X2);\n\t*([X20+38]) = X20;\n\tX0 = *([1946000]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0022;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([1946000]);\nL_0022:\n\tX8 = *([X0+B8]);\n\tX19 = *([X8+8]);\n\tstack[C] = 0;\n\tX1 = &stack[C];\n\tX0 = X19;\n\tX2 = 0;\n\tSystem.Threading.Monitor::Enter(X0, X1, X2);\n\tX0 = *([1946000]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0030;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([1946000]);\nL_0030:\n\tX8 = *([X0+B8]);\n\tX21 = 0;\n\tX9 = *([X8]);\n\tX10 = X9 + 1;\n\tTEMP = X9 & 0xFFFF;\n\tX9 = TEMP << 0xB;\n\t*([X8]) = X10;\n\t*([X20+18]) = X9;\nL_0038:\n\tX8 = stack[C];\n\tif (TEMP) goto L_003E;\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\nL_003E:\n\tTEMP = X21 == 0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0048;\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX30 = stack[0];\n\t// 70 ShiftStack 48\n\treturn;\nL_0048:\n\tX0 = X21;\n\tX0 = 0xAD96B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_005B;\n\tX0 = X20;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0038;\nL_005B:\n\tX21 = 0;\n\tgoto L_005E;\n\tX20 = X0;\nL_005E:\n\tX8 = stack[C];\n\tif (TEMP) goto L_0064;\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\nL_0064:\n\tTEMP = X21 == 0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0069;\n\tX0 = X20;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0069:\n\tX0 = X21;\n\tX0 = 0xAD96B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VertexAttachment(string name)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1854CA0 (inside System.__Il2CppComDelegate::Finalize +0x8C)");
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x152FD14", Offset = "0x152FD14", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.VertexAttachment::ComputeWorldVertices(this, slot, 0, this.worldVerticesLength, worldVertices, 0, 2);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ComputeWorldVertices(Slot slot, float[] worldVertices)
		{
			ComputeWorldVertices(slot, 0, WorldVerticesLength, worldVertices, 0);
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x152FD2C", Offset = "0x152FD2C", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = slot.bone;\n\tv376 = this.bones;\n\tv372 = this.vertices;\n\tv364 = slot.deform;\n\tv411 = count >> 1;\n\tv412 = v411 * stride;\n\tv359 = v75 + v412;\n\tv413 = this.bones == 0;\n\tif (v413) goto L_0051;\n\tv354 = v10.skeleton;\n\tv209 = v64 < 1;\n\tif (v209) goto L_FFFFFFFF;\nL_0030:\n\tv513 = v513 + 2;\n\tv541 = v524 + v376[v524 @ X11_v18 (System.Int32)];\n\tv716 = v541 + 1;\n\tv189 = v376[v524 @ X11_v18 (System.Int32)] + v189;\n\tv206 = v513 < v64;\n\tif (v206) goto L_0030;\n\tv776 = v354 == 0;\n\tv392 = ~v776;\n\tif (v392) goto L_00BE;\n\tgoto L_0282;\nL_0051:\n\tv510 = v364.Count < 1;\n\tif (v510) goto L_005F;\n\tv372 = v364.Items;\nL_005F:\n\tv207 = v359 <= v75;\n\tif (v207) goto L_0280;\nL_0074:\n\tv383 = v64 + 1;\n\tv713 = v75 + 1;\n\tv863 = v10.a * v372[v64 @ X2_v4 (System.Int32)];\n\tv559 = v10.b * v372[v383 @ X11_v6 (System.Int32)];\n\tv864 = v863 + v559;\n\tv560 = v10.worldX + v864;\n\tworldVertices[v75 @ X5_v6 (System.Int32)] = v560;\n\tv730 = v10.c * v372[v64 @ X2_v4 (System.Int32)];\n\tv938 = v10.d * v372[v383 @ X11_v6 (System.Int32)];\n\tv75 = v75 + stride;\n\tv939 = v730 + v938;\n\tv729 = v10.worldY + v939;\n\tv64 = v383 + 1;\n\tworldVertices[v713 @ X13_v7 (System.Int32)] = v729;\n\tv738 = v75 < v359;\n\tif (v738) goto L_0074;\n\tgoto L_0280;\nL_00BE:\n\tv356 = v354.bones;\n\tv357 = v356.Items;\n\tv775 = v364.Count == 0;\n\tif (v775) goto L_01BB;\n\tv739 = v359 <= v75;\n\tif (v739) goto L_0280;\n\tv366 = v364.Items;\n\tv182 = v189 << 1;\n\tv792 = v189 << 1;\n\tv192 = v189 + v792;\nL_00E6:\n\tv818 = v716 + 1;\n\tv386 = v376[v716 @ X11_v8 (System.Int32)] + v818;\n\tv829 = v818 >= v386;\n\tif (v829) goto L_FFFFFFFF;\n\tv846 = v376[v716 @ X11_v8 (System.Int32)] << 1;\n\tv847 = v376[v716 @ X11_v8 (System.Int32)] + v846;\n\tv848 = v376[v716 @ X11_v8 (System.Int32)] << 1;\n\tv46 = v182 + v848;\n\tv65 = v192 + v847;\nL_012F:\n\tv15 = v192 + 1;\n\tv39 = v182 + 1;\n\tv21 = v15 + 1;\n\tv32 = v357[v376[v157 @ X17_v16 (System.Int32)]];\n\tv993 = v372[v192 @ X15_v15 (System.Int32)] + v366[v182 @ X16_v13 (System.Int32)];\n\tv996 = v993 * v32.a;\n\tv997 = v372[v15 @ X20_v8 (System.Int32)] + v366[v39 @ X3_v14 (System.Int32)];\n\tv998 = v192 + 2;\n\tv999 = v993 * v32.c;\n\tv1000 = v997 * v32.b;\n\tv872 = v996 + v1000;\n\tv870 = v997 * v32.d;\n\tv1002 = v999 + v870;\n\tv1003 = v32.worldX + v872;\n\tv1004 = v32.worldY + v1002;\n\tv874 = v372[v998 @ X16_v16 (System.Int32)] * v1003;\n\tv875 = v372[v998 @ X16_v16 (System.Int32)] * v1004;\n\tv868 = v55 - 1;\n\tv192 = v21 + 1;\n\tv142 = v142 + v874;\n\tv150 = v150 + v875;\n\tv182 = v39 + 1;\n\tv882 = v55 != 1;\n\tif (v882) goto L_012F;\n\tgoto L_019A;\nL_019A:\n\tv555 = v75 + 1;\n\tworldVertices[v75 @ X5_v6 (System.Int32)] = v142;\n\tv75 = v75 + stride;\n\tworldVertices[v555 @ X0_v15 (System.Int32)] = v150;\n\tv740 = v75 < v359;\n\tif (v740) goto L_00E6;\n\tgoto L_0280;\nL_01BB:\n\tv741 = v359 <= v75;\n\tif (v741) goto L_0280;\n\tv794 = v189 << 1;\n\tv202 = v189 + v794;\nL_01CD:\n\tv833 = v716 + 1;\n\tv387 = v376[v716 @ X11_v8 (System.Int32)] + v833;\n\tv844 = v833 >= v387;\n\tif (v844) goto L_FFFFFFFF;\n\tv853 = v376[v716 @ X11_v8 (System.Int32)] << 1;\n\tv854 = v376[v716 @ X11_v8 (System.Int32)] + v853;\n\tv158 = v202 + v854;\nL_0207:\n\tv67 = v202 + 1;\n\tv58 = v67 + 1;\n\tv49 = v357[v376[v191 @ X15_v11 (System.Int32)]];\n\tv969 = v372[v202 @ X14_v11 (System.Int32)] * v49.a;\n\tv970 = v372[v202 @ X14_v11 (System.Int32)] * v49.c;\n\tv971 = v202 + 2;\n\tv972 = v372[v67 @ X2_v9 (System.Int32)] * v49.b;\n\tv974 = v969 + v972;\n\tv907 = v372[v67 @ X2_v9 (System.Int32)] * v49.d;\n\tv976 = v970 + v907;\n\tv977 = v49.worldX + v974;\n\tv908 = v49.worldY + v976;\n\tv911 = v372[v971 @ X14_v13 (System.Int32)] * v977;\n\tv910 = v372[v971 @ X14_v13 (System.Int32)] * v908;\n\tv915 = v181 - 1;\n\tv143 = v143 + v911;\n\tv151 = v151 + v910;\n\tv202 = v58 + 1;\n\tv918 = v181 != 1;\n\tif (v918) goto L_0207;\n\tgoto L_025D;\nL_025D:\n\tv592 = v75 + 1;\n\tworldVertices[v75 @ X5_v6 (System.Int32)] = v143;\n\tv75 = v75 + stride;\n\tworldVertices[v592 @ X16_v8 (System.Int32)] = v151;\n\tv737 = v75 < v359;\n\tif (v737) goto L_01CD;\nL_0280:\n\treturn;\n\tv53 = new System.IndexOutOfRangeException();\nL_0282:\n\tthrow System.NullReferenceException;\n// 508 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ComputeWorldVertices(Slot slot, int start, int count, float[] worldVertices, int offset, int stride = 2)
		{
			Bone bone = slot.Bone;
			int[] array = Bones;
			float[] items = Vertices;
			ExposedList<float> deform = slot.Deform;
			int num = count >> 1;
			int num2 = num * stride;
			int num4 = default(int);
			int num3 = num4 + num2;
			int num5 = default(int);
			if (Bones != null)
			{
				Skeleton skeleton = bone.Skeleton;
				int num7;
				int num10;
				if (num5 >= 1)
				{
					int num6 = 0;
					num7 = 0;
					int num8 = 0;
					bool flag;
					do
					{
						num6 += 2;
						int num9 = num8 + array[num8];
						num10 = num9 + 1;
						num7 = array[num8] + num7;
						flag = num6 < num5;
						num8 = num10;
					}
					while (flag);
					if (skeleton == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					num7 = 0;
					num10 = 0;
				}
				ExposedList<Bone> exposedList = skeleton.Bones;
				Bone[] items2 = exposedList.Items;
				if (deform.Count != 0)
				{
					if (num3 <= num4)
					{
						return;
					}
					float[] items3 = deform.Items;
					int num11 = num7 << 1;
					int num12 = num7 << 1;
					int num13 = num7 + num12;
					int num27 = default(int);
					do
					{
						int num14 = num10 + 1;
						int num15 = array[num10] + num14;
						float num22;
						float num23;
						if (num14 < num15)
						{
							int num16 = array[num10] << 1;
							int num17 = array[num10] + num16;
							int num18 = array[num10] << 1;
							int num19 = num11 + num18;
							int num20 = num13 + num17;
							int num21 = array[num10];
							num22 = 0f;
							num23 = 0f;
							bool flag2;
							do
							{
								int num24 = num13 + 1;
								int num25 = num11 + 1;
								int num26 = num24 + 1;
								Bone bone2 = items2[array[num27]];
								float num28 = items[num13] + items3[num11];
								float num29 = num28 * bone2.A;
								float num30 = items[num24] + items3[num25];
								int num31 = num13 + 2;
								float num32 = num28 * bone2.C;
								float num33 = num30 * bone2.B;
								float num34 = num29 + num33;
								float num35 = num30 * bone2.D;
								float num36 = num32 + num35;
								float num37 = bone2.WorldX + num34;
								float num38 = bone2.WorldY + num36;
								float num39 = items[num31] * num37;
								float num40 = items[num31] * num38;
								int num41 = num21 - 1;
								num13 = num26 + 1;
								num22 += num39;
								num23 += num40;
								num11 = num25 + 1;
								flag2 = num21 != 1;
								num21 = num41;
							}
							while (flag2);
							num11 = num19;
							num13 = num20;
							num10 = num15;
						}
						else
						{
							num22 = 0f;
							num23 = 0f;
							num10 = num14;
						}
						int num42 = num4 + 1;
						worldVertices[num4] = num22;
						num4 += stride;
						worldVertices[num42] = num23;
					}
					while (num4 < num3);
				}
				else
				{
					if (num3 <= num4)
					{
						return;
					}
					int num43 = num7 << 1;
					int num44 = num7 + num43;
					int num55 = default(int);
					do
					{
						int num45 = num10 + 1;
						int num46 = array[num10] + num45;
						float num50;
						float num51;
						if (num45 < num46)
						{
							int num47 = array[num10] << 1;
							int num48 = array[num10] + num47;
							int num49 = num44 + num48;
							num50 = 0f;
							num51 = 0f;
							int num52 = array[num10];
							bool flag3;
							do
							{
								int num53 = num44 + 1;
								int num54 = num53 + 1;
								Bone bone3 = items2[array[num55]];
								float num56 = items[num44] * bone3.A;
								float num57 = items[num44] * bone3.C;
								int num58 = num44 + 2;
								float num59 = items[num53] * bone3.B;
								float num60 = num56 + num59;
								float num61 = items[num53] * bone3.D;
								float num62 = num57 + num61;
								float num63 = bone3.WorldX + num60;
								float num64 = bone3.WorldY + num62;
								float num65 = items[num58] * num63;
								float num66 = items[num58] * num64;
								int num67 = num52 - 1;
								num50 += num65;
								num51 += num66;
								num44 = num54 + 1;
								flag3 = num52 != 1;
								num52 = num67;
							}
							while (flag3);
							num44 = num49;
							num10 = num46;
						}
						else
						{
							num50 = 0f;
							num51 = 0f;
							num10 = num45;
						}
						int num68 = num4 + 1;
						worldVertices[num4] = num50;
						num4 += stride;
						worldVertices[num68] = num51;
					}
					while (num4 < num3);
				}
				return;
			}
			if (deform.Count >= 1)
			{
				items = deform.Items;
			}
			if (num3 > num4)
			{
				do
				{
					int num69 = num5 + 1;
					int num70 = num4 + 1;
					float num71 = bone.A * items[num5];
					float num72 = bone.B * items[num69];
					float num73 = num71 + num72;
					float num74 = bone.WorldX + num73;
					worldVertices[num4] = num74;
					float num75 = bone.C * items[num5];
					float num76 = bone.D * items[num69];
					num4 += stride;
					float num77 = num75 + num76;
					float num78 = bone.WorldY + num77;
					num5 = num69 + 1;
					worldVertices[num70] = num78;
				}
				while (num4 < num3);
			}
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x152F1F4", Offset = "0x152F1F4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Int32[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, attachment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = System.Single[];\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, attachment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B4B]) = v37;\nL_0015:\n\tv38 = this.bones;\n\tv39 = this.bones == 0;\n\tif (v39) goto L_002C;\n\t// 28 NewArr v46 @ X0_v10 (System.Int32[]), typeof(System.Int32[]), v38.Length\n\tattachment.bones = v46;\n\tv64 = this.bones;\n\tSystem.Array::Copy(this.bones, 0, v46, 0, *([v64 @ X0_v11 (System.Array)+18]));\n\tgoto L_002D;\nL_002C:\n\tattachment.bones = 0;\nL_002D:\n\tv70 = this.vertices;\n\tv81 = this.vertices == 0;\n\tif (v81) goto L_0040;\n\t// 52 NewArr v84 @ X0_v5 (System.Single[]), typeof(System.Single[]), v70.Length\n\tattachment.vertices = v84;\n\tv65 = this.vertices;\n\tSystem.Array::Copy(this.vertices, 0, v84, 0, *([v65 @ X0_v6 (System.Array)+18]));\n\tgoto L_0042;\nL_0040:\n\tattachment.vertices = 0;\nL_0042:\n\tattachment.worldVerticesLength = this.worldVerticesLength;\n\tattachment.deformAttachment = this.deformAttachment;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void CopyTo(VertexAttachment attachment)
		{
			int[] array = Bones;
			if (Bones != null)
			{
				int[] destinationArray = (attachment.Bones = new int[array.Length]);
				Array array3 = Bones;
				int[] sourceArray = Bones;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v11 (System.Array)+18]");
				Array.Copy(sourceArray, 0, destinationArray, 0, 0);
			}
			else
			{
				attachment.Bones = null;
			}
			float[] array4 = Vertices;
			if (Vertices != null)
			{
				float[] destinationArray2 = (attachment.Vertices = new float[array4.Length]);
				Array array6 = Vertices;
				float[] sourceArray2 = Vertices;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X0_v6 (System.Array)+18]");
				Array.Copy(sourceArray2, 0, destinationArray2, 0, 0);
			}
			else
			{
				attachment.Vertices = null;
			}
			attachment.WorldVerticesLength = WorldVerticesLength;
			attachment.DeformAttachment = DeformAttachment;
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x1530164", Offset = "0x1530164", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = System.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Spine.VertexAttachment;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A37B4C]) = v39;\nL_0019:\n\tv41.nextID = 0;\n\tv43 = new System.Object();\n\tSystem.Object::.ctor(v43);\n\tv49.nextIdLock = v43;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static VertexAttachment()
		{
			object obj = new object();
			nextIdLock = obj;
		}
	}
}
