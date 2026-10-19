using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Serializable]
	[Token(Token = "0x20005BA")]
	public class DebugCameraData
	{
		[Token(Token = "0x40013C2")]
		[FieldOffset(Offset = "0x10")]
		public List<DebugCameraPreset> Presets;

		[Token(Token = "0x40013C3")]
		[FieldOffset(Offset = "0x18")]
		public List<DebugCameraPath> Paths;

		[Token(Token = "0x6001882")]
		[Address(RVA = "0x3D38CB4", Offset = "0x3D38CB4", Length = "0xE0")]
		public DebugCameraData()
		{
			List<DebugCameraPreset> presets = new List<DebugCameraPreset>();
			Presets = presets;
			List<DebugCameraPath> paths = new List<DebugCameraPath>();
			Paths = paths;
		}
	}
}
