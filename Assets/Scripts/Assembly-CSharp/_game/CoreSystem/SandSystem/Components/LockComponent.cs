using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000096")]
	public class LockComponent : ICellComponent
	{
		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x10")]
		public GameColor lockColor;

		[Token(Token = "0x600028C")]
		[Address(RVA = "0x3C79D04", Offset = "0x3C79D04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LockComponent()
		{
		}
	}
}
