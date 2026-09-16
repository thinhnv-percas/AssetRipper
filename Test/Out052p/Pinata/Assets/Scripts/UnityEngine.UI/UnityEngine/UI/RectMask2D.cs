using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72772C", Offset = "0x72772C")]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x72772C", Offset = "0x72772C")]
	[Token(Token = "0x2000030")]
	public class RectMask2D : UIBehaviour, IClipper, ICanvasRaycastFilter
	{
		[NonSerialized]
		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x18")]
		private readonly RectangularVertexClipper m_VertexClipper;

		[NonSerialized]
		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_RectTransform;

		[NonSerialized]
		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x28")]
		private HashSet<MaskableGraphic> m_MaskableTargets;

		[NonSerialized]
		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x30")]
		private HashSet<IClippable> m_ClipTargets;

		[NonSerialized]
		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x38")]
		private bool m_ShouldRecalculateClipRects;

		[NonSerialized]
		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x40")]
		private List<RectMask2D> m_Clippers;

		[NonSerialized]
		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x48")]
		private Rect m_LastClipRectCanvasSpace;

		[NonSerialized]
		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x58")]
		private bool m_ForceClip;

		[NonSerialized]
		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x60")]
		private Canvas m_Canvas;

		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x68")]
		private Vector3[] m_Corners;

		[Token(Token = "0x170000D0")]
		private Canvas Canvas
		{
			[Token(Token = "0x60002F9")]
			[Address(RVA = "0xECBDDC", Offset = "0xECBDDC", Length = "0x140")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D1")]
		public Rect canvasRect
		{
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0xECBF1C", Offset = "0xECBF1C", Length = "0x50")]
			get
			{
				return default(Rect);
			}
		}

		[Token(Token = "0x170000D2")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0xECBF6C", Offset = "0xECBF6C", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D3")]
		private Rect rootCanvasRect
		{
			[Token(Token = "0x6000300")]
			[Address(RVA = "0xECC46C", Offset = "0xECC46C", Length = "0x140")]
			get
			{
				return default(Rect);
			}
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0xECC15C", Offset = "0xECC15C", Length = "0xF4")]
		protected RectMask2D()
		{
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0xECC2C0", Offset = "0xECC2C0", Length = "0x3C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0xECC2FC", Offset = "0xECC2FC", Length = "0xA8")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0xECC3A4", Offset = "0xECC3A4", Length = "0xC8")]
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0xECC5AC", Offset = "0xECC5AC", Length = "0x734")]
		public virtual void PerformClipping()
		{
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0xECA0FC", Offset = "0xECA0FC", Length = "0x108")]
		public void AddClippable(IClippable clippable)
		{
		}

		[Token(Token = "0x6000303")]
		[Address(RVA = "0xEC9F74", Offset = "0xEC9F74", Length = "0x188")]
		public void RemoveClippable(IClippable clippable)
		{
		}

		[Token(Token = "0x6000304")]
		[Address(RVA = "0xECCCE0", Offset = "0xECCCE0", Length = "0x2C")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0xECCD0C", Offset = "0xECCD0C", Length = "0x30")]
		protected override void OnCanvasHierarchyChanged()
		{
		}
	}
}
