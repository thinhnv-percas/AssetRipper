using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x2000964")]
	public class ElephantPayment
	{
		[JsonProperty("purchased_product")]
		[Token(Token = "0x4001FB8")]
		[FieldOffset(Offset = "0x10")]
		public ElephantProduct purchasedProduct;

		[JsonProperty("transaction_id")]
		[Token(Token = "0x4001FB9")]
		[FieldOffset(Offset = "0x18")]
		public string transactionId;

		[Token(Token = "0x6002834")]
		[Address(RVA = "0x3E4EB20", Offset = "0x3E4EB20", Length = "0x8")]
		public ElephantPayment()
		{
		}
	}
}
