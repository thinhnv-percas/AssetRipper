using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[Serializable]
	[Token(Token = "0x20005C7")]
	public class ScreenshotResolutionEntry
	{
		[Token(Token = "0x4001401")]
		[FieldOffset(Offset = "0x10")]
		public bool Enabled;

		[Token(Token = "0x4001402")]
		[FieldOffset(Offset = "0x18")]
		public string Name;

		[Token(Token = "0x4001403")]
		[FieldOffset(Offset = "0x20")]
		public int Width;

		[Token(Token = "0x4001404")]
		[FieldOffset(Offset = "0x24")]
		public int Height;

		[Token(Token = "0x4001405")]
		[FieldOffset(Offset = "0x28")]
		public FullScreenMode ScreenMode;

		[Token(Token = "0x60018D7")]
		[Address(RVA = "0x3D415C4", Offset = "0x3D415C4", Length = "0x24")]
		public ScreenshotResolutionEntry()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolutionEntry::.ctor");
		}
	}
}
