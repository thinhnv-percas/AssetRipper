using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000015")]
	public class StoreNotSupportedException : IAPSecurityException
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15D43BC", Offset = "0x15D43BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this, message);\n\treturn;\n")]
		public StoreNotSupportedException(string message)
			: base(message)
		{
		}
	}
}
