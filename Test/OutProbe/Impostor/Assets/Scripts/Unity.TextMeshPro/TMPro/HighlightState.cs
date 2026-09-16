using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000026")]
	public struct HighlightState
	{
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x0")]
		public Color32 color;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x4")]
		public TMP_Offset padding;

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x15D0420", Offset = "0x15D0420", Length = "0x10")]
		public HighlightState(Color32 color, TMP_Offset padding)
		{
			this.color = default(Color32);
			this.padding = default(TMP_Offset);
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x15D0430", Offset = "0x15D0430", Length = "0xCC")]
		public static bool operator ==(HighlightState lhs, HighlightState rhs)
		{
			return false;
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x15D04FC", Offset = "0x15D04FC", Length = "0x48")]
		public static bool operator !=(HighlightState lhs, HighlightState rhs)
		{
			return false;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x15D0544", Offset = "0x15D0544", Length = "0x6C")]
		public override int GetHashCode()
		{
			return 0;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x15D05B0", Offset = "0x15D05B0", Length = "0x80")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x15D0630", Offset = "0x15D0630", Length = "0xA4")]
		public bool Equals(HighlightState other)
		{
			return false;
		}
	}
}
