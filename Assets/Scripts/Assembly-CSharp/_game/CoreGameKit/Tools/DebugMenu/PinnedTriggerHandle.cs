using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B6")]
	public readonly struct PinnedTriggerHandle
	{
		[Token(Token = "0x40013BC")]
		[FieldOffset(Offset = "0x0")]
		public readonly string Label;

		[Token(Token = "0x40013BD")]
		[FieldOffset(Offset = "0x8")]
		public readonly KeyCode Hotkey;

		[Token(Token = "0x40013BE")]
		[FieldOffset(Offset = "0x10")]
		public readonly Action Invoke;

		[Token(Token = "0x6001878")]
		[Address(RVA = "0x3D386B8", Offset = "0x3D386B8", Length = "0x44")]
		public PinnedTriggerHandle(string label, KeyCode hotkey, Action invoke)
		{
			Label = label;
			Invoke = invoke;
			Hotkey = hotkey;
		}
	}
}
