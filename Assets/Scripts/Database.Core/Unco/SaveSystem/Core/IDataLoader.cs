using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core
{
	[Token(Token = "0x200000B")]
	public interface IDataLoader
	{
		[Token(Token = "0x6000023")]
		void LoadFloat(string key, Action<float> onComplete, float defaultValue = 0f);

		[Token(Token = "0x6000024")]
		void LoadInt(string key, Action<int> onComplete, int defaultValue = 0);

		[Token(Token = "0x6000025")]
		void LoadString(string key, Action<string> onComplete, string defaultValue = "");

		[Token(Token = "0x6000026")]
		void LoadJson<T>(string key, Action<T> onComplete, T defaultValue = default(T));

		[Token(Token = "0x6000027")]
		Task<Dictionary<string, object>> LoadUserDataAsync();
	}
}
