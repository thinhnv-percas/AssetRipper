using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000016")]
	public static class TMP_DefaultControls
	{
		[Token(Token = "0x2000074")]
		public struct Resources
		{
			[Token(Token = "0x400048D")]
			[FieldOffset(Offset = "0x0")]
			public Sprite standard;

			[Token(Token = "0x400048E")]
			[FieldOffset(Offset = "0x8")]
			public Sprite background;

			[Token(Token = "0x400048F")]
			[FieldOffset(Offset = "0x10")]
			public Sprite inputField;

			[Token(Token = "0x4000490")]
			[FieldOffset(Offset = "0x18")]
			public Sprite knob;

			[Token(Token = "0x4000491")]
			[FieldOffset(Offset = "0x20")]
			public Sprite checkmark;

			[Token(Token = "0x4000492")]
			[FieldOffset(Offset = "0x28")]
			public Sprite dropdown;

			[Token(Token = "0x4000493")]
			[FieldOffset(Offset = "0x30")]
			public Sprite mask;
		}

		[Token(Token = "0x4000096")]
		private const float kWidth = 160f;

		[Token(Token = "0x4000097")]
		private const float kThickHeight = 30f;

		[Token(Token = "0x4000098")]
		private const float kThinHeight = 20f;

		[Token(Token = "0x4000099")]
		private static Vector2 s_ThickElementSize;

		[Token(Token = "0x400009A")]
		private static Vector2 s_ThinElementSize;

		[Token(Token = "0x400009B")]
		private static Color s_DefaultSelectableColor;

		[Token(Token = "0x400009C")]
		private static Color s_TextColor;

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x91C574", Offset = "0x91C574", Length = "0xA8")]
		private static GameObject CreateUIElementRoot(string name, Vector2 size)
		{
			return null;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x91C61C", Offset = "0x91C61C", Length = "0xBC")]
		private static GameObject CreateUIObject(string name, GameObject parent)
		{
			return null;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x91C7E8", Offset = "0x91C7E8", Length = "0x9C")]
		private static void SetDefaultTextValues(TMP_Text lbl)
		{
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x91C884", Offset = "0x91C884", Length = "0x80")]
		private static void SetDefaultColorTransitionValues(Selectable slider)
		{
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x91C6D8", Offset = "0x91C6D8", Length = "0x110")]
		private static void SetParentAndAlign(GameObject child, GameObject parent)
		{
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x91C904", Offset = "0x91C904", Length = "0x104")]
		private static void SetLayerRecursively(GameObject go, int layer)
		{
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x91CA08", Offset = "0x91CA08", Length = "0x2B4")]
		public static GameObject CreateScrollbar(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x91CCBC", Offset = "0x91CCBC", Length = "0x228")]
		public static GameObject CreateButton(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x91CEE4", Offset = "0x91CEE4", Length = "0xC4")]
		public static GameObject CreateText(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x91CFA8", Offset = "0x91CFA8", Length = "0x4E8")]
		public static GameObject CreateInputField(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x91D654", Offset = "0x91D654", Length = "0xDB4")]
		public static GameObject CreateDropdown(Resources resources)
		{
			return null;
		}
	}
}
