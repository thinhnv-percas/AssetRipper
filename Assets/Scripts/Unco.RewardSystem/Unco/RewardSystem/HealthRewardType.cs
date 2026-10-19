using Cpp2ILInjected;

namespace Unco.RewardSystem
{
	[Token(Token = "0x2000014")]
	public enum HealthRewardType
	{
		[Token(Token = "0x4000023")]
		None = 0,
		[Token(Token = "0x4000024")]
		LimitlessHealth = 1,
		[Token(Token = "0x4000025")]
		IncreaseHealth = 2
	}
}
