using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.MenuLayer
{
	[AttributeUsage(AttributeTargets.Field)]
	[Token(Token = "0x20005E1")]
	public class TypeSelectorAttribute : PropertyAttribute
	{
		[Token(Token = "0x17000262")]
		[field: Token(Token = "0x4001450")]
		[field: FieldOffset(Offset = "0x18")]
		public Type BaseType
		{
			[Token(Token = "0x600193E")]
			[Address(RVA = "0x3D46630", Offset = "0x3D46630", Length = "0x8")]
			get;
		}

		[Token(Token = "0x600193F")]
		[Address(RVA = "0x3D46638", Offset = "0x3D46638", Length = "0x34")]
		public TypeSelectorAttribute(Type baseType)
		{
			BaseType = baseType;
		}
	}
}
