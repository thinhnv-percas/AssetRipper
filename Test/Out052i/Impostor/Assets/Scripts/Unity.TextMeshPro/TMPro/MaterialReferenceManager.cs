using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000009")]
	public class MaterialReferenceManager
	{
		[Token(Token = "0x400000E")]
		private static MaterialReferenceManager s_Instance;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<int, Material> m_FontMaterialReferenceLookup;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<int, TMP_FontAsset> m_FontAssetReferenceLookup;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<int, TMP_SpriteAsset> m_SpriteAssetReferenceLookup;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<int, TMP_ColorGradient> m_ColorGradientReferenceLookup;

		[Token(Token = "0x17000001")]
		public static MaterialReferenceManager instance
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x15BF198", Offset = "0x15BF198", Length = "0x74")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15BF360", Offset = "0x15BF360", Length = "0x20")]
		public static void AddFontAsset(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x15BF380", Offset = "0x15BF380", Length = "0xC4")]
		private void AddFontAssetInternal(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15BF444", Offset = "0x15BF444", Length = "0x20")]
		public static void AddSpriteAsset(TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x15BF464", Offset = "0x15BF464", Length = "0xC4")]
		private void AddSpriteAssetInternal(TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x15BF528", Offset = "0x15BF528", Length = "0x30")]
		public static void AddSpriteAsset(int hashCode, TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x15BF558", Offset = "0x15BF558", Length = "0xD4")]
		private void AddSpriteAssetInternal(int hashCode, TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x15BF62C", Offset = "0x15BF62C", Length = "0x30")]
		public static void AddFontMaterial(int hashCode, Material material)
		{
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x15BF65C", Offset = "0x15BF65C", Length = "0x68")]
		private void AddFontMaterialInternal(int hashCode, Material material)
		{
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x15BF6C4", Offset = "0x15BF6C4", Length = "0x30")]
		public static void AddColorGradientPreset(int hashCode, TMP_ColorGradient spriteAsset)
		{
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x15BF6F4", Offset = "0x15BF6F4", Length = "0xA4")]
		private void AddColorGradientPreset_Internal(int hashCode, TMP_ColorGradient spriteAsset)
		{
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x15BF798", Offset = "0x15BF798", Length = "0x5C")]
		public bool Contains(TMP_FontAsset font)
		{
			return false;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15BF7F4", Offset = "0x15BF7F4", Length = "0x5C")]
		public bool Contains(TMP_SpriteAsset sprite)
		{
			return false;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15BF850", Offset = "0x15BF850", Length = "0x30")]
		public static bool TryGetFontAsset(int hashCode, out TMP_FontAsset fontAsset)
		{
			fontAsset = null;
			return false;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15BF880", Offset = "0x15BF880", Length = "0x6C")]
		private bool TryGetFontAssetInternal(int hashCode, out TMP_FontAsset fontAsset)
		{
			fontAsset = null;
			return false;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15BF8EC", Offset = "0x15BF8EC", Length = "0x30")]
		public static bool TryGetSpriteAsset(int hashCode, out TMP_SpriteAsset spriteAsset)
		{
			spriteAsset = null;
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15BF91C", Offset = "0x15BF91C", Length = "0x6C")]
		private bool TryGetSpriteAssetInternal(int hashCode, out TMP_SpriteAsset spriteAsset)
		{
			spriteAsset = null;
			return false;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x15BF988", Offset = "0x15BF988", Length = "0x30")]
		public static bool TryGetColorGradientPreset(int hashCode, out TMP_ColorGradient gradientPreset)
		{
			gradientPreset = null;
			return false;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x15BF9B8", Offset = "0x15BF9B8", Length = "0x6C")]
		private bool TryGetColorGradientPresetInternal(int hashCode, out TMP_ColorGradient gradientPreset)
		{
			gradientPreset = null;
			return false;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15BFA24", Offset = "0x15BFA24", Length = "0x30")]
		public static bool TryGetMaterial(int hashCode, out Material material)
		{
			material = null;
			return false;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15BFA54", Offset = "0x15BFA54", Length = "0x6C")]
		private bool TryGetMaterialInternal(int hashCode, out Material material)
		{
			material = null;
			return false;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15BF20C", Offset = "0x15BF20C", Length = "0x154")]
		public MaterialReferenceManager()
		{
		}
	}
}
