using System.Runtime.CompilerServices;

namespace DSMCaps.Mips
{
	public sealed class MipsMemoryOperandValue
	{
		[CompilerGenerated]
		private readonly MipsRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		private readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		public MipsRegister Base
		{
			get;
		}

		public long Displacement
		{
			get;
		}

		internal MipsMemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = MipsRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
		}
	}
}
