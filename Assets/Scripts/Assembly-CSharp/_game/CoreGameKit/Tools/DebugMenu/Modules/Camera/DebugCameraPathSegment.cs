using System;
using Cpp2ILInjected;
using _game.CoreSystem.CameraControl;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Serializable]
	[Token(Token = "0x20005BD")]
	public class DebugCameraPathSegment
	{
		[Token(Token = "0x40013CA")]
		[FieldOffset(Offset = "0x10")]
		public string PresetName;

		[Token(Token = "0x40013CB")]
		[FieldOffset(Offset = "0x18")]
		public float Duration;

		[Token(Token = "0x40013CC")]
		[FieldOffset(Offset = "0x1C")]
		public CameraEaseType Ease;

		[Token(Token = "0x6001885")]
		[Address(RVA = "0x3D38E28", Offset = "0x3D38E28", Length = "0x14")]
		public DebugCameraPathSegment()
		{
			Duration = 1f;
		}
	}
}
