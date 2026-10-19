using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[Serializable]
	[Token(Token = "0x20007A7")]
	public struct BlurredShadow : IEquatable<BlurredShadow>
	{
		[Tooltip("Shadow tint. Alpha controls overall opacity.")]
		[SerializeField]
		[Token(Token = "0x4001963")]
		[FieldOffset(Offset = "0x0")]
		private bool m_enabled;

		[Tooltip("Shadow tint. Alpha controls overall opacity.")]
		[Token(Token = "0x4001964")]
		[FieldOffset(Offset = "0x4")]
		public Color Color;

		[Tooltip("Shadow offset in em units (fraction of font size). Positive Y is up.")]
		[Token(Token = "0x4001965")]
		[FieldOffset(Offset = "0x14")]
		public Vector2 Offset;

		[Range(-1f, 1f)]
		[Tooltip("Silhouette expansion (Figma 'spread'), normalised the same way as UTextEffect.Expand. 0 = source contour; +1 = max outward (Padding/SamplingPointSize em); -1 = shrunk to nothing.")]
		[Token(Token = "0x4001966")]
		[FieldOffset(Offset = "0x1C")]
		public float Spread;

		[Range(0f, 1f)]
		[Tooltip("Blur falloff width applied outside the (post-spread) silhouette, normalised against atlas padding. 0 = no blur (prefer authoring as a UTextEffect drop-shadow); 1 = max soft (= Padding/SamplingPointSize em).")]
		[Token(Token = "0x4001967")]
		[FieldOffset(Offset = "0x20")]
		public float BlurRadius;

		[Token(Token = "0x17000325")]
		public bool Enabled
		{
			[Token(Token = "0x6002047")]
			[Address(RVA = "0x3D97C18", Offset = "0x3D97C18", Length = "0x30")]
			get
			{
				if (m_enabled)
				{
					bool flag = Color.a < 0f;
					bool flag2 = Color.a == 0f;
					bool flag3 = Color.a == Color.a;
					bool flag4 = !flag3;
					bool flag5 = flag == flag4;
					bool flag6 = !flag5;
					if (!(flag6 || flag2))
					{
						bool flag7 = BlurRadius < 0f;
						bool flag8 = BlurRadius == 0f;
						bool flag9 = BlurRadius == BlurRadius;
						bool flag10 = !flag9;
						bool flag11 = flag7 == flag10;
						bool flag12 = !flag8;
						return flag11 && flag12;
					}
				}
				return false;
			}
		}

		[Token(Token = "0x17000326")]
		public bool HasValues
		{
			[Token(Token = "0x6002048")]
			[Address(RVA = "0x3D97C48", Offset = "0x3D97C48", Length = "0x24")]
			get
			{
				bool flag = Color.a < 0f;
				bool flag2 = Color.a == 0f;
				bool flag3 = Color.a == Color.a;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag5;
				if (!(flag6 || flag2))
				{
					bool flag7 = BlurRadius < 0f;
					bool flag8 = BlurRadius == 0f;
					bool flag9 = BlurRadius == BlurRadius;
					bool flag10 = !flag9;
					bool flag11 = flag7 == flag10;
					bool flag12 = !flag8;
					return flag11 && flag12;
				}
				return false;
			}
		}

		[Token(Token = "0x6002049")]
		[Address(RVA = "0x3D97C6C", Offset = "0x3D97C6C", Length = "0x1C")]
		public BlurredShadow(Color color, Vector2 offset, float spread, float blurRadius)
		{
			m_enabled = true;
			Color = color;
			_ = color.g;
			_ = color.b;
			_ = color.a;
			Offset = offset;
			_ = offset.y;
			Spread = spread;
			BlurRadius = blurRadius;
		}

		[Token(Token = "0x600204A")]
		[Address(RVA = "0x3D97C88", Offset = "0x3D97C88", Length = "0x94")]
		public bool Equals(BlurredShadow other)
		{
			float num = Color.r - other.Color.r;
			float num2 = num * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			float num3 = num2 + other.Color.r;
			float num4 = Color.b - other.Color.b;
			float num5 = num4 * num4;
			float num6 = num5 + num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			float num7 = num5 + num6;
			if (num7 < 9.9999994E-11f)
			{
				float num8 = Offset.x - other.Offset.x;
				float num9 = num8 * num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
				if (num9 < 9.9999994E-11f && BlurRadius == other.BlurRadius)
				{
					return Spread == other.Spread;
				}
			}
			return false;
		}
	}
}
