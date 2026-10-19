using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x200035E")]
	public class DailyOrder
	{
		[Token(Token = "0x40009E7")]
		[FieldOffset(Offset = "0x10")]
		public List<DifficultyOrder> items;

		[Token(Token = "0x1700010B")]
		public unsafe int TotalCount
		{
			[Token(Token = "0x6000E09")]
			[Address(RVA = "0x3F02D10", Offset = "0x3F02D10", Length = "0x13C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv60 = System.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.DifficultyOrder>::GetEnumerator(this.items);\n\tv65 = v60._list;\n\tv69 = v60.Current;\n\tv163 = 0;\n\tv92 = v60.Current == 0;\n\tif (v92) goto L_0038;\n\tv93 = ~v69.count;\n\tv96 = v69.count & v93;\n\tv163 = v96 + v163;\n\tgoto L_0038;\nL_0046:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v65 @ stack_-48_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.DifficultyOrder>));\nL_004F:\n\treturn v163;\nL_0050:\n\tv61 = new System.NullReferenceException();\n\tv84 = methodInfo != 1;\n\tv111 = v61;\n\tif (v84) goto L_006B;\n\tv101 = 0x8BF5BC4(v61, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv118 = 0x8BF5BF4(v101, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v124);\n\tv110 = *([v101 @ X0_v11]) == 0;\n\tv163 = this;\n\tif (v110) goto L_004F;\n\tv108 = new System.OutOfMemoryException();\n\tv104 = *([v101 @ X0_v11]);\n\tv111 = v108;\n\treturn returnVal2;\nL_0021:\n\tv47 = this.items == 0;\n\tif (v47) goto L_0050;\nL_0038:\n\tv90 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v65 @ stack_-48_v3 (System.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.DifficultyOrder>));\n\tv116 = v90 == 0;\n\tif (v116) goto L_0046;\nL_006B:\n\tv114 = 0x319134C(&v104 @ stack_-58, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv120 = 0x8BF0368(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DailyOrder::get_TotalCount");
				return default;
			}
		}

		[Token(Token = "0x6000E0A")]
		[Address(RVA = "0x3F02E4C", Offset = "0x3F02E4C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.DifficultyOrder>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.LevelGeneratorSystem.Orchestrator.DifficultyOrder>::.ctor(v48);\n\tthis.items = v48;\n")]
		public DailyOrder()
		{
			List<DifficultyOrder> list = new List<DifficultyOrder>();
			items = list;
		}
	}
}
