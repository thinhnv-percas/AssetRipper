using Systems.RemoteManagementSystem.ScriptableObjects;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects
{
	[Token(Token = "0x2000005")]
	public class RemoteConfigNewtonSerializer<T> : RemoteConfig
	{
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x6241064", Offset = "0x6241064", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.RemoteManagementSystem.ScriptableObjects.RemoteConfig::.ctor(this);\n\treturn;\n")]
		public RemoteConfigNewtonSerializer()
		{
		}
	}
}
