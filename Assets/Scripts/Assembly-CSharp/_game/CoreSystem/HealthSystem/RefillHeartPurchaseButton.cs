using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.PaymentSystem.Flow;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004D5")]
	public class RefillHeartPurchaseButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400102C")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_costText;

		[SerializeField]
		[Token(Token = "0x400102D")]
		[FieldOffset(Offset = "0x28")]
		private TextView m_heartCountText;

		[SerializeField]
		[Token(Token = "0x400102E")]
		[FieldOffset(Offset = "0x30")]
		private ComponentStateHandler m_stateHandler;

		[Inject(false)]
		[Token(Token = "0x400102F")]
		[FieldOffset(Offset = "0x38")]
		private PaymentFlowController _paymentFlowController;

		[Token(Token = "0x6001460")]
		[Address(RVA = "0x3CF4D58", Offset = "0x3CF4D58", Length = "0x328")]
		public void Initialize(RefillHeartConfig.PurchaseOption purchaseOption, Action<RefillHeartConfig.PurchaseOption> onSuccess, Action<RefillHeartConfig.PurchaseOption> onFail)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RefillHeartPurchaseButton::Initialize");
		}

		[Token(Token = "0x6001461")]
		[Address(RVA = "0x3CF5088", Offset = "0x3CF5088", Length = "0x8")]
		public RefillHeartPurchaseButton()
		{
		}
	}
}
