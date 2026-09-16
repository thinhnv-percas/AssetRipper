using System;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000044")]
	public interface ITurnBasedMultiplayerClient
	{
		[Token(Token = "0x60003C5")]
		void CreateQuickMatch(MatchRequest request, Action<bool, TurnBasedMatch> callback);

		[Token(Token = "0x60003C6")]
		void CreateWithMatchmakerUI(MatchRequest request, Action cancelCallback, Action<string> errorCallback);

		[Token(Token = "0x60003C7")]
		void GetAllMatches(Action<TurnBasedMatch[]> callback);

		[Token(Token = "0x60003C8")]
		void ShowMatchesUI();

		[Token(Token = "0x60003C9")]
		void AcceptInvitation(Invitation invitation, Action<bool, TurnBasedMatch> callback);

		[Token(Token = "0x60003CA")]
		void RegisterMatchDelegate(MatchDelegate del);

		[Token(Token = "0x60003CB")]
		void TakeTurn(TurnBasedMatch match, byte[] data, string nextParticipantId, Action<bool> callback);

		[Token(Token = "0x60003CC")]
		void TakeTurn(TurnBasedMatch match, byte[] data, Participant nextParticipant, Action<bool> callback);

		[Token(Token = "0x60003CD")]
		int GetMaxMatchDataSize();

		[Token(Token = "0x60003CE")]
		void Finish(TurnBasedMatch match, byte[] data, MatchOutcome outcome, Action<bool> callback);

		[Token(Token = "0x60003CF")]
		void AcknowledgeFinished(TurnBasedMatch match, Action<bool> callback);

		[Token(Token = "0x60003D0")]
		void LeaveMatch(TurnBasedMatch match, Action<bool> callback);

		[Token(Token = "0x60003D1")]
		void LeaveMatchInTurn(TurnBasedMatch match, string nextParticipantId, Action<bool> callback);

		[Token(Token = "0x60003D2")]
		void LeaveMatchInTurn(TurnBasedMatch match, Participant nextParticipant, Action<bool> callback);

		[Token(Token = "0x60003D3")]
		void Rematch(TurnBasedMatch match, Action<bool, TurnBasedMatch> callback);

		[Token(Token = "0x60003D4")]
		void DeclineInvitation(Invitation invitation);
	}
}
