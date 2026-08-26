using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace LightJson.Serialization;

internal sealed class JsonReader
{
	private TextScanner scanner;

	private JsonReader(TextReader reader)
	{
		scanner = new TextScanner(reader);
	}

	public static JsonValue Parse(TextReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		return new JsonReader(reader).Parse();
	}

	public static JsonValue Parse(string source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		using StringReader reader = new StringReader(source);
		return Parse(reader);
	}

	private string ReadJsonKey()
	{
		return ReadString();
	}

	private JsonValue ReadJsonValue()
	{
		scanner.SkipWhitespace();
		char c = scanner.Peek();
		if (char.IsNumber(c))
		{
			return ReadNumber();
		}
		switch (c)
		{
		case '{':
			return ReadObject();
		case '[':
			return ReadArray();
		case '"':
			return ReadString();
		case '-':
			return ReadNumber();
		case 'f':
		case 't':
			return ReadBoolean();
		case 'n':
			return ReadNull();
		default:
			throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, scanner.Position);
		}
	}

	private JsonValue ReadNull()
	{
		scanner.Assert("null");
		return JsonValue.Null;
	}

	private JsonValue ReadBoolean()
	{
		char c = scanner.Peek();
		if (c == 't')
		{
			scanner.Assert("true");
			return true;
		}
		scanner.Assert("false");
		return false;
	}

	private void ReadDigits(StringBuilder builder)
	{
		while (true)
		{
			int num = scanner.Peek(throwAtEndOfFile: false);
			if (num == -1 || !char.IsNumber((char)checked((ushort)num)))
			{
				break;
			}
			builder.Append(scanner.Read());
		}
	}

	private JsonValue ReadNumber()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (scanner.Peek() == '-')
		{
			stringBuilder.Append(scanner.Read());
		}
		if (scanner.Peek() == '0')
		{
			stringBuilder.Append(scanner.Read());
		}
		else
		{
			ReadDigits(stringBuilder);
		}
		if (scanner.Peek(throwAtEndOfFile: false) == 46)
		{
			stringBuilder.Append(scanner.Read());
			ReadDigits(stringBuilder);
		}
		if (scanner.Peek(throwAtEndOfFile: false) == 101 || scanner.Peek(throwAtEndOfFile: false) == 69)
		{
			stringBuilder.Append(scanner.Read());
			char c = scanner.Peek();
			char c2 = c;
			if (c2 == '+' || c2 == '-')
			{
				stringBuilder.Append(scanner.Read());
			}
			ReadDigits(stringBuilder);
		}
		return double.Parse(stringBuilder.ToString(), CultureInfo.InvariantCulture);
	}

	private string ReadString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		scanner.Assert('"');
		while (true)
		{
			TextPosition position = scanner.Position;
			char c = scanner.Read();
			switch (c)
			{
			case '\\':
				position = scanner.Position;
				c = scanner.Read();
				switch (char.ToLower(c))
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
					stringBuilder.Append(ReadUnicodeLiteral());
					break;
				default:
					throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
				}
				break;
			default:
				if (char.IsControl(c))
				{
					throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
				}
				stringBuilder.Append(c);
				break;
			case '"':
				return stringBuilder.ToString();
			}
		}
	}

	private int ReadHexDigit()
	{
		TextPosition position = scanner.Position;
		return char.ToUpper(scanner.Read()) switch
		{
			'0' => 0, 
			'1' => 1, 
			'2' => 2, 
			'3' => 3, 
			'4' => 4, 
			'5' => 5, 
			'6' => 6, 
			'7' => 7, 
			'8' => 8, 
			'9' => 9, 
			'A' => 10, 
			'B' => 11, 
			'C' => 12, 
			'D' => 13, 
			'E' => 14, 
			'F' => 15, 
			_ => throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position), 
		};
	}

	private char ReadUnicodeLiteral()
	{
		int num = 0;
		checked
		{
			num += ReadHexDigit() * 4096;
			num += ReadHexDigit() * 256;
			num += ReadHexDigit() * 16;
			num += ReadHexDigit();
		}
		return (char)checked((ushort)num);
	}

	private JsonObject ReadObject()
	{
		return ReadObject(new JsonObject());
	}

	private JsonObject ReadObject(JsonObject jsonObject)
	{
		scanner.Assert('{');
		scanner.SkipWhitespace();
		if (scanner.Peek() == '}')
		{
			scanner.Read();
		}
		else
		{
			while (true)
			{
				scanner.SkipWhitespace();
				TextPosition position = scanner.Position;
				string key = ReadJsonKey();
				if (jsonObject.ContainsKey(key))
				{
					throw new JsonParseException(JsonParseException.ErrorType.DuplicateObjectKeys, position);
				}
				scanner.SkipWhitespace();
				scanner.Assert(':');
				scanner.SkipWhitespace();
				JsonValue value = ReadJsonValue();
				jsonObject.Add(key, value);
				scanner.SkipWhitespace();
				position = scanner.Position;
				char c = scanner.Read();
				if (c == ',')
				{
					scanner.SkipWhitespace();
					if (scanner.Peek() == '}')
					{
						c = scanner.Read();
					}
				}
				if (c == '}')
				{
					break;
				}
				if (c == ',')
				{
					continue;
				}
				throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
			}
		}
		return jsonObject;
	}

	private JsonArray ReadArray()
	{
		return ReadArray(new JsonArray());
	}

	private JsonArray ReadArray(JsonArray jsonArray)
	{
		scanner.Assert('[');
		scanner.SkipWhitespace();
		if (scanner.Peek() == ']')
		{
			scanner.Read();
		}
		else
		{
			while (true)
			{
				scanner.SkipWhitespace();
				JsonValue value = ReadJsonValue();
				jsonArray.Add(value);
				scanner.SkipWhitespace();
				TextPosition position = scanner.Position;
				char c = scanner.Read();
				if (c == ',')
				{
					scanner.SkipWhitespace();
					if (scanner.Peek() == ']')
					{
						c = scanner.Read();
					}
				}
				if (c == ']')
				{
					break;
				}
				if (c == ',')
				{
					continue;
				}
				throw new JsonParseException(JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
			}
		}
		return jsonArray;
	}

	private JsonValue Parse()
	{
		scanner.SkipWhitespace();
		return ReadJsonValue();
	}
}
