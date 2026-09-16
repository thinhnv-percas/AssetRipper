using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200007C")]
	public class InvalidProductTypeException : ReceiptParserException
	{
		[Token(Token = "0x6000216")]
		[Address(RVA = "0xC61F94", Offset = "0xC61F94", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.ReceiptParserException::.ctor(this);\n\treturn;\n")]
		public InvalidProductTypeException()
		{
		}
	}
}
