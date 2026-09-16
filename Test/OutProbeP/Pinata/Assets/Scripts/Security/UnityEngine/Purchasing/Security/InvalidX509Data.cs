using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000004")]
	public class InvalidX509Data : IAPSecurityException
	{
		[Token(Token = "0x6000026")]
		[Address(RVA = "0x15D48DC", Offset = "0x15D48DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidX509Data()
		{
		}
	}
}
