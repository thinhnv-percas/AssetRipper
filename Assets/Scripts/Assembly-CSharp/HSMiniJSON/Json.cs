using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Cpp2ILInjected;

namespace HSMiniJSON
{
	[Token(Token = "0x2000808")]
	public static class Json
	{
		[Token(Token = "0x2000809")]
		private sealed class Parser : IDisposable
		{
			[Token(Token = "0x200080A")]
			private enum TOKEN
			{
				[Token(Token = "0x4001AEE")]
				NONE = 0,
				[Token(Token = "0x4001AEF")]
				CURLY_OPEN = 1,
				[Token(Token = "0x4001AF0")]
				CURLY_CLOSE = 2,
				[Token(Token = "0x4001AF1")]
				SQUARED_OPEN = 3,
				[Token(Token = "0x4001AF2")]
				SQUARED_CLOSE = 4,
				[Token(Token = "0x4001AF3")]
				COLON = 5,
				[Token(Token = "0x4001AF4")]
				COMMA = 6,
				[Token(Token = "0x4001AF5")]
				STRING = 7,
				[Token(Token = "0x4001AF6")]
				NUMBER = 8,
				[Token(Token = "0x4001AF7")]
				TRUE = 9,
				[Token(Token = "0x4001AF8")]
				FALSE = 10,
				[Token(Token = "0x4001AF9")]
				NULL = 11
			}

			[Token(Token = "0x4001AEB")]
			private const string WORD_BREAK = "{}[],:\"";

			[Token(Token = "0x4001AEC")]
			[FieldOffset(Offset = "0x10")]
			private StringReader json;

			[Token(Token = "0x17000351")]
			private char PeekChar
			{
				[Token(Token = "0x600224E")]
				[Address(RVA = "0x3DD0004", Offset = "0x3DD0004", Length = "0x8C")]
				get
				{
					int value = json.Peek();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x17000352")]
			private char NextChar
			{
				[Token(Token = "0x600224F")]
				[Address(RVA = "0x3DCFC60", Offset = "0x3DCFC60", Length = "0x8C")]
				get
				{
					int value = json.Read();
					return Convert.ToChar(value);
				}
			}

			[Token(Token = "0x17000353")]
			private string NextWord
			{
				[Token(Token = "0x6002250")]
				[Address(RVA = "0x3DCFCEC", Offset = "0x3DCFCEC", Length = "0x208")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("Json.Parser::get_NextWord");
					return default;
				}
			}

			[Token(Token = "0x17000354")]
			private TOKEN NextToken
			{
				[Token(Token = "0x6002251")]
				[Address(RVA = "0x3DCF254", Offset = "0x3DCF254", Length = "0x274")]
				get
				{
					//IL_00af: Expected O, but got I4
					//IL_01c9: Expected O, but got I4
					EatWhitespace();
					int num = json.Peek();
					if (num != -1)
					{
						int value = json.Peek();
						char c = Convert.ToChar(value);
						bool flag = (uint)c < 91u;
						bool flag2 = !flag;
						int num2 = c - 91;
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						bool flag5 = flag2 && flag4;
						object obj = 0;
						if (!flag5)
						{
							int num3 = c - 34;
							bool flag6 = (uint)num3 < 57u;
							bool flag7 = !flag6;
							int num4 = num3 - 57;
							bool flag8 = num4 == 0;
							bool flag9 = !flag8;
							if (!(flag7 && flag9))
							{
								int num5 = 154173440 + 472;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ X9_v8 (System.Int32)+v222 @ X8_v19 (System.Int32)]");
								int num6 = (int)((nint)0 << 2);
								int num7 = 64811840 + num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v152 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
								goto IL_0165;
							}
						}
						else
						{
							if (c == ']')
							{
								int num8 = json.Read();
								return TOKEN.SQUARED_CLOSE;
							}
							if (c == '{')
							{
								return TOKEN.CURLY_OPEN;
							}
							bool flag10 = c != '}';
							obj = 0;
							if (!flag10)
							{
								int num9 = json.Read();
								return TOKEN.CURLY_CLOSE;
							}
						}
						return NextWord switch
						{
							"false" => TOKEN.FALSE, 
							"true" => TOKEN.TRUE, 
							"null" => TOKEN.NULL, 
							_ => default(TOKEN), 
						};
					}
					goto IL_0165;
					IL_0165:
					return default(TOKEN);
				}
			}

			[Token(Token = "0x6002243")]
			[Address(RVA = "0x3DCEF24", Offset = "0x3DCEF24", Length = "0xC0")]
			public static bool IsWordBreak(char c)
			{
				//IL_0009: Expected O, but got I4
				//IL_00d5: Expected O, but got I
				//IL_005b: Expected O, but got I
				object obj = 192471040;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E238]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					int num = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v13 (System.Int32)+88]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v19+E4]");
					if ((nint)0 != 0)
					{
						goto IL_0080;
					}
				}
				else
				{
					_ = 1;
					int num2 = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v8 (System.Int32)+88]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X0_v13+E4]");
					if ((nint)0 != 0)
					{
						goto IL_0080;
					}
				}
				if (char.IsWhiteSpace(c))
				{
					goto IL_00aa;
				}
				goto IL_013f;
				IL_00aa:
				return true;
				IL_013f:
				int num3 = "{}[],:\"".IndexOf(c);
				int num4 = num3 - -1;
				bool flag = num4 == 0;
				return !flag;
				IL_0080:
				if (char.IsWhiteSpace(c))
				{
					goto IL_00aa;
				}
				goto IL_013f;
			}

			[Token(Token = "0x6002244")]
			[Address(RVA = "0x3DCEFE4", Offset = "0x3DCEFE4", Length = "0x80")]
			private Parser(string jsonString)
			{
				StringReader stringReader = new StringReader(jsonString);
				json = stringReader;
			}

			[Token(Token = "0x6002245")]
			[Address(RVA = "0x3DCEC94", Offset = "0x3DCEC94", Length = "0x1BC")]
			public static object Parse(string jsonString)
			{
				//IL_00e0: Expected I4, but got O
				//IL_0126: Expected I4, but got O
				//IL_013c: Expected I4, but got O
				//IL_0149: Expected I4, but got O
				Parser parser = (Parser)FormatterServices.GetUninitializedObject(typeof(Parser));
				StringReader stringReader = new StringReader(jsonString);
				parser.json = stringReader;
				Parser parser2 = parser;
				TOKEN nextToken = parser.NextToken;
				object result = parser.ParseByToken(nextToken);
				object obj = parser2;
				IDisposable disposable = (IDisposable)obj;
				bool flag = obj == null;
				int num = 0;
				int num2 = 0;
				num = 0;
				TOKEN tOKEN = nextToken;
				int num3 = 0;
				if (flag)
				{
					goto IL_0184;
				}
				goto IL_01ac;
				IL_01ac:
				disposable.Dispose();
				tOKEN = default(TOKEN);
				result = null;
				num3 = num2;
				goto IL_0184;
				IL_0184:
				object obj2 = default(object);
				object result2 = default(object);
				while (true)
				{
					if (num3 == 0)
					{
						return result;
					}
					OutOfMemoryException ex = new OutOfMemoryException();
					if (tOKEN == TOKEN.CURLY_OPEN)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BC4");
						num2 = (int)obj2;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
						object obj3 = parser2;
						disposable = (IDisposable)obj3;
						bool flag2 = obj3 == null;
						bool flag3 = !flag2;
						num = (int)obj2;
						if (flag3)
						{
							break;
						}
						num = (int)obj2;
						result = null;
						num3 = (int)obj2;
						continue;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @3175484");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
					return result2;
				}
				goto IL_01ac;
			}

			[Token(Token = "0x6002246")]
			[Address(RVA = "0x3DCF08C", Offset = "0x3DCF08C", Length = "0x3C")]
			public void Dispose()
			{
				json.Dispose();
				json = null;
			}

			[Token(Token = "0x6002247")]
			[Address(RVA = "0x3DCF0C8", Offset = "0x3DCF0C8", Length = "0x18C")]
			private Dictionary<string, object> ParseObject()
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				StringReader stringReader = json;
				int num = stringReader.Read();
				Dictionary<string, object> result;
				if (dictionary == null)
				{
					while (true)
					{
						switch (NextToken)
						{
						case TOKEN.COMMA:
							continue;
						default:
						{
							string text = ParseString();
							if (text == null)
							{
								break;
							}
							TOKEN nextToken = NextToken;
							if (nextToken != TOKEN.COLON)
							{
								break;
							}
							bool flag = json == null;
							bool flag2 = !flag;
							NullReferenceException ex = (NullReferenceException)(object)json;
							if (!flag2)
							{
								ex = new NullReferenceException();
							}
							string source = ex.Source;
							TOKEN nextToken2 = NextToken;
							object obj = ParseByToken(nextToken2);
							return (Dictionary<string, object>)(object)new NullReferenceException();
						}
						case TOKEN.NONE:
						case TOKEN.CURLY_CLOSE:
							break;
						}
						break;
					}
				}
				else
				{
					while (true)
					{
						TOKEN nextToken3 = NextToken;
						if (nextToken3 == TOKEN.COMMA)
						{
							continue;
						}
						if (nextToken3 == TOKEN.NONE)
						{
							break;
						}
						bool flag3 = nextToken3 == TOKEN.CURLY_CLOSE;
						result = dictionary;
						if (!flag3)
						{
							string text2 = ParseString();
							if (text2 == null)
							{
								break;
							}
							TOKEN nextToken4 = NextToken;
							if (nextToken4 != TOKEN.COLON)
							{
								break;
							}
							StringReader stringReader2 = json;
							int num2 = stringReader2.Read();
							TOKEN nextToken5 = NextToken;
							object value = ParseByToken(nextToken5);
							dictionary[text2] = value;
							continue;
						}
						goto IL_027c;
					}
				}
				result = null;
				goto IL_027c;
				IL_027c:
				return result;
			}

			[Token(Token = "0x6002248")]
			[Address(RVA = "0x3DCF988", Offset = "0x3DCF988", Length = "0x15C")]
			private List<object> ParseArray()
			{
				List<object> list = new List<object>();
				StringReader stringReader = json;
				int num = stringReader.Read();
				List<object> result;
				if (list == null)
				{
					TOKEN token = default(TOKEN);
					while (true)
					{
						switch (NextToken)
						{
						case TOKEN.COMMA:
							continue;
						case TOKEN.NONE:
						case TOKEN.SQUARED_CLOSE:
							break;
						default:
						{
							object obj = ParseByToken(token);
							return (List<object>)(object)new NullReferenceException();
						}
						}
						break;
					}
				}
				else
				{
					while (true)
					{
						TOKEN nextToken = NextToken;
						if (nextToken == TOKEN.COMMA)
						{
							continue;
						}
						if (nextToken == TOKEN.NONE)
						{
							break;
						}
						bool flag = nextToken == TOKEN.SQUARED_CLOSE;
						result = list;
						if (!flag)
						{
							object item = ParseByToken(nextToken);
							list.Add(item);
							continue;
						}
						goto IL_0175;
					}
				}
				result = null;
				goto IL_0175;
				IL_0175:
				return result;
			}

			[Token(Token = "0x6002249")]
			[Address(RVA = "0x3DCF064", Offset = "0x3DCF064", Length = "0x28")]
			private object ParseValue()
			{
				TOKEN nextToken = NextToken;
				return ParseByToken(nextToken);
			}

			[Token(Token = "0x600224A")]
			[Address(RVA = "0x3DCFAE4", Offset = "0x3DCFAE4", Length = "0xCC")]
			private object ParseByToken(TOKEN token)
			{
				//IL_0174: Expected O, but got I
				//IL_017c: Expected O, but got I4
				//IL_00f3: Expected O, but got I4
				//IL_0112: Expected O, but got I
				object result = default(object);
				if (token <= TOKEN.STRING)
				{
					switch (token)
					{
					case TOKEN.CURLY_OPEN:
						return ParseObject();
					case TOKEN.SQUARED_OPEN:
						return ParseArray();
					}
					bool flag = token != TOKEN.STRING;
					result = null;
					if (!flag)
					{
						return ParseString();
					}
				}
				else
				{
					if (token == TOKEN.NUMBER)
					{
						return ParseNumber();
					}
					if (token != TOKEN.TRUE)
					{
						bool flag2 = token != TOKEN.FALSE;
						result = null;
						if (flag2)
						{
							goto IL_0181;
						}
						object obj = 0;
						int num = 192761856 + 1336;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v8 (System.Int32)+28]");
						object obj2 = 0;
						object obj3 = obj;
					}
					else
					{
						int num2 = 1;
						int num3 = 192761856 + 1336;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v6 (System.Int32)+28]");
						object obj2 = 0;
						object obj3 = num2;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				}
				goto IL_0181;
				IL_0181:
				return result;
			}

			[Token(Token = "0x600224B")]
			[Address(RVA = "0x3DCF4C8", Offset = "0x3DCF4C8", Length = "0x4C0")]
			private string ParseString()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Parser::ParseString");
				return default;
			}

			[Token(Token = "0x600224C")]
			[Address(RVA = "0x3DCFBB0", Offset = "0x3DCFBB0", Length = "0xB0")]
			private object ParseNumber()
			{
				string nextWord = NextWord;
				int num = nextWord.IndexOf('.');
				if (num != -1)
				{
					bool flag = double.TryParse(nextWord, out var result);
					double num2 = result;
					int num3 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object result2 = default(object);
					return result2;
				}
				bool flag2 = long.TryParse(nextWord, out var result3);
				long num4 = result3;
				int num5 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object result4 = default(object);
				return result4;
			}

			[Token(Token = "0x600224D")]
			[Address(RVA = "0x3DCFEF4", Offset = "0x3DCFEF4", Length = "0x110")]
			private void EatWhitespace()
			{
				//IL_0045: Expected O, but got I
				int num = 192761856 + 1336;
				int num3;
				do
				{
					int value = json.Peek();
					char c = Convert.ToChar(value);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X22_v2 (System.Int32)+88]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v13+E4]");
					if ((nint)0 != 0)
					{
						if (!char.IsWhiteSpace(c))
						{
							break;
						}
					}
					else if (!char.IsWhiteSpace(c))
					{
						break;
					}
					int num2 = json.Read();
					num3 = json.Peek();
				}
				while (num3 != -1);
			}
		}

		[Token(Token = "0x200080B")]
		private sealed class Serializer
		{
			[Token(Token = "0x4001AFA")]
			[FieldOffset(Offset = "0x10")]
			private StringBuilder builder;

			[Token(Token = "0x6002252")]
			[Address(RVA = "0x3DD0090", Offset = "0x3DD0090", Length = "0x78")]
			private Serializer()
			{
				StringBuilder stringBuilder = new StringBuilder();
				builder = stringBuilder;
			}

			[Token(Token = "0x6002253")]
			[Address(RVA = "0x3DCEE50", Offset = "0x3DCEE50", Length = "0xD4")]
			public static string Serialize(object obj)
			{
				Serializer serializer = new Serializer();
				StringBuilder stringBuilder = new StringBuilder();
				serializer.builder = stringBuilder;
				serializer.SerializeValue(obj);
				StringBuilder stringBuilder2 = serializer.builder;
				return stringBuilder2.ToString();
			}

			[Token(Token = "0x6002254")]
			[Address(RVA = "0x3DD0108", Offset = "0x3DD0108", Length = "0x1F0")]
			private void SerializeValue(object value)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Serializer::SerializeValue");
			}

			[Token(Token = "0x6002255")]
			[Address(RVA = "0x3DD090C", Offset = "0x3DD090C", Length = "0x47C")]
			private void SerializeObject(IDictionary obj)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Serializer::SerializeObject");
			}

			[Token(Token = "0x6002256")]
			[Address(RVA = "0x3DD05CC", Offset = "0x3DD05CC", Length = "0x340")]
			private void SerializeArray(IList anArray)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Serializer::SerializeArray");
			}

			[Token(Token = "0x6002257")]
			[Address(RVA = "0x3DD02F8", Offset = "0x3DD02F8", Length = "0x2D4")]
			private void SerializeString(string str)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Serializer::SerializeString");
			}

			[Token(Token = "0x6002258")]
			[Address(RVA = "0x3DD0D88", Offset = "0x3DD0D88", Length = "0x1C8")]
			private void SerializeOther(object value)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Json.Serializer::SerializeOther");
			}
		}

		[Token(Token = "0x6002241")]
		[Address(RVA = "0x3DCEB08", Offset = "0x3DCEB08", Length = "0xC")]
		public static object Deserialize(string json)
		{
			if (json != null)
			{
				return Parser.Parse(json);
			}
			return json;
		}

		[Token(Token = "0x6002242")]
		[Address(RVA = "0x3DCD2B0", Offset = "0x3DCD2B0", Length = "0x4")]
		public static string Serialize(object obj)
		{
			return Serializer.Serialize(obj);
		}
	}
}
