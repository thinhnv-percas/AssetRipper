using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200000A")]
	public struct TMP_MaterialReference
	{
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x0")]
		public Material material;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x8")]
		public int referenceCount;
	}
}
