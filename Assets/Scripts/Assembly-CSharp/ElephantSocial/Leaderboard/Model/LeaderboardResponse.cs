using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Leaderboard.Model
{
	[Serializable]
	[Token(Token = "0x20008DC")]
	public class LeaderboardResponse
	{
		[Token(Token = "0x4001DB1")]
		[FieldOffset(Offset = "0x10")]
		public int score;

		[Token(Token = "0x4001DB2")]
		[FieldOffset(Offset = "0x14")]
		public int status;

		[JsonProperty("social_id")]
		[Token(Token = "0x4001DB3")]
		[FieldOffset(Offset = "0x18")]
		public string socialId;

		[JsonProperty("player_name")]
		[Token(Token = "0x4001DB4")]
		[FieldOffset(Offset = "0x20")]
		public string playerName;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001DB5")]
		[FieldOffset(Offset = "0x28")]
		public string profilePicture;

		[JsonProperty("team_id")]
		[Token(Token = "0x4001DB6")]
		[FieldOffset(Offset = "0x30")]
		public string teamId;

		[JsonProperty("team_name")]
		[Token(Token = "0x4001DB7")]
		[FieldOffset(Offset = "0x38")]
		public string teamName;

		[Token(Token = "0x600256A")]
		[Address(RVA = "0x3E05284", Offset = "0x3E05284", Length = "0x8")]
		public LeaderboardResponse()
		{
		}
	}
}
