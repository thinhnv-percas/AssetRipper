using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AddComponentMenu("Layout/Layout Element", 140)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x200004D")]
	public class LayoutElement : UIBehaviour, ILayoutElement, ILayoutIgnorer
	{
		[SerializeField]
		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x20")]
		private bool m_IgnoreLayout;

		[SerializeField]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x24")]
		private float m_MinWidth;

		[SerializeField]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x28")]
		private float m_MinHeight;

		[SerializeField]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x2C")]
		private float m_PreferredWidth;

		[SerializeField]
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x30")]
		private float m_PreferredHeight;

		[SerializeField]
		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x34")]
		private float m_FlexibleWidth;

		[SerializeField]
		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x38")]
		private float m_FlexibleHeight;

		[SerializeField]
		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x3C")]
		private int m_LayoutPriority;

		[Token(Token = "0x170000BE")]
		public virtual bool ignoreLayout
		{
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0x1826D20", Offset = "0x1826D20", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0x1826D28", Offset = "0x1826D28", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000BF")]
		public virtual float minWidth
		{
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0x1826E5C", Offset = "0x1826E5C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C1")]
			[Address(RVA = "0x1826E64", Offset = "0x1826E64", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C0")]
		public virtual float minHeight
		{
			[Token(Token = "0x60002C2")]
			[Address(RVA = "0x1826ED8", Offset = "0x1826ED8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C3")]
			[Address(RVA = "0x1826EE0", Offset = "0x1826EE0", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C1")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x60002C4")]
			[Address(RVA = "0x1826F54", Offset = "0x1826F54", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C5")]
			[Address(RVA = "0x1826F5C", Offset = "0x1826F5C", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C2")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0x1826FD0", Offset = "0x1826FD0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0x1826FD8", Offset = "0x1826FD8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C3")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0x182704C", Offset = "0x182704C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0x1827054", Offset = "0x1827054", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C4")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0x18270C8", Offset = "0x18270C8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0x18270D0", Offset = "0x18270D0", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000C5")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0x1827144", Offset = "0x1827144", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0x182714C", Offset = "0x182714C", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0x1826E54", Offset = "0x1826E54", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x1826E58", Offset = "0x1826E58", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0x18271C0", Offset = "0x18271C0", Length = "0x20")]
		protected LayoutElement()
		{
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0x18271E0", Offset = "0x18271E0", Length = "0x1C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0x18271FC", Offset = "0x18271FC", Length = "0x4")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0x1827200", Offset = "0x1827200", Length = "0x1C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x182721C", Offset = "0x182721C", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x1827220", Offset = "0x1827220", Length = "0x4")]
		protected override void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x1826D9C", Offset = "0x1826D9C", Length = "0xB8")]
		protected void SetDirty()
		{
		}
	}
}
