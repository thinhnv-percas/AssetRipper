using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000871")]
	public class TournamentScoreUpdateWithInfo
	{
		[JsonProperty("score")]
		[Token(Token = "0x170003D7")]
		[field: Token(Token = "0x4001C47")]
		[field: FieldOffset(Offset = "0x10")]
		public int Score
		{
			[Token(Token = "0x6002436")]
			[Address(RVA = "0x3DE9734", Offset = "0x3DE9734", Length = "0x8")]
			get;
			[Token(Token = "0x6002437")]
			[Address(RVA = "0x3DE973C", Offset = "0x3DE973C", Length = "0x8")]
			set;
		}

		[JsonProperty("social_id")]
		[Token(Token = "0x170003D8")]
		[field: Token(Token = "0x4001C48")]
		[field: FieldOffset(Offset = "0x18")]
		public string SocialId
		{
			[Token(Token = "0x6002438")]
			[Address(RVA = "0x3DE9744", Offset = "0x3DE9744", Length = "0x8")]
			get;
			[Token(Token = "0x6002439")]
			[Address(RVA = "0x3DE974C", Offset = "0x3DE974C", Length = "0x8")]
			set;
		}

		[JsonProperty("player_info")]
		[Token(Token = "0x170003D9")]
		[field: Token(Token = "0x4001C49")]
		[field: FieldOffset(Offset = "0x20")]
		public TournamentPlayerInfo PlayerInfo
		{
			[Token(Token = "0x600243A")]
			[Address(RVA = "0x3DE9754", Offset = "0x3DE9754", Length = "0x8")]
			get;
			[Token(Token = "0x600243B")]
			[Address(RVA = "0x3DE975C", Offset = "0x3DE975C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600243C")]
		[Address(RVA = "0x3DE9764", Offset = "0x3DE9764", Length = "0x8")]
		public TournamentScoreUpdateWithInfo()
		{
		}
	}
}
