using Cpp2ILInjected;

namespace YMMJSONUtils
{
	[Token(Token = "0x200001B")]
	public enum IntegerSize
	{
		[Token(Token = "0x4000045")]
		UInt64 = 0,
		[Token(Token = "0x4000046")]
		Int64 = 1,
		[Token(Token = "0x4000047")]
		UInt32 = 2,
		[Token(Token = "0x4000048")]
		Int32 = 3,
		[Token(Token = "0x4000049")]
		UInt16 = 4,
		[Token(Token = "0x400004A")]
		Int16 = 5,
		[Token(Token = "0x400004B")]
		UInt8 = 6,
		[Token(Token = "0x400004C")]
		Int8 = 7
	}
}
