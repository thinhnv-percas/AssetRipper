using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.UText.Runtime.Layout;
using Unco.UText.Runtime.Rendering;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.UText.Runtime.Components
{
	[ExecuteAlways]
	[AddComponentMenu("UI/UText GUI")]
	[RequireComponent(typeof(CanvasRenderer))]
	[Token(Token = "0x20007C2")]
	public class UTextGUI : MaskableGraphic, IRichTextStyleRegistry, IRichTextSpriteRegistry
	{
		[Token(Token = "0x40019F0")]
		private static Shader UiShader;

		[Token(Token = "0x40019F1")]
		private static Material SharedMaterial;

		[SerializeField]
		[Multiline(6)]
		[Token(Token = "0x40019F2")]
		[FieldOffset(Offset = "0xD8")]
		internal string m_text;

		[SerializeField]
		[Token(Token = "0x40019F3")]
		[FieldOffset(Offset = "0xE0")]
		private UTextFont m_font;

		[SerializeField]
		[Token(Token = "0x40019F4")]
		[FieldOffset(Offset = "0xE8")]
		private UTextStyle m_style;

		[SerializeField]
		[Token(Token = "0x40019F5")]
		[FieldOffset(Offset = "0xF0")]
		private LayoutSettings m_layoutSettings;

		[SerializeField]
		[Tooltip("When true, the Graphic.color on this component replaces UTextStyle.FillColor at draw time. Effects + shadow still come from the style. Lets a single style asset drive many components that just need a different tint.")]
		[Token(Token = "0x40019F6")]
		[FieldOffset(Offset = "0x118")]
		private bool m_overrideFillColor;

		[SerializeField]
		[Tooltip("Per-component overrides for <style=Name> rich-text tags. Resolved before Resources/UTextStyles/<Name>.")]
		[Token(Token = "0x40019F7")]
		[FieldOffset(Offset = "0x120")]
		private StyleRegistryEntry[] m_styleOverrides;

		[SerializeField]
		[Tooltip("Per-component overrides for <sprite=...> rich-text tags. Resolved before Resources/UTextSpriteAtlas (default) or Resources/UTextSpriteAtlases/<AtlasName>.")]
		[Token(Token = "0x40019F8")]
		[FieldOffset(Offset = "0x128")]
		private SpriteRegistryEntry[] m_spriteOverrides;

		[Token(Token = "0x40019F9")]
		[FieldOffset(Offset = "0x130")]
		private UTextGUISubmeshPool _submeshPool;

		[Token(Token = "0x40019FA")]
		[FieldOffset(Offset = "0x138")]
		private float _lastComputedFontSize;

		[Token(Token = "0x40019FB")]
		[FieldOffset(Offset = "0x140")]
		private UTextSdfFontAsset _resolvedAtlas;

		[Token(Token = "0x1700032E")]
		public override Color color
		{
			[Token(Token = "0x60020B0")]
			[Address(RVA = "0x3DBAE34", Offset = "0x3DBAE34", Length = "0x74")]
			get
			{
				if (m_overrideFillColor)
				{
					return color;
				}
				UTextStyle orDefault = UTextStyle.GetOrDefault(m_style);
				return orDefault.FillColor;
			}
			[Token(Token = "0x60020B1")]
			[Address(RVA = "0x3DBAEA8", Offset = "0x3DBAEA8", Length = "0x58")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::set_color");
			}
		}

		[Token(Token = "0x1700032F")]
		public override Texture mainTexture
		{
			[Token(Token = "0x60020B2")]
			[Address(RVA = "0x3DBAF00", Offset = "0x3DBAF00", Length = "0x104")]
			get
			{
				if (_resolvedAtlas != null)
				{
					UTextSdfFontAsset resolvedAtlas = _resolvedAtlas;
					if (resolvedAtlas.AtlasTexture != null)
					{
						UTextSdfFontAsset resolvedAtlas2 = _resolvedAtlas;
						return resolvedAtlas2.AtlasTexture;
					}
				}
				return Texture2D.whiteTexture;
			}
		}

		[Token(Token = "0x60020AB")]
		[Address(RVA = "0x3DBAE00", Offset = "0x3DBAE00", Length = "0x8")]
		public string GetText()
		{
			return m_text;
		}

		[Token(Token = "0x60020AC")]
		[Address(RVA = "0x3DBAE08", Offset = "0x3DBAE08", Length = "0x8")]
		public UTextFont GetFont()
		{
			return m_font;
		}

		[Token(Token = "0x60020AD")]
		[Address(RVA = "0x3DBAE10", Offset = "0x3DBAE10", Length = "0x8")]
		public UTextStyle GetStyle()
		{
			return m_style;
		}

		[Token(Token = "0x60020AE")]
		[Address(RVA = "0x3DBAE18", Offset = "0x3DBAE18", Length = "0x14")]
		public LayoutSettings GetLayoutSettings()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::GetLayoutSettings");
			return default;
		}

		[Token(Token = "0x60020AF")]
		[Address(RVA = "0x3DBAE2C", Offset = "0x3DBAE2C", Length = "0x8")]
		public float GetLastComputedFontSize()
		{
			return _lastComputedFontSize;
		}

		[Token(Token = "0x60020B3")]
		[Address(RVA = "0x3DBB004", Offset = "0x3DBB004", Length = "0x60")]
		public void SetText(string value)
		{
			if (!(m_text == value))
			{
				m_text = value;
				MarkDirty();
			}
		}

		[Token(Token = "0x60020B4")]
		[Address(RVA = "0x3DBB138", Offset = "0x3DBB138", Length = "0xD4")]
		public void SetFont(UTextFont value)
		{
			if (!(m_font == value))
			{
				m_font = value;
				MarkDirty();
			}
		}

		[Token(Token = "0x60020B5")]
		[Address(RVA = "0x3DBB20C", Offset = "0x3DBB20C", Length = "0xD4")]
		public void SetStyle(UTextStyle value)
		{
			if (!(m_style == value))
			{
				m_style = value;
				MarkDirty();
			}
		}

		[Token(Token = "0x60020B6")]
		[Address(RVA = "0x3DBB2E0", Offset = "0x3DBB2E0", Length = "0x64")]
		public unsafe void SetLayoutSettings(LayoutSettings value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::SetLayoutSettings");
		}

		[Token(Token = "0x60020B7")]
		[Address(RVA = "0x3DBB344", Offset = "0x3DBB344", Length = "0x18")]
		public void SetOverrideFillColor(bool value)
		{
			if (m_overrideFillColor != value)
			{
				m_overrideFillColor = value;
				MarkDirty();
			}
		}

		[Token(Token = "0x60020B8")]
		[Address(RVA = "0x3DBB35C", Offset = "0x3DBB35C", Length = "0x5C")]
		protected override void OnEnable()
		{
			base.OnEnable();
			EnsureMaterial();
			EnsureCanvasChannels();
			UTextSdfFontAsset resolvedAtlas = ResolveAtlas();
			_resolvedAtlas = resolvedAtlas;
			UTextGUI uTextGUI = default(UTextGUI);
			uTextGUI.SetAllDirty();
		}

		[Token(Token = "0x60020B9")]
		[Address(RVA = "0x3DBB824", Offset = "0x3DBB824", Length = "0x48")]
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_submeshPool != null)
			{
				_submeshPool.Dispose();
				_submeshPool = null;
			}
		}

		[Token(Token = "0x60020BA")]
		[Address(RVA = "0x3DBB9A8", Offset = "0x3DBB9A8", Length = "0x38")]
		protected override void OnDisable()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::OnDisable");
		}

		[Token(Token = "0x60020BB")]
		[Address(RVA = "0x3DBB670", Offset = "0x3DBB670", Length = "0xF4")]
		private void EnsureCanvasChannels()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192471040;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E0DD]");
			Canvas canvas2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Canvas canvas = base.canvas;
				canvas2 = canvas;
			}
			else
			{
				_ = 1;
				Canvas canvas3 = base.canvas;
				canvas2 = canvas3;
			}
			if (!(canvas2 == null))
			{
				AdditionalCanvasShaderChannels additionalShaderChannels = canvas2.additionalShaderChannels;
				if ((additionalShaderChannels & AdditionalCanvasShaderChannels.TexCoord1) == 0)
				{
					AdditionalCanvasShaderChannels additionalShaderChannels2 = canvas2.additionalShaderChannels;
					AdditionalCanvasShaderChannels additionalShaderChannels3 = additionalShaderChannels2 | AdditionalCanvasShaderChannels.TexCoord1;
					canvas2.additionalShaderChannels = additionalShaderChannels3;
				}
			}
		}

		[Token(Token = "0x60020BC")]
		[Address(RVA = "0x3DBBB20", Offset = "0x3DBBB20", Length = "0x28")]
		protected override void OnCanvasHierarchyChanged()
		{
			base.OnCanvasHierarchyChanged();
			EnsureCanvasChannels();
		}

		[Token(Token = "0x60020BD")]
		[Address(RVA = "0x3DBBB48", Offset = "0x3DBBB48", Length = "0x28")]
		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			EnsureCanvasChannels();
		}

		[Token(Token = "0x60020BE")]
		[Address(RVA = "0x3DBBB70", Offset = "0x3DBBB70", Length = "0x34")]
		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UTextGUI uTextGUI = default(UTextGUI);
			uTextGUI.SetVerticesDirty();
		}

		[Token(Token = "0x60020BF")]
		[Address(RVA = "0x3DBB764", Offset = "0x3DBB764", Length = "0xC0")]
		private UTextSdfFontAsset ResolveAtlas()
		{
			UTextFont orDefault = UTextFont.GetOrDefault(m_font);
			if (orDefault == null)
			{
				return null;
			}
			return orDefault.ResolveAtlas(m_layoutSettings.Bold, m_layoutSettings.Italic);
		}

		[Token(Token = "0x60020C0")]
		[Address(RVA = "0x3DBBBA4", Offset = "0x3DBBBA4", Length = "0x758")]
		protected unsafe override void OnPopulateMesh(VertexHelper vh)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::OnPopulateMesh");
		}

		[Token(Token = "0x60020C1")]
		[Address(RVA = "0x3DBB064", Offset = "0x3DBB064", Length = "0xD4")]
		public void MarkDirty()
		{
			if ((bool)this && base.isActiveAndEnabled)
			{
				UTextSdfFontAsset resolvedAtlas = ResolveAtlas();
				_resolvedAtlas = resolvedAtlas;
				UTextGUI uTextGUI = default(UTextGUI);
				uTextGUI.SetAllDirty();
			}
		}

		[Token(Token = "0x60020C2")]
		[Address(RVA = "0x3DBB3B8", Offset = "0x3DBB3B8", Length = "0x2B8")]
		private void EnsureMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextGUI::EnsureMaterial");
		}

		[Token(Token = "0x60020C3")]
		[Address(RVA = "0x3DBC938", Offset = "0x3DBC938", Length = "0x14")]
		bool IRichTextStyleRegistry.TryResolve(string name, out UTextStyle style)
		{
			style = null;
			return RichTextRegistryResolver.ResolveStyle(name, m_styleOverrides, out style);
		}

		[Token(Token = "0x60020C4")]
		[Address(RVA = "0x3DBC94C", Offset = "0x3DBC94C", Length = "0x14")]
		bool IRichTextSpriteRegistry.TryResolveByName(string name, out int atlasIndex, out int entryIndex, out UTextSpriteAsset atlas)
		{
			atlasIndex = default(int);
			entryIndex = default(int);
			atlas = null;
			return RichTextRegistryResolver.ResolveSpriteByName(name, m_spriteOverrides, out atlasIndex, out entryIndex, out atlas);
		}

		[Token(Token = "0x60020C5")]
		[Address(RVA = "0x3DBC960", Offset = "0x3DBC960", Length = "0x18")]
		bool IRichTextSpriteRegistry.TryResolveByIndex(string atlasName, int entryIndex, out int atlasIndex, out UTextSpriteAsset atlas)
		{
			atlasIndex = default(int);
			atlas = null;
			return RichTextRegistryResolver.ResolveSpriteByIndex(atlasName, entryIndex, m_spriteOverrides, out atlasIndex, out atlas);
		}

		[Token(Token = "0x60020C6")]
		[Address(RVA = "0x3DBC978", Offset = "0x3DBC978", Length = "0xA8")]
		public UTextGUI()
		{
			m_text = "UText";
			LayoutSettings layoutSettings = new LayoutSettings(1f, 0f, 0f, 0f);
			m_layoutSettings = layoutSettings;
			m_layoutSettings.WordSpacing = 0f;
			m_layoutSettings.MinFontSize = 0f;
		}
	}
}
