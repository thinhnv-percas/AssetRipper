using System.Runtime.CompilerServices;

namespace DSMCaps.M68K
{
	public sealed class M68KMemoryOperandValue
	{
		[CompilerGenerated]
		private readonly M68KRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020;

		[CompilerGenerated]
		private readonly short _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private readonly M68KRegister _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		private readonly M68KRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		private readonly byte _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		public M68KRegister Base
		{
			get;
		}

		public byte BitField
		{
			get;
		}

		public short Displacement
		{
			get;
		}

		public M68KRegister Index
		{
			get;
		}

		public byte IndexSize
		{
			get;
		}

		public M68KRegister IndirectBase
		{
			get;
		}

		public int IndirectDisplacement
		{
			get;
		}

		public byte Offset
		{
			get;
		}

		public int OutDisplacement
		{
			get;
		}

		public byte Scale
		{
			get;
		}

		public byte Width
		{
			get;
		}

		internal M68KMemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020 = nativeMemoryOperandValue.BitField;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.Index);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A = nativeMemoryOperandValue.IndexSize;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020 = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeMemoryOperandValue.IndirectBase);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A = nativeMemoryOperandValue.IndirectDisplacement;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020 = nativeMemoryOperandValue.Offset;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A = nativeMemoryOperandValue.OutDisplacement;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A = nativeMemoryOperandValue.Scale;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 = nativeMemoryOperandValue.Width;
		}
	}
}
