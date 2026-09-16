using System;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200008C")]
	public interface IConsentRequirable
	{
		[Token(Token = "0x170001B0")]
		ConsentStatus DataPrivacyConsent
		{
			[Token(Token = "0x60005EE")]
			get;
		}

		[Token(Token = "0x14000034")]
		event Action<ConsentStatus> DataPrivacyConsentUpdated;

		[Token(Token = "0x60005EF")]
		void GrantDataPrivacyConsent();

		[Token(Token = "0x60005F0")]
		void RevokeDataPrivacyConsent();
	}
}
