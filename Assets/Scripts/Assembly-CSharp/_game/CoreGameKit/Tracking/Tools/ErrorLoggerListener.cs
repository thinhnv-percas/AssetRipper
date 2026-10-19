using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.Utils;

namespace _game.CoreGameKit.Tracking.Tools
{
	[Serializable]
	[Token(Token = "0x2000590")]
	public class ErrorLoggerListener : ITracker
	{
		[Token(Token = "0x4001334")]
		[FieldOffset(Offset = "0x10")]
		private TrackingRouter _router;

		[Token(Token = "0x4001335")]
		[FieldOffset(Offset = "0x18")]
		private bool _isConnected;

		[Token(Token = "0x6001799")]
		[Address(RVA = "0x3D2E888", Offset = "0x3D2E888", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new ErrorLoggerListener();
		}

		[Token(Token = "0x600179A")]
		[Address(RVA = "0x3D2E8E8", Offset = "0x3D2E8E8", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Token(Token = "0x600179B")]
		[Address(RVA = "0x3D2E8F0", Offset = "0x3D2E8F0", Length = "0x114")]
		public void BeginTracking()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLoggerListener::BeginTracking");
		}

		[Token(Token = "0x600179C")]
		[Address(RVA = "0x3D2EB48", Offset = "0x3D2EB48", Length = "0x114")]
		public void EndTracking()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLoggerListener::EndTracking");
		}

		[Token(Token = "0x600179D")]
		[Address(RVA = "0x3D2EA04", Offset = "0x3D2EA04", Length = "0x144")]
		private unsafe void SendCachedErrors()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLoggerListener::SendCachedErrors");
		}

		[Token(Token = "0x600179E")]
		[Address(RVA = "0x3D2EFD4", Offset = "0x3D2EFD4", Length = "0x4")]
		private void OnErrorLogged(ErrorLogEntry error)
		{
			SendErrorToTracking(error);
		}

		[Token(Token = "0x600179F")]
		[Address(RVA = "0x3D2EC5C", Offset = "0x3D2EC5C", Length = "0x378")]
		private void SendErrorToTracking(ErrorLogEntry error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ErrorLoggerListener::SendErrorToTracking");
		}

		[Token(Token = "0x60017A0")]
		[Address(RVA = "0x3D2E8E0", Offset = "0x3D2E8E0", Length = "0x8")]
		public ErrorLoggerListener()
		{
		}
	}
}
