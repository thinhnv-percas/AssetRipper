using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000014")]
public struct SetTextFromIntVariableComponent : IComponent
{
	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74AB0C", Offset = "0x74AB0C")]
	[TableList]
	[Token(Token = "0x4000050")]
	[FieldOffset(Offset = "0x0")]
	public List<SetTextSetup> SetText;
}
