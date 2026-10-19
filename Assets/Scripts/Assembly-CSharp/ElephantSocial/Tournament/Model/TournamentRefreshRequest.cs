using System;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086C")]
	public class TournamentRefreshRequest : SocialBaseData
	{
		[JsonProperty("tournament_id")]
		[Token(Token = "0x4001C3C")]
		[FieldOffset(Offset = "0x118")]
		public int tournamentId;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001C3D")]
		[FieldOffset(Offset = "0x11C")]
		public int scheduleId;

		[Token(Token = "0x6002421")]
		[Address(RVA = "0x3DE9664", Offset = "0x3DE9664", Length = "0x38")]
		public TournamentRefreshRequest(int tournamentId, int scheduleId)
		{
			this.tournamentId = tournamentId;
			this.scheduleId = scheduleId;
		}
	}
}
