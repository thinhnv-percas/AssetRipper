using Cpp2ILInjected;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x2000583")]
	public enum TrackingKey
	{
		[Token(Token = "0x40012F3")]
		level_started = 0,
		[Token(Token = "0x40012F4")]
		level_completed = 1,
		[Token(Token = "0x40012F5")]
		level_failed = 2,
		[Token(Token = "0x40012F6")]
		shop_item_purchased = 3,
		[Token(Token = "0x40012F7")]
		level_refresh = 4,
		[Token(Token = "0x40012F8")]
		level_leave = 5,
		[Token(Token = "0x40012F9")]
		ui_show = 6,
		[Token(Token = "0x40012FA")]
		ui_hide = 7,
		[Token(Token = "0x40012FB")]
		keep_playing_clicked = 10,
		[Token(Token = "0x40012FC")]
		keep_playing_purchased = 11,
		[Token(Token = "0x40012FD")]
		keep_playing_cantafford = 12,
		[Token(Token = "0x40012FE")]
		keep_playing_giveup = 13,
		[Token(Token = "0x40012FF")]
		iap_item_purchased = 20,
		[Token(Token = "0x4001300")]
		iap_item_failed = 21,
		[Token(Token = "0x4001301")]
		iap_item_tapped = 22,
		[Token(Token = "0x4001302")]
		health_changed = 50,
		[Token(Token = "0x4001303")]
		health_lost = 51,
		[Token(Token = "0x4001304")]
		health_infinite_changed = 52,
		[Token(Token = "0x4001305")]
		heartrefill_clicked = 60,
		[Token(Token = "0x4001306")]
		heartrefill_purchased = 61,
		[Token(Token = "0x4001307")]
		heartrefill_cantafford = 62,
		[Token(Token = "0x4001308")]
		booster_used = 70,
		[Token(Token = "0x4001309")]
		booster_purchased = 71,
		[Token(Token = "0x400130A")]
		iap_store_not_initialized = 23,
		[Token(Token = "0x400130B")]
		iap_store_product_not_found = 24,
		[Token(Token = "0x400130C")]
		iap_store_opened = 100,
		[Token(Token = "0x400130D")]
		offer_shown = 101,
		[Token(Token = "0x400130E")]
		offer_accepted = 102,
		[Token(Token = "0x400130F")]
		offer_rejected = 103
	}
}
