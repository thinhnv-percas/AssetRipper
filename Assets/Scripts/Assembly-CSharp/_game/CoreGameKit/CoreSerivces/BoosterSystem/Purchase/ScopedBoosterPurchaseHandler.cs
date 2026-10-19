using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ResourceSystem;
using Unco.RewardSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Config;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.PaymentSystem.Flow;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase
{
	[Token(Token = "0x200061F")]
	public class ScopedBoosterPurchaseHandler : IBoosterPurchaseHandler
	{
		[Token(Token = "0x2000620")]
		private class StubOffer : IBoosterPurchaseOffer
		{
			[Token(Token = "0x17000286")]
			[field: Token(Token = "0x400152D")]
			[field: FieldOffset(Offset = "0x10")]
			public string BoosterId
			{
				[Token(Token = "0x6001A37")]
				[Address(RVA = "0x3D520AC", Offset = "0x3D520AC", Length = "0x8")]
				get;
				[Token(Token = "0x6001A38")]
				[Address(RVA = "0x3D520B4", Offset = "0x3D520B4", Length = "0x8")]
				set;
			}

			[Token(Token = "0x17000287")]
			[field: Token(Token = "0x400152E")]
			[field: FieldOffset(Offset = "0x18")]
			public int Amount
			{
				[Token(Token = "0x6001A39")]
				[Address(RVA = "0x3D520BC", Offset = "0x3D520BC", Length = "0x8")]
				get;
				[Token(Token = "0x6001A3A")]
				[Address(RVA = "0x3D520C4", Offset = "0x3D520C4", Length = "0x8")]
				set;
			}

			[Token(Token = "0x17000288")]
			[field: Token(Token = "0x400152F")]
			[field: FieldOffset(Offset = "0x20")]
			public string PriceDisplay
			{
				[Token(Token = "0x6001A3B")]
				[Address(RVA = "0x3D520CC", Offset = "0x3D520CC", Length = "0x8")]
				get;
				[Token(Token = "0x6001A3C")]
				[Address(RVA = "0x3D520D4", Offset = "0x3D520D4", Length = "0x8")]
				set;
			}

			[Token(Token = "0x17000289")]
			[field: Token(Token = "0x4001530")]
			[field: FieldOffset(Offset = "0x28")]
			public Sprite CurrencyIcon
			{
				[Token(Token = "0x6001A3D")]
				[Address(RVA = "0x3D520DC", Offset = "0x3D520DC", Length = "0x8")]
				get;
				[Token(Token = "0x6001A3E")]
				[Address(RVA = "0x3D520E4", Offset = "0x3D520E4", Length = "0x8")]
				set;
			}

			[Token(Token = "0x6001A3F")]
			[Address(RVA = "0x3D51D24", Offset = "0x3D51D24", Length = "0x8")]
			public StubOffer()
			{
			}
		}

		[Token(Token = "0x4001529")]
		[FieldOffset(Offset = "0x10")]
		private IBoosterService _boosterService;

		[Token(Token = "0x400152A")]
		[FieldOffset(Offset = "0x18")]
		private BoosterUnlockHandler _unlockHandler;

		[Token(Token = "0x400152B")]
		[FieldOffset(Offset = "0x20")]
		private BoosterDatabase _boosterDatabase;

		[Token(Token = "0x400152C")]
		[FieldOffset(Offset = "0x28")]
		private PaymentFlowController _paymentFlowController;

		[Inject(false)]
		[Token(Token = "0x6001A33")]
		[Address(RVA = "0x3D51AB0", Offset = "0x3D51AB0", Length = "0x64")]
		private void Inject(IBoosterService boosterService, BoosterUnlockHandler unlockHandler, BoosterDatabase boosterDatabase, PaymentFlowController paymentFlowController)
		{
			_boosterService = boosterService;
			_unlockHandler = unlockHandler;
			_boosterDatabase = boosterDatabase;
			_paymentFlowController = paymentFlowController;
		}

		[Token(Token = "0x6001A34")]
		[Address(RVA = "0x3D51B14", Offset = "0x3D51B14", Length = "0x198")]
		public IBoosterPurchaseOffer GetOffer(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopedBoosterPurchaseHandler::GetOffer");
			return default;
		}

		[Token(Token = "0x6001A35")]
		[Address(RVA = "0x3D51D2C", Offset = "0x3D51D2C", Length = "0x370")]
		public void Purchase(IBoosterPurchaseOffer offer, Action<bool> onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScopedBoosterPurchaseHandler::Purchase");
		}

		[Token(Token = "0x6001A36")]
		[Address(RVA = "0x3D520A4", Offset = "0x3D520A4", Length = "0x8")]
		public ScopedBoosterPurchaseHandler()
		{
		}
	}
}
