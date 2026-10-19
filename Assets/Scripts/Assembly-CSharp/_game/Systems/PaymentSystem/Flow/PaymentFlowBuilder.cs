using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.Extensions;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.RewardSystem.Distribution;
using Unco.RewardSystem.SimpleSequenceSystem;
using UnityEngine;
using _game.CoreGameKit.Ui.Animations;
using _game.CoreGameKit.UiControllers;
using _game.Systems.PaymentSystem.Core;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Flow
{
	[Token(Token = "0x2000744")]
	public class PaymentFlowBuilder
	{
		[Token(Token = "0x400184E")]
		[FieldOffset(Offset = "0x10")]
		private readonly Instancer _instancer;

		[Token(Token = "0x400184F")]
		[FieldOffset(Offset = "0x18")]
		private readonly PaymentExecutor _executor;

		[Token(Token = "0x4001850")]
		[FieldOffset(Offset = "0x20")]
		private readonly ShopItemData _itemData;

		[Token(Token = "0x4001851")]
		[FieldOffset(Offset = "0x28")]
		private readonly CostData _costData;

		[Token(Token = "0x4001852")]
		[FieldOffset(Offset = "0x30")]
		private readonly USequence _sequence;

		[Token(Token = "0x4001853")]
		[FieldOffset(Offset = "0x38")]
		internal Action _onFailed;

		[Token(Token = "0x6001E99")]
		[Address(RVA = "0x3D87200", Offset = "0x3D87200", Length = "0xD8")]
		internal PaymentFlowBuilder(Instancer instancer, PaymentExecutor executor, ShopItemData itemData, CostData costData)
		{
			_instancer = instancer;
			_executor = executor;
			_itemData = itemData;
			_costData = costData;
			_sequence = new USequence();
		}

		[Token(Token = "0x6001E9A")]
		[Address(RVA = "0x3D872D8", Offset = "0x3D872D8", Length = "0x134")]
		public PaymentFlowBuilder ThenDistributeRewards(bool animateCurrency = true)
		{
			DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
			DefaultSequenceElement element = defaultSequenceElement;
			USequence uSequence = _sequence.Append(element);
			Action action = default(Action);
			Action value = delegate
			{
				PaymentFlowBuilder paymentFlowBuilder = this;
				IEnumerable<ShopItemData> data = paymentFlowBuilder._itemData.Enumerate();
				USequence uSequence2 = RewardDistributor.ExtractAndDistribute(data, callOnPurchase: true, animateCurrency);
				Action value2 = action;
				if (action == null)
				{
					value2 = (action = delegate
					{
						element.Complete();
					});
				}
				uSequence2.OnComplete += value2;
				uSequence2.Start();
			};
			element.OnStart += value;
			return this;
		}

		[Token(Token = "0x6001E9B")]
		[Address(RVA = "0x3D87414", Offset = "0x3D87414", Length = "0x178")]
		public PaymentFlowBuilder ThenShowPackageRewardsUi(Action onRewardGiven = null)
		{
			DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
			DefaultSequenceElement element = defaultSequenceElement;
			USequence uSequence = _sequence.Append(element);
			IEnumerable<ShopItemData> data = _itemData.Enumerate();
			IEnumerable<ShopItemData> enumerable = RewardDistributor.Extract(data);
			IEnumerable<ShopItemData> extractedItems = enumerable;
			Action action = default(Action);
			Action value = delegate
			{
				PaymentFlowBuilder paymentFlowBuilder = this;
				if (paymentFlowBuilder._instancer.TryResolve<UiManager>(out var result))
				{
					RewardUiController rewardUiController = result.Show<RewardUiController>();
					Action onComplete = action;
					if (action == null)
					{
						onComplete = (action = delegate
						{
							element.Complete();
						});
					}
					rewardUiController.Show(extractedItems, onComplete, onRewardGiven);
				}
				else
				{
					element.Complete();
				}
			};
			element.OnStart += value;
			return this;
		}

		[Token(Token = "0x6001E9C")]
		[Address(RVA = "0x3D87594", Offset = "0x3D87594", Length = "0x11C")]
		public PaymentFlowBuilder ThenGoHome()
		{
			DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
			DefaultSequenceElement element = defaultSequenceElement;
			USequence uSequence = _sequence.Append(element);
			Action value = delegate
			{
				element.Complete();
			};
			element.OnStart += value;
			return this;
		}

		[Token(Token = "0x6001E9D")]
		[Address(RVA = "0x3D876B8", Offset = "0x3D876B8", Length = "0x12C")]
		public unsafe PaymentFlowBuilder ThenPlayCurrencyAnimations()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentFlowBuilder::ThenPlayCurrencyAnimations");
			return default;
		}

		[Token(Token = "0x6001E9E")]
		[Address(RVA = "0x3D877EC", Offset = "0x3D877EC", Length = "0x130")]
		public PaymentFlowBuilder ThenCallback(Action callback)
		{
			DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
			DefaultSequenceElement element = defaultSequenceElement;
			USequence uSequence = _sequence.Append(element);
			Action value = delegate
			{
				if (callback != null)
				{
					callback();
				}
				element.Complete();
			};
			element.OnStart += value;
			return this;
		}

		[Token(Token = "0x6001E9F")]
		[Address(RVA = "0x3D87924", Offset = "0x3D87924", Length = "0x28")]
		public PaymentFlowBuilder OnFailed(Action onFailed)
		{
			_onFailed = onFailed;
			return this;
		}

		[Token(Token = "0x6001EA0")]
		[Address(RVA = "0x3D8794C", Offset = "0x3D8794C", Length = "0x268")]
		public void Execute(Action onComplete = null)
		{
			PaymentSequenceElement element = new PaymentSequenceElement(_instancer, _executor, _itemData, _costData, _onFailed);
			USequence uSequence = new USequence();
			USequence uSequence2 = uSequence.Append(element);
			CostData costData = _costData;
			if (costData.costType == CostData.CostType.Resource && _instancer.TryResolve<CurrencyAnimationController>(out var animController))
			{
				DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
				DefaultSequenceElement refreshElement = defaultSequenceElement;
				Action value = delegate
				{
					PaymentFlowBuilder paymentFlowBuilder = this;
					CostData costData2 = paymentFlowBuilder._costData;
					animController.RefreshVisualizers(costData2.resourceType);
					refreshElement.Complete();
				};
				refreshElement.OnStart += value;
				USequence uSequence3 = uSequence.Append(refreshElement);
			}
			USequence uSequence4 = uSequence.Append(_sequence);
			if (onComplete != null)
			{
				uSequence.OnComplete += onComplete;
			}
			uSequence.Start();
		}
	}
}
