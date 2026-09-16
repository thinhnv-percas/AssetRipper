using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E6F0", Offset = "0x73E6F0")]
[Token(Token = "0x2000010")]
public class PlayMakerFSM : MonoBehaviour, ISerializationCallbackReceiver
{
	[Token(Token = "0x2000088")]
	private delegate void AddEventHandlerDelegate(PlayMakerFSM fsm);

	[Token(Token = "0x400000D")]
	internal static readonly List<PlayMakerFSM> fsmList;

	[Token(Token = "0x400000E")]
	public static bool MaximizeFileCompatibility;

	[Token(Token = "0x400000F")]
	public static bool ApplicationIsQuitting;

	[Token(Token = "0x4000010")]
	public static bool NotMainThread;

	[SerializeField]
	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x18")]
	internal Fsm fsm;

	[SerializeField]
	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x20")]
	private FsmTemplate fsmTemplate;

	[SerializeField]
	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x28")]
	private bool eventHandlerComponentsAdded;

	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0x30")]
	private AddEventHandlerDelegate addEventHandlers;

	[Token(Token = "0x1700000A")]
	public static string VersionNotes
	{
		[Token(Token = "0x6000031")]
		[Address(RVA = "0xE54EDC", Offset = "0xE54EDC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBE328]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247D5]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "";
		}
	}

	[Token(Token = "0x1700000B")]
	public static string VersionLabel
	{
		[Token(Token = "0x6000032")]
		[Address(RVA = "0xE54F24", Offset = "0xE54F24", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EA9C28]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247D6]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "";
		}
	}

	[Token(Token = "0x1700000C")]
	public static List<PlayMakerFSM> FsmList
	{
		[Token(Token = "0x6000033")]
		[Address(RVA = "0xE54F6C", Offset = "0xE54F6C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0DD78]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247D7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerFSM;\nL_0024:\n\treturn v49.fsmList;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return fsmList;
		}
	}

	[Token(Token = "0x1700000D")]
	public FsmTemplate FsmTemplate
	{
		[Token(Token = "0x6000035")]
		[Address(RVA = "0xE551AC", Offset = "0xE551AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fsmTemplate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return FsmTemplate;
		}
	}

	[Token(Token = "0x1700000E")]
	[field: Token(Token = "0x4000014")]
	public static bool DrawGizmos
	{
		[Token(Token = "0x6000036")]
		[Address(RVA = "0xE551B4", Offset = "0xE551B4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EADE18]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247D9]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerFSM;\nL_0024:\n\treturn v49.<DrawGizmos>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x6000037")]
		[Address(RVA = "0xE5521C", Offset = "0xE5521C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE26D8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247DA]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerFSM;\nL_0022:\n\tv52.<DrawGizmos>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set;
	}

	[Token(Token = "0x1700000F")]
	private AddEventHandlerDelegate AddEventHandlers
	{
		[Token(Token = "0x600003F")]
		[Address(RVA = "0xE55EC0", Offset = "0xE55EC0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F04200]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247E2]) = v40;\nL_0014:\n\treturnVal1 = this.addEventHandlers;\n\tv42 = this.addEventHandlers == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_005F;\n\tgoto L_0027;\n\tv104 = *([v46 @ X0_v4+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0027;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv114 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(\"HutongGames.PlayMaker.FsmProcessor\");\n\tv161 = System.Type::GetMethod(v114, \"OnPreprocess\");\n\tgoto L_0042;\n\tv182 = *([v166 @ X8_v15+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0042;\n\tv191 = v166;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v191, v160, v159, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tv190 = System.Type::GetTypeFromHandle(PlayMakerFSM+AddEventHandlerDelegate);\n\tv92 = System.Delegate::CreateDelegate(v190, 0, v161);\n\tv94 = v92 == 0;\n\tif (v94) goto L_0058;\n\tv170 = *([v92 @ X0_v15 (System.Delegate)]) != PlayMakerFSM+AddEventHandlerDelegate;\n\tif (v170) goto L_0061;\nL_0058:\n\tthis.addEventHandlers = v92;\nL_005F:\n\treturn returnVal1;\n\tv162 = new System.NullReferenceException();\nL_0061:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			AddEventHandlerDelegate result = addEventHandlers;
			if (addEventHandlers == null)
			{
				Type globalType = ReflectionUtils.GetGlobalType("HutongGames.PlayMaker.FsmProcessor");
				MethodInfo method = globalType.GetMethod("OnPreprocess");
				Type typeFromHandle = typeof(AddEventHandlerDelegate);
				Delegate obj = Delegate.CreateDelegate(typeFromHandle, null, method);
				if (obj != null && (object)obj.GetType() != typeof(AddEventHandlerDelegate))
				{
					return (AddEventHandlerDelegate)(object)new InvalidCastException();
				}
				addEventHandlers = (AddEventHandlerDelegate)obj;
				result = (AddEventHandlerDelegate)obj;
			}
			return result;
		}
	}

	[Token(Token = "0x17000010")]
	public Fsm Fsm
	{
		[Token(Token = "0x6000055")]
		[Address(RVA = "0xE540BC", Offset = "0xE540BC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv0.owner = this;\n\treturn this.fsm;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			fsm.Owner = this;
			return this.fsm;
		}
	}

	[Token(Token = "0x17000011")]
	public string FsmName
	{
		[Token(Token = "0x6000056")]
		[Address(RVA = "0xE5518C", Offset = "0xE5518C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.Name;
		}
		[Token(Token = "0x6000057")]
		[Address(RVA = "0xE56E7C", Offset = "0xE56E7C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv0.name = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			Fsm fsm = this.fsm;
			fsm.Name = value;
		}
	}

	[Token(Token = "0x17000012")]
	public string FsmDescription
	{
		[Token(Token = "0x6000058")]
		[Address(RVA = "0xE56E9C", Offset = "0xE56E9C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.description;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.Description;
		}
		[Token(Token = "0x6000059")]
		[Address(RVA = "0xE56EBC", Offset = "0xE56EBC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv0.description = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			Fsm fsm = this.fsm;
			fsm.Description = value;
		}
	}

	[Token(Token = "0x17000013")]
	public bool Active
	{
		[Token(Token = "0x600005A")]
		[Address(RVA = "0xE540E0", Offset = "0xE540E0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_Active(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return fsm.Active;
		}
	}

	[Token(Token = "0x17000014")]
	public string ActiveStateName
	{
		[Token(Token = "0x600005B")]
		[Address(RVA = "0xE56EDC", Offset = "0xE56EDC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F08E18]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247EE]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.Fsm::get_ActiveState(this.fsm);\n\tv52 = v42 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv47 = HutongGames.PlayMaker.Fsm::get_ActiveState(this.fsm);\n\tv66 = v47 + 0x40;\n\tgoto L_002B;\nL_002B:\n\treturn *([v66 @ X8_v3 (System.String)]);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_0054: Expected O, but got I
			FsmState activeState = fsm.ActiveState;
			if (activeState != null)
			{
				FsmState activeState2 = fsm.ActiveState;
				return (string)((long)(IntPtr)activeState2 + 64L);
			}
			return "";
		}
	}

	[Token(Token = "0x17000015")]
	public FsmState[] FsmStates
	{
		[Token(Token = "0x600005C")]
		[Address(RVA = "0xE56F5C", Offset = "0xE56F5C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.states;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.States;
		}
	}

	[Token(Token = "0x17000016")]
	public FsmEvent[] FsmEvents
	{
		[Token(Token = "0x600005D")]
		[Address(RVA = "0xE56F7C", Offset = "0xE56F7C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.events;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.Events;
		}
	}

	[Token(Token = "0x17000017")]
	public FsmTransition[] FsmGlobalTransitions
	{
		[Token(Token = "0x600005E")]
		[Address(RVA = "0xE56F9C", Offset = "0xE56F9C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.globalTransitions;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.GlobalTransitions;
		}
	}

	[Token(Token = "0x17000018")]
	public FsmVariables FsmVariables
	{
		[Token(Token = "0x600005F")]
		[Address(RVA = "0xE56FBC", Offset = "0xE56FBC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\treturn v0.variables;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Fsm fsm = this.fsm;
			return fsm.Variables;
		}
	}

	[Token(Token = "0x17000019")]
	public bool UsesTemplate
	{
		[Token(Token = "0x6000060")]
		[Address(RVA = "0xE56FDC", Offset = "0xE56FDC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([20247EF]) & 1;\n\tv15 = v14 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_001B;\n\treturnVal1 = 0xE6005C(this, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20247EF]) = X8;\nL_001B:\n\tgoto L_0029;\n\tv42 = *([v38 @ X0_v1+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0029;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\treturnVal2 = UnityEngine.Object::op_Inequality(this.fsmTemplate, 0);\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [20247EF]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E6005C (inside PlayMakerTriggerExit2D::.ctor +0x8)");
				bool result = default(bool);
				return result;
			}
			return FsmTemplate != null;
		}
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0xE54FD4", Offset = "0xE54FD4", Length = "0x1B8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EF5E00]);\n\tv29 = *([v28 @ X8_v26]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsmName, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20247D8]) = v47;\nL_001C:\n\tv52 = 0;\n\tgoto L_002A;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002A;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v53, fsmName, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv61 = PlayMakerFSM;\nL_002A:\n\tv66 = v64.fsmList == 0;\n\tif (v66) goto L_0069;\n\tv72 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v64.fsmList);\nL_0037:\n\tv114 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::MoveNext(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv126 = v114 == 0;\n\tif (v126) goto L_FFFFFFFF;\n\tv90 = 0;\n\tv148 = UnityEngine.Component::get_gameObject(0);\n\tgoto L_004F;\n\tv217 = *([v165 @ X0_v31+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_004F;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v165, v147, v94, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004F:\n\tv103 = UnityEngine.Object::op_Equality(v148, go);\n\tv106 = v103 == 0;\n\tif (v106) goto L_0037;\n\tv110 = *([v90 @ X21_v11 (UnityEngine.Component)+18]);\n\tv104 = System.String::op_Equality(*([v110 @ X8_v21+30]), fsmName);\n\tv107 = v104 == 0;\n\tif (v107) goto L_0037;\n\tgoto L_0063;\nL_0063:\n\tv162 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tgoto L_0090;\n\tthrow System.NullReferenceException;\n\tv84 = new System.NullReferenceException();\nL_0069:\n\tv91 = new System.NullReferenceException();\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\nL_0078:\n\tv124 = v81 != 1;\n\tif (v124) goto L_0091;\n\tv127 = 0x6D2BC0(v91, v81, v73, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv132 = 0x6D2490(v127, v81, v73, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv136 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv172 = *([v127 @ X0_v13]) == 0;\n\tv138 = ~v172;\n\tif (v138) goto L_0095;\nL_0090:\n\treturn v238;\nL_0091:\n\tv128 = 0x6D2380(v91, v81, v73, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0095:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static PlayMakerFSM FindFsmOnGameObject(GameObject go, string fsmName)
	{
		//IL_006f: Expected O, but got I
		//IL_0089: Expected O, but got I
		List<PlayMakerFSM>.Enumerator enumerator = default(List<PlayMakerFSM>.Enumerator);
		Component result;
		if (fsmList != null)
		{
			List<PlayMakerFSM>.Enumerator enumerator2 = fsmList.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					Component component = null;
					GameObject gameObject = ((Component)null).gameObject;
					if (gameObject == go)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X21_v11 (UnityEngine.Component)+18]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v21+30]");
						if ((string)0 == fsmName)
						{
							result = null;
							break;
						}
					}
					continue;
				}
				result = null;
				break;
			}
			enumerator.Dispose();
			goto IL_01c2;
		}
		NullReferenceException ex = new NullReferenceException();
		string text = default(string);
		if ((IntPtr)text == (IntPtr)1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			enumerator.Dispose();
			object obj2 = default(object);
			if (obj2 == null)
			{
				result = null;
				goto IL_01c2;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}
		return (PlayMakerFSM)(object)new TypeLoadException();
		IL_01c2:
		return (PlayMakerFSM)result;
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0xE5528C", Offset = "0xE5528C", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBF340]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247DB]) = v38;\nL_0013:\n\tv51 = this.fsm;\n\tv40 = this.fsm == 0;\n\tif (v40) goto L_001B;\n\tthis.fsmTemplate = 0;\n\tgoto L_002B;\nL_001B:\n\tv44 = new HutongGames.PlayMaker.Fsm();\n\tHutongGames.PlayMaker.Fsm::.ctor(v44);\n\tthis.fsm = v44;\n\tthis.fsmTemplate = 0;\nL_002B:\n\tHutongGames.PlayMaker.Fsm::Reset(v51, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Reset()
	{
		Fsm fsm = this.fsm;
		if (this.fsm != null)
		{
			fsmTemplate = null;
		}
		else
		{
			Fsm fsm2 = (this.fsm = new Fsm());
			fsmTemplate = null;
			fsm = fsm2;
		}
		fsm.Reset(this);
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0xE55314", Offset = "0xE55314", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF2770]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247DC]) = v40;\nL_0014:\n\tPlayMakerGlobals::Initialize();\n\tgoto L_0025;\n\tv46 = *([1F05128]);\n\tv47 = *([v46 @ X8_v24]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = 0 | 1;\n\t*([2021711]) = v51;\nL_0025:\n\tv57 = ~v55.<IsEditor>k__BackingField;\n\tv58 = ~v57;\n\tif (v58) goto L_0053;\n\tgoto L_0038;\n\tv80 = *([v61 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0038;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0038:\n\tgoto L_0043;\n\tv91 = *([1EE2F98]);\n\tv92 = *([v91 @ X8_v20]);\n\tv93 = \"il2cpp_codegen_initialize_method\"(v92, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv96 = 0 | 1;\n\t*([2023702]) = v96;\nL_0043:\n\tgoto L_004B;\n\tv101 = *([v97 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tgoto L_004B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v97, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = HutongGames.PlayMaker.FsmLog;\nL_004B:\n\tv72.<LoggingEnabled>k__BackingField = 0;\nL_0053:\n\tPlayMakerFSM::Init(v38);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		PlayMakerGlobals.Initialize();
		if (!PlayMakerGlobals.IsEditor)
		{
			FsmLog.LoggingEnabled = false;
		}
		Init();
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0xE557DC", Offset = "0xE557DC", Length = "0xA8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB2C18]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247DD]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.fsmTemplate, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_002B;\n\tPlayMakerFSM::InitTemplate(this);\n\tgoto L_0031;\nL_002B:\n\tPlayMakerFSM::InitFsm(this);\nL_0031:\n\tHutongGames.PlayMaker.Fsm::Preprocess(this.fsm, this);\n\tPlayMakerFSM::AddEventHandlerComponents(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Preprocess()
	{
		if (FsmTemplate != null)
		{
			InitTemplate();
		}
		else
		{
			InitFsm();
		}
		fsm.Preprocess(this);
		AddEventHandlerComponents();
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0xE556B4", Offset = "0xE556B4", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EED340]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247DE]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.fsmTemplate, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0030;\n\tv60 = UnityEngine.Application::get_isPlaying();\n\tv63 = v60 == 0;\n\tif (v63) goto L_0035;\n\tPlayMakerFSM::InitTemplate(this);\n\tgoto L_0035;\nL_0030:\n\tPlayMakerFSM::InitFsm(this);\nL_0035:\n\tgoto L_0041;\n\tv72 = *([1F05128]);\n\tv73 = *([v72 @ X8_v24]);\n\tv74 = \"il2cpp_codegen_initialize_method\"(v73, v54, v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv77 = 0 | 1;\n\t*([2021711]) = v77;\nL_0041:\n\tv83 = ~v81.<IsEditor>k__BackingField;\n\tif (v83) goto L_004D;\n\tv84 = this.fsm;\n\tv84.preprocessed = 0;\n\tthis.eventHandlerComponentsAdded = 0;\nL_004D:\n\tHutongGames.PlayMaker.Fsm::Init(this.fsm, this);\n\tv107 = ~this.eventHandlerComponentsAdded;\n\tif (v107) goto L_0063;\n\tv98 = this.fsm;\n\tv109 = ~v98.preprocessed;\n\tif (v109) goto L_0063;\n\treturn;\nL_0063:\n\tPlayMakerFSM::AddEventHandlerComponents(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Init()
	{
		if (FsmTemplate != null)
		{
			if (Application.isPlaying)
			{
				InitTemplate();
			}
		}
		else
		{
			InitFsm();
		}
		if (PlayMakerGlobals.IsEditor)
		{
			Fsm fsm = this.fsm;
			fsm.preprocessed = false;
			eventHandlerComponentsAdded = false;
		}
		this.fsm.Init(this);
		if (eventHandlerComponentsAdded)
		{
			Fsm fsm2 = this.fsm;
			if (fsm2.Preprocessed)
			{
				return;
			}
		}
		AddEventHandlerComponents();
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0xE55884", Offset = "0xE55884", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE72E0]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20247DF]) = v50;\nL_0019:\n\tv51 = this.fsm;\n\tv53 = this.fsmTemplate;\n\tv76 = new HutongGames.PlayMaker.Fsm();\n\tHutongGames.PlayMaker.Fsm::.ctor(v76, v53.fsm, v51.variables);\n\tv76.usedInTemplate = 0;\n\tv76.name = v51.name;\n\tv76.EnableDebugFlow = v51.EnableDebugFlow;\n\tv76.EnableBreakpoints = v51.EnableBreakpoints;\n\tv76.showStateLabel = v51.showStateLabel;\n\tthis.fsm = v76;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void InitTemplate()
	{
		Fsm fsm = this.fsm;
		FsmTemplate fsmTemplate = FsmTemplate;
		Fsm fsm2 = new Fsm(fsmTemplate.fsm, fsm.Variables);
		fsm2.UsedInTemplate = null;
		fsm2.Name = fsm.Name;
		fsm2.EnableDebugFlow = fsm.EnableDebugFlow;
		fsm2.EnableBreakpoints = fsm.EnableBreakpoints;
		fsm2.showStateLabel = fsm.ShowStateLabel;
		this.fsm = fsm2;
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0xE55948", Offset = "0xE55948", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EECFE8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247E0]) = v38;\nL_0014:\n\tv40 = this.fsm == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0021;\n\tPlayMakerFSM::Reset(this);\n\tv45 = this.fsm == 0;\n\tif (v45) goto L_0028;\nL_0021:\n\treturn;\nL_0028:\n\tgoto L_0032;\n\tv76 = *([v72 @ X0_v4+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0032;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v72, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tUnityEngine.Debug::LogError(\"Could not initialize FSM!\");\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void InitFsm()
	{
		if (fsm == null)
		{
			Reset();
			if (fsm == null)
			{
				Debug.LogError("Could not initialize FSM!");
				base.enabled = false;
			}
		}
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0xE559EC", Offset = "0xE559EC", Length = "0x468")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FE40]);\n\tv19 = *([v18 @ X8_v120]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247E1]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = PlayMakerPrefs::get_LogPerformanceWarnings();\n\tgoto L_002E;\n\tv56 = *([2021711]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002E;\n\tv68 = *([1F05128]);\n\tv69 = *([v68 @ X8_v116]);\n\tv60 = \"il2cpp_codegen_initialize_method\"(v69, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv63 = 0 | 1;\n\t*([2021711]) = v63;\nL_002E:\n\tv370 = this.fsm;\n\tv71 = ~v370.mouseEvents;\n\tif (v71) goto L_003D;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_003D:\n\tv203 = ~v370.handleCollisionEnter;\n\tif (v203) goto L_0048;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0048:\n\tv234 = ~v370.handleCollisionExit;\n\tif (v234) goto L_0053;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0053:\n\tv241 = ~v370.handleCollisionStay;\n\tif (v241) goto L_005E;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_005E:\n\tv266 = ~v370.handleTriggerEnter;\n\tif (v266) goto L_0069;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0069:\n\tv273 = ~v370.handleTriggerExit;\n\tif (v273) goto L_0074;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0074:\n\tv280 = ~v370.handleTriggerStay;\n\tif (v280) goto L_007F;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_007F:\n\tv287 = ~v370.handleCollisionEnter2D;\n\tif (v287) goto L_008A;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_008A:\n\tv294 = ~v370.handleCollisionExit2D;\n\tif (v294) goto L_0095;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0095:\n\tv301 = ~v370.handleCollisionStay2D;\n\tif (v301) goto L_00A0;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00A0:\n\tv308 = ~v370.handleTriggerEnter2D;\n\tif (v308) goto L_00AB;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00AB:\n\tv315 = ~v370.handleTriggerExit2D;\n\tif (v315) goto L_00B6;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00B6:\n\tv322 = ~v370.handleTriggerStay2D;\n\tif (v322) goto L_00C1;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00C1:\n\tv329 = ~v370.handleParticleCollision;\n\tif (v329) goto L_00CC;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00CC:\n\tv336 = ~v370.handleControllerColliderHit;\n\tif (v336) goto L_00D7;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00D7:\n\tv343 = ~v370.handleJointBreak;\n\tif (v343) goto L_00E2;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00E2:\n\tv350 = ~v370.handleJointBreak2D;\n\tif (v350) goto L_00ED;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00ED:\n\tv357 = ~v370.handleFixedUpdate;\n\tif (v357) goto L_00F8;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_00F8:\n\tv364 = ~v370.handleLateUpdate;\n\tif (v364) goto L_0103;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv370 = this.fsm;\nL_0103:\n\tv372 = ~v370.handleOnGUI;\n\tif (v372) goto L_012B;\n\tv377 = UnityEngine.Component::GetComponent(this);\n\tgoto L_011B;\n\tv389 = *([v222 @ X8_v53+E0]);\n\tv390 = v389 == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_011B;\n\tv403 = v222;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v403, v376, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_011B:\n\tv379 = UnityEngine.Object::op_Equality(v377, 0);\n\tv381 = v379 == 0;\n\tif (v381) goto L_012B;\n\tv214 = UnityEngine.Component::get_gameObject(this);\n\tv215 = UnityEngine.GameObject::AddComponent(v214);\n\tv215.playMakerFSM = this;\nL_012B:\n\tv417 = this.fsm;\n\tv388 = ~v417.handleApplicationEvents;\n\tif (v388) goto L_013A;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv417 = this.fsm;\nL_013A:\n\tv402 = ~v417.handleAnimatorMove;\n\tif (v402) goto L_0145;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv417 = this.fsm;\nL_0145:\n\tv411 = ~v417.handleAnimatorIK;\n\tif (v411) goto L_0150;\n\tPlayMakerFSM::AddEventHandlerComponent(this);\n\tv417 = this.fsm;\nL_0150:\n\tv418 = ~v417.handleLegacyNetworking;\n\tv419 = ~v418;\n\tif (v419) goto L_0157;\n\tv421 = v417.handleUiEvents == 0;\n\tif (v421) goto L_015D;\nL_0157:\n\tv216 = PlayMakerFSM::get_AddEventHandlers(this);\n\tPlayMakerFSM+AddEventHandlerDelegate::Invoke(v216, this);\nL_015D:\n\tthis.eventHandlerComponentsAdded = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 219 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddEventHandlerComponents()
	{
		bool logPerformanceWarnings = PlayMakerPrefs.LogPerformanceWarnings;
		Fsm fsm = this.fsm;
		if (fsm.MouseEvents)
		{
			AddEventHandlerComponent<PlayMakerMouseEvents>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionEnter)
		{
			AddEventHandlerComponent<PlayMakerCollisionEnter>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionExit)
		{
			AddEventHandlerComponent<PlayMakerCollisionExit>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionStay)
		{
			AddEventHandlerComponent<PlayMakerCollisionStay>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerEnter)
		{
			AddEventHandlerComponent<PlayMakerTriggerEnter>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerExit)
		{
			AddEventHandlerComponent<PlayMakerTriggerExit>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerStay)
		{
			AddEventHandlerComponent<PlayMakerTriggerStay>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionEnter2D)
		{
			AddEventHandlerComponent<PlayMakerCollisionEnter2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionExit2D)
		{
			AddEventHandlerComponent<PlayMakerCollisionExit2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleCollisionStay2D)
		{
			AddEventHandlerComponent<PlayMakerCollisionStay2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerEnter2D)
		{
			AddEventHandlerComponent<PlayMakerTriggerEnter2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerExit2D)
		{
			AddEventHandlerComponent<PlayMakerTriggerExit2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleTriggerStay2D)
		{
			AddEventHandlerComponent<PlayMakerTriggerStay2D>();
			fsm = this.fsm;
		}
		if (fsm.HandleParticleCollision)
		{
			AddEventHandlerComponent<PlayMakerParticleCollision>();
			fsm = this.fsm;
		}
		if (fsm.HandleControllerColliderHit)
		{
			AddEventHandlerComponent<PlayMakerControllerColliderHit>();
			fsm = this.fsm;
		}
		if (fsm.HandleJointBreak)
		{
			AddEventHandlerComponent<PlayMakerJointBreak>();
			fsm = this.fsm;
		}
		if (fsm.HandleJointBreak2D)
		{
			AddEventHandlerComponent<PlayMakerJointBreak>();
			fsm = this.fsm;
		}
		if (fsm.HandleFixedUpdate)
		{
			AddEventHandlerComponent<PlayMakerFixedUpdate>();
			fsm = this.fsm;
		}
		if (fsm.HandleLateUpdate)
		{
			AddEventHandlerComponent<PlayMakerLateUpdate>();
			fsm = this.fsm;
		}
		if (fsm.HandleOnGUI)
		{
			PlayMakerOnGUI component = GetComponent<PlayMakerOnGUI>();
			if (component == null)
			{
				GameObject gameObject = base.gameObject;
				PlayMakerOnGUI playMakerOnGUI = gameObject.AddComponent<PlayMakerOnGUI>();
				playMakerOnGUI.playMakerFSM = this;
			}
		}
		Fsm fsm2 = this.fsm;
		if (fsm2.HandleApplicationEvents)
		{
			AddEventHandlerComponent<PlayMakerApplicationEvents>();
			fsm2 = this.fsm;
		}
		if (fsm2.HandleAnimatorMove)
		{
			AddEventHandlerComponent<PlayMakerAnimatorMove>();
			fsm2 = this.fsm;
		}
		if (fsm2.HandleAnimatorIK)
		{
			AddEventHandlerComponent<PlayMakerAnimatorIK>();
			fsm2 = this.fsm;
		}
		if (fsm2.HandleLegacyNetworking || fsm2.HandleUiEvents != UiEvents.None)
		{
			AddEventHandlerDelegate addEventHandlerDelegate = AddEventHandlers;
			addEventHandlerDelegate(this);
		}
		eventHandlerComponentsAdded = true;
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x9EB554", Offset = "0x9EB554", Length = "0x1A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EAAD28]);\n\tv23 = *([v22 @ X8_v38]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021ACB]) = v41;\nL_0019:\n\tv45 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002C;\n\tv67 = *([v50 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002C;\n\tv75 = v50;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v75, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002C:\n\tv60 = PlayMakerFSM::GetEventHandlerComponent(v45);\n\tPlayMakerProxyBase::AddTarget(v60, this);\n\tgoto L_0042;\n\tv113 = *([1EA5878]);\n\tv114 = *([v113 @ X8_v34]);\n\tv115 = \"il2cpp_codegen_initialize_method\"(v114, v76, v77, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv118 = 0 | 1;\n\t*([2021711]) = v118;\nL_0042:\n\tv124 = ~v122.<IsEditor>k__BackingField;\n\tv125 = ~v124;\n\tif (v125) goto L_008C;\n\tgoto L_0052;\n\tv135 = *([v128 @ X0_v12+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0052;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v128, v76, v77, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tv132 = PlayMakerPrefs::get_LogPerformanceWarnings();\n\tv133 = v132 == 0;\n\tif (v133) goto L_008C;\n\tgoto L_0066;\n\tv151 = *([v145 @ X0_v16+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_0066;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v145, v76, v77, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0066:\n\tv160 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv166 = System.String::Concat(\"AddEventHandlerComponent: \", v160);\n\tgoto L_0084;\n\tv173 = *([v100 @ X8_v30+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_0084;\n\tv178 = v100;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v178, v163, v82, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0084:\n\tUnityEngine.Debug::Log(v166);\n\treturn;\nL_008C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void AddEventHandlerComponent<T>() where T : PlayMakerProxyBase
	{
		GameObject go = base.gameObject;
		PlayMakerProxyBase eventHandlerComponent = GetEventHandlerComponent<T>(go);
		eventHandlerComponent.AddTarget(this);
		if (!PlayMakerGlobals.IsEditor && PlayMakerPrefs.LogPerformanceWarnings)
		{
			Type typeFromHandle = typeof(T);
			string message = "AddEventHandlerComponent: " + typeFromHandle;
			Debug.Log(message);
		}
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0xB89164", Offset = "0xB89164", Length = "0x138")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F014C0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022A08]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(go, 0);\n\tv63 = v60 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_006C;\n\tv102 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_0041;\n\tv127 = *([v87 @ X8_v9+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0041;\n\tv134 = v87;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v134, v100, v59, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tv79 = UnityEngine.Object::op_Equality(v102, 0);\n\tv83 = v79 == 0;\n\tif (v83) goto L_006C;\n\tv139 = UnityEngine.GameObject::AddComponent(go);\n\tgoto L_0059;\n\tv145 = *([v86 @ X8_v14+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0059;\n\tv152 = v86;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v152, v76, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0059:\n\tv80 = PlayMakerPrefs::get_ShowEventHandlerComponents();\n\tv154 = v80 == 0;\n\tv84 = ~v154;\n\tif (v84) goto L_006C;\n\tUnityEngine.Object::set_hideFlags(v139, 2);\nL_006C:\n\treturn v88;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static T GetEventHandlerComponent<T>(GameObject go) where T : PlayMakerProxyBase
	{
		bool flag = go == null;
		bool flag2 = !flag;
		bool flag3 = !flag2;
		T result = null;
		if (!flag3)
		{
			UnityEngine.Object component = go.GetComponent<T>();
			bool flag4 = component == null;
			bool flag5 = !flag4;
			result = (T)component;
			if (!flag5)
			{
				UnityEngine.Object obj = go.AddComponent<T>();
				bool showEventHandlerComponents = PlayMakerPrefs.ShowEventHandlerComponents;
				bool flag6 = !showEventHandlerComponents;
				bool flag7 = !flag6;
				result = (T)obj;
				if (!flag7)
				{
					obj.hideFlags = HideFlags.HideInInspector;
					result = (T)obj;
				}
			}
		}
		return result;
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0xE56384", Offset = "0xE56384", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EB51E8]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, template, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247E3]) = v43;\nL_0016:\n\tv44 = this.fsm;\n\tthis.fsmTemplate = template;\n\tv44.owner = this;\n\tHutongGames.PlayMaker.Fsm::Clear(this.fsm, this);\n\tgoto L_0030;\n\tv90 = *([v86 @ X0_v7+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0030;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v86, v73, v74, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0030:\n\tv56 = UnityEngine.Object::op_Inequality(template, 0);\n\tv120 = v56 == 0;\n\tif (v120) goto L_0052;\n\tv66 = this.fsm;\n\tv66.owner = this;\n\tv67 = this.fsmTemplate;\n\tv68 = v67.fsm;\n\tv49 = this.fsm;\n\tv57 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v57, v68.variables);\n\tv49.variables = v57;\nL_0052:\n\tPlayMakerFSM::Init(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetFsmTemplate(FsmTemplate template)
	{
		Fsm fsm = this.fsm;
		this.fsmTemplate = template;
		fsm.Owner = this;
		this.fsm.Clear(this);
		if (template != null)
		{
			Fsm fsm2 = this.fsm;
			fsm2.Owner = this;
			FsmTemplate fsmTemplate = FsmTemplate;
			Fsm fsm3 = fsmTemplate.fsm;
			Fsm fsm4 = this.fsm;
			FsmVariables variables = new FsmVariables(fsm3.Variables);
			fsm4.Variables = variables;
		}
		Init();
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0xE5647C", Offset = "0xE5647C", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv4 = ~v0.<Started>k__BackingField;\n\tif (v4) goto L_0008;\n\treturn;\nL_0008:\n\tHutongGames.PlayMaker.Fsm::Start(v0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		Fsm fsm = this.fsm;
		if (!fsm.Started)
		{
			fsm.Start();
		}
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0xE564A4", Offset = "0xE564A4", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECAEA0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247E4]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b15\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerFSM;\nL_0028:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Add(v52.fsmList, this);\n\tHutongGames.PlayMaker.Fsm::OnEnable(this.fsm);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		fsmList.Add(this);
		fsm.OnEnable();
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0xE56538", Offset = "0xE56538", Length = "0x30")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.fsm;\n\tv4 = ~v0.<Finished>k__BackingField;\n\tv5 = ~v4;\n\tif (v5) goto L_000A;\n\tv28 = ~v0.manualUpdate;\n\tif (v28) goto L_000C;\nL_000A:\n\treturn;\nL_000C:\n\tHutongGames.PlayMaker.Fsm::Update(v0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		Fsm fsm = this.fsm;
		if (!fsm.Finished && !fsm.ManualUpdate)
		{
			fsm.Update();
		}
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0xE56568", Offset = "0xE56568", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EEA1D0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, routine, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247E5]) = v41;\nL_0018:\n\tv45 = new PlayMakerFSM+<DoCoroutine>d__37();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n\tv45.routine = routine;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IEnumerator DoCoroutine(IEnumerator routine)
	{
		_003CDoCoroutine_003Ed__37 _003CDoCoroutine_003Ed__38 = null;
		_003CDoCoroutine_003Ed__38._003C_003E1__state = 0;
		_003CDoCoroutine_003Ed__38._003C_003E4__this = this;
		_003CDoCoroutine_003Ed__38.routine = routine;
		return _003CDoCoroutine_003Ed__38;
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0xE56614", Offset = "0xE56614", Length = "0x13C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBCF20]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20247E6]) = v42;\nL_0015:\n\tv43 = this.fsm;\n\tv46 = ~v43.<Started>k__BackingField;\n\tif (v46) goto L_0048;\n\tgoto L_002B;\n\tv85 = *([v50 @ X0_v13+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_002B;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tgoto L_0036;\n\tv103 = *([1EE07F8]);\n\tv104 = *([v103 @ X8_v23]);\n\tv105 = \"il2cpp_codegen_initialize_method\"(v104, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv108 = 0 | 1;\n\t*([202485D]) = v108;\nL_0036:\n\tgoto L_0041;\n\tv148 = *([v109 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tgoto L_0041;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv152 = HutongGames.PlayMaker.FsmEvent;\nL_0041:\n\tHutongGames.PlayMaker.Fsm::Event(v43, v66.<Disable>k__BackingField);\nL_0048:\n\tgoto L_0057;\n\tv95 = *([v69 @ X0_v6 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\t// 76 ConditionalJump @b30, v97 @ TEMP_v16\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v69, v56, v54, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv99 = PlayMakerFSM;\nL_0057:\n\tv118 = System.Collections.Generic.List`1<PlayMakerFSM>::Remove(v82.fsmList, this);\n\tv132 = this.fsm;\n\tv154 = this.fsm == 0;\n\tif (v154) goto L_0065;\n\tv135 = ~v132.<Finished>k__BackingField;\n\tif (v135) goto L_006E;\nL_0065:\n\treturn;\nL_006E:\n\tHutongGames.PlayMaker.Fsm::OnDisable(this.fsm);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		Fsm fsm = this.fsm;
		if (fsm.Started)
		{
			fsm.Event(FsmEvent.Disable);
		}
		bool flag = fsmList.Remove(this);
		Fsm fsm2 = this.fsm;
		if (this.fsm != null && !fsm2.Finished)
		{
			this.fsm.OnDisable();
		}
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0xE56750", Offset = "0xE56750", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB2448]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247E7]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b16\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerFSM;\nL_0028:\n\tv60 = System.Collections.Generic.List`1<PlayMakerFSM>::Remove(v52.fsmList, this);\n\tv63 = this.fsm == 0;\n\tif (v63) goto L_0039;\n\tHutongGames.PlayMaker.Fsm::OnDestroy(this.fsm);\n\treturn;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDestroy()
	{
		bool flag = fsmList.Remove(this);
		if (fsm != null)
		{
			fsm.OnDestroy();
		}
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0xE567F0", Offset = "0xE567F0", Length = "0xFC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EDA7E0]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247E8]) = v40;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tgoto L_0030;\n\tv60 = *([1F05BB0]);\n\tv61 = *([v60 @ X8_v17]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = 0 | 1;\n\t*([202485E]) = v65;\nL_0030:\n\tgoto L_003D;\n\tv70 = *([v66 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 52 Jump @b22\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv74 = HutongGames.PlayMaker.FsmEvent;\nL_003D:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v79.<ApplicationQuit>k__BackingField);\n\tgoto L_004D;\n\tv91 = *([v87 @ X0_v10 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_004D;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v87, v82, v81, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = PlayMakerFSM;\nL_004D:\n\tv98.ApplicationIsQuitting = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnApplicationQuit()
	{
		fsm.Event(FsmEvent.ApplicationQuit);
		ApplicationIsQuitting = true;
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0xE568EC", Offset = "0xE568EC", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.fsm == 0;\n\tif (v2) goto L_0006;\n\tHutongGames.PlayMaker.Fsm::OnDrawGizmos(this.fsm);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDrawGizmos()
	{
		if (fsm != null)
		{
			fsm.OnDrawGizmos();
		}
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0xE56900", Offset = "0xE56900", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::SetState(this.fsm, stateName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetState(string stateName)
	{
		fsm.SetState(stateName);
	}

	[Token(Token = "0x600004C")]
	[Address(RVA = "0xE5691C", Offset = "0xE5691C", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, fsmEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ChangeState(FsmEvent fsmEvent)
	{
		fsm.Event(fsmEvent);
	}

	[Obsolete]
	[Token(Token = "0x600004D")]
	[Address(RVA = "0xE56938", Offset = "0xE56938", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, eventName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ChangeState(string eventName)
	{
		fsm.Event(eventName);
	}

	[Token(Token = "0x600004E")]
	[Address(RVA = "0xE56954", Offset = "0xE56954", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, eventName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SendEvent(string eventName)
	{
		fsm.Event(eventName);
	}

	[Obsolete]
	[Token(Token = "0x600004F")]
	[Address(RVA = "0xE56970", Offset = "0xE56970", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, eventName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SendRemoteFsmEvent(string eventName)
	{
		fsm.Event(eventName);
	}

	[Obsolete]
	[Token(Token = "0x6000050")]
	[Address(RVA = "0xE5698C", Offset = "0xE5698C", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB20F8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, eventName, eventData, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20247E9]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, eventName, eventData, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = HutongGames.PlayMaker.Fsm;\nL_0025:\n\tv59 = v58.EventData;\n\tv59.StringData = eventData;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, eventName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SendRemoteFsmEventWithData(string eventName, string eventData)
	{
		FsmEventData eventData2 = Fsm.EventData;
		eventData2.StringData = eventData;
		fsm.Event(eventName);
	}

	[Token(Token = "0x6000051")]
	[Address(RVA = "0xE56A28", Offset = "0xE56A28", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBAE78]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247EA]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(fsmEventName);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0025;\n\treturn;\nL_0025:\n\tgoto L_002D;\n\tv73 = *([v50 @ X0_v4+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_002D;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v50, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv81 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tgoto L_0042;\n\tv88 = *([v68 @ X8_v9+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0042;\n\tv93 = v68;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v93, v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tPlayMakerFSM::BroadcastEvent(v81);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void BroadcastEvent(string fsmEventName)
	{
		if (!string.IsNullOrEmpty(fsmEventName))
		{
			FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
			BroadcastEvent(fsmEvent);
		}
	}

	[Token(Token = "0x6000052")]
	[Address(RVA = "0xE56ADC", Offset = "0xE56ADC", Length = "0x210")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE6128]);\n\tv23 = *([v22 @ X8_v37]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20247EB]) = v42;\nL_0019:\n\tv47 = 0;\n\tgoto L_0028;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0028:\n\tgoto L_0033;\n\tv64 = *([1F06658]);\n\tv65 = *([v64 @ X8_v33]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv69 = 0 | 1;\n\t*([2021A8F]) = v69;\nL_0033:\n\tgoto L_003F;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003F;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv78 = PlayMakerFSM;\nL_003F:\n\tv86 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v86, v82.fsmList);\n\tv93 = v86 == 0;\n\tif (v93) goto L_0089;\n\tv99 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v86);\nL_0054:\n\tv140 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::MoveNext(&v47 @ stack_-48_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv152 = v140 == 0;\n\tif (v152) goto L_0081;\n\tv117 = 0;\n\tgoto L_0066;\n\tv179 = *([v155 @ X0_v28+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0066;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v155, v138, v123, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0066:\n\tv128 = UnityEngine.Object::op_Equality(0, 0);\n\tv189 = v128 == 0;\n\tv131 = ~v189;\n\tif (v131) goto L_0054;\n\tv247 = *([v117 @ X20_v9 (UnityEngine.Object)+18]);\n\t*([v247 @ X8_v27+20]) = 0;\n\tv132 = *([v117 @ X20_v9 (UnityEngine.Object)+18]) == 0;\n\tif (v132) goto L_0054;\n\t*([v136 @ X8_v28+20]) = 0;\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(*([v117 @ X20_v9 (UnityEngine.Object)+18]), fsmEvent, 0);\n\tgoto L_0054;\nL_0081:\n\tv163 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v47 @ stack_-48_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tgoto L_00AB;\n\tthrow System.NullReferenceException;\n\tv255 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0089:\n\tv119 = new System.NullReferenceException();\n\tgoto L_0097;\n\tgoto L_0097;\n\tgoto L_0097;\n\tgoto L_0097;\nL_0097:\n\tv150 = 0 != 1;\n\tif (v150) goto L_00AC;\n\tv153 = System.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v119, 0);\n\tv165 = System.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v153, 0);\n\tv169 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v47 @ stack_-48_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv224 = *([v153 @ X0_v17 (System.Collections.Generic.List`1<PlayMakerFSM>)]) == 0;\n\tv171 = ~v224;\n\tif (v171) goto L_00B0;\nL_00AB:\n\treturn;\nL_00AC:\n\tv154 = System.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v119, 0);\nL_00B0:\n\tthrow System.TypeLoadException;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void BroadcastEvent(FsmEvent fsmEvent)
	{
		//IL_015e: Expected I4, but got O
		//IL_0069: Expected O, but got I
		//IL_00ba: Expected O, but got I
		List<PlayMakerFSM>.Enumerator enumerator = default(List<PlayMakerFSM>.Enumerator);
		List<PlayMakerFSM> list = new List<PlayMakerFSM>((int)fsmList);
		if (list != null)
		{
			List<PlayMakerFSM>.Enumerator enumerator2 = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				UnityEngine.Object obj = null;
				if (!((UnityEngine.Object)null == (UnityEngine.Object)null))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v9 (UnityEngine.Object)+18]");
					object obj2 = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v9 (UnityEngine.Object)+18]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ X20_v9 (UnityEngine.Object)+18]");
						((Fsm)0).ProcessEvent(fsmEvent);
					}
				}
			}
			enumerator.Dispose();
			return;
		}
		NullReferenceException ex = (NullReferenceException)(object)new List<PlayMakerFSM>(null);
		if (0 == 1)
		{
			enumerator.Dispose();
			List<PlayMakerFSM> list2 = default(List<PlayMakerFSM>);
			if (list2 == null)
			{
				return;
			}
		}
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000053")]
	[Address(RVA = "0xE56CEC", Offset = "0xE56CEC", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EF5730]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247EC]) = v40;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tgoto L_0030;\n\tv60 = *([1EA53E0]);\n\tv61 = *([v60 @ X8_v13]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = 0 | 1;\n\t*([202485F]) = v65;\nL_0030:\n\tgoto L_0043;\n\tv70 = *([v66 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 52 Jump @b19\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv74 = HutongGames.PlayMaker.FsmEvent;\nL_0043:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v79.<BecameVisible>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnBecameVisible()
	{
		fsm.Event(FsmEvent.BecameVisible);
	}

	[Token(Token = "0x6000054")]
	[Address(RVA = "0xE56DB4", Offset = "0xE56DB4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE6CD0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247ED]) = v40;\nL_001B:\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tgoto L_0030;\n\tv60 = *([1EE9770]);\n\tv61 = *([v60 @ X8_v13]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = 0 | 1;\n\t*([2024860]) = v65;\nL_0030:\n\tgoto L_0043;\n\tv70 = *([v66 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\t// 52 Jump @b19\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv74 = HutongGames.PlayMaker.FsmEvent;\nL_0043:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v79.<BecameInvisible>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnBecameInvisible()
	{
		fsm.Event(FsmEvent.BecameInvisible);
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0xE5704C", Offset = "0xE5704C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public void OnBeforeSerialize()
	{
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0xE57050", Offset = "0xE57050", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE85D0]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20247F0]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = PlayMakerFSM;\nL_0025:\n\tv56.NotMainThread = 1;\n\tgoto L_0034;\n\tv64 = *([1EA4B08]);\n\tv65 = *([v64 @ X8_v19]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([2024861]) = v57;\nL_0034:\n\tv74 = ~v72.<Initialized>k__BackingField;\n\tif (v74) goto L_003F;\n\tHutongGames.PlayMaker.Fsm::InitData(this.fsm);\nL_003F:\n\tgoto L_0047;\n\tv86 = *([v81 @ X0_v6 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0047;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v81, v77, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv90 = PlayMakerFSM;\nL_0047:\n\tv93.NotMainThread = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnAfterDeserialize()
	{
		NotMainThread = true;
		if (PlayMakerGlobals.Initialized)
		{
			fsm.InitData();
		}
		NotMainThread = false;
	}

	[Token(Token = "0x6000063")]
	[Address(RVA = "0xE57138", Offset = "0xE57138", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerFSM()
	{
	}

	[Token(Token = "0x6000064")]
	[Address(RVA = "0xE57140", Offset = "0xE57140", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EEE370]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247F1]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v39);\n\tv47.fsmList = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static PlayMakerFSM()
	{
		List<PlayMakerFSM> list = new List<PlayMakerFSM>();
		fsmList = list;
	}
}
