using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000085")]
	public interface IMeshModifier
	{
		[Obsolete("use IMeshModifier.ModifyMesh (VertexHelper verts) instead", false)]
		[Token(Token = "0x6000534")]
		void ModifyMesh(Mesh mesh);

		[Token(Token = "0x6000535")]
		void ModifyMesh(VertexHelper verts);
	}
}
