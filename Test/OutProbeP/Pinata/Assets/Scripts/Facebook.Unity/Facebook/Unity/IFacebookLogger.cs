using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200003B")]
	internal interface IFacebookLogger
	{
		[Token(Token = "0x6000144")]
		void Log(string msg);

		[Token(Token = "0x6000145")]
		void Info(string msg);

		[Token(Token = "0x6000146")]
		void Warn(string msg);
	}
}
