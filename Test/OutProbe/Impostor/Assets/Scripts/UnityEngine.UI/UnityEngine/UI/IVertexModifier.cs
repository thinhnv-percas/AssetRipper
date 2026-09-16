using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Obsolete("Use IMeshModifier instead", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Token(Token = "0x2000084")]
	public interface IVertexModifier
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("use IMeshModifier.ModifyMesh (VertexHelper verts)  instead", true)]
		[Token(Token = "0x6000533")]
		void ModifyVertices(List<UIVertex> verts);
	}
}
