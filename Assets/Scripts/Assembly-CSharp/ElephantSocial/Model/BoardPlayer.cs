using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Model
{
	[Serializable]
	[Token(Token = "0x20008C3")]
	public class BoardPlayer
	{
		[JsonProperty("player_name")]
		[Token(Token = "0x4001D68")]
		[FieldOffset(Offset = "0x10")]
		public string playerName;

		[JsonProperty]
		[Token(Token = "0x4001D69")]
		[FieldOffset(Offset = "0x18")]
		public string country;

		[JsonProperty("social_id")]
		[Token(Token = "0x4001D6A")]
		[FieldOffset(Offset = "0x20")]
		public string socialId;

		[JsonProperty("profile_picture")]
		[Token(Token = "0x4001D6B")]
		[FieldOffset(Offset = "0x28")]
		public string profilePicture;

		[Token(Token = "0x4001D6C")]
		[FieldOffset(Offset = "0x30")]
		public int status;

		[Token(Token = "0x4001D6D")]
		[FieldOffset(Offset = "0x34")]
		public int badge;

		[Token(Token = "0x4001D6E")]
		[FieldOffset(Offset = "0x38")]
		public int score;

		[JsonProperty("server_id")]
		[Token(Token = "0x4001D6F")]
		[FieldOffset(Offset = "0x3C")]
		public int serverId;

		[Token(Token = "0x6002523")]
		[Address(RVA = "0x3DFEF38", Offset = "0x3DFEF38", Length = "0xB8")]
		public void FillBaseData(Player player)
		{
			playerName = player.playerName;
			string text = ((player.profilePicture != null) ? player.profilePicture : "");
			profilePicture = text;
			status = player.status;
			socialId = player.socialId;
			country = player.country;
			badge = player.badge;
			serverId = player.serverId;
		}

		[Token(Token = "0x6002524")]
		[Address(RVA = "0x3DFEFF0", Offset = "0x3DFEFF0", Length = "0xBC")]
		public void FillBaseData(BoardPlayer player)
		{
			playerName = player.playerName;
			string text = ((player.profilePicture != null) ? player.profilePicture : "");
			profilePicture = text;
			status = player.status;
			socialId = player.socialId;
			country = player.country;
			badge = player.badge;
			serverId = player.serverId;
		}

		[Token(Token = "0x6002525")]
		[Address(RVA = "0x3DFF0AC", Offset = "0x3DFF0AC", Length = "0x80")]
		public BoardPlayer Clone()
		{
			BoardPlayer boardPlayer = new BoardPlayer();
			boardPlayer.FillBaseData(this);
			boardPlayer.score = score;
			return boardPlayer;
		}

		[Token(Token = "0x6002526")]
		[Address(RVA = "0x3DFF12C", Offset = "0x3DFF12C", Length = "0x8")]
		public BoardPlayer()
		{
		}
	}
}
