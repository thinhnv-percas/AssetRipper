using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

[Serializable]
[StructLayout((LayoutKind)0, Size = 32)]
[Token(Token = "0x200001A")]
public struct WeaponUpgradeParametersComponent : IComponent
{
	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74ABA8", Offset = "0x74ABA8")]
	[Token(Token = "0x4000070")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
	public int UpgradesLimit;

	[Token(Token = "0x4000071")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
	public int CurrentAmmoUpgrade;

	[Token(Token = "0x4000072")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
	public int CurrentPowerUpgrade;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74ABE0", Offset = "0x74ABE0")]
	[Token(Token = "0x4000073")]
	[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
	public int BuyPrice;

	[Token(Token = "0x4000074")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
	public int AmmoUpgradePrice;

	[Token(Token = "0x4000075")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
	public int AmmoUpgradeInterpolation;

	[Token(Token = "0x4000076")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
	public int PowerUpgradePrice;

	[Token(Token = "0x4000077")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
	public int PowerUpgradeInterpolation;
}
