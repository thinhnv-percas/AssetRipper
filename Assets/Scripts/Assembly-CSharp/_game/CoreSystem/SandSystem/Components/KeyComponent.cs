using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000094")]
	public class KeyComponent : ICellComponent
	{
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x10")]
		public GameColor lockColor;

		[Token(Token = "0x600028A")]
		[Address(RVA = "0x3C79CFC", Offset = "0x3C79CFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public KeyComponent()
		{
		}
	}
}
