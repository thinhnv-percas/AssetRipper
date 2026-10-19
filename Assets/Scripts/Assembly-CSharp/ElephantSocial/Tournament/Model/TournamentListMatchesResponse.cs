using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200086F")]
	public class TournamentListMatchesResponse
	{
		[JsonProperty("matches")]
		[Token(Token = "0x170003CF")]
		[field: Token(Token = "0x4001C3F")]
		[field: FieldOffset(Offset = "0x10")]
		public List<TournamentMatchItem> Matches
		{
			[Token(Token = "0x6002424")]
			[Address(RVA = "0x3DE96A4", Offset = "0x3DE96A4", Length = "0x8")]
			get;
			[Token(Token = "0x6002425")]
			[Address(RVA = "0x3DE96AC", Offset = "0x3DE96AC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002426")]
		[Address(RVA = "0x3DE96B4", Offset = "0x3DE96B4", Length = "0x8")]
		public TournamentListMatchesResponse()
		{
		}
	}
}
