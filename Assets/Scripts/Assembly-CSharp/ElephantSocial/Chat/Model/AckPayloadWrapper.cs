using Cpp2ILInjected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x200092A")]
	public class AckPayloadWrapper
	{
		[JsonProperty("payload_type")]
		[Token(Token = "0x1700044E")]
		[field: Token(Token = "0x4001EC0")]
		[field: FieldOffset(Offset = "0x10")]
		public string PayloadType
		{
			[Token(Token = "0x6002702")]
			[Address(RVA = "0x3E186DC", Offset = "0x3E186DC", Length = "0x8")]
			get;
			[Token(Token = "0x6002703")]
			[Address(RVA = "0x3E186E4", Offset = "0x3E186E4", Length = "0x8")]
			set;
		}

		[JsonProperty("payload")]
		[Token(Token = "0x1700044F")]
		[field: Token(Token = "0x4001EC1")]
		[field: FieldOffset(Offset = "0x18")]
		public JObject Payload
		{
			[Token(Token = "0x6002704")]
			[Address(RVA = "0x3E186EC", Offset = "0x3E186EC", Length = "0x8")]
			get;
			[Token(Token = "0x6002705")]
			[Address(RVA = "0x3E186F4", Offset = "0x3E186F4", Length = "0x8")]
			set;
		}

		[JsonProperty("source_event_id")]
		[Token(Token = "0x17000450")]
		[field: Token(Token = "0x4001EC2")]
		[field: FieldOffset(Offset = "0x20")]
		public string SourceEventId
		{
			[Token(Token = "0x6002706")]
			[Address(RVA = "0x3E186FC", Offset = "0x3E186FC", Length = "0x8")]
			get;
			[Token(Token = "0x6002707")]
			[Address(RVA = "0x3E18704", Offset = "0x3E18704", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6002708")]
		[Address(RVA = "0x3E1870C", Offset = "0x3E1870C", Length = "0x8")]
		public AckPayloadWrapper()
		{
		}
	}
}
