using System.Runtime.CompilerServices;

namespace DSMCaps.Arm64
{
	public sealed class Arm64MemoryOperandValue
	{
		[CompilerGenerated]
		private readonly Arm64Register _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private readonly Arm64Register _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		public Arm64Register Base
		{
			get;
		}

		public int Displacement
		{
			get;
		}

		public Arm64Register Index
		{
			get;
		}

		internal Arm64MemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = Arm64Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = Arm64Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Index);
		}
	}
}
