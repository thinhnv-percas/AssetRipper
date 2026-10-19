using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;

namespace Unco.UText.Runtime
{
	[Token(Token = "0x20007A3")]
	internal static class RichTextRegistryResolver
	{
		[Token(Token = "0x6002031")]
		[Address(RVA = "0x3D962B0", Offset = "0x3D962B0", Length = "0x130")]
		public static bool ResolveStyle(string name, StyleRegistryEntry[] componentOverrides, out UTextStyle style)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextRegistryResolver::ResolveStyle");
			style = default;
			return default;
		}

		[Token(Token = "0x6002032")]
		[Address(RVA = "0x3D964A8", Offset = "0x3D964A8", Length = "0x2E0")]
		public static bool ResolveSpriteByName(string name, SpriteRegistryEntry[] componentOverrides, out int atlasIndex, out int entryIndex, out UTextSpriteAsset atlas)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextRegistryResolver::ResolveSpriteByName");
			atlasIndex = default;
			entryIndex = default;
			atlas = default;
			return default;
		}

		[Token(Token = "0x6002033")]
		[Address(RVA = "0x3D968D0", Offset = "0x3D968D0", Length = "0x2FC")]
		public static bool ResolveSpriteByIndex(string atlasName, int entryIndex, SpriteRegistryEntry[] componentOverrides, out int atlasIndex, out UTextSpriteAsset atlas)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextRegistryResolver::ResolveSpriteByIndex");
			atlasIndex = default;
			atlas = default;
			return default;
		}

		[Token(Token = "0x6002034")]
		[Address(RVA = "0x3D96820", Offset = "0x3D96820", Length = "0xB0")]
		private static UTextSpriteAsset LoadDefaultAtlas()
		{
			if ((UnityEngine.Object)null != (UnityEngine.Object)null)
			{
				return null;
			}
			string defaultSpriteAtlasPath = UTextSettings.DefaultSpriteAtlasPath;
			return Resources.Load<UTextSpriteAsset>(defaultSpriteAtlasPath);
		}
	}
}
