using Systems.RemoteManagementSystem.ScriptableObjects;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects
{
	[Token(Token = "0x2000006")]
	public class RemoteConfigUnitySerializer<T> : RemoteConfig
	{
		[Token(Token = "0x600000A")]
		[Address(RVA = "0x624106C", Offset = "0x624106C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.RemoteManagementSystem.ScriptableObjects.RemoteConfig::.ctor(this);\n\treturn;\n")]
		public RemoteConfigUnitySerializer()
		{
		}
	}
}
