using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[ExecuteAlways]
	[AddComponentMenu("UI/TextMeshPro - Text (UI)", 11)]
	[RequireComponent(typeof(CanvasRenderer))]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0")]
	[Token(Token = "0x200000F")]
	public class TextMeshProUGUI : TMP_Text, ILayoutElement
	{
		[CompilerGenerated]
		[Token(Token = "0x2000010")]
		private sealed class _003CDelayedGraphicRebuild_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000083")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000084")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000085")]
			[FieldOffset(Offset = "0x20")]
			public TextMeshProUGUI _003C_003E4__this;

			[Token(Token = "0x1700001F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000E9")]
				[Address(RVA = "0x15CE360", Offset = "0x15CE360", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000020")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000EB")]
				[Address(RVA = "0x15CE3A0", Offset = "0x15CE3A0", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x15C7624", Offset = "0x15C7624", Length = "0x28")]
			public _003CDelayedGraphicRebuild_003Ed__18(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x15CE2A4", Offset = "0x15CE2A4", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x15CE2A8", Offset = "0x15CE2A8", Length = "0xB8")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x15CE368", Offset = "0x15CE368", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000011")]
		private sealed class _003CDelayedMaterialRebuild_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000086")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000087")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000088")]
			[FieldOffset(Offset = "0x20")]
			public TextMeshProUGUI _003C_003E4__this;

			[Token(Token = "0x17000021")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000EF")]
				[Address(RVA = "0x15CE46C", Offset = "0x15CE46C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000022")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000F1")]
				[Address(RVA = "0x15CE4AC", Offset = "0x15CE4AC", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x15C76AC", Offset = "0x15C76AC", Length = "0x28")]
			public _003CDelayedMaterialRebuild_003Ed__19(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x15CE3A8", Offset = "0x15CE3A8", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000EE")]
			[Address(RVA = "0x15CE3AC", Offset = "0x15CE3AC", Length = "0xC0")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x15CE474", Offset = "0x15CE474", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x6C8")]
		private bool m_isRebuildingLayout;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x6D0")]
		private Coroutine m_DelayedGraphicRebuild;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x6D8")]
		private Coroutine m_DelayedMaterialRebuild;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x6E0")]
		private Rect m_ClipRect;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x6F0")]
		private bool m_ValidRect;

		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x700")]
		private bool m_hasFontAssetChanged;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x708")]
		protected TMP_SubMeshUI[] m_subTextObjects;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x710")]
		private float m_previousLossyScaleY;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x718")]
		private Vector3[] m_RectTransformCorners;

		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x720")]
		private CanvasRenderer m_canvasRenderer;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x728")]
		private Canvas m_canvas;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x730")]
		private float m_CanvasScaleFactor;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x734")]
		private bool m_isFirstAllocation;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x738")]
		private int m_max_characters;

		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x740")]
		private Material m_baseMaterial;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x748")]
		private bool m_isScrollRegionSet;

		[SerializeField]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x74C")]
		private Vector4 m_maskOffset;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x75C")]
		private Matrix4x4 m_EnvMapMatrix;

		[NonSerialized]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x79C")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x400006F")]
		private static ProfilerMarker k_GenerateTextMarker;

		[Token(Token = "0x4000070")]
		private static ProfilerMarker k_SetArraySizesMarker;

		[Token(Token = "0x4000071")]
		private static ProfilerMarker k_GenerateTextPhaseIMarker;

		[Token(Token = "0x4000072")]
		private static ProfilerMarker k_ParseMarkupTextMarker;

		[Token(Token = "0x4000073")]
		private static ProfilerMarker k_CharacterLookupMarker;

		[Token(Token = "0x4000074")]
		private static ProfilerMarker k_HandleGPOSFeaturesMarker;

		[Token(Token = "0x4000075")]
		private static ProfilerMarker k_CalculateVerticesPositionMarker;

		[Token(Token = "0x4000076")]
		private static ProfilerMarker k_ComputeTextMetricsMarker;

		[Token(Token = "0x4000077")]
		private static ProfilerMarker k_HandleVisibleCharacterMarker;

		[Token(Token = "0x4000078")]
		private static ProfilerMarker k_HandleWhiteSpacesMarker;

		[Token(Token = "0x4000079")]
		private static ProfilerMarker k_HandleHorizontalLineBreakingMarker;

		[Token(Token = "0x400007A")]
		private static ProfilerMarker k_HandleVerticalLineBreakingMarker;

		[Token(Token = "0x400007B")]
		private static ProfilerMarker k_SaveGlyphVertexDataMarker;

		[Token(Token = "0x400007C")]
		private static ProfilerMarker k_ComputeCharacterAdvanceMarker;

		[Token(Token = "0x400007D")]
		private static ProfilerMarker k_HandleCarriageReturnMarker;

		[Token(Token = "0x400007E")]
		private static ProfilerMarker k_HandleLineTerminationMarker;

		[Token(Token = "0x400007F")]
		private static ProfilerMarker k_SavePageInfoMarker;

		[Token(Token = "0x4000080")]
		private static ProfilerMarker k_SaveProcessingStatesMarker;

		[Token(Token = "0x4000081")]
		private static ProfilerMarker k_GenerateTextPhaseIIMarker;

		[Token(Token = "0x4000082")]
		private static ProfilerMarker k_GenerateTextPhaseIIIMarker;

		[Token(Token = "0x1700001A")]
		public override Material materialForRendering
		{
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x15C7114", Offset = "0x15C7114", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001B")]
		public override bool autoSizeTextContainer
		{
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x15C7174", Offset = "0x15C7174", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x15C717C", Offset = "0x15C717C", Length = "0xA0")]
			set
			{
			}
		}

		[Token(Token = "0x1700001C")]
		public override Mesh mesh
		{
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x15C721C", Offset = "0x15C721C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001D")]
		public new CanvasRenderer canvasRenderer
		{
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x15C7224", Offset = "0x15C7224", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001E")]
		public Vector4 maskOffset
		{
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x15C7CF0", Offset = "0x15C7CF0", Length = "0x14")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x15C7D04", Offset = "0x15C7D04", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x14000002")]
		public override event Action<TMP_TextInfo> OnPreRenderText
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B9")]
			[Address(RVA = "0x15C89D0", Offset = "0x15C89D0", Length = "0xB4")]
			add
			{
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x15C8A84", Offset = "0x15C8A84", Length = "0xB4")]
			remove
			{
			}
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x15C72B8", Offset = "0x15C72B8", Length = "0x4")]
		public void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x15C72BC", Offset = "0x15C72BC", Length = "0x4")]
		public void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x15C72C0", Offset = "0x15C72C0", Length = "0xE4")]
		public override void SetVerticesDirty()
		{
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x15C73A4", Offset = "0x15C73A4", Length = "0xF0")]
		public override void SetLayoutDirty()
		{
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x15C7494", Offset = "0x15C7494", Length = "0xEC")]
		public override void SetMaterialDirty()
		{
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x15C7580", Offset = "0x15C7580", Length = "0x44")]
		public override void SetAllDirty()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedGraphicRebuild_003Ed__18))]
		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x15C75C4", Offset = "0x15C75C4", Length = "0x60")]
		private IEnumerator DelayedGraphicRebuild()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedMaterialRebuild_003Ed__19))]
		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15C764C", Offset = "0x15C764C", Length = "0x60")]
		private IEnumerator DelayedMaterialRebuild()
		{
			return null;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x15C76D4", Offset = "0x15C76D4", Length = "0xE8")]
		public override void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15C7A30", Offset = "0x15C7A30", Length = "0xD4")]
		private void UpdateSubObjectPivot()
		{
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x15C7B04", Offset = "0x15C7B04", Length = "0x100")]
		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x15C7C04", Offset = "0x15C7C04", Length = "0xEC")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15C8048", Offset = "0x15C8048", Length = "0x8")]
		public override void RecalculateClipping()
		{
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x15C8050", Offset = "0x15C8050", Length = "0x27C")]
		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x15C82CC", Offset = "0x15C82CC", Length = "0x21C")]
		internal override void UpdateCulling()
		{
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15C84E8", Offset = "0x15C84E8", Length = "0x100")]
		public override void UpdateMeshPadding()
		{
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x15C85E8", Offset = "0x15C85E8", Length = "0xCC")]
		protected override void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x15C86B4", Offset = "0x15C86B4", Length = "0x9C")]
		protected override void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15C8750", Offset = "0x15C8750", Length = "0xA8")]
		public override void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false)
		{
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15C87F8", Offset = "0x15C87F8", Length = "0xE8")]
		public override TMP_TextInfo GetTextInfo(string text)
		{
			return null;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15C88E0", Offset = "0x15C88E0", Length = "0xF0")]
		public override void ClearMesh()
		{
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15C8B38", Offset = "0x15C8B38", Length = "0x78")]
		public override void UpdateGeometry(Mesh mesh, int index)
		{
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15C8BB0", Offset = "0x15C8BB0", Length = "0x1E4")]
		public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags)
		{
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15C8D94", Offset = "0x15C8D94", Length = "0x214")]
		public override void UpdateVertexData()
		{
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x15C8FA8", Offset = "0x15C8FA8", Length = "0x10")]
		public void UpdateFontAsset()
		{
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x15C8FB8", Offset = "0x15C8FB8", Length = "0x380")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15C9338", Offset = "0x15C9338", Length = "0x130")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x15C95CC", Offset = "0x15C95CC", Length = "0x1A4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x15C9770", Offset = "0x15C9770", Length = "0x15C")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x15C98CC", Offset = "0x15C98CC", Length = "0x530")]
		protected override void LoadFontAsset()
		{
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x15C9468", Offset = "0x15C9468", Length = "0x164")]
		private Canvas GetCanvas()
		{
			return null;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x15C9DFC", Offset = "0x15C9DFC", Length = "0x274")]
		private void UpdateEnvMapMatrix()
		{
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x15CA070", Offset = "0x15CA070", Length = "0x1A4")]
		private void EnableMasking()
		{
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x15CA214", Offset = "0x15CA214", Length = "0x4")]
		private void DisableMasking()
		{
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15C7D30", Offset = "0x15C7D30", Length = "0x318")]
		private void UpdateMask()
		{
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x15CA218", Offset = "0x15CA218", Length = "0x144")]
		protected override Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15CA35C", Offset = "0x15CA35C", Length = "0x1B0")]
		protected override Material[] GetMaterials(Material[] mats)
		{
			return null;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x15CA50C", Offset = "0x15CA50C", Length = "0x38")]
		protected override void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x15CA544", Offset = "0x15CA544", Length = "0x190")]
		protected override Material[] GetSharedMaterials()
		{
			return null;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x15CA6D4", Offset = "0x15CA6D4", Length = "0x3AC")]
		protected override void SetSharedMaterials(Material[] materials)
		{
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x15CAA80", Offset = "0x15CAA80", Length = "0x1C0")]
		protected override void SetOutlineThickness(float thickness)
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x15CAC40", Offset = "0x15CAC40", Length = "0x130")]
		protected override void SetFaceColor(Color32 color)
		{
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x15CAD70", Offset = "0x15CAD70", Length = "0x130")]
		protected override void SetOutlineColor(Color32 color)
		{
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x15CAEA0", Offset = "0x15CAEA0", Length = "0x12C")]
		protected override void SetShaderDepth()
		{
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x15CAFCC", Offset = "0x15CAFCC", Length = "0x2C8")]
		protected override void SetCulling()
		{
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x15CB294", Offset = "0x15CB294", Length = "0x84")]
		private void SetPerspectiveCorrection()
		{
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x15CB318", Offset = "0x15CB318", Length = "0xAC")]
		private void SetMeshArrays(int size)
		{
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x15CB3C4", Offset = "0x15CB3C4", Length = "0x1C4C")]
		internal override int SetArraySizes(UnicodeChar[] unicodeChars)
		{
			return 0;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x15CD010", Offset = "0x15CD010", Length = "0xDC")]
		public override void ComputeMarginSize()
		{
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x15CD0EC", Offset = "0x15CD0EC", Length = "0x38")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x15CD124", Offset = "0x15CD124", Length = "0x120")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x15CD244", Offset = "0x15CD244", Length = "0x44")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x15CD288", Offset = "0x15CD288", Length = "0x1D0")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x15CD458", Offset = "0x15CD458", Length = "0x9C")]
		internal override void InternalUpdate()
		{
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x15C77BC", Offset = "0x15C77BC", Length = "0x274")]
		private void OnPreRenderCanvas()
		{
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x15B78A0", Offset = "0x15B78A0", Length = "0x7550")]
		protected virtual void GenerateTextMesh()
		{
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x15CD6FC", Offset = "0x15CD6FC", Length = "0x98")]
		protected override Vector3[] GetTextContainerLocalCorners()
		{
			return null;
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x15CD794", Offset = "0x15CD794", Length = "0x110")]
		protected override void SetActiveSubMeshes(bool state)
		{
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x15CD8A4", Offset = "0x15CD8A4", Length = "0xDC")]
		protected override void DestroySubMeshObjects()
		{
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x15CD980", Offset = "0x15CD980", Length = "0x1F0")]
		protected override Bounds GetCompoundBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x15CDB70", Offset = "0x15CDB70", Length = "0x1C0")]
		internal override Rect GetCanvasSpaceClippingRect()
		{
			return default(Rect);
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x15CD4F4", Offset = "0x15CD4F4", Length = "0x208")]
		private void UpdateSDFScale(float scaleDelta)
		{
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x15CDD30", Offset = "0x15CDD30", Length = "0xB8")]
		public TextMeshProUGUI()
		{
		}
	}
}
