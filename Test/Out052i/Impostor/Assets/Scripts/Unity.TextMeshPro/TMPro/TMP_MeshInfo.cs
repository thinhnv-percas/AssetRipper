using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000070")]
	public struct TMP_MeshInfo
	{
		[Token(Token = "0x40002F3")]
		private static readonly Color32 s_DefaultColor;

		[Token(Token = "0x40002F4")]
		private static readonly Vector3 s_DefaultNormal;

		[Token(Token = "0x40002F5")]
		private static readonly Vector4 s_DefaultTangent;

		[Token(Token = "0x40002F6")]
		private static readonly Bounds s_DefaultBounds;

		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0x0")]
		public Mesh mesh;

		[Token(Token = "0x40002F8")]
		[FieldOffset(Offset = "0x8")]
		public int vertexCount;

		[Token(Token = "0x40002F9")]
		[FieldOffset(Offset = "0x10")]
		public Vector3[] vertices;

		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0x18")]
		public Vector3[] normals;

		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0x20")]
		public Vector4[] tangents;

		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0x28")]
		public Vector2[] uvs0;

		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0x30")]
		public Vector2[] uvs2;

		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0x38")]
		public Color32[] colors32;

		[Token(Token = "0x40002FF")]
		[FieldOffset(Offset = "0x40")]
		public int[] triangles;

		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0x48")]
		public Material material;

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0x16055BC", Offset = "0x16055BC", Length = "0x4F4")]
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
			material = null;
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0x1605AB0", Offset = "0x1605AB0", Length = "0x784")]
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
			material = null;
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0x1606234", Offset = "0x1606234", Length = "0x474")]
		public void ResizeMeshInfo(int size)
		{
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0x16066A8", Offset = "0x16066A8", Length = "0x8D8")]
		public void ResizeMeshInfo(int size, bool isVolumetric)
		{
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0x1606F80", Offset = "0x1606F80", Length = "0xA4")]
		public void Clear()
		{
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0x1607024", Offset = "0x1607024", Length = "0x138")]
		public void Clear(bool uploadChanges)
		{
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0x160715C", Offset = "0x160715C", Length = "0x3C")]
		public void ClearUnusedVertices()
		{
		}

		[Token(Token = "0x60003B3")]
		[Address(RVA = "0x1607198", Offset = "0x1607198", Length = "0x34")]
		public void ClearUnusedVertices(int startIndex)
		{
		}

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0x16071CC", Offset = "0x16071CC", Length = "0xC4")]
		public void ClearUnusedVertices(int startIndex, bool updateMesh)
		{
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0x1607290", Offset = "0x1607290", Length = "0xB4")]
		public void SortGeometry(VertexSortingOrder order)
		{
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0x16078D0", Offset = "0x16078D0", Length = "0x1F8")]
		public void SortGeometry(IList<int> sortingOrder)
		{
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0x1607344", Offset = "0x1607344", Length = "0x58C")]
		public void SwapVertexData(int src, int dst)
		{
		}
	}
}
