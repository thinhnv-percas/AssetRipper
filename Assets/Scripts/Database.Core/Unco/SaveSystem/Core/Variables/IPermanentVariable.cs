using System;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x200000F")]
	public interface IPermanentVariable
	{
		[Token(Token = "0x17000004")]
		string SaveKey
		{
			[Token(Token = "0x600003E")]
			get;
		}

		[Token(Token = "0x600003F")]
		void DeleteData();

		[Token(Token = "0x6000040")]
		SaveData GetRawData(bool isLocal);

		[Token(Token = "0x6000041")]
		void SetRawData(SaveData data, bool isLocal);

		[Token(Token = "0x6000042")]
		object GetCurrentValue();

		[Token(Token = "0x6000043")]
		void SetCurrentValue(object o);

		[Token(Token = "0x6000044")]
		void SetPendingToCurrent();

		[Token(Token = "0x6000045")]
		void SaveLocalFromCurrent();

		[Token(Token = "0x6000046")]
		DateTime GetLastSavedTime(bool isLocal);
	}
}
