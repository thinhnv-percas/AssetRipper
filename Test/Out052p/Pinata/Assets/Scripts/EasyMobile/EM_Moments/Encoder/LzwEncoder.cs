using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EM_Moments.Encoder
{
	[Token(Token = "0x2000007")]
	public class LzwEncoder
	{
		[Token(Token = "0x400001F")]
		private static readonly int EOF = -1;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x10")]
		private byte[] pixAry;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x18")]
		private int initCodeSize;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x1C")]
		private int curPixel;

		[Token(Token = "0x4000023")]
		private static readonly int BITS = 12;

		[Token(Token = "0x4000024")]
		private static readonly int HSIZE = 5003;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x20")]
		private int n_bits;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x24")]
		private int maxbits;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x28")]
		private int maxcode;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x2C")]
		private int maxmaxcode;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x30")]
		private int[] htab;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x38")]
		private int[] codetab;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x40")]
		private int hsize;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x44")]
		private int free_ent;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x48")]
		private bool clear_flg;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x4C")]
		private int g_init_bits;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x50")]
		private int ClearCode;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x54")]
		private int EOFCode;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x58")]
		private int cur_accum;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x5C")]
		private int cur_bits;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x60")]
		private int[] masks;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x68")]
		private int a_count;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x70")]
		private byte[] accum;

		[Token(Token = "0x6000021")]
		[Address(RVA = "0xA40550", Offset = "0xA40550", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EB4AD8]);\n\tv29 = *([v28 @ X8_v28]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, width, height, pixels, color_depth, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021E75]) = v46;\nL_001E:\n\tgoto L_0029;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EM_Moments.Encoder.LzwEncoder>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0029;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v49, width, height, pixels, color_depth, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = EM_Moments.Encoder.LzwEncoder;\nL_0029:\n\tthis.maxbits = v60.BITS;\n\tv66 = v64.BITS & 0x1F;\n\tv67 = 1 << v66;\n\tthis.maxmaxcode = v67;\n\t// 51 NewArr v72 @ X0_v5 (System.Int32[]), typeof(System.Int32[]), v68.HSIZE (System.Int32)\n\tthis.htab = v72;\n\t// 57 NewArr v78 @ X0_v7 (System.Int32[]), typeof(System.Int32[]), v76.HSIZE (System.Int32)\n\tthis.codetab = v78;\n\tthis.hsize = v81.HSIZE;\n\t// 65 NewArr v84 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), 17\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v84, Il2CppFieldInfo);\n\tthis.masks = v84;\n\t// 77 NewArr v94 @ X0_v11 (System.Byte[]), typeof(System.Byte[]), 256\n\tthis.accum = v94;\n\tSystem.Object::.ctor(this);\n\tthis.pixAry = pixels;\n\tgoto L_0062;\n\tv103 = *([v99 @ X0_v13+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0062;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v99, v96, v87, pixels, color_depth, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0062:\n\tv113 = System.Math::Max(2, color_depth);\n\tthis.initCodeSize = v113;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LzwEncoder(int width, int height, byte[] pixels, int color_depth)
		{
			maxbits = BITS;
			int num = BITS & 0x1F;
			int num2 = 1 << num;
			maxmaxcode = num2;
			int[] array = new int[HSIZE];
			htab = array;
			int[] array2 = new int[HSIZE];
			codetab = array2;
			hsize = HSIZE;
			masks = new int[17]
			{
				0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
				1023, 2047, 4095, 8191, 16383, 32767, 65535
			};
			byte[] array3 = new byte[256];
			accum = array3;
			pixAry = pixels;
			int num3 = Math.Max(2, color_depth);
			initCodeSize = num3;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0xA4078C", Offset = "0xA4078C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.a_count;\n\tv8 = this.accum;\n\tv9 = this.a_count + 1;\n\tthis.a_count = v9;\n\tv12 = this.a_count < v8.Length;\n\tv13 = ~v12;\n\tif (v13) goto L_0030;\n\tv8[v6 @ X8_v1 (System.Int32)] = c;\n\tv50 = this.a_count < 0xFE;\n\tif (v50) goto L_002D;\n\tEM_Moments.Encoder.LzwEncoder::Flush(this, outs);\n\treturn;\nL_002D:\n\treturn;\n\tv22 = new System.NullReferenceException();\nL_0030:\n\tv69 = new System.IndexOutOfRangeException();\n\tthrow v69;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Add(byte c, Stream outs)
		{
			int num = a_count;
			byte[] array = accum;
			int num2 = a_count + 1;
			a_count = num2;
			if (a_count < array.Length)
			{
				array[num] = c;
				if (a_count >= 254)
				{
					Flush(outs);
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xA408C0", Offset = "0xA408C0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEM_Moments.Encoder.LzwEncoder::ResetCodeTable(this, this.hsize);\n\tthis.clear_flg = 1;\n\tv20 = this.ClearCode + 2;\n\tthis.free_ent = v20;\n\tEM_Moments.Encoder.LzwEncoder::Output(this, this.ClearCode, outs);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearTable(Stream outs)
		{
			ResetCodeTable(hsize);
			clear_flg = true;
			int num = ClearCode + 2;
			free_ent = num;
			Output(ClearCode, outs);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0xA40908", Offset = "0xA40908", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = hsize < 1;\n\tif (v17) goto L_0034;\nL_0013:\n\tv74 = this.htab;\n\tv110 = v64 < v74.Length;\n\tv111 = ~v110;\n\tif (v111) goto L_0037;\n\tv38 = v64 + 1;\n\tv74[v64 @ X8_v3 (System.Int32)] = 0xFFFFFFFF;\n\tv41 = v38 < hsize;\n\tif (v41) goto L_0013;\nL_0034:\n\treturn;\n\tv120 = new System.NullReferenceException();\nL_0037:\n\tv137 = new System.IndexOutOfRangeException();\n\tthrow v137;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetCodeTable(int hsize)
		{
			if (hsize < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				int[] array = htab;
				if (num >= array.Length)
				{
					break;
				}
				int num2 = num + 1;
				array[num] = -1;
				bool flag = num2 < hsize;
				num = num2;
				if (!flag)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xA40AE4", Offset = "0xA40AE4", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1EA5A88]);\n\tv37 = *([v36 @ X8_v31]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, init_bits, outs, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021E76]) = v54;\nL_001C:\n\tv55 = init_bits & 0x1F;\n\tv57 = init_bits + 0x1F;\n\tv58 = 1 << v55;\n\tv59 = v57 & 0x1F;\n\tv60 = 1 << v59;\n\tv61 = v58 - 1;\n\tthis.maxcode = v61;\n\tthis.g_init_bits = init_bits;\n\tthis.ClearCode = v60;\n\tv62 = v60 + 1;\n\tv63 = v60 + 2;\n\tthis.clear_flg = 0;\n\tthis.n_bits = init_bits;\n\tthis.EOFCode = v62;\n\tthis.free_ent = v63;\n\tthis.a_count = 0;\n\tv65 = EM_Moments.Encoder.LzwEncoder::NextPixel(this);\n\tv78 = this.hsize >= 0x10000;\n\tif (v78) goto L_0050;\nL_003F:\n\tv107 = v107 << 1;\n\tv101 = v127 + 1;\n\tv84 = v107 < 0x10000;\n\tif (v84) goto L_003F;\nL_0050:\n\tv106 = 8 - v101;\n\tEM_Moments.Encoder.LzwEncoder::ResetCodeTable(this, this.hsize);\n\tEM_Moments.Encoder.LzwEncoder::Output(this, this.ClearCode, outs);\n\tv136 = v106 & 0x1F;\n\tgoto L_011F;\nL_005A:\n\tv257 = this.htab;\n\tv274 = v228 << v136;\n\tv161 = v274 ^ v223;\n\tv275 = v161 < v257.Length;\n\tv276 = ~v275;\n\tif (v276) goto L_014F;\n\tv380 = this.maxbits & 0x1F;\n\tv156 = v228 << v380;\n\tv142 = v156 + v223;\n\tv178 = v257[v161 @ X26_v6 (System.Int32)] != v142;\n\tif (v178) goto L_008F;\n\tv372 = this.codetab;\n\tv442 = v161 < v372.Length;\n\tv210 = ~v442;\n\tif (v210) goto L_014F;\n\tgoto L_011F;\nL_008F:\n\tv439 = v257[v161 @ X26_v6 (System.Int32)] & 0x80000000;\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_00D4;\n\tv163 = this.hsize - v161;\n\tv448 = v161 == 0;\n\tv453 = ~v448;\n\tv454 = ~v453;\n\tif (v454) goto L_FFFFFFFF;\n\tgoto L_00A4;\nL_00A4:\n\tv382 = v474 - v163;\n\tv138 = v382 < 0;\n\tif (v138) goto L_FFFFFFFF;\n\tgoto L_00B5;\nL_00B5:\n\tv161 = v384 + v382;\n\tv500 = v161 < v257.Length;\n\tv404 = ~v500;\n\tif (v404) goto L_014F;\n\tv344 = v257[v161 @ X26_v6 (System.Int32)] == v142;\n\tif (v344) goto L_010D;\n\tv504 = v257[v161 @ X26_v6 (System.Int32)] & 0x80000000;\n\tv466 = v504 == 0;\n\tif (v466) goto L_00A4;\nL_00D4:\n\tEM_Moments.Encoder.LzwEncoder::Output(this, v223, outs);\n\tv179 = this.free_ent >= this.maxmaxcode;\n\tif (v179) goto L_010A;\n\tv311 = this.codetab;\n\tv302 = this.free_ent + 1;\n\tthis.free_ent = v302;\n\tv497 = v161 < v311.Length;\n\tv361 = ~v497;\n\tif (v361) goto L_014F;\n\tv311[v161 @ X26_v6 (System.Int32)] = this.free_ent;\n\tv374 = this.htab;\n\tv503 = v161 < v374.Length;\n\tv403 = ~v503;\n\tif (v403) goto L_014F;\n\tv374[v161 @ X26_v6 (System.Int32)] = v142;\n\tgoto L_FFFFFFFF;\nL_010A:\n\tEM_Moments.Encoder.LzwEncoder::ClearTable(this, outs);\n\tgoto L_011F;\nL_010D:\n\tv375 = this.codetab;\n\tv505 = v161 < v375.Length;\n\tv209 = ~v505;\n\tif (v209) goto L_014F;\nL_011F:\n\tv228 = EM_Moments.Encoder.LzwEncoder::NextPixel(this);\n\tgoto L_0138;\n\tv233 = *([v229 @ X8_v10 (Il2CppClass<EM_Moments.Encoder.LzwEncoder>)+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tgoto L_0138;\n\tv253 = v229;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v253, v170, v166, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv240 = EM_Moments.Encoder.LzwEncoder;\nL_0138:\n\tv252 = v228 != v241.EOF;\n\tif (v252) goto L_005A;\n\tEM_Moments.Encoder.LzwEncoder::Output(this, v223, outs);\n\tEM_Moments.Encoder.LzwEncoder::Output(this, this.EOFCode, outs);\n\treturn;\nL_014F:\n\tv407 = new System.IndexOutOfRangeException();\n\tthrow v407;\n\tthrow System.NullReferenceException;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Compress(int init_bits, Stream outs)
		{
			//IL_0185: Expected I4, but got I8
			//IL_026f: Expected I4, but got I8
			int num = init_bits & 0x1F;
			int num2 = init_bits + 31;
			int num3 = 1 << num;
			int num4 = num2 & 0x1F;
			int num5 = 1 << num4;
			int num6 = num3 - 1;
			maxcode = num6;
			g_init_bits = init_bits;
			ClearCode = num5;
			int eOFCode = num5 + 1;
			int num7 = num5 + 2;
			clear_flg = false;
			n_bits = init_bits;
			EOFCode = eOFCode;
			free_ent = num7;
			a_count = 0;
			int num8 = NextPixel();
			bool flag = hsize >= 65536;
			int num9 = 0;
			if (!flag)
			{
				int num10 = hsize;
				int num11 = 0;
				int num12 = default(int);
				num10 = num12;
				int num13 = default(int);
				num11 = num13;
				bool flag2;
				do
				{
					num10 <<= 1;
					num9 = num11 + 1;
					flag2 = num10 < 65536;
					num11 = num9;
				}
				while (flag2);
			}
			int num14 = 8 - num9;
			ResetCodeTable(hsize);
			Output(ClearCode, outs);
			int num15 = num14 & 0x1F;
			int num16 = num8;
			while (true)
			{
				int num17 = NextPixel();
				int num19;
				int num22;
				if (num17 != EOF)
				{
					int[] array = htab;
					int num18 = num17 << num15;
					num19 = num18 ^ num16;
					if (num19 >= array.Length)
					{
						break;
					}
					int num20 = maxbits & 0x1F;
					int num21 = num17 << num20;
					num22 = num21 + num16;
					if (array[num19] == num22)
					{
						int[] array2 = codetab;
						if (num19 >= array2.Length)
						{
							break;
						}
						num16 = array2[num19];
						continue;
					}
					if ((int)(array[num19] & 0x80000000L) == 0)
					{
						int num23 = hsize - num19;
						int num24;
						if (num19 != 0)
						{
							num24 = num19;
						}
						else
						{
							num24 = num19;
							num23 = 1;
						}
						while (true)
						{
							int num25 = num24 - num23;
							int num26 = ((num25 < 0) ? hsize : 0);
							num19 = num26 + num25;
							if (num19 >= array.Length)
							{
								break;
							}
							if (array[num19] != num22)
							{
								int num27 = (int)(array[num19] & 0x80000000L);
								bool flag3 = num27 == 0;
								num24 = num19;
								if (flag3)
								{
									continue;
								}
								goto IL_0294;
							}
							goto IL_0396;
						}
						break;
					}
					goto IL_0294;
				}
				Output(num16, outs);
				Output(EOFCode, outs);
				return;
				IL_0396:
				int[] array3 = codetab;
				if (num19 >= array3.Length)
				{
					break;
				}
				num16 = array3[num19];
				continue;
				IL_0294:
				Output(num16, outs);
				if (free_ent < maxmaxcode)
				{
					int[] array4 = codetab;
					int num28 = free_ent + 1;
					free_ent = num28;
					if (num19 >= array4.Length)
					{
						break;
					}
					array4[num19] = free_ent;
					int[] array5 = htab;
					if (num19 >= array5.Length)
					{
						break;
					}
					array5[num19] = num22;
				}
				else
				{
					ClearTable(outs);
				}
				num16 = num17;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xA406B8", Offset = "0xA406B8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBAAE8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, os, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E77]) = v41;\nL_001C:\n\tgoto L_0024;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, os, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = System.Convert::ToByte(this.initCodeSize);\n\tv65 = System.IO.Stream::WriteByte(os, v58);\n\tthis.curPixel = 0;\n\tv69 = this.initCodeSize + 1;\n\tEM_Moments.Encoder.LzwEncoder::Compress(this, v69, os);\n\tv72 = os->klass;\n\tv78 = os->klass->vtable[30];\n\tv79 = os->klass->vtable[30];\n\t// 62 IndirectJump v78 @ X3_v1, os @ X1 (System.IO.Stream), os @ X1 (System.IO.Stream), 0, v79 @ X2_v3, v78 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Encode(Stream os)
		{
			//IL_0057: Expected I, but got O
			//IL_0067: Expected O, but got I
			//IL_0077: Expected O, but got I
			while (true)
			{
				byte value = Convert.ToByte(initCodeSize);
				os.WriteByte(value);
				curPixel = 0;
				int init_bits = initCodeSize + 1;
				Compress(init_bits, os);
				IntPtr intPtr = (IntPtr)os;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v9 (Il2CppClass<System.IO.Stream>)+310]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v9 (Il2CppClass<System.IO.Stream>)+318]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v78 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0xA407F4", Offset = "0xA407F4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EC28D0]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, outs, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E78]) = v41;\nL_0020:\n\tv53 = this.a_count < 1;\n\tif (v53) goto L_0048;\n\tgoto L_0030;\n\tv82 = *([v56 @ X0_v3+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0030;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v56, outs, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0030:\n\tv91 = System.Convert::ToByte(this.a_count);\n\tv111 = System.IO.Stream::WriteByte(outs, v91);\n\tv72 = System.IO.Stream::Write(outs, this.accum, 0, this.a_count);\n\tthis.a_count = 0;\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Flush(Stream outs)
		{
			if (a_count >= 1)
			{
				byte value = Convert.ToByte(a_count);
				outs.WriteByte(value);
				outs.Write(accum, 0, a_count);
				a_count = 0;
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xA40D9C", Offset = "0xA40D9C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = n_bits & 0x1F;\n\tv3 = 1 << v0;\n\treturnVal1 = v3 - 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int MaxCode(int n_bits)
		{
			int num = n_bits & 0x1F;
			int num2 = 1 << num;
			return num2 - 1;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xA40DB0", Offset = "0xA40DB0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF2488]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E79]) = v38;\nL_0013:\n\tv39 = this.pixAry;\n\tv41 = this.curPixel;\n\tv52 = this.curPixel != v39.Length;\n\tif (v52) goto L_0033;\n\tgoto L_0031;\n\tv96 = *([v57 @ X0_v9 (Il2CppClass<EM_Moments.Encoder.LzwEncoder>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0031;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = EM_Moments.Encoder.LzwEncoder;\nL_0031:\n\treturnVal1 = v103.EOF;\n\tgoto L_0047;\nL_0033:\n\tv61 = this.curPixel + 1;\n\tthis.curPixel = v61;\n\tv63 = this.curPixel < v39.Length;\n\tv64 = ~v63;\n\tif (v64) goto L_004A;\nL_0047:\n\treturn returnVal1;\n\tv54 = new System.NullReferenceException();\nL_004A:\n\tv95 = new System.IndexOutOfRangeException();\n\tthrow v95;\n\treturn returnVal2;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int NextPixel()
		{
			byte[] array = pixAry;
			int num = curPixel;
			if (curPixel != array.Length)
			{
				int num2 = curPixel + 1;
				curPixel = num2;
				if (curPixel < array.Length)
				{
					return array[num];
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return EOF;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0xA4096C", Offset = "0xA4096C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.masks;\n\tv20 = this.cur_bits;\n\tv22 = this.cur_bits < v14.Length;\n\tv23 = ~v22;\n\tif (v23) goto L_00C8;\n\tv60 = v14[v20 @ X8_v2 (System.Int32)] & this.cur_accum;\n\tthis.cur_accum = v60;\n\tv62 = this.cur_bits < 1;\n\tif (v62) goto L_0030;\n\tv85 = this.cur_bits & 0x1F;\n\tv86 = code << v85;\n\tv141 = v86 | v60;\nL_0030:\n\tv150 = this.n_bits + this.cur_bits;\n\tthis.cur_accum = v141;\n\tthis.cur_bits = v150;\n\tv102 = v150 < 8;\n\tif (v102) goto L_0063;\nL_0041:\n\tEM_Moments.Encoder.LzwEncoder::Add(this, v115, v138);\n\tv141 = this.cur_accum >> 8;\n\tv150 = this.cur_bits - 8;\n\tthis.cur_accum = v141;\n\tthis.cur_bits = v150;\n\tv114 = v150 > 7;\n\tif (v114) goto L_0041;\nL_0063:\n\tv166 = this.free_ent <= this.maxcode;\n\tif (v166) goto L_0079;\n\tv170 = ~this.clear_flg;\n\tv171 = ~v170;\n\tif (v171) goto L_007D;\n\tv239 = this.n_bits + 1;\n\tthis.n_bits = v239;\n\tv249 = v239 != this.maxbits;\n\tif (v249) goto L_00C2;\n\tv276 = this.maxmaxcode;\n\tgoto L_0082;\nL_0079:\n\tv172 = ~this.clear_flg;\n\tif (v172) goto L_008D;\nL_007D:\n\tthis.clear_flg = 0;\n\tthis.n_bits = this.g_init_bits;\n\tv253 = this.g_init_bits & 0x1F;\n\tv293 = 1 << v253;\nL_0081:\n\tv276 = v293 - 1;\nL_0082:\n\tthis.maxcode = v276;\nL_008D:\n\tv186 = this.EOFCode != code;\n\tif (v186) goto L_00C1;\n\tv305 = v150 < 1;\n\tif (v305) goto L_00B9;\nL_009D:\n\tEM_Moments.Encoder.LzwEncoder::Add(this, v314, v138);\n\tv315 = this.cur_accum >> 8;\n\tv333 = this.cur_bits - 8;\n\tthis.cur_accum = v315;\n\tthis.cur_bits = v333;\n\tv313 = v333 > 0;\n\tif (v313) goto L_009D;\nL_00B9:\n\tEM_Moments.Encoder.LzwEncoder::Flush(this, v138);\n\treturn;\nL_00C1:\n\treturn;\nL_00C2:\n\tv279 = v239 & 0x1F;\n\tv293 = 1 << v279;\n\tgoto L_0081;\n\tv32 = new System.NullReferenceException();\nL_00C8:\n\tv84 = new System.IndexOutOfRangeException();\n\tthrow v84;\n\treturn;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Output(int code, Stream outs)
		{
			int[] array = masks;
			int num = cur_bits;
			if (cur_bits >= array.Length)
			{
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			int num2 = (cur_accum = array[num] & cur_accum);
			bool flag = cur_bits < 1;
			int num3 = code;
			if (!flag)
			{
				int num4 = cur_bits & 0x1F;
				int num5 = code << num4;
				num3 = num5 | num2;
			}
			int num6 = n_bits + cur_bits;
			cur_accum = num3;
			cur_bits = num6;
			bool flag2 = num6 < 8;
			byte c = (byte)num3;
			Stream outs2 = default(Stream);
			if (!flag2)
			{
				bool flag3;
				do
				{
					Add(c, outs2);
					num3 = cur_accum >> 8;
					num6 = cur_bits - 8;
					cur_accum = num3;
					cur_bits = num6;
					flag3 = num6 > 7;
					c = (byte)num3;
				}
				while (flag3);
			}
			int num8;
			int num10;
			if (free_ent > maxcode)
			{
				if (!clear_flg)
				{
					int num7 = ++n_bits;
					if (num7 == maxbits)
					{
						num8 = maxmaxcode;
						goto IL_031e;
					}
					int num9 = num7 & 0x1F;
					num10 = 1 << num9;
					goto IL_034e;
				}
			}
			else if (!clear_flg)
			{
				goto IL_032d;
			}
			clear_flg = false;
			n_bits = g_init_bits;
			int num11 = g_init_bits & 0x1F;
			num10 = 1 << num11;
			goto IL_034e;
			IL_031e:
			maxcode = num8;
			goto IL_032d;
			IL_032d:
			if (EOFCode != code)
			{
				return;
			}
			bool flag4 = num6 < 1;
			byte c2 = (byte)num3;
			if (!flag4)
			{
				bool flag5;
				do
				{
					Add(c2, outs2);
					int num12 = cur_accum >> 8;
					int num13 = cur_bits - 8;
					cur_accum = num12;
					cur_bits = num13;
					flag5 = num13 > 0;
					c2 = (byte)num12;
				}
				while (flag5);
			}
			Flush(outs2);
			return;
			IL_034e:
			num8 = num10 - 1;
			goto IL_031e;
		}
	}
}
