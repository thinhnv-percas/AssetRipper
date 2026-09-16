using System;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Variables;
using Morpeh.Globals;
using Sirenix.OdinInspector;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000030")]
	public struct WeaponSettings
	{
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x0")]
		public GlobalVariableInt CurrentWeapon;

		[AttributeAttribute(Type = typeof(InlineEditorAttribute), RVA = "0x74AF1C", Offset = "0x74AF1C")]
		[HideLabel]
		[Required]
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x8")]
		public WeaponsSetupVariable Data;
	}
}
