using Cpp2ILInjected;
using UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004D0")]
	public class HealthRemoteConfig : RemoteConfigUnitySerializer<HealthConfig>
	{
		[Token(Token = "0x6001458")]
		[Address(RVA = "0x3CF4A60", Offset = "0x3CF4A60", Length = "0x58")]
		public HealthRemoteConfig()
		{
		}
	}
}
