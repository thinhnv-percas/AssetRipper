using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Serializable]
	[Token(Token = "0x200052E")]
	public struct CameraPose
	{
		[Token(Token = "0x4001180")]
		[FieldOffset(Offset = "0x0")]
		public Vector3 Position;

		[Token(Token = "0x4001181")]
		[FieldOffset(Offset = "0xC")]
		public Quaternion Rotation;

		[Token(Token = "0x4001182")]
		[FieldOffset(Offset = "0x1C")]
		public float OrthographicSize;

		[Token(Token = "0x60015AD")]
		[Address(RVA = "0x3D13B68", Offset = "0x3D13B68", Length = "0xC8")]
		public static CameraPose Lerp(CameraPose a, CameraPose b, float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPose::Lerp");
			return default;
		}
	}
}
