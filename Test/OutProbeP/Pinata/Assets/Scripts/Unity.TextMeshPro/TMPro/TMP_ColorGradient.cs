using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000011")]
	public class TMP_ColorGradient : ScriptableObject
	{
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x18")]
		public ColorMode colorMode;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x1C")]
		public Color topLeft;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x2C")]
		public Color topRight;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x3C")]
		public Color bottomLeft;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x4C")]
		public Color bottomRight;

		[Token(Token = "0x4000087")]
		private const ColorMode k_DefaultColorMode = ColorMode.FourCornersGradient;

		[Token(Token = "0x4000088")]
		private static readonly Color k_DefaultColor;

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x91C2CC", Offset = "0x91C2CC", Length = "0xEC")]
		public TMP_ColorGradient()
		{
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x91C3B8", Offset = "0x91C3B8", Length = "0x70")]
		public TMP_ColorGradient(Color color)
		{
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x91C428", Offset = "0x91C428", Length = "0xF0")]
		public TMP_ColorGradient(Color color0, Color color1, Color color2, Color color3)
		{
		}
	}
}
