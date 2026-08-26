using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class LinearMemory
	{
		private List<byte> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020;

		[CompilerGenerated]
		private ResizableLimits _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A;

		public ResizableLimits Limits
		{
			get;
			private set;
		}

		public uint Size => (uint)_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020.Count / 65536u;

		public LinearMemoryAsInt8 Int8 => new LinearMemoryAsInt8(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemoryAsInt16 Int16 => new LinearMemoryAsInt16(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemoryAsInt32 Int32 => new LinearMemoryAsInt32(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemoryAsInt64 Int64 => new LinearMemoryAsInt64(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemoryAsFloat32 Float32 => new LinearMemoryAsFloat32(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemoryAsFloat64 Float64 => new LinearMemoryAsFloat64(_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020);

		public LinearMemory(ResizableLimits limits)
		{
			Limits = limits;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020 = new List<byte>();
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A(limits.Initial);
		}

		private int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A(uint _0020)
		{
			if (Limits.HasMaximum && _0020 > Limits.Maximum.Value)
			{
				return -1;
			}
			int size = (int)Size;
			int num = (int)(_0020 * 65536);
			while (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020.Count < num)
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020.Add(0);
			}
			return size;
		}

		public int Grow(uint numberOfPages)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A(Size + numberOfPages);
		}

		internal static void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(List<byte> _0020, uint _0020_000A, uint _0020_0020)
		{
			if ((ulong)_0020.Count < (ulong)((long)_0020_000A + (long)_0020_0020))
			{
				throw new TrapException($"Memory access out of bounds: cannot access {_0020_0020} bytes at offset {_0020_000A} in memory with length {_0020.Count}.", "out of bounds memory access");
			}
		}
	}
}
