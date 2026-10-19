using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Model
{
	[Serializable]
	[Token(Token = "0x20008C6")]
	public class PlayerUpdateRequest : SocialBaseData
	{
		[JsonProperty("player_name")]
		[Token(Token = "0x4001D79")]
		[FieldOffset(Offset = "0x118")]
		public string playerName;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001D7A")]
		[FieldOffset(Offset = "0x120")]
		public string profilePicture;

		[Token(Token = "0x4001D7B")]
		[FieldOffset(Offset = "0x128")]
		public string content;

		[Token(Token = "0x4001D7C")]
		[FieldOffset(Offset = "0x130")]
		public int status;

		[Token(Token = "0x4001D7D")]
		[FieldOffset(Offset = "0x134")]
		public int badge;

		[Token(Token = "0x600252B")]
		[Address(RVA = "0x3DFF27C", Offset = "0x3DFF27C", Length = "0x6C")]
		public PlayerUpdateRequest(Player player)
		{
			playerName = player.playerName;
			profilePicture = player.profilePicture;
			status = player.status;
			content = player.content;
			badge = player.badge;
		}
	}
}
