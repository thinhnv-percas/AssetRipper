using System;
using Cpp2ILInjected;
using ElephantSocial.Team.Model;
using Newtonsoft.Json;

namespace ElephantSocial.Inbox.Model
{
	[Serializable]
	[Token(Token = "0x20008EA")]
	public class InboxItem
	{
		[JsonProperty("id")]
		[Token(Token = "0x4001DD6")]
		[FieldOffset(Offset = "0x10")]
		public int Id;

		[JsonProperty("owner_social_id")]
		[Token(Token = "0x4001DD7")]
		[FieldOffset(Offset = "0x18")]
		public string OwnerSocialId;

		[JsonProperty("sender_social_id")]
		[Token(Token = "0x4001DD8")]
		[FieldOffset(Offset = "0x20")]
		public string SenderSocialId;

		[JsonProperty("sender_player_info")]
		[Token(Token = "0x4001DD9")]
		[FieldOffset(Offset = "0x28")]
		public PlayerInfo SenderPlayerInfo;

		[JsonProperty("metadata")]
		[Token(Token = "0x4001DDA")]
		[FieldOffset(Offset = "0x30")]
		public string Metadata;

		[JsonProperty("created_at")]
		[Token(Token = "0x4001DDB")]
		[FieldOffset(Offset = "0x38")]
		public string CreatedAt;

		[Token(Token = "0x600258F")]
		[Address(RVA = "0x3E08000", Offset = "0x3E08000", Length = "0x8")]
		public InboxItem()
		{
		}
	}
}
