using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000031")]
	public struct TMP_MeshInfo
	{
		[Token(Token = "0x4000199")]
		private static readonly Color32 s_DefaultColor;

		[Token(Token = "0x400019A")]
		private static readonly Vector3 s_DefaultNormal;

		[Token(Token = "0x400019B")]
		private static readonly Vector4 s_DefaultTangent;

		[Token(Token = "0x400019C")]
		private static readonly Bounds s_DefaultBounds;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x0")]
		public Mesh mesh;

		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x8")]
		public int vertexCount;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x10")]
		public Vector3[] vertices;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x18")]
		public Vector3[] normals;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x20")]
		public Vector4[] tangents;

		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x28")]
		public Vector2[] uvs0;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x30")]
		public Vector2[] uvs2;

		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x38")]
		public Color32[] colors32;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x40")]
		public int[] triangles;

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0x8469B0", Offset = "0x8469B0", Length = "0x8")]
		public TMP_MeshInfo(Mesh mesh, int size)
		{
			this.mesh = null;
			vertexCount = 0;
			vertices = null;
			normals = null;
			tangents = null;
			uvs0 = null;
			uvs2 = null;
			colors32 = null;
			triangles = null;
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0x8469B8", Offset = "0x8469B8", Length = "0xC")]
		public TMP_MeshInfo(Mesh mesh, int size, bool isVolumetric)
		{
			this.mesh = null;
			vertexCount = 0;
			vertices = null;
			normals = null;
			tangents = null;
			uvs0 = null;
			uvs2 = null;
			colors32 = null;
			triangles = null;
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0x8469C4", Offset = "0x8469C4", Length = "0x8")]
		public void ResizeMeshInfo(int size)
		{
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0x8469CC", Offset = "0x8469CC", Length = "0xC")]
		public void ResizeMeshInfo(int size, bool isVolumetric)
		{
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x8469D8", Offset = "0x8469D8", Length = "0x8")]
		public void Clear()
		{
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x8469E0", Offset = "0x8469E0", Length = "0xC")]
		public void Clear(bool uploadChanges)
		{
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x8469EC", Offset = "0x8469EC", Length = "0x8")]
		public void ClearUnusedVertices()
		{
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x8469F4", Offset = "0x8469F4", Length = "0x8")]
		public void ClearUnusedVertices(int startIndex)
		{
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x8469FC", Offset = "0x8469FC", Length = "0xC")]
		public void ClearUnusedVertices(int startIndex, bool updateMesh)
		{
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x846A08", Offset = "0x846A08", Length = "0x8")]
		public void SortGeometry(VertexSortingOrder order)
		{
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x846A10", Offset = "0x846A10", Length = "0x8")]
		public void SortGeometry(IList<int> sortingOrder)
		{
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x846A18", Offset = "0x846A18", Length = "0xB0")]
		public void SwapVertexData(int src, int dst)
		{
		}
	}
}
