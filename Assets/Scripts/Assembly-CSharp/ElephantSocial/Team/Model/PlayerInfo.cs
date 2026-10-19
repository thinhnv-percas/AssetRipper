using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Team.Model
{
	[Serializable]
	[Token(Token = "0x20008AA")]
	public class PlayerInfo
	{
		[JsonProperty("player_name")]
		[Token(Token = "0x4001D26")]
		[FieldOffset(Offset = "0x10")]
		public string PlayerName;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001D27")]
		[FieldOffset(Offset = "0x18")]
		public string ProfilePicture;

		[JsonProperty("status")]
		[Token(Token = "0x4001D28")]
		[FieldOffset(Offset = "0x20")]
		public int Status;

		[JsonProperty("badge")]
		[Token(Token = "0x4001D29")]
		[FieldOffset(Offset = "0x24")]
		public int Badge;

		[JsonProperty("country")]
		[Token(Token = "0x4001D2A")]
		[FieldOffset(Offset = "0x28")]
		public string Country;

		[JsonProperty("level")]
		[Token(Token = "0x4001D2B")]
		[FieldOffset(Offset = "0x30")]
		public string Level;

		[Token(Token = "0x6002508")]
		[Address(RVA = "0x3DFED00", Offset = "0x3DFED00", Length = "0x8")]
		public PlayerInfo()
		{
		}
	}
}
