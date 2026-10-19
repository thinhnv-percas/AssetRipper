using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Response
{
	[Serializable]
	[Token(Token = "0x20008B0")]
	public class TeamResponse
	{
		[JsonProperty("badge")]
		[Token(Token = "0x4001D3A")]
		[FieldOffset(Offset = "0x10")]
		public int Badge;

		[JsonProperty("capacity")]
		[Token(Token = "0x4001D3B")]
		[FieldOffset(Offset = "0x14")]
		public int Capacity;

		[JsonProperty("description")]
		[Token(Token = "0x4001D3C")]
		[FieldOffset(Offset = "0x18")]
		public string Description;

		[JsonProperty("name")]
		[Token(Token = "0x4001D3D")]
		[FieldOffset(Offset = "0x20")]
		public string Name;

		[JsonProperty("required_level")]
		[Token(Token = "0x4001D3E")]
		[FieldOffset(Offset = "0x28")]
		public int RequiredLevel;

		[JsonProperty("server_id")]
		[Token(Token = "0x4001D3F")]
		[FieldOffset(Offset = "0x2C")]
		public int ServerId;

		[JsonProperty("size")]
		[Token(Token = "0x4001D40")]
		[FieldOffset(Offset = "0x30")]
		public int Size;

		[JsonProperty("stars")]
		[Token(Token = "0x4001D41")]
		[FieldOffset(Offset = "0x34")]
		public int Stars;

		[JsonProperty("team_id")]
		[Token(Token = "0x4001D42")]
		[FieldOffset(Offset = "0x38")]
		public string TeamId;

		[JsonProperty("team_members")]
		[Token(Token = "0x4001D43")]
		[FieldOffset(Offset = "0x40")]
		public TeamMemberResponse[] TeamMembers;

		[JsonProperty("team_type")]
		[Token(Token = "0x4001D44")]
		[FieldOffset(Offset = "0x48")]
		public int TeamType;

		[JsonProperty("weekly_helps")]
		[Token(Token = "0x4001D45")]
		[FieldOffset(Offset = "0x4C")]
		public int WeeklyHelps;

		[JsonProperty("online_count")]
		[Token(Token = "0x4001D46")]
		[FieldOffset(Offset = "0x50")]
		public int OnlineCount;

		[JsonProperty("country")]
		[Token(Token = "0x4001D47")]
		[FieldOffset(Offset = "0x58")]
		public string Country;

		[JsonProperty("team_stat")]
		[Token(Token = "0x4001D48")]
		[FieldOffset(Offset = "0x60")]
		public TeamStat TeamStat;

		[Token(Token = "0x600250E")]
		[Address(RVA = "0x3DFEE68", Offset = "0x3DFEE68", Length = "0x8")]
		public TeamResponse()
		{
		}
	}
}
