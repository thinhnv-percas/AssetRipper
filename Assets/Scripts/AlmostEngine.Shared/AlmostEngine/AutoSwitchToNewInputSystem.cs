using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine
{
	[Token(Token = "0x200000E")]
	public class AutoSwitchToNewInputSystem : MonoBehaviour
	{
		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3C45FBC", Offset = "0x3C45FBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AutoSwitchToNewInputSystem()
		{
		}
	}
}
