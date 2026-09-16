using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x2000043")]
	internal abstract class ABSPathDecoder
	{
		[Token(Token = "0x6000249")]
		internal abstract void FinalizePath(Path p, Vector3[] wps, bool isClosedPath);

		[Token(Token = "0x600024A")]
		internal abstract Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints);

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x1080240", Offset = "0x1080240", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ABSPathDecoder()
		{
		}
	}
}
