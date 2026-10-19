using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000A")]
	public interface IResourceQuery
	{
		[Token(Token = "0x6000015")]
		double GetAmount(ResourceType resourceType);

		[Token(Token = "0x6000016")]
		bool IsEnough(ResourceType resourceType, double amount);

		[Token(Token = "0x6000017")]
		bool IsInfinite(ResourceType resourceType);

		[Token(Token = "0x6000018")]
		ResourceSnapshot GetSnapshot(ResourceType resourceType);
	}
}
