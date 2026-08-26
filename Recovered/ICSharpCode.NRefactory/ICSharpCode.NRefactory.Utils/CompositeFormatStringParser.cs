using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Utils
{
	public class CompositeFormatStringParser
	{
		private IList<IFormatStringError> errors;

		private bool hasMissingEndBrace;

		public CompositeFormatStringParser()
		{
			errors = new List<IFormatStringError>();
		}

		public FormatStringParseResult Parse(string format)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			FormatStringParseResult formatStringParseResult = new FormatStringParseResult();
			int num = 0;
			int length = format.Length;
			for (int i = 0; i < length; i++)
			{
				GetText(format, ref i);
				if (i >= format.Length || format[i] != '{')
				{
					continue;
				}
				int num2 = i;
				List<IFormatStringError> list = new List<IFormatStringError>(GetErrors());
				i++;
				int index = ParseIndex(format, ref i);
				CheckForMissingEndBrace(format, i, length);
				int? alignment = ParseAlignment(format, ref i, length);
				CheckForMissingEndBrace(format, i, length);
				string formatString = ParseSubFormatString(format, ref i, length);
				CheckForMissingEndBrace(format, i, length);
				if (i == num2 + 1 && (i == length || (i < length && format[i] != '}')))
				{
					SetErrors(list);
					if (i >= length || format[i] != '{')
					{
						AddError(new DefaultFormatStringError
						{
							Message = "Unescaped '{'",
							StartLocation = num2,
							EndLocation = num2 + 1,
							OriginalText = "{",
							SuggestedReplacementText = "{{"
						});
					}
					continue;
				}
				if (num2 - num > 0)
				{
					TextSegment textSegment = new TextSegment(UnEscape(format.Substring(num, num2 - num)));
					textSegment.Errors = list;
					formatStringParseResult.Segments.Add(textSegment);
				}
				if (i < length && format[i] != '}')
				{
					i--;
				}
				int endLocation = Math.Min(length, i + 1);
				formatStringParseResult.Segments.Add(new FormatItem(index, alignment, formatString)
				{
					StartLocation = num2,
					EndLocation = endLocation,
					Errors = GetErrors()
				});
				ClearErrors();
				num = i + 1;
			}
			if (num < length)
			{
				TextSegment textSegment2 = new TextSegment(UnEscape(format.Substring(num)), num);
				textSegment2.Errors = GetErrors();
				formatStringParseResult.Segments.Add(textSegment2);
			}
			return formatStringParseResult;
		}

		private int ParseIndex(string format, ref int i)
		{
			int parsedCharacters;
			int? andCheckNumber = GetAndCheckNumber(format, ",:}", ref i, i, out parsedCharacters);
			if (parsedCharacters == 0)
			{
				AddError(new DefaultFormatStringError
				{
					StartLocation = i,
					EndLocation = i,
					Message = "Missing index",
					OriginalText = "",
					SuggestedReplacementText = "0"
				});
			}
			return andCheckNumber ?? 0;
		}

		private int? ParseAlignment(string format, ref int i, int length)
		{
			if (i < length && format[i] == ',')
			{
				int num = i;
				i++;
				while (i < length && char.IsWhiteSpace(format[i]))
				{
					i++;
				}
				int parsedCharacters;
				int? andCheckNumber = GetAndCheckNumber(format, ",:}", ref i, num + 1, out parsedCharacters);
				if (parsedCharacters == 0)
				{
					AddError(new DefaultFormatStringError
					{
						StartLocation = i,
						EndLocation = i,
						Message = "Missing alignment",
						OriginalText = "",
						SuggestedReplacementText = "0"
					});
				}
				return andCheckNumber ?? 0;
			}
			return null;
		}

		private string ParseSubFormatString(string format, ref int i, int length)
		{
			if (i < length && format[i] == ':')
			{
				i++;
				int num = i;
				GetText(format, ref i, "", allowEscape: true);
				return UnEscape(format.Substring(num, i - num));
			}
			return null;
		}

		private void CheckForMissingEndBrace(string format, int i, int length)
		{
			if (i == length)
			{
				int num = i - 1;
				while (format[num] == '}')
				{
					num--;
				}
				if ((i - num) % 2 == 1)
				{
					AddMissingEndBraceError(i, i, "Missing '}'", "");
				}
			}
		}

		private void GetText(string format, ref int index, string delimiters = "", bool allowEscape = false)
		{
			while (index < format.Length)
			{
				if (format[index] == '{' || format[index] == '}')
				{
					if (!((index + 1 < format.Length && format[index + 1] == format[index]) & allowEscape))
					{
						break;
					}
					index++;
				}
				else if (delimiters.Contains(format[index].ToString()))
				{
					break;
				}
				index++;
			}
		}

		private int? GetNumber(string format, ref int index)
		{
			if (format.Length == 0)
			{
				return null;
			}
			int num = 0;
			int i = index;
			bool flag = format[i] != '-';
			if (!flag)
			{
				i++;
			}
			int num2 = i;
			for (; i < format.Length && format[i] >= '0' && format[i] <= '9'; i++)
			{
				num = 10 * num + format[i] - 48;
			}
			if (i == num2)
			{
				return null;
			}
			index = i;
			return flag ? num : (-num);
		}

		private int? GetAndCheckNumber(string format, string delimiters, ref int index, int numberFieldStart, out int parsedCharacters)
		{
			int index2 = index;
			GetText(format, ref index2, delimiters);
			int num = index2;
			string text = format.Substring(index, num - index);
			parsedCharacters = text.Length;
			int index3 = 0;
			int? number = GetNumber(text, ref index3);
			if (index3 != parsedCharacters && num < format.Length && delimiters.Contains(format[num]))
			{
				index = num;
				string replacementText = (number ?? 0).ToString();
				AddInvalidNumberFormatError(numberFieldStart, format.Substring(numberFieldStart, index - numberFieldStart), replacementText);
			}
			else
			{
				int num2 = index + index3;
				if (index3 != parsedCharacters)
				{
					index = num2;
					AddMissingEndBraceError(index, index, "Missing ending '}'", "");
				}
				else
				{
					index = num2;
				}
			}
			return number;
		}

		public static string UnEscape(string unEscaped)
		{
			return unEscaped.Replace("{{", "{").Replace("}}", "}");
		}

		private void AddError(IFormatStringError error)
		{
			errors.Add(error);
		}

		private void AddMissingEndBraceError(int start, int end, string message, string originalText)
		{
			if (!hasMissingEndBrace)
			{
				AddError(new DefaultFormatStringError
				{
					StartLocation = start,
					EndLocation = end,
					Message = message,
					OriginalText = originalText,
					SuggestedReplacementText = "}"
				});
				hasMissingEndBrace = true;
			}
		}

		private void AddInvalidNumberFormatError(int i, string number, string replacementText)
		{
			AddError(new DefaultFormatStringError
			{
				StartLocation = i,
				EndLocation = i + number.Length,
				Message = $"Invalid number '{number}'",
				OriginalText = number,
				SuggestedReplacementText = replacementText
			});
		}

		private IList<IFormatStringError> GetErrors()
		{
			return errors;
		}

		private void SetErrors(IList<IFormatStringError> errors)
		{
			this.errors = errors;
		}

		private void ClearErrors()
		{
			hasMissingEndBrace = false;
			errors = new List<IFormatStringError>();
		}
	}
}
