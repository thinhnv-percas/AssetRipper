using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Utils
{
	[Token(Token = "0x200001E")]
	public static class CoroutineUtil
	{
		[Token(Token = "0x4000040")]
		public static readonly WaitForSeconds _1second;

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3C66090", Offset = "0x3C66090", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn;\nL_001B:\n\tv47 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v47, 1f);\n\tv54._1second = v47;\n")]
		static CoroutineUtil()
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
			_1second = waitForSeconds;
		}
	}
}
