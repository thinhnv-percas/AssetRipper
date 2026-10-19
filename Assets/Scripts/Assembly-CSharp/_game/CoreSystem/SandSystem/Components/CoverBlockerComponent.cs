using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000091")]
	public class CoverBlockerComponent : ICellComponent
	{
		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x10")]
		public int groupId;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x14")]
		public int counter;

		[Token(Token = "0x6000287")]
		[Address(RVA = "0x3C79CE4", Offset = "0x3C79CE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public CoverBlockerComponent()
		{
		}
	}
}
