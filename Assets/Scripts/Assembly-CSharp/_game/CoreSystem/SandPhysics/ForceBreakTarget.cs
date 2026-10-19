using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A1")]
	public struct ForceBreakTarget : IBufferElementData
	{
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x0")]
		public int entityId;

		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x4")]
		public int count;
	}
}
