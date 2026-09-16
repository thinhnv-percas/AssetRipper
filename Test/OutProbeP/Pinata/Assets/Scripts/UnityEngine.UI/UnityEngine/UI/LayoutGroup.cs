using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727584", Offset = "0x727584")]
	[Token(Token = "0x2000025")]
	public abstract class LayoutGroup : UIBehaviour, ILayoutElement, ILayoutGroup, ILayoutController
	{
		[SerializeField]
		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x18")]
		protected RectOffset m_Padding;

		[SerializeField]
		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x20")]
		protected TextAnchor m_ChildAlignment;

		[NonSerialized]
		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_Rect;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x30")]
		protected DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x34")]
		private Vector2 m_TotalMinSize;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x3C")]
		private Vector2 m_TotalPreferredSize;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x44")]
		private Vector2 m_TotalFlexibleSize;

		[NonSerialized]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x50")]
		private List<RectTransform> m_RectChildren;

		[Token(Token = "0x170000B4")]
		public RectOffset padding
		{
			[Token(Token = "0x6000272")]
			[Address(RVA = "0xF5CF88", Offset = "0xF5CF88", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000273")]
			[Address(RVA = "0xF5CF90", Offset = "0xF5CF90", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000B5")]
		public TextAnchor childAlignment
		{
			[Token(Token = "0x6000274")]
			[Address(RVA = "0xF5CFF4", Offset = "0xF5CFF4", Length = "0x8")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x6000275")]
			[Address(RVA = "0xF5CFFC", Offset = "0xF5CFFC", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000B6")]
		protected RectTransform rectTransform
		{
			[Token(Token = "0x6000276")]
			[Address(RVA = "0xF4A7BC", Offset = "0xF4A7BC", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B7")]
		protected List<RectTransform> rectChildren
		{
			[Token(Token = "0x6000277")]
			[Address(RVA = "0xF5D060", Offset = "0xF5D060", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B8")]
		public virtual float minWidth
		{
			[Token(Token = "0x600027A")]
			[Address(RVA = "0xF5D068", Offset = "0xF5D068", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B9")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x600027B")]
			[Address(RVA = "0xF5D078", Offset = "0xF5D078", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000BA")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x600027C")]
			[Address(RVA = "0xF5D088", Offset = "0xF5D088", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000BB")]
		public virtual float minHeight
		{
			[Token(Token = "0x600027D")]
			[Address(RVA = "0xF5D098", Offset = "0xF5D098", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000BC")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x600027E")]
			[Address(RVA = "0xF5D0A8", Offset = "0xF5D0A8", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000BD")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x600027F")]
			[Address(RVA = "0xF5D0B8", Offset = "0xF5D0B8", Length = "0x10")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000BE")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x6000280")]
			[Address(RVA = "0xF5D0C8", Offset = "0xF5D0C8", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170000BF")]
		private bool isRootLayoutGroup
		{
			[Token(Token = "0x6000291")]
			[Address(RVA = "0xF5D338", Offset = "0xF5D338", Length = "0x154")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xF4A264", Offset = "0xF4A264", Length = "0x318")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000279")]
		public abstract void CalculateLayoutInputVertical();

		[Token(Token = "0x6000281")]
		public abstract void SetLayoutHorizontal();

		[Token(Token = "0x6000282")]
		public abstract void SetLayoutVertical();

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xF49FCC", Offset = "0xF49FCC", Length = "0x100")]
		protected internal LayoutGroup()
		{
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xF5D0D0", Offset = "0xF5D0D0", Length = "0x28")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xF5D1EC", Offset = "0xF5D1EC", Length = "0x90")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xF5D27C", Offset = "0xF5D27C", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xF4C1E4", Offset = "0xF4C1E4", Length = "0xC")]
		protected float GetTotalMinSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xF4C1CC", Offset = "0xF4C1CC", Length = "0xC")]
		protected float GetTotalPreferredSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xF4C1D8", Offset = "0xF4C1D8", Length = "0xC")]
		protected float GetTotalFlexibleSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xF4AECC", Offset = "0xF4AECC", Length = "0x124")]
		protected float GetStartOffset(int axis, float requiredSpaceWithoutPadding)
		{
			return 0f;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xF4BDE4", Offset = "0xF4BDE4", Length = "0x4C")]
		protected float GetAlignmentOnAxis(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xF4A57C", Offset = "0xF4A57C", Length = "0x60")]
		protected void SetLayoutInputForAxis(float totalMin, float totalPreferred, float totalFlexible, int axis)
		{
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xF5D280", Offset = "0xF5D280", Length = "0xB8")]
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos)
		{
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xF4C008", Offset = "0xF4C008", Length = "0x1C4")]
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float scaleFactor)
		{
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xF4AFF0", Offset = "0xF4AFF0", Length = "0xC0")]
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos, float size)
		{
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xF4BE30", Offset = "0xF4BE30", Length = "0x1D8")]
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float size, float scaleFactor)
		{
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0xF5D48C", Offset = "0xF5D48C", Length = "0x40")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xF5D4CC", Offset = "0xF5D4CC", Length = "0x4")]
		protected virtual void OnTransformChildrenChanged()
		{
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0xB86754", Offset = "0xB86754", Length = "0x8C")]
		protected void SetProperty<T>(ref T currentValue, T newValue)
		{
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xF5D0F8", Offset = "0xF5D0F8", Length = "0xF4")]
		protected void SetDirty()
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72A198", Offset = "0x72A198")]
		[Token(Token = "0x6000296")]
		[Address(RVA = "0xF5D4D0", Offset = "0xF5D4D0", Length = "0x1074")]
		private IEnumerator DelayedSetDirty(RectTransform rectTransform)
		{
			return null;
		}
	}
}
