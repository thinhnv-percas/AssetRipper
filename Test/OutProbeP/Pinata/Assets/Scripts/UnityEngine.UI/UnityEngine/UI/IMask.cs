using System;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x7271DC", Offset = "0x7271DC")]
	[Obsolete]
	[Token(Token = "0x2000016")]
	public interface IMask
	{
		[Token(Token = "0x1700005A")]
		RectTransform rectTransform
		{
			[Token(Token = "0x600014A")]
			get;
		}

		[Token(Token = "0x6000149")]
		bool Enabled();
	}
}
