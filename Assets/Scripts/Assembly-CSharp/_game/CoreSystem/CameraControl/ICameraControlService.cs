using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000533")]
	public interface ICameraControlService
	{
		[Token(Token = "0x170001FC")]
		bool IsOrthographic
		{
			[Token(Token = "0x60015BF")]
			get;
		}

		[Token(Token = "0x170001FD")]
		bool IsTracking
		{
			[Token(Token = "0x60015C1")]
			get;
		}

		[Token(Token = "0x170001FE")]
		Transform TrackingTarget
		{
			[Token(Token = "0x60015C2")]
			get;
		}

		[Token(Token = "0x170001FF")]
		IReadOnlyList<CameraPose> CapturedPoses
		{
			[Token(Token = "0x60015C6")]
			get;
		}

		[Token(Token = "0x17000200")]
		bool IsPlaying
		{
			[Token(Token = "0x60015CC")]
			get;
		}

		[Token(Token = "0x17000201")]
		Camera ControlledCamera
		{
			[Token(Token = "0x60015D1")]
			get;
		}

		[Token(Token = "0x60015C0")]
		void DepthMove(float speed);

		[Token(Token = "0x60015C3")]
		void EnableTracking();

		[Token(Token = "0x60015C4")]
		void DisableTracking();

		[Token(Token = "0x60015C5")]
		void SetTrackingTarget(Transform target);

		[Token(Token = "0x60015C7")]
		void CapturePose();

		[Token(Token = "0x60015C8")]
		void RemoveLastPose();

		[Token(Token = "0x60015C9")]
		void SwapPoses(int indexA, int indexB);

		[Token(Token = "0x60015CA")]
		void ClearPoses();

		[Token(Token = "0x60015CB")]
		CameraPathAsset BuildPath(string pathName, float transitionDuration, CameraEaseType ease);

		[Token(Token = "0x60015CD")]
		void GoToPose(CameraPose pose, float duration, CameraEaseType ease = CameraEaseType.SmoothStep, Action onComplete = null);

		[Token(Token = "0x60015CE")]
		void GoToPose(int capturedPoseIndex, float duration, CameraEaseType ease = CameraEaseType.SmoothStep, Action onComplete = null);

		[Token(Token = "0x60015CF")]
		void PlayPath(CameraPathAsset path, Action onComplete = null);

		[Token(Token = "0x60015D0")]
		void StopPlayback();

		[Token(Token = "0x60015D2")]
		void SetCamera(Camera camera);
	}
}
