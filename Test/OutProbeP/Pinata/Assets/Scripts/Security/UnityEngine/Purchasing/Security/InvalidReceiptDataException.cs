using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000017")]
	public class InvalidReceiptDataException : IAPSecurityException
	{
		[Token(Token = "0x6000076")]
		[Address(RVA = "0x15D4044", Offset = "0x15D4044", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidReceiptDataException()
		{
		}
	}
}
