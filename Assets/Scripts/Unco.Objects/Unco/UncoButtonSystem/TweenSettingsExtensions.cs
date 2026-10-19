using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;

namespace Unco.UncoButtonSystem
{
	[Token(Token = "0x200000D")]
	public static class TweenSettingsExtensions
	{
		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81BF9B4", Offset = "0x81BF9B4", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = 0x93B2000 + 0x4F7;\n\tv12 = ease < 0x1E;\n\tv14 = ~v12;\n\tv15 = ease - 0x1E;\n\tv17 = v15 == 0;\n\tv22 = ~v17;\n\tv23 = v14 & v22;\n\tif (v23) goto L_002F;\n\tv27 = *([v11 @ X19_v2 (System.Int32)+ease @ X0 (PrimeTween.Ease)]) << 2;\n\tv28 = 0x81BF9E4 + v27;\n\t// 25 IndirectJump v28 @ X9_v2 (System.Int32), ease @ X0 (PrimeTween.Ease), ease @ X0 (PrimeTween.Ease), methodInfo @ X1 (Il2CppMethodInfo), v30 @ X2, v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\nL_002F:\n\treturn ease;\n")]
		public static Ease Inverse(this Ease ease)
		{
			int num = 154869760 + 1271;
			bool flag = (uint)ease < 30u;
			bool flag2 = !flag;
			int num2 = (int)(ease - 30);
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X19_v2 (System.Int32)+ease @ X0 (PrimeTween.Ease)]");
				int num3 = (int)((nint)0 << 2);
				int num4 = 136051172 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v28 @ X9_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			return ease;
		}
	}
}
