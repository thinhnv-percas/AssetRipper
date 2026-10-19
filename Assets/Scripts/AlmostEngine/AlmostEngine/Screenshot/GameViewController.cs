using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000049")]
	public static class GameViewController
	{
		[Token(Token = "0x6000165")]
		[Address(RVA = "0x3C30B58", Offset = "0x3C30B58", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F3000 + 0x7F0;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::LogError(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public static void SaveCurrentGameViewSize()
		{
			//IL_0022: Expected O, but got I4
			int num = 187641856 + 2032;
			Debug.LogError(num);
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x3C30BEC", Offset = "0x3C30BEC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F3000 + 0x7F8;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::LogError(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public static void SetGameViewSize(int width, int height)
		{
			//IL_0022: Expected O, but got I4
			int num = 187641856 + 2040;
			Debug.LogError(num);
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x3C30C80", Offset = "0x3C30C80", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F3000 + 0x7F8;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::LogError(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public static void RestoreGameViewSize()
		{
			//IL_0022: Expected O, but got I4
			int num = 187641856 + 2040;
			Debug.LogError(num);
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x3C31CCC", Offset = "0x3C31CCC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Screen::get_width();\n\tv14 = UnityEngine.Screen::get_height();\n\treturn v11;\n")]
		public static Vector2 GetCurrentGameViewSize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameViewController::GetCurrentGameViewSize");
			return default;
		}
	}
}
