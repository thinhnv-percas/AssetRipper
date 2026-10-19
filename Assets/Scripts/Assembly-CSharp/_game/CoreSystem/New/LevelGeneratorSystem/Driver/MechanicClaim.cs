using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000381")]
	public sealed class MechanicClaim
	{
		[Token(Token = "0x4000AC0")]
		[FieldOffset(Offset = "0x10")]
		public string Kind = "";

		[Token(Token = "0x4000AC1")]
		[FieldOffset(Offset = "0x18")]
		public int At = -1;

		[Token(Token = "0x4000AC2")]
		[FieldOffset(Offset = "0x20")]
		public string RemovalEffect = "";

		[Token(Token = "0x4000AC3")]
		[FieldOffset(Offset = "0x28")]
		public int ArrivalTapEstimate = -1;

		[Token(Token = "0x4000AC4")]
		[FieldOffset(Offset = "0x30")]
		public string Intent = "";

		[Token(Token = "0x6000EAE")]
		[Address(RVA = "0x3F16908", Offset = "0x3F16908", Length = "0x90")]
		public MechanicClaim()
		{
		}
	}
}
