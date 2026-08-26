namespace System.IO.Compression;

internal sealed class FastEncoder
{
	private readonly System.IO.Compression.FastEncoderWindow _inputWindow;

	private readonly System.IO.Compression.Match _currentMatch;

	private double _lastCompressionRatio;

	internal int BytesInHistory => _inputWindow.BytesAvailable;

	internal System.IO.Compression.DeflateInput UnprocessedInput => _inputWindow.UnprocessedInput;

	internal double LastCompressionRatio => _lastCompressionRatio;

	public FastEncoder()
	{
		_inputWindow = new System.IO.Compression.FastEncoderWindow();
		_currentMatch = new System.IO.Compression.Match();
	}

	internal void FlushInput()
	{
		_inputWindow.FlushWindow();
	}

	internal void GetBlock(System.IO.Compression.DeflateInput input, System.IO.Compression.OutputBuffer output, int maxBytesToCopy)
	{
		WriteDeflatePreamble(output);
		GetCompressedOutput(input, output, maxBytesToCopy);
		WriteEndOfBlock(output);
	}

	internal void GetCompressedData(System.IO.Compression.DeflateInput input, System.IO.Compression.OutputBuffer output)
	{
		GetCompressedOutput(input, output, -1);
	}

	internal void GetBlockHeader(System.IO.Compression.OutputBuffer output)
	{
		WriteDeflatePreamble(output);
	}

	internal void GetBlockFooter(System.IO.Compression.OutputBuffer output)
	{
		WriteEndOfBlock(output);
	}

	private void GetCompressedOutput(System.IO.Compression.DeflateInput input, System.IO.Compression.OutputBuffer output, int maxBytesToCopy)
	{
		int bytesWritten = output.BytesWritten;
		int num = 0;
		int num2 = BytesInHistory + input.Count;
		do
		{
			int num3 = ((input.Count < _inputWindow.FreeWindowSpace) ? input.Count : _inputWindow.FreeWindowSpace);
			if (maxBytesToCopy >= 1)
			{
				num3 = Math.Min(num3, maxBytesToCopy - num);
			}
			if (num3 > 0)
			{
				_inputWindow.CopyBytes(input.Buffer, input.StartIndex, num3);
				input.ConsumeBytes(num3);
				num += num3;
			}
			GetCompressedOutput(output);
		}
		while (SafeToWriteTo(output) && InputAvailable(input) && (maxBytesToCopy < 1 || num < maxBytesToCopy));
		int bytesWritten2 = output.BytesWritten;
		int num4 = bytesWritten2 - bytesWritten;
		int num5 = BytesInHistory + input.Count;
		int num6 = num2 - num5;
		if (num4 != 0)
		{
			_lastCompressionRatio = (double)num4 / (double)num6;
		}
	}

	private void GetCompressedOutput(System.IO.Compression.OutputBuffer output)
	{
		while (_inputWindow.BytesAvailable > 0 && SafeToWriteTo(output))
		{
			_inputWindow.GetNextSymbolOrMatch(_currentMatch);
			if (_currentMatch.State == MatchState.HasSymbol)
			{
				WriteChar(_currentMatch.Symbol, output);
				continue;
			}
			if (_currentMatch.State == MatchState.HasMatch)
			{
				WriteMatch(_currentMatch.Length, _currentMatch.Position, output);
				continue;
			}
			WriteChar(_currentMatch.Symbol, output);
			WriteMatch(_currentMatch.Length, _currentMatch.Position, output);
		}
	}

	private bool InputAvailable(System.IO.Compression.DeflateInput input)
	{
		if (input.Count <= 0)
		{
			return BytesInHistory > 0;
		}
		return true;
	}

	private bool SafeToWriteTo(System.IO.Compression.OutputBuffer output)
	{
		return output.FreeBytes > 16;
	}

	private void WriteEndOfBlock(System.IO.Compression.OutputBuffer output)
	{
		uint num = System.IO.Compression.FastEncoderStatics.FastEncoderLiteralCodeInfo[256];
		int n = (int)(num & 0x1F);
		output.WriteBits(n, num >> 5);
	}

	internal static void WriteMatch(int matchLen, int matchPos, System.IO.Compression.OutputBuffer output)
	{
		uint num = System.IO.Compression.FastEncoderStatics.FastEncoderLiteralCodeInfo[254 + matchLen];
		int num2 = (int)(num & 0x1F);
		if (num2 <= 16)
		{
			output.WriteBits(num2, num >> 5);
		}
		else
		{
			output.WriteBits(16, (num >> 5) & 0xFFFF);
			output.WriteBits(num2 - 16, num >> 21);
		}
		num = System.IO.Compression.FastEncoderStatics.FastEncoderDistanceCodeInfo[System.IO.Compression.FastEncoderStatics.GetSlot(matchPos)];
		output.WriteBits((int)(num & 0xF), num >> 8);
		int num3 = (int)((num >> 4) & 0xF);
		if (num3 != 0)
		{
			output.WriteBits(num3, (uint)matchPos & System.IO.Compression.FastEncoderStatics.BitMask[num3]);
		}
	}

	internal static void WriteChar(byte b, System.IO.Compression.OutputBuffer output)
	{
		uint num = System.IO.Compression.FastEncoderStatics.FastEncoderLiteralCodeInfo[b];
		output.WriteBits((int)(num & 0x1F), num >> 5);
	}

	internal static void WriteDeflatePreamble(System.IO.Compression.OutputBuffer output)
	{
		output.WriteBytes(System.IO.Compression.FastEncoderStatics.FastEncoderTreeStructureData, 0, System.IO.Compression.FastEncoderStatics.FastEncoderTreeStructureData.Length);
		output.WriteBits(9, 34u);
	}
}
