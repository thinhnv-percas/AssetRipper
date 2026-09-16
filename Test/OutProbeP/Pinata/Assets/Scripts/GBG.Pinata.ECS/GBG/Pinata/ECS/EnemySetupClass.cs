using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000033")]
	public class EnemySetupClass
	{
		[AttributeAttribute(Type = typeof(TableColumnWidthAttribute), RVA = "0x74B070", Offset = "0x74B070")]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x10")]
		public int Id;

		[AttributeAttribute(Type = typeof(VerticalGroupAttribute), RVA = "0x74B0A8", Offset = "0x74B0A8")]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x14")]
		public int Health;

		[AttributeAttribute(Type = typeof(VerticalGroupAttribute), RVA = "0x74B0E4", Offset = "0x74B0E4")]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x18")]
		public int BaseReward;

		[AttributeAttribute(Type = typeof(TableColumnWidthAttribute), RVA = "0x74B120", Offset = "0x74B120")]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x20")]
		public GameObject EnemyPrefab;

		[Token(Token = "0x6000060")]
		[Address(RVA = "0xCBEF90", Offset = "0xCBEF90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnemySetupClass()
		{
		}
	}
}
