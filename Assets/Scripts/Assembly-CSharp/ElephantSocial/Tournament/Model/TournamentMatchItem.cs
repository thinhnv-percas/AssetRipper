using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000870")]
	public class TournamentMatchItem
	{
		[JsonProperty("game_id")]
		[Token(Token = "0x170003D0")]
		[field: Token(Token = "0x4001C40")]
		[field: FieldOffset(Offset = "0x10")]
		public int GameId
		{
			[Token(Token = "0x6002427")]
			[Address(RVA = "0x3DE96BC", Offset = "0x3DE96BC", Length = "0x8")]
			get;
			[Token(Token = "0x6002428")]
			[Address(RVA = "0x3DE96C4", Offset = "0x3DE96C4", Length = "0x8")]
			set;
		}

		[JsonProperty("server_id")]
		[Token(Token = "0x170003D1")]
		[field: Token(Token = "0x4001C41")]
		[field: FieldOffset(Offset = "0x14")]
		public int ServerId
		{
			[Token(Token = "0x6002429")]
			[Address(RVA = "0x3DE96CC", Offset = "0x3DE96CC", Length = "0x8")]
			get;
			[Token(Token = "0x600242A")]
			[Address(RVA = "0x3DE96D4", Offset = "0x3DE96D4", Length = "0x8")]
			set;
		}

		[JsonProperty("tournament_id")]
		[Token(Token = "0x170003D2")]
		[field: Token(Token = "0x4001C42")]
		[field: FieldOffset(Offset = "0x18")]
		public int TournamentId
		{
			[Token(Token = "0x600242B")]
			[Address(RVA = "0x3DE96DC", Offset = "0x3DE96DC", Length = "0x8")]
			get;
			[Token(Token = "0x600242C")]
			[Address(RVA = "0x3DE96E4", Offset = "0x3DE96E4", Length = "0x8")]
			set;
		}

		[JsonProperty("schedule_id")]
		[Token(Token = "0x170003D3")]
		[field: Token(Token = "0x4001C43")]
		[field: FieldOffset(Offset = "0x1C")]
		public int ScheduleId
		{
			[Token(Token = "0x600242D")]
			[Address(RVA = "0x3DE96EC", Offset = "0x3DE96EC", Length = "0x8")]
			get;
			[Token(Token = "0x600242E")]
			[Address(RVA = "0x3DE96F4", Offset = "0x3DE96F4", Length = "0x8")]
			set;
		}

		[JsonProperty("metadata")]
		[Token(Token = "0x170003D4")]
		[field: Token(Token = "0x4001C44")]
		[field: FieldOffset(Offset = "0x20")]
		public string Metadata
		{
			[Token(Token = "0x600242F")]
			[Address(RVA = "0x3DE96FC", Offset = "0x3DE96FC", Length = "0x8")]
			get;
			[Token(Token = "0x6002430")]
			[Address(RVA = "0x3DE9704", Offset = "0x3DE9704", Length = "0x8")]
			set;
		}

		[JsonProperty("score_updates")]
		[Token(Token = "0x170003D5")]
		[field: Token(Token = "0x4001C45")]
		[field: FieldOffset(Offset = "0x28")]
		public List<TournamentScoreUpdateWithInfo> ScoreUpdates
		{
			[Token(Token = "0x6002431")]
			[Address(RVA = "0x3DE970C", Offset = "0x3DE970C", Length = "0x8")]
			get;
			[Token(Token = "0x6002432")]
			[Address(RVA = "0x3DE9714", Offset = "0x3DE9714", Length = "0x8")]
			set;
		}

		[JsonProperty("created_at")]
		[Token(Token = "0x170003D6")]
		[field: Token(Token = "0x4001C46")]
		[field: FieldOffset(Offset = "0x30")]
		public string CreatedAt
		{
			[Token(Token = "0x6002433")]
			[Address(RVA = "0x3DE971C", Offset = "0x3DE971C", Length = "0x8")]
			get;
			[Token(Token = "0x6002434")]
			[Address(RVA = "0x3DE9724", Offset = "0x3DE9724", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002435")]
		[Address(RVA = "0x3DE972C", Offset = "0x3DE972C", Length = "0x8")]
		public TournamentMatchItem()
		{
		}
	}
}
