using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x200051F")]
	public class CameraControlService : MonoBehaviour, ICameraControlService
	{
		[Token(Token = "0x4001143")]
		[FieldOffset(Offset = "0x20")]
		private Camera _camera;

		[Token(Token = "0x4001144")]
		[FieldOffset(Offset = "0x28")]
		private readonly CameraMovementHandler _movement;

		[Token(Token = "0x4001145")]
		[FieldOffset(Offset = "0x30")]
		private readonly CameraTrackingHandler _tracking;

		[Token(Token = "0x4001146")]
		[FieldOffset(Offset = "0x38")]
		private readonly CameraPoseCapture _poseCapture;

		[Token(Token = "0x4001147")]
		[FieldOffset(Offset = "0x40")]
		private readonly CameraPlayback _playback;

		[Token(Token = "0x4001148")]
		[FieldOffset(Offset = "0x48")]
		private CameraFlowRunner _flowRunner;

		[Token(Token = "0x170001E7")]
		public CameraFlowRunner FlowRunner
		{
			[Token(Token = "0x6001561")]
			[Address(RVA = "0x3D10C60", Offset = "0x3D10C60", Length = "0x8")]
			get
			{
				return _flowRunner;
			}
		}

		[Token(Token = "0x170001E8")]
		public Camera ControlledCamera
		{
			[Token(Token = "0x6001563")]
			[Address(RVA = "0x3D10C70", Offset = "0x3D10C70", Length = "0x8")]
			get
			{
				return _camera;
			}
		}

		[Token(Token = "0x170001E9")]
		public bool IsOrthographic
		{
			[Token(Token = "0x6001564")]
			[Address(RVA = "0x3D10C78", Offset = "0x3D10C78", Length = "0xBC")]
			get
			{
				CameraMovementHandler movement = _movement;
				bool flag = movement._camera != null;
				if (flag)
				{
					return movement._camera.orthographic;
				}
				return flag;
			}
		}

		[Token(Token = "0x170001EA")]
		public bool IsTracking
		{
			[Token(Token = "0x6001565")]
			[Address(RVA = "0x3D10DEC", Offset = "0x3D10DEC", Length = "0x1C")]
			get
			{
				return _tracking.IsTracking;
			}
		}

		[Token(Token = "0x170001EB")]
		public Transform TrackingTarget
		{
			[Token(Token = "0x6001566")]
			[Address(RVA = "0x3D10E08", Offset = "0x3D10E08", Length = "0x1C")]
			get
			{
				CameraTrackingHandler tracking = _tracking;
				return tracking.Target;
			}
		}

		[Token(Token = "0x170001EC")]
		public IReadOnlyList<CameraPose> CapturedPoses
		{
			[Token(Token = "0x6001567")]
			[Address(RVA = "0x3D10E24", Offset = "0x3D10E24", Length = "0x1C")]
			get
			{
				CameraPoseCapture poseCapture = _poseCapture;
				return poseCapture.PosesMutable;
			}
		}

		[Token(Token = "0x170001ED")]
		public bool IsPlaying
		{
			[Token(Token = "0x6001568")]
			[Address(RVA = "0x3D10E40", Offset = "0x3D10E40", Length = "0x1C")]
			get
			{
				CameraPlayback playback = _playback;
				return playback.IsPlaying;
			}
		}

		[Token(Token = "0x6001562")]
		[Address(RVA = "0x3D10C68", Offset = "0x3D10C68", Length = "0x8")]
		public void SetFlowRunner(CameraFlowRunner runner)
		{
			_flowRunner = runner;
		}

		[Token(Token = "0x6001569")]
		[Address(RVA = "0x3D0F9BC", Offset = "0x3D0F9BC", Length = "0x150")]
		public void SetCamera(Camera camera)
		{
			Camera camera2 = default(Camera);
			_camera = camera2;
			if (!(ControlledCamera == null))
			{
				Transform cameraTransform = ControlledCamera.transform;
				CameraMovementHandler movement = _movement;
				movement._cameraTransform = cameraTransform;
				CameraMovementHandler movement2 = _movement;
				movement2._camera = ControlledCamera;
				CameraTrackingHandler tracking = _tracking;
				tracking._camera = ControlledCamera;
				CameraPoseCapture poseCapture = _poseCapture;
				poseCapture._cameraTransform = cameraTransform;
				CameraPoseCapture poseCapture2 = _poseCapture;
				poseCapture2._camera = ControlledCamera;
				CameraPlayback playback = _playback;
				playback._cameraTransform = cameraTransform;
				CameraPlayback playback2 = _playback;
				playback2._camera = ControlledCamera;
			}
		}

		[Token(Token = "0x600156A")]
		[Address(RVA = "0x3D10E5C", Offset = "0x3D10E5C", Length = "0x34")]
		public void DepthMove(float delta)
		{
			CameraPlayback playback = _playback;
			if (!playback.IsPlaying)
			{
				_movement.DepthMove(delta);
			}
		}

		[Token(Token = "0x600156B")]
		[Address(RVA = "0x3D1107C", Offset = "0x3D1107C", Length = "0x1C")]
		public void EnableTracking()
		{
			bool flag = _tracking.TryAcquireTarget();
		}

		[Token(Token = "0x600156C")]
		[Address(RVA = "0x3D11098", Offset = "0x3D11098", Length = "0x1C")]
		public void DisableTracking()
		{
			_tracking.ClearTarget();
		}

		[Token(Token = "0x600156D")]
		[Address(RVA = "0x3D110B4", Offset = "0x3D110B4", Length = "0x1C")]
		public void SetTrackingTarget(Transform target)
		{
			_tracking.SetTarget(target);
		}

		[Token(Token = "0x600156E")]
		[Address(RVA = "0x3D110D0", Offset = "0x3D110D0", Length = "0x1C")]
		public void CapturePose()
		{
			bool flag = _poseCapture.Capture();
		}

		[Token(Token = "0x600156F")]
		[Address(RVA = "0x3D110EC", Offset = "0x3D110EC", Length = "0x1C")]
		public void RemoveLastPose()
		{
			_poseCapture.RemoveLast();
		}

		[Token(Token = "0x6001570")]
		[Address(RVA = "0x3D11108", Offset = "0x3D11108", Length = "0x1C")]
		public void SwapPoses(int indexA, int indexB)
		{
			_poseCapture.SwapPoses(indexA, indexB);
		}

		[Token(Token = "0x6001571")]
		[Address(RVA = "0x3D11124", Offset = "0x3D11124", Length = "0x1C")]
		public void ClearPoses()
		{
			_poseCapture.Clear();
		}

		[Token(Token = "0x6001572")]
		[Address(RVA = "0x3D11140", Offset = "0x3D11140", Length = "0x1C")]
		public CameraPathAsset BuildPath(string pathName, float transitionDuration, CameraEaseType ease)
		{
			return _poseCapture.BuildPath(pathName, transitionDuration, ease);
		}

		[Token(Token = "0x6001573")]
		[Address(RVA = "0x3D1115C", Offset = "0x3D1115C", Length = "0x7C")]
		public unsafe void GoToPose(CameraPose pose, float duration, CameraEaseType ease = CameraEaseType.SmoothStep, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraControlService::GoToPose");
		}

		[Token(Token = "0x6001574")]
		[Address(RVA = "0x3D11438", Offset = "0x3D11438", Length = "0x1B0")]
		public unsafe void GoToPose(int capturedPoseIndex, float duration, CameraEaseType ease = CameraEaseType.SmoothStep, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraControlService::GoToPose");
		}

		[Token(Token = "0x6001575")]
		[Address(RVA = "0x3D115E8", Offset = "0x3D115E8", Length = "0x50")]
		public void PlayPath(CameraPathAsset path, Action onComplete = null)
		{
			_tracking.ClearTarget();
			_playback.Play(path, onComplete);
		}

		[Token(Token = "0x6001576")]
		[Address(RVA = "0x3D117D0", Offset = "0x3D117D0", Length = "0x74")]
		public void StopPlayback()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraControlService::StopPlayback");
		}

		[Token(Token = "0x6001577")]
		[Address(RVA = "0x3D118B4", Offset = "0x3D118B4", Length = "0xD0")]
		private void Update()
		{
			_tracking.UpdateFollow();
			CameraPlayback playback = _playback;
			if (playback.IsPlaying && !(playback._cameraTransform == null))
			{
				if (playback._isGoingTo)
				{
					playback.Update();
				}
				else
				{
					playback.Update();
				}
			}
		}

		[Token(Token = "0x6001578")]
		[Address(RVA = "0x3D11A38", Offset = "0x3D11A38", Length = "0x128")]
		public CameraControlService()
		{
			CameraMovementHandler movement = new CameraMovementHandler();
			_movement = movement;
			CameraTrackingHandler tracking = new CameraTrackingHandler();
			_tracking = tracking;
			CameraPoseCapture poseCapture = new CameraPoseCapture();
			_poseCapture = poseCapture;
			CameraPlayback playback = new CameraPlayback();
			_playback = playback;
		}
	}
}
