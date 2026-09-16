using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000040")]
	public class FaceInfo_Legacy
	{
		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x18")]
		public float PointSize;

		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x1C")]
		public float Scale;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x20")]
		public int CharacterCount;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x24")]
		public float LineHeight;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x28")]
		public float Baseline;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x2C")]
		public float Ascender;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x30")]
		public float CapHeight;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x34")]
		public float Descender;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x38")]
		public float CenterLine;

		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x3C")]
		public float SuperscriptOffset;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x40")]
		public float SubscriptOffset;

		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x44")]
		public float SubSize;

		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x48")]
		public float Underline;

		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x4C")]
		public float UnderlineThickness;

		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x50")]
		public float strikethrough;

		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x54")]
		public float strikethroughThickness;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x58")]
		public float TabWidth;

		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x5C")]
		public float Padding;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x60")]
		public float AtlasWidth;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x64")]
		public float AtlasHeight;

		[Token(Token = "0x6000238")]
		[Address(RVA = "0x15DE5AC", Offset = "0x15DE5AC", Length = "0x8")]
		public FaceInfo_Legacy()
		{
		}
	}
}
