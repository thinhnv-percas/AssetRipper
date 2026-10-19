using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x2000093")]
	public class HiddenColorCubeComponent : ICellComponent
	{
		[Token(Token = "0x6000289")]
		[Address(RVA = "0x3C79CF4", Offset = "0x3C79CF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HiddenColorCubeComponent()
		{
		}
	}
}
