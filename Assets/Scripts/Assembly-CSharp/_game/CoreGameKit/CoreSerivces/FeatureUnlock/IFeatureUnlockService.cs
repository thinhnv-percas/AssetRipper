using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[Token(Token = "0x200061A")]
	public interface IFeatureUnlockService
	{
		[Token(Token = "0x6001A26")]
		FeatureUnlockData GetNextUnlockFeature(out float progress, out float startProgress);
	}
}
