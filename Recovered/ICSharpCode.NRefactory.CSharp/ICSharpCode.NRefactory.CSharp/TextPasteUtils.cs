using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ICSharpCode.NRefactory.CSharp
{
	public static class TextPasteUtils
	{
		public interface IPasteStrategy
		{
			PasteStrategy Type
			{
				get;
			}

			string Encode(string text);

			string Decode(string text);
		}

		public sealed class TextPasteStrategies
		{
			private IDictionary<PasteStrategy, IPasteStrategy> strategies;

			public IPasteStrategy this[PasteStrategy strategy]
			{
				get
				{
					if (strategies.ContainsKey(strategy))
					{
						return strategies[strategy];
					}
					return DefaultStrategy;
				}
			}

			public TextPasteStrategies()
			{
				strategies = (from t in Assembly.GetExecutingAssembly().GetTypes()
					where typeof(IPasteStrategy).IsAssignableFrom(t) && t.IsClass
					select (IPasteStrategy)t.GetProperty("Instance").GetValue(null, null)).ToDictionary((IPasteStrategy s) => s.Type);
			}
		}

		public class PlainTextPasteStrategy : IPasteStrategy
		{
			private static PlainTextPasteStrategy instance;

			public static IPasteStrategy Instance => instance ?? (instance = new PlainTextPasteStrategy());

			public PasteStrategy Type => PasteStrategy.PlainText;

			protected PlainTextPasteStrategy()
			{
			}

			public string Encode(string text)
			{
				return text;
			}

			public string Decode(string text)
			{
				return text;
			}
		}

		public class StringLiteralPasteStrategy : IPasteStrategy
		{
			private static StringLiteralPasteStrategy instance;

			public static IPasteStrategy Instance => instance ?? (instance = new StringLiteralPasteStrategy());

			public PasteStrategy Type => PasteStrategy.StringLiteral;

			protected StringLiteralPasteStrategy()
			{
			}

			public string Encode(string text)
			{
				return CSharpOutputVisitor.ConvertString(text);
			}

			public string Decode(string text)
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = false;
				for (int i = 0; i < text.Length; i++)
				{
					char c = text[i];
					if (flag)
					{
						char r;
						switch (c)
						{
						case 'a':
							stringBuilder.Append('\a');
							break;
						case 'b':
							stringBuilder.Append('\b');
							break;
						case 'n':
							stringBuilder.Append('\n');
							break;
						case 't':
							stringBuilder.Append('\t');
							break;
						case 'v':
							stringBuilder.Append('\v');
							break;
						case 'r':
							stringBuilder.Append('\r');
							break;
						case '\\':
							stringBuilder.Append('\\');
							break;
						case 'f':
							stringBuilder.Append('\f');
							break;
						case '0':
							stringBuilder.Append(0);
							break;
						case '"':
							stringBuilder.Append('"');
							break;
						case '\'':
							stringBuilder.Append('\'');
							break;
						case 'x':
							if (TryGetHex(text, -1, ref i, out r))
							{
								stringBuilder.Append(r);
								break;
							}
							goto default;
						case 'u':
							if (TryGetHex(text, 4, ref i, out r))
							{
								stringBuilder.Append(r);
								break;
							}
							goto default;
						case 'U':
							if (TryGetHex(text, 8, ref i, out r))
							{
								stringBuilder.Append(r);
								break;
							}
							goto default;
						default:
							stringBuilder.Append('\\');
							stringBuilder.Append(c);
							break;
						}
						flag = false;
					}
					else if (c != '\\')
					{
						stringBuilder.Append(c);
					}
					else
					{
						flag = true;
					}
				}
				return stringBuilder.ToString();
			}

			private static bool TryGetHex(string text, int count, ref int idx, out char r)
			{
				int num = 0;
				int num2 = (count != -1) ? count : 4;
				for (int i = 0; i < num2; i++)
				{
					int num3 = text[idx + 1 + i];
					if (num3 >= 48 && num3 <= 57)
					{
						num3 -= 48;
					}
					else if (num3 >= 65 && num3 <= 70)
					{
						num3 = num3 - 65 + 10;
					}
					else
					{
						if (num3 < 97 || num3 > 102)
						{
							r = '\0';
							return false;
						}
						num3 = num3 - 97 + 10;
					}
					num = num * 16 + num3;
				}
				if (num2 == 8)
				{
					if (num > 1114111)
					{
						r = '\0';
						return false;
					}
					if (num >= 65536)
					{
						num = (num - 65536) / 1024 + 55296;
					}
				}
				r = (char)num;
				idx += num2;
				return true;
			}
		}

		public class VerbatimStringPasteStrategy : IPasteStrategy
		{
			private static VerbatimStringPasteStrategy instance;

			private static readonly Dictionary<char, IEnumerable<char>> encodeReplace = new Dictionary<char, IEnumerable<char>>
			{
				{
					'"',
					"\"\""
				}
			};

			public static IPasteStrategy Instance => instance ?? (instance = new VerbatimStringPasteStrategy());

			public PasteStrategy Type => PasteStrategy.VerbatimString;

			protected VerbatimStringPasteStrategy()
			{
			}

			public string Encode(string text)
			{
				return string.Concat(text.SelectMany((char c) => (!encodeReplace.ContainsKey(c)) ? new char[1]
				{
					c
				} : encodeReplace[c]));
			}

			public string Decode(string text)
			{
				bool isEscaped = false;
				return string.Concat(from c in text
					where !(isEscaped = (!isEscaped && c == '"'))
					select c);
			}
		}

		public static TextPasteStrategies Strategies = new TextPasteStrategies();

		public static IPasteStrategy DefaultStrategy = PlainTextPasteStrategy.Instance;

		public static IPasteStrategy StringLiteralStrategy = StringLiteralPasteStrategy.Instance;

		public static IPasteStrategy VerbatimStringStrategy = VerbatimStringPasteStrategy.Instance;
	}
}
