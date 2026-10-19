using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x2000344")]
	public static class WallTrapClosure
	{
		[Token(Token = "0x2000345")]
		public readonly struct Stats
		{
			[Token(Token = "0x40009A9")]
			[FieldOffset(Offset = "0x0")]
			public readonly int Added;

			[Token(Token = "0x40009AA")]
			[FieldOffset(Offset = "0x4")]
			public readonly int Removed;

			[Token(Token = "0x40009AB")]
			[FieldOffset(Offset = "0x8")]
			public readonly int Unresolved;

			[Token(Token = "0x6000DD6")]
			[Address(RVA = "0x3EFD614", Offset = "0x3EFD614", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Added = added;\n\tthis.Removed = removed;\n\tthis.Unresolved = unresolved;\n\treturn;\n")]
			public Stats(int added, int removed, int unresolved)
			{
				Added = added;
				Removed = removed;
				Unresolved = unresolved;
			}

			[Token(Token = "0x6000DD7")]
			[Address(RVA = "0x3EFDD10", Offset = "0x3EFDD10", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\treturnVal1 = System.String::Format(\"added={0} removed={1} unresolved={2}\", v54, v60, v66);\n\treturn returnVal1;\nL_0019:\n\tv49 = this.Added;\n\tv51 = 0xB7D5000 + 0x538;\n\tv54 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v49 @ stack_-44_v1 (System.Int32), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = this.Removed;\n\tv60 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v57 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv63 = this.Unresolved;\n\tv66 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v63 @ stack_-4C_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			public override string ToString()
			{
				int added = Added;
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int removed = Removed;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int unresolved = Unresolved;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				object arg3 = default(object);
				return $"added={arg} removed={arg2} unresolved={arg3}";
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000346")]
		private sealed class _003C_003Ec__DisplayClass1_0
		{
			[Token(Token = "0x40009AC")]
			[FieldOffset(Offset = "0x10")]
			public IGeneratorActions actions;

			[Token(Token = "0x40009AD")]
			[FieldOffset(Offset = "0x18")]
			public Vector2Int gridSize;

			[Token(Token = "0x6000DD8")]
			[Address(RVA = "0x3EFD60C", Offset = "0x3EFD60C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass1_0()
			{
			}

			internal bool _003CApply_003Eb__2(int x, int y)
			{
				int x2 = default(int);
				int y2 = default(int);
				GridCoord coord = new GridCoord(x2, y2);
				return actions.IsWallAt(coord);
			}
		}

		[Token(Token = "0x6000DD5")]
		[Address(RVA = "0x3EFBDCC", Offset = "0x3EFBDCC", Length = "0xB54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tgoto L_0059;\n\tv297 = v67 + 0x10;\n\tv67.actions = actions;\n\tv67.gridSize = gridSize;\n\tv100 = gridSize < 1;\n\tif (v100) goto L_FFFFFFFF;\n\tv250 = gridSize.y < 1;\nL_FFFFFFFF:\n\tv115 = v113;\nL_FFFFFFFF:\n\tv118 = v116;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv786 = v145;\nL_FFFFFFFF:\n\tv163 = v162;\nL_FFFFFFFF:\n\tv176 = gridSize.y;\nL_FFFFFFFF:\n\tv1496 = 0;\nL_FFFFFFFF:\n\tv181 = gridSize;\nL_FFFFFFFF:\n\tv184 = v67;\nL_FFFFFFFF:\n\tv1605 = 0;\nL_FFFFFFFF:\n\tv229 = gridSize;\n\tif (v250) goto L_0365;\n\tv309 = gridSize & 0x7FFFFFFF;\n\tv283 = v309;\n\tv301 = 0x21C1134(System.Boolean[2], &v283 @ stack_-88_v17 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv303 = v301 == 0;\nL_FFFFFFFF:\n\tv115 = v113;\nL_FFFFFFFF:\n\tv118 = v116;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv786 = v145;\nL_FFFFFFFF:\n\tv163 = v162;\nL_FFFFFFFF:\n\tv176 = gridSize.y;\nL_FFFFFFFF:\n\tv1496 = 0;\nL_FFFFFFFF:\n\tv181 = gridSize;\nL_FFFFFFFF:\n\tv184 = v67;\nL_FFFFFFFF:\n\tv229 = gridSize;\n\tif (v303) goto L_0390;\n\tv548 = v301 + 0x20;\n\tv229 = 0xB28F000 + 0xAE8;\nL_FFFFFFFF:\n\tv163 = v162;\nL_FFFFFFFF:\n\tv511 = 0;\n\tgoto L_00D0;\n\tv1215 = v511 < *([v924 @ X8_v78+10]);\n\tv885 = ~v1215;\n\tif (v885) goto L_0385;\n\tv747 = *([v924 @ X8_v78+10]) * v499;\n\tv973 = v511 + v747;\n\t*([v548 @ X19_v23+v973 @ X8_v80 (System.Int32)]) = v745;\n\tv499 = v499 + 1;\n\tv961 = v499 != v309;\nL_FFFFFFFF:\n\tv163 = 0;\n\tif (v961) goto L_0097;\n\tv511 = v511 + 1;\n\tv725 = v511 != gridSize.y;\nL_FFFFFFFF:\n\tv163 = 0;\n\tif (v725) goto L_FFFFFFFF;\n\tv1322 = new System.Func`3<System.Int32, System.Int32, System.Boolean>();\n\tSystem.Func`3<System.Int32, System.Int32, System.Boolean>::.ctor(v1322, v67, Il2CppMethodInfo);\n\tv1372 = new System.Func`3<System.Int32, System.Int32, System.Boolean>();\n\tSystem.Func`3<System.Int32, System.Int32, System.Boolean>::.ctor(v1372, v67, Il2CppMethodInfo);\n\tv1399 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapRepair::Plan(gridSize, gridSize.y, v301, v1322, v1372);\n\tv911 = v1399 == 0;\n\tif (v911) goto L_039D;\n\tv912 = v1399.Adds == 0;\n\tif (v912) goto L_039F;\n\tv1437 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v1399.Adds);\n\tv767 = v1437;\n\tv163 = 0xB7D5000 + 0x538;\n\tv1520 = log == 0;\n\tif (v1520) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv786 = v1372;\n\tv1677 = v67.actions == 0;\nL_FFFFFFFF:\n\tv118 = v1399;\nL_FFFFFFFF:\n\tv892 = Il2CppMethodInfo;\n\tif (v1677) goto L_0389;\n\tv1552 = v1437.Current;\n\tgoto L_017D;\n\tv1539 = v1437.Current;\n\tv1921 = \"il2cpp_vm_object_box\"(*([v163 @ X28_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+48]), &v1539 @ stack_-B4_v17 (_game.CoreSystem.New.GridEcsBinding.GridCoord), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1537 = v1552.y;\n\tv1935 = \"il2cpp_vm_object_box\"(*([v163 @ X28_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+48]), &v1537 @ stack_-B8_v17 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1570 = v1437.Current == 0;\n\tif (v1570) goto L_FFFFFFFF;\n\tv1543 = *([v1552 @ X25_v26 (_game.CoreSystem.New.GridEcsBinding.GridCoord)+10]);\n\tgoto L_0196;\nL_FFFFFFFF:\n\tv1543 = 0;\nL_019E:\n\tv1923 = v115 + 1;\n\tv1539 = v1437.Current;\n\tv1926 = \"il2cpp_vm_object_box\"(*([v163 @ X28_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+48]), &v1539 @ stack_-B4_v17 (_game.CoreSystem.New.GridEcsBinding.GridCoord), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1537 = v1552.y;\n\tv1939 = \"il2cpp_vm_object_box\"(*([v163 @ X28_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+48]), &v1537 @ stack_-B8_v17 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1949 = System.String::Format(\"[wall-trap] add {0},{1}\", v1926, v1939);\n\tSystem.Action`1<System.String>::Invoke(log, v1949);\nL_FFFFFFFF:\n\tv115 = v1923;\nL_FFFFFFFF:\n\tv1496 = v1607;\n\tgoto L_0147;\nL_FFFFFFFF:\n\tv118 = v1399;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv386 = &v767 @ stack_-B0_v12 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>);\nL_FFFFFFFF:\n\tv626 = 0;\nL_FFFFFFFF:\n\tv176 = gridSize.y;\nL_FFFFFFFF:\n\tv181 = gridSize;\nL_FFFFFFFF:\n\tv184 = v67;\nL_FFFFFFFF:\n\tv444 = 0xD;\nL_FFFFFFFF:\n\tv115 = v113;\nL_FFFFFFFF:\n\tv118 = v116;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv786 = v145;\nL_FFFFFFFF:\n\tv163 = v162;\nL_FFFFFFFF:\n\tv176 = v174;\nL_FFFFFFFF:\n\tv1496 = 0;\nL_FFFFFFFF:\n\tv181 = v179;\nL_FFFFFFFF:\n\tv184 = v182;\nL_FFFFFFFF:\n\tv1605 = 0;\nL_FFFFFFFF:\n\tv229 = gridSize;\n\tgoto L_0365;\nL_FFFFFFFF:\n\tv1605 = 0;\n\tv1678 = v67.actions == 0;\n\tif (v1678) goto L_FFFFFFFF;\n\tgoto L_01F8;\n\tv1605 = v1605 + 1;\n\tgoto L_0205;\nL_FFFFFFFF:\n\tv115 = v113;\nL_FFFFFFFF:\n\tv118 = v116;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv786 = v1372;\nL_FFFFFFFF:\n\tv384 = v1399;\nL_FFFFFFFF:\n\tv386 = &v767 @ stack_-B0_v12 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>);\nL_FFFFFFFF:\n\tv626 = 0;\nL_FFFFFFFF:\n\tv176 = gridSize.y;\nL_FFFFFFFF:\n\tv181 = gridSize;\nL_FFFFFFFF:\n\tv184 = v67;\nL_FFFFFFFF:\n\tv444 = 0xD;\n\tv416 = v444 == 0xD;\n\tif (v416) goto L_021E;\n\tv1395 = v444 == 0;\n\tv438 = ~v1395;\n\tif (v438) goto L_0365;\nL_021E:\n\tv914 = v384.Removes == 0;\n\tif (v914) goto L_03A3;\n\tv1411 = log == 0;\n\tv1421 = System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::GetEnumerator(v384.Removes);\n\tv767 = v1421;\n\tv1426 = v1411 == 0;\n\tv1427 = ~v1426;\n\tif (v1427) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1496 = 0;\n\tv1458 = *([v297 @ X23_v11 (System.Func`3<System.Int32, System.Int32, System.Boolean>)]);\n\tv1534 = *([v297 @ X23_v11 (System.Func`3<System.Int32, System.Int32, System.Boolean>)]) == 0;\nL_FFFFFFFF:\n\tv115 = v1605;\nL_FFFFFFFF:\n\tv893 = Il2CppMethodInfo;\n\tif (v1534) goto L_038C;\n\tv1459 = v1421.Current;\n\tv1609 = *([v1458 @ X25_v9 (Il2CppClass<System.Func`3<System.Int32, System.Int32, System.Boolean>>)]);\n\tv1681 = *([v1609 @ X8_v43+12E]);\n\tv1611 = *([v1609 @ X8_v43+12E]) == 0;\n\tif (v1611) goto L_0276;\n\tv1680 = *([v1609 @ X8_v43+B0]) + 8;\n\tv1680 = v1680 + 0x10;\n\tv1626 = v1681 - 1;\n\tv1628 = v1681 != 1;\nL_FFFFFFFF:\n\tv1681 = v1626;\n\tif (v1628) goto L_025C;\nL_0276:\n\tv1739 = 0x220C5E0(*([v297 @ X23_v11 (System.Func`3<System.Int32, System.Int32, System.Boolean>)]), v229.x, 0x19, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_027D;\nL_0278:\n\t;\n\tv1734 = *([v1680 @ X10_v18]) + 0x19;\n\tv1735 = v1734 << 4;\n\tv1736 = v1609 + v1735;\n\tv1739 = v1736 + 0x138;\n\tv1539 = v1421.Current;\n\tv1824 = \"il2cpp_vm_object_box\"(*([v163 @ X28_v5 (System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>+Enumerator<_game.CoreSystem.New.GridEcsBinding.GridCoord>)+48]), &v1539 @ stack_-B4_v17 (_game.CoreSystem.New.GridEcsBinding.GridCoord), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered\n// ... truncated")]
		public unsafe static Stats Apply(IGeneratorActions actions, Vector2Int gridSize, Action<string> log = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallTrapClosure::Apply");
			return default;
		}
	}
}
