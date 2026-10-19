using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B3")]
	public static class DebugMenuStyle
	{
		[Token(Token = "0x4001397")]
		private const float k_ReferenceDpi = 160f;

		[Token(Token = "0x4001398")]
		private const float k_MinScale = 1f;

		[Token(Token = "0x4001399")]
		private const float k_MaxScale = 3f;

		[Token(Token = "0x400139A")]
		public static readonly Color BgPanel;

		[Token(Token = "0x400139B")]
		public static readonly Color BgHeader;

		[Token(Token = "0x400139C")]
		public static readonly Color BgSection;

		[Token(Token = "0x400139D")]
		public static readonly Color BgRow;

		[Token(Token = "0x400139E")]
		public static readonly Color BgTab;

		[Token(Token = "0x400139F")]
		public static readonly Color BgTabActive;

		[Token(Token = "0x40013A0")]
		public static readonly Color Accent;

		[Token(Token = "0x40013A1")]
		public static readonly Color Divider;

		[Token(Token = "0x40013A2")]
		public static readonly Color BtnPrimary;

		[Token(Token = "0x40013A3")]
		public static readonly Color BtnSuccess;

		[Token(Token = "0x40013A4")]
		public static readonly Color BtnDanger;

		[Token(Token = "0x40013A5")]
		public static readonly Color BtnNeutral;

		[Token(Token = "0x40013A6")]
		public static readonly Color TextPrimary;

		[Token(Token = "0x40013A7")]
		public static readonly Color TextSecondary;

		[Token(Token = "0x40013A8")]
		private static GUIStyle s_panelBox;

		[Token(Token = "0x40013A9")]
		private static GUIStyle s_headerBar;

		[Token(Token = "0x40013AA")]
		internal static GUIStyle s_section;

		[Token(Token = "0x40013AB")]
		internal static GUIStyle s_row;

		[Token(Token = "0x40013AC")]
		private static GUIStyle s_tabActive;

		[Token(Token = "0x40013AD")]
		internal static GUIStyle s_tabInactive;

		[Token(Token = "0x40013AE")]
		internal static GUIStyle s_title;

		[Token(Token = "0x40013AF")]
		internal static GUIStyle s_sectionHeader;

		[Token(Token = "0x40013B0")]
		internal static GUIStyle s_label;

		[Token(Token = "0x40013B1")]
		internal static GUIStyle s_subtleLabel;

		[Token(Token = "0x40013B2")]
		internal static GUIStyle s_textField;

		[Token(Token = "0x40013B3")]
		internal static GUIStyle s_buttonNeutral;

		[Token(Token = "0x40013B4")]
		internal static GUIStyle s_buttonPrimary;

		[Token(Token = "0x40013B5")]
		internal static GUIStyle s_buttonSuccess;

		[Token(Token = "0x40013B6")]
		internal static GUIStyle s_buttonDanger;

		[Token(Token = "0x40013B7")]
		internal static GUIStyle s_overlayButton;

		[Token(Token = "0x40013B8")]
		internal static GUIStyle s_closeButton;

		[Token(Token = "0x40013B9")]
		private static int s_initFrame;

		[Token(Token = "0x1700023D")]
		public static GUIStyle PanelBox
		{
			[Token(Token = "0x600185B")]
			[Address(RVA = "0x3D37F0C", Offset = "0x3D37F0C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_panelBox;
			}
		}

		[Token(Token = "0x1700023E")]
		public static GUIStyle HeaderBar
		{
			[Token(Token = "0x600185C")]
			[Address(RVA = "0x3D37F6C", Offset = "0x3D37F6C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_headerBar;
			}
		}

		[Token(Token = "0x1700023F")]
		public static GUIStyle Section
		{
			[Token(Token = "0x600185D")]
			[Address(RVA = "0x3D37FCC", Offset = "0x3D37FCC", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_section;
			}
		}

		[Token(Token = "0x17000240")]
		public static GUIStyle Row
		{
			[Token(Token = "0x600185E")]
			[Address(RVA = "0x3D3802C", Offset = "0x3D3802C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_row;
			}
		}

		[Token(Token = "0x17000241")]
		public static GUIStyle TabActive
		{
			[Token(Token = "0x600185F")]
			[Address(RVA = "0x3D36888", Offset = "0x3D36888", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_tabActive;
			}
		}

		[Token(Token = "0x17000242")]
		public static GUIStyle TabInactive
		{
			[Token(Token = "0x6001860")]
			[Address(RVA = "0x3D36828", Offset = "0x3D36828", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_tabInactive;
			}
		}

		[Token(Token = "0x17000243")]
		public static GUIStyle Title
		{
			[Token(Token = "0x6001861")]
			[Address(RVA = "0x3D36594", Offset = "0x3D36594", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_title;
			}
		}

		[Token(Token = "0x17000244")]
		public static GUIStyle SectionHeader
		{
			[Token(Token = "0x6001862")]
			[Address(RVA = "0x3D3808C", Offset = "0x3D3808C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_sectionHeader;
			}
		}

		[Token(Token = "0x17000245")]
		public static GUIStyle Label
		{
			[Token(Token = "0x6001863")]
			[Address(RVA = "0x3D380EC", Offset = "0x3D380EC", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_label;
			}
		}

		[Token(Token = "0x17000246")]
		public static GUIStyle SubtleLabel
		{
			[Token(Token = "0x6001864")]
			[Address(RVA = "0x3D3814C", Offset = "0x3D3814C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_subtleLabel;
			}
		}

		[Token(Token = "0x17000247")]
		public static GUIStyle TextField
		{
			[Token(Token = "0x6001865")]
			[Address(RVA = "0x3D381AC", Offset = "0x3D381AC", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_textField;
			}
		}

		[Token(Token = "0x17000248")]
		public static GUIStyle BtnNeutralStyle
		{
			[Token(Token = "0x6001866")]
			[Address(RVA = "0x3D3820C", Offset = "0x3D3820C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_buttonNeutral;
			}
		}

		[Token(Token = "0x17000249")]
		public static GUIStyle BtnPrimaryStyle
		{
			[Token(Token = "0x6001867")]
			[Address(RVA = "0x3D3826C", Offset = "0x3D3826C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_buttonPrimary;
			}
		}

		[Token(Token = "0x1700024A")]
		public static GUIStyle BtnSuccessStyle
		{
			[Token(Token = "0x6001868")]
			[Address(RVA = "0x3D382CC", Offset = "0x3D382CC", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_buttonSuccess;
			}
		}

		[Token(Token = "0x1700024B")]
		public static GUIStyle BtnDangerStyle
		{
			[Token(Token = "0x6001869")]
			[Address(RVA = "0x3D3832C", Offset = "0x3D3832C", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_buttonDanger;
			}
		}

		[Token(Token = "0x1700024C")]
		public static GUIStyle OverlayButton
		{
			[Token(Token = "0x600186A")]
			[Address(RVA = "0x3D37984", Offset = "0x3D37984", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_overlayButton;
			}
		}

		[Token(Token = "0x1700024D")]
		public static GUIStyle CloseButton
		{
			[Token(Token = "0x600186B")]
			[Address(RVA = "0x3D365F4", Offset = "0x3D365F4", Length = "0x60")]
			get
			{
				EnsureInit();
				return s_closeButton;
			}
		}

		[Token(Token = "0x6001857")]
		[Address(RVA = "0x3D35AC8", Offset = "0x3D35AC8", Length = "0x44")]
		public static float GetUiScale()
		{
			float dpi = Screen.dpi;
			float num = dpi / 160f;
			bool flag = dpi == 0f;
			bool flag2 = dpi < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag;
			if (!(flag3 && flag4))
			{
				num = 1f;
			}
			bool flag5 = num < 3f;
			bool flag6 = num == 3f;
			bool flag7 = num == num;
			bool flag8 = 3f == 3f;
			bool flag9 = flag7 && flag8;
			bool flag10 = !flag9;
			bool flag11 = flag5 == flag10;
			bool flag12 = !flag6;
			float result = ((!(flag11 && flag12)) ? num : 3f);
			if (num < 1f)
			{
				return 1f;
			}
			return result;
		}

		[Token(Token = "0x6001858")]
		[Address(RVA = "0x3D34FD8", Offset = "0x3D34FD8", Length = "0xAF0")]
		public static void EnsureInit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuStyle::EnsureInit");
		}

		[Token(Token = "0x6001859")]
		[Address(RVA = "0x3D37AE0", Offset = "0x3D37AE0", Length = "0x3E4")]
		private static GUIStyle MakeButtonStyle(Color bg, Color text, int fontSize, FontStyle fontStyle)
		{
			GUISkin skin = GUI.skin;
			if ((object)skin != null)
			{
				GUIStyle button = skin.button;
				GUIStyle gUIStyle = new GUIStyle(button);
				gUIStyle.fontSize = fontSize;
				gUIStyle.fontStyle = fontStyle;
				gUIStyle.alignment = TextAnchor.MiddleCenter;
				RectOffset padding = new RectOffset(8, 8, 6, 6);
				gUIStyle.padding = padding;
				RectOffset margin = new RectOffset(2, 2, 2, 2);
				gUIStyle.margin = margin;
				RectOffset border = new RectOffset(0, 0, 0, 0);
				gUIStyle.border = border;
				GUIStyleState normal = gUIStyle.normal;
				Texture2D background = TextureCache.Get(bg);
				normal.background = background;
				GUIStyleState normal2 = gUIStyle.normal;
				normal2.textColor = text;
				GUIStyleState hover = gUIStyle.hover;
				float num = bg.r + 0.15f;
				bool flag = num < 1f;
				bool flag2 = num == 1f;
				bool flag3 = num == num;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float num2 = ((!(flag7 && flag8)) ? num : 1f);
				float r = ((!(num < 0f)) ? num2 : 0f);
				float num3 = bg.g + 0.15f;
				bool flag9 = num3 < 1f;
				bool flag10 = num3 == 1f;
				bool flag11 = num3 == num3;
				bool flag12 = 1f == 1f;
				bool flag13 = flag11 && flag12;
				bool flag14 = !flag13;
				bool flag15 = flag9 == flag14;
				bool flag16 = !flag10;
				float num4 = ((!(flag15 && flag16)) ? num3 : 1f);
				float g = ((!(num3 < 0f)) ? num4 : 0f);
				float num5 = bg.b + 0.15f;
				bool flag17 = num5 < 1f;
				bool flag18 = num5 == 1f;
				bool flag19 = num5 == num5;
				bool flag20 = 1f == 1f;
				bool flag21 = flag19 && flag20;
				bool flag22 = !flag21;
				bool flag23 = flag17 == flag22;
				bool flag24 = !flag18;
				float num6 = ((!(flag23 && flag24)) ? num5 : 1f);
				float b = ((!(num5 < 0f)) ? num6 : 0f);
				Color color = default(Color);
				color.r = r;
				color.g = g;
				color.b = b;
				color.a = bg.a;
				Texture2D background2 = TextureCache.Get(color);
				hover.background = background2;
				GUIStyleState hover2 = gUIStyle.hover;
				hover2.textColor = text;
				GUIStyleState active = gUIStyle.active;
				float num7 = bg.r + -0.15f;
				bool flag25 = num7 < 1f;
				bool flag26 = num7 == 1f;
				bool flag27 = num7 == num7;
				bool flag28 = 1f == 1f;
				bool flag29 = flag27 && flag28;
				bool flag30 = !flag29;
				bool flag31 = flag25 == flag30;
				bool flag32 = !flag26;
				float num8 = ((!(flag31 && flag32)) ? num7 : 1f);
				float r2 = ((!(num7 < 0f)) ? num8 : 0f);
				float num9 = bg.g + -0.15f;
				bool flag33 = num9 < 1f;
				bool flag34 = num9 == 1f;
				bool flag35 = num9 == num9;
				bool flag36 = 1f == 1f;
				bool flag37 = flag35 && flag36;
				bool flag38 = !flag37;
				bool flag39 = flag33 == flag38;
				bool flag40 = !flag34;
				float num10 = ((!(flag39 && flag40)) ? num9 : 1f);
				float g2 = ((!(num9 < 0f)) ? num10 : 0f);
				float num11 = bg.b + -0.15f;
				bool flag41 = num11 < 1f;
				bool flag42 = num11 == 1f;
				bool flag43 = num11 == num11;
				bool flag44 = 1f == 1f;
				bool flag45 = flag43 && flag44;
				bool flag46 = !flag45;
				bool flag47 = flag41 == flag46;
				bool flag48 = !flag42;
				float num12 = ((!(flag47 && flag48)) ? num11 : 1f);
				float b2 = ((!(num11 < 0f)) ? num12 : 0f);
				Color color2 = default(Color);
				color2.r = r2;
				color2.g = g2;
				color2.b = b2;
				color2.a = bg.a;
				Texture2D background3 = TextureCache.Get(color2);
				active.background = background3;
				GUIStyleState active2 = gUIStyle.active;
				active2.textColor = text;
				return gUIStyle;
			}
			return (GUIStyle)(object)new NullReferenceException();
		}

		[Token(Token = "0x600185A")]
		[Address(RVA = "0x3D37EC4", Offset = "0x3D37EC4", Length = "0x48")]
		private static Color LightenColor(Color c, float amount)
		{
			float num = c.r + amount;
			bool flag = num < 1f;
			bool flag2 = num == 1f;
			bool flag3 = num == num;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float r = ((!(flag7 && flag8)) ? num : 1f);
			Color result = default(Color);
			if (num < 0f)
			{
				result = default(Color);
			}
			else
			{
				result.r = r;
			}
			float num2 = c.g + amount;
			bool flag9 = num2 < 1f;
			bool flag10 = num2 == 1f;
			bool flag11 = num2 == num2;
			bool flag12 = 1f == 1f;
			bool flag13 = flag11 && flag12;
			bool flag14 = !flag13;
			bool flag15 = flag9 == flag14;
			bool flag16 = !flag10;
			if (flag15 && flag16)
			{
			}
			if (num2 < 0f)
			{
			}
			float num3 = c.b + amount;
			bool flag17 = num3 < 1f;
			bool flag18 = num3 == 1f;
			bool flag19 = num3 == num3;
			bool flag20 = 1f == 1f;
			bool flag21 = flag19 && flag20;
			bool flag22 = !flag21;
			bool flag23 = flag17 == flag22;
			bool flag24 = !flag18;
			if (flag23 && flag24)
			{
			}
			if (num3 < 0f)
			{
			}
			return result;
		}

		[Token(Token = "0x600186C")]
		[Address(RVA = "0x3D3838C", Offset = "0x3D3838C", Length = "0x1BC")]
		public static void DrawDivider()
		{
			GUILayoutOption[] array = new GUILayoutOption[1];
			GUILayoutOption gUILayoutOption = GUILayout.ExpandWidth(expand: true);
			array[0] = gUILayoutOption;
			Rect rect = GUILayoutUtility.GetRect(1f, 2f, array);
			Color color = GUI.color;
			Color color2 = default(Color);
			color2.r = Divider.r;
			color2.g = Divider.g;
			color2.b = Divider.b;
			color2.a = Divider.a;
			GUI.color = color2;
			Texture2D white = TextureCache.White;
			GUI.DrawTexture(rect, white);
			GUI.color = color;
		}

		[Token(Token = "0x600186D")]
		[Address(RVA = "0x3D38548", Offset = "0x3D38548", Length = "0xDC")]
		static DebugMenuStyle()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuStyle::.cctor");
		}
	}
}
