using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[Token(Token = "0x2000016")]
public struct TabComponent : IComponent
{
	[HideInInspector]
	[Token(Token = "0x4000053")]
	[FieldOffset(Offset = "0x0")]
	public GlobalEvent OnClick;

	[Token(Token = "0x4000054")]
	[FieldOffset(Offset = "0x8")]
	public bool SpriteSwap;

	[Token(Token = "0x4000055")]
	[FieldOffset(Offset = "0x10")]
	public Button Button;

	[Token(Token = "0x4000056")]
	[FieldOffset(Offset = "0x18")]
	public int uiId;
}
