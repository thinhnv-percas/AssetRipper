using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200002A")]
	public class ActionReport
	{
		[Token(Token = "0x40000CE")]
		public static readonly List<ActionReport> ActionReportList;

		[Token(Token = "0x40000CF")]
		public static int InfoCount;

		[Token(Token = "0x40000D0")]
		public static int ErrorCount;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x10")]
		public PlayMakerFSM fsm;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x18")]
		public FsmState state;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x20")]
		public FsmStateAction action;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x28")]
		public int actionIndex;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x30")]
		public string logText;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x38")]
		public bool isError;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x40")]
		public string parameter;

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x9D6DB0", Offset = "0x9D6DB0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBB7F0]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A09]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b13\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.ActionReport;\nL_0025:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::Clear(v49.ActionReportList);\n\tv58.InfoCount = 0;\n\tv59.ErrorCount = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Start()
		{
			ActionReportList.Clear();
			InfoCount = 0;
			ErrorCount = 0;
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x9D0AE4", Offset = "0x9D0AE4", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv44 = *([1ECA7D0]);\n\tv45 = *([v44 @ X8_v30]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, state, action, actionIndex, parameter, logLine, isError, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2021A0A]) = v58;\nL_0024:\n\tgoto L_0030;\n\tv64 = *([1EFA290]);\n\tv65 = *([v64 @ X8_v27]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, state, action, actionIndex, parameter, logLine, isError, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv69 = 0 | 1;\n\t*([2021711]) = v69;\nL_0030:\n\tv75 = ~v73.<IsEditor>k__BackingField;\n\tif (v75) goto L_FFFFFFFF;\n\tv79 = new HutongGames.PlayMaker.ActionReport();\n\tSystem.Object::.ctor(v79);\n\tv79.fsm = fsm;\n\tv79.state = state;\n\tv79.action = action;\n\tv79.actionIndex = actionIndex;\n\tv79.parameter = parameter;\n\tv79.logText = logLine;\n\tv79.isError = isError;\n\tgoto L_004E;\n\tv146 = *([v141 @ X0_v11+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_004E;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v141, v81, action, actionIndex, parameter, logLine, isError, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55);\nL_004E:\n\tv84 = HutongGames.PlayMaker.ActionReport::ActionReportContains(v79);\n\tv86 = v84 == 0;\n\tif (v86) goto L_0058;\n\tgoto L_007A;\nL_0058:\n\tgoto L_0067;\n\tv160 = *([v156 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\t// 92 ConditionalJump @b26, v162 @ TEMP_v21\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v156, v81, action, actionIndex, parameter, logLine, isError, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv164 = HutongGames.PlayMaker.ActionReport;\nL_0067:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::Add(v154.ActionReportList, v79);\n\tv93 = v105.InfoCount + 1;\n\tv105.InfoCount = v93;\nL_007A:\n\treturn v106;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ActionReport Log(PlayMakerFSM fsm, FsmState state, FsmStateAction action, int actionIndex, string parameter, string logLine, bool isError = false)
		{
			if (PlayMakerGlobals.IsEditor)
			{
				ActionReport actionReport = new ActionReport();
				actionReport.fsm = fsm;
				actionReport.state = state;
				actionReport.action = action;
				actionReport.actionIndex = actionIndex;
				actionReport.parameter = parameter;
				actionReport.logText = logLine;
				actionReport.isError = isError;
				if (!ActionReportContains(actionReport))
				{
					ActionReportList.Add(actionReport);
					int infoCount = InfoCount + 1;
					InfoCount = infoCount;
					return actionReport;
				}
			}
			return null;
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x9D6E4C", Offset = "0x9D6E4C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0F5C8]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A0B]) = v38;\nL_0017:\n\tv43 = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv52 = HutongGames.PlayMaker.ActionReport;\nL_0025:\n\tv57 = v55.ActionReportList == 0;\n\tif (v57) goto L_0046;\n\tv63 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::GetEnumerator(v55.ActionReportList);\nL_0030:\n\tv82 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::MoveNext(&v43 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>));\n\tv94 = v82 == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tv78 = HutongGames.PlayMaker.ActionReport::SameAs(0, report);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0030;\n\tgoto L_0043;\nL_0043:\n\tv123 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::Dispose(&v43 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>));\n\tgoto L_0065;\n\tv67 = new System.NullReferenceException();\nL_0046:\n\tv73 = new System.NullReferenceException();\n\tgoto L_0052;\n\tgoto L_0052;\nL_0052:\n\tv92 = Il2CppMethodInfo != 1;\n\tif (v92) goto L_0066;\n\tv95 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::MoveNext(v73);\n\tv173 = v95.m_value;\n\tv100 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::MoveNext(v95);\n\tv104 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::Dispose(&v43 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>));\n\tv127 = ~v95.m_value;\n\tv106 = ~v127;\n\tif (v106) goto L_006A;\nL_0065:\n\treturn v173;\nL_0066:\n\tv96 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>+Enumerator<HutongGames.PlayMaker.ActionReport>::MoveNext(v73);\nL_006A:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool ActionReportContains(ActionReport report)
		{
			//IL_010e: Expected I4, but got O
			List<ActionReport>.Enumerator enumerator = default(List<ActionReport>.Enumerator);
			bool result;
			if (ActionReportList != null)
			{
				List<ActionReport>.Enumerator enumerator2 = ActionReportList.GetEnumerator();
				int num;
				while (true)
				{
					if (enumerator.MoveNext())
					{
						if (((ActionReport)null).SameAs(report))
						{
							num = 1;
							break;
						}
						continue;
					}
					num = 0;
					break;
				}
				enumerator.Dispose();
				result = (byte)num != 0;
				goto IL_00e9;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<ActionReport>.Enumerator*)ex)->MoveNext();
				result = ((bool*)(flag ? 1 : 0))->m_value;
				bool flag2 = (flag ? ((List<ActionReport>.Enumerator*)1) : ((List<ActionReport>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					goto IL_00e9;
				}
			}
			else
			{
				bool flag3 = ((List<ActionReport>.Enumerator*)ex)->MoveNext();
			}
			TypeLoadException ex2 = new TypeLoadException();
			return (byte)(int)ex2 != 0;
			IL_00e9:
			return result;
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x9D6F84", Offset = "0x9D6F84", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = actionReport.fsm != this.fsm;\n\tif (v26) goto L_005A;\n\tv54 = actionReport.state != this.state;\n\tif (v54) goto L_005A;\n\tv63 = actionReport.actionIndex != this.actionIndex;\n\tif (v63) goto L_005A;\n\tv60 = System.String::op_Equality(actionReport.logText, this.logText);\n\tv96 = v60 == 0;\n\tif (v96) goto L_005A;\n\tv148 = actionReport.isError == 0;\n\tv153 = ~v148;\n\tv77 = this.isError == 0;\n\tv62 = ~v77;\n\tv92 = v153 ^ v62;\n\tv95 = v92 == 0;\n\tif (v95) goto L_0063;\nL_005A:\n\treturn 0;\nL_0063:\n\treturnVal3 = System.String::op_Equality(actionReport.parameter, this.parameter);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool SameAs(ActionReport actionReport)
		{
			if ((object)actionReport.fsm == fsm && actionReport.state == state && actionReport.actionIndex == actionIndex && actionReport.logText == logText)
			{
				bool flag = !actionReport.isError;
				bool flag2 = !flag;
				bool flag3 = !isError;
				bool flag4 = !flag3;
				if (!(flag2 ^ flag4))
				{
					return actionReport.parameter == parameter;
				}
			}
			return false;
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x9D7030", Offset = "0x9D7030", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1ECB3B8]);\n\tv39 = *([v38 @ X8_v12]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, state, action, actionIndex, parameter, logLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2021A0C]) = v53;\nL_0023:\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, state, action, actionIndex, parameter, logLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0030:\n\tv74 = HutongGames.PlayMaker.ActionReport::Log(fsm, state, action, actionIndex, parameter, logLine, 1);\n\tv78 = HutongGames.PlayMaker.FsmUtility::GetPath(state, action);\n\tv81 = System.String::Concat(v78, logLine);\n\tgoto L_0049;\n\tv89 = *([v85 @ X8_v7+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0049;\n\tv99 = v85;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v99, v79, v80, v71, v72, v73, v67, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0049:\n\tUnityEngine.Debug::LogWarning(v81, fsm);\n\tv103 = v101.ErrorCount + 1;\n\tv101.ErrorCount = v103;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogWarning(PlayMakerFSM fsm, FsmState state, FsmStateAction action, int actionIndex, string parameter, string logLine)
		{
			ActionReport actionReport = Log(fsm, state, action, actionIndex, parameter, logLine, isError: true);
			string path = FsmUtility.GetPath(state, action);
			string message = path + logLine;
			Debug.LogWarning(message, fsm);
			int errorCount = ErrorCount + 1;
			ErrorCount = errorCount;
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x9D09D0", Offset = "0x9D09D0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F05100]);\n\tv39 = *([v38 @ X8_v12]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, state, action, actionIndex, parameter, logLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2021A0D]) = v53;\nL_0023:\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, state, action, actionIndex, parameter, logLine, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0030:\n\tv74 = HutongGames.PlayMaker.ActionReport::Log(fsm, state, action, actionIndex, parameter, logLine, 1);\n\tv78 = HutongGames.PlayMaker.FsmUtility::GetPath(state, action);\n\tv81 = System.String::Concat(v78, logLine);\n\tgoto L_0049;\n\tv89 = *([v85 @ X8_v7+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0049;\n\tv99 = v85;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v99, v79, v80, v71, v72, v73, v67, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0049:\n\tUnityEngine.Debug::LogError(v81, fsm);\n\tv103 = v101.ErrorCount + 1;\n\tv101.ErrorCount = v103;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(PlayMakerFSM fsm, FsmState state, FsmStateAction action, int actionIndex, string parameter, string logLine)
		{
			ActionReport actionReport = Log(fsm, state, action, actionIndex, parameter, logLine, isError: true);
			string path = FsmUtility.GetPath(state, action);
			string message = path + logLine;
			Debug.LogError(message, fsm);
			int errorCount = ErrorCount + 1;
			ErrorCount = errorCount;
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x9D7144", Offset = "0x9D7144", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EE8CD0]);\n\tv35 = *([v34 @ X8_v14]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, state, action, actionIndex, logLine, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021A0E]) = v50;\nL_0021:\n\tgoto L_0030;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0030;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, state, action, actionIndex, logLine, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0030:\n\tv73 = HutongGames.PlayMaker.ActionReport::Log(fsm, state, action, actionIndex, logLine, \"\", 1);\n\tv77 = HutongGames.PlayMaker.FsmUtility::GetPath(state, action);\n\tv80 = System.String::Concat(v77, logLine);\n\tgoto L_0049;\n\tv88 = *([v84 @ X8_v9+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0049;\n\tv98 = v84;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v98, v78, v79, v71, v72, v69, v66, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0049:\n\tUnityEngine.Debug::LogError(v80, fsm);\n\tv102 = v100.ErrorCount + 1;\n\tv100.ErrorCount = v102;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(PlayMakerFSM fsm, FsmState state, FsmStateAction action, int actionIndex, string logLine)
		{
			ActionReport actionReport = Log(fsm, state, action, actionIndex, logLine, "", isError: true);
			string path = FsmUtility.GetPath(state, action);
			string message = path + logLine;
			Debug.LogError(message, fsm);
			int errorCount = ErrorCount + 1;
			ErrorCount = errorCount;
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x9D7254", Offset = "0x9D7254", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB2768]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A0F]) = v35;\nL_0017:\n\tgoto L_0029;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b13\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.ActionReport;\nL_0029:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::Clear(v49.ActionReportList);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear()
		{
			ActionReportList.Clear();
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x9D72D0", Offset = "0x9D72D0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EBB090]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A10]) = v40;\nL_0017:\n\tv44 = new HutongGames.PlayMaker.ActionReport+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v44);\n\tv44.fsm = fsm;\n\tgoto L_0030;\n\tv75 = *([v50 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0030;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v50, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv79 = HutongGames.PlayMaker.ActionReport;\nL_0030:\n\tv66 = new System.Predicate`1<HutongGames.PlayMaker.ActionReport>();\n\tSystem.Predicate`1<HutongGames.PlayMaker.ActionReport>::.ctor(v66, v44, Il2CppMethodInfo);\n\tv100 = System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::RemoveAll(v83.ActionReportList, v66);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Remove(PlayMakerFSM fsm)
		{
			Predicate<ActionReport> match = (ActionReport x) => x.fsm == fsm;
			int num = ActionReportList.RemoveAll(match);
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x9D73C4", Offset = "0x9D73C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDA5D0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A11]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.ActionReport;\nL_001F:\n\tv50 = v49.ActionReportList;\n\treturn v50._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetCount()
		{
			List<ActionReport> actionReportList = ActionReportList;
			return actionReportList.Count;
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x9D6E44", Offset = "0x9D6E44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionReport()
		{
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x9D743C", Offset = "0x9D743C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ED7B60]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A12]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ActionReport>::.ctor(v39);\n\tv47.ActionReportList = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ActionReport()
		{
			List<ActionReport> actionReportList = new List<ActionReport>();
			ActionReportList = actionReportList;
		}
	}
}
