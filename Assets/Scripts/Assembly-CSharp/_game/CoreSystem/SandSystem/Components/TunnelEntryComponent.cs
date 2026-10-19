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
	[Token(Token = "0x200009C")]
	public class TunnelEntryComponent : ICellComponent
	{
		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x10")]
		public TunnelDirection direction;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x18")]
		public List<TunnelSlotData> slots;

		[Token(Token = "0x6000292")]
		[Address(RVA = "0x3C79DD4", Offset = "0x3C79DD4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.TunnelSlotData>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.SandSystem.Components.TunnelSlotData>::.ctor(v48);\n\tthis.slots = v48;\n")]
		public TunnelEntryComponent()
		{
			List<TunnelSlotData> list = new List<TunnelSlotData>();
			slots = list;
		}
	}
}
