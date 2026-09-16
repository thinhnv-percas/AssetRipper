using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.Android
{
	[Token(Token = "0x200006C")]
	internal interface IAndroidWrapper
	{
		[Token(Token = "0x60002A3")]
		T CallStatic<T>(string methodName);

		[Token(Token = "0x60002A4")]
		void CallStatic(string methodName, params object[] args);
	}
}
