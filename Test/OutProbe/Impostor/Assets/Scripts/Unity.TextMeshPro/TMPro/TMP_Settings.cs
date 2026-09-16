using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[Token(Token = "0x2000079")]
	public class TMP_Settings : ScriptableObject
	{
		[Token(Token = "0x200007A")]
		public class LineBreakingTable
		{
			[Token(Token = "0x40003C6")]
			[FieldOffset(Offset = "0x10")]
			public Dictionary<int, char> leadingCharacters;

			[Token(Token = "0x40003C7")]
			[FieldOffset(Offset = "0x18")]
			public Dictionary<int, char> followingCharacters;

			[Token(Token = "0x60003FB")]
			[Address(RVA = "0x1608BCC", Offset = "0x1608BCC", Length = "0x8")]
			public LineBreakingTable()
			{
			}
		}

		[Token(Token = "0x40003A6")]
		private static TMP_Settings s_Instance;

		[SerializeField]
		[Token(Token = "0x40003A7")]
		[FieldOffset(Offset = "0x18")]
		private bool m_enableWordWrapping;

		[SerializeField]
		[Token(Token = "0x40003A8")]
		[FieldOffset(Offset = "0x19")]
		private bool m_enableKerning;

		[SerializeField]
		[Token(Token = "0x40003A9")]
		[FieldOffset(Offset = "0x1A")]
		private bool m_enableExtraPadding;

		[SerializeField]
		[Token(Token = "0x40003AA")]
		[FieldOffset(Offset = "0x1B")]
		private bool m_enableTintAllSprites;

		[SerializeField]
		[Token(Token = "0x40003AB")]
		[FieldOffset(Offset = "0x1C")]
		private bool m_enableParseEscapeCharacters;

		[SerializeField]
		[Token(Token = "0x40003AC")]
		[FieldOffset(Offset = "0x1D")]
		private bool m_EnableRaycastTarget;

		[SerializeField]
		[Token(Token = "0x40003AD")]
		[FieldOffset(Offset = "0x1E")]
		private bool m_GetFontFeaturesAtRuntime;

		[SerializeField]
		[Token(Token = "0x40003AE")]
		[FieldOffset(Offset = "0x20")]
		private int m_missingGlyphCharacter;

		[SerializeField]
		[Token(Token = "0x40003AF")]
		[FieldOffset(Offset = "0x24")]
		private bool m_warningsDisabled;

		[SerializeField]
		[Token(Token = "0x40003B0")]
		[FieldOffset(Offset = "0x28")]
		private TMP_FontAsset m_defaultFontAsset;

		[SerializeField]
		[Token(Token = "0x40003B1")]
		[FieldOffset(Offset = "0x30")]
		private string m_defaultFontAssetPath;

		[SerializeField]
		[Token(Token = "0x40003B2")]
		[FieldOffset(Offset = "0x38")]
		private float m_defaultFontSize;

		[SerializeField]
		[Token(Token = "0x40003B3")]
		[FieldOffset(Offset = "0x3C")]
		private float m_defaultAutoSizeMinRatio;

		[SerializeField]
		[Token(Token = "0x40003B4")]
		[FieldOffset(Offset = "0x40")]
		private float m_defaultAutoSizeMaxRatio;

		[SerializeField]
		[Token(Token = "0x40003B5")]
		[FieldOffset(Offset = "0x44")]
		private Vector2 m_defaultTextMeshProTextContainerSize;

		[SerializeField]
		[Token(Token = "0x40003B6")]
		[FieldOffset(Offset = "0x4C")]
		private Vector2 m_defaultTextMeshProUITextContainerSize;

		[SerializeField]
		[Token(Token = "0x40003B7")]
		[FieldOffset(Offset = "0x54")]
		private bool m_autoSizeTextContainer;

		[SerializeField]
		[Token(Token = "0x40003B8")]
		[FieldOffset(Offset = "0x55")]
		private bool m_IsTextObjectScaleStatic;

		[SerializeField]
		[Token(Token = "0x40003B9")]
		[FieldOffset(Offset = "0x58")]
		private List<TMP_FontAsset> m_fallbackFontAssets;

		[SerializeField]
		[Token(Token = "0x40003BA")]
		[FieldOffset(Offset = "0x60")]
		private bool m_matchMaterialPreset;

		[SerializeField]
		[Token(Token = "0x40003BB")]
		[FieldOffset(Offset = "0x68")]
		private TMP_SpriteAsset m_defaultSpriteAsset;

		[SerializeField]
		[Token(Token = "0x40003BC")]
		[FieldOffset(Offset = "0x70")]
		private string m_defaultSpriteAssetPath;

		[SerializeField]
		[Token(Token = "0x40003BD")]
		[FieldOffset(Offset = "0x78")]
		private bool m_enableEmojiSupport;

		[SerializeField]
		[Token(Token = "0x40003BE")]
		[FieldOffset(Offset = "0x7C")]
		private uint m_MissingCharacterSpriteUnicode;

		[SerializeField]
		[Token(Token = "0x40003BF")]
		[FieldOffset(Offset = "0x80")]
		private string m_defaultColorGradientPresetsPath;

		[SerializeField]
		[Token(Token = "0x40003C0")]
		[FieldOffset(Offset = "0x88")]
		private TMP_StyleSheet m_defaultStyleSheet;

		[SerializeField]
		[Token(Token = "0x40003C1")]
		[FieldOffset(Offset = "0x90")]
		private string m_StyleSheetsResourcePath;

		[SerializeField]
		[Token(Token = "0x40003C2")]
		[FieldOffset(Offset = "0x98")]
		private TextAsset m_leadingCharacters;

		[SerializeField]
		[Token(Token = "0x40003C3")]
		[FieldOffset(Offset = "0xA0")]
		private TextAsset m_followingCharacters;

		[SerializeField]
		[Token(Token = "0x40003C4")]
		[FieldOffset(Offset = "0xA8")]
		private LineBreakingTable m_linebreakingRules;

		[SerializeField]
		[Token(Token = "0x40003C5")]
		[FieldOffset(Offset = "0xB0")]
		private bool m_UseModernHangulLineBreakingRules;

		[Token(Token = "0x170000BD")]
		public static string version
		{
			[Token(Token = "0x60003CD")]
			[Address(RVA = "0x1608290", Offset = "0x1608290", Length = "0x40")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000BE")]
		public static bool enableWordWrapping
		{
			[Token(Token = "0x60003CE")]
			[Address(RVA = "0x16082D0", Offset = "0x16082D0", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000BF")]
		public static bool enableKerning
		{
			[Token(Token = "0x60003CF")]
			[Address(RVA = "0x16083B8", Offset = "0x16083B8", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C0")]
		public static bool enableExtraPadding
		{
			[Token(Token = "0x60003D0")]
			[Address(RVA = "0x16083D4", Offset = "0x16083D4", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C1")]
		public static bool enableTintAllSprites
		{
			[Token(Token = "0x60003D1")]
			[Address(RVA = "0x16083F0", Offset = "0x16083F0", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C2")]
		public static bool enableParseEscapeCharacters
		{
			[Token(Token = "0x60003D2")]
			[Address(RVA = "0x160840C", Offset = "0x160840C", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C3")]
		public static bool enableRaycastTarget
		{
			[Token(Token = "0x60003D3")]
			[Address(RVA = "0x1608428", Offset = "0x1608428", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C4")]
		public static bool getFontFeaturesAtRuntime
		{
			[Token(Token = "0x60003D4")]
			[Address(RVA = "0x1608444", Offset = "0x1608444", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C5")]
		public static int missingGlyphCharacter
		{
			[Token(Token = "0x60003D5")]
			[Address(RVA = "0x1608460", Offset = "0x1608460", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x160847C", Offset = "0x160847C", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x170000C6")]
		public static bool warningsDisabled
		{
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x160849C", Offset = "0x160849C", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000C7")]
		public static TMP_FontAsset defaultFontAsset
		{
			[Token(Token = "0x60003D8")]
			[Address(RVA = "0x16084B8", Offset = "0x16084B8", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C8")]
		public static string defaultFontAssetPath
		{
			[Token(Token = "0x60003D9")]
			[Address(RVA = "0x16084D4", Offset = "0x16084D4", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C9")]
		public static float defaultFontSize
		{
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0x16084F0", Offset = "0x16084F0", Length = "0x1C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CA")]
		public static float defaultTextAutoSizingMinRatio
		{
			[Token(Token = "0x60003DB")]
			[Address(RVA = "0x160850C", Offset = "0x160850C", Length = "0x1C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CB")]
		public static float defaultTextAutoSizingMaxRatio
		{
			[Token(Token = "0x60003DC")]
			[Address(RVA = "0x1608528", Offset = "0x1608528", Length = "0x1C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000CC")]
		public static Vector2 defaultTextMeshProTextContainerSize
		{
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0x1608544", Offset = "0x1608544", Length = "0x1C")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170000CD")]
		public static Vector2 defaultTextMeshProUITextContainerSize
		{
			[Token(Token = "0x60003DE")]
			[Address(RVA = "0x1608560", Offset = "0x1608560", Length = "0x1C")]
			get
			{
				return default(Vector2);
			}
		}

		[Token(Token = "0x170000CE")]
		public static bool autoSizeTextContainer
		{
			[Token(Token = "0x60003DF")]
			[Address(RVA = "0x160857C", Offset = "0x160857C", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000CF")]
		public static bool isTextObjectScaleStatic
		{
			[Token(Token = "0x60003E0")]
			[Address(RVA = "0x1608598", Offset = "0x1608598", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003E1")]
			[Address(RVA = "0x16085B4", Offset = "0x16085B4", Length = "0x24")]
			set
			{
			}
		}

		[Token(Token = "0x170000D0")]
		public static List<TMP_FontAsset> fallbackFontAssets
		{
			[Token(Token = "0x60003E2")]
			[Address(RVA = "0x16085D8", Offset = "0x16085D8", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D1")]
		public static bool matchMaterialPreset
		{
			[Token(Token = "0x60003E3")]
			[Address(RVA = "0x16085F4", Offset = "0x16085F4", Length = "0x1C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000D2")]
		public static TMP_SpriteAsset defaultSpriteAsset
		{
			[Token(Token = "0x60003E4")]
			[Address(RVA = "0x1608610", Offset = "0x1608610", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D3")]
		public static string defaultSpriteAssetPath
		{
			[Token(Token = "0x60003E5")]
			[Address(RVA = "0x160862C", Offset = "0x160862C", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D4")]
		public static bool enableEmojiSupport
		{
			[Token(Token = "0x60003E6")]
			[Address(RVA = "0x1608648", Offset = "0x1608648", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003E7")]
			[Address(RVA = "0x1608664", Offset = "0x1608664", Length = "0x24")]
			set
			{
			}
		}

		[Token(Token = "0x170000D5")]
		public static uint missingCharacterSpriteUnicode
		{
			[Token(Token = "0x60003E8")]
			[Address(RVA = "0x1608688", Offset = "0x1608688", Length = "0x1C")]
			get
			{
				return 0u;
			}
			[Token(Token = "0x60003E9")]
			[Address(RVA = "0x16086A4", Offset = "0x16086A4", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x170000D6")]
		public static string defaultColorGradientPresetsPath
		{
			[Token(Token = "0x60003EA")]
			[Address(RVA = "0x16086C4", Offset = "0x16086C4", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D7")]
		public static TMP_StyleSheet defaultStyleSheet
		{
			[Token(Token = "0x60003EB")]
			[Address(RVA = "0x16086E0", Offset = "0x16086E0", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D8")]
		public static string styleSheetsResourcePath
		{
			[Token(Token = "0x60003EC")]
			[Address(RVA = "0x16086FC", Offset = "0x16086FC", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000D9")]
		public static TextAsset leadingCharacters
		{
			[Token(Token = "0x60003ED")]
			[Address(RVA = "0x1608718", Offset = "0x1608718", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000DA")]
		public static TextAsset followingCharacters
		{
			[Token(Token = "0x60003EE")]
			[Address(RVA = "0x1608734", Offset = "0x1608734", Length = "0x1C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000DB")]
		public static LineBreakingTable linebreakingRules
		{
			[Token(Token = "0x60003EF")]
			[Address(RVA = "0x1608750", Offset = "0x1608750", Length = "0x30")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000DC")]
		public static bool useModernHangulLineBreakingRules
		{
			[Token(Token = "0x60003F0")]
			[Address(RVA = "0x160888C", Offset = "0x160888C", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003F1")]
			[Address(RVA = "0x16088A8", Offset = "0x16088A8", Length = "0x24")]
			set
			{
			}
		}

		[Token(Token = "0x170000DD")]
		public static TMP_Settings instance
		{
			[Token(Token = "0x60003F2")]
			[Address(RVA = "0x16082EC", Offset = "0x16082EC", Length = "0xCC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0x16088CC", Offset = "0x16088CC", Length = "0xF8")]
		public static TMP_Settings LoadDefaultSettings()
		{
			return null;
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x16089C4", Offset = "0x16089C4", Length = "0x7C")]
		public static TMP_Settings GetSettings()
		{
			return null;
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x1608A40", Offset = "0x1608A40", Length = "0x84")]
		public static TMP_FontAsset GetFontAsset()
		{
			return null;
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x1608AC4", Offset = "0x1608AC4", Length = "0x84")]
		public static TMP_SpriteAsset GetSpriteAsset()
		{
			return null;
		}

		[Token(Token = "0x60003F7")]
		[Address(RVA = "0x1608B48", Offset = "0x1608B48", Length = "0x84")]
		public static TMP_StyleSheet GetStyleSheet()
		{
			return null;
		}

		[Token(Token = "0x60003F8")]
		[Address(RVA = "0x1608780", Offset = "0x1608780", Length = "0x10C")]
		public static void LoadLinebreakingRules()
		{
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0x1608BD4", Offset = "0x1608BD4", Length = "0x124")]
		private static Dictionary<int, char> GetCharacters(TextAsset file)
		{
			return null;
		}

		[Token(Token = "0x60003FA")]
		[Address(RVA = "0x1608CF8", Offset = "0x1608CF8", Length = "0x10")]
		public TMP_Settings()
		{
		}
	}
}
