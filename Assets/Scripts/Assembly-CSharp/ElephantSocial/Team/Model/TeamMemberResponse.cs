using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model
{
	[Serializable]
	[Token(Token = "0x20008AC")]
	public class TeamMemberResponse
	{
		[JsonProperty("helps")]
		[Token(Token = "0x4001D2C")]
		[FieldOffset(Offset = "0x10")]
		public int Helps;

		[JsonProperty("player_info")]
		[Token(Token = "0x4001D2D")]
		[FieldOffset(Offset = "0x18")]
		public PlayerInfo PlayerInfo;

		[JsonProperty("role")]
		[Token(Token = "0x4001D2E")]
		[FieldOffset(Offset = "0x20")]
		public int Role;

		[JsonProperty("score")]
		[Token(Token = "0x4001D2F")]
		[FieldOffset(Offset = "0x24")]
		public int Score;

		[JsonProperty("social_id")]
		[Token(Token = "0x4001D30")]
		[FieldOffset(Offset = "0x28")]
		public string SocialId;

		[JsonProperty("team_id")]
		[Token(Token = "0x4001D31")]
		[FieldOffset(Offset = "0x30")]
		public string TeamId;

		[Token(Token = "0x600250A")]
		[Address(RVA = "0x3DFEDAC", Offset = "0x3DFEDAC", Length = "0x8")]
		public TeamMemberResponse()
		{
		}
	}
}
