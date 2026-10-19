using System.Collections.Generic;
using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x2000800")]
	public interface IHelpshiftProactiveAPIConfigCollector
	{
		[Token(Token = "0x60021F0")]
		Dictionary<string, object> getLocalApiConfig();
	}
}
