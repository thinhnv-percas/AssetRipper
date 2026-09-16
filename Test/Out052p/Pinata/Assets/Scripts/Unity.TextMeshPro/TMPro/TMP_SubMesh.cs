using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x748204", Offset = "0x748204")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x748204", Offset = "0x748204")]
	[ExecuteAlways]
	[Token(Token = "0x2000044")]
	public class TMP_SubMesh : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x18")]
		private TMP_FontAsset m_fontAsset;

		[SerializeField]
		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0x20")]
		private TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x400027D")]
		[FieldOffset(Offset = "0x28")]
		private Material m_material;

		[SerializeField]
		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0x30")]
		private Material m_sharedMaterial;

		[Token(Token = "0x400027F")]
		[FieldOffset(Offset = "0x38")]
		private Material m_fallbackMaterial;

		[Token(Token = "0x4000280")]
		[FieldOffset(Offset = "0x40")]
		private Material m_fallbackSourceMaterial;

		[SerializeField]
		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x48")]
		private bool m_isDefaultMaterial;

		[SerializeField]
		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x4C")]
		private float m_padding;

		[SerializeField]
		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0x50")]
		private Renderer m_renderer;

		[SerializeField]
		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x58")]
		private MeshFilter m_meshFilter;

		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x60")]
		private Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x68")]
		private TextMeshPro m_TextComponent;

		[NonSerialized]
		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x70")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x170000C6")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x6000360")]
			[Address(RVA = "0x93E82C", Offset = "0x93E82C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000361")]
			[Address(RVA = "0x93E834", Offset = "0x93E834", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C7")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x6000362")]
			[Address(RVA = "0x93E83C", Offset = "0x93E83C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000363")]
			[Address(RVA = "0x93E844", Offset = "0x93E844", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000C8")]
		public Material material
		{
			[Token(Token = "0x6000364")]
			[Address(RVA = "0x93E84C", Offset = "0x93E84C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000365")]
			[Address(RVA = "0x93E990", Offset = "0x93E990", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x170000C9")]
		public Material sharedMaterial
		{
			[Token(Token = "0x6000366")]
			[Address(RVA = "0x93EB94", Offset = "0x93EB94", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000367")]
			[Address(RVA = "0x93EB9C", Offset = "0x93EB9C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x170000CA")]
		public Material fallbackMaterial
		{
			[Token(Token = "0x6000368")]
			[Address(RVA = "0x93EBF4", Offset = "0x93EBF4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000369")]
			[Address(RVA = "0x93EBFC", Offset = "0x93EBFC", Length = "0x164")]
			set
			{
			}
		}

		[Token(Token = "0x170000CB")]
		public Material fallbackSourceMaterial
		{
			[Token(Token = "0x600036A")]
			[Address(RVA = "0x93ED60", Offset = "0x93ED60", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600036B")]
			[Address(RVA = "0x93ED68", Offset = "0x93ED68", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000CC")]
		public bool isDefaultMaterial
		{
			[Token(Token = "0x600036C")]
			[Address(RVA = "0x93ED70", Offset = "0x93ED70", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600036D")]
			[Address(RVA = "0x93ED78", Offset = "0x93ED78", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000CD")]
		public float padding
		{
			[Token(Token = "0x600036E")]
			[Address(RVA = "0x93ED84", Offset = "0x93ED84", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600036F")]
			[Address(RVA = "0x93ED8C", Offset = "0x93ED8C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000CE")]
		public Renderer renderer
		{
			[Token(Token = "0x6000370")]
			[Address(RVA = "0x93ED94", Offset = "0x93ED94", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000CF")]
		public MeshFilter meshFilter
		{
			[Token(Token = "0x6000371")]
			[Address(RVA = "0x93EE2C", Offset = "0x93EE2C", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D0")]
		public Mesh mesh
		{
			[Token(Token = "0x6000372")]
			[Address(RVA = "0x93EEC4", Offset = "0x93EEC4", Length = "0xD0")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000373")]
			[Address(RVA = "0x93EF94", Offset = "0x93EF94", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000374")]
		[Address(RVA = "0x93EF9C", Offset = "0x93EF9C", Length = "0x134")]
		private void OnEnable()
		{
		}

		[Token(Token = "0x6000375")]
		[Address(RVA = "0x93F0D0", Offset = "0x93F0D0", Length = "0xC0")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x6000376")]
		[Address(RVA = "0x93F190", Offset = "0x93F190", Length = "0x10C")]
		private void OnDestroy()
		{
		}

		[Token(Token = "0x6000377")]
		[Address(RVA = "0x93F29C", Offset = "0x93F29C", Length = "0x368")]
		public static TMP_SubMesh AddSubTextObject(TextMeshPro textComponent, MaterialReference materialReference)
		{
			return null;
		}

		[Token(Token = "0x6000378")]
		[Address(RVA = "0x93F604", Offset = "0x93F604", Length = "0x80")]
		public void DestroySelf()
		{
		}

		[Token(Token = "0x6000379")]
		[Address(RVA = "0x93E854", Offset = "0x93E854", Length = "0x13C")]
		private Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600037A")]
		[Address(RVA = "0x93F684", Offset = "0x93F684", Length = "0xC0")]
		private Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x600037B")]
		[Address(RVA = "0x93F744", Offset = "0x93F744", Length = "0xA8")]
		private Material GetSharedMaterial()
		{
			return null;
		}

		[Token(Token = "0x600037C")]
		[Address(RVA = "0x93EBC8", Offset = "0x93EBC8", Length = "0x2C")]
		private void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x600037D")]
		[Address(RVA = "0x93EA1C", Offset = "0x93EA1C", Length = "0x9C")]
		public float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x600037E")]
		[Address(RVA = "0x93F7EC", Offset = "0x93F7EC", Length = "0x8C")]
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
		}

		[Token(Token = "0x600037F")]
		[Address(RVA = "0x93EAB8", Offset = "0x93EAB8", Length = "0xD8")]
		public void SetVerticesDirty()
		{
		}

		[Token(Token = "0x6000380")]
		[Address(RVA = "0x93EB90", Offset = "0x93EB90", Length = "0x4")]
		public void SetMaterialDirty()
		{
		}

		[Token(Token = "0x6000381")]
		[Address(RVA = "0x93F8B0", Offset = "0x93F8B0", Length = "0xA0")]
		protected void UpdateMaterial()
		{
		}

		[Token(Token = "0x6000382")]
		[Address(RVA = "0x93F950", Offset = "0x93F950", Length = "0x8")]
		public TMP_SubMesh()
		{
		}
	}
}
