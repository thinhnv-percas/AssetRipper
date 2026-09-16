using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Rect Mask 2D", 14)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[Token(Token = "0x200005F")]
	public class RectMask2D : UIBehaviour, IClipper, ICanvasRaycastFilter
	{
		[NonSerialized]
		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x20")]
		private readonly RectangularVertexClipper m_VertexClipper;

		[NonSerialized]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_RectTransform;

		[NonSerialized]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x30")]
		private HashSet<MaskableGraphic> m_MaskableTargets;

		[NonSerialized]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x38")]
		private HashSet<IClippable> m_ClipTargets;

		[NonSerialized]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x40")]
		private bool m_ShouldRecalculateClipRects;

		[NonSerialized]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x48")]
		private List<RectMask2D> m_Clippers;

		[NonSerialized]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x50")]
		private Rect m_LastClipRectCanvasSpace;

		[NonSerialized]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x60")]
		private bool m_ForceClip;

		[SerializeField]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x64")]
		private Vector4 m_Padding;

		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x74")]
		private Vector2Int m_Softness;

		[NonSerialized]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x80")]
		private Canvas m_Canvas;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x88")]
		private Vector3[] m_Corners;

		[Token(Token = "0x170000E6")]
		public Vector4 padding
		{
			[Token(Token = "0x600037E")]
			[Address(RVA = "0x182D6D0", Offset = "0x182D6D0", Length = "0xC")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x600037F")]
			[Address(RVA = "0x182D6DC", Offset = "0x182D6DC", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x170000E7")]
		public Vector2Int softness
		{
			[Token(Token = "0x6000380")]
			[Address(RVA = "0x182D6EC", Offset = "0x182D6EC", Length = "0x8")]
			get
			{
				return default(Vector2Int);
			}
			[Token(Token = "0x6000381")]
			[Address(RVA = "0x182D6F4", Offset = "0x182D6F4", Length = "0x18")]
			set
			{
			}
		}

		[Token(Token = "0x170000E8")]
		internal Canvas Canvas
		{
			[Token(Token = "0x6000382")]
			[Address(RVA = "0x182D70C", Offset = "0x182D70C", Length = "0x160")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000E9")]
		public Rect canvasRect
		{
			[Token(Token = "0x6000383")]
			[Address(RVA = "0x182D86C", Offset = "0x182D86C", Length = "0x44")]
			get
			{
				return default(Rect);
			}
		}

		[Token(Token = "0x170000EA")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x6000384")]
			[Address(RVA = "0x182D8B0", Offset = "0x182D8B0", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000EB")]
		private Rect rootCanvasRect
		{
			[Token(Token = "0x600038A")]
			[Address(RVA = "0x182DC6C", Offset = "0x182DC6C", Length = "0xFC")]
			get
			{
				return default(Rect);
			}
		}

		[Token(Token = "0x6000385")]
		[Address(RVA = "0x182D908", Offset = "0x182D908", Length = "0x164")]
		protected RectMask2D()
		{
		}

		[Token(Token = "0x6000386")]
		[Address(RVA = "0x182DA6C", Offset = "0x182DA6C", Length = "0x34")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000387")]
		[Address(RVA = "0x182DAA0", Offset = "0x182DAA0", Length = "0xD0")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0x182DB70", Offset = "0x182DB70", Length = "0x20")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x6000389")]
		[Address(RVA = "0x182DB90", Offset = "0x182DB90", Length = "0xDC")]
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x600038B")]
		[Address(RVA = "0x182DD68", Offset = "0x182DD68", Length = "0x81C")]
		public virtual void PerformClipping()
		{
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0x182E584", Offset = "0x182E584", Length = "0x2F8")]
		public virtual void UpdateClipSoftness()
		{
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0x182E87C", Offset = "0x182E87C", Length = "0x114")]
		public void AddClippable(IClippable clippable)
		{
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0x182E990", Offset = "0x182E990", Length = "0x1A0")]
		public void RemoveClippable(IClippable clippable)
		{
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0x182EB30", Offset = "0x182EB30", Length = "0x24")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x6000390")]
		[Address(RVA = "0x182EB54", Offset = "0x182EB54", Length = "0x24")]
		protected override void OnCanvasHierarchyChanged()
		{
		}
	}
}
