using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[CreateAssetMenu(fileName = "SandSDFConfig", menuName = "Game/Sand SDF Config")]
	[Token(Token = "0x200010D")]
	public class SandSDFConfig : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000380")]
		[FieldOffset(Offset = "0x18")]
		private float m_cellSize;

		[SerializeField]
		[Token(Token = "0x4000381")]
		[FieldOffset(Offset = "0x1C")]
		private float m_aabbPadding;

		[SerializeField]
		[Token(Token = "0x4000382")]
		[FieldOffset(Offset = "0x20")]
		private bool m_verboseBakeLogging;

		[Token(Token = "0x17000083")]
		public float CellSize
		{
			[Token(Token = "0x60005B6")]
			[Address(RVA = "0x3DAE1B0", Offset = "0x3DAE1B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CellSize;\n")]
			get
			{
				return m_cellSize;
			}
		}

		[Token(Token = "0x17000084")]
		public float AabbPadding
		{
			[Token(Token = "0x60005B7")]
			[Address(RVA = "0x3DAE1B8", Offset = "0x3DAE1B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.AabbPadding;\n")]
			get
			{
				return m_aabbPadding;
			}
		}

		[Token(Token = "0x17000085")]
		public bool VerboseBakeLogging
		{
			[Token(Token = "0x60005B8")]
			[Address(RVA = "0x3DAE1C0", Offset = "0x3DAE1C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VerboseBakeLogging;\n")]
			get
			{
				return m_verboseBakeLogging;
			}
		}

		[Token(Token = "0x60005B9")]
		[Address(RVA = "0x3DAE1C8", Offset = "0x3DAE1C8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CellSize = 3.0517585132656676E-05d;\n\tthis.VerboseBakeLogging = 1;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public SandSDFConfig()
		{
			m_cellSize = 0.08f;
			m_aabbPadding = 0.5f;
			m_verboseBakeLogging = true;
		}
	}
}
