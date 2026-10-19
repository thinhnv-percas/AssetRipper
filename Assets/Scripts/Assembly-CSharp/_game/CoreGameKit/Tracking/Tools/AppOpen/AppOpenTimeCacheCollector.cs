using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.Utils;

namespace _game.CoreGameKit.Tracking.Tools.AppOpen
{
	[Token(Token = "0x2000598")]
	public class AppOpenTimeCacheCollector
	{
		[Token(Token = "0x4001344")]
		[FieldOffset(Offset = "0x10")]
		private TrackingManager _trackingManager;

		[Token(Token = "0x4001345")]
		[FieldOffset(Offset = "0x18")]
		private IEnumerable<AppOpenTimeCache> _appOpenTimeLoggers;

		[Inject(false)]
		[Token(Token = "0x60017BE")]
		[Address(RVA = "0x3D3071C", Offset = "0x3D3071C", Length = "0x3C")]
		private void Inject(TrackingManager trackingManager, IEnumerable<AppOpenTimeCache> appOpenTimeLoggers)
		{
			_trackingManager = trackingManager;
			_appOpenTimeLoggers = appOpenTimeLoggers;
			SendAllEvents();
		}

		[Token(Token = "0x60017BF")]
		[Address(RVA = "0x3D30758", Offset = "0x3D30758", Length = "0x358")]
		private void SendAllEvents()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AppOpenTimeCacheCollector::SendAllEvents");
		}

		[Token(Token = "0x60017C0")]
		[Address(RVA = "0x3D30AB0", Offset = "0x3D30AB0", Length = "0x8")]
		public AppOpenTimeCacheCollector()
		{
		}
	}
}
