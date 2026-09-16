using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000006")]
	public class MaterialReferenceManager
	{
		[Token(Token = "0x4000009")]
		private static MaterialReferenceManager s_Instance;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<int, Material> m_FontMaterialReferenceLookup;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<int, TMP_FontAsset> m_FontAssetReferenceLookup;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<int, TMP_SpriteAsset> m_SpriteAssetReferenceLookup;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<int, TMP_ColorGradient> m_ColorGradientReferenceLookup;

		[Token(Token = "0x17000001")]
		public static MaterialReferenceManager instance
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x918D08", Offset = "0x918D08", Length = "0x7C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x918E6C", Offset = "0x918E6C", Length = "0x2C")]
		public static void AddFontAsset(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x918E98", Offset = "0x918E98", Length = "0xC4")]
		private void AddFontAssetInternal(TMP_FontAsset fontAsset)
		{
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x918F5C", Offset = "0x918F5C", Length = "0x2C")]
		public static void AddSpriteAsset(TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x918F88", Offset = "0x918F88", Length = "0xC4")]
		private void AddSpriteAssetInternal(TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x91904C", Offset = "0x91904C", Length = "0x34")]
		public static void AddSpriteAsset(int hashCode, TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x919080", Offset = "0x919080", Length = "0xCC")]
		private void AddSpriteAssetInternal(int hashCode, TMP_SpriteAsset spriteAsset)
		{
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x91914C", Offset = "0x91914C", Length = "0x34")]
		public static void AddFontMaterial(int hashCode, Material material)
		{
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x919180", Offset = "0x919180", Length = "0x70")]
		private void AddFontMaterialInternal(int hashCode, Material material)
		{
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x9191F0", Offset = "0x9191F0", Length = "0x34")]
		public static void AddColorGradientPreset(int hashCode, TMP_ColorGradient spriteAsset)
		{
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x919224", Offset = "0x919224", Length = "0xA0")]
		private void AddColorGradientPreset_Internal(int hashCode, TMP_ColorGradient spriteAsset)
		{
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x9192C4", Offset = "0x9192C4", Length = "0x70")]
		public bool Contains(TMP_FontAsset font)
		{
			return false;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x919334", Offset = "0x919334", Length = "0x70")]
		public bool Contains(TMP_SpriteAsset sprite)
		{
			return false;
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x9193A4", Offset = "0x9193A4", Length = "0x34")]
		public static bool TryGetFontAsset(int hashCode, out TMP_FontAsset fontAsset)
		{
			fontAsset = null;
			return false;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x9193D8", Offset = "0x9193D8", Length = "0x74")]
		private bool TryGetFontAssetInternal(int hashCode, out TMP_FontAsset fontAsset)
		{
			fontAsset = null;
			return false;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x91944C", Offset = "0x91944C", Length = "0x34")]
		public static bool TryGetSpriteAsset(int hashCode, out TMP_SpriteAsset spriteAsset)
		{
			spriteAsset = null;
			return false;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x919480", Offset = "0x919480", Length = "0x74")]
		private bool TryGetSpriteAssetInternal(int hashCode, out TMP_SpriteAsset spriteAsset)
		{
			spriteAsset = null;
			return false;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x9194F4", Offset = "0x9194F4", Length = "0x34")]
		public static bool TryGetColorGradientPreset(int hashCode, out TMP_ColorGradient gradientPreset)
		{
			gradientPreset = null;
			return false;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x919528", Offset = "0x919528", Length = "0x74")]
		private bool TryGetColorGradientPresetInternal(int hashCode, out TMP_ColorGradient gradientPreset)
		{
			gradientPreset = null;
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x91959C", Offset = "0x91959C", Length = "0x34")]
		public static bool TryGetMaterial(int hashCode, out Material material)
		{
			material = null;
			return false;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x9195D0", Offset = "0x9195D0", Length = "0x300")]
		private bool TryGetMaterialInternal(int hashCode, out Material material)
		{
			material = null;
			return false;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x918D84", Offset = "0x918D84", Length = "0xE8")]
		public MaterialReferenceManager()
		{
		}
	}
}
