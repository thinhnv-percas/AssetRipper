using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727644", Offset = "0x727644")]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727644", Offset = "0x727644")]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000029")]
	public class Mask : UIBehaviour, ICanvasRaycastFilter, IMaterialModifier
	{
		[NonSerialized]
		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x18")]
		private RectTransform m_RectTransform;

		[SerializeField]
		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x20")]
		private bool m_ShowMaskGraphic;

		[NonSerialized]
		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x28")]
		private Graphic m_Graphic;

		[NonSerialized]
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x30")]
		private Material m_MaskMaterial;

		[NonSerialized]
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x38")]
		private Material m_UnmaskMaterial;

		[Token(Token = "0x170000C1")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0xEC7100", Offset = "0xEC7100", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C2")]
		public bool showMaskGraphic
		{
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0xEC7160", Offset = "0xEC7160", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0xEC7168", Offset = "0xEC7168", Length = "0xD8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C3")]
		public Graphic graphic
		{
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0xEC7240", Offset = "0xEC7240", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0xEC72A0", Offset = "0xEC72A0", Length = "0x10")]
		protected Mask()
		{
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0xEC72B0", Offset = "0xEC72B0", Length = "0xA0")]
		public virtual bool MaskEnabled()
		{
			return false;
		}

		[Obsolete]
		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xEC7350", Offset = "0xEC7350", Length = "0x4")]
		public virtual void OnSiblingGraphicEnabledDisabled()
		{
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xEC7354", Offset = "0xEC7354", Length = "0xD8")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0xEC768C", Offset = "0xEC768C", Length = "0x138")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0xEC797C", Offset = "0xEC797C", Length = "0xC8")]
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0xEC7A44", Offset = "0xEC7A44", Length = "0x290")]
		public virtual Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}
	}
}
