using Cpp2ILInjected;

namespace _game.CoreSystem.LevelCreator
{
	[Token(Token = "0x20004BB")]
	public interface ILevelCreatorDataProvider
	{
		[Token(Token = "0x60013E8")]
		LevelCreatorData GetLevelData(string levelId);
	}
}
