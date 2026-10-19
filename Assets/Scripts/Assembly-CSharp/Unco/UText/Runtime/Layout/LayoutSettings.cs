using System;
using Cpp2ILInjected;

namespace Unco.UText.Runtime.Layout
{
	[Serializable]
	[Token(Token = "0x20007B9")]
	public struct LayoutSettings : IEquatable<LayoutSettings>
	{
		[Token(Token = "0x40019C4")]
		[FieldOffset(Offset = "0x0")]
		public float FontSize;

		[Token(Token = "0x40019C5")]
		[FieldOffset(Offset = "0x4")]
		public bool Bold;

		[Token(Token = "0x40019C6")]
		[FieldOffset(Offset = "0x5")]
		public bool Italic;

		[Token(Token = "0x40019C7")]
		[FieldOffset(Offset = "0x8")]
		public float LineSpacing;

		[Token(Token = "0x40019C8")]
		[FieldOffset(Offset = "0xC")]
		public float LetterSpacing;

		[Token(Token = "0x40019C9")]
		[FieldOffset(Offset = "0x10")]
		public float WordSpacing;

		[Token(Token = "0x40019CA")]
		[FieldOffset(Offset = "0x14")]
		public HorizontalAlignment Horizontal;

		[Token(Token = "0x40019CB")]
		[FieldOffset(Offset = "0x18")]
		public VerticalAlignment Vertical;

		[Token(Token = "0x40019CC")]
		[FieldOffset(Offset = "0x1C")]
		public bool Wrap;

		[Token(Token = "0x40019CD")]
		[FieldOffset(Offset = "0x1D")]
		public bool AutoSize;

		[Token(Token = "0x40019CE")]
		[FieldOffset(Offset = "0x20")]
		public float MinFontSize;

		[Token(Token = "0x40019CF")]
		[FieldOffset(Offset = "0x24")]
		public float MaxFontSize;

		[Token(Token = "0x600207B")]
		[Address(RVA = "0x3D9FFB0", Offset = "0x3D9FFB0", Length = "0x20")]
		public LayoutSettings(float fontSize, float lineSpacing, float letterSpacing, float wordSpacing)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LayoutSettings::.ctor");
			this = default;
		}

		[Token(Token = "0x600207C")]
		[Address(RVA = "0x3D9FFD0", Offset = "0x3D9FFD0", Length = "0xDC")]
		public bool Equals(LayoutSettings other)
		{
			if (FontSize == other.FontSize && Bold == other.Bold && Italic == other.Italic && LineSpacing == other.LineSpacing && LetterSpacing == other.LetterSpacing && WordSpacing == other.WordSpacing && Horizontal == other.Horizontal && Vertical == other.Vertical && Wrap == other.Wrap && AutoSize == other.AutoSize && MinFontSize == other.MinFontSize)
			{
				return MaxFontSize == other.MaxFontSize;
			}
			return false;
		}
	}
}
