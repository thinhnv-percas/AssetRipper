using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.Events;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000422")]
	public class FailGraceTimer
	{
		[Token(Token = "0x4000D00")]
		public const float GraceDuration = 4f;

		[Inject(false)]
		[Token(Token = "0x4000D01")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _bus;

		[Inject(false)]
		[Token(Token = "0x4000D02")]
		[FieldOffset(Offset = "0x18")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x4000D03")]
		[FieldOffset(Offset = "0x20")]
		internal float _elapsed;

		[Token(Token = "0x4000D04")]
		[FieldOffset(Offset = "0x24")]
		private bool _running;

		[Token(Token = "0x4000D05")]
		[FieldOffset(Offset = "0x28")]
		private IDisposable _inputBlockHandle;

		[Token(Token = "0x1700015F")]
		public bool HasExpired
		{
			[Token(Token = "0x6001148")]
			[Address(RVA = "0x3CBE8B0", Offset = "0x3CBE8B0", Length = "0x28")]
			get
			{
				if (IsRunning)
				{
					bool flag = _elapsed < 4f;
					bool flag2 = _elapsed == _elapsed;
					bool flag3 = 4f == 4f;
					bool flag4 = flag2 && flag3;
					bool flag5 = !flag4;
					return flag == flag5;
				}
				return false;
			}
		}

		[Token(Token = "0x17000160")]
		public bool IsRunning
		{
			[Token(Token = "0x6001149")]
			[Address(RVA = "0x3CBECC8", Offset = "0x3CBECC8", Length = "0x8")]
			get
			{
				return _running;
			}
		}

		[Token(Token = "0x17000161")]
		public float Remaining
		{
			[Token(Token = "0x600114A")]
			[Address(RVA = "0x3CBECD0", Offset = "0x3CBECD0", Length = "0x1C")]
			get
			{
				float result = 4f - _elapsed;
				if (4f < _elapsed)
				{
					result = 0f;
				}
				return result;
			}
		}

		[Token(Token = "0x600114B")]
		[Address(RVA = "0x3CBE86C", Offset = "0x3CBE86C", Length = "0x44")]
		public void Tick(float dt)
		{
			if (!IsRunning)
			{
				Start();
			}
			float elapsed = _elapsed + dt;
			_elapsed = elapsed;
		}

		[Token(Token = "0x600114C")]
		[Address(RVA = "0x3CBE580", Offset = "0x3CBE580", Length = "0x34")]
		public void Reset()
		{
			if (IsRunning)
			{
				Stop();
			}
			_elapsed = 0f;
		}

		[Token(Token = "0x600114D")]
		[Address(RVA = "0x3CBECEC", Offset = "0x3CBECEC", Length = "0xA0")]
		internal void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailGraceTimer::Start");
		}

		[Token(Token = "0x600114E")]
		[Address(RVA = "0x3CBED8C", Offset = "0x3CBED8C", Length = "0xEC")]
		internal void Stop()
		{
			_running = false;
			if (_inputBlockHandle != null)
			{
				_inputBlockHandle.Dispose();
			}
			_inputBlockHandle = null;
			_bus.InvokeEvent(default(UventGraceCountdownChanged));
		}

		[Token(Token = "0x600114F")]
		[Address(RVA = "0x3CBDABC", Offset = "0x3CBDABC", Length = "0x8")]
		public FailGraceTimer()
		{
		}
	}
}
