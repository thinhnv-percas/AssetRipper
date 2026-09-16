using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000002")]
	internal class AnalyticsReporter
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		private IUnityAnalytics m_Analytics;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x160D754", Offset = "0x160D754", Length = "0x2C")]
		public AnalyticsReporter(IUnityAnalytics analytics)
		{
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x160D780", Offset = "0x160D780", Length = "0x11C")]
		public void OnPurchaseSucceeded(Product product)
		{
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x160D89C", Offset = "0x160D89C", Length = "0x1E0")]
		public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
		{
		}
	}
}
