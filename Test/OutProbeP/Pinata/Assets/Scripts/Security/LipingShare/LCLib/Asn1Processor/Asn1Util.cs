using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LipingShare.LCLib.Asn1Processor
{
	[Token(Token = "0x2000021")]
	internal class Asn1Util
	{
		[Token(Token = "0x400004F")]
		private static char[] hexDigits = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F'
		};

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15D0B00", Offset = "0x15D0B00", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv38 = *([1EACE78]);\n\tv39 = *([v38 @ X8_v24]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, lineLen, groupLen, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2029A0F]) = v56;\nL_0022:\n\tv61 = inStr.m_stringLength << 1;\n\t// 36 NewArr v63 @ X0_v8 (System.Char[]), typeof(System.Char[]), v61 @ X1_v3 (System.Int32)\n\tv203 = inStr.m_stringLength < 1;\n\tif (v203) goto L_00B7;\nL_003C:\n\tv164 = System.String::get_Chars(inStr, v102);\n\tv315 = v98 < v63.Length;\n\tv316 = ~v315;\n\tif (v316) goto L_00F9;\n\tv258 = v98 + 1;\n\tv90 = v90 + 1;\n\tv63[v98 @ X25_v7 (System.Int32)] = v164;\n\tv340 = groupLen < 1;\n\tif (v340) goto L_0079;\n\tv347 = v90 < groupLen;\n\tif (v347) goto L_0079;\n\tv421 = v258 < v63.Length;\n\tv370 = ~v421;\n\tif (v370) goto L_00F9;\n\tv409 = v98 + 2;\n\tv63[v258 @ X8_v18 (System.Int32)] = 0x20;\nL_0079:\n\tv94 = v94 + 1;\n\tv348 = v94 < lineLen;\n\tif (v348) goto L_00A6;\n\tv422 = v258 < v63.Length;\n\tv371 = ~v422;\n\tif (v371) goto L_00F9;\n\tv63[v258 @ X8_v18 (System.Int32)] = 0xD;\n\tv376 = v258 + 1;\n\tv440 = v376 < v63.Length;\n\tv372 = ~v440;\n\tif (v372) goto L_00F9;\n\tv258 = v258 + 2;\n\tv63[v376 @ X9_v18 (System.Int32)] = 0xA;\nL_00A6:\n\tv102 = v102 + 1;\n\tv244 = v102 < inStr.m_stringLength;\n\tif (v244) goto L_003C;\nL_00B7:\n\tv261 = System.String::CreateString(0, v63);\n\t// 190 NewArr v165 @ X0_v16 (System.Char[]), typeof(System.Char[]), 1\n\tv325 = System.String::TrimEnd(v261, v165);\n\t// 201 NewArr v166 @ X0_v20 (System.Char[]), typeof(System.Char[]), 1\n\tv380 = v166.Length == 0;\n\tif (v380) goto L_00F9;\n\tv166[0] = 0xA;\n\tv443 = System.String::TrimEnd(v325, v166);\n\t// 220 NewArr v167 @ X0_v24 (System.Char[]), typeof(System.Char[]), 1\n\tv381 = v167.Length == 0;\n\tif (v381) goto L_00F9;\n\tv167[0] = 0xD;\n\treturnVal2 = System.String::TrimEnd(v443, v167);\n\treturn returnVal2;\nL_00F9:\n\tv383 = new System.IndexOutOfRangeException();\n\tthrow v383;\n\tv191 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 196 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string FormatString(string inStr, int lineLen, int groupLen)
		{
			int num = inStr.Length << 1;
			char[] array = new char[num];
			if (inStr.Length < 1)
			{
				goto IL_01fe;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			while (true)
			{
				char c = inStr.get_Chars(num5);
				if (num4 >= array.Length)
				{
					break;
				}
				int num6 = num4 + 1;
				num2++;
				array[num4] = c;
				if (groupLen >= 1 && num2 >= groupLen)
				{
					if (num6 >= array.Length)
					{
						break;
					}
					int num7 = num4 + 2;
					array[num6] = ' ';
					num2 = 0;
					num6 = num7;
				}
				num3++;
				if (num3 >= lineLen)
				{
					if (num6 >= array.Length)
					{
						break;
					}
					array[num6] = '\r';
					int num8 = num6 + 1;
					if (num8 >= array.Length)
					{
						break;
					}
					num6 += 2;
					array[num8] = '\n';
					num3 = 0;
				}
				num5++;
				bool flag = num5 < inStr.Length;
				num4 = num6;
				if (flag)
				{
					continue;
				}
				goto IL_01fe;
			}
			goto IL_02eb;
			IL_01fe:
			string text = ((string)null).CreateString(array);
			char[] trimChars = new char[1];
			string text2 = text.TrimEnd(trimChars);
			char[] array2 = new char[1];
			if (array2.Length != 0)
			{
				array2[0] = '\n';
				string text3 = text2.TrimEnd(array2);
				char[] array3 = new char[1];
				if (array3.Length != 0)
				{
					array3[0] = '\r';
					return text3.TrimEnd(array3);
				}
			}
			goto IL_02eb;
			IL_02eb:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x15CEAA4", Offset = "0x15CEAA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF74F8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, xch, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A10]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Char[]), typeof(System.Char[]), len @ X0 (System.Int32)\n\tv58 = len < 1;\n\tif (v58) goto L_004E;\nL_002D:\n\tv141 = v109 < v46.Length;\n\tv127 = ~v141;\n\tif (v127) goto L_0050;\n\tv46[v109 @ X9_v4 (System.Int32)] = xch;\n\tv109 = v109 + 1;\n\tv73 = v109 < len;\n\tif (v73) goto L_002D;\nL_004E:\n\treturnVal1 = System.String::CreateString(0, v46);\n\treturn returnVal1;\nL_0050:\n\tv166 = new System.IndexOutOfRangeException();\n\tthrow v166;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GenStr(int len, char xch)
		{
			char[] array = new char[len];
			if (len >= 1)
			{
				int num = 0;
				do
				{
					if (num < array.Length)
					{
						array[num] = xch;
						num++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num < len);
			}
			return ((string)null).CreateString(array);
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x15D07A4", Offset = "0x15D07A4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = bytes.Length << 0x20;\n\tv20 = v9 < 1;\n\tif (v20) goto L_FFFFFFFF;\nL_0018:\n\tv111 = v66 < bytes.Length;\n\tv63 = ~v111;\n\tif (v63) goto L_003B;\n\tv109 = v66 + 1;\n\tv151 = v36 & 0xFFFFFFFFFFFFFF;\n\tv110 = v151 << 8;\n\tv152 = bytes[v66 @ X9_v5 (System.Int32)] & 0xFF;\n\tv90 = v152 | v110;\n\tv92 = v109 < bytes.Length;\n\tif (v92) goto L_0018;\n\tgoto L_003A;\nL_003A:\n\treturn returnVal2;\nL_003B:\n\tv154 = new System.IndexOutOfRangeException();\n\tthrow v154;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long BytesToLong(byte[] bytes)
		{
			//IL_00da: Expected I8, but got I4
			//IL_0064: Expected I4, but got I8
			//IL_00cc: Expected I8, but got I4
			int num = bytes.Length << 32;
			if (num >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				while (num3 < bytes.Length)
				{
					int num4 = num3 + 1;
					int num5 = (int)(num2 & 0xFFFFFFFFFFFFFFL);
					int num6 = num5 << 8;
					int num7 = bytes[num3] & 0xFF;
					int num8 = num7 | num6;
					bool flag = num4 < bytes.Length;
					num2 = num8;
					num3 = num4;
					if (!flag)
					{
						return num8;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return 0L;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15D0688", Offset = "0x15D0688", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAB0A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A11]) = v38;\nL_0016:\n\tv42 = bytes == 0;\n\tif (v42) goto L_0080;\n\tv54 = bytes.Length < 1;\n\tif (v54) goto L_0080;\n\t// 40 NewArr v81 @ X0_v4 (System.Char[]), typeof(System.Char[]), bytes.Length\n\tv172 = bytes.Length;\n\tv165 = bytes.Length < 1;\n\tif (v165) goto L_0069;\nL_0039:\n\tv203 = v191 < v172;\n\tv204 = ~v203;\n\tif (v204) goto L_0081;\n\tv217 = bytes[v191 @ X9_v4 (System.Int32)] == 0;\n\tif (v217) goto L_0059;\n\tv259 = v170 < v81.Length;\n\tv236 = ~v259;\n\tif (v236) goto L_0081;\n\tv81[v170 @ X11_v5 (System.Int32)] = bytes[v191 @ X9_v4 (System.Int32)];\n\tv172 = bytes.Length;\n\tv170 = v170 + 1;\nL_0059:\n\tv191 = v191 + 1;\n\tv173 = v191 < v172;\n\tif (v173) goto L_0039;\nL_0069:\n\tv187 = System.String::CreateString(0, v81);\n\t// 110 NewArr v215 @ X0_v11 (System.Char[]), typeof(System.Char[]), 1\n\treturnVal2 = System.String::TrimEnd(v187, v215);\n\treturn returnVal2;\nL_0080:\n\treturn \"\";\nL_0081:\n\tv239 = new System.IndexOutOfRangeException();\n\tthrow v239;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string BytesToString(byte[] bytes)
		{
			if (bytes != null && bytes.Length >= 1)
			{
				char[] array = new char[bytes.Length];
				int num = bytes.Length;
				if (bytes.Length >= 1)
				{
					int num2 = 0;
					int num3 = 0;
					while (true)
					{
						if (num3 < num)
						{
							if (bytes[num3] != 0)
							{
								if (num2 >= array.Length)
								{
									goto IL_0136;
								}
								array[num2] = (char)bytes[num3];
								num = bytes.Length;
								num2++;
							}
							num3++;
							if (num3 >= num)
							{
								break;
							}
							continue;
						}
						goto IL_0136;
						IL_0136:
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
				}
				string text = ((string)null).CreateString(array);
				char[] trimChars = new char[1];
				return text.TrimEnd(trimChars);
			}
			return "";
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x15CE350", Offset = "0x15CE350", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED5080]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029A12]) = v46;\nL_0017:\n\tv47 = bytes == 0;\n\tif (v47) goto L_00B7;\n\tv52 = bytes.Length << 1;\n\t// 30 NewArr v53 @ X0_v4 (System.Char[]), typeof(System.Char[]), v52 @ X1_v1 (System.Int32)\n\tv208 = bytes.Length;\n\tv77 = bytes.Length < 1;\n\tif (v77) goto L_00A9;\nL_0031:\n\tv209 = v103 < v208;\n\tv210 = ~v209;\n\tif (v210) goto L_00B8;\n\tgoto L_0049;\n\tv282 = *([v218 @ X0_v15 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Util>)+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_0049;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v218, v52, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv285 = LipingShare.LCLib.Asn1Processor.Asn1Util;\nL_0049:\n\tv279 = v288.hexDigits;\n\tv272 = bytes[v103 @ X21_v5 (System.Int32)] >> 4;\n\tv293 = v272 < v279.Length;\n\tv267 = ~v293;\n\tif (v267) goto L_00B8;\n\tv228 = v100 - 1;\n\tv297 = v228 < v53.Length;\n\tv268 = ~v297;\n\tif (v268) goto L_00B8;\n\tv53[v228 @ X10_v6 (System.Int32)] = v279[v272 @ X9_v7 (System.Int32)];\n\tv280 = v302.hexDigits;\n\tv273 = bytes[v103 @ X21_v5 (System.Int32)] & 0xF;\n\tv303 = v273 < v280.Length;\n\tv269 = ~v303;\n\tif (v269) goto L_00B8;\n\tv304 = v100 < v53.Length;\n\tv270 = ~v304;\n\tif (v270) goto L_00B8;\n\tv103 = v103 + 1;\n\tv174 = v100 + 2;\n\tv53[v100 @ X22_v5 (System.Int32)] = v280[v273 @ X9_v9 (System.Int32)];\n\tv208 = bytes.Length;\n\tv178 = v103 < bytes.Length;\n\tif (v178) goto L_0031;\nL_00A9:\n\treturnVal2 = System.String::CreateString(0, v53);\n\treturn returnVal2;\nL_00B7:\n\treturn \"\";\nL_00B8:\n\tv281 = new System.IndexOutOfRangeException();\n\tthrow v281;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToHexString(byte[] bytes)
		{
			if (bytes != null)
			{
				int num = bytes.Length << 1;
				char[] array = new char[num];
				int num2 = bytes.Length;
				if (bytes.Length >= 1)
				{
					int num3 = 1;
					int num4 = 0;
					while (true)
					{
						if (num4 < num2)
						{
							char[] array2 = hexDigits;
							int num5 = bytes[num4] >> 4;
							if (num5 < array2.Length)
							{
								int num6 = num3 - 1;
								if (num6 < array.Length)
								{
									array[num6] = array2[num5];
									char[] array3 = hexDigits;
									int num7 = bytes[num4] & 0xF;
									if (num7 < array3.Length && num3 < array.Length)
									{
										num4++;
										int num8 = num3 + 2;
										array[num3] = array3[num7];
										num2 = bytes.Length;
										bool flag = num4 < bytes.Length;
										num3 = num8;
										if (!flag)
										{
											break;
										}
										continue;
									}
								}
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
				}
				return ((string)null).CreateString(array);
			}
			return "";
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x15D1AB8", Offset = "0x15D1AB8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_000E:\n\tv4 = v40 <= 0;\n\tif (v4) goto L_0017;\n\tv45 = v38 & 0x38;\n\tv40 = v40 - 1;\n\tv37 = value >> v45;\n\tv38 = v38 - 8;\n\tv34 = v37 == 0;\n\tif (v34) goto L_000E;\nL_0017:\n\treturn v40;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int BytePrecision(ulong value)
		{
			int num = 24;
			int num2 = 4;
			while (num2 > 0)
			{
				int num3 = num & 0x38;
				num2--;
				long num4 = (long)value >> num3;
				num -= 8;
				if (num4 != 0)
				{
					break;
				}
			}
			return num2;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15CEF20", Offset = "0x15CEF20", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F05460]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, length, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029A13]) = v45;\nL_0017:\n\tv46 = length < 0x7F;\n\tv47 = ~v46;\n\tv48 = length - 0x7F;\n\tv50 = v48 == 0;\n\tv55 = ~v50;\n\tv56 = v47 & v55;\n\tif (v56) goto L_0032;\n\tv69 = System.IO.Stream::WriteByte(xdata, length);\n\tgoto L_FFFFFFFF;\nL_0032:\n\tgoto L_FFFFFFFF;\n\tv105 = *([v60 @ X0_v8+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_FFFFFFFF;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v60, length, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0046:\n\tv71 = v162 <= 0;\n\tif (v71) goto L_0051;\n\tv233 = v164 & 0x38;\n\tv162 = v162 - 1;\n\tv161 = length >> v233;\n\tv164 = v164 - 8;\n\tv167 = v161 == 0;\n\tif (v167) goto L_0046;\nL_0051:\n\tv141 = v162 | 0x80;\n\tv143 = System.IO.Stream::WriteByte(xdata, v141);\nL_0058:\n\tv147 = v199 - 2;\n\tv114 = v147 < 1;\n\tif (v114) goto L_FFFFFFFF;\n\tv253 = v257 - 0x10;\n\tv254 = v253 & 0x38;\n\tv250 = length >> v254;\n\tv257 = v257 - 8;\n\tv199 = v199 - 1;\n\tv248 = v250 == 0;\n\tif (v248) goto L_0058;\n\tv256 = v257 - 8;\nL_0071:\n\tv198 = v256 & 0x38;\n\tv192 = length >> v198;\n\tv194 = System.IO.Stream::WriteByte(xdata, v192);\n\tv184 = v257 - 8;\n\tv256 = v256 - 8;\n\tv196 = v257 != 8;\n\tif (v196) goto L_0071;\n\tgoto L_0084;\nL_0084:\n\treturn v199;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int DERLengthEncode(Stream xdata, ulong length)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0221: Expected I4, but got I8
			bool flag = (long)length < 127L;
			bool flag2 = !flag;
			long num = (long)(length - 127);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			int num7;
			int num6;
			if (!(flag2 && flag4))
			{
				xdata.WriteByte((byte)length);
			}
			else
			{
				int num2 = 4;
				int num3 = 24;
				while (num2 > 0)
				{
					int num4 = num3 & 0x38;
					num2--;
					long num5 = (long)length >> num4;
					num3 -= 8;
					if (num5 != 0)
					{
						break;
					}
				}
				int value = num2 | 0x80;
				xdata.WriteByte((byte)value);
				num6 = 40;
				num7 = 6;
				while (true)
				{
					int num8 = num7 - 2;
					if (num8 < 1)
					{
						break;
					}
					int num9 = num6 - 16;
					int num10 = num9 & 0x38;
					long num11 = (long)length >> num10;
					num6 -= 8;
					num7--;
					if (num11 == 0)
					{
						continue;
					}
					goto IL_011b;
				}
			}
			num7 = 1;
			goto IL_0265;
			IL_011b:
			int num12 = num6 - 8;
			int num13 = default(int);
			num12 = num13;
			int num14 = default(int);
			num6 = num14;
			bool flag5;
			do
			{
				int num15 = num12 & 0x38;
				long num16 = (long)length >> num15;
				xdata.WriteByte((byte)num16);
				int num17 = num6 - 8;
				num12 -= 8;
				flag5 = num6 != 8;
				num6 = num17;
			}
			while (flag5);
			goto IL_0265;
			IL_0265:
			return num7;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15D139C", Offset = "0x15D139C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([isIndefiniteLength @ X1 (System.Boolean&)]) = 0;\n\tv21 = System.IO.Stream::ReadByte(bt);\n\tv36 = v21 & 0x80;\n\tv37 = v36 == 0;\n\tv38 = ~v37;\n\tif (v38) goto L_0017;\n\tv40 = v21 & 0xFF;\n\tgoto L_004D;\nL_0017:\n\tv41 = v21 & 0x7F;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0043;\n\tv104 = v41 + 1;\nL_001C:\n\tv97 = v84 >> 0x18;\n\tv48 = v97 >= 1;\n\tif (v48) goto L_FFFFFFFF;\n\tv148 = System.IO.Stream::ReadByte(bt);\n\tv149 = v148 & 0xFF;\n\tv104 = v104 - 1;\n\tv150 = v84 & 0xFFFFFFFFFFFFFF;\n\tv102 = v150 << 8;\n\tv151 = v149 & 0xFF;\n\tv94 = v151 | v102;\n\tv50 = v104 > 1;\n\tif (v50) goto L_001C;\n\tgoto L_004D;\nL_0043:\n\t*([isIndefiniteLength @ X1 (System.Boolean&)]) = 1;\n\tgoto L_004D;\nL_004D:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static long DerLengthDecode(Stream bt, ref bool isIndefiniteLength)
		{
			//IL_015b: Expected I8, but got I4
			//IL_0067: Expected I8, but got I4
			//IL_0169: Expected I8, but got I4
			//IL_00ee: Expected I4, but got I8
			//IL_0144: Expected I8, but got I4
			ref bool reference = ref *(bool*)null;
			int num = bt.ReadByte();
			if ((num & 0x80) == 0)
			{
				int num2 = num & 0xFF;
				return num2;
			}
			int num3 = num & 0x7F;
			if (num3 != 0)
			{
				int num4 = num3 + 1;
				int num5 = 0;
				while (true)
				{
					int num6 = num5 >> 24;
					if (num6 >= 1)
					{
						break;
					}
					int num7 = bt.ReadByte();
					int num8 = num7 & 0xFF;
					num4--;
					int num9 = (int)(num5 & 0xFFFFFFFFFFFFFFL);
					int num10 = num9 << 8;
					int num11 = num8 & 0xFF;
					int num12 = num11 | num10;
					bool flag = num4 > 1;
					num5 = num12;
					if (!flag)
					{
						return num12;
					}
				}
				return -1L;
			}
			reference = ref *(bool*)1;
			return -2L;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15CF2D8", Offset = "0x15CF2D8", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE9CA8]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A14]) = v38;\nL_0017:\n\tv43 = v36 & 0xC0;\n\tv44 = v43 == 0;\n\tif (v44) goto L_0043;\n\tv45 = v43 < 0x21;\n\tv46 = ~v45;\n\tv54 = ~v46;\n\tif (v54) goto L_00D4;\n\tv72 = v43 == 0x40;\n\tv77 = v36 & 0xFF;\n\tif (v72) goto L_0059;\n\tv144 = v43 != 0x80;\n\tif (v144) goto L_006A;\n\tv43 = v77 & 0x1F;\n\tv208 = 0xDC3560(&v43 @ X8_v5 (System.Int32), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_007A;\nL_0043:\n\tv43 = v36 & 0x1F;\n\tv43 = v43 - 1;\n\tv57 = v43 < 0x1D;\n\tv58 = ~v57;\n\tv59 = v43 - 0x1D;\n\tv61 = v59 == 0;\n\tv66 = ~v61;\n\tv67 = v58 & v66;\n\tif (v67) goto L_0099;\n\tv130 = 0x183F000 + 0x2C4;\n\tv43 = *([v130 @ X9_v4 (System.Int32)+v43 @ X8_v5 (System.Int32)*4]);\n\tv43 = v43 + v130;\n\t// 85 IndirectJump v43 @ X8_v5 (System.Int32), v36 @ X0_v1 (System.Byte), v36 @ X0_v1 (System.Byte), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1F02380]);\n\tgoto L_00CC;\nL_0059:\n\tv43 = v77 & 0x1F;\n\tv208 = 0xDC3560(&v43 @ X8_v5 (System.Int32), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_007A;\nL_006A:\n\tv93 = v43 != 0xC0;\n\tif (v93) goto L_00D4;\n\tv43 = v77 & 0x1F;\n\tv208 = 0xDC3560(&v43 @ X8_v5 (System.Int32), 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007A:\n\tv119 = System.String::Concat(\"\", *([v199 @ X8_v14 (System.String)]), v208, \")\");\n\tgoto L_FFFFFFFF;\n\tX8 = *([1EBDC98]);\n\tgoto L_00CC;\n\tX8 = *([1EB73F0]);\n\tgoto L_00CC;\n\tX8 = *([1EE3D30]);\n\tgoto L_00CC;\n\tX8 = *([1EADF08]);\n\tgoto L_00CC;\n\tX8 = *([1EADB50]);\n\tgoto L_00CC;\n\tX8 = *([1F0BE70]);\n\tgoto L_00CC;\n\tX8 = *([1EBCAA8]);\n\tgoto L_00CC;\n\tX8 = *([1EE6E90]);\n\tgoto L_00CC;\n\tX8 = *([1EB2E00]);\n\tgoto L_00CC;\nL_0099:\n\tgoto L_00CC;\n\tX8 = *([1ED6A20]);\n\tgoto L_00CC;\n\tX8 = *([1ECD630]);\n\tgoto L_00CC;\n\tX8 = *([1ECE920]);\n\tgoto L_00CC;\n\tX8 = *([1EBC870]);\n\tgoto L_00CC;\n\tX8 = *([1ECB938]);\n\tgoto L_00CC;\n\tX8 = *([1EC9CA8]);\n\tgoto L_00CC;\n\tX8 = *([1EE49C8]);\n\tgoto L_00CC;\n\tX8 = *([1EA9EF0]);\n\tgoto L_00CC;\n\tX8 = *([1ED7508]);\n\tgoto L_00CC;\n\tX8 = *([1ED8CA0]);\n\tgoto L_00CC;\n\tX8 = *([1EEB978]);\n\tgoto L_00CC;\n\tX8 = *([1EDEB00]);\n\tgoto L_00CC;\n\tX8 = *([1F00850]);\n\tgoto L_00CC;\n\tX8 = *([1EE6320]);\n\tgoto L_00CC;\n\tX8 = *([1EBB898]);\n\tgoto L_00CC;\n\tX8 = *([1EDB5C8]);\nL_00CC:\n\tv119 = System.String::Concat(\"\", \"UNKNOWN TAG\");\nL_00D4:\n\treturn v122;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetTagName(byte tag)
		{
			byte b = default(byte);
			int num = b & 0xC0;
			string result;
			int num2 = default(int);
			string text;
			string text2;
			if (num != 0)
			{
				bool flag = num < 33;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = "";
				if (flag3)
				{
					goto IL_0222;
				}
				bool flag4 = num == 64;
				num2 = b & 0xFF;
				if (!flag4)
				{
					if (num == 128)
					{
						num = num2 & 0x1F;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						text = "CONTEXT SPECIFIC (";
					}
					else
					{
						bool flag5 = num != 192;
						result = "";
						if (flag5)
						{
							goto IL_0222;
						}
						num = num2 & 0x1F;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						text = "PRIVATE (";
					}
					goto IL_0227;
				}
			}
			else
			{
				num = b & 0x1F;
				num--;
				bool flag6 = num < 29;
				bool flag7 = !flag6;
				int num3 = num - 29;
				bool flag8 = num3 == 0;
				bool flag9 = !flag8;
				if (flag7 && flag9)
				{
					text2 = "" + "UNKNOWN TAG";
					goto IL_01ea;
				}
				int num4 = 25423872 + 708;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X9_v4 (System.Int32)+v43 @ X8_v5 (System.Int32)*4]");
				num = 0;
				num += num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ X8_v5 (System.Int32) (should have been resolved before IL gen)");
			}
			num = num2 & 0x1F;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			text = "APPLICATION (";
			goto IL_0227;
			IL_0227:
			string text3 = default(string);
			text2 = "" + text + text3 + ")";
			goto IL_01ea;
			IL_0222:
			return result;
			IL_01ea:
			result = text2;
			goto IL_0222;
		}
	}
}
