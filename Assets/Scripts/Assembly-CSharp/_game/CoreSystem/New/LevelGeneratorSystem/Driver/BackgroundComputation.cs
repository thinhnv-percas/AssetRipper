using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x200036F")]
	public sealed class BackgroundComputation<T>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000370")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000A61")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000A62")]
			public static Action<Task<T>> _003C_003E9__7_0;

			[Token(Token = "0x6000E25")]
			[Address(RVA = "0x4F9D0F8", Offset = "0x4F9D0F8", Length = "0x1A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv19 = *([v16 @ X0_v1 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv20 = v19 == 0;\n\tif (v20) goto L_002B;\n\tv22 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv25 = *([v22 @ X0_v42 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv26 = v25 == 0;\n\tv47 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv52 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v26) goto L_0034;\nL_0016:\n\tv49 = new v47();\n\tv59 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv77 = *([v59 @ X0_v41 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]);\n\tv62 = *([v59 @ X0_v41 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tv100 = v49;\n\tv74 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv107 = v49;\n\tv103 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tif (v64) goto L_003E;\nL_001F:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv93 = *([v76 @ X0_v37+C0]);\n\tv94 = *([v93 @ X8_v43+8]);\n\tv98 = *([v94 @ X8_v44]);\n\tv96 = *([v90 @ X0_v38 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv97 = v96 == 0;\n\tv103 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tif (v97) goto L_0044;\n\tv105 = *([v94 @ X8_v44]);\n\tv107 = v100;\n\tgoto L_0048;\nL_002B:\n\tv27 = 0x220C238(Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = *([v27 @ X0_v34+C0]);\n\tv47 = *([v54 @ X8_v38]);\n\tv56 = *([v47 @ X0_v39 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv57 = v56 == 0;\n\tv44 = ~v57;\n\tv52 = v47;\n\tif (v44) goto L_0016;\nL_0034:\n\tv53 = 0x220C238(v52, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv65 = new v53();\n\tv75 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv77 = *([v75 @ X0_v33 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]);\n\tv88 = *([v75 @ X0_v33 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv71 = v88 == 0;\n\tv100 = v65;\n\tv74 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv107 = v65;\n\tv103 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tif (v71) goto L_001F;\nL_003E:\n\tv83 = Il2CppMethodInfo;\n\tv98 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tv85 = v77 & 1;\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tv100 = v107;\n\tv105 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tif (v87) goto L_0048;\nL_0044:\n\tv104 = 0x220C238(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = v98;\n\tv107 = v100;\nL_0048:\n\tv105(v114, v107, Il2CppMethodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv115 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv118 = *([v115 @ X0_v5 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv119 = v118 == 0;\n\tif (v119) goto L_0070;\n\tv121 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv124 = *([v121 @ X0_v25 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv141 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v125) goto L_0079;\nL_0057:\n\tv133.<>9 = v107;\n\tv134 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv137 = *([v134 @ X0_v24 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv138 = v137 == 0;\n\tv161 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tif (v138) goto L_0083;\nL_005F:\n\tv154 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv157 = *([v154 @ X0_v22 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv158 = v157 == 0;\n\tv184 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v158) goto L_008C;\nL_006F:\n\treturn;\nL_0070:\n\tv126 = 0x220C238(Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = *([v126 @ X0_v16+C0]);\n\tv141 = *([v143 @ X8_v16+10]);\n\tv145 = *([v141 @ X0_v13 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv128 = ~v146;\n\tif (v128) goto L_0057;\nL_0079:\n\tv142 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = *([v142 @ X0_v14+B8]);\n\t*([v163 @ X8_v13]) = v107;\n\tv152 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tv165 = *([v152 @ X0_v15 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\n\tv161 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>;\n\tif (v148) goto L_005F;\nL_0083:\n\tv162 = 0x220C238(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = *([v162 @ X0_v11+C0]);\n\tv184 = *([v186 @ X8_v9+10]);\n\tv188 = *([v184 @ X0_v6 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tv168 = ~v189;\n\tif (v168) goto L_006F;\nL_008C:\n\tv185 = 0x220C238(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec()
			{
				//IL_019d: Expected O, but got I
				//IL_01a5: Expected I, but got O
				//IL_0099: Expected O, but got I
				//IL_0277: Expected O, but got I
				//IL_02b0: Expected O, but got I
				//IL_0118: Expected O, but got I
				//IL_0128: Expected O, but got I
				//IL_021a: Expected O, but got I
				//IL_040b: Expected O, but got I
				//IL_04e9: Expected O, but got I
				//IL_0478: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v42 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X0_v34+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v39 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec _003C_003Ec2 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				_003C_003Ec _003C_003Ec3 = _003C_003Ec2;
				nint num9 = 0;
				_003C_003Ec _003C_003Ec4 = _003C_003Ec2;
				nint num10 = 0;
				if (flag4)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_04ca:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v11+C0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v9+10]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v6 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0537;
				IL_03ac:
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v22 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
				int num13 = (int)((nint)0 & (nint)1);
				bool flag5 = num13 == 0;
				num11 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0537;
				IL_0537:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				return;
				IL_007e:
				_003C_003Ec _003C_003Ec5 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag6 = num15 == 0;
				bool flag7 = !flag6;
				_003C_003Ec3 = _003C_003Ec5;
				num9 = 0;
				_003C_003Ec4 = _003C_003Ec5;
				num10 = 0;
				if (!flag7)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_0269:
				nint num16 = 0;
				object obj4 = num16;
				int num17 = (int)((nint)obj2 & 1);
				bool flag8 = num17 == 0;
				bool flag9 = !flag8;
				_003C_003Ec3 = _003C_003Ec4;
				object obj5 = num16;
				if (!flag9)
				{
					goto IL_02be;
				}
				goto IL_02e2;
				IL_00f3:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v37+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v43+8]");
				object obj7 = 0;
				obj4 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v38 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag10 = num19 == 0;
				num10 = 0;
				if (flag10)
				{
					goto IL_02be;
				}
				obj5 = obj7;
				_003C_003Ec4 = _003C_003Ec3;
				goto IL_02e2;
				IL_02be:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				obj5 = obj4;
				_003C_003Ec4 = _003C_003Ec3;
				goto IL_02e2;
				IL_0364:
				_003C_003E9 = _003C_003Ec4;
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v24 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				int num21 = (int)((nint)0 & (nint)1);
				bool flag11 = num21 == 0;
				nint num22 = 0;
				if (!flag11)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
				IL_02e2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105 @ X21_v1 (should have been resolved before IL gen)");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v5 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v25 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
					int num25 = (int)((nint)0 & (nint)1);
					bool flag12 = num25 == 0;
					nint num26 = 0;
					if (!flag12)
					{
						goto IL_0364;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16+10]");
					nint num26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v13 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0364;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v14+B8]");
				object obj9 = 0;
				obj9 = _003C_003Ec4;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1+<>c>)+135]");
				int num28 = (int)((nint)0 & (nint)1);
				bool flag13 = num28 == 0;
				bool flag14 = !flag13;
				num22 = 0;
				if (flag14)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
			}

			[Token(Token = "0x6000E26")]
			[Address(RVA = "0x4F9D298", Offset = "0x4F9D298", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CObserve_003Eb__7_0(Task<T> x)
			{
				AggregateException exception = x.Exception;
			}
		}

		[Token(Token = "0x4000A60")]
		[FieldOffset(Offset = "0x0")]
		private Task<T> _task;

		[Token(Token = "0x1700010D")]
		public bool Started
		{
			[Token(Token = "0x6000E1F")]
			[Address(RVA = "0x6E8E640", Offset = "0x6E8E640", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._task == 0;\n\tv11 = ~v6;\n\treturn v11;\n")]
			get
			{
				bool flag = _task == null;
				return !flag;
			}
		}

		[Token(Token = "0x1700010E")]
		public bool IsRunning
		{
			[Token(Token = "0x6000E20")]
			[Address(RVA = "0x6E8E650", Offset = "0x6E8E650", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._task == 0;\n\treturnVal1 = this._task;\n\tif (v2) goto L_000D;\n\tv10 = System.Threading.Tasks.Task::get_IsCompleted(this._task);\n\tv22 = v10 ^ 1;\n\treturnVal1 = v22;\nL_000D:\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BackgroundComputation::get_IsRunning");
				return default;
			}
		}

		[Token(Token = "0x6000E21")]
		[Address(RVA = "0x6E8E674", Offset = "0x6E8E674", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv47 = this._task == 0;\n\tif (v47) goto L_002A;\n\treturn;\nL_002A:\n\tgoto L_0031;\nL_0031:\n\tv94 = System.Threading.Tasks.Task::Run(work);\n\tthis._task = v94;\n\treturn;\nL_003F:\n\tv49 = 0xB28B000 + 0x600;\n\tv63 = new v49();\n\tv97 = 0xB312000 + 0x670;\n\tSystem.ArgumentNullException::.ctor(v63, v97);\n\tthrow v63;\nL_0016:\n\tv44 = work == 0;\n\tif (v44) goto L_003F;\n")]
		public void Start(Func<T> work)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BackgroundComputation::Start");
		}

		[Token(Token = "0x6000E22")]
		[Address(RVA = "0x6E8E754", Offset = "0x6E8E754", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_0025;\n\treturnVal1 = System.Threading.Tasks.Task::get_IsCompleted(this._task);\n\tv99 = ~returnVal1;\n\tif (v99) goto L_0081;\n\tthis._task = 0;\n\tv193 = System.Threading.Tasks.Task::get_IsFaulted(this._task);\n\tv194 = ~v193;\n\tif (v194) goto L_0065;\n\tv197 = System.Threading.Tasks.Task::get_Exception(this._task);\n\tv212 = v197 == 0;\n\tif (v212) goto L_0057;\n\tv224 = System.AggregateException::GetBaseException(v197);\n\tv226 = v224 == 0;\n\tv227 = ~v226;\nL_FFFFFFFF:\n\tv252 = v224;\n\tif (v227) goto L_005E;\nL_0057:\n\tv237 = new System.Exception();\n\tSystem.Exception::.ctor(v237, \"background computation faulted\");\nL_FFFFFFFF:\n\tv252 = v237;\nL_005E:\n\t*([error @ X2 (System.Exception&)]) = v252;\n\tgoto L_FFFFFFFF;\nL_0065:\n\tv200 = Il2CppMethodInfo;\n\tv202 = v66;\n\t*([v200 @ X1_v9 (Il2CppMethodInfo)+10])(v207, *([v200 @ X1_v9 (Il2CppMethodInfo)]), Il2CppMethodInfo, this._task, &v202 @ stack_-60_v4 (System.Byte*), v66, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv211 = 0x8BF6A1C(result, v66, *([v60 @ X8_v8 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_007D;\nL_007D:\n\tv242 = 0x21C0FD4(Il2CppClass<T>, result, v66, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\treturn returnVal1;\nL_009B:\n\tv128 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0025:\n\tv60 = Il2CppClass<T>;\n\tv64 = *([v60 @ X8_v8 (Il2CppClass<T>)+FC]) + 0xF;\n\tv65 = v64 & 0x1FFFFFFF0;\n\t// 42 StackAlloc v66 @ X22_v2 (System.Byte*), v65 @ X9_v2 (System.Int32)\n\tv70 = 0x8BF5F18(result, *([v60 @ X8_v8 (Il2CppClass<T>)+FC]), error, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([error @ X2 (System.Exception&)]) = 0;\n\tv78 = this._task == 0;\nL_FFFFFFFF:\n\treturnVal1 = this._task;\n\tif (v78) goto L_0081;\nL_0081:\n\tv106 = *([A4731E0]);\n\tv117 = *([v106 @ X9_v5]) != *([v31 @ X8_v2]);\n\tif (v117) goto L_009B;\n")]
		public unsafe bool TryConsume(out T result, out Exception error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BackgroundComputation::TryConsume");
			result = default;
			error = default;
			return default;
		}

		[Token(Token = "0x6000E23")]
		[Address(RVA = "0x6E8E938", Offset = "0x6E8E938", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._task = 0;\n\tv35 = this._task == 0;\n\tif (v35) goto L_0030;\n\tv38 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv41 = *([v38 @ X0_v3 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0031;\n\tgoto L_001D;\nL_001D:\n\tv89 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv92 = *([v89 @ X0_v40 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv93 = v92 == 0;\nL_FFFFFFFF:\n\tv105 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v93) goto L_0040;\nL_0023:\n\tv107 = *([v105 @ X0_v38 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+B8]);\n\tv126 = *([v107 @ X9_v22 (Il2CppStaticFields<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+8]);\n\tv109 = *([v107 @ X9_v22 (Il2CppStaticFields<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+8]) == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0094;\n\tgoto L_0048;\nL_0030:\n\treturn;\nL_0031:\n\tv51 = 0x220C238(Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv98 = *([v51 @ X0_v37+E4]) == 0;\n\tv85 = ~v98;\n\tif (v85) goto L_001D;\n\tv106 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv118 = *([v106 @ X0_v36 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv119 = v118 == 0;\n\tv104 = ~v119;\nL_FFFFFFFF:\n\tv105 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv114 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v104) goto L_0023;\nL_0040:\n\tv115 = 0x220C238(v114, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv130 = *([v115 @ X0_v33+B8]);\n\tv126 = *([v130 @ X9_v17+8]);\n\tv140 = *([v130 @ X9_v17+8]) == 0;\n\tv135 = ~v140;\n\tif (v135) goto L_0094;\nL_0048:\n\tv147 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv150 = *([v147 @ X0_v7 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv151 = v150 == 0;\n\tif (v151) goto L_0095;\n\tgoto L_0053;\nL_0053:\n\tv162 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv165 = *([v162 @ X0_v31 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv166 = v165 == 0;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v166) goto L_00A4;\nL_005A:\n\tv125 = v180.<>9;\nL_FFFFFFFF:\n\tv211 = Il2CppClass<System.Action`1<System.Threading.Tasks.Task`1<T>>>;\n\tgoto L_0063;\nL_0063:\n\tv212 = new v211();\n\tv221 = System.Action`1<System.Threading.Tasks.Task`1<T>>::.ctor(v212, v125, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv233 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tgoto L_0078;\nL_FFFFFFFF:\n\tv126 = v212;\nL_0095:\n\tv154 = 0x220C238(Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv171 = *([v154 @ X0_v14+E4]) == 0;\n\tv158 = ~v171;\n\tif (v158) goto L_0053;\n\tv179 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tv195 = *([v179 @ X0_v13 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+135]) & 1;\n\tv196 = v195 == 0;\n\tv177 = ~v196;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>;\n\tif (v177) goto L_005A;\nL_00A4:\n\tv192 = 0x220C238(v191, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = *([v192 @ X0_v9+B8]);\n\tv125 = *([v200 @ X9_v4]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv211 = Il2CppClass<System.Action`1<System.Threading.Tasks.Task`1<T>>>;\n\tgoto L_0063;\nL_0094:\n\tv77 = System.Threading.Tasks.Task`1<T>::ContinueWith(v77, v126, 0x50000);\nL_0094:\n\treturn;\nL_0078:\n\tv129 = *([v233 @ X0_v19 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+B8]);\n\t*([v129 @ X9_v10 (Il2CppStaticFields<_game.CoreSystem.New.LevelGeneratorSystem.Driver.BackgroundComputation`1<T>+<>c<T>>)+8]) = v212;\n\tgoto L_FFFFFFFF;\n")]
		public void Observe()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BackgroundComputation::Observe");
		}

		[Token(Token = "0x6000E24")]
		[Address(RVA = "0x6E8EB30", Offset = "0x6E8EB30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public BackgroundComputation()
		{
		}
	}
}
