using System;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x2000969")]
	public class MarkPaymentProcessedRequest : BaseData
	{
		[JsonProperty("transaction_id")]
		[Token(Token = "0x4001FC1")]
		[FieldOffset(Offset = "0x110")]
		public string transactionId;

		[Token(Token = "0x600283B")]
		[Address(RVA = "0x3E4EE04", Offset = "0x3E4EE04", Length = "0xCC")]
		public static MarkPaymentProcessedRequest Create(string transactionId)
		{
			MarkPaymentProcessedRequest markPaymentProcessedRequest = (MarkPaymentProcessedRequest)new BaseData();
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			markPaymentProcessedRequest.FillBaseData(currentSession.start_time);
			markPaymentProcessedRequest.transactionId = transactionId;
			return markPaymentProcessedRequest;
		}

		[Token(Token = "0x600283C")]
		[Address(RVA = "0x3E5057C", Offset = "0x3E5057C", Length = "0x8")]
		public MarkPaymentProcessedRequest()
		{
		}
	}
}
