using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiniJSON
{
	public class Json
	{
		internal sealed class _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A : IDisposable
		{
			internal enum TOKEN
			{
				NONE,
				CURLY_OPEN,
				CURLY_CLOSE,
				SQUARED_OPEN,
				SQUARED_CLOSE,
				COLON,
				COMMA,
				STRING,
				NUMBER,
				TRUE,
				FALSE,
				NULL
			}

			internal const string _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A = "{}[],:\"";

			internal StringReader _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020;

			internal char _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020 => Convert.ToChar(_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek());

			internal char _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A => Convert.ToChar(_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read());

			internal string _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020
			{
				get
				{
					StringBuilder stringBuilder = new StringBuilder();
					while (!IsWordBreak(_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020))
					{
						stringBuilder.Append(_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A);
						if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek() == -1)
						{
							break;
						}
					}
					return stringBuilder.ToString();
				}
			}

			internal TOKEN _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A
			{
				get
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020();
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek() == -1)
					{
						return TOKEN.NONE;
					}
					switch (_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020)
					{
					case '{':
						return TOKEN.CURLY_OPEN;
					case '}':
						_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
						return TOKEN.CURLY_CLOSE;
					case '[':
						return TOKEN.SQUARED_OPEN;
					case ']':
						_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
						return TOKEN.SQUARED_CLOSE;
					case ',':
						_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
						return TOKEN.COMMA;
					case '"':
						return TOKEN.STRING;
					case ':':
						return TOKEN.COLON;
					case '-':
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						return TOKEN.NUMBER;
					default:
						switch (_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020)
						{
						case "false":
							return TOKEN.FALSE;
						case "true":
							return TOKEN.TRUE;
						case "null":
							return TOKEN.NULL;
						default:
							return TOKEN.NONE;
						}
					}
				}
			}

			public static bool IsWordBreak(char c)
			{
				if (!char.IsWhiteSpace(c))
				{
					return "{}[],:\"".IndexOf(c) != -1;
				}
				return true;
			}

			internal _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A(string jsonString)
			{
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020 = new StringReader(jsonString);
			}

			public static object Parse(string jsonString)
			{
				using (_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A = new _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A(jsonString))
				{
					return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020();
				}
			}

			public void Dispose()
			{
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Dispose();
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020 = null;
			}

			internal Dictionary<string, object> _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020()
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
				while (true)
				{
					switch (_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A)
					{
					case TOKEN.COMMA:
						continue;
					case TOKEN.NONE:
						return null;
					case TOKEN.CURLY_CLOSE:
						return dictionary;
					}
					string text = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020();
					if (text == null)
					{
						return null;
					}
					if (_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A != TOKEN.COLON)
					{
						return null;
					}
					_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
					dictionary[text] = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020();
				}
			}

			internal List<object> _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A()
			{
				List<object> list = new List<object>();
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
				bool flag = true;
				while (flag)
				{
					TOKEN tOKEN = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A;
					switch (tOKEN)
					{
					case TOKEN.NONE:
						return null;
					case TOKEN.SQUARED_CLOSE:
						flag = false;
						break;
					default:
					{
						object item = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A(tOKEN);
						list.Add(item);
						break;
					}
					case TOKEN.COMMA:
						break;
					}
				}
				return list;
			}

			internal object _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020()
			{
				TOKEN _0020 = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A;
				return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A(_0020);
			}

			internal object _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A(TOKEN _0020)
			{
				switch (_0020)
				{
				case TOKEN.STRING:
					return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020();
				case TOKEN.NUMBER:
					return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A();
				case TOKEN.CURLY_OPEN:
					return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020();
				case TOKEN.SQUARED_OPEN:
					return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A();
				case TOKEN.TRUE:
					return true;
				case TOKEN.FALSE:
					return false;
				case TOKEN.NULL:
					return null;
				default:
					return null;
				}
			}

			internal string _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020()
			{
				StringBuilder stringBuilder = new StringBuilder();
				_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
				bool flag = true;
				while (flag)
				{
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek() == -1)
					{
						flag = false;
						break;
					}
					char c = _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A;
					switch (c)
					{
					case '"':
						flag = false;
						break;
					case '\\':
						if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek() == -1)
						{
							flag = false;
							break;
						}
						c = _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A;
						switch (c)
						{
						case '"':
						case '/':
						case '\\':
							stringBuilder.Append(c);
							break;
						case 'b':
							stringBuilder.Append('\b');
							break;
						case 'f':
							stringBuilder.Append('\f');
							break;
						case 'n':
							stringBuilder.Append('\n');
							break;
						case 'r':
							stringBuilder.Append('\r');
							break;
						case 't':
							stringBuilder.Append('\t');
							break;
						case 'u':
						{
							char[] array = new char[4];
							for (int i = 0; i < 4; i++)
							{
								array[i] = _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A;
							}
							stringBuilder.Append((char)Convert.ToInt32(new string(array), 16));
							break;
						}
						}
						break;
					default:
						stringBuilder.Append(c);
						break;
					}
				}
				return stringBuilder.ToString();
			}

			internal object _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A()
			{
				string text = _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020;
				if (text.IndexOf('.') == -1)
				{
					long.TryParse(text, out long result);
					return result;
				}
				double.TryParse(text, out double result2);
				return result2;
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020()
			{
				while (char.IsWhiteSpace(_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020))
				{
					_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Read();
					if (_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.Peek() == -1)
					{
						break;
					}
				}
			}
		}

		internal sealed class _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A
		{
			internal StringBuilder _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A;

			internal _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A()
			{
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A = new StringBuilder();
			}

			public static string Serialize(object obj)
			{
				_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A = new _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A();
				_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(obj);
				return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.ToString();
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(object _0020)
			{
				string _00202;
				IList _00203;
				IDictionary _00204;
				if (_0020 == null)
				{
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("null");
				}
				else if ((_00202 = (_0020 as string)) != null)
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(_00202);
				}
				else if (_0020 is bool)
				{
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(((bool)_0020) ? "true" : "false");
				}
				else if ((_00203 = (_0020 as IList)) != null)
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(_00203);
				}
				else if ((_00204 = (_0020 as IDictionary)) != null)
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A(_00204);
				}
				else if (_0020 is char)
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(new string((char)_0020, 1));
				}
				else
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(_0020);
				}
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A(IDictionary _0020)
			{
				bool flag = true;
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append('{');
				foreach (object key in _0020.Keys)
				{
					if (!flag)
					{
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(',');
					}
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(key.ToString());
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(':');
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(_0020[key]);
					flag = false;
				}
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append('}');
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(IList _0020)
			{
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append('[');
				bool flag = true;
				foreach (object item in _0020)
				{
					if (!flag)
					{
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(',');
					}
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(item);
					flag = false;
				}
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(']');
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(string _0020)
			{
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append('"');
				char[] array = _0020.ToCharArray();
				foreach (char c in array)
				{
					switch (c)
					{
					case '"':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\\"");
						continue;
					case '\\':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\\\");
						continue;
					case '\b':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\b");
						continue;
					case '\f':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\f");
						continue;
					case '\n':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\n");
						continue;
					case '\r':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\r");
						continue;
					case '\t':
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\t");
						continue;
					}
					int num = Convert.ToInt32(c);
					if (num >= 32 && num <= 126)
					{
						_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(c);
						continue;
					}
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append("\\u");
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(num.ToString("x4"));
				}
				_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append('"');
			}

			internal void _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(object _0020)
			{
				if (_0020 is float)
				{
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(((float)_0020).ToString("R"));
				}
				else if (_0020 is int || _0020 is uint || _0020 is long || _0020 is sbyte || _0020 is byte || _0020 is short || _0020 is ushort || _0020 is ulong)
				{
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(_0020);
				}
				else if (_0020 is double || _0020 is decimal)
				{
					_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Append(Convert.ToDouble(_0020).ToString("R"));
				}
				else
				{
					_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(_0020.ToString());
				}
			}
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020(object _0020, string _0020_000A, out object _0020_0020)
		{
			_0020_0020 = _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A);
			if (_0020_0020 != null)
			{
				return true;
			}
			return false;
		}

		internal static string _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020(object _0020, string _0020_000A, string _0020_0020 = null)
		{
			return _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A)?.ToString() ?? _0020_0020;
		}

		internal static float[] _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(object _0020, string _0020_000A, float[] _0020_0020 = null)
		{
			List<object> list = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(_0020, _0020_000A);
			if (list == null)
			{
				return _0020_0020;
			}
			float[] array = new float[list.Count];
			for (int i = 0; i < array.Length; i++)
			{
				if (list[i] is float)
				{
					array[i] = (float)list[i];
				}
				else if (list[i] is double)
				{
					array[i] = (float)(double)list[i];
				}
				else if (list[i] is long)
				{
					array[i] = (long)list[i];
				}
				else if (list[i] is int)
				{
					array[i] = (int)list[i];
				}
				else
				{
					array[i] = (float)FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(list[i].ToString());
				}
			}
			return array;
		}

		internal static float _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A(object _0020, string _0020_000A, float _0020_0020 = 0f)
		{
			object obj = _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A);
			if (obj == null)
			{
				return _0020_0020;
			}
			try
			{
				if (obj is long)
				{
					return (long)obj;
				}
				if (obj is int)
				{
					return (int)obj;
				}
				if (obj is float)
				{
					return (float)obj;
				}
				if (obj is double)
				{
					return (float)(double)obj;
				}
				return (float)FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(obj.ToString());
			}
			catch (Exception arg)
			{
				ConsoleManager.WriteInfo(string.Concat(arg));
				return _0020_0020;
			}
		}

		internal static int _0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020(object _0020, string _0020_000A, int _0020_0020 = 0)
		{
			object obj = _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A);
			if (obj == null)
			{
				return _0020_0020;
			}
			try
			{
				if (obj is long)
				{
					return (int)(long)obj;
				}
				if (obj is int)
				{
					return (int)obj;
				}
				return int.Parse(obj.ToString());
			}
			catch (Exception arg)
			{
				ConsoleManager.WriteInfo(string.Concat(arg));
				return _0020_0020;
			}
		}

		internal static long _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020(object _0020, string _0020_000A, long _0020_0020 = 0L)
		{
			object obj = _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A);
			if (obj == null)
			{
				return _0020_0020;
			}
			try
			{
				if (obj is long)
				{
					return (long)obj;
				}
				if (obj is int)
				{
					return (int)obj;
				}
				return long.Parse(obj.ToString());
			}
			catch (Exception arg)
			{
				ConsoleManager.WriteInfo(string.Concat(arg));
				return _0020_0020;
			}
		}

		internal static object _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(object _0020, string _0020_000A)
		{
			if (string.IsNullOrEmpty(_0020_000A))
			{
				return _0020;
			}
			string[] array = _0020_000A.Split('/', '\\');
			if (_0020 is Dictionary<string, object>)
			{
				Dictionary<string, object> obj = _0020 as Dictionary<string, object>;
				object value = null;
				if (!obj.TryGetValue(array[0], out value))
				{
					return null;
				}
				if (array.Length == 1)
				{
					return value;
				}
				return _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(value, string.Join("/", array, 1, array.Length - 1));
			}
			if (_0020 is Dictionary<string, string>)
			{
				Dictionary<string, string> obj2 = _0020 as Dictionary<string, string>;
				string value2 = null;
				if (!obj2.TryGetValue(array[0], out value2))
				{
					return null;
				}
				if (array.Length == 1)
				{
					return value2;
				}
				return _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(value2, string.Join("/", array, 1, array.Length - 1));
			}
			return null;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A(object _0020, string _0020_000A, out Dictionary<string, object> _0020_0020)
		{
			_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020(_0020, _0020_000A);
			if (_0020_0020 != null)
			{
				return true;
			}
			return false;
		}

		internal static Dictionary<string, object> _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020(object _0020, string _0020_000A)
		{
			return _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A) as Dictionary<string, object>;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(object _0020, string _0020_000A, out List<object> _0020_0020)
		{
			_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(_0020, _0020_000A);
			if (_0020_0020 != null)
			{
				return true;
			}
			return false;
		}

		internal static List<object> _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(object _0020, string _0020_000A)
		{
			return _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(_0020, _0020_000A) as List<object>;
		}

		public static object Deserialize(string json)
		{
			if (json == null)
			{
				return null;
			}
			return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A.Parse(json);
		}

		public static string Serialize(object obj)
		{
			return _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A.Serialize(obj);
		}
	}
}
