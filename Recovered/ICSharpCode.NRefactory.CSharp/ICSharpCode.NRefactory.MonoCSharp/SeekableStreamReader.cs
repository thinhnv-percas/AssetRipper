using ICSharpCode.NRefactory.Editor;
using System;
using System.IO;
using System.Text;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class SeekableStreamReader : IDisposable
	{
		public const int DefaultReadAheadSize = 2048;

		private readonly ITextSource textSource;

		private int pos;

		public int Position
		{
			get
			{
				return pos;
			}
			set
			{
				pos = value;
			}
		}

		private static string GetAllText(Stream stream, Encoding encoding)
		{
			using (StreamReader streamReader = new StreamReader(stream, encoding))
			{
				return streamReader.ReadToEnd();
			}
		}

		public SeekableStreamReader(Stream stream, Encoding encoding, char[] sharedBuffer = null)
			: this(new StringTextSource(GetAllText(stream, encoding)))
		{
		}

		public SeekableStreamReader(ITextSource source)
		{
			textSource = source;
		}

		public void Dispose()
		{
		}

		public char GetChar(int position)
		{
			return textSource.GetCharAt(position);
		}

		public char[] ReadChars(int fromPosition, int toPosition)
		{
			return textSource.GetText(fromPosition, toPosition - fromPosition).ToCharArray();
		}

		public int Peek()
		{
			if (pos >= textSource.TextLength)
			{
				return -1;
			}
			return textSource.GetCharAt(pos);
		}

		public int Read()
		{
			if (pos >= textSource.TextLength)
			{
				return -1;
			}
			return textSource.GetCharAt(pos++);
		}
	}
}
