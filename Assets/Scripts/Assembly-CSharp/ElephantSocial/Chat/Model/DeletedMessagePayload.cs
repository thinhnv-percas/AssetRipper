using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSocial.Chat.Model
{
	[Token(Token = "0x2000925")]
	public class DeletedMessagePayload
	{
		[JsonProperty("id")]
		[Token(Token = "0x17000438")]
		[field: Token(Token = "0x4001EAA")]
		[field: FieldOffset(Offset = "0x10")]
		public string Id
		{
			[Token(Token = "0x60026D1")]
			[Address(RVA = "0x3E184CC", Offset = "0x3E184CC", Length = "0x8")]
			get;
			[Token(Token = "0x60026D2")]
			[Address(RVA = "0x3E184D4", Offset = "0x3E184D4", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60026D3")]
		[Address(RVA = "0x3E184DC", Offset = "0x3E184DC", Length = "0x8")]
		public DeletedMessagePayload()
		{
		}
	}
}
