using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.FrameSystem
{
	[Serializable]
	[Token(Token = "0x20004DE")]
	public struct FrameData
	{
		[Token(Token = "0x4001045")]
		[FieldOffset(Offset = "0x0")]
		public WallSegment[] walls;

		[Token(Token = "0x4001046")]
		[FieldOffset(Offset = "0x8")]
		public int[] regionTypes;

		[Token(Token = "0x4001047")]
		[FieldOffset(Offset = "0x10")]
		public bool[] generateMesh;

		[Token(Token = "0x4001048")]
		[FieldOffset(Offset = "0x18")]
		public bool isFullSnapshot;
	}
}
