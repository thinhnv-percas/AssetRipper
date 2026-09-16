using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000D")]
	public static class DefaultControls
	{
		[Token(Token = "0x2000075")]
		public interface IFactoryControls
		{
			[Token(Token = "0x600061C")]
			GameObject CreateGameObject(string name, params Type[] components);
		}

		[Token(Token = "0x2000076")]
		private class DefaultRuntimeFactory : IFactoryControls
		{
			[Token(Token = "0x4000220")]
			public static IFactoryControls Default;

			[Token(Token = "0x600061D")]
			[Address(RVA = "0xC54308", Offset = "0xC54308", Length = "0x74")]
			public GameObject CreateGameObject(string name, params Type[] components)
			{
				return null;
			}

			[Token(Token = "0x600061E")]
			[Address(RVA = "0xC5437C", Offset = "0xC5437C", Length = "0x8")]
			public DefaultRuntimeFactory()
			{
			}
		}

		[Token(Token = "0x2000077")]
		public struct Resources
		{
			[Token(Token = "0x4000221")]
			[FieldOffset(Offset = "0x0")]
			public Sprite standard;

			[Token(Token = "0x4000222")]
			[FieldOffset(Offset = "0x8")]
			public Sprite background;

			[Token(Token = "0x4000223")]
			[FieldOffset(Offset = "0x10")]
			public Sprite inputField;

			[Token(Token = "0x4000224")]
			[FieldOffset(Offset = "0x18")]
			public Sprite knob;

			[Token(Token = "0x4000225")]
			[FieldOffset(Offset = "0x20")]
			public Sprite checkmark;

			[Token(Token = "0x4000226")]
			[FieldOffset(Offset = "0x28")]
			public Sprite dropdown;

			[Token(Token = "0x4000227")]
			[FieldOffset(Offset = "0x30")]
			public Sprite mask;
		}

		[Token(Token = "0x4000024")]
		private static IFactoryControls m_CurrentFactory;

		[Token(Token = "0x4000025")]
		private const float kWidth = 160f;

		[Token(Token = "0x4000026")]
		private const float kThickHeight = 30f;

		[Token(Token = "0x4000027")]
		private const float kThinHeight = 20f;

		[Token(Token = "0x4000028")]
		private static Vector2 s_ThickElementSize;

		[Token(Token = "0x4000029")]
		private static Vector2 s_ThinElementSize;

		[Token(Token = "0x400002A")]
		private static Vector2 s_ImageElementSize;

		[Token(Token = "0x400002B")]
		private static Color s_DefaultSelectableColor;

		[Token(Token = "0x400002C")]
		private static Color s_PanelColor;

		[Token(Token = "0x400002D")]
		private static Color s_TextColor;

		[Token(Token = "0x17000014")]
		public static IFactoryControls factory
		{
			[Token(Token = "0x600004D")]
			[Address(RVA = "0xC4FF88", Offset = "0xC4FF88", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0xC4FFF0", Offset = "0xC4FFF0", Length = "0x174")]
		private static GameObject CreateUIElementRoot(string name, Vector2 size, params Type[] components)
		{
			return null;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xC50164", Offset = "0xC50164", Length = "0x14C")]
		private static GameObject CreateUIObject(string name, GameObject parent, params Type[] components)
		{
			return null;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0xC503C0", Offset = "0xC503C0", Length = "0x98")]
		private static void SetDefaultTextValues(Text lbl)
		{
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0xC50458", Offset = "0xC50458", Length = "0x80")]
		private static void SetDefaultColorTransitionValues(Selectable slider)
		{
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0xC502B0", Offset = "0xC502B0", Length = "0x110")]
		private static void SetParentAndAlign(GameObject child, GameObject parent)
		{
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0xC504D8", Offset = "0xC504D8", Length = "0x104")]
		private static void SetLayerRecursively(GameObject go, int layer)
		{
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0xC505DC", Offset = "0xC505DC", Length = "0x234")]
		public static GameObject CreatePanel(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0xC50810", Offset = "0xC50810", Length = "0x344")]
		public static GameObject CreateButton(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0xC50B54", Offset = "0xC50B54", Length = "0x17C")]
		public static GameObject CreateText(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0xC50CD0", Offset = "0xC50CD0", Length = "0x128")]
		public static GameObject CreateImage(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0xC50DF8", Offset = "0xC50DF8", Length = "0x128")]
		public static GameObject CreateRawImage(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0xC50F20", Offset = "0xC50F20", Length = "0x76C")]
		public static GameObject CreateSlider(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0xC5168C", Offset = "0xC5168C", Length = "0x448")]
		public static GameObject CreateScrollbar(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0xC51AD4", Offset = "0xC51AD4", Length = "0x600")]
		public static GameObject CreateToggle(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0xC520D4", Offset = "0xC520D4", Length = "0x558")]
		public static GameObject CreateInputField(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0xC5262C", Offset = "0xC5262C", Length = "0x11A4")]
		public static GameObject CreateDropdown(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0xC53A14", Offset = "0xC53A14", Length = "0x718")]
		public static GameObject CreateScrollView(Resources resources)
		{
			return null;
		}
	}
}
