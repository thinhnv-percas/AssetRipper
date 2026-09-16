using System;
using Cpp2ILInjected;
using Morpeh;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[Token(Token = "0x2000018")]
public struct WeaponButtonParametersOpacityComponent : IComponent
{
	[Token(Token = "0x200008A")]
	public enum ParameterComponentType
	{
		[Token(Token = "0x400017F")]
		Image = 0,
		[Token(Token = "0x4000180")]
		TextMeshProUGUI = 1
	}

	[Token(Token = "0x4000067")]
	[FieldOffset(Offset = "0x0")]
	public Transform Parent;

	[Token(Token = "0x4000068")]
	[FieldOffset(Offset = "0x8")]
	public ParameterComponentType ThisGameObjectComponentType;

	[Token(Token = "0x4000069")]
	[FieldOffset(Offset = "0x10")]
	public Image Image;

	[Token(Token = "0x400006A")]
	[FieldOffset(Offset = "0x18")]
	public TextMeshProUGUI Text;
}
