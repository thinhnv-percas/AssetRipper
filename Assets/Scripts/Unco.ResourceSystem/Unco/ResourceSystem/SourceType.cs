using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000016")]
	public class SourceType
	{
		[Token(Token = "0x4000033")]
		public const string GodMode = "GodMode";

		[Token(Token = "0x4000034")]
		public const string Default = "Default";

		[Token(Token = "0x4000035")]
		public const string Quest = "Quest";

		[Token(Token = "0x4000036")]
		public const string DailyReward = "DailyReward";

		[Token(Token = "0x4000037")]
		public const string Purchase = "Purchase";

		[Token(Token = "0x4000038")]
		public const string Achievement = "Achievement";

		[Token(Token = "0x4000039")]
		public const string LevelUp = "LevelUp";

		[Token(Token = "0x400003A")]
		public const string Chest = "Chest";

		[Token(Token = "0x400003B")]
		public const string Battle = "Battle";

		[Token(Token = "0x400003C")]
		public const string Event = "Event";

		[Token(Token = "0x400003D")]
		public const string LevelWin = "level_complete";

		[Token(Token = "0x400003E")]
		public const string Shop = "Shop";

		[Token(Token = "0x400003F")]
		public const string RestorePurchase = "RestorePurchase";

		[Token(Token = "0x4000040")]
		public const string Undefined = "Undefined";

		[Token(Token = "0x4000041")]
		public const string RewardedLevelWin = "RewardedLevelWin";

		[Token(Token = "0x4000042")]
		public const string KeepPlaying = "KeepPlaying";

		[Token(Token = "0x4000043")]
		public const string IAPShop = "IAPShop";

		[Token(Token = "0x4000044")]
		public const string Booster = "Booster";

		[Token(Token = "0x4000045")]
		public const string Flow = "Flow";

		[Token(Token = "0x4000046")]
		public const string Offline = "Offline";

		[Token(Token = "0x4000047")]
		public const string RefillHeart = "RefillHeart";

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x81D26EC", Offset = "0x81D26EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SourceType()
		{
		}
	}
}
