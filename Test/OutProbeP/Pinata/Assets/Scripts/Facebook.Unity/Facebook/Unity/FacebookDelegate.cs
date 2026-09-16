using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000014")]
	public delegate void FacebookDelegate<T>(T result) where T : IResult;
}
