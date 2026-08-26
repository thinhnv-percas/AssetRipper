using System.Collections.Generic;

namespace Wasm.Interpret
{
	public struct LinearMemoryAsInt16
	{
		private List<byte> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A;

		public short this[uint offset]
		{
			get
			{
				LinearMemory._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A, offset, 2u);
				return (short)((_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A[(int)(offset + 1)] << 8) | _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A[(int)offset]);
			}
			set
			{
				LinearMemory._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A, offset, 2u);
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A[(int)(offset + 1)] = (byte)(value >> 8);
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A[(int)offset] = (byte)value;
			}
		}

		internal LinearMemoryAsInt16(List<byte> memory)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A = memory;
		}
	}
}
