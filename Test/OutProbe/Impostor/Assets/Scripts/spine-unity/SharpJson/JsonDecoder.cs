using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace SharpJson
{
	[Token(Token = "0x2000006")]
	public class JsonDecoder
	{
		[CompilerGenerated]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x10")]
		private string _003CerrorMessage_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x18")]
		internal bool _003CparseNumbersAsFloat_003Ek__BackingField;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x20")]
		private Lexer lexer;

		[Token(Token = "0x17000004")]
		public string errorMessage
		{
			[CompilerGenerated]
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x152189C", Offset = "0x152189C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<errorMessage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return errorMessage;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x15218A4", Offset = "0x15218A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<errorMessage>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CerrorMessage_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000005")]
		public bool parseNumbersAsFloat
		{
			[CompilerGenerated]
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x15218AC", Offset = "0x15218AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<parseNumbersAsFloat>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return parseNumbersAsFloat;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x15218B4", Offset = "0x15218B4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<parseNumbersAsFloat>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CparseNumbersAsFloat_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15218C0", Offset = "0x15218C0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<errorMessage>k__BackingField = 0;\n\tthis.<parseNumbersAsFloat>k__BackingField = 0;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JsonDecoder()
		{
			errorMessage = null;
			parseNumbersAsFloat = false;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x15218E0", Offset = "0x15218E0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = SharpJson.Lexer;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, text, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ACF]) = v40;\nL_0015:\n\tthis.<errorMessage>k__BackingField = 0;\n\tv42 = new SharpJson.Lexer();\n\tSharpJson.Lexer::.ctor(v42, text);\n\tthis.lexer = v42;\n\tv42.<parseNumbersAsFloat>k__BackingField = this.<parseNumbersAsFloat>k__BackingField;\n\treturnVal1 = SharpJson.JsonDecoder::ParseValue(this);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object Decode(string text)
		{
			errorMessage = null;
			(lexer = new Lexer(text)).parseNumbersAsFloat = parseNumbersAsFloat;
			return ParseValue();
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x1521B6C", Offset = "0x1521B6C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = SharpJson.JsonDecoder;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AD0]) = v37;\nL_0014:\n\tv39 = new SharpJson.JsonDecoder();\n\tSystem.Object::.ctor(v39);\n\tv39.<errorMessage>k__BackingField = 0;\n\tv39.<parseNumbersAsFloat>k__BackingField = 0;\n\treturnVal1 = SharpJson.JsonDecoder::Decode(v39, text);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object DecodeText(string text)
		{
			JsonDecoder jsonDecoder = new JsonDecoder();
			jsonDecoder.errorMessage = null;
			jsonDecoder.parseNumbersAsFloat = false;
			return jsonDecoder.Decode(text);
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x1521BD0", Offset = "0x1521BD0", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv55 = System.Collections.Generic.Dictionary`2<System.String, System.Object>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv170 = \"Invalid token\";\n\tv171 = \"il2cpp_codegen_initialize_runtime_metadata\"(v170, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv174 = \"Invalid token; expected ':'\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37AD1]) = v46;\nL_0028:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v48);\n\tv57 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv230 = this.lexer + 0x20;\n\tv137 = SharpJson.Lexer::NextToken(v57.json, v230);\n\tv164 = this.lexer;\nL_003C:\n\tSharpJson.Lexer::SkipWhiteSpaces(v164);\n\tv154 = v164.index;\n\tv141 = SharpJson.Lexer::NextToken(v164.json, &v154 @ X8_v5 (System.Int32));\n\tv103 = v141 == 5;\n\tif (v103) goto L_0086;\n\tv101 = v141 == 9;\n\tif (v101) goto L_0093;\n\tv238 = v141 == 0;\n\tif (v238) goto L_FFFFFFFF;\n\tv246 = SharpJson.Lexer::ParseString(this.lexer);\n\tv139 = SharpJson.JsonDecoder::EvalLexer(this, v246);\n\tv297 = this.<errorMessage>k__BackingField == 0;\n\tv291 = ~v297;\n\tif (v291) goto L_FFFFFFFF;\n\tv160 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv134 = this.lexer + 0x20;\n\tv259 = SharpJson.Lexer::NextToken(v160.json, v134);\n\tv69 = v259 != 4;\n\tif (v69) goto L_FFFFFFFF;\n\tv140 = SharpJson.JsonDecoder::ParseValue(this);\n\tv308 = this.<errorMessage>k__BackingField == 0;\n\tv292 = ~v308;\n\tif (v292) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v48, v139, v140);\n\tgoto L_008E;\nL_0086:\n\tv166 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv230 = this.lexer + 0x20;\n\tv245 = SharpJson.Lexer::NextToken(v166.json, v230);\nL_008E:\n\tv164 = this.lexer;\n\tv276 = this.lexer == 0;\n\tv149 = ~v276;\n\tif (v149) goto L_003C;\n\tgoto L_00AF;\nL_0093:\n\tv152 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv268 = this.lexer + 0x20;\n\tv269 = SharpJson.Lexer::NextToken(v152.json, v268);\n\tgoto L_00AE;\n\tgoto L_00A3;\nL_00A3:\n\tSharpJson.JsonDecoder::TriggerError(this, *([v261 @ X8_v8 (System.String)]));\nL_00AE:\n\treturn v300;\nL_00AF:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe IDictionary<string, object> ParseObject()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Lexer lexer = this.lexer;
			this.lexer.SkipWhiteSpaces();
			ref int index = ref *(int*)((nint)this.lexer + 32);
			Lexer.Token token = Lexer.NextToken(lexer.json, ref index);
			Lexer lexer2 = this.lexer;
			do
			{
				lexer2.SkipWhiteSpaces();
				int index2 = lexer2.index;
				Lexer.Token token2 = Lexer.NextToken(lexer2.json, ref index2);
				string message;
				if (token2 != Lexer.Token.Comma)
				{
					if (token2 != Lexer.Token.CurlyClose)
					{
						if (token2 != Lexer.Token.None)
						{
							string value = this.lexer.ParseString();
							object obj = EvalLexer((object)value);
							if (errorMessage == null)
							{
								Lexer lexer3 = this.lexer;
								this.lexer.SkipWhiteSpaces();
								ref int index3 = ref *(int*)((nint)this.lexer + 32);
								Lexer.Token token3 = Lexer.NextToken(lexer3.json, ref index3);
								if (token3 != Lexer.Token.Colon)
								{
									message = "Invalid token; expected ':'";
									goto IL_02f8;
								}
								object value2 = ParseValue();
								if (errorMessage == null)
								{
									dictionary[(string)obj] = value2;
									index = ref *(int*)obj;
									goto IL_01cf;
								}
							}
							goto IL_0279;
						}
						message = "Invalid token";
						goto IL_02f8;
					}
					Lexer lexer4 = this.lexer;
					this.lexer.SkipWhiteSpaces();
					ref int index4 = ref *(int*)((nint)this.lexer + 32);
					Lexer.Token token4 = Lexer.NextToken(lexer4.json, ref index4);
					return dictionary;
				}
				Lexer lexer5 = this.lexer;
				this.lexer.SkipWhiteSpaces();
				index = ref *(int*)((nint)this.lexer + 32);
				Lexer.Token token5 = Lexer.NextToken(lexer5.json, ref index);
				goto IL_01cf;
				IL_0279:
				return null;
				IL_01cf:
				lexer2 = this.lexer;
				continue;
				IL_02f8:
				TriggerError(message);
				goto IL_0279;
			}
			while (this.lexer != null);
			return (IDictionary<string, object>)new NullReferenceException();
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x1521E64", Offset = "0x1521E64", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = System.Collections.Generic.List`1<System.Object>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"Invalid token\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37AD2]) = v42;\nL_0020:\n\tv44 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v44);\n\tv53 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv196 = this.lexer + 0x20;\n\tv127 = SharpJson.Lexer::NextToken(v53.json, v196);\n\tv149 = this.lexer;\nL_0032:\n\tSharpJson.Lexer::SkipWhiteSpaces(v149);\n\tv143 = v149.index;\n\tv129 = SharpJson.Lexer::NextToken(v149.json, &v143 @ X8_v5 (System.Int32));\n\tv102 = v129 == 5;\n\tif (v102) goto L_0070;\n\tv101 = v129 == 0xB;\n\tif (v101) goto L_0083;\n\tv204 = v129 == 0;\n\tif (v204) goto L_0090;\n\tv128 = SharpJson.JsonDecoder::ParseValue(this);\n\tv215 = this.<errorMessage>k__BackingField == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_FFFFFFFF;\n\tv142 = v44._items;\n\tv77 = v44._version + 1;\n\tv44._version = v77;\n\tv232 = v44._size;\n\tv249 = v44._size < v142.Length;\n\tv240 = ~v249;\n\tif (v240) goto L_007D;\n\tv231 = v44._size + 1;\n\tv44._size = v231;\n\tv142[v232 @ X10_v6 (System.Int32)] = v128;\n\tgoto L_007E;\nL_0070:\n\tv150 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv196 = this.lexer + 0x20;\n\tv214 = SharpJson.Lexer::NextToken(v150.json, v196);\n\tgoto L_007E;\nL_007D:\n\tSystem.Collections.Generic.List`1<System.Object>::AddWithResize(v44, v128);\nL_007E:\n\tv149 = this.lexer;\n\tv247 = this.lexer == 0;\n\tv136 = ~v247;\n\tif (v136) goto L_0032;\n\tgoto L_009A;\nL_0083:\n\tv139 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv223 = this.lexer + 0x20;\n\tv224 = SharpJson.Lexer::NextToken(v139.json, v223);\n\tgoto L_0099;\nL_0090:\n\tSharpJson.JsonDecoder::TriggerError(this, \"Invalid token\");\nL_0099:\n\treturn v227;\nL_009A:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe IList<object> ParseArray()
		{
			List<object> list = new List<object>();
			Lexer lexer = this.lexer;
			this.lexer.SkipWhiteSpaces();
			ref int index = ref *(int*)((nint)this.lexer + 32);
			Lexer.Token token = Lexer.NextToken(lexer.json, ref index);
			Lexer lexer2 = this.lexer;
			do
			{
				lexer2.SkipWhiteSpaces();
				int index2 = lexer2.index;
				switch (Lexer.NextToken(lexer2.json, ref index2))
				{
				default:
				{
					object obj = ParseValue();
					if (errorMessage != null)
					{
						break;
					}
					object[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					int count = list.Count;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						list._size = size;
						items[count] = obj;
						index = ref *(int*)obj;
					}
					else
					{
						list.Add(obj);
						index = ref *(int*)obj;
					}
					goto IL_01c9;
				}
				case Lexer.Token.Comma:
				{
					Lexer lexer4 = this.lexer;
					this.lexer.SkipWhiteSpaces();
					index = ref *(int*)((nint)this.lexer + 32);
					Lexer.Token token3 = Lexer.NextToken(lexer4.json, ref index);
					goto IL_01c9;
				}
				case Lexer.Token.SquaredClose:
				{
					Lexer lexer3 = this.lexer;
					this.lexer.SkipWhiteSpaces();
					ref int index3 = ref *(int*)((nint)this.lexer + 32);
					Lexer.Token token2 = Lexer.NextToken(lexer3.json, ref index3);
					return list;
				}
				case Lexer.Token.None:
					TriggerError("Invalid token");
					break;
				}
				return null;
				IL_01c9:
				lexer2 = this.lexer;
			}
			while (this.lexer != null);
			return (IList<object>)new NullReferenceException();
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x152195C", Offset = "0x152195C", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv14 = System.Boolean;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = System.Double;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv117 = System.Single;\n\tv118 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv120 = \"Unable to parse value\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37AD3]) = v34;\nL_0022:\n\tv35 = this.lexer;\n\tSharpJson.Lexer::SkipWhiteSpaces(this.lexer);\n\tv45 = v35.index;\n\tv49 = SharpJson.Lexer::NextToken(v35.json, &v45 @ X8_v3 (System.Int32));\n\tv45 = v49 - 1;\n\tv54 = v45 < 9;\n\tv55 = ~v54;\n\tv56 = v45 - 9;\n\tv58 = v56 == 0;\n\tv63 = ~v58;\n\tv64 = v55 & v63;\n\tif (v64) goto L_0067;\n\tv77 = 0x44C000 + 0xD09;\n\tv68 = *([v77 @ X9_v2 (System.Int32)+v45 @ X8_v3 (System.Int32)]) << 2;\n\tv74 = 0x1525A18 + v68;\n\t// 63 IndirectJump v74 @ X10_v2 (System.Int32), v49 @ X0_v5 (SharpJson.Lexer+Token), v49 @ X0_v5 (SharpJson.Lexer+Token), &v45 @ X8_v3 (System.Int32), v17 @ X2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\tX19 = *([X19+20]);\n\tif (TEMP) goto L_009C;\n\tX0 = X19;\n\tSharpJson.Lexer::SkipWhiteSpaces(X0, X1);\n\tX0 = *([X19+18]);\n\tX1 = X19 + 0x20;\n\tX0 = SharpJson.Lexer::NextToken(X0, X1, X2);\n\tgoto L_0068;\n\tX19 = *([X19+20]);\n\tif (TEMP) goto L_009C;\n\tX0 = X19;\n\tSharpJson.Lexer::SkipWhiteSpaces(X0, X1);\n\tX0 = *([X19+18]);\n\tX1 = X19 + 0x20;\n\tX0 = SharpJson.Lexer::NextToken(X0, X1, X2);\n\tX8 = *([1935530]);\n\tX0 = *([X8]);\n\tX8 = 1;\n\tstack[8] = X8;\n\tgoto L_0095;\n\tX19 = *([X19+20]);\n\tif (TEMP) goto L_009C;\n\tX0 = X19;\n\tSharpJson.Lexer::SkipWhiteSpaces(X0, X1);\n\tX0 = *([X19+18]);\n\tX1 = X19 + 0x20;\n\tX0 = SharpJson.Lexer::NextToken(X0, X1, X2);\n\tX8 = *([1935530]);\n\tstack[8] = 0;\n\tgoto L_0094;\nL_0067:\n\tSharpJson.JsonDecoder::TriggerError(this, \"Unable to parse value\");\nL_0068:\n\t;\n\tgoto L_009B;\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_009C;\n\tX0 = SharpJson.Lexer::ParseString(X0, X1);\n\tX8 = *([1946688]);\n\tX1 = X0;\n\tX0 = X19;\n\tX2 = *([X8]);\n\tX0 = SharpJson.JsonDecoder::EvalLexer(X0, X1, X2);\n\tgoto L_009B;\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_009C;\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_008B;\n\tV0 = SharpJson.Lexer::ParseFloatNumber(X0, X1);\n\tX8 = *([1946680]);\n\tX0 = X19;\n\tX1 = *([X8]);\n\tV0 = SharpJson.JsonDecoder::EvalLexer(X0, V0, X1);\n\tX8 = *([1936180]);\n\tstack[8] = V0;\n\tgoto L_0094;\n\tX0 = X19;\n\tX0 = SharpJson.JsonDecoder::ParseObject(X0, X1);\n\tgoto L_009B;\n\tX0 = X19;\n\tX0 = SharpJson.JsonDecoder::ParseArray(X0, X1);\n\tgoto L_009B;\nL_008B:\n\tV0 = SharpJson.Lexer::ParseDoubleNumber(X0, X1);\n\tX8 = *([1946678]);\n\tX0 = X19;\n\tX1 = *([X8]);\n\tX0 = SharpJson.JsonDecoder::EvalLexer /* +1 sharing this address */(X0, X1, X2);\n\tX8 = *([1937CC8]);\n\tstack[8] = V0;\nL_0094:\n\tX0 = *([X8]);\nL_0095:\n\tX1 = &stack[8];\n\tX0 = 0xAD95A0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009B:\n\treturn 0;\nL_009C:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private object ParseValue()
		{
			Lexer lexer = this.lexer;
			this.lexer.SkipWhiteSpaces();
			int index = lexer.index;
			Lexer.Token token = Lexer.NextToken(lexer.json, ref index);
			index = (int)(token - 1);
			bool flag = index < 9;
			bool flag2 = !flag;
			int num = index - 9;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 4505600 + 3337;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X9_v2 (System.Int32)+v45 @ X8_v3 (System.Int32)]");
				int num3 = (int)((nint)0 << 2);
				int num4 = 22174232 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			TriggerError("Unable to parse value");
			return null;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x1521DC8", Offset = "0x1521DC8", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Int32;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, message, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = \"Error: '{0}' at line {1}\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, message, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37AD4]) = v37;\nL_0015:\n\tv38 = this.lexer;\n\tv44 = v38.<lineNumber>k__BackingField;\n\t// 32 Box v50 @ X0_v4 (System.Object), typeof(System.Int32), &v44 @ X8_v4 (System.Int32)\n\tv57 = System.String::Format(\"Error: '{0}' at line {1}\", message, v50);\n\tthis.<errorMessage>k__BackingField = v57;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TriggerError(string message)
		{
			Lexer lexer = this.lexer;
			int lineNumber = lexer.lineNumber;
			object arg = lineNumber;
			string text = $"Error: '{message}' at line {arg}";
			errorMessage = text;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xC76A80", Offset = "0xC76A80", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = \"Lexical error ocurred\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v22, v23, v24, v25, v26, v11, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3582F]) = v36;\nL_0016:\n\tv40 = SharpJson.Lexer::get_hasError(this.lexer);\n\tv43 = v40 == 0;\n\tif (v43) goto L_0026;\n\tSharpJson.JsonDecoder::TriggerError(this, \"Lexical error ocurred\");\nL_0026:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private T EvalLexer<T>(T value)
		{
			//IL_002b: Expected O, but got I4
			bool hasError = lexer.hasError;
			bool flag = !hasError;
			T result = (T)hasError;
			if (!flag)
			{
				TriggerError("Lexical error ocurred");
				result = (T)this;
			}
			return result;
		}
	}
}
