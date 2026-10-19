using System;
using Cpp2ILInjected;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x2000967")]
	public class ListPaymentsRequest : BaseData
	{
		[Token(Token = "0x6002837")]
		[Address(RVA = "0x3E4D31C", Offset = "0x3E4D31C", Length = "0xB8")]
		public static ListPaymentsRequest Create()
		{
			ListPaymentsRequest listPaymentsRequest = (ListPaymentsRequest)new BaseData();
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			listPaymentsRequest.FillBaseData(currentSession.start_time);
			return listPaymentsRequest;
		}

		[Token(Token = "0x6002838")]
		[Address(RVA = "0x3E504B4", Offset = "0x3E504B4", Length = "0x8")]
		public ListPaymentsRequest()
		{
		}
	}
}
