using System.Security.Cryptography.X509Certificates;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x200001C")]
	public interface ICertificateService
	{
		[Token(Token = "0x6000081")]
		X509CertificateCollection Install(IFirebaseAppPlatform app);
	}
}
