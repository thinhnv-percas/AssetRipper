using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000A9")]
	public struct MeshGeneratorBuffers
	{
		[Token(Token = "0x40003EE")]
		[FieldOffset(Offset = "0x0")]
		public int vertexCount;

		[Token(Token = "0x40003EF")]
		[FieldOffset(Offset = "0x8")]
		public Vector3[] vertexBuffer;

		[Token(Token = "0x40003F0")]
		[FieldOffset(Offset = "0x10")]
		public Vector2[] uvBuffer;

		[Token(Token = "0x40003F1")]
		[FieldOffset(Offset = "0x18")]
		public Color32[] colorBuffer;

		[Token(Token = "0x40003F2")]
		[FieldOffset(Offset = "0x20")]
		public MeshGenerator meshGenerator;
	}
}
