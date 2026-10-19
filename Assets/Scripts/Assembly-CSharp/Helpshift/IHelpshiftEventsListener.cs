using System.Collections.Generic;
using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x20007FF")]
	public interface IHelpshiftEventsListener
	{
		[Token(Token = "0x60021EE")]
		void HandleHelpshiftEvent(string eventName, Dictionary<string, object> eventData);

		[Token(Token = "0x60021EF")]
		void AuthenticationFailedForUser(HelpshiftAuthenticationFailureReason reason);
	}
}
