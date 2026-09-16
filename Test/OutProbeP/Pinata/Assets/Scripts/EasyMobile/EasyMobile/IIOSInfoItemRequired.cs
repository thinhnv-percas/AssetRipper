using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200000E")]
	public interface IIOSInfoItemRequired
	{
		[Token(Token = "0x6000065")]
		List<iOSInfoPlistItem> GetIOSInfoPlistKeys();
	}
}
