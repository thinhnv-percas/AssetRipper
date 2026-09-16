using System;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Obsolete("Not supported anymore.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Token(Token = "0x200002C")]
	public interface IMask
	{
		[Token(Token = "0x17000066")]
		RectTransform rectTransform
		{
			[Token(Token = "0x6000189")]
			get;
		}

		[Token(Token = "0x6000188")]
		bool Enabled();
	}
}
