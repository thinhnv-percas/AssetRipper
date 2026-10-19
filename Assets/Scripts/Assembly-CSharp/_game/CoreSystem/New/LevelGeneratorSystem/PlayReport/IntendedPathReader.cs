using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PlayReport
{
	[Token(Token = "0x200034B")]
	public static class IntendedPathReader
	{
		[Token(Token = "0x6000DE7")]
		[Address(RVA = "0x3EFE9CC", Offset = "0x3EFE9CC", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv80 = steps.Length < 1;\n\tif (v80) goto L_00AC;\n\tv185 = v56 == 0;\n\tif (v185) goto L_00BC;\n\tv293 = steps + 0x28;\nL_FFFFFFFF:\n\tv292 = 0;\n\tgoto L_006A;\nL_006A:\n\tv101 = *([v293 @ X22_v7]) != 0;\n\tif (v101) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv99 = \"\";\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv99 = *([v293 @ X22_v7]);\n\tgoto L_0090;\nL_0090:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`3<System.Int32, System.Int32, System.Object>>::Add(v56, v87);\n\tv293 = v293 + 0x10;\n\tv292 = v292 + 1;\n\tv120 = v292 < steps.Length;\n\tif (v120) goto L_006A;\nL_00AC:\n\treturn v56;\nL_00BC:\n\tv269 = *([steps @ X0 (_game.CoreGameKit.BaseLayer.LevelSystem.IntendedStep[])+28]) != 0;\n\tif (v269) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv311 = \"\";\n\tgoto L_00C2;\nL_FFFFFFFF:\n\tv311 = *([steps @ X0 (_game.CoreGameKit.BaseLayer.LevelSystem.IntendedStep[])+28]);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0029:\n\tv56 = new System.Collections.Generic.List`1<System.ValueTuple`3<System.Int32, System.Int32, System.String>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`3<System.Int32, System.Int32, System.String>>::.ctor(v56);\n\tv65 = steps == 0;\n\tif (v65) goto L_00AC;\nL_0074:\n\tSystem.ValueTuple`3<System.Int32, System.Int32, System.Object>::.ctor(&v87 @ stack_-60_v6 (System.ValueTuple`3<System.Int32, System.Int32, System.Object>), *([v293 @ X22_v7-8]), *([v293 @ X22_v7-4]), v99);\nL_00C2:\n\tv87 = 0;\n\tSystem.ValueTuple`3<System.Int32, System.Int32, System.Object>::.ctor(&v87 @ stack_-60_v6 (System.ValueTuple`3<System.Int32, System.Int32, System.Object>), &steps[0], *([steps @ X0 (_game.CoreGameKit.BaseLayer.LevelSystem.IntendedStep[])+24]), v311);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static IReadOnlyList<(int, int, string)> Read(IntendedStep[] steps)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IntendedPathReader::Read");
			return default;
		}
	}
}
