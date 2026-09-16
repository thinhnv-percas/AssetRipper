using Cpp2ILInjected;

namespace Mycom.Tracker.Unity
{
	[Token(Token = "0x2000002")]
	public enum GenderEnum : short
	{
		[Token(Token = "0x4000002")]
		Female = 2,
		[Token(Token = "0x4000003")]
		Male = 1,
		[Token(Token = "0x4000004")]
		None = 0,
		[Token(Token = "0x4000005")]
		Unspecified = -1
	}
}
