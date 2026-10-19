using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TapHoldSpeedUp
{
	[Token(Token = "0x20003FA")]
	internal static class TapSpeedUpDebugOverride
	{
		[Token(Token = "0x4000CA1")]
		private const string PrefKey = "debug_tap_speedup_multiplier";

		[Token(Token = "0x17000153")]
		public static int Value
		{
			[Token(Token = "0x60010BD")]
			[Address(RVA = "0x3CB77E0", Offset = "0x3CB77E0", Length = "0x4C")]
			get
			{
				return PlayerPrefs.GetInt("debug_tap_speedup_multiplier", 0);
			}
			[Token(Token = "0x60010BE")]
			[Address(RVA = "0x3CB80B0", Offset = "0x3CB80B0", Length = "0x60")]
			set
			{
				int num = ~value;
				int value2 = value & num;
				PlayerPrefs.SetInt("debug_tap_speedup_multiplier", value2);
				PlayerPrefs.Save();
			}
		}

		[Token(Token = "0x17000154")]
		public static bool IsActive
		{
			[Token(Token = "0x60010BF")]
			[Address(RVA = "0x3CB7788", Offset = "0x3CB7788", Length = "0x58")]
			get
			{
				int num = PlayerPrefs.GetInt("debug_tap_speedup_multiplier", 0);
				bool flag = num < 0;
				bool flag2 = num == 0;
				int num2 = num ^ num;
				int num3 = num & num2;
				bool flag3 = num3 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}
	}
}
