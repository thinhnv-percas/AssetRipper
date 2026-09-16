using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000011")]
	public static class DefaultControls
	{
		[Token(Token = "0x2000012")]
		public interface IFactoryControls
		{
			[Token(Token = "0x600006E")]
			GameObject CreateGameObject(string name, params Type[] components);
		}

		[Token(Token = "0x2000013")]
		private class DefaultRuntimeFactory : IFactoryControls
		{
			[Token(Token = "0x400003B")]
			public static IFactoryControls Default;

			[Token(Token = "0x600006F")]
			[Address(RVA = "0x16C8130", Offset = "0x16C8130", Length = "0x6C")]
			public GameObject CreateGameObject(string name, params Type[] components)
			{
				return null;
			}

			[Token(Token = "0x6000070")]
			[Address(RVA = "0x16C819C", Offset = "0x16C819C", Length = "0x8")]
			public DefaultRuntimeFactory()
			{
			}
		}

		[Token(Token = "0x2000014")]
		public struct Resources
		{
			[Token(Token = "0x400003C")]
			[FieldOffset(Offset = "0x0")]
			public Sprite standard;

			[Token(Token = "0x400003D")]
			[FieldOffset(Offset = "0x8")]
			public Sprite background;

			[Token(Token = "0x400003E")]
			[FieldOffset(Offset = "0x10")]
			public Sprite inputField;

			[Token(Token = "0x400003F")]
			[FieldOffset(Offset = "0x18")]
			public Sprite knob;

			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x20")]
			public Sprite checkmark;

			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x28")]
			public Sprite dropdown;

			[Token(Token = "0x4000042")]
			[FieldOffset(Offset = "0x30")]
			public Sprite mask;
		}

		[Token(Token = "0x4000031")]
		private static IFactoryControls m_CurrentFactory;

		[Token(Token = "0x4000032")]
		private const float kWidth = 160f;

		[Token(Token = "0x4000033")]
		private const float kThickHeight = 30f;

		[Token(Token = "0x4000034")]
		private const float kThinHeight = 20f;

		[Token(Token = "0x4000035")]
		private static Vector2 s_ThickElementSize;

		[Token(Token = "0x4000036")]
		private static Vector2 s_ThinElementSize;

		[Token(Token = "0x4000037")]
		private static Vector2 s_ImageElementSize;

		[Token(Token = "0x4000038")]
		private static Color s_DefaultSelectableColor;

		[Token(Token = "0x4000039")]
		private static Color s_PanelColor;

		[Token(Token = "0x400003A")]
		private static Color s_TextColor;

		[Token(Token = "0x17000015")]
		public static IFactoryControls factory
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x16C3878", Offset = "0x16C3878", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x16C38D0", Offset = "0x16C38D0", Length = "0x160")]
		private static GameObject CreateUIElementRoot(string name, Vector2 size, params Type[] components)
		{
			return null;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x16C3A30", Offset = "0x16C3A30", Length = "0x128")]
		private static GameObject CreateUIObject(string name, GameObject parent, params Type[] components)
		{
			return null;
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x16C3C58", Offset = "0x16C3C58", Length = "0xDC")]
		private static void SetDefaultTextValues(Text lbl)
		{
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x16C3D34", Offset = "0x16C3D34", Length = "0x60")]
		private static void SetDefaultColorTransitionValues(Selectable slider)
		{
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x16C3B58", Offset = "0x16C3B58", Length = "0x100")]
		private static void SetParentAndAlign(GameObject child, GameObject parent)
		{
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x16C3D94", Offset = "0x16C3D94", Length = "0xE4")]
		private static void SetLayerRecursively(GameObject go, int layer)
		{
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x16C3E78", Offset = "0x16C3E78", Length = "0x2BC")]
		public static GameObject CreatePanel(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x16C4468", Offset = "0x16C4468", Length = "0x3EC")]
		public static GameObject CreateButton(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x16C4854", Offset = "0x16C4854", Length = "0x1A0")]
		public static GameObject CreateText(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x16C49F4", Offset = "0x16C49F4", Length = "0x13C")]
		public static GameObject CreateImage(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x16C4B30", Offset = "0x16C4B30", Length = "0x13C")]
		public static GameObject CreateRawImage(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x16C4C6C", Offset = "0x16C4C6C", Length = "0x6BC")]
		public static GameObject CreateSlider(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x16C5328", Offset = "0x16C5328", Length = "0x47C")]
		public static GameObject CreateScrollbar(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x16C57A4", Offset = "0x16C57A4", Length = "0x574")]
		public static GameObject CreateToggle(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x16C5D18", Offset = "0x16C5D18", Length = "0x624")]
		public static GameObject CreateInputField(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x16C633C", Offset = "0x16C633C", Length = "0x122C")]
		public static GameObject CreateDropdown(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x16C7780", Offset = "0x16C7780", Length = "0x8D8")]
		public static GameObject CreateScrollView(Resources resources)
		{
			return null;
		}
	}
}
