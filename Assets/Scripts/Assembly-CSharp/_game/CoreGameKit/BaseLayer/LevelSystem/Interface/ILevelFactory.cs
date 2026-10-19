using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Interface
{
	[Token(Token = "0x2000681")]
	public interface ILevelFactory
	{
		[Token(Token = "0x6001BA6")]
		bool CreateLevel(ILevel levelData);
	}
}
