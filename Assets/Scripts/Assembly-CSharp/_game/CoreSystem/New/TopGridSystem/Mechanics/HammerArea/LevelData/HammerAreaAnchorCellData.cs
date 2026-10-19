using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.LevelData
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x200020B")]
	public class HammerAreaAnchorCellData : ICellComponent
	{
		[Token(Token = "0x4000675")]
		[FieldOffset(Offset = "0x10")]
		public int sizeX;

		[Token(Token = "0x4000676")]
		[FieldOffset(Offset = "0x14")]
		public int sizeY;

		[Token(Token = "0x4000677")]
		[FieldOffset(Offset = "0x18")]
		public int groupId;

		[Token(Token = "0x4000678")]
		[FieldOffset(Offset = "0x1C")]
		public int counter;

		[Token(Token = "0x6000939")]
		[Address(RVA = "0x3E9046C", Offset = "0x3E9046C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerAreaAnchorCellData()
		{
		}
	}
}
