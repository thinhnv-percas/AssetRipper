using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(RectTransform))]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[Token(Token = "0x200004E")]
	public abstract class LayoutGroup : UIBehaviour, ILayoutElement, ILayoutGroup, ILayoutController
	{
		[CompilerGenerated]
		[Token(Token = "0x200004F")]
		private sealed class _003CDelayedSetDirty_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000182")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000183")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000184")]
			[FieldOffset(Offset = "0x20")]
			public RectTransform rectTransform;

			[Token(Token = "0x170000D2")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60002FD")]
				[Address(RVA = "0x18277C4", Offset = "0x18277C4", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x170000D3")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60002FF")]
				[Address(RVA = "0x1827804", Offset = "0x1827804", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0x1827710", Offset = "0x1827710", Length = "0x28")]
			public _003CDelayedSetDirty_003Ed__56(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0x1827738", Offset = "0x1827738", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60002FC")]
			[Address(RVA = "0x182773C", Offset = "0x182773C", Length = "0x88")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60002FE")]
			[Address(RVA = "0x18277CC", Offset = "0x18277CC", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x20")]
		protected RectOffset m_Padding;

		[SerializeField]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x28")]
		protected TextAnchor m_ChildAlignment;

		[NonSerialized]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x30")]
		private RectTransform m_Rect;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x38")]
		protected DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x3C")]
		private Vector2 m_TotalMinSize;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x44")]
		private Vector2 m_TotalPreferredSize;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x4C")]
		private Vector2 m_TotalFlexibleSize;

		[NonSerialized]
		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x58")]
		private List<RectTransform> m_RectChildren;

		[Token(Token = "0x170000C6")]
		public RectOffset padding
		{
			[Token(Token = "0x60002D5")]
			[Address(RVA = "0x1827224", Offset = "0x1827224", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002D6")]
			[Address(RVA = "0x182722C", Offset = "0x182722C", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000C7")]
		public TextAnchor childAlignment
		{
			[Token(Token = "0x60002D7")]
			[Address(RVA = "0x1827288", Offset = "0x1827288", Length = "0x8")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x60002D8")]
			[Address(RVA = "0x1827290", Offset = "0x1827290", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000C8")]
		protected RectTransform rectTransform
		{
			[Token(Token = "0x60002D9")]
			[Address(RVA = "0x1824F30", Offset = "0x1824F30", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C9")]
		protected List<RectTransform> rectChildren
		{
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0x18272EC", Offset = "0x18272EC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000CA")]
		public virtual float minWidth
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0x18272F4", Offset = "0x18272F4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CB")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0x18272FC", Offset = "0x18272FC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CC")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0x1827304", Offset = "0x1827304", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CD")]
		public virtual float minHeight
		{
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0x182730C", Offset = "0x182730C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CE")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x60002E1")]
			[Address(RVA = "0x1827314", Offset = "0x1827314", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CF")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x60002E2")]
			[Address(RVA = "0x182731C", Offset = "0x182731C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000D0")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x60002E3")]
			[Address(RVA = "0x1827324", Offset = "0x1827324", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170000D1")]
		private bool isRootLayoutGroup
		{
			[Token(Token = "0x60002F4")]
			[Address(RVA = "0x1827544", Offset = "0x1827544", Length = "0x138")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0x18248F0", Offset = "0x18248F0", Length = "0x3B8")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60002DC")]
		public abstract void CalculateLayoutInputVertical();

		[Token(Token = "0x60002E4")]
		public abstract void SetLayoutHorizontal();

		[Token(Token = "0x60002E5")]
		public abstract void SetLayoutVertical();

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x1824608", Offset = "0x1824608", Length = "0x11C")]
		protected internal LayoutGroup()
		{
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x182732C", Offset = "0x182732C", Length = "0x1C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x182741C", Offset = "0x182741C", Length = "0x7C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x1827498", Offset = "0x1827498", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x1826CA4", Offset = "0x1826CA4", Length = "0x70")]
		protected float GetTotalMinSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x1826BC4", Offset = "0x1826BC4", Length = "0x70")]
		protected float GetTotalPreferredSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x1826C34", Offset = "0x1826C34", Length = "0x70")]
		protected float GetTotalFlexibleSize(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x1825760", Offset = "0x1825760", Length = "0x148")]
		protected float GetStartOffset(int axis, float requiredSpaceWithoutPadding)
		{
			return 0f;
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x18266D8", Offset = "0x18266D8", Length = "0x4C")]
		protected float GetAlignmentOnAxis(int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x1824CA8", Offset = "0x1824CA8", Length = "0x80")]
		protected void SetLayoutInputForAxis(float totalMin, float totalPreferred, float totalFlexible, int axis)
		{
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0x182749C", Offset = "0x182749C", Length = "0xA8")]
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos)
		{
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0x1826998", Offset = "0x1826998", Length = "0x22C")]
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float scaleFactor)
		{
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x18258A8", Offset = "0x18258A8", Length = "0xB0")]
		protected void SetChildAlongAxis(RectTransform rect, int axis, float pos, float size)
		{
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x1826724", Offset = "0x1826724", Length = "0x274")]
		protected void SetChildAlongAxisWithScale(RectTransform rect, int axis, float pos, float size, float scaleFactor)
		{
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0x182767C", Offset = "0x182767C", Length = "0x30")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0x18276AC", Offset = "0x18276AC", Length = "0x4")]
		protected virtual void OnTransformChildrenChanged()
		{
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0xC76F5C", Offset = "0xC76F5C", Length = "0xB4")]
		protected void SetProperty<T>(ref T currentValue, T newValue)
		{
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0x1827348", Offset = "0x1827348", Length = "0xD4")]
		protected void SetDirty()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetDirty_003Ed__56))]
		[Token(Token = "0x60002F9")]
		[Address(RVA = "0x18276B0", Offset = "0x18276B0", Length = "0x60")]
		private IEnumerator DelayedSetDirty(RectTransform rectTransform)
		{
			return null;
		}
	}
}
