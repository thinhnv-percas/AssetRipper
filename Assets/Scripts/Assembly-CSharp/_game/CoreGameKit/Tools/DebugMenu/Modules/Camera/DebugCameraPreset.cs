using System;
using Cpp2ILInjected;
using _game.CoreSystem.CameraControl;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Serializable]
	[Token(Token = "0x20005BB")]
	public class DebugCameraPreset
	{
		[Token(Token = "0x40013C4")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x40013C5")]
		[FieldOffset(Offset = "0x18")]
		public CameraPose Pose;

		[Token(Token = "0x6001883")]
		[Address(RVA = "0x3D38D94", Offset = "0x3D38D94", Length = "0x8")]
		public DebugCameraPreset()
		{
		}
	}
}
