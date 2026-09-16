using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000042")]
	public interface IRealTimeMultiplayerClient
	{
		[Token(Token = "0x60003AF")]
		void CreateQuickMatch(MatchRequest request, IRealTimeMultiplayerListener listener);

		[Token(Token = "0x60003B0")]
		void CreateWithMatchmakerUI(MatchRequest request, IRealTimeMultiplayerListener listener);

		[Token(Token = "0x60003B1")]
		void ShowInvitationsUI(IRealTimeMultiplayerListener listener);

		[Token(Token = "0x60003B2")]
		void AcceptInvitation(Invitation invitation, bool showWaitingRoomUI, IRealTimeMultiplayerListener listener);

		[Token(Token = "0x60003B3")]
		void SendMessageToAll(bool reliable, byte[] data);

		[Token(Token = "0x60003B4")]
		void SendMessageToAll(bool reliable, byte[] data, int offset, int length);

		[Token(Token = "0x60003B5")]
		void SendMessage(bool reliable, string participantId, byte[] data);

		[Token(Token = "0x60003B6")]
		void SendMessage(bool reliable, string participantId, byte[] data, int offset, int length);

		[Token(Token = "0x60003B7")]
		List<Participant> GetConnectedParticipants();

		[Token(Token = "0x60003B8")]
		Participant GetSelf();

		[Token(Token = "0x60003B9")]
		Participant GetParticipant(string participantId);

		[Token(Token = "0x60003BA")]
		void LeaveRoom();

		[Token(Token = "0x60003BB")]
		bool IsRoomConnected();

		[Token(Token = "0x60003BC")]
		void DeclineInvitation(Invitation invitation);
	}
}
