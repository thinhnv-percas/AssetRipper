using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x200052D")]
	public class CameraPoseCapture
	{
		[Token(Token = "0x400117D")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<CameraPose> _poses;

		[Token(Token = "0x400117E")]
		[FieldOffset(Offset = "0x18")]
		internal Transform _cameraTransform;

		[Token(Token = "0x400117F")]
		[FieldOffset(Offset = "0x20")]
		internal Camera _camera;

		[Token(Token = "0x170001F4")]
		public IReadOnlyList<CameraPose> Poses
		{
			[Token(Token = "0x60015A3")]
			[Address(RVA = "0x3D135CC", Offset = "0x3D135CC", Length = "0x8")]
			get
			{
				return PosesMutable;
			}
		}

		[Token(Token = "0x170001F5")]
		public List<CameraPose> PosesMutable
		{
			[Token(Token = "0x60015A4")]
			[Address(RVA = "0x3D135D4", Offset = "0x3D135D4", Length = "0x8")]
			get
			{
				return _poses;
			}
		}

		[Token(Token = "0x60015A5")]
		[Address(RVA = "0x3D135DC", Offset = "0x3D135DC", Length = "0x8")]
		public void SetTarget(Transform cameraTransform)
		{
			_cameraTransform = cameraTransform;
		}

		[Token(Token = "0x60015A6")]
		[Address(RVA = "0x3D135E4", Offset = "0x3D135E4", Length = "0x8")]
		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}

		[Token(Token = "0x60015A7")]
		[Address(RVA = "0x3D135EC", Offset = "0x3D135EC", Length = "0x214")]
		public unsafe bool Capture()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPoseCapture::Capture");
			return default;
		}

		[Token(Token = "0x60015A8")]
		[Address(RVA = "0x3D13800", Offset = "0x3D13800", Length = "0x78")]
		public void RemoveLast()
		{
			List<CameraPose> posesMutable = PosesMutable;
			int index = posesMutable.Count - 1;
			if (posesMutable.Count >= 1)
			{
				posesMutable.RemoveAt(index);
			}
		}

		[Token(Token = "0x60015A9")]
		[Address(RVA = "0x3D13878", Offset = "0x3D13878", Length = "0x120")]
		public unsafe void SwapPoses(int indexA, int indexB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPoseCapture::SwapPoses");
		}

		[Token(Token = "0x60015AA")]
		[Address(RVA = "0x3D13998", Offset = "0x3D13998", Length = "0x54")]
		public void Clear()
		{
			List<CameraPose> posesMutable = PosesMutable;
			posesMutable.Clear();
		}

		[Token(Token = "0x60015AB")]
		[Address(RVA = "0x3D139EC", Offset = "0x3D139EC", Length = "0xF0")]
		public CameraPathAsset BuildPath(string pathName, float transitionDuration, CameraEaseType ease)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPoseCapture::BuildPath");
			return default;
		}

		[Token(Token = "0x60015AC")]
		[Address(RVA = "0x3D13ADC", Offset = "0x3D13ADC", Length = "0x8C")]
		public CameraPoseCapture()
		{
			List<CameraPose> poses = new List<CameraPose>();
			_poses = poses;
		}
	}
}
