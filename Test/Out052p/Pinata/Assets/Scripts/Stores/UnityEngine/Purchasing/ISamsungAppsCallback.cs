using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002B")]
	internal interface ISamsungAppsCallback
	{
		[Token(Token = "0x60000A5")]
		void OnTransactionsRestored(bool result);
	}
}
