using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200001A")]
	public class GenericValidationException : IAPSecurityException
	{
		[Token(Token = "0x6000079")]
		[Address(RVA = "0x15D43C0", Offset = "0x15D43C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(this, message);\n\treturn;\n")]
		public GenericValidationException(string message)
			: base(message)
		{
		}
	}
}
