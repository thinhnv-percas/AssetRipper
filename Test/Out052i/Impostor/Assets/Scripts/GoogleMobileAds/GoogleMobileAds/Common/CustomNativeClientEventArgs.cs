using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000022")]
	public class CustomNativeClientEventArgs : EventArgs
	{
		[Token(Token = "0x17000008")]
		[field: Token(Token = "0x400008F")]
		[field: FieldOffset(Offset = "0x10")]
		internal ICustomNativeTemplateClient nativeAdClient
		{
			[Token(Token = "0x6000168")]
			[Address(RVA = "0x134F8C8", Offset = "0x134F8C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<nativeAdClient>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000169")]
			[Address(RVA = "0x134F8D0", Offset = "0x134F8D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<nativeAdClient>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000009")]
		[field: Token(Token = "0x4000090")]
		[field: FieldOffset(Offset = "0x18")]
		internal string assetName
		{
			[Token(Token = "0x600016A")]
			[Address(RVA = "0x134F8D8", Offset = "0x134F8D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<assetName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600016B")]
			[Address(RVA = "0x134F8E0", Offset = "0x134F8E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<assetName>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x1344F08", Offset = "0x1344F08", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = System.EventArgs;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3684E]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CustomNativeClientEventArgs()
		{
		}
	}
}
