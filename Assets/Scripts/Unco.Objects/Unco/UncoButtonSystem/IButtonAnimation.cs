using System;
using Cpp2ILInjected;

namespace Unco.UncoButtonSystem
{
	[Token(Token = "0x2000009")]
	public interface IButtonAnimation : IDisposable
	{
		[Token(Token = "0x6000012")]
		void OnMouseDown();

		[Token(Token = "0x6000013")]
		void OnMouseUp();
	}
}
