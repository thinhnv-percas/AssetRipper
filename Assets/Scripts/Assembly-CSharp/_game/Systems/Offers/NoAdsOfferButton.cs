using System;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.AdSystem;
using Unco.UncoButtonSystem;
using UnityEngine;
using _game.CoreGameKit.MenuLayer.SideBubbleSystem;
using _game.CoreGameKit.UiControllers;

namespace _game.Systems.Offers
{
	[Token(Token = "0x200075F")]
	public class NoAdsOfferButton : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400189F")]
		[FieldOffset(Offset = "0x20")]
		private UncoButton m_noAdsButton;

		[Inject(false)]
		[Token(Token = "0x40018A0")]
		[FieldOffset(Offset = "0x28")]
		private UiManager _uiManager;

		[Inject(false)]
		[Token(Token = "0x40018A1")]
		[FieldOffset(Offset = "0x30")]
		private IAdManager _adManager;

		[Inject(false)]
		[Token(Token = "0x6001F0F")]
		[Address(RVA = "0x3D8B848", Offset = "0x3D8B848", Length = "0x274")]
		private void Init()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferButton::Init");
		}

		[Token(Token = "0x6001F10")]
		[Address(RVA = "0x3D8BB3C", Offset = "0x3D8BB3C", Length = "0x164")]
		private void NoAdsStatusUpdate(bool status)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferButton::NoAdsStatusUpdate");
		}

		[Token(Token = "0x6001F11")]
		[Address(RVA = "0x3D8BABC", Offset = "0x3D8BABC", Length = "0x80")]
		private void Hide()
		{
			SideBubbleSlot componentInParent = GetComponentInParent<SideBubbleSlot>();
			Sequence sequence = componentInParent.Hide();
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x6001F12")]
		[Address(RVA = "0x3D8BCA0", Offset = "0x3D8BCA0", Length = "0x110")]
		private void OnDestroy()
		{
			if (_adManager != null)
			{
				Action<bool> value = NoAdsStatusUpdate;
				_adManager.NoAdsStatusUpdatedEvent -= value;
			}
		}

		[Token(Token = "0x6001F13")]
		[Address(RVA = "0x3D8BDB0", Offset = "0x3D8BDB0", Length = "0x8")]
		public NoAdsOfferButton()
		{
		}
	}
}
