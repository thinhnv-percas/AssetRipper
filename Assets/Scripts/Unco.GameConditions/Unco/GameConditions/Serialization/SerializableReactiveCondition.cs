using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Serialization
{
	[Serializable]
	[Token(Token = "0x2000005")]
	public class SerializableReactiveCondition
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		public string type;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		public object[] data;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		public SerializableReactiveCondition nestedCondition;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x28")]
		public SerializableReactiveCondition leftCondition;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x30")]
		public SerializableReactiveCondition rightCondition;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x38")]
		public SerializableReactiveCondition[] conditions;

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81AC52C", Offset = "0x81AC52C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SerializableReactiveCondition()
		{
		}
	}
}
