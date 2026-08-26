using System.Runtime.CompilerServices;

namespace DSMCaps.Arm
{
	public sealed class ArmMemoryOperandValue
	{
		[CompilerGenerated]
		private readonly ArmRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private readonly ArmRegister _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A;

		public ArmRegister Base
		{
			get;
		}

		public int Displacement
		{
			get;
		}

		public ArmRegister Index
		{
			get;
		}

		public int LeftShit
		{
			get;
		}

		public int Scale
		{
			get;
		}

		internal ArmMemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = ArmRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = ArmRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Index);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 = nativeMemoryOperandValue.LeftShift;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A = nativeMemoryOperandValue.Scale;
		}
	}
}
