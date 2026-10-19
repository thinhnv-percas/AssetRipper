using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B4")]
	internal static class TextureCache
	{
		[Token(Token = "0x40013BA")]
		private static readonly Dictionary<int, Texture2D> s_textures;

		[Token(Token = "0x40013BB")]
		private static Texture2D s_white;

		[Token(Token = "0x1700024E")]
		public static Texture2D White
		{
			[Token(Token = "0x600186E")]
			[Address(RVA = "0x3D36654", Offset = "0x3D36654", Length = "0x1D4")]
			get
			{
				//IL_0021: Expected O, but got I4
				int num = 187244544 + 1440;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v47+E4]");
				if ((nint)0 != 0)
				{
					if (!(s_white == null))
					{
						goto IL_007e;
					}
				}
				else if (!(s_white == null))
				{
					goto IL_007e;
				}
				Texture2D texture2D = new Texture2D(1, 1);
				s_white = texture2D;
				Color color = default(Color);
				color.r = 1f;
				color.g = 1f;
				color.b = 1f;
				color.a = 1f;
				s_white.SetPixel(0, 0, color);
				s_white.Apply();
				s_white.hideFlags = HideFlags.HideAndDontSave;
				goto IL_007e;
				IL_007e:
				return s_white;
			}
		}

		[Token(Token = "0x600186F")]
		[Address(RVA = "0x3D35B0C", Offset = "0x3D35B0C", Length = "0x224")]
		public unsafe static Texture2D Get(Color color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextureCache::Get");
			return default;
		}

		[Token(Token = "0x6001870")]
		[Address(RVA = "0x3D38624", Offset = "0x3D38624", Length = "0x94")]
		static TextureCache()
		{
			Dictionary<int, Texture2D> dictionary = new Dictionary<int, Texture2D>();
			s_textures = dictionary;
		}
	}
}
