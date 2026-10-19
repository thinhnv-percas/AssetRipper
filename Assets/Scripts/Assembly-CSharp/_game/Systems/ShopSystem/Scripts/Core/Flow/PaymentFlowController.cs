using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using _game.CoreGameKit.Ui.Animations;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.ShopSystem.Scripts.Core.Flow
{
	[Token(Token = "0x2000738")]
	public class PaymentFlowController
	{
		[Inject(false)]
		[Token(Token = "0x4001823")]
		[FieldOffset(Offset = "0x10")]
		private PaymentExecutor _paymentExecutor;

		[Inject(false)]
		[Token(Token = "0x4001824")]
		[FieldOffset(Offset = "0x18")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x4001825")]
		[FieldOffset(Offset = "0x20")]
		private CurrencyAnimationController _currencyAnimationController;

		[Inject(false)]
		[Token(Token = "0x4001826")]
		[FieldOffset(Offset = "0x28")]
		private IResourceService _resourceService;

		[Token(Token = "0x6001E64")]
		[Address(RVA = "0x3D84818", Offset = "0x3D84818", Length = "0x8C")]
		public void Pay(Instancer instancer, ShopItemData itemData, CostData costData, Action onSuccess = null, Action onFailed = null, Action onComplete = null, Action onDirty = null)
		{
			onDirty?.Invoke();
			Instancer instancer2 = default(Instancer);
			ShopItemData itemData2 = default(ShopItemData);
			CostData costData2 = default(CostData);
			Action onSuccess2 = default(Action);
			Action onFailed2 = default(Action);
			Action onComplete2 = default(Action);
			_paymentExecutor.Pay(instancer2, itemData2, costData2, onSuccess2, onFailed2, onComplete2);
		}

		[Token(Token = "0x6001E65")]
		[Address(RVA = "0x3D848A4", Offset = "0x3D848A4", Length = "0xE0")]
		public void PayAndDistribute(Instancer instancer, ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_paymentExecutor, itemData, costData, _currencyAnimationController, _resourceService);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenPlayCurrencyAnimations();
			paymentFlowBuilder3._onFailed = onFailed;
			paymentFlowBuilder.Execute(instancer, onComplete);
		}

		[Token(Token = "0x6001E66")]
		[Address(RVA = "0x3D84A10", Offset = "0x3D84A10", Length = "0xE4")]
		public void PayAndShowRewardUi(Instancer instancer, ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true, Action onRewardGiven = null)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_paymentExecutor, itemData, costData, _currencyAnimationController, _resourceService);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenShowPackageRewardsUi(_uiManager, onRewardGiven);
			paymentFlowBuilder3._onFailed = onFailed;
			paymentFlowBuilder.Execute(instancer, onComplete);
		}

		[Token(Token = "0x6001E67")]
		[Address(RVA = "0x3D84AF4", Offset = "0x3D84AF4", Length = "0xC8")]
		public void PayAndGoHome(Instancer instancer, ShopItemData itemData, CostData costData, Action onFailed = null)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_paymentExecutor, itemData, costData, _currencyAnimationController, _resourceService);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenGoHome();
			paymentFlowBuilder2._onFailed = onFailed;
			paymentFlowBuilder.Execute(instancer);
		}

		[Token(Token = "0x6001E68")]
		[Address(RVA = "0x3D84BBC", Offset = "0x3D84BBC", Length = "0x18C")]
		public void PayAndDistributeOrShowHoverShop(Instancer instancer, ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_paymentExecutor, itemData, costData, _currencyAnimationController, _resourceService);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenPlayCurrencyAnimations();
			Action onFailed2 = delegate
			{
				PaymentFlowController paymentFlowController = this;
				HoveringShopUiController hoveringShopUiController = paymentFlowController._uiManager.Show<HoveringShopUiController>();
				if (onFailed != null)
				{
					onFailed();
				}
			};
			paymentFlowBuilder._onFailed = onFailed2;
			paymentFlowBuilder.Execute(instancer, onComplete);
		}

		[Token(Token = "0x6001E69")]
		[Address(RVA = "0x3D84984", Offset = "0x3D84984", Length = "0x8C")]
		public PaymentFlowBuilder CreateFlow(ShopItemData itemData, CostData costData)
		{
			return new PaymentFlowBuilder(_paymentExecutor, itemData, costData, _currencyAnimationController, _resourceService);
		}

		[Token(Token = "0x6001E6A")]
		[Address(RVA = "0x3D84D50", Offset = "0x3D84D50", Length = "0x1C")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			return _paymentExecutor.IsAffordable(instancer, costData);
		}

		[Token(Token = "0x6001E6B")]
		[Address(RVA = "0x3D84D6C", Offset = "0x3D84D6C", Length = "0x8")]
		public PaymentFlowController()
		{
		}
	}
}
