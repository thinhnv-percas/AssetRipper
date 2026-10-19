using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[Token(Token = "0x200010E")]
	public struct SandSDFData : IDisposable
	{
		[Token(Token = "0x4000383")]
		[FieldOffset(Offset = "0x0")]
		public NativeArray<half> values;

		[Token(Token = "0x4000384")]
		[FieldOffset(Offset = "0x10")]
		public float2 origin;

		[Token(Token = "0x4000385")]
		[FieldOffset(Offset = "0x18")]
		public float cellSize;

		[Token(Token = "0x4000386")]
		[FieldOffset(Offset = "0x1C")]
		public int gridWidth;

		[Token(Token = "0x4000387")]
		[FieldOffset(Offset = "0x20")]
		public int gridHeight;

		[Token(Token = "0x4000388")]
		[FieldOffset(Offset = "0x24")]
		public bool IsBuilt;

		[Token(Token = "0x60005BA")]
		[Address(RVA = "0x3DAE1E4", Offset = "0x3DAE1E4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.half>::Dispose(this);\nL_001D:\n\tthis.IsBuilt = 0;\n\treturn;\nL_0016:\n\tv40 = this.values == 0;\n\tif (v40) goto L_001D;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFData::Dispose");
		}
	}
}
