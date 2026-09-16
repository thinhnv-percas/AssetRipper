using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000068")]
	public static class TMP_MaterialManager
	{
		[Token(Token = "0x2000069")]
		private class FallbackMaterial
		{
			[Token(Token = "0x40002E3")]
			[FieldOffset(Offset = "0x10")]
			public long fallbackID;

			[Token(Token = "0x40002E4")]
			[FieldOffset(Offset = "0x18")]
			public Material sourceMaterial;

			[Token(Token = "0x40002E5")]
			[FieldOffset(Offset = "0x20")]
			internal int sourceMaterialCRC;

			[Token(Token = "0x40002E6")]
			[FieldOffset(Offset = "0x28")]
			public Material fallbackMaterial;

			[Token(Token = "0x40002E7")]
			[FieldOffset(Offset = "0x30")]
			public int count;

			[Token(Token = "0x60003A2")]
			[Address(RVA = "0x1604ACC", Offset = "0x1604ACC", Length = "0x8")]
			public FallbackMaterial()
			{
			}
		}

		[Token(Token = "0x200006A")]
		private class MaskingMaterial
		{
			[Token(Token = "0x40002E8")]
			[FieldOffset(Offset = "0x10")]
			public Material baseMaterial;

			[Token(Token = "0x40002E9")]
			[FieldOffset(Offset = "0x18")]
			public Material stencilMaterial;

			[Token(Token = "0x40002EA")]
			[FieldOffset(Offset = "0x20")]
			public int count;

			[Token(Token = "0x40002EB")]
			[FieldOffset(Offset = "0x24")]
			public int stencilID;

			[Token(Token = "0x60003A3")]
			[Address(RVA = "0x16030DC", Offset = "0x16030DC", Length = "0x8")]
			public MaskingMaterial()
			{
			}
		}

		[Token(Token = "0x40002DE")]
		private static List<MaskingMaterial> m_materialList;

		[Token(Token = "0x40002DF")]
		private static Dictionary<long, FallbackMaterial> m_fallbackMaterials;

		[Token(Token = "0x40002E0")]
		private static Dictionary<int, long> m_fallbackMaterialLookup;

		[Token(Token = "0x40002E1")]
		private static List<FallbackMaterial> m_fallbackCleanupList;

		[Token(Token = "0x40002E2")]
		private static bool isFallbackListDirty;

		[Token(Token = "0x600038E")]
		[Address(RVA = "0x1601E1C", Offset = "0x1601E1C", Length = "0x1C8")]
		static TMP_MaterialManager()
		{
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0x1601FE4", Offset = "0x1601FE4", Length = "0x78")]
		private static void OnPreRender()
		{
		}

		[Token(Token = "0x6000390")]
		[Address(RVA = "0x1602270", Offset = "0x1602270", Length = "0x3A0")]
		public static Material GetStencilMaterial(Material baseMaterial, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x6000391")]
		[Address(RVA = "0x16030E4", Offset = "0x16030E4", Length = "0x1F0")]
		public static void ReleaseStencilMaterial(Material stencilMaterial)
		{
		}

		[Token(Token = "0x6000392")]
		[Address(RVA = "0x16032D4", Offset = "0x16032D4", Length = "0x160")]
		public static Material GetBaseMaterial(Material stencilMaterial)
		{
			return null;
		}

		[Token(Token = "0x6000393")]
		[Address(RVA = "0x160343C", Offset = "0x160343C", Length = "0xBC")]
		public static Material SetStencil(Material material, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x6000394")]
		[Address(RVA = "0x16034F8", Offset = "0x16034F8", Length = "0x26C")]
		public static void AddMaskingMaterial(Material baseMaterial, Material stencilMaterial, int stencilID)
		{
		}

		[Token(Token = "0x6000395")]
		[Address(RVA = "0x160376C", Offset = "0x160376C", Length = "0x15C")]
		public static void RemoveStencilMaterial(Material stencilMaterial)
		{
		}

		[Token(Token = "0x6000396")]
		[Address(RVA = "0x16038D0", Offset = "0x16038D0", Length = "0x494")]
		public static void ReleaseBaseMaterial(Material baseMaterial)
		{
		}

		[Token(Token = "0x6000397")]
		[Address(RVA = "0x1603D6C", Offset = "0x1603D6C", Length = "0x1BC")]
		public static void ClearMaterials()
		{
		}

		[Token(Token = "0x6000398")]
		[Address(RVA = "0x1603F28", Offset = "0x1603F28", Length = "0x2CC")]
		public static int GetStencilID(GameObject obj)
		{
			return 0;
		}

		[Token(Token = "0x6000399")]
		[Address(RVA = "0x1604394", Offset = "0x1604394", Length = "0x1FC")]
		public static Material GetMaterialForRendering(MaskableGraphic graphic, Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x600039A")]
		[Address(RVA = "0x16041F4", Offset = "0x16041F4", Length = "0x1A0")]
		private static Transform FindRootSortOverrideCanvas(Transform start)
		{
			return null;
		}

		[Token(Token = "0x600039B")]
		[Address(RVA = "0x1604590", Offset = "0x1604590", Length = "0x2D0")]
		internal static Material GetFallbackMaterial(TMP_FontAsset fontAsset, Material sourceMaterial, int atlasIndex)
		{
			return null;
		}

		[Token(Token = "0x600039C")]
		[Address(RVA = "0x1604AD4", Offset = "0x1604AD4", Length = "0x424")]
		public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial)
		{
			return null;
		}

		[Token(Token = "0x600039D")]
		[Address(RVA = "0x1604EF8", Offset = "0x1604EF8", Length = "0x144")]
		public static void AddFallbackMaterialReference(Material targetMaterial)
		{
		}

		[Token(Token = "0x600039E")]
		[Address(RVA = "0x160503C", Offset = "0x160503C", Length = "0x1D0")]
		public static void RemoveFallbackMaterialReference(Material targetMaterial)
		{
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0x160205C", Offset = "0x160205C", Length = "0x214")]
		public static void CleanupFallbackMaterials()
		{
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x160520C", Offset = "0x160520C", Length = "0x1F0")]
		public static void ReleaseFallbackMaterial(Material fallbackMaterial)
		{
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0x1604860", Offset = "0x1604860", Length = "0x26C")]
		public static void CopyMaterialPresetProperties(Material source, Material destination)
		{
		}
	}
}
