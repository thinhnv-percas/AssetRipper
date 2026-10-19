using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x200087C")]
	public class TournamentResponse
	{
		[Token(Token = "0x4001C5E")]
		[FieldOffset(Offset = "0x10")]
		public int score;

		[Token(Token = "0x4001C5F")]
		[FieldOffset(Offset = "0x14")]
		public int status;

		[JsonProperty("social_id")]
		[Token(Token = "0x4001C60")]
		[FieldOffset(Offset = "0x18")]
		public string socialId;

		[JsonProperty("player_name")]
		[Token(Token = "0x4001C61")]
		[FieldOffset(Offset = "0x20")]
		public string playerName;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001C62")]
		[FieldOffset(Offset = "0x28")]
		public string profilePicture;

		[JsonProperty("team_id")]
		[Token(Token = "0x4001C63")]
		[FieldOffset(Offset = "0x30")]
		public string teamId;

		[JsonProperty("team_name")]
		[Token(Token = "0x4001C64")]
		[FieldOffset(Offset = "0x38")]
		public string teamName;

		[Token(Token = "0x6002453")]
		[Address(RVA = "0x3DE980C", Offset = "0x3DE980C", Length = "0x8")]
		public TournamentResponse()
		{
		}
	}
}
