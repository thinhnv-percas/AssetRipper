using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000042")]
	internal class FakeAppleConfiguation : IAppleConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xC5EE74", Offset = "0xC5EE74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetApplePromotionalPurchaseInterceptorCallback(Action<Product> callback)
		{
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xC5EE78", Offset = "0xC5EE78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeAppleConfiguation()
		{
		}
	}
}
