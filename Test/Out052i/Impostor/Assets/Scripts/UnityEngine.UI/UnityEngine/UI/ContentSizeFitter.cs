using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AddComponentMenu("Layout/Content Size Fitter", 141)]
	[RequireComponent(typeof(RectTransform))]
	[ExecuteAlways]
	[Token(Token = "0x2000040")]
	public class ContentSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[Token(Token = "0x2000041")]
		public enum FitMode
		{
			[Token(Token = "0x4000155")]
			Unconstrained = 0,
			[Token(Token = "0x4000156")]
			MinSize = 1,
			[Token(Token = "0x4000157")]
			PreferredSize = 2
		}

		[SerializeField]
		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x20")]
		protected FitMode m_HorizontalFit;

		[SerializeField]
		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x24")]
		protected FitMode m_VerticalFit;

		[NonSerialized]
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_Rect;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x30")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x170000A5")]
		public FitMode horizontalFit
		{
			[Token(Token = "0x6000278")]
			[Address(RVA = "0x1823F58", Offset = "0x1823F58", Length = "0x8")]
			get
			{
				return FitMode.Unconstrained;
			}
			[Token(Token = "0x6000279")]
			[Address(RVA = "0x1823F60", Offset = "0x1823F60", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000A6")]
		public FitMode verticalFit
		{
			[Token(Token = "0x600027A")]
			[Address(RVA = "0x1824058", Offset = "0x1824058", Length = "0x8")]
			get
			{
				return FitMode.Unconstrained;
			}
			[Token(Token = "0x600027B")]
			[Address(RVA = "0x1824060", Offset = "0x1824060", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000A7")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x600027C")]
			[Address(RVA = "0x18240D4", Offset = "0x18240D4", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0x1824168", Offset = "0x1824168", Length = "0x8")]
		protected ContentSizeFitter()
		{
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0x1824170", Offset = "0x1824170", Length = "0x1C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0x182418C", Offset = "0x182418C", Length = "0x7C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0x1824208", Offset = "0x1824208", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0x182420C", Offset = "0x182420C", Length = "0xE4")]
		private void HandleSelfFittingAlongAxis(int axis)
		{
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0x1824308", Offset = "0x1824308", Length = "0x24")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0x182432C", Offset = "0x182432C", Length = "0x8")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0x1823FD4", Offset = "0x1823FD4", Length = "0x84")]
		protected void SetDirty()
		{
		}
	}
}
