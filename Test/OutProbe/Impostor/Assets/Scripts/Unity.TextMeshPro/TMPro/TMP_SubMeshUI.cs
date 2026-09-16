using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[RequireComponent(typeof(CanvasRenderer))]
	[ExecuteAlways]
	[Token(Token = "0x2000086")]
	public class TMP_SubMeshUI : MaskableGraphic
	{
		[SerializeField]
		[Token(Token = "0x400044E")]
		[FieldOffset(Offset = "0xD8")]
		private TMP_FontAsset m_fontAsset;

		[SerializeField]
		[Token(Token = "0x400044F")]
		[FieldOffset(Offset = "0xE0")]
		private TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x4000450")]
		[FieldOffset(Offset = "0xE8")]
		private Material m_material;

		[SerializeField]
		[Token(Token = "0x4000451")]
		[FieldOffset(Offset = "0xF0")]
		private Material m_sharedMaterial;

		[Token(Token = "0x4000452")]
		[FieldOffset(Offset = "0xF8")]
		private Material m_fallbackMaterial;

		[Token(Token = "0x4000453")]
		[FieldOffset(Offset = "0x100")]
		private Material m_fallbackSourceMaterial;

		[SerializeField]
		[Token(Token = "0x4000454")]
		[FieldOffset(Offset = "0x108")]
		private bool m_isDefaultMaterial;

		[SerializeField]
		[Token(Token = "0x4000455")]
		[FieldOffset(Offset = "0x10C")]
		private float m_padding;

		[Token(Token = "0x4000456")]
		[FieldOffset(Offset = "0x110")]
		private Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x4000457")]
		[FieldOffset(Offset = "0x118")]
		private TextMeshProUGUI m_TextComponent;

		[NonSerialized]
		[Token(Token = "0x4000458")]
		[FieldOffset(Offset = "0x120")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x4000459")]
		[FieldOffset(Offset = "0x121")]
		private bool m_materialDirty;

		[SerializeField]
		[Token(Token = "0x400045A")]
		[FieldOffset(Offset = "0x124")]
		private int m_materialReferenceIndex;

		[Token(Token = "0x400045B")]
		[FieldOffset(Offset = "0x128")]
		private Transform m_RootCanvasTransform;

		[Token(Token = "0x170000FD")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x6000472")]
			[Address(RVA = "0x160ECEC", Offset = "0x160ECEC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000473")]
			[Address(RVA = "0x160ECF4", Offset = "0x160ECF4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FE")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x6000474")]
			[Address(RVA = "0x160ECFC", Offset = "0x160ECFC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000475")]
			[Address(RVA = "0x160ED04", Offset = "0x160ED04", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FF")]
		public override Texture mainTexture
		{
			[Token(Token = "0x6000476")]
			[Address(RVA = "0x160ED0C", Offset = "0x160ED0C", Length = "0xBC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000100")]
		public override Material material
		{
			[Token(Token = "0x6000477")]
			[Address(RVA = "0x160EDC8", Offset = "0x160EDC8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000478")]
			[Address(RVA = "0x160EEC4", Offset = "0x160EEC4", Length = "0xE8")]
			set
			{
			}
		}

		[Token(Token = "0x17000101")]
		public Material sharedMaterial
		{
			[Token(Token = "0x6000479")]
			[Address(RVA = "0x160F020", Offset = "0x160F020", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600047A")]
			[Address(RVA = "0x160F028", Offset = "0x160F028", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x17000102")]
		public Material fallbackMaterial
		{
			[Token(Token = "0x600047B")]
			[Address(RVA = "0x160F088", Offset = "0x160F088", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600047C")]
			[Address(RVA = "0x160F090", Offset = "0x160F090", Length = "0x148")]
			set
			{
			}
		}

		[Token(Token = "0x17000103")]
		public Material fallbackSourceMaterial
		{
			[Token(Token = "0x600047D")]
			[Address(RVA = "0x160F1D8", Offset = "0x160F1D8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600047E")]
			[Address(RVA = "0x160F1E0", Offset = "0x160F1E0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000104")]
		public override Material materialForRendering
		{
			[Token(Token = "0x600047F")]
			[Address(RVA = "0x160F1E8", Offset = "0x160F1E8", Length = "0x5C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000105")]
		public bool isDefaultMaterial
		{
			[Token(Token = "0x6000480")]
			[Address(RVA = "0x160F244", Offset = "0x160F244", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000481")]
			[Address(RVA = "0x160F24C", Offset = "0x160F24C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000106")]
		public float padding
		{
			[Token(Token = "0x6000482")]
			[Address(RVA = "0x160F258", Offset = "0x160F258", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000483")]
			[Address(RVA = "0x160F260", Offset = "0x160F260", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000107")]
		public Mesh mesh
		{
			[Token(Token = "0x6000484")]
			[Address(RVA = "0x160F268", Offset = "0x160F268", Length = "0xB0")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000485")]
			[Address(RVA = "0x160F318", Offset = "0x160F318", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000108")]
		public TMP_Text textComponent
		{
			[Token(Token = "0x6000486")]
			[Address(RVA = "0x160F320", Offset = "0x160F320", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000487")]
		[Address(RVA = "0x160F3B4", Offset = "0x160F3B4", Length = "0x3B0")]
		public static TMP_SubMeshUI AddSubTextObject(TextMeshProUGUI textComponent, MaterialReference materialReference)
		{
			return null;
		}

		[Token(Token = "0x6000488")]
		[Address(RVA = "0x160F764", Offset = "0x160F764", Length = "0x70")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000489")]
		[Address(RVA = "0x160F7D4", Offset = "0x160F7D4", Length = "0xA8")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600048A")]
		[Address(RVA = "0x160F87C", Offset = "0x160F87C", Length = "0x1AC")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x600048B")]
		[Address(RVA = "0x160FA28", Offset = "0x160FA28", Length = "0x54")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600048C")]
		[Address(RVA = "0x160FA7C", Offset = "0x160FA7C", Length = "0x100")]
		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x600048D")]
		[Address(RVA = "0x160EFAC", Offset = "0x160EFAC", Length = "0x74")]
		public float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x600048E")]
		[Address(RVA = "0x160FB7C", Offset = "0x160FB7C", Length = "0x74")]
		public float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x600048F")]
		[Address(RVA = "0x160FBF0", Offset = "0x160FBF0", Length = "0x74")]
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
		}

		[Token(Token = "0x6000490")]
		[Address(RVA = "0x160FC64", Offset = "0x160FC64", Length = "0x4")]
		public override void SetAllDirty()
		{
		}

		[Token(Token = "0x6000491")]
		[Address(RVA = "0x160FC68", Offset = "0x160FC68", Length = "0xB4")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x6000492")]
		[Address(RVA = "0x160FD1C", Offset = "0x160FD1C", Length = "0x4")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x6000493")]
		[Address(RVA = "0x160FD20", Offset = "0x160FD20", Length = "0x44")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x6000494")]
		[Address(RVA = "0x160FD64", Offset = "0x160FD64", Length = "0x68")]
		public void SetPivotDirty()
		{
		}

		[Token(Token = "0x6000495")]
		[Address(RVA = "0x160FDCC", Offset = "0x160FDCC", Length = "0xA0")]
		private Transform GetRootCanvasTransform()
		{
			return null;
		}

		[Token(Token = "0x6000496")]
		[Address(RVA = "0x160FE6C", Offset = "0x160FE6C", Length = "0x4")]
		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x6000497")]
		[Address(RVA = "0x160FE70", Offset = "0x160FE70", Length = "0x4")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x6000498")]
		[Address(RVA = "0x160FE74", Offset = "0x160FE74", Length = "0x38")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000499")]
		[Address(RVA = "0x160FEAC", Offset = "0x160FEAC", Length = "0x10")]
		public void RefreshMaterial()
		{
		}

		[Token(Token = "0x600049A")]
		[Address(RVA = "0x160FEBC", Offset = "0x160FEBC", Length = "0x180")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x600049B")]
		[Address(RVA = "0x161003C", Offset = "0x161003C", Length = "0x8")]
		public override void RecalculateClipping()
		{
		}

		[Token(Token = "0x600049C")]
		[Address(RVA = "0x1610044", Offset = "0x1610044", Length = "0x8")]
		private Material GetMaterial()
		{
			return null;
		}

		[Token(Token = "0x600049D")]
		[Address(RVA = "0x160EDD0", Offset = "0x160EDD0", Length = "0xF4")]
		private Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0x161004C", Offset = "0x161004C", Length = "0xC0")]
		private Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0x161010C", Offset = "0x161010C", Length = "0x20")]
		private Material GetSharedMaterial()
		{
			return null;
		}

		[Token(Token = "0x60004A0")]
		[Address(RVA = "0x160F058", Offset = "0x160F058", Length = "0x30")]
		private void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x60004A1")]
		[Address(RVA = "0x161012C", Offset = "0x161012C", Length = "0x8")]
		public TMP_SubMeshUI()
		{
		}
	}
}
