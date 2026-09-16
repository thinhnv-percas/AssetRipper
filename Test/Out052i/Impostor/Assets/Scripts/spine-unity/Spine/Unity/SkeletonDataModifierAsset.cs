using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000070")]
	public abstract class SkeletonDataModifierAsset : ScriptableObject
	{
		[Token(Token = "0x60004A8")]
		public abstract void Apply(SkeletonData skeletonData);

		[Token(Token = "0x60004A9")]
		[Address(RVA = "0x15524AC", Offset = "0x15524AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonDataModifierAsset()
		{
		}
	}
}
