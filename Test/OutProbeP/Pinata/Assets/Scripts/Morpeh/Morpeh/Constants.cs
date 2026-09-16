using Cpp2ILInjected;

namespace Morpeh
{
	[Token(Token = "0x2000006")]
	internal static class Constants
	{
		[Token(Token = "0x4000007")]
		internal const int DEFAULT_WORLD_ENTITIES_CAPACITY = 65536;

		[Token(Token = "0x4000008")]
		internal const int DEFAULT_ENTITY_COMPONENTS_CAPACITY = 2;

		[Token(Token = "0x4000009")]
		internal const int DEFAULT_ROOT_FILTER_DIRTY_ENTITIES_CAPACITY = 65536;

		[Token(Token = "0x400000A")]
		internal const int DEFAULT_FILTER_DIRTY_ENTITIES_CAPACITY = 1024;

		[Token(Token = "0x400000B")]
		internal const int DEFAULT_FILTER_ADDED_ENTITIES_CAPACITY = 32;

		[Token(Token = "0x400000C")]
		internal const int DEFAULT_FILTER_REMOVED_ENTITIES_CAPACITY = 32;

		[Token(Token = "0x400000D")]
		internal const int DEFAULT_CACHE_COMPONENTS_CAPACITY = 2048;
	}
}
