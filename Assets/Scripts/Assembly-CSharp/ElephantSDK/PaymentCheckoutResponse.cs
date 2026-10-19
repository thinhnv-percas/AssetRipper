using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x200096B")]
	public class PaymentCheckoutResponse
	{
		[JsonProperty("escrow_code")]
		[Token(Token = "0x4001FC4")]
		[FieldOffset(Offset = "0x10")]
		public string escrowCode;

		[JsonProperty("expiry")]
		[Token(Token = "0x4001FC5")]
		[FieldOffset(Offset = "0x18")]
		public long expiry;

		[Token(Token = "0x600283F")]
		[Address(RVA = "0x3E5058C", Offset = "0x3E5058C", Length = "0x8")]
		public PaymentCheckoutResponse()
		{
		}
	}
}
