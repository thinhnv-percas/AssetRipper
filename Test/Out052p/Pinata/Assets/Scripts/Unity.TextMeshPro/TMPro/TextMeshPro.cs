using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[DisallowMultipleComponent]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x747F88", Offset = "0x747F88")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x747F88", Offset = "0x747F88")]
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x747F88", Offset = "0x747F88")]
	[ExecuteAlways]
	[Token(Token = "0x200000A")]
	public class TextMeshPro : TMP_Text, ILayoutElement
	{
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0xB30")]
		private bool m_currentAutoSizeMode;

		[SerializeField]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0xB31")]
		private bool m_hasFontAssetChanged;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0xB34")]
		private float m_previousLossyScaleY;

		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0xB38")]
		private Renderer m_renderer;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0xB40")]
		private MeshFilter m_meshFilter;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0xB48")]
		private bool m_isFirstAllocation;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0xB4C")]
		private int m_max_characters;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0xB50")]
		private int m_max_numberOfLines;

		[SerializeField]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0xB58")]
		protected TMP_SubMesh[] m_subTextObjects;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0xB60")]
		private bool m_isMaskingEnabled;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0xB61")]
		private bool isMaskUpdateRequired;

		[SerializeField]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0xB64")]
		private MaskingTypes m_maskType;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0xB68")]
		private Matrix4x4 m_EnvMapMatrix;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0xBA8")]
		private Vector3[] m_RectTransformCorners;

		[NonSerialized]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0xBB0")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0xBB4")]
		private int loopCountA;

		[Token(Token = "0x17000011")]
		public int sortingLayerID
		{
			[Token(Token = "0x600004E")]
			[Address(RVA = "0xC92288", Offset = "0xC92288", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600004F")]
			[Address(RVA = "0xC922A4", Offset = "0xC922A4", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000012")]
		public int sortingOrder
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0xC922C0", Offset = "0xC922C0", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000051")]
			[Address(RVA = "0xC922DC", Offset = "0xC922DC", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000013")]
		public override bool autoSizeTextContainer
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0xC922F8", Offset = "0xC922F8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000053")]
			[Address(RVA = "0xC92300", Offset = "0xC92300", Length = "0x60")]
			set
			{
			}
		}

		[Obsolete]
		[Token(Token = "0x17000014")]
		public TextContainer textContainer
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0xC92360", Offset = "0xC92360", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000015")]
		public new Transform transform
		{
			[Token(Token = "0x6000055")]
			[Address(RVA = "0xC92368", Offset = "0xC92368", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000016")]
		public Renderer renderer
		{
			[Token(Token = "0x6000056")]
			[Address(RVA = "0xC92400", Offset = "0xC92400", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000017")]
		public override Mesh mesh
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0xC92498", Offset = "0xC92498", Length = "0xD0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000018")]
		public MeshFilter meshFilter
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0xC92568", Offset = "0xC92568", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000019")]
		public MaskingTypes maskType
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0xC92600", Offset = "0xC92600", Length = "0x8")]
			get
			{
				return MaskingTypes.MaskOff;
			}
			[Token(Token = "0x600005A")]
			[Address(RVA = "0xC92608", Offset = "0xC92608", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xC9279C", Offset = "0xC9279C", Length = "0x54")]
		public void SetMask(MaskingTypes type, Vector4 maskCoords)
		{
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xC928A4", Offset = "0xC928A4", Length = "0x6C")]
		public void SetMask(MaskingTypes type, Vector4 maskCoords, float softnessX, float softnessY)
		{
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xC92A1C", Offset = "0xC92A1C", Length = "0xA0")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xC92ABC", Offset = "0xC92ABC", Length = "0xA8")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0xC92B64", Offset = "0xC92B64", Length = "0x10")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0xC92B74", Offset = "0xC92B74", Length = "0x58")]
		public override void SetAllDirty()
		{
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0xC92BCC", Offset = "0xC92BCC", Length = "0x100")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0xC92E5C", Offset = "0xC92E5C", Length = "0x12C")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0xC92F88", Offset = "0xC92F88", Length = "0x124")]
		public override void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0xC930AC", Offset = "0xC930AC", Length = "0xC")]
		public override void ForceMeshUpdate()
		{
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0xC930B8", Offset = "0xC930B8", Length = "0x10")]
		public override void ForceMeshUpdate(bool ignoreInactive)
		{
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0xC930C8", Offset = "0xC930C8", Length = "0x78")]
		public override TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0xC93140", Offset = "0xC93140", Length = "0xE4")]
		public override void ClearMesh(bool updateMesh)
		{
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0xC93224", Offset = "0xC93224", Length = "0x20")]
		public override void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0xC93244", Offset = "0xC93244", Length = "0x1B0")]
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0xC933F4", Offset = "0xC933F4", Length = "0x1AC")]
		public override void UpdateVertexData()
		{
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xC935A0", Offset = "0xC935A0", Length = "0x10")]
		public void UpdateFontAsset()
		{
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xC935B0", Offset = "0xC935B0", Length = "0x12C")]
		public void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0xC936DC", Offset = "0xC936DC", Length = "0x10C")]
		public void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0xC937E8", Offset = "0xC937E8", Length = "0x45C")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0xC93C44", Offset = "0xC93C44", Length = "0xD0")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0xC93D14", Offset = "0xC93D14", Length = "0x6C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0xC93D80", Offset = "0xC93D80", Length = "0xB8")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xC93E38", Offset = "0xC93E38", Length = "0x524")]
		protected override void LoadFontAsset()
		{
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xC9435C", Offset = "0xC9435C", Length = "0x2FC")]
		private void UpdateEnvMapMatrix()
		{
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xC92610", Offset = "0xC92610", Length = "0x18C")]
		private void SetMask(MaskingTypes maskType)
		{
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0xC927F0", Offset = "0xC927F0", Length = "0xB4")]
		private void SetMaskCoordinates(Vector4 coords)
		{
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0xC92910", Offset = "0xC92910", Length = "0x10C")]
		private void SetMaskCoordinates(Vector4 coords, float softX, float softY)
		{
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0xC94658", Offset = "0xC94658", Length = "0x120")]
		private void EnableMasking()
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0xC94808", Offset = "0xC94808", Length = "0x11C")]
		private void DisableMasking()
		{
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xC94778", Offset = "0xC94778", Length = "0x90")]
		private void UpdateMask()
		{
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xC949F4", Offset = "0xC949F4", Length = "0x128")]
		protected override Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xC94B1C", Offset = "0xC94B1C", Length = "0x1B0")]
		protected override Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0xC94CCC", Offset = "0xC94CCC", Length = "0x44")]
		protected override void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0xC94D10", Offset = "0xC94D10", Length = "0x198")]
		protected override Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0xC94EA8", Offset = "0xC94EA8", Length = "0x39C")]
		protected override void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xC95244", Offset = "0xC95244", Length = "0x164")]
		protected override void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0xC953A8", Offset = "0xC953A8", Length = "0x114")]
		protected override void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0xC954BC", Offset = "0xC954BC", Length = "0x114")]
		protected override void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xC94924", Offset = "0xC94924", Length = "0xD0")]
		private void CreateMaterialInstance()
		{
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0xC955D0", Offset = "0xC955D0", Length = "0x120")]
		protected override void SetShaderDepth()
		{
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0xC956F0", Offset = "0xC956F0", Length = "0x2FC")]
		protected override void SetCulling()
		{
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0xC959EC", Offset = "0xC959EC", Length = "0xB0")]
		private void SetPerspectiveCorrection()
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xC95A9C", Offset = "0xC95A9C", Length = "0xE0")]
		protected override float GetPaddingForMaterial(Material mat)
		{
			return 0f;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xC95B7C", Offset = "0xC95B7C", Length = "0x140")]
		protected override float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0xC95CBC", Offset = "0xC95CBC", Length = "0x1C40")]
		protected override int SetArraySizes(UnicodeChar[] chars)
		{
			return 0;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0xC978FC", Offset = "0xC978FC", Length = "0x120")]
		public override void ComputeMarginSize()
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0xC97A1C", Offset = "0xC97A1C", Length = "0x1C")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0xC97A38", Offset = "0xC97A38", Length = "0x3C")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0xC97A74", Offset = "0xC97A74", Length = "0x50")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0xC97AC4", Offset = "0xC97AC4", Length = "0xD8")]
		internal override void InternalUpdate()
		{
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0xC92CCC", Offset = "0xC92CCC", Length = "0x190")]
		private void OnPreRenderObject()
		{
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0xC97D9C", Offset = "0xC97D9C", Length = "0x7F80")]
		protected override void GenerateTextMesh()
		{
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0xC9FD1C", Offset = "0xC9FD1C", Length = "0xAC")]
		protected override Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0xC9FDC8", Offset = "0xC9FDC8", Length = "0x208")]
		private void SetMeshFilters(bool state)
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0xC9FFD0", Offset = "0xC9FFD0", Length = "0x138")]
		protected override void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0xCA0108", Offset = "0xCA0108", Length = "0x198")]
		protected override void ClearSubMeshObjects()
		{
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xCA02A0", Offset = "0xCA02A0", Length = "0x32C")]
		protected override Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xC97B9C", Offset = "0xC97B9C", Length = "0x200")]
		private void UpdateSDFScale(float scaleDelta)
		{
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0xCA05CC", Offset = "0xCA05CC", Length = "0x420")]
		protected override void AdjustLineOffset(int startIndex, int endIndex, float offset)
		{
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0xCA09EC", Offset = "0xCA09EC", Length = "0x10B0")]
		public TextMeshPro()
		{
		}
	}
}
