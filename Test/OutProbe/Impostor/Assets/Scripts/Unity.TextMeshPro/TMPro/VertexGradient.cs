using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000018")]
	public struct VertexGradient
	{
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x0")]
		public Color topLeft;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x10")]
		public Color topRight;

		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x20")]
		public Color bottomLeft;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x30")]
		public Color bottomRight;

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x15CF724", Offset = "0x15CF724", Length = "0x24")]
		public VertexGradient(Color color)
		{
			topLeft = default(Color);
			topRight = default(Color);
			bottomLeft = default(Color);
			bottomRight = default(Color);
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x15CF748", Offset = "0x15CF748", Length = "0x1C")]
		public VertexGradient(Color color0, Color color1, Color color2, Color color3)
		{
			topLeft = default(Color);
			topRight = default(Color);
			bottomLeft = default(Color);
			bottomRight = default(Color);
		}
	}
}
