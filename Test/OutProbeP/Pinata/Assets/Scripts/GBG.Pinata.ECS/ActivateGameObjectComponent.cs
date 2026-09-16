using System;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[Token(Token = "0x200000F")]
public struct ActivateGameObjectComponent : IComponent
{
	[HideInInspector]
	[Token(Token = "0x4000041")]
	[FieldOffset(Offset = "0x0")]
	public GlobalEvent OnClick;

	[Required]
	[Token(Token = "0x4000042")]
	[FieldOffset(Offset = "0x8")]
	public CanvasGroup CanvasGroup;

	[Token(Token = "0x4000043")]
	[FieldOffset(Offset = "0x10")]
	public Button Button;

	[Token(Token = "0x4000044")]
	[FieldOffset(Offset = "0x18")]
	public GameObject GameObject;

	[Token(Token = "0x4000045")]
	[FieldOffset(Offset = "0x20")]
	public bool ActiveOnStart;
}
