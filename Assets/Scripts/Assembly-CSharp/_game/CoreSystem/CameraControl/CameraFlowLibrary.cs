using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/Camera Flow Library", fileName = "CameraFlowLibrary")]
	[Token(Token = "0x2000524")]
	public class CameraFlowLibrary : ScriptableObject
	{
		[Token(Token = "0x400115E")]
		[FieldOffset(Offset = "0x18")]
		public List<CameraFlowAsset> Flows;

		[Token(Token = "0x600157B")]
		[Address(RVA = "0x3D11C10", Offset = "0x3D11C10", Length = "0x8C")]
		public CameraFlowLibrary()
		{
			List<CameraFlowAsset> flows = new List<CameraFlowAsset>();
			Flows = flows;
		}
	}
}
