using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x200001B")]
	public class WorldViewer : MonoBehaviour
	{
		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15F841C", Offset = "0x15F841C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WorldViewer()
		{
		}
	}
}
