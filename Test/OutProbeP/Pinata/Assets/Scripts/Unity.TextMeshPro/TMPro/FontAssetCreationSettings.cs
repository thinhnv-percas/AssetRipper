using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 88)]
	[Token(Token = "0x200001C")]
	public struct FontAssetCreationSettings
	{
		[Token(Token = "0x40000EE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string sourceFontFileName;

		[Token(Token = "0x40000EF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public string sourceFontFileGUID;

		[Token(Token = "0x40000F0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public int pointSizeSamplingMode;

		[Token(Token = "0x40000F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public int pointSize;

		[Token(Token = "0x40000F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public int padding;

		[Token(Token = "0x40000F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public int packingMode;

		[Token(Token = "0x40000F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public int atlasWidth;

		[Token(Token = "0x40000F5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public int atlasHeight;

		[Token(Token = "0x40000F6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public int characterSetSelectionMode;

		[Token(Token = "0x40000F7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public string characterSequence;

		[Token(Token = "0x40000F8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public string referencedFontAssetGUID;

		[Token(Token = "0x40000F9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public string referencedTextAssetGUID;

		[Token(Token = "0x40000FA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public int fontStyle;

		[Token(Token = "0x40000FB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
		public float fontStyleModifier;

		[Token(Token = "0x40000FC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public int renderMode;

		[Token(Token = "0x40000FD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
		public bool includeFontFeatures;

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x846508", Offset = "0x846508", Length = "0x20")]
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
