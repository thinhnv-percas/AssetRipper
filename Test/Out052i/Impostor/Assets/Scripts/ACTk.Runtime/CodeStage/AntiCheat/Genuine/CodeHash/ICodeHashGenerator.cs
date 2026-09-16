using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x2000032")]
	public interface ICodeHashGenerator
	{
		[Token(Token = "0x17000028")]
		HashGeneratorResult LastResult
		{
			[Token(Token = "0x600036D")]
			get;
		}

		[Token(Token = "0x17000029")]
		bool IsBusy
		{
			[Token(Token = "0x600036E")]
			get;
		}

		[Token(Token = "0x600036F")]
		ICodeHashGenerator Generate();
	}
}
