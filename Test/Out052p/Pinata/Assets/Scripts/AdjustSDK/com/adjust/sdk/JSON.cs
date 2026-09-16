using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000008")]
	public static class JSON
	{
		[Token(Token = "0x600006F")]
		[Address(RVA = "0x156D0AC", Offset = "0x156D0AC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = com.adjust.sdk.JSONNode::Parse(aJSON);\n\treturn returnVal1;\n")]
		public static JSONNode Parse(string aJSON)
		{
			return JSONNode.Parse(aJSON);
		}
	}
}
