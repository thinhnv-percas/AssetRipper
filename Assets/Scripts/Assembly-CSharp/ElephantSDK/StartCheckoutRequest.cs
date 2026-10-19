using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x200096A")]
	public class StartCheckoutRequest : BaseData
	{
		[JsonProperty("product_id")]
		[Token(Token = "0x4001FC2")]
		[FieldOffset(Offset = "0x110")]
		public string productId;

		[JsonProperty("is_test")]
		[Token(Token = "0x4001FC3")]
		[FieldOffset(Offset = "0x118")]
		public bool isTest;

		[Token(Token = "0x600283D")]
		[Address(RVA = "0x3E4D8CC", Offset = "0x3E4D8CC", Length = "0xDC")]
		public static StartCheckoutRequest Create(string productId, bool isTest)
		{
			StartCheckoutRequest startCheckoutRequest = (StartCheckoutRequest)new BaseData();
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			startCheckoutRequest.FillBaseData(currentSession.start_time);
			startCheckoutRequest.productId = productId;
			startCheckoutRequest.isTest = isTest;
			return startCheckoutRequest;
		}

		[Token(Token = "0x600283E")]
		[Address(RVA = "0x3E50584", Offset = "0x3E50584", Length = "0x8")]
		public StartCheckoutRequest()
		{
		}
	}
}
