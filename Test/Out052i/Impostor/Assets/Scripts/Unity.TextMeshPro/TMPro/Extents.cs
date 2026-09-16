using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200001D")]
	public struct Extents
	{
		[Token(Token = "0x40000C2")]
		internal static Extents zero;

		[Token(Token = "0x40000C3")]
		internal static Extents uninitialized;

		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x0")]
		public Vector2 min;

		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x8")]
		public Vector2 max;

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x15CFAF0", Offset = "0x15CFAF0", Length = "0xC")]
		public Extents(Vector2 min, Vector2 max)
		{
			this.min = default(Vector2);
			this.max = default(Vector2);
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x15CFAFC", Offset = "0x15CFAFC", Length = "0x1A0")]
		public override string ToString()
		{
			return null;
		}
	}
}
