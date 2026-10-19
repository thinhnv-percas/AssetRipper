using System;
using Cpp2ILInjected;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000866")]
	public class TournamentListMatchesRequest : BaseTournamentRequest
	{
		[Token(Token = "0x6002413")]
		[Address(RVA = "0x3DE8A34", Offset = "0x3DE8A34", Length = "0x38")]
		public TournamentListMatchesRequest(int tournamentId, int scheduleID)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
		}
	}
}
