using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("Layout/Vertical Layout Group", 151)]
	[Token(Token = "0x2000054")]
	public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
	{
		[Token(Token = "0x6000332")]
		[Address(RVA = "0x1829E4C", Offset = "0x1829E4C", Length = "0xC")]
		protected VerticalLayoutGroup()
		{
		}

		[Token(Token = "0x6000333")]
		[Address(RVA = "0x1829E58", Offset = "0x1829E58", Length = "0x20")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000334")]
		[Address(RVA = "0x1829E78", Offset = "0x1829E78", Length = "0xC")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000335")]
		[Address(RVA = "0x1829E84", Offset = "0x1829E84", Length = "0xC")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000336")]
		[Address(RVA = "0x1829E90", Offset = "0x1829E90", Length = "0xC")]
		public override void SetLayoutVertical()
		{
		}
	}
}
