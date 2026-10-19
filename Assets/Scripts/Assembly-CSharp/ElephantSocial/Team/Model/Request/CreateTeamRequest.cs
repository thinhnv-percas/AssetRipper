using Cpp2ILInjected;
using ElephantSocial.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model.Request
{
	[Token(Token = "0x20008B3")]
	public class CreateTeamRequest : SocialBaseData
	{
		[JsonProperty("badge")]
		[Token(Token = "0x4001D4A")]
		[FieldOffset(Offset = "0x118")]
		public int Badge;

		[JsonProperty("capacity")]
		[Token(Token = "0x4001D4B")]
		[FieldOffset(Offset = "0x11C")]
		public int Capacity;

		[JsonProperty("name")]
		[Token(Token = "0x4001D4C")]
		[FieldOffset(Offset = "0x120")]
		public string Name;

		[JsonProperty("required_level")]
		[Token(Token = "0x4001D4D")]
		[FieldOffset(Offset = "0x128")]
		public int RequiredLevel;

		[JsonProperty("team_type")]
		[Token(Token = "0x4001D4E")]
		[FieldOffset(Offset = "0x12C")]
		public int TeamType;

		[JsonProperty("description")]
		[Token(Token = "0x4001D4F")]
		[FieldOffset(Offset = "0x130")]
		public string Description;

		[Token(Token = "0x6002511")]
		[Address(RVA = "0x3DEE674", Offset = "0x3DEE674", Length = "0x4")]
		public CreateTeamRequest()
		{
		}
	}
}
