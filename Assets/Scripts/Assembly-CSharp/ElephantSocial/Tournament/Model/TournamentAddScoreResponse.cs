using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000873")]
	public class TournamentAddScoreResponse
	{
		[JsonProperty("added_score")]
		[Token(Token = "0x4001C50")]
		[FieldOffset(Offset = "0x10")]
		public int addedScore;

		[Token(Token = "0x600244A")]
		[Address(RVA = "0x3DE97D4", Offset = "0x3DE97D4", Length = "0x8")]
		public TournamentAddScoreResponse()
		{
		}
	}
}
