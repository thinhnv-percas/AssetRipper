using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000011")]
public struct RewardedAdButtonComponent : IComponent
{
	[Required]
	[Token(Token = "0x4000047")]
	[FieldOffset(Offset = "0x0")]
	public GameStatesEnum AdPlacement;

	[Required]
	[Token(Token = "0x4000048")]
	[FieldOffset(Offset = "0x8")]
	public TextMeshProUGUI Reward;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AA64", Offset = "0x74AA64")]
	[Token(Token = "0x4000049")]
	[FieldOffset(Offset = "0x10")]
	public float AddMoneyMultiplier;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AA9C", Offset = "0x74AA9C")]
	[Token(Token = "0x400004A")]
	[FieldOffset(Offset = "0x14")]
	public bool DoubleReward;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AAD4", Offset = "0x74AAD4")]
	[Token(Token = "0x400004B")]
	[FieldOffset(Offset = "0x18")]
	public List<GlobalEvent> SuccessEvent;
}
