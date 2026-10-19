using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000C")]
	public interface IResourceRepository
	{
		[Token(Token = "0x6000020")]
		double Load(ResourceType resourceType);

		[Token(Token = "0x6000021")]
		void Save(ResourceType resourceType, double amount);

		[Token(Token = "0x6000022")]
		bool LoadInfiniteFlag(ResourceType resourceType);

		[Token(Token = "0x6000023")]
		void SaveInfiniteFlag(ResourceType resourceType, bool isInfinite);

		[Token(Token = "0x6000024")]
		string GetSaveKey(ResourceType resourceType);
	}
}
