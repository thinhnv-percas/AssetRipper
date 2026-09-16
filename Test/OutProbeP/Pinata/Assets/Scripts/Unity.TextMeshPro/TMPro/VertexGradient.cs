using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 64)]
	[Token(Token = "0x2000063")]
	public struct VertexGradient
	{
		[Token(Token = "0x4000425")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Color topLeft;

		[Token(Token = "0x4000426")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Color topRight;

		[Token(Token = "0x4000427")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public Color bottomLeft;

		[Token(Token = "0x4000428")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public Color bottomRight;

		[Token(Token = "0x6000538")]
		[Address(RVA = "0x85C6E4", Offset = "0x85C6E4", Length = "0x24")]
		public VertexGradient(Color color)
		{
			topLeft = default(Color);
			topRight = default(Color);
			bottomLeft = default(Color);
			bottomRight = default(Color);
		}

		[Token(Token = "0x6000539")]
		[Address(RVA = "0x85C708", Offset = "0x85C708", Length = "0x70")]
		public VertexGradient(Color color0, Color color1, Color color2, Color color3)
		{
			topLeft = default(Color);
			topRight = default(Color);
			bottomLeft = default(Color);
			bottomRight = default(Color);
		}
	}
}
