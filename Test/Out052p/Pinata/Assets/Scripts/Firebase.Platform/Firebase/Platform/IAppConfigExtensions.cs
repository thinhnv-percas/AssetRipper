using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x200001A")]
	internal interface IAppConfigExtensions
	{
		[Token(Token = "0x600007F")]
		string GetWriteablePath(IFirebaseAppPlatform app);

		[Token(Token = "0x6000080")]
		string GetCertPemFile(IFirebaseAppPlatform app);
	}
}
