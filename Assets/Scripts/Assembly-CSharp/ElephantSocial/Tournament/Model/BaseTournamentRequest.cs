using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Token(Token = "0x2000864")]
	public class BaseTournamentRequest : SocialBaseData
	{
		[JsonProperty("tournament_id")]
		[Token(Token = "0x4001C30")]
		[FieldOffset(Offset = "0x118")]
		public int tournamentId;

		[JsonProperty("schedule_id")]
		[Token(Token = "0x4001C31")]
		[FieldOffset(Offset = "0x11C")]
		public int scheduleID;

		[Token(Token = "0x6002411")]
		[Address(RVA = "0x3DE9450", Offset = "0x3DE9450", Length = "0x38")]
		public BaseTournamentRequest(int tournamentId, int scheduleID)
		{
			this.tournamentId = tournamentId;
			this.scheduleID = scheduleID;
		}
	}
}
