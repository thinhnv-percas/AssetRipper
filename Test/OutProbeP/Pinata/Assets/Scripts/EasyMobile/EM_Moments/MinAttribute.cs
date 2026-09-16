using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EM_Moments
{
	[Token(Token = "0x2000002")]
	public sealed class MinAttribute : PropertyAttribute
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		public readonly float min;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0xA424E0", Offset = "0xA424E0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.min = min;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MinAttribute(float min)
		{
			this.min = min;
		}
	}
}
