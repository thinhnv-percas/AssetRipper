using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TimeTaskSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Token(Token = "0x20006E5")]
	public class TimerFailBehavior : IStateBehavior
	{
		[Token(Token = "0x4001712")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerTimerController _timerController;

		[Token(Token = "0x4001713")]
		[FieldOffset(Offset = "0x18")]
		private IBaseLayerFailService _failService;

		[Inject(false)]
		[Token(Token = "0x6001D10")]
		[Address(RVA = "0x3D73440", Offset = "0x3D73440", Length = "0x34")]
		public void Initialize(BaseLayerTimerController timerController, IBaseLayerFailService failService)
		{
			_timerController = timerController;
			_failService = failService;
		}

		[Token(Token = "0x6001D11")]
		[Address(RVA = "0x3D73474", Offset = "0x3D73474", Length = "0xAC")]
		public void OnStateEnter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerFailBehavior::OnStateEnter");
		}

		[Token(Token = "0x6001D12")]
		[Address(RVA = "0x3D73520", Offset = "0x3D73520", Length = "0xAC")]
		public void OnStateExit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerFailBehavior::OnStateExit");
		}

		[Token(Token = "0x6001D13")]
		[Address(RVA = "0x3D735CC", Offset = "0x3D735CC", Length = "0xE0")]
		private void OnTimerUpdate(float elapsed, float duration)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerFailBehavior::OnTimerUpdate");
		}

		[Token(Token = "0x6001D14")]
		[Address(RVA = "0x3D736AC", Offset = "0x3D736AC", Length = "0x8")]
		public TimerFailBehavior()
		{
		}
	}
}
