using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727C6C", Offset = "0x727C6C")]
	[Token(Token = "0x2000045")]
	public class Shadow : BaseMeshEffect
	{
		[SerializeField]
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x20")]
		private Color m_EffectColor;

		[SerializeField]
		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x30")]
		private Vector2 m_EffectDistance;

		[SerializeField]
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x38")]
		private bool m_UseGraphicAlpha;

		[Token(Token = "0x4000186")]
		private const float kMaxEffectDistance = 600f;

		[Token(Token = "0x1700013E")]
		public Color effectColor
		{
			[Token(Token = "0x6000490")]
			[Address(RVA = "0xED790C", Offset = "0xED790C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000491")]
			[Address(RVA = "0xED7918", Offset = "0xED7918", Length = "0xE4")]
			set
			{
			}
		}

		[Token(Token = "0x1700013F")]
		public Vector2 effectDistance
		{
			[Token(Token = "0x6000492")]
			[Address(RVA = "0xED79FC", Offset = "0xED79FC", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000493")]
			[Address(RVA = "0xED7A04", Offset = "0xED7A04", Length = "0x138")]
			set
			{
			}
		}

		[Token(Token = "0x17000140")]
		public bool useGraphicAlpha
		{
			[Token(Token = "0x6000494")]
			[Address(RVA = "0xED7B3C", Offset = "0xED7B3C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000495")]
			[Address(RVA = "0xED7B44", Offset = "0xED7B44", Length = "0xCC")]
			set
			{
			}
		}

		[Token(Token = "0x600048F")]
		[Address(RVA = "0xECA744", Offset = "0xECA744", Length = "0x90")]
		protected internal Shadow()
		{
		}

		[Token(Token = "0x6000496")]
		[Address(RVA = "0xECAA3C", Offset = "0xECAA3C", Length = "0x26C")]
		protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
		}

		[Token(Token = "0x6000497")]
		[Address(RVA = "0xED7C10", Offset = "0xED7C10", Length = "0x8")]
		protected void ApplyShadow(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
		{
		}

		[Token(Token = "0x6000498")]
		[Address(RVA = "0xED7C18", Offset = "0xED7C18", Length = "0x110")]
		public override void ModifyMesh(VertexHelper vh)
		{
		}
	}
}
