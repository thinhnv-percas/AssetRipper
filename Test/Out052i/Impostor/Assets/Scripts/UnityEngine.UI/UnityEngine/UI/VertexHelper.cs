using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000081")]
	public class VertexHelper : IDisposable
	{
		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x10")]
		private List<Vector3> m_Positions;

		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x18")]
		private List<Color32> m_Colors;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x20")]
		private List<Vector4> m_Uv0S;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x28")]
		private List<Vector4> m_Uv1S;

		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x30")]
		private List<Vector4> m_Uv2S;

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x38")]
		private List<Vector4> m_Uv3S;

		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x40")]
		private List<Vector3> m_Normals;

		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x48")]
		private List<Vector4> m_Tangents;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x50")]
		private List<int> m_Indices;

		[Token(Token = "0x400026C")]
		private static readonly Vector4 s_DefaultTangent;

		[Token(Token = "0x400026D")]
		private static readonly Vector3 s_DefaultNormal;

		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x58")]
		private bool m_ListsInitalized;

		[Token(Token = "0x17000152")]
		public int currentVertCount
		{
			[Token(Token = "0x600051B")]
			[Address(RVA = "0x183D274", Offset = "0x183D274", Length = "0x4C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000153")]
		public int currentIndexCount
		{
			[Token(Token = "0x600051C")]
			[Address(RVA = "0x183D2C0", Offset = "0x183D2C0", Length = "0x4C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000516")]
		[Address(RVA = "0x183CCF4", Offset = "0x183CCF4", Length = "0x8")]
		public VertexHelper()
		{
		}

		[Token(Token = "0x6000517")]
		[Address(RVA = "0x183CCFC", Offset = "0x183CCFC", Length = "0x23C")]
		public VertexHelper(Mesh m)
		{
		}

		[Token(Token = "0x6000518")]
		[Address(RVA = "0x183CF38", Offset = "0x183CF38", Length = "0x188")]
		private void InitializeListIfRequired()
		{
		}

		[Token(Token = "0x6000519")]
		[Address(RVA = "0x183D0C0", Offset = "0x183D0C0", Length = "0x1B4")]
		public void Dispose()
		{
		}

		[Token(Token = "0x600051A")]
		[Address(RVA = "0x182D2D8", Offset = "0x182D2D8", Length = "0x11C")]
		public void Clear()
		{
		}

		[Token(Token = "0x600051D")]
		[Address(RVA = "0x183D30C", Offset = "0x183D30C", Length = "0x160")]
		public void PopulateUIVertex(ref UIVertex vertex, int i)
		{
		}

		[Token(Token = "0x600051E")]
		[Address(RVA = "0x183D46C", Offset = "0x183D46C", Length = "0x15C")]
		public void SetUIVertex(UIVertex vertex, int i)
		{
		}

		[Token(Token = "0x600051F")]
		[Address(RVA = "0x183D5C8", Offset = "0x183D5C8", Length = "0x160")]
		public void FillMesh(Mesh mesh)
		{
		}

		[Token(Token = "0x6000520")]
		[Address(RVA = "0x183D728", Offset = "0x183D728", Length = "0x49C")]
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0, Vector4 uv1, Vector4 uv2, Vector4 uv3, Vector3 normal, Vector4 tangent)
		{
		}

		[Token(Token = "0x6000521")]
		[Address(RVA = "0x183DBC4", Offset = "0x183DBC4", Length = "0xF8")]
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0, Vector4 uv1, Vector3 normal, Vector4 tangent)
		{
		}

		[Token(Token = "0x6000522")]
		[Address(RVA = "0x182D3F4", Offset = "0x182D3F4", Length = "0x130")]
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0)
		{
		}

		[Token(Token = "0x6000523")]
		[Address(RVA = "0x183DCBC", Offset = "0x183DCBC", Length = "0x94")]
		public void AddVert(UIVertex v)
		{
		}

		[Token(Token = "0x6000524")]
		[Address(RVA = "0x182D524", Offset = "0x182D524", Length = "0x170")]
		public void AddTriangle(int idx0, int idx1, int idx2)
		{
		}

		[Token(Token = "0x6000525")]
		[Address(RVA = "0x1839E84", Offset = "0x1839E84", Length = "0x110")]
		public void AddUIVertexQuad(UIVertex[] verts)
		{
		}

		[Token(Token = "0x6000526")]
		[Address(RVA = "0x183DD50", Offset = "0x183DD50", Length = "0xAC")]
		public void AddUIVertexStream(List<UIVertex> verts, List<int> indices)
		{
		}

		[Token(Token = "0x6000527")]
		[Address(RVA = "0x183DDFC", Offset = "0x183DDFC", Length = "0x50")]
		public void AddUIVertexTriangleStream(List<UIVertex> verts)
		{
		}

		[Token(Token = "0x6000528")]
		[Address(RVA = "0x183DE4C", Offset = "0x183DE4C", Length = "0x50")]
		public void GetUIVertexStream(List<UIVertex> stream)
		{
		}
	}
}
