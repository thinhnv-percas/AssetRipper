using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000019")]
	public class InvalidPublicKeyException : IAPSecurityException
	{
		[Token(Token = "0x6000078")]
		[Address(RVA = "0x15D39B4", Offset = "0x15D39B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this, message);\n\treturn;\n")]
		public InvalidPublicKeyException(string message)
			: base(message)
		{
		}
	}
}
