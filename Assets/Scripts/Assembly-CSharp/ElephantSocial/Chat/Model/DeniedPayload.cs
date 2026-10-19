using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000926")]
	public class DeniedPayload
	{
		[JsonProperty("reason")]
		[Token(Token = "0x17000439")]
		[field: Token(Token = "0x4001EAB")]
		[field: FieldOffset(Offset = "0x10")]
		public string Reason
		{
			[Token(Token = "0x60026D4")]
			[Address(RVA = "0x3E184E4", Offset = "0x3E184E4", Length = "0x8")]
			get;
			[Token(Token = "0x60026D5")]
			[Address(RVA = "0x3E184EC", Offset = "0x3E184EC", Length = "0x8")]
			set;
		}

		[JsonProperty("source_event_id")]
		[Token(Token = "0x1700043A")]
		[field: Token(Token = "0x4001EAC")]
		[field: FieldOffset(Offset = "0x18")]
		public string SourceEventId
		{
			[Token(Token = "0x60026D6")]
			[Address(RVA = "0x3E184F4", Offset = "0x3E184F4", Length = "0x8")]
			get;
			[Token(Token = "0x60026D7")]
			[Address(RVA = "0x3E184FC", Offset = "0x3E184FC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026D8")]
		[Address(RVA = "0x3E18504", Offset = "0x3E18504", Length = "0x8")]
		public DeniedPayload()
		{
		}
	}
}
