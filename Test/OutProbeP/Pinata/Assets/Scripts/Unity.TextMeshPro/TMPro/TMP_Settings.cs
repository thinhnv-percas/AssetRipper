using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200003B")]
	public class TMP_Settings : ScriptableObject
	{
		[Token(Token = "0x2000095")]
		public class LineBreakingTable
		{
			[Token(Token = "0x40004E5")]
			[FieldOffset(Offset = "0x10")]
			public Dictionary<int, char> leadingCharacters;

			[Token(Token = "0x40004E6")]
			[FieldOffset(Offset = "0x18")]
			public Dictionary<int, char> followingCharacters;

			[Token(Token = "0x600059E")]
			[Address(RVA = "0x93B860", Offset = "0x93B860", Length = "0x8")]
			public LineBreakingTable()
			{
			}
		}

		[Token(Token = "0x4000202")]
		private static TMP_Settings s_Instance;

		[SerializeField]
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x18")]
		private bool m_enableWordWrapping;

		[SerializeField]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x19")]
		private bool m_enableKerning;

		[SerializeField]
		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x1A")]
		private bool m_enableExtraPadding;

		[SerializeField]
		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x1B")]
		private bool m_enableTintAllSprites;

		[SerializeField]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x1C")]
		private bool m_enableParseEscapeCharacters;

		[SerializeField]
		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x1D")]
		private bool m_EnableRaycastTarget;

		[SerializeField]
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x1E")]
		private bool m_GetFontFeaturesAtRuntime;

		[SerializeField]
		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x20")]
		private int m_missingGlyphCharacter;

		[SerializeField]
		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x24")]
		private bool m_warningsDisabled;

		[SerializeField]
		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x28")]
		private TMP_FontAsset m_defaultFontAsset;

		[SerializeField]
		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x30")]
		private string m_defaultFontAssetPath;

		[SerializeField]
		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x38")]
		private float m_defaultFontSize;

		[SerializeField]
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x3C")]
		private float m_defaultAutoSizeMinRatio;

		[SerializeField]
		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x40")]
		private float m_defaultAutoSizeMaxRatio;

		[SerializeField]
		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x44")]
		private Vector2 m_defaultTextMeshProTextContainerSize;

		[SerializeField]
		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x4C")]
		private Vector2 m_defaultTextMeshProUITextContainerSize;

		[SerializeField]
		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x54")]
		private bool m_autoSizeTextContainer;

		[SerializeField]
		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x58")]
		private List<TMP_FontAsset> m_fallbackFontAssets;

		[SerializeField]
		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x60")]
		private bool m_matchMaterialPreset;

		[SerializeField]
		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x68")]
		private TMP_SpriteAsset m_defaultSpriteAsset;

		[SerializeField]
		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x70")]
		private string m_defaultSpriteAssetPath;

		[SerializeField]
		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x78")]
		private string m_defaultColorGradientPresetsPath;

		[SerializeField]
		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x80")]
		private bool m_enableEmojiSupport;

		[SerializeField]
		[Token(Token = "0x400021A")]
		[FieldOffset(Offset = "0x88")]
		private TMP_StyleSheet m_defaultStyleSheet;

		[SerializeField]
		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x90")]
		private TextAsset m_leadingCharacters;

		[SerializeField]
		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x98")]
		private TextAsset m_followingCharacters;

		[SerializeField]
		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0xA0")]
		private LineBreakingTable m_linebreakingRules;

		[Token(Token = "0x1700009B")]
		public static string version
		{
			[Token(Token = "0x60002F6")]
			[Address(RVA = "0x93AF44", Offset = "0x93AF44", Length = "0x48")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700009C")]
		public static bool enableWordWrapping
		{
			[Token(Token = "0x60002F7")]
			[Address(RVA = "0x93AF8C", Offset = "0x93AF8C", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009D")]
		public static bool enableKerning
		{
			[Token(Token = "0x60002F8")]
			[Address(RVA = "0x93B064", Offset = "0x93B064", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009E")]
		public static bool enableExtraPadding
		{
			[Token(Token = "0x60002F9")]
			[Address(RVA = "0x93B084", Offset = "0x93B084", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700009F")]
		public static bool enableTintAllSprites
		{
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0x93B0A4", Offset = "0x93B0A4", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A0")]
		public static bool enableParseEscapeCharacters
		{
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0x93B0C4", Offset = "0x93B0C4", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A1")]
		public static bool enableRaycastTarget
		{
			[Token(Token = "0x60002FC")]
			[Address(RVA = "0x93B0E4", Offset = "0x93B0E4", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A2")]
		public static bool getFontFeaturesAtRuntime
		{
			[Token(Token = "0x60002FD")]
			[Address(RVA = "0x93B104", Offset = "0x93B104", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A3")]
		public static int missingGlyphCharacter
		{
			[Token(Token = "0x60002FE")]
			[Address(RVA = "0x93B124", Offset = "0x93B124", Length = "0x20")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002FF")]
			[Address(RVA = "0x93B144", Offset = "0x93B144", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x170000A4")]
		public static bool warningsDisabled
		{
			[Token(Token = "0x6000300")]
			[Address(RVA = "0x93B170", Offset = "0x93B170", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A5")]
		public static TMP_FontAsset defaultFontAsset
		{
			[Token(Token = "0x6000301")]
			[Address(RVA = "0x93B190", Offset = "0x93B190", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000A6")]
		public static string defaultFontAssetPath
		{
			[Token(Token = "0x6000302")]
			[Address(RVA = "0x93B1B0", Offset = "0x93B1B0", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000A7")]
		public static float defaultFontSize
		{
			[Token(Token = "0x6000303")]
			[Address(RVA = "0x93B1D0", Offset = "0x93B1D0", Length = "0x20")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000A8")]
		public static float defaultTextAutoSizingMinRatio
		{
			[Token(Token = "0x6000304")]
			[Address(RVA = "0x93B1F0", Offset = "0x93B1F0", Length = "0x20")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000A9")]
		public static float defaultTextAutoSizingMaxRatio
		{
			[Token(Token = "0x6000305")]
			[Address(RVA = "0x93B210", Offset = "0x93B210", Length = "0x20")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000AA")]
		public static Vector2 defaultTextMeshProTextContainerSize
		{
			[Token(Token = "0x6000306")]
			[Address(RVA = "0x93B230", Offset = "0x93B230", Length = "0x20")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170000AB")]
		public static Vector2 defaultTextMeshProUITextContainerSize
		{
			[Token(Token = "0x6000307")]
			[Address(RVA = "0x93B250", Offset = "0x93B250", Length = "0x20")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170000AC")]
		public static bool autoSizeTextContainer
		{
			[Token(Token = "0x6000308")]
			[Address(RVA = "0x93B270", Offset = "0x93B270", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000AD")]
		public static List<TMP_FontAsset> fallbackFontAssets
		{
			[Token(Token = "0x6000309")]
			[Address(RVA = "0x93B290", Offset = "0x93B290", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000AE")]
		public static bool matchMaterialPreset
		{
			[Token(Token = "0x600030A")]
			[Address(RVA = "0x93B2B0", Offset = "0x93B2B0", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000AF")]
		public static TMP_SpriteAsset defaultSpriteAsset
		{
			[Token(Token = "0x600030B")]
			[Address(RVA = "0x93B2D0", Offset = "0x93B2D0", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B0")]
		public static string defaultSpriteAssetPath
		{
			[Token(Token = "0x600030C")]
			[Address(RVA = "0x93B2F0", Offset = "0x93B2F0", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B1")]
		public static string defaultColorGradientPresetsPath
		{
			[Token(Token = "0x600030D")]
			[Address(RVA = "0x93B310", Offset = "0x93B310", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B2")]
		public static bool enableEmojiSupport
		{
			[Token(Token = "0x600030E")]
			[Address(RVA = "0x93B330", Offset = "0x93B330", Length = "0x20")]
			get
			{
				return false;
			}
			[Token(Token = "0x600030F")]
			[Address(RVA = "0x93B350", Offset = "0x93B350", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x170000B3")]
		public static TMP_StyleSheet defaultStyleSheet
		{
			[Token(Token = "0x6000310")]
			[Address(RVA = "0x93B380", Offset = "0x93B380", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B4")]
		public static TextAsset leadingCharacters
		{
			[Token(Token = "0x6000311")]
			[Address(RVA = "0x93B3A0", Offset = "0x93B3A0", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B5")]
		public static TextAsset followingCharacters
		{
			[Token(Token = "0x6000312")]
			[Address(RVA = "0x93B3C0", Offset = "0x93B3C0", Length = "0x20")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B6")]
		public static LineBreakingTable linebreakingRules
		{
			[Token(Token = "0x6000313")]
			[Address(RVA = "0x93B3E0", Offset = "0x93B3E0", Length = "0x34")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000B7")]
		public static TMP_Settings instance
		{
			[Token(Token = "0x6000314")]
			[Address(RVA = "0x93AFAC", Offset = "0x93AFAC", Length = "0xB8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0x93B524", Offset = "0x93B524", Length = "0xF4")]
		public static TMP_Settings LoadDefaultSettings()
		{
			return null;
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0x93B618", Offset = "0x93B618", Length = "0x8C")]
		public static TMP_Settings GetSettings()
		{
			return null;
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0x93B6A4", Offset = "0x93B6A4", Length = "0x94")]
		public static TMP_FontAsset GetFontAsset()
		{
			return null;
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0x93B738", Offset = "0x93B738", Length = "0x94")]
		public static TMP_SpriteAsset GetSpriteAsset()
		{
			return null;
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0x93B7CC", Offset = "0x93B7CC", Length = "0x94")]
		public static TMP_StyleSheet GetStyleSheet()
		{
			return null;
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0x93B414", Offset = "0x93B414", Length = "0x110")]
		public static void LoadLinebreakingRules()
		{
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0x93B868", Offset = "0x93B868", Length = "0x114")]
		private static Dictionary<int, char> GetCharacters(TextAsset file)
		{
			return null;
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0x93B97C", Offset = "0x93B97C", Length = "0x10")]
		public TMP_Settings()
		{
		}
	}
}
