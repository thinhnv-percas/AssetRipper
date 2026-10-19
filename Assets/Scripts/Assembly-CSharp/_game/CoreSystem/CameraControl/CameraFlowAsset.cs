using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/Camera Flow", fileName = "CameraFlow")]
	[Token(Token = "0x2000523")]
	public class CameraFlowAsset : ScriptableObject
	{
		[Token(Token = "0x400115C")]
		[FieldOffset(Offset = "0x18")]
		public string FlowName;

		[Token(Token = "0x400115D")]
		[FieldOffset(Offset = "0x20")]
		public List<CameraFlowStep> Steps;

		[Token(Token = "0x600157A")]
		[Address(RVA = "0x3D11B84", Offset = "0x3D11B84", Length = "0x8C")]
		public CameraFlowAsset()
		{
			List<CameraFlowStep> steps = new List<CameraFlowStep>();
			Steps = steps;
		}
	}
}
