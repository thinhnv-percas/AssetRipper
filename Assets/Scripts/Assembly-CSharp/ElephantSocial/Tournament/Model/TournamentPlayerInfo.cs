using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000872")]
	public class TournamentPlayerInfo
	{
		[JsonProperty("player_name")]
		[Token(Token = "0x170003DA")]
		[field: Token(Token = "0x4001C4A")]
		[field: FieldOffset(Offset = "0x10")]
		public string PlayerName
		{
			[Token(Token = "0x600243D")]
			[Address(RVA = "0x3DE976C", Offset = "0x3DE976C", Length = "0x8")]
			get;
			[Token(Token = "0x600243E")]
			[Address(RVA = "0x3DE9774", Offset = "0x3DE9774", Length = "0x8")]
			set;
		}

		[JsonProperty("profile_picture")]
		[Token(Token = "0x170003DB")]
		[field: Token(Token = "0x4001C4B")]
		[field: FieldOffset(Offset = "0x18")]
		public string ProfilePicture
		{
			[Token(Token = "0x600243F")]
			[Address(RVA = "0x3DE977C", Offset = "0x3DE977C", Length = "0x8")]
			get;
			[Token(Token = "0x6002440")]
			[Address(RVA = "0x3DE9784", Offset = "0x3DE9784", Length = "0x8")]
			set;
		}

		[JsonProperty("status")]
		[Token(Token = "0x170003DC")]
		[field: Token(Token = "0x4001C4C")]
		[field: FieldOffset(Offset = "0x20")]
		public int Status
		{
			[Token(Token = "0x6002441")]
			[Address(RVA = "0x3DE978C", Offset = "0x3DE978C", Length = "0x8")]
			get;
			[Token(Token = "0x6002442")]
			[Address(RVA = "0x3DE9794", Offset = "0x3DE9794", Length = "0x8")]
			set;
		}

		[JsonProperty("badge")]
		[Token(Token = "0x170003DD")]
		[field: Token(Token = "0x4001C4D")]
		[field: FieldOffset(Offset = "0x24")]
		public int Badge
		{
			[Token(Token = "0x6002443")]
			[Address(RVA = "0x3DE979C", Offset = "0x3DE979C", Length = "0x8")]
			get;
			[Token(Token = "0x6002444")]
			[Address(RVA = "0x3DE97A4", Offset = "0x3DE97A4", Length = "0x8")]
			set;
		}

		[JsonProperty("country")]
		[Token(Token = "0x170003DE")]
		[field: Token(Token = "0x4001C4E")]
		[field: FieldOffset(Offset = "0x28")]
		public string Country
		{
			[Token(Token = "0x6002445")]
			[Address(RVA = "0x3DE97AC", Offset = "0x3DE97AC", Length = "0x8")]
			get;
			[Token(Token = "0x6002446")]
			[Address(RVA = "0x3DE97B4", Offset = "0x3DE97B4", Length = "0x8")]
			set;
		}

		[JsonProperty("level")]
		[Token(Token = "0x170003DF")]
		[field: Token(Token = "0x4001C4F")]
		[field: FieldOffset(Offset = "0x30")]
		public int Level
		{
			[Token(Token = "0x6002447")]
			[Address(RVA = "0x3DE97BC", Offset = "0x3DE97BC", Length = "0x8")]
			get;
			[Token(Token = "0x6002448")]
			[Address(RVA = "0x3DE97C4", Offset = "0x3DE97C4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002449")]
		[Address(RVA = "0x3DE97CC", Offset = "0x3DE97CC", Length = "0x8")]
		public TournamentPlayerInfo()
		{
		}
	}
}
