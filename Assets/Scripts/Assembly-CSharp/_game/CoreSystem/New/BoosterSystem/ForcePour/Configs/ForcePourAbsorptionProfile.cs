using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.ForcePour.Configs
{
	[Serializable]
	[Token(Token = "0x2000498")]
	public struct ForcePourAbsorptionProfile
	{
		[Tooltip("Base attract speed before clamping to min/max.")]
		[Token(Token = "0x4000F27")]
		[FieldOffset(Offset = "0x0")]
		public float attractSpeed;

		[Tooltip("Minimum speed clamp for the bezier arc.")]
		[Token(Token = "0x4000F28")]
		[FieldOffset(Offset = "0x4")]
		public float minSpeed;

		[Tooltip("Maximum speed clamp for the bezier arc.")]
		[Token(Token = "0x4000F29")]
		[FieldOffset(Offset = "0x8")]
		public float maxSpeed;

		[Tooltip("Peak Z (depth) deviation of the arc above startZ/targetZ lerp.")]
		[Token(Token = "0x4000F2A")]
		[FieldOffset(Offset = "0xC")]
		public float zCurveHeight;

		[Tooltip("Skew of the Z curve sine — higher pushes the peak later.")]
		[Token(Token = "0x4000F2B")]
		[FieldOffset(Offset = "0x10")]
		public float zCurveSkew;

		[Tooltip("Anticipation strength on Y axis (0 = linear, 1.5 = moderate wind-up).")]
		[Token(Token = "0x4000F2C")]
		[FieldOffset(Offset = "0x14")]
		public float yAnticipation;

		[Tooltip("Random per-particle XY scatter around the mold pour point.")]
		[Token(Token = "0x4000F2D")]
		[FieldOffset(Offset = "0x18")]
		public float targetScatter;

		[Token(Token = "0x170001A6")]
		public static ForcePourAbsorptionProfile Default
		{
			[Token(Token = "0x6001322")]
			[Address(RVA = "0x3CE6A58", Offset = "0x3CE6A58", Length = "0x28")]
			get
			{
				//IL_0015: Expected F4, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9307EC0]");
				ForcePourAbsorptionProfile result = default(ForcePourAbsorptionProfile);
				result.attractSpeed = 0f;
				result.zCurveSkew = 2f;
				result.yAnticipation = 1.5f;
				result.targetScatter = 0.15f;
				return result;
			}
		}
	}
}
