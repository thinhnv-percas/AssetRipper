using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003B2")]
	public class LevelFeatures
	{
		[Token(Token = "0x4000B7A")]
		[FieldOffset(Offset = "0x10")]
		public string levelId;

		[Token(Token = "0x4000B7B")]
		[FieldOffset(Offset = "0x18")]
		public int gridColumns;

		[Token(Token = "0x4000B7C")]
		[FieldOffset(Offset = "0x1C")]
		public int gridRows;

		[Token(Token = "0x4000B7D")]
		[FieldOffset(Offset = "0x20")]
		public int sandCubeCount;

		[Token(Token = "0x4000B7E")]
		[FieldOffset(Offset = "0x24")]
		public int tunnelQueuedCubeCount;

		[Token(Token = "0x4000B7F")]
		[FieldOffset(Offset = "0x28")]
		public int distinctColorCount;

		[Token(Token = "0x4000B80")]
		[FieldOffset(Offset = "0x2C")]
		public int entryPointCount;

		[Token(Token = "0x4000B81")]
		[FieldOffset(Offset = "0x30")]
		public int tunnelCount;

		[Token(Token = "0x4000B82")]
		[FieldOffset(Offset = "0x34")]
		public int linkedCount;

		[Token(Token = "0x4000B83")]
		[FieldOffset(Offset = "0x38")]
		public int hiddenCount;

		[Token(Token = "0x4000B84")]
		[FieldOffset(Offset = "0x3C")]
		public int pinCount;

		[Token(Token = "0x4000B85")]
		[FieldOffset(Offset = "0x40")]
		public int garageCount;

		[Token(Token = "0x4000B86")]
		[FieldOffset(Offset = "0x44")]
		public int hammerAreaCount;

		[Token(Token = "0x4000B87")]
		[FieldOffset(Offset = "0x48")]
		public int lockCount;

		[Token(Token = "0x4000B88")]
		[FieldOffset(Offset = "0x4C")]
		public int keyCount;

		[Token(Token = "0x4000B89")]
		[FieldOffset(Offset = "0x50")]
		public int snakeCount;

		[Token(Token = "0x4000B8A")]
		[FieldOffset(Offset = "0x54")]
		public int wallCount;

		[Token(Token = "0x6000F72")]
		[Address(RVA = "0x3C9D9F4", Offset = "0x3C9D9F4", Length = "0x8")]
		public LevelFeatures()
		{
		}
	}
}
