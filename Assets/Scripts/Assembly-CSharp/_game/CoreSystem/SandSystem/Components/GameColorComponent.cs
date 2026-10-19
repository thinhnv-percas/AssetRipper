using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000092")]
	public class GameColorComponent : ICellComponent
	{
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x10")]
		public GameColor gameColor;

		[Token(Token = "0x6000288")]
		[Address(RVA = "0x3C79CEC", Offset = "0x3C79CEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameColorComponent()
		{
		}
	}
}
