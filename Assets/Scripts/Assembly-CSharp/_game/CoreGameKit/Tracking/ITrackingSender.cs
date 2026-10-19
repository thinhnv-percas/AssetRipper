using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ResourceSystem;
using Unco.Utils;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x200057D")]
	public interface ITrackingSender
	{
		[Token(Token = "0x6001721")]
		void SendEvent(string eventName, int level, string levelName, Params parameters);

		[Token(Token = "0x6001722")]
		void SendLevelComplete(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId);

		[Token(Token = "0x6001723")]
		void SendLevelStarted(int level, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount, int coinAmount);

		[Token(Token = "0x6001724")]
		void SendLevelFail(int level, bool isRetry, string originalLevelId, string levelName, bool isLoop, int loopTurnId, int healthAmount);

		[Token(Token = "0x6001725")]
		void SendCustomEvent(string eventName, int level, string levelName, List<Pair<string, string>> pair);

		[Token(Token = "0x6001726")]
		void SendMoveEvent(int level, string levelName, string levelGuid, int moveNumber, int col, int row, string color);

		[Token(Token = "0x6001727")]
		void SendTransaction(string type, long delta, long newAmount, string levelName, TransactionContext context);
	}
}
