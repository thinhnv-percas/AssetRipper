using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro.SpriteAssetUtilities
{
	[Token(Token = "0x200006E")]
	public class TexturePacker
	{
		[Serializable]
		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x200009B")]
		public struct SpriteFrame
		{
			[Token(Token = "0x4000503")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float x;

			[Token(Token = "0x4000504")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float y;

			[Token(Token = "0x4000505")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float w;

			[Token(Token = "0x4000506")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public float h;

			[Token(Token = "0x60005AA")]
			[Address(RVA = "0x8466F4", Offset = "0x8466F4", Length = "0x8")]
			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 8)]
		[Token(Token = "0x200009C")]
		public struct SpriteSize
		{
			[Token(Token = "0x4000507")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float w;

			[Token(Token = "0x4000508")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float h;

			[Token(Token = "0x60005AB")]
			[Address(RVA = "0x8466FC", Offset = "0x8466FC", Length = "0x90")]
			public override string ToString()
			{
				return null;
			}
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 64)]
		[Token(Token = "0x200009D")]
		public struct SpriteData
		{
			[Token(Token = "0x4000509")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string filename;

			[Token(Token = "0x400050A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public SpriteFrame frame;

			[Token(Token = "0x400050B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public bool rotated;

			[Token(Token = "0x400050C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x19")]
			public bool trimmed;

			[Token(Token = "0x400050D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
			public SpriteFrame spriteSourceSize;

			[Token(Token = "0x400050E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public SpriteSize sourceSize;

			[Token(Token = "0x400050F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
			public Vector2 pivot;
		}

		[Serializable]
		[Token(Token = "0x200009E")]
		public class SpriteDataObject
		{
			[Token(Token = "0x4000510")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public List<SpriteData> frames;

			[Token(Token = "0x60005AC")]
			[Address(RVA = "0x91BEF0", Offset = "0x91BEF0", Length = "0x2F0")]
			public SpriteDataObject()
			{
			}
		}

		[Token(Token = "0x6000542")]
		[Address(RVA = "0x91BEE8", Offset = "0x91BEE8", Length = "0x8")]
		public TexturePacker()
		{
		}
	}
}
