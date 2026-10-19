using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.LevelData
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000226")]
	public class GarageAnchorCellData : ICellComponent
	{
		[Token(Token = "0x40006B8")]
		[FieldOffset(Offset = "0x10")]
		public int sizeX;

		[Token(Token = "0x40006B9")]
		[FieldOffset(Offset = "0x14")]
		public int sizeY;

		[Token(Token = "0x40006BA")]
		[FieldOffset(Offset = "0x18")]
		public int groupId;

		[Token(Token = "0x40006BB")]
		[FieldOffset(Offset = "0x1C")]
		public int counter;

		[Token(Token = "0x6000991")]
		[Address(RVA = "0x3E97304", Offset = "0x3E97304", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GarageAnchorCellData()
		{
		}
	}
}
