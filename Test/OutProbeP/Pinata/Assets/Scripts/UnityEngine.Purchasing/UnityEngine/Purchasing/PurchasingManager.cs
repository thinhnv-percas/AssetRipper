using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000017")]
	internal class PurchasingManager : IStoreCallback, IStoreController
	{
		[Serializable]
		[Token(Token = "0x2000018")]
		private class UnifiedReceipt
		{
			[Token(Token = "0x400004F")]
			[FieldOffset(Offset = "0x10")]
			public string Store;

			[Token(Token = "0x4000050")]
			[FieldOffset(Offset = "0x18")]
			public string TransactionID;

			[Token(Token = "0x4000051")]
			[FieldOffset(Offset = "0x20")]
			public string Payload;

			[Token(Token = "0x6000084")]
			[Address(RVA = "0x1610B18", Offset = "0x1610B18", Length = "0x8")]
			public UnifiedReceipt()
			{
			}
		}

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x10")]
		private IStore m_Store;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x18")]
		private IInternalStoreListener m_Listener;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x20")]
		private ILogger m_Logger;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x28")]
		private TransactionLog m_TransactionLog;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x30")]
		private string m_StoreName;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x38")]
		private Action m_AdditionalProductsCallback;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x40")]
		private Action<InitializationFailureReason> m_AdditionalProductsFailCallback;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x58")]
		private bool initialized;

		[Token(Token = "0x17000021")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7268B4", Offset = "0x7268B4")]
		[field: Token(Token = "0x400004B")]
		[field: FieldOffset(Offset = "0x48")]
		public bool useTransactionLog
		{
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x160F264", Offset = "0x160F264", Length = "0x8")]
			get;
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x160F26C", Offset = "0x160F26C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000022")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7268F0", Offset = "0x7268F0")]
		[field: Token(Token = "0x400004C")]
		[field: FieldOffset(Offset = "0x50")]
		public ProductCollection products
		{
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x160FA6C", Offset = "0x160FA6C", Length = "0x8")]
			get;
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x160FA74", Offset = "0x160FA74", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x160F20C", Offset = "0x160F20C", Length = "0x58")]
		internal PurchasingManager(TransactionLog tDb, ILogger logger, IStore store, string storeName)
		{
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x160F278", Offset = "0x160F278", Length = "0x68")]
		public void InitiatePurchase(Product product)
		{
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x160F57C", Offset = "0x160F57C", Length = "0x68")]
		public void InitiatePurchase(string productId)
		{
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x160F2E0", Offset = "0x160F2E0", Length = "0x29C")]
		public void InitiatePurchase(Product product, string developerPayload)
		{
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x160F5E4", Offset = "0x160F5E4", Length = "0x110")]
		public void InitiatePurchase(string purchasableId, string developerPayload)
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x160F6F4", Offset = "0x160F6F4", Length = "0x1E8")]
		public void ConfirmPendingPurchase(Product product)
		{
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x160FA7C", Offset = "0x160FA7C", Length = "0x120")]
		public void OnPurchaseSucceeded(string id, string receipt, string transactionId)
		{
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x160FE74", Offset = "0x160FE74", Length = "0x104")]
		public void OnSetupFailed(InitializationFailureReason reason)
		{
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x160FF78", Offset = "0x160FF78", Length = "0x220")]
		public void OnPurchaseFailed(PurchaseFailureDescription description)
		{
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x1610198", Offset = "0x1610198", Length = "0x364")]
		public void OnProductsRetrieved(List<ProductDescription> products)
		{
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x160FC28", Offset = "0x160FC28", Length = "0x24C")]
		private void ProcessPurchaseIfNew(Product product)
		{
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x16104FC", Offset = "0x16104FC", Length = "0x384")]
		private void CheckForInitialization()
		{
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x16108E0", Offset = "0x16108E0", Length = "0x238")]
		public void Initialize(IInternalStoreListener listener, HashSet<ProductDefinition> products)
		{
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x160FB9C", Offset = "0x160FB9C", Length = "0x8C")]
		private string FormatUnifiedReceipt(string platformReceipt, string transactionId)
		{
			return null;
		}
	}
}
