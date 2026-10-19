using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.Services.Interface;
using _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x200041D")]
	public class FailCheckBehavior : IStateBehavior, IDisposable
	{
		[Token(Token = "0x4000CF1")]
		private const float CheckInterval = 0.5f;

		[Inject(false)]
		[Token(Token = "0x4000CF2")]
		[FieldOffset(Offset = "0x10")]
		private IFailCheckSuppressor _suppressor;

		[Inject(false)]
		[Token(Token = "0x4000CF3")]
		[FieldOffset(Offset = "0x18")]
		private FailDetector _detector;

		[Inject(false)]
		[Token(Token = "0x4000CF4")]
		[FieldOffset(Offset = "0x20")]
		private WinDetector _winDetector;

		[Inject(false)]
		[Token(Token = "0x4000CF5")]
		[FieldOffset(Offset = "0x28")]
		private FailGraceTimer _grace;

		[Inject(false)]
		[Token(Token = "0x4000CF6")]
		[FieldOffset(Offset = "0x30")]
		private IBaseLayerFailService _failService;

		[Token(Token = "0x4000CF7")]
		[FieldOffset(Offset = "0x38")]
		private bool _failed;

		[Token(Token = "0x4000CF8")]
		[FieldOffset(Offset = "0x3C")]
		private float _checkAccumulator;

		[Token(Token = "0x6001136")]
		[Address(RVA = "0x3CBE53C", Offset = "0x3CBE53C", Length = "0x44")]
		public void OnStateEnter()
		{
			_failed = false;
			_checkAccumulator = 0f;
			FailGraceTimer grace = _grace;
			if (grace.IsRunning)
			{
				grace.Stop();
			}
			grace._elapsed = 0f;
		}

		[Token(Token = "0x6001137")]
		[Address(RVA = "0x3CBE5B4", Offset = "0x3CBE5B4", Length = "0x3C")]
		public void OnStateExit()
		{
			FailGraceTimer grace = _grace;
			if (grace.IsRunning)
			{
				grace.Stop();
			}
			grace._elapsed = 0f;
		}

		[Token(Token = "0x6001138")]
		[Address(RVA = "0x3CBE5F0", Offset = "0x3CBE5F0", Length = "0x248")]
		public void OnStateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailCheckBehavior::OnStateUpdate");
		}

		[Token(Token = "0x6001139")]
		[Address(RVA = "0x3CBE8D8", Offset = "0x3CBE8D8", Length = "0x3C")]
		public void Dispose()
		{
			FailGraceTimer grace = _grace;
			if (grace.IsRunning)
			{
				grace.Stop();
			}
			grace._elapsed = 0f;
		}

		[Token(Token = "0x600113A")]
		[Address(RVA = "0x3CBDCCC", Offset = "0x3CBDCCC", Length = "0x8")]
		public FailCheckBehavior()
		{
		}
	}
}
