using System.IO;

namespace LightJson.Serialization;

internal sealed class TextScanner
{
	private TextReader reader;

	private TextPosition position;

	public TextPosition Position => position;

	public TextScanner(TextReader reader)
	{
		this.reader = reader;
	}

	public char Peek()
	{
		return (char)checked((ushort)Peek(throwAtEndOfFile: true));
	}

	public int Peek(bool throwAtEndOfFile)
	{
		int num = reader.Peek();
		if ((num == -1) & throwAtEndOfFile)
		{
			throw new JsonParseException(JsonParseException.ErrorType.IncompleteMessage, position);
		}
		return num;
	}

	public char Read()
	{
		int num = reader.Read();
		checked
		{
			switch (num)
			{
			case -1:
				throw new JsonParseException(JsonParseException.ErrorType.IncompleteMessage, position);
			case 10:
				position.Line++;
				position.Column = 0L;
				break;
			default:
				position.Column++;
				break;
			}
		}
		return (char)checked((ushort)num);
	}

	public void SkipWhitespace()
	{
		while (true)
		{
			char c = Peek();
			if (char.IsWhiteSpace(c))
			{
				Read();
				continue;
			}
			if (c == '/')
			{
				SkipComment();
				continue;
			}
			break;
		}
	}

	public void Assert(char next)
	{
		TextPosition textPosition = position;
		if (Read() != next)
		{
			throw new JsonParseException($"Parser expected '{next}'", JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, textPosition);
		}
	}

	public void Assert(string next)
	{
		for (int i = 0; i < next.Length; i = checked(i + 1))
		{
			Assert(next[i]);
		}
	}

	private void SkipComment()
	{
		Read();
		switch (Peek())
		{
		case '/':
			SkipLineComment();
			break;
		case '*':
			SkipBlockComment();
			break;
		default:
			throw new JsonParseException($"Parser expected '{Peek()}'", JsonParseException.ErrorType.InvalidOrUnexpectedCharacter, position);
		}
	}

	private void SkipLineComment()
	{
		Read();
		while (true)
		{
			switch (reader.Peek())
			{
			case 10:
				Read();
				return;
			case -1:
				return;
			}
			Read();
		}
	}

	private void SkipBlockComment()
	{
		Read();
		bool flag = false;
		while (true)
		{
			switch (reader.Peek())
			{
			case 42:
				Read();
				flag = true;
				break;
			case 47:
				Read();
				if (flag)
				{
					return;
				}
				flag = false;
				break;
			case -1:
				return;
			default:
				Read();
				flag = false;
				break;
			}
		}
	}
}
