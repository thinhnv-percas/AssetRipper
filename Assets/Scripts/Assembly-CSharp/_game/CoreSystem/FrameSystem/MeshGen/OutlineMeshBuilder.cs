using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x2000502")]
	public static class OutlineMeshBuilder
	{
		[Token(Token = "0x60014F6")]
		[Address(RVA = "0x3D084F0", Offset = "0x3D084F0", Length = "0x8")]
		public static Mesh Build(List<List<float2>> loops, float thickness, int cornerSegments = 4, float extrudeHeight = 0f)
		{
			return Build(loops, thickness, cornerSegments, extrudeHeight, isClosed: true);
		}

		[Token(Token = "0x60014F7")]
		[Address(RVA = "0x3D084F8", Offset = "0x3D084F8", Length = "0x3B0")]
		public unsafe static Mesh Build(List<List<float2>> chains, float thickness, int cornerSegments, float extrudeHeight, bool isClosed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OutlineMeshBuilder::Build");
			return default;
		}

		[Token(Token = "0x60014F8")]
		[Address(RVA = "0x3D088A8", Offset = "0x3D088A8", Length = "0x1D08")]
		private static void GenerateLoopStroke(List<float2> loop, float thickness, int cornerSegments, float extrudeHeight, bool isClosed, List<Vector3> vertices, List<int> triangles, List<Vector2> uvs)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OutlineMeshBuilder::GenerateLoopStroke");
		}
	}
}
