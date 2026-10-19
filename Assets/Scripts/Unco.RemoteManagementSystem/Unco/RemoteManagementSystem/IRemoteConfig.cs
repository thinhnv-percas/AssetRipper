using System.Collections.Generic;
using Cpp2ILInjected;

namespace Unco.RemoteManagementSystem
{
	[Token(Token = "0x200000E")]
	public interface IRemoteConfig
	{
		[Token(Token = "0x600002D")]
		string Get(string key, string def = null);

		[Token(Token = "0x600002E")]
		float GetFloat(string key, float def = 0f);

		[Token(Token = "0x600002F")]
		int GetInt(string key, int def = 0);

		[Token(Token = "0x6000030")]
		bool GetBool(string key, bool def = false);

		[Token(Token = "0x6000031")]
		List<string> GetKeys();
	}
}
