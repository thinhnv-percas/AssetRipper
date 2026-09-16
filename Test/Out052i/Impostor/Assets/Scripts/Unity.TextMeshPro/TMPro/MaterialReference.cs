using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200000B")]
	public struct MaterialReference
	{
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x8")]
		public TMP_FontAsset fontAsset;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		public TMP_SpriteAsset spriteAsset;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x18")]
		public Material material;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x20")]
		public bool isDefaultMaterial;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x21")]
		public bool isFallbackMaterial;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x28")]
		public Material fallbackMaterial;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x30")]
		public float padding;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x34")]
		public int referenceCount;

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15BFAC0", Offset = "0x15BFAC0", Length = "0x7C")]
		public MaterialReference(int index, TMP_FontAsset fontAsset, TMP_SpriteAsset spriteAsset, Material material, float padding)
		{
			this.index = 0;
			this.fontAsset = null;
			this.spriteAsset = null;
			this.material = null;
			isDefaultMaterial = false;
			isFallbackMaterial = false;
			fallbackMaterial = null;
			this.padding = 0f;
			referenceCount = 0;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15BFB3C", Offset = "0x15BFB3C", Length = "0xFC")]
		public static bool Contains(MaterialReference[] materialReferences, TMP_FontAsset fontAsset)
		{
			return false;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15BFC38", Offset = "0x15BFC38", Length = "0x20C")]
		public static int AddMaterialReference(Material material, TMP_FontAsset fontAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			return 0;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15BFE44", Offset = "0x15BFE44", Length = "0x1D8")]
		public static int AddMaterialReference(Material material, TMP_SpriteAsset spriteAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			return 0;
		}
	}
}
