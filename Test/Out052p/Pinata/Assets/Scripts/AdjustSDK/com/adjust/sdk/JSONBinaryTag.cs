using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000002")]
	public enum JSONBinaryTag
	{
		[Token(Token = "0x4000002")]
		Array = 1,
		[Token(Token = "0x4000003")]
		Class = 2,
		[Token(Token = "0x4000004")]
		Value = 3,
		[Token(Token = "0x4000005")]
		IntValue = 4,
		[Token(Token = "0x4000006")]
		DoubleValue = 5,
		[Token(Token = "0x4000007")]
		BoolValue = 6,
		[Token(Token = "0x4000008")]
		FloatValue = 7
	}
}
