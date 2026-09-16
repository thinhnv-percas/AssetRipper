using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200007F")]
	public class StoreSubscriptionInfoNotSupportedException : ReceiptParserException
	{
		[Token(Token = "0x6000219")]
		[Address(RVA = "0x15AE5D4", Offset = "0x15AE5D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.ReceiptParserException::.ctor(this, message);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StoreSubscriptionInfoNotSupportedException(string message)
			: base(message)
		{
		}
	}
}
