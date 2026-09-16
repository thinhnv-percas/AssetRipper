using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000048")]
	public interface ILayoutElement
	{
		[Token(Token = "0x170000B6")]
		float minWidth
		{
			[Token(Token = "0x60002B2")]
			get;
		}

		[Token(Token = "0x170000B7")]
		float preferredWidth
		{
			[Token(Token = "0x60002B3")]
			get;
		}

		[Token(Token = "0x170000B8")]
		float flexibleWidth
		{
			[Token(Token = "0x60002B4")]
			get;
		}

		[Token(Token = "0x170000B9")]
		float minHeight
		{
			[Token(Token = "0x60002B5")]
			get;
		}

		[Token(Token = "0x170000BA")]
		float preferredHeight
		{
			[Token(Token = "0x60002B6")]
			get;
		}

		[Token(Token = "0x170000BB")]
		float flexibleHeight
		{
			[Token(Token = "0x60002B7")]
			get;
		}

		[Token(Token = "0x170000BC")]
		int layoutPriority
		{
			[Token(Token = "0x60002B8")]
			get;
		}

		[Token(Token = "0x60002B0")]
		void CalculateLayoutInputHorizontal();

		[Token(Token = "0x60002B1")]
		void CalculateLayoutInputVertical();
	}
}
