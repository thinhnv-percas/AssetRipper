using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreSystem;
using _game.CoreSystem.Events;

namespace _game.CoreGameKit.Tracking.Trackers
{
	[Serializable]
	[Token(Token = "0x2000589")]
	public class MoveTracker : ITracker
	{
		[Inject(false)]
		[Token(Token = "0x4001323")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Token(Token = "0x4001324")]
		[FieldOffset(Offset = "0x18")]
		private TrackingRouter _router;

		[Token(Token = "0x6001768")]
		[Address(RVA = "0x3D2BF4C", Offset = "0x3D2BF4C", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new MoveTracker();
		}

		[Token(Token = "0x6001769")]
		[Address(RVA = "0x3D2BFAC", Offset = "0x3D2BFAC", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x600176A")]
		[Address(RVA = "0x3D2BFB4", Offset = "0x3D2BFB4", Length = "0xA8")]
		public void BeginTracking()
		{
			Action<UMoveCompleted> observer = OnMoveCompleted;
			_eventBus.ListenEvent(observer);
		}

		[Token(Token = "0x600176B")]
		[Address(RVA = "0x3D2C05C", Offset = "0x3D2C05C", Length = "0xA8")]
		public void EndTracking()
		{
			Action<UMoveCompleted> observer = OnMoveCompleted;
			_eventBus.RemoveListener(observer);
		}

		[Token(Token = "0x600176C")]
		[Address(RVA = "0x3D2C104", Offset = "0x3D2C104", Length = "0xA8")]
		private void OnMoveCompleted(UMoveCompleted evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoveTracker::OnMoveCompleted");
		}

		[Token(Token = "0x600176D")]
		[Address(RVA = "0x3D2BFA4", Offset = "0x3D2BFA4", Length = "0x8")]
		public MoveTracker()
		{
		}
	}
}
