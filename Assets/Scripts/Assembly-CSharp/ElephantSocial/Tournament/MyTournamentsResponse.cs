using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament
{
	[Serializable]
	[Token(Token = "0x2000828")]
	public class MyTournamentsResponse
	{
		[JsonProperty("tournaments")]
		[Token(Token = "0x4001BAD")]
		[FieldOffset(Offset = "0x10")]
		public List<TournamentAndScheduleId> myTournamentIds;

		[Token(Token = "0x6002316")]
		[Address(RVA = "0x3DDC708", Offset = "0x3DDC708", Length = "0x8C")]
		public MyTournamentsResponse()
		{
			List<TournamentAndScheduleId> list = new List<TournamentAndScheduleId>();
			myTournamentIds = list;
		}
	}
}
