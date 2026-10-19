using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x2000966")]
	public class ElephantProduct
	{
		[JsonProperty("product_id")]
		[Token(Token = "0x4001FBF")]
		[FieldOffset(Offset = "0x10")]
		public string productId;

		[JsonProperty("price")]
		[Token(Token = "0x4001FC0")]
		[FieldOffset(Offset = "0x18")]
		public double price;

		[Token(Token = "0x6002836")]
		[Address(RVA = "0x3E504AC", Offset = "0x3E504AC", Length = "0x8")]
		public ElephantProduct()
		{
		}
	}
}
