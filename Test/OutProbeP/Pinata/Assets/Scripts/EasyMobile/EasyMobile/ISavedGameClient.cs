using System;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000050")]
	public interface ISavedGameClient
	{
		[Token(Token = "0x6000415")]
		void OpenWithAutomaticConflictResolution(string name, Action<SavedGame, string> callback);

		[Token(Token = "0x6000416")]
		void OpenWithManualConflictResolution(string name, bool prefetchDataOnConflict, SavedGameConflictResolver resolverFunction, Action<SavedGame, string> completedCallback);

		[Token(Token = "0x6000417")]
		void ReadSavedGameData(SavedGame savedGame, Action<SavedGame, byte[], string> callback);

		[Token(Token = "0x6000418")]
		void WriteSavedGameData(SavedGame savedGame, byte[] data, Action<SavedGame, string> callback);

		[Token(Token = "0x6000419")]
		void WriteSavedGameData(SavedGame savedGame, byte[] data, SavedGameInfoUpdate infoUpdate, Action<SavedGame, string> callback);

		[Token(Token = "0x600041A")]
		void FetchAllSavedGames(Action<SavedGame[], string> callback);

		[Token(Token = "0x600041B")]
		void DeleteSavedGame(SavedGame savedGame);

		[Token(Token = "0x600041C")]
		void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SavedGame, string> callback);
	}
}
