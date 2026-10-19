using AssetRipperInjected;
using Cpp2ILInjected;
using UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects;

namespace _game.CoreSystem.VacuumSystem
{
	[Token(Token = "0x2000131")]
	public class VacuumRemoteConfig : RemoteConfigUnitySerializer<VacuumConfigData>
	{
		[Token(Token = "0x600061C")]
		[Address(RVA = "0x3DB27FC", Offset = "0x3DB27FC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tUncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.RemoteConfigUnitySerializer`1<_game.CoreSystem.VacuumSystem.VacuumConfigData>::.ctor(this);\n\treturn;\n")]
		public VacuumRemoteConfig()
		{
		}
	}
}
