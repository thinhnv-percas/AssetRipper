using Cpp2ILInjected;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004A9")]
	internal struct AbsorptionZone
	{
		[Token(Token = "0x4000F9F")]
		[FieldOffset(Offset = "0x0")]
		public float xMin;

		[Token(Token = "0x4000FA0")]
		[FieldOffset(Offset = "0x4")]
		public float xMax;

		[Token(Token = "0x4000FA1")]
		[FieldOffset(Offset = "0x8")]
		public float yMin;

		[Token(Token = "0x4000FA2")]
		[FieldOffset(Offset = "0xC")]
		public float yMax;

		[Token(Token = "0x4000FA3")]
		[FieldOffset(Offset = "0x10")]
		public float moldCenterX;

		[Token(Token = "0x4000FA4")]
		[FieldOffset(Offset = "0x14")]
		public float moldCenterY;

		[Token(Token = "0x4000FA5")]
		[FieldOffset(Offset = "0x18")]
		public float pourPointX;

		[Token(Token = "0x4000FA6")]
		[FieldOffset(Offset = "0x1C")]
		public float pourPointY;

		[Token(Token = "0x4000FA7")]
		[FieldOffset(Offset = "0x20")]
		public int gameColor;

		[Token(Token = "0x4000FA8")]
		[FieldOffset(Offset = "0x24")]
		public bool isEmpty;

		[Token(Token = "0x4000FA9")]
		[FieldOffset(Offset = "0x25")]
		public bool isComplete;

		[Token(Token = "0x4000FAA")]
		[FieldOffset(Offset = "0x28")]
		public int remainingNeed;

		[Token(Token = "0x4000FAB")]
		[FieldOffset(Offset = "0x2C")]
		public int targetRow;

		[Token(Token = "0x4000FAC")]
		[FieldOffset(Offset = "0x30")]
		public int activeEntityId;
	}
}
