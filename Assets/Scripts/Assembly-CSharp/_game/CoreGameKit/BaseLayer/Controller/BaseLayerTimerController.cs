using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TimeTaskSystem.Runtime;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Token(Token = "0x20006BF")]
	public class BaseLayerTimerController : IDisposable
	{
		[CompilerGenerated]
		[Token(Token = "0x40016D0")]
		[FieldOffset(Offset = "0x10")]
		private Action<float> OnTimeAdded;

		[Token(Token = "0x40016D1")]
		[FieldOffset(Offset = "0x18")]
		private ITimeTaskController _timeTaskController;

		[Token(Token = "0x40016D2")]
		[FieldOffset(Offset = "0x20")]
		internal TimerHandle _baseLayerTimer;

		[Token(Token = "0x40016D3")]
		[FieldOffset(Offset = "0x30")]
		internal float _duration;

		[Token(Token = "0x40016D4")]
		[FieldOffset(Offset = "0x34")]
		internal int _pauserCount;

		[CompilerGenerated]
		[Token(Token = "0x6001C98")]
		[Address(RVA = "0x3D70130", Offset = "0x3D70130", Length = "0xB4")]
		public void add_OnTimeAdded(Action<float> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::add_OnTimeAdded");
		}

		[CompilerGenerated]
		[Token(Token = "0x6001C99")]
		[Address(RVA = "0x3D701E4", Offset = "0x3D701E4", Length = "0xB4")]
		public void remove_OnTimeAdded(Action<float> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::remove_OnTimeAdded");
		}

		[Token(Token = "0x6001C9A")]
		[Address(RVA = "0x3D70298", Offset = "0x3D70298", Length = "0x34")]
		public BaseLayerTimerController(float duration)
		{
			_duration = duration;
		}

		[Inject(false)]
		[Token(Token = "0x6001C9B")]
		[Address(RVA = "0x3D702CC", Offset = "0x3D702CC", Length = "0x244")]
		public void Initialize(ITimeTaskController timeTaskController, ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::Initialize");
		}

		[Token(Token = "0x6001C9C")]
		[Address(RVA = "0x3D70568", Offset = "0x3D70568", Length = "0x20")]
		public float GetElapsedTime()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::GetElapsedTime");
			return default;
		}

		[Token(Token = "0x6001C9D")]
		[Address(RVA = "0x3D70588", Offset = "0x3D70588", Length = "0x8")]
		public float GetTotalTime()
		{
			return _duration;
		}

		[Token(Token = "0x6001C9E")]
		[Address(RVA = "0x3D70590", Offset = "0x3D70590", Length = "0x68")]
		public void AddTime(float timeToAdd)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::AddTime");
		}

		[Token(Token = "0x6001C9F")]
		[Address(RVA = "0x3D70510", Offset = "0x3D70510", Length = "0x58")]
		public void Pause()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::Pause");
		}

		[Token(Token = "0x6001CA0")]
		[Address(RVA = "0x3D705F8", Offset = "0x3D705F8", Length = "0x2C")]
		public void Resume()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::Resume");
		}

		[Token(Token = "0x6001CA1")]
		[Address(RVA = "0x3D70624", Offset = "0x3D70624", Length = "0x20")]
		public void AddListener(OnTimerUpdate onTimerUpdate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::AddListener");
		}

		[Token(Token = "0x6001CA2")]
		[Address(RVA = "0x3D70644", Offset = "0x3D70644", Length = "0x20")]
		public void RemoveListener(OnTimerUpdate onTimerUpdate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::RemoveListener");
		}

		[Token(Token = "0x6001CA3")]
		[Address(RVA = "0x3D70664", Offset = "0x3D70664", Length = "0x1C")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerTimerController::Dispose");
		}
	}
}
