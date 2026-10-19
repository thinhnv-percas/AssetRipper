using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Interface
{
	[Token(Token = "0x2000683")]
	public interface ILevelNavigationHandler
	{
		[Token(Token = "0x170002D3")]
		int CurrentPosition
		{
			[Token(Token = "0x6001BB8")]
			get;
		}

		[Token(Token = "0x170002D4")]
		bool CurrentIsLoop
		{
			[Token(Token = "0x6001BB9")]
			get;
		}

		[Token(Token = "0x6001BBA")]
		void Initialize();

		[Token(Token = "0x6001BBB")]
		ILevel GetCurrentLevel();

		[Token(Token = "0x6001BBC")]
		IEnumerable<ILevel> GetLevelRange(int startIndex, int count);

		[Token(Token = "0x6001BBD")]
		void AdvanceOnWin();
	}
}
