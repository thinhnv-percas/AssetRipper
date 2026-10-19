using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000868")]
	public class TournamentAddScoresRequest : BaseTournamentRequest
	{
		[JsonProperty("player_scores")]
		[Token(Token = "0x170003CB")]
		[field: Token(Token = "0x4001C35")]
		[field: FieldOffset(Offset = "0x120")]
		public List<PlayerScore> PlayerScores
		{
			[Token(Token = "0x6002415")]
			[Address(RVA = "0x3DE95E8", Offset = "0x3DE95E8", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6002416")]
		[Address(RVA = "0x3DE890C", Offset = "0x3DE890C", Length = "0x48")]
		public TournamentAddScoresRequest(int tournamentId, int scheduleID, List<PlayerScore> scores)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
			PlayerScores = scores;
		}
	}
}
