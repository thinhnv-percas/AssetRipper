using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000020")]
	internal interface ILoggingService
	{
		[Token(Token = "0x6000086")]
		void LogMessage(PlatformLogLevel level, string message);
	}
}
