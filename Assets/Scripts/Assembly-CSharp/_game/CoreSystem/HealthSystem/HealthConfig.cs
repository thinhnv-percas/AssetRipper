using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.HealthSystem
{
	[Serializable]
	[Token(Token = "0x20004D1")]
	public class HealthConfig
	{
		[Token(Token = "0x4001024")]
		[FieldOffset(Offset = "0x10")]
		public int MaxHealth;

		[Token(Token = "0x4001025")]
		[FieldOffset(Offset = "0x14")]
		public float RegenDuration;

		[Token(Token = "0x4001026")]
		[FieldOffset(Offset = "0x18")]
		public float MaxInfiniteDuration;

		[Token(Token = "0x4001027")]
		[FieldOffset(Offset = "0x1C")]
		public int DisableHealthUntilLevel;

		[Token(Token = "0x4001028")]
		[FieldOffset(Offset = "0x20")]
		public int HeartRequiredToPlay;

		[Token(Token = "0x4001029")]
		[FieldOffset(Offset = "0x24")]
		public float InitialInfiniteHeartTimeInMinutes;

		[Token(Token = "0x6001459")]
		[Address(RVA = "0x3CF4AB8", Offset = "0x3CF4AB8", Length = "0x24")]
		public HealthConfig()
		{
			MaxHealth = 5;
			RegenDuration = 300f;
			MaxInfiniteDuration = 3.4028235E+38f;
			DisableHealthUntilLevel = 10;
		}
	}
}
