using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000878")]
	public class TournamentInitResponse
	{
		[JsonProperty("tournaments")]
		[Token(Token = "0x4001C55")]
		[FieldOffset(Offset = "0x10")]
		public Tournament[] tournaments;

		[JsonProperty("player_tournaments")]
		[Token(Token = "0x4001C56")]
		[FieldOffset(Offset = "0x18")]
		public Tournament[] playerTournaments;

		[Token(Token = "0x600244F")]
		[Address(RVA = "0x3DE97EC", Offset = "0x3DE97EC", Length = "0x8")]
		public TournamentInitResponse()
		{
		}
	}
}
