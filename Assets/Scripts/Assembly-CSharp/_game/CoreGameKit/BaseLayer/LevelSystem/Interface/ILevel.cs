using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Interface
{
	[Token(Token = "0x200067E")]
	public interface ILevel
	{
		[Token(Token = "0x170002CA")]
		string UniqueId
		{
			[Token(Token = "0x6001B9E")]
			get;
		}

		[Token(Token = "0x170002CB")]
		string LevelName
		{
			[Token(Token = "0x6001B9F")]
			get;
		}

		[Token(Token = "0x170002CC")]
		string UnlockedFeatureId
		{
			[Token(Token = "0x6001BA0")]
			get;
		}

		[Token(Token = "0x170002CD")]
		bool LandHome
		{
			[Token(Token = "0x6001BA1")]
			get;
		}

		[Token(Token = "0x170002CE")]
		LevelDifficulty Difficulty
		{
			[Token(Token = "0x6001BA2")]
			get;
		}

		[Token(Token = "0x170002CF")]
		float LevelEndValue
		{
			[Token(Token = "0x6001BA3")]
			get;
		}

		[Token(Token = "0x170002D0")]
		GameEndCondition EndConditionType
		{
			[Token(Token = "0x6001BA4")]
			get;
		}

		[Token(Token = "0x170002D1")]
		ILevelCreationData CreationData
		{
			[Token(Token = "0x6001BA5")]
			get;
		}
	}
}
