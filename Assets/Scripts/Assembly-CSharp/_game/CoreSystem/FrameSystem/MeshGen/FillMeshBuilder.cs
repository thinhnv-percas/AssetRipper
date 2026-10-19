using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x20004FE")]
	public static class FillMeshBuilder
	{
		[Token(Token = "0x60014E3")]
		[Address(RVA = "0x3D06080", Offset = "0x3D06080", Length = "0x8")]
		public static Mesh Build(float2[] loop, float depth = 0f)
		{
			return Build(loop, depth, bakeGradient: false);
		}

		[Token(Token = "0x60014E4")]
		[Address(RVA = "0x3D06088", Offset = "0x3D06088", Length = "0x120")]
		public static Mesh Build(float2[] loop, float depth, bool bakeGradient)
		{
			if (loop != null && loop.Length > 2)
			{
				float2[] array = EnsureCCW(loop);
				List<float2[]> list = new List<float2[]>();
				PolygonWithHoles polygon = default(PolygonWithHoles);
				return Build(polygon, depth, bakeGradient);
			}
			return new Mesh();
		}

		[Token(Token = "0x60014E5")]
		[Address(RVA = "0x3D061A8", Offset = "0x3D061A8", Length = "0x118")]
		private static float2[] EnsureCCW(float2[] loop)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::EnsureCCW");
			return default;
		}

		[Token(Token = "0x60014E6")]
		[Address(RVA = "0x3D06440", Offset = "0x3D06440", Length = "0x8")]
		public static Mesh Build(PolygonWithHoles polygon, float depth = 0f)
		{
			return Build(polygon, depth, bakeGradient: false);
		}

		[Token(Token = "0x60014E7")]
		[Address(RVA = "0x3D062C0", Offset = "0x3D062C0", Length = "0xF8")]
		public static Mesh Build(PolygonWithHoles polygon, float depth, bool bakeGradient)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::Build");
			return default;
		}

		[Token(Token = "0x60014E8")]
		[Address(RVA = "0x3D06C84", Offset = "0x3D06C84", Length = "0x1B0")]
		private static Mesh BuildFlat(float2[] mergedVertices, int[] triangleIndices)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::BuildFlat");
			return default;
		}

		[Token(Token = "0x60014E9")]
		[Address(RVA = "0x3D06448", Offset = "0x3D06448", Length = "0x83C")]
		private unsafe static Mesh BuildExtruded(float2[] mergedVertices, int[] triangleIndices, float2[] outerLoop, List<float2[]> holes, float depth)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::BuildExtruded");
			return default;
		}

		[Token(Token = "0x60014EA")]
		[Address(RVA = "0x3D071D8", Offset = "0x3D071D8", Length = "0x418")]
		private static void AddSideWalls(float2[] loop, float depth, Vector3[] vertices, Vector3[] normals, Vector2[] uvs, int[] triangles, ref int vertOffset, ref int triOffset, bool outerWinding)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::AddSideWalls");
		}

		[Token(Token = "0x60014EB")]
		[Address(RVA = "0x3D0705C", Offset = "0x3D0705C", Length = "0x17C")]
		private static Vector2[] GenerateAABBUVs(float2[] verts, float minX, float maxX, float minY, float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::GenerateAABBUVs");
			return default;
		}

		[Token(Token = "0x60014EC")]
		[Address(RVA = "0x3D06E34", Offset = "0x3D06E34", Length = "0x228")]
		private static void BakeGradientScalar(Mesh mesh)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FillMeshBuilder::BakeGradientScalar");
		}
	}
}
