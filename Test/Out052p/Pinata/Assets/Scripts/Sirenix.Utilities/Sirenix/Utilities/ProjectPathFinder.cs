using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000008")]
	internal class ProjectPathFinder : ScriptableObject
	{
		[Token(Token = "0x600001A")]
		[Address(RVA = "0x1658DA0", Offset = "0x1658DA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProjectPathFinder()
		{
		}
	}
}
