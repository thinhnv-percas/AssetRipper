using System;
using Cpp2ILInjected;
using Unco.RewardSystem;
using UnityEngine;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000758")]
	public class PaymentContext
	{
		[Token(Token = "0x4001892")]
		[FieldOffset(Offset = "0x20")]
		internal readonly Action _onSuccess;

		[Token(Token = "0x4001893")]
		[FieldOffset(Offset = "0x28")]
		internal readonly Action _onFailed;

		[Token(Token = "0x4001894")]
		[FieldOffset(Offset = "0x30")]
		internal readonly Action _onComplete;

		[Token(Token = "0x170002F2")]
		[field: Token(Token = "0x4001890")]
		[field: FieldOffset(Offset = "0x10")]
		public ShopItemData ItemData
		{
			[Token(Token = "0x6001EF5")]
			[Address(RVA = "0x3D8A41C", Offset = "0x3D8A41C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x170002F3")]
		[field: Token(Token = "0x4001891")]
		[field: FieldOffset(Offset = "0x18")]
		public CostData CostData
		{
			[Token(Token = "0x6001EF6")]
			[Address(RVA = "0x3D8A424", Offset = "0x3D8A424", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6001EF7")]
		[Address(RVA = "0x3D8A42C", Offset = "0x3D8A42C", Length = "0x94")]
		public PaymentContext(ShopItemData itemData, CostData costData, Action onSuccess, Action onFailed, Action onComplete)
		{
			ItemData = itemData;
			CostData = costData;
			_onSuccess = onSuccess;
			_onFailed = onFailed;
			_onComplete = onComplete;
		}

		[Token(Token = "0x6001EF8")]
		[Address(RVA = "0x3D89B00", Offset = "0x3D89B00", Length = "0x258")]
		public unsafe void CompletePayment()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentContext::CompletePayment");
		}

		[Token(Token = "0x6001EF9")]
		[Address(RVA = "0x3D89938", Offset = "0x3D89938", Length = "0x54")]
		public void FailPayment()
		{
			if (_onFailed != null)
			{
				_onFailed();
			}
			if (_onComplete != null)
			{
				_onComplete();
			}
		}
	}
}
