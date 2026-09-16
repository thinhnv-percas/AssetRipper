using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000024")]
	public struct TMP_Vertex
	{
		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x0")]
		public Vector3 position;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0xC")]
		public Vector2 uv;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x14")]
		public Vector2 uv2;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x1C")]
		public Vector2 uv4;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x24")]
		public Color32 color;

		[Token(Token = "0x400011B")]
		private static readonly TMP_Vertex k_Zero;

		[Token(Token = "0x17000024")]
		public static TMP_Vertex zero
		{
			[Token(Token = "0x6000125")]
			[Address(RVA = "0x15D0028", Offset = "0x15D0028", Length = "0x68")]
			get
			{
				return default(TMP_Vertex);
			}
		}
	}
}
