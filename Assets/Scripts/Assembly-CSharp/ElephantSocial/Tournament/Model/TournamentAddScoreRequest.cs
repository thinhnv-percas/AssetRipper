using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000867")]
	public class TournamentAddScoreRequest : BaseTournamentRequest
	{
		[JsonProperty("score")]
		[Token(Token = "0x4001C33")]
		[FieldOffset(Offset = "0x120")]
		public int score;

		[JsonProperty("online")]
		[Token(Token = "0x4001C34")]
		[FieldOffset(Offset = "0x124")]
		public bool Online;

		[Token(Token = "0x6002414")]
		[Address(RVA = "0x3DE88C4", Offset = "0x3DE88C4", Length = "0x48")]
		public TournamentAddScoreRequest(int tournamentId, int scheduleID, int scoreToAdd)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
			score = scoreToAdd;
			Online = true;
		}
	}
}
