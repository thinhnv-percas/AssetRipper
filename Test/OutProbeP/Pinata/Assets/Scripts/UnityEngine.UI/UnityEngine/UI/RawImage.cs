using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x7276F0", Offset = "0x7276F0")]
	[Token(Token = "0x200002F")]
	public class RawImage : MaskableGraphic
	{
		[Attribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729468", Offset = "0x729468")]
		[SerializeField]
		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0xC0")]
		private Texture m_Texture;

		[SerializeField]
		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0xC8")]
		private Rect m_UVRect;

		[Token(Token = "0x170000CD")]
		public override Texture mainTexture
		{
			[Token(Token = "0x60002F1")]
			[Address(RVA = "0xECB300", Offset = "0xECB300", Length = "0x180")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000CE")]
		public Texture texture
		{
			[Token(Token = "0x60002F2")]
			[Address(RVA = "0xECB480", Offset = "0xECB480", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002F3")]
			[Address(RVA = "0xECB488", Offset = "0xECB488", Length = "0xBC")]
			set
			{
			}
		}

		[Token(Token = "0x170000CF")]
		public Rect uvRect
		{
			[Token(Token = "0x60002F4")]
			[Address(RVA = "0xECB544", Offset = "0xECB544", Length = "0xC")]
			get
			{
				return default(Rect);
			}
			[Token(Token = "0x60002F5")]
			[Address(RVA = "0xECB550", Offset = "0xECB550", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xECB298", Offset = "0xECB298", Length = "0x68")]
		protected RawImage()
		{
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0xECB5E0", Offset = "0xECB5E0", Length = "0x1C8")]
		public override void SetNativeSize()
		{
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0xECB7A8", Offset = "0xECB7A8", Length = "0x420")]
		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0xECBDA0", Offset = "0xECBDA0", Length = "0x3C")]
		protected override void OnDidApplyAnimationProperties()
		{
		}
	}
}
