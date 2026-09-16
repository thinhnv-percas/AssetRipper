using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Tayx.Graphy.Graph
{
	[Token(Token = "0x2000039")]
	public abstract class G_Graph : MonoBehaviour
	{
		[Token(Token = "0x600018E")]
		protected abstract void UpdateGraph();

		[Token(Token = "0x600018F")]
		protected abstract void CreatePoints();

		[Token(Token = "0x6000190")]
		[Address(RVA = "0xB0D858", Offset = "0xB0D858", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal G_Graph()
		{
		}
	}
}
