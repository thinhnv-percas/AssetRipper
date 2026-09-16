using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7273C4", Offset = "0x7273C4")]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7273C4", Offset = "0x7273C4")]
	[Token(Token = "0x200001B")]
	public class ContentSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[Token(Token = "0x2000095")]
		public enum FitMode
		{
			[Token(Token = "0x4000295")]
			Unconstrained = 0,
			[Token(Token = "0x4000296")]
			MinSize = 1,
			[Token(Token = "0x4000297")]
			PreferredSize = 2
		}

		[SerializeField]
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x18")]
		protected FitMode m_HorizontalFit;

		[SerializeField]
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x1C")]
		protected FitMode m_VerticalFit;

		[NonSerialized]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_Rect;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x28")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x17000094")]
		public FitMode horizontalFit
		{
			[Token(Token = "0x6000217")]
			[Address(RVA = "0xC4F780", Offset = "0xC4F780", Length = "0x8")]
			get
			{
				return FitMode.Unconstrained;
			}
			[Token(Token = "0x6000218")]
			[Address(RVA = "0xC4F788", Offset = "0xC4F788", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000095")]
		public FitMode verticalFit
		{
			[Token(Token = "0x6000219")]
			[Address(RVA = "0xC4F89C", Offset = "0xC4F89C", Length = "0x8")]
			get
			{
				return FitMode.Unconstrained;
			}
			[Token(Token = "0x600021A")]
			[Address(RVA = "0xC4F8A4", Offset = "0xC4F8A4", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000096")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x600021B")]
			[Address(RVA = "0xC4F920", Offset = "0xC4F920", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xC4F9B8", Offset = "0xC4F9B8", Length = "0x8")]
		protected ContentSizeFitter()
		{
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0xC4F9C0", Offset = "0xC4F9C0", Length = "0x4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0xC4F9C4", Offset = "0xC4F9C4", Length = "0x84")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0xC4FA48", Offset = "0xC4FA48", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0xC4FA4C", Offset = "0xC4FA4C", Length = "0xD4")]
		private void HandleSelfFittingAlongAxis(int axis)
		{
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0xC4FB20", Offset = "0xC4FB20", Length = "0x30")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0xC4FB50", Offset = "0xC4FB50", Length = "0x1D4")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0xC4F804", Offset = "0xC4F804", Length = "0x98")]
		protected void SetDirty()
		{
		}
	}
}
