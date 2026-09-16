using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000046")]
	public interface ITextElement
	{
		[Token(Token = "0x170000DD")]
		Material sharedMaterial
		{
			[Token(Token = "0x60003B3")]
			get;
		}

		[Token(Token = "0x60003B4")]
		void Rebuild(CanvasUpdate update);

		[Token(Token = "0x60003B5")]
		int GetInstanceID();
	}
}
