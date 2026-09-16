using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro.SpriteAssetUtilities
{
	[Token(Token = "0x20000A8")]
	public class TexturePacker_JsonArray
	{
		[Serializable]
		[Token(Token = "0x20000A9")]
		public struct SpriteFrame
		{
			[Token(Token = "0x4000610")]
			[FieldOffset(Offset = "0x0")]
			public float x;

			[Token(Token = "0x4000611")]
			[FieldOffset(Offset = "0x4")]
			public float y;

			[Token(Token = "0x4000612")]
			[FieldOffset(Offset = "0x8")]
			public float w;

			[Token(Token = "0x4000613")]
			[FieldOffset(Offset = "0xC")]
			public float h;

			[Token(Token = "0x6000652")]
			[Address(RVA = "0x1615E4C", Offset = "0x1615E4C", Length = "0x188")]
			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		[Token(Token = "0x20000AA")]
		public struct SpriteSize
		{
			[Token(Token = "0x4000614")]
			[FieldOffset(Offset = "0x0")]
			public float w;

			[Token(Token = "0x4000615")]
			[FieldOffset(Offset = "0x4")]
			public float h;

			[Token(Token = "0x6000653")]
			[Address(RVA = "0x1615FD4", Offset = "0x1615FD4", Length = "0xAC")]
			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		[Token(Token = "0x20000AB")]
		public struct Frame
		{
			[Token(Token = "0x4000616")]
			[FieldOffset(Offset = "0x0")]
			public string filename;

			[Token(Token = "0x4000617")]
			[FieldOffset(Offset = "0x8")]
			public SpriteFrame frame;

			[Token(Token = "0x4000618")]
			[FieldOffset(Offset = "0x18")]
			public bool rotated;

			[Token(Token = "0x4000619")]
			[FieldOffset(Offset = "0x19")]
			public bool trimmed;

			[Token(Token = "0x400061A")]
			[FieldOffset(Offset = "0x1C")]
			public SpriteFrame spriteSourceSize;

			[Token(Token = "0x400061B")]
			[FieldOffset(Offset = "0x2C")]
			public SpriteSize sourceSize;

			[Token(Token = "0x400061C")]
			[FieldOffset(Offset = "0x34")]
			public Vector2 pivot;
		}

		[Serializable]
		[Token(Token = "0x20000AC")]
		public struct Meta
		{
			[Token(Token = "0x400061D")]
			[FieldOffset(Offset = "0x0")]
			public string app;

			[Token(Token = "0x400061E")]
			[FieldOffset(Offset = "0x8")]
			public string version;

			[Token(Token = "0x400061F")]
			[FieldOffset(Offset = "0x10")]
			public string image;

			[Token(Token = "0x4000620")]
			[FieldOffset(Offset = "0x18")]
			public string format;

			[Token(Token = "0x4000621")]
			[FieldOffset(Offset = "0x20")]
			public SpriteSize size;

			[Token(Token = "0x4000622")]
			[FieldOffset(Offset = "0x28")]
			public float scale;

			[Token(Token = "0x4000623")]
			[FieldOffset(Offset = "0x30")]
			public string smartupdate;
		}

		[Serializable]
		[Token(Token = "0x20000AD")]
		public class SpriteDataObject
		{
			[Token(Token = "0x4000624")]
			[FieldOffset(Offset = "0x10")]
			public List<Frame> frames;

			[Token(Token = "0x4000625")]
			[FieldOffset(Offset = "0x18")]
			public Meta meta;

			[Token(Token = "0x6000654")]
			[Address(RVA = "0x1616080", Offset = "0x1616080", Length = "0x8")]
			public SpriteDataObject()
			{
			}
		}

		[Token(Token = "0x6000651")]
		[Address(RVA = "0x1615E44", Offset = "0x1615E44", Length = "0x8")]
		public TexturePacker_JsonArray()
		{
		}
	}
}
