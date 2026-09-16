using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[Token(Token = "0x2000034")]
	public static class TMP_DefaultControls
	{
		[Token(Token = "0x2000035")]
		public struct Resources
		{
			[Token(Token = "0x4000181")]
			[FieldOffset(Offset = "0x0")]
			public Sprite standard;

			[Token(Token = "0x4000182")]
			[FieldOffset(Offset = "0x8")]
			public Sprite background;

			[Token(Token = "0x4000183")]
			[FieldOffset(Offset = "0x10")]
			public Sprite inputField;

			[Token(Token = "0x4000184")]
			[FieldOffset(Offset = "0x18")]
			public Sprite knob;

			[Token(Token = "0x4000185")]
			[FieldOffset(Offset = "0x20")]
			public Sprite checkmark;

			[Token(Token = "0x4000186")]
			[FieldOffset(Offset = "0x28")]
			public Sprite dropdown;

			[Token(Token = "0x4000187")]
			[FieldOffset(Offset = "0x30")]
			public Sprite mask;
		}

		[Token(Token = "0x4000179")]
		private const float kWidth = 160f;

		[Token(Token = "0x400017A")]
		private const float kThickHeight = 30f;

		[Token(Token = "0x400017B")]
		private const float kThinHeight = 20f;

		[Token(Token = "0x400017C")]
		private static Vector2 s_TextElementSize;

		[Token(Token = "0x400017D")]
		private static Vector2 s_ThickElementSize;

		[Token(Token = "0x400017E")]
		private static Vector2 s_ThinElementSize;

		[Token(Token = "0x400017F")]
		private static Color s_DefaultSelectableColor;

		[Token(Token = "0x4000180")]
		private static Color s_TextColor;

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x15D0CE0", Offset = "0x15D0CE0", Length = "0xA8")]
		private static GameObject CreateUIElementRoot(string name, Vector2 size)
		{
			return null;
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0x15D0D88", Offset = "0x15D0D88", Length = "0xC0")]
		private static GameObject CreateUIObject(string name, GameObject parent)
		{
			return null;
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x15D0F48", Offset = "0x15D0F48", Length = "0x88")]
		private static void SetDefaultTextValues(TMP_Text lbl)
		{
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0x15D0FD0", Offset = "0x15D0FD0", Length = "0x60")]
		private static void SetDefaultColorTransitionValues(Selectable slider)
		{
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0x15D0E48", Offset = "0x15D0E48", Length = "0x100")]
		private static void SetParentAndAlign(GameObject child, GameObject parent)
		{
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x15D1030", Offset = "0x15D1030", Length = "0xE4")]
		private static void SetLayerRecursively(GameObject go, int layer)
		{
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x15D1114", Offset = "0x15D1114", Length = "0x2CC")]
		public static GameObject CreateScrollbar(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x15D13E0", Offset = "0x15D13E0", Length = "0x2C0")]
		public static GameObject CreateButton(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x15D16A0", Offset = "0x15D16A0", Length = "0xA0")]
		public static GameObject CreateText(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0x15D1740", Offset = "0x15D1740", Length = "0x660")]
		public static GameObject CreateInputField(Resources resources)
		{
			return null;
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x15D1F44", Offset = "0x15D1F44", Length = "0xDE0")]
		public static GameObject CreateDropdown(Resources resources)
		{
			return null;
		}
	}
}
