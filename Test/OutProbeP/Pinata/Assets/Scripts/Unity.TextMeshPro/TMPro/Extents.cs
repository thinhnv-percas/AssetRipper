using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000068")]
	public struct Extents
	{
		[Token(Token = "0x400043C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector2 min;

		[Token(Token = "0x400043D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public Vector2 max;

		[Token(Token = "0x600053E")]
		[Address(RVA = "0x846274", Offset = "0x846274", Length = "0xC")]
		public Extents(Vector2 min, Vector2 max)
		{
			this.min = default(Vector2);
			this.max = default(Vector2);
		}

		[Token(Token = "0x600053F")]
		[Address(RVA = "0x846280", Offset = "0x846280", Length = "0x4C")]
		public override string ToString()
		{
			return null;
		}
	}
}
