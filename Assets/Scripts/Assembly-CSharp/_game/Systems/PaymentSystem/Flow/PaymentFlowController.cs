using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.RewardSystem;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Flow
{
	[Token(Token = "0x200074B")]
	public class PaymentFlowController
	{
		[Token(Token = "0x4001865")]
		[FieldOffset(Offset = "0x10")]
		private readonly PaymentExecutor _paymentExecutor;

		[Token(Token = "0x4001866")]
		[FieldOffset(Offset = "0x18")]
		private readonly Instancer _instancer;

		[Token(Token = "0x6001EAF")]
		[Address(RVA = "0x3D86D60", Offset = "0x3D86D60", Length = "0x50")]
		public PaymentFlowController(PaymentExecutor paymentExecutor, Instancer instancer)
		{
			_paymentExecutor = paymentExecutor;
			_instancer = instancer;
		}

		[Token(Token = "0x6001EB0")]
		[Address(RVA = "0x3D883F8", Offset = "0x3D883F8", Length = "0x38")]
		public void Pay(ShopItemData itemData, CostData costData, Action onSuccess = null, Action onFailed = null, Action onComplete = null)
		{
			_paymentExecutor.Pay(_instancer, itemData, costData, onSuccess, onFailed, onComplete);
		}

		[Token(Token = "0x6001EB1")]
		[Address(RVA = "0x3D88430", Offset = "0x3D88430", Length = "0xC8")]
		public void PayAndDistribute(ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_instancer, _paymentExecutor, itemData, costData);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenPlayCurrencyAnimations();
			paymentFlowBuilder3._onFailed = onFailed;
			paymentFlowBuilder.Execute(onComplete);
		}

		[Token(Token = "0x6001EB2")]
		[Address(RVA = "0x3D82B44", Offset = "0x3D82B44", Length = "0xD0")]
		public void PayAndShowRewardUi(ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true, Action onRewardGiven = null)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_instancer, _paymentExecutor, itemData, costData);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenShowPackageRewardsUi(onRewardGiven);
			paymentFlowBuilder3._onFailed = onFailed;
			paymentFlowBuilder.Execute(onComplete);
		}

		[Token(Token = "0x6001EB3")]
		[Address(RVA = "0x3D8857C", Offset = "0x3D8857C", Length = "0xB0")]
		public void PayAndGoHome(ShopItemData itemData, CostData costData, Action onFailed = null)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_instancer, _paymentExecutor, itemData, costData);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenGoHome();
			paymentFlowBuilder2._onFailed = onFailed;
			paymentFlowBuilder.Execute();
		}

		[Token(Token = "0x6001EB4")]
		[Address(RVA = "0x3D72EB8", Offset = "0x3D72EB8", Length = "0x170")]
		public void PayAndDistributeOrShowHoverShop(ShopItemData itemData, CostData costData, Action onComplete = null, Action onFailed = null, bool animateCurrency = true)
		{
			PaymentFlowBuilder paymentFlowBuilder = new PaymentFlowBuilder(_instancer, _paymentExecutor, itemData, costData);
			PaymentFlowBuilder paymentFlowBuilder2 = paymentFlowBuilder.ThenDistributeRewards(animateCurrency);
			PaymentFlowBuilder paymentFlowBuilder3 = paymentFlowBuilder2.ThenPlayCurrencyAnimations();
			Action onFailed2 = delegate
			{
				PaymentFlowController paymentFlowController = this;
				if (paymentFlowController._instancer.TryResolve<UiManager>(out var result))
				{
					HoveringShopUiController hoveringShopUiController = result.Show<HoveringShopUiController>();
				}
				if (onFailed != null)
				{
					onFailed();
				}
			};
			paymentFlowBuilder._onFailed = onFailed2;
			paymentFlowBuilder.Execute(onComplete);
		}

		[Token(Token = "0x6001EB5")]
		[Address(RVA = "0x3D884F8", Offset = "0x3D884F8", Length = "0x84")]
		public PaymentFlowBuilder CreateFlow(ShopItemData itemData, CostData costData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentFlowController::CreateFlow");
			return default;
		}

		[Token(Token = "0x6001EB6")]
		[Address(RVA = "0x3D88634", Offset = "0x3D88634", Length = "0x28")]
		public bool IsAffordable(CostData costData)
		{
			return _paymentExecutor.IsAffordable(_instancer, costData);
		}
	}
}
