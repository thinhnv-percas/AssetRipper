using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000010")]
public struct ActivateGameObjectFromListComponent : IComponent
{
	[Token(Token = "0x4000046")]
	[FieldOffset(Offset = "0x0")]
	public List<GameObject> GameObjects;
}
