using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000069")]
	public struct Mesh_Extents
	{
		[Token(Token = "0x400043E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector2 min;

		[Token(Token = "0x400043F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public Vector2 max;

		[Token(Token = "0x6000540")]
		[Address(RVA = "0x8465D0", Offset = "0x8465D0", Length = "0xC")]
		public Mesh_Extents(Vector2 min, Vector2 max)
		{
			this.min = default(Vector2);
			this.max = default(Vector2);
		}

		[Token(Token = "0x6000541")]
		[Address(RVA = "0x8465DC", Offset = "0x8465DC", Length = "0x118")]
		public override string ToString()
		{
			return null;
		}
	}
}
