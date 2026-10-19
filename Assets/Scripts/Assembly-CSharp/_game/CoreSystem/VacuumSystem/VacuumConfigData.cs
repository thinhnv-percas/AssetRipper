using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.VacuumSystem
{
	[Serializable]
	[Token(Token = "0x2000132")]
	public class VacuumConfigData
	{
		[SerializeField]
		[Token(Token = "0x40003EF")]
		[FieldOffset(Offset = "0x10")]
		private int m_boosterCapacity;

		[SerializeField]
		[Token(Token = "0x40003F0")]
		[FieldOffset(Offset = "0x14")]
		private int m_keepPlayingCapacity;

		[Token(Token = "0x17000097")]
		public int BoosterCapacity
		{
			[Token(Token = "0x600061D")]
			[Address(RVA = "0x3DB2854", Offset = "0x3DB2854", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BoosterCapacity;\n")]
			get
			{
				return m_boosterCapacity;
			}
		}

		[Token(Token = "0x17000098")]
		public int KeepPlayingCapacity
		{
			[Token(Token = "0x600061E")]
			[Address(RVA = "0x3DB285C", Offset = "0x3DB285C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.KeepPlayingCapacity;\n")]
			get
			{
				return m_keepPlayingCapacity;
			}
		}

		[Token(Token = "0x600061F")]
		[Address(RVA = "0x3DB2864", Offset = "0x3DB2864", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public VacuumConfigData()
		{
		}
	}
}
