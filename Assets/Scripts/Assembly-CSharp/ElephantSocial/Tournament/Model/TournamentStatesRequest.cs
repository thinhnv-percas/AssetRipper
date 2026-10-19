using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086E")]
	public class TournamentStatesRequest
	{
		[JsonProperty("tournament_schedule_ids")]
		[Token(Token = "0x4001C3E")]
		[FieldOffset(Offset = "0x10")]
		public List<TournamentAndScheduleId> tournamentScheduleIds;

		[Token(Token = "0x6002423")]
		[Address(RVA = "0x3DE969C", Offset = "0x3DE969C", Length = "0x8")]
		public TournamentStatesRequest()
		{
		}
	}
}
