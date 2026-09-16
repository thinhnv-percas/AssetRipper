using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000D")]
	public class InvalidRSAData : IAPSecurityException
	{
		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15D4F44", Offset = "0x15D4F44", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidRSAData()
		{
		}
	}
}
