using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Token(Token = "0x20005BE")]
	public class DebugCameraKeyListener : MonoBehaviour
	{
		[Token(Token = "0x40013CD")]
		[FieldOffset(Offset = "0x20")]
		internal DebugCameraData _data;

		[Token(Token = "0x40013CE")]
		[FieldOffset(Offset = "0x28")]
		internal DebugCameraPathPlayer _player;

		[Token(Token = "0x6001886")]
		[Address(RVA = "0x3D38E3C", Offset = "0x3D38E3C", Length = "0x34")]
		public void Configure(DebugCameraData data, DebugCameraPathPlayer player)
		{
			_data = data;
			_player = player;
		}

		[Token(Token = "0x6001887")]
		[Address(RVA = "0x3D38E70", Offset = "0x3D38E70", Length = "0xD8")]
		private void Update()
		{
			DebugCameraData data = _data;
			if (_data == null || _player == null || data.Paths == null)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				List<DebugCameraPath> paths = data.Paths;
				if (num < paths.Count)
				{
					DebugCameraPath debugCameraPath = paths[num];
					if (debugCameraPath != null && debugCameraPath.Hotkey != KeyCode.None && Input.GetKeyDown(debugCameraPath.Hotkey))
					{
						_player.Play(debugCameraPath);
					}
					num++;
					data = _data;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6001888")]
		[Address(RVA = "0x3D390B8", Offset = "0x3D390B8", Length = "0x8")]
		public DebugCameraKeyListener()
		{
		}
	}
}
