using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.VacuumSystem
{
	[Serializable]
	[Token(Token = "0x2000130")]
	public struct VacuumExecuteConfig
	{
		[SerializeField]
		[Token(Token = "0x40003ED")]
		[FieldOffset(Offset = "0x0")]
		private int m_cubeCapacity;

		[SerializeField]
		[Token(Token = "0x40003EE")]
		[FieldOffset(Offset = "0x8")]
		private Material m_visualMaterial;

		[Token(Token = "0x17000095")]
		public int CubeCapacity
		{
			[Token(Token = "0x6000619")]
			[Address(RVA = "0x3DB27E4", Offset = "0x3DB27E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CubeCapacity;\n")]
			get
			{
				return m_cubeCapacity;
			}
			[Token(Token = "0x600061A")]
			[Address(RVA = "0x3DB27EC", Offset = "0x3DB27EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CubeCapacity = value;\n\treturn;\n")]
			set
			{
				m_cubeCapacity = value;
			}
		}

		[Token(Token = "0x17000096")]
		public Material VisualMaterial
		{
			[Token(Token = "0x600061B")]
			[Address(RVA = "0x3DB27F4", Offset = "0x3DB27F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VisualMaterial;\n")]
			get
			{
				return m_visualMaterial;
			}
		}
	}
}
