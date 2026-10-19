using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Sirenix.Utilities;
using Unco.AdSystem;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using _game.Systems.ExternalStubs.Misc;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.ShopSystem.Scripts.Core;

namespace _game.Scripts.Shop.View.Components
{
	[Token(Token = "0x20006FF")]
	public class PurchaseButton : MonoBehaviour, IDisposable
	{
		[SerializeField]
		[Token(Token = "0x4001770")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_purchaseButton;

		[SerializeField]
		[Token(Token = "0x4001771")]
		[FieldOffset(Offset = "0x28")]
		private ComponentStateHandler m_handler;

		[SerializeField]
		[Token(Token = "0x4001772")]
		[FieldOffset(Offset = "0x30")]
		private TextView m_priceHolder;

		[SerializeField]
		[Token(Token = "0x4001773")]
		[FieldOffset(Offset = "0x38")]
		private bool m_showRewardUiController;

		[Inject(false)]
		[Token(Token = "0x4001774")]
		[FieldOffset(Offset = "0x40")]
		private IAdManager _adManager;

		[Inject(false)]
		[Token(Token = "0x4001775")]
		[FieldOffset(Offset = "0x48")]
		private ShopService _shopService;

		[Token(Token = "0x4001776")]
		[FieldOffset(Offset = "0x50")]
		private CostData _costData;

		[Token(Token = "0x4001777")]
		[FieldOffset(Offset = "0x58")]
		private string _extraText;

		[Token(Token = "0x6001D7E")]
		[Address(RVA = "0x3D79ABC", Offset = "0x3D79ABC", Length = "0x1F4")]
		public void InitCostButtonWithoutPayment(CostData cost, Action onClick, bool setCostText = true)
		{
			_costData = cost;
			IEnumerable<GenericViewStateHandler.IPurchaseButtonState> statesSafeAs = m_handler.GetStatesSafeAs<GenericViewStateHandler.IPurchaseButtonState>();
			Action<GenericViewStateHandler.IPurchaseButtonState> action = delegate(GenericViewStateHandler.IPurchaseButtonState state)
			{
				state.Init(this, cost);
			};
			IEnumerable<GenericViewStateHandler.IPurchaseButtonState> enumerable = statesSafeAs.ForEach(action);
			ActivateStateByCostData();
			Action clickAction = delegate
			{
				if (onClick != null)
				{
					onClick();
				}
			};
			m_purchaseButton.AddListener(clickAction, removeAllListener: true, deactivateAfterClick: false);
			if (setCostText)
			{
				SetCostText();
			}
		}

		[Token(Token = "0x6001D7F")]
		[Address(RVA = "0x3D79F00", Offset = "0x3D79F00", Length = "0xC8")]
		private void SetCostText()
		{
			string text;
			if (_extraText.IsNullOrWhitespace())
			{
				text = "";
			}
			else
			{
				string text2 = _extraText + " ";
				text = text2;
			}
			string costString = _shopService.GetCostString(_costData);
			string text3 = text + costString;
			TextView textView = default(TextView);
			textView.SetText(text3);
		}

		[Token(Token = "0x6001D80")]
		[Address(RVA = "0x3D79CB8", Offset = "0x3D79CB8", Length = "0x248")]
		private void ActivateStateByCostData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PurchaseButton::ActivateStateByCostData");
		}

		[Token(Token = "0x6001D81")]
		[Address(RVA = "0x3D7A1C0", Offset = "0x3D7A1C0", Length = "0x100")]
		private void OnAdLoaded(string obj)
		{
			Action<string> value = OnAdLoaded;
			_adManager.OnAdsLoaded -= value;
			ActivateStateByCostData();
		}

		[Token(Token = "0x6001D82")]
		[Address(RVA = "0x3D7A2C0", Offset = "0x3D7A2C0", Length = "0x1C")]
		public void SetEnabled(bool b)
		{
			m_purchaseButton.enabled = b;
		}

		[Token(Token = "0x6001D83")]
		[Address(RVA = "0x3D7A2DC", Offset = "0x3D7A2DC", Length = "0x8")]
		public UncoButton GetButton()
		{
			return m_purchaseButton;
		}

		[Token(Token = "0x6001D84")]
		[Address(RVA = "0x3D7A2E4", Offset = "0x3D7A2E4", Length = "0x190")]
		public void Dispose()
		{
			if (_adManager != null)
			{
				Action<string> value = OnAdLoaded;
				_adManager.OnAdsLoaded -= value;
				return;
			}
			GameObject gameObject = base.gameObject;
			Transform transform = gameObject.transform;
			Transform parent = transform.parent;
			string message = parent.name;
			Debug.LogError(message);
		}

		[Token(Token = "0x6001D85")]
		[Address(RVA = "0x3D7A474", Offset = "0x3D7A474", Length = "0x10")]
		public PurchaseButton()
		{
			m_showRewardUiController = true;
		}
	}
}
