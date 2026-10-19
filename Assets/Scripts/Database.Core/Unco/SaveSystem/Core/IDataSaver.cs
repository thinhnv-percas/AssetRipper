using System;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core
{
	[Token(Token = "0x200000C")]
	public interface IDataSaver
	{
		[Token(Token = "0x6000028")]
		void SaveFloat(string key, float value, Action<float> onSaveComplete = null);

		[Token(Token = "0x6000029")]
		void SaveInt(string key, int value, Action<int> onSaveComplete = null);

		[Token(Token = "0x600002A")]
		void SaveString(string key, string value, Action<string> onSaveComplete = null);

		[Token(Token = "0x600002B")]
		void SaveJson<T>(string key, T value, Action<T> onSaveComplete = null);
	}
}
