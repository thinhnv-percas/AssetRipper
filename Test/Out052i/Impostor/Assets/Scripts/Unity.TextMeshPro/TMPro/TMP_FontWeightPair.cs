using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000043")]
	public struct TMP_FontWeightPair
	{
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x0")]
		public TMP_FontAsset regularTypeface;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x8")]
		public TMP_FontAsset italicTypeface;
	}
}
