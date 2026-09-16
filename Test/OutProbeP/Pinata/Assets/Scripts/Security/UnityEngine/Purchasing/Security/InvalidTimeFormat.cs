using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000A")]
	public class InvalidTimeFormat : IAPSecurityException
	{
		[Token(Token = "0x600003C")]
		[Address(RVA = "0x15D4F48", Offset = "0x15D4F48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public InvalidTimeFormat()
		{
		}
	}
}
