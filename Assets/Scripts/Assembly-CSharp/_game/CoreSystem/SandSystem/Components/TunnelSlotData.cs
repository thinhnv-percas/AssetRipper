using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.BaseLayerSystems.EntitySystem.Serialization;

namespace _game.CoreSystem.SandSystem.Components
{
	[Serializable]
	[JsonObject]
	[Token(Token = "0x200009D")]
	public class TunnelSlotData
	{
		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x10")]
		public List<DrawableEntity> entities;

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x3C79E60", Offset = "0x3C79E60", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity>::.ctor(v48);\n\tthis.entities = v48;\n")]
		public TunnelSlotData()
		{
			List<DrawableEntity> list = new List<DrawableEntity>();
			entities = list;
		}
	}
}
