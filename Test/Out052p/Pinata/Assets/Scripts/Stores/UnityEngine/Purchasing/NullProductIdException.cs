using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200007D")]
	public class NullProductIdException : ReceiptParserException
	{
		[Token(Token = "0x6000217")]
		[Address(RVA = "0xC6B0D8", Offset = "0xC6B0D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.ReceiptParserException::.ctor(this);\n\treturn;\n")]
		public NullProductIdException()
		{
		}
	}
}
