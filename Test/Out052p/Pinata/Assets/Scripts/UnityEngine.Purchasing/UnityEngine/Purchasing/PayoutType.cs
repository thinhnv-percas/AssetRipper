using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000C")]
	public enum PayoutType
	{
		[Token(Token = "0x4000012")]
		Other = 0,
		[Token(Token = "0x4000013")]
		Currency = 1,
		[Token(Token = "0x4000014")]
		Item = 2,
		[Token(Token = "0x4000015")]
		Resource = 3
	}
}
