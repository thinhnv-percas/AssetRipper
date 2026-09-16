using System.Collections.Generic;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200000D")]
	public interface IAndroidPermissionRequired
	{
		[Token(Token = "0x6000064")]
		List<AndroidPermission> GetAndroidPermissions();
	}
}
