using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000010")]
	public class FakeAmazonExtensions : IAmazonExtensions, IStoreExtension, IAmazonConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x1700000F")]
		public string amazonUserId
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0xC5EE24", Offset = "0xC5EE24", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE83C8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023327]) = v35;\nL_0018:\n\treturn \"fakeid\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "fakeid";
			}
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0xC5EE20", Offset = "0xC5EE20", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void WriteSandboxJSON(HashSet<ProductDefinition> products)
		{
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0xC5EE6C", Offset = "0xC5EE6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeAmazonExtensions()
		{
		}
	}
}
