using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x72749C", Offset = "0x72749C")]
	[Token(Token = "0x200001D")]
	public class HorizontalLayoutGroup : HorizontalOrVerticalLayoutGroup
	{
		[Token(Token = "0x6000236")]
		[Address(RVA = "0xF4B0B0", Offset = "0xF4B0B0", Length = "0xC")]
		protected HorizontalLayoutGroup()
		{
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xF4B0C8", Offset = "0xF4B0C8", Length = "0x2C")]
		public override void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000238")]
		[Address(RVA = "0xF4B390", Offset = "0xF4B390", Length = "0xC")]
		public override void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000239")]
		[Address(RVA = "0xF4B39C", Offset = "0xF4B39C", Length = "0xC")]
		public override void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x600023A")]
		[Address(RVA = "0xF4B9B0", Offset = "0xF4B9B0", Length = "0xC")]
		public override void SetLayoutVertical()
		{
		}
	}
}
