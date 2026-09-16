using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000008")]
	public class InvalidSignatureException : IAPSecurityException
	{
		[Token(Token = "0x600003A")]
		[Address(RVA = "0x15D3774", Offset = "0x15D3774", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidSignatureException()
		{
		}
	}
}
