using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x200009B")]
	public class TunnelCubeComponent : ICellComponent
	{
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x10")]
		public List<GameColor> queue;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x18")]
		public TunnelDirection direction;

		[Token(Token = "0x6000291")]
		[Address(RVA = "0x3C79D48", Offset = "0x3C79D48", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.GameColor>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.GameColor>::.ctor(v48);\n\tthis.queue = v48;\n")]
		public TunnelCubeComponent()
		{
			List<GameColor> list = new List<GameColor>();
			queue = list;
		}
	}
}
