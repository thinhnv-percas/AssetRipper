using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x2000062")]
	public struct SubscriptionViewComponent : IComponent
	{
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x0")]
		public GlobalEventString PurchaseEvent;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x8")]
		public string WeeklySubscriptionProductName;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x10")]
		public string MonthlySubscriptionProductName;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x18")]
		public string YearlySubscriptionProductName;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x20")]
		public GameObject VIPIcon;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x28")]
		public GameObject VIPTab;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x30")]
		public GameObject ErrorScreen;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x38")]
		public Button PurchaseConfirmButton;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x40")]
		public Button WeekChooseButton;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x48")]
		public Button MonthChooseButton;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x50")]
		public Button YearChooseButton;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x58")]
		public TextMeshProUGUI WeekPriceText;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x60")]
		public TextMeshProUGUI MonthPriceText;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x68")]
		public TextMeshProUGUI YearPriceText;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x70")]
		public TextMeshProUGUI AgreementText;
	}
}
