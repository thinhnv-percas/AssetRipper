using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200002A")]
	public static class TMP_Compatibility
	{
		[Token(Token = "0x200002B")]
		public enum AnchorPositions
		{
			[Token(Token = "0x4000159")]
			TopLeft = 0,
			[Token(Token = "0x400015A")]
			Top = 1,
			[Token(Token = "0x400015B")]
			TopRight = 2,
			[Token(Token = "0x400015C")]
			Left = 3,
			[Token(Token = "0x400015D")]
			Center = 4,
			[Token(Token = "0x400015E")]
			Right = 5,
			[Token(Token = "0x400015F")]
			BottomLeft = 6,
			[Token(Token = "0x4000160")]
			Bottom = 7,
			[Token(Token = "0x4000161")]
			BottomRight = 8,
			[Token(Token = "0x4000162")]
			BaseLine = 9,
			[Token(Token = "0x4000163")]
			None = 10
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0x15D08CC", Offset = "0x15D08CC", Length = "0x24")]
		public static TextAlignmentOptions ConvertTextAlignmentEnumValues(TextAlignmentOptions oldValue)
		{
			return (TextAlignmentOptions)0;
		}
	}
}
