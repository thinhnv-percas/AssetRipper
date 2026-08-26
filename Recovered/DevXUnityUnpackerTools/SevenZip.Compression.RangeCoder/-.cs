using @as;
using DevXForms;
using DevXUnityUnpackerTools._WPF;
using DMP4;
using DSMCaps;
using FMOD;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using LZ4;
using System;
using System.Collections.Generic;
using System.IO;
using Unreal;
using Wasm;
using Wasm.Interpret;

namespace SevenZip.Compression.RangeCoder
{
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020
	{
		public const uint kTopValue = 16777216u;

		private Stream _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A;

		public ulong Low;

		public uint Range;

		private uint _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020;

		private byte _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A;

		private long _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		public void SetStream(Stream stream)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A = stream;
		}

		public void ReleaseStream()
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A = null;
		}

		public void Init()
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A.Position;
			Low = 0uL;
			Range = uint.MaxValue;
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 = 1u;
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A = 0;
		}

		public void FlushData()
		{
			for (int i = 0; i < 5; i++)
			{
				ShiftLow();
			}
		}

		public void FlushStream()
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A.Flush();
		}

		public void CloseStream()
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A.Close();
		}

		public void Encode(uint start, uint size, uint total)
		{
			Low += start * (Range /= total);
			Range *= size;
			while (Range < 16777216)
			{
				Range <<= 8;
				ShiftLow();
			}
		}

		public void ShiftLow()
		{
			if ((uint)Low < 4278190080u || (int)(Low >> 32) == 1)
			{
				byte b = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A;
				do
				{
					_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A.WriteByte((byte)(b + (Low >> 32)));
					b = byte.MaxValue;
				}
				while (--_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 != 0);
				_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A = (byte)((uint)Low >> 24);
			}
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020++;
			Low = (uint)Low << 8;
		}

		public void EncodeDirectBits(uint v, int numTotalBits)
		{
			for (int num = numTotalBits - 1; num >= 0; num--)
			{
				Range >>= 1;
				if (((v >> num) & 1) == 1)
				{
					Low += Range;
				}
				if (Range < 16777216)
				{
					Range <<= 8;
					ShiftLow();
				}
			}
		}

		public void EncodeBit(uint size0, int numTotalBits, uint symbol)
		{
			uint num = (Range >> numTotalBits) * size0;
			if (symbol == 0)
			{
				Range = num;
			}
			else
			{
				Low += num;
				Range -= num;
			}
			while (Range < 16777216)
			{
				Range <<= 8;
				ShiftLow();
			}
		}

		public long GetProcessedSizeAdd()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 + _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A.Position - _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 + 4;
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A
	{
		public const uint kTopValue = 16777216u;

		public uint Range;

		public uint Code;

		public Stream Stream;

		public void Init(Stream stream)
		{
			Stream = stream;
			Code = 0u;
			Range = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				Code = ((Code << 8) | (byte)Stream.ReadByte());
			}
		}

		public void ReleaseStream()
		{
			Stream = null;
		}

		public void CloseStream()
		{
			Stream.Close();
		}

		public void Normalize()
		{
			while (Range < 16777216)
			{
				Code = ((Code << 8) | (byte)Stream.ReadByte());
				Range <<= 8;
			}
		}

		public void Normalize2()
		{
			if (Range < 16777216)
			{
				Code = ((Code << 8) | (byte)Stream.ReadByte());
				Range <<= 8;
			}
		}

		public uint GetThreshold(uint total)
		{
			return Code / (Range /= total);
		}

		public void Decode(uint start, uint size, uint total)
		{
			Code -= start * Range;
			Range *= size;
			Normalize();
		}

		public uint DecodeDirectBits(int numTotalBits)
		{
			uint num = Range;
			uint num2 = Code;
			uint num3 = 0u;
			for (int num4 = numTotalBits; num4 > 0; num4--)
			{
				num >>= 1;
				uint num5 = num2 - num >> 31;
				num2 -= (num & (num5 - 1));
				num3 = ((num3 << 1) | (1 - num5));
				if (num < 16777216)
				{
					num2 = ((num2 << 8) | (byte)Stream.ReadByte());
					num <<= 8;
				}
			}
			Range = num;
			Code = num2;
			return num3;
		}

		public uint DecodeBit(uint size0, int numTotalBits)
		{
			uint num = (Range >> numTotalBits) * size0;
			uint result;
			if (Code < num)
			{
				result = 0u;
				Range = num;
			}
			else
			{
				result = 1u;
				Code -= num;
				Range -= num;
			}
			Normalize();
			return result;
		}
	}
	internal struct _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020
	{
		public const int kNumBitModelTotalBits = 11;

		public const uint kBitModelTotal = 2048u;

		private const int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020 = 5;

		private const int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A = 2;

		public const int kNumBitPriceShiftBits = 6;

		private uint _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;

		private static uint[] _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020;

		public void Init()
		{
			_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 = 1024u;
		}

		public void UpdateModel(uint symbol)
		{
			if (symbol == 0)
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 += 2048 - _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
			}
			else
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 -= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
			}
		}

		public void Encode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 encoder, uint symbol)
		{
			uint num = (encoder.Range >> 11) * _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;
			if (symbol == 0)
			{
				encoder.Range = num;
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 += 2048 - _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
			}
			else
			{
				encoder.Low += num;
				encoder.Range -= num;
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 -= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
			}
			if (encoder.Range < 16777216)
			{
				encoder.Range <<= 8;
				encoder.ShiftLow();
			}
		}

		static _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020()
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020 = new uint[512];
			for (int num = 8; num >= 0; num--)
			{
				int num2 = 1 << 9 - num - 1;
				uint num3 = (uint)(1 << 9 - num);
				for (uint num4 = (uint)num2; num4 < num3; num4++)
				{
					_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020[num4] = (uint)((num << 6) + (int)(num3 - num4 << 6 >> 9 - num - 1));
				}
			}
		}

		public uint GetPrice(uint symbol)
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020[(((_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 - symbol) ^ (int)(0 - symbol)) & 0x7FF) >> 2];
		}

		public uint GetPrice0()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020[_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 2];
		}

		public uint GetPrice1()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020[2048 - _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 2];
		}
	}
	internal struct _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A
	{
		public const int kNumBitModelTotalBits = 11;

		public const uint kBitModelTotal = 2048u;

		private const int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020 = 5;

		private uint _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;

		public void UpdateModel(int numMoveBits, uint symbol)
		{
			if (symbol == 0)
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 += 2048 - _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> numMoveBits;
			}
			else
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 -= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> numMoveBits;
			}
		}

		public void Init()
		{
			_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 = 1024u;
		}

		public uint Decode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A rangeDecoder)
		{
			uint num = (rangeDecoder.Range >> 11) * _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;
			if (rangeDecoder.Code < num)
			{
				rangeDecoder.Range = num;
				_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 += 2048 - _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
				if (rangeDecoder.Range < 16777216)
				{
					rangeDecoder.Code = ((rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte());
					rangeDecoder.Range <<= 8;
				}
				return 0u;
			}
			rangeDecoder.Range -= num;
			rangeDecoder.Code -= num;
			_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 -= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 >> 5;
			if (rangeDecoder.Range < 16777216)
			{
				rangeDecoder.Code = ((rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte());
				rangeDecoder.Range <<= 8;
			}
			return 1u;
		}
	}
	internal struct _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020
	{
		private _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020[] _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020;

		private int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;

		public _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020(int numBitLevels)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A = numBitLevels;
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020[1 << numBitLevels];
		}

		public void Init()
		{
			for (uint num = 1u; num < 1 << _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; num++)
			{
				_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Init();
			}
		}

		public void Encode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 rangeEncoder, uint symbol)
		{
			uint num = 1u;
			int num2 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;
			while (num2 > 0)
			{
				num2--;
				uint num3 = (symbol >> num2) & 1;
				_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Encode(rangeEncoder, num3);
				num = ((num << 1) | num3);
			}
		}

		public void ReverseEncode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 rangeEncoder, uint symbol)
		{
			uint num = 1u;
			for (uint num2 = 0u; num2 < _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; num2++)
			{
				uint num3 = symbol & 1;
				_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Encode(rangeEncoder, num3);
				num = ((num << 1) | num3);
				symbol >>= 1;
			}
		}

		public uint GetPrice(uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			int num3 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;
			while (num3 > 0)
			{
				num3--;
				uint num4 = (symbol >> num3) & 1;
				num += _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num2].GetPrice(num4);
				num2 = (num2 << 1) + num4;
			}
			return num;
		}

		public uint ReverseGetPrice(uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int num3 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; num3 > 0; num3--)
			{
				uint num4 = symbol & 1;
				symbol >>= 1;
				num += _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num2].GetPrice(num4);
				num2 = ((num2 << 1) | num4);
			}
			return num;
		}

		public static uint ReverseGetPrice(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020[] Models, uint startIndex, int NumBitLevels, uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int num3 = NumBitLevels; num3 > 0; num3--)
			{
				uint num4 = symbol & 1;
				symbol >>= 1;
				num += Models[startIndex + num2].GetPrice(num4);
				num2 = ((num2 << 1) | num4);
			}
			return num;
		}

		public static void ReverseEncode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020[] Models, uint startIndex, _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 rangeEncoder, int NumBitLevels, uint symbol)
		{
			uint num = 1u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num2 = symbol & 1;
				Models[startIndex + num].Encode(rangeEncoder, num2);
				num = ((num << 1) | num2);
				symbol >>= 1;
			}
		}
	}
	internal struct _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A
	{
		private _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A[] _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020;

		private int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;

		public _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A(int numBitLevels)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A = numBitLevels;
			_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A[1 << numBitLevels];
		}

		public void Init()
		{
			for (uint num = 1u; num < 1 << _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; num++)
			{
				_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Init();
			}
		}

		public uint Decode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A rangeDecoder)
		{
			uint num = 1u;
			for (int num2 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; num2 > 0; num2--)
			{
				num = (num << 1) + _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Decode(rangeDecoder);
			}
			return (uint)((int)num - (1 << _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A));
		}

		public uint ReverseDecode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A rangeDecoder)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A; i++)
			{
				uint num3 = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020[num].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		public static uint ReverseDecode(_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A[] Models, uint startIndex, _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A rangeDecoder, int NumBitLevels)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num3 = Models[startIndex + num].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A
	{
		private string _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020()
		{
			((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020)null).SetInflaterInput((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A)null);
			VerFormat verFormat = ((ShaderInfo)null)._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A;
			return "2033941081";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A
	{
		private unsafe int _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020(_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 _0020)
		{
			((_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A*)(byte*)null)->StructParams = null;
			((TreeNodeCollection)null).Add((string)null);
			return 542709801;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A
	{
		private string _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020(CapstoneDisassembler _0020, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A _0020_000A, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A _0020_0020)
		{
			((_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A)null)._0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A();
			return "1705851724";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A
	{
		private void _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020(uint _0020, TIMEUNIT _0020_000A, uint _0020_0020, TIMEUNIT _0020_000A_000A)
		{
			_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020();
			bool flag = (ImageResData)null != (ImageResData)null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A
	{
		private void _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020(_3DView.Params _0020, _3DView.ModelHandler _0020_000A, ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020_0020, bool _0020_000A_000A)
		{
			((_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A)null).GetDigest();
			bool flag = _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020;
			((ImageInfo)null)._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A((List<_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020>)null);
			LZ4Stream._0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020((string)null);
			((_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A((string)null, (string)null);
			DateTime maxDate = ((_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020)null).MaxDate;
			OperatorImpls.Int32LeS(null, null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A
	{
		private unsafe object _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020(string _0020, ExternalKind _0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A _0020_0020, bool _0020_000A_000A)
		{
			((_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A)null)._0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(ref *(UObject[]*)null);
			return null;
		}
	}
}
