using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x7274E8", Offset = "0x7274E8")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x7274E8", Offset = "0x7274E8")]
	[ExecuteAlways]
	[Token(Token = "0x2000024")]
	public class LayoutElement : UIBehaviour, ILayoutElement, ILayoutIgnorer
	{
		[SerializeField]
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x18")]
		private bool m_IgnoreLayout;

		[SerializeField]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x1C")]
		private float m_MinWidth;

		[SerializeField]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x20")]
		private float m_MinHeight;

		[SerializeField]
		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x24")]
		private float m_PreferredWidth;

		[SerializeField]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x28")]
		private float m_PreferredHeight;

		[SerializeField]
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x2C")]
		private float m_FlexibleWidth;

		[SerializeField]
		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x30")]
		private float m_FlexibleHeight;

		[SerializeField]
		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x34")]
		private int m_LayoutPriority;

		[Token(Token = "0x170000AC")]
		public virtual bool ignoreLayout
		{
			[Token(Token = "0x6000259")]
			[Address(RVA = "0xF5CA20", Offset = "0xF5CA20", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600025A")]
			[Address(RVA = "0xF5CA28", Offset = "0xF5CA28", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AD")]
		public virtual float minWidth
		{
			[Token(Token = "0x600025D")]
			[Address(RVA = "0xF5CB6C", Offset = "0xF5CB6C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600025E")]
			[Address(RVA = "0xF5CB74", Offset = "0xF5CB74", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AE")]
		public virtual float minHeight
		{
			[Token(Token = "0x600025F")]
			[Address(RVA = "0xF5CBF0", Offset = "0xF5CBF0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000260")]
			[Address(RVA = "0xF5CBF8", Offset = "0xF5CBF8", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AF")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0xF5CC74", Offset = "0xF5CC74", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000262")]
			[Address(RVA = "0xF5CC7C", Offset = "0xF5CC7C", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B0")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0xF5CCF8", Offset = "0xF5CCF8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000264")]
			[Address(RVA = "0xF5CD00", Offset = "0xF5CD00", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B1")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x6000265")]
			[Address(RVA = "0xF5CD7C", Offset = "0xF5CD7C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000266")]
			[Address(RVA = "0xF5CD84", Offset = "0xF5CD84", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B2")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x6000267")]
			[Address(RVA = "0xF5CE00", Offset = "0xF5CE00", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000268")]
			[Address(RVA = "0xF5CE08", Offset = "0xF5CE08", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B3")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x6000269")]
			[Address(RVA = "0xF5CE84", Offset = "0xF5CE84", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600026A")]
			[Address(RVA = "0xF5CE8C", Offset = "0xF5CE8C", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0xF5CB64", Offset = "0xF5CB64", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0xF5CB68", Offset = "0xF5CB68", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0xF5CF08", Offset = "0xF5CF08", Length = "0x24")]
		protected LayoutElement()
		{
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0xF5CF2C", Offset = "0xF5CF2C", Length = "0x28")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xF5CF54", Offset = "0xF5CF54", Length = "0x4")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xF5CF58", Offset = "0xF5CF58", Length = "0x28")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xF5CF80", Offset = "0xF5CF80", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xF5CF84", Offset = "0xF5CF84", Length = "0x4")]
		protected override void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xF5CAA4", Offset = "0xF5CAA4", Length = "0xC0")]
		protected void SetDirty()
		{
		}
	}
}
