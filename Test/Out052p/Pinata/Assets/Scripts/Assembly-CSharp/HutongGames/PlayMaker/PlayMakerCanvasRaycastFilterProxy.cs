using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200006F")]
	public class PlayMakerCanvasRaycastFilterProxy : MonoBehaviour, ICanvasRaycastFilter
	{
		[Token(Token = "0x40002C1")]
		[FieldOffset(Offset = "0x18")]
		public bool RayCastingEnabled;

		[Token(Token = "0x6000333")]
		[Address(RVA = "0x98B0A4", Offset = "0x98B0A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.RayCastingEnabled;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return RayCastingEnabled;
		}

		[Token(Token = "0x6000334")]
		[Address(RVA = "0x98B0AC", Offset = "0x98B0AC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.RayCastingEnabled = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayMakerCanvasRaycastFilterProxy()
		{
			RayCastingEnabled = true;
		}
	}
}
