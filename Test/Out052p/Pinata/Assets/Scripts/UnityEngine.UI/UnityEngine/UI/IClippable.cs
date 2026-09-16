using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000B")]
	public interface IClippable
	{
		[Token(Token = "0x17000012")]
		GameObject gameObject
		{
			[Token(Token = "0x6000046")]
			get;
		}

		[Token(Token = "0x17000013")]
		RectTransform rectTransform
		{
			[Token(Token = "0x6000048")]
			get;
		}

		[Token(Token = "0x6000047")]
		void RecalculateClipping();

		[Token(Token = "0x6000049")]
		void Cull(Rect clipRect, bool validRect);

		[Token(Token = "0x600004A")]
		void SetClipRect(Rect value, bool validRect);
	}
}
