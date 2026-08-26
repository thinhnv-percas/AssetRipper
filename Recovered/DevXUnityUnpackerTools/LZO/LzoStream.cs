using System;
using System.IO;
using System.IO.Compression;

namespace LZO
{
	public class LzoStream : Stream
	{
		internal enum LzoState
		{
			ZeroCopy,
			SmallCopy1,
			SmallCopy2,
			SmallCopy3,
			LargeCopy
		}

		internal readonly Stream Source;

		internal long? _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A;

		internal readonly bool _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		internal byte[] DecodedBuffer;

		internal const int MaxWindowSize = 49151;

		internal RingBuffer RingBuffer = new RingBuffer(49151);

		internal long OutputPosition;

		internal int Instruction;

		internal LzoState State;

		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A.HasValue)
				{
					return _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A.Value;
				}
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				return OutputPosition;
			}
			set
			{
				if (OutputPosition != value)
				{
					Seek(value, SeekOrigin.Begin);
				}
			}
		}

		public LzoStream(Stream stream, CompressionMode mode)
			: this(stream, mode, leaveOpen: false)
		{
		}

		public LzoStream(Stream stream, CompressionMode mode, bool leaveOpen)
		{
			if (mode != 0)
			{
				throw new NotSupportedException("Compression is not supported");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("write-only stream cannot be used for decompression");
			}
			Source = stream;
			if (!(stream is BufferedStream))
			{
				Source = new BufferedStream(stream);
			}
			_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = leaveOpen;
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A();
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A()
		{
			Instruction = Source.ReadByte();
			if (Instruction == -1)
			{
				throw new EndOfStreamException();
			}
			if (Instruction > 15 && Instruction <= 17)
			{
				throw new Exception();
			}
		}

		internal void _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			while (true)
			{
				int num = Source.Read(_0020, _0020_000A, _0020_0020);
				if (num == 0)
				{
					break;
				}
				RingBuffer.Write(_0020, _0020_000A, num);
				_0020_000A += num;
				_0020_0020 -= num;
				if (_0020_0020 <= 0)
				{
					return;
				}
			}
			throw new EndOfStreamException();
		}

		internal virtual int Decode(byte[] buffer, int offset, int count)
		{
			int num;
			if (Instruction <= 15)
			{
				switch (State)
				{
				case LzoState.ZeroCopy:
				{
					int num2 = 3;
					num2 = ((Instruction == 0) ? (num2 + (15 + _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A())) : (num2 + Instruction));
					if (num2 > count)
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(buffer, offset, count);
						DecodedBuffer = new byte[num2 - count];
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(DecodedBuffer, 0, num2 - count);
						num = count;
					}
					else
					{
						_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(buffer, offset, num2);
						num = num2;
					}
					State = LzoState.LargeCopy;
					break;
				}
				case LzoState.SmallCopy1:
				case LzoState.SmallCopy2:
				case LzoState.SmallCopy3:
					num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020(buffer, offset, count);
					break;
				case LzoState.LargeCopy:
					num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A(buffer, offset, count);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			else if (Instruction < 32)
			{
				int num3 = Instruction & 7;
				int _0020_000A_0020 = (num3 != 0) ? (2 + num3) : (9 + _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A());
				int num4 = Source.ReadByte();
				if (num4 == -1)
				{
					throw new EndOfStreamException();
				}
				int num5 = Source.ReadByte();
				if (num5 == -1)
				{
					throw new EndOfStreamException();
				}
				num5 = ((num5 << 8) | num4) >> 2;
				int num6 = (16384 + ((Instruction & 8) << 11)) | num5;
				if (num6 == 16384)
				{
					return -1;
				}
				num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(buffer, offset, count, num6, _0020_000A_0020, num4 & 3);
			}
			else if (Instruction < 64)
			{
				int num7 = Instruction & 0x1F;
				int _0020_000A_00202 = (num7 != 0) ? (2 + num7) : (33 + _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A());
				int num8 = Source.ReadByte();
				if (num8 == -1)
				{
					throw new EndOfStreamException();
				}
				int num9 = Source.ReadByte();
				if (num9 == -1)
				{
					throw new EndOfStreamException();
				}
				int _0020_000A_000A = (((num9 << 8) | num8) >> 2) + 1;
				num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(buffer, offset, count, _0020_000A_000A, _0020_000A_00202, num8 & 3);
			}
			else if (Instruction < 128)
			{
				int _0020_000A_00203 = 3 + ((Instruction >> 5) & 1);
				int num10 = Source.ReadByte();
				if (num10 == -1)
				{
					throw new EndOfStreamException();
				}
				int _0020_000A_000A2 = (num10 << 3) + ((Instruction >> 2) & 7) + 1;
				num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(buffer, offset, count, _0020_000A_000A2, _0020_000A_00203, Instruction & 3);
			}
			else
			{
				int _0020_000A_00204 = 5 + ((Instruction >> 5) & 3);
				int num11 = Source.ReadByte();
				if (num11 == -1)
				{
					throw new EndOfStreamException();
				}
				int _0020_000A_000A3 = (num11 << 3) + ((Instruction & 0x1C) >> 2) + 1;
				num = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(buffer, offset, count, _0020_000A_000A3, _0020_000A_00204, Instruction & 3);
			}
			Instruction = Source.ReadByte();
			if (Instruction == -1)
			{
				throw new EndOfStreamException();
			}
			OutputPosition += num;
			return num;
		}

		internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			int num = Source.ReadByte();
			if (num == -1)
			{
				throw new EndOfStreamException();
			}
			int _0020_000A_000A = (num << 2) + ((Instruction & 0xC) >> 2) + 2049;
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, 3, Instruction & 3);
		}

		internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			int num = Source.ReadByte();
			if (num == -1)
			{
				throw new EndOfStreamException();
			}
			int _0020_000A_000A = (num << 2) + ((Instruction & 0xC) >> 2) + 1;
			return _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, 2, Instruction & 3);
		}

		internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A()
		{
			int num = 0;
			int num2;
			while ((num2 = Source.ReadByte()) == 0)
			{
				if (num >= 2147482647)
				{
					throw new Exception();
				}
				num += 255;
			}
			if (num2 == -1)
			{
				throw new EndOfStreamException();
			}
			return num + num2;
		}

		internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
		{
			int num = _0020_000A_0020 + _0020_0020_000A;
			if (_0020_0020 < num)
			{
				if (_0020_0020 <= _0020_000A_0020)
				{
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_0020, 0);
					DecodedBuffer = new byte[num - _0020_0020];
					_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(DecodedBuffer, 0, DecodedBuffer.Length, _0020_000A_000A, _0020_000A_0020 - _0020_0020, _0020_0020_000A);
					return _0020_0020;
				}
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(_0020, _0020_000A, _0020_0020, _0020_000A_000A, _0020_000A_0020, 0);
				int num2 = _0020_0020 - _0020_000A_0020;
				DecodedBuffer = new byte[_0020_0020_000A - num2];
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(_0020, _0020_000A + _0020_000A_0020, num2);
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(DecodedBuffer, 0, _0020_0020_000A - num2);
				State = (LzoState)_0020_0020_000A;
				return _0020_0020;
			}
			int num3 = _0020_000A_0020;
			if (_0020_000A_0020 > _0020_000A_000A)
			{
				num3 = _0020_000A_000A;
				RingBuffer.Copy(_0020, _0020_000A, _0020_000A_000A, num3);
				_0020_000A_0020 -= num3;
				int num4 = _0020_000A_0020 / _0020_000A_000A;
				for (int i = 0; i < num4; i++)
				{
					Buffer.BlockCopy(_0020, _0020_000A, _0020, _0020_000A + num3, num3);
					_0020_000A += num3;
					_0020_000A_0020 -= num3;
				}
				if (num4 > 0)
				{
					int num5 = num3 * num4;
					RingBuffer.Write(_0020, _0020_000A - num5, num5);
				}
				_0020_000A += num3;
			}
			if (_0020_000A_0020 > 0)
			{
				if (_0020_000A_0020 < num3)
				{
					num3 = _0020_000A_0020;
				}
				RingBuffer.Copy(_0020, _0020_000A, _0020_000A_000A, num3);
				_0020_000A += num3;
			}
			if (_0020_0020_000A > 0)
			{
				_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(_0020, _0020_000A, _0020_0020_000A);
			}
			State = (LzoState)_0020_0020_000A;
			return num;
		}

		internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A.HasValue && OutputPosition >= _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A)
			{
				return -1;
			}
			if (DecodedBuffer != null)
			{
				int num = DecodedBuffer.Length;
				if (_0020_0020 > num)
				{
					Buffer.BlockCopy(DecodedBuffer, 0, _0020, _0020_000A, num);
					DecodedBuffer = null;
					OutputPosition += num;
					return num;
				}
				Buffer.BlockCopy(DecodedBuffer, 0, _0020, _0020_000A, _0020_0020);
				if (num > _0020_0020)
				{
					byte[] array = new byte[num - _0020_0020];
					Buffer.BlockCopy(DecodedBuffer, _0020_0020, array, 0, array.Length);
					DecodedBuffer = array;
				}
				else
				{
					DecodedBuffer = null;
				}
				OutputPosition += _0020_0020;
				return _0020_0020;
			}
			int result;
			if ((result = Decode(_0020, _0020_000A, _0020_0020)) < 0)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A = OutputPosition;
				return -1;
			}
			return result;
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A.HasValue && OutputPosition >= _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A)
			{
				return 0;
			}
			int num = 0;
			while (count > 0)
			{
				int num2 = _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(buffer, offset, count);
				if (num2 == -1)
				{
					return num;
				}
				num += num2;
				offset += num2;
				count -= num2;
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A = value;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException("cannot write to readonly stream");
		}

		protected override void Dispose(bool disposing)
		{
			if (!_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020)
			{
				Source.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
