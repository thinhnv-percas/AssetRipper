using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools.Tutorials
{
	[Token(Token = "0x2000052")]
	public class SpawnEnemyExample : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000053")]
		public class Bonus
		{
			[Token(Token = "0x4000109")]
			[FieldOffset(Offset = "0x10")]
			public int typeId;

			[Token(Token = "0x400010A")]
			[FieldOffset(Offset = "0x14")]
			public int number;

			[Token(Token = "0x400010B")]
			[FieldOffset(Offset = "0x18")]
			public int interval;

			[Token(Token = "0x400010C")]
			[FieldOffset(Offset = "0x1C")]
			public int bonusHp;

			[Token(Token = "0x400010D")]
			[FieldOffset(Offset = "0x20")]
			public int bonusMoveSpeed;

			[Token(Token = "0x400010E")]
			[FieldOffset(Offset = "0x24")]
			public int bonusAtk;

			[Token(Token = "0x60001A7")]
			[Address(RVA = "0xC05800", Offset = "0xC05800", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Bonus()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000054")]
		public class SpawnEnemy
		{
			[Token(Token = "0x400010F")]
			[FieldOffset(Offset = "0x10")]
			public int timeStart;

			[Token(Token = "0x4000110")]
			[FieldOffset(Offset = "0x14")]
			public int timeEnd;

			[Token(Token = "0x4000111")]
			[FieldOffset(Offset = "0x18")]
			public int[] zoneId;

			[Token(Token = "0x4000112")]
			[FieldOffset(Offset = "0x20")]
			public Bonus[] bonuses;

			[Token(Token = "0x60001A8")]
			[Address(RVA = "0xC05808", Offset = "0xC05808", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SpawnEnemy()
			{
			}
		}

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x18")]
		public SpawnEnemy[] spawnEnemies;

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xC057F8", Offset = "0xC057F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpawnEnemyExample()
		{
		}
	}
}
