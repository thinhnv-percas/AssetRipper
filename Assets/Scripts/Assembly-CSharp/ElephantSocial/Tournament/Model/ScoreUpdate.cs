using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Tournament.Model
{
	[Serializable]
	[Token(Token = "0x2000863")]
	public class ScoreUpdate
	{
		[JsonProperty("social_id")]
		[Token(Token = "0x170003C9")]
		[field: Token(Token = "0x4001C2E")]
		[field: FieldOffset(Offset = "0x10")]
		public string SocialId
		{
			[Token(Token = "0x600240B")]
			[Address(RVA = "0x3DE9488", Offset = "0x3DE9488", Length = "0x8")]
			get;
			[Token(Token = "0x600240C")]
			[Address(RVA = "0x3DE9490", Offset = "0x3DE9490", Length = "0x8")]
			set;
		}

		[JsonProperty("score")]
		[Token(Token = "0x170003CA")]
		[field: Token(Token = "0x4001C2F")]
		[field: FieldOffset(Offset = "0x18")]
		public int Score
		{
			[Token(Token = "0x600240D")]
			[Address(RVA = "0x3DE9498", Offset = "0x3DE9498", Length = "0x8")]
			get;
			[Token(Token = "0x600240E")]
			[Address(RVA = "0x3DE94A0", Offset = "0x3DE94A0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600240F")]
		[Address(RVA = "0x3DE94A8", Offset = "0x3DE94A8", Length = "0x8")]
		public ScoreUpdate()
		{
		}

		[Token(Token = "0x6002410")]
		[Address(RVA = "0x3DE94B0", Offset = "0x3DE94B0", Length = "0x48")]
		public ScoreUpdate(string socialId, int score)
		{
			SocialId = socialId;
			Score = score;
		}
	}
}
