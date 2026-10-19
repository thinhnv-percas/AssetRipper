using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x2000064")]
	public class CompactEntityData
	{
		[JsonProperty("i")]
		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x10")]
		public string Id;

		[JsonProperty("c")]
		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x18")]
		public Dictionary<string, object> Components;

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x3C6D7F4", Offset = "0x3C6D7F4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v48);\n\tthis.Components = v48;\n")]
		public CompactEntityData()
		{
			Dictionary<string, object> components = new Dictionary<string, object>();
			Components = components;
		}
	}
}
