using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.MoldSystem.Mechanics.Hammer.LevelData
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x20002BC")]
	public class HammerCellData : ICellComponent
	{
		[Token(Token = "0x6000C3B")]
		[Address(RVA = "0x3ED36EC", Offset = "0x3ED36EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HammerCellData()
		{
		}
	}
}
