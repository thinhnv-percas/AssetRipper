using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000008")]
	public interface ILicensingListener
	{
		[Token(Token = "0x6000017")]
		void allow(LicensingCode code, string message);

		[Token(Token = "0x6000018")]
		void dontAllow(LicensingCode code, string message);

		[Token(Token = "0x6000019")]
		void applicationError(LicensingErrorCode errorCode, string message);
	}
}
