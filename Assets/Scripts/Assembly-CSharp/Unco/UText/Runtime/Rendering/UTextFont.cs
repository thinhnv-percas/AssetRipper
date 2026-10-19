using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Unco.UText.Runtime.Layout;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[CreateAssetMenu(fileName = "UTextFont", menuName = "UText/Font")]
	[Token(Token = "0x20007AD")]
	public class UTextFont : ScriptableObject
	{
		[Tooltip("Regular face. Required — every other slot falls back to this.")]
		[Token(Token = "0x4001983")]
		[FieldOffset(Offset = "0x18")]
		public UTextSdfFontAsset RegularAtlas;

		[Tooltip("CSS-scale weight (100..900) baked into the Regular atlas. Set to whatever face you actually baked there — e.g. 700 if you used Bold as the regular weight.")]
		[Token(Token = "0x4001984")]
		[FieldOffset(Offset = "0x20")]
		public int RegularWeight;

		[Tooltip("Bold face. Falls back to RegularAtlas.")]
		[Token(Token = "0x4001985")]
		[FieldOffset(Offset = "0x28")]
		public UTextSdfFontAsset BoldAtlas;

		[Tooltip("CSS-scale weight (100..900) baked into the Bold atlas. 700 = standard Bold; 900 = Black. The midpoint between RegularWeight and this drives Figma weight → bold-face selection.")]
		[Token(Token = "0x4001986")]
		[FieldOffset(Offset = "0x30")]
		public int BoldWeight;

		[Tooltip("Italic face. Falls back to RegularAtlas.")]
		[Token(Token = "0x4001987")]
		[FieldOffset(Offset = "0x38")]
		public UTextSdfFontAsset ItalicAtlas;

		[Tooltip("Bold-italic face. Falls back to BoldAtlas → ItalicAtlas → RegularAtlas.")]
		[Token(Token = "0x4001988")]
		[FieldOffset(Offset = "0x40")]
		public UTextSdfFontAsset BoldItalicAtlas;

		[Tooltip("Default line spacing. Added to LayoutSettings.LineSpacing at render time.")]
		[Token(Token = "0x4001989")]
		[FieldOffset(Offset = "0x48")]
		public float LineSpacing;

		[Tooltip("Default letter spacing. Added to LayoutSettings.LetterSpacing at render time.")]
		[Token(Token = "0x400198A")]
		[FieldOffset(Offset = "0x4C")]
		public float LetterSpacing;

		[Tooltip("Default word spacing. Added to LayoutSettings.WordSpacing at render time.")]
		[Token(Token = "0x400198B")]
		[FieldOffset(Offset = "0x50")]
		public float WordSpacing;

		[CompilerGenerated]
		[Token(Token = "0x400198C")]
		private static Action<UTextFont> OnChanged;

		[Token(Token = "0x17000328")]
		public bool HasBoldFace
		{
			[Token(Token = "0x600205B")]
			[Address(RVA = "0x3D9EC00", Offset = "0x3D9EC00", Length = "0xCC")]
			get
			{
				if (BoldAtlas != null)
				{
					return true;
				}
				return BoldItalicAtlas != null;
			}
		}

		[Token(Token = "0x17000329")]
		public bool HasItalicFace
		{
			[Token(Token = "0x600205C")]
			[Address(RVA = "0x3D9ECCC", Offset = "0x3D9ECCC", Length = "0xCC")]
			get
			{
				if (ItalicAtlas != null)
				{
					return true;
				}
				return BoldItalicAtlas != null;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6002059")]
		[Address(RVA = "0x3D9EA60", Offset = "0x3D9EA60", Length = "0xD0")]
		public static void add_OnChanged(Action<UTextFont> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextFont::add_OnChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600205A")]
		[Address(RVA = "0x3D9EB30", Offset = "0x3D9EB30", Length = "0xD0")]
		public static void remove_OnChanged(Action<UTextFont> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextFont::remove_OnChanged");
		}

		[Token(Token = "0x600205D")]
		[Address(RVA = "0x3D9ED98", Offset = "0x3D9ED98", Length = "0x44")]
		public bool IsBoldWeight(int weight)
		{
			int num = RegularWeight;
			bool flag = RegularWeight < 0;
			bool flag2 = RegularWeight == 0;
			int num2 = RegularWeight ^ RegularWeight;
			int num3 = RegularWeight & num2;
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (!(flag4 && flag5))
			{
				num = 400;
			}
			int num4 = BoldWeight;
			bool flag6 = BoldWeight < 0;
			bool flag7 = BoldWeight == 0;
			int num5 = BoldWeight ^ BoldWeight;
			int num6 = BoldWeight & num5;
			bool flag8 = num6 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			if (!(flag9 && flag10))
			{
				num4 = 700;
			}
			bool flag11 = (uint)num4 < (uint)num;
			bool flag12 = !flag11;
			int num7 = num4 - num;
			bool flag13 = num7 == 0;
			int num8 = num + num4;
			int num9 = num8 + 1;
			int num10 = num9 >> 31;
			int num11 = num9 + num10;
			int num12 = num11 >> 1;
			bool flag14 = !flag12;
			if (flag14 || flag13)
			{
				num12 = num4;
			}
			int num13 = num12 - weight;
			bool flag15 = num13 < 0;
			bool flag16 = num13 == 0;
			int num14 = num12 ^ weight;
			int num15 = num12 ^ num13;
			int num16 = num14 & num15;
			bool flag17 = num16 < 0;
			bool flag18 = flag15 == flag17;
			bool flag19 = !flag18;
			return flag19 || flag16;
		}

		[Token(Token = "0x600205E")]
		[Address(RVA = "0x3D99AD0", Offset = "0x3D99AD0", Length = "0xC0")]
		public static UTextFont GetOrDefault(UTextFont font)
		{
			if (font != null)
			{
				return font;
			}
			string defaultFontPath = UTextSettings.DefaultFontPath;
			return Resources.Load<UTextFont>(defaultFontPath);
		}

		[Token(Token = "0x600205F")]
		[Address(RVA = "0x3D99FBC", Offset = "0x3D99FBC", Length = "0x30")]
		public void ApplyDefaults(ref LayoutSettings layout)
		{
			float lineSpacing = layout.LineSpacing + LineSpacing;
			layout.LineSpacing = lineSpacing;
			float letterSpacing = layout.LetterSpacing + LetterSpacing;
			layout.LetterSpacing = letterSpacing;
			float wordSpacing = layout.WordSpacing + WordSpacing;
			layout.WordSpacing = wordSpacing;
		}

		[Token(Token = "0x6002060")]
		[Address(RVA = "0x3D99FEC", Offset = "0x3D99FEC", Length = "0x174")]
		public UTextSdfFontAsset ResolveAtlas(bool bold, bool italic)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextFont::ResolveAtlas");
			return default;
		}

		[Token(Token = "0x6002061")]
		[Address(RVA = "0x3D9EDDC", Offset = "0x3D9EDDC", Length = "0x7C")]
		public void RaiseChanged()
		{
			if (OnChanged != null)
			{
				OnChanged(this);
			}
		}

		[Token(Token = "0x6002062")]
		[Address(RVA = "0x3D9EE58", Offset = "0x3D9EE58", Length = "0x18")]
		public UTextFont()
		{
			RegularWeight = 400;
			BoldWeight = 700;
		}
	}
}
