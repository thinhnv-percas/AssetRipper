using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace SharpJson
{
	[Token(Token = "0x2000004")]
	internal class Lexer
	{
		[Token(Token = "0x2000005")]
		public enum Token
		{
			[Token(Token = "0x400000D")]
			None = 0,
			[Token(Token = "0x400000E")]
			Null = 1,
			[Token(Token = "0x400000F")]
			True = 2,
			[Token(Token = "0x4000010")]
			False = 3,
			[Token(Token = "0x4000011")]
			Colon = 4,
			[Token(Token = "0x4000012")]
			Comma = 5,
			[Token(Token = "0x4000013")]
			String = 6,
			[Token(Token = "0x4000014")]
			Number = 7,
			[Token(Token = "0x4000015")]
			CurlyOpen = 8,
			[Token(Token = "0x4000016")]
			CurlyClose = 9,
			[Token(Token = "0x4000017")]
			SquaredOpen = 10,
			[Token(Token = "0x4000018")]
			SquaredClose = 11
		}

		[CompilerGenerated]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		private int _003ClineNumber_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x14")]
		internal bool _003CparseNumbersAsFloat_003Ek__BackingField;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x18")]
		internal char[] json;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x20")]
		internal int index;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x24")]
		private bool success;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x28")]
		private char[] stringBuffer;

		[Token(Token = "0x17000001")]
		public bool hasError
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x1520E0C", Offset = "0x1520E0C", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.success == 0;\n\treturn v6;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return !success;
			}
		}

		[Token(Token = "0x17000002")]
		public int lineNumber
		{
			[CompilerGenerated]
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x1520E1C", Offset = "0x1520E1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<lineNumber>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return lineNumber;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x1520E24", Offset = "0x1520E24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<lineNumber>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003ClineNumber_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000003")]
		public bool parseNumbersAsFloat
		{
			[CompilerGenerated]
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x1520E2C", Offset = "0x1520E2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<parseNumbersAsFloat>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return parseNumbersAsFloat;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x1520E34", Offset = "0x1520E34", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<parseNumbersAsFloat>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CparseNumbersAsFloat_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1520E40", Offset = "0x1520E40", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = System.Char[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, text, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ACA]) = v40;\nL_0016:\n\tthis.success = 1;\n\t// 25 NewArr v44 @ X0_v3 (System.Char[]), typeof(System.Char[]), 4096\n\tthis.stringBuffer = v44;\n\tSystem.Object::.ctor(this);\n\tthis.index = 0;\n\tthis.<lineNumber>k__BackingField = 1;\n\tthis.success = 1;\n\tv50 = System.String::ToCharArray(text);\n\tthis.json = v50;\n\tthis.<parseNumbersAsFloat>k__BackingField = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Lexer(string text)
		{
			success = true;
			char[] array = new char[4096];
			stringBuffer = array;
			index = 0;
			lineNumber = 1;
			success = true;
			char[] array2 = text.ToCharArray();
			json = array2;
			parseNumbersAsFloat = false;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1520ED8", Offset = "0x1520ED8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.index = 0;\n\tthis.<lineNumber>k__BackingField = 1;\n\tthis.success = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			index = 0;
			lineNumber = 1;
			success = true;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1520EEC", Offset = "0x1520EEC", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = System.Convert;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv55 = System.Text.StringBuilder;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37ACB]) = v52;\nL_001D:\n\tSharpJson.Lexer::SkipWhiteSpaces(this);\n\tv58 = this.index + 1;\n\tthis.index = v58;\n\tv127 = 0x44C000 + 0xCE8;\nL_0040:\n\tv400 = v124 & 1;\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_0204;\n\tv110 = this.json;\n\tv225 = this.index;\n\tv523 = this.index == v110.Length;\n\tif (v523) goto L_0204;\n\tv222 = this.index + 1;\n\tthis.index = v222;\n\tv538 = v110[v225 @ X9_v8 (System.Int32)] == 0x5C;\n\tif (v538) goto L_009E;\n\tv179 = v110[v225 @ X9_v8 (System.Int32)] == 0x22;\n\tif (v179) goto L_0214;\n\tv243 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv243[v97 @ X21_v5 (System.Int32)] = v110[v225 @ X9_v8 (System.Int32)];\nL_0089:\n\tv244 = this.stringBuffer;\n\tv95 = v98 < v244.Length;\n\tif (v95) goto L_0040;\n\tgoto L_01F2;\nL_009E:\n\tv524 = v222 == v110.Length;\n\tif (v524) goto L_0204;\n\tv86 = this.index + 2;\n\tthis.index = v86;\n\tv549 = v110[v222 @ X10_v7 (System.Int32)] < 0x5C;\n\tv550 = ~v549;\n\tv551 = v110[v222 @ X10_v7 (System.Int32)] - 0x5C;\n\tv553 = v551 == 0;\n\tv558 = ~v553;\n\tv93 = v550 & v558;\n\tif (v93) goto L_00F2;\n\tv183 = v110[v222 @ X10_v7 (System.Int32)] == 0x22;\n\tif (v183) goto L_0150;\n\tv184 = v110[v222 @ X10_v7 (System.Int32)] == 0x2F;\n\tif (v184) goto L_0164;\n\tv91 = v110[v222 @ X10_v7 (System.Int32)] != 0x5C;\n\tif (v91) goto L_FFFFFFFF;\n\tv245 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv245[v97 @ X21_v5 (System.Int32)] = 0x5C;\n\tgoto L_0089;\nL_00F2:\n\tv564 = v110[v222 @ X10_v7 (System.Int32)] < 0x66;\n\tv565 = ~v564;\n\tv566 = v110[v222 @ X10_v7 (System.Int32)] - 0x66;\n\tv568 = v566 == 0;\n\tv573 = ~v568;\n\tv94 = v565 & v573;\n\tif (v94) goto L_0127;\n\tv185 = v110[v222 @ X10_v7 (System.Int32)] == 0x62;\n\tif (v185) goto L_0178;\n\tv92 = v110[v222 @ X10_v7 (System.Int32)] != 0x66;\n\tif (v92) goto L_FFFFFFFF;\n\tv246 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv246[v97 @ X21_v5 (System.Int32)] = v114;\n\tgoto L_0089;\nL_0127:\n\tv495 = v110[v222 @ X10_v7 (System.Int32)] - 0x6E;\n\tv608 = v495 < 7;\n\tv489 = ~v608;\n\tv486 = v495 - 7;\n\tv480 = v486 == 0;\n\tv609 = ~v480;\n\tv418 = v489 & v609;\n\tif (v418) goto L_0089;\n\tv427 = *([v127 @ X24_v4 (System.Int32)+v495 @ X9_v12 (System.Int32)]) << 2;\n\tv492 = 0x1525008 + v427;\n\t// 313 IndirectJump v492 @ X10_v9 (System.Int32), v392 @ X0_v11 (System.Text.StringBuilder), v392 @ X0_v11 (System.Text.StringBuilder), v110 @ X1_v6 (System.Char[]), v86 @ X2_v7 (System.Int32), v97 @ X21_v5 (System.Int32), 0, v38 @ X5, v39 @ X6, v40 @ X7, v41 @ V0, v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X21 < X9;\n\tC = ~C;\n\tTEMP1 = X21 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X9;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X21 << 1;\n\tX8 = X8 + TEMPSHIFT;\n\tX22 = 0;\n\tX21 = X21 + 1;\n\t*([X8+20]) = X13;\n\tgoto L_0089;\n\tgoto L_0089;\nL_0150:\n\tv247 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv247[v97 @ X21_v5 (System.Int32)] = 0x22;\n\tgoto L_0089;\nL_0164:\n\tv248 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv248[v97 @ X21_v5 (System.Int32)] = 0x2F;\n\tgoto L_0089;\nL_0178:\n\tv249 = this.stringBuffer;\n\tv98 = v97 + 1;\n\tv249[v97 @ X21_v5 (System.Int32)] = 8;\n\tgoto L_0089;\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X21 < X9;\n\tC = ~C;\n\tTEMP1 = X21 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X9;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X21 << 1;\n\tX8 = X8 + TEMPSHIFT;\n\tX22 = 0;\n\tX21 = X21 + 1;\n\t*([X8+20]) = X14;\n\tgoto L_0089;\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X21 < X9;\n\tC = ~C;\n\tTEMP1 = X21 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X9;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X21 << 1;\n\tX8 = X8 + TEMPSHIFT;\n\tX22 = 0;\n\tX21 = X21 + 1;\n\t*([X8+20]) = X15;\n\tgoto L_0089;\n\tX8 = X8 - X2;\n\tC = X8 < 4;\n\tC = ~C;\n\tTEMP1 = X8 - 4;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 4;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_01C2;\n\tX22 = 1;\n\tgoto L_0089;\nL_01C2:\n\tX3 = 4;\n\tX0 = 0;\n\tX4 = 0;\n\tX29 = X28;\n\tX0 = System.String::CreateString(X0, X1, X2, X3, X4);\n\tX8 = *([X23]);\n\tX28 = X23;\n\tX23 = *([X19+28]);\n\tX22 = X0;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01D1;\n\tX0 = X8;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01D1:\n\tX1 = 0x10;\n\tX0 = X22;\n\tX2 = 0;\n\tX0 = System.Convert::ToInt32(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X23+18]);\n\tC = X21 < X8;\n\tC = ~C;\n\tTEMP1 = X21 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X8;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X21 << 1;\n\tX8 = X23 + TEMPSHIFT;\n\t*([X8+20]) = X0;\n\tX8 = *([X19+20]);\n\tX22 = 0;\n\tX21 = X21 + 1;\n\tX23 = X28;\n\tX8 = X8 + 4;\n\t*([X19+20]) = X8;\n\tX28 = X29;\n\tX29 = 8;\n\tX12 = 0xC;\n\tX13 = 0xA;\n\tX14 = 0xD;\n\tX15 = 9;\n\tgoto L_0089;\nL_01F2:\n\tv618 = v396 == 0;\n\tv619 = ~v618;\n\tif (v619) goto L_0201;\n\tv230 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v230);\nL_0201:\n\tv392 = System.Text.StringBuilder::Append(v396, this.stringBuffer, 0, v98);\n\tgoto L_FFFFFFFF;\nL_0204:\n\tthis.success = 0;\n\treturn 0;\nL_0214:\n\tv503 = v396 == 0;\n\tif (v503) goto L_023A;\n\tv510 = *([v396 @ X20_v7 (System.Text.StringBuilder)]);\n\t// 551 IndirectJump [v510 @ X8_v23 (Il2CppClass<System.Text.StringBuilder>)+168], v396 @ X20_v7 (System.Text.StringBuilder), v396 @ X20_v7 (System.Text.StringBuilder), [v510 @ X8_v23 (Il2CppClass<System.Text.StringBuilder>)+170], [v510 @ X8_v23 (Il2CppClass<System.Text.StringBuilder>)+168], v98 @ X21_v7 (System.Int32), 0, v38 @ X5, v39 @ X6, v40 @ X7, v41 @ V0, v42 @ V1, v43 @ V2, v44 @ V3, v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\nL_023A:\n\treturnVal3 = System.String::CreateString(0, this.stringBuffer, 0, v97);\n\treturn returnVal3;\n\tv254 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 353 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ParseString()
		{
			//IL_05be: Expected I, but got O
			SkipWhiteSpaces();
			int num = index + 1;
			index = num;
			int num2 = 4505600 + 3304;
			int num3 = 12;
			int num4 = 0;
			StringBuilder stringBuilder = null;
			while (true)
			{
				int num5 = 0;
				int num9;
				bool flag14;
				do
				{
					if ((num4 & 1) == 0)
					{
						char[] array = json;
						int num6 = index;
						if (index != array.Length)
						{
							int num7 = ++index;
							if (array[num6] != '\\')
							{
								if (array[num6] == '"')
								{
									if (stringBuilder != null)
									{
										nint num8 = (nint)stringBuilder;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v510 @ X8_v23 (Il2CppClass<System.Text.StringBuilder>)+168] (should have been resolved before IL gen)");
									}
									return ((string)null).CreateString(stringBuffer, 0, num5);
								}
								char[] array2 = stringBuffer;
								num9 = num5 + 1;
								array2[num5] = array[num6];
								num4 = 0;
							}
							else
							{
								if (num7 == array.Length)
								{
									goto IL_058c;
								}
								int num10 = index + 2;
								index = num10;
								bool flag = array[num7] < '\\';
								bool flag2 = !flag;
								int num11 = array[num7] - 92;
								bool flag3 = num11 == 0;
								bool flag4 = !flag3;
								if (!(flag2 && flag4))
								{
									if (array[num7] != '"')
									{
										if (array[num7] != '/')
										{
											if (array[num7] != '\\')
											{
												goto IL_0451;
											}
											char[] array3 = stringBuffer;
											num9 = num5 + 1;
											array3[num5] = '\\';
											num4 = 0;
										}
										else
										{
											char[] array4 = stringBuffer;
											num9 = num5 + 1;
											array4[num5] = '/';
											num4 = 0;
										}
									}
									else
									{
										char[] array5 = stringBuffer;
										num9 = num5 + 1;
										array5[num5] = '"';
										num4 = 0;
									}
								}
								else
								{
									bool flag5 = array[num7] < 'f';
									bool flag6 = !flag5;
									int num12 = array[num7] - 102;
									bool flag7 = num12 == 0;
									bool flag8 = !flag7;
									if (!(flag6 && flag8))
									{
										if (array[num7] != 'b')
										{
											if (array[num7] != 'f')
											{
												goto IL_0451;
											}
											char[] array6 = stringBuffer;
											num9 = num5 + 1;
											array6[num5] = (char)num3;
											num4 = 0;
										}
										else
										{
											char[] array7 = stringBuffer;
											num9 = num5 + 1;
											array7[num5] = '\b';
											num4 = 0;
										}
									}
									else
									{
										int num13 = array[num7] - 110;
										bool flag9 = num13 < 7;
										bool flag10 = !flag9;
										int num14 = num13 - 7;
										bool flag11 = num14 == 0;
										bool flag12 = !flag11;
										bool flag13 = flag10 && flag12;
										num9 = num5;
										num4 = 0;
										if (!flag13)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X24_v4 (System.Int32)+v495 @ X9_v12 (System.Int32)]");
											int num15 = (int)((nint)0 << 2);
											int num16 = 22171656 + num15;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v492 @ X10_v9 (System.Int32) (should have been resolved before IL gen)");
											goto IL_0451;
										}
									}
								}
							}
							goto IL_0641;
						}
					}
					goto IL_058c;
					IL_0641:
					char[] array8 = stringBuffer;
					flag14 = num9 < array8.Length;
					num5 = num9;
					continue;
					IL_0451:
					num9 = num5;
					num4 = 0;
					goto IL_0641;
					IL_058c:
					success = false;
					return null;
				}
				while (flag14);
				if (stringBuilder == null)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					stringBuilder = stringBuilder2;
				}
				StringBuilder stringBuilder3 = stringBuilder.Append(stringBuffer, 0, num9);
				num3 = 12;
			}
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x15213FC", Offset = "0x15213FC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSharpJson.Lexer::SkipWhiteSpaces(this);\n\tv11 = SharpJson.Lexer::GetLastIndexOfNumber(this, this.index);\n\tv15 = v11 + 1;\n\tv17 = v15 - this.index;\n\treturnVal1 = System.String::CreateString(0, this.json, this.index, v17);\n\tthis.index = v15;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GetNumberString()
		{
			SkipWhiteSpaces();
			int lastIndexOfNumber = GetLastIndexOfNumber(index);
			int num = lastIndexOfNumber + 1;
			int length = num - index;
			string result = ((string)null).CreateString(json, index, length);
			index = num;
			return result;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x15214C4", Offset = "0x15214C4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Globalization.CultureInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37ACC]) = v37;\nL_0015:\n\tv40 = SharpJson.Lexer::GetNumberString(this);\n\tgoto L_001F;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv57 = System.Single::TryParse(v40, 0xA7, v50, &v53 @ stack_-24_v2 (System.Single));\n\tv65 = v57 == 0;\n\tv69 = ~v65;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float ParseFloatNumber()
		{
			string numberString = GetNumberString();
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (float.TryParse(numberString, NumberStyles.Float, invariantCulture, out var result))
			{
				return result;
			}
			return 0f;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x1521560", Offset = "0x1521560", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Globalization.CultureInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37ACD]) = v37;\nL_0015:\n\tv40 = SharpJson.Lexer::GetNumberString(this);\n\tgoto L_001F;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv57 = System.Double::TryParse(v40, 0x1FF, v50, &v53 @ stack_-28_v2 (System.Double));\n\tv65 = v57 == 0;\n\tv69 = ~v65;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public double ParseDoubleNumber()
		{
			string numberString = GetNumberString();
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (double.TryParse(numberString, NumberStyles.Any, invariantCulture, out var result))
			{
				return result;
			}
			return 0.0;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x1521444", Offset = "0x1521444", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.json;\n\tv20 = v2.Length <= index;\n\tif (v20) goto L_0051;\nL_0024:\n\tv90 = v2[v65 @ X8_v4 (System.Int32)] - 0x30;\n\tv166 = v90 < 0xA;\n\tv167 = ~v166;\n\tv175 = ~v167;\n\tif (v175) goto L_0044;\n\tv93 = v2[v65 @ X8_v4 (System.Int32)] - 0x2B;\n\tv176 = v93 < 0x3A;\n\tv126 = ~v176;\n\tv123 = v93 - 0x3A;\n\tv115 = v123 == 0;\n\tv177 = ~v115;\n\tv99 = v126 & v177;\n\tif (v99) goto L_0051;\n\tv94 = 1 << v93;\n\tv132 = v94 & 0x40000000400000D;\n\tv116 = v132 == 0;\n\tif (v116) goto L_0051;\nL_0044:\n\tv128 = v65 + 1;\n\tv98 = v128 < v2.Length;\n\tif (v98) goto L_0024;\nL_0051:\n\treturnVal1 = v128 - 1;\n\treturn returnVal1;\n\tv22 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int GetLastIndexOfNumber(int index)
		{
			//IL_012b: Expected I4, but got I8
			char[] array = json;
			bool flag = array.Length <= index;
			int num = index;
			if (!flag)
			{
				int num2 = index;
				bool flag8;
				do
				{
					int num3 = array[num2] - 48;
					if (num3 >= 10)
					{
						int num4 = array[num2] - 43;
						bool flag2 = num4 < 58;
						bool flag3 = !flag2;
						int num5 = num4 - 58;
						bool flag4 = num5 == 0;
						bool flag5 = !flag4;
						bool flag6 = flag3 && flag5;
						num = num2;
						if (flag6)
						{
							break;
						}
						int num6 = 1 << num4;
						int num7 = (int)(num6 & 0x40000000400000DL);
						bool flag7 = num7 == 0;
						num = num2;
						if (flag7)
						{
							break;
						}
					}
					num = num2 + 1;
					flag8 = num < array.Length;
					num2 = num;
				}
				while (flag8);
			}
			return num - 1;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x1521348", Offset = "0x1521348", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv16 = System.Char;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A37ACE]) = v35;\nL_0011:\n\tv104 = this.json;\n\tv101 = this.index;\nL_0021:\n\tv115 = v101 >= v104.Length;\n\tif (v115) goto L_004E;\n\tv47 = v104[v101 @ X9_v4 (System.Int32)] != 0xA;\n\tif (v47) goto L_0039;\n\tv164 = this.<lineNumber>k__BackingField + 1;\n\tthis.<lineNumber>k__BackingField = v164;\nL_0039:\n\tgoto L_003D;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v166, v90, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003D:\n\tv81 = System.Char::IsWhiteSpace(v104[v101 @ X9_v4 (System.Int32)]);\n\tv132 = v81 == 0;\n\tif (v132) goto L_004E;\n\tv104 = this.json;\n\tv101 = this.index + 1;\n\tthis.index = v101;\n\tv174 = this.json == 0;\n\tv83 = ~v174;\n\tif (v83) goto L_0021;\n\tthrow System.NullReferenceException;\nL_004E:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SkipWhiteSpaces()
		{
			char[] array = json;
			int num = index;
			while (num < array.Length)
			{
				if (array[num] == '\n')
				{
					int num2 = lineNumber + 1;
					lineNumber = num2;
				}
				if (char.IsWhiteSpace(array[num]))
				{
					array = json;
					num = ++index;
					if (json == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15215FC", Offset = "0x15215FC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSharpJson.Lexer::SkipWhiteSpaces(this);\n\tv7 = this.index;\n\treturnVal1 = SharpJson.Lexer::NextToken(this.json, &v7 @ X8_v1 (System.Int32));\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Token LookAhead()
		{
			SkipWhiteSpaces();
			int num = index;
			return NextToken(json, ref num);
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x1521880", Offset = "0x1521880", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSharpJson.Lexer::SkipWhiteSpaces(this);\n\tv8 = this + 0x20;\n\treturnVal1 = SharpJson.Lexer::NextToken(this.json, v8);\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Token NextToken()
		{
			SkipWhiteSpaces();
			return NextToken(json, ref *(int*)((nint)this + 32));
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x152162C", Offset = "0x152162C", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = index->klass;\n\tv16 = *([index @ X1 (System.Int32&)]) != json.Length;\n\tif (v16) goto L_0013;\n\tgoto L_01CD;\nL_0013:\n\tv50 = *([index @ X1 (System.Int32&)]) + 1;\n\t*([index @ X1 (System.Int32&)]) = v50;\n\tv375 = json[v4 @ X9_v2] < 0x5B;\n\tv376 = ~v375;\n\tv377 = json[v4 @ X9_v2] - 0x5B;\n\tv379 = v377 == 0;\n\tv384 = ~v379;\n\tv329 = v376 & v384;\n\tif (v329) goto L_004A;\n\tv422 = json[v4 @ X9_v2] - 0x22;\n\tv423 = v422 < 0x18;\n\tv419 = ~v423;\n\tv417 = v422 - 0x18;\n\tv413 = v417 == 0;\n\tv424 = ~v413;\n\tv403 = v419 & v424;\n\tif (v403) goto L_0074;\n\tv394 = 0x44C000 + 0xCF0;\n\tv398 = *([v394 @ X13_v2 (System.Int32)+v422 @ X8_v43 (System.Int32)]) << 2;\n\tv391 = 0x1525698 + v398;\n\t// 67 IndirectJump v391 @ X14_v2 (System.Int32), json @ X0 (System.Char[]), json @ X0 (System.Char[]), index @ X1 (System.Int32&), methodInfo @ X2 (Il2CppMethodInfo), v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tX8 = 7;\n\tgoto L_01CD;\nL_004A:\n\tv353 = json[v4 @ X9_v2] == 0x5D;\n\tif (v353) goto L_FFFFFFFF;\n\tv354 = json[v4 @ X9_v2] == 0x7B;\n\tif (v354) goto L_FFFFFFFF;\n\tv328 = json[v4 @ X9_v2] != 0x7D;\n\tif (v328) goto L_0078;\n\tgoto L_01CD;\n\tgoto L_01CD;\n\tgoto L_01CD;\nL_0074:\n\tv330 = json[v4 @ X9_v2] != 0x5B;\n\tif (v330) goto L_0078;\n\tgoto L_01CD;\nL_0078:\n\tv53 = json.Length - *([index @ X1 (System.Int32&)]);\n\tindex->klass = index->klass;\n\tv449 = v53 >= 5;\n\tif (v449) goto L_00A9;\n\tv65 = v53 != 4;\n\tif (v65) goto L_FFFFFFFF;\n\tv465 = json[v4 @ X9_v2] == 0x6E;\n\tif (v465) goto L_018F;\n\tv135 = json[v4 @ X9_v2] == 0x74;\n\tif (v135) goto L_0141;\n\tgoto L_FFFFFFFF;\nL_00A9:\n\tv456 = json[v4 @ X9_v2] == 0x74;\n\tif (v456) goto L_0141;\n\tv474 = json[v4 @ X9_v2] == 0x6E;\n\tif (v474) goto L_018F;\n\tv66 = json[v4 @ X9_v2] != 0x66;\n\tif (v66) goto L_FFFFFFFF;\n\tv67 = json[v50 @ X11_v3] != 0x61;\n\tif (v67) goto L_FFFFFFFF;\n\tv204 = *([index @ X1 (System.Int32&)]) + 2;\n\tv68 = json[v204 @ X8_v29] != 0x6C;\n\tif (v68) goto L_FFFFFFFF;\n\tv205 = *([index @ X1 (System.Int32&)]) + 3;\n\tv69 = json[v205 @ X8_v32] != 0x73;\n\tif (v69) goto L_FFFFFFFF;\n\tv206 = *([index @ X1 (System.Int32&)]) + 4;\n\tv70 = json[v206 @ X8_v35] != 0x65;\n\tif (v70) goto L_FFFFFFFF;\n\tv529 = *([index @ X1 (System.Int32&)]) + 5;\n\t*([index @ X1 (System.Int32&)]) = v529;\n\tgoto L_01CD;\nL_0141:\n\tv71 = json[v50 @ X11_v3] != 0x72;\n\tif (v71) goto L_FFFFFFFF;\n\tv207 = *([index @ X1 (System.Int32&)]) + 2;\n\tv72 = json[v207 @ X8_v19] != 0x75;\n\tif (v72) goto L_FFFFFFFF;\n\tv208 = *([index @ X1 (System.Int32&)]) + 3;\n\tv73 = json[v208 @ X8_v22] != 0x65;\n\tif (v73) goto L_FFFFFFFF;\n\tv522 = *([index @ X1 (System.Int32&)]) + 4;\n\t*([index @ X1 (System.Int32&)]) = v522;\n\tgoto L_01CD;\nL_018F:\n\tv74 = json[v50 @ X11_v3] != 0x75;\n\tif (v74) goto L_FFFFFFFF;\n\tv209 = *([index @ X1 (System.Int32&)]) + 2;\n\tv75 = json[v209 @ X8_v9] != 0x6C;\n\tif (v75) goto L_FFFFFFFF;\n\tv210 = *([index @ X1 (System.Int32&)]) + 3;\n\tv76 = json[v210 @ X8_v12] != 0x6C;\n\tif (v76) goto L_FFFFFFFF;\n\tv523 = *([index @ X1 (System.Int32&)]) + 4;\n\t*([index @ X1 (System.Int32&)]) = v523;\n\tgoto L_01CD;\n\tX8 = 5;\n\tgoto L_01CD;\n\tX8 = 4;\nL_01CD:\n\treturn v319;\n\tv17 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 366 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static Token NextToken(char[] json, ref int index)
		{
			//IL_000d: Expected O, but got I4
			//IL_0055: Expected O, but got I4
			//IL_026c: Expected O, but got I4
			//IL_04d0: Expected O, but got I4
			//IL_05a4: Expected O, but got I4
			//IL_0511: Expected O, but got I4
			//IL_05e5: Expected O, but got I4
			//IL_03bb: Expected O, but got I4
			//IL_0552: Expected O, but got I4
			//IL_0626: Expected O, but got I4
			//IL_03fc: Expected O, but got I4
			//IL_043d: Expected O, but got I4
			//IL_047e: Expected O, but got I4
			object obj = index;
			if (index == json.Length)
			{
				goto IL_0033;
			}
			object obj2 = index + 1;
			ref int reference = ref *(int*)obj2;
			bool flag = json[obj] < '[';
			bool flag2 = !flag;
			int num = json[obj] - 91;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = json[obj] - 34;
				bool flag5 = num2 < 24;
				bool flag6 = !flag5;
				int num3 = num2 - 24;
				bool flag7 = num3 == 0;
				bool flag8 = !flag7;
				if (flag6 && flag8)
				{
					if (json[obj] == '[')
					{
						return Token.SquaredOpen;
					}
					goto IL_0258;
				}
				int num4 = 4505600 + 3312;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ X13_v2 (System.Int32)+v422 @ X8_v43 (System.Int32)]");
				int num5 = (int)((nint)0 << 2);
				int num6 = 22173336 + num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v391 @ X14_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			if (json[obj] != ']')
			{
				if (json[obj] != '{')
				{
					if (json[obj] == '}')
					{
						return Token.CurlyClose;
					}
					goto IL_0258;
				}
				return Token.CurlyOpen;
			}
			return Token.SquaredClose;
			IL_0258:
			object obj3 = json.Length - index;
			reference = ref *(int*)index;
			if ((nint)obj3 < 5)
			{
				if ((nint)obj3 == 4)
				{
					if (json[obj] == 'n')
					{
						goto IL_0568;
					}
					if (json[obj] == 't')
					{
						goto IL_0494;
					}
				}
			}
			else
			{
				if (json[obj] == 't')
				{
					goto IL_0494;
				}
				if (json[obj] == 'n')
				{
					goto IL_0568;
				}
				if (json[obj] == 'f' && json[obj2] == 'a')
				{
					object obj4 = index + 2;
					if (json[obj4] == 'l')
					{
						object obj5 = index + 3;
						if (json[obj5] == 's')
						{
							object obj6 = index + 4;
							if (json[obj6] == 'e')
							{
								object obj7 = index + 5;
								reference = ref *(int*)obj7;
								return Token.False;
							}
						}
					}
				}
			}
			goto IL_0033;
			IL_0033:
			return default(Token);
			IL_0568:
			if (json[obj2] == 'u')
			{
				object obj8 = index + 2;
				if (json[obj8] == 'l')
				{
					object obj9 = index + 3;
					if (json[obj9] == 'l')
					{
						object obj10 = index + 4;
						reference = ref *(int*)obj10;
						return Token.Null;
					}
				}
			}
			goto IL_0033;
			IL_0494:
			if (json[obj2] == 'r')
			{
				object obj11 = index + 2;
				if (json[obj11] == 'u')
				{
					object obj12 = index + 3;
					if (json[obj12] == 'e')
					{
						object obj13 = index + 4;
						reference = ref *(int*)obj13;
						return Token.True;
					}
				}
			}
			goto IL_0033;
		}
	}
}
