using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000009")]
	internal interface IUnityAnalytics
	{
		[Token(Token = "0x600001F")]
		void Transaction(string productId, decimal price, string currency, string receipt, string signature);

		[Token(Token = "0x6000020")]
		void CustomEvent(string name, Dictionary<string, object> data);
	}
}
