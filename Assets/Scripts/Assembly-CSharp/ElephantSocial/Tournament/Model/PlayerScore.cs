using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000869")]
	public class PlayerScore
	{
		[JsonProperty("score")]
		[Token(Token = "0x170003CC")]
		[field: Token(Token = "0x4001C36")]
		[field: FieldOffset(Offset = "0x10")]
		public int Score
		{
			[Token(Token = "0x6002417")]
			[Address(RVA = "0x3DE95F0", Offset = "0x3DE95F0", Length = "0x8")]
			get;
			[Token(Token = "0x6002418")]
			[Address(RVA = "0x3DE95F8", Offset = "0x3DE95F8", Length = "0x8")]
			set;
		}

		[JsonProperty("date")]
		[Token(Token = "0x170003CD")]
		[field: Token(Token = "0x4001C37")]
		[field: FieldOffset(Offset = "0x18")]
		public long Date
		{
			[Token(Token = "0x6002419")]
			[Address(RVA = "0x3DE9600", Offset = "0x3DE9600", Length = "0x8")]
			get;
			[Token(Token = "0x600241A")]
			[Address(RVA = "0x3DE9608", Offset = "0x3DE9608", Length = "0x8")]
			set;
		}

		[JsonProperty("online")]
		[Token(Token = "0x170003CE")]
		[field: Token(Token = "0x4001C38")]
		[field: FieldOffset(Offset = "0x20")]
		public bool Online
		{
			[Token(Token = "0x600241B")]
			[Address(RVA = "0x3DE9610", Offset = "0x3DE9610", Length = "0x8")]
			get;
			[Token(Token = "0x600241C")]
			[Address(RVA = "0x3DE9618", Offset = "0x3DE9618", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600241D")]
		[Address(RVA = "0x3DE5AC4", Offset = "0x3DE5AC4", Length = "0x8")]
		public PlayerScore()
		{
		}

		[Token(Token = "0x600241E")]
		[Address(RVA = "0x3DE9620", Offset = "0x3DE9620", Length = "0x44")]
		public PlayerScore(int score, long date, bool online)
		{
			Score = score;
			Date = date;
			Online = online;
		}
	}
}
