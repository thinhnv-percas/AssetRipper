using System.Runtime.CompilerServices;

namespace DSMCaps.M68K
{
	public sealed class M68KBranchDisplacementOperandValue
	{
		[CompilerGenerated]
		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private readonly M68KBranchDisplacementSize _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A;

		public int Displacement
		{
			get;
		}

		public M68KBranchDisplacementSize DisplacementSize
		{
			get;
		}

		internal M68KBranchDisplacementOperandValue(ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A nativeBranchDisplacementOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeBranchDisplacementOperandValue.Displacement;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A = nativeBranchDisplacementOperandValue.DisplacementSize;
		}
	}
}
