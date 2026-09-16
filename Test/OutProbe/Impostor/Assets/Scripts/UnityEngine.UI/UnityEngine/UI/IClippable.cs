using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000F")]
	public interface IClippable
	{
		[Token(Token = "0x17000013")]
		GameObject gameObject
		{
			[Token(Token = "0x6000053")]
			get;
		}

		[Token(Token = "0x17000014")]
		RectTransform rectTransform
		{
			[Token(Token = "0x6000055")]
			get;
		}

		[Token(Token = "0x6000054")]
		void RecalculateClipping();

		[Token(Token = "0x6000056")]
		void Cull(Rect clipRect, bool validRect);

		[Token(Token = "0x6000057")]
		void SetClipRect(Rect value, bool validRect);

		[Token(Token = "0x6000058")]
		void SetClipSoftness(Vector2 clipSoftness);
	}
}
