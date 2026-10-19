using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x2000063")]
	public class CompactLevelData
	{
		[JsonProperty("v")]
		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x10")]
		public int Version = 2;

		[JsonProperty("e")]
		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x18")]
		public List<CompactEntityData> Entities;

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x3C6D760", Offset = "0x3C6D760", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tthis.Version = 2;\n\tv49 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.CompactEntityData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.CompactEntityData>::.ctor(v49);\n\tthis.Entities = v49;\n")]
		public CompactLevelData()
		{
			List<CompactEntityData> entities = new List<CompactEntityData>();
			Entities = entities;
		}
	}
}
