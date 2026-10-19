using System;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreSystem.MoldSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x20004B4")]
	public class HiddenMoldComponent : ICellComponent
	{
		[Token(Token = "0x60013D7")]
		[Address(RVA = "0x3CEFB18", Offset = "0x3CEFB18", Length = "0x8")]
		public HiddenMoldComponent()
		{
		}
	}
}
