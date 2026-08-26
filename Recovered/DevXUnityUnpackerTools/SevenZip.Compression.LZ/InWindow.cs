using System.IO;

namespace SevenZip.Compression.LZ
{
	public class InWindow
	{
		public byte[] _bufferBase;

		private Stream _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020;

		private uint _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020;

		private bool _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A;

		private uint _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public uint _bufferOffset;

		public uint _blockSize;

		public uint _pos;

		private uint _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A;

		private uint _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020;

		public uint _streamPos;

		public void MoveBlock()
		{
			uint num = _bufferOffset + _pos - _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A;
			if (num != 0)
			{
				num--;
			}
			uint num2 = _bufferOffset + _streamPos - num;
			for (uint num3 = 0u; num3 < num2; num3++)
			{
				_bufferBase[num3] = _bufferBase[num + num3];
			}
			_bufferOffset -= num;
		}

		public virtual void ReadBlock()
		{
			if (_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A)
			{
				return;
			}
			while (true)
			{
				int num = (int)(0 - _bufferOffset + _blockSize - _streamPos);
				if (num == 0)
				{
					return;
				}
				int num2 = _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020.Read(_bufferBase, (int)(_bufferOffset + _streamPos), num);
				if (num2 == 0)
				{
					break;
				}
				_streamPos += (uint)num2;
				if (_streamPos >= _pos + _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020)
				{
					_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 = _streamPos - _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020;
				}
			}
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 = _streamPos;
			if (_bufferOffset + _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 > _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020)
			{
				_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 = _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020 - _bufferOffset;
			}
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A = true;
		}

		private void _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020()
		{
			_bufferBase = null;
		}

		public void Create(uint keepSizeBefore, uint keepSizeAfter, uint keepSizeReserv)
		{
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A = keepSizeBefore;
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020 = keepSizeAfter;
			uint num = keepSizeBefore + keepSizeAfter + keepSizeReserv;
			if (_bufferBase == null || _blockSize != num)
			{
				_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020();
				_blockSize = num;
				_bufferBase = new byte[_blockSize];
			}
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020 = _blockSize - keepSizeAfter;
		}

		public void SetStream(Stream stream)
		{
			_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 = stream;
		}

		public void ReleaseStream()
		{
			_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 = null;
		}

		public void Init()
		{
			_bufferOffset = 0u;
			_pos = 0u;
			_streamPos = 0u;
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A = false;
			ReadBlock();
		}

		public void MovePos()
		{
			_pos++;
			if (_pos > _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020)
			{
				if (_bufferOffset + _pos > _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020)
				{
					MoveBlock();
				}
				ReadBlock();
			}
		}

		public byte GetIndexByte(int index)
		{
			return _bufferBase[_bufferOffset + _pos + index];
		}

		public uint GetMatchLen(int index, uint distance, uint limit)
		{
			if (_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A && _pos + index + limit > _streamPos)
			{
				limit = (uint)((int)_streamPos - (int)(_pos + index));
			}
			distance++;
			uint num = (uint)((int)(_bufferOffset + _pos) + index);
			uint num2;
			for (num2 = 0u; num2 < limit && _bufferBase[num + num2] == _bufferBase[num + num2 - distance]; num2++)
			{
			}
			return num2;
		}

		public uint GetNumAvailableBytes()
		{
			return _streamPos - _pos;
		}

		public void ReduceOffsets(int subValue)
		{
			_bufferOffset += (uint)subValue;
			_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 -= (uint)subValue;
			_pos -= (uint)subValue;
			_streamPos -= (uint)subValue;
		}
	}
}
