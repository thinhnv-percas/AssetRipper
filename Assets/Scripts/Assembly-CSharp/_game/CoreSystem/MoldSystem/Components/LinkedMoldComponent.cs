using System;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.MoldSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x20004B5")]
	public class LinkedMoldComponent : ICellComponent
	{
		[Token(Token = "0x4000FD3")]
		[FieldOffset(Offset = "0x10")]
		public int linkedCol;

		[Token(Token = "0x4000FD4")]
		[FieldOffset(Offset = "0x14")]
		public int linkedRow;

		[Token(Token = "0x60013D8")]
		[Address(RVA = "0x3CEFB20", Offset = "0x3CEFB20", Length = "0x8")]
		public LinkedMoldComponent()
		{
		}
	}
}
