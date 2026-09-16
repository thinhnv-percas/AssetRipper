using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Obsolete("Use BaseMeshEffect instead", true)]
	[Token(Token = "0x2000082")]
	public abstract class BaseVertexEffect
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use BaseMeshEffect.ModifyMeshes instead", true)]
		[Token(Token = "0x600052A")]
		public abstract void ModifyVertices(List<UIVertex> vertices);

		[Token(Token = "0x600052B")]
		[Address(RVA = "0x183DF34", Offset = "0x183DF34", Length = "0x8")]
		protected BaseVertexEffect()
		{
		}
	}
}
