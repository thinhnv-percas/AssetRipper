using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[DisallowMultipleComponent]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x748058", Offset = "0x748058")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x748058", Offset = "0x748058")]
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x748058", Offset = "0x748058")]
	[ExecuteAlways]
	[Token(Token = "0x200000B")]
	public class TextMeshProUGUI : TMP_Text, ILayoutElement
	{
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0xB30")]
		private bool m_isRebuildingLayout;

		[SerializeField]
		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0xB31")]
		private bool m_hasFontAssetChanged;

		[SerializeField]
		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0xB38")]
		protected TMP_SubMeshUI[] m_subTextObjects;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0xB40")]
		private float m_previousLossyScaleY;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0xB48")]
		private Vector3[] m_RectTransformCorners;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0xB50")]
		private CanvasRenderer m_canvasRenderer;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0xB58")]
		private Canvas m_canvas;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0xB60")]
		private bool m_isFirstAllocation;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0xB64")]
		private int m_max_characters;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0xB68")]
		private bool m_isMaskingEnabled;

		[SerializeField]
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0xB70")]
		private Material m_baseMaterial;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0xB78")]
		private bool m_isScrollRegionSet;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0xB7C")]
		private int m_stencilID;

		[SerializeField]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0xB80")]
		private Vector4 m_maskOffset;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0xB90")]
		private Matrix4x4 m_EnvMapMatrix;

		[NonSerialized]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0xBD0")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0xBD4")]
		private int m_recursiveCountA;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0xBD8")]
		private int loopCountA;

		[Token(Token = "0x1700001A")]
		public override Material materialForRendering
		{
			[Token(Token = "0x6000098")]
			[Address(RVA = "0x11FFD28", Offset = "0x11FFD28", Length = "0x70")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001B")]
		public override bool autoSizeTextContainer
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x11FFD98", Offset = "0x11FFD98", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x11FFDA0", Offset = "0x11FFDA0", Length = "0xB8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001C")]
		public override Mesh mesh
		{
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x11FFE58", Offset = "0x11FFE58", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001D")]
		public new CanvasRenderer canvasRenderer
		{
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x11FFE60", Offset = "0x11FFE60", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001E")]
		public Vector4 maskOffset
		{
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x12009C4", Offset = "0x12009C4", Length = "0x14")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x60000A8")]
			[Address(RVA = "0x12009D8", Offset = "0x12009D8", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x11FFEF8", Offset = "0x11FFEF8", Length = "0x80")]
		public void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x11FFF78", Offset = "0x11FFF78", Length = "0x84")]
		public void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x11FFFFC", Offset = "0x11FFFFC", Length = "0x100")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x12000FC", Offset = "0x12000FC", Length = "0x10C")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x1200208", Offset = "0x1200208", Length = "0xF8")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x1200300", Offset = "0x1200300", Length = "0x58")]
		public override void SetAllDirty()
		{
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x1200358", Offset = "0x1200358", Length = "0x100")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x120064C", Offset = "0x120064C", Length = "0x108")]
		private void UpdateSubObjectPivot()
		{
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x1200754", Offset = "0x1200754", Length = "0x150")]
		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x12008A4", Offset = "0x12008A4", Length = "0x120")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x1200F08", Offset = "0x1200F08", Length = "0x8")]
		public override void RecalculateClipping()
		{
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x1200F10", Offset = "0x1200F10", Length = "0x18")]
		public override void RecalculateMasking()
		{
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x1200F28", Offset = "0x1200F28", Length = "0x18")]
		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x1200F40", Offset = "0x1200F40", Length = "0x124")]
		public override void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x1201064", Offset = "0x1201064", Length = "0xF0")]
		protected override void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x1201154", Offset = "0x1201154", Length = "0xB8")]
		protected override void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x120120C", Offset = "0x120120C", Length = "0xC")]
		public override void ForceMeshUpdate()
		{
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x1201218", Offset = "0x1201218", Length = "0x10")]
		public override void ForceMeshUpdate(bool ignoreInactive)
		{
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x1201228", Offset = "0x1201228", Length = "0xF8")]
		public override TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x1201320", Offset = "0x1201320", Length = "0x124")]
		public override void ClearMesh()
		{
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x1201444", Offset = "0x1201444", Length = "0x98")]
		public override void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x12014DC", Offset = "0x12014DC", Length = "0x204")]
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x12016E0", Offset = "0x12016E0", Length = "0x1F4")]
		public override void UpdateVertexData()
		{
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x12018D4", Offset = "0x12018D4", Length = "0x10")]
		public void UpdateFontAsset()
		{
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x12018E4", Offset = "0x12018E4", Length = "0x3C0")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x1201CA4", Offset = "0x1201CA4", Length = "0x11C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x1201F1C", Offset = "0x1201F1C", Length = "0x1D4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x12020F0", Offset = "0x12020F0", Length = "0x150")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x1202240", Offset = "0x1202240", Length = "0x5D4")]
		protected override void LoadFontAsset()
		{
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x1201DC0", Offset = "0x1201DC0", Length = "0x15C")]
		private Canvas GetCanvas()
		{
			return null;
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x1202814", Offset = "0x1202814", Length = "0x2EC")]
		private void UpdateEnvMapMatrix()
		{
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x1202B00", Offset = "0x1202B00", Length = "0x1D4")]
		private void EnableMasking()
		{
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x1202CD4", Offset = "0x1202CD4", Length = "0x130")]
		private void DisableMasking()
		{
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x1200A10", Offset = "0x1200A10", Length = "0x4F8")]
		private void UpdateMask()
		{
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x1202E04", Offset = "0x1202E04", Length = "0x158")]
		protected override Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x1202F5C", Offset = "0x1202F5C", Length = "0x1B8")]
		protected override Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x1203114", Offset = "0x1203114", Length = "0x44")]
		protected override void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x1203158", Offset = "0x1203158", Length = "0x198")]
		protected override Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x12032F0", Offset = "0x12032F0", Length = "0x430")]
		protected override void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x1203720", Offset = "0x1203720", Length = "0x208")]
		protected override void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x1203928", Offset = "0x1203928", Length = "0x120")]
		protected override void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x1203A48", Offset = "0x1203A48", Length = "0x120")]
		protected override void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x1203B68", Offset = "0x1203B68", Length = "0x15C")]
		protected override void SetShaderDepth()
		{
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x1203CC4", Offset = "0x1203CC4", Length = "0x34C")]
		protected override void SetCulling()
		{
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x1204010", Offset = "0x1204010", Length = "0xB0")]
		private void SetPerspectiveCorrection()
		{
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x12040C0", Offset = "0x12040C0", Length = "0xE0")]
		protected override float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x12041A0", Offset = "0x12041A0", Length = "0xC8")]
		protected override float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x1204268", Offset = "0x1204268", Length = "0x84")]
		private void SetMeshArrays(int size)
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x12042EC", Offset = "0x12042EC", Length = "0x1CF4")]
		protected override int SetArraySizes(UnicodeChar[] chars)
		{
			return 0;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x1205FE0", Offset = "0x1205FE0", Length = "0x120")]
		public override void ComputeMarginSize()
		{
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x1206100", Offset = "0x1206100", Length = "0x44")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x1206144", Offset = "0x1206144", Length = "0x34")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x1206178", Offset = "0x1206178", Length = "0x50")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x12061C8", Offset = "0x12061C8", Length = "0x84")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x120624C", Offset = "0x120624C", Length = "0xD8")]
		internal override void InternalUpdate()
		{
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x1200458", Offset = "0x1200458", Length = "0x1F4")]
		private void OnPreRenderCanvas()
		{
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x12065B0", Offset = "0x12065B0", Length = "0x81D8")]
		protected override void GenerateTextMesh()
		{
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x120E788", Offset = "0x120E788", Length = "0xAC")]
		protected override Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x120E834", Offset = "0x120E834", Length = "0x138")]
		protected override void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x120E96C", Offset = "0x120E96C", Length = "0x32C")]
		protected override Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x1206324", Offset = "0x1206324", Length = "0x28C")]
		private void UpdateSDFScale(float scaleDelta)
		{
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x120EC98", Offset = "0x120EC98", Length = "0x420")]
		protected override void AdjustLineOffset(int startIndex, int endIndex, float offset)
		{
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x120F0B8", Offset = "0x120F0B8", Length = "0x1100")]
		public TextMeshProUGUI()
		{
		}
	}
}
