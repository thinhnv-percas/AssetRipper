using System;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.AdSystem;
using UnityEngine;
using _game.Systems.Offers;

namespace _game.Systems.ShopSystem.Scripts.Ui.ShopGroups.ShopPacks
{
	[Token(Token = "0x2000713")]
	public class NoAdViewController : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x40017B2")]
		[FieldOffset(Offset = "0x20")]
		private OfferService _offerService;

		[Inject(false)]
		[Token(Token = "0x40017B3")]
		[FieldOffset(Offset = "0x28")]
		private IAdManager _adManager;

		[Inject(false)]
		[Token(Token = "0x6001DD0")]
		[Address(RVA = "0x3D7D130", Offset = "0x3D7D130", Length = "0x1AC")]
		private void Inject()
		{
			if (ShouldHide())
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
			Action<bool> value = OnNoAdsStatusUpdated;
			_adManager.NoAdsStatusUpdatedEvent -= value;
			Action<bool> value2 = OnNoAdsStatusUpdated;
			_adManager.NoAdsStatusUpdatedEvent += value2;
		}

		[Token(Token = "0x6001DD1")]
		[Address(RVA = "0x3D7D2DC", Offset = "0x3D7D2DC", Length = "0x1F4")]
		private bool ShouldHide()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdViewController::ShouldHide");
			return default;
		}

		[Token(Token = "0x6001DD2")]
		[Address(RVA = "0x3D7D4D0", Offset = "0x3D7D4D0", Length = "0x178")]
		private void OnNoAdsStatusUpdated(bool purchased)
		{
			if (purchased)
			{
				Action<bool> value = OnNoAdsStatusUpdated;
				_adManager.NoAdsStatusUpdatedEvent -= value;
				if (this != null)
				{
					GameObject gameObject = base.gameObject;
					gameObject.SetActive(value: false);
				}
			}
		}

		[Token(Token = "0x6001DD3")]
		[Address(RVA = "0x3D7D648", Offset = "0x3D7D648", Length = "0x110")]
		private void OnDestroy()
		{
			if (_adManager != null)
			{
				Action<bool> value = OnNoAdsStatusUpdated;
				_adManager.NoAdsStatusUpdatedEvent -= value;
			}
		}

		[Token(Token = "0x6001DD4")]
		[Address(RVA = "0x3D7D758", Offset = "0x3D7D758", Length = "0x8")]
		public NoAdViewController()
		{
		}
	}
}
