using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.UText.Runtime.Layout;
using Unco.UText.Runtime.Rendering;
using UnityEngine;

namespace Unco.UText.Runtime.Components
{
	[ExecuteAlways]
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	[Token(Token = "0x20007C1")]
	public class UText : MonoBehaviour, IRichTextStyleRegistry, IRichTextSpriteRegistry
	{
		[Token(Token = "0x40019DB")]
		private static readonly int MainTexId;

		[Token(Token = "0x40019DC")]
		private static Shader Shader;

		[Token(Token = "0x40019DD")]
		private static Shader SpriteShaderInstance;

		[SerializeField]
		[Multiline(6)]
		[Token(Token = "0x40019DE")]
		[FieldOffset(Offset = "0x20")]
		private string m_text;

		[SerializeField]
		[Token(Token = "0x40019DF")]
		[FieldOffset(Offset = "0x28")]
		private UTextFont m_font;

		[SerializeField]
		[Token(Token = "0x40019E0")]
		[FieldOffset(Offset = "0x30")]
		private UTextStyle m_style;

		[SerializeField]
		[Token(Token = "0x40019E1")]
		[FieldOffset(Offset = "0x38")]
		private LayoutSettings m_layoutSettings;

		[SerializeField]
		[Tooltip("When true, the Color field on this component replaces UTextStyle.FillColor at draw time. Effects + shadow still come from the style. Lets a single style asset drive many components that just need a different tint.")]
		[Token(Token = "0x40019E2")]
		[FieldOffset(Offset = "0x60")]
		private bool m_overrideFillColor;

		[SerializeField]
		[Token(Token = "0x40019E3")]
		[FieldOffset(Offset = "0x64")]
		private Color m_color;

		[SerializeField]
		[Tooltip("Per-component overrides for <style=Name> rich-text tags. Resolved before Resources/UTextStyles/<Name>.")]
		[Token(Token = "0x40019E4")]
		[FieldOffset(Offset = "0x78")]
		private StyleRegistryEntry[] m_styleOverrides;

		[SerializeField]
		[Tooltip("Per-component overrides for <sprite=...> rich-text tags. Resolved before Resources/UTextSpriteAtlas (default) or Resources/UTextSpriteAtlases/<AtlasName>.")]
		[Token(Token = "0x40019E5")]
		[FieldOffset(Offset = "0x80")]
		private SpriteRegistryEntry[] m_spriteOverrides;

		[SerializeField]
		[Tooltip("World-space bounds used by Auto Size to pick the largest font size that fits. Centered at the GameObject's local origin. Ignored when Auto Size is off.")]
		[Token(Token = "0x40019E6")]
		[FieldOffset(Offset = "0x88")]
		private Vector2 m_autoSizeRect;

		[Token(Token = "0x40019E7")]
		[FieldOffset(Offset = "0x90")]
		private float _lastComputedFontSize;

		[Token(Token = "0x40019E8")]
		[FieldOffset(Offset = "0x98")]
		private MeshFilter _meshFilter;

		[Token(Token = "0x40019E9")]
		[FieldOffset(Offset = "0xA0")]
		private MeshRenderer _meshRenderer;

		[Token(Token = "0x40019EA")]
		[FieldOffset(Offset = "0xA8")]
		private Mesh _mesh;

		[Token(Token = "0x40019EB")]
		[FieldOffset(Offset = "0xB0")]
		private Material _material;

		[Token(Token = "0x40019EC")]
		[FieldOffset(Offset = "0xB8")]
		private UTextSdfFontAsset _resolvedAtlas;

		[Token(Token = "0x40019ED")]
		[FieldOffset(Offset = "0xC0")]
		private Dictionary<UTextSpriteAsset, Material> _spriteMaterials;

		[Token(Token = "0x40019EE")]
		[FieldOffset(Offset = "0xC8")]
		private Material[] _materialBuffer;

		[Token(Token = "0x40019EF")]
		[FieldOffset(Offset = "0xD0")]
		private int[] _triBuffer;

		[Token(Token = "0x1700032D")]
		public Color Color
		{
			[Token(Token = "0x6002095")]
			[Address(RVA = "0x3DA25A8", Offset = "0x3DA25A8", Length = "0xFC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UText::get_Color");
				return default;
			}
			[Token(Token = "0x6002096")]
			[Address(RVA = "0x3DA26A4", Offset = "0x3DA26A4", Length = "0x9C")]
			set
			{
				float num = m_color.r - value.r;
				float num2 = m_color.g - value.g;
				float num3 = m_color.b - value.b;
				float num4 = m_color.a - value.a;
				float num5 = num * num;
				float num6 = num2 * num2;
				float num7 = num5 + num6;
				float num8 = num3 * num3;
				float num9 = num8 + num7;
				float num10 = num4 * num4;
				float num11 = num10 + num9;
				if (!(num11 < 9.9999994E-11f))
				{
					m_overrideFillColor = true;
				}
				m_color.r = value.r;
				m_color.g = value.g;
				m_color.b = value.b;
				m_color.a = value.a;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x600208F")]
		[Address(RVA = "0x3DA2568", Offset = "0x3DA2568", Length = "0x8")]
		public string GetText()
		{
			return m_text;
		}

		[Token(Token = "0x6002090")]
		[Address(RVA = "0x3DA2570", Offset = "0x3DA2570", Length = "0x8")]
		public UTextFont GetFont()
		{
			return m_font;
		}

		[Token(Token = "0x6002091")]
		[Address(RVA = "0x3DA2578", Offset = "0x3DA2578", Length = "0x8")]
		public UTextStyle GetStyle()
		{
			return m_style;
		}

		[Token(Token = "0x6002092")]
		[Address(RVA = "0x3DA2580", Offset = "0x3DA2580", Length = "0x18")]
		public LayoutSettings GetLayoutSettings()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::GetLayoutSettings");
			return default;
		}

		[Token(Token = "0x6002093")]
		[Address(RVA = "0x3DA2598", Offset = "0x3DA2598", Length = "0x8")]
		public Vector2 GetAutoSizeRect()
		{
			return m_autoSizeRect;
		}

		[Token(Token = "0x6002094")]
		[Address(RVA = "0x3DA25A0", Offset = "0x3DA25A0", Length = "0x8")]
		public float GetLastComputedFontSize()
		{
			return _lastComputedFontSize;
		}

		[Token(Token = "0x6002097")]
		[Address(RVA = "0x3DA2778", Offset = "0x3DA2778", Length = "0x70")]
		public void SetText(string value)
		{
			if (!(m_text == value))
			{
				m_text = value;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x6002098")]
		[Address(RVA = "0x3DA27E8", Offset = "0x3DA27E8", Length = "0xE8")]
		public void SetFont(UTextFont value)
		{
			if (!(m_font == value))
			{
				m_font = value;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x6002099")]
		[Address(RVA = "0x3DA28D0", Offset = "0x3DA28D0", Length = "0xE8")]
		public void SetStyle(UTextStyle value)
		{
			if (!(m_style == value))
			{
				m_style = value;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x600209A")]
		[Address(RVA = "0x3DA29B8", Offset = "0x3DA29B8", Length = "0x120")]
		public void SetLayoutSettings(LayoutSettings value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::SetLayoutSettings");
		}

		[Token(Token = "0x600209B")]
		[Address(RVA = "0x3DA2AD8", Offset = "0x3DA2AD8", Length = "0x48")]
		public void SetOverrideFillColor(bool value)
		{
			if (m_overrideFillColor != value)
			{
				m_overrideFillColor = value;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x600209C")]
		[Address(RVA = "0x3DA2B20", Offset = "0x3DA2B20", Length = "0x68")]
		public void SetAutoSizeRect(Vector2 value)
		{
			float num = m_autoSizeRect.x - value.x;
			float num2 = m_autoSizeRect.y - value.y;
			float num3 = num * num;
			float num4 = num2 * num2;
			float num5 = num3 + num4;
			if (!(num5 < 9.9999994E-11f))
			{
				m_autoSizeRect.x = value.x;
				m_autoSizeRect.y = value.y;
				if (base.isActiveAndEnabled)
				{
					Rebuild();
				}
			}
		}

		[Token(Token = "0x600209D")]
		[Address(RVA = "0x3DA2B88", Offset = "0x3DA2B88", Length = "0x1A4")]
		private void OnEnable()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			_meshFilter = component;
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			_meshRenderer = component2;
			HideCompanionComponents();
			EnsureMaterial();
			if (!(_mesh == null))
			{
				Rebuild();
				return;
			}
			Mesh mesh = new Mesh();
			mesh.name = "UText";
			mesh.hideFlags = HideFlags.DontSave;
			_mesh = mesh;
			_mesh.MarkDynamic();
			Rebuild();
		}

		[Token(Token = "0x600209E")]
		[Address(RVA = "0x3DA3734", Offset = "0x3DA3734", Length = "0x4")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x600209F")]
		[Address(RVA = "0x3DA3738", Offset = "0x3DA3738", Length = "0x3C8")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::OnDestroy");
		}

		[Token(Token = "0x60020A0")]
		[Address(RVA = "0x3DA2740", Offset = "0x3DA2740", Length = "0x38")]
		public void MarkDirty()
		{
			if (base.isActiveAndEnabled)
			{
				Rebuild();
			}
		}

		[Token(Token = "0x60020A1")]
		[Address(RVA = "0x3DA31D4", Offset = "0x3DA31D4", Length = "0x560")]
		private unsafe void Rebuild()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::Rebuild");
		}

		[Token(Token = "0x60020A2")]
		[Address(RVA = "0x3DA3B00", Offset = "0x3DA3B00", Length = "0x25C")]
		private unsafe void AssignSubmeshMaterials(TextMeshBuilder.Result result, int subMeshCount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::AssignSubmeshMaterials");
		}

		[Token(Token = "0x60020A3")]
		[Address(RVA = "0x3DA3D5C", Offset = "0x3DA3D5C", Length = "0x4A0")]
		private unsafe Material ResolveSpriteMaterial(TextMeshBuilder.SubMeshRange range)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::ResolveSpriteMaterial");
			return default;
		}

		[Token(Token = "0x60020A4")]
		[Address(RVA = "0x3DA2E68", Offset = "0x3DA2E68", Length = "0x36C")]
		private void EnsureMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UText::EnsureMaterial");
		}

		[Token(Token = "0x60020A5")]
		[Address(RVA = "0x3DA2D2C", Offset = "0x3DA2D2C", Length = "0x13C")]
		private void HideCompanionComponents()
		{
			UnityEngine.Object meshRenderer;
			if (!(_meshFilter != null))
			{
				meshRenderer = _meshRenderer;
			}
			else
			{
				HideFlags hideFlags = _meshFilter.hideFlags;
				HideFlags hideFlags2 = hideFlags | HideFlags.HideInInspector;
				_meshFilter.hideFlags = hideFlags2;
				meshRenderer = _meshRenderer;
			}
			if (meshRenderer != null)
			{
				HideFlags hideFlags3 = _meshRenderer.hideFlags;
				HideFlags hideFlags4 = hideFlags3 | HideFlags.HideInInspector;
				_meshRenderer.hideFlags = hideFlags4;
			}
		}

		[Token(Token = "0x60020A6")]
		[Address(RVA = "0x3DA41FC", Offset = "0x3DA41FC", Length = "0x10")]
		bool IRichTextStyleRegistry.TryResolve(string name, out UTextStyle style)
		{
			style = null;
			return RichTextRegistryResolver.ResolveStyle(name, m_styleOverrides, out style);
		}

		[Token(Token = "0x60020A7")]
		[Address(RVA = "0x3DA420C", Offset = "0x3DA420C", Length = "0x10")]
		bool IRichTextSpriteRegistry.TryResolveByName(string name, out int atlasIndex, out int entryIndex, out UTextSpriteAsset atlas)
		{
			atlasIndex = default(int);
			entryIndex = default(int);
			atlas = null;
			return RichTextRegistryResolver.ResolveSpriteByName(name, m_spriteOverrides, out atlasIndex, out entryIndex, out atlas);
		}

		[Token(Token = "0x60020A8")]
		[Address(RVA = "0x3DA421C", Offset = "0x3DA421C", Length = "0x14")]
		bool IRichTextSpriteRegistry.TryResolveByIndex(string atlasName, int entryIndex, out int atlasIndex, out UTextSpriteAsset atlas)
		{
			atlasIndex = default(int);
			atlas = null;
			return RichTextRegistryResolver.ResolveSpriteByIndex(atlasName, entryIndex, m_spriteOverrides, out atlasIndex, out atlas);
		}

		[Token(Token = "0x60020A9")]
		[Address(RVA = "0x3DA4230", Offset = "0x3DA4230", Length = "0x94")]
		public UText()
		{
			m_text = "UText";
			m_layoutSettings.FontSize = 1f;
			m_layoutSettings.Bold = false;
			m_layoutSettings.LetterSpacing = 0f;
			m_layoutSettings.Wrap = false;
			m_layoutSettings.MinFontSize = 0f;
			m_color = default(Color);
			m_autoSizeRect = default(Vector2);
		}

		[Token(Token = "0x60020AA")]
		[Address(RVA = "0x3DA42C4", Offset = "0x3DA42C4", Length = "0x74")]
		static UText()
		{
			int mainTexId = Shader.PropertyToID("_MainTex");
			MainTexId = mainTexId;
		}
	}
}
