using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace IronSourceJSON
{
	[Token(Token = "0x200000F")]
	public static class Json
	{
		[Token(Token = "0x2000011")]
		private sealed class Parser : IDisposable
		{
			[Token(Token = "0x2000013")]
			private enum TOKEN
			{
				[Token(Token = "0x400006C")]
				NONE = 0,
				[Token(Token = "0x400006D")]
				CURLY_OPEN = 1,
				[Token(Token = "0x400006E")]
				CURLY_CLOSE = 2,
				[Token(Token = "0x400006F")]
				SQUARED_OPEN = 3,
				[Token(Token = "0x4000070")]
				SQUARED_CLOSE = 4,
				[Token(Token = "0x4000071")]
				COLON = 5,
				[Token(Token = "0x4000072")]
				COMMA = 6,
				[Token(Token = "0x4000073")]
				STRING = 7,
				[Token(Token = "0x4000074")]
				NUMBER = 8,
				[Token(Token = "0x4000075")]
				TRUE = 9,
				[Token(Token = "0x4000076")]
				FALSE = 10,
				[Token(Token = "0x4000077")]
				NULL = 11
			}

			[Token(Token = "0x4000067")]
			private const string WHITE_SPACE = " \t\n\r";

			[Token(Token = "0x4000068")]
			private const string WORD_BREAK = " \t\n\r{}[],:\"";

			[Token(Token = "0x4000069")]
			[FieldOffset(Offset = "0x10")]
			private StringReader json;

			[Token(Token = "0x1700000A")]
			private char PeekChar
			{
				[Token(Token = "0x6000195")]
				[Address(RVA = "0x159D528", Offset = "0x159D528", Length = "0x88")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7940]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297AE]) = v38;\nL_0019:\n\tv44 = System.IO.StringReader::Peek(this.json);\n\tgoto L_002F;\n\tv53 = *([v48 @ X8_v6+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002F;\n\tv67 = v48;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v67, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\treturnVal2 = System.Convert::ToChar(v44);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					int value = json.Peek();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x1700000B")]
			private char NextChar
			{
				[Token(Token = "0x6000196")]
				[Address(RVA = "0x159D30C", Offset = "0x159D30C", Length = "0x88")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F07218]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297AF]) = v38;\nL_0019:\n\tv44 = System.IO.StringReader::Read(this.json);\n\tgoto L_002F;\n\tv53 = *([v48 @ X8_v6+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002F;\n\tv67 = v48;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v67, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\treturnVal2 = System.Convert::ToChar(v44);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					int value = json.Read();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x1700000C")]
			private string NextWord
			{
				[Token(Token = "0x6000197")]
				[Address(RVA = "0x159D394", Offset = "0x159D394", Length = "0xE8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1ECCC18]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20297B0]) = v40;\nL_0017:\n\tv44 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v44);\nL_001E:\n\tv78 = IronSourceJSON.Json+Parser::get_PeekChar(this);\n\tv84 = System.String::IndexOf(\" \\t\\n\\r{}[],:\\\"\", v78);\n\tv104 = v84 + 1;\n\tv92 = v104 == 0;\n\tv86 = ~v92;\n\tif (v86) goto L_0046;\n\tv99 = IronSourceJSON.Json+Parser::get_NextChar(this);\n\tv155 = System.Text.StringBuilder::Append(v44, v99);\n\tv113 = this.json;\n\tv72 = System.IO.StringReader::Peek(v113);\n\tv74 = v72 + 1;\n\tv63 = v74 == 0;\n\tv54 = ~v63;\n\tif (v54) goto L_001E;\n\tgoto L_0046;\nL_0046:\n\tv129 = *([v44 @ X0_v3 (System.Text.StringBuilder)]);\n\tv135 = *([v129 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv136 = *([v129 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 80 IndirectJump v135 @ X2_v6, v44 @ X0_v3 (System.Text.StringBuilder), v44 @ X0_v3 (System.Text.StringBuilder), v136 @ X1_v7, v135 @ X2_v6, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_00ce: Expected I, but got O
					//IL_00de: Expected O, but got I
					//IL_00ee: Expected O, but got I
					while (true)
					{
						StringBuilder stringBuilder = new StringBuilder();
						int num2;
						do
						{
							char peekChar = PeekChar;
							int num = " \t\n\r{}[],:\"".IndexOf(peekChar);
							if (num + 1 != 0)
							{
								break;
							}
							char nextChar = NextChar;
							StringBuilder stringBuilder2 = stringBuilder.Append(nextChar);
							StringReader stringReader = json;
							num2 = stringReader.Peek();
						}
						while (num2 + 1 != 0);
						IntPtr intPtr = (IntPtr)stringBuilder;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v135 @ X2_v6 (should have been resolved before IL gen)");
					}
				}
			}

			[Token(Token = "0x1700000D")]
			private TOKEN NextToken
			{
				[Token(Token = "0x6000198")]
				[Address(RVA = "0x159CC50", Offset = "0x159CC50", Length = "0x1B0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAE4E8]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297B1]) = v38;\nL_0014:\n\tIronSourceJSON.Json+Parser::EatWhitespace(this);\n\tv40 = this.json;\n\tv42 = *([v40 @ X0_v3 (System.IO.StringReader)]);\n\tv45 = System.IO.StringReader::Peek(v40);\n\tv46 = v45 + 1;\n\tv48 = v46 == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv100 = IronSourceJSON.Json+Parser::get_PeekChar(this);\n\tv97 = v100 & 0xFFFF;\n\tv102 = v97 < 0x5B;\n\tv103 = ~v102;\n\tv104 = v97 - 0x5B;\n\tv106 = v104 == 0;\n\tv111 = ~v106;\n\tv54 = v103 & v111;\n\tif (v54) goto L_0051;\n\tv168 = v97 - 0x22;\n\tv226 = v168 < 0x18;\n\tv210 = ~v226;\n\tv206 = v168 - 0x18;\n\tv212 = v206 == 0;\n\tv227 = ~v212;\n\tv198 = v210 & v227;\n\tif (v198) goto L_0089;\n\tv230 = 0x183B000 + 0xA40;\n\tv223 = *([v230 @ X8_v17 (System.Int32)+v168 @ X9_v7 (System.Int32)*4]) + v230;\n\t// 67 IndirectJump v223 @ X8_v18, 5, 5, [v42 @ X8_v4 (Il2CppClass<System.IO.StringReader>)+1C8], v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = 0 | 8;\n\tgoto L_004C;\nL_004C:\n\treturn returnVal2;\nL_0051:\n\tv82 = v97 == 0x5D;\n\tif (v82) goto L_007B;\n\tv150 = v97 == 0x7B;\n\tif (v150) goto L_FFFFFFFF;\n\tv53 = v97 != 0x7D;\n\tif (v53) goto L_008E;\n\tv240 = System.IO.StringReader::Read(this.json);\n\tgoto L_004C;\nL_007B:\n\tv236 = System.IO.StringReader::Read(this.json);\n\tgoto L_004C;\n\tgoto L_004C;\nL_0089:\n\tv120 = v97 != 0x5B;\n\tif (v120) goto L_008E;\n\tgoto L_004C;\nL_008E:\n\tv234 = IronSourceJSON.Json+Parser::get_NextWord(this);\n\tv238 = System.String::op_Equality(v234, \"false\");\n\tv179 = v238 == 0;\n\tif (v179) goto L_009F;\n\tgoto L_004C;\nL_009F:\n\tv243 = System.String::op_Equality(v234, \"true\");\n\tv180 = v243 == 0;\n\tif (v180) goto L_00AA;\n\tgoto L_004C;\nL_00AA:\n\tv248 = System.String::op_Equality(v234, \"null\");\n\tv153 = v248 == 0;\n\tv122 = ~v153;\n\tv114 = ~v122;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_00B8;\nL_00B8:\n\tgoto L_004C;\n\tX0 = 0 | 7;\n\tgoto L_004C;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X0]);\n\tX9 = *([X8+1D0]);\n\tX1 = *([X8+1D8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0 | 6;\n\tgoto L_004C;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000d: Expected I, but got O
					//IL_0149: Expected O, but got I
					EatWhitespace();
					StringReader stringReader = json;
					IntPtr intPtr = (IntPtr)stringReader;
					int num = stringReader.Peek();
					if (num + 1 == 0)
					{
						goto IL_0153;
					}
					char peekChar = PeekChar;
					int num2 = peekChar & 0xFFFF;
					bool flag = num2 < 91;
					bool flag2 = !flag;
					int num3 = num2 - 91;
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						int num4 = num2 - 34;
						bool flag5 = num4 < 24;
						bool flag6 = !flag5;
						int num5 = num4 - 24;
						bool flag7 = num5 == 0;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							int num6 = 25407488 + 2624;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X8_v17 (System.Int32)+v168 @ X9_v7 (System.Int32)*4]");
							object obj = 0L + (long)num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v223 @ X8_v18 (should have been resolved before IL gen)");
							goto IL_0153;
						}
						if (num2 == 91)
						{
							return TOKEN.SQUARED_OPEN;
						}
					}
					else
					{
						switch (num2)
						{
						case 125:
						{
							int num8 = json.Read();
							return TOKEN.CURLY_CLOSE;
						}
						case 93:
						{
							int num7 = json.Read();
							return TOKEN.SQUARED_CLOSE;
						}
						case 123:
							return TOKEN.CURLY_OPEN;
						}
					}
					switch (NextWord)
					{
					case "false":
						return TOKEN.FALSE;
					case "true":
						return TOKEN.TRUE;
					case "null":
						return TOKEN.NULL;
					}
					TOKEN result = default(TOKEN);
					goto IL_0332;
					IL_0332:
					return result;
					IL_0153:
					result = default(TOKEN);
					goto IL_0332;
				}
			}

			[Token(Token = "0x600018B")]
			[Address(RVA = "0x159CA5C", Offset = "0x159CA5C", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ECC170]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297A6]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv47 = new System.IO.StringReader();\n\tSystem.IO.StringReader::.ctor(v47, jsonString);\n\tthis.json = v47;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private Parser(string jsonString)
			{
				StringReader stringReader = new StringReader(jsonString);
				json = stringReader;
			}

			[Token(Token = "0x600018C")]
			[Address(RVA = "0x159C89C", Offset = "0x159C89C", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F043F8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297A7]) = v42;\nL_0018:\n\tv46 = new IronSourceJSON.Json+Parser();\n\tIronSourceJSON.Json+Parser::.ctor(v46, jsonString);\n\tv51 = IronSourceJSON.Json+Parser::get_NextToken(v46);\n\tv56 = IronSourceJSON.Json+Parser::ParseByToken(v46, v51);\nL_002C:\n\tgoto L_0053;\n\tv167 = *([v160 @ X8_v6+B0]);\n\tv168 = 0;\n\tv169 = v167 + 8;\n\tv171 = *([v208 @ X11_v6-8]);\n\tv213 = v171 == v163;\n\tif (v213) goto L_004C;\n\tv191 = v207 + 1;\n\tv268 = v191 < v162;\n\tv189 = ~v268;\n\tv193 = v208 + 0x10;\n\tv173 = ~v189;\n\tif (v173) goto L_FFFFFFFF;\n\tv194 = v48;\n\tv195 = 0;\n\tv196 = 0x8909C4(v194, v163, v195, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0053;\nL_004C:\n\tv269 = *([v208 @ X11_v6]);\n\tv270 = v269 << 4;\n\tv271 = v160 + v270;\n\tv272 = v271 + 0x130;\nL_0053:\n\tSystem.IDisposable::Dispose(v46);\n\tv294 = v147 + 1;\n\tv296 = v294 == 0;\n\tv299 = ~v296;\n\tif (v299) goto L_0066;\nL_005B:\n\tv301 = v104 == 0;\n\tv110 = ~v301;\n\tif (v110) goto L_006C;\nL_0066:\n\treturn v305;\n\tthrow System.NullReferenceException;\nL_006C:\n\tv118 = new System.TypeLoadException();\n\tgoto L_0080;\n\tv165 = 0x6D2BC0(v118, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv104 = *([v165 @ X0_v15]);\n\tv153 = 0x6D2490(v165, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv155 = v46 == 0;\n\tif (v155) goto L_005B;\n\tgoto L_002C;\nL_0080:\n\treturnVal1 = 0x6D2380(v118, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static object Parse(string jsonString)
			{
				Parser parser = new Parser(jsonString);
				TOKEN nextToken = parser.NextToken;
				object obj = parser.ParseByToken(nextToken);
				int num = 0;
				int num2 = 0;
				object obj2 = obj;
				((IDisposable)parser).Dispose();
				int num3 = num + 1;
				bool flag = num3 == 0;
				bool flag2 = !flag;
				object result = obj2;
				if (!flag2)
				{
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					result = obj2;
					if (flag4)
					{
						TypeLoadException ex = new TypeLoadException();
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						object result2 = default(object);
						return result2;
					}
				}
				return result;
			}

			[Token(Token = "0x600018D")]
			[Address(RVA = "0x159CB00", Offset = "0x159CB00", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.IO.TextReader::Dispose(this.json);\n\tthis.json = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				json.Dispose();
				json = null;
			}

			[Token(Token = "0x600018E")]
			[Address(RVA = "0x159CB34", Offset = "0x159CB34", Length = "0x11C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA3F98]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297A8]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tv51 = this.json;\n\tv56 = System.IO.StringReader::Read(v51);\n\tgoto L_0049;\nL_0029:\n\tv218 = IronSourceJSON.Json+Parser::get_NextToken(this);\n\tv67 = v218 != 5;\n\tif (v67) goto L_FFFFFFFF;\n\tv99 = this.json;\n\tv230 = System.IO.StringReader::Read(v99);\n\tv232 = IronSourceJSON.Json+Parser::get_NextToken(this);\n\tv151 = IronSourceJSON.Json+Parser::ParseByToken(this, v232);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v46, v217, v151);\nL_0049:\n\tv129 = IronSourceJSON.Json+Parser::get_NextToken(this);\n\tv118 = v129 == 6;\n\tif (v118) goto L_0049;\n\tv157 = v129 == 0;\n\tif (v157) goto L_FFFFFFFF;\n\tv201 = v129 == 2;\n\tif (v201) goto L_006F;\n\tv217 = IronSourceJSON.Json+Parser::ParseString(this);\n\tv226 = v217 == 0;\n\tv220 = ~v226;\n\tif (v220) goto L_0029;\nL_006F:\n\treturn v225;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private Dictionary<string, object> ParseObject()
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				StringReader stringReader = json;
				int num = stringReader.Read();
				Dictionary<string, object> result;
				while (true)
				{
					TOKEN nextToken = NextToken;
					if (nextToken == TOKEN.COMMA)
					{
						continue;
					}
					if (nextToken != TOKEN.NONE)
					{
						bool flag = nextToken == TOKEN.CURLY_CLOSE;
						result = dictionary;
						if (flag)
						{
							break;
						}
						string text = ParseString();
						if (text != null)
						{
							TOKEN nextToken2 = NextToken;
							if (nextToken2 == TOKEN.COLON)
							{
								StringReader stringReader2 = json;
								int num2 = stringReader2.Read();
								TOKEN nextToken3 = NextToken;
								object value = ParseByToken(nextToken3);
								dictionary.set_Item(text, value);
								continue;
							}
						}
					}
					result = null;
					break;
				}
				return result;
			}

			[Token(Token = "0x600018F")]
			[Address(RVA = "0x159D070", Offset = "0x159D070", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EB91D0]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20297A9]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v44);\n\tv49 = this.json;\n\tv54 = System.IO.StringReader::Read(v49);\n\tgoto L_003B;\nL_002B:\n\tv72 = v115 == 4;\n\tif (v72) goto L_0052;\n\tv160 = IronSourceJSON.Json+Parser::ParseByToken(this, v115);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v44, v160);\nL_003B:\n\tv115 = IronSourceJSON.Json+Parser::get_NextToken(this);\n\tv105 = v115 == 6;\n\tif (v105) goto L_003B;\n\tv154 = v115 == 0;\n\tv146 = ~v154;\n\tif (v146) goto L_002B;\nL_0052:\n\treturn v157;\n\tv89 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private List<object> ParseArray()
			{
				List<object> list = new List<object>();
				StringReader stringReader = json;
				int num = stringReader.Read();
				List<object> result;
				while (true)
				{
					TOKEN nextToken = NextToken;
					if (nextToken != TOKEN.COMMA)
					{
						if (nextToken == TOKEN.NONE)
						{
							result = null;
							break;
						}
						bool flag = nextToken == TOKEN.SQUARED_CLOSE;
						result = list;
						if (flag)
						{
							break;
						}
						object item = ParseByToken(nextToken);
						list.Add(item);
					}
				}
				return result;
			}

			[Token(Token = "0x6000190")]
			[Address(RVA = "0x159CAD8", Offset = "0x159CAD8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = IronSourceJSON.Json+Parser::get_NextToken(this);\n\treturnVal1 = IronSourceJSON.Json+Parser::ParseByToken(this, v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private object ParseValue()
			{
				TOKEN nextToken = NextToken;
				return ParseByToken(nextToken);
			}

			[Token(Token = "0x6000191")]
			[Address(RVA = "0x159D150", Offset = "0x159D150", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF23B0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, token, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297AA]) = v41;\nL_0015:\n\tv42 = token - 1;\n\tv43 = v42 < 9;\n\tv44 = ~v43;\n\tv45 = v42 - 9;\n\tv47 = v45 == 0;\n\tv53 = ~v47;\n\tv54 = v44 & v53;\n\tif (v54) goto L_004D;\n\tv56 = 0x183B000 + 0xAC4;\n\tv58 = *([v56 @ X9_v2 (System.Int32)+v42 @ X8_v3 (System.Int32)*4]) + v56;\n\t// 39 IndirectJump v58 @ X8_v5, 0, 0, token @ X1 (IronSourceJSON.Json+Parser+TOKEN), methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX0 = X19;\n\tX0 = IronSourceJSON.Json+Parser::ParseObject(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX0 = IronSourceJSON.Json+Parser::ParseArray(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX0 = IronSourceJSON.Json+Parser::ParseString(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 55 ShiftStack 48\n\tX0 = IronSourceJSON.Json+Parser::ParseNumber(X0, X1);\n\treturn X0;\n\tX8 = *([1EC5410]);\n\tX1 = &stack[C];\n\tX0 = *([X8]);\n\tX8 = 0 | 1;\n\tstack[C] = X8;\n\tgoto L_0046;\n\tX8 = *([1EC5410]);\n\tX1 = &stack[8];\n\tstack[8] = 0;\n\tX0 = *([X8]);\nL_0046:\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004D:\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private object ParseByToken(TOKEN token)
			{
				//IL_0029: Expected O, but got I
				int num = (int)(token - 1);
				bool flag = num < 9;
				bool flag2 = !flag;
				int num2 = num - 9;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25407488 + 2756;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X9_v2 (System.Int32)+v42 @ X8_v3 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X8_v5 (should have been resolved before IL gen)");
				}
				return null;
			}

			[Token(Token = "0x6000192")]
			[Address(RVA = "0x159CE00", Offset = "0x159CE00", Length = "0x270")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv32 = *([1EC75C8]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20297AB]) = v52;\nL_001D:\n\tv343 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v343);\n\tv64 = System.IO.StringReader::Read(this.json);\n\tv222 = this.json;\n\tv99 = 0x183B000 + 0xAA4;\nL_0032:\n\t;\n\tv227 = System.IO.StringReader::Peek(v222);\n\tv228 = v227 + 1;\n\tv230 = v228 == 0;\n\tif (v230) goto L_010D;\n\tv247 = IronSourceJSON.Json+Parser::get_NextChar(this);\n\tv106 = v247 & 0xFFFF;\n\tv86 = v106 == 0x5C;\n\tif (v86) goto L_0056;\n\tv233 = v106 != 0x22;\n\tif (v233) goto L_FFFFFFFF;\n\tgoto L_010D;\nL_0056:\n\tv110 = this.json;\n\tv251 = *([v110 @ X0_v24 (System.IO.StringReader)]);\n\tv248 = System.IO.StringReader::Peek(v110);\n\tv250 = v248 + 1;\n\tv240 = v250 == 0;\n\tif (v240) goto L_010D;\n\tv197 = IronSourceJSON.Json+Parser::get_NextChar(this);\n\tv187 = v197 & 0xFFFF;\n\tv350 = v187 < 0x5C;\n\tv351 = ~v350;\n\tv352 = v187 - 0x5C;\n\tv354 = v352 == 0;\n\tv359 = ~v354;\n\tv360 = v351 & v359;\n\tif (v360) goto L_0089;\n\tv361 = v187 - 0x22;\n\tv366 = v361 < 0x3A;\n\tv314 = ~v366;\n\tv313 = v361 - 0x3A;\n\tv311 = v313 == 0;\n\tv367 = ~v311;\n\tv306 = v314 & v367;\n\tif (v306) goto L_0105;\n\tv378 = 1 << v361;\n\tv315 = v378 & 0x400000000002001;\n\tv317 = v315 == 0;\n\tif (v317) goto L_0105;\n\tgoto L_0104;\nL_0089:\n\tv208 = v197 & 0xFFFF;\n\tv368 = v187 < 0x66;\n\tv369 = ~v368;\n\tv370 = v187 - 0x66;\n\tv372 = v370 == 0;\n\tv377 = ~v372;\n\tv126 = v369 & v377;\n\tif (v126) goto L_00AF;\n\tv156 = v208 == 0x62;\n\tif (v156) goto L_FFFFFFFF;\n\tv125 = v208 != 0x66;\n\tif (v125) goto L_0105;\n\tgoto L_FFFFFFFF;\nL_00AF:\n\tv364 = v208 - 0x6E;\n\tv380 = v364 < 7;\n\tv279 = ~v380;\n\tv277 = v364 - 7;\n\tv273 = v277 == 0;\n\tv381 = ~v273;\n\tv263 = v279 & v381;\n\tif (v263) goto L_0105;\n\tv297 = *([v99 @ X25_v6 (System.Int32)+v364 @ X8_v17 (System.Int32)*4]) + v99;\n\t// 190 IndirectJump v297 @ X8_v19, v197 @ X0_v27 (System.Char), v197 @ X0_v27 (System.Char), [v251 @ X8_v14 (Il2CppClass<System.IO.StringReader>)+1C8], 0, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\tif (TEMP) goto L_010A;\n\tX1 = 0xA;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (TEMP) goto L_010A;\n\tX1 = 0xD;\n\tgoto L_FFFFFFFF;\n\tif (TEMP) goto L_010A;\n\tX1 = 9;\n\tgoto L_FFFFFFFF;\n\tX0 = *([X22]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX21 = X0;\n\tSystem.Text.StringBuilder::.ctor(X0, X1);\n\tX27 = 0xFFFFFFFF;\nL_00D5:\n\tX0 = X19;\n\tX0 = IronSourceJSON.Json+Parser::get_NextChar(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_010A;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Text.StringBuilder::Append(X0, X1, X2);\n\tX27 = X27 + 1;\n\tC = X27 < 3;\n\tC = ~C;\n\tTEMP1 = X27 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X27 ^ 3;\n\tTEMP3 = X27 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00D5;\n\tX8 = *([X21]);\n\tX0 = X21;\n\tX9 = *([X8+160]);\n\tX1 = *([X8+168]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X26]);\n\tX21 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00FB;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FB;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FB:\n\tX1 = 0 | 0x10;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Convert::ToInt32(X0, X1, X2);\n\tX1 = X0;\n\tif (TEMP) goto L_010A;\nL_0104:\n\tv349 = System.Text.StringBuilder::Append(v343, v341);\nL_0105:\n\tv222 = this.json;\n\tv365 = this.json == 0;\n\tv200 = ~v365;\n\tif (v200) goto L_0032;\nL_010A:\n\tthrow System.NullReferenceException;\nL_010D:\n\tv298 = *([v343 @ X0_v18 (System.Text.StringBuilder)]);\n\tv259 = *([v298 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv290 = *([v298 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 285 IndirectJump v259 @ X2_v3, v343 @ X0_v18 (System.Text.StringBuilder), v343 @ X0_v18 (System.Text.StringBuilder), v290 @ X1_v5, v259 @ X2_v3, v37 @ X3, v38 @ X4, v39 @ X5, v40 @ X6, v41 @ X7, v42 @ V0, v43 @ V1, v44 @ V2, v45 @ V3, v46 @ V4, v47 @ V5, v48 @ V6, v49 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private string ParseString()
			{
				//IL_03b7: Expected I, but got O
				//IL_03c7: Expected O, but got I
				//IL_03d7: Expected O, but got I
				//IL_00b0: Expected I, but got O
				//IL_0350: Expected O, but got I
				//IL_01e8: Expected I4, but got I8
				while (true)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num = json.Read();
					StringReader stringReader = json;
					int num2 = 25407488 + 2724;
					while (true)
					{
						int num3 = stringReader.Peek();
						if (num3 + 1 == 0)
						{
							break;
						}
						char nextChar = NextChar;
						int num4 = nextChar & 0xFFFF;
						char c;
						if (num4 != 92)
						{
							bool flag = num4 != 34;
							c = nextChar;
							if (!flag)
							{
								break;
							}
							goto IL_020d;
						}
						StringReader stringReader2 = json;
						IntPtr intPtr = (IntPtr)stringReader2;
						int num5 = stringReader2.Peek();
						if (num5 + 1 == 0)
						{
							break;
						}
						char nextChar2 = NextChar;
						int num6 = nextChar2 & 0xFFFF;
						bool flag2 = num6 < 92;
						bool flag3 = !flag2;
						int num7 = num6 - 92;
						bool flag4 = num7 == 0;
						bool flag5 = !flag4;
						int num14;
						if (!(flag3 && flag5))
						{
							int num8 = num6 - 34;
							bool flag6 = num8 < 58;
							bool flag7 = !flag6;
							int num9 = num8 - 58;
							bool flag8 = num9 == 0;
							bool flag9 = !flag8;
							if (!(flag7 && flag9))
							{
								int num10 = 1 << num8;
								int num11 = (int)(num10 & 0x400000000002001L);
								bool flag10 = num11 == 0;
								c = nextChar2;
								if (!flag10)
								{
									goto IL_020d;
								}
							}
						}
						else
						{
							int num12 = nextChar2 & 0xFFFF;
							bool flag11 = num6 < 102;
							bool flag12 = !flag11;
							int num13 = num6 - 102;
							bool flag13 = num13 == 0;
							bool flag14 = !flag13;
							if (!(flag12 && flag14))
							{
								if (num12 == 98)
								{
									goto IL_035a;
								}
								if (num12 == 102)
								{
									num14 = 12;
									goto IL_0368;
								}
							}
							else
							{
								int num15 = num12 - 110;
								bool flag15 = num15 < 7;
								bool flag16 = !flag15;
								int num16 = num15 - 7;
								bool flag17 = num16 == 0;
								bool flag18 = !flag17;
								if (!(flag16 && flag18))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X25_v6 (System.Int32)+v364 @ X8_v17 (System.Int32)*4]");
									object obj = 0L + (long)num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v297 @ X8_v19 (should have been resolved before IL gen)");
									goto IL_035a;
								}
							}
						}
						goto IL_0375;
						IL_035a:
						num14 = 8;
						goto IL_0368;
						IL_020d:
						char value = c;
						goto IL_03f0;
						IL_03f0:
						StringBuilder stringBuilder2 = stringBuilder.Append(value);
						goto IL_0375;
						IL_0375:
						stringReader = json;
						if (json == null)
						{
							throw new NullReferenceException();
						}
						continue;
						IL_0368:
						value = (char)num14;
						goto IL_03f0;
					}
					IntPtr intPtr2 = (IntPtr)stringBuilder;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+160]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+168]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v259 @ X2_v3 (should have been resolved before IL gen)");
				}
			}

			[Token(Token = "0x6000193")]
			[Address(RVA = "0x159D22C", Offset = "0x159D22C", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC8E28]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297AC]) = v38;\nL_0016:\n\tv42 = IronSourceJSON.Json+Parser::get_NextWord(this);\n\tv48 = System.String::IndexOf(v42, 0x2E);\n\tv50 = v48 + 1;\n\tv52 = v50 == 0;\n\tif (v52) goto L_003A;\n\tgoto L_0033;\n\tv102 = *([v57 @ X0_v12+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0033;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v57, v45, v47, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0033:\n\tv113 = System.Double::TryParse(v42, &v110 @ stack_-28_v3 (System.Double));\n\tgoto L_0041;\nL_003A:\n\tv65 = System.Int64::TryParse(v42, &v62 @ stack_-30_v3 (System.Int64));\nL_0041:\n\treturnVal2 = \"il2cpp_vm_object_box\"(v121, &v97 @ X8_v3, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private object ParseNumber()
			{
				//IL_0096: Expected O, but got I4
				//IL_00ac: Expected O, but got I8
				//IL_0061: Expected O, but got I4
				//IL_0077: Expected O, but got F8
				string nextWord = NextWord;
				int num = nextWord.IndexOf('.');
				if (num + 1 != 0)
				{
					bool flag = double.TryParse(nextWord, out var result);
					object obj = 0;
					object typeFromHandle = typeof(double);
					object obj2 = result;
				}
				else
				{
					bool flag2 = long.TryParse(nextWord, out var result2);
					object obj = 0;
					object typeFromHandle = typeof(long);
					object obj2 = result2;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object result3 = default(object);
				return result3;
			}

			[Token(Token = "0x6000194")]
			[Address(RVA = "0x159D47C", Offset = "0x159D47C", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED53F8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = 0 | 1;\n\t*([20297AD]) = v63;\nL_0014:\n\tv66 = IronSourceJSON.Json+Parser::get_PeekChar(this);\n\tv73 = System.String::IndexOf(\" \\t\\n\\r\", v66);\n\tv95 = v73 + 1;\n\tv81 = v95 == 0;\n\tif (v81) goto L_003E;\n\tv130 = System.IO.StringReader::Read(this.json);\n\tv131 = this.json;\n\tv59 = System.IO.StringReader::Peek(v131);\n\tv61 = v59 + 1;\n\tv50 = v61 == 0;\n\tv38 = ~v50;\n\tif (v38) goto L_0014;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void EatWhitespace()
			{
				int num3;
				do
				{
					char peekChar = PeekChar;
					int num = " \t\n\r".IndexOf(peekChar);
					if (num + 1 != 0)
					{
						int num2 = json.Read();
						StringReader stringReader = json;
						num3 = stringReader.Peek();
						continue;
					}
					break;
				}
				while (num3 + 1 != 0);
			}
		}

		[Token(Token = "0x2000012")]
		private sealed class Serializer
		{
			[Token(Token = "0x400006A")]
			[FieldOffset(Offset = "0x10")]
			private StringBuilder builder;

			[Token(Token = "0x6000199")]
			[Address(RVA = "0x159D5B0", Offset = "0x159D5B0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA9F00]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297B2]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v44);\n\tthis.builder = v44;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private Serializer()
			{
				StringBuilder stringBuilder = new StringBuilder();
				builder = stringBuilder;
			}

			[Token(Token = "0x600019A")]
			[Address(RVA = "0x159C9DC", Offset = "0x159C9DC", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFDA78]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297B3]) = v38;\nL_0016:\n\tv42 = new IronSourceJSON.Json+Serializer();\n\tIronSourceJSON.Json+Serializer::.ctor(v42);\n\tIronSourceJSON.Json+Serializer::SerializeValue(v42, obj);\n\tv48 = v42.builder;\n\tv54 = *([v48 @ X0_v8 (System.Text.StringBuilder)]);\n\tv57 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv58 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 41 IndirectJump v57 @ X2_v1, v48 @ X0_v8 (System.Text.StringBuilder), v48 @ X0_v8 (System.Text.StringBuilder), v58 @ X1_v3, v57 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static string Serialize(object obj)
			{
				//IL_002c: Expected I, but got O
				//IL_003c: Expected O, but got I
				//IL_004c: Expected O, but got I
				while (true)
				{
					Serializer serializer = new Serializer();
					serializer.SerializeValue(obj);
					StringBuilder stringBuilder = serializer.builder;
					IntPtr intPtr = (IntPtr)stringBuilder;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+160]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+168]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X2_v1 (should have been resolved before IL gen)");
				}
			}

			[Token(Token = "0x600019B")]
			[Address(RVA = "0x159D61C", Offset = "0x159D61C", Length = "0x194")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEDAF0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297B4]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0044;\n\tv51 = *([value @ X1 (System.Object)]) == System.String;\n\tif (v51) goto L_FFFFFFFF;\n\tv65 = *([value @ X1 (System.Object)]) == System.Boolean;\n\tif (v65) goto L_0059;\n\t// 54 IsInst v108 @ X0_v17 (System.Collections.IList), typeof(System.Collections.IList), value @ X1 (System.Object)\n\tv183 = v108 == 0;\n\tif (v183) goto L_006F;\n\tIronSourceJSON.Json+Serializer::SerializeArray(v130, v108);\n\treturn;\nL_0044:\n\tv152 = v130.builder;\n\tgoto L_0069;\nL_0053:\n\tIronSourceJSON.Json+Serializer::SerializeString(v130, v110);\n\treturn;\nL_0059:\n\tv97 = System.Object::ToString(value);\n\tv176 = System.String::ToLower(v97);\nL_0069:\n\tv164 = System.Text.StringBuilder::Append(v152, v141);\n\treturn;\nL_006F:\n\t// 111 IsInst v196 @ X0_v19 (System.Collections.IDictionary), typeof(System.Collections.IDictionary), value @ X1 (System.Object)\n\tv133 = v196 == 0;\n\tif (v133) goto L_0085;\n\tIronSourceJSON.Json+Serializer::SerializeObject(v130, v196);\n\treturn;\nL_0085:\n\tv121 = *([value @ X1 (System.Object)]) == System.Char;\n\tif (v121) goto L_0098;\n\tIronSourceJSON.Json+Serializer::SerializeOther(v130, value);\n\treturn;\nL_0098:\n\tv237 = System.Char::ToString(value);\n\tgoto L_0053;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void SerializeValue(object value)
			{
				string value2;
				StringBuilder stringBuilder;
				if (value != null)
				{
					string str;
					if ((object)value.GetType() != typeof(string))
					{
						if ((object)value.GetType() == typeof(bool))
						{
							string text = value.ToString();
							string text2 = text.ToLower();
							value2 = text2;
							stringBuilder = builder;
							goto IL_018b;
						}
						IList list = value as IList;
						if (list != null)
						{
							SerializeArray(list);
							return;
						}
						IDictionary dictionary = value as IDictionary;
						if (dictionary != null)
						{
							SerializeObject(dictionary);
							return;
						}
						if ((object)value.GetType() != typeof(char))
						{
							SerializeOther(value);
							return;
						}
						string text3 = ((char*)value)->ToString();
						str = text3;
					}
					else
					{
						str = (string)value;
					}
					SerializeString(str);
					return;
				}
				stringBuilder = builder;
				value2 = "null";
				goto IL_018b;
				IL_018b:
				StringBuilder stringBuilder2 = stringBuilder.Append(value2);
			}

			[Token(Token = "0x600019C")]
			[Address(RVA = "0x159DD04", Offset = "0x159DD04", Length = "0x410")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EB97F0]);\n\tv31 = *([v30 @ X8_v40]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, obj, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20297B5]) = v49;\nL_001E:\n\tv54 = System.Text.StringBuilder::Append(this.builder, 0x7B);\n\tv174 = obj->klass;\n\tv177 = *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]) == 0;\n\tif (v177) goto L_0045;\n\tv347 = *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+B0]) + 8;\nL_0030:\n\tv352 = *([v347 @ X11_v43-8]) == System.Collections.IDictionary;\n\tif (v352) goto L_0048;\n\tv346 = v346 + 1;\n\tv397 = v346 < *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]);\n\tv299 = ~v397;\n\tv347 = v347 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_0030;\nL_0045:\n\tv403 = 0x8909C4(obj, System.Collections.IDictionary, 2, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_004F;\nL_0048:\n\tv399 = *([v347 @ X11_v43]) + 2;\n\tv400 = v399 << 4;\n\tv401 = v174 + v400;\n\tv403 = v401 + 0x130;\nL_004F:\n\t*([v403 @ X0_v30])(v128, obj, *([v403 @ X0_v30+8]), v122, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0080;\n\tv414 = *([v408 @ X8_v17+B0]);\n\tv415 = 0;\n\tv416 = v414 + 8;\n\tv418 = *([v457 @ X11_v38-8]);\n\tv462 = v418 == v411;\n\tif (v462) goto L_0079;\n\tv438 = v456 + 1;\n\tv468 = v438 < v410;\n\tv436 = ~v468;\n\tv440 = v457 + 0x10;\n\tv420 = ~v436;\n\tif (v420) goto L_FFFFFFFF;\n\tv441 = v139;\n\tv442 = 0;\n\tv443 = 0x8909C4(v441, v411, v442, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0080;\nL_0079:\n\tv469 = *([v457 @ X11_v38]);\n\tv470 = v469 << 4;\n\tv471 = v408 + v470;\n\tv472 = v471 + 0x130;\nL_0080:\n\tv333 = System.Collections.IEnumerable::GetEnumerator(v128);\n\tv334 = v333 == 0;\n\tif (v334) goto L_0139;\nL_008B:\n\tgoto L_00B2;\n\tv598 = *([v565 @ X8_v21+B0]);\n\tv599 = 0;\n\tv600 = v598 + 8;\n\tv602 = *([v671 @ X11_v33-8]);\n\tv676 = v602 == v566;\n\tif (v676) goto L_00AB;\n\tv622 = v670 + 1;\n\tv702 = v622 < v567;\n\tv620 = ~v702;\n\tv624 = v671 + 0x10;\n\tv604 = ~v620;\n\tif (v604) goto L_FFFFFFFF;\n\tv625 = v224;\n\tv626 = 0;\n\tv627 = 0x8909C4(v625, v566, v626, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00B2;\nL_00AB:\n\tv703 = *([v671 @ X11_v33]);\n\tv704 = v703 << 4;\n\tv705 = v565 + v704;\n\tv706 = v705 + 0x130;\nL_00B2:\n\tv511 = System.Collections.IEnumerator::MoveNext(v333);\n\tv513 = v511 == 0;\n\tif (v513) goto L_FFFFFFFF;\n\tv719 = *([v333 @ X0_v35 (System.Collections.IEnumerator)]);\n\tv722 = *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v722) goto L_00D8;\n\tv764 = *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00C3:\n\tv769 = *([v764 @ X11_v28-8]) == System.Collections.IEnumerator;\n\tif (v769) goto L_00DB;\n\tv763 = v763 + 1;\n\tv774 = v763 < *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv745 = ~v774;\n\tv764 = v764 + 0x10;\n\tv729 = ~v745;\n\tif (v729) goto L_00C3;\nL_00D8:\n\tv782 = 0x8909C4(v333, System.Collections.IEnumerator, 1, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00E2;\nL_00DB:\n\tv776 = *([v764 @ X11_v28]) + 1;\n\tv777 = v776 << 4;\n\tv778 = v719 + v777;\n\tv782 = v778 + 0x130;\nL_00E2:\n\t*([v782 @ X0_v40])(v787, v333, *([v782 @ X0_v40+8]), v793, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv788 = v183 & 1;\n\tv789 = v788 == 0;\n\tv790 = ~v789;\n\tif (v790) goto L_00F4;\n\tv798 = System.Text.StringBuilder::Append(this.builder, 0x2C);\nL_00F4:\n\tv811 = System.Object::ToString(v787);\n\tIronSourceJSON.Json+Serializer::SerializeString(this, v811);\n\tv821 = System.Text.StringBuilder::Append(this.builder, 0x3A);\n\tgoto L_012A;\n\tv825 = *([v822 @ X8_v30+B0]);\n\tv826 = 0;\n\tv827 = v825 + 8;\n\tv829 = *([v866 @ X11_v23-8]);\n\tv871 = v829 == v823;\n\tif (v871) goto L_0122;\n\tv849 = v865 + 1;\n\tv876 = v849 < v824;\n\tv847 = ~v876;\n\tv851 = v866 + 0x10;\n\tv831 = ~v847;\n\tif (v831) goto L_FFFFFFFF;\n\tv852 = v22;\n\tv853 = 0;\n\tv854 = 0x8909C4(v852, v823, v853, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_012A;\nL_0122:\n\tv877 = *([v866 @ X11_v23]);\n\tv878 = v877 << 4;\n\tv879 = v822 + v878;\n\tv880 = v879 + 0x130;\nL_012A:\n\tv886 = System.Collections.IDictionary::get_Item(obj, v787);\n\tIronSourceJSON.Json+Serializer::SerializeValue(this, v886);\n\tgoto L_008B;\n\tgoto L_0158;\n\tv815 = new System.NullReferenceException();\n\tv804 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv226 = new System.NullReferenceException();\nL_0139:\n\tv268 = new System.NullReferenceException();\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\n\tgoto L_014E;\nL_014E:\n\tv238 = v265 != 1;\n\tif (v238) goto L_01A8;\n\tv413 = 0x6D2BC0(v268, v265, v263, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv133 = *([v413 @ X0_v25]);\n\tv445 = 0x6D2490(v413, v265, v263, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0158:\n\t// 344 IsInst v521 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v333 @ X0_v35 (System.Collections.IEnumerator)\n\tv524 = v521 == 0;\n\tif (v524) goto L_0188;\n\tgoto L_0187;\n\tv628 = *([v569 @ X8_v8+B0]);\n\tv629 = 0;\n\tv630 = v628 + 8;\n\tv632 = *([v692 @ X11_v10-8]);\n\tv697 = v632 == v570;\n\tif (v697) goto L_0180;\n\tv652 = v691 + 1;\n\tv711 = v652 < v571;\n\tv650 = ~v711;\n\tv654 = v692 + 0x10;\n\tv634 = ~v650;\n\tif (v634) goto L_FFFFFFFF;\n\tv655 = v138;\n\tv656 = 0;\n\tv657 = 0x8909C4(v655, v570, v656, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0187;\nL_0180:\n\tv712 = *([v692 @ X11_v10]);\n\tv713 = v712 << 4;\n\tv714 = v569 + v713;\n\tv715 = v714 + 0x130;\nL_0187:\n\tSystem.IDisposable::Dispose(v521);\nL_0188:\n\tv597 = v60 + 1;\n\tv90 = v597 == 0;\n\tv70 = ~v90;\n\tif (v70) goto L_01A1;\n\tv658 = v133 == 0;\n\tv165 = ~v658;\n\tif (v165) goto L_01A7;\nL_01A1:\n\tv386 = System.Text.StringBuilder::Append(this.builder, 0x7D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_01A7:\n\tv172 = new System.TypeLoadException();\nL_01A8:\n\tv276 = 0x6D2380(v268, 0, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeObject(IDictionary obj)
			{
				//IL_0026: Expected I, but got O
				//IL_0061: Expected O, but got I
				//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Expected O, but got Unknown
				//IL_010e: Expected O, but got I
				//IL_011d: Expected O, but got I
				//IL_00ad: Expected O, but got I
				//IL_02fe: Expected I4, but got O
				//IL_0146: Expected I, but got O
				//IL_0181: Expected O, but got I
				//IL_020c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Expected O, but got Unknown
				//IL_022e: Expected O, but got I
				//IL_023d: Expected O, but got I
				//IL_01cd: Expected O, but got I
				StringBuilder stringBuilder = builder.Append('{');
				IntPtr intPtr = (IntPtr)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+B0]");
				object obj2 = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ X11_v43-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c6;
				}
				object obj3 = obj2 + 2;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num3;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				int num4 = 0;
				goto IL_03b2;
				IL_0378:
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				return;
				IL_00c6:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num4 = 2;
				goto IL_03b2;
				IL_03b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v403 @ X0_v30] (should have been resolved before IL gen)");
				IEnumerable enumerable = default(IEnumerable);
				IEnumerator enumerator = enumerable.GetEnumerator();
				int num10;
				int num11;
				NullReferenceException ex;
				if (enumerator != null)
				{
					int num5 = 1;
					object obj10 = default(object);
					while (enumerator.MoveNext())
					{
						IntPtr intPtr2 = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_01e6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj6 = 0L + 8L;
						int num6 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ X11_v28-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num6++;
							int num7 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag3 = (long)num7 < 0L;
							bool flag4 = !flag3;
							obj6 = (long)(IntPtr)obj6 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_01e6;
						}
						object obj7 = obj6 + 1;
						int num8 = (int)((long)(IntPtr)obj7 << 4);
						object obj8 = (long)intPtr2 + (long)num8;
						object obj9 = (long)(IntPtr)obj8 + 304L;
						int num9 = 0;
						goto IL_043f;
						IL_01e6:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						num9 = 1;
						goto IL_043f;
						IL_043f:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v782 @ X0_v40] (should have been resolved before IL gen)");
						if ((num5 & 1) == 0)
						{
							StringBuilder stringBuilder2 = builder.Append(',');
							num9 = 0;
						}
						string str = obj10.ToString();
						SerializeString(str);
						StringBuilder stringBuilder3 = builder.Append(':');
						object value = obj.get_Item(obj10);
						SerializeValue(value);
						num5 = 0;
					}
					num10 = 0;
					num11 = 0;
				}
				else
				{
					ex = new NullReferenceException();
					int num12 = default(int);
					if (num12 != 1)
					{
						goto IL_0378;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj11 = default(object);
					num11 = (int)obj11;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					num10 = -1;
				}
				(enumerator as IDisposable)?.Dispose();
				if (num10 + 1 != 0 || num11 == 0)
				{
					StringBuilder stringBuilder4 = builder.Append('}');
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				ex = (NullReferenceException)(object)ex2;
				goto IL_0378;
			}

			[Token(Token = "0x600019D")]
			[Address(RVA = "0x159DA2C", Offset = "0x159DA2C", Length = "0x2D8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECCAD8]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, anArray, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20297B6]) = v45;\nL_001C:\n\tv50 = System.Text.StringBuilder::Append(this.builder, 0x5B);\n\tgoto L_004C;\n\tv243 = *([v143 @ X8_v14+B0]);\n\tv244 = 0;\n\tv245 = v243 + 8;\n\tv247 = *([v312 @ X11_v31-8]);\n\tv318 = v247 == v146;\n\tif (v318) goto L_0045;\n\tv269 = v313 + 1;\n\tv359 = v269 < v145;\n\tv265 = ~v359;\n\tv267 = v312 + 0x10;\n\tv249 = ~v265;\n\tif (v249) goto L_FFFFFFFF;\n\tv270 = v18;\n\tv271 = 0;\n\tv272 = 0x8909C4(v270, v146, v271, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004C;\nL_0045:\n\tv360 = *([v312 @ X11_v31]);\n\tv361 = v360 << 4;\n\tv362 = v143 + v361;\n\tv363 = v362 + 0x130;\nL_004C:\n\tv299 = System.Collections.IEnumerable::GetEnumerator(anArray);\n\tv300 = v299 == 0;\n\tif (v300) goto L_00C5;\nL_0057:\n\tgoto L_007E;\n\tv402 = *([v396 @ X8_v18+B0]);\n\tv403 = 0;\n\tv404 = v402 + 8;\n\tv406 = *([v443 @ X11_v26-8]);\n\tv449 = v406 == v397;\n\tif (v449) goto L_0077;\n\tv428 = v444 + 1;\n\tv500 = v428 < v398;\n\tv424 = ~v500;\n\tv426 = v443 + 0x10;\n\tv408 = ~v424;\n\tif (v408) goto L_FFFFFFFF;\n\tv429 = v189;\n\tv430 = 0;\n\tv431 = 0x8909C4(v429, v397, v430, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_007E;\nL_0077:\n\tv501 = *([v443 @ X11_v26]);\n\tv502 = v501 << 4;\n\tv503 = v396 + v502;\n\tv504 = v503 + 0x130;\nL_007E:\n\tv489 = System.Collections.IEnumerator::MoveNext(v299);\n\tv491 = v489 == 0;\n\tif (v491) goto L_FFFFFFFF;\n\tv510 = *([v299 @ X0_v32 (System.Collections.IEnumerator)]);\n\tv513 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v513) goto L_00A4;\n\tv615 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008F:\n\tv621 = *([v615 @ X11_v21-8]) == System.Collections.IEnumerator;\n\tif (v621) goto L_00A7;\n\tv616 = v616 + 1;\n\tv647 = v616 < *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv565 = ~v647;\n\tv615 = v615 + 0x10;\n\tv549 = ~v565;\n\tif (v549) goto L_008F;\nL_00A4:\n\tv653 = 0x8909C4(v299, System.Collections.IEnumerator, 1, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00AE;\nL_00A7:\n\tv649 = *([v615 @ X11_v21]) + 1;\n\tv650 = v649 << 4;\n\tv651 = v510 + v650;\n\tv653 = v651 + 0x130;\nL_00AE:\n\t*([v653 @ X0_v37])(v656, v299, *([v653 @ X0_v37+8]), v387, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv657 = v151 & 1;\n\tv658 = v657 == 0;\n\tv659 = ~v658;\n\tif (v659) goto L_00BC;\n\tv673 = System.Text.StringBuilder::Append(this.builder, 0x2C);\nL_00BC:\n\tIronSourceJSON.Json+Serializer::SerializeValue(this, v656);\n\tgoto L_0057;\n\tgoto L_00DE;\n\tthrow System.NullReferenceException;\n\tv195 = new System.NullReferenceException();\nL_00C5:\n\tv233 = new System.NullReferenceException();\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\n\tgoto L_00D4;\nL_00D4:\n\tv205 = v230 != 1;\n\tif (v205) goto L_012C;\n\tv370 = 0x6D2BC0(v233, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv110 = *([v370 @ X0_v25]);\n\tv401 = 0x6D2490(v370, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00DE:\n\t// 222 IsInst v499 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v299 @ X0_v32 (System.Collections.IEnumerator)\n\tv509 = v499 == 0;\n\tif (v509) goto L_010E;\n\tgoto L_010D;\n\tv573 = *([v514 @ X8_v8+B0]);\n\tv574 = 0;\n\tv575 = v573 + 8;\n\tv577 = *([v636 @ X11_v10-8]);\n\tv642 = v577 == v515;\n\tif (v642) goto L_0106;\n\tv599 = v637 + 1;\n\tv660 = v599 < v516;\n\tv595 = ~v660;\n\tv597 = v636 + 0x10;\n\tv579 = ~v595;\n\tif (v579) goto L_FFFFFFFF;\n\tv600 = v106;\n\tv601 = 0;\n\tv602 = 0x8909C4(v600, v515, v601, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_010D;\nL_0106:\n\tv661 = *([v636 @ X11_v10]);\n\tv662 = v661 << 4;\n\tv663 = v514 + v662;\n\tv664 = v663 + 0x130;\nL_010D:\n\tSystem.IDisposable::Dispose(v499);\nL_010E:\n\tv542 = v57 + 1;\n\tv77 = v542 == 0;\n\tv62 = ~v77;\n\tif (v62) goto L_0125;\n\tv603 = v110 == 0;\n\tv134 = ~v603;\n\tif (v134) goto L_012B;\nL_0125:\n\tv348 = System.Text.StringBuilder::Append(this.builder, 0x5D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_012B:\n\tv141 = new System.TypeLoadException();\nL_012C:\n\tv242 = 0x6D2380(v233, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeArray(IList anArray)
			{
				//IL_01d4: Expected I4, but got O
				//IL_0039: Expected I, but got O
				//IL_0074: Expected O, but got I
				//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0104: Expected O, but got Unknown
				//IL_0121: Expected O, but got I
				//IL_0130: Expected O, but got I
				//IL_00c0: Expected O, but got I
				StringBuilder stringBuilder = builder.Append('[');
				IEnumerator enumerator = anArray.GetEnumerator();
				int num6;
				int num7;
				NullReferenceException ex;
				if (enumerator != null)
				{
					int num = 1;
					object value = default(object);
					while (enumerator.MoveNext())
					{
						IntPtr intPtr = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_00d9;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj = 0L + 8L;
						int num2 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ X11_v21-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
							{
								break;
							}
							num2++;
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag = (long)num3 < 0L;
							bool flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							if (!flag2)
							{
								continue;
							}
							goto IL_00d9;
						}
						object obj2 = obj + 1;
						int num4 = (int)((long)(IntPtr)obj2 << 4);
						object obj3 = (long)intPtr + (long)num4;
						object obj4 = (long)(IntPtr)obj3 + 304L;
						int num5 = 0;
						goto IL_02dc;
						IL_00d9:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						num5 = 1;
						goto IL_02dc;
						IL_02dc:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v653 @ X0_v37] (should have been resolved before IL gen)");
						if ((num & 1) == 0)
						{
							StringBuilder stringBuilder2 = builder.Append(',');
							num5 = 0;
						}
						SerializeValue(value);
						num = 0;
					}
					num6 = 0;
					num7 = 0;
				}
				else
				{
					ex = new NullReferenceException();
					int num8 = default(int);
					if (num8 != 1)
					{
						goto IL_024e;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj5 = default(object);
					num7 = (int)obj5;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					num6 = -1;
				}
				(enumerator as IDisposable)?.Dispose();
				if (num6 + 1 != 0 || num7 == 0)
				{
					StringBuilder stringBuilder3 = builder.Append(']');
					return;
				}
				TypeLoadException ex2 = new TypeLoadException();
				ex = (NullReferenceException)(object)ex2;
				goto IL_024e;
				IL_024e:
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}

			[Token(Token = "0x600019E")]
			[Address(RVA = "0x159D7B0", Offset = "0x159D7B0", Length = "0x27C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EE9320]);\n\tv37 = *([v36 @ X8_v33]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, str, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20297B7]) = v55;\nL_0021:\n\tv60 = System.Text.StringBuilder::Append(this.builder, 0x22);\n\tv154 = System.String::ToCharArray(str);\n\tv214 = v154.Length;\n\tv269 = v154.Length < 1;\n\tif (v269) goto L_0100;\n\tv79 = 0x183B000 + 0xAEC;\n\tgoto L_0048;\nL_0046:\n\tv342 = System.Text.StringBuilder::Append(this.builder, v154[v76 @ X24_v7 (System.Int32)]);\n\tgoto L_00E0;\nL_0048:\n\tv355 = v76 < v214;\n\tv205 = ~v355;\n\tif (v205) goto L_0103;\n\tv168 = v154[v76 @ X24_v7 (System.Int32)] - 8;\n\tv357 = v168 < 5;\n\tv304 = ~v357;\n\tv302 = v168 - 5;\n\tv298 = v302 == 0;\n\tv358 = ~v298;\n\tv94 = v304 & v358;\n\tif (v94) goto L_006F;\n\tv317 = *([v79 @ X28_v7 (System.Int32)+v168 @ X8_v10 (System.Int32)*4]) + v79;\n\t// 100 IndirectJump v317 @ X8_v30, v209 @ X0_v17 (System.Char[]), v209 @ X0_v17 (System.Char[]), v405 @ X1_v10 (System.String), v145 @ X2_v8, v327 @ X3_v7, v41 @ X4, v42 @ X5, v43 @ X6, v44 @ X7, v45 @ V0, v46 @ V1, v47 @ V2, v48 @ V3, v49 @ V4, v50 @ V5, v51 @ V6, v52 @ V7\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([1ED5630]);\n\tgoto L_FFFFFFFF;\nL_006F:\n\tv124 = v154[v76 @ X24_v7 (System.Int32)] == 0x5C;\n\tif (v124) goto L_00D8;\n\tv92 = v154[v76 @ X24_v7 (System.Int32)] != 0x22;\n\tif (v92) goto L_008A;\n\tv406 = this.builder;\n\tgoto L_FFFFFFFF;\nL_008A:\n\tgoto L_0092;\n\tv370 = *([v362 @ X0_v23+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0092;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v362, v150, v145, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0092:\n\tv246 = System.Convert::ToInt32(v154[v76 @ X24_v7 (System.Int32)]);\n\tv253 = v246 - 0x20;\n\tv391 = v253 < 0x5E;\n\tv141 = ~v391;\n\tv135 = v253 - 0x5E;\n\tv123 = v135 == 0;\n\tv392 = ~v141;\n\tv93 = v392 | v123;\n\tif (v93) goto L_0046;\n\tgoto L_00AF;\n\tv432 = *([v413 @ X0_v27+E0]);\n\tv433 = v432 == 0;\n\tv434 = ~v433;\n\tif (v434) goto L_00AF;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v413, v242, v145, v62, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00AF:\n\tv156 = System.Convert::ToString(v246, 0x10);\n\tv442 = System.String::PadLeft(v156, 4, 0x30);\n\tv247 = System.String::Concat(\"\\\\u\", v442);\n\tgoto L_00DF;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([1EB8178]);\n\tgoto L_FFFFFFFF;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([1EA6CD8]);\n\tgoto L_FFFFFFFF;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X26]);\n\tgoto L_00DF;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X25]);\n\tgoto L_00DF;\nL_00D8:\n\tv406 = this.builder;\nL_00DF:\n\tv342 = System.Text.StringBuilder::Append(v406, v405);\nL_00E0:\n\tv214 = v154.Length;\n\tv76 = v76 + 1;\n\tv330 = v76 < v154.Length;\n\tif (v330) goto L_0048;\nL_0100:\n\tv310 = System.Text.StringBuilder::Append(this.builder, 0x22);\n\treturn;\n\tv175 = new System.NullReferenceException();\nL_0103:\n\tv216 = new System.IndexOutOfRangeException();\n\tthrow v216;\n\tthrow System.NullReferenceException;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeString(string str)
			{
				//IL_007a: Expected O, but got I4
				//IL_016f: Expected O, but got I
				//IL_0372: Expected O, but got I4
				//IL_00a9: Expected O, but got I4
				//IL_00ba: Expected O, but got I4
				//IL_02be: Expected O, but got I4
				StringBuilder stringBuilder = builder.Append('"');
				char[] array = str.ToCharArray();
				int num = array.Length;
				if (array.Length >= 1)
				{
					int num2 = 25407488 + 2796;
					int num3 = 0;
					object obj = 0;
					string text = null;
					do
					{
						StringBuilder stringBuilder3;
						StringBuilder stringBuilder2;
						if (num3 < num)
						{
							int num4 = array[num3] - 8;
							bool flag = num4 < 5;
							bool flag2 = !flag;
							int num5 = num4 - 5;
							bool flag3 = num5 == 0;
							bool flag4 = !flag3;
							if (!(flag2 && flag4))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X28_v7 (System.Int32)+v168 @ X8_v10 (System.Int32)*4]");
								object obj2 = 0L + (long)num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v317 @ X8_v30 (should have been resolved before IL gen)");
							}
							string text5;
							if (array[num3] != '\\')
							{
								if (array[num3] != '"')
								{
									int num6 = Convert.ToInt32(array[num3]);
									int num7 = num6 - 32;
									bool flag5 = num7 < 94;
									bool flag6 = !flag5;
									int num8 = num7 - 94;
									bool flag7 = num8 == 0;
									bool flag8 = !flag6;
									if (flag8 || flag7)
									{
										stringBuilder2 = builder.Append(array[num3]);
										obj = 0;
										text = (string)array[num3];
										goto IL_02f2;
									}
									string text2 = Convert.ToString(num6, 16);
									string text3 = text2.PadLeft(4, '0');
									string text4 = "\\u" + text3;
									object obj3 = 0;
									text = text4;
									stringBuilder3 = builder;
									goto IL_0358;
								}
								stringBuilder3 = builder;
								text5 = "\\\"";
							}
							else
							{
								stringBuilder3 = builder;
								text5 = "\\\\";
							}
							text = text5;
							goto IL_0358;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
						IL_02f2:
						num = array.Length;
						num3++;
						continue;
						IL_0358:
						stringBuilder2 = stringBuilder3.Append(text);
						obj = 0;
						goto IL_02f2;
					}
					while (num3 < array.Length);
				}
				StringBuilder stringBuilder4 = builder.Append('"');
			}

			[Token(Token = "0x600019F")]
			[Address(RVA = "0x159E114", Offset = "0x159E114", Length = "0x17C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = *([1EE87C0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20297B8]) = v41;\nL_001F:\n\tv51 = *([value @ X1 (System.Object)]) == System.Single;\n\tif (v51) goto L_00B9;\n\tv101 = *([value @ X1 (System.Object)]) == System.Int32;\n\tif (v101) goto L_00B9;\n\tv142 = *([value @ X1 (System.Object)]) == System.UInt32;\n\tif (v142) goto L_00B9;\n\tv143 = *([value @ X1 (System.Object)]) == System.Int64;\n\tif (v143) goto L_00B9;\n\tv144 = *([value @ X1 (System.Object)]) == System.Double;\n\tif (v144) goto L_00B9;\n\tv145 = *([value @ X1 (System.Object)]) == System.SByte;\n\tif (v145) goto L_00B9;\n\tv146 = *([value @ X1 (System.Object)]) == System.Byte;\n\tif (v146) goto L_00B9;\n\tv147 = *([value @ X1 (System.Object)]) == System.Int16;\n\tif (v147) goto L_00B9;\n\tv148 = *([value @ X1 (System.Object)]) == System.UInt16;\n\tif (v148) goto L_00B9;\n\tv149 = *([value @ X1 (System.Object)]) == System.UInt64;\n\tif (v149) goto L_00B9;\n\tv150 = *([value @ X1 (System.Object)]) == System.Decimal;\n\tif (v150) goto L_00B9;\n\tv254 = System.Object::ToString(value);\n\tIronSourceJSON.Json+Serializer::SerializeString(this, v254);\n\treturn;\nL_00B9:\n\tv86 = System.Object::ToString(value);\n\tv200 = System.Text.StringBuilder::Append(this.builder, v86);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeOther(object value)
			{
				if ((object)value.GetType() != typeof(float) && (object)value.GetType() != typeof(int) && (object)value.GetType() != typeof(uint) && (object)value.GetType() != typeof(long) && (object)value.GetType() != typeof(double) && (object)value.GetType() != typeof(sbyte) && (object)value.GetType() != typeof(byte) && (object)value.GetType() != typeof(short) && (object)value.GetType() != typeof(ushort) && (object)value.GetType() != typeof(ulong) && (object)value.GetType() != typeof(decimal))
				{
					string str = value.ToString();
					SerializeString(str);
				}
				else
				{
					string value2 = value.ToString();
					StringBuilder stringBuilder = builder.Append(value2);
				}
			}
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x158F5F8", Offset = "0x158F5F8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = json == 0;\n\tif (v0) goto L_0004;\n\treturnVal2 = IronSourceJSON.Json+Parser::Parse(json);\n\treturn returnVal2;\nL_0004:\n\treturn json;\n")]
		public static object Deserialize(string json)
		{
			if (json != null)
			{
				return Parser.Parse(json);
			}
			return json;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0x158F728", Offset = "0x158F728", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = IronSourceJSON.Json+Serializer::Serialize(obj);\n\treturn returnVal1;\n")]
		public static string Serialize(object obj)
		{
			return Serializer.Serialize(obj);
		}
	}
}
