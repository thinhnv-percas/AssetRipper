using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000087")]
	public interface ITextElement
	{
		[Token(Token = "0x17000109")]
		Material sharedMaterial
		{
			[Token(Token = "0x60004A2")]
			get;
		}

		[Token(Token = "0x60004A3")]
		void Rebuild(CanvasUpdate update);

		[Token(Token = "0x60004A4")]
		int GetInstanceID();
	}
}
