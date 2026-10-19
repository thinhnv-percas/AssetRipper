using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000095")]
	public class LinkedSandCubeComponent : ICellComponent
	{
		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x10")]
		public int linkedCol;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x14")]
		public int linkedRow;

		[Token(Token = "0x600028B")]
		[Address(RVA = "0x3C788A0", Offset = "0x3C788A0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.linkedCol = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LinkedSandCubeComponent()
		{
			linkedCol = -1;
			linkedRow = -1;
		}
	}
}
