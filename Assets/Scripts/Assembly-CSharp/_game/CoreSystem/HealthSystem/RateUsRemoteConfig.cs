using Cpp2ILInjected;
using UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects;
using _game.CoreGameKit.AppLayerInstaller;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004D4")]
	public class RateUsRemoteConfig : RemoteConfigUnitySerializer<RateUsConfig>
	{
		[Token(Token = "0x600145F")]
		[Address(RVA = "0x3CF4D00", Offset = "0x3CF4D00", Length = "0x58")]
		public RateUsRemoteConfig()
		{
		}
	}
}
