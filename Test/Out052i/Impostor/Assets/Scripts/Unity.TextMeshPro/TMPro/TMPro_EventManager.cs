using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000013")]
	public static class TMPro_EventManager
	{
		[Token(Token = "0x400008C")]
		public static readonly FastAction<object, Compute_DT_EventArgs> COMPUTE_DT_EVENT;

		[Token(Token = "0x400008D")]
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT;

		[Token(Token = "0x400008E")]
		public static readonly FastAction<bool, Object> FONT_PROPERTY_EVENT;

		[Token(Token = "0x400008F")]
		public static readonly FastAction<bool, Object> SPRITE_ASSET_PROPERTY_EVENT;

		[Token(Token = "0x4000090")]
		public static readonly FastAction<bool, Object> TEXTMESHPRO_PROPERTY_EVENT;

		[Token(Token = "0x4000091")]
		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT;

		[Token(Token = "0x4000092")]
		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT;

		[Token(Token = "0x4000093")]
		public static readonly FastAction<Object> COLOR_GRADIENT_PROPERTY_EVENT;

		[Token(Token = "0x4000094")]
		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT;

		[Token(Token = "0x4000095")]
		public static readonly FastAction RESOURCE_LOAD_EVENT;

		[Token(Token = "0x4000096")]
		public static readonly FastAction<bool, Object> TEXTMESHPRO_UGUI_PROPERTY_EVENT;

		[Token(Token = "0x4000097")]
		public static readonly FastAction<Object> TEXT_CHANGED_EVENT;

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x15CE4B4", Offset = "0x15CE4B4", Length = "0x90")]
		public static void ON_MATERIAL_PROPERTY_CHANGED(bool isChanged, Material mat)
		{
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x15CE544", Offset = "0x15CE544", Length = "0x90")]
		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x15CE5D4", Offset = "0x15CE5D4", Length = "0x90")]
		public static void ON_SPRITE_ASSET_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x15CE664", Offset = "0x15CE664", Length = "0x90")]
		public static void ON_TEXTMESHPRO_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x15CE6F4", Offset = "0x15CE6F4", Length = "0x98")]
		public static void ON_DRAG_AND_DROP_MATERIAL_CHANGED(GameObject sender, Material currentMaterial, Material newMaterial)
		{
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x15CE78C", Offset = "0x15CE78C", Length = "0x80")]
		public static void ON_TEXT_STYLE_PROPERTY_CHANGED(bool isChanged)
		{
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x15CE80C", Offset = "0x15CE80C", Length = "0x80")]
		public static void ON_COLOR_GRADIENT_PROPERTY_CHANGED(Object obj)
		{
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x15CE88C", Offset = "0x15CE88C", Length = "0x80")]
		public static void ON_TEXT_CHANGED(Object obj)
		{
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x15CE90C", Offset = "0x15CE90C", Length = "0x60")]
		public static void ON_TMP_SETTINGS_CHANGED()
		{
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x15CE96C", Offset = "0x15CE96C", Length = "0x60")]
		public static void ON_RESOURCES_LOADED()
		{
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x15CE9CC", Offset = "0x15CE9CC", Length = "0x90")]
		public static void ON_TEXTMESHPRO_UGUI_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x15CEA5C", Offset = "0x15CEA5C", Length = "0x90")]
		public static void ON_COMPUTE_DT_EVENT(object Sender, Compute_DT_EventArgs e)
		{
		}
	}
}
