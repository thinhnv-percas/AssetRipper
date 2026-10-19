using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Token(Token = "0x2000034")]
	public class HighlightRoot : MonoBehaviour
	{
		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x772F558", Offset = "0x772F558", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightRoot()
		{
		}
	}
}
