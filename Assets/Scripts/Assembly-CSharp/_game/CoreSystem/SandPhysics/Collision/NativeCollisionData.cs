using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using _game.CoreSystem.CollisionSystem;

namespace _game.CoreSystem.SandPhysics.Collision
{
	[Token(Token = "0x2000123")]
	public struct NativeCollisionData : IDisposable
	{
		[Token(Token = "0x40003C4")]
		[FieldOffset(Offset = "0x0")]
		public NativeArray<float2> vertices;

		[Token(Token = "0x40003C5")]
		[FieldOffset(Offset = "0x10")]
		public NativeArray<CollisionShape> shapes;

		[Token(Token = "0x40003C6")]
		[FieldOffset(Offset = "0x20")]
		public NativeArray<float2> edgeNormals;

		[Token(Token = "0x40003C7")]
		[FieldOffset(Offset = "0x30")]
		public NativeArray<float4> shapeAabbs;

		[Token(Token = "0x40003C8")]
		[FieldOffset(Offset = "0x40")]
		public NativeParallelMultiHashMap<int2, int> shapeSpatialGrid;

		[Token(Token = "0x40003C9")]
		[FieldOffset(Offset = "0x50")]
		public float spatialGridCellSize;

		[Token(Token = "0x40003CA")]
		[FieldOffset(Offset = "0x54")]
		public int wallShapeCount;

		[Token(Token = "0x40003CB")]
		[FieldOffset(Offset = "0x58")]
		public int cubeShapeCount;

		[Token(Token = "0x60005E5")]
		[Address(RVA = "0x3DAB4DC", Offset = "0x3DAB4DC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Dispose(this);\nL_0030:\n\tv51 = this + 0x10;\n\tv53 = v51.m_Buffer == 0;\n\tif (v53) goto L_0039;\n\tUnity.Collections.NativeArray`1<_game.CoreSystem.CollisionSystem.CollisionShape>::Dispose(&this.shapes (Unity.Collections.NativeArray`1<_game.CoreSystem.CollisionSystem.CollisionShape>));\nL_0039:\n\tv63 = this + 0x20;\n\tv65 = v63.m_Buffer == 0;\n\tif (v65) goto L_0042;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Dispose(&this.edgeNormals (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\nL_0042:\n\tv74 = this + 0x30;\n\tv76 = v74.m_Buffer == 0;\n\tif (v76) goto L_004B;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float4>::Dispose(&this.shapeAabbs (Unity.Collections.NativeArray`1<Unity.Mathematics.float4>));\nL_004B:\n\t;\n\tv87 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::get_IsCreated(&this.shapeSpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\n\tv91 = ~v87;\n\tif (v91) goto L_005F;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::Dispose(&this.shapeSpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\n\treturn;\nL_005F:\n\treturn;\nL_002A:\n\tv42 = this.vertices == 0;\n\tif (v42) goto L_0030;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeCollisionData::Dispose");
		}
	}
}
