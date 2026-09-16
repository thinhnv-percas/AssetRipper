using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000042")]
	public struct FontAssetCreationSettings
	{
		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x0")]
		public string sourceFontFileName;

		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x8")]
		public string sourceFontFileGUID;

		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x10")]
		public int pointSizeSamplingMode;

		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x14")]
		public int pointSize;

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x18")]
		public int padding;

		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x1C")]
		public int packingMode;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x20")]
		public int atlasWidth;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x24")]
		public int atlasHeight;

		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x28")]
		public int characterSetSelectionMode;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x30")]
		public string characterSequence;

		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x38")]
		public string referencedFontAssetGUID;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x40")]
		public string referencedTextAssetGUID;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x48")]
		public int fontStyle;

		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x4C")]
		public float fontStyleModifier;

		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x50")]
		public int renderMode;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x54")]
		public bool includeFontFeatures;

		[Token(Token = "0x600023B")]
		[Address(RVA = "0x15DE638", Offset = "0x15DE638", Length = "0xD4")]
		internal FontAssetCreationSettings(string sourceFontFileGUID, int pointSize, int pointSizeSamplingMode, int padding, int packingMode, int atlasWidth, int atlasHeight, int characterSelectionMode, string characterSet, int renderMode)
		{
			sourceFontFileName = null;
			this.sourceFontFileGUID = null;
			this.pointSizeSamplingMode = 0;
			this.pointSize = 0;
			this.padding = 0;
			this.packingMode = 0;
			this.atlasWidth = 0;
			this.atlasHeight = 0;
			characterSetSelectionMode = 0;
			characterSequence = null;
			referencedFontAssetGUID = null;
			referencedTextAssetGUID = null;
			fontStyle = 0;
			fontStyleModifier = 0f;
			this.renderMode = 0;
			includeFontFeatures = false;
		}
	}
}
