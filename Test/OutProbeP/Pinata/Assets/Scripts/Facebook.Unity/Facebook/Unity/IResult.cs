using System.Collections.Generic;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200002F")]
	public interface IResult
	{
		[Token(Token = "0x1700003F")]
		string Error
		{
			[Token(Token = "0x60000FD")]
			get;
		}

		[Token(Token = "0x17000040")]
		IDictionary<string, object> ResultDictionary
		{
			[Token(Token = "0x60000FE")]
			get;
		}

		[Token(Token = "0x17000041")]
		string RawResult
		{
			[Token(Token = "0x60000FF")]
			get;
		}

		[Token(Token = "0x17000042")]
		bool Cancelled
		{
			[Token(Token = "0x6000100")]
			get;
		}
	}
}
