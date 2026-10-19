using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools.LevelScreenshot
{
	[Token(Token = "0x20005AA")]
	public struct LevelCaptureRequest
	{
		[Token(Token = "0x400136B")]
		[FieldOffset(Offset = "0x0")]
		public string FileNameWithoutExtension;

		[Token(Token = "0x400136C")]
		[FieldOffset(Offset = "0x8")]
		public string OutputSubfolder;

		[Token(Token = "0x400136D")]
		[FieldOffset(Offset = "0x10")]
		public float DelayBeforeCapture;

		[Token(Token = "0x400136E")]
		[FieldOffset(Offset = "0x14")]
		public bool HideUi;

		[Token(Token = "0x400136F")]
		[FieldOffset(Offset = "0x18")]
		public Action OnCaptured;
	}
}
