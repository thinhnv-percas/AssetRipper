using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.LevelData
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x200023E")]
	public class FrozenCubeCellComponent : ICellComponent
	{
		[Token(Token = "0x60009C9")]
		[Address(RVA = "0x3E9B480", Offset = "0x3E9B480", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public FrozenCubeCellComponent()
		{
		}
	}
}
