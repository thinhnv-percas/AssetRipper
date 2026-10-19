using Cpp2ILInjected;

namespace Unco.SaveSystem.Runtime.DataSyncronization
{
	[Token(Token = "0x2000004")]
	public interface IDataSyncer
	{
		[Token(Token = "0x6000003")]
		void SyncFloat(string key);

		[Token(Token = "0x6000004")]
		void SyncString(string key);

		[Token(Token = "0x6000005")]
		void SyncJson<T>(string key);

		[Token(Token = "0x6000006")]
		void SyncInt(string key);
	}
}
