using System.Collections.Generic;
using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x2000801")]
	public interface IHelpshiftUserLoginEventListener
	{
		[Token(Token = "0x60021F1")]
		void OnLoginSuccess();

		[Token(Token = "0x60021F2")]
		void OnLoginFailure(string reason, Dictionary<string, string> errorMap);
	}
}
