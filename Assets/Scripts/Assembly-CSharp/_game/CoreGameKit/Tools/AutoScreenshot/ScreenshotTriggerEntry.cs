using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[Serializable]
	[Token(Token = "0x20005D2")]
	public class ScreenshotTriggerEntry
	{
		[Token(Token = "0x4001434")]
		[FieldOffset(Offset = "0x10")]
		public bool Enabled;

		[Token(Token = "0x4001435")]
		[FieldOffset(Offset = "0x18")]
		public string Name;

		[Token(Token = "0x4001436")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotTriggerType TriggerType;

		[Tooltip("OnUiShown: WinUiController, FailUiController vb.")]
		[Token(Token = "0x4001437")]
		[FieldOffset(Offset = "0x28")]
		public string UiControllerTypeName;

		[Tooltip("OnStateEntered: BaseLayerRunningState, BaseLayerWinState vb.")]
		[Token(Token = "0x4001438")]
		[FieldOffset(Offset = "0x30")]
		public string StateTypeName;

		[Token(Token = "0x4001439")]
		[FieldOffset(Offset = "0x38")]
		public float DelayBeforeCapture;

		[Token(Token = "0x600191C")]
		[Address(RVA = "0x3D45184", Offset = "0x3D45184", Length = "0x1C")]
		public ScreenshotTriggerEntry()
		{
			Enabled = true;
			DelayBeforeCapture = 0.8f;
		}
	}
}
