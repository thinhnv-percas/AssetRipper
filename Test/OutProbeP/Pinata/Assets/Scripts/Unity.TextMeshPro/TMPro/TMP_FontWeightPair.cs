using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200001D")]
	public struct TMP_FontWeightPair
	{
		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x0")]
		public TMP_FontAsset regularTypeface;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x8")]
		public TMP_FontAsset italicTypeface;
	}
}
