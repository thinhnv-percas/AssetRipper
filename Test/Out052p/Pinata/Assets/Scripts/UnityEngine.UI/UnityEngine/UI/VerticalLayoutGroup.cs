using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727608", Offset = "0x727608")]
	[Token(Token = "0x2000028")]
	public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
	{
		[Token(Token = "0x60002B6")]
		[Address(RVA = "0x1681088", Offset = "0x1681088", Length = "0x8")]
		protected VerticalLayoutGroup()
		{
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0x1681090", Offset = "0x1681090", Length = "0x34")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0x16810C4", Offset = "0x16810C4", Length = "0x10")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0x16810D4", Offset = "0x16810D4", Length = "0x10")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x16810E4", Offset = "0x16810E4", Length = "0x10")]
		public override void SetLayoutVertical()
		{
		}
	}
}
