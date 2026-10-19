using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000015")]
	public enum ResourceType
	{
		[Token(Token = "0x4000026")]
		None = -1,
		[Token(Token = "0x4000027")]
		CommonCore = 2,
		[Token(Token = "0x4000028")]
		RareCore = 3,
		[Token(Token = "0x4000029")]
		Energy = 4,
		[Token(Token = "0x400002A")]
		SoftCurrency = 5,
		[Token(Token = "0x400002B")]
		HardCurrency = 6,
		[Token(Token = "0x400002C")]
		EquipmentKey = 7,
		[Token(Token = "0x400002D")]
		CoreKey = 8,
		[Token(Token = "0x400002E")]
		Patrol = 9,
		[Token(Token = "0x400002F")]
		LevelUpResource = 500,
		[Token(Token = "0x4000030")]
		BonusLootDropSource = 501,
		[Token(Token = "0x4000031")]
		EpicBonusLootDropSource = 502,
		[Token(Token = "0x4000032")]
		TreasureEventCurrency = 503
	}
}
