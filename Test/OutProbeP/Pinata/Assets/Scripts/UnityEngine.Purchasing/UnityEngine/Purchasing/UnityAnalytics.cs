using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200001C")]
	internal class UnityAnalytics : IUnityAnalytics
	{
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x16112AC", Offset = "0x16112AC", Length = "0x8")]
		public UnityAnalytics()
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x16112B4", Offset = "0x16112B4", Length = "0x28")]
		public void Transaction(string productId, decimal price, string currency, string receipt, string signature)
		{
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x16112DC", Offset = "0x16112DC", Length = "0x10")]
		public void CustomEvent(string name, Dictionary<string, object> data)
		{
		}
	}
}
