using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 40)]
	[Token(Token = "0x200000E")]
	public struct TMP_Vertex
	{
		[Token(Token = "0x4000054")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 position;

		[Token(Token = "0x4000055")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector2 uv;

		[Token(Token = "0x4000056")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public Vector2 uv2;

		[Token(Token = "0x4000057")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public Vector2 uv4;

		[Token(Token = "0x4000058")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public Color32 color;
	}
}
