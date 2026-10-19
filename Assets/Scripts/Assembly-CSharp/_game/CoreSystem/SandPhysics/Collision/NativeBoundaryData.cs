using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;

namespace _game.CoreSystem.SandPhysics.Collision
{
	[Token(Token = "0x2000122")]
	public struct NativeBoundaryData : IDisposable
	{
		[Token(Token = "0x40003BA")]
		[FieldOffset(Offset = "0x0")]
		public NativeArray<float2> loopVertices;

		[Token(Token = "0x40003BB")]
		[FieldOffset(Offset = "0x10")]
		public NativeArray<int2> loopRanges;

		[Token(Token = "0x40003BC")]
		[FieldOffset(Offset = "0x20")]
		public NativeArray<bool> isCCW;

		[Token(Token = "0x40003BD")]
		[FieldOffset(Offset = "0x30")]
		public NativeArray<float4> loopAabbs;

		[Token(Token = "0x40003BE")]
		[FieldOffset(Offset = "0x40")]
		public int loopCount;

		[Token(Token = "0x40003BF")]
		[FieldOffset(Offset = "0x48")]
		public NativeArray<float2> blockedLoopVertices;

		[Token(Token = "0x40003C0")]
		[FieldOffset(Offset = "0x58")]
		public NativeArray<int2> blockedLoopRanges;

		[Token(Token = "0x40003C1")]
		[FieldOffset(Offset = "0x68")]
		public NativeArray<float4> blockedLoopAabbs;

		[Token(Token = "0x40003C2")]
		[FieldOffset(Offset = "0x78")]
		public NativeArray<float2> blockedLoopCenters;

		[Token(Token = "0x40003C3")]
		[FieldOffset(Offset = "0x88")]
		public int blockedLoopCount;

		[Token(Token = "0x60005E4")]
		[Address(RVA = "0x3DAB608", Offset = "0x3DAB608", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Dispose(this);\nL_0034:\n\tv57 = this + 0x10;\n\tv59 = v57.m_Buffer == 0;\n\tif (v59) goto L_003B;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.int2>::Dispose(&this.loopRanges (Unity.Collections.NativeArray`1<Unity.Mathematics.int2>));\nL_003B:\n\tv66 = this + 0x20;\n\tv68 = v66.m_Buffer == 0;\n\tif (v68) goto L_0046;\n\tUnity.Collections.NativeArray`1<System.Boolean>::Dispose(&this.isCCW (Unity.Collections.NativeArray`1<System.Boolean>));\nL_0046:\n\tv80 = this + 0x30;\n\tv82 = v80.m_Buffer == 0;\n\tif (v82) goto L_004D;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float4>::Dispose(&this.loopAabbs (Unity.Collections.NativeArray`1<Unity.Mathematics.float4>));\nL_004D:\n\tv89 = this + 0x48;\n\tv91 = v89.m_Buffer == 0;\n\tif (v91) goto L_0054;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Dispose(&this.blockedLoopVertices (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\nL_0054:\n\tv98 = this + 0x58;\n\tv100 = v98.m_Buffer == 0;\n\tif (v100) goto L_005B;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.int2>::Dispose(&this.blockedLoopRanges (Unity.Collections.NativeArray`1<Unity.Mathematics.int2>));\nL_005B:\n\tv107 = this + 0x68;\n\tv109 = v107.m_Buffer == 0;\n\tif (v109) goto L_0061;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float4>::Dispose(&this.blockedLoopAabbs (Unity.Collections.NativeArray`1<Unity.Mathematics.float4>));\nL_0061:\n\tv114 = this + 0x78;\n\tv116 = v114.m_Buffer == 0;\n\tif (v116) goto L_0077;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Dispose(&this.blockedLoopCenters (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\treturn;\nL_0077:\n\treturn;\nL_002C:\n\tv46 = this.loopVertices == 0;\n\tif (v46) goto L_0034;\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeBoundaryData::Dispose");
		}
	}
}
