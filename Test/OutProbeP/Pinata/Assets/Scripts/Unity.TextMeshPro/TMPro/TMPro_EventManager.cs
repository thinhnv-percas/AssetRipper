using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200005E")]
	public static class TMPro_EventManager
	{
		[Token(Token = "0x4000405")]
		public static readonly FastAction<object, Compute_DT_EventArgs> COMPUTE_DT_EVENT;

		[Token(Token = "0x4000406")]
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT;

		[Token(Token = "0x4000407")]
		public static readonly FastAction<bool, TMP_FontAsset> FONT_PROPERTY_EVENT;

		[Token(Token = "0x4000408")]
		public static readonly FastAction<bool, Object> SPRITE_ASSET_PROPERTY_EVENT;

		[Token(Token = "0x4000409")]
		public static readonly FastAction<bool, TextMeshPro> TEXTMESHPRO_PROPERTY_EVENT;

		[Token(Token = "0x400040A")]
		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT;

		[Token(Token = "0x400040B")]
		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT;

		[Token(Token = "0x400040C")]
		public static readonly FastAction<TMP_ColorGradient> COLOR_GRADIENT_PROPERTY_EVENT;

		[Token(Token = "0x400040D")]
		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT;

		[Token(Token = "0x400040E")]
		public static readonly FastAction RESOURCE_LOAD_EVENT;

		[Token(Token = "0x400040F")]
		public static readonly FastAction<bool, TextMeshProUGUI> TEXTMESHPRO_UGUI_PROPERTY_EVENT;

		[Token(Token = "0x4000410")]
		public static readonly FastAction OnPreRenderObject_Event;

		[Token(Token = "0x4000411")]
		public static readonly FastAction<Object> TEXT_CHANGED_EVENT;

		[Token(Token = "0x6000519")]
		[Address(RVA = "0xC8FF54", Offset = "0xC8FF54", Length = "0x74")]
		public static void ON_PRE_RENDER_OBJECT_CHANGED()
		{
		}

		[Token(Token = "0x600051A")]
		[Address(RVA = "0xC8FFC8", Offset = "0xC8FFC8", Length = "0x94")]
		public static void ON_MATERIAL_PROPERTY_CHANGED(bool isChanged, Material mat)
		{
		}

		[Token(Token = "0x600051B")]
		[Address(RVA = "0xC9005C", Offset = "0xC9005C", Length = "0x94")]
		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, TMP_FontAsset font)
		{
		}

		[Token(Token = "0x600051C")]
		[Address(RVA = "0xC900F0", Offset = "0xC900F0", Length = "0x94")]
		public static void ON_SPRITE_ASSET_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
		}

		[Token(Token = "0x600051D")]
		[Address(RVA = "0xC90184", Offset = "0xC90184", Length = "0x94")]
		public static void ON_TEXTMESHPRO_PROPERTY_CHANGED(bool isChanged, TextMeshPro obj)
		{
		}

		[Token(Token = "0x600051E")]
		[Address(RVA = "0xC90218", Offset = "0xC90218", Length = "0x9C")]
		public static void ON_DRAG_AND_DROP_MATERIAL_CHANGED(GameObject sender, Material currentMaterial, Material newMaterial)
		{
		}

		[Token(Token = "0x600051F")]
		[Address(RVA = "0xC902B4", Offset = "0xC902B4", Length = "0x84")]
		public static void ON_TEXT_STYLE_PROPERTY_CHANGED(bool isChanged)
		{
		}

		[Token(Token = "0x6000520")]
		[Address(RVA = "0xC90338", Offset = "0xC90338", Length = "0x84")]
		public static void ON_COLOR_GRAIDENT_PROPERTY_CHANGED(TMP_ColorGradient gradient)
		{
		}

		[Token(Token = "0x6000521")]
		[Address(RVA = "0xC903BC", Offset = "0xC903BC", Length = "0x84")]
		public static void ON_TEXT_CHANGED(Object obj)
		{
		}

		[Token(Token = "0x6000522")]
		[Address(RVA = "0xC90440", Offset = "0xC90440", Length = "0x74")]
		public static void ON_TMP_SETTINGS_CHANGED()
		{
		}

		[Token(Token = "0x6000523")]
		[Address(RVA = "0xC904B4", Offset = "0xC904B4", Length = "0x74")]
		public static void ON_RESOURCES_LOADED()
		{
		}

		[Token(Token = "0x6000524")]
		[Address(RVA = "0xC90528", Offset = "0xC90528", Length = "0x94")]
		public static void ON_TEXTMESHPRO_UGUI_PROPERTY_CHANGED(bool isChanged, TextMeshProUGUI obj)
		{
		}

		[Token(Token = "0x6000525")]
		[Address(RVA = "0xC905BC", Offset = "0xC905BC", Length = "0x94")]
		public static void ON_COMPUTE_DT_EVENT(object Sender, Compute_DT_EventArgs e)
		{
		}
	}
}
