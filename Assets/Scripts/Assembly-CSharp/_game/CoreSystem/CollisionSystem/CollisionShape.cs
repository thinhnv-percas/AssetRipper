using Cpp2ILInjected;

namespace _game.CoreSystem.CollisionSystem
{
	[Token(Token = "0x2000515")]
	public struct CollisionShape
	{
		[Token(Token = "0x4001130")]
		[FieldOffset(Offset = "0x0")]
		public CollisionShapeType type;

		[Token(Token = "0x4001131")]
		[FieldOffset(Offset = "0x4")]
		public int vertexStart;

		[Token(Token = "0x4001132")]
		[FieldOffset(Offset = "0x8")]
		public int vertexCount;

		[Token(Token = "0x4001133")]
		[FieldOffset(Offset = "0xC")]
		public int sourceIndex;
	}
}
