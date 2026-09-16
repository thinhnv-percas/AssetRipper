using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000009")]
	public class InvalidPKCS7Data : IAPSecurityException
	{
		[Token(Token = "0x600003B")]
		[Address(RVA = "0x15D2B88", Offset = "0x15D2B88", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidPKCS7Data()
		{
		}
	}
}
