using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Obsolete]
	[Token(Token = "0x200003F")]
	public abstract class BaseVertexEffect
	{
		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72A3C0", Offset = "0x72A3C0")]
		[Obsolete]
		[Token(Token = "0x600047F")]
		public abstract void ModifyVertices(List<UIVertex> vertices);

		[Token(Token = "0x6000480")]
		[Address(RVA = "0xC4CA7C", Offset = "0xC4CA7C", Length = "0x8")]
		protected BaseVertexEffect()
		{
		}
	}
}
