using Cpp2ILInjected;

namespace Systems.TutorialSystem.Scripts
{
	[Token(Token = "0x2000013")]
	public enum TutorialType
	{
		[Token(Token = "0x4000037")]
		None = 0,
		[Token(Token = "0x4000038")]
		EnemyKilled = 1,
		[Token(Token = "0x4000039")]
		ExpCollected = 2,
		[Token(Token = "0x400003A")]
		Dash = 3,
		[Token(Token = "0x400003B")]
		Rage = 4,
		[Token(Token = "0x400003C")]
		Chest = 5,
		[Token(Token = "0x400003D")]
		LevelReward = 6,
		[Token(Token = "0x400003E")]
		WeaponRankUp = 7,
		[Token(Token = "0x400003F")]
		WeaponUpgrade = 8,
		[Token(Token = "0x4000040")]
		WeaponMerged = 9,
		[Token(Token = "0x4000041")]
		GearChest = 10,
		[Token(Token = "0x4000042")]
		GearEquip = 11,
		[Token(Token = "0x4000043")]
		WeaponEquip = 12,
		[Token(Token = "0x4000044")]
		SkillSelection = 13,
		[Token(Token = "0x4000045")]
		Rage2 = 14,
		[Token(Token = "0x4000046")]
		StageEntered = 15,
		[Token(Token = "0x4000047")]
		StageCleared = 16,
		[Token(Token = "0x4000048")]
		FreezeBooster = 17,
		[Token(Token = "0x4000049")]
		ShieldBooster = 18,
		[Token(Token = "0x400004A")]
		RageBooster = 19,
		[Token(Token = "0x400004B")]
		StageEnterHealthBoosterTutorial = 51,
		[Token(Token = "0x400004C")]
		StageEnterTimeBoosterTutorial = 52,
		[Token(Token = "0x400004D")]
		StageEnterPowerUpSelectionBoosterTutorial = 53
	}
}
