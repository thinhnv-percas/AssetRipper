using System;
using Cpp2ILInjected;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086D")]
	public class TournamentRequest : BaseTournamentRequest
	{
		[Token(Token = "0x6002422")]
		[Address(RVA = "0x3DE8954", Offset = "0x3DE8954", Length = "0x38")]
		public TournamentRequest(int tournamentId, int scheduleID)
			: base(tournamentId, scheduleID)
		{
			base.tournamentId = tournamentId;
			base.scheduleID = scheduleID;
		}
	}
}
