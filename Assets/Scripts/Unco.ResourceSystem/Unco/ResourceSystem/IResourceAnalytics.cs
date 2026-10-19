using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000D")]
	public interface IResourceAnalytics
	{
		[Token(Token = "0x6000025")]
		void RecordTransaction(ResourceType resourceType, long delta, long newAmount, TransactionContext context);
	}
}
