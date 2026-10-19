using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[Serializable]
	[Token(Token = "0x20007AC")]
	public struct UTextEffect : IEquatable<UTextEffect>
	{
		[Tooltip("Layer colour. Opaque for strokes; semi-transparent allowed for hard drop shadows.")]
		[Token(Token = "0x4001980")]
		[FieldOffset(Offset = "0x0")]
		public Color Color;

		[Tooltip("Offset in em units (fraction of glyph height). (0,0) places the silhouette directly under the glyph — typical for strokes.")]
		[Token(Token = "0x4001981")]
		[FieldOffset(Offset = "0x10")]
		public Vector2 Offset;

		[Range(-1f, 1f)]
		[Tooltip("Silhouette expansion, normalised against the atlas's Padding/SamplingPointSize cap. 0 = source contour; +1 = maximum outward growth (= Padding/SamplingPointSize em); -1 = silhouette shrunk to nothing. Bump Padding on the SDF font asset and re-bake to raise the outward ceiling.")]
		[Token(Token = "0x4001982")]
		[FieldOffset(Offset = "0x18")]
		public float Expand;

		[Token(Token = "0x17000327")]
		public bool Visible
		{
			[Token(Token = "0x6002056")]
			[Address(RVA = "0x3D9DF58", Offset = "0x3D9DF58", Length = "0x44")]
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
					if (Offset.x == 0f && Offset.y == 0f)
					{
						bool flag7 = Expand == 0f;
						return !flag7;
					}
					return true;
				}
				return false;
			}
		}

		[Token(Token = "0x6002057")]
		[Address(RVA = "0x3D9E9D0", Offset = "0x3D9E9D0", Length = "0x14")]
		public UTextEffect(Color color, Vector2 offset, float expand)
		{
			Color = color;
			_ = color.g;
			_ = color.b;
			_ = color.a;
			Offset = offset;
			_ = offset.y;
			Expand = expand;
		}

		[Token(Token = "0x6002058")]
		[Address(RVA = "0x3D9E9E4", Offset = "0x3D9E9E4", Length = "0x7C")]
		public bool Equals(UTextEffect other)
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
				if (num9 < 9.9999994E-11f)
				{
					return Expand == other.Expand;
				}
			}
			return false;
		}
	}
}
