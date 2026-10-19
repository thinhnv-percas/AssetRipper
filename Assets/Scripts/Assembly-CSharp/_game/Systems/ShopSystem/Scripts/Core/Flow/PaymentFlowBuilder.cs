using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
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

namespace _game.Systems.ShopSystem.Scripts.Core.Flow
{
	[Token(Token = "0x2000731")]
	public class PaymentFlowBuilder
	{
		[Inject(false)]
		[Token(Token = "0x400180B")]
		[FieldOffset(Offset = "0x10")]
		private UiManager _uiManager;

		[Token(Token = "0x400180C")]
		[FieldOffset(Offset = "0x18")]
		private readonly PaymentExecutor _executor;

		[Token(Token = "0x400180D")]
		[FieldOffset(Offset = "0x20")]
		private readonly ShopItemData _itemData;

		[Token(Token = "0x400180E")]
		[FieldOffset(Offset = "0x28")]
		private readonly CostData _costData;

		[Token(Token = "0x400180F")]
		[FieldOffset(Offset = "0x30")]
		private readonly USequence _sequence;

		[Token(Token = "0x4001810")]
		[FieldOffset(Offset = "0x38")]
		private readonly CurrencyAnimationController _currencyAnimationController;

		[Token(Token = "0x4001811")]
		[FieldOffset(Offset = "0x40")]
		private readonly IResourceService _resourceService;

		[Token(Token = "0x4001812")]
		[FieldOffset(Offset = "0x48")]
		internal Action _onFailed;

		[Token(Token = "0x6001E4E")]
		[Address(RVA = "0x3D8369C", Offset = "0x3D8369C", Length = "0xEC")]
		internal PaymentFlowBuilder(PaymentExecutor executor, ShopItemData itemData, CostData costData, CurrencyAnimationController currencyAnimationController, IResourceService resourceService)
		{
			_executor = executor;
			_itemData = itemData;
			_costData = costData;
			_currencyAnimationController = currencyAnimationController;
			_resourceService = resourceService;
			_sequence = new USequence();
		}

		[Token(Token = "0x6001E4F")]
		[Address(RVA = "0x3D83788", Offset = "0x3D83788", Length = "0x134")]
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

		[Token(Token = "0x6001E50")]
		[Address(RVA = "0x3D838C4", Offset = "0x3D838C4", Length = "0x190")]
		public PaymentFlowBuilder ThenShowPackageRewardsUi(UiManager uiManager, Action onRewardGiven = null)
		{
			_uiManager = uiManager;
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
				RewardUiController rewardUiController = paymentFlowBuilder._uiManager.Show<RewardUiController>();
				Action onComplete = action;
				if (action == null)
				{
					onComplete = (action = delegate
					{
						element.Complete();
					});
				}
				rewardUiController.Show(extractedItems, onComplete, onRewardGiven);
			};
			element.OnStart += value;
			return this;
		}

		[Token(Token = "0x6001E51")]
		[Address(RVA = "0x3D83A5C", Offset = "0x3D83A5C", Length = "0x11C")]
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

		[Token(Token = "0x6001E52")]
		[Address(RVA = "0x3D83B80", Offset = "0x3D83B80", Length = "0x12C")]
		public unsafe PaymentFlowBuilder ThenPlayCurrencyAnimations()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentFlowBuilder::ThenPlayCurrencyAnimations");
			return default;
		}

		[Token(Token = "0x6001E53")]
		[Address(RVA = "0x3D83CB4", Offset = "0x3D83CB4", Length = "0x130")]
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

		[Token(Token = "0x6001E54")]
		[Address(RVA = "0x3D83DEC", Offset = "0x3D83DEC", Length = "0x28")]
		public PaymentFlowBuilder OnFailed(Action onFailed)
		{
			_onFailed = onFailed;
			return this;
		}

		[Token(Token = "0x6001E55")]
		[Address(RVA = "0x3D83E14", Offset = "0x3D83E14", Length = "0x240")]
		public void Execute(Instancer instancer, Action onComplete = null)
		{
			PaymentSequenceElement element = new PaymentSequenceElement(instancer, _executor, _itemData, _costData, _onFailed);
			USequence uSequence = new USequence();
			USequence uSequence2 = uSequence.Append(element);
			CostData costData = _costData;
			if (costData.costType == CostData.CostType.Resource)
			{
				DefaultSequenceElement defaultSequenceElement = new DefaultSequenceElement();
				DefaultSequenceElement refreshElement = defaultSequenceElement;
				Action value = delegate
				{
					PaymentFlowBuilder paymentFlowBuilder = this;
					CostData costData2 = paymentFlowBuilder._costData;
					paymentFlowBuilder._currencyAnimationController.RefreshVisualizers(costData2.resourceType);
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
