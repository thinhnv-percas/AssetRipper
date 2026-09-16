using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000B")]
	public class UnsupportedSignerInfoVersion : IAPSecurityException
	{
		[Token(Token = "0x600003D")]
		[Address(RVA = "0x15D5FC0", Offset = "0x15D5FC0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this);\n\treturn;\n")]
		public UnsupportedSignerInfoVersion()
		{
		}
	}
}
