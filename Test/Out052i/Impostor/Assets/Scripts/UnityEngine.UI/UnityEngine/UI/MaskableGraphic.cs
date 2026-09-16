using System;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000056")]
	public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier
	{
		[Serializable]
		[Token(Token = "0x2000057")]
		public class CullStateChangedEvent : UnityEvent<bool>
		{
			[Token(Token = "0x6000358")]
			[Address(RVA = "0x182BB48", Offset = "0x182BB48", Length = "0x48")]
			public CullStateChangedEvent()
			{
			}
		}

		[NonSerialized]
		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0xA1")]
		protected bool m_ShouldRecalculateStencil;

		[NonSerialized]
		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0xA8")]
		protected Material m_MaskMaterial;

		[NonSerialized]
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0xB0")]
		private RectMask2D m_ParentMask;

		[SerializeField]
		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0xB8")]
		private bool m_Maskable;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0xB9")]
		private bool m_IsMaskingGraphic;

		[NonSerialized]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not used anymore.", true)]
		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0xBA")]
		protected bool m_IncludeForMasking;

		[SerializeField]
		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0xC0")]
		private CullStateChangedEvent m_OnCullStateChanged;

		[NonSerialized]
		[Obsolete("Not used anymore", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0xC8")]
		protected bool m_ShouldRecalculate;

		[NonSerialized]
		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0xCC")]
		protected int m_StencilValue;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0xD0")]
		private readonly Vector3[] m_Corners;

		[Token(Token = "0x170000D8")]
		public CullStateChangedEvent onCullStateChanged
		{
			[Token(Token = "0x6000342")]
			[Address(RVA = "0x182ADA4", Offset = "0x182ADA4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000343")]
			[Address(RVA = "0x182ADAC", Offset = "0x182ADAC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D9")]
		public bool maskable
		{
			[Token(Token = "0x6000344")]
			[Address(RVA = "0x182ADB4", Offset = "0x182ADB4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000345")]
			[Address(RVA = "0x182ADBC", Offset = "0x182ADBC", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x170000DA")]
		public bool isMaskingGraphic
		{
			[Token(Token = "0x6000346")]
			[Address(RVA = "0x182ADEC", Offset = "0x182ADEC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000347")]
			[Address(RVA = "0x182A208", Offset = "0x182A208", Length = "0x18")]
			set
			{
			}
		}

		[Token(Token = "0x170000DB")]
		private Rect rootCanvasRect
		{
			[Token(Token = "0x6000352")]
			[Address(RVA = "0x182AFC4", Offset = "0x182AFC4", Length = "0x1B8")]
			get
			{
				return default(Rect);
			}
		}

		GameObject IClippable.gameObject
		{
			[Token(Token = "0x6000357")]
			[Address(RVA = "0x182BB90", Offset = "0x182BB90", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x182ADF4", Offset = "0x182ADF4", Length = "0x100")]
		public virtual Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x182AEF4", Offset = "0x182AEF4", Length = "0xD0")]
		public virtual void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x182B17C", Offset = "0x182B17C", Length = "0xE4")]
		private void UpdateCull(bool cull)
		{
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x182B260", Offset = "0x182B260", Length = "0x6C")]
		public virtual void SetClipRect(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x182B2CC", Offset = "0x182B2CC", Length = "0x38")]
		public virtual void SetClipSoftness(Vector2 clipSoftness)
		{
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x182B304", Offset = "0x182B304", Length = "0x50")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x182B4A8", Offset = "0x182B4A8", Length = "0xAC")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0x182B554", Offset = "0x182B554", Length = "0x50")]
		protected override void OnTransformParentChanged()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Not used anymore.", true)]
		[Token(Token = "0x6000350")]
		[Address(RVA = "0x182B5A4", Offset = "0x182B5A4", Length = "0x4")]
		public virtual void ParentMaskStateChanged()
		{
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0x182B5A8", Offset = "0x182B5A8", Length = "0x50")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0x182B354", Offset = "0x182B354", Length = "0x154")]
		private void UpdateClipParent()
		{
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0x182BA0C", Offset = "0x182BA0C", Length = "0x4")]
		public virtual void RecalculateClipping()
		{
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0x182BA10", Offset = "0x182BA10", Length = "0x7C")]
		public virtual void RecalculateMasking()
		{
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0x182BA8C", Offset = "0x182BA8C", Length = "0xBC")]
		protected internal MaskableGraphic()
		{
		}
	}
}
