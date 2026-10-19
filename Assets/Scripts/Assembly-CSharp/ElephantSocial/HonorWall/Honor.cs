using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.HonorWall
{
	[Serializable]
	[Token(Token = "0x20008F3")]
	public class Honor
	{
		[Token(Token = "0x170003E5")]
		[field: Token(Token = "0x4001DE2")]
		[field: FieldOffset(Offset = "0x10")]
		public int id
		{
			[Token(Token = "0x600259E")]
			[Address(RVA = "0x3E087F4", Offset = "0x3E087F4", Length = "0x8")]
			get;
			[Token(Token = "0x600259F")]
			[Address(RVA = "0x3E087FC", Offset = "0x3E087FC", Length = "0x8")]
			set;
		}

		[JsonProperty("name")]
		[Token(Token = "0x170003E6")]
		[field: Token(Token = "0x4001DE3")]
		[field: FieldOffset(Offset = "0x18")]
		public string name
		{
			[Token(Token = "0x60025A0")]
			[Address(RVA = "0x3E08804", Offset = "0x3E08804", Length = "0x8")]
			get;
			[Token(Token = "0x60025A1")]
			[Address(RVA = "0x3E0880C", Offset = "0x3E0880C", Length = "0x8")]
			set;
		}

		[JsonProperty("description")]
		[Token(Token = "0x170003E7")]
		[field: Token(Token = "0x4001DE4")]
		[field: FieldOffset(Offset = "0x20")]
		public string description
		{
			[Token(Token = "0x60025A2")]
			[Address(RVA = "0x3E08814", Offset = "0x3E08814", Length = "0x8")]
			get;
			[Token(Token = "0x60025A3")]
			[Address(RVA = "0x3E0881C", Offset = "0x3E0881C", Length = "0x8")]
			set;
		}

		[JsonProperty("social_id")]
		[Token(Token = "0x170003E8")]
		[field: Token(Token = "0x4001DE5")]
		[field: FieldOffset(Offset = "0x28")]
		public string social_id
		{
			[Token(Token = "0x60025A4")]
			[Address(RVA = "0x3E08824", Offset = "0x3E08824", Length = "0x8")]
			get;
			[Token(Token = "0x60025A5")]
			[Address(RVA = "0x3E0882C", Offset = "0x3E0882C", Length = "0x8")]
			set;
		}

		[JsonProperty("player_name")]
		[Token(Token = "0x170003E9")]
		[field: Token(Token = "0x4001DE6")]
		[field: FieldOffset(Offset = "0x30")]
		public string player_name
		{
			[Token(Token = "0x60025A6")]
			[Address(RVA = "0x3E08834", Offset = "0x3E08834", Length = "0x8")]
			get;
			[Token(Token = "0x60025A7")]
			[Address(RVA = "0x3E0883C", Offset = "0x3E0883C", Length = "0x8")]
			set;
		}

		[JsonProperty("unlocked_at")]
		[Token(Token = "0x170003EA")]
		[field: Token(Token = "0x4001DE7")]
		[field: FieldOffset(Offset = "0x38")]
		public long unlocked_at
		{
			[Token(Token = "0x60025A8")]
			[Address(RVA = "0x3E08844", Offset = "0x3E08844", Length = "0x8")]
			get;
			[Token(Token = "0x60025A9")]
			[Address(RVA = "0x3E0884C", Offset = "0x3E0884C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60025AA")]
		[Address(RVA = "0x3E08854", Offset = "0x3E08854", Length = "0x8")]
		public Honor()
		{
		}
	}
}
