using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200007E")]
	public class NullReceiptException : ReceiptParserException
	{
		[Token(Token = "0x6000218")]
		[Address(RVA = "0xC6B0DC", Offset = "0xC6B0DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.ReceiptParserException::.ctor(this);\n\treturn;\n")]
		public NullReceiptException()
		{
		}
	}
}
