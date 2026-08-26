namespace System.IO.Compression;

internal sealed class InflaterManaged
{
	private static readonly byte[] s_extraLengthBits = new byte[31]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
		4, 4, 4, 4, 5, 5, 5, 5, 16, 56,
		62
	};

	private static readonly int[] s_lengthBase = new int[31]
	{
		3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
		15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
		67, 83, 99, 115, 131, 163, 195, 227, 3, 0,
		0
	};

	private static readonly int[] s_distanceBasePosition = new int[32]
	{
		1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
		33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
		1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577,
		32769, 49153
	};

	private static readonly byte[] s_codeOrder = new byte[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private static readonly byte[] s_staticDistanceTreeTable = new byte[32]
	{
		0, 16, 8, 24, 4, 20, 12, 28, 2, 18,
		10, 26, 6, 22, 14, 30, 1, 17, 9, 25,
		5, 21, 13, 29, 3, 19, 11, 27, 7, 23,
		15, 31
	};

	private readonly System.IO.Compression.OutputWindow _output;

	private readonly System.IO.Compression.InputBuffer _input;

	private System.IO.Compression.HuffmanTree _literalLengthTree;

	private System.IO.Compression.HuffmanTree _distanceTree;

	private System.IO.Compression.InflaterState _state;

	private bool _hasFormatReader;

	private int _bfinal;

	private System.IO.Compression.BlockType _blockType;

	private readonly byte[] _blockLengthBuffer = new byte[4];

	private int _blockLength;

	private int _length;

	private int _distanceCode;

	private int _extraBits;

	private int _loopCounter;

	private int _literalLengthCodeCount;

	private int _distanceCodeCount;

	private int _codeLengthCodeCount;

	private int _codeArraySize;

	private int _lengthCode;

	private readonly byte[] _codeList;

	private readonly byte[] _codeLengthTreeCodeLength;

	private readonly bool _deflate64;

	private System.IO.Compression.HuffmanTree _codeLengthTree;

	private System.IO.Compression.IFileFormatReader _formatReader;

	public int AvailableOutput => _output.AvailableBytes;

	public InflaterManaged(bool deflate64)
	{
		_output = new System.IO.Compression.OutputWindow();
		_input = new System.IO.Compression.InputBuffer();
		_codeList = new byte[320];
		_codeLengthTreeCodeLength = new byte[19];
		_deflate64 = deflate64;
		Reset();
	}

	internal InflaterManaged(System.IO.Compression.IFileFormatReader reader, bool deflate64)
	{
		_output = new System.IO.Compression.OutputWindow();
		_input = new System.IO.Compression.InputBuffer();
		_codeList = new byte[320];
		_codeLengthTreeCodeLength = new byte[19];
		_deflate64 = deflate64;
		if (reader != null)
		{
			_formatReader = reader;
			_hasFormatReader = true;
		}
		Reset();
	}

	public void SetFileFormatReader(System.IO.Compression.IFileFormatReader reader)
	{
		_formatReader = reader;
		_hasFormatReader = true;
		Reset();
	}

	private void Reset()
	{
		_state = ((!_hasFormatReader) ? System.IO.Compression.InflaterState.ReadingBFinal : System.IO.Compression.InflaterState.ReadingHeader);
	}

	public void SetInput(byte[] inputBytes, int offset, int length)
	{
		_input.SetInput(inputBytes, offset, length);
	}

	public bool Finished()
	{
		if (_state != System.IO.Compression.InflaterState.Done)
		{
			return _state == System.IO.Compression.InflaterState.VerifyingFooter;
		}
		return true;
	}

	public bool NeedsInput()
	{
		return _input.NeedsInput();
	}

	public int Inflate(byte[] bytes, int offset, int length)
	{
		int num = 0;
		do
		{
			int num2 = _output.CopyTo(bytes, offset, length);
			if (num2 > 0)
			{
				if (_hasFormatReader)
				{
					_formatReader.UpdateWithBytesRead(bytes, offset, num2);
				}
				offset += num2;
				num += num2;
				length -= num2;
			}
		}
		while (length != 0 && !Finished() && Decode());
		if (_state == System.IO.Compression.InflaterState.VerifyingFooter && _output.AvailableBytes == 0)
		{
			_formatReader.Validate();
		}
		return num;
	}

	private bool Decode()
	{
		bool end_of_block = false;
		bool flag = false;
		if (Finished())
		{
			return true;
		}
		if (_hasFormatReader)
		{
			if (_state == System.IO.Compression.InflaterState.ReadingHeader)
			{
				if (!_formatReader.ReadHeader(_input))
				{
					return false;
				}
				_state = System.IO.Compression.InflaterState.ReadingBFinal;
			}
			else if (_state == System.IO.Compression.InflaterState.StartReadingFooter || _state == System.IO.Compression.InflaterState.ReadingFooter)
			{
				if (!_formatReader.ReadFooter(_input))
				{
					return false;
				}
				_state = System.IO.Compression.InflaterState.VerifyingFooter;
				return true;
			}
		}
		if (_state == System.IO.Compression.InflaterState.ReadingBFinal)
		{
			if (!_input.EnsureBitsAvailable(1))
			{
				return false;
			}
			_bfinal = _input.GetBits(1);
			_state = System.IO.Compression.InflaterState.ReadingBType;
		}
		if (_state == System.IO.Compression.InflaterState.ReadingBType)
		{
			if (!_input.EnsureBitsAvailable(2))
			{
				_state = System.IO.Compression.InflaterState.ReadingBType;
				return false;
			}
			_blockType = (System.IO.Compression.BlockType)_input.GetBits(2);
			if (_blockType == System.IO.Compression.BlockType.Dynamic)
			{
				_state = System.IO.Compression.InflaterState.ReadingNumLitCodes;
			}
			else if (_blockType == System.IO.Compression.BlockType.Static)
			{
				_literalLengthTree = System.IO.Compression.HuffmanTree.StaticLiteralLengthTree;
				_distanceTree = System.IO.Compression.HuffmanTree.StaticDistanceTree;
				_state = System.IO.Compression.InflaterState.DecodeTop;
			}
			else
			{
				if (_blockType != System.IO.Compression.BlockType.Uncompressed)
				{
					throw new InvalidDataException(System.SR.UnknownBlockType);
				}
				_state = System.IO.Compression.InflaterState.UncompressedAligning;
			}
		}
		if (_blockType == System.IO.Compression.BlockType.Dynamic)
		{
			flag = ((_state >= System.IO.Compression.InflaterState.DecodeTop) ? DecodeBlock(out end_of_block) : DecodeDynamicBlockHeader());
		}
		else if (_blockType == System.IO.Compression.BlockType.Static)
		{
			flag = DecodeBlock(out end_of_block);
		}
		else
		{
			if (_blockType != System.IO.Compression.BlockType.Uncompressed)
			{
				throw new InvalidDataException(System.SR.UnknownBlockType);
			}
			flag = DecodeUncompressedBlock(out end_of_block);
		}
		if (end_of_block && _bfinal != 0)
		{
			if (_hasFormatReader)
			{
				_state = System.IO.Compression.InflaterState.StartReadingFooter;
			}
			else
			{
				_state = System.IO.Compression.InflaterState.Done;
			}
		}
		return flag;
	}

	private bool DecodeUncompressedBlock(out bool end_of_block)
	{
		end_of_block = false;
		while (true)
		{
			switch (_state)
			{
			case System.IO.Compression.InflaterState.UncompressedAligning:
				_input.SkipToByteBoundary();
				_state = System.IO.Compression.InflaterState.UncompressedByte1;
				goto case System.IO.Compression.InflaterState.UncompressedByte1;
			case System.IO.Compression.InflaterState.UncompressedByte1:
			case System.IO.Compression.InflaterState.UncompressedByte2:
			case System.IO.Compression.InflaterState.UncompressedByte3:
			case System.IO.Compression.InflaterState.UncompressedByte4:
			{
				int bits = _input.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_blockLengthBuffer[(int)(_state - 16)] = (byte)bits;
				if (_state == System.IO.Compression.InflaterState.UncompressedByte4)
				{
					_blockLength = _blockLengthBuffer[0] + _blockLengthBuffer[1] * 256;
					int num2 = _blockLengthBuffer[2] + _blockLengthBuffer[3] * 256;
					if ((ushort)_blockLength != (ushort)(~num2))
					{
						throw new InvalidDataException(System.SR.InvalidBlockLength);
					}
				}
				break;
			}
			case System.IO.Compression.InflaterState.DecodingUncompressed:
			{
				int num = _output.CopyFrom(_input, _blockLength);
				_blockLength -= num;
				if (_blockLength == 0)
				{
					_state = System.IO.Compression.InflaterState.ReadingBFinal;
					end_of_block = true;
					return true;
				}
				if (_output.FreeBytes == 0)
				{
					return true;
				}
				return false;
			}
			default:
				throw new InvalidDataException(System.SR.UnknownState);
			}
			_state++;
		}
	}

	private bool DecodeBlock(out bool end_of_block_code_seen)
	{
		end_of_block_code_seen = false;
		int num = _output.FreeBytes;
		while (num > 258)
		{
			switch (_state)
			{
			case System.IO.Compression.InflaterState.DecodeTop:
			{
				int nextSymbol = _literalLengthTree.GetNextSymbol(_input);
				if (nextSymbol < 0)
				{
					return false;
				}
				if (nextSymbol < 256)
				{
					_output.Write((byte)nextSymbol);
					num--;
					break;
				}
				if (nextSymbol == 256)
				{
					end_of_block_code_seen = true;
					_state = System.IO.Compression.InflaterState.ReadingBFinal;
					return true;
				}
				nextSymbol -= 257;
				if (nextSymbol < 8)
				{
					nextSymbol += 3;
					_extraBits = 0;
				}
				else if (!_deflate64 && nextSymbol == 28)
				{
					nextSymbol = 258;
					_extraBits = 0;
				}
				else
				{
					if (nextSymbol < 0 || nextSymbol >= s_extraLengthBits.Length)
					{
						throw new InvalidDataException(System.SR.GenericInvalidData);
					}
					_extraBits = s_extraLengthBits[nextSymbol];
				}
				_length = nextSymbol;
				goto case System.IO.Compression.InflaterState.HaveInitialLength;
			}
			case System.IO.Compression.InflaterState.HaveInitialLength:
				if (_extraBits > 0)
				{
					_state = System.IO.Compression.InflaterState.HaveInitialLength;
					int bits2 = _input.GetBits(_extraBits);
					if (bits2 < 0)
					{
						return false;
					}
					if (_length < 0 || _length >= s_lengthBase.Length)
					{
						throw new InvalidDataException(System.SR.GenericInvalidData);
					}
					_length = s_lengthBase[_length] + bits2;
				}
				_state = System.IO.Compression.InflaterState.HaveFullLength;
				goto case System.IO.Compression.InflaterState.HaveFullLength;
			case System.IO.Compression.InflaterState.HaveFullLength:
				if (_blockType == System.IO.Compression.BlockType.Dynamic)
				{
					_distanceCode = _distanceTree.GetNextSymbol(_input);
				}
				else
				{
					_distanceCode = _input.GetBits(5);
					if (_distanceCode >= 0)
					{
						_distanceCode = s_staticDistanceTreeTable[_distanceCode];
					}
				}
				if (_distanceCode < 0)
				{
					return false;
				}
				_state = System.IO.Compression.InflaterState.HaveDistCode;
				goto case System.IO.Compression.InflaterState.HaveDistCode;
			case System.IO.Compression.InflaterState.HaveDistCode:
			{
				int distance;
				if (_distanceCode > 3)
				{
					_extraBits = _distanceCode - 2 >> 1;
					int bits = _input.GetBits(_extraBits);
					if (bits < 0)
					{
						return false;
					}
					distance = s_distanceBasePosition[_distanceCode] + bits;
				}
				else
				{
					distance = _distanceCode + 1;
				}
				_output.WriteLengthDistance(_length, distance);
				num -= _length;
				_state = System.IO.Compression.InflaterState.DecodeTop;
				break;
			}
			default:
				throw new InvalidDataException(System.SR.UnknownState);
			}
		}
		return true;
	}

	private bool DecodeDynamicBlockHeader()
	{
		switch (_state)
		{
		case System.IO.Compression.InflaterState.ReadingNumLitCodes:
			_literalLengthCodeCount = _input.GetBits(5);
			if (_literalLengthCodeCount < 0)
			{
				return false;
			}
			_literalLengthCodeCount += 257;
			_state = System.IO.Compression.InflaterState.ReadingNumDistCodes;
			goto case System.IO.Compression.InflaterState.ReadingNumDistCodes;
		case System.IO.Compression.InflaterState.ReadingNumDistCodes:
			_distanceCodeCount = _input.GetBits(5);
			if (_distanceCodeCount < 0)
			{
				return false;
			}
			_distanceCodeCount++;
			_state = System.IO.Compression.InflaterState.ReadingNumCodeLengthCodes;
			goto case System.IO.Compression.InflaterState.ReadingNumCodeLengthCodes;
		case System.IO.Compression.InflaterState.ReadingNumCodeLengthCodes:
			_codeLengthCodeCount = _input.GetBits(4);
			if (_codeLengthCodeCount < 0)
			{
				return false;
			}
			_codeLengthCodeCount += 4;
			_loopCounter = 0;
			_state = System.IO.Compression.InflaterState.ReadingCodeLengthCodes;
			goto case System.IO.Compression.InflaterState.ReadingCodeLengthCodes;
		case System.IO.Compression.InflaterState.ReadingCodeLengthCodes:
		{
			while (_loopCounter < _codeLengthCodeCount)
			{
				int bits = _input.GetBits(3);
				if (bits < 0)
				{
					return false;
				}
				_codeLengthTreeCodeLength[s_codeOrder[_loopCounter]] = (byte)bits;
				_loopCounter++;
			}
			for (int l = _codeLengthCodeCount; l < s_codeOrder.Length; l++)
			{
				_codeLengthTreeCodeLength[s_codeOrder[l]] = 0;
			}
			_codeLengthTree = new System.IO.Compression.HuffmanTree(_codeLengthTreeCodeLength);
			_codeArraySize = _literalLengthCodeCount + _distanceCodeCount;
			_loopCounter = 0;
			_state = System.IO.Compression.InflaterState.ReadingTreeCodesBefore;
			goto case System.IO.Compression.InflaterState.ReadingTreeCodesBefore;
		}
		case System.IO.Compression.InflaterState.ReadingTreeCodesBefore:
		case System.IO.Compression.InflaterState.ReadingTreeCodesAfter:
		{
			while (_loopCounter < _codeArraySize)
			{
				if (_state == System.IO.Compression.InflaterState.ReadingTreeCodesBefore && (_lengthCode = _codeLengthTree.GetNextSymbol(_input)) < 0)
				{
					return false;
				}
				if (_lengthCode <= 15)
				{
					_codeList[_loopCounter++] = (byte)_lengthCode;
				}
				else if (_lengthCode == 16)
				{
					if (!_input.EnsureBitsAvailable(2))
					{
						_state = System.IO.Compression.InflaterState.ReadingTreeCodesAfter;
						return false;
					}
					if (_loopCounter == 0)
					{
						throw new InvalidDataException();
					}
					byte b = _codeList[_loopCounter - 1];
					int num = _input.GetBits(2) + 3;
					if (_loopCounter + num > _codeArraySize)
					{
						throw new InvalidDataException();
					}
					for (int i = 0; i < num; i++)
					{
						_codeList[_loopCounter++] = b;
					}
				}
				else if (_lengthCode == 17)
				{
					if (!_input.EnsureBitsAvailable(3))
					{
						_state = System.IO.Compression.InflaterState.ReadingTreeCodesAfter;
						return false;
					}
					int num = _input.GetBits(3) + 3;
					if (_loopCounter + num > _codeArraySize)
					{
						throw new InvalidDataException();
					}
					for (int j = 0; j < num; j++)
					{
						_codeList[_loopCounter++] = 0;
					}
				}
				else
				{
					if (!_input.EnsureBitsAvailable(7))
					{
						_state = System.IO.Compression.InflaterState.ReadingTreeCodesAfter;
						return false;
					}
					int num = _input.GetBits(7) + 11;
					if (_loopCounter + num > _codeArraySize)
					{
						throw new InvalidDataException();
					}
					for (int k = 0; k < num; k++)
					{
						_codeList[_loopCounter++] = 0;
					}
				}
				_state = System.IO.Compression.InflaterState.ReadingTreeCodesBefore;
			}
			byte[] array = new byte[288];
			byte[] array2 = new byte[32];
			Array.Copy(_codeList, 0, array, 0, _literalLengthCodeCount);
			Array.Copy(_codeList, _literalLengthCodeCount, array2, 0, _distanceCodeCount);
			if (array[256] == 0)
			{
				throw new InvalidDataException();
			}
			_literalLengthTree = new System.IO.Compression.HuffmanTree(array);
			_distanceTree = new System.IO.Compression.HuffmanTree(array2);
			_state = System.IO.Compression.InflaterState.DecodeTop;
			return true;
		}
		default:
			throw new InvalidDataException(System.SR.UnknownState);
		}
	}

	public void Dispose()
	{
	}
}
