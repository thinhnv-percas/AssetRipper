using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200001E")]
	public struct Mesh_Extents
	{
		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x0")]
		public Vector2 min;

		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x8")]
		public Vector2 max;

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x15CFD30", Offset = "0x15CFD30", Length = "0xC")]
		public Mesh_Extents(Vector2 min, Vector2 max)
		{
			this.min = default(Vector2);
			this.max = default(Vector2);
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x15CFD3C", Offset = "0x15CFD3C", Length = "0x1A0")]
		public override string ToString()
		{
			return null;
		}
	}
}
