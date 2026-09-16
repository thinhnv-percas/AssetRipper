using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Flags]
	[Token(Token = "0x200006C")]
	public enum UiEvents
	{
		[Token(Token = "0x4000258")]
		None = 0,
		[Token(Token = "0x4000259")]
		Click = 1,
		[Token(Token = "0x400025A")]
		BeginDrag = 2,
		[Token(Token = "0x400025B")]
		Drag = 4,
		[Token(Token = "0x400025C")]
		EndDrag = 8,
		[Token(Token = "0x400025D")]
		Drop = 0x10,
		[Token(Token = "0x400025E")]
		PointerClick = 0x20,
		[Token(Token = "0x400025F")]
		PointerDown = 0x40,
		[Token(Token = "0x4000260")]
		PointerEnter = 0x80,
		[Token(Token = "0x4000261")]
		PointerExit = 0x100,
		[Token(Token = "0x4000262")]
		PointerUp = 0x200,
		[Token(Token = "0x4000263")]
		EndEdit = 0x400,
		[Token(Token = "0x4000264")]
		BoolValueChanged = 0x800,
		[Token(Token = "0x4000265")]
		FloatValueChanged = 0x1000,
		[Token(Token = "0x4000266")]
		IntValueChanged = 0x2000,
		[Token(Token = "0x4000267")]
		Vector2ValueChanged = 0x4000,
		[Token(Token = "0x4000268")]
		DragEvents = 0xE,
		[Token(Token = "0x4000269")]
		PointerEvents = 0x3E0
	}
}
