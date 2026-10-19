using Cpp2ILInjected;

namespace Unco.SaveSystem.Core
{
	[Token(Token = "0x200000A")]
	public interface IDataHandler : IDataLoader, IDataSaver
	{
		[Token(Token = "0x6000022")]
		void DeleteData(string key);
	}
}
