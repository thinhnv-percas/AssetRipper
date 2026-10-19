using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.VacuumSystem
{
	[Serializable]
	[Token(Token = "0x2000133")]
	public struct VacuumScoringWeights
	{
		[SerializeField]
		[Token(Token = "0x40003F1")]
		[FieldOffset(Offset = "0x0")]
		internal float m_wFront;

		[SerializeField]
		[Token(Token = "0x40003F2")]
		[FieldOffset(Offset = "0x4")]
		private float m_wConveyor;

		[SerializeField]
		[Token(Token = "0x40003F3")]
		[FieldOffset(Offset = "0x8")]
		private float m_wProximity;

		[SerializeField]
		[Token(Token = "0x40003F4")]
		[FieldOffset(Offset = "0xC")]
		private float m_wEmpty;

		[Tooltip("Centroid distance (world units) that maps proximity to 0. <= 0 -> auto from the farthest grain.")]
		[SerializeField]
		[Token(Token = "0x40003F5")]
		[FieldOffset(Offset = "0x10")]
		internal float m_proximityMaxReach;

		[Token(Token = "0x17000099")]
		public float WFront
		{
			[Token(Token = "0x6000620")]
			[Address(RVA = "0x3DB286C", Offset = "0x3DB286C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WFront;\n")]
			get
			{
				return m_wFront;
			}
		}

		[Token(Token = "0x1700009A")]
		public float WConveyor
		{
			[Token(Token = "0x6000621")]
			[Address(RVA = "0x3DB2874", Offset = "0x3DB2874", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WConveyor;\n")]
			get
			{
				return m_wConveyor;
			}
		}

		[Token(Token = "0x1700009B")]
		public float WProximity
		{
			[Token(Token = "0x6000622")]
			[Address(RVA = "0x3DB287C", Offset = "0x3DB287C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WProximity;\n")]
			get
			{
				return m_wProximity;
			}
		}

		[Token(Token = "0x1700009C")]
		public float WEmpty
		{
			[Token(Token = "0x6000623")]
			[Address(RVA = "0x3DB2884", Offset = "0x3DB2884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WEmpty;\n")]
			get
			{
				return m_wEmpty;
			}
		}

		[Token(Token = "0x1700009D")]
		public float ProximityMaxReach
		{
			[Token(Token = "0x6000624")]
			[Address(RVA = "0x3DB288C", Offset = "0x3DB288C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ProximityMaxReach;\n")]
			get
			{
				return m_proximityMaxReach;
			}
		}

		[Token(Token = "0x1700009E")]
		public static VacuumScoringWeights Default
		{
			[Token(Token = "0x6000625")]
			[Address(RVA = "0x3DB2894", Offset = "0x3DB2894", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.WFront = *([9308160]);\n\treturnBuffer.ProximityMaxReach = 0f;\n\treturn returnBuffer;\n")]
			get
			{
				//IL_0015: Expected F4, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9308160]");
				VacuumScoringWeights result = default(VacuumScoringWeights);
				result.m_wFront = 0f;
				result.m_proximityMaxReach = 0f;
				return result;
			}
		}

		[Token(Token = "0x1700009F")]
		public bool IsUnset
		{
			[Token(Token = "0x6000626")]
			[Address(RVA = "0x3DB28A8", Offset = "0x3DB28A8", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.WFront == 0;\n\tv8 = ~v3;\n\tif (v8) goto L_0025;\n\tv11 = this.WConveyor == 0;\n\tv16 = ~v11;\n\tif (v16) goto L_0025;\n\tv26 = this.WProximity == 0;\n\tv18 = ~v26;\n\tif (v18) goto L_0025;\n\tv43 = this.WEmpty == 0;\n\treturn v43;\nL_0025:\n\treturn 0;\n")]
			get
			{
				if (WFront == 0f && WConveyor == 0f && WProximity == 0f)
				{
					return WEmpty == 0f;
				}
				return false;
			}
		}
	}
}
