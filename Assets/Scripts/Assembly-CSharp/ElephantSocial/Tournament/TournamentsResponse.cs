using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament
{
	[Serializable]
	[Token(Token = "0x2000829")]
	public class TournamentsResponse
	{
		[JsonProperty("server_time")]
		[Token(Token = "0x4001BAE")]
		[FieldOffset(Offset = "0x10")]
		public long serverTime;

		[JsonProperty("tournaments")]
		[Token(Token = "0x4001BAF")]
		[FieldOffset(Offset = "0x18")]
		public List<TournamentData> tournaments;

		[Token(Token = "0x6002317")]
		[Address(RVA = "0x3DDC794", Offset = "0x3DDC794", Length = "0x8C")]
		public TournamentsResponse()
		{
			List<TournamentData> list = new List<TournamentData>();
			tournaments = list;
		}
	}
}
