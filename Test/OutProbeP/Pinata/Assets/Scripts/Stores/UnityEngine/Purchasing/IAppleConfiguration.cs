using System;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000044")]
	public interface IAppleConfiguration : IStoreConfiguration
	{
		[Token(Token = "0x6000101")]
		void SetApplePromotionalPurchaseInterceptorCallback(Action<Product> callback);
	}
}
