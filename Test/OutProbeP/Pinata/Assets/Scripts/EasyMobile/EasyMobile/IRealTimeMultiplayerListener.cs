using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000043")]
	public interface IRealTimeMultiplayerListener
	{
		[Token(Token = "0x60003BD")]
		void OnRoomSetupProgress(float percent);

		[Token(Token = "0x60003BE")]
		void OnRoomConnected(bool success);

		[Token(Token = "0x60003BF")]
		void OnLeftRoom();

		[Token(Token = "0x60003C0")]
		void OnParticipantLeft(Participant participant);

		[Token(Token = "0x60003C1")]
		void OnPeersConnected(string[] participantIds);

		[Token(Token = "0x60003C2")]
		void OnPeersDisconnected(string[] participantIds);

		[Token(Token = "0x60003C3")]
		void OnRealTimeMessageReceived(string senderId, byte[] data);

		[Token(Token = "0x60003C4")]
		bool ShouldReinviteDisconnectedPlayer(Participant participant);
	}
}
