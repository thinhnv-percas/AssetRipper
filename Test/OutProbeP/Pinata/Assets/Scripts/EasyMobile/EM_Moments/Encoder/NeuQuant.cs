using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EM_Moments.Encoder
{
	[Token(Token = "0x2000008")]
	public class NeuQuant
	{
		[Token(Token = "0x4000036")]
		protected static readonly int netsize = 256;

		[Token(Token = "0x4000037")]
		protected static readonly int prime1 = 499;

		[Token(Token = "0x4000038")]
		protected static readonly int prime2 = 491;

		[Token(Token = "0x4000039")]
		protected static readonly int prime3 = 487;

		[Token(Token = "0x400003A")]
		protected static readonly int prime4 = 503;

		[Token(Token = "0x400003B")]
		protected static readonly int minpicturebytes;

		[Token(Token = "0x400003C")]
		protected static readonly int maxnetpos;

		[Token(Token = "0x400003D")]
		protected static readonly int netbiasshift;

		[Token(Token = "0x400003E")]
		protected static readonly int ncycles;

		[Token(Token = "0x400003F")]
		protected static readonly int intbiasshift;

		[Token(Token = "0x4000040")]
		protected static readonly int intbias;

		[Token(Token = "0x4000041")]
		protected static readonly int gammashift;

		[Token(Token = "0x4000042")]
		protected static readonly int gamma;

		[Token(Token = "0x4000043")]
		protected static readonly int betashift;

		[Token(Token = "0x4000044")]
		protected static readonly int beta;

		[Token(Token = "0x4000045")]
		protected static readonly int betagamma;

		[Token(Token = "0x4000046")]
		protected static readonly int initrad;

		[Token(Token = "0x4000047")]
		protected static readonly int radiusbiasshift;

		[Token(Token = "0x4000048")]
		protected static readonly int radiusbias;

		[Token(Token = "0x4000049")]
		protected static readonly int initradius;

		[Token(Token = "0x400004A")]
		protected static readonly int radiusdec;

		[Token(Token = "0x400004B")]
		protected static readonly int alphabiasshift;

		[Token(Token = "0x400004C")]
		protected static readonly int initalpha;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x10")]
		protected int alphadec;

		[Token(Token = "0x400004E")]
		protected static readonly int radbiasshift;

		[Token(Token = "0x400004F")]
		protected static readonly int radbias;

		[Token(Token = "0x4000050")]
		protected static readonly int alpharadbshift;

		[Token(Token = "0x4000051")]
		protected static readonly int alpharadbias;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x18")]
		protected byte[] thepicture;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x20")]
		protected int lengthcount;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x24")]
		protected int samplefac;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x28")]
		protected int[][] network;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x30")]
		protected int[] netindex;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x38")]
		protected int[] bias;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x40")]
		protected int[] freq;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x48")]
		protected int[] radpower;

		[Token(Token = "0x600002C")]
		[Address(RVA = "0xA3FF70", Offset = "0xA3FF70", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EEEAE8]);\n\tv35 = *([v34 @ X8_v40]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, thepic, len, sample, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2021E7B]) = v51;\nL_001F:\n\t// 31 NewArr v56 @ X0_v3 (System.Int32[]), typeof(System.Int32[]), 256\n\tthis.netindex = v56;\n\tgoto L_0031;\n\tv63 = *([v59 @ X0_v4 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0031;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, v54, len, sample, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv67 = EM_Moments.Encoder.NeuQuant;\nL_0031:\n\t// 49 NewArr v73 @ X0_v7 (System.Int32[]), typeof(System.Int32[]), v70.netsize (System.Int32)\n\tthis.bias = v73;\n\t// 55 NewArr v79 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v77.netsize (System.Int32)\n\tthis.freq = v79;\n\t// 61 NewArr v84 @ X0_v11 (System.Int32[]), typeof(System.Int32[]), v82.initrad (System.Int32)\n\tthis.radpower = v84;\n\tSystem.Object::.ctor(this);\n\tthis.thepicture = thepic;\n\tthis.lengthcount = len;\n\tthis.samplefac = sample;\n\t// 75 NewArr v93 @ X0_v14 (System.Int32[][]), typeof(System.Int32[][]), v89.netsize (System.Int32)\n\tthis.network = v93;\n\tgoto L_00CE;\nL_0050:\n\tv129 = this.network;\n\t// 82 NewArr v182 @ X0_v19 (System.Int32[]), typeof(System.Int32[]), 4\n\tv185 = v182 == 0;\n\tif (v185) goto L_006C;\n\t// 91 IsInst v255 @ X0_v35, typeof(System.Int32[]), v182 @ X0_v19 (System.Int32[])\n\tv257 = v255 == 0;\n\tif (v257) goto L_00F4;\nL_006C:\n\tv129[v140 @ X21_v3 (System.Int32)] = v182;\n\tv246 = this.network;\n\tv143 = v246[v140 @ X21_v3 (System.Int32)];\n\tgoto L_009B;\n\tv331 = *([v327 @ X0_v30 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv332 = v331 == 0;\n\tv333 = ~v332;\n\t// 134 ConditionalJump @b45, v333 @ TEMP_v26\n\tv336 = \"il2cpp_codegen_runtime_class_init\"(v327, v133, len, sample, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv334 = EM_Moments.Encoder.NeuQuant;\nL_009B:\n\tv342 = v339.netbiasshift + 8;\n\tv343 = v342 & 0x1F;\n\tv233 = v140 << v343;\n\tv344 = v233 / v339.netsize;\n\tv143[1] = v344;\n\tv143[2] = v344;\n\tv143[0] = v344;\n\tv247 = this.freq;\n\tv234 = v348.intbias / v348.netsize;\n\tv247[v140 @ X21_v3 (System.Int32)] = v234;\n\tv248 = this.bias;\n\tv141 = v140 + 1;\n\tv248[v140 @ X21_v3 (System.Int32)] = 0;\nL_00CE:\n\tgoto L_00E1;\n\tv150 = *([v146 @ X0_v16 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tgoto L_00E1;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v146, v132, len, sample, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv154 = EM_Moments.Encoder.NeuQuant;\nL_00E1:\n\tv169 = v140 < v157.netsize;\n\tif (v169) goto L_0050;\n\treturn;\n\tv251 = new System.NullReferenceException();\n\tv282 = new System.IndexOutOfRangeException();\nL_00F3:\n\tv324 = new System.TypeLoadException();\nL_00F4:\n\tv313 = new System.ArrayTypeMismatchException();\n\tgoto L_00F3;\n\treturn;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NeuQuant(byte[] thepic, int len, int sample)
		{
			int[] array = new int[256];
			netindex = array;
			int[] array2 = new int[netsize];
			bias = array2;
			int[] array3 = new int[netsize];
			freq = array3;
			int[] array4 = new int[initrad];
			radpower = array4;
			thepicture = thepic;
			lengthcount = len;
			samplefac = sample;
			int[][] array5 = new int[netsize][];
			network = array5;
			int num = 0;
			while (true)
			{
				if (num >= netsize)
				{
					return;
				}
				int[][] array6 = network;
				int[] array7 = new int[4];
				if (array7 != null)
				{
					object obj = array7 as int[];
					if (obj == null)
					{
						break;
					}
				}
				array6[num] = array7;
				int[][] array8 = network;
				int[] array9 = array8[num];
				int num2 = netbiasshift + 8;
				int num3 = num2 & 0x1F;
				int num4 = num << num3;
				array9[0] = (array9[2] = (array9[1] = num4 / netsize));
				int[] array10 = freq;
				int num5 = intbias / netsize;
				array10[num] = num5;
				int[] array11 = bias;
				int num6 = num + 1;
				array11[num] = 0;
				num = num6;
			}
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0xA40EE0", Offset = "0xA40EE0", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EDABD8]);\n\tv27 = *([v26 @ X8_v38]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021E7C]) = v46;\nL_001D:\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = EM_Moments.Encoder.NeuQuant;\nL_0028:\n\tv64 = v60.netsize << 1;\n\tv65 = v60.netsize + v64;\n\t// 43 NewArr v67 @ X0_v5 (System.Byte[]), typeof(System.Byte[]), v65 @ X1_v1 (System.Int32)\n\t// 52 NewArr v77 @ X0_v7 (System.Int32[]), typeof(System.Int32[]), v72.netsize (System.Int32)\n\tgoto L_006E;\nL_0038:\n\tv145 = this.network;\n\tv189 = v109 < v145.Length;\n\tv190 = ~v189;\n\tif (v190) goto L_0142;\n\tv329 = v145[v109 @ X23_v2 (System.Int32)];\n\tv383 = v329.Length < 3;\n\tv294 = ~v383;\n\tv284 = v329.Length - 3;\n\tv264 = v284 == 0;\n\tv384 = ~v294;\n\tv81 = v384 | v264;\n\tif (v81) goto L_0142;\n\tv412 = v329[3] < v77.Length;\n\tv107 = ~v412;\n\tif (v107) goto L_0142;\n\tv77[v329[3]] = v109;\n\tv109 = v109 + 1;\nL_006E:\n\tgoto L_0081;\n\tv123 = *([v119 @ X0_v9 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tgoto L_0081;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v119, v74, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv126 = EM_Moments.Encoder.NeuQuant;\nL_0081:\n\tv141 = v109 < v129.netsize;\n\tif (v141) goto L_0038;\n\tgoto L_0122;\nL_0089:\n\tv411 = v175 < v77.Length;\n\tv296 = ~v411;\n\tif (v296) goto L_0142;\n\tv309 = this.network;\n\tv332 = v77[v175 @ X23_v6 (System.Int32)];\n\tv414 = v77[v175 @ X23_v6 (System.Int32)] < v309.Length;\n\tv297 = ~v414;\n\tif (v297) goto L_0142;\n\tv207 = v309[v332 @ X8_v24];\n\tv370 = v207.Length == 0;\n\tif (v370) goto L_0142;\n\tv312 = v153 - 2;\n\tv415 = v312 < v67.Length;\n\tv298 = ~v415;\n\tif (v298) goto L_0142;\n\tv67[v312 @ X9_v12 (System.Int32)] = v207[0];\n\tv208 = this.network;\n\tv417 = v77[v175 @ X23_v6 (System.Int32)] < v208.Length;\n\tv299 = ~v417;\n\tif (v299) goto L_0142;\n\tv209 = v208[v332 @ X8_v24];\n\tv419 = v209.Length < 1;\n\tv366 = ~v419;\n\tv364 = v209.Length - 1;\n\tv360 = v364 == 0;\n\tv420 = ~v366;\n\tv216 = v420 | v360;\n\tif (v216) goto L_0142;\n\tv313 = v312 + 1;\n\tv421 = v313 < v67.Length;\n\tv300 = ~v421;\n\tif (v300) goto L_0142;\n\tv423 = v153 - 1;\n\tv67[v423 @ X11_v9 (System.Int32)] = v209[1];\n\tv210 = this.network;\n\tv424 = v77[v175 @ X23_v6 (System.Int32)] < v210.Length;\n\tv301 = ~v424;\n\tif (v301) goto L_0142;\n\tv333 = v210[v332 @ X8_v24];\n\tv426 = v333.Length < 2;\n\tv367 = ~v426;\n\tv365 = v333.Length - 2;\n\tv361 = v365 == 0;\n\tv427 = ~v367;\n\tv156 = v427 | v361;\n\tif (v156) goto L_0142;\n\tv368 = v313 + 1;\n\tv428 = v368 < v67.Length;\n\tv174 = ~v428;\n\tif (v174) goto L_0142;\n\tv175 = v175 + 1;\n\tv154 = v153 + 3;\n\tv67[v153 @ X24_v4 (System.Int32)] = v333[2];\nL_0122:\n\tgoto L_0135;\n\tv336 = *([v179 @ X0_v17 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv337 = v336 == 0;\n\tv338 = ~v337;\n\tgoto L_0135;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v179, v74, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv339 = EM_Moments.Encoder.NeuQuant;\nL_0135:\n\tv215 = v175 < v342.netsize;\n\tif (v215) goto L_0089;\n\treturn v67;\nL_0142:\n\tv372 = new System.IndexOutOfRangeException();\n\tthrow v372;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public byte[] ColorMap()
		{
			//IL_007f: Expected O, but got I4
			//IL_0179: Expected O, but got I4
			//IL_02b5: Expected O, but got I4
			//IL_03cd: Expected O, but got I4
			int num = netsize << 1;
			int num2 = netsize + num;
			byte[] array = new byte[num2];
			int[] array2 = new int[netsize];
			int num3 = 0;
			while (true)
			{
				if (num3 < netsize)
				{
					int[][] array3 = network;
					if (num3 >= array3.Length)
					{
						break;
					}
					int[] array4 = array3[num3];
					bool flag = array4.Length < 3;
					bool flag2 = !flag;
					object obj = array4.Length - 3;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (flag4 || flag3 || array4[3] >= array2.Length)
					{
						break;
					}
					array2[array4[3]] = num3;
					num3++;
					continue;
				}
				int num4 = 2;
				int num5 = 0;
				while (true)
				{
					if (num5 < netsize)
					{
						if (num5 >= array2.Length)
						{
							break;
						}
						int[][] array5 = network;
						object obj2 = array2[num5];
						if (array2[num5] >= array5.Length)
						{
							break;
						}
						int[] array6 = array5[obj2];
						if (array6.Length == 0)
						{
							break;
						}
						int num6 = num4 - 2;
						if (num6 >= array.Length)
						{
							break;
						}
						array[num6] = (byte)array6[0];
						int[][] array7 = network;
						if (array2[num5] >= array7.Length)
						{
							break;
						}
						int[] array8 = array7[obj2];
						bool flag5 = array8.Length < 1;
						bool flag6 = !flag5;
						object obj3 = array8.Length - 1;
						bool flag7 = obj3 == null;
						bool flag8 = !flag6;
						if (flag8 || flag7)
						{
							break;
						}
						int num7 = num6 + 1;
						if (num7 >= array.Length)
						{
							break;
						}
						int num8 = num4 - 1;
						array[num8] = (byte)array8[1];
						int[][] array9 = network;
						if (array2[num5] >= array9.Length)
						{
							break;
						}
						int[] array10 = array9[obj2];
						bool flag9 = array10.Length < 2;
						bool flag10 = !flag9;
						object obj4 = array10.Length - 2;
						bool flag11 = obj4 == null;
						bool flag12 = !flag10;
						if (flag12 || flag11)
						{
							break;
						}
						int num9 = num7 + 1;
						if (num9 >= array.Length)
						{
							break;
						}
						num5++;
						int num10 = num4 + 3;
						array[num4] = (byte)array10[2];
						num4 = num10;
						continue;
					}
					return array;
				}
				break;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0xA41168", Offset = "0xA41168", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv32 = *([1EE5128]);\n\tv33 = *([v32 @ X8_v43]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021E7D]) = v52;\n\tgoto L_016F;\nL_0020:\n\tv263 = this.network;\n\tv154 = v58 < v263.Length;\n\tv155 = ~v154;\n\tif (v155) goto L_01CB;\n\tv75 = v263[v58 @ X22_v2 (System.Int32)];\n\tv468 = v75.Length < 2;\n\tv427 = ~v468;\n\tv299 = ~v427;\n\tif (v299) goto L_01CB;\n\tv70 = v75[1];\n\tgoto L_0070;\nL_0043:\n\tv601 = v169 < v263.Length;\n\tv237 = ~v601;\n\tif (v237) goto L_01CB;\n\tv245 = v263[v169 @ X27_v7 (System.Int32)];\n\tv616 = v245.Length < 1;\n\tv428 = ~v616;\n\tv412 = v245.Length - 1;\n\tv380 = v412 == 0;\n\tv617 = ~v428;\n\tv300 = v617 | v380;\n\tif (v300) goto L_01CB;\n\tv560 = v245[1] >= v70;\n\tif (v560) goto L_0070;\nL_0070:\n\tgoto L_007A;\n\tv246 = *([v571 @ X0_v18 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv582 = v246 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_007A;\n\tv264 = v26.network;\nL_007A:\n\tv169 = v169 + 1;\n\tv173 = v169 < v586.netsize;\n\tif (v173) goto L_0043;\n\tv600 = v68 < v263.Length;\n\tv429 = ~v600;\n\tif (v429) goto L_01CB;\n\tv218 = v58 == v68;\n\tif (v218) goto L_0132;\n\tv265 = v263[v68 @ X26_v7 (System.Int32)];\n\tv455 = v265.Length == 0;\n\tif (v455) goto L_01CB;\n\tv456 = v75.Length == 0;\n\tif (v456) goto L_01CB;\n\tv265[0] = v75[0];\n\tv457 = v75.Length == 0;\n\tif (v457) goto L_01CB;\n\tv75[0] = v265[0];\n\tv627 = v265.Length < 1;\n\tv430 = ~v627;\n\tv414 = v265.Length - 1;\n\tv382 = v414 == 0;\n\tv628 = ~v430;\n\tv301 = v628 | v382;\n\tif (v301) goto L_01CB;\n\tv642 = v75.Length < 1;\n\tv431 = ~v642;\n\tv415 = v75.Length - 1;\n\tv383 = v415 == 0;\n\tv643 = ~v431;\n\tv302 = v643 | v383;\n\tif (v302) goto L_01CB;\n\tv265[1] = v75[1];\n\tv645 = v75.Length < 1;\n\tv432 = ~v645;\n\tv416 = v75.Length - 1;\n\tv384 = v416 == 0;\n\tv646 = ~v432;\n\tv303 = v646 | v384;\n\tif (v303) goto L_01CB;\n\tv75[1] = v265[1];\n\tv649 = v265.Length < 2;\n\tv433 = ~v649;\n\tv417 = v265.Length - 2;\n\tv385 = v417 == 0;\n\tv650 = ~v433;\n\tv304 = v650 | v385;\n\tif (v304) goto L_01CB;\n\tv651 = v75.Length < 2;\n\tv434 = ~v651;\n\tv418 = v75.Length - 2;\n\tv386 = v418 == 0;\n\tv652 = ~v434;\n\tv305 = v652 | v386;\n\tif (v305) goto L_01CB;\n\tv265[2] = v75[2];\n\tv654 = v75.Length < 2;\n\tv435 = ~v654;\n\tv419 = v75.Length - 2;\n\tv387 = v419 == 0;\n\tv655 = ~v435;\n\tv306 = v655 | v387;\n\tif (v306) goto L_01CB;\n\tv75[2] = v265[2];\n\tv656 = v265.Length < 3;\n\tv436 = ~v656;\n\tv420 = v265.Length - 3;\n\tv388 = v420 == 0;\n\tv657 = ~v436;\n\tv307 = v657 | v388;\n\tif (v307) goto L_01CB;\n\tv658 = v75.Length < 3;\n\tv437 = ~v658;\n\tv421 = v75.Length - 3;\n\tv389 = v421 == 0;\n\tv659 = ~v437;\n\tv308 = v659 | v389;\n\tif (v308) goto L_01CB;\n\tv265[3] = v75[3];\n\tv660 = v75.Length < 3;\n\tv438 = ~v660;\n\tv422 = v75.Length - 3;\n\tv390 = v422 == 0;\n\tv661 = ~v438;\n\tv309 = v661 | v390;\n\tif (v309) goto L_01CB;\n\tv75[3] = v265[3];\nL_0132:\n\tv219 = v70 == v640;\n\tif (v219) goto L_016A;\n\tv639 = this.netindex;\n\tv623 = v640 < v639.Length;\n\tv439 = ~v623;\n\tif (v439) goto L_01CB;\n\tv625 = v58 + v61;\n\tv249 = v625 >> 1;\nL_014A:\n\tv270 = v640 + 1;\n\tv639[v640 @ X20_v11 (System.Int32)] = v249;\n\tv176 = v270 >= v70;\n\tif (v176) goto L_FFFFFFFF;\n\tv639 = this.netindex;\n\tv648 = v270 < v639.Length;\n\tv440 = ~v648;\n\tv310 = ~v440;\n\tif (v310) goto L_014A;\n\tgoto L_01CB;\nL_016A:\n\tv58 = v58 + 1;\nL_016F:\n\tgoto L_0182;\n\tv118 = *([v114 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tgoto L_0182;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v114, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv122 = EM_Moments.Encoder.NeuQuant;\nL_0182:\n\tv137 = v58 < v125.netsize;\n\tif (v137) goto L_0020;\n\tv528 = this.netindex;\n\tgoto L_0191;\n\tv145 = *([v121 @ X0_v4 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\t// 396 ConditionalJump @b48, v147 @ TEMP_v23\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v121, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0191:\n\tv275 = v640 < v528.Length;\n\tv276 = ~v275;\n\tif (v276) goto L_01CB;\n\tv466 = v464.maxnetpos + v61;\n\tv542 = v466 >> 1;\nL_01A2:\n\tv271 = v640 + 1;\n\tv528[v640 @ X20_v11 (System.Int32)] = v542;\n\tv177 = v271 >= 0x100;\n\tif (v177) goto L_01DB;\n\tv528 = this.netindex;\n\tgoto L_01BF;\n\tv577 = *([v554 @ X0_v14+E0]);\n\tv578 = v577 == 0;\n\tv579 = ~v578;\n\t// 440 ConditionalJump @b54, v579 @ TEMP_v21\n\tv580 = \"il2cpp_codegen_runtime_class_init\"(v554, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01BF:\n\tv599 = v271 < v528.Length;\n\tv426 = ~v599;\n\tv542 = v598.maxnetpos;\n\tv298 = ~v426;\n\tif (v298) goto L_01A2;\nL_01CB:\n\tv462 = new System.IndexOutOfRangeException();\n\tthrow v462;\nL_01DB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 295 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Inxbuild()
		{
			//IL_011a: Expected O, but got I4
			//IL_02de: Expected O, but got I4
			//IL_033f: Expected O, but got I4
			//IL_03bc: Expected O, but got I4
			//IL_0439: Expected O, but got I4
			//IL_049a: Expected O, but got I4
			//IL_0517: Expected O, but got I4
			//IL_0594: Expected O, but got I4
			//IL_05f5: Expected O, but got I4
			//IL_0672: Expected O, but got I4
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				if (num < netsize)
				{
					int[][] array = network;
					if (num >= array.Length)
					{
						break;
					}
					int[] array2 = array[num];
					if (array2.Length < 2)
					{
						break;
					}
					int num4 = array2[1];
					int num5 = num;
					int num6 = num;
					while (true)
					{
						num5++;
						if (num5 < netsize)
						{
							if (num5 >= array.Length)
							{
								goto end_IL_08c8;
							}
							int[] array3 = array[num5];
							bool flag = array3.Length < 1;
							bool flag2 = !flag;
							object obj = array3.Length - 1;
							bool flag3 = obj == null;
							bool flag4 = !flag2;
							if (flag4 || flag3)
							{
								goto end_IL_08c8;
							}
							if (array3[1] < num4)
							{
								num6 = num5;
								num4 = array3[1];
							}
							continue;
						}
						break;
					}
					if (num6 >= array.Length)
					{
						break;
					}
					if (num != num6)
					{
						int[] array4 = array[num6];
						if (array4.Length == 0 || array2.Length == 0)
						{
							break;
						}
						array4[0] = array2[0];
						if (array2.Length == 0)
						{
							break;
						}
						array2[0] = array4[0];
						bool flag5 = array4.Length < 1;
						bool flag6 = !flag5;
						object obj2 = array4.Length - 1;
						bool flag7 = obj2 == null;
						bool flag8 = !flag6;
						if (flag8 || flag7)
						{
							break;
						}
						bool flag9 = array2.Length < 1;
						bool flag10 = !flag9;
						object obj3 = array2.Length - 1;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						if (flag12 || flag11)
						{
							break;
						}
						array4[1] = array2[1];
						bool flag13 = array2.Length < 1;
						bool flag14 = !flag13;
						object obj4 = array2.Length - 1;
						bool flag15 = obj4 == null;
						bool flag16 = !flag14;
						if (flag16 || flag15)
						{
							break;
						}
						array2[1] = array4[1];
						bool flag17 = array4.Length < 2;
						bool flag18 = !flag17;
						object obj5 = array4.Length - 2;
						bool flag19 = obj5 == null;
						bool flag20 = !flag18;
						if (flag20 || flag19)
						{
							break;
						}
						bool flag21 = array2.Length < 2;
						bool flag22 = !flag21;
						object obj6 = array2.Length - 2;
						bool flag23 = obj6 == null;
						bool flag24 = !flag22;
						if (flag24 || flag23)
						{
							break;
						}
						array4[2] = array2[2];
						bool flag25 = array2.Length < 2;
						bool flag26 = !flag25;
						object obj7 = array2.Length - 2;
						bool flag27 = obj7 == null;
						bool flag28 = !flag26;
						if (flag28 || flag27)
						{
							break;
						}
						array2[2] = array4[2];
						bool flag29 = array4.Length < 3;
						bool flag30 = !flag29;
						object obj8 = array4.Length - 3;
						bool flag31 = obj8 == null;
						bool flag32 = !flag30;
						if (flag32 || flag31)
						{
							break;
						}
						bool flag33 = array2.Length < 3;
						bool flag34 = !flag33;
						object obj9 = array2.Length - 3;
						bool flag35 = obj9 == null;
						bool flag36 = !flag34;
						if (flag36 || flag35)
						{
							break;
						}
						array4[3] = array2[3];
						bool flag37 = array2.Length < 3;
						bool flag38 = !flag37;
						object obj10 = array2.Length - 3;
						bool flag39 = obj10 == null;
						bool flag40 = !flag38;
						if (flag40 || flag39)
						{
							break;
						}
						array2[3] = array4[3];
					}
					if (num4 != num3)
					{
						int[] array5 = netindex;
						if (num3 >= array5.Length)
						{
							break;
						}
						int num7 = num + num2;
						int num8 = num7 >> 1;
						while (true)
						{
							int num9 = num3 + 1;
							array5[num3] = num8;
							if (num9 >= num4)
							{
								break;
							}
							array5 = netindex;
							bool flag41 = num9 < array5.Length;
							bool flag42 = !flag41;
							bool flag43 = !flag42;
							num8 = num;
							num3 = num9;
							if (!flag43)
							{
								goto end_IL_08c8;
							}
						}
						num2 = num;
						num3 = num4;
					}
					num++;
					continue;
				}
				int[] array6 = netindex;
				if (num3 >= array6.Length)
				{
					break;
				}
				int num10 = maxnetpos + num2;
				int num11 = num10 >> 1;
				bool flag46;
				do
				{
					int num12 = num3 + 1;
					array6[num3] = num11;
					if (num12 < 256)
					{
						array6 = netindex;
						bool flag44 = num12 < array6.Length;
						bool flag45 = !flag44;
						num11 = maxnetpos;
						flag46 = !flag45;
						num3 = num12;
						continue;
					}
					return;
				}
				while (flag46);
				break;
				continue;
				end_IL_08c8:
				break;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0xA41488", Offset = "0xA41488", Length = "0x580")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv34 = *([1EE4C08]);\n\tv35 = *([v34 @ X8_v102]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021E7E]) = v54;\n\tgoto L_0036;\n\tv62 = *([v58 @ X0_v2 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0036;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv66 = EM_Moments.Encoder.NeuQuant;\n\tv68 = EM_Moments.Encoder.NeuQuant;\nL_0036:\n\tv82 = this.lengthcount >= v71.minpicturebytes;\n\tif (v82) goto L_003B;\n\tthis.samplefac = 1;\n\tgoto L_003D;\nL_003B:\n\tv87 = this.samplefac;\nL_003D:\n\tv89 = v87 - 1;\n\tv91 = v89 * 0x55555556;\n\tv92 = v91 >> 0x3F;\n\tv93 = v91 >> 0x20;\n\tv94 = v93 + v92;\n\tv95 = v94 + 0x1E;\n\tthis.alphadec = v95;\n\tv96 = this.thepicture;\n\tgoto L_0058;\n\tv102 = *([v67 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tgoto L_0058;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv106 = EM_Moments.Encoder.NeuQuant;\n\tv108 = EM_Moments.Encoder.NeuQuant;\nL_0058:\n\tv410 = v111.initalpha;\n\tv116 = v111.radiusbiasshift & 0x1F;\n\tv117 = v111.initradius >> v116;\n\tv120 = v117 - 1;\n\tv121 = v120 < 0;\n\tv122 = v120 == 0;\n\tv123 = v117 ^ 1;\n\tv124 = v117 ^ v120;\n\tv125 = v123 & v124;\n\tv126 = v125 < 0;\n\tv127 = v121 == v126;\n\tv128 = ~v122;\n\tv129 = v127 & v128;\n\tv130 = ~v129;\n\tif (v130) goto L_FFFFFFFF;\n\tgoto L_0078;\nL_0078:\n\tv147 = v135 < 1;\n\tif (v147) goto L_00B2;\n\tv149 = v117 * v117;\nL_007E:\n\tv152 = this.radpower;\n\tgoto L_008B;\n\tv241 = *([v212 @ X0_v52+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\t// 133 Jump @b93\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v212, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv244 = EM_Moments.Encoder.NeuQuant;\nL_008B:\n\t;\n\tv257 = v209 < v152.Length;\n\tv258 = ~v257;\n\tif (v258) goto L_0258;\n\tv185 = v209 * v209;\n\tv453 = v149 - v185;\n\tv456 = v454.radbias * v453;\n\tv457 = v456 / v149;\n\tv187 = v457 * v410;\n\tv152[v209 @ X23_v10 (System.Int32)] = v187;\n\tv223 = *([v395 @ X12_v15 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)]);\n\tv209 = v209 + 1;\n\tv154 = v209 < v135;\n\tif (v154) goto L_007E;\nL_00B2:\n\tv191 = v87 << 1;\n\tv192 = v87 + v191;\n\tv193 = this.lengthcount / v192;\n\tgoto L_00C2;\n\tv218 = *([v182 @ X0_v11 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_00C2;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v182, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv222 = EM_Moments.Encoder.NeuQuant;\n\tv224 = EM_Moments.Encoder.NeuQuant;\nL_00C2:\n\tv744 = *([v223 @ X0_v12 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+B8]);\n\tv289 = v193 / v111.ncycles;\n\tv240 = this.lengthcount >= v744.minpicturebytes;\n\tif (v240) goto L_00D7;\n\tgoto L_FFFFFFFF;\nL_00D7:\n\tgoto L_00E2;\n\tv435 = *([v223 @ X0_v12 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv436 = v435 == 0;\n\tv437 = ~v436;\n\tif (v437) goto L_00E2;\n\tv568 = \"il2cpp_codegen_runtime_class_init\"(v223, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv440 = EM_Moments.Encoder.NeuQuant;\n\tv442 = EM_Moments.Encoder.NeuQuant;\n\tv445 = *([v442 @ X0_v49+B8]);\nL_00E2:\n\tv447 = this.lengthcount / v744.prime1;\n\tv448 = v447 * v744.prime1;\n\tv450 = this.lengthcount == v448;\n\tif (v450) goto L_00FA;\n\tgoto L_00F4;\n\tv629 = *([v441 @ X0_v32+E0]);\n\tv630 = v629 == 0;\n\tv631 = ~v630;\n\tif (v631) goto L_00F4;\n\tv636 = \"il2cpp_codegen_runtime_class_init\"(v441, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv634 = EM_Moments.Encoder.NeuQuant;\n\tv690 = EM_Moments.Encoder.NeuQuant;\n\tv639 = *([v690 @ X8_v82+B8]);\nL_00F4:\n\tv673 = v744 + 4;\n\tgoto L_014A;\nL_00FA:\n\tgoto L_0105;\n\tv641 = *([v441 @ X0_v32+E0]);\n\tv642 = v641 == 0;\n\tv643 = ~v642;\n\tif (v643) goto L_0105;\n\tv678 = \"il2cpp_codegen_runtime_class_init\"(v441, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv646 = EM_Moments.Encoder.NeuQuant;\n\tv648 = EM_Moments.Encoder.NeuQuant;\n\tv651 = *([v648 @ X0_v45+B8]);\nL_0105:\n\tv653 = this.lengthcount / v744.prime2;\n\tv654 = v653 * v744.prime2;\n\tv656 = this.lengthcount == v654;\n\tif (v656) goto L_011D;\n\tgoto L_0117;\n\tv692 = *([v647 @ X0_v34+E0]);\n\tv693 = v692 == 0;\n\tv694 = ~v693;\n\tif (v694) goto L_0117;\n\tv696 = \"il2cpp_codegen_runtime_class_init\"(v647, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv695 = EM_Moments.Encoder.NeuQuant;\n\tv730 = EM_Moments.Encoder.NeuQuant;\n\tv698 = *([v730 @ X8_v77+B8]);\nL_0117:\n\tv673 = v744 + 8;\n\tgoto L_014A;\nL_011D:\n\tgoto L_0129;\n\tv699 = *([v647 @ X0_v34+E0]);\n\tv700 = v699 == 0;\n\tv701 = ~v700;\n\tif (v701) goto L_0129;\n\tv722 = \"il2cpp_codegen_runtime_class_init\"(v647, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv706 = EM_Moments.Encoder.NeuQuant;\n\tv708 = EM_Moments.Encoder.NeuQuant;\n\tv711 = *([v708 @ X0_v41+B8]);\n\tv704 = *([v708 @ X0_v41+12E]);\nL_0129:\n\tv658 = this.lengthcount / v744.prime3;\n\tv713 = v658 * v744.prime3;\n\tv714 = this.lengthcount == v713;\n\tif (v714) goto L_013E;\n\tgoto L_013A;\n\tv732 = *([v707 @ X0_v35+E0]);\n\tv733 = v732 == 0;\n\tv734 = ~v733;\n\tif (v734) goto L_013A;\n\tv736 = \"il2cpp_codegen_runtime_class_init\"(v707, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv735 = EM_Moments.Encoder.NeuQuant;\n\tv765 = EM_Moments.Encoder.NeuQuant;\n\tv738 = *([v765 @ X8_v72+B8]);\nL_013A:\n\tv673 = v744 + 0xC;\n\tgoto L_014A;\nL_013E:\n\tgoto L_0148;\n\tv739 = *([v707 @ X0_v35+E0]);\n\tv740 = v739 == 0;\n\tv741 = ~v740;\n\tif (v741) goto L_0148;\n\tv743 = \"il2cpp_codegen_runtime_class_init\"(v707, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv742 = EM_Moments.Encoder.NeuQuant;\n\tv767 = EM_Moments.Encoder.NeuQuant;\n\tv745 = *([v767 @ X8_v68+B8]);\nL_0148:\n\tv673 = v744 + 0x10;\nL_014A:\n\tv420 = *([v673 @ X8_v61]) << 1;\n\tv431 = *([v673 @ X8_v61]) + v420;\n\tgoto L_0248;\nL_0152:\n\t;\n\tv657 = v390 < v96.Length;\n\tv493 = ~v657;\n\tif (v493) goto L_0258;\n\tv499 = *([v395 @ X12_v15 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)]);\n\tgoto L_016D;\n\tv715 = *([v685 @ X0_v15+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_016D;\n\tv727 = \"il2cpp_codegen_runtime_class_init\"(v685, v308, v304, v300, v296, v292, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv719 = EM_Moments.Encoder.NeuQuant;\n\tv720 = *([v96 @ X27_v1 (System.Byte[])+18]);\nL_016D:\n\tv497 = v390 + 1;\n\tv721 = v497 < v96.Length;\n\tv496 = ~v721;\n\tif (v496) goto L_0258;\n\tv463 = v390 + 2;\n\tv728 = v463 < v96.Length;\n\tv494 = ~v728;\n\tif (v494) goto L_0258;\n\tv748 = *([v499 @ X0_v16+B8]);\n\tv314 = *([v748 @ X8_v28+1C]) & 0x1F;\n\tv753 = *([v748 @ X8_v28+1C]) & 0x1F;\n\tv549 = v96[v390 @ X21_v6 (System.Int32)] << v753;\n\tv550 = v96[v497 @ X9_v18 (System.Int32)] << v314;\n\tv507 = v96[v463 @ X10_v7 (System.Int32)] << v314;\n\tv757 = EM_Moments.Encoder.NeuQuant::Contest(this, v549, v550, v507);\n\tEM_Moments.Encoder.NeuQuant::Altersingle(this, v410, v757, v549, v550, v507);\n\tv768 = v272 == 0;\n\tif (v768) goto L_01A5;\n\tEM_Moments.Encoder.NeuQuant::Alterneigh(this, v272, v757, v549, v550, v507);\nL_01A5:\n\tv390 = v390 + v431;\n\tv787 = v390 < this.lengthcount;\n\tif (v787) goto L_01BA;\n\tv390 = v390 - this.lengthcount;\nL_01BA:\n\tv534 = v289 == 0;\n\tv284 = v284 + 1;\n\tv513 = ~v534;\n\tv505 = ~v513;\n\tif (v505) goto L_FFFFFFFF;\n\tgoto L_01C8;\nL_01C8:\n\tv795 = v284 / v289;\n\tv796 = v795 * v289;\n\tv560 = v284 != v796;\n\tif (v560) goto L_0248;\n\tv801 = v410 / this.alphadec;\n\tv410 = v410 - v801;\n\tgoto L_01E2;\n\tv804 = *([v798 @ X0_v21 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv805 = v804 == 0;\n\tv806 = ~v805;\n\tif (v806) goto L_01E2;\n\tv827 = \"il2cpp_codegen_runtime_class_init\"(v798, v309, v305, v301, v297, v293, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv807 = EM_Moments.Encoder.NeuQuant;\n\tv808 = EM_Moments.Encoder.NeuQuant;\nL_01E2:\n\tv814 = v321 / v810.radiusdec;\n\tv510 = v321 - v814;\n\tv815 = v810.radiusbiasshift & 0x1F;\n\tv565 = v510 >> v815;\n\tv818 \n// ... truncated")]
		public void Learn()
		{
			//IL_048e: Expected I, but got O
			//IL_049c: Expected I, but got O
			//IL_06cf: Expected O, but got I
			//IL_096a: Expected I4, but got O
			//IL_0972: Unknown result type (might be due to invalid IL or missing references)
			//IL_0977: Expected I4, but got Unknown
			//IL_071f: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_0783: Expected O, but got I
			//IL_076f: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0839: Expected I, but got O
			//IL_0356: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(NeuQuant);
			IntPtr intPtr2 = (IntPtr)typeof(NeuQuant);
			int num;
			if (lengthcount < minpicturebytes)
			{
				samplefac = 1;
				num = 1;
			}
			else
			{
				num = samplefac;
			}
			int num2 = num - 1;
			int num3 = num2 * 1431655766;
			int num4 = num3 >> 63;
			int num5 = num3 >> 32;
			int num6 = num5 + num4;
			int num7 = num6 + 30;
			alphadec = num7;
			byte[] array = thepicture;
			int num8 = initalpha;
			int num9 = radiusbiasshift & 0x1F;
			int num10 = initradius >> num9;
			int num11 = num10 - 1;
			bool flag = num11 < 0;
			bool flag2 = num11 == 0;
			int num12 = num10 ^ 1;
			int num13 = num10 ^ num11;
			int num14 = num12 & num13;
			bool flag3 = num14 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num15 = ((flag4 && flag5) ? num10 : 0);
			if (num15 < 1)
			{
				goto IL_011a;
			}
			int num16 = num10 * num10;
			int num17 = 0;
			while (true)
			{
				int[] array2 = radpower;
				if (num17 >= array2.Length)
				{
					break;
				}
				int num18 = num17 * num17;
				int num19 = num16 - num18;
				int num20 = radbias * num19;
				int num21 = num20 / num16;
				int num22 = num21 * num8;
				array2[num17] = num22;
				intPtr2 = intPtr;
				num17++;
				bool flag6 = num17 < num15;
				intPtr = intPtr;
				if (flag6)
				{
					continue;
				}
				goto IL_011a;
			}
			goto IL_0472;
			IL_0472:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_011a:
			int num23 = num << 1;
			int num24 = num + num23;
			int num25 = lengthcount / num24;
			IntPtr intPtr3 = (IntPtr)netsize;
			int num26 = num25 / ncycles;
			int num27;
			if (lengthcount < minpicturebytes)
			{
				num27 = 3;
			}
			else
			{
				int num28 = lengthcount / prime1;
				int num29 = num28 * prime1;
				object obj;
				if (lengthcount != num29)
				{
					obj = (long)intPtr3 + 4L;
				}
				else
				{
					int num30 = lengthcount / prime2;
					int num31 = num30 * prime2;
					if (lengthcount != num31)
					{
						obj = (long)intPtr3 + 8L;
					}
					else
					{
						int num32 = lengthcount / prime3;
						int num33 = num32 * prime3;
						obj = ((lengthcount == num33) ? ((object)((long)intPtr3 + 16L)) : ((object)((long)intPtr3 + 12L)));
					}
				}
				int num34 = obj << 1;
				num27 = obj + num34;
			}
			int num35 = num15;
			int num36 = 0;
			int num37 = initradius;
			int num38 = 0;
			while (true)
			{
				IL_0455:
				if (num36 >= num25)
				{
					return;
				}
				if (num38 >= array.Length)
				{
					break;
				}
				object obj2 = (long)intPtr;
				int num39 = num38 + 1;
				if (num39 >= array.Length)
				{
					break;
				}
				int num40 = num38 + 2;
				if (num40 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ X0_v16+B8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ X8_v28+1C]");
				int num41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ X8_v28+1C]");
				int num42 = 0;
				int b = array[num38] << num42;
				int g = array[num39] << num41;
				int r = array[num40] << num41;
				int i = Contest(b, g, r);
				Altersingle(num8, i, b, g, r);
				if (num35 != 0)
				{
					Alterneigh(num35, i, b, g, r);
				}
				num38 += num27;
				if (num38 >= lengthcount)
				{
					num38 -= lengthcount;
				}
				bool flag7 = num26 == 0;
				num36++;
				if (flag7)
				{
					num26 = 1;
				}
				int num43 = num36 / num26;
				int num44 = num43 * num26;
				bool flag8 = num36 != num44;
				intPtr = (IntPtr)typeof(NeuQuant);
				if (flag8)
				{
					continue;
				}
				int num45 = num8 / alphadec;
				num8 -= num45;
				intPtr = (IntPtr)typeof(NeuQuant);
				int num46 = num37 / radiusdec;
				int num47 = num37 - num46;
				int num48 = radiusbiasshift & 0x1F;
				int num49 = num47 >> num48;
				int num50 = num49 - 1;
				bool flag9 = num50 < 0;
				bool flag10 = num50 == 0;
				int num51 = num49 ^ 1;
				int num52 = num49 ^ num50;
				int num53 = num51 & num52;
				bool flag11 = num53 < 0;
				bool flag12 = flag9 == flag11;
				bool flag13 = !flag10;
				int num54 = ((flag12 && flag13) ? num49 : 0);
				bool flag14 = num54 < 1;
				num35 = num54;
				num37 = num47;
				if (flag14)
				{
					continue;
				}
				int num55 = num49 * num49;
				int num56 = 0;
				while (true)
				{
					int[] array3 = radpower;
					if (num56 >= array3.Length)
					{
						break;
					}
					int num57 = num56 * num56;
					int num58 = num55 - num57;
					int num59 = num56 + 1;
					int num60 = radbias * num58;
					int num61 = num60 / num55;
					int num62 = num61 * num8;
					array3[num56] = num62;
					bool flag15 = num59 < num54;
					num35 = num54;
					num37 = num47;
					if (flag15)
					{
						num56 = num59;
						continue;
					}
					goto IL_0455;
				}
				break;
			}
			goto IL_0472;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0xA40214", Offset = "0xA40214", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1F08420]);\n\tv39 = *([v38 @ X8_v33]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, b, g, r, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2021E7F]) = v55;\nL_001D:\n\tv56 = this.netindex;\n\tv59 = v56.Length < g;\n\tv60 = ~v59;\n\tv61 = v56.Length - g;\n\tv63 = v61 == 0;\n\tv68 = ~v60;\n\tv69 = v68 | v63;\n\tif (v69) goto L_01B7;\n\tv371 = v56[g @ X2 (System.Int32)] - 1;\n\tgoto L_00CA;\nL_0038:\n\tv526 = v371 < v169.Length;\n\tv150 = ~v526;\n\tif (v150) goto L_01B7;\n\tv170 = v169[v371 @ X9_v6 (System.Int32)];\n\tv544 = v170.Length < 1;\n\tv263 = ~v544;\n\tv256 = v170.Length - 1;\n\tv242 = v256 == 0;\n\tv545 = ~v263;\n\tv207 = v545 | v242;\n\tif (v207) goto L_01B7;\n\tv584 = g - v170[1];\n\tv336 = v584 >= v89;\n\tif (v336) goto L_00CA;\n\tv575 = v584 >= 0;\n\tif (v575) goto L_007B;\n\tv584 = -v584;\n\tgoto L_007B;\nL_007B:\n\tv610 = v170[0] - b;\n\tv189 = v170[0] >= b;\n\tif (v189) goto L_0082;\n\tv610 = -v610;\n\tgoto L_0082;\nL_0082:\n\tv194 = v610 + v584;\n\tv371 = v371 - 1;\n\tv337 = v194 >= v89;\n\tif (v337) goto L_00CA;\n\tv614 = v170.Length < 2;\n\tv264 = ~v614;\n\tv257 = v170.Length - 2;\n\tv243 = v257 == 0;\n\tv615 = ~v264;\n\tv208 = v615 | v243;\n\tif (v208) goto L_01B7;\n\tv187 = v170[2] - r;\n\tv190 = v170[2] >= r;\n\tif (v190) goto L_00AC;\n\tv187 = -v187;\n\tgoto L_00AC;\nL_00AC:\n\tv195 = v187 + v194;\n\tv338 = v195 >= v89;\n\tif (v338) goto L_00CA;\n\tv633 = v170.Length < 3;\n\tv265 = ~v633;\n\tv258 = v170.Length - 3;\n\tv244 = v258 == 0;\n\tv634 = ~v265;\n\tv209 = v634 | v244;\n\tif (v209) goto L_01B7;\n\tv172 = v170[3];\nL_00CA:\n\tgoto L_00D3;\n\tv464 = *([v451 @ X0_v12 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tgoto L_00D3;\n\tv472 = \"il2cpp_codegen_runtime_class_init\"(v451, b, g, r, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv467 = EM_Moments.Encoder.NeuQuant;\nL_00D3:\n\tv471 = v371 & 0x80000000;\n\tv310 = v471 == 0;\n\tif (v310) goto L_00E4;\n\tv288 = v417 >= v470.netsize;\n\tif (v288) goto L_01B6;\nL_00E4:\n\tgoto L_00F6;\n\tv486 = *([v308 @ X0_v13 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv487 = v486 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_00F6;\n\tv494 = \"il2cpp_codegen_runtime_class_init\"(v308, b, g, r, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv490 = EM_Moments.Encoder.NeuQuant;\n\tv518 = *([v490 @ X0_v19+B8]);\n\tv492 = *([v518 @ X8_v28]);\nL_00F6:\n\tv104 = v417 >= v470.netsize;\n\tif (v104) goto L_0189;\n\tv157 = this.network;\n\tv519 = v417 < v157.Length;\n\tv152 = ~v519;\n\tif (v152) goto L_01B7;\n\tv158 = v157[v417 @ X25_v8 (System.Int32)];\n\tv524 = v158.Length < 1;\n\tv266 = ~v524;\n\tv259 = v158.Length - 1;\n\tv245 = v259 == 0;\n\tv525 = ~v266;\n\tv210 = v525 | v245;\n\tif (v210) goto L_01B7;\n\tv196 = v158[1] - g;\n\tv423 = v196 >= v89;\n\tif (v423) goto L_018F;\n\tv540 = v196 >= 0;\n\tif (v540) goto L_0135;\n\tv196 = -v196;\n\tgoto L_0135;\nL_0135:\n\tv417 = v417 + 1;\n\tv582 = v158[0] - b;\n\tv191 = v158[0] >= b;\n\tif (v191) goto L_0146;\n\tv582 = -v582;\n\tgoto L_0146;\nL_0146:\n\tv274 = v582 + v196;\n\tv496 = v274 >= v89;\n\tif (v496) goto L_0189;\n\tv595 = v158.Length < 2;\n\tv267 = ~v595;\n\tv260 = v158.Length - 2;\n\tv246 = v260 == 0;\n\tv596 = ~v267;\n\tv211 = v596 | v246;\n\tif (v211) goto L_01B7;\n\tv197 = v158[2] - r;\n\tv192 = v158[2] >= r;\n\tif (v192) goto L_016F;\n\tv197 = -v197;\n\tgoto L_016F;\nL_016F:\n\tv275 = v197 + v274;\n\tv497 = v275 >= v89;\n\tif (v497) goto L_0189;\n\tv628 = v158.Length < 3;\n\tv268 = ~v628;\n\tv261 = v158.Length - 3;\n\tv247 = v261 == 0;\n\tv629 = ~v268;\n\tv212 = v629 | v247;\n\tif (v212) goto L_01B7;\n\tv172 = v158[3];\nL_0189:\n\tv516 = v371 & 0x80000000;\n\tv517 = v516 == 0;\n\tv454 = ~v517;\n\tif (v454) goto L_00CA;\n\tgoto L_01A3;\nL_018F:\n\tv542 = *([v162 @ X0_v14 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+12F]) & 2;\n\tv543 = v542 == 0;\n\tif (v543) goto L_0196;\n\tv548 = *([v162 @ X0_v14 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]) == 0;\n\tif (v548) goto L_019E;\nL_0196:\n\tv550 = v371 & 0x80000000;\n\tv551 = v550 == 0;\n\tv455 = ~v551;\n\tif (v455) goto L_00CA;\n\tgoto L_01A3;\nL_019E:\n\tv92 = v459.netsize;\n\tv578 = v371 & 0x80000000;\n\tv579 = v578 == 0;\n\tv456 = ~v579;\n\tif (v456) goto L_00CA;\nL_01A3:\n\tv169 = this.network;\n\tv523 = this.network == 0;\n\tv164 = ~v523;\n\tif (v164) goto L_0038;\n\tthrow System.NullReferenceException;\nL_01B6:\n\treturn v172;\nL_01B7:\n\tv277 = new System.IndexOutOfRangeException();\n\tthrow v277;\n\treturn returnVal2;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int Map(int b, int g, int r)
		{
			//IL_00a3: Expected I, but got O
			//IL_07f4: Expected I4, but got I8
			//IL_08ee: Expected I4, but got I8
			//IL_03bc: Expected O, but got I4
			//IL_011c: Expected O, but got I4
			//IL_0611: Expected I4, but got I8
			//IL_0673: Expected I4, but got I8
			//IL_069b: Expected I, but got O
			//IL_06b2: Expected I, but got O
			//IL_048f: Expected O, but got I4
			//IL_0209: Expected O, but got I4
			//IL_053e: Expected O, but got I4
			//IL_02b9: Expected O, but got I4
			int[] array = netindex;
			bool flag = array.Length < g;
			bool flag2 = !flag;
			int num = array.Length - g;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				int num2 = array[g] - 1;
				int num3 = 1000;
				int num4 = array[g];
				IntPtr intPtr = (IntPtr)typeof(NeuQuant);
				int result = -1;
				while (true)
				{
					if ((int)(num2 & 0x80000000L) != 0 && num4 >= netsize)
					{
						return result;
					}
					int num6;
					IntPtr intPtr2;
					if (num4 < netsize)
					{
						int[][] array2 = network;
						if (num4 >= array2.Length)
						{
							break;
						}
						int[] array3 = array2[num4];
						bool flag5 = array3.Length < 1;
						bool flag6 = !flag5;
						object obj = array3.Length - 1;
						bool flag7 = obj == null;
						bool flag8 = !flag6;
						if (flag8 || flag7)
						{
							break;
						}
						int num5 = array3[1] - g;
						if (num5 >= num3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v14 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+12F]");
							if (0u != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v14 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									num6 = netsize;
									int num7 = (int)(num2 & 0x80000000L);
									bool flag9 = num7 == 0;
									bool flag10 = !flag9;
									intPtr2 = (IntPtr)typeof(NeuQuant);
									num4 = netsize;
									intPtr = (IntPtr)typeof(NeuQuant);
									if (!flag10)
									{
										goto IL_06c0;
									}
									continue;
								}
							}
							int num8 = (int)(num2 & 0x80000000L);
							bool flag11 = num8 == 0;
							bool flag12 = !flag11;
							num4 = netsize;
							if (!flag12)
							{
								num6 = netsize;
								intPtr2 = intPtr;
								goto IL_06c0;
							}
							continue;
						}
						if (num5 < 0)
						{
							num5 = -num5;
						}
						num4++;
						int num9 = array3[0] - b;
						if (array3[0] < b)
						{
							num9 = -num9;
						}
						int num10 = num9 + num5;
						if (num10 < num3)
						{
							bool flag13 = array3.Length < 2;
							bool flag14 = !flag13;
							object obj2 = array3.Length - 2;
							bool flag15 = obj2 == null;
							bool flag16 = !flag14;
							if (flag16 || flag15)
							{
								break;
							}
							int num11 = array3[2] - r;
							if (array3[2] < r)
							{
								num11 = -num11;
							}
							int num12 = num11 + num10;
							if (num12 < num3)
							{
								bool flag17 = array3.Length < 3;
								bool flag18 = !flag17;
								object obj3 = array3.Length - 3;
								bool flag19 = obj3 == null;
								bool flag20 = !flag18;
								if (flag20 || flag19)
								{
									break;
								}
								result = array3[3];
								num3 = num12;
							}
						}
					}
					if ((int)(num2 & 0x80000000L) == 0)
					{
						num6 = num4;
						intPtr2 = intPtr;
						goto IL_06c0;
					}
					continue;
					IL_06c0:
					int[][] array4 = network;
					if (network != null)
					{
						if (num2 >= array4.Length)
						{
							break;
						}
						int[] array5 = array4[num2];
						bool flag21 = array5.Length < 1;
						bool flag22 = !flag21;
						object obj4 = array5.Length - 1;
						bool flag23 = obj4 == null;
						bool flag24 = !flag22;
						if (flag24 || flag23)
						{
							break;
						}
						int num13 = g - array5[1];
						bool flag25 = num13 >= num3;
						num4 = num6;
						num2 = -1;
						intPtr = intPtr2;
						if (flag25)
						{
							continue;
						}
						if (num13 < 0)
						{
							num13 = -num13;
						}
						int num14 = array5[0] - b;
						if (array5[0] < b)
						{
							num14 = -num14;
						}
						int num15 = num14 + num13;
						num2--;
						bool flag26 = num15 >= num3;
						num4 = num6;
						intPtr = intPtr2;
						if (flag26)
						{
							continue;
						}
						bool flag27 = array5.Length < 2;
						bool flag28 = !flag27;
						object obj5 = array5.Length - 2;
						bool flag29 = obj5 == null;
						bool flag30 = !flag28;
						if (flag30 || flag29)
						{
							break;
						}
						int num16 = array5[2] - r;
						if (array5[2] < r)
						{
							num16 = -num16;
						}
						int num17 = num16 + num15;
						bool flag31 = num17 >= num3;
						num4 = num6;
						intPtr = intPtr2;
						if (!flag31)
						{
							bool flag32 = array5.Length < 3;
							bool flag33 = !flag32;
							object obj6 = array5.Length - 3;
							bool flag34 = obj6 == null;
							bool flag35 = !flag33;
							if (flag35 || flag34)
							{
								break;
							}
							result = array5[3];
							num3 = num17;
							num4 = num6;
							intPtr = intPtr2;
						}
						continue;
					}
					throw new NullReferenceException();
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0xA401E0", Offset = "0xA401E0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEM_Moments.Encoder.NeuQuant::Learn(this);\n\tEM_Moments.Encoder.NeuQuant::Unbiasnet(this);\n\tEM_Moments.Encoder.NeuQuant::Inxbuild(this);\n\treturnVal1 = EM_Moments.Encoder.NeuQuant::ColorMap(this);\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public byte[] Process()
		{
			Learn();
			Unbiasnet();
			Inxbuild();
			return ColorMap();
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0xA42120", Offset = "0xA42120", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv26 = *([1EC5280]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021E80]) = v46;\n\tgoto L_00B6;\nL_001B:\n\tv133 = this.network;\n\tv181 = v98 < v133.Length;\n\tv182 = ~v181;\n\tif (v182) goto L_00D7;\n\tv56 = v133[v98 @ X20_v3 (System.Int32)];\n\tv278 = v56.Length == 0;\n\tif (v278) goto L_00D7;\n\tgoto L_003F;\n\tv283 = *([v107 @ X0_v4 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_003F;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v107, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv294 = EM_Moments.Encoder.NeuQuant;\n\tv289 = *([v294 @ X8_v22+B8]);\nL_003F:\n\tv291 = v288.netbiasshift & 0x1F;\n\tv292 = v56[0] >> v291;\n\tv56[0] = v292;\n\tv271 = this.network;\n\tv293 = v98 < v271.Length;\n\tv243 = ~v293;\n\tif (v243) goto L_00D7;\n\tv267 = v271[v98 @ X20_v3 (System.Int32)];\n\tv296 = v267.Length < 1;\n\tv244 = ~v296;\n\tv238 = v267.Length - 1;\n\tv226 = v238 == 0;\n\tv297 = ~v244;\n\tv191 = v297 | v226;\n\tif (v191) goto L_00D7;\n\tv301 = v299.netbiasshift & 0x1F;\n\tv253 = v267[1] >> v301;\n\tv267[1] = v253;\n\tv268 = this.network;\n\tv302 = v98 < v268.Length;\n\tv245 = ~v302;\n\tif (v245) goto L_00D7;\n\tv269 = v268[v98 @ X20_v3 (System.Int32)];\n\tv304 = v269.Length < 2;\n\tv246 = ~v304;\n\tv240 = v269.Length - 2;\n\tv228 = v240 == 0;\n\tv305 = ~v246;\n\tv192 = v305 | v228;\n\tif (v192) goto L_00D7;\n\tv309 = v307.netbiasshift & 0x1F;\n\tv255 = v269[2] >> v309;\n\tv269[2] = v255;\n\tv270 = this.network;\n\tv310 = v98 < v270.Length;\n\tv247 = ~v310;\n\tif (v247) goto L_00D7;\n\tv97 = v270[v98 @ X20_v3 (System.Int32)];\n\tv312 = v97.Length < 3;\n\tv84 = ~v312;\n\tv81 = v97.Length - 3;\n\tv75 = v81 == 0;\n\tv313 = ~v84;\n\tv51 = v313 | v75;\n\tif (v51) goto L_00D7;\n\tv97[3] = v98;\n\tv98 = v98 + 1;\nL_00B6:\n\tgoto L_00C9;\n\tv104 = *([v100 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tgoto L_00C9;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v100, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv108 = EM_Moments.Encoder.NeuQuant;\nL_00C9:\n\tv123 = v98 < v111.netsize;\n\tif (v123) goto L_001B;\n\treturn;\n\tv273 = new System.NullReferenceException();\nL_00D7:\n\tv279 = new System.IndexOutOfRangeException();\n\tthrow v279;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Unbiasnet()
		{
			//IL_00e2: Expected O, but got I4
			//IL_01c9: Expected O, but got I4
			//IL_02b0: Expected O, but got I4
			int num = 0;
			while (true)
			{
				if (num < netsize)
				{
					int[][] array = network;
					if (num >= array.Length)
					{
						break;
					}
					int[] array2 = array[num];
					if (array2.Length == 0)
					{
						break;
					}
					int num2 = netbiasshift & 0x1F;
					int num3 = array2[0] >> num2;
					array2[0] = num3;
					int[][] array3 = network;
					if (num >= array3.Length)
					{
						break;
					}
					int[] array4 = array3[num];
					bool flag = array4.Length < 1;
					bool flag2 = !flag;
					object obj = array4.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						break;
					}
					int num4 = netbiasshift & 0x1F;
					int num5 = array4[1] >> num4;
					array4[1] = num5;
					int[][] array5 = network;
					if (num >= array5.Length)
					{
						break;
					}
					int[] array6 = array5[num];
					bool flag5 = array6.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array6.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (flag8 || flag7)
					{
						break;
					}
					int num6 = netbiasshift & 0x1F;
					int num7 = array6[2] >> num6;
					array6[2] = num7;
					int[][] array7 = network;
					if (num >= array7.Length)
					{
						break;
					}
					int[] array8 = array7[num];
					bool flag9 = array8.Length < 3;
					bool flag10 = !flag9;
					object obj3 = array8.Length - 3;
					bool flag11 = obj3 == null;
					bool flag12 = !flag10;
					if (flag12 || flag11)
					{
						break;
					}
					array8[3] = num;
					num++;
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0xA41E24", Offset = "0xA41E24", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = *([1ED12D0]);\n\tv45 = *([v44 @ X8_v41]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, rad, i, b, g, r, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv62 = v38;\n\tv60 = v34;\n\tv58 = v36;\n\tv65 = 0 | 1;\n\t*([2021E81]) = v65;\nL_0025:\n\tv68 = i - rad;\n\tv79 = v68 < 0;\n\tif (v79) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\tv132 = i + rad;\n\tgoto L_0052;\n\tv88 = *([v83 @ X0_v2 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tgoto L_0052;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v83, rad, i, v61, v59, v57, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv96 = v38;\n\tv94 = v34;\n\tv92 = v36;\n\tv98 = EM_Moments.Encoder.NeuQuant;\nL_0052:\n\tv114 = v132 <= v101.netsize;\n\tif (v114) goto L_0067;\n\tv117 = *([v97 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+12F]) & 2;\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_0067;\n\tgoto L_0067;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v97, rad, i, v95, v93, v91, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv254 = EM_Moments.Encoder.NeuQuant;\n\tv127 = v38;\n\tv125 = v34;\n\tv123 = v36;\n\tv137 = *([v254 @ X8_v37+B8]);\n\tv133 = *([v137 @ X8_v38]);\nL_0067:\n\tv147 = i + 1;\n\tgoto L_00BC;\nL_006B:\n\tv513 = v191 < v381.Length;\n\tv371 = ~v513;\n\tif (v371) goto L_0169;\n\tv159 = v381[v191 @ X22_v2 (System.Int32)];\n\tv487 = v159.Length == 0;\n\tif (v487) goto L_0169;\n\tgoto L_008E;\n\tv544 = *([v533 @ X0_v15 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv545 = v544 == 0;\n\tv546 = ~v545;\n\tif (v546) goto L_008E;\n\tv564 = \"il2cpp_codegen_runtime_class_init\"(v533, rad, i, v235, v233, v231, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv550 = v38;\n\tv549 = v34;\n\tv548 = v36;\n\tv551 = EM_Moments.Encoder.NeuQuant;\n\tv552 = *([v159 @ X20_v8 (System.Int32[])+18]);\nL_008E:\n\tv554 = v159[0] - v186;\n\tv451 = v554 * v274[v198 @ X28_v3 (System.Int32)];\n\tv555 = v159.Length < 1;\n\tv476 = ~v555;\n\tv473 = v159.Length - 1;\n\tv467 = v473 == 0;\n\tv557 = v451 / v553.alpharadbias;\n\tv480 = v159[0] - v557;\n\tv159[0] = v480;\n\tv558 = ~v476;\n\tv149 = v558 | v467;\n\tif (v149) goto L_0169;\n\tv172 = v159.Length == 2;\n\tv568 = v159[1] - v184;\n\tv151 = v568 * v274[v198 @ X28_v3 (System.Int32)];\n\tv570 = v151 / v567.alpharadbias;\n\tv478 = v159[1] - v570;\n\tv159[1] = v478;\n\tif (v172) goto L_0169;\n\tv573 = v159[2] - v182;\n\tv154 = v573 * v274[v198 @ X28_v3 (System.Int32)];\n\tv575 = v154 / v572.alpharadbias;\n\tv194 = v159[2] - v575;\n\tv159[2] = v194;\nL_00BC:\n\tv191 = v191 - 1;\nL_00C8:\n\tv253 = v191 > v82;\n\tif (v253) goto L_00D5;\n\tv264 = v147 >= v132;\n\tif (v264) goto L_0168;\nL_00D5:\n\tv274 = this.radpower;\n\tv337 = v198 < v274.Length;\n\tv338 = ~v337;\n\tif (v338) goto L_0169;\n\tv346 = v147 >= v132;\n\tif (v346) goto L_0150;\n\tv383 = this.network;\n\tv511 = v147 < v383.Length;\n\tv373 = ~v511;\n\tif (v373) goto L_0169;\n\tv347 = v383[v147 @ X27_v8 (System.Int32)];\n\tv488 = v347.Length == 0;\n\tif (v488) goto L_0169;\n\tgoto L_0118;\n\tv518 = *([v514 @ X0_v19 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv519 = v518 == 0;\n\tv520 = ~v519;\n\tif (v520) goto L_0118;\n\tv537 = \"il2cpp_codegen_runtime_class_init\"(v514, rad, i, v234, v232, v230, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv524 = v38;\n\tv523 = v34;\n\tv522 = v36;\n\tv525 = EM_Moments.Encoder.NeuQuant;\n\tv526 = *([v347 @ X20_v9 (System.Int32[])+18]);\nL_0118:\n\tv528 = v347[0] - v186;\n\tv452 = v528 * v274[v198 @ X28_v3 (System.Int32)];\n\tv529 = v347.Length < 1;\n\tv477 = ~v529;\n\tv474 = v347.Length - 1;\n\tv468 = v474 == 0;\n\tv531 = v452 / v527.alpharadbias;\n\tv481 = v347[0] - v531;\n\tv347[0] = v481;\n\tv532 = ~v477;\n\tv447 = v532 | v468;\n\tif (v447) goto L_0169;\n\tv466 = v347.Length == 2;\n\tv541 = v347[1] - v184;\n\tv448 = v541 * v274[v198 @ X28_v3 (System.Int32)];\n\tv543 = v448 / v540.alpharadbias;\n\tv479 = v347[1] - v543;\n\tv347[1] = v479;\n\tif (v466) goto L_0169;\n\tv147 = v147 + 1;\n\tv561 = v347[2] - v182;\n\tv497 = v561 * v274[v198 @ X28_v3 (System.Int32)];\n\tv563 = v497 / v560.alpharadbias;\n\tv507 = v347[2] - v563;\n\tv347[2] = v507;\nL_0150:\n\tv198 = v198 + 1;\n\tv201 = v191 <= v82;\n\tif (v201) goto L_00C8;\n\tv381 = this.network;\n\tv512 = this.network == 0;\n\tv377 = ~v512;\n\tif (v377) goto L_006B;\n\tthrow System.NullReferenceException;\nL_0168:\n\treturn;\nL_0169:\n\tv494 = new System.IndexOutOfRangeException();\n\tthrow v494;\n\treturn;\n// 218 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void Alterneigh(int rad, int i, int b, int g, int r)
		{
			//IL_0439: Expected I, but got O
			//IL_05cd: Expected O, but got I4
			//IL_04db: Expected O, but got I4
			int num = i - rad;
			int num2 = ((num < 0) ? (-1) : num);
			int num3 = i + rad;
			IntPtr intPtr = (IntPtr)typeof(NeuQuant);
			if (num3 > netsize)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+12F]");
				num3 = ((0u != 0) ? netsize : netsize);
			}
			int num4 = i + 1;
			int num5 = 1;
			int num6 = i;
			int num8 = default(int);
			int num13 = default(int);
			int num18 = default(int);
			while (true)
			{
				num6--;
				int[] array;
				int[] array5;
				while (true)
				{
					if (num6 <= num2 && num4 >= num3)
					{
						return;
					}
					array = radpower;
					if (num5 < array.Length)
					{
						if (num4 >= num3)
						{
							goto IL_0547;
						}
						int[][] array2 = network;
						if (num4 < array2.Length)
						{
							int[] array3 = array2[num4];
							if (array3.Length != 0)
							{
								int num7 = array3[0] - num8;
								int num9 = num7 * array[num5];
								bool flag = array3.Length < 1;
								bool flag2 = !flag;
								object obj = array3.Length - 1;
								bool flag3 = obj == null;
								int num10 = num9 / alpharadbias;
								int num11 = array3[0] - num10;
								array3[0] = num11;
								bool flag4 = !flag2;
								if (!(flag4 || flag3))
								{
									bool flag5 = array3.Length == 2;
									int num12 = array3[1] - num13;
									int num14 = num12 * array[num5];
									int num15 = num14 / alpharadbias;
									int num16 = array3[1] - num15;
									array3[1] = num16;
									if (!flag5)
									{
										num4++;
										int num17 = array3[2] - num18;
										int num19 = num17 * array[num5];
										int num20 = num19 / alpharadbias;
										int num21 = array3[2] - num20;
										array3[2] = num21;
										goto IL_0547;
									}
								}
							}
						}
					}
					goto IL_03e6;
					IL_03e6:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0547:
					num5++;
					if (num6 <= num2)
					{
						continue;
					}
					int[][] array4 = network;
					if (network != null)
					{
						if (num6 < array4.Length)
						{
							array5 = array4[num6];
							if (array5.Length != 0)
							{
								int num22 = array5[0] - num8;
								int num23 = num22 * array[num5];
								bool flag6 = array5.Length < 1;
								bool flag7 = !flag6;
								object obj2 = array5.Length - 1;
								bool flag8 = obj2 == null;
								int num24 = num23 / alpharadbias;
								int num25 = array5[0] - num24;
								array5[0] = num25;
								bool flag9 = !flag7;
								if (!(flag9 || flag8))
								{
									bool flag10 = array5.Length == 2;
									int num26 = array5[1] - num13;
									int num27 = num26 * array[num5];
									int num28 = num27 / alpharadbias;
									int num29 = array5[1] - num28;
									array5[1] = num29;
									if (!flag10)
									{
										break;
									}
								}
							}
						}
						goto IL_03e6;
					}
					throw new NullReferenceException();
				}
				int num30 = array5[2] - num18;
				int num31 = num30 * array[num5];
				int num32 = num31 / alpharadbias;
				int num33 = array5[2] - num32;
				array5[2] = num33;
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0xA41CD8", Offset = "0xA41CD8", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1F0DF80]);\n\tv39 = *([v38 @ X8_v17]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, alpha, i, b, g, r, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2021E82]) = v53;\nL_001D:\n\tv54 = this.network;\n\tv57 = v54.Length < i;\n\tv58 = ~v57;\n\tv59 = v54.Length - i;\n\tv61 = v59 == 0;\n\tv66 = ~v58;\n\tv67 = v66 | v61;\n\tif (v67) goto L_007E;\n\tv121 = v54[i @ X2 (System.Int32)];\n\tv153 = v121.Length == 0;\n\tif (v153) goto L_007E;\n\tgoto L_0045;\n\tv204 = *([v200 @ X0_v8 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0045;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v200, alpha, i, b, g, r, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv208 = EM_Moments.Encoder.NeuQuant;\n\tv209 = *([v121 @ X23_v4 (System.Int32[])+18]);\nL_0045:\n\tv211 = v121[0] - b;\n\tv131 = v211 * alpha;\n\tv212 = v121.Length < 1;\n\tv148 = ~v212;\n\tv146 = v121.Length - 1;\n\tv142 = v146 == 0;\n\tv214 = v131 / v210.initalpha;\n\tv150 = v121[0] - v214;\n\tv121[0] = v150;\n\tv215 = ~v148;\n\tv132 = v215 | v142;\n\tif (v132) goto L_007E;\n\tv141 = v121.Length == 2;\n\tv220 = v121[1] - g;\n\tv129 = v220 * alpha;\n\tv222 = v129 / v219.initalpha;\n\tv149 = v121[1] - v222;\n\tv121[1] = v149;\n\tif (v141) goto L_007E;\n\tv225 = v121[2] - r;\n\tv166 = v225 * alpha;\n\tv227 = v166 / v224.initalpha;\n\tv194 = v121[2] - v227;\n\tv121[2] = v194;\n\treturn;\nL_007E:\n\tv159 = new System.IndexOutOfRangeException();\n\tthrow v159;\n\tthrow System.NullReferenceException;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void Altersingle(int alpha, int i, int b, int g, int r)
		{
			//IL_01e1: Expected O, but got I4
			int[][] array = network;
			bool flag = array.Length < i;
			bool flag2 = !flag;
			int num = array.Length - i;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				int[] array2 = array[i];
				if (array2.Length != 0)
				{
					int num2 = array2[0] - b;
					int num3 = num2 * alpha;
					bool flag5 = array2.Length < 1;
					bool flag6 = !flag5;
					object obj = array2.Length - 1;
					bool flag7 = obj == null;
					int num4 = num3 / initalpha;
					int num5 = array2[0] - num4;
					array2[0] = num5;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						bool flag9 = array2.Length == 2;
						int num6 = array2[1] - g;
						int num7 = num6 * alpha;
						int num8 = num7 / initalpha;
						int num9 = array2[1] - num8;
						array2[1] = num9;
						if (!flag9)
						{
							int num10 = array2[2] - r;
							int num11 = num10 * alpha;
							int num12 = num11 / initalpha;
							int num13 = array2[2] - num12;
							array2[2] = num13;
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0xA41A08", Offset = "0xA41A08", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv40 = *([1EC8570]);\n\tv41 = *([v40 @ X8_v29]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, b, g, r, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2021E83]) = v57;\n\tgoto L_012E;\nL_0026:\n\tv159 = this.network;\n\tv303 = v65 < v159.Length;\n\tv262 = ~v303;\n\tif (v262) goto L_0189;\n\tv276 = v159[v65 @ X26_v2 (System.Int32)];\n\tv349 = v276.Length == 0;\n\tif (v349) goto L_0189;\n\tv325 = v276.Length == 1;\n\tif (v325) goto L_0189;\n\tv418 = v276.Length < 2;\n\tv338 = ~v418;\n\tv334 = v276.Length - 2;\n\tv326 = v334 == 0;\n\tv419 = ~v338;\n\tv308 = v419 | v326;\n\tif (v308) goto L_0189;\n\tv452 = v276[0] - b;\n\tv439 = v276[1] - g;\n\tv436 = v276[1] >= g;\n\tif (v436) goto L_0073;\n\tv439 = -v439;\n\tgoto L_0073;\nL_0073:\n\tv449 = v452 >= 0;\n\tif (v449) goto L_0082;\n\tv452 = -v452;\n\tgoto L_0082;\nL_0082:\n\tv196 = v276[2] - r;\n\tv272 = v439 + v452;\n\tv279 = this.bias;\n\tv463 = v276[2] >= r;\n\tif (v463) goto L_008B;\n\tv196 = -v196;\n\tgoto L_008B;\nL_008B:\n\tv177 = v272 + v196;\n\tv258 = v177 - v76;\n\tv251 = v258 < 0;\n\tv237 = v177 ^ v76;\n\tv230 = v177 ^ v258;\n\tv223 = v237 & v230;\n\tv216 = v223 < 0;\n\tv467 = v251 == v216;\n\tv468 = ~v467;\n\tv469 = ~v468;\n\tif (v469) goto L_009D;\n\tgoto L_009D;\nL_009D:\n\tv472 = v251 == v216;\n\tv200 = ~v472;\n\tv190 = ~v200;\n\tif (v190) goto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tv475 = v65 < v279.Length;\n\tv339 = ~v475;\n\tif (v339) goto L_0189;\n\tgoto L_00C2;\n\tv480 = *([v139 @ X0_v4 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_00C2;\n\tv495 = \"il2cpp_codegen_runtime_class_init\"(v139, b, g, r, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv484 = EM_Moments.Encoder.NeuQuant;\n\tv486 = *([v484 @ X0_v18+B8]);\nL_00C2:\n\tv347 = this.freq;\n\tv488 = v296.intbiasshift - v296.netbiasshift;\n\tv489 = v488 & 0x1F;\n\tv490 = v279[v65 @ X26_v2 (System.Int32)] >> v489;\n\tv273 = v177 - v490;\n\tv259 = v273 - v70;\n\tv252 = v259 < 0;\n\tv238 = v273 ^ v70;\n\tv231 = v273 ^ v259;\n\tv224 = v238 & v231;\n\tv217 = v224 < 0;\n\tv492 = v252 == v217;\n\tv493 = ~v492;\n\tv494 = ~v493;\n\tif (v494) goto L_00D8;\n\tgoto L_00D8;\nL_00D8:\n\tv498 = v252 == v217;\n\tv87 = ~v498;\n\tv78 = ~v87;\n\tif (v78) goto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tv501 = v65 < v347.Length;\n\tv263 = ~v501;\n\tif (v263) goto L_0189;\n\tgoto L_00FF;\n\tv270 = *([v285 @ X0_v14 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv505 = v270 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_00FF;\n\tv277 = v28.freq;\n\tv515 = EM_Moments.Encoder.NeuQuant;\n\tv508 = *([v515 @ X8_v23 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+B8]);\nL_00FF:\n\tv509 = v65 < v347.Length;\n\tv264 = ~v509;\n\tif (v264) goto L_0189;\n\tv513 = v351.betashift & 0x1F;\n\tv297 = v347[v65 @ X26_v2 (System.Int32)] >> v513;\n\tv271 = v347[v65 @ X26_v2 (System.Int32)] - v297;\n\tv347[v65 @ X26_v2 (System.Int32)] = v271;\n\tv278 = this.bias;\n\tv514 = v65 < v278.Length;\n\tv116 = ~v514;\n\tif (v116) goto L_0189;\n\tv66 = v65 + 1;\n\tv119 = v517.gammashift & 0x1F;\n\tv519 = v297 << v119;\n\tv129 = v519 + v278[v65 @ X26_v2 (System.Int32)];\n\tv278[v65 @ X26_v2 (System.Int32)] = v129;\nL_012E:\n\tgoto L_0141;\n\tv136 = *([v132 @ X0_v3 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tgoto L_0141;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v132, b, g, r, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv140 = EM_Moments.Encoder.NeuQuant;\nL_0141:\n\tv155 = v65 < v143.netsize;\n\tif (v155) goto L_0026;\n\tv157 = this.freq;\n\tv162 = v74 < v157.Length;\n\tv163 = ~v162;\n\tif (v163) goto L_0189;\n\tv207 = v74 << 2;\n\tv304 = v157 + v207;\n\tv178 = v304 + 0x20;\n\tgoto L_0162;\n\tv354 = *([v139 @ X0_v4 (Il2CppClass<EM_Moments.Encoder.NeuQuant>)+E0]);\n\tv355 = v354 == 0;\n\tv356 = ~v355;\n\tif (v356) goto L_0162;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v139, b, g, r, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv414 = EM_Moments.Encoder.NeuQuant;\n\tv360 = *([v414 @ X8_v14+B8]);\nL_0162:\n\tv362 = v359.beta + *([v178 @ X22_v5]);\n\t*([v178 @ X22_v5]) = v362;\n\tv298 = this.bias;\n\tv412 = v74 < v298.Length;\n\tv340 = ~v412;\n\tif (v340) goto L_0189;\n\tv400 = v298[v74 @ X25_v6 (System.Int32)] - v416.betagamma;\n\tv298[v74 @ X25_v6 (System.Int32)] = v400;\n\treturn v131;\nL_0189:\n\tv352 = new System.IndexOutOfRangeException();\n\tthrow v352;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 247 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected int Contest(int b, int g, int r)
		{
			//IL_0339: Expected O, but got I
			//IL_0348: Expected O, but got I
			//IL_066c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0671: Expected O, but got Unknown
			//IL_00bd: Expected O, but got I4
			int num = 0;
			int num2 = int.MaxValue;
			int num3 = -1;
			int num4 = int.MaxValue;
			int result = -1;
			while (true)
			{
				if (num < netsize)
				{
					int[][] array = network;
					if (num >= array.Length)
					{
						break;
					}
					int[] array2 = array[num];
					if (array2.Length == 0 || array2.Length == 1)
					{
						break;
					}
					bool flag = array2.Length < 2;
					bool flag2 = !flag;
					object obj = array2.Length - 2;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (flag4 || flag3)
					{
						break;
					}
					int num5 = array2[0] - b;
					int num6 = array2[1] - g;
					if (array2[1] < g)
					{
						num6 = -num6;
					}
					if (num5 < 0)
					{
						num5 = -num5;
					}
					int num7 = array2[2] - r;
					int num8 = num6 + num5;
					int[] array3 = bias;
					if (array2[2] < r)
					{
						num7 = -num7;
					}
					int num9 = num8 + num7;
					int num10 = num9 - num4;
					bool flag5 = num10 < 0;
					int num11 = num9 ^ num4;
					int num12 = num9 ^ num10;
					int num13 = num11 & num12;
					bool flag6 = num13 < 0;
					if (flag5 != flag6)
					{
						num4 = num9;
					}
					if (flag5 != flag6)
					{
						num3 = num;
					}
					if (num >= array3.Length)
					{
						break;
					}
					int[] array4 = freq;
					int num14 = intbiasshift - netbiasshift;
					int num15 = num14 & 0x1F;
					int num16 = array3[num] >> num15;
					int num17 = num9 - num16;
					int num18 = num17 - num2;
					bool flag7 = num18 < 0;
					int num19 = num17 ^ num2;
					int num20 = num17 ^ num18;
					int num21 = num19 & num20;
					bool flag8 = num21 < 0;
					if (flag7 != flag8)
					{
						num2 = num17;
					}
					if (flag7 != flag8)
					{
						result = num;
					}
					if (num >= array4.Length || num >= array4.Length)
					{
						break;
					}
					int num22 = betashift & 0x1F;
					int num23 = array4[num] >> num22;
					int num24 = array4[num] - num23;
					array4[num] = num24;
					int[] array5 = bias;
					if (num >= array5.Length)
					{
						break;
					}
					int num25 = num + 1;
					int num26 = gammashift & 0x1F;
					int num27 = num23 << num26;
					int num28 = num27 + array5[num];
					array5[num] = num28;
					num = num25;
					continue;
				}
				int[] array6 = freq;
				if (num3 >= array6.Length)
				{
					break;
				}
				int num29 = num3 << 2;
				object obj2 = (long)(IntPtr)array6 + (long)num29;
				object obj3 = (long)(IntPtr)obj2 + 32L;
				object obj4 = beta + obj3;
				obj3 = obj4;
				int[] array7 = bias;
				if (num3 >= array7.Length)
				{
					break;
				}
				int num30 = array7[num3] - betagamma;
				array7[num3] = num30;
				return result;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0xA422E4", Offset = "0xA422E4", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7F08]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021E84]) = v35;\nL_0017:\n\tv41.netsize = 0x100;\n\tv44.prime1 = 0x1F3;\n\tv46.prime2 = 0x1EB;\n\tv47.prime3 = 0x1E7;\n\tv49.prime4 = 0x1F7;\n\tv53 = v51.prime4 << 1;\n\tv54 = v51.prime4 + v53;\n\tv51.minpicturebytes = v54;\n\tv57 = v55.netsize - 1;\n\tv55.maxnetpos = v57;\n\tv58.netbiasshift = 4;\n\tv60.ncycles = 0x64;\n\tv62.intbiasshift = 0x10;\n\tv67 = v64.intbiasshift & 0x1F;\n\tv68 = 1 << v67;\n\tv64.intbias = v68;\n\tv69.gammashift = 0xA;\n\tv73 = v71.gammashift & 0x1F;\n\tv74 = 1 << v73;\n\tv71.gamma = v74;\n\tv75.betashift = 0xA;\n\tv79 = v76.betashift & 0x1F;\n\tv80 = v76.intbias >> v79;\n\tv76.beta = v80;\n\tv85 = v81.gammashift - v81.betashift;\n\tv86 = v85 & 0x1F;\n\tv87 = v81.intbias << v86;\n\tv81.betagamma = v87;\n\tv90 = v88.netsize >> 3;\n\tv88.initrad = v90;\n\tv91.radiusbiasshift = 6;\n\tv95 = v93.radiusbiasshift & 0x1F;\n\tv96 = 1 << v95;\n\tv93.radiusbias = v96;\n\tv100 = v97.radiusbias * v97.initrad;\n\tv97.initradius = v100;\n\tv101.radiusdec = 0x1E;\n\tv103.alphabiasshift = 0xA;\n\tv107 = v105.alphabiasshift & 0x1F;\n\tv108 = 1 << v107;\n\tv105.initalpha = v108;\n\tv109.radbiasshift = 8;\n\tv113 = v111.radbiasshift & 0x1F;\n\tv114 = 1 << v113;\n\tv111.radbias = v114;\n\tv118 = v115.radbiasshift + v115.alphabiasshift;\n\tv115.alpharadbshift = v118;\n\tv121 = v119.alpharadbshift & 0x1F;\n\tv122 = 1 << v121;\n\tv119.alpharadbias = v122;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static NeuQuant()
		{
			int num = prime4 << 1;
			int num2 = prime4 + num;
			minpicturebytes = num2;
			int num3 = netsize - 1;
			maxnetpos = num3;
			netbiasshift = 4;
			ncycles = 100;
			intbiasshift = 16;
			int num4 = intbiasshift & 0x1F;
			int num5 = 1 << num4;
			intbias = num5;
			gammashift = 10;
			int num6 = gammashift & 0x1F;
			int num7 = 1 << num6;
			gamma = num7;
			betashift = 10;
			int num8 = betashift & 0x1F;
			int num9 = intbias >> num8;
			beta = num9;
			int num10 = gammashift - betashift;
			int num11 = num10 & 0x1F;
			int num12 = intbias << num11;
			betagamma = num12;
			int num13 = netsize >> 3;
			initrad = num13;
			radiusbiasshift = 6;
			int num14 = radiusbiasshift & 0x1F;
			int num15 = 1 << num14;
			radiusbias = num15;
			int num16 = radiusbias * initrad;
			initradius = num16;
			radiusdec = 30;
			alphabiasshift = 10;
			int num17 = alphabiasshift & 0x1F;
			int num18 = 1 << num17;
			initalpha = num18;
			radbiasshift = 8;
			int num19 = radbiasshift & 0x1F;
			int num20 = 1 << num19;
			radbias = num20;
			int num21 = radbiasshift + alphabiasshift;
			alpharadbshift = num21;
			int num22 = alpharadbshift & 0x1F;
			int num23 = 1 << num22;
			alpharadbias = num23;
		}
	}
}
