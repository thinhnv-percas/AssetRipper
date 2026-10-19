using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x200006B")]
	public class ComponentData
	{
		[JsonProperty("type")]
		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x10")]
		public string TypeName;

		[JsonProperty("data")]
		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x18")]
		public object Data;

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x3C6EE44", Offset = "0x3C6EE44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ComponentData()
		{
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x3C6EE4C", Offset = "0x3C6EE4C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv59 = System.Object::GetType(component);\n\tgoto L_0028;\n\treturn;\nL_0017:\n\tSystem.Object::.ctor(this);\nL_0028:\n\tv62 = _game.BaseLayerSystems.EntitySystem.Serialization.ComponentTypeRegistry::GetTypeName(v59);\n\tthis.TypeName = v62;\n\tthis.Data = component;\n")]
		public ComponentData(object component)
		{
			TypeName = ComponentTypeRegistry.GetTypeName(component.GetType());
			Data = component;
		}
	}
}
