using System.Runtime.CompilerServices;

namespace DSMCaps.X86
{
	public sealed class X86MemoryOperandValue
	{
		[CompilerGenerated]
		internal readonly X86Register _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal readonly X86Register _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		internal readonly X86Register _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A;

		public X86Register Base
		{
			get;
		}

		public long Displacement
		{
			get;
		}

		public X86Register Index
		{
			get;
		}

		public int Scale
		{
			get;
		}

		public X86Register Segment
		{
			get;
		}

		internal X86MemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Index);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A = nativeMemoryOperandValue.Scale;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Segment);
		}
	}
}
