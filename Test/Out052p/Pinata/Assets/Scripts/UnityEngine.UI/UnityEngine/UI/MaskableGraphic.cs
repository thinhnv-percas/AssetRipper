using System;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[Token(Token = "0x200002A")]
	public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier
	{
		[Serializable]
		[Token(Token = "0x200009C")]
		public class CullStateChangedEvent : UnityEvent<bool>
		{
			[Token(Token = "0x600066C")]
			[Address(RVA = "0xECA344", Offset = "0xECA344", Length = "0x50")]
			public CullStateChangedEvent()
			{
			}
		}

		[NonSerialized]
		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x89")]
		protected bool m_ShouldRecalculateStencil;

		[NonSerialized]
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x90")]
		protected Material m_MaskMaterial;

		[NonSerialized]
		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x98")]
		private RectMask2D m_ParentMask;

		[NonSerialized]
		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0xA0")]
		private bool m_Maskable;

		[NonSerialized]
		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x729360", Offset = "0x729360")]
		[Obsolete]
		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0xA1")]
		protected bool m_IncludeForMasking;

		[SerializeField]
		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0xA8")]
		private CullStateChangedEvent m_OnCullStateChanged;

		[NonSerialized]
		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x7293C4", Offset = "0x7293C4")]
		[Obsolete]
		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0xB0")]
		protected bool m_ShouldRecalculate;

		[NonSerialized]
		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0xB4")]
		protected int m_StencilValue;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0xB8")]
		private readonly Vector3[] m_Corners;

		[Token(Token = "0x170000C4")]
		public CullStateChangedEvent onCullStateChanged
		{
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0xEC9484", Offset = "0xEC9484", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0xEC948C", Offset = "0xEC948C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C5")]
		public bool maskable
		{
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0xEC9494", Offset = "0xEC9494", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0xEC949C", Offset = "0xEC949C", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000C6")]
		private Rect rootCanvasRect
		{
			[Token(Token = "0x60002D3")]
			[Address(RVA = "0xEC96B4", Offset = "0xEC96B4", Length = "0x35C")]
			get
			{
				return default(Rect);
			}
		}

		GameObject IClippable.gameObject
		{
			[Token(Token = "0x60002D8")]
			[Address(RVA = "0xECA394", Offset = "0xECA394", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0xEC94D4", Offset = "0xEC94D4", Length = "0x180")]
		public virtual Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0xEC9654", Offset = "0xEC9654", Length = "0x60")]
		public virtual void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xEC9A10", Offset = "0xEC9A10", Length = "0xE4")]
		private void UpdateCull(bool cull)
		{
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xEC9AF4", Offset = "0xEC9AF4", Length = "0x7C")]
		public virtual void SetClipRect(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xEC9B70", Offset = "0xEC9B70", Length = "0xD0")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xEC9DB0", Offset = "0xEC9DB0", Length = "0x100")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xEC9EB0", Offset = "0xEC9EB0", Length = "0x60")]
		protected override void OnTransformParentChanged()
		{
		}

		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72A234", Offset = "0x72A234")]
		[Obsolete]
		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xEC9F10", Offset = "0xEC9F10", Length = "0x4")]
		public virtual void ParentMaskStateChanged()
		{
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xEC9F14", Offset = "0xEC9F14", Length = "0x60")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0xEC9C40", Offset = "0xEC9C40", Length = "0x170")]
		private void UpdateClipParent()
		{
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0xECA204", Offset = "0xECA204", Length = "0x4")]
		public virtual void RecalculateClipping()
		{
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0xECA208", Offset = "0xECA208", Length = "0x88")]
		public virtual void RecalculateMasking()
		{
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0xECA290", Offset = "0xECA290", Length = "0xB4")]
		protected internal MaskableGraphic()
		{
		}
	}
}
