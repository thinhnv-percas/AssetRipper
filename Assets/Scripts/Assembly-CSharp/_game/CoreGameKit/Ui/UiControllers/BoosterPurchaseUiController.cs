using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.StateSystem.Runtime;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase;
using _game.CoreGameKit.Ui.Animations;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000540")]
	public class BoosterPurchaseUiController : UIController
	{
		[SerializeField]
		[Token(Token = "0x40011B6")]
		[FieldOffset(Offset = "0x48")]
		private Image m_boosterIcon;

		[SerializeField]
		[Token(Token = "0x40011B7")]
		[FieldOffset(Offset = "0x50")]
		private TextView m_boosterName;

		[SerializeField]
		[Token(Token = "0x40011B8")]
		[FieldOffset(Offset = "0x58")]
		private TextView m_description;

		[SerializeField]
		[Token(Token = "0x40011B9")]
		[FieldOffset(Offset = "0x60")]
		private TextView m_amountText;

		[SerializeField]
		[Token(Token = "0x40011BA")]
		[FieldOffset(Offset = "0x68")]
		private TextView m_priceText;

		[SerializeField]
		[Token(Token = "0x40011BB")]
		[FieldOffset(Offset = "0x70")]
		private Image m_currencyIcon;

		[SerializeField]
		[Token(Token = "0x40011BC")]
		[FieldOffset(Offset = "0x78")]
		private UncoButton m_buyButton;

		[Inject(false)]
		[Token(Token = "0x40011BD")]
		[FieldOffset(Offset = "0x80")]
		private CurrencyAnimationController _currencyAnimationController;

		[Inject(false)]
		[Token(Token = "0x40011BE")]
		[FieldOffset(Offset = "0x88")]
		private BaseLayerStateMachine _stateMachine;

		[Inject(false)]
		[Token(Token = "0x40011BF")]
		[FieldOffset(Offset = "0x90")]
		private BaseLayerWaitState _waitState;

		[Token(Token = "0x40011C0")]
		[FieldOffset(Offset = "0x98")]
		private BaseLayerState _cachedState;

		[Token(Token = "0x40011C1")]
		[FieldOffset(Offset = "0xA0")]
		private IBoosterPurchaseHandler _purchaseHandler;

		[Token(Token = "0x40011C2")]
		[FieldOffset(Offset = "0xA8")]
		private IBoosterPurchaseOffer _currentOffer;

		[Inject(false)]
		[Token(Token = "0x60015FF")]
		[Address(RVA = "0x3D17828", Offset = "0x3D17828", Length = "0x170")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterPurchaseUiController::Construct");
		}

		[Token(Token = "0x6001600")]
		[Address(RVA = "0x3D17998", Offset = "0x3D17998", Length = "0x94")]
		public override void Hide()
		{
			if (_cachedState != null)
			{
				BaseLayerReadyState baseLayerReadyState = _cachedState as BaseLayerReadyState;
				if (baseLayerReadyState != null)
				{
					goto IL_004b;
				}
			}
			_stateMachine.SetState(_cachedState);
			goto IL_004b;
			IL_004b:
			base.Hide();
		}

		[Token(Token = "0x6001601")]
		[Address(RVA = "0x3D17A2C", Offset = "0x3D17A2C", Length = "0x410")]
		public void SetData(BoosterDefinition definition, IBoosterPurchaseOffer offer, IBoosterPurchaseHandler handler)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterPurchaseUiController::SetData");
		}

		[Token(Token = "0x6001602")]
		[Address(RVA = "0x3D17E3C", Offset = "0x3D17E3C", Length = "0x104")]
		private void OnBuyClicked()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterPurchaseUiController::OnBuyClicked");
		}

		[Token(Token = "0x6001603")]
		[Address(RVA = "0x3D17F40", Offset = "0x3D17F40", Length = "0x8")]
		public BoosterPurchaseUiController()
		{
		}
	}
}
