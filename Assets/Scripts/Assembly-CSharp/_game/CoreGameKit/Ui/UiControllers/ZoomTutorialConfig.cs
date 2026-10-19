using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Serializable]
	[Token(Token = "0x200055D")]
	public struct ZoomTutorialConfig
	{
		[Token(Token = "0x400125E")]
		[FieldOffset(Offset = "0x0")]
		public string text;

		[Token(Token = "0x400125F")]
		[FieldOffset(Offset = "0x8")]
		public float zoomAmount;

		[Token(Token = "0x4001260")]
		[FieldOffset(Offset = "0xC")]
		public int requiredLevel;
	}
}
