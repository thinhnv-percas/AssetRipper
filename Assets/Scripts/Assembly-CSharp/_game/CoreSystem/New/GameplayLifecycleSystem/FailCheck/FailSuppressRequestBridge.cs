using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.CoreSystem.Events;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000425")]
	public class FailSuppressRequestBridge : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000D0F")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _bus;

		[Inject(false)]
		[Token(Token = "0x4000D10")]
		[FieldOffset(Offset = "0x18")]
		private IFailCheckSuppressor _suppressor;

		[Token(Token = "0x4000D11")]
		[FieldOffset(Offset = "0x20")]
		internal readonly Dictionary<string, IDisposable> _handles;

		[Inject(false)]
		[Token(Token = "0x6001156")]
		[Address(RVA = "0x3CBF9C4", Offset = "0x3CBF9C4", Length = "0xA8")]
		public void Initialize()
		{
			Action<UventFailSuppressRequested> observer = OnSuppressRequested;
			_bus.ListenEvent(observer);
		}

		[Token(Token = "0x6001157")]
		[Address(RVA = "0x3CBFA6C", Offset = "0x3CBFA6C", Length = "0x224")]
		private void OnSuppressRequested(UventFailSuppressRequested evt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSuppressRequestBridge::OnSuppressRequested");
		}

		[Token(Token = "0x6001158")]
		[Address(RVA = "0x3CBFC90", Offset = "0x3CBFC90", Length = "0x264")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FailSuppressRequestBridge::Dispose");
		}

		[Token(Token = "0x6001159")]
		[Address(RVA = "0x3CBDE58", Offset = "0x3CBDE58", Length = "0x8C")]
		public FailSuppressRequestBridge()
		{
			Dictionary<string, IDisposable> handles = new Dictionary<string, IDisposable>();
			_handles = handles;
		}
	}
}
