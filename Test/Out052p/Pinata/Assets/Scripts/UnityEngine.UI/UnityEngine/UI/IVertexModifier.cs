using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x727BA0", Offset = "0x727BA0")]
	[Obsolete]
	[Token(Token = "0x2000041")]
	public interface IVertexModifier
	{
		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72A414", Offset = "0x72A414")]
		[Obsolete]
		[Token(Token = "0x6000488")]
		void ModifyVertices(List<UIVertex> verts);
	}
}
