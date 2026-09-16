using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.MiniJSON
{
	[Token(Token = "0x2000005")]
	public static class Json
	{
		[Token(Token = "0x2000006")]
		private sealed class Parser : IDisposable
		{
			[Token(Token = "0x2000007")]
			private enum TOKEN
			{
				[Token(Token = "0x4000003")]
				NONE = 0,
				[Token(Token = "0x4000004")]
				CURLY_OPEN = 1,
				[Token(Token = "0x4000005")]
				CURLY_CLOSE = 2,
				[Token(Token = "0x4000006")]
				SQUARED_OPEN = 3,
				[Token(Token = "0x4000007")]
				SQUARED_CLOSE = 4,
				[Token(Token = "0x4000008")]
				COLON = 5,
				[Token(Token = "0x4000009")]
				COMMA = 6,
				[Token(Token = "0x400000A")]
				STRING = 7,
				[Token(Token = "0x400000B")]
				NUMBER = 8,
				[Token(Token = "0x400000C")]
				TRUE = 9,
				[Token(Token = "0x400000D")]
				FALSE = 10,
				[Token(Token = "0x400000E")]
				NULL = 11
			}

			[Token(Token = "0x4000001")]
			[FieldOffset(Offset = "0x10")]
			private StringReader json;

			[Token(Token = "0x17000001")]
			private char PeekChar
			{
				[Token(Token = "0x6000017")]
				[Address(RVA = "0x166DF5C", Offset = "0x166DF5C", Length = "0x88")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBBF80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B232]) = v38;\nL_0019:\n\tv44 = System.IO.StringReader::Peek(this.json);\n\tgoto L_002F;\n\tv53 = *([v48 @ X8_v6+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002F;\n\tv67 = v48;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v67, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\treturnVal2 = System.Convert::ToChar(v44);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					int value = json.Peek();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x17000002")]
			private char NextChar
			{
				[Token(Token = "0x6000018")]
				[Address(RVA = "0x166DD60", Offset = "0x166DD60", Length = "0x88")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB76D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B233]) = v38;\nL_0019:\n\tv44 = System.IO.StringReader::Read(this.json);\n\tgoto L_002F;\n\tv53 = *([v48 @ X8_v6+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002F;\n\tv67 = v48;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v67, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\treturnVal2 = System.Convert::ToChar(v44);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					int value = json.Read();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x17000003")]
			private string NextWord
			{
				[Token(Token = "0x6000019")]
				[Address(RVA = "0x166DDE8", Offset = "0x166DDE8", Length = "0xC0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB0EC8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B234]) = v38;\nL_0016:\n\tv42 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v42);\nL_001B:\n\tv74 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_PeekChar(this);\n\tv75 = UnityEngine.Purchasing.MiniJSON.Json+Parser::IsWordBreak(v74);\n\tv77 = v75 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_003A;\n\tv80 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextChar(this);\n\tv108 = System.Text.StringBuilder::Append(v42, v80);\n\tv129 = this.json;\n\tv68 = System.IO.StringReader::Peek(v129);\n\tv70 = v68 + 1;\n\tv56 = v70 == 0;\n\tv47 = ~v56;\n\tif (v47) goto L_001B;\n\tgoto L_003A;\nL_003A:\n\tv95 = *([v42 @ X0_v3 (System.Text.StringBuilder)]);\n\tv99 = *([v95 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv100 = *([v95 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 67 IndirectJump v99 @ X2_v4, v42 @ X0_v3 (System.Text.StringBuilder), v42 @ X0_v3 (System.Text.StringBuilder), v100 @ X1_v6, v99 @ X2_v4, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_00ca: Expected I, but got O
					//IL_00da: Expected O, but got I
					//IL_00ea: Expected O, but got I
					while (true)
					{
						StringBuilder stringBuilder = new StringBuilder();
						int num;
						do
						{
							char peekChar = PeekChar;
							if (IsWordBreak(peekChar))
							{
								break;
							}
							char nextChar = NextChar;
							StringBuilder stringBuilder2 = stringBuilder.Append(nextChar);
							StringReader stringReader = json;
							num = stringReader.Peek();
						}
						while (num + 1 != 0);
						IntPtr intPtr = (IntPtr)stringBuilder;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+160]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v7 (Il2CppClass<System.Text.StringBuilder>)+168]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v99 @ X2_v4 (should have been resolved before IL gen)");
					}
				}
			}

			[Token(Token = "0x17000004")]
			private TOKEN NextToken
			{
				[Token(Token = "0x600001A")]
				[Address(RVA = "0x166D5D0", Offset = "0x166D5D0", Length = "0x1B4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F02628]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B235]) = v38;\nL_0014:\n\tUnityEngine.Purchasing.MiniJSON.Json+Parser::EatWhitespace(this);\n\tv40 = this.json;\n\tv42 = *([v40 @ X0_v3 (System.IO.StringReader)]);\n\tv45 = System.IO.StringReader::Peek(v40);\n\tv46 = v45 + 1;\n\tv48 = v46 == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv100 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_PeekChar(this);\n\tv97 = v100 & 0xFFFF;\n\tv136 = v97 < 0x5B;\n\tv137 = ~v136;\n\tv138 = v97 - 0x5B;\n\tv140 = v138 == 0;\n\tv145 = ~v140;\n\tv54 = v137 & v145;\n\tif (v54) goto L_004A;\n\tv183 = v97 - 0x22;\n\tv236 = v183 < 0x18;\n\tv220 = ~v236;\n\tv216 = v183 - 0x18;\n\tv222 = v216 == 0;\n\tv237 = ~v222;\n\tv208 = v220 & v237;\n\tif (v208) goto L_0082;\n\tv240 = 0x185E000 + 0xBF8;\n\tv233 = *([v240 @ X8_v17 (System.Int32)+v183 @ X9_v8 (System.Int32)*4]) + v240;\n\t// 67 IndirectJump v233 @ X8_v18, 5, 5, [v42 @ X8_v4 (Il2CppClass<System.IO.StringReader>)+1C8], v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = 0 | 8;\n\tgoto L_00BD;\nL_004A:\n\tv82 = v97 == 0x5D;\n\tif (v82) goto L_0074;\n\tv170 = v97 == 0x7B;\n\tif (v170) goto L_FFFFFFFF;\n\tv53 = v97 != 0x7D;\n\tif (v53) goto L_0087;\n\tv249 = System.IO.StringReader::Read(this.json);\n\tgoto L_00BD;\nL_0074:\n\tv245 = System.IO.StringReader::Read(this.json);\n\tgoto L_00BD;\n\tgoto L_00BD;\nL_0082:\n\tv150 = v97 != 0x5B;\n\tif (v150) goto L_0087;\n\tgoto L_00BD;\nL_0087:\n\tv126 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextWord(this);\n\tv129 = v126 == 0;\n\tif (v129) goto L_FFFFFFFF;\n\tv248 = System.String::op_Equality(v126, \"false\");\n\tv193 = v248 == 0;\n\tif (v193) goto L_009B;\n\tgoto L_00BD;\nL_009B:\n\tv253 = System.String::op_Equality(v126, \"true\");\n\tv194 = v253 == 0;\n\tif (v194) goto L_00B1;\n\tgoto L_00BD;\n\tX0 = 0 | 7;\n\tgoto L_00BD;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X0]);\n\tX9 = *([X8+1D0]);\n\tX1 = *([X8+1D8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0 | 6;\n\tgoto L_00BD;\nL_00B1:\n\tv127 = System.String::op_Equality(v126, \"null\");\n\tv130 = v127 == 0;\n\tif (v130) goto L_FFFFFFFF;\n\tgoto L_00BD;\nL_00BD:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000d: Expected I, but got O
					//IL_0149: Expected O, but got I
					EatWhitespace();
					StringReader stringReader = json;
					IntPtr intPtr = (IntPtr)stringReader;
					int num = stringReader.Peek();
					if (num + 1 != 0)
					{
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
							if (flag6 && flag8)
							{
								if (num2 == 91)
								{
									return TOKEN.SQUARED_OPEN;
								}
								goto IL_0223;
							}
							int num6 = 25550848 + 3064;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v17 (System.Int32)+v183 @ X9_v8 (System.Int32)*4]");
							object obj = 0L + (long)num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v233 @ X8_v18 (should have been resolved before IL gen)");
						}
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
						goto IL_0223;
					}
					goto IL_0301;
					IL_0223:
					string nextWord = NextWord;
					if (nextWord != null)
					{
						switch (nextWord)
						{
						case "false":
							return TOKEN.FALSE;
						case "true":
							return TOKEN.TRUE;
						case "null":
							return TOKEN.NULL;
						}
					}
					goto IL_0301;
					IL_0301:
					return default(TOKEN);
				}
			}

			[Token(Token = "0x600000C")]
			[Address(RVA = "0x166D33C", Offset = "0x166D33C", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC2D70]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B229]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = System.Char::IsWhiteSpace(c);\n\tv56 = v54 == 0;\n\tif (v56) goto L_002E;\n\tgoto L_003B;\nL_002E:\n\tv90 = System.String::IndexOf(\"{}[],:\\\"\", c);\n\tv84 = v90 + 1;\n\tv72 = v84 == 0;\n\tv63 = ~v72;\nL_003B:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public static bool IsWordBreak(char c)
			{
				if (char.IsWhiteSpace(c))
				{
					return true;
				}
				int num = "{}[],:\"".IndexOf(c);
				int num2 = num + 1;
				bool flag = num2 == 0;
				return !flag;
			}

			[Token(Token = "0x600000D")]
			[Address(RVA = "0x166D3DC", Offset = "0x166D3DC", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED5ED0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, jsonString, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B22A]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv47 = new System.IO.StringReader();\n\tSystem.IO.StringReader::.ctor(v47, jsonString);\n\tthis.json = v47;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private Parser(string jsonString)
			{
				StringReader stringReader = new StringReader(jsonString);
				json = stringReader;
			}

			[Token(Token = "0x600000E")]
			[Address(RVA = "0x166D178", Offset = "0x166D178", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDBF88]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202B22B]) = v42;\nL_0018:\n\tv46 = new UnityEngine.Purchasing.MiniJSON.Json+Parser();\n\tUnityEngine.Purchasing.MiniJSON.Json+Parser::.ctor(v46, jsonString);\n\tv51 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(v46);\n\tv56 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseByToken(v46, v51);\nL_002C:\n\tgoto L_0053;\n\tv167 = *([v160 @ X8_v6+B0]);\n\tv168 = 0;\n\tv169 = v167 + 8;\n\tv171 = *([v208 @ X11_v6-8]);\n\tv213 = v171 == v163;\n\tif (v213) goto L_004C;\n\tv191 = v207 + 1;\n\tv268 = v191 < v162;\n\tv189 = ~v268;\n\tv193 = v208 + 0x10;\n\tv173 = ~v189;\n\tif (v173) goto L_FFFFFFFF;\n\tv194 = v48;\n\tv195 = 0;\n\tv196 = 0x8909C4(v194, v163, v195, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0053;\nL_004C:\n\tv269 = *([v208 @ X11_v6]);\n\tv270 = v269 << 4;\n\tv271 = v160 + v270;\n\tv272 = v271 + 0x130;\nL_0053:\n\tSystem.IDisposable::Dispose(v46);\n\tv294 = v147 + 1;\n\tv296 = v294 == 0;\n\tv299 = ~v296;\n\tif (v299) goto L_0066;\nL_005B:\n\tv301 = v104 == 0;\n\tv110 = ~v301;\n\tif (v110) goto L_006C;\nL_0066:\n\treturn v305;\n\tthrow System.NullReferenceException;\nL_006C:\n\tv118 = new System.TypeLoadException();\n\tgoto L_0080;\n\tv165 = 0x6D2BC0(v118, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv104 = *([v165 @ X0_v15]);\n\tv153 = 0x6D2490(v165, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv155 = v46 == 0;\n\tif (v155) goto L_005B;\n\tgoto L_002C;\nL_0080:\n\treturnVal1 = 0x6D2380(v118, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

			[Token(Token = "0x600000F")]
			[Address(RVA = "0x166D480", Offset = "0x166D480", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.IO.TextReader::Dispose(this.json);\n\tthis.json = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				json.Dispose();
				json = null;
			}

			[Token(Token = "0x6000010")]
			[Address(RVA = "0x166D4B4", Offset = "0x166D4B4", Length = "0x11C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED4EB0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202B22C]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tv51 = this.json;\n\tv56 = System.IO.StringReader::Read(v51);\n\tgoto L_0049;\nL_0029:\n\tv218 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(this);\n\tv67 = v218 != 5;\n\tif (v67) goto L_FFFFFFFF;\n\tv99 = this.json;\n\tv230 = System.IO.StringReader::Read(v99);\n\tv232 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(this);\n\tv151 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseByToken(this, v232);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v46, v217, v151);\nL_0049:\n\tv129 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(this);\n\tv118 = v129 == 6;\n\tif (v118) goto L_0049;\n\tv157 = v129 == 0;\n\tif (v157) goto L_FFFFFFFF;\n\tv201 = v129 == 2;\n\tif (v201) goto L_006F;\n\tv217 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseString(this);\n\tv226 = v217 == 0;\n\tv220 = ~v226;\n\tif (v220) goto L_0029;\nL_006F:\n\treturn v225;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

			[Token(Token = "0x6000011")]
			[Address(RVA = "0x166DA10", Offset = "0x166DA10", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA6EC8]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202B22D]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v44);\n\tv49 = this.json;\n\tv54 = System.IO.StringReader::Read(v49);\n\tgoto L_003B;\nL_002B:\n\tv72 = v115 == 4;\n\tif (v72) goto L_0052;\n\tv160 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseByToken(this, v115);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v44, v160);\nL_003B:\n\tv115 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(this);\n\tv105 = v115 == 6;\n\tif (v105) goto L_003B;\n\tv154 = v115 == 0;\n\tv146 = ~v154;\n\tif (v146) goto L_002B;\nL_0052:\n\treturn v157;\n\tv89 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

			[Token(Token = "0x6000012")]
			[Address(RVA = "0x166D458", Offset = "0x166D458", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextToken(this);\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseByToken(this, v10);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private object ParseValue()
			{
				TOKEN nextToken = NextToken;
				return ParseByToken(nextToken);
			}

			[Token(Token = "0x6000013")]
			[Address(RVA = "0x166DAF0", Offset = "0x166DAF0", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF3E58]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, token, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B22E]) = v41;\nL_0015:\n\tv42 = token - 1;\n\tv43 = v42 < 9;\n\tv44 = ~v43;\n\tv45 = v42 - 9;\n\tv47 = v45 == 0;\n\tv53 = ~v47;\n\tv54 = v44 & v53;\n\tif (v54) goto L_004D;\n\tv56 = 0x185E000 + 0xC7C;\n\tv58 = *([v56 @ X9_v2 (System.Int32)+v42 @ X8_v3 (System.Int32)*4]) + v56;\n\t// 39 IndirectJump v58 @ X8_v5, 0, 0, token @ X1 (UnityEngine.Purchasing.MiniJSON.Json+Parser+TOKEN), methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX0 = X19;\n\tX0 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseObject(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX0 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseArray(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX0 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseString(X0, X1);\n\tgoto L_004D;\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 55 ShiftStack 48\n\tX0 = UnityEngine.Purchasing.MiniJSON.Json+Parser::ParseNumber(X0, X1);\n\treturn X0;\n\tX8 = *([1EC5410]);\n\tX1 = &stack[C];\n\tX0 = *([X8]);\n\tX8 = 0 | 1;\n\tstack[C] = X8;\n\tgoto L_0046;\n\tX8 = *([1EC5410]);\n\tX1 = &stack[8];\n\tstack[8] = 0;\n\tX0 = *([X8]);\nL_0046:\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004D:\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					int num3 = 25550848 + 3196;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X9_v2 (System.Int32)+v42 @ X8_v3 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X8_v5 (should have been resolved before IL gen)");
				}
				return null;
			}

			[Token(Token = "0x6000014")]
			[Address(RVA = "0x166D784", Offset = "0x166D784", Length = "0x28C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EBAFF8]);\n\tv35 = *([v34 @ X8_v24]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202B22F]) = v54;\nL_001E:\n\tv352 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v352);\n\tv66 = System.IO.StringReader::Read(this.json);\n\tv229 = this.json;\n\tv101 = 0x185E000 + 0xC5C;\nL_0035:\n\t;\n\tv234 = System.IO.StringReader::Peek(v229);\n\tv235 = v234 + 1;\n\tv237 = v235 == 0;\n\tif (v237) goto L_0118;\n\tv254 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextChar(this);\n\tv110 = v254 & 0xFFFF;\n\tv88 = v110 == 0x5C;\n\tif (v88) goto L_0059;\n\tv240 = v110 != 0x22;\n\tif (v240) goto L_FFFFFFFF;\n\tgoto L_0118;\nL_0059:\n\tv114 = this.json;\n\tv258 = *([v114 @ X0_v24 (System.IO.StringReader)]);\n\tv255 = System.IO.StringReader::Peek(v114);\n\tv257 = v255 + 1;\n\tv247 = v257 == 0;\n\tif (v247) goto L_0118;\n\tv204 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextChar(this);\n\tv194 = v204 & 0xFFFF;\n\tv359 = v194 < 0x5C;\n\tv360 = ~v359;\n\tv361 = v194 - 0x5C;\n\tv363 = v361 == 0;\n\tv368 = ~v363;\n\tv369 = v360 & v368;\n\tif (v369) goto L_008C;\n\tv370 = v194 - 0x22;\n\tv375 = v370 < 0x3A;\n\tv323 = ~v375;\n\tv322 = v370 - 0x3A;\n\tv320 = v322 == 0;\n\tv376 = ~v320;\n\tv315 = v323 & v376;\n\tif (v315) goto L_0110;\n\tv387 = 1 << v370;\n\tv324 = v387 & 0x400000000002001;\n\tv326 = v324 == 0;\n\tif (v326) goto L_0110;\n\tgoto L_010F;\nL_008C:\n\tv215 = v204 & 0xFFFF;\n\tv377 = v194 < 0x66;\n\tv378 = ~v377;\n\tv379 = v194 - 0x66;\n\tv381 = v379 == 0;\n\tv386 = ~v381;\n\tv131 = v378 & v386;\n\tif (v131) goto L_00B2;\n\tv161 = v215 == 0x62;\n\tif (v161) goto L_FFFFFFFF;\n\tv130 = v215 != 0x66;\n\tif (v130) goto L_0110;\n\tgoto L_FFFFFFFF;\nL_00B2:\n\tv373 = v215 - 0x6E;\n\tv389 = v373 < 7;\n\tv286 = ~v389;\n\tv284 = v373 - 7;\n\tv280 = v284 == 0;\n\tv390 = ~v280;\n\tv270 = v286 & v390;\n\tif (v270) goto L_0110;\n\tv306 = *([v101 @ X24_v6 (System.Int32)+v373 @ X8_v19 (System.Int32)*4]) + v101;\n\t// 193 IndirectJump v306 @ X8_v21, v204 @ X0_v27 (System.Char), v204 @ X0_v27 (System.Char), [v258 @ X8_v16 (Il2CppClass<System.IO.StringReader>)+1C8], 0, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tif (TEMP) goto L_0115;\n\tX1 = 0xA;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (TEMP) goto L_0115;\n\tX1 = 0xD;\n\tgoto L_FFFFFFFF;\n\tif (TEMP) goto L_0115;\n\tX1 = 9;\n\tgoto L_FFFFFFFF;\n\tX0 = *([X25]);\n\tX1 = 0 | 4;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX27 = 0;\n\tX28 = X21 + 0x20;\nL_00D8:\n\tX0 = X19;\n\tX0 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextChar(X0, X1);\n\tif (TEMP) goto L_0115;\n\tX8 = *([X21+18]);\n\tC = X27 < X8;\n\tC = ~C;\n\tTEMP1 = X27 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X27 ^ X8;\n\tTEMP3 = X27 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_012A;\n\tX8 = X27 + 1;\n\tC = X27 < 3;\n\tC = ~C;\n\tTEMP1 = X27 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X27 ^ 3;\n\tTEMP3 = X27 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X28+X27*2]) = X0;\n\tX27 = X8;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00D8;\n\tX0 = 0;\n\tX1 = X21;\n\tX2 = 0;\n\tX0 = System.String::CreateString(X0, X1, X2);\n\tX8 = *([X26]);\n\tX21 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0106;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0106;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0106:\n\tX1 = 0 | 0x10;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Convert::ToInt32(X0, X1, X2);\n\tX1 = X0;\n\tif (TEMP) goto L_0115;\nL_010F:\n\tv358 = System.Text.StringBuilder::Append(v352, v350);\nL_0110:\n\tv229 = this.json;\n\tv374 = this.json == 0;\n\tv207 = ~v374;\n\tif (v207) goto L_0035;\nL_0115:\n\tthrow System.NullReferenceException;\nL_0118:\n\tv307 = *([v352 @ X0_v18 (System.Text.StringBuilder)]);\n\tv266 = *([v307 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv299 = *([v307 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 297 IndirectJump v266 @ X2_v3, v352 @ X0_v18 (System.Text.StringBuilder), v352 @ X0_v18 (System.Text.StringBuilder), v299 @ X1_v5, v266 @ X2_v3, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\nL_012A:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					int num2 = 25550848 + 3164;
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
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X24_v6 (System.Int32)+v373 @ X8_v19 (System.Int32)*4]");
									object obj = 0L + (long)num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v306 @ X8_v21 (should have been resolved before IL gen)");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+160]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v8 (Il2CppClass<System.Text.StringBuilder>)+168]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v266 @ X2_v3 (should have been resolved before IL gen)");
				}
			}

			[Token(Token = "0x6000015")]
			[Address(RVA = "0x166DBCC", Offset = "0x166DBCC", Length = "0x194")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFF2B8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202B230]) = v40;\nL_0017:\n\tv44 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_NextWord(this);\n\tv50 = System.String::IndexOf(v44, 0x2E);\n\tv52 = v50 + 1;\n\tv54 = v52 == 0;\n\tv57 = ~v54;\n\tif (v57) goto L_0036;\n\tv61 = System.String::IndexOf(v44, 0x65);\n\tv74 = v61 + 1;\n\tv67 = v74 == 0;\n\tif (v67) goto L_0062;\nL_0036:\n\tgoto L_003E;\n\tgoto L_003E;\n\tv166 = v147;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v166, v141, v139, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003E:\n\tv164 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tgoto L_0052;\n\tv177 = *([v170 @ X8_v5+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_0052;\n\tv195 = v170;\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v195, v158, v157, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\tv190 = System.Double::TryParse(v44, 0x1FF, v164, &v186 @ stack_-28_v3 (System.Double));\nL_0057:\n\treturnVal2 = \"il2cpp_vm_object_box\"(v215, &v124 @ X8_v3 (System.Double), v114, v93, v89, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\nL_0062:\n\tv144 = System.String::IndexOf(v44, 0x45);\n\tv176 = v144 + 1;\n\tv136 = v176 == 0;\n\tif (v136) goto L_0074;\n\tgoto L_003E;\n\tgoto L_003E;\nL_0074:\n\tgoto L_007C;\n\tv198 = *([v148 @ X8_v13 (Il2CppClass<System.Globalization.CultureInfo>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_007C;\n\tv219 = v148;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v219, v142, v140, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_007C:\n\tv206 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv221 = System.Int64::TryParse(v44, 0x1FF, v206, &v207 @ stack_-38_v3 (System.Int64));\n\tgoto L_0057;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private object ParseNumber()
			{
				//IL_00c0: Expected O, but got I4
				//IL_00c8: Expected O, but got F8
				//IL_0163: Expected O, but got I4
				//IL_016b: Expected O, but got I8
				string nextWord = NextWord;
				int num = nextWord.IndexOf('.');
				object obj;
				object obj2;
				IFormatProvider formatProvider;
				object typeFromHandle;
				double num4;
				if (num + 1 == 0)
				{
					int num2 = nextWord.IndexOf('e');
					if (num2 + 1 == 0)
					{
						int num3 = nextWord.IndexOf('E');
						if (num3 + 1 == 0)
						{
							CultureInfo invariantCulture = CultureInfo.InvariantCulture;
							bool flag = long.TryParse(nextWord, NumberStyles.Any, invariantCulture, out var result);
							obj = 0;
							obj2 = result;
							formatProvider = invariantCulture;
							typeFromHandle = typeof(long);
							num4 = result;
							goto IL_019e;
						}
					}
				}
				CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
				bool flag2 = double.TryParse(nextWord, NumberStyles.Any, invariantCulture2, out var result2);
				obj = 0;
				obj2 = result2;
				formatProvider = invariantCulture2;
				typeFromHandle = typeof(double);
				num4 = result2;
				goto IL_019e;
				IL_019e:
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object result3 = default(object);
				return result3;
			}

			[Token(Token = "0x6000016")]
			[Address(RVA = "0x166DEA8", Offset = "0x166DEA8", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEFDE0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv61 = 0 | 1;\n\t*([202B231]) = v61;\nL_0014:\n\tv66 = UnityEngine.Purchasing.MiniJSON.Json+Parser::get_PeekChar(this);\n\tgoto L_0025;\n\tv73 = *([v69 @ X8_v5+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0025;\n\tv83 = v69;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v83, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tv82 = System.Char::IsWhiteSpace(v66);\n\tv85 = v82 == 0;\n\tif (v85) goto L_0043;\n\tv105 = System.IO.StringReader::Read(this.json);\n\tv106 = this.json;\n\tv57 = System.IO.StringReader::Peek(v106);\n\tv59 = v57 + 1;\n\tv47 = v59 == 0;\n\tv38 = ~v47;\n\tif (v38) goto L_0014;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void EatWhitespace()
			{
				int num2;
				do
				{
					char peekChar = PeekChar;
					if (char.IsWhiteSpace(peekChar))
					{
						int num = json.Read();
						StringReader stringReader = json;
						num2 = stringReader.Peek();
						continue;
					}
					break;
				}
				while (num2 + 1 != 0);
			}
		}

		[Token(Token = "0x2000008")]
		private sealed class Serializer
		{
			[Token(Token = "0x400000F")]
			[FieldOffset(Offset = "0x10")]
			private StringBuilder builder;

			[Token(Token = "0x600001B")]
			[Address(RVA = "0x166DFE4", Offset = "0x166DFE4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA7F48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B236]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v44);\n\tthis.builder = v44;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private Serializer()
			{
				StringBuilder stringBuilder = new StringBuilder();
				builder = stringBuilder;
			}

			[Token(Token = "0x600001C")]
			[Address(RVA = "0x166D2BC", Offset = "0x166D2BC", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB9E18]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202B237]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Purchasing.MiniJSON.Json+Serializer();\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::.ctor(v42);\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeValue(v42, obj);\n\tv48 = v42.builder;\n\tv54 = *([v48 @ X0_v8 (System.Text.StringBuilder)]);\n\tv57 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv58 = *([v54 @ X8_v5 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 41 IndirectJump v57 @ X2_v1, v48 @ X0_v8 (System.Text.StringBuilder), v48 @ X0_v8 (System.Text.StringBuilder), v58 @ X1_v3, v57 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

			[Token(Token = "0x600001D")]
			[Address(RVA = "0x166E050", Offset = "0x166E050", Length = "0x1AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECCCD8]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B238]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0044;\n\tv51 = *([value @ X1 (System.Object)]) == System.String;\n\tif (v51) goto L_FFFFFFFF;\n\tv65 = *([value @ X1 (System.Object)]) == System.Boolean;\n\tif (v65) goto L_0056;\n\t// 54 IsInst v79 @ X0_v15 (System.Collections.IList), typeof(System.Collections.IList), value @ X1 (System.Object)\n\tv183 = v79 == 0;\n\tif (v183) goto L_007C;\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeArray(v107, v79);\n\treturn;\nL_0044:\n\tv151 = v107.builder;\n\tgoto L_0076;\nL_0052:\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeString(v107, v87);\n\treturn;\nL_0056:\n\tv82 = \"il2cpp_vm_object_unbox\"(value, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv120 = *([v82 @ X0_v12]) != 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0076;\nL_0076:\n\tv166 = System.Text.StringBuilder::Append(v151, *([v156 @ X8_v3 (System.String)]));\n\treturn;\nL_007C:\n\t// 124 IsInst v195 @ X0_v17 (System.Collections.IDictionary), typeof(System.Collections.IDictionary), value @ X1 (System.Object)\n\tv110 = v195 == 0;\n\tif (v110) goto L_0092;\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeObject(v107, v195);\n\treturn;\nL_0092:\n\tv98 = *([value @ X1 (System.Object)]) == System.Char;\n\tif (v98) goto L_00A3;\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeOther(v107, value);\n\treturn;\nL_00A3:\n\tv241 = \"il2cpp_vm_object_unbox\"(value, System.Collections.IDictionary, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv244 = System.String::CreateString(0, *([v241 @ X0_v19]), 1);\n\tgoto L_0052;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeValue(object value)
			{
				//IL_019b: Expected I4, but got O
				StringBuilder stringBuilder;
				string value2;
				if (value != null)
				{
					string str;
					if ((object)value.GetType() != typeof(string))
					{
						if ((object)value.GetType() == typeof(bool))
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							if (obj == null)
							{
								stringBuilder = builder;
								value2 = "false";
							}
							else
							{
								stringBuilder = builder;
								value2 = "true";
							}
							goto IL_01ce;
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
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj2 = default(object);
						string text = ((string)null).CreateString((char)(int)obj2, 1);
						str = text;
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
				goto IL_01ce;
				IL_01ce:
				StringBuilder stringBuilder2 = stringBuilder.Append(value2);
			}

			[Token(Token = "0x600001E")]
			[Address(RVA = "0x166E740", Offset = "0x166E740", Length = "0x410")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EC05C0]);\n\tv31 = *([v30 @ X8_v40]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, obj, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([202B239]) = v49;\nL_001E:\n\tv54 = System.Text.StringBuilder::Append(this.builder, 0x7B);\n\tv174 = obj->klass;\n\tv177 = *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]) == 0;\n\tif (v177) goto L_0045;\n\tv347 = *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+B0]) + 8;\nL_0030:\n\tv352 = *([v347 @ X11_v43-8]) == System.Collections.IDictionary;\n\tif (v352) goto L_0048;\n\tv346 = v346 + 1;\n\tv397 = v346 < *([v174 @ X8_v14 (Il2CppClass<System.Collections.IDictionary>)+126]);\n\tv299 = ~v397;\n\tv347 = v347 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_0030;\nL_0045:\n\tv403 = 0x8909C4(obj, System.Collections.IDictionary, 2, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_004F;\nL_0048:\n\tv399 = *([v347 @ X11_v43]) + 2;\n\tv400 = v399 << 4;\n\tv401 = v174 + v400;\n\tv403 = v401 + 0x130;\nL_004F:\n\t*([v403 @ X0_v30])(v128, obj, *([v403 @ X0_v30+8]), v122, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0080;\n\tv414 = *([v408 @ X8_v17+B0]);\n\tv415 = 0;\n\tv416 = v414 + 8;\n\tv418 = *([v457 @ X11_v38-8]);\n\tv462 = v418 == v411;\n\tif (v462) goto L_0079;\n\tv438 = v456 + 1;\n\tv468 = v438 < v410;\n\tv436 = ~v468;\n\tv440 = v457 + 0x10;\n\tv420 = ~v436;\n\tif (v420) goto L_FFFFFFFF;\n\tv441 = v139;\n\tv442 = 0;\n\tv443 = 0x8909C4(v441, v411, v442, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0080;\nL_0079:\n\tv469 = *([v457 @ X11_v38]);\n\tv470 = v469 << 4;\n\tv471 = v408 + v470;\n\tv472 = v471 + 0x130;\nL_0080:\n\tv333 = System.Collections.IEnumerable::GetEnumerator(v128);\n\tv334 = v333 == 0;\n\tif (v334) goto L_0138;\nL_008B:\n\tgoto L_00B2;\n\tv598 = *([v565 @ X8_v21+B0]);\n\tv599 = 0;\n\tv600 = v598 + 8;\n\tv602 = *([v671 @ X11_v33-8]);\n\tv676 = v602 == v566;\n\tif (v676) goto L_00AB;\n\tv622 = v670 + 1;\n\tv702 = v622 < v567;\n\tv620 = ~v702;\n\tv624 = v671 + 0x10;\n\tv604 = ~v620;\n\tif (v604) goto L_FFFFFFFF;\n\tv625 = v224;\n\tv626 = 0;\n\tv627 = 0x8909C4(v625, v566, v626, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00B2;\nL_00AB:\n\tv703 = *([v671 @ X11_v33]);\n\tv704 = v703 << 4;\n\tv705 = v565 + v704;\n\tv706 = v705 + 0x130;\nL_00B2:\n\tv511 = System.Collections.IEnumerator::MoveNext(v333);\n\tv513 = v511 == 0;\n\tif (v513) goto L_FFFFFFFF;\n\tv719 = *([v333 @ X0_v35 (System.Collections.IEnumerator)]);\n\tv722 = *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v722) goto L_00D8;\n\tv764 = *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00C3:\n\tv769 = *([v764 @ X11_v28-8]) == System.Collections.IEnumerator;\n\tif (v769) goto L_00DB;\n\tv763 = v763 + 1;\n\tv774 = v763 < *([v719 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv745 = ~v774;\n\tv764 = v764 + 0x10;\n\tv729 = ~v745;\n\tif (v729) goto L_00C3;\nL_00D8:\n\tv782 = 0x8909C4(v333, System.Collections.IEnumerator, 1, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00E2;\nL_00DB:\n\tv776 = *([v764 @ X11_v28]) + 1;\n\tv777 = v776 << 4;\n\tv778 = v719 + v777;\n\tv782 = v778 + 0x130;\nL_00E2:\n\t*([v782 @ X0_v40])(v787, v333, *([v782 @ X0_v40+8]), v792, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv788 = v183 == 0;\n\tv789 = ~v788;\n\tif (v789) goto L_00F3;\n\tv797 = System.Text.StringBuilder::Append(this.builder, 0x2C);\nL_00F3:\n\tv810 = System.Object::ToString(v787);\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeString(this, v810);\n\tv820 = System.Text.StringBuilder::Append(this.builder, 0x3A);\n\tgoto L_0129;\n\tv824 = *([v821 @ X8_v30+B0]);\n\tv825 = 0;\n\tv826 = v824 + 8;\n\tv828 = *([v865 @ X11_v23-8]);\n\tv870 = v828 == v822;\n\tif (v870) goto L_0121;\n\tv848 = v864 + 1;\n\tv875 = v848 < v823;\n\tv846 = ~v875;\n\tv850 = v865 + 0x10;\n\tv830 = ~v846;\n\tif (v830) goto L_FFFFFFFF;\n\tv851 = v22;\n\tv852 = 0;\n\tv853 = 0x8909C4(v851, v822, v852, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0129;\nL_0121:\n\tv876 = *([v865 @ X11_v23]);\n\tv877 = v876 << 4;\n\tv878 = v821 + v877;\n\tv879 = v878 + 0x130;\nL_0129:\n\tv885 = System.Collections.IDictionary::get_Item(obj, v787);\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeValue(this, v885);\n\tgoto L_008B;\n\tgoto L_0157;\n\tv814 = new System.NullReferenceException();\n\tv803 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv226 = new System.NullReferenceException();\nL_0138:\n\tv268 = new System.NullReferenceException();\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\n\tgoto L_014D;\nL_014D:\n\tv238 = v265 != 1;\n\tif (v238) goto L_01A7;\n\tv413 = 0x6D2BC0(v268, v265, v263, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv133 = *([v413 @ X0_v25]);\n\tv445 = 0x6D2490(v413, v265, v263, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0157:\n\t// 343 IsInst v521 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v333 @ X0_v35 (System.Collections.IEnumerator)\n\tv524 = v521 == 0;\n\tif (v524) goto L_0187;\n\tgoto L_0186;\n\tv628 = *([v569 @ X8_v8+B0]);\n\tv629 = 0;\n\tv630 = v628 + 8;\n\tv632 = *([v692 @ X11_v10-8]);\n\tv697 = v632 == v570;\n\tif (v697) goto L_017F;\n\tv652 = v691 + 1;\n\tv711 = v652 < v571;\n\tv650 = ~v711;\n\tv654 = v692 + 0x10;\n\tv634 = ~v650;\n\tif (v634) goto L_FFFFFFFF;\n\tv655 = v138;\n\tv656 = 0;\n\tv657 = 0x8909C4(v655, v570, v656, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0186;\nL_017F:\n\tv712 = *([v692 @ X11_v10]);\n\tv713 = v712 << 4;\n\tv714 = v569 + v713;\n\tv715 = v714 + 0x130;\nL_0186:\n\tSystem.IDisposable::Dispose(v521);\nL_0187:\n\tv597 = v60 + 1;\n\tv90 = v597 == 0;\n\tv70 = ~v90;\n\tif (v70) goto L_01A0;\n\tv658 = v133 == 0;\n\tv165 = ~v658;\n\tif (v165) goto L_01A6;\nL_01A0:\n\tv386 = System.Text.StringBuilder::Append(this.builder, 0x7D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_01A6:\n\tv172 = new System.TypeLoadException();\nL_01A7:\n\tv276 = 0x6D2380(v268, 0, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						if (num5 == 0)
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

			[Token(Token = "0x600001F")]
			[Address(RVA = "0x166E468", Offset = "0x166E468", Length = "0x2D8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EBE0E0]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, anArray, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202B23A]) = v45;\nL_001C:\n\tv50 = System.Text.StringBuilder::Append(this.builder, 0x5B);\n\tgoto L_004C;\n\tv243 = *([v143 @ X8_v14+B0]);\n\tv244 = 0;\n\tv245 = v243 + 8;\n\tv247 = *([v312 @ X11_v31-8]);\n\tv318 = v247 == v146;\n\tif (v318) goto L_0045;\n\tv269 = v313 + 1;\n\tv359 = v269 < v145;\n\tv265 = ~v359;\n\tv267 = v312 + 0x10;\n\tv249 = ~v265;\n\tif (v249) goto L_FFFFFFFF;\n\tv270 = v18;\n\tv271 = 0;\n\tv272 = 0x8909C4(v270, v146, v271, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004C;\nL_0045:\n\tv360 = *([v312 @ X11_v31]);\n\tv361 = v360 << 4;\n\tv362 = v143 + v361;\n\tv363 = v362 + 0x130;\nL_004C:\n\tv299 = System.Collections.IEnumerable::GetEnumerator(anArray);\n\tv300 = v299 == 0;\n\tif (v300) goto L_00C4;\nL_0057:\n\tgoto L_007E;\n\tv402 = *([v396 @ X8_v18+B0]);\n\tv403 = 0;\n\tv404 = v402 + 8;\n\tv406 = *([v443 @ X11_v26-8]);\n\tv449 = v406 == v397;\n\tif (v449) goto L_0077;\n\tv428 = v444 + 1;\n\tv500 = v428 < v398;\n\tv424 = ~v500;\n\tv426 = v443 + 0x10;\n\tv408 = ~v424;\n\tif (v408) goto L_FFFFFFFF;\n\tv429 = v189;\n\tv430 = 0;\n\tv431 = 0x8909C4(v429, v397, v430, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_007E;\nL_0077:\n\tv501 = *([v443 @ X11_v26]);\n\tv502 = v501 << 4;\n\tv503 = v396 + v502;\n\tv504 = v503 + 0x130;\nL_007E:\n\tv489 = System.Collections.IEnumerator::MoveNext(v299);\n\tv491 = v489 == 0;\n\tif (v491) goto L_FFFFFFFF;\n\tv510 = *([v299 @ X0_v32 (System.Collections.IEnumerator)]);\n\tv513 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v513) goto L_00A4;\n\tv615 = *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_008F:\n\tv621 = *([v615 @ X11_v21-8]) == System.Collections.IEnumerator;\n\tif (v621) goto L_00A7;\n\tv616 = v616 + 1;\n\tv647 = v616 < *([v510 @ X8_v21 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv565 = ~v647;\n\tv615 = v615 + 0x10;\n\tv549 = ~v565;\n\tif (v549) goto L_008F;\nL_00A4:\n\tv653 = 0x8909C4(v299, System.Collections.IEnumerator, 1, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00AE;\nL_00A7:\n\tv649 = *([v615 @ X11_v21]) + 1;\n\tv650 = v649 << 4;\n\tv651 = v510 + v650;\n\tv653 = v651 + 0x130;\nL_00AE:\n\t*([v653 @ X0_v37])(v656, v299, *([v653 @ X0_v37+8]), v387, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv657 = v151 == 0;\n\tv658 = ~v657;\n\tif (v658) goto L_00BB;\n\tv672 = System.Text.StringBuilder::Append(this.builder, 0x2C);\nL_00BB:\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeValue(this, v656);\n\tgoto L_0057;\n\tgoto L_00DD;\n\tthrow System.NullReferenceException;\n\tv195 = new System.NullReferenceException();\nL_00C4:\n\tv233 = new System.NullReferenceException();\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\nL_00D3:\n\tv205 = v230 != 1;\n\tif (v205) goto L_012B;\n\tv370 = 0x6D2BC0(v233, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv110 = *([v370 @ X0_v25]);\n\tv401 = 0x6D2490(v370, v230, v228, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00DD:\n\t// 221 IsInst v499 @ X0_v13 (System.IDisposable), typeof(System.IDisposable), v299 @ X0_v32 (System.Collections.IEnumerator)\n\tv509 = v499 == 0;\n\tif (v509) goto L_010D;\n\tgoto L_010C;\n\tv573 = *([v514 @ X8_v8+B0]);\n\tv574 = 0;\n\tv575 = v573 + 8;\n\tv577 = *([v636 @ X11_v10-8]);\n\tv642 = v577 == v515;\n\tif (v642) goto L_0105;\n\tv599 = v637 + 1;\n\tv659 = v599 < v516;\n\tv595 = ~v659;\n\tv597 = v636 + 0x10;\n\tv579 = ~v595;\n\tif (v579) goto L_FFFFFFFF;\n\tv600 = v106;\n\tv601 = 0;\n\tv602 = 0x8909C4(v600, v515, v601, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_010C;\nL_0105:\n\tv660 = *([v636 @ X11_v10]);\n\tv661 = v660 << 4;\n\tv662 = v514 + v661;\n\tv663 = v662 + 0x130;\nL_010C:\n\tSystem.IDisposable::Dispose(v499);\nL_010D:\n\tv542 = v57 + 1;\n\tv77 = v542 == 0;\n\tv62 = ~v77;\n\tif (v62) goto L_0124;\n\tv603 = v110 == 0;\n\tv134 = ~v603;\n\tif (v134) goto L_012A;\nL_0124:\n\tv348 = System.Text.StringBuilder::Append(this.builder, 0x5D);\n\treturn;\n\tthrow System.NullReferenceException;\nL_012A:\n\tv141 = new System.TypeLoadException();\nL_012B:\n\tv242 = 0x6D2380(v233, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						if (num == 0)
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

			[Token(Token = "0x6000020")]
			[Address(RVA = "0x166E1FC", Offset = "0x166E1FC", Length = "0x26C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EF0A40]);\n\tv37 = *([v36 @ X8_v32]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, str, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202B23B]) = v55;\nL_0022:\n\tv61 = System.Text.StringBuilder::Append(this.builder, 0x22);\n\tv145 = System.String::ToCharArray(str);\n\tv203 = v145.Length;\n\tv264 = v145.Length < 1;\n\tif (v264) goto L_00E7;\n\tv74 = 0x185E000 + 0xCA4;\n\tgoto L_0057;\nL_004A:\n\tv429 = System.Text.StringBuilder::Append(this.builder, \"\\\\u\");\n\tv243 = 0xDC3590(&v374 @ X0_v26 (System.Int32), \"x4\", 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00D3;\nL_0057:\n\tv351 = v71 < v203;\n\tv194 = ~v351;\n\tif (v194) goto L_00F7;\n\tv159 = v145[v71 @ X22_v7 (System.Int32)] - 8;\n\tv353 = v159 < 5;\n\tv299 = ~v353;\n\tv297 = v159 - 5;\n\tv293 = v297 == 0;\n\tv354 = ~v293;\n\tv94 = v299 & v354;\n\tif (v94) goto L_007E;\n\tv312 = *([v74 @ X28_v7 (System.Int32)+v159 @ X8_v10 (System.Int32)*4]) + v74;\n\t// 115 IndirectJump v312 @ X8_v29, v198 @ X0_v17 (System.Char[]), v198 @ X0_v17 (System.Char[]), v399 @ X1_v11 (System.String), v137 @ X2_v8, v40 @ X3, v41 @ X4, v42 @ X5, v43 @ X6, v44 @ X7, v45 @ V0, v46 @ V1, v47 @ V2, v48 @ V3, v49 @ V4, v50 @ V5, v51 @ V6, v52 @ V7\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([1ED5630]);\n\tgoto L_FFFFFFFF;\nL_007E:\n\tv119 = v145[v71 @ X22_v7 (System.Int32)] == 0x5C;\n\tif (v119) goto L_00CC;\n\tv93 = v145[v71 @ X22_v7 (System.Int32)] != 0x22;\n\tif (v93) goto L_0099;\n\tv400 = this.builder;\n\tgoto L_FFFFFFFF;\nL_0099:\n\tgoto L_00A1;\n\tv366 = *([v358 @ X0_v23+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_00A1;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v358, v141, v137, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00A1:\n\tv374 = System.Convert::ToInt32(v145[v71 @ X22_v7 (System.Int32)]);\n\tv407 = v374 - 0x20;\n\tv408 = v407 < 0x5E;\n\tv234 = ~v408;\n\tv232 = v407 - 0x5E;\n\tv228 = v232 == 0;\n\tv409 = ~v228;\n\tv218 = v234 & v409;\n\tif (v218) goto L_004A;\n\tv338 = System.Text.StringBuilder::Append(this.builder, v145[v71 @ X22_v7 (System.Int32)]);\n\tgoto L_00D4;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X27]);\n\tgoto L_00D3;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X23]);\n\tgoto L_00D3;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X24]);\n\tgoto L_00D3;\n\tX0 = *([X19+10]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X26]);\n\tgoto L_00D3;\nL_00CC:\n\tv400 = this.builder;\nL_00D3:\n\tv338 = System.Text.StringBuilder::Append(v400, v399);\nL_00D4:\n\tv203 = v145.Length;\n\tv71 = v71 + 1;\n\tv326 = v71 < v145.Length;\n\tif (v326) goto L_0057;\nL_00E7:\n\tv305 = System.Text.StringBuilder::Append(this.builder, 0x22);\n\treturn;\n\tv165 = new System.NullReferenceException();\nL_00F7:\n\tv206 = new System.IndexOutOfRangeException();\n\tthrow v206;\n\tthrow System.NullReferenceException;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeString(string str)
			{
				//IL_007a: Expected O, but got I4
				//IL_0173: Expected O, but got I
				//IL_033f: Expected O, but got I4
				//IL_0299: Expected O, but got I4
				//IL_02aa: Expected O, but got I4
				StringBuilder stringBuilder = builder.Append('"');
				char[] array = str.ToCharArray();
				int num = array.Length;
				if (array.Length >= 1)
				{
					int num2 = 25550848 + 3236;
					int num3 = 0;
					object obj = 0;
					string text = null;
					string text2 = default(string);
					do
					{
						StringBuilder stringBuilder3;
						StringBuilder stringBuilder4;
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X28_v7 (System.Int32)+v159 @ X8_v10 (System.Int32)*4]");
								object obj2 = 0L + (long)num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v312 @ X8_v29 (should have been resolved before IL gen)");
							}
							string text3;
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
									bool flag8 = !flag7;
									if (flag6 && flag8)
									{
										StringBuilder stringBuilder2 = builder.Append("\\u");
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3590 (inside System.InvalidCastException::.ctor +0x2B8)");
										text = text2;
										stringBuilder3 = builder;
										goto IL_0325;
									}
									stringBuilder4 = builder.Append(array[num3]);
									obj = 0;
									text = (string)array[num3];
									goto IL_02cc;
								}
								stringBuilder3 = builder;
								text3 = "\\\"";
							}
							else
							{
								stringBuilder3 = builder;
								text3 = "\\\\";
							}
							text = text3;
							goto IL_0325;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
						IL_02cc:
						num = array.Length;
						num3++;
						continue;
						IL_0325:
						stringBuilder4 = stringBuilder3.Append(text);
						obj = 0;
						goto IL_02cc;
					}
					while (num3 < array.Length);
				}
				StringBuilder stringBuilder5 = builder.Append('"');
			}

			[Token(Token = "0x6000021")]
			[Address(RVA = "0x166EB50", Offset = "0x166EB50", Length = "0x268")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0015;\n\tv22 = *([1EBB2B0]);\n\tv23 = *([v22 @ X8_v30]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202B23C]) = v41;\nL_0015:\n\t*([v10 @ X29_v1-14]) = 0;\n\tv52 = *([value @ X1 (System.Object)]) == System.Single;\n\tif (v52) goto L_00B1;\n\tv111 = *([value @ X1 (System.Object)]) == System.Int32;\n\tif (v111) goto L_00D1;\n\tv156 = *([value @ X1 (System.Object)]) == System.UInt32;\n\tif (v156) goto L_00D1;\n\tv185 = *([value @ X1 (System.Object)]) == System.Int64;\n\tif (v185) goto L_00D1;\n\tv186 = *([value @ X1 (System.Object)]) == System.SByte;\n\tif (v186) goto L_00D1;\n\tv187 = *([value @ X1 (System.Object)]) == System.Byte;\n\tif (v187) goto L_00D1;\n\tv188 = *([value @ X1 (System.Object)]) == System.Int16;\n\tif (v188) goto L_00D1;\n\tv189 = *([value @ X1 (System.Object)]) == System.UInt16;\n\tif (v189) goto L_00D1;\n\tv190 = *([value @ X1 (System.Object)]) == System.UInt64;\n\tif (v190) goto L_00D1;\n\tv345 = *([value @ X1 (System.Object)]) == System.Double;\n\tif (v345) goto L_00D5;\n\tv300 = *([value @ X1 (System.Object)]) == System.Decimal;\n\tif (v300) goto L_00D5;\n\tv362 = System.Object::ToString(value);\n\tUnityEngine.Purchasing.MiniJSON.Json+Serializer::SerializeString(this, v362);\n\tgoto L_0105;\nL_00B1:\n\tv99 = this.builder;\n\tv118 = \"il2cpp_vm_object_unbox\"(value, value, methodInfo, v26, v27, v28, v29, v30, v312, v32, v33, v34, v35, v36, v37, v38);\n\t*([v10 @ X29_v1-14]) = *([v118 @ X0_v12]);\n\tgoto L_00C3;\n\tv228 = *([v218 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_00C3;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v218, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00C3:\n\tv236 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv287 = &v11 @ stack_-10_v2 - 0x14;\n\tv95 = 0xBCCF74(v287, \"R\", v236, 0, v27, v28, v29, v30, v312, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00FE;\nL_00D1:\n\tv227 = System.Text.StringBuilder::Append(this.builder, value);\n\tgoto L_0105;\nL_00D5:\n\tv99 = this.builder;\n\tgoto L_00E2;\n\tv363 = *([v356 @ X0_v22+E0]);\n\tv364 = v363 == 0;\n\tv365 = ~v364;\n\tif (v365) goto L_00E2;\n\tv367 = \"il2cpp_codegen_runtime_class_init\"(v356, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00E2:\n\tv312 = System.Convert::ToDouble(value);\n\tgoto L_00F1;\n\tv378 = *([v374 @ X0_v25+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_00F1;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v374, v371, methodInfo, v26, v27, v28, v29, v30, v312, v32, v33, v34, v35, v36, v37, v38);\nL_00F1:\n\tv385 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv95 = 0xA663A4(&v312 @ V0_v5 (System.Double), \"R\", v385, 0, v27, v28, v29, v30, v312, v32, v33, v34, v35, v36, v37, v38);\nL_00FE:\n\tv305 = System.Text.StringBuilder::Append(v99, v95);\nL_0105:\n\treturn;\n\tv103 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SerializeOther(object value)
			{
				//IL_0211: Expected O, but got I
				object obj2 = default(object);
				object obj = obj2;
				_ = 0;
				StringBuilder stringBuilder2;
				if ((object)value.GetType() != typeof(float))
				{
					if ((object)value.GetType() == typeof(int) || (object)value.GetType() == typeof(uint) || (object)value.GetType() == typeof(long) || (object)value.GetType() == typeof(sbyte) || (object)value.GetType() == typeof(byte) || (object)value.GetType() == typeof(short) || (object)value.GetType() == typeof(ushort) || (object)value.GetType() == typeof(ulong))
					{
						StringBuilder stringBuilder = builder.Append(value);
						return;
					}
					if ((object)value.GetType() != typeof(double) && (object)value.GetType() != typeof(decimal))
					{
						string str = value.ToString();
						SerializeString(str);
						return;
					}
					stringBuilder2 = builder;
					double num = Convert.ToDouble(value);
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A663A4 (inside System.Double::IsNaN +0x4C0)");
				}
				else
				{
					stringBuilder2 = builder;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
					object obj3 = (long)(IntPtr)obj2 - 20L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCF74 (inside System.Single::IsNaN +0x35C)");
				}
				string value2 = default(string);
				StringBuilder stringBuilder3 = stringBuilder2.Append(value2);
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x166D16C", Offset = "0x166D16C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = json == 0;\n\tif (v0) goto L_0004;\n\treturnVal2 = UnityEngine.Purchasing.MiniJSON.Json+Parser::Parse(json);\n\treturn returnVal2;\nL_0004:\n\treturn json;\n")]
		public static object Deserialize(string json)
		{
			if (json != null)
			{
				return Parser.Parse(json);
			}
			return json;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x166D2B8", Offset = "0x166D2B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json+Serializer::Serialize(obj);\n\treturn returnVal1;\n")]
		public static string Serialize(object obj)
		{
			return Serializer.Serialize(obj);
		}
	}
}
