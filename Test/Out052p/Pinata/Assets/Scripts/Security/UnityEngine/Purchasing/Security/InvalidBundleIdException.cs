using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000016")]
	public class InvalidBundleIdException : IAPSecurityException
	{
		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15D43B8", Offset = "0x15D43B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidBundleIdException()
		{
		}
	}
}
