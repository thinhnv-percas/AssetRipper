using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Effects/Shadow", 80)]
	[Token(Token = "0x2000088")]
	public class Shadow : BaseMeshEffect
	{
		[SerializeField]
		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x28")]
		private Color m_EffectColor;

		[SerializeField]
		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x38")]
		private Vector2 m_EffectDistance;

		[SerializeField]
		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x40")]
		private bool m_UseGraphicAlpha;

		[Token(Token = "0x4000273")]
		private const float kMaxEffectDistance = 600f;

		[Token(Token = "0x17000155")]
		public Color effectColor
		{
			[Token(Token = "0x600053B")]
			[Address(RVA = "0x183E69C", Offset = "0x183E69C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x600053C")]
			[Address(RVA = "0x183E6A8", Offset = "0x183E6A8", Length = "0xD4")]
			set
			{
			}
		}

		[Token(Token = "0x17000156")]
		public Vector2 effectDistance
		{
			[Token(Token = "0x600053D")]
			[Address(RVA = "0x183E77C", Offset = "0x183E77C", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x600053E")]
			[Address(RVA = "0x183E784", Offset = "0x183E784", Length = "0x104")]
			set
			{
			}
		}

		[Token(Token = "0x17000157")]
		public bool useGraphicAlpha
		{
			[Token(Token = "0x600053F")]
			[Address(RVA = "0x183E888", Offset = "0x183E888", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000540")]
			[Address(RVA = "0x183E890", Offset = "0x183E890", Length = "0xB8")]
			set
			{
			}
		}

		[Token(Token = "0x600053A")]
		[Address(RVA = "0x183E674", Offset = "0x183E674", Length = "0x28")]
		protected internal Shadow()
		{
		}

		[Token(Token = "0x6000541")]
		[Address(RVA = "0x183E948", Offset = "0x183E948", Length = "0x2F8")]
		protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
		}

		[Token(Token = "0x6000542")]
		[Address(RVA = "0x183EC40", Offset = "0x183EC40", Length = "0x8")]
		protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
		}

		[Token(Token = "0x6000543")]
		[Address(RVA = "0x183EC48", Offset = "0x183EC48", Length = "0x120")]
		public override void ModifyMesh(VertexHelper vh)
		{
		}
	}
}
