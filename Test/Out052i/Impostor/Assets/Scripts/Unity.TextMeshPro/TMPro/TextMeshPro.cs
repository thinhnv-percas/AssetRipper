using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
	[ExecuteAlways]
	[AddComponentMenu("Mesh/TextMeshPro - Text")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(MeshRenderer))]
	[Token(Token = "0x200000E")]
	public class TextMeshPro : TMP_Text, ILayoutElement
	{
		[SerializeField]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x6C8")]
		internal int _SortingLayer;

		[SerializeField]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x6CC")]
		internal int _SortingLayerID;

		[SerializeField]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x6D0")]
		internal int _SortingOrder;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x6E0")]
		private bool m_currentAutoSizeMode;

		[SerializeField]
		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x6E1")]
		private bool m_hasFontAssetChanged;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x6E4")]
		private float m_previousLossyScaleY;

		[SerializeField]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x6E8")]
		private Renderer m_renderer;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x6F0")]
		private MeshFilter m_meshFilter;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x6F8")]
		private bool m_isFirstAllocation;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x6FC")]
		private int m_max_characters;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x700")]
		private int m_max_numberOfLines;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x708")]
		private TMP_SubMesh[] m_subTextObjects;

		[SerializeField]
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x710")]
		private MaskingTypes m_maskType;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x714")]
		private Matrix4x4 m_EnvMapMatrix;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x758")]
		private Vector3[] m_RectTransformCorners;

		[NonSerialized]
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x760")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x4000047")]
		private static ProfilerMarker k_GenerateTextMarker;

		[Token(Token = "0x4000048")]
		private static ProfilerMarker k_SetArraySizesMarker;

		[Token(Token = "0x4000049")]
		private static ProfilerMarker k_GenerateTextPhaseIMarker;

		[Token(Token = "0x400004A")]
		private static ProfilerMarker k_ParseMarkupTextMarker;

		[Token(Token = "0x400004B")]
		private static ProfilerMarker k_CharacterLookupMarker;

		[Token(Token = "0x400004C")]
		private static ProfilerMarker k_HandleGPOSFeaturesMarker;

		[Token(Token = "0x400004D")]
		private static ProfilerMarker k_CalculateVerticesPositionMarker;

		[Token(Token = "0x400004E")]
		private static ProfilerMarker k_ComputeTextMetricsMarker;

		[Token(Token = "0x400004F")]
		private static ProfilerMarker k_HandleVisibleCharacterMarker;

		[Token(Token = "0x4000050")]
		private static ProfilerMarker k_HandleWhiteSpacesMarker;

		[Token(Token = "0x4000051")]
		private static ProfilerMarker k_HandleHorizontalLineBreakingMarker;

		[Token(Token = "0x4000052")]
		private static ProfilerMarker k_HandleVerticalLineBreakingMarker;

		[Token(Token = "0x4000053")]
		private static ProfilerMarker k_SaveGlyphVertexDataMarker;

		[Token(Token = "0x4000054")]
		private static ProfilerMarker k_ComputeCharacterAdvanceMarker;

		[Token(Token = "0x4000055")]
		private static ProfilerMarker k_HandleCarriageReturnMarker;

		[Token(Token = "0x4000056")]
		private static ProfilerMarker k_HandleLineTerminationMarker;

		[Token(Token = "0x4000057")]
		private static ProfilerMarker k_SavePageInfoMarker;

		[Token(Token = "0x4000058")]
		private static ProfilerMarker k_SaveProcessingStatesMarker;

		[Token(Token = "0x4000059")]
		private static ProfilerMarker k_GenerateTextPhaseIIMarker;

		[Token(Token = "0x400005A")]
		private static ProfilerMarker k_GenerateTextPhaseIIIMarker;

		[Token(Token = "0x17000011")]
		public int sortingLayerID
		{
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x15C0A34", Offset = "0x15C0A34", Length = "0x94")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x15C0B5C", Offset = "0x15C0B5C", Length = "0xB4")]
			set
			{
			}
		}

		[Token(Token = "0x17000012")]
		public int sortingOrder
		{
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x15C0D1C", Offset = "0x15C0D1C", Length = "0x94")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x15C0DB0", Offset = "0x15C0DB0", Length = "0xB4")]
			set
			{
			}
		}

		[Token(Token = "0x17000013")]
		public override bool autoSizeTextContainer
		{
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x15C0F70", Offset = "0x15C0F70", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000056")]
			[Address(RVA = "0x15C0F78", Offset = "0x15C0F78", Length = "0xA0")]
			set
			{
			}
		}

		[Obsolete("The TextContainer is now obsolete. Use the RectTransform instead.")]
		[Token(Token = "0x17000014")]
		public TextContainer textContainer
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x15C1018", Offset = "0x15C1018", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000015")]
		public new Transform transform
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x15C1020", Offset = "0x15C1020", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000016")]
		public Renderer renderer
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x15C0AC8", Offset = "0x15C0AC8", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000017")]
		public override Mesh mesh
		{
			[Token(Token = "0x600005A")]
			[Address(RVA = "0x15C10B4", Offset = "0x15C10B4", Length = "0xB0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000018")]
		public MeshFilter meshFilter
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x15C1164", Offset = "0x15C1164", Length = "0xFC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000019")]
		public MaskingTypes maskType
		{
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x15C1260", Offset = "0x15C1260", Length = "0x8")]
			get
			{
				return MaskingTypes.MaskOff;
			}
			[Token(Token = "0x600005D")]
			[Address(RVA = "0x15C1268", Offset = "0x15C1268", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x14000001")]
		public override event Action<TMP_TextInfo> OnPreRenderText
		{
			[CompilerGenerated]
			[Token(Token = "0x600006A")]
			[Address(RVA = "0x15C1E68", Offset = "0x15C1E68", Length = "0xB4")]
			add
			{
			}
			[CompilerGenerated]
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x15C1F1C", Offset = "0x15C1F1C", Length = "0xB4")]
			remove
			{
			}
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x15C13B8", Offset = "0x15C13B8", Length = "0x48")]
		public void SetMask(MaskingTypes type, Vector4 maskCoords)
		{
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x15C14A0", Offset = "0x15C14A0", Length = "0x60")]
		public void SetMask(MaskingTypes type, Vector4 maskCoords, float softnessX, float softnessY)
		{
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x15C15F0", Offset = "0x15C15F0", Length = "0xB0")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x15C16A0", Offset = "0x15C16A0", Length = "0xD0")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x15C1770", Offset = "0x15C1770", Length = "0x10")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x15C1780", Offset = "0x15C1780", Length = "0x44")]
		public override void SetAllDirty()
		{
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x15C17C4", Offset = "0x15C17C4", Length = "0xE8")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x15C1AF4", Offset = "0x15C1AF4", Length = "0x134")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x15C1C28", Offset = "0x15C1C28", Length = "0x100")]
		public override void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x15C1D28", Offset = "0x15C1D28", Length = "0x14")]
		public override void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false)
		{
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x15C1D3C", Offset = "0x15C1D3C", Length = "0x6C")]
		public override TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x15C1DA8", Offset = "0x15C1DA8", Length = "0xC0")]
		public override void ClearMesh(bool updateMesh)
		{
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x15C1FD0", Offset = "0x15C1FD0", Length = "0x18")]
		public override void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x15C1FE8", Offset = "0x15C1FE8", Length = "0x1A0")]
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x15C2188", Offset = "0x15C2188", Length = "0x1D0")]
		public override void UpdateVertexData()
		{
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x15C2358", Offset = "0x15C2358", Length = "0x10")]
		public void UpdateFontAsset()
		{
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x15C2368", Offset = "0x15C2368", Length = "0x4")]
		public void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x15C236C", Offset = "0x15C236C", Length = "0x4")]
		public void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x15C2370", Offset = "0x15C2370", Length = "0x3A0")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x15C2710", Offset = "0x15C2710", Length = "0xFC")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15C280C", Offset = "0x15C280C", Length = "0xAC")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15C28B8", Offset = "0x15C28B8", Length = "0xCC")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x15C2984", Offset = "0x15C2984", Length = "0x5E0")]
		protected override void LoadFontAsset()
		{
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x15C2F64", Offset = "0x15C2F64", Length = "0x274")]
		private void UpdateEnvMapMatrix()
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x15C1270", Offset = "0x15C1270", Length = "0x148")]
		private void SetMask(MaskingTypes maskType)
		{
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x15C1400", Offset = "0x15C1400", Length = "0xA0")]
		private void SetMaskCoordinates(Vector4 coords)
		{
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x15C1500", Offset = "0x15C1500", Length = "0xF0")]
		private void SetMaskCoordinates(Vector4 coords, float softX, float softY)
		{
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x15C31D8", Offset = "0x15C31D8", Length = "0xF8")]
		private void EnableMasking()
		{
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x15C3350", Offset = "0x15C3350", Length = "0xF4")]
		private void DisableMasking()
		{
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x15C32D0", Offset = "0x15C32D0", Length = "0x80")]
		private void UpdateMask()
		{
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x15C3508", Offset = "0x15C3508", Length = "0x110")]
		protected override Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x15C3618", Offset = "0x15C3618", Length = "0x1A8")]
		protected override Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x15C37C0", Offset = "0x15C37C0", Length = "0x38")]
		protected override void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x15C37F8", Offset = "0x15C37F8", Length = "0x190")]
		protected override Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x15C3988", Offset = "0x15C3988", Length = "0x368")]
		protected override void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x15C3CF0", Offset = "0x15C3CF0", Length = "0x12C")]
		protected override void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15C3E1C", Offset = "0x15C3E1C", Length = "0x128")]
		protected override void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x15C3F44", Offset = "0x15C3F44", Length = "0x128")]
		protected override void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x15C3444", Offset = "0x15C3444", Length = "0xC4")]
		private void CreateMaterialInstance()
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x15C406C", Offset = "0x15C406C", Length = "0xE8")]
		protected override void SetShaderDepth()
		{
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x15C4154", Offset = "0x15C4154", Length = "0x29C")]
		protected override void SetCulling()
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x15C43F0", Offset = "0x15C43F0", Length = "0x84")]
		private void SetPerspectiveCorrection()
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x15C4474", Offset = "0x15C4474", Length = "0x1B2C")]
		internal override int SetArraySizes(UnicodeChar[] unicodeChars)
		{
			return 0;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15C5FA0", Offset = "0x15C5FA0", Length = "0xDC")]
		public override void ComputeMarginSize()
		{
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x15C607C", Offset = "0x15C607C", Length = "0x1C")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x15C6098", Offset = "0x15C6098", Length = "0x30")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x15C60C8", Offset = "0x15C60C8", Length = "0x154")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x15C621C", Offset = "0x15C621C", Length = "0x9C")]
		internal override void InternalUpdate()
		{
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x15C18AC", Offset = "0x15C18AC", Length = "0x248")]
		private void OnPreRenderObject()
		{
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x15B0640", Offset = "0x15B0640", Length = "0x7260")]
		protected virtual void GenerateTextMesh()
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x15C6564", Offset = "0x15C6564", Length = "0x98")]
		protected override Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x15C65FC", Offset = "0x15C65FC", Length = "0x1C0")]
		private void SetMeshFilters(bool state)
		{
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x15C67BC", Offset = "0x15C67BC", Length = "0x110")]
		protected override void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x15C6434", Offset = "0x15C6434", Length = "0x130")]
		protected void SetActiveSubTextObjectRenderers(bool state)
		{
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x15C68CC", Offset = "0x15C68CC", Length = "0xDC")]
		protected override void DestroySubMeshObjects()
		{
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x15C0C10", Offset = "0x15C0C10", Length = "0x10C")]
		internal void UpdateSubMeshSortingLayerID(int id)
		{
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x15C0E64", Offset = "0x15C0E64", Length = "0x10C")]
		internal void UpdateSubMeshSortingOrder(int order)
		{
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x15C69A8", Offset = "0x15C69A8", Length = "0x1F0")]
		protected override Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x15C62B8", Offset = "0x15C62B8", Length = "0x17C")]
		private void UpdateSDFScale(float scaleDelta)
		{
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x15C6B98", Offset = "0x15C6B98", Length = "0xC0")]
		public TextMeshPro()
		{
		}
	}
}
