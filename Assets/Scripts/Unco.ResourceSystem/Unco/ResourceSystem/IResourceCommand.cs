using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000B")]
	public interface IResourceCommand
	{
		[Token(Token = "0x6000019")]
		void AddResource(ResourceType resourceType, double amount, TransactionContext context);

		[Token(Token = "0x600001A")]
		bool ConsumeResource(ResourceType resourceType, double amount, TransactionContext context);

		[Token(Token = "0x600001B")]
		void SetResource(ResourceType resourceType, double amount, TransactionContext context);

		[Token(Token = "0x600001C")]
		void SetInfinite(ResourceType resourceType, bool infinite, TransactionContext context);

		[Token(Token = "0x600001D")]
		void ResetResource(ResourceType resourceType, TransactionContext context);

		[Token(Token = "0x600001E")]
		void Mute();

		[Token(Token = "0x600001F")]
		void Unmute();
	}
}
