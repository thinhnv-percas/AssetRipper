using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.AdSystem;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.ElephantStorage;

namespace _game.Systems.MonetizationCore
{
	[Token(Token = "0x200076B")]
	public class BannerAdService
	{
		[Inject(false)]
		[Token(Token = "0x40018BD")]
		[FieldOffset(Offset = "0x10")]
		private IAdManager _adManager;

		[Inject(false)]
		[Token(Token = "0x40018BE")]
		[FieldOffset(Offset = "0x18")]
		private ILevelProgressService _levelProgressService;

		[Inject(false)]
		[Token(Token = "0x40018BF")]
		[FieldOffset(Offset = "0x20")]
		private MonetizationStorageData _monetizationData;

		[Inject(false)]
		[Token(Token = "0x40018C0")]
		[FieldOffset(Offset = "0x28")]
		private IPlayerDataHandler _dataHandler;

		[Token(Token = "0x40018C1")]
		[FieldOffset(Offset = "0x30")]
		internal readonly InterstitialConfig _config;

		[Token(Token = "0x40018C2")]
		[FieldOffset(Offset = "0x38")]
		private bool _isBannerVisible;

		[Token(Token = "0x6001F43")]
		[Address(RVA = "0x3D8D960", Offset = "0x3D8D960", Length = "0x34")]
		public BannerAdService(InterstitialConfig config)
		{
			_config = config;
		}

		[Inject(false)]
		[Token(Token = "0x6001F44")]
		[Address(RVA = "0x3D8D994", Offset = "0x3D8D994", Length = "0x14C")]
		private void Inject()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			if (monetizationData.BannerFirstInstallDay == 0)
			{
				DateTime utcNow = DateTime.UtcNow;
				DateTime dateTime = utcNow;
				int year = dateTime.Year;
				int dayOfYear = dateTime.DayOfYear;
				int num = year * 1000;
				int bannerFirstInstallDay = dayOfYear + num;
				monetizationData.BannerFirstInstallDay = bannerFirstInstallDay;
				_dataHandler.Save();
			}
		}

		[Token(Token = "0x6001F45")]
		[Address(RVA = "0x3D8DB68", Offset = "0x3D8DB68", Length = "0xC8")]
		public void TryShow()
		{
			if (!_isBannerVisible && IsEligible())
			{
				_adManager.ShowBanner();
				_isBannerVisible = true;
			}
		}

		[Token(Token = "0x6001F46")]
		[Address(RVA = "0x3D8DD1C", Offset = "0x3D8DD1C", Length = "0xBC")]
		public void Hide()
		{
			if (_isBannerVisible)
			{
				_adManager.HideBanner();
				_isBannerVisible = false;
			}
		}

		[Token(Token = "0x6001F47")]
		[Address(RVA = "0x3D8DC30", Offset = "0x3D8DC30", Length = "0xEC")]
		private bool IsEligible()
		{
			InterstitialConfig config = _config;
			if (config.noBanner)
			{
				return false;
			}
			if (IsAdFreeDay())
			{
				return false;
			}
			bool flag = _adManager.IsNoAdsPurchased();
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}

		[Token(Token = "0x6001F48")]
		[Address(RVA = "0x3D8DDD8", Offset = "0x3D8DDD8", Length = "0xC0")]
		private bool IsAdFreeDay()
		{
			MonetizationStorageData monetizationData = _monetizationData;
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = utcNow;
			int year = dateTime.Year;
			int dayOfYear = dateTime.DayOfYear;
			InterstitialConfig config = _config;
			int num = year * 1000;
			int num2 = num - monetizationData.BannerFirstInstallDay;
			int num3 = num2 + dayOfYear;
			int num4 = num3 - config.firstDayToDisplayBanner;
			bool flag = num4 < 0;
			int num5 = num3 ^ config.firstDayToDisplayBanner;
			int num6 = num3 ^ num4;
			int num7 = num5 & num6;
			bool flag2 = num7 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x6001F49")]
		[Address(RVA = "0x3D8DAE0", Offset = "0x3D8DAE0", Length = "0x88")]
		private static int GetCurrentDay()
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = utcNow;
			int year = dateTime.Year;
			int dayOfYear = dateTime.DayOfYear;
			int num = year * 1000;
			return dayOfYear + num;
		}
	}
}
