using System;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000012")]
public struct CreateWeaponButtonComponent : IComponent
{
	[Token(Token = "0x400004C")]
	[FieldOffset(Offset = "0x0")]
	public Transform WeaponButtonParent;

	[Token(Token = "0x400004D")]
	[FieldOffset(Offset = "0x8")]
	public GameObject WeaponButtonPrefab;
}
