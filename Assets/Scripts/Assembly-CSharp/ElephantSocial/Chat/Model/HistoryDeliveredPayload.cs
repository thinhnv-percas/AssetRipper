using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000927")]
	public class HistoryDeliveredPayload
	{
		[JsonProperty("messages")]
		[Token(Token = "0x1700043B")]
		[field: Token(Token = "0x4001EAD")]
		[field: FieldOffset(Offset = "0x10")]
		public List<MessageContentPayload> Messages
		{
			[Token(Token = "0x60026D9")]
			[Address(RVA = "0x3E1850C", Offset = "0x3E1850C", Length = "0x8")]
			get;
			[Token(Token = "0x60026DA")]
			[Address(RVA = "0x3E18514", Offset = "0x3E18514", Length = "0x8")]
			set;
		}

		[JsonProperty("has_more")]
		[Token(Token = "0x1700043C")]
		[field: Token(Token = "0x4001EAE")]
		[field: FieldOffset(Offset = "0x18")]
		public bool HasMore
		{
			[Token(Token = "0x60026DB")]
			[Address(RVA = "0x3E1851C", Offset = "0x3E1851C", Length = "0x8")]
			get;
			[Token(Token = "0x60026DC")]
			[Address(RVA = "0x3E18524", Offset = "0x3E18524", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026DD")]
		[Address(RVA = "0x3E1852C", Offset = "0x3E1852C", Length = "0x8C")]
		public HistoryDeliveredPayload()
		{
			List<MessageContentPayload> list = new List<MessageContentPayload>();
			Messages = list;
		}
	}
}
