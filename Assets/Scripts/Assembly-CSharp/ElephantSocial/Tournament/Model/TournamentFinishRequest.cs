using System;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086A")]
	public class TournamentFinishRequest : SocialBaseData
	{
		[JsonProperty("tournament_id")]
		[Token(Token = "0x4001C39")]
		[FieldOffset(Offset = "0x118")]
		public int tournamentId;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001C3A")]
		[FieldOffset(Offset = "0x11C")]
		public int scheduleID;

		[Token(Token = "0x600241F")]
		[Address(RVA = "0x3DE8AAC", Offset = "0x3DE8AAC", Length = "0x38")]
		public TournamentFinishRequest(int tournamentId, int scheduleID)
		{
			this.tournamentId = tournamentId;
			this.scheduleID = scheduleID;
		}
	}
}
