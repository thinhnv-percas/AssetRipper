using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Serializable]
	[Token(Token = "0x20005BC")]
	public class DebugCameraPath
	{
		[Token(Token = "0x40013C6")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x40013C7")]
		[FieldOffset(Offset = "0x18")]
		public List<DebugCameraPathSegment> Segments;

		[Token(Token = "0x40013C8")]
		[FieldOffset(Offset = "0x20")]
		public bool PinToOverlay;

		[Token(Token = "0x40013C9")]
		[FieldOffset(Offset = "0x24")]
		public KeyCode Hotkey;

		[Token(Token = "0x6001884")]
		[Address(RVA = "0x3D38D9C", Offset = "0x3D38D9C", Length = "0x8C")]
		public DebugCameraPath()
		{
			List<DebugCameraPathSegment> segments = new List<DebugCameraPathSegment>();
			Segments = segments;
		}
	}
}
