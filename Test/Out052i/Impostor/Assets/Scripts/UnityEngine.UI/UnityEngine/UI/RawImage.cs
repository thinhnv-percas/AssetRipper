using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu("UI/Raw Image", 12)]
	[Token(Token = "0x200005E")]
	public class RawImage : MaskableGraphic
	{
		[SerializeField]
		[FormerlySerializedAs("m_Tex")]
		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0xD8")]
		private Texture m_Texture;

		[SerializeField]
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0xE0")]
		private Rect m_UVRect;

		[Token(Token = "0x170000E3")]
		public override Texture mainTexture
		{
			[Token(Token = "0x6000376")]
			[Address(RVA = "0x182CAF8", Offset = "0x182CAF8", Length = "0x158")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000E4")]
		public Texture texture
		{
			[Token(Token = "0x6000377")]
			[Address(RVA = "0x182CC50", Offset = "0x182CC50", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000378")]
			[Address(RVA = "0x182CC58", Offset = "0x182CC58", Length = "0xAC")]
			set
			{
			}
		}

		[Token(Token = "0x170000E5")]
		public Rect uvRect
		{
			[Token(Token = "0x6000379")]
			[Address(RVA = "0x182CD04", Offset = "0x182CD04", Length = "0xC")]
			get
			{
				return default(Rect);
			}
			[Token(Token = "0x600037A")]
			[Address(RVA = "0x182CD10", Offset = "0x182CD10", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x6000375")]
		[Address(RVA = "0x182CAD0", Offset = "0x182CAD0", Length = "0x28")]
		protected RawImage()
		{
		}

		[Token(Token = "0x600037B")]
		[Address(RVA = "0x182CD5C", Offset = "0x182CD5C", Length = "0x2B4")]
		public override void SetNativeSize()
		{
		}

		[Token(Token = "0x600037C")]
		[Address(RVA = "0x182D010", Offset = "0x182D010", Length = "0x2C8")]
		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		[Token(Token = "0x600037D")]
		[Address(RVA = "0x182D694", Offset = "0x182D694", Length = "0x3C")]
		protected override void OnDidApplyAnimationProperties()
		{
		}
	}
}
