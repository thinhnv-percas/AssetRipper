using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Token(Token = "0x2000035")]
	public struct MeshData
	{
		[Token(Token = "0x400030A")]
		[FieldOffset(Offset = "0x0")]
		public Renderer renderer;

		[Token(Token = "0x400030B")]
		[FieldOffset(Offset = "0x8")]
		public int subMeshCount;
	}
}
