using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.New.LevelGeneratorSystem.PlayReport;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E0")]
	public sealed class PathPlaybackController : IRequireUpdateCall, IDisposable
	{
		[Token(Token = "0x4000C38")]
		private const float AutoMaxIntervalSeconds = 5f;

		[Token(Token = "0x4000C39")]
		private const float AutoMinSettleSeconds = 1f;

		[Inject(false)]
		[Token(Token = "0x4000C3A")]
		[FieldOffset(Offset = "0x10")]
		private PlayTestRecorder _recorder;

		[Inject(false)]
		[Token(Token = "0x4000C3B")]
		[FieldOffset(Offset = "0x18")]
		private ConveyorSettleProbe _probe;

		[Inject(true)]
		[Token(Token = "0x4000C3C")]
		[FieldOffset(Offset = "0x20")]
		private InputBlockService _inputBlock;

		[Token(Token = "0x4000C3D")]
		[FieldOffset(Offset = "0x28")]
		private PathPlaybackOverlay _overlay;

		[Token(Token = "0x4000C3E")]
		[FieldOffset(Offset = "0x30")]
		private IDisposable _tapBlock;

		[Token(Token = "0x4000C3F")]
		[FieldOffset(Offset = "0x38")]
		private bool _auto;

		[Token(Token = "0x4000C40")]
		[FieldOffset(Offset = "0x39")]
		private bool _anyStepFired;

		[Token(Token = "0x4000C41")]
		[FieldOffset(Offset = "0x3C")]
		private float _sinceLastStepUnscaled;

		[Inject(false)]
		[Token(Token = "0x600104E")]
		[Address(RVA = "0x3CB1270", Offset = "0x3CB1270", Length = "0x258")]
		public void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathPlaybackController::Construct");
		}

		[Token(Token = "0x600104F")]
		[Address(RVA = "0x3CB14C8", Offset = "0x3CB14C8", Length = "0x128")]
		public void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathPlaybackController::Update");
		}

		[Token(Token = "0x6001050")]
		[Address(RVA = "0x3CB1610", Offset = "0x3CB1610", Length = "0x5C")]
		private void StepOnce()
		{
			PlayTestRecorder recorder = _recorder;
			if (!recorder._finished && recorder._seq != null && recorder._seq.HasNext)
			{
				_recorder.FireStep();
				_anyStepFired = true;
				_sinceLastStepUnscaled = 0f;
			}
		}

		[Token(Token = "0x6001051")]
		[Address(RVA = "0x3CB18DC", Offset = "0x3CB18DC", Length = "0x190")]
		private string BuildStatus()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathPlaybackController::BuildStatus");
			return default;
		}

		[Token(Token = "0x6001052")]
		[Address(RVA = "0x3CB1B44", Offset = "0x3CB1B44", Length = "0x15C")]
		public void Dispose()
		{
			if (_tapBlock != null)
			{
				_tapBlock.Dispose();
			}
			_tapBlock = null;
			if (_overlay != null)
			{
				GameObject gameObject = _overlay.gameObject;
				UnityEngine.Object.Destroy(gameObject);
			}
			_overlay = null;
		}

		[Token(Token = "0x6001053")]
		[Address(RVA = "0x3CB1CA0", Offset = "0x3CB1CA0", Length = "0x8")]
		public PathPlaybackController()
		{
		}
	}
}
