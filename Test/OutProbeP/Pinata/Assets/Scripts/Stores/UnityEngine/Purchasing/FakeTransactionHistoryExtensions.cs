using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000080")]
	internal class FakeTransactionHistoryExtensions : ITransactionHistoryExtensions, IStoreExtension
	{
		[Token(Token = "0x600021A")]
		[Address(RVA = "0xC6118C", Offset = "0xC6118C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseFailureDescription GetLastPurchaseFailureDescription()
		{
			return null;
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0xC61194", Offset = "0xC61194", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0x21;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StoreSpecificPurchaseErrorCode GetLastStoreSpecificPurchaseErrorCode()
		{
			return StoreSpecificPurchaseErrorCode.Unknown;
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xC6119C", Offset = "0xC6119C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeTransactionHistoryExtensions()
		{
		}
	}
}
