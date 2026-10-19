using System;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000755")]
	internal class IAPPaymentExecutor : IPaymentInnerExecutor
	{
		[Token(Token = "0x400188C")]
		[FieldOffset(Offset = "0x10")]
		private PaymentContext _activeContext;

		[Token(Token = "0x400188D")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x400188E")]
		[FieldOffset(Offset = "0x20")]
		private UiManager _uiManager;

		[Token(Token = "0x170002F0")]
		public CostData.CostType CostType
		{
			[Token(Token = "0x6001EE8")]
			[Address(RVA = "0x3D89D88", Offset = "0x3D89D88", Length = "0x8")]
			get
			{
				return CostData.CostType.IAP;
			}
		}

		[Token(Token = "0x6001EE9")]
		[Address(RVA = "0x3D89D90", Offset = "0x3D89D90", Length = "0x290")]
		public void Execute(Instancer instancer, PaymentContext context)
		{
			if (_activeContext != null)
			{
				if (context._onFailed != null)
				{
					context._onFailed();
				}
				if (context._onComplete != null)
				{
					context._onComplete();
				}
				return;
			}
			_activeContext = context;
			CostData costData = context.CostData;
			bool flag = instancer.TryResolve<EventBus>(out _eventBus);
			bool flag2 = instancer.TryResolve<UiManager>(out _uiManager);
			bool flag3 = instancer.TryResolve<IAPStoreService>(out var result);
			Action<UventPurchaseStarted> observer = OnPurchaseStarted;
			_eventBus.ListenEvent(observer);
			Action<UventPurchaseFailed> observer2 = OnPurchaseFailed;
			_eventBus.ListenEvent(observer2);
			Action<UventPurchaseSucceed> observer3 = OnPurchaseSucceed;
			_eventBus.ListenEvent(observer3);
			result.Purchase(costData.bundleId, costData.sourceType);
		}

		[Token(Token = "0x6001EEA")]
		[Address(RVA = "0x3D8A020", Offset = "0x3D8A020", Length = "0x8")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			return true;
		}

		[Token(Token = "0x6001EEB")]
		[Address(RVA = "0x3D8A028", Offset = "0x3D8A028", Length = "0x54")]
		private void OnPurchaseStarted(UventPurchaseStarted evt)
		{
			WaitingUiController waitingUiController = _uiManager.Show<WaitingUiController>();
		}

		[Token(Token = "0x6001EEC")]
		[Address(RVA = "0x3D8A07C", Offset = "0x3D8A07C", Length = "0x130")]
		private void OnPurchaseFailed(UventPurchaseFailed evt)
		{
			CleanSubscriptions();
			_uiManager.ForceHideIfExist<WaitingUiController>();
			PaymentContext failContext = _activeContext;
			_activeContext = null;
			IapFailUiController iapFailUiController = _uiManager.Show<IapFailUiController>();
			Action onClose = delegate
			{
				PaymentContext paymentContext = failContext;
				if (failContext != null)
				{
					if (paymentContext._onFailed != null)
					{
						paymentContext._onFailed();
					}
					if (paymentContext._onComplete != null)
					{
						paymentContext._onComplete();
					}
				}
			};
			iapFailUiController._onClose = onClose;
		}

		[Token(Token = "0x6001EED")]
		[Address(RVA = "0x3D8A344", Offset = "0x3D8A344", Length = "0x78")]
		private void OnPurchaseSucceed(UventPurchaseSucceed evt)
		{
			CleanSubscriptions();
			_uiManager.ForceHideIfExist<WaitingUiController>();
			if (_activeContext != null)
			{
				_activeContext.CompletePayment();
			}
			_activeContext = null;
		}

		[Token(Token = "0x6001EEE")]
		[Address(RVA = "0x3D8A1B4", Offset = "0x3D8A1B4", Length = "0x190")]
		private void CleanSubscriptions()
		{
			Action<UventPurchaseStarted> observer = OnPurchaseStarted;
			_eventBus.RemoveListener(observer);
			Action<UventPurchaseFailed> observer2 = OnPurchaseFailed;
			_eventBus.RemoveListener(observer2);
			Action<UventPurchaseSucceed> observer3 = OnPurchaseSucceed;
			_eventBus.RemoveListener(observer3);
		}

		[Token(Token = "0x6001EEF")]
		[Address(RVA = "0x3D8A3BC", Offset = "0x3D8A3BC", Length = "0x8")]
		public IAPPaymentExecutor()
		{
		}
	}
}
