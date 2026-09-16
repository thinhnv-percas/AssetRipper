using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[ExecuteAlways]
	[Token(Token = "0x2000045")]
	public class TMP_SubMeshUI : MaskableGraphic, IClippable, IMaskable, IMaterialModifier
	{
		[SerializeField]
		[Token(Token = "0x4000288")]
		[FieldOffset(Offset = "0xC0")]
		private TMP_FontAsset m_fontAsset;

		[SerializeField]
		[Token(Token = "0x4000289")]
		[FieldOffset(Offset = "0xC8")]
		private TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0xD0")]
		private Material m_material;

		[SerializeField]
		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0xD8")]
		private Material m_sharedMaterial;

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0xE0")]
		private Material m_fallbackMaterial;

		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0xE8")]
		private Material m_fallbackSourceMaterial;

		[SerializeField]
		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0xF0")]
		private bool m_isDefaultMaterial;

		[SerializeField]
		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0xF4")]
		private float m_padding;

		[SerializeField]
		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0xF8")]
		private CanvasRenderer m_canvasRenderer;

		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x100")]
		private Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x108")]
		private TextMeshProUGUI m_TextComponent;

		[NonSerialized]
		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x110")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x111")]
		private bool m_materialDirty;

		[SerializeField]
		[Token(Token = "0x4000295")]
		[FieldOffset(Offset = "0x114")]
		private int m_materialReferenceIndex;

		[Token(Token = "0x170000D1")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x6000383")]
			[Address(RVA = "0x93F958", Offset = "0x93F958", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000384")]
			[Address(RVA = "0x93F960", Offset = "0x93F960", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D2")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x6000385")]
			[Address(RVA = "0x93F968", Offset = "0x93F968", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000386")]
			[Address(RVA = "0x93F970", Offset = "0x93F970", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D3")]
		public override Texture mainTexture
		{
			[Token(Token = "0x6000387")]
			[Address(RVA = "0x93F978", Offset = "0x93F978", Length = "0xCC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D4")]
		public override Material material
		{
			[Token(Token = "0x6000388")]
			[Address(RVA = "0x93FA44", Offset = "0x93FA44", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000389")]
			[Address(RVA = "0x93FB58", Offset = "0x93FB58", Length = "0x100")]
			set
			{
			}
		}

		[Token(Token = "0x170000D5")]
		public Material sharedMaterial
		{
			[Token(Token = "0x600038A")]
			[Address(RVA = "0x93FCF4", Offset = "0x93FCF4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600038B")]
			[Address(RVA = "0x93FCFC", Offset = "0x93FCFC", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x170000D6")]
		public Material fallbackMaterial
		{
			[Token(Token = "0x600038C")]
			[Address(RVA = "0x93FD74", Offset = "0x93FD74", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600038D")]
			[Address(RVA = "0x93FD7C", Offset = "0x93FD7C", Length = "0x174")]
			set
			{
			}
		}

		[Token(Token = "0x170000D7")]
		public Material fallbackSourceMaterial
		{
			[Token(Token = "0x600038E")]
			[Address(RVA = "0x93FEF0", Offset = "0x93FEF0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600038F")]
			[Address(RVA = "0x93FEF8", Offset = "0x93FEF8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D8")]
		public override Material materialForRendering
		{
			[Token(Token = "0x6000390")]
			[Address(RVA = "0x93FF00", Offset = "0x93FF00", Length = "0x6C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D9")]
		public bool isDefaultMaterial
		{
			[Token(Token = "0x6000391")]
			[Address(RVA = "0x93FF6C", Offset = "0x93FF6C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000392")]
			[Address(RVA = "0x93FF74", Offset = "0x93FF74", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000DA")]
		public float padding
		{
			[Token(Token = "0x6000393")]
			[Address(RVA = "0x93FF80", Offset = "0x93FF80", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000394")]
			[Address(RVA = "0x93FF88", Offset = "0x93FF88", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000DB")]
		public new CanvasRenderer canvasRenderer
		{
			[Token(Token = "0x6000395")]
			[Address(RVA = "0x93FF90", Offset = "0x93FF90", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000DC")]
		public Mesh mesh
		{
			[Token(Token = "0x6000396")]
			[Address(RVA = "0x940028", Offset = "0x940028", Length = "0xB8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000397")]
			[Address(RVA = "0x9400E0", Offset = "0x9400E0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000398")]
		[Address(RVA = "0x9400E8", Offset = "0x9400E8", Length = "0x2DC")]
		public static TMP_SubMeshUI AddSubTextObject(TextMeshProUGUI textComponent, MaterialReference materialReference)
		{
			return null;
		}

		[Token(Token = "0x6000399")]
		[Address(RVA = "0x9404F4", Offset = "0x9404F4", Length = "0x58")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600039A")]
		[Address(RVA = "0x94054C", Offset = "0x94054C", Length = "0x124")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600039B")]
		[Address(RVA = "0x940670", Offset = "0x940670", Length = "0x178")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x600039C")]
		[Address(RVA = "0x9407E8", Offset = "0x9407E8", Length = "0x64")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600039D")]
		[Address(RVA = "0x94084C", Offset = "0x94084C", Length = "0x144")]
		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x600039E")]
		[Address(RVA = "0x93FC58", Offset = "0x93FC58", Length = "0x9C")]
		public float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0x940990", Offset = "0x940990", Length = "0x9C")]
		public float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x940A2C", Offset = "0x940A2C", Length = "0x8C")]
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0x940AB8", Offset = "0x940AB8", Length = "0x4")]
		public override void SetAllDirty()
		{
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0x940ABC", Offset = "0x940ABC", Length = "0xDC")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0x940B98", Offset = "0x940B98", Length = "0x4")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0x940B9C", Offset = "0x940B9C", Length = "0x4C")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x60003A5")]
		[Address(RVA = "0x940BE8", Offset = "0x940BE8", Length = "0x78")]
		public void SetPivotDirty()
		{
		}

		[Token(Token = "0x60003A6")]
		[Address(RVA = "0x940C60", Offset = "0x940C60", Length = "0x30")]
		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60003A7")]
		[Address(RVA = "0x940C90", Offset = "0x940C90", Length = "0x6C")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0x940CFC", Offset = "0x940CFC", Length = "0x44")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0x940D40", Offset = "0x940D40", Length = "0x10")]
		public void RefreshMaterial()
		{
		}

		[Token(Token = "0x60003AA")]
		[Address(RVA = "0x940D50", Offset = "0x940D50", Length = "0x104")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0x940E54", Offset = "0x940E54", Length = "0x8")]
		public override void RecalculateClipping()
		{
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0x940E5C", Offset = "0x940E5C", Length = "0x18")]
		public override void RecalculateMasking()
		{
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0x940E74", Offset = "0x940E74", Length = "0x8")]
		private Material GetMaterial()
		{
			return null;
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0x93FA4C", Offset = "0x93FA4C", Length = "0x10C")]
		private Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0x940E7C", Offset = "0x940E7C", Length = "0xC0")]
		private Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0x940F3C", Offset = "0x940F3C", Length = "0xA8")]
		private Material GetSharedMaterial()
		{
			return null;
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0x93FD38", Offset = "0x93FD38", Length = "0x3C")]
		private void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0x940FE4", Offset = "0x940FE4", Length = "0x8")]
		public TMP_SubMeshUI()
		{
		}
	}
}
