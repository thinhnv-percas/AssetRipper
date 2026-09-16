using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000005")]
	public interface ICanvasElement
	{
		[Token(Token = "0x17000007")]
		Transform transform
		{
			[Token(Token = "0x6000014")]
			get;
		}

		[Token(Token = "0x6000013")]
		void Rebuild(CanvasUpdate executing);

		[Token(Token = "0x6000015")]
		void LayoutComplete();

		[Token(Token = "0x6000016")]
		void GraphicUpdateComplete();

		[Token(Token = "0x6000017")]
		bool IsDestroyed();
	}
}
