using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000862")]
	public class TournamentAddMatchRequest : BaseTournamentRequest
	{
		[JsonProperty("score_updates")]
		[Token(Token = "0x170003C8")]
		[field: Token(Token = "0x4001C2D")]
		[field: FieldOffset(Offset = "0x120")]
		public List<ScoreUpdate> ScoreUpdates
		{
			[Token(Token = "0x6002409")]
			[Address(RVA = "0x3DE9448", Offset = "0x3DE9448", Length = "0x8")]
			get;
		}

		[Token(Token = "0x600240A")]
		[Address(RVA = "0x3DE898C", Offset = "0x3DE898C", Length = "0xA8")]
		public TournamentAddMatchRequest(int tournamentId, int scheduleID, List<ScoreUpdate> updates)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
			bool flag = updates == null;
			bool flag2 = !flag;
			List<ScoreUpdate> list = updates;
			if (!flag2)
			{
				List<ScoreUpdate> list2 = new List<ScoreUpdate>();
				list = list2;
			}
			ScoreUpdates = list;
		}
	}
}
