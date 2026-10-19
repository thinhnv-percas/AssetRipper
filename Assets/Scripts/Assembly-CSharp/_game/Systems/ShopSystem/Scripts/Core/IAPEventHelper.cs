using System;
using System.Collections.Generic;
using Systems.ResourceSystem.IAPSystem.Scripts.Data;
using AdjustSdk;
using Cpp2ILInjected;
using Facebook.Unity;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.PaymentSystem.Data;
using _game.Systems.ShopSystem.Scripts.IAP;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200071C")]
	internal class IAPEventHelper
	{
		[Inject(false)]
		[Token(Token = "0x40017C6")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Inject(false)]
		[Token(Token = "0x40017C7")]
		[FieldOffset(Offset = "0x18")]
		private IAPStoreService _iapStoreService;

		[Inject(false)]
		[Token(Token = "0x40017C8")]
		[FieldOffset(Offset = "0x20")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x6001DF3")]
		[Address(RVA = "0x3D7EA0C", Offset = "0x3D7EA0C", Length = "0xA8")]
		public void Initialize()
		{
			Action<UventPurchaseSucceed> observer = OnPurchaseSucceed;
			_eventBus.ListenEvent(observer);
		}

		[Token(Token = "0x6001DF4")]
		[Address(RVA = "0x3D7EAB4", Offset = "0x3D7EAB4", Length = "0x490")]
		private void OnPurchaseSucceed(UventPurchaseSucceed evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IAPEventHelper::OnPurchaseSucceed");
		}

		[Token(Token = "0x6001DF5")]
		[Address(RVA = "0x3D7EF5C", Offset = "0x3D7EF5C", Length = "0x8")]
		public IAPEventHelper()
		{
		}
	}
}
