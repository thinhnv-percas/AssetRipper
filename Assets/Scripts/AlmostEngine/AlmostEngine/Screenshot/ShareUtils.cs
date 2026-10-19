using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x200000B")]
	public class ShareUtils
	{
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x3C2EBC8", Offset = "0x3C2EBC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public static bool CanShare()
		{
			return false;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3C2EBD8", Offset = "0x3C2EBD8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2FC000 + 0x7E8;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::LogError(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public static void ShareImage(Texture2D texture, string screenshotName, string title = "", string subject = "", string description = "", TextureExporter.ImageFileFormat imageFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 70)
		{
			//IL_0022: Expected O, but got I4
			int num = 187678720 + 2024;
			Debug.LogError(num);
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x3C2EC6C", Offset = "0x3C2EC6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShareUtils()
		{
		}
	}
}
