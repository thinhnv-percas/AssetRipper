using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000875")]
	public class TournamentBoardResponse
	{
		[JsonProperty("board_players")]
		[Token(Token = "0x4001C52")]
		[FieldOffset(Offset = "0x10")]
		public List<BoardPlayer> boardPlayers;

		[Token(Token = "0x600244C")]
		[Address(RVA = "0x3DDE23C", Offset = "0x3DDE23C", Length = "0x8")]
		public TournamentBoardResponse()
		{
		}
	}
}
