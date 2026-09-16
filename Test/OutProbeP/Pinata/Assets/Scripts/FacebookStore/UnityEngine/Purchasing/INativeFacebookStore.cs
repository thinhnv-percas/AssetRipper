using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000002")]
	public interface INativeFacebookStore : INativeStore
	{
		[Token(Token = "0x6000001")]
		bool Check();

		[Token(Token = "0x6000002")]
		void Init();

		[Token(Token = "0x6000003")]
		void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback);
	}
}
