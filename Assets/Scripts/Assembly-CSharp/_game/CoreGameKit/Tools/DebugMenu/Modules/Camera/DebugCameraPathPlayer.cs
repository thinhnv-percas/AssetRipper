using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.CameraControl;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Token(Token = "0x20005C4")]
	public class DebugCameraPathPlayer
	{
		[Token(Token = "0x40013EC")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ICameraControlService _cameraService;

		[Token(Token = "0x40013ED")]
		[FieldOffset(Offset = "0x18")]
		internal readonly DebugCameraData _data;

		[Token(Token = "0x40013EE")]
		[FieldOffset(Offset = "0x20")]
		private DebugCameraPath _activePath;

		[Token(Token = "0x40013EF")]
		[FieldOffset(Offset = "0x28")]
		private int _activeSegment;

		[Token(Token = "0x17000257")]
		[field: Token(Token = "0x40013F0")]
		[field: FieldOffset(Offset = "0x2C")]
		public bool IsPlaying
		{
			[Token(Token = "0x60018BC")]
			[Address(RVA = "0x3D402A0", Offset = "0x3D402A0", Length = "0x8")]
			get;
			[Token(Token = "0x60018BD")]
			[Address(RVA = "0x3D402A8", Offset = "0x3D402A8", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x60018BE")]
		[Address(RVA = "0x3D3FFF8", Offset = "0x3D3FFF8", Length = "0x50")]
		public DebugCameraPathPlayer(ICameraControlService cameraService, DebugCameraData data)
		{
			_cameraService = cameraService;
			_data = data;
		}

		[Token(Token = "0x60018BF")]
		[Address(RVA = "0x3D38F48", Offset = "0x3D38F48", Length = "0x170")]
		public void Play(DebugCameraPath path)
		{
			if (path != null)
			{
				List<DebugCameraPathSegment> segments = path.Segments;
				if (path.Segments != null && segments.Count != 0)
				{
					if (IsPlaying)
					{
						_cameraService.StopPlayback();
					}
					_activePath = path;
					_activeSegment = -1;
					IsPlaying = true;
					PlayNextSegment();
					return;
				}
			}
			Debug.LogWarning("[DebugCamera] Cannot play path: null or empty");
		}

		[Token(Token = "0x60018C0")]
		[Address(RVA = "0x3D3EB60", Offset = "0x3D3EB60", Length = "0xEC")]
		public void Stop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraPathPlayer::Stop");
		}

		[Token(Token = "0x60018C1")]
		[Address(RVA = "0x3D402B0", Offset = "0x3D402B0", Length = "0x27C")]
		private void PlayNextSegment()
		{
			if (!IsPlaying)
			{
				return;
			}
			DebugCameraPath activePath = _activePath;
			if (_activePath == null)
			{
				return;
			}
			int num = ++_activeSegment;
			List<DebugCameraPathSegment> segments = activePath.Segments;
			if (num < segments.Count)
			{
				DebugCameraPathSegment debugCameraPathSegment = segments[num];
				if (TryFindPreset(debugCameraPathSegment.PresetName, out var preset))
				{
					Action onComplete = PlayNextSegment;
					CameraPose pose = preset.Pose;
					_cameraService.GoToPose(pose, debugCameraPathSegment.Duration, debugCameraPathSegment.Ease, onComplete);
				}
				else
				{
					string message = "[DebugCamera] Preset '" + debugCameraPathSegment.PresetName + "' not found, skipping segment";
					Debug.LogWarning(message);
					PlayNextSegment();
				}
			}
			else
			{
				IsPlaying = false;
				_activePath = null;
			}
		}

		[Token(Token = "0x60018C2")]
		[Address(RVA = "0x3D4052C", Offset = "0x3D4052C", Length = "0x124")]
		private bool TryFindPreset(string name, out DebugCameraPreset preset)
		{
			preset = null;
			preset = null;
			if (!string.IsNullOrEmpty(name))
			{
				DebugCameraData data = _data;
				int num = 0;
				while (true)
				{
					List<DebugCameraPreset> presets = data.Presets;
					if (num >= presets.Count)
					{
						break;
					}
					DebugCameraPreset debugCameraPreset = presets[num];
					if (!(debugCameraPreset.Name == name))
					{
						int num2 = num + 1;
						data = _data;
						bool flag = _data == null;
						bool flag2 = !flag;
						num = num2;
						if (flag2)
						{
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						num = num2;
					}
					DebugCameraData data2 = _data;
					DebugCameraPreset debugCameraPreset2 = data2.Presets[num];
					preset = debugCameraPreset2;
					return true;
				}
			}
			return false;
		}
	}
}
