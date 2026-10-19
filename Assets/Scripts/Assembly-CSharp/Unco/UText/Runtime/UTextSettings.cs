using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unco.UText.Runtime
{
	[CreateAssetMenu(fileName = "UTextSettings", menuName = "UText/Settings")]
	[Token(Token = "0x20007A6")]
	public class UTextSettings : ScriptableObject
	{
		[Token(Token = "0x4001944")]
		private const string ResourcePath = "UTextSettings";

		[Token(Token = "0x4001945")]
		private const string FALLBACK_TEXT_SHADER_3D_PATH = "UTextShaders/UText3D";

		[Token(Token = "0x4001946")]
		private const string FALLBACK_TEXT_SHADER_UI_PATH = "UTextShaders/UTextGUI";

		[Token(Token = "0x4001947")]
		private const string FALLBACK_SPRITE_SHADER_3D_NAME = "Unlit/Transparent";

		[Token(Token = "0x4001948")]
		private const string FALLBACK_SPRITE_SHADER_UI_NAME = "UI/Default";

		[Token(Token = "0x4001949")]
		private const string FALLBACK_FONT_RESOURCES_FOLDER = "UTextFonts/";

		[Token(Token = "0x400194A")]
		private const string FALLBACK_STYLE_RESOURCES_FOLDER = "UTextStyles/";

		[Token(Token = "0x400194B")]
		private const string FALLBACK_SPRITE_ATLAS_RESOURCES_FOLDER = "UTextSpriteAtlases/";

		[Token(Token = "0x400194C")]
		private const string FALLBACK_DEFAULT_FONT_PATH = "UTextFonts/Mikado";

		[Token(Token = "0x400194D")]
		private const string FALLBACK_DEFAULT_STYLE_PATH = "UTextStyles/DefaultStyle";

		[Token(Token = "0x400194E")]
		private const string FALLBACK_DEFAULT_SPRITE_ATLAS_PATH = "UTextSpriteAtlases/DefaultSpriteAtlas";

		[Token(Token = "0x400194F")]
		private const string FALLBACK_FIGMA_GENERATED_STYLES_FOLDER = "Assets/_game/Art/Generated/Resources/UTextStyles";

		[Token(Token = "0x4001950")]
		private const float FALLBACK_FIGMA_COLOR_TOLERANCE = 0.01f;

		[Token(Token = "0x4001951")]
		private const float FALLBACK_FIGMA_OFFSET_TOLERANCE = 0.01f;

		[Token(Token = "0x4001952")]
		private const float FALLBACK_FIGMA_EXPAND_TOLERANCE = 0.01f;

		[Header("Shaders")]
		[SerializeField]
		[FormerlySerializedAs("TextShader3DPath")]
		[Tooltip("Resources path for the 3D MeshRenderer SDF text shader (UText component).")]
		[Token(Token = "0x4001953")]
		[FieldOffset(Offset = "0x18")]
		private string m_textShader3DPath;

		[SerializeField]
		[FormerlySerializedAs("TextShaderUIPath")]
		[Tooltip("Resources path for the UGUI CanvasRenderer SDF text shader (UTextGUI component).")]
		[Token(Token = "0x4001954")]
		[FieldOffset(Offset = "0x20")]
		private string m_textShaderUIPath;

		[SerializeField]
		[FormerlySerializedAs("SpriteShader3DName")]
		[Tooltip("Shader.Find name for sprite quads in 3D MeshRenderer setups (one submesh per atlas in UText).")]
		[Token(Token = "0x4001955")]
		[FieldOffset(Offset = "0x28")]
		private string m_spriteShader3DName;

		[SerializeField]
		[FormerlySerializedAs("SpriteShaderUIName")]
		[Tooltip("Shader.Find name for sprite quads in UGUI CanvasRenderer setups (one child renderer per atlas in UTextGUI).")]
		[Token(Token = "0x4001956")]
		[FieldOffset(Offset = "0x30")]
		private string m_spriteShaderUIName;

		[Header("Default Assets (Resources paths)")]
		[SerializeField]
		[FormerlySerializedAs("DefaultFontPath")]
		[Tooltip("Resources path for the project-default UTextFont, used when a component leaves its Font field empty.")]
		[Token(Token = "0x4001957")]
		[FieldOffset(Offset = "0x38")]
		private string m_defaultFontPath;

		[SerializeField]
		[FormerlySerializedAs("DefaultStylePath")]
		[Tooltip("Resources path for the project-default UTextStyle, used when a component leaves its Style field empty.")]
		[Token(Token = "0x4001958")]
		[FieldOffset(Offset = "0x40")]
		private string m_defaultStylePath;

		[SerializeField]
		[FormerlySerializedAs("DefaultSpriteAtlasPath")]
		[Tooltip("Resources path for the project-default UTextSpriteAsset, used by <sprite=Name> and <sprite index=N> tags without an explicit atlas name.")]
		[Token(Token = "0x4001959")]
		[FieldOffset(Offset = "0x48")]
		private string m_defaultSpriteAtlasPath;

		[Header("Rich-Text Resources Folders")]
		[SerializeField]
		[FormerlySerializedAs("StyleResourcesFolder")]
		[Tooltip("Resources folder prefix for <style=Name> tag lookups. Trailing slash required.")]
		[Token(Token = "0x400195A")]
		[FieldOffset(Offset = "0x50")]
		private string m_styleResourcesFolder;

		[SerializeField]
		[FormerlySerializedAs("SpriteAtlasResourcesFolder")]
		[Tooltip("Resources folder prefix for <sprite=\"AtlasName\" ...> tag lookups. Trailing slash required.")]
		[Token(Token = "0x400195B")]
		[FieldOffset(Offset = "0x58")]
		private string m_spriteAtlasResourcesFolder;

		[Header("Editor Generators")]
		[SerializeField]
		[FormerlySerializedAs("FigmaGeneratedStylesFolder")]
		[Tooltip("Project-relative folder where the Figma importer writes newly-generated UTextStyle assets. Must live under a Resources folder for runtime <style=Name> resolution to find them.")]
		[Token(Token = "0x400195C")]
		[FieldOffset(Offset = "0x60")]
		private string m_figmaGeneratedStylesFolder;

		[SerializeField]
		[FormerlySerializedAs("FigmaStyleColorTolerance")]
		[Tooltip("Per-channel sRGB tolerance when matching an existing UTextStyle against a Figma node's colour. Larger values cause more imports to reuse a shared style asset; smaller values create more variants.")]
		[Token(Token = "0x400195D")]
		[FieldOffset(Offset = "0x68")]
		private float m_figmaStyleColorTolerance;

		[SerializeField]
		[FormerlySerializedAs("FigmaStyleOffsetTolerance")]
		[Tooltip("Em-space tolerance when matching effect / shadow offset components during Figma import.")]
		[Token(Token = "0x400195E")]
		[FieldOffset(Offset = "0x6C")]
		private float m_figmaStyleOffsetTolerance;

		[SerializeField]
		[FormerlySerializedAs("FigmaStyleExpandTolerance")]
		[Tooltip("Normalised-expand tolerance when matching effect Expand / shadow Spread / BlurRadius during Figma import.")]
		[Token(Token = "0x400195F")]
		[FieldOffset(Offset = "0x70")]
		private float m_figmaStyleExpandTolerance;

		[Token(Token = "0x4001960")]
		private static UTextSettings _fallbackInstance;

		[Token(Token = "0x4001961")]
		private static UTextSettings _instance;

		[CompilerGenerated]
		[Token(Token = "0x4001962")]
		private static Action OnChanged;

		[Token(Token = "0x17000317")]
		public static string TextShader3DPath
		{
			[Token(Token = "0x6002035")]
			[Address(RVA = "0x3D96DB8", Offset = "0x3D96DB8", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFC6]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_textShader3DPath;
				}
				return "UTextShaders/UText3D";
			}
		}

		[Token(Token = "0x17000318")]
		public static string TextShaderUIPath
		{
			[Token(Token = "0x6002036")]
			[Address(RVA = "0x3D970B4", Offset = "0x3D970B4", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFC7]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_textShaderUIPath;
				}
				return "UTextShaders/UTextGUI";
			}
		}

		[Token(Token = "0x17000319")]
		public static string SpriteShader3DName
		{
			[Token(Token = "0x6002037")]
			[Address(RVA = "0x3D9717C", Offset = "0x3D9717C", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFC8]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_spriteShader3DName;
				}
				return "Unlit/Transparent";
			}
		}

		[Token(Token = "0x1700031A")]
		public static string SpriteShaderUIName
		{
			[Token(Token = "0x6002038")]
			[Address(RVA = "0x3D97244", Offset = "0x3D97244", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFC9]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_spriteShaderUIName;
				}
				return "UI/Default";
			}
		}

		[Token(Token = "0x1700031B")]
		public static string DefaultFontPath
		{
			[Token(Token = "0x6002039")]
			[Address(RVA = "0x3D9730C", Offset = "0x3D9730C", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCA]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_defaultFontPath;
				}
				return "UTextFonts/Mikado";
			}
		}

		[Token(Token = "0x1700031C")]
		public static string DefaultStylePath
		{
			[Token(Token = "0x600203A")]
			[Address(RVA = "0x3D973D4", Offset = "0x3D973D4", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCB]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_defaultStylePath;
				}
				return "UTextStyles/DefaultStyle";
			}
		}

		[Token(Token = "0x1700031D")]
		public static string DefaultSpriteAtlasPath
		{
			[Token(Token = "0x600203B")]
			[Address(RVA = "0x3D9749C", Offset = "0x3D9749C", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCC]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_defaultSpriteAtlasPath;
				}
				return "UTextSpriteAtlases/DefaultSpriteAtlas";
			}
		}

		[Token(Token = "0x1700031E")]
		public static string StyleResourcesFolder
		{
			[Token(Token = "0x600203C")]
			[Address(RVA = "0x3D963E0", Offset = "0x3D963E0", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCD]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_styleResourcesFolder;
				}
				return "UTextStyles/";
			}
		}

		[Token(Token = "0x1700031F")]
		public static string SpriteAtlasResourcesFolder
		{
			[Token(Token = "0x600203D")]
			[Address(RVA = "0x3D96C30", Offset = "0x3D96C30", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCE]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_spriteAtlasResourcesFolder;
				}
				return "UTextSpriteAtlases/";
			}
		}

		[Token(Token = "0x17000320")]
		public static string FigmaGeneratedStylesFolder
		{
			[Token(Token = "0x600203E")]
			[Address(RVA = "0x3D97564", Offset = "0x3D97564", Length = "0xC8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFCF]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_figmaGeneratedStylesFolder;
				}
				return "Assets/_game/Art/Generated/Resources/UTextStyles";
			}
		}

		[Token(Token = "0x17000321")]
		public static float FigmaStyleColorTolerance
		{
			[Token(Token = "0x600203F")]
			[Address(RVA = "0x3D9762C", Offset = "0x3D9762C", Length = "0xB8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFD0]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_figmaStyleColorTolerance;
				}
				return 0.01f;
			}
		}

		[Token(Token = "0x17000322")]
		public static float FigmaStyleOffsetTolerance
		{
			[Token(Token = "0x6002040")]
			[Address(RVA = "0x3D976E4", Offset = "0x3D976E4", Length = "0xB8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFD1]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_figmaStyleOffsetTolerance;
				}
				return 0.01f;
			}
		}

		[Token(Token = "0x17000323")]
		public static float FigmaStyleExpandTolerance
		{
			[Token(Token = "0x6002041")]
			[Address(RVA = "0x3D9779C", Offset = "0x3D9779C", Length = "0xB8")]
			get
			{
				//IL_0009: Expected O, but got I4
				object obj = 192466944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFD2]");
				UnityEngine.Object obj2;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					UTextSettings instance = Instance;
					obj2 = instance;
				}
				else
				{
					_ = 1;
					UTextSettings instance2 = Instance;
					obj2 = instance2;
				}
				if (obj2 != null)
				{
					UTextSettings instance3 = Instance;
					return instance3.m_figmaStyleExpandTolerance;
				}
				return 0.01f;
			}
		}

		[Token(Token = "0x17000324")]
		public static UTextSettings Instance
		{
			[Token(Token = "0x6002042")]
			[Address(RVA = "0x3D96E80", Offset = "0x3D96E80", Length = "0x234")]
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				UTextSettings instance = Resources.Load<UTextSettings>("UTextSettings");
				_instance = instance;
				if (_instance != null)
				{
					return _instance;
				}
				if (!(_fallbackInstance != null))
				{
					UTextSettings fallbackInstance = ScriptableObject.CreateInstance<UTextSettings>();
					_fallbackInstance = fallbackInstance;
					_fallbackInstance.name = "UTextSettings (default)";
					_fallbackInstance.hideFlags = HideFlags.DontSave;
				}
				return _fallbackInstance;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6002043")]
		[Address(RVA = "0x3D97854", Offset = "0x3D97854", Length = "0xC4")]
		public static void add_OnChanged(Action value)
		{
			Action action = OnChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6002044")]
		[Address(RVA = "0x3D97918", Offset = "0x3D97918", Length = "0xC4")]
		public static void remove_OnChanged(Action value)
		{
			Action action = OnChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6002045")]
		[Address(RVA = "0x3D979DC", Offset = "0x3D979DC", Length = "0x68")]
		public void RaiseChanged()
		{
			if (OnChanged != null)
			{
				OnChanged();
			}
		}

		[Token(Token = "0x6002046")]
		[Address(RVA = "0x3D97A44", Offset = "0x3D97A44", Length = "0x1D4")]
		public UTextSettings()
		{
			m_textShader3DPath = "UTextShaders/UText3D";
			m_textShaderUIPath = "UTextShaders/UTextGUI";
			m_spriteShader3DName = "Unlit/Transparent";
			m_spriteShaderUIName = "UI/Default";
			m_defaultFontPath = "UTextFonts/Mikado";
			m_defaultStylePath = "UTextStyles/DefaultStyle";
			m_defaultSpriteAtlasPath = "UTextSpriteAtlases/DefaultSpriteAtlas";
			m_styleResourcesFolder = "UTextStyles/";
			m_spriteAtlasResourcesFolder = "UTextSpriteAtlases/";
			m_figmaGeneratedStylesFolder = "Assets/_game/Art/Generated/Resources/UTextStyles";
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			object obj = default(object);
			m_figmaStyleColorTolerance = (float)obj;
			m_figmaStyleExpandTolerance = 0.01f;
		}
	}
}
