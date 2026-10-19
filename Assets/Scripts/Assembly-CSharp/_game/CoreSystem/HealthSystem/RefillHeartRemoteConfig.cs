using Cpp2ILInjected;
using UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004D7")]
	public class RefillHeartRemoteConfig : RemoteConfigUnitySerializer<RefillHeartConfig>
	{
		[Token(Token = "0x6001466")]
		[Address(RVA = "0x3CF52E8", Offset = "0x3CF52E8", Length = "0x58")]
		public RefillHeartRemoteConfig()
		{
		}
	}
}
