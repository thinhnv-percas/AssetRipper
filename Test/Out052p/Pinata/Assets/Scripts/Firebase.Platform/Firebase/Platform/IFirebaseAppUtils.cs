using System;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000028")]
	internal interface IFirebaseAppUtils
	{
		[Token(Token = "0x60000A4")]
		void TranslateDllNotFoundException(Action action);

		[Token(Token = "0x60000A5")]
		void PollCallbacks();

		[Token(Token = "0x60000A6")]
		IFirebaseAppPlatform GetDefaultInstance();

		[Token(Token = "0x60000A7")]
		string GetDefaultInstanceName();

		[Token(Token = "0x60000A8")]
		PlatformLogLevel GetLogLevel();
	}
}
