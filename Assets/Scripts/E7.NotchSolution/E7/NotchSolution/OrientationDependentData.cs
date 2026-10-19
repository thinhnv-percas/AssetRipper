using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000012")]
	internal class OrientationDependentData
	{
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x10")]
		public Rect safeArea;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x20")]
		public Rect[] cutouts;

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x3F46168", Offset = "0x3F46168", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public OrientationDependentData()
		{
		}
	}
}
