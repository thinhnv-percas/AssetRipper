using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000B5")]
	public interface IAppLifecycleHandler
	{
		[Token(Token = "0x60006E0")]
		void OnApplicationFocus(bool isFocus);

		[Token(Token = "0x60006E1")]
		void OnApplicationPause(bool isPaused);

		[Token(Token = "0x60006E2")]
		void OnApplicationQuit();
	}
}
