using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.MoldSystem;

namespace _game.CoreSystem.New.MoldSystem
{
	[Serializable]
	[Token(Token = "0x20002A2")]
	public class MoldConfig
	{
		[Header("Absorption")]
		[Token(Token = "0x4000812")]
		[FieldOffset(Offset = "0x10")]
		public AbsorptionProfile normalProfile;

		[Token(Token = "0x4000813")]
		[FieldOffset(Offset = "0x2C")]
		public float absorptionRadiusX;

		[Token(Token = "0x4000814")]
		[FieldOffset(Offset = "0x30")]
		public float absorptionRadiusY;

		[Token(Token = "0x4000815")]
		[FieldOffset(Offset = "0x38")]
		public AnimationCurve attractEaseCurve;

		[Token(Token = "0x4000816")]
		[FieldOffset(Offset = "0x40")]
		public float absorbSpeedMultiplier;

		[Header("Fill Target")]
		[Token(Token = "0x4000817")]
		[FieldOffset(Offset = "0x44")]
		public float fillTargetBase;

		[Token(Token = "0x4000818")]
		[FieldOffset(Offset = "0x48")]
		public float fillTargetHeight;

		[Header("Grid Layout")]
		[Token(Token = "0x4000819")]
		[FieldOffset(Offset = "0x4C")]
		public Vector2 spacing;

		[Token(Token = "0x400081A")]
		[FieldOffset(Offset = "0x54")]
		public float frontRowGap;

		[Token(Token = "0x400081B")]
		[FieldOffset(Offset = "0x58")]
		public float cellWidth;

		[Token(Token = "0x400081C")]
		[FieldOffset(Offset = "0x5C")]
		public float cellHeight;

		[Token(Token = "0x170000E4")]
		public AbsorptionProfile NormalProfile
		{
			[Token(Token = "0x6000B8D")]
			[Address(RVA = "0x3EC7C14", Offset = "0x3EC7C14", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.attractSpeed = this.normalProfile;\n\treturnBuffer.zCurveHeight = this.normalProfile.zCurveHeight;\n\treturn returnBuffer;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldConfig::get_NormalProfile");
				return default;
			}
		}

		[Token(Token = "0x170000E5")]
		public float AbsorptionRadiusX
		{
			[Token(Token = "0x6000B8E")]
			[Address(RVA = "0x3EC7C28", Offset = "0x3EC7C28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.absorptionRadiusX;\n")]
			get
			{
				return absorptionRadiusX;
			}
		}

		[Token(Token = "0x170000E6")]
		public float AbsorptionRadiusY
		{
			[Token(Token = "0x6000B8F")]
			[Address(RVA = "0x3EC7C30", Offset = "0x3EC7C30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.absorptionRadiusY;\n")]
			get
			{
				return absorptionRadiusY;
			}
		}

		[Token(Token = "0x170000E7")]
		public AnimationCurve AttractEaseCurve
		{
			[Token(Token = "0x6000B90")]
			[Address(RVA = "0x3EC7C38", Offset = "0x3EC7C38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attractEaseCurve;\n")]
			get
			{
				return attractEaseCurve;
			}
		}

		[Token(Token = "0x170000E8")]
		public float AbsorbSpeedMultiplier
		{
			[Token(Token = "0x6000B91")]
			[Address(RVA = "0x3EC7C40", Offset = "0x3EC7C40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.absorbSpeedMultiplier;\n")]
			get
			{
				return absorbSpeedMultiplier;
			}
		}

		[Token(Token = "0x170000E9")]
		public float FillTargetBase
		{
			[Token(Token = "0x6000B92")]
			[Address(RVA = "0x3EC7C48", Offset = "0x3EC7C48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fillTargetBase;\n")]
			get
			{
				return fillTargetBase;
			}
		}

		[Token(Token = "0x170000EA")]
		public float FillTargetHeight
		{
			[Token(Token = "0x6000B93")]
			[Address(RVA = "0x3EC7C50", Offset = "0x3EC7C50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fillTargetHeight;\n")]
			get
			{
				return fillTargetHeight;
			}
		}

		[Token(Token = "0x6000B94")]
		[Address(RVA = "0x3EC7C58", Offset = "0x3EC7C58", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.absorptionRadiusX = 32.000007486343385d;\n\tv19 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 1f);\n\tthis.attractEaseCurve = v19;\n\tthis.absorbSpeedMultiplier = -1.3411048258027414E-08d;\n\tthis.fillTargetHeight = 0.45f;\n\tthis.frontRowGap = 0.012062499258900062d;\n\tthis.cellHeight = 0.46f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldConfig()
		{
			absorptionRadiusX = 0.4f;
			absorptionRadiusY = 3f;
			AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
			attractEaseCurve = animationCurve;
			absorbSpeedMultiplier = 1f;
			fillTargetBase = -0.2f;
			fillTargetHeight = 0.45f;
			frontRowGap = 0.3f;
			cellWidth = 1.068f;
			cellHeight = 0.46f;
		}
	}
}
