using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000874")]
	public class TournamentBulkAddScoresResponse
	{
		[JsonProperty("added_score")]
		[Token(Token = "0x4001C51")]
		[FieldOffset(Offset = "0x10")]
		public int addedScore;

		[Token(Token = "0x600244B")]
		[Address(RVA = "0x3DE97DC", Offset = "0x3DE97DC", Length = "0x8")]
		public TournamentBulkAddScoresResponse()
		{
		}
	}
}
