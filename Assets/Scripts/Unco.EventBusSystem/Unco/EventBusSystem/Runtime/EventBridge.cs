using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.EventBusSystem.Runtime
{
	[Token(Token = "0x2000007")]
	public class EventBridge : IDisposable
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003C_003Ec__5<TEvent> where TEvent : IEvent
		{
			[Token(Token = "0x400000D")]
			public static readonly _003C_003Ec__5<TEvent> _003C_003E9;

			[Token(Token = "0x400000E")]
			public static Func<TEvent, TEvent> _003C_003E9__5_0;

			[Token(Token = "0x6000012")]
			[Address(RVA = "0x4FFB4BC", Offset = "0x4FFB4BC", Length = "0x1A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv19 = *([v16 @ X0_v1 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv20 = v19 == 0;\n\tif (v20) goto L_002B;\n\tv22 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv25 = *([v22 @ X0_v42 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv26 = v25 == 0;\n\tv47 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv52 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v26) goto L_0034;\nL_0016:\n\tv49 = new v47();\n\tv59 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv77 = *([v59 @ X0_v41 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]);\n\tv62 = *([v59 @ X0_v41 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tv100 = v49;\n\tv74 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv107 = v49;\n\tv103 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tif (v64) goto L_003E;\nL_001F:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv93 = *([v76 @ X0_v37+C0]);\n\tv94 = *([v93 @ X8_v43+8]);\n\tv98 = *([v94 @ X8_v44]);\n\tv96 = *([v90 @ X0_v38 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv97 = v96 == 0;\n\tv103 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tif (v97) goto L_0044;\n\tv105 = *([v94 @ X8_v44]);\n\tv107 = v100;\n\tgoto L_0048;\nL_002B:\n\tv27 = 0x220C238(Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = *([v27 @ X0_v34+C0]);\n\tv47 = *([v54 @ X8_v38]);\n\tv56 = *([v47 @ X0_v39 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv57 = v56 == 0;\n\tv44 = ~v57;\n\tv52 = v47;\n\tif (v44) goto L_0016;\nL_0034:\n\tv53 = 0x220C238(v52, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv65 = new v53();\n\tv75 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv77 = *([v75 @ X0_v33 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]);\n\tv88 = *([v75 @ X0_v33 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv71 = v88 == 0;\n\tv100 = v65;\n\tv74 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv107 = v65;\n\tv103 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tif (v71) goto L_001F;\nL_003E:\n\tv83 = Il2CppMethodInfo;\n\tv98 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tv85 = v77 & 1;\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tv100 = v107;\n\tv105 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tif (v87) goto L_0048;\nL_0044:\n\tv104 = 0x220C238(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = v98;\n\tv107 = v100;\nL_0048:\n\tv105(v114, v107, Il2CppMethodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv115 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv118 = *([v115 @ X0_v5 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv119 = v118 == 0;\n\tif (v119) goto L_0070;\n\tv121 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv124 = *([v121 @ X0_v25 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv141 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v125) goto L_0079;\nL_0057:\n\tv133.<>9 = v107;\n\tv134 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv137 = *([v134 @ X0_v24 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv138 = v137 == 0;\n\tv161 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tif (v138) goto L_0083;\nL_005F:\n\tv154 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv157 = *([v154 @ X0_v22 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv158 = v157 == 0;\n\tv184 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v158) goto L_008C;\nL_006F:\n\treturn;\nL_0070:\n\tv126 = 0x220C238(Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = *([v126 @ X0_v16+C0]);\n\tv141 = *([v143 @ X8_v16+10]);\n\tv145 = *([v141 @ X0_v13 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv128 = ~v146;\n\tif (v128) goto L_0057;\nL_0079:\n\tv142 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = *([v142 @ X0_v14+B8]);\n\t*([v163 @ X8_v13]) = v107;\n\tv152 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tv165 = *([v152 @ X0_v15 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\n\tv161 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>;\n\tif (v148) goto L_005F;\nL_0083:\n\tv162 = 0x220C238(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = *([v162 @ X0_v11+C0]);\n\tv184 = *([v186 @ X8_v9+10]);\n\tv188 = *([v184 @ X0_v6 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tv168 = ~v189;\n\tif (v168) goto L_006F;\nL_008C:\n\tv185 = 0x220C238(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec__5()
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v42 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v39 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
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
				_003C_003Ec__5<TEvent> _003C_003Ec__6 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				_003C_003Ec__5<TEvent> _003C_003Ec__7 = _003C_003Ec__6;
				nint num9 = 0;
				_003C_003Ec__5<TEvent> _003C_003Ec__8 = _003C_003Ec__6;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v6 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0537;
				IL_03ac:
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v22 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
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
				_003C_003Ec__5<TEvent> _003C_003Ec__9 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag6 = num15 == 0;
				bool flag7 = !flag6;
				_003C_003Ec__7 = _003C_003Ec__9;
				num9 = 0;
				_003C_003Ec__8 = _003C_003Ec__9;
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
				_003C_003Ec__7 = _003C_003Ec__8;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v38 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag10 = num19 == 0;
				num10 = 0;
				if (flag10)
				{
					goto IL_02be;
				}
				obj5 = obj7;
				_003C_003Ec__8 = _003C_003Ec__7;
				goto IL_02e2;
				IL_02be:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				obj5 = obj4;
				_003C_003Ec__8 = _003C_003Ec__7;
				goto IL_02e2;
				IL_0364:
				_003C_003E9 = _003C_003Ec__8;
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v24 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v5 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v25 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v13 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0364;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v14+B8]");
				object obj9 = 0;
				obj9 = _003C_003Ec__8;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1>)+135]");
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

			[Token(Token = "0x6000013")]
			[Address(RVA = "0x4FFB65C", Offset = "0x4FFB65C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__5()
			{
			}

			internal TEvent _003CBridgeEvent_003Eb__5_0(TEvent e)
			{
				TEvent val2 = default(TEvent);
				TEvent val = val2;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v3 (Il2CppClass<TEvent>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v3 (Il2CppClass<TEvent>)+28]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v3 (Il2CppClass<TEvent>)+28]");
				int num3 = (int)(num2 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v3 (Il2CppClass<TEvent>)+28]");
				int num4 = (int)((nint)0 & (nint)num3);
				bool flag2 = num4 < 0;
				if (flag != flag2)
				{
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
				TEvent result = default(TEvent);
				return result;
			}
		}

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x10")]
		private readonly EventBus _sourceEventBus;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x18")]
		private readonly EventBus _targetEventBus;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<Action> _cleanupActions;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81A8960", Offset = "0x81A8960", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tSystem.Object::.ctor(this);\n\tv65 = sourceEventBus == 0;\n\tif (v65) goto L_0045;\n\tthis._sourceEventBus = sourceEventBus;\n\tv73 = targetEventBus == 0;\n\tif (v73) goto L_004D;\n\tthis._targetEventBus = targetEventBus;\n\treturn;\nL_0045:\n\tv71 = 0xB28B000 + 0x600;\n\tv74 = new v71();\n\tv95 = 0xB310000 + 0x580;\n\tv98 = v74;\n\tgoto L_0057;\nL_004D:\n\tv88 = 0xB28B000 + 0x600;\n\tv93 = new v88();\n\tv95 = 0xB310000 + 0xE88;\n\tv98 = v93;\n\tthrow v98;\nL_0020:\n\tv54 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v54);\n\tthis._cleanupActions = v54;\nL_0057:\n\tSystem.ArgumentNullException::.ctor(v98, v95);\n")]
		public EventBridge(EventBus sourceEventBus, EventBus targetEventBus)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EventBridge::.ctor");
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x4961CF8", Offset = "0x4961CF8", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv64 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass4_0`2<TSource, TTarget>>;\n\tgoto L_0022;\nL_0022:\n\tv67 = new v64();\n\tv72 = Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass4_0`2<TSource, TTarget>::.ctor(v67);\n\tv67.converter = converter;\n\tv67.<>4__this = this;\n\tv126 = v67.converter == 0;\n\tif (v126) goto L_00A6;\n\tgoto L_0041;\nL_0041:\n\tv148 = new Il2CppClass<System.Action`1<TSource>>();\n\tv153 = System.Action`1<TSource>::.ctor(v148, v67, Il2CppMethodInfo);\n\tv67.handler = v148;\n\tv164 = Unco.EventBusSystem.Runtime.EventBus::ListenEvent(this._sourceEventBus, v67.handler);\n\tv107 = this._cleanupActions;\n\tv97 = new System.Action();\n\tSystem.Action::.ctor(v97, v67, Il2CppMethodInfo);\n\tgoto L_0098;\nL_0098:\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v107, v97);\n\treturn;\n\tv75 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv64 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass4_0`2<TSource, TTarget>>;\n\tgoto L_0022;\nL_00A6:\n\tv132 = 0xB28B000 + 0x600;\n\tv134 = new v132();\n\tv144 = 0xB309000 + 0xB8;\n\tSystem.ArgumentNullException::.ctor(v134, v144);\n\tthrow v134;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void BridgeEvent<TSource, TTarget>(Func<TSource, TTarget> converter) where TSource : IEvent where TTarget : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EventBridge::BridgeEvent");
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x4961B28", Offset = "0x4961B28", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000D;\nL_000D:\n\tv20 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv23 = *([v20 @ X0_v47 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv24 = v23 == 0;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v24) goto L_003A;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv63 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv66 = *([v63 @ X0_v45 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv67 = v66 == 0;\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\nL_FFFFFFFF:\n\tv82 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v67) goto L_0048;\nL_001D:\n\tv79 = *([v73 @ X0_v43 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+B8]);\n\tv120 = *([v79 @ X8_v48 (Il2CppStaticFields<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+8]);\n\tv81 = *([v79 @ X8_v48 (Il2CppStaticFields<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+8]) == 0;\n\tif (v81) goto L_004F;\nL_002F:\n\tv131 = Unco.EventBusSystem.Runtime.EventBridge::BridgeEvent(v131, v120);\nL_002F:\n\treturn;\n\tv26 = System.Func`2<TEvent, TEvent>::.ctor(methodInfo, methodInfo, v27);\n\tv42 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv55 = *([v42 @ X0_v39 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv56 = v55 == 0;\n\tv44 = ~v56;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v44) goto L_0015;\nL_003A:\n\tv52 = 0x220C238(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv72 = *([v52 @ X0_v36+E4]) == 0;\n\tv59 = ~v72;\n\tif (v59) goto L_0017;\n\tv74 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv88 = *([v74 @ X0_v34 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv89 = v88 == 0;\n\tv76 = ~v89;\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\nL_FFFFFFFF:\n\tv82 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v76) goto L_001D;\nL_0048:\n\tv85 = 0x220C238(v82, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = *([v85 @ X0_v31+B8]);\n\tv120 = *([v96 @ X8_v34+8]);\n\tv108 = *([v96 @ X8_v34+8]) == 0;\n\tv94 = ~v108;\n\tif (v94) goto L_002F;\nL_004F:\n\tv103 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv106 = *([v103 @ X0_v29 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv107 = v106 == 0;\nL_FFFFFFFF:\n\tv157 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v107) goto L_008D;\n\tgoto L_0059;\nL_0059:\n\tv173 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv176 = *([v173 @ X0_v27 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv177 = v176 == 0;\nL_FFFFFFFF:\n\tv216 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v177) goto L_009B;\nL_0060:\n\tv113 = v202.<>9;\nL_FFFFFFFF:\n\tv242 = Il2CppClass<System.Func`2<TEvent, TEvent>>;\n\tgoto L_0069;\nL_0069:\n\tv245 = new v242();\n\tv252 = System.Func`2<TEvent, TEvent>::.ctor(v245, v113, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv261 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tgoto L_007A;\nL_007A:\n\tv262 = *([v261 @ X0_v15 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+B8]);\n\t*([v262 @ X8_v17 (Il2CppStaticFields<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+8]) = v245;\n\tgoto L_0089;\nL_0089:\n\tv273 = this == 0;\n\tv125 = ~v273;\nL_FFFFFFFF:\n\tv120 = v245;\n\tif (v125) goto L_002F;\n\tv157 = new System.NullReferenceException();\nL_008D:\n\tv160 = 0x220C238(v157, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = *([v160 @ X0_v8+E4]) == 0;\n\tv169 = ~v188;\n\tif (v169) goto L_0059;\n\tv197 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tv221 = *([v197 @ X0_v6 (Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>)+135]) & 1;\n\tv222 = v221 == 0;\n\tv199 = ~v222;\nL_FFFFFFFF:\n\tv216 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__5`1<TEvent>>;\n\tif (v199) goto L_0060;\nL_009B:\n\tv219 = 0x220C238(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv224 = *([v219 @ X0_v2+B8]);\n\tv113 = *([v224 @ X9_v2]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv242 = Il2CppClass<System.Func`2<TEvent, TEvent>>;\n\tgoto L_0069;\n")]
		public void BridgeEvent<TEvent>() where TEvent : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EventBridge::BridgeEvent");
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x4961F10", Offset = "0x4961F10", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv65 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass6_0`2<TSource, TTarget>>;\n\tgoto L_0023;\nL_0023:\n\tv68 = new v65();\n\tv73 = Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass6_0`2<TSource, TTarget>::.ctor(v68);\n\tv68.filter = filter;\n\tv68.converter = converter;\n\tv68.<>4__this = this;\n\tv131 = v68.converter == 0;\n\tif (v131) goto L_00B0;\n\tv147 = v68.filter == 0;\n\tif (v147) goto L_00B8;\n\tgoto L_004B;\nL_004B:\n\tv177 = new Il2CppClass<System.Action`1<TSource>>();\n\tv183 = System.Action`1<TSource>::.ctor(v177, v68, Il2CppMethodInfo);\n\tv68.handler = v177;\n\tv263 = Unco.EventBusSystem.Runtime.EventBus::ListenEvent(this._sourceEventBus, v68.handler);\n\tv108 = this._cleanupActions;\n\tv98 = new System.Action();\n\tSystem.Action::.ctor(v98, v68, Il2CppMethodInfo);\n\tgoto L_00A2;\nL_00A2:\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v108, v98);\n\treturn;\n\tv76 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv65 = Il2CppClass<Unco.EventBusSystem.Runtime.EventBridge+<>c__DisplayClass6_0`2<TSource, TTarget>>;\n\tgoto L_0023;\nL_00B0:\n\tv138 = 0xB28B000 + 0x600;\n\tv142 = new v138();\n\tv153 = 0xB309000 + 0xB8;\nL_FFFFFFFF:\n\tv157 = v142;\n\tgoto L_00C2;\nL_00B8:\n\tv170 = 0xB28B000 + 0x600;\n\tv178 = new v170();\n\tv153 = 0xB30A000 + 0xA18;\nL_FFFFFFFF:\n\tv157 = v178;\nL_00C2:\n\tSystem.ArgumentNullException::.ctor(v157, v153);\n\tthrow v157;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void BridgeEventWithFilter<TSource, TTarget>(Func<TSource, TTarget> converter, Predicate<TSource> filter) where TSource : IEvent where TTarget : IEvent
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EventBridge::BridgeEventWithFilter");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81A8A8C", Offset = "0x81A8A8C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv116 = 0xB2A5000 + 0xC80;\n\tv60 = System.Collections.Generic.List`1<System.Action>::GetEnumerator(this._cleanupActions);\n\tv130 = v60._list;\n\tv150 = v60.Current == 0;\n\tif (v150) goto L_003A;\n\tSystem.Action::Invoke(v60.Current);\n\tgoto L_003A;\nL_0048:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v130 @ stack_-48_v4 (System.Collections.Generic.List`1<System.Action>));\n\tv96 = 0;\n\tv114 = Il2CppMethodInfo;\nL_0049:\n\tv123 = this._cleanupActions;\n\tv121 = this._cleanupActions == 0;\n\tif (v121) goto L_0069;\n\tSystem.Collections.Generic.List`1<System.Action>::Clear(v123);\n\tv207 = v123.Count < 1;\n\tif (v207) goto L_0068;\nL_0068:\n\treturn;\nL_0069:\n\tv126 = new System.NullReferenceException();\n\tgoto L_0075;\nL_0075:\n\tv164 = v114 != 1;\n\tv179 = v126;\n\tif (v164) goto L_0085;\n\tv170 = 0x8BF5BC4(v126, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = 0x8BF5BF4(v170, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv114 = *([v116 @ X21_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v130 @ stack_-48_v4 (System.Collections.Generic.List`1<System.Action>));\n\tv178 = *([v170 @ X0_v12]) == 0;\n\tv96 = *([v170 @ X0_v12]);\n\tif (v178) goto L_0049;\n\tv176 = new System.OutOfMemoryException();\n\tv96 = *([v170 @ X0_v12]);\n\tv179 = v176;\n\treturn;\nL_0020:\n\tv130 = 0;\n\tv47 = this._cleanupActions == 0;\n\tif (v47) goto L_0069;\nL_003A:\n\tv147 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v130 @ stack_-48_v4 (System.Collections.Generic.List`1<System.Action>));\n\tv168 = v147 == 0;\n\tif (v168) goto L_0048;\nL_0085:\n\tv182 = 0x3966B78(&v96 @ stack_-58 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = 0x8BF0368(v179, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv193 = 0x7C03E68(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EventBridge::Dispose");
		}
	}
}
