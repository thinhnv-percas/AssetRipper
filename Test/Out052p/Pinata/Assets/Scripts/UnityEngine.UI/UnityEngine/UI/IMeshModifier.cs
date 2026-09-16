using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000042")]
	public interface IMeshModifier
	{
		[Obsolete]
		[Token(Token = "0x6000489")]
		void ModifyMesh(Mesh mesh);

		[Token(Token = "0x600048A")]
		void ModifyMesh(VertexHelper verts);
	}
}
