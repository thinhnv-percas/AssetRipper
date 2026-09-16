using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000003")]
	public interface INativeTizenStore : INativeStore
	{
		[Token(Token = "0x6000005")]
		void SetUnityPurchasingCallback(UnityNativePurchasingCallback AsyncCallback);

		[Token(Token = "0x6000006")]
		void SetGroupId(string group);
	}
}
