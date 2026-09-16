using System;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

namespace GBG.Pinata.ECS.Components
{
	[Serializable]
	[Token(Token = "0x2000085")]
	public struct UICanvasComponent : IComponent
	{
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x0")]
		public CanvasGroup MainMenu;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x8")]
		public CanvasGroup WinScreen;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x10")]
		public CanvasGroup LoseScreen;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x18")]
		public CanvasGroup NoInternet;
	}
}
