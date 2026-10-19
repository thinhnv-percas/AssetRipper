using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003B7")]
	public sealed class TunnelInfo
	{
		[Token(Token = "0x4000BAE")]
		[FieldOffset(Offset = "0x10")]
		public GridCoord Cell;

		[Token(Token = "0x4000BAF")]
		[FieldOffset(Offset = "0x1C")]
		public GridCoord Target;

		[Token(Token = "0x4000BB0")]
		[FieldOffset(Offset = "0x28")]
		public int QueueLength;

		[Token(Token = "0x6000F7A")]
		[Address(RVA = "0x3C9DDF8", Offset = "0x3C9DDF8", Length = "0x8")]
		public TunnelInfo()
		{
		}
	}
}
