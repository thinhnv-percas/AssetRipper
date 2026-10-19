using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000879")]
	public class TournamentJoinResponse
	{
		[JsonProperty("board_players")]
		[Token(Token = "0x4001C57")]
		[FieldOffset(Offset = "0x10")]
		public List<BoardPlayer> boardPlayers;

		[Token(Token = "0x6002450")]
		[Address(RVA = "0x3DE97F4", Offset = "0x3DE97F4", Length = "0x8")]
		public TournamentJoinResponse()
		{
		}
	}
}
