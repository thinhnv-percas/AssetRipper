using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.Shared
{
	[SelectionBase]
	[Token(Token = "0x2000284")]
	public class SelectionRoot : MonoBehaviour
	{
		[Token(Token = "0x6000B3A")]
		[Address(RVA = "0x3EC5060", Offset = "0x3EC5060", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SelectionRoot()
		{
		}
	}
}
