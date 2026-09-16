using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000016")]
	public interface IInitListener
	{
		[Token(Token = "0x6000072")]
		void OnInitialized(UserInfo userInfo);

		[Token(Token = "0x6000073")]
		void OnInitializeFailed(string message);
	}
}
