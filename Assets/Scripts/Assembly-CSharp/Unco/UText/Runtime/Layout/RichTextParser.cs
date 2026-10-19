using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;
using UnityEngine;
using UnityEngine.Pool;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007BB")]
	public static class RichTextParser
	{
		[Token(Token = "0x20007BC")]
		private struct SizeFrame
		{
			[Token(Token = "0x40019D7")]
			[FieldOffset(Offset = "0x0")]
			public float Multiplier;

			[Token(Token = "0x40019D8")]
			[FieldOffset(Offset = "0x4")]
			public float Absolute;
		}

		[Token(Token = "0x600207D")]
		[Address(RVA = "0x3D9A160", Offset = "0x3D9A160", Length = "0x7A0")]
		public unsafe static void Parse(string text, IRichTextStyleRegistry styleRegistry, IRichTextSpriteRegistry spriteRegistry, List<Element> elementsOut, List<RunStyle> runStylesOut, List<UTextStyle> resolvedStylesOut, List<UTextSpriteAsset> resolvedSpriteAtlasesOut)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::Parse");
		}

		[Token(Token = "0x600207E")]
		[Address(RVA = "0x3DA00AC", Offset = "0x3DA00AC", Length = "0x78")]
		private static int FindTagClose(string text, int openAt)
		{
			int num = openAt;
			while (true)
			{
				num++;
				if (num >= text.Length)
				{
					break;
				}
				char c = text[num];
				if (c == '\n' || c == '<')
				{
					break;
				}
				if (c == '>')
				{
					return num;
				}
			}
			return -1;
		}

		[Token(Token = "0x600207F")]
		[Address(RVA = "0x3DA0124", Offset = "0x3DA0124", Length = "0x120")]
		private static bool IsClosingTagNamed(string text, int bodyStart, int bodyEnd, string name)
		{
			bool result;
			if (bodyStart < bodyEnd)
			{
				char c = text[bodyStart];
				if (c == '/')
				{
					int num = bodyStart + 1;
					int num2 = bodyEnd - num;
					if (num2 == name.Length)
					{
						if (name.Length < 1)
						{
							goto IL_0150;
						}
						int num3 = 0;
						while (true)
						{
							int index = num + num3;
							char c2 = text[index];
							char c3 = name[num3];
							char c4 = char.ToLowerInvariant(c2);
							char c5 = char.ToLowerInvariant(c3);
							int num4 = c4 - c5;
							bool flag = num4 == 0;
							bool flag2 = c4 != c5;
							result = flag;
							if (flag2)
							{
								break;
							}
							num3++;
							if (num3 < name.Length)
							{
								continue;
							}
							goto IL_0150;
						}
						goto IL_0164;
					}
				}
			}
			return false;
			IL_0150:
			result = true;
			goto IL_0164;
			IL_0164:
			return result;
		}

		[Token(Token = "0x6002080")]
		[Address(RVA = "0x3DA0A48", Offset = "0x3DA0A48", Length = "0x11C")]
		private static bool NameEquals(string text, int from, int to, string name)
		{
			int num = to - from;
			if (num == name.Length)
			{
				if (num >= 1)
				{
					int num2 = to - 1;
					int num3 = 0;
					int num4 = from;
					bool result;
					bool flag;
					do
					{
						char c = text[num4];
						char c2 = name[num3];
						char c3 = char.ToLowerInvariant(c);
						char c4 = char.ToLowerInvariant(c2);
						int num5 = c3 - c4;
						result = num5 == 0;
						if (c3 != c4)
						{
							break;
						}
						num3++;
						int num6 = num4 + 1;
						flag = num2 != num4;
						num4 = num6;
					}
					while (flag);
					return result;
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x6002081")]
		[Address(RVA = "0x3DA0B64", Offset = "0x3DA0B64", Length = "0x28")]
		private static bool IsNameChar(char c)
		{
			int num = c & -33;
			int num2 = num - 65;
			int num3 = c - 48;
			bool flag2;
			if (c - 95 != 0)
			{
				bool flag = (uint)num3 < 10u;
				flag2 = !flag;
			}
			else
			{
				flag2 = false;
			}
			bool result = !flag2;
			if ((uint)num2 < 26u)
			{
				return true;
			}
			return result;
		}

		[Token(Token = "0x6002082")]
		[Address(RVA = "0x3DA0244", Offset = "0x3DA0244", Length = "0x500")]
		private static bool TryHandleTag(string text, int bodyStart, int bodyEnd, ref bool noparse, List<SizeFrame> sizeStack, List<Color> colorStack, List<int> styleStack, IRichTextStyleRegistry styleRegistry, IRichTextSpriteRegistry spriteRegistry, Dictionary<UTextStyle, int> styleAssetIndex, List<UTextStyle> resolvedStylesOut, Dictionary<UTextSpriteAsset, int> spriteAtlasIndex, List<UTextSpriteAsset> resolvedSpriteAtlasesOut, List<Element> elementsOut, List<RunStyle> runStylesOut, Dictionary<RunStyle, int> runStyleIndex, ref bool rsiDirty)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::TryHandleTag");
			return default;
		}

		[Token(Token = "0x6002083")]
		[Address(RVA = "0x3DA0B8C", Offset = "0x3DA0B8C", Length = "0x1A4")]
		private static bool TryParseSizeOpen(string text, int from, int to, List<SizeFrame> stack, ref bool dirty)
		{
			bool flag;
			if (from < to)
			{
				char c = text[from];
				if (c == '=')
				{
					int num = from + 1;
					if (num < to)
					{
						int num2 = to - 1;
						char c2 = text[num2];
						int num3 = ((c2 != '%') ? to : num2);
						int length = num3 - num;
						if (num3 > num)
						{
							string s = text.Substring(num, length);
							CultureInfo invariantCulture = CultureInfo.InvariantCulture;
							flag = float.TryParse(s, NumberStyles.Float, invariantCulture, out var result);
							if (!flag)
							{
								goto IL_01f3;
							}
							if (!(result < 0f))
							{
								float num4 = result / 100f;
								if (c2 != '%')
								{
									num4 = 1f;
								}
								if (c2 == '%')
								{
									float num5 = 0f;
								}
								else
								{
									float num5 = result;
								}
								Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @31884B0");
								dirty = true;
								return true;
							}
						}
					}
				}
				return false;
			}
			flag = false;
			goto IL_01f3;
			IL_01f3:
			return flag;
		}

		[Token(Token = "0x6002084")]
		[Address(RVA = "0x3DA0D30", Offset = "0x3DA0D30", Length = "0x164")]
		private static bool TryParseColorOpen(string text, int from, int to, List<Color> stack, ref bool dirty)
		{
			//IL_00f6: Expected F4, but got O
			//IL_0103: Expected F4, but got O
			//IL_0110: Expected F4, but got O
			bool flag;
			if (from < to)
			{
				char c = text[from];
				if (c == '=')
				{
					int num = from + 1;
					int length = to - num;
					if (to > num)
					{
						string htmlString = text.Substring(num, length);
						flag = ColorUtility.TryParseHtmlString(htmlString, out var color);
						if (flag)
						{
							Color item = default(Color);
							item.r = color.r;
							object obj = default(object);
							item.g = (float)obj;
							object obj2 = default(object);
							item.b = (float)obj2;
							object obj3 = default(object);
							item.a = (float)obj3;
							stack.Add(item);
							dirty = true;
							return true;
						}
						goto IL_0155;
					}
				}
				return false;
			}
			flag = false;
			goto IL_0155;
			IL_0155:
			return flag;
		}

		[Token(Token = "0x6002085")]
		[Address(RVA = "0x3DA0E94", Offset = "0x3DA0E94", Length = "0x26C")]
		private static bool TryParseStyleOpen(string text, int from, int to, List<int> stack, IRichTextStyleRegistry registry, Dictionary<UTextStyle, int> indexMap, List<UTextStyle> styles, ref bool dirty)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::TryParseStyleOpen");
			return default;
		}

		[Token(Token = "0x6002086")]
		[Address(RVA = "0x3DA1100", Offset = "0x3DA1100", Length = "0x6A0")]
		private unsafe static bool TryParseSprite(string text, int from, int to, IRichTextSpriteRegistry registry, Dictionary<UTextSpriteAsset, int> spriteAtlasIndexMap, List<UTextSpriteAsset> resolvedSpriteAtlasesOut, List<Element> elementsOut, List<RunStyle> runStylesOut, Dictionary<RunStyle, int> runStyleIndexMap, List<SizeFrame> sizeStack, List<Color> colorStack, List<int> styleStack)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::TryParseSprite");
			return default;
		}

		[Token(Token = "0x6002087")]
		[Address(RVA = "0x3DA17A0", Offset = "0x3DA17A0", Length = "0x194")]
		private static bool TryReadAttrValue(string text, ref int p, int to, out string val, out bool quoted)
		{
			val = null;
			quoted = default(bool);
			val = null;
			quoted = false;
			if (p < to)
			{
				char c = text[p];
				if (c == '"')
				{
					quoted = true;
					int num = p + 1;
					if (num < to)
					{
						int num2 = 2;
						int num3 = num;
						while (true)
						{
							char c2 = text[num3];
							if (c2 == '"')
							{
								break;
							}
							num3++;
							num2++;
							if (to != num3)
							{
								continue;
							}
							goto IL_0207;
						}
						int length = num2 - 2;
						string text2 = text.Substring(num, length);
						val = text2;
						int num4 = num3 + 1;
						p = num4;
						goto IL_028e;
					}
				}
				else if (p < to)
				{
					int index = p;
					int num5;
					bool flag;
					do
					{
						char c3 = text[index];
						num5 = p;
						if (c3 == ' ')
						{
							break;
						}
						char c4 = text[p];
						num5 = p;
						if (c4 == '\t')
						{
							break;
						}
						num5 = (p = num5 + 1);
						flag = num5 < to;
						index = num5;
					}
					while (flag);
					int length2 = num5 - p;
					if (num5 != p)
					{
						string text3 = text.Substring(p, length2);
						val = text3;
						goto IL_028e;
					}
				}
			}
			goto IL_0207;
			IL_028e:
			return true;
			IL_0207:
			return false;
		}

		[Token(Token = "0x6002088")]
		[Address(RVA = "0x3DA0744", Offset = "0x3DA0744", Length = "0x190")]
		private static RunStyle BuildCurrent(List<SizeFrame> sizeStack, List<Color> colorStack, List<int> styleStack)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::BuildCurrent");
			return default;
		}

		[Token(Token = "0x6002089")]
		[Address(RVA = "0x3DA08D4", Offset = "0x3DA08D4", Length = "0x174")]
		private unsafe static int GetOrAddRunStyle(RunStyle rs, List<RunStyle> list, Dictionary<RunStyle, int> map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RichTextParser::GetOrAddRunStyle");
			return default;
		}
	}
}
