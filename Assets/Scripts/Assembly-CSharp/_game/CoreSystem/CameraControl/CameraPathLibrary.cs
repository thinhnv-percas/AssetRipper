using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/Camera Path Library", fileName = "CameraPathLibrary")]
	[Token(Token = "0x2000531")]
	public class CameraPathLibrary : ScriptableObject
	{
		[Token(Token = "0x400118C")]
		[FieldOffset(Offset = "0x18")]
		public List<CameraPathAsset> Paths;

		[Token(Token = "0x60015B2")]
		[Address(RVA = "0x3D13DBC", Offset = "0x3D13DBC", Length = "0x8C")]
		public CameraPathLibrary()
		{
			List<CameraPathAsset> paths = new List<CameraPathAsset>();
			Paths = paths;
		}
	}
}
