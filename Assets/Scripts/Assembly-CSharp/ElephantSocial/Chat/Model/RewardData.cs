using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000913")]
	public class RewardData
	{
		[JsonProperty("reward_id")]
		[Token(Token = "0x17000403")]
		[field: Token(Token = "0x4001E6C")]
		[field: FieldOffset(Offset = "0x10")]
		public string RewardId
		{
			[Token(Token = "0x6002655")]
			[Address(RVA = "0x3E17D2C", Offset = "0x3E17D2C", Length = "0x8")]
			get;
			[Token(Token = "0x6002656")]
			[Address(RVA = "0x3E17D34", Offset = "0x3E17D34", Length = "0x8")]
			set;
		}

		[JsonProperty("max_receiver")]
		[Token(Token = "0x17000404")]
		[field: Token(Token = "0x4001E6D")]
		[field: FieldOffset(Offset = "0x18")]
		public int MaxReceiver
		{
			[Token(Token = "0x6002657")]
			[Address(RVA = "0x3E17D3C", Offset = "0x3E17D3C", Length = "0x8")]
			get;
			[Token(Token = "0x6002658")]
			[Address(RVA = "0x3E17D44", Offset = "0x3E17D44", Length = "0x8")]
			set;
		}

		[JsonProperty("receivers")]
		[Token(Token = "0x17000405")]
		[field: Token(Token = "0x4001E6E")]
		[field: FieldOffset(Offset = "0x20")]
		public List<string> Receivers
		{
			[Token(Token = "0x6002659")]
			[Address(RVA = "0x3E17D4C", Offset = "0x3E17D4C", Length = "0x8")]
			get;
			[Token(Token = "0x600265A")]
			[Address(RVA = "0x3E17D54", Offset = "0x3E17D54", Length = "0x8")]
			set;
		}

		[Token(Token = "0x600265B")]
		[Address(RVA = "0x3E17D5C", Offset = "0x3E17D5C", Length = "0x8")]
		public RewardData()
		{
		}
	}
}
