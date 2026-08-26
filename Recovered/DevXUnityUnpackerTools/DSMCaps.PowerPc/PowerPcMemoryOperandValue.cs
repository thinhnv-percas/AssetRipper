using System.Runtime.CompilerServices;

namespace DSMCaps.PowerPc
{
	public sealed class PowerPcMemoryOperandValue
	{
		[CompilerGenerated]
		internal readonly PowerPcRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		public PowerPcRegister Base
		{
			get;
		}

		public int Displacement
		{
			get;
		}

		internal PowerPcMemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020 nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = PowerPcRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
		}
	}
}
