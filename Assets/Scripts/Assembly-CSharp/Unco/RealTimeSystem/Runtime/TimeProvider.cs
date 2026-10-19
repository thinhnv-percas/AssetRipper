using System;
using Cpp2ILInjected;

namespace Unco.RealTimeSystem.Runtime
{
	[Token(Token = "0x20007F7")]
	public static class TimeProvider
	{
		[Token(Token = "0x4001A87")]
		internal static Func<DateTime> _utcNowOverride;

		[Token(Token = "0x1700034D")]
		public static DateTime UtcNow
		{
			[Token(Token = "0x60021B2")]
			[Address(RVA = "0x3DC76E8", Offset = "0x3DC76E8", Length = "0xA0")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TimeProvider::get_UtcNow");
				return default;
			}
		}

		[Token(Token = "0x60021B3")]
		[Address(RVA = "0x3DC8F08", Offset = "0x3DC8F08", Length = "0x5C")]
		public static void SetOverride(Func<DateTime> utcNowFunc)
		{
			_utcNowOverride = utcNowFunc;
		}

		[Token(Token = "0x60021B4")]
		[Address(RVA = "0x3DC8F64", Offset = "0x3DC8F64", Length = "0x50")]
		public static void ClearOverride()
		{
			_utcNowOverride = null;
		}
	}
}
