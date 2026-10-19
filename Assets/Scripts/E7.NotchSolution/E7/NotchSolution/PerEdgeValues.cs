using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x200000E")]
	internal class PerEdgeValues<T>
	{
		[SerializeField]
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x0")]
		public T left;

		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x0")]
		public T bottom;

		[SerializeField]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x0")]
		public T top;

		[SerializeField]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x0")]
		public T right;

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x5EC9BFC", Offset = "0x5EC9BFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public PerEdgeValues()
		{
		}
	}
}
