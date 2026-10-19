using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x200006C")]
	public class LevelExportData
	{
		[JsonProperty("version")]
		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x10")]
		public string Version;

		[JsonProperty("exportTime")]
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x18")]
		public string ExportTime;

		[JsonProperty("entities")]
		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x20")]
		public List<EntityData> Entities;

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x3C6EEF8", Offset = "0x3C6EEF8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.EntityData>::.ctor(v65);\n\tthis.Entities = v65;\n\treturn;\nL_0024:\n\tSystem.Object::.ctor(this);\n\tthis.Version = \"1.0\";\n\tv65 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.Serialization.EntityData>();\n")]
		public LevelExportData()
		{
			Version = "1.0";
			List<EntityData> entities = new List<EntityData>();
			Entities = entities;
		}
	}
}
