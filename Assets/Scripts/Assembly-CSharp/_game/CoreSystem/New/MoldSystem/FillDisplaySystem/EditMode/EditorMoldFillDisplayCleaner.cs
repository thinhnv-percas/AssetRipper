using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.EditMode
{
	[Token(Token = "0x20002CE")]
	public class EditorMoldFillDisplayCleaner : MoldFillDisplayCleanerBase
	{
		[Token(Token = "0x6000C6D")]
		[Address(RVA = "0x3ED6504", Offset = "0x3ED6504", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv51 = UnityEngine.Object::op_Inequality(obj, 0);\n\tv58 = ~v51;\n\tif (v58) goto L_0042;\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(obj);\n\treturn;\nL_0042:\n\treturn;\n")]
		protected override void DestroyObject(Object obj)
		{
			if (obj != null)
			{
				Object.DestroyImmediate(obj);
			}
		}

		[Token(Token = "0x6000C6E")]
		[Address(RVA = "0x3ED62D0", Offset = "0x3ED62D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public EditorMoldFillDisplayCleaner()
		{
		}
	}
}
