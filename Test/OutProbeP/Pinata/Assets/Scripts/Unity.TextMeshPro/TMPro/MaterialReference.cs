using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000007")]
	public struct MaterialReference
	{
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x8")]
		public TMP_FontAsset fontAsset;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x10")]
		public TMP_SpriteAsset spriteAsset;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x18")]
		public Material material;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x20")]
		public bool isDefaultMaterial;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x21")]
		public bool isFallbackMaterial;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x28")]
		public Material fallbackMaterial;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x30")]
		public float padding;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x34")]
		public int referenceCount;

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x8465C8", Offset = "0x8465C8", Length = "0x8")]
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

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x91888C", Offset = "0x91888C", Length = "0x128")]
		public static bool Contains(MaterialReference[] materialReferences, TMP_FontAsset fontAsset)
		{
			return false;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x9189B4", Offset = "0x9189B4", Length = "0x1BC")]
		public static int AddMaterialReference(Material material, TMP_FontAsset fontAsset, MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			return 0;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x918B70", Offset = "0x918B70", Length = "0x198")]
		public static int AddMaterialReference(Material material, TMP_SpriteAsset spriteAsset, MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			return 0;
		}
	}
}
