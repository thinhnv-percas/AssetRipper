using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000009")]
	public interface ICanvasElement
	{
		[Token(Token = "0x17000009")]
		Transform transform
		{
			[Token(Token = "0x600001D")]
			get;
		}

		[Token(Token = "0x600001C")]
		void Rebuild(CanvasUpdate executing);

		[Token(Token = "0x600001E")]
		void LayoutComplete();

		[Token(Token = "0x600001F")]
		void GraphicUpdateComplete();

		[Token(Token = "0x6000020")]
		bool IsDestroyed();
	}
}
