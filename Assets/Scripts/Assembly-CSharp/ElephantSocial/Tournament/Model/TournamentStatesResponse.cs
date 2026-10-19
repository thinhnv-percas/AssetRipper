using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200087A")]
	public class TournamentStatesResponse
	{
		[JsonProperty("tournament_states")]
		[Token(Token = "0x4001C58")]
		[FieldOffset(Offset = "0x10")]
		public List<StateInfo> tournamentStates;

		[Token(Token = "0x6002451")]
		[Address(RVA = "0x3DE97FC", Offset = "0x3DE97FC", Length = "0x8")]
		public TournamentStatesResponse()
		{
		}
	}
}
