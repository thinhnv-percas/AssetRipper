using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000010")]
	public interface ITransactionContextProvider
	{
		[Token(Token = "0x17000004")]
		int CurrentLevel
		{
			[Token(Token = "0x600003C")]
			get;
		}
	}
}
