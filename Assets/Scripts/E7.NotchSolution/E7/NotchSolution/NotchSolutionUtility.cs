using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Token(Token = "0x200000B")]
	public static class NotchSolutionUtility
	{
		[Token(Token = "0x400001A")]
		internal static Rect defaultSafeArea;

		[Token(Token = "0x400001B")]
		internal static Rect[] defaultCutouts;

		[Token(Token = "0x400001C")]
		internal static Rect cachedScreenSafeArea;

		[Token(Token = "0x400001D")]
		internal static Rect cachedScreenSafeAreaRelative;

		[Token(Token = "0x400001E")]
		internal static bool safeAreaRelativeCached;

		[Token(Token = "0x400001F")]
		internal static Rect[] cachedScreenCutouts;

		[Token(Token = "0x4000020")]
		internal static Rect[] cachedScreenCutoutsRelative;

		[Token(Token = "0x4000021")]
		internal static bool cutoutsRelativeCached;

		[Token(Token = "0x17000009")]
		public static bool ShouldUseNotchSimulatorValue
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x3F44B50", Offset = "0x3F44B50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000A")]
		internal static Rect ScreenSafeAreaRelative
		{
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x3F44B58", Offset = "0x3F44B58", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0027:\n\tv63 = UnityEngine.Screen::get_currentResolution();\n\tv64 = v63;\n\tv68 = UnityEngine.Resolution::get_width(&v64 @ stack_-50_v1 (UnityEngine.Resolution));\n\tv71 = UnityEngine.Screen::get_currentResolution();\n\tv64 = v71;\n\tv76 = UnityEngine.Resolution::get_height(&v64 @ stack_-50_v1 (UnityEngine.Resolution));\n\treturnVal1 = v48 / v68;\n\tv80 = v48.y / v76;\n\tv81 = v48.width / v68;\n\tv83.cachedScreenSafeAreaRelative.x = returnVal1;\n\tv83.cachedScreenSafeAreaRelative.y = v80;\n\tv84 = v48.height / v76;\n\tv83.cachedScreenSafeAreaRelative.width = v81;\n\tv83.cachedScreenSafeAreaRelative.height = v84;\n\tv83.cachedScreenSafeArea.x = v48;\n\tv83.cachedScreenSafeArea.y = v48.y;\n\tv83.cachedScreenSafeArea.width = v48.width;\n\tv83.cachedScreenSafeArea.height = v48.height;\n\tv83.safeAreaRelativeCached = 1;\n\treturn returnVal1;\nL_0018:\n\tv48 = UnityEngine.Screen::get_safeArea();\n\tgoto L_0027;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUtility::get_ScreenSafeAreaRelative");
				return default;
			}
		}

		[Token(Token = "0x1700000B")]
		internal static Rect[] ScreenCutoutsRelative
		{
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x3F45CC8", Offset = "0x3F45CC8", Length = "0x1AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\t// 35 NewArr v58 @ X0_v7 (UnityEngine.Rect[]), typeof(UnityEngine.Rect[]), v47.Length\n\tgoto L_002E;\n\tv91 = 2;\nL_0054:\n\tv89 = v142.cachedScreenCutoutsRelative;\n\tv294 = UnityEngine.Screen::get_currentResolution();\n\tv305 = v294;\n\tv309 = UnityEngine.Resolution::get_width(&v305 @ stack_-50_v5 (UnityEngine.Resolution));\n\tv311 = UnityEngine.Screen::get_currentResolution();\n\tv305 = v311;\n\tv136 = UnityEngine.Resolution::get_height(&v305 @ stack_-50_v5 (UnityEngine.Resolution));\n\t// 117 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv235 = *([v47 @ X0_v3 (UnityEngine.Rect[])+v91 @ X22_v5 (System.Int32)*16]) / v309;\n\t*([v89 @ X23_v6 (UnityEngine.Rect[])+v91 @ X22_v5 (System.Int32)*16]) = v235;\n\tv231 = v91 - 1;\n\tv91 = v91 + 1;\n\tv239 = v231 < v47.Length;\n\tif (v239) goto L_0044;\nL_008D:\n\tgoto L_0092;\nL_0019:\n\tv47 = UnityEngine.Screen::get_cutouts();\nL_002E:\n\tv153.cachedScreenCutoutsRelative = v58;\n\tv226 = v47.Length < 1;\n\tif (v226) goto L_008D;\nL_0044:\n\tgoto L_0054;\nL_0092:\n\tv283.cachedScreenCutouts = v47;\n\tv210.cutoutsRelativeCached = 1;\n\treturn v210.cachedScreenCutoutsRelative;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Rect[] cutouts = Screen.cutouts;
				Rect[] array = new Rect[cutouts.Length];
				cachedScreenCutoutsRelative = array;
				if (cutouts.Length >= 1)
				{
					int num = 2;
					int num3;
					do
					{
						Rect[] array2 = cachedScreenCutoutsRelative;
						Resolution currentResolution = Screen.currentResolution;
						Resolution resolution = currentResolution;
						int width = resolution.width;
						Resolution currentResolution2 = Screen.currentResolution;
						resolution = currentResolution2;
						int height = resolution.height;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v3 (UnityEngine.Rect[])+v91 @ X22_v5 (System.Int32)*16]");
						float num2 = 0f / (float)width;
						num3 = num - 1;
						num++;
					}
					while (num3 < cutouts.Length);
				}
				cachedScreenCutouts = cutouts;
				cutoutsRelativeCached = true;
				return cachedScreenCutoutsRelative;
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3F44A54", Offset = "0x3F44A54", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Screen::get_width();\n\tv14 = UnityEngine.Screen::get_height();\n\tv17 = v11 - v14;\n\tv18 = v17 < 0;\n\tv19 = v17 == 0;\n\tv20 = v11 ^ v14;\n\tv21 = v11 ^ v17;\n\tv22 = v20 & v21;\n\tv23 = v22 < 0;\n\tv25 = v18 == v23;\n\tv26 = ~v19;\n\tv27 = v25 & v26;\n\tv28 = ~v27;\n\tif (v28) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 3;\n\tgoto L_0023;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0023:\n\treturn returnVal1;\n")]
		internal static ScreenOrientation GetCurrentOrientation()
		{
			int width = Screen.width;
			int height = Screen.height;
			int num = width - height;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = width ^ height;
			int num3 = width ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (flag4 && flag5)
			{
				return ScreenOrientation.LandscapeLeft;
			}
			return ScreenOrientation.Portrait;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3F45C3C", Offset = "0x3F45C3C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = UnityEngine.Screen::get_currentResolution();\n\tv28 = v27;\n\tv33 = UnityEngine.Resolution::get_width(&v28 @ stack_-50_v1 (UnityEngine.Resolution));\n\tv36 = UnityEngine.Screen::get_currentResolution();\n\tv28 = v36;\n\tv41 = UnityEngine.Resolution::get_height(&v28 @ stack_-50_v1 (UnityEngine.Resolution));\n\treturnVal1 = absoluteRect / v33;\n\treturn returnVal1;\n")]
		private static Rect ToScreenRelativeRect(Rect absoluteRect)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUtility::ToScreenRelativeRect");
			return default;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x3F45E74", Offset = "0x3F45E74", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv47.defaultSafeArea = *([9246290]);\n\t// 33 NewArr v52 @ X0_v3 (UnityEngine.Rect[]), typeof(UnityEngine.Rect[]), 0\n\tv57.defaultCutouts = v52;\n\treturn;\n")]
		static NotchSolutionUtility()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUtility::.cctor");
		}
	}
}
