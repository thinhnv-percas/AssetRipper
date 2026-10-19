using Cpp2ILInjected;
using UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000666")]
	public class LevelDifficultyRewardRemoteConfig : RemoteConfigUnitySerializer<LevelDifficultyRewardConfig>
	{
		[Token(Token = "0x6001AFE")]
		[Address(RVA = "0x3D57A24", Offset = "0x3D57A24", Length = "0x58")]
		public LevelDifficultyRewardRemoteConfig()
		{
		}
	}
}
