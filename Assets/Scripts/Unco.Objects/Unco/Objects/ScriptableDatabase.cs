using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Objects
{
	[Token(Token = "0x2000029")]
	public class ScriptableDatabase<T> : ScriptableObject where T : ScriptableObject
	{
		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x624B890", Offset = "0x624B890", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public ScriptableDatabase()
		{
		}
	}
}
