using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x200028E")]
	public static class GridBrushRegistry
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200028F")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000808")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000809")]
			public static Func<Type, bool> _003C_003E9__3_0;

			[Token(Token = "0x400080A")]
			public static Comparison<(IGridBrush brush, int order)> _003C_003E9__3_1;

			[Token(Token = "0x400080B")]
			public static Func<(IGridBrush brush, int order), IGridBrush> _003C_003E9__3_2;

			[Token(Token = "0x6000B65")]
			[Address(RVA = "0x3EC7594", Offset = "0x3EC7594", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.CoreSystem.New.Shared.EditMode.Brushes.GridBrushRegistry+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000B66")]
			[Address(RVA = "0x3EC75F8", Offset = "0x3EC75F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CDiscover_003Eb__3_0(Type t)
			{
				//IL_001f: Expected O, but got I
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X0_v1+E4]");
				if ((nint)0 != 0)
				{
					return t != null;
				}
				return t != null;
			}

			internal unsafe int _003CDiscover_003Eb__3_1((IGridBrush brush, int order) a, (IGridBrush brush, int order) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GridBrushRegistry._003C_003Ec::_003CDiscover_003Eb__3_1");
				return default;
			}

			internal IGridBrush _003CDiscover_003Eb__3_2((IGridBrush brush, int order) p)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GridBrushRegistry._003C_003Ec::_003CDiscover_003Eb__3_2");
				return default;
			}
		}

		[Token(Token = "0x4000807")]
		private static Dictionary<string, IReadOnlyList<IGridBrush>> _byGridId;

		[Token(Token = "0x6000B62")]
		[Address(RVA = "0x3EC68F4", Offset = "0x3EC68F4", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78E81C]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0051;\n\tv85 = v24._byGridId;\n\tv26 = v24._byGridId == 0;\nL_FFFFFFFF:\n\tv47 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv47 = 0;\n\tif (v26) goto L_0059;\nL_0016:\n\tv53 = gridId == 0;\nL_FFFFFFFF:\n\tv69 = v85;\n\tif (v53) goto L_0061;\nL_FFFFFFFF:\n\tv89 = gridId;\nL_0020:\n\tv96 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>::TryGetValue(v85, v89, &v47 @ stack_-38_v15 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>));\n\tv107 = v96 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0046;\n\tgoto L_002B;\nL_002B:\n\tv157 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>;\n\tv160 = *([v157 @ X0_v35 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>)+135]) & 1;\n\tv161 = v160 == 0;\nL_FFFFFFFF:\n\tv165 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>;\n\tif (v161) goto L_0073;\nL_0033:\n\tgoto L_003B;\nL_003B:\n\tgoto L_0046;\nL_0051:\n\t*([B78E81C]) = 1;\n\tv85 = v52._byGridId;\n\tv105 = v52._byGridId == 0;\n\tv50 = ~v105;\nL_FFFFFFFF:\n\tv47 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv47 = 0;\n\tif (v50) goto L_0016;\nL_0059:\n\t_game.CoreSystem.New.Shared.EditMode.Brushes.GridBrushRegistry::Discover();\n\tv85 = v67._byGridId;\n\tv81 = gridId == 0;\n\tv65 = ~v81;\nL_FFFFFFFF:\n\tv69 = v67._byGridId;\n\tif (v65) goto L_FFFFFFFF;\nL_0061:\n\tv74 = 0xB7D5000 + 0x538;\n\tv75 = *([v74 @ X8_v16 (System.Int32)+90]);\n\tv76 = *([v75 @ X8_v17+B8]);\n\tv89 = *([v76 @ X8_v18]);\n\tv78 = v69 == 0;\n\tv79 = ~v78;\nL_FFFFFFFF:\n\tv85 = v69;\n\tif (v79) goto L_0020;\n\tthrow System.NullReferenceException;\n\tv122 = System.Array::Empty();\n\tv151 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>;\n\tv154 = *([v151 @ X0_v11 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>)+135]) & 1;\n\tv155 = v154 == 0;\n\tv156 = ~v155;\nL_FFFFFFFF:\n\tv165 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>;\n\tif (v156) goto L_0033;\nL_0073:\n\tv171 = 0x220C238(v165, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = *([v171 @ X0_v7+E4]) == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_003B;\n\tgoto L_0080;\nL_0080:\n\tgoto L_0046;\nL_0046:\n\treturn v137.Value;\n")]
		public static IReadOnlyList<IGridBrush> Brushes(string gridId)
		{
			//IL_01b3: Expected O, but got I
			//IL_01c3: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78E81C]");
			Dictionary<string, IReadOnlyList<IGridBrush>> dictionary;
			IReadOnlyList<IGridBrush> readOnlyList;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				dictionary = _byGridId;
				bool flag = _byGridId == null;
				readOnlyList = null;
				readOnlyList = null;
				if (!flag)
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				dictionary = _byGridId;
				bool flag2 = _byGridId == null;
				bool flag3 = !flag2;
				readOnlyList = null;
				readOnlyList = null;
				if (flag3)
				{
					goto IL_0061;
				}
			}
			Discover();
			dictionary = _byGridId;
			bool flag4 = gridId == null;
			bool flag5 = !flag4;
			Dictionary<string, IReadOnlyList<IGridBrush>> dictionary2 = _byGridId;
			if (flag5)
			{
				goto IL_0082;
			}
			goto IL_0194;
			IL_0082:
			string key = gridId;
			goto IL_008f;
			IL_008f:
			if (!dictionary.TryGetValue(key, out readOnlyList))
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X0_v35 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>)+135]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag6 = num2 == 0;
				nint num3 = 0;
				if (flag6)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X0_v7+E4]");
					if ((nint)0 != 0)
					{
					}
				}
			}
			return Array.Empty<IGridBrush>();
			IL_0194:
			int num4 = 192761856 + 1336;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v16 (System.Int32)+90]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v17+B8]");
			object obj2 = 0;
			key = (string)obj2;
			bool flag7 = dictionary2 == null;
			bool flag8 = !flag7;
			dictionary = dictionary2;
			if (!flag8)
			{
				throw new NullReferenceException();
			}
			goto IL_008f;
			IL_0061:
			bool flag9 = gridId == null;
			dictionary2 = dictionary;
			if (!flag9)
			{
				goto IL_0082;
			}
			goto IL_0194;
		}

		[Token(Token = "0x6000B63")]
		[Address(RVA = "0x3EC7544", Offset = "0x3EC7544", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv40._byGridId = 0;\n\treturn;\n")]
		public static void Invalidate()
		{
			_byGridId = null;
		}

		[Token(Token = "0x6000B64")]
		[Address(RVA = "0x3EC6A70", Offset = "0x3EC6A70", Length = "0xAD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_007D;\nL_008C:\n\tv90 = System.Type::GetTypeFromHandle(_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush);\n\tv96 = System.AppDomain::get_CurrentDomain();\n\tv106 = System.AppDomain::GetAssemblies(v96);\n\tv421 = v106.Length < 1;\n\tif (v421) goto L_0295;\n\tv430 = 0;\n\tv431 = v127;\n\tv509 = 0;\n\tv455 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush;\n\tv297 = 0;\n\tgoto L_00B8;\nL_00A9:\n\tv297 = v297 + 1;\n\tv442 = v297 >= v106.Length;\n\tif (v442) goto L_0295;\nL_00B8:\n\tv534 = v106[v297 @ X21_v14 (System.Int32)];\n\tv517 = v106[v297 @ X21_v14 (System.Int32)] == 0;\n\tif (v517) goto L_0215;\n\tv300 = *([v534 @ X0_v73]);\n\tv509 = *([v300 @ X8_v58+250]);\n\t*([v300 @ X8_v58+248])(v268, v106[v297 @ X21_v14 (System.Int32)], *([v300 @ X8_v58+250]), v439, v643, v43, v44, v45, v46, v430, v48, v49, v50, v51, v52, v53, v54);\n\tv289 = v268 + 0x20;\n\tv561 = v90 == 0;\n\tif (v561) goto L_00DF;\n\tv611 = *([v268 @ X0_v75+18]) < 1;\n\tif (v611) goto L_00A9;\n\tv636 = v430;\n\tv637 = v431;\n\tv643 = v643;\n\tv294 = 0;\n\tgoto L_012B;\nL_00DF:\n\tv622 = *([v268 @ X0_v75+18]) < 1;\n\tif (v622) goto L_00A9;\n\tv293 = 0;\n\tgoto L_00F0;\nL_00E3:\n\tv455 = v293 + 1;\n\tv649 = v455 >= *([v268 @ X0_v75+18]);\n\tv293 = v455;\n\tif (v649) goto L_00A9;\nL_00F0:\n\t;\n\tv712 = *([v78 @ X24_v2 (System.Int32)+E0]);\n\tv713 = *([v712 @ X0_v77+E4]) == 0;\n\tif (v713) goto L_0102;\n\tv752 = System.Type::op_Equality(*([v289 @ X19_v17+v293 @ X20_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]), 0);\n\tv768 = v752 == 0;\n\tv769 = ~v768;\n\tv439 = 0;\n\tv509 = 0;\n\tif (v769) goto L_00E3;\n\tv170 = 0;\n\tgoto L_010B;\nL_0102:\n\tv773 = System.Type::op_Equality(*([v289 @ X19_v17+v293 @ X20_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]), 0);\n\tv840 = v773 == 0;\n\tv836 = ~v840;\n\tv439 = 0;\n\tv509 = 0;\n\tv170 = 0;\n\tif (v836) goto L_00E3;\nL_010B:\n\tv835 = System.Type::get_IsAbstract(*([v289 @ X19_v17+v293 @ X20_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv954 = v835 == 0;\n\tv837 = ~v954;\n\tv439 = v170;\n\tv509 = 0;\n\tif (v837) goto L_00E3;\n\tv270 = System.Type::get_IsInterface(*([v289 @ X19_v17+v293 @ X20_v13 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv985 = ~v270;\n\tv280 = ~v985;\n\tv439 = v170;\n\tv509 = 0;\n\tif (v280) goto L_00E3;\n\tv258 = 0;\n\tv291 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush;\n\tgoto L_0342;\nL_011D:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Object, System.Int32>>::Add(v1091, v134);\n\tv636 = v134;\n\tv637 = 0;\n\tv643 = Il2CppMethodInfo;\n\tv439 = v1117;\n\tv509 = v134;\nL_011E:\n\tv455 = v294 + 1;\n\tv650 = v455 >= *([v268 @ X0_v75+18]);\n\tv430 = v636;\n\tv431 = v637;\n\tv294 = v455;\n\tif (v650) goto L_00A9;\nL_012B:\n\t;\n\tv704 = *([v78 @ X24_v2 (System.Int32)+E0]);\n\tv705 = *([v704 @ X0_v90+E4]) == 0;\n\tif (v705) goto L_013D;\n\tv747 = System.Type::op_Equality(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]), 0);\n\tv761 = v747 == 0;\n\tv762 = ~v761;\n\tv439 = 0;\n\tv509 = 0;\n\tif (v762) goto L_011E;\n\tv171 = 0;\n\tgoto L_0146;\nL_013D:\n\tv766 = System.Type::op_Equality(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]), 0);\n\tv833 = v766 == 0;\n\tv821 = ~v833;\n\tv439 = 0;\n\tv509 = 0;\n\tv171 = 0;\n\tif (v821) goto L_011E;\nL_0146:\n\tv816 = System.Type::get_IsAbstract(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv952 = v816 == 0;\n\tv822 = ~v952;\n\tv439 = v171;\n\tv509 = 0;\n\tif (v822) goto L_011E;\n\tv817 = System.Type::get_IsInterface(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv984 = v817 == 0;\n\tv823 = ~v984;\n\tv439 = v171;\n\tv509 = 0;\n\tif (v823) goto L_011E;\n\tv828 = *([v90 @ X0_v7 (System.Type)]);\n\tv439 = *([v828 @ X8_v65 (Il2CppClass<System.Type>)+2C0]);\n\tv818 = System.Type::IsAssignableFrom(v90, *([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv824 = v818 == 0;\n\tv509 = *([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]);\n\tif (v824) goto L_011E;\n\tv819 = System.Reflection.CustomAttributeExtensions::GetCustomAttribute(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]), 0);\n\tv825 = v819 == 0;\n\tv439 = Il2CppMethodInfo;\n\tv509 = 0;\n\tif (v825) goto L_011E;\n\tv1045 = System.Activator::CreateInstance(*([v289 @ X19_v17+v294 @ X20_v16 (Il2CppClass<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>)*8]));\n\tv1051 = v1045 == 0;\n\tif (v1051) goto L_017C;\n\tv1057 = 0x21C11D0(v1045, _game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv516 = v1057 == 0;\n\tif (v516) goto L_01CE;\n\tv1073 = v819.GridId;\n\tv1066 = v819.GridId == 0;\n\tv147 = v1057;\n\tv149 = v1057;\n\tif (v1066) goto L_0180;\nL_0177:\n\tv1071 = v1075 == 0;\n\tv282 = ~v1071;\n\tv149 = v147;\n\tif (v282) goto L_018B;\n\tv258 = 0;\n\tv291 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush;\n\tgoto L_0342;\nL_017C:\n\tv1073 = v819.GridId;\n\tv1060 = v819.GridId == 0;\n\tv1061 = ~v1060;\n\tv147 = 0;\n\tv149 = 0;\n\tif (v1061) goto L_0177;\nL_0180:\n\tv1068 = *([v78 @ X24_v2 (System.Int32)+90]);\n\tv304 = *([v1068 @ X8_v87+B8]);\n\tv1073 = *([v304 @ X8_v88]);\nL_018B:\n\tv1084 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>>::TryGetValue(v1075, v1073, &v1082 @ stack_-68_v9 (System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>));\n\tv1086 = v1084 == 0;\n\tv1087 = ~v1086;\n\tif (v1087) goto L_01AA;\n\tv1091 = new System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>::.ctor(v1091);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>>::set_Item(v1075, v1073, v1091);\n\tv1082 = v1091;\nL_01AA:\n\tSystem.ValueTuple`2<System.Object, System.Int32>::.ctor(&v134 @ stack_-D0 (System.ValueTuple`2<System.Object, System.Int32>), v149, v819.Order);\n\tgoto L_011D;\nL_01CE:\n\tv512 = new System.InvalidCastException();\n\tv431 = v637;\n\tv585 = _game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush;\n\tv511 = v512;\n\tv890 = v294;\n\tgoto L_0358;\nL_0215:\n\tv513 = new System.NullReferenceException();\n\tv585 = v509;\n\tv511 = v513;\n\tv890 = v455;\n\tgoto L_0358;\nL_0295:\n\tv548 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>>::get_Count(v1075);\n\tv556 = new System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush>>::.ctor(v556, v548);\n\tv628 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>>::GetEnumerator(v1075);\n\tv323 = v628._dictionary;\n\tgoto L_02C4;\nL_02C4:\n\tv843 = v841.<>9__3_1 == 0;\n\tv844 = ~v843;\n\tv585 = Il2CppMethodInfo;\n\tv405 = v841.<>9__3_1;\n\tif (v844) goto L_02E8;\n\tgoto L_02D2;\nL_02D2:\n\tgoto L_02DA;\nL_02E8:\n\tv395 = v774 == 0;\n\tv431 = &v323 @ stack_-90_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.ValueTuple`2<_game.CoreSystem.New.Shared.EditMode.Brushes.IGridBrush, System.Int32>>>);\n\tv134 = 0;\n// ... truncated")]
		private unsafe static void Discover()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridBrushRegistry::Discover");
		}
	}
}
