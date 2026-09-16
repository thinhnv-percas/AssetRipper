using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200001F")]
	public interface ILayoutElement
	{
		[Token(Token = "0x170000A4")]
		float minWidth
		{
			[Token(Token = "0x600024F")]
			get;
		}

		[Token(Token = "0x170000A5")]
		float preferredWidth
		{
			[Token(Token = "0x6000250")]
			get;
		}

		[Token(Token = "0x170000A6")]
		float flexibleWidth
		{
			[Token(Token = "0x6000251")]
			get;
		}

		[Token(Token = "0x170000A7")]
		float minHeight
		{
			[Token(Token = "0x6000252")]
			get;
		}

		[Token(Token = "0x170000A8")]
		float preferredHeight
		{
			[Token(Token = "0x6000253")]
			get;
		}

		[Token(Token = "0x170000A9")]
		float flexibleHeight
		{
			[Token(Token = "0x6000254")]
			get;
		}

		[Token(Token = "0x170000AA")]
		int layoutPriority
		{
			[Token(Token = "0x6000255")]
			get;
		}

		[Token(Token = "0x600024D")]
		void CalculateLayoutInputHorizontal();

		[Token(Token = "0x600024E")]
		void CalculateLayoutInputVertical();
	}
}
