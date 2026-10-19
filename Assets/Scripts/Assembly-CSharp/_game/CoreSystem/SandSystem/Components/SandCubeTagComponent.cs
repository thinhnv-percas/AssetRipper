using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000098")]
	public class SandCubeTagComponent : ICellComponent
	{
		[Token(Token = "0x600028E")]
		[Address(RVA = "0x3C79D14", Offset = "0x3C79D14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandCubeTagComponent()
		{
		}
	}
}
