using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000018")]
	public class MissingStoreSecretException : IAPSecurityException
	{
		[Token(Token = "0x6000077")]
		[Address(RVA = "0x15D4048", Offset = "0x15D4048", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this, message);\n\treturn;\n")]
		public MissingStoreSecretException(string message)
			: base(message)
		{
		}
	}
}
