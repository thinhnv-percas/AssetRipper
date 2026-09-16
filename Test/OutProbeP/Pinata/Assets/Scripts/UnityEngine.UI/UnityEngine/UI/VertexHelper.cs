using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200003E")]
	public class VertexHelper : IDisposable
	{
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x10")]
		private List<Vector3> m_Positions;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x18")]
		private List<Color32> m_Colors;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x20")]
		private List<Vector2> m_Uv0S;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x28")]
		private List<Vector2> m_Uv1S;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		private List<Vector2> m_Uv2S;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x38")]
		private List<Vector2> m_Uv3S;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x40")]
		private List<Vector3> m_Normals;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x48")]
		private List<Vector4> m_Tangents;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x50")]
		private List<int> m_Indices;

		[Token(Token = "0x400017F")]
		private static readonly Vector4 s_DefaultTangent;

		[Token(Token = "0x4000180")]
		private static readonly Vector3 s_DefaultNormal;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x58")]
		private bool m_ListsInitalized;

		[Token(Token = "0x1700013B")]
		public int currentVertCount
		{
			[Token(Token = "0x6000470")]
			[Address(RVA = "0xECB244", Offset = "0xECB244", Length = "0x54")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700013C")]
		public int currentIndexCount
		{
			[Token(Token = "0x6000471")]
			[Address(RVA = "0xEDCEA8", Offset = "0xEDCEA8", Length = "0x54")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0xEDC980", Offset = "0xEDC980", Length = "0x8")]
		public VertexHelper()
		{
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0xEDC988", Offset = "0xEDC988", Length = "0x1E0")]
		public VertexHelper(Mesh m)
		{
		}

		[Token(Token = "0x600046D")]
		[Address(RVA = "0xEDCB68", Offset = "0xEDCB68", Length = "0x18C")]
		private void InitializeListIfRequired()
		{
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0xEDCCF4", Offset = "0xEDCCF4", Length = "0x1B4")]
		public void Dispose()
		{
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0xECACA8", Offset = "0xECACA8", Length = "0x118")]
		public void Clear()
		{
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0xECAF04", Offset = "0xECAF04", Length = "0x1F4")]
		public void PopulateUIVertex(ref UIVertex vertex, int i)
		{
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0xECB0F8", Offset = "0xECB0F8", Length = "0x14C")]
		public void SetUIVertex(UIVertex vertex, int i)
		{
		}

		[Token(Token = "0x6000474")]
		[Address(RVA = "0xEDCEFC", Offset = "0xEDCEFC", Length = "0x16C")]
		public void FillMesh(Mesh mesh)
		{
		}

		[Token(Token = "0x6000475")]
		[Address(RVA = "0xEDD068", Offset = "0xEDD068", Length = "0x1C4")]
		public void AddVert(Vector3 position, Color32 color, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector3 normal, Vector4 tangent)
		{
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0xEDD22C", Offset = "0xEDD22C", Length = "0x10C")]
		public void AddVert(Vector3 position, Color32 color, Vector2 uv0, Vector2 uv1, Vector3 normal, Vector4 tangent)
		{
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0xECBBC8", Offset = "0xECBBC8", Length = "0x130")]
		public void AddVert(Vector3 position, Color32 color, Vector2 uv0)
		{
		}

		[Token(Token = "0x6000478")]
		[Address(RVA = "0xEDD338", Offset = "0xEDD338", Length = "0x70")]
		public void AddVert(UIVertex v)
		{
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0xECBCF8", Offset = "0xECBCF8", Length = "0xA8")]
		public void AddTriangle(int idx0, int idx1, int idx2)
		{
		}

		[Token(Token = "0x600047A")]
		[Address(RVA = "0xEDB5D8", Offset = "0xEDB5D8", Length = "0x118")]
		public void AddUIVertexQuad(UIVertex[] verts)
		{
		}

		[Token(Token = "0x600047B")]
		[Address(RVA = "0xEDD3A8", Offset = "0xEDD3A8", Length = "0xB4")]
		public void AddUIVertexStream(List<UIVertex> verts, List<int> indices)
		{
		}

		[Token(Token = "0x600047C")]
		[Address(RVA = "0xECADC0", Offset = "0xECADC0", Length = "0x58")]
		public void AddUIVertexTriangleStream(List<UIVertex> verts)
		{
		}

		[Token(Token = "0x600047D")]
		[Address(RVA = "0xECA9E4", Offset = "0xECA9E4", Length = "0x58")]
		public void GetUIVertexStream(List<UIVertex> stream)
		{
		}
	}
}
