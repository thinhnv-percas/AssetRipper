using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("Layout/Horizontal Layout Group", 150)]
	[Token(Token = "0x2000046")]
	public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
	{
		[Token(Token = "0x6000297")]
		[Address(RVA = "0x1825958", Offset = "0x1825958", Length = "0xC")]
		protected HorizontalLayoutGroup()
		{
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x1825970", Offset = "0x1825970", Length = "0x20")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x1825C30", Offset = "0x1825C30", Length = "0xC")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0x1825C3C", Offset = "0x1825C3C", Length = "0xC")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0x1826298", Offset = "0x1826298", Length = "0xC")]
		public override void SetLayoutVertical()
		{
		}
	}
}
