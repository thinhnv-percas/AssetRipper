using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[Token(Token = "0x2000029")]
	public class TMP_ColorGradient : ScriptableObject
	{
		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x18")]
		public ColorMode colorMode;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x1C")]
		public Color topLeft;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x2C")]
		public Color topRight;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x3C")]
		public Color bottomLeft;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x4C")]
		public Color bottomRight;

		[Token(Token = "0x4000156")]
		private const ColorMode k_DefaultColorMode = ColorMode.FourCornersGradient;

		[Token(Token = "0x4000157")]
		private static readonly Color k_DefaultColor;

		[Token(Token = "0x6000143")]
		[Address(RVA = "0x15D06D4", Offset = "0x15D06D4", Length = "0x9C")]
		public TMP_ColorGradient()
		{
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x15D0770", Offset = "0x15D0770", Length = "0x6C")]
		public TMP_ColorGradient(Color color)
		{
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x15D07DC", Offset = "0x15D07DC", Length = "0xA4")]
		public TMP_ColorGradient(Color color0, Color color1, Color color2, Color color3)
		{
		}
	}
}
