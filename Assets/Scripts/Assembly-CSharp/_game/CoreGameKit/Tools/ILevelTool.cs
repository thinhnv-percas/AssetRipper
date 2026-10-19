using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A0")]
	public interface ILevelTool : IDevTool
	{
		[Token(Token = "0x60017CB")]
		IEnumerable<string> GetAvailableLevelIds();

		[Token(Token = "0x60017CC")]
		ILevel GetLevel(int levelIndex);

		[Token(Token = "0x60017CD")]
		ILevel GetLevelById(string levelId);

		[Token(Token = "0x60017CE")]
		int GetCurrentLevelIndex();

		[Token(Token = "0x60017CF")]
		LevelDetails GetLevelDetails(int levelIndex);

		[Token(Token = "0x60017D0")]
		ValidationResult ValidateLevel(int levelIndex);

		[Token(Token = "0x60017D1")]
		string DumpLevelToJson(int levelIndex);

		[Token(Token = "0x60017D2")]
		int GetLevelCount();
	}
}
