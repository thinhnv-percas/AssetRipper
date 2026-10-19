using System;
using Cpp2ILInjected;
using ElephantSocial.Team.Model.Response;
using Newtonsoft.Json;

namespace ElephantSocial.Model
{
	[Serializable]
	[Token(Token = "0x20008C4")]
	public class Player
	{
		[JsonProperty("player_name")]
		[Token(Token = "0x4001D70")]
		[FieldOffset(Offset = "0x10")]
		public string playerName;

		[JsonProperty]
		[Token(Token = "0x4001D71")]
		[FieldOffset(Offset = "0x18")]
		public string country;

		[JsonProperty("social_id")]
		[Token(Token = "0x4001D72")]
		[FieldOffset(Offset = "0x20")]
		public string socialId;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001D73")]
		[FieldOffset(Offset = "0x28")]
		public string profilePicture;

		[Token(Token = "0x4001D74")]
		[FieldOffset(Offset = "0x30")]
		public string content;

		[Token(Token = "0x4001D75")]
		[FieldOffset(Offset = "0x38")]
		public int status;

		[Token(Token = "0x4001D76")]
		[FieldOffset(Offset = "0x3C")]
		public int badge;

		[JsonProperty("server_id")]
		[Token(Token = "0x4001D77")]
		[FieldOffset(Offset = "0x40")]
		public int serverId;

		[JsonProperty("team")]
		[Token(Token = "0x4001D78")]
		[FieldOffset(Offset = "0x48")]
		public TeamResponse team;

		[Token(Token = "0x6002527")]
		[Address(RVA = "0x3DFF134", Offset = "0x3DFF134", Length = "0xD0")]
		public void FillBaseData(Player player)
		{
			playerName = player.playerName;
			string text = ((player.profilePicture != null) ? player.profilePicture : "");
			profilePicture = text;
			status = player.status;
			socialId = player.socialId;
			country = player.country;
			content = player.content;
			team = player.team;
			badge = player.badge;
			serverId = (int)((uint)player.badge >> 32);
		}

		[Token(Token = "0x6002528")]
		[Address(RVA = "0x3DFF204", Offset = "0x3DFF204", Length = "0x78")]
		public Player Clone()
		{
			Player player = new Player();
			player.FillBaseData(this);
			return player;
		}

		[Token(Token = "0x6002529")]
		[Address(RVA = "0x3DF5588", Offset = "0x3DF5588", Length = "0x8")]
		public Player()
		{
		}
	}
}
