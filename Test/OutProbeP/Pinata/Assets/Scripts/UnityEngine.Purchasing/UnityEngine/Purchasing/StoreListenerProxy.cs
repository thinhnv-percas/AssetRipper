using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200001A")]
	internal class StoreListenerProxy : IInternalStoreListener
	{
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x10")]
		private AnalyticsReporter m_Analytics;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x18")]
		private IStoreListener m_ForwardTo;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x20")]
		private IExtensionProvider m_Extensions;

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x1610C20", Offset = "0x1610C20", Length = "0x40")]
		public StoreListenerProxy(IStoreListener forwardTo, AnalyticsReporter analytics, IExtensionProvider extensions)
		{
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1610C60", Offset = "0x1610C60", Length = "0xD0")]
		public void OnInitialized(IStoreController controller)
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x1610D30", Offset = "0x1610D30", Length = "0xC4")]
		public void OnInitializeFailed(InitializationFailureReason error)
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x1610DF4", Offset = "0x1610DF4", Length = "0xDC")]
		public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
		{
			return PurchaseProcessingResult.Complete;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x1610ED0", Offset = "0x1610ED0", Length = "0xE8")]
		public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
		{
		}
	}
}
