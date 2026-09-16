using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x72726C", Offset = "0x72726C")]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x72726C", Offset = "0x72726C")]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000019")]
	public class AspectRatioFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[Token(Token = "0x2000091")]
		public enum AspectMode
		{
			[Token(Token = "0x4000281")]
			None = 0,
			[Token(Token = "0x4000282")]
			WidthControlsHeight = 1,
			[Token(Token = "0x4000283")]
			HeightControlsWidth = 2,
			[Token(Token = "0x4000284")]
			FitInParent = 3,
			[Token(Token = "0x4000285")]
			EnvelopeParent = 4
		}

		[SerializeField]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x18")]
		private AspectMode m_AspectMode;

		[SerializeField]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x1C")]
		private float m_AspectRatio;

		[NonSerialized]
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_Rect;

		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x28")]
		private bool m_DelayedSetDirty;

		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x29")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x17000087")]
		public AspectMode aspectMode
		{
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0xC4BFAC", Offset = "0xC4BFAC", Length = "0x8")]
			get
			{
				return AspectMode.None;
			}
			[Token(Token = "0x60001E9")]
			[Address(RVA = "0xC4BFB4", Offset = "0xC4BFB4", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000088")]
		public float aspectRatio
		{
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0xC4C034", Offset = "0xC4C034", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001EB")]
			[Address(RVA = "0xC4C03C", Offset = "0xC4C03C", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000089")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x60001EC")]
			[Address(RVA = "0xC4C0B8", Offset = "0xC4C0B8", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0xC4C150", Offset = "0xC4C150", Length = "0x10")]
		protected AspectRatioFitter()
		{
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xC4C160", Offset = "0xC4C160", Length = "0x4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xC4C164", Offset = "0xC4C164", Length = "0x84")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xC4C1E8", Offset = "0xC4C1E8", Length = "0x14")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xC4C1FC", Offset = "0xC4C1FC", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xC4C200", Offset = "0xC4C200", Length = "0x2B8")]
		private void UpdateRect()
		{
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0xC4C5C8", Offset = "0xC4C5C8", Length = "0xB4")]
		private float GetSizeDeltaToProduceSize(float size, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0xC4C4B8", Offset = "0xC4C4B8", Length = "0x110")]
		private Vector2 GetParentSize()
		{
			return default(Vector2);
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0xC4C67C", Offset = "0xC4C67C", Length = "0x4")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0xC4C680", Offset = "0xC4C680", Length = "0x4")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0xC4C030", Offset = "0xC4C030", Length = "0x4")]
		protected void SetDirty()
		{
		}
	}
}
