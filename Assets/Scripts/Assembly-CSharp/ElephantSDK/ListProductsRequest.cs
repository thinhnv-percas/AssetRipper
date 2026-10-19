using System;
using Cpp2ILInjected;

namespace ElephantSDK
{
	[Serializable]
	[Token(Token = "0x2000968")]
	public class ListProductsRequest : BaseData
	{
		[Token(Token = "0x6002839")]
		[Address(RVA = "0x3E504BC", Offset = "0x3E504BC", Length = "0xB8")]
		public static ListProductsRequest Create()
		{
			ListProductsRequest listProductsRequest = (ListProductsRequest)new BaseData();
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			listProductsRequest.FillBaseData(currentSession.start_time);
			return listProductsRequest;
		}

		[Token(Token = "0x600283A")]
		[Address(RVA = "0x3E50574", Offset = "0x3E50574", Length = "0x8")]
		public ListProductsRequest()
		{
		}
	}
}
