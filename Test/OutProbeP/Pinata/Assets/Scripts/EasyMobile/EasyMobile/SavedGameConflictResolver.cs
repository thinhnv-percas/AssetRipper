using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200004F")]
	public delegate SavedGameConflictResolutionStrategy SavedGameConflictResolver(SavedGame baseVersion, byte[] baseVersionData, SavedGame remoteVersion, byte[] remoteVersionData);
}
