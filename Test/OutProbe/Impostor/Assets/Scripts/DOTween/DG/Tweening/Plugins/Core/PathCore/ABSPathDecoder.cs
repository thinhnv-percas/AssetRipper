using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Token(Token = "0x200009B")]
	internal abstract class ABSPathDecoder
	{
		[Token(Token = "0x1700000B")]
		internal abstract int minInputWaypoints
		{
			[Token(Token = "0x6000395")]
			get;
		}

		[Token(Token = "0x6000393")]
		internal abstract void FinalizePath(Path p, Vector3[] wps, bool isClosedPath);

		[Token(Token = "0x6000394")]
		internal abstract Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints);

		[Token(Token = "0x6000396")]
		[Address(RVA = "0xC29220", Offset = "0xC29220", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ABSPathDecoder()
		{
		}
	}
}
