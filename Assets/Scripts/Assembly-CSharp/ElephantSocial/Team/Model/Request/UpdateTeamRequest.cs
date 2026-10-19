using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008C0")]
	public class UpdateTeamRequest : SocialBaseData
	{
		[JsonProperty("badge")]
		[Token(Token = "0x4001D5A")]
		[FieldOffset(Offset = "0x118")]
		public int Badge;

		[JsonProperty("capacity")]
		[Token(Token = "0x4001D5B")]
		[FieldOffset(Offset = "0x11C")]
		public int Capacity;

		[JsonProperty("description")]
		[Token(Token = "0x4001D5C")]
		[FieldOffset(Offset = "0x120")]
		public string Description;

		[JsonProperty("name")]
		[Token(Token = "0x4001D5D")]
		[FieldOffset(Offset = "0x128")]
		public string Name;

		[JsonProperty("required_level")]
		[Token(Token = "0x4001D5E")]
		[FieldOffset(Offset = "0x130")]
		public int RequiredLevel;

		[JsonProperty("team_type")]
		[Token(Token = "0x4001D5F")]
		[FieldOffset(Offset = "0x134")]
		public int TeamType;

		[Token(Token = "0x6002522")]
		[Address(RVA = "0x3DEEF64", Offset = "0x3DEEF64", Length = "0x4")]
		public UpdateTeamRequest()
		{
		}
	}
}
