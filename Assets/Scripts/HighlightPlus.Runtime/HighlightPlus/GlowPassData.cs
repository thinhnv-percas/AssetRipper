using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Serializable]
	[Token(Token = "0x2000021")]
	public struct GlowPassData
	{
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x0")]
		public float offset;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x4")]
		public float alpha;

		[ColorUsage(true, true)]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x8")]
		public Color color;
	}
}
