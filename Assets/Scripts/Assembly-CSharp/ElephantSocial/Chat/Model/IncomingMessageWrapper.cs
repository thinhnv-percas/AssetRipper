using Cpp2ILInjected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200092B")]
	public class IncomingMessageWrapper
	{
		[JsonProperty("id")]
		[Token(Token = "0x17000451")]
		[field: Token(Token = "0x4001EC3")]
		[field: FieldOffset(Offset = "0x10")]
		public string Id
		{
			[Token(Token = "0x6002709")]
			[Address(RVA = "0x3E18714", Offset = "0x3E18714", Length = "0x8")]
			get;
			[Token(Token = "0x600270A")]
			[Address(RVA = "0x3E1871C", Offset = "0x3E1871C", Length = "0x8")]
			set;
		}

		[JsonProperty("type")]
		[Token(Token = "0x17000452")]
		[field: Token(Token = "0x4001EC4")]
		[field: FieldOffset(Offset = "0x18")]
		public string Type
		{
			[Token(Token = "0x600270B")]
			[Address(RVA = "0x3E18724", Offset = "0x3E18724", Length = "0x8")]
			get;
			[Token(Token = "0x600270C")]
			[Address(RVA = "0x3E1872C", Offset = "0x3E1872C", Length = "0x8")]
			set;
		}

		[JsonProperty("channel")]
		[Token(Token = "0x17000453")]
		[field: Token(Token = "0x4001EC5")]
		[field: FieldOffset(Offset = "0x20")]
		public string Channel
		{
			[Token(Token = "0x600270D")]
			[Address(RVA = "0x3E18734", Offset = "0x3E18734", Length = "0x8")]
			get;
			[Token(Token = "0x600270E")]
			[Address(RVA = "0x3E1873C", Offset = "0x3E1873C", Length = "0x8")]
			set;
		}

		[JsonProperty("payload")]
		[Token(Token = "0x17000454")]
		[field: Token(Token = "0x4001EC6")]
		[field: FieldOffset(Offset = "0x28")]
		public JObject Payload
		{
			[Token(Token = "0x600270F")]
			[Address(RVA = "0x3E18744", Offset = "0x3E18744", Length = "0x8")]
			get;
			[Token(Token = "0x6002710")]
			[Address(RVA = "0x3E1874C", Offset = "0x3E1874C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002711")]
		[Address(RVA = "0x3E18754", Offset = "0x3E18754", Length = "0x8")]
		public IncomingMessageWrapper()
		{
		}
	}
}
