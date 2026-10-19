using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Interface
{
	[Token(Token = "0x2000682")]
	public interface ILevelList
	{
		[Token(Token = "0x170002D2")]
		IEnumerable<ILevel> Internal_LevelList
		{
			[Token(Token = "0x6001BAD")]
			get;
		}

		[Token(Token = "0x6001BA7")]
		LevelOrderAlgorithm GetAlgorithm();

		[Token(Token = "0x6001BA8")]
		ILevel GetLevel(int index);

		[Token(Token = "0x6001BA9")]
		ILevel GetLevelByGuid(string guid);

		[Token(Token = "0x6001BAA")]
		ILevel GetLevelFromDatabaseByGuid(string guid);

		[Token(Token = "0x6001BAB")]
		int GetIndexByGuid(string guid);

		[Token(Token = "0x6001BAC")]
		IEnumerable<ILevel> GetLevelRange(int starterIndex, int count);

		[Token(Token = "0x6001BAE")]
		bool IsLoopLevel(int levelIndex);

		[Token(Token = "0x6001BAF")]
		bool TryGetGuidInfo(string guid, out bool isLoop, out int positionInArray);

		[Token(Token = "0x6001BB0")]
		bool TryGetUniquePosition(string guid, out int position);

		[Token(Token = "0x6001BB1")]
		bool TryGetLoopPosition(string guid, out int position);

		[Token(Token = "0x6001BB2")]
		int GetUniqueLength();

		[Token(Token = "0x6001BB3")]
		int GetLoopLength();

		[Token(Token = "0x6001BB4")]
		ILevel GetUniqueAt(int position);

		[Token(Token = "0x6001BB5")]
		ILevel GetLoopAt(int position);

		[Token(Token = "0x6001BB6")]
		string GetOrderSignature();

		[Token(Token = "0x6001BB7")]
		string GetMigrationAnchorUniqueId();
	}
}
