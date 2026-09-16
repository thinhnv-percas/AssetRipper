using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000032")]
	public class WeaponSetupClass
	{
		[AttributeAttribute(Type = typeof(TableColumnWidthAttribute), RVA = "0x74AF7C", Offset = "0x74AF7C")]
		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x10")]
		public int Id;

		[AssetsOnly]
		[AttributeAttribute(Type = typeof(TableColumnWidthAttribute), RVA = "0x74AFB4", Offset = "0x74AFB4")]
		[PreviewField]
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x18")]
		public Sprite Icon;

		[AssetsOnly]
		[AttributeAttribute(Type = typeof(TableColumnWidthAttribute), RVA = "0x74B024", Offset = "0x74B024")]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x20")]
		public GameObject WeaponPrefab;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x28")]
		public WeaponParametersComponent WeaponParametersComponent;

		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x3C")]
		public WeaponUpgradeParametersComponent WeaponUpgradeParametersComponent;

		[Token(Token = "0x600005F")]
		[Address(RVA = "0xCC84D4", Offset = "0xCC84D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WeaponSetupClass()
		{
		}
	}
}
