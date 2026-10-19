using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x200052C")]
	public class CameraPlayback
	{
		[Token(Token = "0x4001171")]
		[FieldOffset(Offset = "0x10")]
		internal CameraPathAsset _path;

		[Token(Token = "0x4001172")]
		[FieldOffset(Offset = "0x18")]
		internal Transform _cameraTransform;

		[Token(Token = "0x4001173")]
		[FieldOffset(Offset = "0x20")]
		internal Camera _camera;

		[Token(Token = "0x4001174")]
		[FieldOffset(Offset = "0x28")]
		private float _elapsedTime;

		[Token(Token = "0x4001175")]
		[FieldOffset(Offset = "0x30")]
		internal Action _onComplete;

		[Token(Token = "0x4001176")]
		[FieldOffset(Offset = "0x38")]
		private CameraPose _goToStart;

		[Token(Token = "0x4001177")]
		[FieldOffset(Offset = "0x58")]
		private CameraPose _goToTarget;

		[Token(Token = "0x4001178")]
		[FieldOffset(Offset = "0x78")]
		private float _goToDuration;

		[Token(Token = "0x4001179")]
		[FieldOffset(Offset = "0x7C")]
		private float _goToElapsed;

		[Token(Token = "0x400117A")]
		[FieldOffset(Offset = "0x80")]
		private CameraEaseType _goToEase;

		[Token(Token = "0x400117B")]
		[FieldOffset(Offset = "0x84")]
		internal bool _isGoingTo;

		[Token(Token = "0x170001F3")]
		[field: Token(Token = "0x400117C")]
		[field: FieldOffset(Offset = "0x85")]
		public bool IsPlaying
		{
			[Token(Token = "0x6001597")]
			[Address(RVA = "0x3D130BC", Offset = "0x3D130BC", Length = "0x8")]
			get;
			[Token(Token = "0x6001598")]
			[Address(RVA = "0x3D130C4", Offset = "0x3D130C4", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x6001599")]
		[Address(RVA = "0x3D130CC", Offset = "0x3D130CC", Length = "0x8")]
		public void SetTarget(Transform cameraTransform)
		{
			_cameraTransform = cameraTransform;
		}

		[Token(Token = "0x600159A")]
		[Address(RVA = "0x3D130D4", Offset = "0x3D130D4", Length = "0x8")]
		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}

		[Token(Token = "0x600159B")]
		[Address(RVA = "0x3D111D8", Offset = "0x3D111D8", Length = "0x260")]
		public void GoTo(CameraPose target, float duration, CameraEaseType ease = CameraEaseType.SmoothStep, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPlayback::GoTo");
		}

		[Token(Token = "0x600159C")]
		[Address(RVA = "0x3D11638", Offset = "0x3D11638", Length = "0x198")]
		public void Play(CameraPathAsset path, Action onComplete = null)
		{
			if (!(path == null))
			{
				int poseCount = path.PoseCount;
				if (poseCount >= 2 && !(_cameraTransform == null))
				{
					if (IsPlaying)
					{
						_isGoingTo = false;
						IsPlaying = false;
						_onComplete = null;
						_path = null;
						if (_onComplete != null)
						{
							_onComplete();
						}
					}
					_path = path;
					_onComplete = onComplete;
					_elapsedTime = 0f;
					_isGoingTo = false;
					IsPlaying = true;
					return;
				}
			}
			onComplete?.Invoke();
		}

		[Token(Token = "0x600159D")]
		[Address(RVA = "0x3D11844", Offset = "0x3D11844", Length = "0x70")]
		public void Stop()
		{
			if (IsPlaying)
			{
				_isGoingTo = false;
				IsPlaying = false;
				_onComplete = null;
				_path = null;
				if (_onComplete != null)
				{
					_onComplete();
				}
			}
		}

		[Token(Token = "0x600159E")]
		[Address(RVA = "0x3D11984", Offset = "0x3D11984", Length = "0xB4")]
		public void Update()
		{
			if (IsPlaying && !(_cameraTransform == null))
			{
				if (_isGoingTo)
				{
					Update();
				}
				else
				{
					Update();
				}
			}
		}

		[Token(Token = "0x600159F")]
		[Address(RVA = "0x3D130DC", Offset = "0x3D130DC", Length = "0x100")]
		private unsafe void UpdateGoTo()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPlayback::UpdateGoTo");
		}

		[Token(Token = "0x60015A0")]
		[Address(RVA = "0x3D131DC", Offset = "0x3D131DC", Length = "0x2F0")]
		private unsafe void UpdatePath()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraPlayback::UpdatePath");
		}

		[Token(Token = "0x60015A1")]
		[Address(RVA = "0x3D134CC", Offset = "0x3D134CC", Length = "0x100")]
		private void ApplyPose(CameraPose pose)
		{
			Vector3 position = default(Vector3);
			position.x = pose.Position.x;
			position.y = pose.Position.y;
			position.z = pose.Position.z;
			_cameraTransform.position = position;
			Quaternion rotation = default(Quaternion);
			rotation.x = pose.Rotation.x;
			rotation.y = pose.Rotation.y;
			rotation.z = pose.Rotation.z;
			rotation.w = pose.Rotation.w;
			_cameraTransform.rotation = rotation;
			if (_camera != null && _camera.orthographic)
			{
				bool flag = pose.OrthographicSize < 0f;
				bool flag2 = pose.OrthographicSize == 0f;
				bool flag3 = pose.OrthographicSize == pose.OrthographicSize;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag5;
				if (!(flag6 || flag2))
				{
					_camera.orthographicSize = pose.OrthographicSize;
				}
			}
		}

		[Token(Token = "0x60015A2")]
		[Address(RVA = "0x3D11B68", Offset = "0x3D11B68", Length = "0x8")]
		public CameraPlayback()
		{
		}
	}
}
