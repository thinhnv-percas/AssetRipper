using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament
{
	[Serializable]
	[Token(Token = "0x2000827")]
	public class MyTournamentResultsResponse
	{
		[JsonProperty("tournaments")]
		[Token(Token = "0x4001BAC")]
		[FieldOffset(Offset = "0x10")]
		public List<TournamentData> myTournamentResults;

		[Token(Token = "0x6002315")]
		[Address(RVA = "0x3DDC67C", Offset = "0x3DDC67C", Length = "0x8C")]
		public MyTournamentResultsResponse()
		{
			List<TournamentData> list = new List<TournamentData>();
			myTournamentResults = list;
		}
	}
}
