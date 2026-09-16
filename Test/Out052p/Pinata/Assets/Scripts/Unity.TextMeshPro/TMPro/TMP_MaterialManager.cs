using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x200002F")]
	public static class TMP_MaterialManager
	{
		[Token(Token = "0x200008F")]
		private class FallbackMaterial
		{
			[Token(Token = "0x40004D8")]
			[FieldOffset(Offset = "0x10")]
			public int baseID;

			[Token(Token = "0x40004D9")]
			[FieldOffset(Offset = "0x18")]
			public Material baseMaterial;

			[Token(Token = "0x40004DA")]
			[FieldOffset(Offset = "0x20")]
			public long fallbackID;

			[Token(Token = "0x40004DB")]
			[FieldOffset(Offset = "0x28")]
			public Material fallbackMaterial;

			[Token(Token = "0x40004DC")]
			[FieldOffset(Offset = "0x30")]
			public int count;

			[Token(Token = "0x6000594")]
			[Address(RVA = "0x9378FC", Offset = "0x9378FC", Length = "0x8")]
			public FallbackMaterial()
			{
			}
		}

		[Token(Token = "0x2000090")]
		private class MaskingMaterial
		{
			[Token(Token = "0x40004DD")]
			[FieldOffset(Offset = "0x10")]
			public Material baseMaterial;

			[Token(Token = "0x40004DE")]
			[FieldOffset(Offset = "0x18")]
			public Material stencilMaterial;

			[Token(Token = "0x40004DF")]
			[FieldOffset(Offset = "0x20")]
			public int count;

			[Token(Token = "0x40004E0")]
			[FieldOffset(Offset = "0x24")]
			public int stencilID;

			[Token(Token = "0x6000595")]
			[Address(RVA = "0x935E88", Offset = "0x935E88", Length = "0x8")]
			public MaskingMaterial()
			{
			}
		}

		[Token(Token = "0x4000191")]
		private static List<MaskingMaterial> m_materialList;

		[Token(Token = "0x4000192")]
		private static Dictionary<long, FallbackMaterial> m_fallbackMaterials;

		[Token(Token = "0x4000193")]
		private static Dictionary<int, long> m_fallbackMaterialLookup;

		[Token(Token = "0x4000194")]
		private static List<FallbackMaterial> m_fallbackCleanupList;

		[Token(Token = "0x4000195")]
		private static bool isFallbackListDirty;

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x935604", Offset = "0x935604", Length = "0x1B4")]
		static TMP_MaterialManager()
		{
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0x9357B8", Offset = "0x9357B8", Length = "0x90")]
		private static void OnPreRender(Camera cam)
		{
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0x935A5C", Offset = "0x935A5C", Length = "0x90")]
		private static void OnPreRenderCanvas()
		{
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0x935AEC", Offset = "0x935AEC", Length = "0x39C")]
		public static Material GetStencilMaterial(Material baseMaterial, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0x935E90", Offset = "0x935E90", Length = "0x268")]
		public static void ReleaseStencilMaterial(Material stencilMaterial)
		{
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x9360F8", Offset = "0x9360F8", Length = "0x154")]
		public static Material GetBaseMaterial(Material stencilMaterial)
		{
			return null;
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0x936254", Offset = "0x936254", Length = "0xF0")]
		public static Material SetStencil(Material material, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0x936344", Offset = "0x936344", Length = "0x224")]
		public static void AddMaskingMaterial(Material baseMaterial, Material stencilMaterial, int stencilID)
		{
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0x936570", Offset = "0x936570", Length = "0x144")]
		public static void RemoveStencilMaterial(Material stencilMaterial)
		{
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0x9366BC", Offset = "0x9366BC", Length = "0x680")]
		public static void ReleaseBaseMaterial(Material baseMaterial)
		{
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0x936D44", Offset = "0x936D44", Length = "0x1AC")]
		public static void ClearMaterials()
		{
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0x936EF0", Offset = "0x936EF0", Length = "0x2F0")]
		public static int GetStencilID(GameObject obj)
		{
			return 0;
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0x937360", Offset = "0x937360", Length = "0x1D4")]
		public static Material GetMaterialForRendering(MaskableGraphic graphic, Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0x9371E0", Offset = "0x9371E0", Length = "0x180")]
		private static Transform FindRootSortOverrideCanvas(Transform start)
		{
			return null;
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0x937534", Offset = "0x937534", Length = "0x3C8")]
		public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial)
		{
			return null;
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0x937904", Offset = "0x937904", Length = "0x144")]
		public static void AddFallbackMaterialReference(Material targetMaterial)
		{
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0x937A48", Offset = "0x937A48", Length = "0x188")]
		public static void RemoveFallbackMaterialReference(Material targetMaterial)
		{
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0x935848", Offset = "0x935848", Length = "0x214")]
		public static void CleanupFallbackMaterials()
		{
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0x937BD0", Offset = "0x937BD0", Length = "0x1B0")]
		public static void ReleaseFallbackMaterial(Material fallackMaterial)
		{
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0x937D80", Offset = "0x937D80", Length = "0x290")]
		public static void CopyMaterialPresetProperties(Material source, Material destination)
		{
		}
	}
}
