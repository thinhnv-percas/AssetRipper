using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Serializable]
	[Token(Token = "0x2000019")]
	public class ResourceStorageData
	{
		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x400004D")]
		[field: FieldOffset(Offset = "0x10")]
		public Dictionary<string, string> Amounts
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x81D3EC4", Offset = "0x81D3EC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Amounts;\n")]
			get;
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x81D3ECC", Offset = "0x81D3ECC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Amounts = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700000B")]
		[field: Token(Token = "0x400004E")]
		[field: FieldOffset(Offset = "0x18")]
		public Dictionary<string, int> InfiniteFlags
		{
			[Token(Token = "0x600005D")]
			[Address(RVA = "0x81D3ED4", Offset = "0x81D3ED4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.InfiniteFlags;\n")]
			get;
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x81D3EDC", Offset = "0x81D3EDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.InfiniteFlags = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x81D3EE4", Offset = "0x81D3EE4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::.ctor(v72);\n\tthis.InfiniteFlags = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v56);\n\tthis.Amounts = v56;\n")]
		public ResourceStorageData()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Amounts = dictionary;
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			InfiniteFlags = dictionary2;
		}
	}
}
