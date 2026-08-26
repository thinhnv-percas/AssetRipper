using System.Runtime.CompilerServices;

namespace DSMCaps.PowerPc
{
	public sealed class PowerPcConditionRegisterOperandValue
	{
		[CompilerGenerated]
		internal readonly PowerPcBranchCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal readonly PowerPcRegister _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A;

		public PowerPcBranchCode BranchCode
		{
			get;
		}

		public PowerPcRegister Register
		{
			get;
		}

		public int Scale
		{
			get;
		}

		internal PowerPcConditionRegisterOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 nativeConditionRegisterOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A = nativeConditionRegisterOperandValue.BranchCode;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 = PowerPcRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeConditionRegisterOperandValue.Register);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A = nativeConditionRegisterOperandValue.Scale;
		}
	}
}
