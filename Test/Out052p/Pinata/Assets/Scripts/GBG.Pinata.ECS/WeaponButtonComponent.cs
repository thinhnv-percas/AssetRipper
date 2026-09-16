using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[Token(Token = "0x2000017")]
public struct WeaponButtonComponent : IComponent
{
	[HideInInspector]
	[Token(Token = "0x4000057")]
	[FieldOffset(Offset = "0x0")]
	public GlobalEvent OnSelectWeaponClick;

	[HideInInspector]
	[Token(Token = "0x4000058")]
	[FieldOffset(Offset = "0x8")]
	public GlobalEvent OnAmmoUpgradeClick;

	[HideInInspector]
	[Token(Token = "0x4000059")]
	[FieldOffset(Offset = "0x10")]
	public GlobalEvent OnPowerUpgradeClick;

	[HideInInspector]
	[Token(Token = "0x400005A")]
	[FieldOffset(Offset = "0x18")]
	public GlobalEvent OnBuyWeaponClick;

	[Token(Token = "0x400005B")]
	[FieldOffset(Offset = "0x20")]
	public Transform ButtonTransform;

	[Token(Token = "0x400005C")]
	[FieldOffset(Offset = "0x28")]
	public Image WeaponIcon;

	[Token(Token = "0x400005D")]
	[FieldOffset(Offset = "0x30")]
	public Button SelectWeaponButton;

	[Token(Token = "0x400005E")]
	[FieldOffset(Offset = "0x38")]
	public Button AmmoUpgradeButton;

	[Token(Token = "0x400005F")]
	[FieldOffset(Offset = "0x40")]
	public Button PowerUpgradeButton;

	[Token(Token = "0x4000060")]
	[FieldOffset(Offset = "0x48")]
	public Button BuyWeaponButton;

	[Token(Token = "0x4000061")]
	[FieldOffset(Offset = "0x50")]
	public TextMeshProUGUI BuyPrice;

	[Token(Token = "0x4000062")]
	[FieldOffset(Offset = "0x58")]
	public TextMeshProUGUI AmmoPrice;

	[Token(Token = "0x4000063")]
	[FieldOffset(Offset = "0x60")]
	public TextMeshProUGUI PowerPrice;

	[Token(Token = "0x4000064")]
	[FieldOffset(Offset = "0x68")]
	public TextMeshProUGUI AmmoValue;

	[Token(Token = "0x4000065")]
	[FieldOffset(Offset = "0x70")]
	public TextMeshProUGUI PowerValue;

	[Token(Token = "0x4000066")]
	[FieldOffset(Offset = "0x78")]
	public int WeaponId;
}
