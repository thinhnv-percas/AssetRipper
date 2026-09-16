using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.InAppPurchase.Components;
using Morpeh;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200006B")]
	public class Fsm : INameable, IComparable
	{
		[Serializable]
		[Flags]
		[Token(Token = "0x2000097")]
		private enum EditorFlags
		{
			[Token(Token = "0x4000380")]
			none = 0,
			[Token(Token = "0x4000381")]
			nameIsExpanded = 1,
			[Token(Token = "0x4000382")]
			controlsIsExpanded = 2,
			[Token(Token = "0x4000383")]
			debugIsExpanded = 4,
			[Token(Token = "0x4000384")]
			experimentalIsExpanded = 8
		}

		[Token(Token = "0x40001ED")]
		public const int CurrentDataVersion = 2;

		[Token(Token = "0x40001EE")]
		public const int DefaultMaxLoops = 1000;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x10")]
		private MethodInfo updateHelperSetDirty;

		[Token(Token = "0x40001F0")]
		private const string StartStateName = "State 1";

		[Token(Token = "0x40001F1")]
		public static FsmEventData EventData;

		[Token(Token = "0x40001F2")]
		private static Color debugLookAtColor;

		[Token(Token = "0x40001F3")]
		private static Color debugRaycastColor;

		[SerializeField]
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x18")]
		private int dataVersion;

		[NonSerialized]
		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x20")]
		private MonoBehaviour owner;

		[SerializeField]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x28")]
		private FsmTemplate usedInTemplate;

		[SerializeField]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x30")]
		private string name;

		[SerializeField]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x38")]
		private string startState;

		[SerializeField]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x40")]
		private FsmState[] states;

		[SerializeField]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x48")]
		private FsmEvent[] events;

		[SerializeField]
		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x50")]
		private FsmTransition[] globalTransitions;

		[SerializeField]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x58")]
		private FsmVariables variables;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TextAreaAttribute), RVA = "0x73F4EC", Offset = "0x73F4EC")]
		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x60")]
		private string description;

		[SerializeField]
		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x68")]
		private string docUrl;

		[SerializeField]
		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x70")]
		public bool showStateLabel;

		[SerializeField]
		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x74")]
		private int maxLoopCount;

		[SerializeField]
		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x78")]
		private string watermark;

		[SerializeField]
		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x80")]
		private string password;

		[SerializeField]
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x88")]
		private bool locked;

		[SerializeField]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x89")]
		private bool manualUpdate;

		[SerializeField]
		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x8A")]
		private bool keepDelayedEventsOnStateExit;

		[SerializeField]
		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x8B")]
		internal bool preprocessed;

		[NonSerialized]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x90")]
		private Fsm host;

		[NonSerialized]
		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x98")]
		private Fsm rootFsm;

		[NonSerialized]
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0xA0")]
		private List<Fsm> subFsmList;

		[NonSerialized]
		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0xA8")]
		public bool setDirty;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0xA9")]
		private bool activeStateEntered;

		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0xB0")]
		public List<FsmEvent> ExposedEvents;

		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0xB8")]
		private FsmLog myLog;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0xC0")]
		public bool RestartOnEnable;

		[CompilerGenerated]
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0xC1")]
		private bool _003CStarted_003Ek__BackingField;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0xC2")]
		public bool EnableDebugFlow;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0xC3")]
		public bool EnableBreakpoints;

		[NonSerialized]
		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0xC4")]
		public bool StepFrame;

		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0xC8")]
		private readonly List<DelayedEvent> delayedEvents;

		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0xD0")]
		private readonly List<DelayedEvent> updateEvents;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0xD8")]
		private readonly List<DelayedEvent> removeEvents;

		[SerializeField]
		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0xE0")]
		private EditorFlags editorFlags;

		[NonSerialized]
		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0xF0")]
		private bool initialized;

		[CompilerGenerated]
		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0xF1")]
		private bool _003CFinished_003Ek__BackingField;

		[SerializeField]
		[Token(Token = "0x400021A")]
		[FieldOffset(Offset = "0xF8")]
		private string activeStateName;

		[NonSerialized]
		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x100")]
		private FsmState activeState;

		[NonSerialized]
		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x108")]
		private FsmState switchToState;

		[NonSerialized]
		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x110")]
		private FsmState previousActiveState;

		[CompilerGenerated]
		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x118")]
		private FsmTransition _003CLastTransition_003Ek__BackingField;

		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x120")]
		public Action<FsmState> StateChanged;

		[CompilerGenerated]
		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x128")]
		private bool _003CIsModifiedPrefabInstance_003Ek__BackingField;

		[Obsolete]
		[Token(Token = "0x4000221")]
		public static readonly Color[] StateColors;

		[NonSerialized]
		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x130")]
		private FsmState editState;

		[CompilerGenerated]
		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x138")]
		private bool _003CSwitchedState_003Ek__BackingField;

		[SerializeField]
		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x139")]
		private bool mouseEvents;

		[SerializeField]
		[Token(Token = "0x400022F")]
		[FieldOffset(Offset = "0x13A")]
		private bool handleLevelLoaded;

		[SerializeField]
		[Token(Token = "0x4000230")]
		[FieldOffset(Offset = "0x13B")]
		private bool handleTriggerEnter2D;

		[SerializeField]
		[Token(Token = "0x4000231")]
		[FieldOffset(Offset = "0x13C")]
		private bool handleTriggerExit2D;

		[SerializeField]
		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x13D")]
		private bool handleTriggerStay2D;

		[SerializeField]
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x13E")]
		private bool handleCollisionEnter2D;

		[SerializeField]
		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x13F")]
		private bool handleCollisionExit2D;

		[SerializeField]
		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x140")]
		private bool handleCollisionStay2D;

		[SerializeField]
		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x141")]
		private bool handleTriggerEnter;

		[SerializeField]
		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x142")]
		private bool handleTriggerExit;

		[SerializeField]
		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x143")]
		private bool handleTriggerStay;

		[SerializeField]
		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x144")]
		private bool handleCollisionEnter;

		[SerializeField]
		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x145")]
		private bool handleCollisionExit;

		[SerializeField]
		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x146")]
		private bool handleCollisionStay;

		[SerializeField]
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x147")]
		private bool handleParticleCollision;

		[SerializeField]
		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x148")]
		private bool handleControllerColliderHit;

		[SerializeField]
		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x149")]
		private bool handleJointBreak;

		[SerializeField]
		[Token(Token = "0x400023F")]
		[FieldOffset(Offset = "0x14A")]
		private bool handleJointBreak2D;

		[SerializeField]
		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x14B")]
		private bool handleOnGUI;

		[SerializeField]
		[Token(Token = "0x4000241")]
		[FieldOffset(Offset = "0x14C")]
		private bool handleFixedUpdate;

		[SerializeField]
		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x14D")]
		private bool handleLateUpdate;

		[SerializeField]
		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x14E")]
		private bool handleApplicationEvents;

		[SerializeField]
		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x150")]
		private UiEvents handleUiEvents;

		[SerializeField]
		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x154")]
		private bool handleLegacyNetworking;

		[CompilerGenerated]
		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x178")]
		private float _003CJointBreakForce_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0x180")]
		private Joint2D _003CBrokenJoint2D_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400024D")]
		[FieldOffset(Offset = "0x190")]
		private string _003CTriggerName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x198")]
		private string _003CCollisionName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x1A0")]
		private string _003CTrigger2dName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x1A8")]
		private string _003CCollision2dName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x1B8")]
		public RaycastHit _003CRaycastHitInfo_003Ek__BackingField;

		[Token(Token = "0x4000253")]
		private static Dictionary<Fsm, RaycastHit2D> lastRaycastHit2DInfoLUT;

		[SerializeField]
		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x1E4")]
		private bool handleAnimatorMove;

		[SerializeField]
		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x1E5")]
		private bool handleAnimatorIK;

		[Token(Token = "0x4000256")]
		private static readonly FsmEventTarget targetSelf;

		[Token(Token = "0x170000C2")]
		public static List<Fsm> FsmList
		{
			[Token(Token = "0x6000318")]
			[Address(RVA = "0x9D8340", Offset = "0x9D8340", Length = "0x218")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBA2E0]);\n\tv23 = *([v22 @ X8_v35]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2021A19]) = v43;\nL_0019:\n\tv48 = 0;\n\tv50 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v50);\n\tgoto L_0031;\n\tv61 = *([v57 @ X0_v4+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0031;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, v54, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\tgoto L_003C;\n\tv73 = *([1EE93F0]);\n\tv74 = *([v73 @ X8_v31]);\n\tv75 = \"il2cpp_codegen_initialize_method\"(v74, v54, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv78 = 0 | 1;\n\t*([2021A8F]) = v78;\nL_003C:\n\tgoto L_0045;\n\tv83 = *([v79 @ X0_v7 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tgoto L_0045;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v79, v54, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv87 = PlayMakerFSM;\nL_0045:\n\tv92 = v90.fsmList == 0;\n\tif (v92) goto L_0085;\n\tv98 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v90.fsmList);\nL_0054:\n\tv139 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::MoveNext(&v48 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv151 = v139 == 0;\n\tif (v151) goto L_007F;\n\tgoto L_0066;\n\tv178 = *([v154 @ X0_v28+E0]);\n\tv179 = v178 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0066;\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v154, v137, v121, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0066:\n\tv129 = UnityEngine.Object::op_Inequality(0, 0);\n\tv133 = v129 == 0;\n\tif (v133) goto L_0054;\n\tv130 = PlayMakerFSM::get_Fsm(0);\n\tv134 = v130 == 0;\n\tif (v134) goto L_0054;\n\tv250 = PlayMakerFSM::get_Fsm(0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::Add(v50, v250);\n\tgoto L_0054;\nL_007F:\n\tv162 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v48 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tgoto L_00AB;\n\tthrow System.NullReferenceException;\n\tv112 = new System.NullReferenceException();\nL_0085:\n\tv117 = new System.NullReferenceException();\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\n\tgoto L_0095;\nL_0095:\n\tv149 = v109 != 1;\n\tif (v149) goto L_00AC;\n\tv152 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v117);\n\tv164 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v152);\n\tv169 = System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>::Dispose(&v48 @ stack_-58_v1 (System.Collections.Generic.List`1<PlayMakerFSM>+Enumerator<PlayMakerFSM>));\n\tv223 = *([v152 @ X0_v18 (System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>)]) == 0;\n\tv171 = ~v223;\n\tif (v171) goto L_00B0;\nL_00AB:\n\treturn v50;\nL_00AC:\n\tv153 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v117);\nL_00B0:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<PlayMakerFSM>.Enumerator enumerator = default(List<PlayMakerFSM>.Enumerator);
				List<Fsm> list = new List<Fsm>();
				if (PlayMakerFSM.fsmList != null)
				{
					List<PlayMakerFSM>.Enumerator enumerator2 = PlayMakerFSM.fsmList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						if ((UnityEngine.Object)null != (UnityEngine.Object)null)
						{
							Fsm fsm = ((PlayMakerFSM)null).Fsm;
							if (fsm != null)
							{
								Fsm fsm2 = ((PlayMakerFSM)null).Fsm;
								list.Add(fsm2);
							}
						}
					}
					enumerator.Dispose();
					goto IL_0105;
				}
				NullReferenceException ex = (NullReferenceException)(object)new List<Fsm>();
				IntPtr intPtr = default(IntPtr);
				if (intPtr == (IntPtr)1)
				{
					enumerator.Dispose();
					List<Fsm> list2 = default(List<Fsm>);
					if (list2 == null)
					{
						goto IL_0105;
					}
				}
				return (List<Fsm>)(object)new TypeLoadException();
				IL_0105:
				return list;
			}
		}

		[Token(Token = "0x170000C3")]
		public static List<Fsm> SortedFsmList
		{
			[Token(Token = "0x6000319")]
			[Address(RVA = "0x9D8558", Offset = "0x9D8558", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEDE98]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A1A]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = HutongGames.PlayMaker.Fsm::get_FsmList();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::Sort(v49);\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<Fsm> fsmList = FsmList;
				fsmList.Sort();
				return fsmList;
			}
		}

		[Token(Token = "0x170000C4")]
		private MethodInfo UpdateHelperSetDirty
		{
			[Token(Token = "0x600031A")]
			[Address(RVA = "0x9D85DC", Offset = "0x9D85DC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDE1E8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A1B]) = v38;\nL_0013:\n\treturnVal1 = this.updateHelperSetDirty;\n\tv40 = this.updateHelperSetDirty == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0035;\n\tgoto L_0027;\n\tv62 = *([v44 @ X0_v4+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0027;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv73 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(\"HutongGames.PlayMaker.UpdateHelper\");\n\treturnVal1 = System.Type::GetMethod(v73, \"SetDirty\");\n\tthis.updateHelperSetDirty = returnVal1;\nL_0035:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				MethodInfo result = updateHelperSetDirty;
				if ((object)updateHelperSetDirty == null)
				{
					Type globalType = ReflectionUtils.GetGlobalType("HutongGames.PlayMaker.UpdateHelper");
					result = (updateHelperSetDirty = globalType.GetMethod("SetDirty"));
				}
				return result;
			}
		}

		[Token(Token = "0x170000C5")]
		public bool ManualUpdate
		{
			[Token(Token = "0x600031B")]
			[Address(RVA = "0x9D8678", Offset = "0x9D8678", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.manualUpdate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ManualUpdate;
			}
			[Token(Token = "0x600031C")]
			[Address(RVA = "0x9D8680", Offset = "0x9D8680", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.manualUpdate = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				manualUpdate = value;
			}
		}

		[Token(Token = "0x170000C6")]
		public bool KeepDelayedEventsOnStateExit
		{
			[Token(Token = "0x600031D")]
			[Address(RVA = "0x9D868C", Offset = "0x9D868C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.keepDelayedEventsOnStateExit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return KeepDelayedEventsOnStateExit;
			}
			[Token(Token = "0x600031E")]
			[Address(RVA = "0x9D8694", Offset = "0x9D8694", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.keepDelayedEventsOnStateExit = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				keepDelayedEventsOnStateExit = value;
			}
		}

		[Token(Token = "0x170000C7")]
		public bool Preprocessed
		{
			[Token(Token = "0x600031F")]
			[Address(RVA = "0x9D86A0", Offset = "0x9D86A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.preprocessed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Preprocessed;
			}
			[Token(Token = "0x6000320")]
			[Address(RVA = "0x9D86A8", Offset = "0x9D86A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.preprocessed = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				preprocessed = value;
			}
		}

		[Token(Token = "0x170000C8")]
		public Fsm Host
		{
			[Token(Token = "0x6000321")]
			[Address(RVA = "0x9D86B4", Offset = "0x9D86B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.host;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Host;
			}
			[Token(Token = "0x6000322")]
			[Address(RVA = "0x9D86BC", Offset = "0x9D86BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.host = value;\n\treturn;\n")]
			private set
			{
				host = value;
			}
		}

		[Token(Token = "0x170000C9")]
		public string Password
		{
			[Token(Token = "0x6000323")]
			[Address(RVA = "0x9D86C4", Offset = "0x9D86C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.password;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Password;
			}
		}

		[Token(Token = "0x170000CA")]
		public bool Locked
		{
			[Token(Token = "0x6000324")]
			[Address(RVA = "0x9D86CC", Offset = "0x9D86CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.locked;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Locked;
			}
		}

		[Token(Token = "0x170000CB")]
		public FsmTemplate Template
		{
			[Token(Token = "0x6000327")]
			[Address(RVA = "0x9D8738", Offset = "0x9D8738", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBDD30]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A1C]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv60 = v56 == 0;\n\tif (v60) goto L_006F;\n\tv61 = this.owner;\n\tgoto L_FFFFFFFF;\n\tv188 = v188_asT == 0;\n\tif (v188) goto L_0070;\n\tgoto L_FFFFFFFF;\n\tv67 = v67_asT == 0;\n\tif (v67) goto L_0070;\n\treturnVal1 = *([v61 @ X0_v8 (UnityEngine.MonoBehaviour)+20]);\nL_006F:\n\treturn returnVal1;\nL_0070:\n\tv151 = new System.InvalidCastException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00b8: Expected O, but got I
				bool flag = Owner != null;
				bool flag2 = !flag;
				FsmTemplate result = null;
				if (!flag2)
				{
					MonoBehaviour monoBehaviour = Owner;
					PlayMakerFSM playMakerFSM = Owner as PlayMakerFSM;
					if ((object)playMakerFSM != null)
					{
						PlayMakerFSM playMakerFSM2 = Owner as PlayMakerFSM;
						if ((object)playMakerFSM2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X0_v8 (UnityEngine.MonoBehaviour)+20]");
							result = (FsmTemplate)0;
							goto IL_00de;
						}
					}
					InvalidCastException ex = new InvalidCastException();
					return (FsmTemplate)(object)new NullReferenceException();
				}
				goto IL_00de;
				IL_00de:
				return result;
			}
		}

		[Token(Token = "0x170000CC")]
		public bool IsSubFsm
		{
			[Token(Token = "0x6000328")]
			[Address(RVA = "0x9D8828", Offset = "0x9D8828", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.host == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = Host == null;
				return !flag;
			}
		}

		[Token(Token = "0x170000CD")]
		public Fsm RootFsm
		{
			[Token(Token = "0x6000329")]
			[Address(RVA = "0x9D8838", Offset = "0x9D8838", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.rootFsm;\n\tv2 = this.rootFsm == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_000C;\nL_0006:\n\tv13 = v13.host;\n\tv18 = v13.host == 0;\n\tv9 = ~v18;\n\tif (v9) goto L_0006;\n\tthis.rootFsm = v13.host;\nL_000C:\n\treturn v10;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Fsm result = rootFsm;
				if (rootFsm == null)
				{
					Fsm fsm = this;
					Fsm fsm2 = default(Fsm);
					fsm = fsm2;
					do
					{
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
					rootFsm = fsm.Host;
					result = fsm.Host;
				}
				return result;
			}
		}

		[Token(Token = "0x170000CE")]
		public List<Fsm> SubFsmList
		{
			[Token(Token = "0x600032A")]
			[Address(RVA = "0x9D8880", Offset = "0x9D8880", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDA148]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A1D]) = v38;\nL_0013:\n\tv51 = this.subFsmList;\n\tv40 = this.subFsmList == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0027;\n\tv45 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v45);\n\tthis.subFsmList = v45;\nL_0027:\n\treturn v51;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<Fsm> result = subFsmList;
				if (subFsmList == null)
				{
					result = (subFsmList = new List<Fsm>());
				}
				return result;
			}
		}

		[Token(Token = "0x170000CF")]
		public bool Started
		{
			[CompilerGenerated]
			[Token(Token = "0x600032B")]
			[Address(RVA = "0x9D88F4", Offset = "0x9D88F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Started>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Started;
			}
			[CompilerGenerated]
			[Token(Token = "0x600032C")]
			[Address(RVA = "0x9D88FC", Offset = "0x9D88FC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Started>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CStarted_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x170000D0")]
		public List<DelayedEvent> DelayedEvents
		{
			[Token(Token = "0x600032D")]
			[Address(RVA = "0x9D8908", Offset = "0x9D8908", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.delayedEvents;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DelayedEvents;
			}
		}

		[Token(Token = "0x170000D1")]
		public int DataVersion
		{
			[Token(Token = "0x600032F")]
			[Address(RVA = "0x9D8968", Offset = "0x9D8968", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.dataVersion;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DataVersion;
			}
			[Token(Token = "0x6000330")]
			[Address(RVA = "0x9D8970", Offset = "0x9D8970", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.dataVersion = value;\n\treturn;\n")]
			set
			{
				DataVersion = value;
			}
		}

		[Token(Token = "0x170000D2")]
		public MonoBehaviour Owner
		{
			[Token(Token = "0x6000331")]
			[Address(RVA = "0x9D8978", Offset = "0x9D8978", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.owner;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Owner;
			}
			[Token(Token = "0x6000332")]
			[Address(RVA = "0x9D8980", Offset = "0x9D8980", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.owner = value;\n\treturn;\n")]
			set
			{
				Owner = value;
			}
		}

		[Token(Token = "0x170000D3")]
		public bool NameIsExpanded
		{
			[Token(Token = "0x6000333")]
			[Address(RVA = "0x9D8988", Offset = "0x9D8988", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.editorFlags & 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (byte)(editorFlags & EditorFlags.nameIsExpanded) != 0;
			}
			[Token(Token = "0x6000334")]
			[Address(RVA = "0x9D8994", Offset = "0x9D8994", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = value == 0;\n\tv8 = this.editorFlags & 0xFFFFFFFE;\n\tv14 = this.editorFlags | 1;\n\tv10 = ~v5;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_000F;\nL_000F:\n\tthis.editorFlags = v14;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0023: Expected I4, but got I8
				bool flag = !value;
				int num = (int)((long)editorFlags & 0xFFFFFFFEL);
				int num2 = (int)(editorFlags | EditorFlags.nameIsExpanded);
				if (flag)
				{
					num2 = num;
				}
				editorFlags = (EditorFlags)num2;
			}
		}

		[Token(Token = "0x170000D4")]
		public bool ControlsIsExpanded
		{
			[Token(Token = "0x6000335")]
			[Address(RVA = "0x9D89B0", Offset = "0x9D89B0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.editorFlags >> 1;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = (int)editorFlags >> 1;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x6000336")]
			[Address(RVA = "0x9D89BC", Offset = "0x9D89BC", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = value == 0;\n\tv8 = this.editorFlags & 0xFFFFFFFD;\n\tv14 = this.editorFlags | 2;\n\tv10 = ~v5;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_000F;\nL_000F:\n\tthis.editorFlags = v14;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0023: Expected I4, but got I8
				bool flag = !value;
				int num = (int)((long)editorFlags & 0xFFFFFFFDL);
				int num2 = (int)(editorFlags | EditorFlags.controlsIsExpanded);
				if (flag)
				{
					num2 = num;
				}
				editorFlags = (EditorFlags)num2;
			}
		}

		[Token(Token = "0x170000D5")]
		public bool DebugIsExpanded
		{
			[Token(Token = "0x6000337")]
			[Address(RVA = "0x9D89D8", Offset = "0x9D89D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.editorFlags >> 2;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = (int)editorFlags >> 2;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x6000338")]
			[Address(RVA = "0x9D89E4", Offset = "0x9D89E4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = value == 0;\n\tv8 = this.editorFlags & 0xFFFFFFFB;\n\tv14 = this.editorFlags | 4;\n\tv10 = ~v5;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_000F;\nL_000F:\n\tthis.editorFlags = v14;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0023: Expected I4, but got I8
				bool flag = !value;
				int num = (int)((long)editorFlags & 0xFFFFFFFBL);
				int num2 = (int)(editorFlags | EditorFlags.debugIsExpanded);
				if (flag)
				{
					num2 = num;
				}
				editorFlags = (EditorFlags)num2;
			}
		}

		[Token(Token = "0x170000D6")]
		public bool ExperimentalIsExpanded
		{
			[Token(Token = "0x6000339")]
			[Address(RVA = "0x9D8A00", Offset = "0x9D8A00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.editorFlags >> 3;\n\treturnVal1 = v2 & 1;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = (int)editorFlags >> 3;
				return (byte)(num & 1) != 0;
			}
			[Token(Token = "0x600033A")]
			[Address(RVA = "0x9D8A0C", Offset = "0x9D8A0C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = value == 0;\n\tv8 = this.editorFlags & 0xFFFFFFF7;\n\tv14 = this.editorFlags | 8;\n\tv10 = ~v5;\n\tv11 = ~v10;\n\tif (v11) goto L_FFFFFFFF;\n\tgoto L_000F;\nL_000F:\n\tthis.editorFlags = v14;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0023: Expected I4, but got I8
				bool flag = !value;
				int num = (int)((long)editorFlags & 0xFFFFFFF7L);
				int num2 = (int)(editorFlags | EditorFlags.experimentalIsExpanded);
				if (flag)
				{
					num2 = num;
				}
				editorFlags = (EditorFlags)num2;
			}
		}

		[Token(Token = "0x170000D7")]
		public string Name
		{
			[Token(Token = "0x600033B")]
			[Address(RVA = "0x9D8A28", Offset = "0x9D8A28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x600033C")]
			[Address(RVA = "0x9D8A30", Offset = "0x9D8A30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x170000D8")]
		public FsmTemplate UsedInTemplate
		{
			[Token(Token = "0x600033D")]
			[Address(RVA = "0x9D8A38", Offset = "0x9D8A38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.usedInTemplate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UsedInTemplate;
			}
			[Token(Token = "0x600033E")]
			[Address(RVA = "0x9D8A40", Offset = "0x9D8A40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.usedInTemplate = value;\n\treturn;\n")]
			set
			{
				UsedInTemplate = value;
			}
		}

		[Token(Token = "0x170000D9")]
		public string StartState
		{
			[Token(Token = "0x600033F")]
			[Address(RVA = "0x9D8A48", Offset = "0x9D8A48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.startState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StartState;
			}
			[Token(Token = "0x6000340")]
			[Address(RVA = "0x9D8A50", Offset = "0x9D8A50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.startState = value;\n\treturn;\n")]
			set
			{
				StartState = value;
			}
		}

		[Token(Token = "0x170000DA")]
		public FsmState[] States
		{
			[Token(Token = "0x6000341")]
			[Address(RVA = "0x9D8A58", Offset = "0x9D8A58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.states;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return States;
			}
			[Token(Token = "0x6000342")]
			[Address(RVA = "0x9D8A60", Offset = "0x9D8A60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.states = value;\n\treturn;\n")]
			set
			{
				States = value;
			}
		}

		[Token(Token = "0x170000DB")]
		public FsmEvent[] Events
		{
			[Token(Token = "0x6000343")]
			[Address(RVA = "0x9D8A68", Offset = "0x9D8A68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.events;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Events;
			}
			[Token(Token = "0x6000344")]
			[Address(RVA = "0x9D8A70", Offset = "0x9D8A70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.events = value;\n\treturn;\n")]
			set
			{
				Events = value;
			}
		}

		[Token(Token = "0x170000DC")]
		public FsmTransition[] GlobalTransitions
		{
			[Token(Token = "0x6000345")]
			[Address(RVA = "0x9D8A78", Offset = "0x9D8A78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.globalTransitions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GlobalTransitions;
			}
			[Token(Token = "0x6000346")]
			[Address(RVA = "0x9D8A80", Offset = "0x9D8A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.globalTransitions = value;\n\treturn;\n")]
			set
			{
				GlobalTransitions = value;
			}
		}

		[Token(Token = "0x170000DD")]
		public FsmVariables Variables
		{
			[Token(Token = "0x6000347")]
			[Address(RVA = "0x9D8A88", Offset = "0x9D8A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.variables;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Variables;
			}
			[Token(Token = "0x6000348")]
			[Address(RVA = "0x9D8A90", Offset = "0x9D8A90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.variables = value;\n\treturn;\n")]
			set
			{
				Variables = value;
			}
		}

		[Token(Token = "0x170000DE")]
		public FsmEventTarget EventTarget
		{
			[CompilerGenerated]
			[Token(Token = "0x6000349")]
			[Address(RVA = "0x9D8A98", Offset = "0x9D8A98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EventTarget>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EventTarget;
			}
			[CompilerGenerated]
			[Token(Token = "0x600034A")]
			[Address(RVA = "0x9D8AA0", Offset = "0x9D8AA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EventTarget>k__BackingField = value;\n\treturn;\n")]
			set
			{
				EventTarget = value;
			}
		}

		[Token(Token = "0x170000DF")]
		public bool Initialized
		{
			[Token(Token = "0x600034B")]
			[Address(RVA = "0x9D8AA8", Offset = "0x9D8AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.initialized;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Initialized;
			}
		}

		[Token(Token = "0x170000E0")]
		public bool Active
		{
			[Token(Token = "0x600034C")]
			[Address(RVA = "0x9D8AB0", Offset = "0x9D8AB0", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE29D8]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A1F]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tv82 = UnityEngine.Component::get_gameObject(this.owner);\n\tgoto L_003C;\n\tv147 = *([v77 @ X8_v7+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_003C;\n\tv154 = v77;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v154, v81, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tv71 = UnityEngine.Object::op_Inequality(v82, 0);\n\tv74 = v71 == 0;\n\tif (v74) goto L_FFFFFFFF;\n\tv73 = ~this.<Finished>k__BackingField;\n\tif (v73) goto L_004C;\nL_004A:\n\treturn returnVal1;\nL_004C:\n\tv157 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv101 = v157 == 0;\n\tv86 = ~v101;\n\tgoto L_004A;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Owner != null)
				{
					GameObject gameObject = Owner.gameObject;
					if (gameObject != null && !Finished)
					{
						FsmState fsmState = ActiveState;
						bool flag = fsmState == null;
						return !flag;
					}
				}
				return false;
			}
		}

		[Token(Token = "0x170000E1")]
		public bool Finished
		{
			[CompilerGenerated]
			[Token(Token = "0x600034D")]
			[Address(RVA = "0x9D8C14", Offset = "0x9D8C14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Finished>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Finished;
			}
			[CompilerGenerated]
			[Token(Token = "0x600034E")]
			[Address(RVA = "0x9D8C1C", Offset = "0x9D8C1C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Finished>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CFinished_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x170000E2")]
		public bool IsSwitchingState
		{
			[Token(Token = "0x600034F")]
			[Address(RVA = "0x9D8C28", Offset = "0x9D8C28", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.switchToState == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = switchToState == null;
				return !flag;
			}
		}

		[Token(Token = "0x170000E3")]
		public FsmState ActiveState
		{
			[Token(Token = "0x6000350")]
			[Address(RVA = "0x9D8B98", Offset = "0x9D8B98", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBA290]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A20]) = v38;\nL_0013:\n\treturnVal1 = this.activeState;\n\tv40 = this.activeState == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002B;\n\tv47 = System.String::op_Inequality(this.activeStateName, \"\");\n\tv55 = v47 == 0;\n\tif (v55) goto L_0025;\n\treturnVal1 = HutongGames.PlayMaker.Fsm::GetState(this, this.activeStateName);\n\tthis.activeState = returnVal1;\n\tgoto L_002B;\nL_0025:\n\treturnVal1 = this.activeState;\nL_002B:\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmState result = activeState;
				if (activeState == null)
				{
					result = ((!(ActiveStateName != "")) ? activeState : (activeState = GetState(ActiveStateName)));
				}
				return result;
			}
			[Token(Token = "0x6000351")]
			[Address(RVA = "0x9D8CCC", Offset = "0x9D8CCC", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEDE68]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A21]) = v41;\nL_0015:\n\tthis.activeState = value;\n\tv60 = value + 0x40;\n\tv55 = value != 0;\n\tif (v55) goto L_002B;\n\tgoto L_002B;\nL_002B:\n\tthis.activeStateName = value.name;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				//IL_0014: Expected O, but got I
				activeState = value;
				string text = (string)((long)(IntPtr)value + 64L);
				if (value == null)
				{
					text = "";
				}
				activeStateName = text;
			}
		}

		[Token(Token = "0x170000E4")]
		public string ActiveStateName
		{
			[Token(Token = "0x6000352")]
			[Address(RVA = "0x9D8D44", Offset = "0x9D8D44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.activeStateName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActiveStateName;
			}
		}

		[Token(Token = "0x170000E5")]
		public FsmState PreviousActiveState
		{
			[Token(Token = "0x6000353")]
			[Address(RVA = "0x9D8D4C", Offset = "0x9D8D4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.previousActiveState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PreviousActiveState;
			}
			[Token(Token = "0x6000354")]
			[Address(RVA = "0x9D8D54", Offset = "0x9D8D54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.previousActiveState = value;\n\treturn;\n")]
			private set
			{
				previousActiveState = value;
			}
		}

		[Token(Token = "0x170000E6")]
		public FsmTransition LastTransition
		{
			[CompilerGenerated]
			[Token(Token = "0x6000355")]
			[Address(RVA = "0x9D8D5C", Offset = "0x9D8D5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastTransition>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastTransition;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000356")]
			[Address(RVA = "0x9D8D64", Offset = "0x9D8D64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastTransition>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLastTransition_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x170000E7")]
		public int MaxLoopCount
		{
			[Token(Token = "0x6000357")]
			[Address(RVA = "0x9D8D6C", Offset = "0x9D8D6C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.maxLoopCount - 1;\n\tv6 = v5 < 0;\n\tv8 = this.maxLoopCount ^ 1;\n\tv9 = this.maxLoopCount ^ v5;\n\tv10 = v8 & v9;\n\tv11 = v10 < 0;\n\tv12 = v6 == v11;\n\tv13 = ~v12;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\n\tgoto L_0013;\nL_0013:\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = MaxLoopCountOverride - 1;
				bool flag = num < 0;
				int num2 = MaxLoopCountOverride ^ 1;
				int num3 = MaxLoopCountOverride ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				if (flag != flag2)
				{
					return 1000;
				}
				return MaxLoopCountOverride;
			}
		}

		[Token(Token = "0x170000E8")]
		public int MaxLoopCountOverride
		{
			[Token(Token = "0x6000358")]
			[Address(RVA = "0x9D8D80", Offset = "0x9D8D80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxLoopCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxLoopCountOverride;
			}
			[Token(Token = "0x6000359")]
			[Address(RVA = "0x9D8D88", Offset = "0x9D8D88", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE5D98]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A22]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Mathf::Max(0, value);\n\tthis.maxLoopCount = v58;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				int num = Mathf.Max(0, value);
				maxLoopCount = num;
			}
		}

		[Token(Token = "0x170000E9")]
		public string OwnerName
		{
			[Token(Token = "0x600035A")]
			[Address(RVA = "0x9D8E08", Offset = "0x9D8E08", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBBAB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A23]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003A;\n\treturnVal2 = UnityEngine.Object::get_name(this.owner);\n\treturn returnVal2;\nL_003A:\n\treturn \"\";\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Owner != null)
				{
					return Owner.name;
				}
				return "";
			}
		}

		[Token(Token = "0x170000EA")]
		public string OwnerDebugName
		{
			[Token(Token = "0x600035B")]
			[Address(RVA = "0x9D8EA8", Offset = "0x9D8EA8", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB3BA0]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A24]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerFSM;\nL_0022:\n\tv54 = ~v52.NotMainThread;\n\tif (v54) goto L_002E;\n\tgoto L_004E;\nL_002E:\n\tgoto L_0037;\n\tv81 = *([v61 @ X0_v6+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0037;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tv70 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\treturnVal2 = UnityEngine.Object::get_name(this.owner);\n\treturn returnVal2;\nL_004E:\n\treturn *([v73 @ X8_v7 (System.String)]);\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (PlayMakerFSM.NotMainThread)
				{
					return "";
				}
				if (Owner != null)
				{
					return Owner.name;
				}
				return "[missing Owner]";
			}
		}

		[Token(Token = "0x170000EB")]
		public GameObject GameObject
		{
			[Token(Token = "0x600035C")]
			[Address(RVA = "0x9D8F84", Offset = "0x9D8F84", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EFD0B0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A25]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0038;\n\treturnVal2 = UnityEngine.Component::get_gameObject(this.owner);\n\treturn returnVal2;\nL_0038:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Owner != null)
				{
					return Owner.gameObject;
				}
				return null;
			}
		}

		[Token(Token = "0x170000EC")]
		public string GameObjectName
		{
			[Token(Token = "0x600035D")]
			[Address(RVA = "0x9D901C", Offset = "0x9D901C", Length = "0xAC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE5C90]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A26]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.owner, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003E;\n\tv69 = UnityEngine.Component::get_gameObject(this.owner);\n\treturnVal3 = UnityEngine.Object::get_name(v69);\n\treturn returnVal3;\nL_003E:\n\treturn \"[missing GameObject]\";\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Owner != null)
				{
					GameObject gameObject = Owner.gameObject;
					return gameObject.name;
				}
				return "[missing GameObject]";
			}
		}

		[Token(Token = "0x170000ED")]
		public UnityEngine.Object OwnerObject
		{
			[Token(Token = "0x600035E")]
			[Address(RVA = "0x9D90C8", Offset = "0x9D90C8", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0A380]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A27]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = UnityEngine.Object::op_Implicit(this.usedInTemplate);\n\tv57 = v55 == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((bool)UsedInTemplate)
				{
					return UsedInTemplate;
				}
				return Owner;
			}
		}

		[Token(Token = "0x170000EE")]
		public PlayMakerFSM FsmComponent
		{
			[Token(Token = "0x600035F")]
			[Address(RVA = "0x9D9148", Offset = "0x9D9148", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0D9B0]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A28]) = v38;\nL_0014:\n\tv40 = this.owner == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0040;\n\tv94 = v94_asT == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if ((object)Owner == null)
				{
					return null;
				}
				PlayMakerFSM playMakerFSM = Owner as PlayMakerFSM;
				if ((object)playMakerFSM != null)
				{
					return (PlayMakerFSM)Owner;
				}
				return null;
			}
		}

		[Token(Token = "0x170000EF")]
		public FsmLog MyLog
		{
			[Token(Token = "0x6000360")]
			[Address(RVA = "0x9D91CC", Offset = "0x9D91CC", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAEBD0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A29]) = v38;\nL_0013:\n\treturnVal1 = this.myLog;\n\tv40 = this.myLog == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002C;\n\tgoto L_0025;\n\tv60 = *([v44 @ X0_v4+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0025;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = HutongGames.PlayMaker.FsmLog::GetLog(this);\n\tthis.myLog = returnVal1;\nL_002C:\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmLog result = myLog;
				if (myLog == null)
				{
					result = (myLog = FsmLog.GetLog(this));
				}
				return result;
			}
		}

		[Token(Token = "0x170000F0")]
		public bool IsModifiedPrefabInstance
		{
			[CompilerGenerated]
			[Token(Token = "0x6000361")]
			[Address(RVA = "0x9D9244", Offset = "0x9D9244", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsModifiedPrefabInstance>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsModifiedPrefabInstance;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000362")]
			[Address(RVA = "0x9D924C", Offset = "0x9D924C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsModifiedPrefabInstance>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsModifiedPrefabInstance_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x170000F1")]
		public string Description
		{
			[Token(Token = "0x6000363")]
			[Address(RVA = "0x9D9258", Offset = "0x9D9258", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.description;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Description;
			}
			[Token(Token = "0x6000364")]
			[Address(RVA = "0x9D9260", Offset = "0x9D9260", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.description = value;\n\treturn;\n")]
			set
			{
				Description = value;
			}
		}

		[Token(Token = "0x170000F2")]
		public string Watermark
		{
			[Token(Token = "0x6000365")]
			[Address(RVA = "0x9D9268", Offset = "0x9D9268", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.watermark;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Watermark;
			}
			[Token(Token = "0x6000366")]
			[Address(RVA = "0x9D9270", Offset = "0x9D9270", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.watermark = value;\n\treturn;\n")]
			set
			{
				Watermark = value;
			}
		}

		[Token(Token = "0x170000F3")]
		public bool ShowStateLabel
		{
			[Token(Token = "0x6000367")]
			[Address(RVA = "0x9D9278", Offset = "0x9D9278", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.showStateLabel;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShowStateLabel;
			}
			[Token(Token = "0x6000368")]
			[Address(RVA = "0x9D9280", Offset = "0x9D9280", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.showStateLabel = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				showStateLabel = value;
			}
		}

		[Token(Token = "0x170000F4")]
		public static Color DebugLookAtColor
		{
			[Token(Token = "0x6000369")]
			[Address(RVA = "0x9D928C", Offset = "0x9D928C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED8E08]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A2A]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0027:\n\treturn v49.debugLookAtColor;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return debugLookAtColor;
			}
			[Token(Token = "0x600036A")]
			[Address(RVA = "0x9D92F8", Offset = "0x9D92F8", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1ED99B0]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2021A2B]) = v47;\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv58 = HutongGames.PlayMaker.Fsm;\nL_0029:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv61.debugLookAtColor = value;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+C]) = value.g;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+10]) = value.b;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+14]) = value.a;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0013: Expected I, but got O
				//IL_0021: Expected I, but got O
				IntPtr intPtr = (IntPtr)typeof(Fsm);
				IntPtr intPtr2 = (IntPtr)EventData;
				debugLookAtColor = value;
				_ = value.g;
				_ = value.b;
				_ = value.a;
			}
		}

		[Token(Token = "0x170000F5")]
		public static Color DebugRaycastColor
		{
			[Token(Token = "0x600036B")]
			[Address(RVA = "0x9D9384", Offset = "0x9D9384", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECCC88]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A2C]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0027:\n\treturn v49.debugRaycastColor;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return debugRaycastColor;
			}
			[Token(Token = "0x600036C")]
			[Address(RVA = "0x9D93F0", Offset = "0x9D93F0", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1F10DB0]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2021A2D]) = v47;\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv58 = HutongGames.PlayMaker.Fsm;\nL_0029:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv61.debugRaycastColor = value;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+1C]) = value.g;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+20]) = value.b;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+24]) = value.a;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0013: Expected I, but got O
				//IL_0021: Expected I, but got O
				IntPtr intPtr = (IntPtr)typeof(Fsm);
				IntPtr intPtr2 = (IntPtr)EventData;
				debugRaycastColor = value;
				_ = value.g;
				_ = value.b;
				_ = value.a;
			}
		}

		[Token(Token = "0x170000F6")]
		private string GuiLabel
		{
			[Token(Token = "0x600036D")]
			[Address(RVA = "0x9D947C", Offset = "0x9D947C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB28F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A2E]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.Fsm::get_OwnerName(this);\n\treturnVal1 = System.String::Concat(v40, \" : \", this.name);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string ownerName = OwnerName;
				return ownerName + " : " + Name;
			}
		}

		[Token(Token = "0x170000F7")]
		public string DocUrl
		{
			[Token(Token = "0x600036E")]
			[Address(RVA = "0x9D94D8", Offset = "0x9D94D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.docUrl;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DocUrl;
			}
			[Token(Token = "0x600036F")]
			[Address(RVA = "0x9D94E0", Offset = "0x9D94E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.docUrl = value;\n\treturn;\n")]
			set
			{
				DocUrl = value;
			}
		}

		[Token(Token = "0x170000F8")]
		public FsmState EditState
		{
			[Token(Token = "0x6000370")]
			[Address(RVA = "0x9D94E8", Offset = "0x9D94E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.editState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EditState;
			}
			[Token(Token = "0x6000371")]
			[Address(RVA = "0x9D94F0", Offset = "0x9D94F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.editState = value;\n\treturn;\n")]
			set
			{
				EditState = value;
			}
		}

		[Token(Token = "0x170000F9")]
		[field: Token(Token = "0x4000223")]
		public static GameObject LastClickedObject
		{
			[Token(Token = "0x6000372")]
			[Address(RVA = "0x9D94F8", Offset = "0x9D94F8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFF128]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A2F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<LastClickedObject>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000373")]
			[Address(RVA = "0x9D9560", Offset = "0x9D9560", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA7C28]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A30]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0021:\n\tv52.<LastClickedObject>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x170000FA")]
		[field: Token(Token = "0x4000224")]
		public static bool BreakpointsEnabled
		{
			[Token(Token = "0x6000374")]
			[Address(RVA = "0x9D95CC", Offset = "0x9D95CC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC3008]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A31]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<BreakpointsEnabled>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000375")]
			[Address(RVA = "0x9D9634", Offset = "0x9D9634", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF6F48]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A32]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv52.<BreakpointsEnabled>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x170000FB")]
		[field: Token(Token = "0x4000225")]
		public static bool HitBreakpoint
		{
			[Token(Token = "0x6000376")]
			[Address(RVA = "0x9D96A4", Offset = "0x9D96A4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED9C48]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A33]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<HitBreakpoint>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000377")]
			[Address(RVA = "0x9D970C", Offset = "0x9D970C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECAF90]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A34]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv52.<HitBreakpoint>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x170000FC")]
		[field: Token(Token = "0x4000226")]
		public static Fsm BreakAtFsm
		{
			[Token(Token = "0x6000378")]
			[Address(RVA = "0x9D977C", Offset = "0x9D977C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE67B8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A35]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<BreakAtFsm>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000379")]
			[Address(RVA = "0x9D97E4", Offset = "0x9D97E4", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FBB0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A36]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0021:\n\tv52.<BreakAtFsm>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x170000FD")]
		[field: Token(Token = "0x4000227")]
		public static FsmState BreakAtState
		{
			[Token(Token = "0x600037A")]
			[Address(RVA = "0x9D9850", Offset = "0x9D9850", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED1508]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A37]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<BreakAtState>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600037B")]
			[Address(RVA = "0x9D98B8", Offset = "0x9D98B8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEC780]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A38]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0021:\n\tv52.<BreakAtState>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x170000FE")]
		[field: Token(Token = "0x4000228")]
		public static bool IsBreak
		{
			[Token(Token = "0x600037C")]
			[Address(RVA = "0x9D9924", Offset = "0x9D9924", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE9BA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A39]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<IsBreak>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600037D")]
			[Address(RVA = "0x9D998C", Offset = "0x9D998C", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA6BA8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A3A]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv52.<IsBreak>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x170000FF")]
		[field: Token(Token = "0x4000229")]
		public static bool IsErrorBreak
		{
			[Token(Token = "0x600037E")]
			[Address(RVA = "0x9D99FC", Offset = "0x9D99FC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB4A08]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A3B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<IsErrorBreak>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600037F")]
			[Address(RVA = "0x9D9A64", Offset = "0x9D9A64", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAA2C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A3C]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv52.<IsErrorBreak>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000100")]
		[field: Token(Token = "0x400022A")]
		public static string LastError
		{
			[Token(Token = "0x6000380")]
			[Address(RVA = "0x9D9AD4", Offset = "0x9D9AD4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE5100]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A3D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<LastError>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000381")]
			[Address(RVA = "0x9D9B3C", Offset = "0x9D9B3C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE2650]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A3E]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0021:\n\tv52.<LastError>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000101")]
		[field: Token(Token = "0x400022B")]
		public static bool StepToStateChange
		{
			[Token(Token = "0x6000382")]
			[Address(RVA = "0x9D9BA8", Offset = "0x9D9BA8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF0CD0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A3F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<StepToStateChange>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000383")]
			[Address(RVA = "0x9D9C10", Offset = "0x9D9C10", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB0420]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A40]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv52.<StepToStateChange>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000102")]
		[field: Token(Token = "0x400022C")]
		public static Fsm StepFsm
		{
			[Token(Token = "0x6000384")]
			[Address(RVA = "0x9D9C80", Offset = "0x9D9C80", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFFE30]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A41]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\treturn v49.<StepFsm>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000385")]
			[Address(RVA = "0x9D9CE8", Offset = "0x9D9CE8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8CE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A42]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0021:\n\tv52.<StepFsm>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000103")]
		public bool SwitchedState
		{
			[CompilerGenerated]
			[Token(Token = "0x6000386")]
			[Address(RVA = "0x9D9D54", Offset = "0x9D9D54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SwitchedState>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SwitchedState;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000387")]
			[Address(RVA = "0x9D9D5C", Offset = "0x9D9D5C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SwitchedState>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CSwitchedState_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000104")]
		public bool MouseEvents
		{
			[Token(Token = "0x6000388")]
			[Address(RVA = "0x9D9D68", Offset = "0x9D9D68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mouseEvents;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MouseEvents;
			}
			[Token(Token = "0x6000389")]
			[Address(RVA = "0x9D9D70", Offset = "0x9D9D70", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.mouseEvents = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.mouseEvents == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.mouseEvents = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				mouseEvents = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.MouseEvents;
						bool flag3 = !flag2;
						flag = (fsm.mouseEvents = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000105")]
		public bool HandleLevelLoaded
		{
			[Token(Token = "0x600038A")]
			[Address(RVA = "0x9D9DAC", Offset = "0x9D9DAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleLevelLoaded;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleLevelLoaded;
			}
			[Token(Token = "0x600038B")]
			[Address(RVA = "0x9D9DB4", Offset = "0x9D9DB4", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.handleLevelLoaded = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_0018;\nL_000A:\n\tv24 = v38.handleLevelLoaded == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleLevelLoaded = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_000A;\nL_0018:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				bool flag = default(bool);
				handleLevelLoaded = flag;
				if (Host != null)
				{
					do
					{
						bool flag2 = !fsm.HandleLevelLoaded;
						bool flag3 = !flag2;
						flag = (fsm.handleLevelLoaded = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000106")]
		public bool HandleTriggerEnter2D
		{
			[Token(Token = "0x600038C")]
			[Address(RVA = "0x9D9DE8", Offset = "0x9D9DE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerEnter2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerEnter2D;
			}
			[Token(Token = "0x600038D")]
			[Address(RVA = "0x9D9DF0", Offset = "0x9D9DF0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerEnter2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerEnter2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerEnter2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerEnter2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerEnter2D;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerEnter2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000107")]
		public bool HandleTriggerExit2D
		{
			[Token(Token = "0x600038E")]
			[Address(RVA = "0x9D9E2C", Offset = "0x9D9E2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerExit2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerExit2D;
			}
			[Token(Token = "0x600038F")]
			[Address(RVA = "0x9D9E34", Offset = "0x9D9E34", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerExit2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerExit2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerExit2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerExit2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerExit2D;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerExit2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000108")]
		public bool HandleTriggerStay2D
		{
			[Token(Token = "0x6000390")]
			[Address(RVA = "0x9D9E70", Offset = "0x9D9E70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerStay2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerStay2D;
			}
			[Token(Token = "0x6000391")]
			[Address(RVA = "0x9D9E78", Offset = "0x9D9E78", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerStay2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerStay2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerStay2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerStay2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerStay2D;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerStay2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000109")]
		public bool HandleCollisionEnter2D
		{
			[Token(Token = "0x6000392")]
			[Address(RVA = "0x9D9EB4", Offset = "0x9D9EB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionEnter2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionEnter2D;
			}
			[Token(Token = "0x6000393")]
			[Address(RVA = "0x9D9EBC", Offset = "0x9D9EBC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionEnter2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionEnter2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionEnter2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionEnter2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionEnter2D;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionEnter2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010A")]
		public bool HandleCollisionExit2D
		{
			[Token(Token = "0x6000394")]
			[Address(RVA = "0x9D9EF8", Offset = "0x9D9EF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionExit2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionExit2D;
			}
			[Token(Token = "0x6000395")]
			[Address(RVA = "0x9D9F00", Offset = "0x9D9F00", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionExit2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionExit2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionExit2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionExit2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionExit2D;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionExit2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010B")]
		public bool HandleCollisionStay2D
		{
			[Token(Token = "0x6000396")]
			[Address(RVA = "0x9D9F3C", Offset = "0x9D9F3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionStay2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionStay2D;
			}
			[Token(Token = "0x6000397")]
			[Address(RVA = "0x9D9F44", Offset = "0x9D9F44", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionStay2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionStay2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionStay2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionStay2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionStay2D;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionStay2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010C")]
		public bool HandleTriggerEnter
		{
			[Token(Token = "0x6000398")]
			[Address(RVA = "0x9D9F80", Offset = "0x9D9F80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerEnter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerEnter;
			}
			[Token(Token = "0x6000399")]
			[Address(RVA = "0x9D9F88", Offset = "0x9D9F88", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerEnter = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerEnter == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerEnter = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerEnter = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerEnter;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerEnter = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010D")]
		public bool HandleTriggerExit
		{
			[Token(Token = "0x600039A")]
			[Address(RVA = "0x9D9FC4", Offset = "0x9D9FC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerExit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerExit;
			}
			[Token(Token = "0x600039B")]
			[Address(RVA = "0x9D9FCC", Offset = "0x9D9FCC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerExit = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerExit == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerExit = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerExit = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerExit;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerExit = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010E")]
		public bool HandleTriggerStay
		{
			[Token(Token = "0x600039C")]
			[Address(RVA = "0x9DA008", Offset = "0x9DA008", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleTriggerStay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleTriggerStay;
			}
			[Token(Token = "0x600039D")]
			[Address(RVA = "0x9DA010", Offset = "0x9DA010", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleTriggerStay = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleTriggerStay == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleTriggerStay = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleTriggerStay = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleTriggerStay;
						bool flag3 = !flag2;
						flag = (fsm.handleTriggerStay = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700010F")]
		public bool HandleCollisionEnter
		{
			[Token(Token = "0x600039E")]
			[Address(RVA = "0x9DA04C", Offset = "0x9DA04C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionEnter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionEnter;
			}
			[Token(Token = "0x600039F")]
			[Address(RVA = "0x9DA054", Offset = "0x9DA054", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionEnter = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionEnter == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionEnter = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionEnter = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionEnter;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionEnter = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000110")]
		public bool HandleCollisionExit
		{
			[Token(Token = "0x60003A0")]
			[Address(RVA = "0x9DA090", Offset = "0x9DA090", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionExit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionExit;
			}
			[Token(Token = "0x60003A1")]
			[Address(RVA = "0x9DA098", Offset = "0x9DA098", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionExit = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionExit == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionExit = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionExit = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionExit;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionExit = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000111")]
		public bool HandleCollisionStay
		{
			[Token(Token = "0x60003A2")]
			[Address(RVA = "0x9DA0D4", Offset = "0x9DA0D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleCollisionStay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleCollisionStay;
			}
			[Token(Token = "0x60003A3")]
			[Address(RVA = "0x9DA0DC", Offset = "0x9DA0DC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionStay = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleCollisionStay == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleCollisionStay = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleCollisionStay = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleCollisionStay;
						bool flag3 = !flag2;
						flag = (fsm.handleCollisionStay = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000112")]
		public bool HandleParticleCollision
		{
			[Token(Token = "0x60003A4")]
			[Address(RVA = "0x9DA118", Offset = "0x9DA118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleParticleCollision;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleParticleCollision;
			}
			[Token(Token = "0x60003A5")]
			[Address(RVA = "0x9DA120", Offset = "0x9DA120", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleParticleCollision = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleParticleCollision == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleParticleCollision = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleParticleCollision = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleParticleCollision;
						bool flag3 = !flag2;
						flag = (fsm.handleParticleCollision = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000113")]
		public bool HandleControllerColliderHit
		{
			[Token(Token = "0x60003A6")]
			[Address(RVA = "0x9DA15C", Offset = "0x9DA15C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleControllerColliderHit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleControllerColliderHit;
			}
			[Token(Token = "0x60003A7")]
			[Address(RVA = "0x9DA164", Offset = "0x9DA164", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleControllerColliderHit = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleControllerColliderHit == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleControllerColliderHit = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleControllerColliderHit = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleControllerColliderHit;
						bool flag3 = !flag2;
						flag = (fsm.handleControllerColliderHit = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000114")]
		public bool HandleJointBreak
		{
			[Token(Token = "0x60003A8")]
			[Address(RVA = "0x9DA1A0", Offset = "0x9DA1A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleJointBreak;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleJointBreak;
			}
			[Token(Token = "0x60003A9")]
			[Address(RVA = "0x9DA1A8", Offset = "0x9DA1A8", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleJointBreak = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleJointBreak == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleJointBreak = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleJointBreak = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleJointBreak;
						bool flag3 = !flag2;
						flag = (fsm.handleJointBreak = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000115")]
		public bool HandleJointBreak2D
		{
			[Token(Token = "0x60003AA")]
			[Address(RVA = "0x9DA1E4", Offset = "0x9DA1E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleJointBreak2D;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleJointBreak2D;
			}
			[Token(Token = "0x60003AB")]
			[Address(RVA = "0x9DA1EC", Offset = "0x9DA1EC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleJointBreak2D = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleJointBreak2D == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleJointBreak2D = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleJointBreak2D = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleJointBreak2D;
						bool flag3 = !flag2;
						flag = (fsm.handleJointBreak2D = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000116")]
		public bool HandleOnGUI
		{
			[Token(Token = "0x60003AC")]
			[Address(RVA = "0x9DA228", Offset = "0x9DA228", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleOnGUI;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleOnGUI;
			}
			[Token(Token = "0x60003AD")]
			[Address(RVA = "0x9DA230", Offset = "0x9DA230", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleOnGUI = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleOnGUI == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleOnGUI = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleOnGUI = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleOnGUI;
						bool flag3 = !flag2;
						flag = (fsm.handleOnGUI = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000117")]
		public bool HandleFixedUpdate
		{
			[Token(Token = "0x60003AE")]
			[Address(RVA = "0x9DA26C", Offset = "0x9DA26C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleFixedUpdate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleFixedUpdate;
			}
			[Token(Token = "0x60003AF")]
			[Address(RVA = "0x9DA274", Offset = "0x9DA274", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleFixedUpdate = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleFixedUpdate == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleFixedUpdate = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleFixedUpdate = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleFixedUpdate;
						bool flag3 = !flag2;
						flag = (fsm.handleFixedUpdate = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000118")]
		public bool HandleLateUpdate
		{
			[Token(Token = "0x60003B0")]
			[Address(RVA = "0x9DA2B0", Offset = "0x9DA2B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleLateUpdate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleLateUpdate;
			}
			[Token(Token = "0x60003B1")]
			[Address(RVA = "0x9DA2B8", Offset = "0x9DA2B8", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleLateUpdate = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleLateUpdate == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleLateUpdate = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleLateUpdate = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleLateUpdate;
						bool flag3 = !flag2;
						flag = (fsm.handleLateUpdate = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x17000119")]
		public bool HandleApplicationEvents
		{
			[Token(Token = "0x60003B2")]
			[Address(RVA = "0x9DA2F4", Offset = "0x9DA2F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleApplicationEvents;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleApplicationEvents;
			}
			[Token(Token = "0x60003B3")]
			[Address(RVA = "0x9DA2FC", Offset = "0x9DA2FC", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleApplicationEvents = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleApplicationEvents == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleApplicationEvents = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleApplicationEvents = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleApplicationEvents;
						bool flag3 = !flag2;
						flag = (fsm.handleApplicationEvents = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700011A")]
		public UiEvents HandleUiEvents
		{
			[Token(Token = "0x60003B4")]
			[Address(RVA = "0x9DA338", Offset = "0x9DA338", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleUiEvents;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleUiEvents;
			}
			[Token(Token = "0x60003B5")]
			[Address(RVA = "0x9DA340", Offset = "0x9DA340", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleUiEvents = v4;\n\tv3 = this.host == 0;\n\tif (v3) goto L_000D;\nL_0006:\n\tv11.preprocessed = 0;\n\tv5 = v11.handleUiEvents | v4;\n\tv11.handleUiEvents = v5;\n\tv11 = v11.host;\n\tv13 = v11.host == 0;\n\tv10 = ~v13;\n\tif (v10) goto L_0006;\nL_000D:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				UiEvents uiEvents = default(UiEvents);
				handleUiEvents = uiEvents;
				if (Host != null)
				{
					bool flag2;
					do
					{
						fsm.preprocessed = false;
						int num = (int)(fsm.handleUiEvents = fsm.HandleUiEvents | uiEvents);
						fsm = fsm.Host;
						bool flag = fsm.Host == null;
						flag2 = !flag;
						uiEvents = (UiEvents)num;
					}
					while (flag2);
				}
			}
		}

		[Token(Token = "0x1700011B")]
		public bool HandleLegacyNetworking
		{
			[Token(Token = "0x60003B6")]
			[Address(RVA = "0x9DA36C", Offset = "0x9DA36C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleLegacyNetworking;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleLegacyNetworking;
			}
			[Token(Token = "0x60003B7")]
			[Address(RVA = "0x9DA374", Offset = "0x9DA374", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleLegacyNetworking = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleLegacyNetworking == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleLegacyNetworking = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleLegacyNetworking = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleLegacyNetworking;
						bool flag3 = !flag2;
						flag = (fsm.handleLegacyNetworking = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700011C")]
		public Collision CollisionInfo
		{
			[CompilerGenerated]
			[Token(Token = "0x60003BA")]
			[Address(RVA = "0x9DA460", Offset = "0x9DA460", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CollisionInfo>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CollisionInfo;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003BB")]
			[Address(RVA = "0x9DA468", Offset = "0x9DA468", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CollisionInfo>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CollisionInfo = value;
			}
		}

		[Token(Token = "0x1700011D")]
		public Collider TriggerCollider
		{
			[CompilerGenerated]
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0x9DA470", Offset = "0x9DA470", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TriggerCollider>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TriggerCollider;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003BD")]
			[Address(RVA = "0x9DA478", Offset = "0x9DA478", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TriggerCollider>k__BackingField = value;\n\treturn;\n")]
			set
			{
				TriggerCollider = value;
			}
		}

		[Token(Token = "0x1700011E")]
		public Collision2D Collision2DInfo
		{
			[CompilerGenerated]
			[Token(Token = "0x60003BE")]
			[Address(RVA = "0x9DA480", Offset = "0x9DA480", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Collision2DInfo>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Collision2DInfo;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003BF")]
			[Address(RVA = "0x9DA488", Offset = "0x9DA488", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Collision2DInfo>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Collision2DInfo = value;
			}
		}

		[Token(Token = "0x1700011F")]
		public Collider2D TriggerCollider2D
		{
			[CompilerGenerated]
			[Token(Token = "0x60003C0")]
			[Address(RVA = "0x9DA490", Offset = "0x9DA490", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TriggerCollider2D>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TriggerCollider2D;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C1")]
			[Address(RVA = "0x9DA498", Offset = "0x9DA498", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TriggerCollider2D>k__BackingField = value;\n\treturn;\n")]
			set
			{
				TriggerCollider2D = value;
			}
		}

		[Token(Token = "0x17000120")]
		public float JointBreakForce
		{
			[CompilerGenerated]
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x9DA4A0", Offset = "0x9DA4A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<JointBreakForce>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return JointBreakForce;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C3")]
			[Address(RVA = "0x9DA4A8", Offset = "0x9DA4A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<JointBreakForce>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CJointBreakForce_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000121")]
		public Joint2D BrokenJoint2D
		{
			[CompilerGenerated]
			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x9DA4B0", Offset = "0x9DA4B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BrokenJoint2D>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BrokenJoint2D;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x9DA4B8", Offset = "0x9DA4B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<BrokenJoint2D>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBrokenJoint2D_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000122")]
		public GameObject ParticleCollisionGO
		{
			[CompilerGenerated]
			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x9DA4C0", Offset = "0x9DA4C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ParticleCollisionGO>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParticleCollisionGO;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x9DA4C8", Offset = "0x9DA4C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ParticleCollisionGO>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ParticleCollisionGO = value;
			}
		}

		[Token(Token = "0x17000123")]
		public GameObject CollisionGO
		{
			[Token(Token = "0x60003C8")]
			[Address(RVA = "0x9DA4D0", Offset = "0x9DA4D0", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.<CollisionInfo>k__BackingField == 0;\n\tif (v2) goto L_0006;\n\treturnVal2 = UnityEngine.Collision::get_gameObject(this.<CollisionInfo>k__BackingField);\n\treturn returnVal2;\nL_0006:\n\treturn this.<CollisionInfo>k__BackingField;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (CollisionInfo != null)
				{
					return CollisionInfo.gameObject;
				}
				return (GameObject)(object)CollisionInfo;
			}
		}

		[Token(Token = "0x17000124")]
		public GameObject Collision2dGO
		{
			[Token(Token = "0x60003C9")]
			[Address(RVA = "0x9DA4E4", Offset = "0x9DA4E4", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.<Collision2DInfo>k__BackingField == 0;\n\tif (v2) goto L_0006;\n\treturnVal2 = UnityEngine.Collision2D::get_gameObject(this.<Collision2DInfo>k__BackingField);\n\treturn returnVal2;\nL_0006:\n\treturn this.<Collision2DInfo>k__BackingField;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Collision2DInfo != null)
				{
					return Collision2DInfo.gameObject;
				}
				return (GameObject)(object)Collision2DInfo;
			}
		}

		[Token(Token = "0x17000125")]
		public GameObject TriggerGO
		{
			[Token(Token = "0x60003CA")]
			[Address(RVA = "0x9DA4F8", Offset = "0x9DA4F8", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF9F40]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A43]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.<TriggerCollider>k__BackingField, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0038;\n\treturnVal2 = UnityEngine.Component::get_gameObject(this.<TriggerCollider>k__BackingField);\n\treturn returnVal2;\nL_0038:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (TriggerCollider != null)
				{
					return TriggerCollider.gameObject;
				}
				return null;
			}
		}

		[Token(Token = "0x17000126")]
		public GameObject Trigger2dGO
		{
			[Token(Token = "0x60003CB")]
			[Address(RVA = "0x9DA590", Offset = "0x9DA590", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EBE070]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A44]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this.<TriggerCollider2D>k__BackingField, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0038;\n\treturnVal2 = UnityEngine.Component::get_gameObject(this.<TriggerCollider2D>k__BackingField);\n\treturn returnVal2;\nL_0038:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (TriggerCollider2D != null)
				{
					return TriggerCollider2D.gameObject;
				}
				return null;
			}
		}

		[Token(Token = "0x17000127")]
		public string TriggerName
		{
			[CompilerGenerated]
			[Token(Token = "0x60003CC")]
			[Address(RVA = "0x9DA628", Offset = "0x9DA628", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TriggerName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TriggerName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003CD")]
			[Address(RVA = "0x9DA630", Offset = "0x9DA630", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TriggerName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTriggerName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000128")]
		public string CollisionName
		{
			[CompilerGenerated]
			[Token(Token = "0x60003CE")]
			[Address(RVA = "0x9DA638", Offset = "0x9DA638", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CollisionName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CollisionName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003CF")]
			[Address(RVA = "0x9DA640", Offset = "0x9DA640", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CollisionName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CCollisionName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000129")]
		public string Trigger2dName
		{
			[CompilerGenerated]
			[Token(Token = "0x60003D0")]
			[Address(RVA = "0x9DA648", Offset = "0x9DA648", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Trigger2dName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Trigger2dName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003D1")]
			[Address(RVA = "0x9DA650", Offset = "0x9DA650", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Trigger2dName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTrigger2dName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700012A")]
		public string Collision2dName
		{
			[CompilerGenerated]
			[Token(Token = "0x60003D2")]
			[Address(RVA = "0x9DA658", Offset = "0x9DA658", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Collision2dName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Collision2dName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003D3")]
			[Address(RVA = "0x9DA660", Offset = "0x9DA660", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Collision2dName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CCollision2dName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700012B")]
		public ControllerColliderHit ControllerCollider
		{
			[CompilerGenerated]
			[Token(Token = "0x60003D4")]
			[Address(RVA = "0x9DA668", Offset = "0x9DA668", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ControllerCollider>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ControllerCollider;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003D5")]
			[Address(RVA = "0x9DA670", Offset = "0x9DA670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ControllerCollider>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ControllerCollider = value;
			}
		}

		[Token(Token = "0x1700012C")]
		public unsafe RaycastHit RaycastHitInfo
		{
			[CompilerGenerated]
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x9DA678", Offset = "0x9DA678", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.m_Distance = this.<RaycastHitInfo>k__BackingField.m_Distance;\n\t*([returnBuffer @ X8 (UnityEngine.RaycastHit)+10]) = this.<RaycastHitInfo>k__BackingField.m_Normal.y;\n\treturnBuffer.m_Point = this.<RaycastHitInfo>k__BackingField;\n\treturn this;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000f: Expected native int or pointer, but got O
				//IL_002f: Expected native int or pointer, but got O
				RaycastHit raycastHit = default(RaycastHit);
				((RaycastHit*)(IntPtr)raycastHit)->m_Distance = _003CRaycastHitInfo_003Ek__BackingField.distance;
				_ = _003CRaycastHitInfo_003Ek__BackingField.m_Normal.y;
				((RaycastHit*)(IntPtr)raycastHit)->m_Point = (Vector3)_003CRaycastHitInfo_003Ek__BackingField;
				return (RaycastHit)this;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x9DA6A0", Offset = "0x9DA6A0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RaycastHitInfo>k__BackingField.m_Collider = value.m_Collider;\n\tthis.<RaycastHitInfo>k__BackingField.m_UV = value.m_UV;\n\tthis.<RaycastHitInfo>k__BackingField.m_Normal.y = *([value @ X1 (UnityEngine.RaycastHit)+10]);\n\tthis.<RaycastHitInfo>k__BackingField = value.m_Point;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0044: Expected F4, but got I
				_003CRaycastHitInfo_003Ek__BackingField.m_Collider = value.m_Collider;
				_003CRaycastHitInfo_003Ek__BackingField.m_UV = value.m_UV;
				ref Vector3 normal = ref _003CRaycastHitInfo_003Ek__BackingField.m_Normal;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (UnityEngine.RaycastHit)+10]");
				normal.y = 0f;
				_003CRaycastHitInfo_003Ek__BackingField = (RaycastHit)value.m_Point;
			}
		}

		[Token(Token = "0x1700012D")]
		public bool HandleAnimatorMove
		{
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0x9DA8D8", Offset = "0x9DA8D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleAnimatorMove;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleAnimatorMove;
			}
			[Token(Token = "0x60003DB")]
			[Address(RVA = "0x9DA8E0", Offset = "0x9DA8E0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleAnimatorMove = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleAnimatorMove == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleAnimatorMove = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleAnimatorMove = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleAnimatorMove;
						bool flag3 = !flag2;
						flag = (fsm.handleAnimatorMove = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x1700012E")]
		public bool HandleAnimatorIK
		{
			[Token(Token = "0x60003DC")]
			[Address(RVA = "0x9DA91C", Offset = "0x9DA91C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.handleAnimatorIK;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HandleAnimatorIK;
			}
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0x9DA924", Offset = "0x9DA924", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.host;\n\tthis.preprocessed = 0;\n\tthis.handleAnimatorIK = v5;\n\tv4 = this.host == 0;\n\tif (v4) goto L_001A;\nL_0007:\n\tv38.preprocessed = 0;\n\tv24 = v38.handleAnimatorIK == 0;\n\tv9 = ~v24;\n\tv5 = v5 | v9;\n\tv38.handleAnimatorIK = v5;\n\tv38 = v38.host;\n\tv43 = v38.host == 0;\n\tv35 = ~v43;\n\tif (v35) goto L_0007;\nL_001A:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Fsm fsm = Host;
				preprocessed = false;
				bool flag = default(bool);
				handleAnimatorIK = flag;
				if (Host != null)
				{
					do
					{
						fsm.preprocessed = false;
						bool flag2 = !fsm.HandleAnimatorIK;
						bool flag3 = !flag2;
						flag = (fsm.handleAnimatorIK = flag || flag3);
						fsm = fsm.Host;
					}
					while (fsm.Host != null);
				}
			}
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0x9D86D4", Offset = "0x9D86D4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.locked;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tthis.password = pass;\n\tthis.locked = 1;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Lock(string pass)
		{
			if (!Locked)
			{
				password = pass;
				locked = true;
			}
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0x9D86F0", Offset = "0x9D86F0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(this.password);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0016;\n\tv23 = System.String::op_Equality(pass, this.password);\n\tv27 = v23 == 0;\n\tif (v27) goto L_001C;\nL_0016:\n\tthis.locked = 0;\nL_001C:\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Unlock(string pass)
		{
			if (string.IsNullOrEmpty(Password) || pass == Password)
			{
				locked = false;
			}
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0x9D8910", Offset = "0x9D8910", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EDEE30]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A1E]) = v38;\nL_001E:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Clear(this.delayedEvents);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void KillDelayedEvents()
		{
			DelayedEvents.Clear();
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0x9DA3B0", Offset = "0x9DA3B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::ResetEventHandlerFlags(this);\n\treturn;\n")]
		public void ForcePreprocess()
		{
			ResetEventHandlerFlags();
		}

		[Token(Token = "0x60003B9")]
		[Address(RVA = "0x9DA3B4", Offset = "0x9DA3B4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv103 = this.host;\n\tthis.handleApplicationEvents = 0;\n\tthis.handleCollisionEnter = 0;\n\tthis.preprocessed = 0;\n\tv2 = this.host == 0;\n\tif (v2) goto L_001C;\nL_0008:\n\tv103.preprocessed = 0;\n\tv20 = v103.handleCollisionExit == 0;\n\tv5 = ~v20;\n\tv52 = v52 | v5;\n\tv32 = v52 & 1;\n\tv103.handleCollisionExit = v32;\n\tv103 = v103.host;\n\tv61 = v103.host == 0;\n\tv38 = ~v61;\n\tif (v38) goto L_0008;\n\tv103 = this.host;\nL_001C:\n\tthis.handleCollisionStay = 0;\n\tthis.handleCollisionEnter2D = 0;\n\tthis.preprocessed = 0;\n\tv41 = v103 == 0;\n\tif (v41) goto L_0038;\nL_0023:\n\tv103.preprocessed = 0;\n\tv74 = v103.handleCollisionExit2D == 0;\n\tv64 = ~v74;\n\tv101 = v101 | v64;\n\tv82 = v101 & 1;\n\tv103.handleCollisionExit2D = v82;\n\tv103 = v103.host;\n\tv107 = v103.host == 0;\n\tv86 = ~v107;\n\tif (v86) goto L_0023;\nL_0038:\n\tthis.handleTriggerEnter2D = 0;\n\tthis.handleTriggerExit2D = 0;\n\tthis.handleAnimatorMove = 0;\n\tthis.handleLegacyNetworking = 0;\n\tthis.handleUiEvents = 0;\n\tthis.preprocessed = 0;\n\tthis.handleCollisionStay2D = 0;\n\tthis.handleLateUpdate = 0;\n\tthis.handleOnGUI = 0;\n\tthis.handleParticleCollision = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetEventHandlerFlags()
		{
			Fsm fsm = Host;
			handleApplicationEvents = false;
			handleCollisionEnter = false;
			handleCollisionExit = false;
			preprocessed = false;
			int num2 = default(int);
			Fsm fsm2 = default(Fsm);
			if (Host != null)
			{
				int num = 0;
				num = num2;
				fsm = fsm2;
				do
				{
					fsm.preprocessed = false;
					bool flag = !fsm.HandleCollisionExit;
					bool flag2 = !flag;
					num |= (flag2 ? 1 : 0);
					int num3 = num & 1;
					fsm.handleCollisionExit = (byte)num3 != 0;
					fsm = fsm.Host;
				}
				while (fsm.Host != null);
				fsm = Host;
			}
			handleCollisionStay = false;
			handleCollisionEnter2D = false;
			handleCollisionExit2D = false;
			preprocessed = false;
			if (fsm != null)
			{
				int num4 = 0;
				num4 = num2;
				fsm = fsm2;
				do
				{
					fsm.preprocessed = false;
					bool flag3 = !fsm.HandleCollisionExit2D;
					bool flag4 = !flag3;
					num4 |= (flag4 ? 1 : 0);
					int num5 = num4 & 1;
					fsm.handleCollisionExit2D = (byte)num5 != 0;
					fsm = fsm.Host;
				}
				while (fsm.Host != null);
			}
			handleTriggerEnter2D = false;
			handleTriggerExit2D = false;
			handleTriggerStay2D = false;
			handleAnimatorMove = false;
			handleAnimatorIK = false;
			handleLegacyNetworking = false;
			handleUiEvents = default(UiEvents);
			preprocessed = false;
			handleCollisionStay2D = false;
			handleTriggerEnter = false;
			handleTriggerExit = false;
			handleTriggerStay = false;
			handleLateUpdate = false;
			handleOnGUI = false;
			handleFixedUpdate = false;
			handleParticleCollision = false;
			handleControllerColliderHit = false;
			handleJointBreak = false;
			handleJointBreak2D = false;
		}

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0x9DA6C8", Offset = "0x9DA6C8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAC8D8]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, info, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A45]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, info, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = HutongGames.PlayMaker.Fsm;\nL_0025:\n\tv59 = v57.lastRaycastHit2DInfoLUT == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0041;\n\tv65 = new System.Collections.Generic.Dictionary`2<HutongGames.PlayMaker.Fsm, UnityEngine.RaycastHit2D>();\n\tSystem.Collections.Generic.Dictionary`2<HutongGames.PlayMaker.Fsm, UnityEngine.RaycastHit2D>::.ctor(v65);\n\tgoto L_003D;\n\tv114 = *([v97 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_003D;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v97, v67, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv117 = HutongGames.PlayMaker.Fsm;\nL_003D:\n\tv73.lastRaycastHit2DInfoLUT = v65;\nL_0041:\n\tgoto L_004E;\n\tv81 = *([v68 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tgoto L_004E;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v68, v66, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv85 = HutongGames.PlayMaker.Fsm;\nL_004E:\n\tv94 = info.m_Centroid;\n\tSystem.Collections.Generic.Dictionary`2<HutongGames.PlayMaker.Fsm, UnityEngine.RaycastHit2D>::set_Item(v88.lastRaycastHit2DInfoLUT, fsm, &v94 @ V0_v2 (UnityEngine.Vector2));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void RecordLastRaycastHit2DInfo(Fsm fsm, RaycastHit2D info)
		{
			//IL_002b: Expected O, but got Ref
			if (lastRaycastHit2DInfoLUT == null)
			{
				Dictionary<Fsm, RaycastHit2D> dictionary = new Dictionary<Fsm, RaycastHit2D>();
				lastRaycastHit2DInfoLUT = dictionary;
			}
			Vector2 centroid = info.m_Centroid;
			lastRaycastHit2DInfoLUT.set_Item(fsm, (RaycastHit2D)(&centroid));
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0x9DA7FC", Offset = "0x9DA7FC", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB9E60]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021A46]) = v42;\n\tgoto L_0022;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0022;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = HutongGames.PlayMaker.Fsm;\nL_0022:\n\tv56 = *([returnVal1 @ X0_v3 (UnityEngine.RaycastHit2D)+B8]);\n\tv58 = *([v56 @ X8_v4+70]) == 0;\n\tif (v58) goto L_0043;\n\tgoto L_0040;\n\tv69 = *([returnVal1 @ X0_v3 (UnityEngine.RaycastHit2D)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0040;\n\tv105 = HutongGames.PlayMaker.Fsm;\n\tv75 = *([v105 @ X8_v11 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv79 = v75.lastRaycastHit2DInfoLUT;\nL_0040:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<HutongGames.PlayMaker.Fsm, UnityEngine.RaycastHit2D>::get_Item(*([v56 @ X8_v4+70]), fsm);\n\treturn returnVal2;\nL_0043:\n\treturnBuffer.m_Collider = 0;\n\treturnBuffer.m_Centroid = 0;\n\treturnBuffer.m_Normal = 0;\n\treturn returnVal1;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static RaycastHit2D GetLastRaycastHit2DInfo(Fsm fsm)
		{
			//IL_008c: Expected O, but got I
			//IL_0031: Expected native int or pointer, but got O
			//IL_0048: Expected native int or pointer, but got O
			//IL_005f: Expected native int or pointer, but got O
			//IL_001f: Expected O, but got I
			RaycastHit2D typeFromHandle = (RaycastHit2D)typeof(Fsm);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ X0_v3 (UnityEngine.RaycastHit2D)+B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v4+70]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v4+70]");
				return ((Dictionary<Fsm, RaycastHit2D>)0).get_Item(fsm);
			}
			RaycastHit2D raycastHit2D = default(RaycastHit2D);
			((RaycastHit2D*)(IntPtr)raycastHit2D)->m_Collider = 0;
			((RaycastHit2D*)(IntPtr)raycastHit2D)->m_Centroid = default(Vector2);
			((RaycastHit2D*)(IntPtr)raycastHit2D)->m_Normal = default(Vector2);
			return typeFromHandle;
		}

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0x9DA960", Offset = "0x9DA960", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EF58F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A47]) = v35;\nL_0014:\n\tv39 = new HutongGames.PlayMaker.Fsm();\n\tHutongGames.PlayMaker.Fsm::.ctor(v39);\n\tv39.dataVersion = 2;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Fsm NewTempFsm()
		{
			Fsm fsm = new Fsm();
			fsm.DataVersion = 2;
			return fsm;
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0x9DA9CC", Offset = "0x9DA9CC", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1ECB768]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A48]) = v44;\nL_001B:\n\tthis.name = \"FSM\";\n\t// 31 NewArr v53 @ X0_v3 (HutongGames.PlayMaker.FsmState[]), typeof(HutongGames.PlayMaker.FsmState[]), 1\n\tthis.states = v53;\n\t// 37 NewArr v58 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 0\n\tthis.events = v58;\n\t// 43 NewArr v63 @ X0_v7 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.globalTransitions = v63;\n\tv67 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v67);\n\tthis.variables = v67;\n\tthis.description = \"\";\n\tthis.watermark = \"\";\n\tv76 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::.ctor(v76);\n\tthis.ExposedEvents = v76;\n\tthis.RestartOnEnable = 1;\n\tthis.EnableBreakpoints = 1;\n\tv84 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v84);\n\tthis.delayedEvents = v84;\n\tv90 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v90);\n\tthis.updateEvents = v90;\n\tv94 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v94);\n\tthis.removeEvents = v94;\n\tthis.editorFlags = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Fsm()
		{
			Name = "FSM";
			FsmState[] array = new FsmState[1];
			States = array;
			FsmEvent[] array2 = new FsmEvent[0];
			Events = array2;
			FsmTransition[] array3 = new FsmTransition[0];
			GlobalTransitions = array3;
			FsmVariables fsmVariables = new FsmVariables();
			Variables = fsmVariables;
			Description = "";
			Watermark = "";
			List<FsmEvent> exposedEvents = new List<FsmEvent>();
			ExposedEvents = exposedEvents;
			RestartOnEnable = true;
			EnableBreakpoints = true;
			List<DelayedEvent> list = new List<DelayedEvent>();
			delayedEvents = list;
			List<DelayedEvent> list2 = new List<DelayedEvent>();
			updateEvents = list2;
			List<DelayedEvent> list3 = new List<DelayedEvent>();
			removeEvents = list3;
			editorFlags = EditorFlags.nameIsExpanded;
		}

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0x9DAB40", Offset = "0x9DAB40", Length = "0x5A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv38 = *([1EE5C50]);\n\tv39 = *([v38 @ X8_v78]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, source, overrideVariables, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021A49]) = v56;\nL_0026:\n\tthis.name = \"FSM\";\n\t// 41 NewArr v68 @ X0_v3 (HutongGames.PlayMaker.FsmState[]), typeof(HutongGames.PlayMaker.FsmState[]), 1\n\tthis.states = v68;\n\t// 47 NewArr v73 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 0\n\tthis.events = v73;\n\t// 53 NewArr v78 @ X0_v7 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.globalTransitions = v78;\n\tv82 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v82);\n\tthis.variables = v82;\n\tthis.description = \"\";\n\tthis.watermark = \"\";\n\tv91 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::.ctor(v91);\n\tthis.ExposedEvents = v91;\n\tthis.RestartOnEnable = 1;\n\tthis.EnableBreakpoints = 1;\n\tv99 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v99);\n\tthis.delayedEvents = v99;\n\tv105 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v105);\n\tthis.updateEvents = v105;\n\tv109 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::.ctor(v109);\n\tthis.removeEvents = v109;\n\tthis.editorFlags = 1;\n\tSystem.Object::.ctor(this);\n\tthis.dataVersion = source.dataVersion;\n\tthis.owner = source.owner;\n\tthis.name = source.name;\n\tthis.description = source.description;\n\tthis.startState = source.startState;\n\tthis.docUrl = source.docUrl;\n\tthis.showStateLabel = source.showStateLabel;\n\tthis.maxLoopCount = source.maxLoopCount;\n\tthis.watermark = source.watermark;\n\tthis.RestartOnEnable = source.RestartOnEnable;\n\tthis.EnableDebugFlow = source.EnableDebugFlow;\n\tthis.EnableBreakpoints = source.EnableBreakpoints;\n\tv128 = source.states;\n\t// 138 NewArr v332 @ X0_v29 (HutongGames.PlayMaker.FsmState[]), typeof(HutongGames.PlayMaker.FsmState[]), v128.Length\n\tthis.states = v332;\n\tv461 = source.states;\nL_009C:\n\tv133 = v286 >= v461.Length;\n\tif (v133) goto L_00E7;\n\tv464 = v286 < v461.Length;\n\tv275 = ~v464;\n\tif (v275) goto L_01F2;\n\tHutongGames.PlayMaker.FsmState::set_Fsm(v461[v286 @ X25_v7 (System.Int32)], source);\n\tv367 = source.states;\n\tv617 = v286 < v367.Length;\n\tv276 = ~v617;\n\tif (v276) goto L_01F2;\n\tv299 = this.states;\n\tv334 = new HutongGames.PlayMaker.FsmState();\n\tHutongGames.PlayMaker.FsmState::.ctor(v334, v367[v286 @ X25_v7 (System.Int32)]);\n\tv686 = v334 == 0;\n\tif (v686) goto L_00D4;\n\t// 208 IsInst v695 @ X0_v82, typeof(HutongGames.PlayMaker.FsmState), v334 @ X0_v79 (HutongGames.PlayMaker.FsmState)\nL_00D4:\n\tv698 = v286 < v299.Length;\n\tv277 = ~v698;\n\tif (v277) goto L_01F2;\n\tv299[v286 @ X25_v7 (System.Int32)] = v334;\n\tv461 = source.states;\n\tv286 = v286 + 1;\n\tv704 = source.states == 0;\n\tv349 = ~v704;\n\tif (v349) goto L_009C;\n\tgoto L_01D1;\nL_00E7:\n\tv370 = source.events;\n\t// 236 NewArr v337 @ X0_v42 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), v370.Length\n\tthis.events = v337;\n\tv525 = source.events;\nL_00FE:\n\tv134 = v288 >= v525.Length;\n\tif (v134) goto L_0136;\n\tv681 = v288 < v525.Length;\n\tv279 = ~v681;\n\tif (v279) goto L_01F2;\n\tv381 = this.events;\n\tv338 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v338, v525[v288 @ X25_v14 (System.Int32)]);\n\tv699 = v338 == 0;\n\tif (v699) goto L_0120;\n\t// 284 IsInst v708 @ X0_v76, typeof(HutongGames.PlayMaker.FsmEvent), v338 @ X0_v73 (HutongGames.PlayMaker.FsmEvent)\nL_0120:\n\tv711 = v288 < v381.Length;\n\tv280 = ~v711;\n\tif (v280) goto L_01F2;\n\tv381[v288 @ X25_v14 (System.Int32)] = v338;\n\tv525 = source.events;\n\tv288 = v288 + 1;\n\tv731 = source.events == 0;\n\tv353 = ~v731;\n\tif (v353) goto L_00FE;\n\tgoto L_01D1;\nL_0136:\n\tv684 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::.ctor(v684);\n\tthis.ExposedEvents = v684;\n\tv691 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::GetEnumerator(source.ExposedEvents);\nL_014D:\n\tv724 = 0xEF9AB0(&v147 @ stack_-98_v9, Il2CppMethodInfo, v173, methodInfo, v42, v43, v44, v45, v147, v47, v48, v49, v50, v51, v52, v53);\n\tv732 = v724 & 1;\n\tv733 = v732 == 0;\n\tif (v733) goto L_0165;\n\tv735 = new HutongGames.PlayMaker.FsmEvent();\n\tHutongGames.PlayMaker.FsmEvent::.ctor(v735, v700);\n\tv657 = this.ExposedEvents == 0;\n\tif (v657) goto L_0168;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::Add(this.ExposedEvents, v735);\n\tgoto L_014D;\nL_0165:\n\tv740 = 0xEF9AAC(&v147 @ stack_-98_v9, Il2CppMethodInfo, v173, methodInfo, v42, v43, v44, v45, v147, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0182;\nL_0168:\n\tv655 = new System.NullReferenceException();\n\tgoto L_0175;\n\tgoto L_0175;\n\tgoto L_0175;\nL_0175:\n\tv619 = v700 != 1;\n\tif (v619) goto L_01F8;\n\tv750 = 0x6D2BC0(v655, v700, 0, methodInfo, v42, v43, v44, v45, v147, v47, v48, v49, v50, v51, v52, v53);\n\tv762 = 0x6D2490(v750, v700, 0, methodInfo, v42, v43, v44, v45, v147, v47, v48, v49, v50, v51, v52, v53);\n\tv678 = 0xEF9AAC(&v147 @ stack_-98_v9, Il2CppMethodInfo, 0, methodInfo, v42, v43, v44, v45, v147, v47, v48, v49, v50, v51, v52, v53);\n\tv766 = *([v750 @ X0_v67]) == 0;\n\tv679 = ~v766;\n\tif (v679) goto L_01FA;\nL_0182:\n\tv374 = source.globalTransitions;\n\t// 393 NewArr v341 @ X0_v53 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), v374.Length\n\tthis.globalTransitions = v341;\nL_019B:\n\tv131 = v291 >= v311.Length;\n\tif (v131) goto L_01D6;\n\tv375 = source.globalTransitions;\n\tv765 = v291 < v375.Length;\n\tv507 = ~v765;\n\tif (v507) goto L_01F2;\n\tv769 = new HutongGames.PlayMaker.FsmTransition();\n\tHutongGames.PlayMaker.FsmTransition::.ctor(v769, v375[v291 @ X25_v18 (System.Int32)]);\n\tv771 = v769 == 0;\n\tif (v771) goto L_01BE;\n\t// 442 IsInst v727 @ X0_v59, typeof(HutongGames.PlayMaker.FsmTransition), v769 @ X0_v56 (HutongGames.PlayMaker.FsmTransition)\nL_01BE:\n\tv774 = v291 < v311.Length;\n\tv273 = ~v774;\n\tif (v273) goto L_01F2;\n\tv311[v291 @ X25_v18 (System.Int32)] = v769;\n\tv311 = this.globalTransitions;\n\tv291 = v291 + 1;\n\tv775 = this.globalTransitions == 0;\n\tv345 = ~v775;\n\tif (v345) goto L_019B;\nL_01D1:\n\tthrow System.NullReferenceException;\nL_01D6:\n\tv343 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v343, source.variables);\n\tthis.variables = v343;\n\tv463 = overrideVariables == 0;\n\tif (v463) goto L_01F1;\n\tHutongGames.PlayMaker.FsmVariables::OverrideVariableValues(v343, overrideVariables);\nL_01F1:\n\treturn;\nL_01F2:\n\tv529 = new System.IndexOutOfRangeException();\n\tgoto L_01F7;\n\tv598 = new System.ArrayTypeMismatchException();\nL_01F7:\n\tv614 = new System.TypeLoadException();\nL_01F8:\n\tv662 = 0x6D2380(v614, v651, v627, methodInfo, v42, v43, v44, v45, v622, v47, v48, v49, v50, v51, v52, v53);\nL_01FA:\n\tgoto L_01F7;\n\treturn;\n// 341 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Fsm(Fsm source, FsmVariables overrideVariables = null)
		{
			//IL_04bd: Expected I4, but got O
			base._002Ector();
			Name = "FSM";
			FsmState[] array = new FsmState[1];
			States = array;
			FsmEvent[] array2 = new FsmEvent[0];
			Events = array2;
			FsmTransition[] array3 = new FsmTransition[0];
			GlobalTransitions = array3;
			FsmVariables fsmVariables = new FsmVariables();
			Variables = fsmVariables;
			Description = "";
			Watermark = "";
			List<FsmEvent> exposedEvents = new List<FsmEvent>();
			ExposedEvents = exposedEvents;
			RestartOnEnable = true;
			EnableBreakpoints = true;
			List<DelayedEvent> list = new List<DelayedEvent>();
			delayedEvents = list;
			List<DelayedEvent> list2 = new List<DelayedEvent>();
			updateEvents = list2;
			List<DelayedEvent> list3 = new List<DelayedEvent>();
			removeEvents = list3;
			editorFlags = EditorFlags.nameIsExpanded;
			DataVersion = source.DataVersion;
			Owner = source.Owner;
			Name = source.Name;
			Description = source.Description;
			StartState = source.StartState;
			DocUrl = source.DocUrl;
			showStateLabel = source.ShowStateLabel;
			maxLoopCount = source.MaxLoopCountOverride;
			Watermark = source.Watermark;
			RestartOnEnable = source.RestartOnEnable;
			EnableDebugFlow = source.EnableDebugFlow;
			EnableBreakpoints = source.EnableBreakpoints;
			FsmState[] array4 = source.States;
			FsmState[] array5 = new FsmState[array4.Length];
			States = array5;
			FsmState[] array6 = source.States;
			FsmVariables fsmVariables2 = overrideVariables;
			int num = 0;
			object obj3 = default(object);
			FsmEvent fsmEvent2 = default(FsmEvent);
			object obj5 = default(object);
			object obj6 = default(object);
			object obj8 = default(object);
			while (true)
			{
				if (num < array6.Length)
				{
					if (num < array6.Length)
					{
						array6[num].Fsm = source;
						FsmState[] array7 = source.States;
						if (num < array7.Length)
						{
							FsmState[] array8 = States;
							FsmState fsmState = new FsmState(array7[num]);
							if (fsmState != null)
							{
								object obj = fsmState as FsmState;
							}
							if (num < array8.Length)
							{
								array8[num] = fsmState;
								array6 = source.States;
								num++;
								bool flag = source.States == null;
								bool flag2 = !flag;
								fsmVariables2 = null;
								if (!flag2)
								{
									break;
								}
								continue;
							}
						}
					}
					goto IL_076b;
				}
				FsmEvent[] array9 = source.Events;
				FsmEvent[] array10 = new FsmEvent[array9.Length];
				Events = array10;
				FsmEvent[] array11 = source.Events;
				int num2 = 0;
				while (num2 < array11.Length)
				{
					if (num2 < array11.Length)
					{
						FsmEvent[] array12 = Events;
						FsmEvent fsmEvent = new FsmEvent(array11[num2]);
						if (fsmEvent != null)
						{
							object obj2 = fsmEvent as FsmEvent;
						}
						if (num2 < array12.Length)
						{
							array12[num2] = fsmEvent;
							array11 = source.Events;
							num2++;
							bool flag3 = source.Events == null;
							bool flag4 = !flag3;
							fsmVariables2 = null;
							if (!flag4)
							{
								goto end_IL_0805;
							}
							continue;
						}
					}
					goto IL_076b;
				}
				List<FsmEvent> exposedEvents2 = new List<FsmEvent>();
				ExposedEvents = exposedEvents2;
				List<FsmEvent>.Enumerator enumerator = source.ExposedEvents.GetEnumerator();
				int num3 = (int)fsmVariables2;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj3 & 1L) == 0)
					{
						break;
					}
					FsmEvent item = new FsmEvent(fsmEvent2);
					if (ExposedEvents != null)
					{
						ExposedEvents.Add(item);
						num3 = 0;
						continue;
					}
					goto IL_051d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				goto IL_05c0;
				IL_0779:
				TypeLoadException ex = new TypeLoadException();
				object obj4 = obj5;
				int num4 = 0;
				FsmEvent fsmEvent3 = null;
				goto IL_079d;
				IL_076b:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				goto IL_0779;
				IL_05c0:
				FsmTransition[] array13 = source.GlobalTransitions;
				FsmTransition[] array14 = (GlobalTransitions = new FsmTransition[array13.Length]);
				int num5 = 0;
				FsmTransition[] array16 = array14;
				while (true)
				{
					if (num5 < array16.Length)
					{
						FsmTransition[] array17 = source.GlobalTransitions;
						bool flag5 = num5 < array17.Length;
						bool flag6 = !flag5;
						obj5 = obj6;
						if (flag6)
						{
							break;
						}
						FsmTransition fsmTransition = new FsmTransition(array17[num5]);
						if (fsmTransition != null)
						{
							object obj7 = fsmTransition as FsmTransition;
						}
						bool flag7 = num5 < array16.Length;
						bool flag8 = !flag7;
						obj5 = obj6;
						if (flag8)
						{
							break;
						}
						array16[num5] = fsmTransition;
						array16 = GlobalTransitions;
						num5++;
						if (GlobalTransitions == null)
						{
							goto end_IL_0805;
						}
						continue;
					}
					FsmVariables fsmVariables3 = (Variables = new FsmVariables(source.Variables));
					if (overrideVariables != null)
					{
						fsmVariables3.OverrideVariableValues(overrideVariables);
					}
					return;
				}
				goto IL_076b;
				IL_051d:
				NullReferenceException ex3 = new NullReferenceException();
				bool flag9 = (IntPtr)fsmEvent2 != (IntPtr)1;
				obj4 = obj6;
				num4 = 0;
				fsmEvent3 = fsmEvent2;
				ex = (TypeLoadException)(object)ex3;
				if (!flag9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
					bool flag10 = obj8 == null;
					bool flag11 = !flag10;
					num3 = 0;
					if (!flag11)
					{
						goto IL_05c0;
					}
					goto IL_0779;
				}
				goto IL_079d;
				IL_079d:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				goto IL_0779;
				continue;
				end_IL_0805:
				break;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60003E1")]
		[Address(RVA = "0x9DB0E0", Offset = "0x9DB0E0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC5610]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, templateControl, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A4A]) = v41;\nL_0019:\n\tv45 = HutongGames.PlayMaker.FsmTemplateControl::InstantiateFsm(templateControl);\n\tv45.host = this;\n\tHutongGames.PlayMaker.Fsm::Init(v45, this.owner);\n\tv52 = HutongGames.PlayMaker.Fsm::get_SubFsmList(this);\n\ttemplateControl.<ID>k__BackingField = v52._size;\n\tv53 = HutongGames.PlayMaker.Fsm::get_SubFsmList(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::Add(v53, v45);\n\treturn v45;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Fsm CreateSubFsm(FsmTemplateControl templateControl)
		{
			Fsm fsm = templateControl.InstantiateFsm();
			fsm.host = this;
			fsm.Init(Owner);
			List<Fsm> list = SubFsmList;
			templateControl.ID = list.Count;
			List<Fsm> list2 = SubFsmList;
			list2.Add(fsm);
			return fsm;
		}

		[Token(Token = "0x60003E2")]
		[Address(RVA = "0x9D885C", Offset = "0x9D885C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_0004:\n\tv7 = v7.host;\n\tv10 = v7.host == 0;\n\tv6 = ~v10;\n\tif (v6) goto L_0004;\n\treturn v7.host;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Fsm GetRootFsm()
		{
			Fsm fsm = this;
			do
			{
				fsm = fsm.Host;
			}
			while (fsm.Host != null);
			return fsm.Host;
		}

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0x9DB1CC", Offset = "0x9DB1CC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EB3AE0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A4B]) = v40;\nL_0015:\n\tv42 = ~this.setDirty;\n\tif (v42) goto L_0042;\n\tv44 = this.owner == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_001F;\n\tv58 = this.usedInTemplate == 0;\n\tif (v58) goto L_0042;\nL_001F:\n\tv72 = HutongGames.PlayMaker.Fsm::get_UpdateHelperSetDirty(this);\n\t// 38 NewArr v94 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\t// 45 IsInst v99 @ X0_v16, typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Fsm)\n\tv101 = v99 == 0;\n\tif (v101) goto L_0044;\n\tv94[0] = this;\n\tv55 = System.Reflection.MethodBase::Invoke(v72, 0, v94);\n\tthis.setDirty = 0;\nL_0042:\n\treturn;\n\tv100 = new System.NullReferenceException();\nL_0044:\n\tv106 = new System.ArrayTypeMismatchException();\n\tgoto L_0049;\n\tv108 = new System.IndexOutOfRangeException();\nL_0049:\n\tthrow v110;\n\tthrow System.NullReferenceException;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CheckIfDirty()
		{
			if (setDirty && ((object)Owner != null || (object)UsedInTemplate != null))
			{
				MethodInfo methodInfo = UpdateHelperSetDirty;
				object[] array = new object[1];
				object obj = this as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
					throw ex2;
				}
				array[0] = this;
				object obj2 = methodInfo.Invoke(null, array);
				setDirty = false;
			}
		}

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0x9DB2B8", Offset = "0x9DB2B8", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EC5A68]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, component, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A4C]) = v43;\nL_0016:\n\tthis.owner = component;\n\tthis.dataVersion = 2;\n\tthis.name = \"FSM\";\n\tthis.description = \"\";\n\tthis.docUrl = \"\";\n\t// 38 NewArr v55 @ X0_v3 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.globalTransitions = v55;\n\t// 44 NewArr v60 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 0\n\tthis.events = v60;\n\tv64 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v64);\n\tthis.variables = v64;\n\t// 58 NewArr v71 @ X0_v9 (HutongGames.PlayMaker.FsmState[]), typeof(HutongGames.PlayMaker.FsmState[]), 1\n\tthis.states = v71;\n\tv76 = new HutongGames.PlayMaker.FsmState();\n\tHutongGames.PlayMaker.FsmState::.ctor(v76, this);\n\tHutongGames.PlayMaker.FsmState::set_Fsm(v76, this);\n\tv76.name = \"State 1\";\n\tv92 = 0;\n\tv124 = 0x10CCF64(&v92 @ stack_-40_v4, 0, 0, v28, v29, v30, v31, v32, 50f, 100f, 100f, 16f, v37, v38, v39, v40);\n\t// 96 MakeStruct v86 @ AGG9DB40C_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v144 @ stack_-3C, 0, v145 @ stack_-34\n\tHutongGames.PlayMaker.FsmState::set_Position(v76, v86);\n\t// 103 IsInst v138 @ X0_v24, typeof(HutongGames.PlayMaker.FsmState), v76 @ X0_v11 (HutongGames.PlayMaker.FsmState)\n\tv140 = v138 == 0;\n\tif (v140) goto L_007C;\n\tv71[0] = v76;\n\tthis.EnableDebugFlow = 0x100;\n\tthis.startState = \"State 1\";\n\treturn;\n\tv115 = new System.NullReferenceException();\nL_007C:\n\tv143 = new System.ArrayTypeMismatchException();\n\tgoto L_0081;\n\tv158 = new System.IndexOutOfRangeException();\nL_0081:\n\tthrow v157;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset(MonoBehaviour component)
		{
			//IL_005d: Expected O, but got I4
			//IL_0087: Expected F4, but got O
			//IL_00a2: Expected F4, but got O
			Owner = component;
			DataVersion = 2;
			Name = "FSM";
			Description = "";
			DocUrl = "";
			FsmTransition[] array = new FsmTransition[0];
			GlobalTransitions = array;
			FsmEvent[] array2 = new FsmEvent[0];
			Events = array2;
			FsmVariables fsmVariables = new FsmVariables();
			Variables = fsmVariables;
			FsmState[] array3 = (States = new FsmState[1]);
			FsmState fsmState = new FsmState(this);
			fsmState.Fsm = this;
			fsmState.Name = "State 1";
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position = default(Rect);
			position.x = 0f;
			object obj2 = default(object);
			position.y = (float)obj2;
			position.width = 0f;
			object obj3 = default(object);
			position.height = (float)obj3;
			fsmState.Position = position;
			object obj4 = fsmState as FsmState;
			if (obj4 != null)
			{
				array3[0] = fsmState;
				EnableDebugFlow = false;
				EnableBreakpoints = true;
				StartState = "State 1";
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
			throw ex2;
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0x9DB478", Offset = "0x9DB478", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.dataVersion = 2;\n\tHutongGames.PlayMaker.Fsm::SaveActions(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateDataVersion()
		{
			DataVersion = 2;
			SaveActions();
		}

		[Token(Token = "0x60003E6")]
		[Address(RVA = "0x9DB484", Offset = "0x9DB484", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.states;\n\tv131 = v10.Length;\n\tv24 = v10.Length < 1;\n\tif (v24) goto L_003B;\nL_0017:\n\tv133 = v37 < v131;\n\tv63 = ~v133;\n\tif (v63) goto L_003C;\n\tHutongGames.PlayMaker.FsmState::SaveActions(v10[v37 @ X20_v5 (System.Int32)]);\n\tv131 = v10.Length;\n\tv37 = v37 + 1;\n\tv95 = v37 < v10.Length;\n\tif (v95) goto L_0017;\nL_003B:\n\treturn;\nL_003C:\n\tv154 = new System.IndexOutOfRangeException();\n\tthrow v154;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveActions()
		{
			FsmState[] array = States;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				array[num2].SaveActions();
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003E7")]
		[Address(RVA = "0x9DB4FC", Offset = "0x9DB4FC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE3AD0]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, component, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A4D]) = v43;\nL_0016:\n\tthis.owner = component;\n\tthis.dataVersion = 2;\n\tthis.description = \"\";\n\tthis.docUrl = \"\";\n\t// 34 NewArr v52 @ X0_v3 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.globalTransitions = v52;\n\t// 40 NewArr v57 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 0\n\tthis.events = v57;\n\tv61 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v61);\n\tthis.variables = v61;\n\t// 54 NewArr v68 @ X0_v9 (HutongGames.PlayMaker.FsmState[]), typeof(HutongGames.PlayMaker.FsmState[]), 1\n\tthis.states = v68;\n\tv73 = new HutongGames.PlayMaker.FsmState();\n\tHutongGames.PlayMaker.FsmState::.ctor(v73, this);\n\tHutongGames.PlayMaker.FsmState::set_Fsm(v73, this);\n\tv73.name = \"State 1\";\n\tv89 = 0;\n\tv121 = 0x10CCF64(&v89 @ stack_-40_v4, 0, 0, v28, v29, v30, v31, v32, 50f, 100f, 100f, 16f, v37, v38, v39, v40);\n\t// 92 MakeStruct v83 @ AGG9DB640_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v141 @ stack_-3C, 0, v142 @ stack_-34\n\tHutongGames.PlayMaker.FsmState::set_Position(v73, v83);\n\t// 99 IsInst v135 @ X0_v24, typeof(HutongGames.PlayMaker.FsmState), v73 @ X0_v11 (HutongGames.PlayMaker.FsmState)\n\tv137 = v135 == 0;\n\tif (v137) goto L_0076;\n\tv68[0] = v73;\n\tthis.startState = \"State 1\";\n\treturn;\n\tv112 = new System.NullReferenceException();\nL_0076:\n\tv140 = new System.ArrayTypeMismatchException();\n\tgoto L_007B;\n\tv155 = new System.IndexOutOfRangeException();\nL_007B:\n\tthrow v154;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear(MonoBehaviour component)
		{
			//IL_005d: Expected O, but got I4
			//IL_0087: Expected F4, but got O
			//IL_00a2: Expected F4, but got O
			Owner = component;
			DataVersion = 2;
			Description = "";
			DocUrl = "";
			FsmTransition[] array = new FsmTransition[0];
			GlobalTransitions = array;
			FsmEvent[] array2 = new FsmEvent[0];
			Events = array2;
			FsmVariables fsmVariables = new FsmVariables();
			Variables = fsmVariables;
			FsmState[] array3 = (States = new FsmState[1]);
			FsmState fsmState = new FsmState(this);
			fsmState.Fsm = this;
			fsmState.Name = "State 1";
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position = default(Rect);
			position.x = 0f;
			object obj2 = default(object);
			position.y = (float)obj2;
			position.width = 0f;
			object obj3 = default(object);
			position.height = (float)obj3;
			fsmState.Position = position;
			object obj4 = fsmState as FsmState;
			if (obj4 != null)
			{
				array3[0] = fsmState;
				StartState = "State 1";
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
			throw ex2;
		}

		[Token(Token = "0x60003E8")]
		[Address(RVA = "0x9DB6A4", Offset = "0x9DB6A4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.Fsm::DeduceDataVersion(this);\n\tthis.dataVersion = v12;\n\tgoto L_0019;\n\tv19 = *([1EB5CF0]);\n\tv20 = *([v19 @ X8_v11]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv37 = 0 | 1;\n\t*([2021A8E]) = v37;\nL_0019:\n\tv44 = ~v42.<IsBuilding>k__BackingField;\n\tv45 = ~v44;\n\tif (v45) goto L_0023;\n\tthis.setDirty = 1;\nL_0023:\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixDataVersion()
		{
			int num = DeduceDataVersion();
			DataVersion = num;
			if (!PlayMakerGlobals.IsBuilding)
			{
				setDirty = true;
			}
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0x9DB70C", Offset = "0x9DB70C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.states;\n\tv181 = v14.Length;\n\tv27 = v14.Length < 1;\n\tif (v27) goto L_003E;\nL_0019:\n\tv183 = v47 < v181;\n\tv100 = ~v183;\n\tif (v100) goto L_0085;\n\tv106 = v14[v47 @ X21_v9 (System.Int32)];\n\tv122 = HutongGames.PlayMaker.ActionData::UsesDataVersion2(v106.actionData);\n\tv294 = v122 == 0;\n\tv135 = ~v294;\n\tif (v135) goto L_FFFFFFFF;\n\tv181 = v14.Length;\n\tv47 = v47 + 1;\n\tv124 = v47 < v14.Length;\n\tif (v124) goto L_0019;\nL_003E:\n\tv119 = this.states;\n\tv199 = v119.Length;\n\tv195 = v119.Length < 1;\n\tif (v195) goto L_FFFFFFFF;\nL_004F:\n\tv278 = v116 < v199;\n\tv102 = ~v278;\n\tif (v102) goto L_0085;\n\tv108 = v119[v116 @ X20_v9 (System.Int32)];\n\tv204 = HutongGames.PlayMaker.ActionData::get_ActionCount(v108.actionData);\n\tv281 = v204 >= 1;\n\tif (v281) goto L_FFFFFFFF;\n\tv199 = v119.Length;\n\tv116 = v116 + 1;\n\tv208 = v116 < v119.Length;\n\tif (v208) goto L_004F;\n\tgoto L_0084;\nL_0084:\n\treturn returnVal2;\nL_0085:\n\tv201 = new System.IndexOutOfRangeException();\n\tthrow v201;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int DeduceDataVersion()
		{
			FsmState[] array = States;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00cc;
			}
			int num2 = 0;
			while (num2 < num)
			{
				FsmState fsmState = array[num2];
				if (!fsmState.ActionData.UsesDataVersion2())
				{
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00cc;
				}
				goto IL_0190;
			}
			goto IL_01ac;
			IL_01ac:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_00cc:
			FsmState[] array2 = States;
			int num3 = array2.Length;
			if (array2.Length < 1)
			{
				goto IL_0190;
			}
			int num4 = 0;
			while (num4 < num3)
			{
				FsmState fsmState2 = array2[num4];
				int actionCount = fsmState2.ActionData.ActionCount;
				if (actionCount < 1)
				{
					num3 = array2.Length;
					num4++;
					if (num4 < array2.Length)
					{
						continue;
					}
					goto IL_0190;
				}
				return 1;
			}
			goto IL_01ac;
			IL_0190:
			return 2;
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0x9DB7F0", Offset = "0x9DB7F0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::ResetEventHandlerFlags(this);\n\tthis.owner = component;\n\tgoto L_001A;\n\tv19 = *([1EB5CF0]);\n\tv20 = *([v19 @ X8_v9]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, component, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A8E]) = v38;\nL_001A:\n\tv44 = ~v42.<IsBuilding>k__BackingField;\n\tif (v44) goto L_001E;\n\tthis.initialized = 0;\nL_001E:\n\tHutongGames.PlayMaker.Fsm::InitData(this);\n\tHutongGames.PlayMaker.Fsm::Preprocess(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Preprocess(MonoBehaviour component)
		{
			ResetEventHandlerFlags();
			Owner = component;
			if (PlayMakerGlobals.IsBuilding)
			{
				initialized = false;
			}
			InitData();
			Preprocess();
		}

		[Token(Token = "0x60003EB")]
		[Address(RVA = "0x9DBCB0", Offset = "0x9DBCB0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = this.states;\n\tv222 = v22.Length;\n\tv35 = v22.Length < 1;\n\tif (v35) goto L_0077;\nL_001D:\n\tv224 = v76 < v222;\n\tv120 = ~v224;\n\tif (v120) goto L_0085;\n\tv182 = HutongGames.PlayMaker.FsmState::get_Actions(v22[v76 @ X24_v6 (System.Int32)]);\n\tv240 = v182.Length;\n\tv280 = v182.Length < 1;\n\tif (v280) goto L_0068;\nL_0040:\n\tv317 = v53 < v240;\n\tv121 = ~v317;\n\tif (v121) goto L_0085;\n\tv322 = HutongGames.PlayMaker.FsmStateAction::Init(v182[v53 @ X25_v9 (System.Int32)], v22[v76 @ X24_v6 (System.Int32)]);\n\tv286 = HutongGames.PlayMaker.FsmStateAction::OnPreprocess(v182[v53 @ X25_v9 (System.Int32)]);\n\tv240 = v182.Length;\n\tv53 = v53 + 1;\n\tv288 = v53 < v182.Length;\n\tif (v288) goto L_0040;\nL_0068:\n\tv222 = v22.Length;\n\tv76 = v76 + 1;\n\tv152 = v76 < v22.Length;\n\tif (v152) goto L_001D;\nL_0077:\n\tHutongGames.PlayMaker.Fsm::CheckFsmEventsForEventHandlers(this);\n\tthis.preprocessed = 1;\n\treturn;\nL_0085:\n\tv242 = new System.IndexOutOfRangeException();\n\tthrow v242;\n\tthrow System.NullReferenceException;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Preprocess()
		{
			FsmState[] array = States;
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						FsmStateAction[] actions = array[num2].Actions;
						int num3 = actions.Length;
						if (actions.Length < 1)
						{
							goto IL_0108;
						}
						int num4 = 0;
						while (num4 < num3)
						{
							actions[num4].Init(array[num2]);
							actions[num4].OnPreprocess();
							num3 = actions.Length;
							num4++;
							if (num4 < actions.Length)
							{
								continue;
							}
							goto IL_0108;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0108:
					num = array.Length;
					num2++;
				}
				while (num2 < array.Length);
			}
			CheckFsmEventsForEventHandlers();
			preprocessed = true;
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0x9DD718", Offset = "0x9DD718", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = this.states;\n\tv223 = v22.Length;\n\tv35 = v22.Length < 1;\n\tif (v35) goto L_0077;\nL_001D:\n\tv225 = v76 < v223;\n\tv120 = ~v225;\n\tif (v120) goto L_0091;\n\tv183 = HutongGames.PlayMaker.FsmState::get_Actions(v22[v76 @ X24_v7 (System.Int32)]);\n\tv250 = v183.Length;\n\tv290 = v183.Length < 1;\n\tif (v290) goto L_0068;\nL_0040:\n\tv327 = v53 < v250;\n\tv121 = ~v327;\n\tif (v121) goto L_0091;\n\tv332 = HutongGames.PlayMaker.FsmStateAction::Init(v183[v53 @ X25_v10 (System.Int32)], v22[v76 @ X24_v7 (System.Int32)]);\n\tv296 = HutongGames.PlayMaker.FsmStateAction::Awake(v183[v53 @ X25_v10 (System.Int32)]);\n\tv250 = v183.Length;\n\tv53 = v53 + 1;\n\tv298 = v53 < v183.Length;\n\tif (v298) goto L_0040;\nL_0068:\n\tv223 = v22.Length;\n\tv76 = v76 + 1;\n\tv152 = v76 < v22.Length;\n\tif (v152) goto L_001D;\nL_0077:\n\tv174 = ~this.preprocessed;\n\tif (v174) goto L_008F;\n\treturn;\nL_008F:\n\tHutongGames.PlayMaker.Fsm::CheckFsmEventsForEventHandlers(this);\n\treturn;\nL_0091:\n\tv252 = new System.IndexOutOfRangeException();\n\tthrow v252;\n\tthrow System.NullReferenceException;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			FsmState[] array = States;
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						FsmStateAction[] actions = array[num2].Actions;
						int num3 = actions.Length;
						if (actions.Length < 1)
						{
							goto IL_0108;
						}
						int num4 = 0;
						while (num4 < num3)
						{
							actions[num4].Init(array[num2]);
							actions[num4].Awake();
							num3 = actions.Length;
							num4++;
							if (num4 < actions.Length)
							{
								continue;
							}
							goto IL_0108;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0108:
					num = array.Length;
					num2++;
				}
				while (num2 < array.Length);
			}
			if (!Preprocessed)
			{
				CheckFsmEventsForEventHandlers();
			}
		}

		[Token(Token = "0x60003ED")]
		[Address(RVA = "0x9DB194", Offset = "0x9DB194", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.owner = component;\n\tHutongGames.PlayMaker.Fsm::InitData(this);\n\tv12 = ~this.preprocessed;\n\tv13 = ~v12;\n\tif (v13) goto L_0013;\n\tHutongGames.PlayMaker.Fsm::Preprocess(this);\nL_0013:\n\tHutongGames.PlayMaker.Fsm::Awake(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(MonoBehaviour component)
		{
			Owner = component;
			InitData();
			if (!Preprocessed)
			{
				Preprocess();
			}
			Awake();
		}

		[Token(Token = "0x60003EE")]
		[Address(RVA = "0x9DB864", Offset = "0x9DB864", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initialized = 0;\n\tHutongGames.PlayMaker.Fsm::InitData(this);\n\treturn;\n")]
		public void Reinitialize()
		{
			initialized = false;
			InitData();
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0x9DB86C", Offset = "0x9DB86C", Length = "0x444")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EAF6F0]);\n\tv33 = *([v32 @ X8_v60]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021A4E]) = v52;\nL_001B:\n\tv54 = this.dataVersion == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0021;\n\tHutongGames.PlayMaker.Fsm::FixDataVersion(this);\nL_0021:\n\tv59 = this.initialized + 3;\n\tv60 = ~v59;\n\tv62 = v60 & 3;\n\tv63 = v62 == 0;\n\tif (v63) goto L_0034;\n\treturn;\nL_0034:\n\tv314 = this.events;\n\tthis.initialized = 1;\nL_0046:\n\tv168 = v376 >= v314.Length;\n\tif (v168) goto L_0075;\n\tv270 = v376 << 3;\n\tv448 = v314 + v270;\n\tv296 = v448 + 0x20;\n\tgoto L_0059;\n\tv509 = *([v450 @ X0_v74+E0]);\n\tv510 = v509 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0059;\n\tv513 = \"il2cpp_codegen_runtime_class_init\"(v450, v258, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0059:\n\tv518 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(*([v296 @ X24_v13]));\n\tv539 = v518 == 0;\n\tif (v539) goto L_006E;\n\t// 96 IsInst v536 @ X0_v80, typeof(HutongGames.PlayMaker.FsmEvent), v518 @ X0_v77 (HutongGames.PlayMaker.FsmEvent)\n\tv537 = v536 == 0;\n\tif (v537) goto L_01E4;\nL_006E:\n\t*([v296 @ X24_v13]) = v518;\n\tv314 = this.events;\n\tv376 = v376 + 1;\n\tv553 = this.events == 0;\n\tv337 = ~v553;\n\tif (v337) goto L_0046;\n\tgoto L_01DF;\nL_0075:\n\tv528 = this.ExposedEvents;\nL_0085:\n\tv171 = v363 >= v528._size;\n\tif (v171) goto L_00CE;\n\tv540 = v528._size < v363;\n\tv249 = ~v540;\n\tv239 = v528._size - v363;\n\tv219 = v239 == 0;\n\tv541 = ~v219;\n\tv169 = v249 & v541;\n\tif (v169) goto L_0095;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0095:\n\tv549 = v528._items;\n\tv551 = v549[v363 @ X20_v9 (System.Int32)] == 0;\n\tif (v551) goto L_00C4;\n\tv304 = this.ExposedEvents;\n\tv577 = v304._size < v363;\n\tv565 = ~v577;\n\tv564 = v304._size - v363;\n\tv562 = v564 == 0;\n\tv578 = ~v562;\n\tv557 = v565 & v578;\n\tif (v557) goto L_00AE;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00AE:\n\tv593 = v304._items;\n\tgoto L_00BE;\n\tv619 = *([v594 @ X0_v66+E0]);\n\tv620 = v619 == 0;\n\tv621 = ~v620;\n\tif (v621) goto L_00BE;\n\tv623 = \"il2cpp_codegen_runtime_class_init\"(v594, v259, v149, v81, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00BE:\n\tv626 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(v593[v363 @ X20_v9 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::set_Item(v304, v363, v626);\nL_00C4:\n\tv528 = this.ExposedEvents;\n\tv363 = v363 + 1;\n\tv574 = this.ExposedEvents == 0;\n\tv340 = ~v574;\n\tif (v340) goto L_0085;\n\tgoto L_01DF;\nL_00CE:\n\tv328 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::.ctor(v328, this.events);\n\tv299 = this.states;\n\tv590 = v299.Length < 1;\n\tif (v590) goto L_015F;\nL_00F2:\n\tv307 = v299[v284 @ X25_v13 (System.Int32)];\n\tHutongGames.PlayMaker.FsmState::set_Fsm(v299[v284 @ X25_v13 (System.Int32)], this);\n\tHutongGames.PlayMaker.FsmState::LoadActions(v299[v284 @ X25_v13 (System.Int32)]);\n\tv290 = v307.transitions;\n\tv696 = v290.Length < 1;\n\tif (v696) goto L_0152;\nL_0119:\n\tv308 = v290[v281 @ X27_v11 (System.Int32)];\n\tv753 = System.String::IsNullOrEmpty(v308.toState);\n\tv765 = v753 == 0;\n\tv766 = ~v765;\n\tif (v766) goto L_0129;\n\tv773 = HutongGames.PlayMaker.Fsm::GetState(this, v308.toState);\n\tv308.toFsmState = v773;\nL_0129:\n\tv778 = HutongGames.PlayMaker.FsmTransition::get_EventName(v290[v281 @ X27_v11 (System.Int32)]);\n\tv787 = System.String::IsNullOrEmpty(v778);\n\tv790 = v787 == 0;\n\tv791 = ~v790;\n\tif (v791) goto L_0144;\n\tv795 = HutongGames.PlayMaker.FsmTransition::get_EventName(v290[v281 @ X27_v11 (System.Int32)]);\n\tgoto L_0141;\n\tv810 = *([v802 @ X8_v42+E0]);\n\tv811 = v810 == 0;\n\tv812 = ~v811;\n\tif (v812) goto L_0141;\n\tv816 = v802;\n\tv814 = \"il2cpp_codegen_runtime_class_init\"(v816, v794, v153, v81, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0141:\n\tv799 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(v795);\n\tv308.fsmEvent = v799;\nL_0144:\n\tv281 = v281 + 1;\n\tv703 = v281 < v290.Length;\n\tif (v703) goto L_0119;\nL_0152:\n\tv284 = v284 + 1;\n\tv600 = v284 < v299.Length;\n\tif (v600) goto L_00F2;\nL_015F:\n\tv300 = this.globalTransitions;\n\tv647 = v300.Length < 1;\n\tif (v647) goto L_01CD;\nL_017E:\n\tv310 = v300[v286 @ X25_v10 (System.Int32)];\n\tv684 = System.String::IsNullOrEmpty(v310.toState);\n\tv698 = v684 == 0;\n\tv699 = ~v698;\n\tif (v699) goto L_018E;\n\tv731 = HutongGames.PlayMaker.Fsm::GetState(this, v310.toState);\n\tv310.toFsmState = v731;\nL_018E:\n\tv736 = HutongGames.PlayMaker.FsmTransition::get_EventName(v300[v286 @ X25_v10 (System.Int32)]);\n\tv747 = System.String::IsNullOrEmpty(v736);\n\tv749 = v747 == 0;\n\tv750 = ~v749;\n\tif (v750) goto L_01BA;\n\tv756 = HutongGames.PlayMaker.FsmTransition::get_EventName(v300[v286 @ X25_v10 (System.Int32)]);\n\tgoto L_01A6;\n\tv779 = *([v358 @ X8_v32+E0]);\n\tv780 = v779 == 0;\n\tv781 = ~v780;\n\tif (v781) goto L_01A6;\n\tv788 = v358;\n\tv783 = \"il2cpp_codegen_runtime_class_init\"(v788, v755, v155, v81, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01A6:\n\tv403 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(v756);\n\tv310.fsmEvent = v403;\n\tv334 = HutongGames.PlayMaker.FsmEvent::EventListContainsEvent(v328, v403.name);\n\tv806 = v334 == 0;\n\tv760 = ~v806;\n\tif (v760) goto L_01BA;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::Add(v328, v403);\nL_01BA:\n\tv286 = v286 + 1;\n\tv652 = v286 < v300.Length;\n\tif (v652) goto L_017E;\nL_01CD:\n\tv681 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEvent>::ToArray(v328);\n\tthis.events = v681;\n\tHutongGames.PlayMaker.Fsm::CheckIfDirty(this);\n\treturn;\nL_01DF:\n\tv408 = new System.NullReferenceException();\n\tv447 = new System.IndexOutOfRangeException();\nL_01E3:\n\tv508 = new System.TypeLoadException();\nL_01E4:\n\tv499 = new System.ArrayTypeMismatchException();\n\tgoto L_01E3;\n\treturn;\n// 325 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InitData()
		{
			//IL_0020: Expected O, but got I4
			//IL_0029: Expected I4, but got O
			//IL_0099: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_031f: Expected I4, but got O
			if (DataVersion == 0)
			{
				FixDataVersion();
			}
			object obj = (Initialized ? 1 : 0) + 3;
			int num = (int)(~obj);
			if ((num & 3) != 0)
			{
				return;
			}
			FsmEvent[] array = Events;
			initialized = true;
			int num2 = 0;
			while (num2 < array.Length)
			{
				int num3 = num2 << 3;
				object obj2 = (long)(IntPtr)array + (long)num3;
				object fsmEvent = (long)(IntPtr)obj2 + 32L;
				FsmEvent fsmEvent2 = FsmEvent.GetFsmEvent((FsmEvent)fsmEvent);
				if (fsmEvent2 != null)
				{
					object obj3 = fsmEvent2 as FsmEvent;
					if (obj3 == null)
					{
						goto IL_0669;
					}
				}
				fsmEvent = fsmEvent2;
				array = Events;
				num2++;
				if (Events != null)
				{
					continue;
				}
				goto IL_07a8;
			}
			List<FsmEvent> exposedEvents = ExposedEvents;
			int num4 = 0;
			do
			{
				if (num4 < exposedEvents.Count)
				{
					bool flag = exposedEvents.Count < num4;
					bool flag2 = !flag;
					int num5 = exposedEvents.Count - num4;
					bool flag3 = num5 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					FsmEvent[] items = exposedEvents._items;
					if (items[num4] != null)
					{
						List<FsmEvent> exposedEvents2 = ExposedEvents;
						bool flag5 = exposedEvents2.Count < num4;
						bool flag6 = !flag5;
						int num6 = exposedEvents2.Count - num4;
						bool flag7 = num6 == 0;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							throw new ArgumentOutOfRangeException();
						}
						FsmEvent[] items2 = exposedEvents2._items;
						FsmEvent fsmEvent3 = FsmEvent.GetFsmEvent(items2[num4]);
						exposedEvents2.set_Item(num4, fsmEvent3);
					}
					exposedEvents = ExposedEvents;
					num4++;
					continue;
				}
				List<FsmEvent> list = new List<FsmEvent>((int)Events);
				FsmState[] array2 = States;
				if (array2.Length >= 1)
				{
					int num7 = 0;
					do
					{
						FsmState fsmState = array2[num7];
						array2[num7].Fsm = this;
						array2[num7].LoadActions();
						FsmTransition[] transitions = fsmState.Transitions;
						if (transitions.Length >= 1)
						{
							int num8 = 0;
							do
							{
								FsmTransition fsmTransition = transitions[num8];
								if (!string.IsNullOrEmpty(fsmTransition.ToState))
								{
									FsmState state = GetState(fsmTransition.ToState);
									fsmTransition.ToFsmState = state;
								}
								string eventName = transitions[num8].EventName;
								if (!string.IsNullOrEmpty(eventName))
								{
									string eventName2 = transitions[num8].EventName;
									FsmEvent fsmEvent4 = FsmEvent.GetFsmEvent(eventName2);
									fsmTransition.FsmEvent = fsmEvent4;
								}
								num8++;
							}
							while (num8 < transitions.Length);
						}
						num7++;
					}
					while (num7 < array2.Length);
				}
				FsmTransition[] array3 = GlobalTransitions;
				if (array3.Length >= 1)
				{
					int num9 = 0;
					do
					{
						FsmTransition fsmTransition2 = array3[num9];
						if (!string.IsNullOrEmpty(fsmTransition2.ToState))
						{
							FsmState state2 = GetState(fsmTransition2.ToState);
							fsmTransition2.ToFsmState = state2;
						}
						string eventName3 = array3[num9].EventName;
						if (!string.IsNullOrEmpty(eventName3))
						{
							string eventName4 = array3[num9].EventName;
							FsmEvent fsmEvent5 = (fsmTransition2.FsmEvent = FsmEvent.GetFsmEvent(eventName4));
							if (!FsmEvent.EventListContainsEvent(list, fsmEvent5.Name))
							{
								list.Add(fsmEvent5);
							}
						}
						num9++;
					}
					while (num9 < array3.Length);
				}
				FsmEvent[] array4 = list.ToArray();
				Events = array4;
				CheckIfDirty();
				return;
			}
			while (ExposedEvents != null);
			goto IL_07a8;
			IL_0669:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			goto IL_065b;
			IL_07a8:
			NullReferenceException ex2 = new NullReferenceException();
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			goto IL_065b;
			IL_065b:
			TypeLoadException ex4 = new TypeLoadException();
			goto IL_0669;
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0x9DBDBC", Offset = "0x9DBDBC", Length = "0x195C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_001B;\n\tv34 = *([1EF5C28]);\n\tv35 = *([v34 @ X8_v594]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021A4F]) = v54;\nL_001B:\n\t*([v24 @ X29_v1-60]) = 0;\n\t*([v24 @ X29_v1-58]) = 0;\n\t*([v24 @ X29_v1-68]) = 0;\n\tv55 = this.events;\n\tv68 = v55.Length < 1;\n\tif (v68) goto L_0987;\n\tv211 = *([1ED44D8]);\n\tv294 = *([1EDA308]);\n\t*([v24 @ X29_v1-6C]) = *([v294 @ X12_v11]);\n\tv298 = *([1EDF120]);\n\t*([v24 @ X29_v1-70]) = *([v298 @ X12_v14]);\n\tv301 = *([1EC0F68]);\n\t*([v24 @ X29_v1-74]) = *([v301 @ X12_v17]);\n\t*([v24 @ X29_v1-78]) = *([v211 @ X13_v9]);\nL_00C2:\n\tv169 = v55[v154 @ X26_v10 (System.Int32)];\n\tv721 = ~v169.isSystemEvent;\n\tif (v721) goto L_0979;\n\tgoto L_00D5;\n\tv1295 = *([v742 @ X0_v34+E0]);\n\tv1296 = v1295 == 0;\n\tv1297 = ~v1296;\n\tif (v1297) goto L_00D5;\n\tv1299 = \"il2cpp_codegen_runtime_class_init\"(v742, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00D5:\n\tgoto L_00DD;\n\tv1308 = v252;\n\tv1309 = \"il2cpp_codegen_initialize_method\"(v1308, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A90]) = v175;\nL_00DD:\n\tgoto L_00EA;\n\tv1322 = *([v1311 @ X0_v37 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1323 = v1322 == 0;\n\tv1324 = ~v1323;\n\tgoto L_00EA;\n\tv1338 = \"il2cpp_codegen_runtime_class_init\"(v1311, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1325 = HutongGames.PlayMaker.FsmEvent;\nL_00EA:\n\tv986 = v55[v154 @ X26_v10 (System.Int32)] == v1328.<TriggerEnter>k__BackingField;\n\tif (v986) goto L_0370;\n\tgoto L_00FC;\n\tv1427 = *([v1117 @ X0_v38 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1428 = v1427 == 0;\n\tv1429 = ~v1428;\n\tif (v1429) goto L_00FC;\n\tv1431 = \"il2cpp_codegen_runtime_class_init\"(v1117, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00FC:\n\tgoto L_0104;\n\tv1444 = *([v24 @ X29_v1-6C]);\n\tv1445 = \"il2cpp_codegen_initialize_method\"(v1444, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A91]) = v175;\nL_0104:\n\tgoto L_0111;\n\tv1460 = *([v1447 @ X0_v41 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1461 = v1460 == 0;\n\tv1462 = ~v1461;\n\tgoto L_0111;\n\tv1469 = \"il2cpp_codegen_runtime_class_init\"(v1447, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1463 = HutongGames.PlayMaker.FsmEvent;\nL_0111:\n\tv987 = v55[v154 @ X26_v10 (System.Int32)] == v1466.<TriggerExit>k__BackingField;\n\tif (v987) goto L_0387;\n\tgoto L_0123;\n\tv1476 = *([v1118 @ X0_v42 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1477 = v1476 == 0;\n\tv1478 = ~v1477;\n\tif (v1478) goto L_0123;\n\tv1480 = \"il2cpp_codegen_runtime_class_init\"(v1118, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0123:\n\tgoto L_012B;\n\tv1492 = *([v24 @ X29_v1-70]);\n\tv1493 = \"il2cpp_codegen_initialize_method\"(v1492, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A92]) = v175;\nL_012B:\n\tgoto L_0138;\n\tv1506 = *([v1495 @ X0_v45 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1507 = v1506 == 0;\n\tv1508 = ~v1507;\n\tgoto L_0138;\n\tv1515 = \"il2cpp_codegen_runtime_class_init\"(v1495, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1509 = HutongGames.PlayMaker.FsmEvent;\nL_0138:\n\tv988 = v55[v154 @ X26_v10 (System.Int32)] == v1512.<TriggerStay>k__BackingField;\n\tif (v988) goto L_039E;\n\tgoto L_014B;\n\tv1522 = *([v1119 @ X0_v46 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1523 = v1522 == 0;\n\tv1524 = ~v1523;\n\tif (v1524) goto L_014B;\n\tv1526 = \"il2cpp_codegen_runtime_class_init\"(v1119, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_014B:\n\tgoto L_0154;\n\tv1539 = *([v24 @ X29_v1-74]);\n\tv1540 = \"il2cpp_codegen_initialize_method\"(v1539, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A93]) = v175;\nL_0154:\n\tgoto L_0161;\n\tv1555 = *([v1544 @ X0_v49 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1556 = v1555 == 0;\n\tv1557 = ~v1556;\n\tgoto L_0161;\n\tv1564 = \"il2cpp_codegen_runtime_class_init\"(v1544, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1558 = HutongGames.PlayMaker.FsmEvent;\nL_0161:\n\tv989 = v55[v154 @ X26_v10 (System.Int32)] == v1561.<CollisionEnter>k__BackingField;\n\tif (v989) goto L_03B5;\n\tgoto L_0174;\n\tv1571 = *([v1120 @ X0_v50 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1572 = v1571 == 0;\n\tv1573 = ~v1572;\n\tif (v1573) goto L_0174;\n\tv1575 = \"il2cpp_codegen_runtime_class_init\"(v1120, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0174:\n\tgoto L_017D;\n\tv1588 = *([v24 @ X29_v1-78]);\n\tv1589 = \"il2cpp_codegen_initialize_method\"(v1588, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A94]) = v175;\nL_017D:\n\tgoto L_018A;\n\tv1604 = *([v1593 @ X0_v53 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1605 = v1604 == 0;\n\tv1606 = ~v1605;\n\tgoto L_018A;\n\tv1613 = \"il2cpp_codegen_runtime_class_init\"(v1593, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1607 = HutongGames.PlayMaker.FsmEvent;\nL_018A:\n\tv990 = v55[v154 @ X26_v10 (System.Int32)] == v1610.<CollisionExit>k__BackingField;\n\tif (v990) goto L_03CC;\n\tgoto L_019D;\n\tv1620 = *([v1121 @ X0_v54 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1621 = v1620 == 0;\n\tv1622 = ~v1621;\n\tif (v1622) goto L_019D;\n\tv1624 = \"il2cpp_codegen_runtime_class_init\"(v1121, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_019D:\n\tgoto L_01A6;\n\tv1637 = v136;\n\tv1638 = \"il2cpp_codegen_initialize_method\"(v1637, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A95]) = v175;\nL_01A6:\n\tgoto L_01B3;\n\tv1653 = *([v1642 @ X0_v57 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1654 = v1653 == 0;\n\tv1655 = ~v1654;\n\tgoto L_01B3;\n\tv1662 = \"il2cpp_codegen_runtime_class_init\"(v1642, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1656 = HutongGames.PlayMaker.FsmEvent;\nL_01B3:\n\tv991 = v55[v154 @ X26_v10 (System.Int32)] == v1659.<CollisionStay>k__BackingField;\n\tif (v991) goto L_03E3;\n\tgoto L_01C6;\n\tv1669 = *([v1122 @ X0_v58 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1670 = v1669 == 0;\n\tv1671 = ~v1670;\n\tif (v1671) goto L_01C6;\n\tv1673 = \"il2cpp_codegen_runtime_class_init\"(v1122, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_01C6:\n\tgoto L_01CF;\n\tv1686 = v130;\n\tv1687 = \"il2cpp_codegen_initialize_method\"(v1686, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A96]) = v175;\nL_01CF:\n\tgoto L_01DC;\n\tv1702 = *([v1691 @ X0_v61 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1703 = v1702 == 0;\n\tv1704 = ~v1703;\n\tgoto L_01DC;\n\tv1711 = \"il2cpp_codegen_runtime_class_init\"(v1691, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1705 = HutongGames.PlayMaker.FsmEvent;\nL_01DC:\n\tv992 = v55[v154 @ X26_v10 (System.Int32)] == v1708.<TriggerEnter2D>k__BackingField;\n\tif (v992) goto L_03FA;\n\tgoto L_01EF;\n\tv1718 = *([v1123 @ X0_v62 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1719 = v1718 == 0;\n\tv1720 = ~v1719;\n\tif (v1720) goto L_01EF;\n\tv1722 = \"il2cpp_codegen_runtime_class_init\"(v1123, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\nL_01EF:\n\tgoto L_01F8;\n\tv1735 = v121;\n\tv1736 = \"il2cpp_codegen_initialize_method\"(v1735, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A97]) = v175;\nL_01F8:\n\tgoto L_0205;\n\tv1751 = *([v1740 @ X0_v65 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv1752 = v1751 == 0;\n\tv1753 = ~v1752;\n\tgoto L_0205;\n\tv1760 = \"il2cpp_codegen_runtime_class_init\"(v1740, v194, v192, v190, v188, v186, v184, v182, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1754 = HutongGames.PlayMaker.FsmEvent;\nL_\n// ... truncated")]
		private unsafe void CheckFsmEventsForEventHandlers()
		{
			//IL_0041: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_0067: Expected O, but got I
			//IL_007c: Expected O, but got I
			//IL_39eb: Expected O, but got I
			//IL_20b8: Expected O, but got I
			//IL_20a4: Expected O, but got I
			//IL_20d4: Expected I, but got O
			//IL_2135: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			FsmEvent[] array = Events;
			bool flag = array.Length < 1;
			Fsm fsm = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1ED44D8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1EDA308]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1EDF120]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1EC0F68]");
				object obj6 = 0;
				int num = 0;
				Fsm fsm2 = this;
				Fsm fsm5 = default(Fsm);
				Fsm fsm63 = default(Fsm);
				bool flag23;
				do
				{
					FsmEvent fsmEvent = array[num];
					if (fsmEvent.IsSystemEvent)
					{
						if (array[num] == FsmEvent.TriggerEnter)
						{
							Fsm fsm3 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm4 = fsm2;
								fsm4 = fsm5;
								do
								{
									fsm4 = fsm4.Host;
								}
								while (fsm4.Host != null);
								fsm2.rootFsm = fsm4.Host;
								fsm3 = fsm4.Host;
							}
							Fsm fsm6 = fsm3.Host;
							fsm3.preprocessed = false;
							fsm3.handleTriggerEnter = true;
							if (fsm3.Host != null)
							{
								do
								{
									fsm6.preprocessed = false;
									fsm6.handleTriggerEnter = true;
									fsm6 = fsm6.Host;
								}
								while (fsm6.Host != null);
							}
						}
						else if (array[num] == FsmEvent.TriggerExit)
						{
							Fsm fsm7 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm8 = fsm2;
								fsm8 = fsm5;
								do
								{
									fsm8 = fsm8.Host;
								}
								while (fsm8.Host != null);
								fsm2.rootFsm = fsm8.Host;
								fsm7 = fsm8.Host;
							}
							Fsm fsm9 = fsm7.Host;
							fsm7.preprocessed = false;
							fsm7.handleTriggerExit = true;
							if (fsm7.Host != null)
							{
								do
								{
									fsm9.preprocessed = false;
									fsm9.handleTriggerExit = true;
									fsm9 = fsm9.Host;
								}
								while (fsm9.Host != null);
							}
						}
						else if (array[num] == FsmEvent.TriggerStay)
						{
							Fsm fsm10 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm11 = fsm2;
								fsm11 = fsm5;
								do
								{
									fsm11 = fsm11.Host;
								}
								while (fsm11.Host != null);
								fsm2.rootFsm = fsm11.Host;
								fsm10 = fsm11.Host;
							}
							Fsm fsm12 = fsm10.Host;
							fsm10.preprocessed = false;
							fsm10.handleTriggerStay = true;
							if (fsm10.Host != null)
							{
								do
								{
									fsm12.preprocessed = false;
									fsm12.handleTriggerStay = true;
									fsm12 = fsm12.Host;
								}
								while (fsm12.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionEnter)
						{
							Fsm fsm13 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm14 = fsm2;
								fsm14 = fsm5;
								do
								{
									fsm14 = fsm14.Host;
								}
								while (fsm14.Host != null);
								fsm2.rootFsm = fsm14.Host;
								fsm13 = fsm14.Host;
							}
							Fsm fsm15 = fsm13.Host;
							fsm13.preprocessed = false;
							fsm13.handleCollisionEnter = true;
							if (fsm13.Host != null)
							{
								do
								{
									fsm15.preprocessed = false;
									fsm15.handleCollisionEnter = true;
									fsm15 = fsm15.Host;
								}
								while (fsm15.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionExit)
						{
							Fsm fsm16 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm17 = fsm2;
								fsm17 = fsm5;
								do
								{
									fsm17 = fsm17.Host;
								}
								while (fsm17.Host != null);
								fsm2.rootFsm = fsm17.Host;
								fsm16 = fsm17.Host;
							}
							Fsm fsm18 = fsm16.Host;
							fsm16.preprocessed = false;
							fsm16.handleCollisionExit = true;
							if (fsm16.Host != null)
							{
								do
								{
									fsm18.preprocessed = false;
									fsm18.handleCollisionExit = true;
									fsm18 = fsm18.Host;
								}
								while (fsm18.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionStay)
						{
							Fsm fsm19 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm20 = fsm2;
								fsm20 = fsm5;
								do
								{
									fsm20 = fsm20.Host;
								}
								while (fsm20.Host != null);
								fsm2.rootFsm = fsm20.Host;
								fsm19 = fsm20.Host;
							}
							Fsm fsm21 = fsm19.Host;
							fsm19.preprocessed = false;
							fsm19.handleCollisionStay = true;
							if (fsm19.Host != null)
							{
								do
								{
									fsm21.preprocessed = false;
									fsm21.handleCollisionStay = true;
									fsm21 = fsm21.Host;
								}
								while (fsm21.Host != null);
							}
						}
						else if (array[num] == FsmEvent.TriggerEnter2D)
						{
							Fsm fsm22 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm23 = fsm2;
								fsm23 = fsm5;
								do
								{
									fsm23 = fsm23.Host;
								}
								while (fsm23.Host != null);
								fsm2.rootFsm = fsm23.Host;
								fsm22 = fsm23.Host;
							}
							Fsm fsm24 = fsm22.Host;
							fsm22.preprocessed = false;
							fsm22.handleTriggerEnter2D = true;
							if (fsm22.Host != null)
							{
								do
								{
									fsm24.preprocessed = false;
									fsm24.handleTriggerEnter2D = true;
									fsm24 = fsm24.Host;
								}
								while (fsm24.Host != null);
							}
						}
						else if (array[num] == FsmEvent.TriggerExit2D)
						{
							Fsm fsm25 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm26 = fsm2;
								fsm26 = fsm5;
								do
								{
									fsm26 = fsm26.Host;
								}
								while (fsm26.Host != null);
								fsm2.rootFsm = fsm26.Host;
								fsm25 = fsm26.Host;
							}
							Fsm fsm27 = fsm25.Host;
							fsm25.preprocessed = false;
							fsm25.handleTriggerExit2D = true;
							if (fsm25.Host != null)
							{
								do
								{
									fsm27.preprocessed = false;
									fsm27.handleTriggerExit2D = true;
									fsm27 = fsm27.Host;
								}
								while (fsm27.Host != null);
							}
						}
						else if (array[num] == FsmEvent.TriggerStay2D)
						{
							Fsm fsm28 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm29 = fsm2;
								fsm29 = fsm5;
								do
								{
									fsm29 = fsm29.Host;
								}
								while (fsm29.Host != null);
								fsm2.rootFsm = fsm29.Host;
								fsm28 = fsm29.Host;
							}
							Fsm fsm30 = fsm28.Host;
							fsm28.preprocessed = false;
							fsm28.handleTriggerStay2D = true;
							if (fsm28.Host != null)
							{
								do
								{
									fsm30.preprocessed = false;
									fsm30.handleTriggerStay2D = true;
									fsm30 = fsm30.Host;
								}
								while (fsm30.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionEnter2D)
						{
							Fsm fsm31 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm32 = fsm2;
								fsm32 = fsm5;
								do
								{
									fsm32 = fsm32.Host;
								}
								while (fsm32.Host != null);
								fsm2.rootFsm = fsm32.Host;
								fsm31 = fsm32.Host;
							}
							Fsm fsm33 = fsm31.Host;
							fsm31.preprocessed = false;
							fsm31.handleCollisionEnter2D = true;
							if (fsm31.Host != null)
							{
								do
								{
									fsm33.preprocessed = false;
									fsm33.handleCollisionEnter2D = true;
									fsm33 = fsm33.Host;
								}
								while (fsm33.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionExit2D)
						{
							Fsm fsm34 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm35 = fsm2;
								fsm35 = fsm5;
								do
								{
									fsm35 = fsm35.Host;
								}
								while (fsm35.Host != null);
								fsm2.rootFsm = fsm35.Host;
								fsm34 = fsm35.Host;
							}
							Fsm fsm36 = fsm34.Host;
							fsm34.preprocessed = false;
							fsm34.handleCollisionExit2D = true;
							if (fsm34.Host != null)
							{
								do
								{
									fsm36.preprocessed = false;
									fsm36.handleCollisionExit2D = true;
									fsm36 = fsm36.Host;
								}
								while (fsm36.Host != null);
							}
						}
						else if (array[num] == FsmEvent.CollisionStay2D)
						{
							Fsm fsm37 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm38 = fsm2;
								fsm38 = fsm5;
								do
								{
									fsm38 = fsm38.Host;
								}
								while (fsm38.Host != null);
								fsm2.rootFsm = fsm38.Host;
								fsm37 = fsm38.Host;
							}
							Fsm fsm39 = fsm37.Host;
							fsm37.preprocessed = false;
							fsm37.handleCollisionStay2D = true;
							if (fsm37.Host != null)
							{
								do
								{
									fsm39.preprocessed = false;
									fsm39.handleCollisionStay2D = true;
									fsm39 = fsm39.Host;
								}
								while (fsm39.Host != null);
							}
						}
						else if (array[num] == FsmEvent.ParticleCollision)
						{
							Fsm fsm40 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm41 = fsm2;
								fsm41 = fsm5;
								do
								{
									fsm41 = fsm41.Host;
								}
								while (fsm41.Host != null);
								fsm2.rootFsm = fsm41.Host;
								fsm40 = fsm41.Host;
							}
							Fsm fsm42 = fsm40.Host;
							fsm40.preprocessed = false;
							fsm40.handleParticleCollision = true;
							if (fsm40.Host != null)
							{
								do
								{
									fsm42.preprocessed = false;
									fsm42.handleParticleCollision = true;
									fsm42 = fsm42.Host;
								}
								while (fsm42.Host != null);
							}
						}
						else if (array[num] == FsmEvent.ControllerColliderHit)
						{
							Fsm fsm43 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm44 = fsm2;
								fsm44 = fsm5;
								do
								{
									fsm44 = fsm44.Host;
								}
								while (fsm44.Host != null);
								fsm2.rootFsm = fsm44.Host;
								fsm43 = fsm44.Host;
							}
							Fsm fsm45 = fsm43.Host;
							fsm43.preprocessed = false;
							fsm43.handleControllerColliderHit = true;
							if (fsm43.Host != null)
							{
								do
								{
									fsm45.preprocessed = false;
									fsm45.handleControllerColliderHit = true;
									fsm45 = fsm45.Host;
								}
								while (fsm45.Host != null);
							}
						}
						else if (array[num] == FsmEvent.JointBreak)
						{
							Fsm fsm46 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm47 = fsm2;
								fsm47 = fsm5;
								do
								{
									fsm47 = fsm47.Host;
								}
								while (fsm47.Host != null);
								fsm2.rootFsm = fsm47.Host;
								fsm46 = fsm47.Host;
							}
							Fsm fsm48 = fsm46.Host;
							fsm46.preprocessed = false;
							fsm46.handleJointBreak = true;
							if (fsm46.Host != null)
							{
								do
								{
									fsm48.preprocessed = false;
									fsm48.handleJointBreak = true;
									fsm48 = fsm48.Host;
								}
								while (fsm48.Host != null);
							}
						}
						else if (array[num] != FsmEvent.JointBreak2D)
						{
							if (array[num].IsMouseEvent)
							{
								Fsm fsm49 = fsm2.rootFsm;
								if (fsm2.rootFsm == null)
								{
									Fsm fsm50 = fsm2;
									fsm50 = fsm5;
									do
									{
										fsm50 = fsm50.Host;
									}
									while (fsm50.Host != null);
									fsm2.rootFsm = fsm50.Host;
									fsm49 = fsm50.Host;
								}
								Fsm fsm51 = fsm49.Host;
								fsm49.preprocessed = false;
								fsm49.mouseEvents = true;
								if (fsm49.Host != null)
								{
									do
									{
										fsm51.preprocessed = false;
										fsm51.mouseEvents = true;
										fsm51 = fsm51.Host;
									}
									while (fsm51.Host != null);
								}
							}
							else if (array[num].IsApplicationEvent)
							{
								Fsm fsm52 = fsm2.rootFsm;
								if (fsm2.rootFsm == null)
								{
									Fsm fsm53 = fsm2;
									fsm53 = fsm5;
									do
									{
										fsm53 = fsm53.Host;
									}
									while (fsm53.Host != null);
									fsm2.rootFsm = fsm53.Host;
									fsm52 = fsm53.Host;
								}
								Fsm fsm54 = fsm52.Host;
								fsm52.preprocessed = false;
								fsm52.handleApplicationEvents = true;
								if (fsm52.Host != null)
								{
									do
									{
										fsm54.preprocessed = false;
										fsm54.handleApplicationEvents = true;
										fsm54 = fsm54.Host;
									}
									while (fsm54.Host != null);
								}
							}
							else if (array[num].IsLegacyNetworkEvent)
							{
								Fsm fsm55 = fsm2.rootFsm;
								if (fsm2.rootFsm == null)
								{
									Fsm fsm56 = fsm2;
									fsm56 = fsm5;
									do
									{
										fsm56 = fsm56.Host;
									}
									while (fsm56.Host != null);
									fsm2.rootFsm = fsm56.Host;
									fsm55 = fsm56.Host;
								}
								Fsm fsm57 = fsm55.Host;
								fsm55.preprocessed = false;
								fsm55.handleLegacyNetworking = true;
								if (fsm55.Host != null)
								{
									do
									{
										fsm57.preprocessed = false;
										fsm57.handleLegacyNetworking = true;
										fsm57 = fsm57.Host;
									}
									while (fsm57.Host != null);
								}
							}
							else if (array[num] == FsmEvent.LevelLoaded)
							{
								Fsm fsm58 = fsm2.rootFsm;
								if (fsm2.rootFsm == null)
								{
									Fsm fsm59 = fsm2;
									fsm59 = fsm5;
									do
									{
										fsm59 = fsm59.Host;
									}
									while (fsm59.Host != null);
									fsm2.rootFsm = fsm59.Host;
									fsm58 = fsm59.Host;
								}
								Fsm fsm60 = fsm58.Host;
								fsm58.handleLevelLoaded = true;
								if (fsm58.Host != null)
								{
									do
									{
										fsm60.handleLevelLoaded = true;
										fsm60 = fsm60.Host;
									}
									while (fsm60.Host != null);
								}
							}
							else if (array[num] == FsmEvent.UiClick)
							{
								Fsm fsm61 = fsm2.rootFsm;
								if (fsm2.rootFsm == null)
								{
									Fsm fsm62 = fsm2;
									fsm62 = fsm63;
									do
									{
										fsm62 = fsm62.Host;
									}
									while (fsm62.Host != null);
									fsm2.rootFsm = fsm62.Host;
									fsm61 = fsm62.Host;
								}
								Fsm fsm64 = fsm61.Host;
								fsm61.preprocessed = false;
								int num2 = (int)(fsm61.handleUiEvents = fsm61.HandleUiEvents | UiEvents.Click);
								if (fsm61.Host != null)
								{
									do
									{
										fsm64.preprocessed = false;
										num2 = (int)(fsm64.handleUiEvents = (UiEvents)((int)fsm64.HandleUiEvents | num2));
										fsm64 = fsm64.Host;
									}
									while (fsm64.Host != null);
								}
							}
							else if (array[num] == FsmEvent.UiBeginDrag)
							{
								Fsm fsm65 = fsm2.rootFsm;
								bool flag2 = fsm2.rootFsm == null;
								bool flag3 = !flag2;
								Fsm fsm66 = fsm2;
								if (!flag3)
								{
									do
									{
										fsm2 = fsm2.Host;
									}
									while (fsm2.Host != null);
									rootFsm = fsm2.Host;
									fsm65 = fsm2.Host;
									fsm66 = this;
								}
								Fsm fsm67 = fsm65.Host;
								fsm65.preprocessed = false;
								int num3 = (int)(fsm65.handleUiEvents = fsm65.HandleUiEvents | UiEvents.BeginDrag);
								bool flag4 = fsm65.Host == null;
								fsm2 = fsm66;
								if (!flag4)
								{
									do
									{
										fsm67.preprocessed = false;
										num3 = (int)(fsm67.handleUiEvents = (UiEvents)((int)fsm67.HandleUiEvents | num3));
										fsm67 = fsm67.Host;
									}
									while (fsm67.Host != null);
									fsm2 = fsm66;
								}
							}
							else if (array[num] == FsmEvent.UiDrag)
							{
								Fsm fsm68 = rootFsm;
								bool flag5 = rootFsm == null;
								bool flag6 = !flag5;
								Fsm fsm69 = this;
								fsm2 = this;
								if (!flag6)
								{
									do
									{
										fsm69 = fsm69.Host;
									}
									while (fsm69.Host != null);
									rootFsm = fsm69.Host;
									fsm68 = fsm69.Host;
									fsm2 = this;
								}
								Fsm fsm70 = fsm68.Host;
								fsm68.preprocessed = false;
								int num4 = (int)(fsm68.handleUiEvents = fsm68.HandleUiEvents | UiEvents.Drag);
								if (fsm68.Host != null)
								{
									do
									{
										fsm70.preprocessed = false;
										num4 = (int)(fsm70.handleUiEvents = (UiEvents)((int)fsm70.HandleUiEvents | num4));
										fsm70 = fsm70.Host;
									}
									while (fsm70.Host != null);
								}
							}
							else if (array[num] == FsmEvent.UiEndDrag)
							{
								Fsm fsm71 = rootFsm;
								bool flag7 = rootFsm == null;
								bool flag8 = !flag7;
								Fsm fsm72 = this;
								fsm2 = this;
								if (!flag8)
								{
									do
									{
										fsm72 = fsm72.Host;
									}
									while (fsm72.Host != null);
									rootFsm = fsm72.Host;
									fsm71 = fsm72.Host;
									fsm2 = this;
								}
								Fsm fsm73 = fsm71.Host;
								fsm71.preprocessed = false;
								int num5 = (int)(fsm71.handleUiEvents = fsm71.HandleUiEvents | UiEvents.EndDrag);
								if (fsm71.Host != null)
								{
									do
									{
										fsm73.preprocessed = false;
										num5 = (int)(fsm73.handleUiEvents = (UiEvents)((int)fsm73.HandleUiEvents | num5));
										fsm73 = fsm73.Host;
									}
									while (fsm73.Host != null);
								}
							}
							else if (array[num] == FsmEvent.UiDrop)
							{
								Fsm fsm74 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm75 = this;
									fsm75 = fsm63;
									do
									{
										fsm75 = fsm75.Host;
									}
									while (fsm75.Host != null);
									rootFsm = fsm75.Host;
									fsm74 = fsm75.Host;
								}
								fsm74.preprocessed = false;
								Fsm fsm76 = fsm74.Host;
								int num6 = (int)(fsm74.handleUiEvents = fsm74.HandleUiEvents | UiEvents.Drop);
								bool flag9 = fsm74.Host == null;
								fsm2 = this;
								if (!flag9)
								{
									do
									{
										fsm76.preprocessed = false;
										num6 = (int)(fsm76.handleUiEvents = (UiEvents)((int)fsm76.HandleUiEvents | num6));
										fsm76 = fsm76.Host;
									}
									while (fsm76.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiPointerClick)
							{
								Fsm fsm77 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm78 = this;
									fsm78 = fsm63;
									do
									{
										fsm78 = fsm78.Host;
									}
									while (fsm78.Host != null);
									rootFsm = fsm78.Host;
									fsm77 = fsm78.Host;
								}
								fsm77.preprocessed = false;
								Fsm fsm79 = fsm77.Host;
								int num7 = (int)(fsm77.handleUiEvents = fsm77.HandleUiEvents | UiEvents.PointerClick);
								bool flag10 = fsm77.Host == null;
								fsm2 = this;
								if (!flag10)
								{
									do
									{
										fsm79.preprocessed = false;
										num7 = (int)(fsm79.handleUiEvents = (UiEvents)((int)fsm79.HandleUiEvents | num7));
										fsm79 = fsm79.Host;
									}
									while (fsm79.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiPointerDown)
							{
								Fsm fsm80 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm81 = this;
									fsm81 = fsm63;
									do
									{
										fsm81 = fsm81.Host;
									}
									while (fsm81.Host != null);
									rootFsm = fsm81.Host;
									fsm80 = fsm81.Host;
								}
								fsm80.preprocessed = false;
								Fsm fsm82 = fsm80.Host;
								int num8 = (int)(fsm80.handleUiEvents = fsm80.HandleUiEvents | UiEvents.PointerDown);
								bool flag11 = fsm80.Host == null;
								fsm2 = this;
								if (!flag11)
								{
									do
									{
										fsm82.preprocessed = false;
										num8 = (int)(fsm82.handleUiEvents = (UiEvents)((int)fsm82.HandleUiEvents | num8));
										fsm82 = fsm82.Host;
									}
									while (fsm82.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiPointerEnter)
							{
								Fsm fsm83 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm84 = this;
									fsm84 = fsm63;
									do
									{
										fsm84 = fsm84.Host;
									}
									while (fsm84.Host != null);
									rootFsm = fsm84.Host;
									fsm83 = fsm84.Host;
								}
								fsm83.preprocessed = false;
								Fsm fsm85 = fsm83.Host;
								int num9 = (int)(fsm83.handleUiEvents = fsm83.HandleUiEvents | UiEvents.PointerEnter);
								bool flag12 = fsm83.Host == null;
								fsm2 = this;
								if (!flag12)
								{
									do
									{
										fsm85.preprocessed = false;
										num9 = (int)(fsm85.handleUiEvents = (UiEvents)((int)fsm85.HandleUiEvents | num9));
										fsm85 = fsm85.Host;
									}
									while (fsm85.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiPointerExit)
							{
								Fsm fsm86 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm87 = this;
									fsm87 = fsm63;
									do
									{
										fsm87 = fsm87.Host;
									}
									while (fsm87.Host != null);
									rootFsm = fsm87.Host;
									fsm86 = fsm87.Host;
								}
								fsm86.preprocessed = false;
								Fsm fsm88 = fsm86.Host;
								int num10 = (int)(fsm86.handleUiEvents = fsm86.HandleUiEvents | UiEvents.PointerExit);
								bool flag13 = fsm86.Host == null;
								fsm2 = this;
								if (!flag13)
								{
									do
									{
										fsm88.preprocessed = false;
										num10 = (int)(fsm88.handleUiEvents = (UiEvents)((int)fsm88.HandleUiEvents | num10));
										fsm88 = fsm88.Host;
									}
									while (fsm88.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiPointerUp)
							{
								Fsm fsm89 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm90 = this;
									fsm90 = fsm63;
									do
									{
										fsm90 = fsm90.Host;
									}
									while (fsm90.Host != null);
									rootFsm = fsm90.Host;
									fsm89 = fsm90.Host;
								}
								fsm89.preprocessed = false;
								Fsm fsm91 = fsm89.Host;
								int num11 = (int)(fsm89.handleUiEvents = fsm89.HandleUiEvents | UiEvents.PointerUp);
								bool flag14 = fsm89.Host == null;
								fsm2 = this;
								if (!flag14)
								{
									do
									{
										fsm91.preprocessed = false;
										num11 = (int)(fsm91.handleUiEvents = (UiEvents)((int)fsm91.HandleUiEvents | num11));
										fsm91 = fsm91.Host;
									}
									while (fsm91.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiBoolValueChanged)
							{
								Fsm fsm92 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm93 = this;
									fsm93 = fsm63;
									do
									{
										fsm93 = fsm93.Host;
									}
									while (fsm93.Host != null);
									rootFsm = fsm93.Host;
									fsm92 = fsm93.Host;
								}
								fsm92.preprocessed = false;
								Fsm fsm94 = fsm92.Host;
								int num12 = (int)(fsm92.handleUiEvents = fsm92.HandleUiEvents | UiEvents.BoolValueChanged);
								bool flag15 = fsm92.Host == null;
								fsm2 = this;
								if (!flag15)
								{
									do
									{
										fsm94.preprocessed = false;
										num12 = (int)(fsm94.handleUiEvents = (UiEvents)((int)fsm94.HandleUiEvents | num12));
										fsm94 = fsm94.Host;
									}
									while (fsm94.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiFloatValueChanged)
							{
								Fsm fsm95 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm96 = this;
									fsm96 = fsm63;
									do
									{
										fsm96 = fsm96.Host;
									}
									while (fsm96.Host != null);
									rootFsm = fsm96.Host;
									fsm95 = fsm96.Host;
								}
								fsm95.preprocessed = false;
								Fsm fsm97 = fsm95.Host;
								int num13 = (int)(fsm95.handleUiEvents = fsm95.HandleUiEvents | UiEvents.FloatValueChanged);
								bool flag16 = fsm95.Host == null;
								fsm2 = this;
								if (!flag16)
								{
									do
									{
										fsm97.preprocessed = false;
										num13 = (int)(fsm97.handleUiEvents = (UiEvents)((int)fsm97.HandleUiEvents | num13));
										fsm97 = fsm97.Host;
									}
									while (fsm97.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiIntValueChanged)
							{
								Fsm fsm98 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm99 = this;
									fsm99 = fsm63;
									do
									{
										fsm99 = fsm99.Host;
									}
									while (fsm99.Host != null);
									rootFsm = fsm99.Host;
									fsm98 = fsm99.Host;
								}
								fsm98.preprocessed = false;
								Fsm fsm100 = fsm98.Host;
								int num14 = (int)(fsm98.handleUiEvents = fsm98.HandleUiEvents | UiEvents.IntValueChanged);
								bool flag17 = fsm98.Host == null;
								fsm2 = this;
								if (!flag17)
								{
									do
									{
										fsm100.preprocessed = false;
										num14 = (int)(fsm100.handleUiEvents = (UiEvents)((int)fsm100.HandleUiEvents | num14));
										fsm100 = fsm100.Host;
									}
									while (fsm100.Host != null);
									fsm2 = this;
								}
							}
							else if (array[num] == FsmEvent.UiVector2ValueChanged)
							{
								Fsm fsm101 = rootFsm;
								if (rootFsm == null)
								{
									Fsm fsm102 = this;
									fsm102 = fsm63;
									do
									{
										fsm102 = fsm102.Host;
									}
									while (fsm102.Host != null);
									rootFsm = fsm102.Host;
									fsm101 = fsm102.Host;
								}
								fsm101.preprocessed = false;
								Fsm fsm103 = fsm101.Host;
								int num15 = (int)(fsm101.handleUiEvents = fsm101.HandleUiEvents | UiEvents.Vector2ValueChanged);
								bool flag18 = fsm101.Host == null;
								fsm2 = this;
								if (!flag18)
								{
									bool flag20;
									do
									{
										fsm103.preprocessed = false;
										num15 = (int)(fsm103.handleUiEvents = (UiEvents)((int)fsm103.HandleUiEvents | num15));
										fsm103 = fsm103.Host;
										bool flag19 = fsm103.Host == null;
										flag20 = !flag19;
										fsm2 = this;
									}
									while (flag20);
								}
							}
							else
							{
								bool flag21 = array[num] != FsmEvent.UiEndEdit;
								fsm2 = this;
								if (!flag21)
								{
									Fsm fsm104 = rootFsm;
									if (rootFsm == null)
									{
										Fsm fsm105 = this;
										fsm105 = fsm63;
										do
										{
											fsm105 = fsm105.Host;
										}
										while (fsm105.Host != null);
										rootFsm = fsm105.Host;
										fsm104 = fsm105.Host;
									}
									fsm104.preprocessed = false;
									Fsm fsm106 = fsm104.Host;
									int num16 = (int)(fsm104.handleUiEvents = fsm104.HandleUiEvents | UiEvents.EndEdit);
									bool flag22 = fsm104.Host == null;
									fsm2 = this;
									if (!flag22)
									{
										do
										{
											fsm106.preprocessed = false;
											num16 = (int)(fsm106.handleUiEvents = (UiEvents)((int)fsm106.HandleUiEvents | num16));
											fsm106 = fsm106.Host;
										}
										while (fsm106.Host != null);
										fsm2 = this;
									}
								}
							}
						}
						else
						{
							Fsm fsm107 = fsm2.rootFsm;
							if (fsm2.rootFsm == null)
							{
								Fsm fsm108 = fsm2;
								fsm108 = fsm5;
								do
								{
									fsm108 = fsm108.Host;
								}
								while (fsm108.Host != null);
								fsm2.rootFsm = fsm108.Host;
								fsm107 = fsm108.Host;
							}
							Fsm fsm109 = fsm107.Host;
							fsm107.preprocessed = false;
							fsm107.handleJointBreak2D = true;
							if (fsm107.Host != null)
							{
								do
								{
									fsm109.preprocessed = false;
									fsm109.handleJointBreak2D = true;
									fsm109 = fsm109.Host;
								}
								while (fsm109.Host != null);
							}
						}
					}
					num++;
					flag23 = num < array.Length;
					fsm = fsm2;
				}
				while (flag23);
			}
			List<Fsm> list = fsm.SubFsmList;
			List<Fsm>.Enumerator enumerator = list.GetEnumerator();
			IntPtr intPtr;
			while (true)
			{
				List<Fsm>.Enumerator enumerator2 = (List<Fsm>.Enumerator)((long)(IntPtr)obj2 - 104L);
				if (((List<Fsm>.Enumerator*)enumerator2)->MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-58]");
					bool flag24 = (IntPtr)0 == (IntPtr)0;
					intPtr = (IntPtr)0;
					if (flag24)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-58]");
					((Fsm)0).CheckFsmEventsForEventHandlers();
					continue;
				}
				List<Fsm>.Enumerator enumerator3 = (List<Fsm>.Enumerator)((long)(IntPtr)obj2 - 104L);
				((List<Fsm>.Enumerator*)enumerator3)->Dispose();
				return;
			}
			while (true)
			{
				NullReferenceException ex = new NullReferenceException();
				if (intPtr == (IntPtr)1)
				{
					bool flag25 = ((List<Fsm>.Enumerator*)ex)->MoveNext();
					bool flag26 = (flag25 ? ((List<Fsm>.Enumerator*)1) : ((List<Fsm>.Enumerator*)null))->MoveNext();
					List<Fsm>.Enumerator enumerator4 = (List<Fsm>.Enumerator)((long)(IntPtr)obj2 - 104L);
					((List<Fsm>.Enumerator*)enumerator4)->Dispose();
					if (!((bool*)(flag25 ? 1 : 0))->m_value)
					{
						break;
					}
				}
				else
				{
					bool flag27 = ((List<Fsm>.Enumerator*)ex)->MoveNext();
				}
				TypeLoadException ex2 = new TypeLoadException();
				intPtr = (IntPtr)null;
			}
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0x9DD838", Offset = "0x9DD838", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F06930]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A50]) = v44;\nL_0017:\n\tthis.<Finished>k__BackingField = 0;\n\tv46 = ~this.handleLevelLoaded;\n\tif (v46) goto L_0035;\n\tv50 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v50, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v50);\n\tv85 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v85, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v85);\nL_0035:\n\tv67 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv74 = v67 == 0;\n\tif (v74) goto L_003D;\n\tv78 = ~this.RestartOnEnable;\n\tif (v78) goto L_0058;\nL_003D:\n\tv83 = HutongGames.PlayMaker.Fsm::GetState(this, this.startState);\n\tHutongGames.PlayMaker.Fsm::set_ActiveState(this, v83);\n\tthis.activeStateEntered = 0;\n\tv91 = ~this.<Started>k__BackingField;\n\tif (v91) goto L_0058;\n\tHutongGames.PlayMaker.Fsm::Start(this);\n\treturn;\nL_0058:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			Finished = false;
			if (HandleLevelLoaded)
			{
				UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
				SceneManager.sceneLoaded -= value;
				UnityAction<Scene, LoadSceneMode> value2 = OnSceneLoaded;
				SceneManager.sceneLoaded += value2;
			}
			FsmState fsmState = ActiveState;
			if (fsmState == null || RestartOnEnable)
			{
				FsmState state = GetState(StartState);
				ActiveState = state;
				activeStateEntered = false;
				if (Started)
				{
					Start();
				}
			}
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0x9DDBE8", Offset = "0x9DDBE8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE6D50]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, scene, loadSceneMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A51]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, scene, loadSceneMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1ECC630]);\n\tv60 = *([v59 @ X8_v12]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, scene, loadSceneMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021AA0]) = v64;\nL_002F:\n\tgoto L_0038;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0038;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, scene, loadSceneMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_0038:\n\tv78 = v76.<LevelLoaded>k__BackingField == 0;\n\tif (v78) goto L_004A;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v76.<LevelLoaded>k__BackingField);\n\treturn;\nL_004A:\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			if (FsmEvent.LevelLoaded != null)
			{
				Event(EventTarget, FsmEvent.LevelLoaded);
			}
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0x9DD94C", Offset = "0x9DD94C", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED5348]);\n\tv25 = *([v24 @ X8_v51]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A52]) = v44;\nL_001C:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tgoto L_0031;\n\tv63 = *([1EC48C8]);\n\tv64 = *([v63 @ X8_v47]);\n\tv65 = \"il2cpp_codegen_initialize_method\"(v64, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv68 = 0 | 1;\n\t*([2021AA1]) = v68;\nL_0031:\n\tgoto L_003A;\n\tv73 = *([v69 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_003A;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv77 = HutongGames.PlayMaker.FsmLog;\nL_003A:\n\tv82 = ~v80.<LoggingEnabled>k__BackingField;\n\tif (v82) goto L_0048;\n\tv85 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tv104 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.FsmLog::LogStart(v85, v104);\nL_0048:\n\tthis.<Finished>k__BackingField = 0;\n\tthis.<Started>k__BackingField = 1;\n\tgoto L_0057;\n\tv105 = *([v99 @ X0_v10+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0057;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v99, v88, v86, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0057:\n\tv113 = HutongGames.PlayMaker.FsmExecutionStack::get_StackCount();\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv119 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv136 = v119 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_006E;\n\tv140 = HutongGames.PlayMaker.Fsm::GetState(this, this.startState);\n\tHutongGames.PlayMaker.Fsm::set_ActiveState(this, v140);\n\tthis.activeStateEntered = 0;\nL_006E:\n\tgoto L_0078;\n\tv203 = *([v145 @ X0_v18+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tgoto L_0078;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v145, v126, v86, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0078:\n\tgoto L_0083;\n\tv214 = *([1EB3790]);\n\tv215 = *([v214 @ X8_v40]);\n\tv216 = \"il2cpp_codegen_initialize_method\"(v215, v126, v86, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv219 = 0 | 1;\n\t*([2021AA2]) = v219;\nL_0083:\n\tgoto L_008C;\n\tv224 = *([v220 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tgoto L_008C;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v220, v126, v86, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv228 = HutongGames.PlayMaker.Fsm;\nL_008C:\n\tv233 = ~v231.<BreakpointsEnabled>k__BackingField;\n\tif (v233) goto L_009D;\n\tv235 = ~this.EnableBreakpoints;\n\tif (v235) goto L_009D;\n\tv129 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv238 = ~v129.isBreakpoint;\n\tif (v238) goto L_009D;\n\tthis.activeStateEntered = 0;\n\tHutongGames.PlayMaker.Fsm::DoBreak(this);\n\tgoto L_00A5;\nL_009D:\n\tv242 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tthis.switchToState = v242;\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\nL_00A5:\n\tgoto L_00AC;\n\tv253 = *([v249 @ X0_v24+E0]);\n\tv254 = v253 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_00AC;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v249, v126, v86, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00AC:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\tv262 = HutongGames.PlayMaker.FsmExecutionStack::get_StackCount();\n\tv172 = v262 == v113;\n\tv264 = v262 - v113;\n\tif (v172) goto L_00E0;\n\t// 191 Box v270 @ X0_v31 (System.Object), typeof(System.Int32), &v264 @ X8_v26 (System.Int32)\n\tv284 = System.String::Concat(\"Stack error: \", v270);\n\tgoto L_00D7;\n\tv290 = *([v278 @ X8_v33+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_00D7;\n\tv295 = v278;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v295, v281, v272, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00D7:\n\tUnityEngine.Debug::LogError(v284);\nL_00E0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			if (FsmLog.LoggingEnabled)
			{
				FsmLog fsmLog = MyLog;
				FsmState fsmState = ActiveState;
				fsmLog.LogStart(fsmState);
			}
			Finished = false;
			Started = true;
			int stackCount = FsmExecutionStack.StackCount;
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState2 = ActiveState;
			if (fsmState2 == null)
			{
				FsmState state = GetState(StartState);
				ActiveState = state;
				activeStateEntered = false;
			}
			if (BreakpointsEnabled && EnableBreakpoints)
			{
				FsmState fsmState3 = ActiveState;
				if (fsmState3.IsBreakpoint)
				{
					activeStateEntered = false;
					DoBreak();
					goto IL_014e;
				}
			}
			FsmState fsmState4 = ActiveState;
			switchToState = fsmState4;
			UpdateStateChanges();
			goto IL_014e;
			IL_014e:
			FsmExecutionStack.PopFsm();
			int stackCount2 = FsmExecutionStack.StackCount;
			bool flag = stackCount2 == stackCount;
			int num = stackCount2 - stackCount;
			if (!flag)
			{
				object obj = num;
				string message = "Stack error: " + obj;
				Debug.LogError(message);
			}
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x9DDCBC", Offset = "0x9DDCBC", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA7258]);\n\tv25 = *([v24 @ X8_v38]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A53]) = v44;\nL_0017:\n\tHutongGames.PlayMaker.FsmTime::RealtimeBugFix();\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv63 = UnityEngine.Object::op_Equality(this.owner, 0);\n\tv65 = v63 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_00C1;\n\tgoto L_003A;\n\tv137 = *([v69 @ X0_v8+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_003A;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v69, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003A:\n\tv145 = HutongGames.PlayMaker.FsmExecutionStack::get_StackCount();\n\tgoto L_004D;\n\tv151 = *([v147 @ X8_v10+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_004D;\n\tv160 = v147;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v160, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tgoto L_0058;\n\tv162 = *([1EF9430]);\n\tv163 = *([v162 @ X8_v33]);\n\tv164 = \"il2cpp_codegen_initialize_method\"(v163, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv167 = 0 | 1;\n\t*([2021AA3]) = v167;\nL_0058:\n\tgoto L_0061;\n\tv172 = *([v168 @ X0_v14 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv173 = v172 == 0;\n\tv174 = ~v173;\n\tgoto L_0061;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v168, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv175 = HutongGames.PlayMaker.Fsm;\nL_0061:\n\tv179 = ~v178.<HitBreakpoint>k__BackingField;\n\tv121 = ~v179;\n\tif (v121) goto L_00C1;\n\tgoto L_0070;\n\tv185 = *([v181 @ X0_v16+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0070;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v181, v61, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0070:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv195 = ~this.activeStateEntered;\n\tv196 = ~v195;\n\tif (v196) goto L_0078;\n\tHutongGames.PlayMaker.Fsm::Continue(this);\nL_0078:\n\tHutongGames.PlayMaker.Fsm::UpdateDelayedEvents(this);\n\tv201 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv202 = v201 == 0;\n\tif (v202) goto L_0086;\n\tv204 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::UpdateState(this, v204);\nL_0086:\n\tgoto L_008D;\n\tv212 = *([v208 @ X0_v24+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_008D;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v208, v113, v62, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008D:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\tv116 = HutongGames.PlayMaker.FsmExecutionStack::get_StackCount();\n\tv89 = v116 == v145;\n\tv126 = v116 - v145;\n\tif (v89) goto L_00C1;\n\t// 160 Box v225 @ X0_v30 (System.Object), typeof(System.Int32), &v126 @ X8_v22 (System.Int32)\n\tv231 = System.String::Concat(\"Stack error: \", v225);\n\tgoto L_00B8;\n\tv237 = *([v125 @ X8_v28+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_00B8;\n\tv242 = v125;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v242, v228, v110, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00B8:\n\tUnityEngine.Debug::LogError(v231);\nL_00C1:\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			FsmTime.RealtimeBugFix();
			if (Owner == null)
			{
				return;
			}
			int stackCount = FsmExecutionStack.StackCount;
			if (!HitBreakpoint)
			{
				FsmExecutionStack.PushFsm(this);
				if (!activeStateEntered)
				{
					Continue();
				}
				UpdateDelayedEvents();
				FsmState fsmState = ActiveState;
				if (fsmState != null)
				{
					FsmState state = ActiveState;
					UpdateState(state);
				}
				FsmExecutionStack.PopFsm();
				int stackCount2 = FsmExecutionStack.StackCount;
				bool flag = stackCount2 == stackCount;
				int num = stackCount2 - stackCount;
				if (!flag)
				{
					object obj = num;
					string message = "Stack error: " + obj;
					Debug.LogError(message);
				}
			}
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x9DE034", Offset = "0x9DE034", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA9AF0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021A54]) = v42;\nL_001B:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Clear(this.removeEvents);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Clear(this.updateEvents);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::AddRange(this.updateEvents, this.delayedEvents);\n\tv217 = this.updateEvents;\nL_0039:\n\tv172 = v89 >= v217._size;\n\tif (v172) goto L_0060;\n\tv246 = v217._size < v89;\n\tv86 = ~v246;\n\tv82 = v217._size - v89;\n\tv74 = v82 == 0;\n\tv247 = ~v74;\n\tv54 = v86 & v247;\n\tif (v54) goto L_0049;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0049:\n\tv249 = v217._items;\n\tv115 = v249[v89 @ X21_v6 (System.Int32)];\n\tHutongGames.PlayMaker.DelayedEvent::Update(v249[v89 @ X21_v6 (System.Int32)]);\n\tv264 = ~v115.eventFired;\n\tif (v264) goto L_005A;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Add(this.removeEvents, v249[v89 @ X21_v6 (System.Int32)]);\nL_005A:\n\tv217 = this.updateEvents;\n\tv89 = v89 + 1;\n\tv270 = this.updateEvents == 0;\n\tv208 = ~v270;\n\tif (v208) goto L_0039;\n\tgoto L_008F;\nL_0060:\n\tv93 = this.removeEvents;\nL_0070:\n\tv232 = v116 >= v93._size;\n\tif (v232) goto L_0097;\n\tv265 = v93._size < v116;\n\tv87 = ~v265;\n\tv83 = v93._size - v116;\n\tv75 = v83 == 0;\n\tv266 = ~v75;\n\tv55 = v87 & v266;\n\tif (v55) goto L_0083;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0083:\n\tv273 = v93._items;\n\tv201 = System.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Remove(this.delayedEvents, v273[v116 @ X20_v11 (System.Int32)]);\n\tv93 = this.removeEvents;\n\tv116 = v116 + 1;\n\tv274 = this.removeEvents == 0;\n\tv206 = ~v274;\n\tif (v206) goto L_0070;\nL_008F:\n\tthrow System.NullReferenceException;\nL_0097:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateDelayedEvents()
		{
			removeEvents.Clear();
			updateEvents.Clear();
			updateEvents.AddRange(DelayedEvents);
			List<DelayedEvent> list = updateEvents;
			int num = 0;
			do
			{
				if (num < list.Count)
				{
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					DelayedEvent[] items = list._items;
					DelayedEvent delayedEvent = items[num];
					items[num].Update();
					if (delayedEvent.Finished)
					{
						removeEvents.Add(items[num]);
					}
					list = updateEvents;
					num++;
					continue;
				}
				List<DelayedEvent> list2 = removeEvents;
				int num3 = 0;
				do
				{
					if (num3 < list2.Count)
					{
						bool flag5 = list2.Count < num3;
						bool flag6 = !flag5;
						int num4 = list2.Count - num3;
						bool flag7 = num4 == 0;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							throw new ArgumentOutOfRangeException();
						}
						DelayedEvent[] items2 = list2._items;
						bool flag9 = DelayedEvents.Remove(items2[num3]);
						list2 = removeEvents;
						num3++;
						continue;
					}
					return;
				}
				while (removeEvents != null);
				break;
			}
			while (updateEvents != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x9DE1E4", Offset = "0x9DE1E4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EB09B8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A55]) = v38;\nL_001E:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Clear(this.delayedEvents);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearDelayedEvents()
		{
			DelayedEvents.Clear();
		}

		[Token(Token = "0x60003F7")]
		[Address(RVA = "0x9DE23C", Offset = "0x9DE23C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC57A8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A56]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv55 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv56 = v55 == 0;\n\tif (v56) goto L_0032;\n\tv58 = ~this.activeStateEntered;\n\tif (v58) goto L_0032;\n\tv70 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::FixedUpdateState(this, v70);\nL_0032:\n\tgoto L_003E;\n\tv71 = *([v65 @ X0_v8+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_003E;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v65, v59, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FixedUpdate()
		{
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (fsmState != null && activeStateEntered)
			{
				FsmState state = ActiveState;
				FixedUpdateState(state);
			}
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x60003F8")]
		[Address(RVA = "0x9DE338", Offset = "0x9DE338", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED7B18]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A57]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv55 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv56 = v55 == 0;\n\tif (v56) goto L_0032;\n\tv58 = ~this.activeStateEntered;\n\tif (v58) goto L_0032;\n\tv70 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::LateUpdateState(this, v70);\nL_0032:\n\tgoto L_003E;\n\tv71 = *([v65 @ X0_v8+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_003E;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v65, v59, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (fsmState != null && activeStateEntered)
			{
				FsmState state = ActiveState;
				LateUpdateState(state);
			}
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0x9DE434", Offset = "0x9DE434", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB02A0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A58]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Fsm::Stop(this);\n\tv41 = ~this.handleLevelLoaded;\n\tif (v41) goto L_0033;\n\tv45 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v45, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v45);\n\treturn;\nL_0033:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			Stop();
			if (HandleLevelLoaded)
			{
				UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
				SceneManager.sceneLoaded -= value;
			}
		}

		[Token(Token = "0x60003FA")]
		[Address(RVA = "0x9DE4CC", Offset = "0x9DE4CC", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EB9948]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A59]) = v40;\nL_0015:\n\tv42 = ~this.RestartOnEnable;\n\tif (v42) goto L_001A;\n\tHutongGames.PlayMaker.Fsm::StopAndReset(this);\nL_001A:\n\tthis.<Finished>k__BackingField = 1;\n\tgoto L_002B;\n\tv52 = *([v48 @ X0_v3+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_002B;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tgoto L_0036;\n\tv64 = *([1EC48C8]);\n\tv65 = *([v64 @ X8_v15]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv69 = 0 | 1;\n\t*([2021AA1]) = v69;\nL_0036:\n\tgoto L_003F;\n\tv74 = *([v70 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003F;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv78 = HutongGames.PlayMaker.FsmLog;\nL_003F:\n\tv83 = ~v81.<LoggingEnabled>k__BackingField;\n\tif (v83) goto L_0054;\n\tv86 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogStop(v86);\n\treturn;\nL_0054:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Stop()
		{
			if (RestartOnEnable)
			{
				Stop();
			}
			Finished = true;
			if (FsmLog.LoggingEnabled)
			{
				FsmLog fsmLog = MyLog;
				fsmLog.LogStop();
			}
		}

		[Token(Token = "0x60003FB")]
		[Address(RVA = "0x9DE5BC", Offset = "0x9DE5BC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EED810]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A5A]) = v40;\nL_001A:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv57 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv58 = v57 == 0;\n\tif (v58) goto L_0031;\n\tv60 = ~this.activeStateEntered;\n\tif (v60) goto L_0031;\n\tv70 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::ExitState(this, v70);\nL_0031:\n\tHutongGames.PlayMaker.Fsm::set_ActiveState(this, 0);\n\tthis.<LastTransition>k__BackingField = 0;\n\tthis.<SwitchedState>k__BackingField = 0;\n\tgoto L_0044;\n\tv77 = *([v73 @ X0_v9+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0044;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v73, v68, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tgoto L_004F;\n\tv89 = *([1ED36A0]);\n\tv90 = *([v89 @ X8_v18]);\n\tv91 = \"il2cpp_codegen_initialize_method\"(v90, v68, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv94 = 0 | 1;\n\t*([2021AA4]) = v94;\nL_004F:\n\tgoto L_0057;\n\tv99 = *([v95 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tgoto L_0057;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v95, v68, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv103 = HutongGames.PlayMaker.Fsm;\nL_0057:\n\tv106.<HitBreakpoint>k__BackingField = 0;\n\tgoto L_0069;\n\tv112 = *([v107 @ X0_v14+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tgoto L_0069;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v107, v68, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0069:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StopAndReset()
		{
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (fsmState != null && activeStateEntered)
			{
				FsmState state = ActiveState;
				ExitState(state);
			}
			ActiveState = null;
			LastTransition = null;
			SwitchedState = false;
			HitBreakpoint = false;
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x60003FC")]
		[Address(RVA = "0x9DE814", Offset = "0x9DE814", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = System.String::IsNullOrEmpty(eventName);\n\tv20 = v18 == 0;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tv22 = this.events;\n\tv108 = v22.Length;\n\tv35 = v22.Length < 1;\n\tif (v35) goto L_FFFFFFFF;\nL_0021:\n\tv186 = v88 < v108;\n\tv106 = ~v186;\n\tif (v106) goto L_0050;\n\tv109 = v22[v88 @ X21_v6 (System.Int32)];\n\tv77 = System.String::op_Equality(v109.name, eventName);\n\tv191 = v77 == 0;\n\tv73 = ~v191;\n\tif (v73) goto L_FFFFFFFF;\n\tv108 = v22.Length;\n\tv88 = v88 + 1;\n\tv33 = v88 < v22.Length;\n\tif (v33) goto L_0021;\nL_004D:\n\treturn returnVal1;\n\tgoto L_004D;\nL_0050:\n\tv188 = new System.IndexOutOfRangeException();\n\tthrow v188;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasEvent(string eventName)
		{
			if (!string.IsNullOrEmpty(eventName))
			{
				FsmEvent[] array = Events;
				int num = array.Length;
				if (array.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							FsmEvent fsmEvent = array[num2];
							if (!(fsmEvent.Name == eventName))
							{
								num = array.Length;
								num2++;
								continue;
							}
							return true;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array.Length);
				}
			}
			return false;
		}

		[Token(Token = "0x60003FD")]
		[Address(RVA = "0x9DE8C0", Offset = "0x9DE8C0", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EB23C8]);\n\tv39 = *([v38 @ X8_v59]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, fsmEvent, eventData, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021A5B]) = v56;\nL_001E:\n\tv58 = HutongGames.PlayMaker.Fsm::get_Active(this);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0174;\n\tgoto L_0030;\n\tv90 = *([v63 @ X0_v5+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0030;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v63, fsmEvent, eventData, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0030:\n\tv70 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(fsmEvent);\n\tv192 = v70 == 0;\n\tv73 = ~v192;\n\tif (v73) goto L_0174;\n\tv193 = ~this.<Started>k__BackingField;\n\tv194 = ~v193;\n\tif (v194) goto L_003C;\n\tHutongGames.PlayMaker.Fsm::Start(this);\nL_003C:\n\tv71 = HutongGames.PlayMaker.Fsm::get_Active(this);\n\tv74 = v71 == 0;\n\tif (v74) goto L_0174;\n\tv199 = eventData == 0;\n\tif (v199) goto L_0056;\n\tgoto L_004F;\n\tv217 = *([v202 @ X0_v70+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_004F;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v202, v68, eventData, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004F:\n\tHutongGames.PlayMaker.Fsm::SetEventDataSentByInfo(eventData);\nL_0056:\n\tgoto L_005E;\n\tv222 = *([v213 @ X0_v13+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_005E;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v213, v68, eventData, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_005E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv232 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv236 = HutongGames.PlayMaker.FsmState::OnEvent(v232, fsmEvent);\n\tv330 = v236 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_0151;\n\tv300 = this.globalTransitions;\n\tv480 = v300.Length;\n\tv396 = v300.Length < 1;\n\tif (v396) goto L_00DC;\nL_0082:\n\tv493 = v254 < v480;\n\tv428 = ~v493;\n\tif (v428) goto L_0177;\n\tv326 = v300[v254 @ X25_v12 (System.Int32)];\n\tv262 = v326.fsmEvent != fsmEvent;\n\tif (v262) goto L_00CD;\n\tgoto L_00AA;\n\tv507 = *([v498 @ X0_v54+E0]);\n\tv508 = v507 == 0;\n\tv509 = ~v508;\n\tif (v509) goto L_00AA;\n\tv511 = \"il2cpp_codegen_runtime_class_init\"(v498, v307, v303, v238, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00AA:\n\tgoto L_00B2;\n\tv526 = v320;\n\tv527 = \"il2cpp_codegen_initialize_method\"(v526, v307, v303, v238, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2021AA1]) = v246;\nL_00B2:\n\tgoto L_00BB;\n\tv533 = *([v529 @ X0_v57 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv534 = v533 == 0;\n\tv535 = ~v534;\n\tgoto L_00BB;\n\tv544 = \"il2cpp_codegen_runtime_class_init\"(v529, v307, v303, v238, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv537 = HutongGames.PlayMaker.FsmLog;\nL_00BB:\n\tv541 = ~v540.<LoggingEnabled>k__BackingField;\n\tif (v541) goto L_00C8;\n\tv312 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogEvent(v312, fsmEvent, this.activeState);\nL_00C8:\n\tv368 = HutongGames.PlayMaker.Fsm::DoTransition(this, v300[v254 @ X25_v12 (System.Int32)], 1);\n\tv562 = v368 == 0;\n\tv372 = ~v562;\n\tif (v372) goto L_0151;\nL_00CD:\n\tv480 = v300.Length;\n\tv254 = v254 + 1;\n\tv456 = v254 < v300.Length;\n\tif (v456) goto L_0082;\nL_00DC:\n\tv313 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv301 = v313.transitions;\n\tv481 = v301.Length;\n\tv342 = v301.Length < 1;\n\tif (v342) goto L_0151;\nL_00F4:\n\tv525 = v256 < v481;\n\tv429 = ~v525;\n\tif (v429) goto L_0177;\n\tv328 = v301[v256 @ X25_v9 (System.Int32)];\n\tv264 = v328.fsmEvent != fsmEvent;\n\tif (v264) goto L_013F;\n\tgoto L_011C;\n\tv563 = *([v554 @ X0_v37+E0]);\n\tv564 = v563 == 0;\n\tv565 = ~v564;\n\tif (v565) goto L_011C;\n\tv567 = \"il2cpp_codegen_runtime_class_init\"(v554, v309, v305, v240, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_011C:\n\tgoto L_0124;\n\tv573 = v320;\n\tv574 = \"il2cpp_codegen_initialize_method\"(v573, v309, v305, v240, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\t*([2021AA1]) = v248;\nL_0124:\n\tgoto L_012D;\n\tv580 = *([v576 @ X0_v40 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv581 = v580 == 0;\n\tv582 = ~v581;\n\tgoto L_012D;\n\tv589 = \"il2cpp_codegen_runtime_class_init\"(v576, v309, v305, v240, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv584 = HutongGames.PlayMaker.FsmLog;\nL_012D:\n\tv588 = ~v587.<LoggingEnabled>k__BackingField;\n\tif (v588) goto L_013A;\n\tv314 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogEvent(v314, fsmEvent, this.activeState);\nL_013A:\n\tv369 = HutongGames.PlayMaker.Fsm::DoTransition(this, v301[v256 @ X25_v9 (System.Int32)], 0);\n\tv600 = v369 == 0;\n\tv374 = ~v600;\n\tif (v374) goto L_0151;\nL_013F:\n\tv481 = v301.Length;\n\tv256 = v256 + 1;\n\tv341 = v256 < v301.Length;\n\tif (v341) goto L_00F4;\nL_0151:\n\tgoto L_0165;\n\tv447 = *([v380 @ X0_v22+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_0165;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v380, v168, v162, v100, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0165:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\nL_0174:\n\treturn;\n\tv446 = new System.NullReferenceException();\nL_0177:\n\tv484 = new System.IndexOutOfRangeException();\n\tthrow v484;\n\tthrow System.NullReferenceException;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ProcessEvent(FsmEvent fsmEvent, FsmEventData eventData = null)
		{
			if (!Active || FsmEvent.IsNullOrEmpty(fsmEvent))
			{
				return;
			}
			if (!Started)
			{
				Start();
			}
			if (!Active)
			{
				return;
			}
			if (eventData != null)
			{
				SetEventDataSentByInfo(eventData);
			}
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (!fsmState.OnEvent(fsmEvent))
			{
				FsmTransition[] array = GlobalTransitions;
				int num = array.Length;
				if (array.Length < 1)
				{
					goto IL_024c;
				}
				int num2 = 0;
				while (num2 < num)
				{
					FsmTransition fsmTransition = array[num2];
					if (fsmTransition.FsmEvent == fsmEvent)
					{
						if (FsmLog.LoggingEnabled)
						{
							FsmLog fsmLog = MyLog;
							fsmLog.LogEvent(fsmEvent, activeState);
						}
						if (DoTransition(array[num2], isGlobal: true))
						{
							goto IL_0390;
						}
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_024c;
				}
				goto IL_0397;
			}
			goto IL_0390;
			IL_024c:
			FsmState fsmState2 = ActiveState;
			FsmTransition[] transitions = fsmState2.Transitions;
			int num3 = transitions.Length;
			if (transitions.Length >= 1)
			{
				int num4 = 0;
				while (num4 < num3)
				{
					FsmTransition fsmTransition2 = transitions[num4];
					if (fsmTransition2.FsmEvent == fsmEvent)
					{
						if (FsmLog.LoggingEnabled)
						{
							FsmLog fsmLog2 = MyLog;
							fsmLog2.LogEvent(fsmEvent, activeState);
						}
						if (DoTransition(transitions[num4], isGlobal: false))
						{
							goto IL_0390;
						}
					}
					num3 = transitions.Length;
					num4++;
					if (num4 < transitions.Length)
					{
						continue;
					}
					goto IL_0390;
				}
				goto IL_0397;
			}
			goto IL_0390;
			IL_0390:
			FsmExecutionStack.PopFsm();
			return;
			IL_0397:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003FE")]
		[Address(RVA = "0x9DEE00", Offset = "0x9DEE00", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF6C20]);\n\tv17 = *([v16 @ X8_v16]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021A5C]) = v37;\nL_0018:\n\tgoto L_0023;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0023;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv55 = v53.EventData;\n\tgoto L_002F;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002F;\n\tv69 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v69, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002F:\n\tv68 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv55.SentByFsm = v68;\n\tv74 = v73.EventData;\n\tv75 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv74.SentByState = v75;\n\tv85 = v83.EventData;\n\tv78 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv85.SentByAction = v78;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEventDataSentByInfo()
		{
			FsmEventData eventData = EventData;
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			eventData.SentByFsm = executingFsm;
			FsmEventData eventData2 = EventData;
			FsmState executingState = FsmExecutionStack.ExecutingState;
			eventData2.SentByState = executingState;
			FsmEventData eventData3 = EventData;
			FsmStateAction executingAction = FsmExecutionStack.ExecutingAction;
			eventData3.SentByAction = executingAction;
		}

		[Token(Token = "0x60003FF")]
		[Address(RVA = "0x9DEC18", Offset = "0x9DEC18", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFFD00]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A5D]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b15\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv55 = v54.EventData;\n\tv55.SentByFsm = eventData.SentByFsm;\n\tv65 = v69.EventData;\n\tv65.SentByState = eventData.SentByState;\n\tv66 = v70.EventData;\n\tv66.SentByAction = eventData.SentByAction;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetEventDataSentByInfo(FsmEventData eventData)
		{
			FsmEventData eventData2 = EventData;
			eventData2.SentByFsm = eventData.SentByFsm;
			FsmEventData eventData3 = EventData;
			eventData3.SentByState = eventData.SentByState;
			FsmEventData eventData4 = EventData;
			eventData4.SentByAction = eventData.SentByAction;
		}

		[Token(Token = "0x6000400")]
		[Address(RVA = "0x9DEEDC", Offset = "0x9DEEDC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EE8478]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021A5E]) = v35;\nL_0014:\n\tv39 = new HutongGames.PlayMaker.FsmEventData();\n\tHutongGames.PlayMaker.FsmEventData::.ctor(v39);\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v4+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, v40, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tv56 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv39.SentByFsm = v56;\n\tv59 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv39.SentByState = v59;\n\tv63 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv39.SentByAction = v63;\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FsmEventData GetEventDataSentByInfo()
		{
			FsmEventData fsmEventData = new FsmEventData();
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			fsmEventData.SentByFsm = executingFsm;
			FsmState executingState = FsmExecutionStack.ExecutingState;
			fsmEventData.SentByState = executingState;
			FsmStateAction executingAction = FsmExecutionStack.ExecutingAction;
			fsmEventData.SentByAction = executingAction;
			return fsmEventData;
		}

		[Token(Token = "0x6000401")]
		[Address(RVA = "0x9DEF88", Offset = "0x9DEF88", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF1A98]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, eventTarget, fsmEventName, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A5F]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(fsmEventName);\n\tv49 = v47 == 0;\n\tif (v49) goto L_002B;\n\treturn;\nL_002B:\n\tgoto L_0033;\n\tv84 = *([v58 @ X0_v4+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0033;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v58, v46, fsmEventName, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tv91 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tHutongGames.PlayMaker.Fsm::Event(this, eventTarget, v91);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(FsmEventTarget eventTarget, string fsmEventName)
		{
			if (!string.IsNullOrEmpty(fsmEventName))
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
				Event(eventTarget, fsmEvent);
			}
		}

		[Token(Token = "0x6000402")]
		[Address(RVA = "0x9DF030", Offset = "0x9DF030", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EFF578]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, fromGameObject, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021A60]) = v47;\nL_001F:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, fromGameObject, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = HutongGames.PlayMaker.Fsm;\nL_0027:\n\tv62 = v61.EventData;\n\tv62.SentByGameObject = fromGameObject;\n\tHutongGames.PlayMaker.Fsm::Event(this, eventTarget, fsmEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(GameObject fromGameObject, FsmEventTarget eventTarget, FsmEvent fsmEvent)
		{
			FsmEventData eventData = EventData;
			eventData.SentByGameObject = fromGameObject;
			Event(eventTarget, fsmEvent);
		}

		[Token(Token = "0x6000403")]
		[Address(RVA = "0x9DF0D4", Offset = "0x9DF0D4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F051A8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fromGameObject, fsmEvent, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A61]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, fromGameObject, fsmEvent, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = HutongGames.PlayMaker.Fsm;\nL_0025:\n\tv59 = v58.EventData;\n\tv59.SentByGameObject = fromGameObject;\n\tv62 = fsmEvent == 0;\n\tif (v62) goto L_003E;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, fsmEvent);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(GameObject fromGameObject, FsmEvent fsmEvent)
		{
			FsmEventData eventData = EventData;
			eventData.SentByGameObject = fromGameObject;
			if (fsmEvent != null)
			{
				Event(EventTarget, fsmEvent);
			}
		}

		[Token(Token = "0x6000404")]
		[Address(RVA = "0x9D7D54", Offset = "0x9D7D54", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1ECF938]);\n\tv31 = *([v30 @ X8_v46]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021A62]) = v48;\nL_0022:\n\tgoto L_0028;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_0028;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0028:\n\tHutongGames.PlayMaker.Fsm::SetEventDataSentByInfo();\n\tgoto L_003F;\n\tv67 = HutongGames.PlayMaker.Fsm;\n\tv68 = *([v67 @ X0_v56+12F]);\n\tv69 = v68 & 2;\n\tv70 = v69 == 0;\n\tif (v70) goto L_FFFFFFFF;\n\tv85 = *([v67 @ X0_v56+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_FFFFFFFF;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v67, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv88 = HutongGames.PlayMaker.Fsm;\n\tv78 = *([v72 @ X0_v57+B8]);\n\tv76 = *([v78 @ X8_v42+78]);\nL_003F:\n\tgoto L_0049;\n\tv90 = *([v81 @ X0_v5+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tgoto L_0049;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v81, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0049:\n\tgoto L_FFFFFFFF;\n\tv103 = *([1EC48C8]);\n\tv104 = *([v103 @ X8_v37]);\n\tv105 = \"il2cpp_codegen_initialize_method\"(v104, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv108 = 0 | 1;\n\t*([2021AA1]) = v108;\n\tgoto L_005D;\n\tv113 = *([v109 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tgoto L_005D;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v109, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv117 = HutongGames.PlayMaker.FsmLog;\nL_005D:\n\tv122 = ~v120.<LoggingEnabled>k__BackingField;\n\tif (v122) goto L_006E;\n\tv124 = eventTarget == 0;\n\tif (v124) goto L_0113;\n\tv127 = eventTarget.target == 0;\n\tif (v127) goto L_0070;\n\tv160 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tv162 = v160 == 0;\n\tif (v162) goto L_00B9;\n\tv158 = this.activeState;\n\tHutongGames.PlayMaker.FsmLog::LogSendEvent(v160, this.activeState, v155, eventTarget);\n\tgoto L_0070;\nL_006E:\n\tv125 = eventTarget == 0;\n\tif (v125) goto L_0113;\nL_0070:\n\tv164 = v158.target;\n\tv165 = v158.target < 6;\n\tv166 = ~v165;\n\tv167 = v158.target - 6;\n\tv169 = v167 == 0;\n\tv174 = ~v169;\n\tv175 = v166 & v174;\n\tif (v175) goto L_0133;\n\tv179 = 0x1818000 + 0x2C0;\n\tv181 = *([v179 @ X9_v4 (System.Int32)+v164 @ X8_v27 (HutongGames.PlayMaker.FsmEventTarget+EventTarget)*4]) + v179;\n\t// 129 IndirectJump v181 @ X8_v29, v116 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmLog>), v116 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmLog>), this.activeState (HutongGames.PlayMaker.FsmState), v155 @ X2_v3 (HutongGames.PlayMaker.FsmEvent), this.activeState (HutongGames.PlayMaker.FsmState), 0, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tX0 = X19;\n\tgoto L_00E3;\n\tX0 = *([X21+18]);\n\tif (TEMP) goto L_00B9;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX2 = X0 & 1;\n\tX0 = X19;\n\tX1 = X20;\n\tHutongGames.PlayMaker.Fsm::BroadcastEvent(X0, X1, X2, X3);\n\tgoto L_0133;\n\tX1 = *([X21+20]);\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX8 = *([X21+28]);\n\tX21 = X0;\n\tif (TEMP) goto L_0113;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmString::get_Value(X0, X1);\n\tX1 = X21;\n\tX2 = X0;\n\tX3 = X20;\n\tHutongGames.PlayMaker.Fsm::SendEventToFsmOnGameObject(X0, X1, X2, X3, X4);\n\tgoto L_0133;\n\tX8 = *([1EAB010]);\n\tX22 = *([X21+38]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00AA;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AA;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AA:\n\tX0 = X22;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0133;\n\tX0 = *([X21+38]);\n\tif (TEMP) goto L_00B9;\n\tX1 = 0;\n\tX0 = PlayMakerFSM::get_Fsm(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E3;\nL_00B9:\n\tthrow System.NullReferenceException;\n\tgoto L_00C9;\n\tv329 = *([v315 @ X8_v31+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_00C9;\n\tv338 = v315;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v338, v134, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00C9:\n\tv137 = HutongGames.PlayMaker.Fsm::GetEventDataSentByInfo(v332);\n\tv145 = v75.sendToChildren;\n\tv140 = v145 == 0;\n\tif (v140) goto L_0113;\n\tv138 = HutongGames.PlayMaker.FsmBool::get_Value(v145, 0);\n\tv146 = v75.excludeSelf;\n\tv141 = v146 == 0;\n\tif (v141) goto L_0113;\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(v146, 0);\n\tHutongGames.PlayMaker.Fsm::BroadcastEventToGameObject(this, v304, fsmEvent, v137, v138, v343, v36);\n\tgoto L_0133;\n\tX0 = *([X19+90]);\n\tif (TEMP) goto L_0133;\nL_00E3:\n\tX1 = X20;\n\tX2 = 0;\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(X0, X1, X2, X3);\n\tgoto L_0133;\n\tX0 = X19;\n\tX0 = HutongGames.PlayMaker.Fsm::get_SubFsmList(X0, X1);\n\tX8 = *([1EECD40]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F006A0]);\n\tX1 = X22;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tSystem.Collections.Generic.List`1::.ctor /* +17 sharing this address */(X0, X1, X2);\n\tif (TEMP) goto L_0113;\n\tX8 = *([1EA4300]);\n\tX0 = X21;\n\tX1 = *([X8]);\n\tX8 = &stack[8];\n\tX0 = System.Collections.Generic.List`1::GetEnumerator /* +104 sharing this address */(X0, X1);\n\tX21 = *([1EDAC48]);\nL_00FF:\n\tX1 = *([X21]);\n\tX0 = &stack[8];\n\tX0 = 0xEF9AB0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_010C;\n\tX0 = stack[18];\n\tif (TEMP) goto L_0114;\n\tX1 = X20;\n\tX2 = 0;\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(X0, X1, X2, X3);\n\tgoto L_00FF;\nL_010C:\n\tX8 = 0x1EFF000;\n\tX8 = *([1EFFFC0]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0133;\nL_0113:\n\tv150 = new System.NullReferenceException();\nL_0114:\n\tthrow v150;\n\tgoto L_0120;\n\tgoto L_0120;\nL_0120:\n\tv187 = v133 != 1;\n\tif (v187) goto L_0160;\n\tv305 = 0x6D2BC0(v177, v133, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv229 = *([v305 @ X0_v31]);\n\tv319 = 0x6D2490(v305, v133, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv223 = 0xEF9AAC(&v53 @ stack_-58_v1, Il2CppMethodInfo, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv339 = v229 == 0;\n\tv226 = ~v339;\n\tif (v226) goto L_0164;\nL_0133:\n\tgoto L_013A;\n\tv291 = *([v235 @ X0_v11+E0]);\n\tv292 = v291 == 0;\n\tv293 = ~v292;\n\tif (v293) goto L_013A;\n\tv295 = \"il2cpp_codegen_runtime_class_init\"(v235, v219, v217, v215, v213, v182, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_013A:\n\tv299 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv255 = v299 == this;\n\tif (v255) goto L_015F;\n\tgoto L_0151;\n\tv323 = *([v307 @ X0_v16+E0]);\n\tv324 = v323 == 0;\n\tv325 = ~v324;\n\tif (v325) goto L_0151;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v307, v219, v217, v215, v213, v182, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0151:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\nL_015F:\n\treturn;\nL_0160:\n\tv306 = 0x6D2380(v177, v133, fsmEvent, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0164:\n\tthrow System.TypeLoadException;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(FsmEventTarget eventTarget, FsmEvent fsmEvent)
		{
			//IL_01db: Expected I, but got O
			//IL_015d: Expected O, but got I
			//IL_00a3: Expected I, but got O
			SetEventDataSentByInfo();
			IntPtr intPtr = (IntPtr)typeof(FsmLog);
			FsmState fsmState = default(FsmState);
			if (FsmLog.LoggingEnabled)
			{
				if (eventTarget != null)
				{
					if (eventTarget.target != FsmEventTarget.EventTarget.Self)
					{
						FsmLog fsmLog = MyLog;
						if (fsmLog == null)
						{
							goto IL_0167;
						}
						fsmState = activeState;
						FsmEvent fsmEvent2 = default(FsmEvent);
						fsmLog.LogSendEvent(activeState, fsmEvent2, eventTarget);
						intPtr = (IntPtr)fsmLog;
					}
					goto IL_00c5;
				}
			}
			else if (eventTarget != null)
			{
				goto IL_00c5;
			}
			NullReferenceException ex = new NullReferenceException();
			throw ex;
			IL_00c5:
			FsmEventTarget.EventTarget target = ((FsmEventTarget)(object)fsmState).target;
			bool flag = ((FsmEventTarget)(object)fsmState).target < FsmEventTarget.EventTarget.SubFSMs;
			bool flag2 = !flag;
			int num = (int)(((FsmEventTarget)(object)fsmState).target - 6);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 704;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X9_v4 (System.Int32)+v164 @ X8_v27 (HutongGames.PlayMaker.FsmEventTarget+EventTarget)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v181 @ X8_v29 (should have been resolved before IL gen)");
				goto IL_0167;
			}
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			if (executingFsm != this)
			{
				FsmExecutionStack.PushFsm(this);
				UpdateStateChanges();
				FsmExecutionStack.PopFsm();
			}
			return;
			IL_0167:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000405")]
		[Address(RVA = "0x9DFC58", Offset = "0x9DFC58", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EECD88]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsmEventName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A63]) = v41;\nL_0017:\n\tv44 = System.String::IsNullOrEmpty(fsmEventName);\n\tv46 = v44 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_003F;\n\tgoto L_002A;\n\tv67 = *([v50 @ X0_v5+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v50, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv57 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tv59 = v57 == 0;\n\tif (v59) goto L_003F;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v57);\n\treturn;\nL_003F:\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(string fsmEventName)
		{
			if (!string.IsNullOrEmpty(fsmEventName))
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
				if (fsmEvent != null)
				{
					Event(EventTarget, fsmEvent);
				}
			}
		}

		[Token(Token = "0x6000406")]
		[Address(RVA = "0x9D7D3C", Offset = "0x9D7D3C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = fsmEvent == 0;\n\tif (v2) goto L_0007;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, fsmEvent);\n\treturn;\nL_0007:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Event(FsmEvent fsmEvent)
		{
			if (fsmEvent != null)
			{
				Event(EventTarget, fsmEvent);
			}
		}

		[Token(Token = "0x6000407")]
		[Address(RVA = "0x9DFD04", Offset = "0x9DFD04", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EF42D0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsmEvent, methodInfo, v30, v31, v32, v33, v34, delay, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A64]) = v44;\nL_001A:\n\tv48 = new HutongGames.PlayMaker.DelayedEvent();\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(v48, this, fsmEvent, delay);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Add(this.delayedEvents, v48);\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent DelayedEvent(FsmEvent fsmEvent, float delay)
		{
			DelayedEvent delayedEvent = new DelayedEvent(this, fsmEvent, delay);
			DelayedEvents.Add(delayedEvent);
			return delayedEvent;
		}

		[Token(Token = "0x6000408")]
		[Address(RVA = "0x9DFDA4", Offset = "0x9DFDA4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1ED4BB0]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, eventTarget, fsmEvent, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021A65]) = v47;\nL_001C:\n\tv51 = new HutongGames.PlayMaker.DelayedEvent();\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(v51, this, fsmEvent, delay);\n\tv51.eventTarget = eventTarget;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.DelayedEvent>::Add(this.delayedEvents, v51);\n\treturn v51;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent DelayedEvent(FsmEventTarget eventTarget, FsmEvent fsmEvent, float delay)
		{
			DelayedEvent delayedEvent = new DelayedEvent(this, fsmEvent, delay);
			delayedEvent.eventTarget = eventTarget;
			DelayedEvents.Add(delayedEvent);
			return delayedEvent;
		}

		[Token(Token = "0x6000409")]
		[Address(RVA = "0x9DFE4C", Offset = "0x9DFE4C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EEF900]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsmEventName, excludeSelf, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A66]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(fsmEventName);\n\tv49 = v47 == 0;\n\tif (v49) goto L_002B;\n\treturn;\nL_002B:\n\tgoto L_0033;\n\tv84 = *([v58 @ X0_v4+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0033;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v58, v46, excludeSelf, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0033:\n\tv91 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tHutongGames.PlayMaker.Fsm::BroadcastEvent(this, v91, excludeSelf);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BroadcastEvent(string fsmEventName, bool excludeSelf = false)
		{
			if (!string.IsNullOrEmpty(fsmEventName))
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
				BroadcastEvent(fsmEvent, excludeSelf);
			}
		}

		[Token(Token = "0x600040A")]
		[Address(RVA = "0x9DF9DC", Offset = "0x9DF9DC", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv32 = *([1EBB938]);\n\tv33 = *([v32 @ X8_v37]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, fsmEvent, excludeSelf, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021A67]) = v50;\nL_0023:\n\tgoto L_0029;\n\tv60 = *([v56 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0029;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, fsmEvent, excludeSelf, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0029:\n\tv67 = HutongGames.PlayMaker.Fsm::GetEventDataSentByInfo();\n\tgoto L_003C;\n\tv75 = *([v71 @ X8_v7+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_003C;\n\tv86 = v71;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v86, fsmEvent, excludeSelf, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_003C:\n\tgoto L_0047;\n\tv88 = *([1EE93F0]);\n\tv89 = *([v88 @ X8_v33]);\n\tv90 = \"il2cpp_codegen_initialize_method\"(v89, fsmEvent, excludeSelf, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv93 = 0 | 1;\n\t*([2021A8F]) = v93;\nL_0047:\n\tgoto L_0053;\n\tv98 = *([v94 @ X0_v7 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tgoto L_0053;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v94, fsmEvent, excludeSelf, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv102 = PlayMakerFSM;\nL_0053:\n\tv110 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v110, v106.fsmList);\n\tv117 = v110 == 0;\n\tif (v117) goto L_00AD;\n\tv124 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v110);\nL_006C:\n\tv224 = 0xEF9AB0(&v123 @ stack_-88_v3 (System.Int32), Il2CppMethodInfo, v203, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\n\tv235 = v224 & 1;\n\tv236 = v235 == 0;\n\tif (v236) goto L_00A7;\n\tgoto L_007E;\n\tv263 = *([v239 @ X0_v30+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_007E;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v239, v222, v203, methodInfo, v36, v37, v38, v39, v156, v41, v42, v43, v44, v45, v46, v47);\nL_007E:\n\tv212 = UnityEngine.Object::op_Equality(v176, 0);\n\tv273 = v212 == 0;\n\tv217 = ~v273;\n\tif (v217) goto L_006C;\n\tv213 = PlayMakerFSM::get_Fsm(v176);\n\tv218 = v213 == 0;\n\tif (v218) goto L_006C;\n\tv219 = excludeSelf == 0;\n\tif (v219) goto L_009C;\n\tv214 = PlayMakerFSM::get_Fsm(v176);\n\tv192 = v214 == this;\n\tif (v192) goto L_006C;\nL_009C:\n\tv215 = PlayMakerFSM::get_Fsm(v176);\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(v215, fsmEvent, v67);\n\tgoto L_006C;\nL_00A7:\n\tv247 = 0xEF9AAC(&v123 @ stack_-88_v3 (System.Int32), Il2CppMethodInfo, v203, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00D5;\n\tv337 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00AD:\n\tv174 = new System.NullReferenceException();\n\tgoto L_00BE;\n\tgoto L_00BE;\n\tgoto L_00BE;\n\tgoto L_00BE;\n\tgoto L_00BE;\n\tgoto L_00BE;\n\tgoto L_00BE;\nL_00BE:\n\tv234 = v161 != 1;\n\tif (v234) goto L_00D6;\n\tv237 = 0x6D2BC0(v174, v161, 0, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\n\tv249 = 0x6D2490(v237, v161, 0, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\n\tv253 = 0xEF9AAC(&v151 @ stack_-70_v3 (System.Int32), Il2CppMethodInfo, 0, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\n\tv306 = *([v237 @ X0_v19]) == 0;\n\tv255 = ~v306;\n\tif (v255) goto L_00DA;\nL_00D5:\n\treturn;\nL_00D6:\n\tv238 = 0x6D2380(v174, v161, 0, methodInfo, v36, v37, v38, v39, v123, v41, v42, v43, v44, v45, v46, v47);\nL_00DA:\n\tthrow System.TypeLoadException;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BroadcastEvent(FsmEvent fsmEvent, bool excludeSelf = false)
		{
			//IL_01d5: Expected I4, but got O
			//IL_002b: Expected O, but got I
			//IL_0066: Expected O, but got I4
			//IL_0099: Expected O, but got I4
			//IL_00e5: Expected O, but got I4
			FsmEventData eventDataSentByInfo = GetEventDataSentByInfo();
			List<PlayMakerFSM> list = new List<PlayMakerFSM>((int)PlayMakerFSM.fsmList);
			bool flag = list == null;
			int num2 = default(int);
			int num = num2;
			if (!flag)
			{
				List<PlayMakerFSM>.Enumerator enumerator = list.GetEnumerator();
				object obj = 0;
				object obj2 = default(object);
				UnityEngine.Object obj3 = default(UnityEngine.Object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					bool flag2 = obj3 == null;
					bool flag3 = !flag2;
					bool flag4 = !flag3;
					obj = 0;
					if (flag4)
					{
						continue;
					}
					Fsm fsm = ((PlayMakerFSM)obj3).Fsm;
					bool flag5 = fsm == null;
					obj = 0;
					if (flag5)
					{
						continue;
					}
					if (excludeSelf)
					{
						Fsm fsm2 = ((PlayMakerFSM)obj3).Fsm;
						bool flag6 = fsm2 == this;
						obj = 0;
						if (flag6)
						{
							continue;
						}
					}
					Fsm fsm3 = ((PlayMakerFSM)obj3).Fsm;
					fsm3.ProcessEvent(fsmEvent, eventDataSentByInfo);
					obj = eventDataSentByInfo;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IEnumerable<PlayMakerFSM> enumerable = default(IEnumerable<PlayMakerFSM>);
			if ((IntPtr)enumerable == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				object obj4 = default(object);
				if (obj4 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600040B")]
		[Address(RVA = "0x9DFEF4", Offset = "0x9DFEF4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1EBB210]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, go, fsmEventName, sendToChildren, excludeSelf, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021A68]) = v50;\nL_001D:\n\tv53 = System.String::IsNullOrEmpty(fsmEventName);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0031;\n\treturn;\nL_0031:\n\tgoto L_0039;\n\tv105 = *([v66 @ X0_v4+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0039;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v66, v52, fsmEventName, sendToChildren, excludeSelf, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0039:\n\tv124 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tgoto L_0048;\n\tv121 = *([v100 @ X8_v9+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0048;\n\tv127 = v100;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v127, v113, fsmEventName, sendToChildren, excludeSelf, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0048:\n\tv126 = HutongGames.PlayMaker.Fsm::GetEventDataSentByInfo();\n\tHutongGames.PlayMaker.Fsm::BroadcastEventToGameObject(this, go, v124, v126, sendToChildren, excludeSelf);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BroadcastEventToGameObject(GameObject go, string fsmEventName, bool sendToChildren, bool excludeSelf = false)
		{
			if (!string.IsNullOrEmpty(fsmEventName))
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
				FsmEventData eventDataSentByInfo = GetEventDataSentByInfo();
				BroadcastEventToGameObject(go, fsmEvent, eventDataSentByInfo, sendToChildren, excludeSelf);
			}
		}

		[Token(Token = "0x600040C")]
		[Address(RVA = "0x9DF1B4", Offset = "0x9DF1B4", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv44 = *([1EFBA80]);\n\tv45 = *([v44 @ X8_v56]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, go, fsmEvent, eventData, sendToChildren, excludeSelf, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2021A69]) = v59;\nL_002C:\n\tgoto L_0035;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0035;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, go, fsmEvent, eventData, sendToChildren, excludeSelf, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0035:\n\tv82 = UnityEngine.Object::op_Equality(go, 0);\n\tv84 = v82 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0167;\n\tv90 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::.ctor(v90);\n\tgoto L_0054;\n\tv278 = *([v274 @ X0_v9+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tif (v280) goto L_0054;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v274, v209, v81, eventData, sendToChildren, excludeSelf, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0054:\n\tgoto L_005F;\n\tv290 = *([1EE93F0]);\n\tv291 = *([v290 @ X8_v50]);\n\tv292 = \"il2cpp_codegen_initialize_method\"(v291, v209, v81, eventData, sendToChildren, excludeSelf, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv295 = 0 | 1;\n\t*([2021A8F]) = v295;\nL_005F:\n\tgoto L_006E;\n\tv300 = *([v296 @ X0_v12 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv301 = v300 == 0;\n\tv302 = ~v301;\n\t// 99 Jump @b98\n\tv310 = \"il2cpp_codegen_runtime_class_init\"(v296, v209, v81, eventData, sendToChildren, excludeSelf, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv304 = PlayMakerFSM;\nL_006E:\n\tv316 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v307.fsmList);\nL_0077:\n\tv424 = 0xEF9AB0(&v315 @ stack_-B8_v5, Il2CppMethodInfo, v481, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv426 = v424 & 1;\n\tv427 = v426 == 0;\n\tif (v427) goto L_00B4;\n\tgoto L_0089;\n\tv461 = *([v452 @ X0_v54+E0]);\n\tv462 = v461 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_0089;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v452, v422, v402, eventData, sendToChildren, excludeSelf, methodInfo, v48, v353, v50, v51, v52, v53, v54, v55, v56);\nL_0089:\n\tv411 = UnityEngine.Object::op_Inequality(v352, 0);\n\tv415 = v411 == 0;\n\tif (v415) goto L_0077;\n\tv515 = UnityEngine.Component::get_gameObject(v352);\n\tgoto L_00A0;\n\tv547 = *([v538 @ X0_v69+E0]);\n\tv548 = v547 == 0;\n\tv549 = ~v548;\n\tif (v549) goto L_00A0;\n\tv551 = \"il2cpp_codegen_runtime_class_init\"(v538, v514, v403, eventData, sendToChildren, excludeSelf, methodInfo, v48, v353, v50, v51, v52, v53, v54, v55, v56);\nL_00A0:\n\tv412 = UnityEngine.Object::op_Equality(v515, go);\n\tv416 = v412 == 0;\n\tif (v416) goto L_0077;\n\tv543 = PlayMakerFSM::get_Fsm(v352);\n\tv417 = v90 == 0;\n\tif (v417) goto L_00BC;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::Add(v90, v543);\n\tgoto L_0077;\nL_00B4:\n\tv460 = 0xEF9AAC(&v315 @ stack_-B8_v5, Il2CppMethodInfo, v481, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv468 = v90 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_00E1;\n\tgoto L_0159;\n\tthrow System.NullReferenceException;\nL_00BC:\n\tv392 = new System.NullReferenceException();\n\tgoto L_00CD;\n\tgoto L_00CD;\n\tgoto L_00CD;\n\tgoto L_00CD;\n\tgoto L_00CD;\n\tgoto L_00CD;\n\tgoto L_00CD;\nL_00CD:\n\tv362 = 0 != 1;\n\tif (v362) goto L_0169;\n\tv565 = 0x6D2BC0(v392, 0, 0, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv568 = 0x6D2490(v565, 0, 0, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv485 = 0xEF9AAC(&v315 @ stack_-B8_v5, Il2CppMethodInfo, 0, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv575 = *([v565 @ X0_v61]) == 0;\n\tv570 = ~v575;\n\tif (v570) goto L_010C;\nL_00E1:\n\tv495 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::GetEnumerator(v90);\nL_00EA:\n\tv537 = 0xEF9AB0(&v315 @ stack_-B8_v5, Il2CppMethodInfo, v481, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tv545 = v537 & 1;\n\tv546 = v545 == 0;\n\tif (v546) goto L_0108;\n\tv518 = v352 != this;\n\tif (v518) goto L_0102;\n\tv561 = excludeSelf == 0;\n\tv534 = ~v561;\n\tif (v534) goto L_00EA;\nL_0102:\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(v352, fsmEvent, eventData);\n\tgoto L_00EA;\nL_0108:\n\tv180 = 0xEF9AAC(&v315 @ stack_-B8_v5, Il2CppMethodInfo, v481, eventData, sendToChildren, excludeSelf, methodInfo, v48, v315, v50, v51, v52, v53, v54, v55, v56);\n\tgoto L_0127;\n\tthrow System.NullReferenceException;\nL_010C:\n\tgoto L_016D;\n\tgoto L_010F;\n\tgoto L_010F;\nL_010F:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0169;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFFFC0]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_016A;\nL_0127:\n\tv184 = sendToChildren == 0;\n\tif (v184) goto L_0167;\n\tv587 = UnityEngine.GameObject::get_transform(go);\nL_0132:\n\tv181 = UnityEngine.Transform::get_childCount(v587);\n\tv110 = v194 >= v181;\n\tif (v110) goto L_0167;\n\tv343 = UnityEngine.GameObject::get_transform(go);\n\tv344 = UnityEngine.Transform::GetChild(v343, v194);\n\tv591 = UnityEngine.Component::get_gameObject(v344);\n\tHutongGames.PlayMaker.Fsm::BroadcastEventToGameObject(this, v591, fsmEvent, eventData, 1, excludeSelf);\n\tv194 = v194 + 1;\n\tv587 = UnityEngine.GameObject::get_transform(go);\n\tv595 = v587 == 0;\n\tv506 = ~v595;\n\tif (v506) goto L_0132;\nL_0159:\n\tthrow System.NullReferenceException;\nL_0167:\n\treturn;\n\tv350 = new System.NullReferenceException();\nL_0169:\n\tv398 = 0x6D2380(v391, v389, v387, v356, v357, v358, methodInfo, v48, v383, v50, v51, v52, v53, v54, v55, v56);\nL_016A:\n\t;\nL_016D:\n\tthrow System.TypeLoadException;\n// 221 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BroadcastEventToGameObject(GameObject go, FsmEvent fsmEvent, FsmEventData eventData, bool sendToChildren, bool excludeSelf = false)
		{
			//IL_0067: Expected I, but got O
			//IL_0093: Expected I, but got O
			//IL_024d: Expected I, but got O
			//IL_00d8: Expected I, but got O
			//IL_0107: Expected I, but got O
			if (go == null)
			{
				return;
			}
			List<Fsm> list = new List<Fsm>();
			List<PlayMakerFSM>.Enumerator enumerator = PlayMakerFSM.fsmList.GetEnumerator();
			IntPtr intPtr = (IntPtr)null;
			object obj = default(object);
			Fsm fsm = default(Fsm);
			object obj2 = default(object);
			object obj3 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					bool flag = (UnityEngine.Object)(object)fsm != null;
					bool flag2 = !flag;
					intPtr = (IntPtr)null;
					if (flag2)
					{
						continue;
					}
					GameObject gameObject = ((Component)(object)fsm).gameObject;
					bool flag3 = gameObject == go;
					bool flag4 = !flag3;
					intPtr = (IntPtr)null;
					if (flag4)
					{
						continue;
					}
					Fsm fsm2 = ((PlayMakerFSM)(object)fsm).Fsm;
					bool flag5 = list == null;
					intPtr = (IntPtr)null;
					if (!flag5)
					{
						list.Add(fsm2);
						intPtr = (IntPtr)0;
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if (0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
					if (obj2 != null)
					{
						break;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
					if (list == null)
					{
						goto IL_033b;
					}
				}
				List<Fsm>.Enumerator enumerator2 = list.GetEnumerator();
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj3 & 1L) == 0)
					{
						break;
					}
					if (fsm != this || !excludeSelf)
					{
						fsm.ProcessEvent(fsmEvent, eventData);
						intPtr = (IntPtr)eventData;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				if (!sendToChildren)
				{
					return;
				}
				Transform transform = go.transform;
				int num = 0;
				do
				{
					int childCount = transform.childCount;
					if (num < childCount)
					{
						Transform transform2 = go.transform;
						Transform child = transform2.GetChild(num);
						GameObject gameObject2 = child.gameObject;
						BroadcastEventToGameObject(gameObject2, fsmEvent, eventData, sendToChildren: true, excludeSelf);
						num++;
						transform = go.transform;
						continue;
					}
					return;
				}
				while ((object)transform != null);
				goto IL_033b;
				IL_033b:
				throw new NullReferenceException();
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600040D")]
		[Address(RVA = "0x9DFFE8", Offset = "0x9DFFE8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA6988]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, gameObject, fsmName, fsmEventName, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021A6A]) = v44;\nL_0019:\n\tv47 = System.String::IsNullOrEmpty(fsmEventName);\n\tv49 = v47 == 0;\n\tif (v49) goto L_002B;\n\treturn;\nL_002B:\n\tgoto L_0033;\n\tv86 = *([v58 @ X0_v4+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0033;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v58, v46, fsmName, fsmEventName, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0033:\n\tv71 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tHutongGames.PlayMaker.Fsm::SendEventToFsmOnGameObject(v71, gameObject, fsmName, v71);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendEventToFsmOnGameObject(GameObject gameObject, string fsmName, string fsmEventName)
		{
			if (!string.IsNullOrEmpty(fsmEventName))
			{
				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(fsmEventName);
				((Fsm)(object)fsmEvent).SendEventToFsmOnGameObject(gameObject, fsmName, fsmEvent);
			}
		}

		[Token(Token = "0x600040E")]
		[Address(RVA = "0x9DF5BC", Offset = "0x9DF5BC", Length = "0x420")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1ED2F20]);\n\tv35 = *([v34 @ X8_v65]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, gameObject, fsmName, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([2021A6B]) = v52;\nL_0024:\n\tgoto L_002D;\n\tv62 = *([v58 @ X0_v2+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002D;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v58, gameObject, fsmName, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_002D:\n\tv72 = UnityEngine.Object::op_Equality(gameObject, 0);\n\tv74 = v72 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0162;\n\tgoto L_003E;\n\tv173 = *([v78 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_003E;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v78, v70, v71, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_003E:\n\tHutongGames.PlayMaker.Fsm::SetEventDataSentByInfo();\n\tgoto L_004F;\n\tv238 = *([v234 @ X0_v9+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_004F;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v234, v70, v71, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_004F:\n\tgoto L_005A;\n\tv250 = *([1EE93F0]);\n\tv251 = *([v250 @ X8_v58]);\n\tv252 = \"il2cpp_codegen_initialize_method\"(v251, v70, v71, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv255 = 0 | 1;\n\t*([2021A8F]) = v255;\nL_005A:\n\tgoto L_0066;\n\tv260 = *([v256 @ X0_v12 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv261 = v260 == 0;\n\tv262 = ~v261;\n\tgoto L_0066;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v256, v70, v71, fsmEvent, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv264 = PlayMakerFSM;\nL_0066:\n\tv271 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v271, v268.fsmList);\n\tv280 = System.String::IsNullOrEmpty(fsmName);\n\tv282 = v280 == 0;\n\tif (v282) goto L_00E0;\n\tv331 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v271);\nL_0083:\n\tv426 = 0xEF9AB0(&v312 @ stack_-88_v11, Il2CppMethodInfo, v450, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv467 = v426 & 1;\n\tv468 = v467 == 0;\n\tif (v468) goto L_012E;\n\tgoto L_0095;\n\tv514 = *([v497 @ X0_v70+E0]);\n\tv515 = v514 == 0;\n\tv516 = ~v515;\n\tif (v516) goto L_0095;\n\tv518 = \"il2cpp_codegen_runtime_class_init\"(v497, v424, v405, fsmEvent, methodInfo, v38, v39, v40, v310, v42, v43, v44, v45, v46, v47, v48);\nL_0095:\n\tv414 = UnityEngine.Object::op_Inequality(v369, 0);\n\tv418 = v414 == 0;\n\tif (v418) goto L_0083;\n\tv533 = UnityEngine.Component::get_gameObject(v369);\n\tgoto L_00AC;\n\tv554 = *([v540 @ X0_v84+E0]);\n\tv555 = v554 == 0;\n\tv556 = ~v555;\n\tif (v556) goto L_00AC;\n\tv558 = \"il2cpp_codegen_runtime_class_init\"(v540, v532, v406, fsmEvent, methodInfo, v38, v39, v40, v310, v42, v43, v44, v45, v46, v47, v48);\nL_00AC:\n\tv415 = UnityEngine.Object::op_Equality(v533, gameObject);\n\tv419 = v415 == 0;\n\tif (v419) goto L_0083;\n\tv416 = PlayMakerFSM::get_Fsm(v369);\n\tv420 = v416 == 0;\n\tif (v420) goto L_00BB;\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(v416, fsmEvent, 0);\n\tgoto L_0083;\n\tv535 = new System.NullReferenceException();\nL_00BB:\n\tv592 = new System.NullReferenceException();\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\n\tgoto L_00CC;\nL_00CC:\n\tv285 = 0 != 1;\n\tif (v285) goto L_0163;\n\tv572 = 0x6D2BC0(v592, 0, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv599 = 0x6D2490(v572, 0, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv320 = 0xEF9AAC(&v312 @ stack_-88_v11, Il2CppMethodInfo, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv604 = *([v572 @ X0_v76]) == 0;\n\tv322 = ~v604;\n\tif (v322) goto L_0136;\nL_00E0:\n\tv367 = System.Collections.Generic.List`1<PlayMakerFSM>::GetEnumerator(v271);\nL_00E9:\n\tv466 = 0xEF9AB0(&v312 @ stack_-88_v11, Il2CppMethodInfo, v450, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv495 = v466 & 1;\n\tv496 = v495 == 0;\n\tif (v496) goto L_012E;\n\tgoto L_00FB;\n\tv521 = *([v510 @ X0_v40+E0]);\n\tv522 = v521 == 0;\n\tv523 = ~v522;\n\tif (v523) goto L_00FB;\n\tv525 = \"il2cpp_codegen_runtime_class_init\"(v510, v464, v450, fsmEvent, methodInfo, v38, v39, v40, v134, v42, v43, v44, v45, v46, v47, v48);\nL_00FB:\n\tv455 = UnityEngine.Object::op_Inequality(v369, 0);\n\tv459 = v455 == 0;\n\tif (v459) goto L_00E9;\n\tv538 = UnityEngine.Component::get_gameObject(v369);\n\tgoto L_0112;\n\tv561 = *([v550 @ X0_v48+E0]);\n\tv562 = v561 == 0;\n\tv563 = ~v562;\n\tif (v563) goto L_0112;\n\tv565 = \"il2cpp_codegen_runtime_class_init\"(v550, v537, v350, fsmEvent, methodInfo, v38, v39, v40, v134, v42, v43, v44, v45, v46, v47, v48);\nL_0112:\n\tv456 = UnityEngine.Object::op_Equality(v538, gameObject);\n\tv460 = v456 == 0;\n\tif (v460) goto L_00E9;\n\tv392 = PlayMakerFSM::get_Fsm(v369);\n\tv457 = System.String::op_Equality(fsmName, v392.name);\n\tv461 = v457 == 0;\n\tif (v461) goto L_00E9;\n\tv505 = PlayMakerFSM::get_Fsm(v369);\n\tv506 = v505 == 0;\n\tif (v506) goto L_0137;\n\tHutongGames.PlayMaker.Fsm::ProcessEvent(v505, fsmEvent, 0);\nL_012E:\n\tv151 = 0xEF9AAC(&v126 @ stack_-70_v9, Il2CppMethodInfo, v450, fsmEvent, methodInfo, v38, v39, v40, v135, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_0162;\n\tthrow System.NullReferenceException;\n\tv361 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0136:\n\tgoto L_0167;\nL_0137:\n\tv592 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0163;\n\tv608 = 0x6D2BC0(v592, 0, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv609 = 0x6D2490(v608, 0, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv150 = 0xEF9AAC(&v312 @ stack_-88_v11, Il2CppMethodInfo, 0, fsmEvent, methodInfo, v38, v39, v40, v312, v42, v43, v44, v45, v46, v47, v48);\n\tv612 = *([v608 @ X0_v59]) == 0;\n\tv153 = ~v612;\n\tif (v153) goto L_0167;\nL_0162:\n\treturn;\nL_0163:\n\tv597 = 0x6D2380(v592, v590, v450, fsmEvent, methodInfo, v38, v39, v40, v586, v42, v43, v44, v45, v46, v47, v48);\nL_0167:\n\tthrow System.TypeLoadException;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SendEventToFsmOnGameObject(GameObject gameObject, string fsmName, FsmEvent fsmEvent)
		{
			//IL_03a2: Expected I4, but got O
			//IL_020b: Expected I, but got O
			//IL_00b1: Expected I, but got O
			//IL_0250: Expected I, but got O
			//IL_00f6: Expected I, but got O
			//IL_029a: Expected I, but got O
			//IL_0125: Expected I, but got O
			//IL_014b: Expected I, but got O
			//IL_0329: Expected I, but got O
			//IL_02f5: Expected I, but got O
			if (gameObject == null)
			{
				return;
			}
			SetEventDataSentByInfo();
			List<PlayMakerFSM> list = new List<PlayMakerFSM>((int)PlayMakerFSM.fsmList);
			bool flag = string.IsNullOrEmpty(fsmName);
			bool flag2 = !flag;
			IntPtr intPtr = (IntPtr)0;
			if (flag2)
			{
				goto IL_01d2;
			}
			List<PlayMakerFSM>.Enumerator enumerator = list.GetEnumerator();
			intPtr = (IntPtr)0;
			object obj = default(object);
			object obj3 = default(object);
			UnityEngine.Object obj5 = default(UnityEngine.Object);
			UnityEngine.Object obj6;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
				int num = (int)((long)(IntPtr)obj & 1L);
				bool flag3 = num == 0;
				object obj2 = obj3;
				object obj4 = obj3;
				if (flag3)
				{
					break;
				}
				bool flag4 = obj5 != null;
				bool flag5 = !flag4;
				intPtr = (IntPtr)null;
				if (flag5)
				{
					continue;
				}
				GameObject gameObject2 = ((Component)obj5).gameObject;
				bool flag6 = gameObject2 == gameObject;
				bool flag7 = !flag6;
				intPtr = (IntPtr)null;
				if (flag7)
				{
					continue;
				}
				Fsm fsm = ((PlayMakerFSM)obj5).Fsm;
				bool flag8 = fsm == null;
				intPtr = (IntPtr)null;
				obj6 = null;
				if (!flag8)
				{
					fsm.ProcessEvent(fsmEvent);
					intPtr = (IntPtr)null;
					continue;
				}
				goto IL_0150;
			}
			goto IL_02fa;
			IL_0150:
			NullReferenceException ex = new NullReferenceException();
			bool flag9 = 0 != 1;
			object obj7 = obj3;
			if (flag9)
			{
				goto IL_037f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
			object obj8 = default(object);
			if (obj8 == null)
			{
				goto IL_01d2;
			}
			goto IL_0445;
			IL_02a8:
			Fsm fsm2 = ((PlayMakerFSM)obj5).Fsm;
			if (fsm2 != null)
			{
				fsm2.ProcessEvent(fsmEvent);
				object obj2 = obj3;
				object obj4 = obj3;
				intPtr = (IntPtr)null;
				goto IL_02fa;
			}
			ex = new NullReferenceException();
			obj7 = obj3;
			intPtr = (IntPtr)null;
			obj6 = null;
			goto IL_037f;
			IL_01d2:
			List<PlayMakerFSM>.Enumerator enumerator2 = list.GetEnumerator();
			object obj9 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
				int num2 = (int)((long)(IntPtr)obj9 & 1L);
				bool flag10 = num2 == 0;
				object obj2 = obj3;
				object obj4 = obj3;
				if (flag10)
				{
					break;
				}
				bool flag11 = obj5 != null;
				bool flag12 = !flag11;
				intPtr = (IntPtr)null;
				if (flag12)
				{
					continue;
				}
				GameObject gameObject3 = ((Component)obj5).gameObject;
				bool flag13 = gameObject3 == gameObject;
				bool flag14 = !flag13;
				intPtr = (IntPtr)null;
				if (flag14)
				{
					continue;
				}
				Fsm fsm3 = ((PlayMakerFSM)obj5).Fsm;
				bool flag15 = fsmName == fsm3.Name;
				bool flag16 = !flag15;
				intPtr = (IntPtr)null;
				if (flag16)
				{
					continue;
				}
				goto IL_02a8;
			}
			goto IL_02fa;
			IL_0445:
			throw new TypeLoadException();
			IL_037f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			goto IL_0445;
			IL_02fa:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
		}

		[Token(Token = "0x600040F")]
		[Address(RVA = "0x9E0090", Offset = "0x9E0090", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.Fsm::GetState(this, stateName);\n\tHutongGames.PlayMaker.Fsm::SwitchState(this, v10);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetState(string stateName)
		{
			FsmState state = GetState(stateName);
			SwitchState(state);
		}

		[Token(Token = "0x6000410")]
		[Address(RVA = "0x9D8168", Offset = "0x9D8168", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F08998]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021A6C]) = v44;\nL_0017:\n\tv46 = this.switchToState == 0;\n\tif (v46) goto L_0048;\nL_0024:\n\tgoto L_002D;\n\tv125 = *([v75 @ X0_v15+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tgoto L_002D;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v75, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tgoto L_0035;\n\tv175 = v52;\n\tv176 = \"il2cpp_codegen_initialize_method\"(v175, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t*([2021AA3]) = v51;\nL_0035:\n\tgoto L_003E;\n\tv211 = *([v178 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tgoto L_003E;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v178, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv214 = HutongGames.PlayMaker.Fsm;\nL_003E:\n\tv218 = ~v217.<HitBreakpoint>k__BackingField;\n\tv65 = ~v218;\n\tif (v65) goto L_0048;\n\tHutongGames.PlayMaker.Fsm::SwitchState(this, this.switchToState);\n\tv227 = this.switchToState == 0;\n\tv64 = ~v227;\n\tif (v64) goto L_0024;\nL_0048:\n\tv149 = this.states;\nL_004D:\n\tv151 = v150 < v149.Length;\n\tv105 = ~v151;\n\tv81 = v150 >= v149.Length;\n\tif (v81) goto L_0067;\n\tif (v105) goto L_0071;\n\tHutongGames.PlayMaker.FsmState::ResetLoopCount(v149[v150 @ X20_v7 (System.Int32)]);\n\tv149 = this.states;\n\tv150 = v150 + 1;\n\tv228 = this.states == 0;\n\tv118 = ~v228;\n\tif (v118) goto L_004D;\n\tthrow System.NullReferenceException;\nL_0067:\n\tthis.<EventTarget>k__BackingField = 0;\n\treturn;\nL_0071:\n\tv221 = new System.IndexOutOfRangeException();\n\tthrow v221;\n\tthrow System.NullReferenceException;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateStateChanges()
		{
			if (switchToState != null)
			{
				while (!HitBreakpoint)
				{
					SwitchState(switchToState);
					if (switchToState != null)
					{
						continue;
					}
					break;
				}
			}
			FsmState[] array = States;
			int num = 0;
			while (true)
			{
				bool flag = num < array.Length;
				bool flag2 = !flag;
				if (num < array.Length)
				{
					if (flag2)
					{
						break;
					}
					array[num].ResetLoopCount();
					array = States;
					num++;
					if (States == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				EventTarget = null;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000411")]
		[Address(RVA = "0x9DECC4", Offset = "0x9DECC4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC4E50]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, transition, isGlobal, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021A6D]) = v46;\nL_001B:\n\tv49 = transition.toFsmState == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tthis.<LastTransition>k__BackingField = transition;\n\tgoto L_002E;\n\tv83 = *([1EFA290]);\n\tv84 = *([v83 @ X8_v19]);\n\tv85 = \"il2cpp_codegen_initialize_method\"(v84, transition, isGlobal, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv88 = 0 | 1;\n\t*([2021711]) = v88;\nL_002E:\n\tv93 = ~v92.<IsEditor>k__BackingField;\n\tif (v93) goto L_0046;\n\tv60 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tv170 = isGlobal == 0;\n\tif (v170) goto L_003E;\n\tv178 = v60 == 0;\n\tv64 = ~v178;\n\tif (v64) goto L_0045;\n\tgoto L_0070;\n\tgoto L_006E;\nL_003E:\n\tv61 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\nL_0045:\n\tHutongGames.PlayMaker.FsmLog::LogTransition(v60, v159, transition);\nL_0046:\n\tthis.switchToState = transition.toFsmState;\n\tgoto L_0055;\n\tv171 = *([v165 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0055;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v165, v57, v53, v51, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv174 = HutongGames.PlayMaker.Fsm;\nL_0055:\n\tv71 = v177.EventData;\n\tv107 = v71.SentByFsm == this;\n\tif (v107) goto L_FFFFFFFF;\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\nL_006E:\n\treturn returnVal2;\nL_0070:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoTransition(FsmTransition transition, bool isGlobal)
		{
			//IL_0123: Expected I4, but got O
			if (transition.ToFsmState != null)
			{
				LastTransition = transition;
				if (PlayMakerGlobals.IsEditor)
				{
					FsmLog fsmLog = MyLog;
					FsmState fromState;
					if (isGlobal)
					{
						bool flag = fsmLog == null;
						bool flag2 = !flag;
						fromState = null;
						if (!flag2)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
					}
					else
					{
						FsmState fsmState = ActiveState;
						fromState = fsmState;
					}
					fsmLog.LogTransition(fromState, transition);
				}
				switchToState = transition.ToFsmState;
				FsmEventData eventData = EventData;
				if (eventData.SentByFsm != this)
				{
					UpdateStateChanges();
				}
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000412")]
		[Address(RVA = "0x9E00B8", Offset = "0x9E00B8", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EB8C38]);\n\tv25 = *([v24 @ X8_v64]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, toState, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A6E]) = v43;\nL_0016:\n\tv44 = toState == 0;\n\tif (v44) goto L_00D6;\n\tv46 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv53 = v46 == 0;\n\tif (v53) goto L_0026;\n\tv117 = ~this.activeStateEntered;\n\tif (v117) goto L_0026;\n\tv126 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::ExitState(this, v126);\nL_0026:\n\tHutongGames.PlayMaker.Fsm::set_ActiveState(this, toState);\n\tgoto L_0037;\n\tv133 = *([v129 @ X0_v6+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0037;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v129, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0037:\n\tgoto L_0042;\n\tv145 = *([1EB3790]);\n\tv146 = *([v145 @ X8_v58]);\n\tv147 = \"il2cpp_codegen_initialize_method\"(v146, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv150 = 0 | 1;\n\t*([2021AA2]) = v150;\nL_0042:\n\tgoto L_004B;\n\tv155 = *([v151 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tgoto L_004B;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v151, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv159 = HutongGames.PlayMaker.Fsm;\nL_004B:\n\tv164 = ~v162.<BreakpointsEnabled>k__BackingField;\n\tif (v164) goto L_0057;\n\tv167 = ~this.EnableBreakpoints;\n\tif (v167) goto L_0057;\n\tv175 = ~toState.isBreakpoint;\n\tv169 = ~v175;\n\tif (v169) goto L_00D7;\nL_0057:\n\tgoto L_0061;\n\tv176 = *([v158 @ X0_v10 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0061;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v158, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0061:\n\tgoto L_006C;\n\tv205 = *([1ED3510]);\n\tv206 = *([v205 @ X8_v51]);\n\tv207 = \"il2cpp_codegen_initialize_method\"(v206, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv210 = 0 | 1;\n\t*([2021AA5]) = v210;\nL_006C:\n\tgoto L_0075;\n\tv215 = *([v211 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tgoto L_0075;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v211, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv219 = HutongGames.PlayMaker.Fsm;\nL_0075:\n\tv224 = ~v222.<StepToStateChange>k__BackingField;\n\tif (v224) goto L_00CD;\n\tgoto L_0084;\n\tv231 = *([v218 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0084;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v218, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0084:\n\tgoto L_008F;\n\tv242 = *([1ED5AF0]);\n\tv243 = *([v242 @ X8_v46]);\n\tv244 = \"il2cpp_codegen_initialize_method\"(v243, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv247 = 0 | 1;\n\t*([2021AA6]) = v247;\nL_008F:\n\tgoto L_0098;\n\tv252 = *([v248 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tgoto L_0098;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v248, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv255 = HutongGames.PlayMaker.Fsm;\nL_0098:\n\tv200 = v258.<StepFsm>k__BackingField == 0;\n\tif (v200) goto L_00D7;\n\tgoto L_00A6;\n\tv263 = *([v198 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_00A6;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v198, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A6:\n\tgoto L_00B1;\n\tv274 = *([1ED5AF0]);\n\tv275 = *([v274 @ X8_v41]);\n\tv276 = \"il2cpp_codegen_initialize_method\"(v275, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv279 = 0 | 1;\n\t*([2021AA6]) = v279;\nL_00B1:\n\tgoto L_00BE;\n\tv284 = *([v280 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tgoto L_00BE;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v280, v94, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv287 = HutongGames.PlayMaker.Fsm;\nL_00BE:\n\tv191 = v289.<StepFsm>k__BackingField == this;\n\tif (v191) goto L_00D7;\nL_00CD:\n\tHutongGames.PlayMaker.Fsm::EnterState(this, toState);\n\treturn;\nL_00D6:\n\treturn;\nL_00D7:\n\tthis.activeStateEntered = 0;\n\tHutongGames.PlayMaker.Fsm::DoBreak(this);\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SwitchState(FsmState toState)
		{
			if (toState != null)
			{
				FsmState fsmState = ActiveState;
				if (fsmState != null && activeStateEntered)
				{
					FsmState state = ActiveState;
					ExitState(state);
				}
				ActiveState = toState;
				if ((!BreakpointsEnabled || !EnableBreakpoints || !toState.IsBreakpoint) && (!StepToStateChange || (StepFsm != null && StepFsm != this)))
				{
					EnterState(toState);
					return;
				}
				activeStateEntered = false;
				DoBreak();
			}
		}

		[Token(Token = "0x6000413")]
		[Address(RVA = "0x9E04EC", Offset = "0x9E04EC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.previousActiveState == 0;\n\tif (v2) goto L_0005;\n\tHutongGames.PlayMaker.Fsm::SwitchState(this, this.previousActiveState);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GotoPreviousState()
		{
			if (PreviousActiveState != null)
			{
				SwitchState(PreviousActiveState);
			}
		}

		[Token(Token = "0x6000414")]
		[Address(RVA = "0x9E0308", Offset = "0x9E0308", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBB000]);\n\tv25 = *([v24 @ X8_v35]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, state, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A6F]) = v43;\nL_0017:\n\tthis.<EventTarget>k__BackingField = 0;\n\tthis.switchToState = 0;\n\tthis.<SwitchedState>k__BackingField = 1;\n\tthis.activeStateEntered = 1;\n\tgoto L_002B;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002B;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, state, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002B:\n\tgoto L_0036;\n\tv63 = *([1EC48C8]);\n\tv64 = *([v63 @ X8_v31]);\n\tv65 = \"il2cpp_codegen_initialize_method\"(v64, state, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv68 = 0 | 1;\n\t*([2021AA1]) = v68;\nL_0036:\n\tgoto L_003F;\n\tv73 = *([v69 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_003F;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v69, state, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv77 = HutongGames.PlayMaker.FsmLog;\nL_003F:\n\tv82 = ~v80.<LoggingEnabled>k__BackingField;\n\tif (v82) goto L_004A;\n\tv85 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogEnterState(v85, state);\nL_004A:\n\tv194 = this.maxLoopCount;\n\tv99 = this.maxLoopCount - 1;\n\tv100 = v99 < 0;\n\tv102 = this.maxLoopCount ^ 1;\n\tv103 = this.maxLoopCount ^ v99;\n\tv104 = v102 & v103;\n\tv105 = v104 < 0;\n\tv106 = v100 == v105;\n\tv107 = ~v106;\n\tv108 = ~v107;\n\tif (v108) goto L_0067;\n\tgoto L_0067;\nL_0067:\n\tv167 = state.<loopCount>k__BackingField >= v194;\n\tif (v167) goto L_0085;\n\tHutongGames.PlayMaker.FsmState::set_Fsm(state, this);\n\tv228 = this.StateChanged == 0;\n\tif (v228) goto L_007E;\n\tSystem.Action`1<HutongGames.PlayMaker.FsmState>::Invoke(this.StateChanged, state);\nL_007E:\n\tHutongGames.PlayMaker.FsmState::OnEnter(state);\n\treturn;\nL_0085:\n\tUnityEngine.Behaviour::set_enabled(this.owner, 0);\n\tv255 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tv140 = this.maxLoopCount - 1;\n\tv137 = v140 < 0;\n\tv131 = this.maxLoopCount ^ 1;\n\tv128 = this.maxLoopCount ^ v140;\n\tv125 = v131 & v128;\n\tv122 = v125 < 0;\n\tv263 = v137 == v122;\n\tv119 = ~v263;\n\tv116 = ~v119;\n\tif (v116) goto L_00A1;\n\tgoto L_00A1;\nL_00A1:\n\t// 161 Box v267 @ X0_v17 (System.Object), typeof(System.Int32), &v110 @ stack_-34\n\tv154 = System.String::Concat(\"Loop count exceeded maximum: \", v267, \" Default is 1000. Override in Fsm Inspector.\");\n\tHutongGames.PlayMaker.FsmLog::LogError(v255, v154);\n\treturn;\n\tv162 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void EnterState(FsmState state)
		{
			//IL_0249: Expected I4, but got O
			EventTarget = null;
			switchToState = null;
			SwitchedState = true;
			activeStateEntered = true;
			if (FsmLog.LoggingEnabled)
			{
				FsmLog fsmLog = MyLog;
				fsmLog.LogEnterState(state);
			}
			int num = MaxLoopCountOverride;
			int num2 = MaxLoopCountOverride - 1;
			bool flag = num2 < 0;
			int num3 = MaxLoopCountOverride ^ 1;
			int num4 = MaxLoopCountOverride ^ num2;
			int num5 = num3 & num4;
			bool flag2 = num5 < 0;
			if (flag != flag2)
			{
				num = 1000;
			}
			if (state.loopCount < num)
			{
				state.Fsm = this;
				if (StateChanged != null)
				{
					StateChanged(state);
				}
				state.OnEnter();
				return;
			}
			Owner.enabled = false;
			FsmLog fsmLog2 = MyLog;
			int num6 = MaxLoopCountOverride - 1;
			bool flag3 = num6 < 0;
			int num7 = MaxLoopCountOverride ^ 1;
			int num8 = MaxLoopCountOverride ^ num6;
			int num9 = num7 & num8;
			bool flag4 = num9 < 0;
			if (flag3 != flag4)
			{
			}
			object obj2 = default(object);
			object obj = (int)obj2;
			string text = string.Concat("Loop count exceeded maximum: ", obj, " Default is 1000. Override in Fsm Inspector.");
			fsmLog2.LogError(text);
		}

		[Token(Token = "0x6000415")]
		[Address(RVA = "0x9DE2EC", Offset = "0x9DE2EC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmState::set_Fsm(state, this);\n\tHutongGames.PlayMaker.FsmState::OnFixedUpdate(state);\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdateState(FsmState state)
		{
			state.Fsm = this;
			state.OnFixedUpdate();
			UpdateStateChanges();
		}

		[Token(Token = "0x6000416")]
		[Address(RVA = "0x9DE198", Offset = "0x9DE198", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmState::set_Fsm(state, this);\n\tHutongGames.PlayMaker.FsmState::OnUpdate(state);\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateState(FsmState state)
		{
			state.Fsm = this;
			state.OnUpdate();
			UpdateStateChanges();
		}

		[Token(Token = "0x6000417")]
		[Address(RVA = "0x9DE3E8", Offset = "0x9DE3E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmState::set_Fsm(state, this);\n\tHutongGames.PlayMaker.FsmState::OnLateUpdate(state);\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdateState(FsmState state)
		{
			state.Fsm = this;
			state.OnLateUpdate();
			UpdateStateChanges();
		}

		[Token(Token = "0x6000418")]
		[Address(RVA = "0x9DE6F0", Offset = "0x9DE6F0", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EAA698]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, state, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A70]) = v43;\nL_0016:\n\tthis.previousActiveState = state;\n\tHutongGames.PlayMaker.FsmState::set_Fsm(state, this);\n\tgoto L_002D;\n\tv67 = *([v51 @ X0_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002D;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v51, v46, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002D:\n\tgoto L_0038;\n\tv78 = *([1EC48C8]);\n\tv79 = *([v78 @ X8_v15]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, v46, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv83 = 0 | 1;\n\t*([2021AA1]) = v83;\nL_0038:\n\tgoto L_0041;\n\tv117 = *([v84 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tgoto L_0041;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v84, v46, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv121 = HutongGames.PlayMaker.FsmLog;\nL_0041:\n\tv125 = ~v124.<LoggingEnabled>k__BackingField;\n\tif (v125) goto L_004C;\n\tv60 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogExitState(v60, state);\nL_004C:\n\tHutongGames.PlayMaker.Fsm::set_ActiveState(this, 0);\n\tHutongGames.PlayMaker.FsmState::OnExit(state);\n\tv102 = ~this.keepDelayedEventsOnStateExit;\n\tif (v102) goto L_0063;\n\treturn;\nL_0063:\n\tHutongGames.PlayMaker.Fsm::KillDelayedEvents(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ExitState(FsmState state)
		{
			previousActiveState = state;
			state.Fsm = this;
			if (FsmLog.LoggingEnabled)
			{
				FsmLog fsmLog = MyLog;
				fsmLog.LogExitState(state);
			}
			ActiveState = null;
			state.OnExit();
			if (!KeepDelayedEventsOnStateExit)
			{
				KillDelayedEvents();
			}
		}

		[Token(Token = "0x6000419")]
		[Address(RVA = "0x9E04FC", Offset = "0x9E04FC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFADD0]);\n\tv25 = *([v24 @ X8_v13]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, subFsmName, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A71]) = v43;\nL_0017:\n\tv107 = HutongGames.PlayMaker.Fsm::get_SubFsmList(this);\nL_0025:\n\tv121 = v106 >= v107._size;\n\tif (v121) goto L_FFFFFFFF;\n\tv141 = HutongGames.PlayMaker.Fsm::get_SubFsmList(this);\n\tv195 = v141._size < v106;\n\tv80 = ~v195;\n\tv77 = v141._size - v106;\n\tv71 = v77 == 0;\n\tv196 = ~v71;\n\tv56 = v80 & v196;\n\tif (v56) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv199 = v141._items;\n\tv91 = v199[v106 @ X22_v6 (System.Int32)];\n\tv200 = v199[v106 @ X22_v6 (System.Int32)] == 0;\n\tif (v200) goto L_004A;\n\tv158 = System.String::op_Equality(v91.name, subFsmName);\n\tv206 = v158 == 0;\n\tv160 = ~v206;\n\tif (v160) goto L_005A;\nL_004A:\n\tv106 = v106 + 1;\n\tv107 = HutongGames.PlayMaker.Fsm::get_SubFsmList(this);\n\tv207 = v107 == 0;\n\tv87 = ~v207;\n\tif (v87) goto L_0025;\n\tthrow System.NullReferenceException;\nL_005A:\n\treturn v162;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Fsm GetSubFsm(string subFsmName)
		{
			List<Fsm> list = SubFsmList;
			int num = 0;
			Fsm result;
			while (true)
			{
				if (num < list.Count)
				{
					List<Fsm> list2 = SubFsmList;
					bool flag = list2.Count < num;
					bool flag2 = !flag;
					int num2 = list2.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Fsm[] items = list2._items;
					Fsm fsm = items[num];
					if (items[num] != null)
					{
						bool flag5 = fsm.Name == subFsmName;
						bool flag6 = !flag5;
						bool flag7 = !flag6;
						result = items[num];
						if (flag7)
						{
							break;
						}
					}
					num++;
					list = SubFsmList;
					if (list == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				result = null;
				break;
			}
			return result;
		}

		[Token(Token = "0x600041A")]
		[Address(RVA = "0x9E05D0", Offset = "0x9E05D0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE3AE8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A72]) = v38;\nL_0013:\n\tv39 = fsm == 0;\n\tif (v39) goto L_002B;\n\tv41 = HutongGames.PlayMaker.Fsm::get_OwnerName(fsm);\n\treturnVal2 = System.String::Concat(v41, \" : \", fsm.name);\n\treturn returnVal2;\nL_002B:\n\treturn \"None (FSM)\";\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullFsmLabel(Fsm fsm)
		{
			if (fsm != null)
			{
				string ownerName = fsm.OwnerName;
				return ownerName + " : " + fsm.Name;
			}
			return "None (FSM)";
		}

		[Token(Token = "0x600041B")]
		[Address(RVA = "0x9DF180", Offset = "0x9DF180", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ownerDefault == 0;\n\tif (v0) goto L_000C;\n\tv3 = ownerDefault.ownerOption == 0;\n\tif (v3) goto L_000D;\n\treturnVal3 = HutongGames.PlayMaker.FsmGameObject::get_Value(ownerDefault.gameObject);\n\treturn returnVal3;\nL_000C:\n\treturn 0;\nL_000D:\n\treturnVal2 = HutongGames.PlayMaker.Fsm::get_GameObject(this);\n\treturn returnVal2;\n\treturnVal4 = new System.NullReferenceException();\n\treturn returnVal4;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject GetOwnerDefaultTarget(FsmOwnerDefault ownerDefault)
		{
			if (ownerDefault != null)
			{
				if (ownerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
				{
					return ownerDefault.GameObject.Value;
				}
				return GameObject;
			}
			return null;
		}

		[Token(Token = "0x600041C")]
		[Address(RVA = "0x9D8C38", Offset = "0x9D8C38", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.states;\n\tv78 = v14.Length;\n\tv30 = v14.Length < 1;\n\tif (v30) goto L_FFFFFFFF;\nL_001A:\n\tv141 = v49 < v78;\n\tv75 = ~v141;\n\tif (v75) goto L_0049;\n\tv43 = v14[v49 @ X22_v6 (System.Int32)];\n\tv105 = System.String::op_Equality(v43.name, stateName);\n\tv190 = v105 == 0;\n\tv131 = ~v190;\n\tif (v131) goto L_0048;\n\tv78 = v14.Length;\n\tv49 = v49 + 1;\n\tv111 = v49 < v14.Length;\n\tif (v111) goto L_001A;\nL_0048:\n\treturn v145;\nL_0049:\n\tv187 = new System.IndexOutOfRangeException();\n\tthrow v187;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmState GetState(string stateName)
		{
			FsmState[] array = States;
			int num = array.Length;
			if (array.Length < 1)
			{
				goto IL_00e1;
			}
			int num2 = 0;
			FsmState result;
			while (true)
			{
				if (num2 < num)
				{
					FsmState fsmState = array[num2];
					bool flag = fsmState.Name == stateName;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					result = array[num2];
					if (flag3)
					{
						break;
					}
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00e1;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_00f9;
			IL_00e1:
			result = null;
			goto IL_00f9;
			IL_00f9:
			return result;
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0x9E0648", Offset = "0x9E0648", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F07BE8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, state, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A73]) = v41;\nL_0016:\n\tv43 = fsm == 0;\n\tif (v43) goto L_0059;\n\tv44 = state == 0;\n\tif (v44) goto L_0059;\n\tv142 = fsm.states;\nL_0020:\n\tv183 = v107 < v142.Length;\n\tv80 = ~v183;\n\tv48 = v107 >= v142.Length;\n\tif (v48) goto L_0046;\n\tif (v80) goto L_005A;\n\tv106 = v142[v107 @ X20_v3 (System.Int32)];\n\tv97 = System.String::op_Equality(v106.name, state.name);\n\tv206 = v97 == 0;\n\tv100 = ~v206;\n\tif (v100) goto L_0059;\n\tv142 = fsm.states;\n\tv107 = v107 + 1;\n\tv207 = fsm.states == 0;\n\tv164 = ~v207;\n\tif (v164) goto L_0020;\n\tthrow System.NullReferenceException;\nL_0046:\n\tgoto L_0050;\n\tv195 = *([v191 @ X0_v5+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0050;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v191, v184, v86, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0050:\n\tUnityEngine.Debug::LogError(\"State not in FSM!\");\nL_0059:\n\treturn v107;\nL_005A:\n\tv203 = new System.IndexOutOfRangeException();\n\tthrow v203;\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetStateIndex(Fsm fsm, FsmState state)
		{
			bool flag = fsm == null;
			int num = -1;
			if (!flag)
			{
				bool flag2 = state == null;
				num = -1;
				if (!flag2)
				{
					FsmState[] array = fsm.States;
					num = 0;
					while (true)
					{
						bool flag3 = num < array.Length;
						bool flag4 = !flag3;
						if (num < array.Length)
						{
							if (!flag4)
							{
								FsmState fsmState = array[num];
								if (fsmState.Name == state.Name)
								{
									break;
								}
								array = fsm.States;
								num++;
								if (fsm.States == null)
								{
									throw new NullReferenceException();
								}
								continue;
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						Debug.LogError("State not in FSM!");
						num = -1;
						break;
					}
				}
			}
			return num;
		}

		[Obsolete]
		[Token(Token = "0x600041E")]
		[Address(RVA = "0x9E0740", Offset = "0x9E0740", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECD7B0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, eventName, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2021A74]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, eventName, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\treturnVal1 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(eventName);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEvent GetEvent(string eventName)
		{
			return FsmEvent.GetFsmEvent(eventName);
		}

		[Token(Token = "0x600041F")]
		[Address(RVA = "0x9E07A8", Offset = "0x9E07A8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED3478]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A75]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0043;\n\tgoto L_FFFFFFFF;\n\tv80 = v80_asT != 0;\n\tv60 = v60_asT == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tif (v80) goto L_0045;\nL_0043:\n\treturn 0;\nL_0045:\n\tv150 = HutongGames.PlayMaker.Fsm::get_GuiLabel(this);\n\tv153 = HutongGames.PlayMaker.Fsm::get_GuiLabel(v99);\n\treturnVal3 = System.String::CompareTo(v150, v153);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			if (obj != null)
			{
				Fsm fsm = obj as Fsm;
				bool flag = fsm != null;
				Fsm fsm2 = obj as Fsm;
				object obj2 = ((fsm2 == null) ? null : obj);
				if (flag)
				{
					string guiLabel = GuiLabel;
					string guiLabel2 = ((Fsm)obj2).GuiLabel;
					return guiLabel.CompareTo(guiLabel2);
				}
			}
			return 0;
		}

		[Token(Token = "0x6000420")]
		[Address(RVA = "0x9D0DAC", Offset = "0x9D0DAC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmObject(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject GetFsmObject(string varName)
		{
			return Variables.GetFsmObject(varName);
		}

		[Token(Token = "0x6000421")]
		[Address(RVA = "0x9D0D90", Offset = "0x9D0D90", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmMaterial(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmMaterial GetFsmMaterial(string varName)
		{
			return Variables.GetFsmMaterial(varName);
		}

		[Token(Token = "0x6000422")]
		[Address(RVA = "0x9D0DE4", Offset = "0x9D0DE4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmTexture(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTexture GetFsmTexture(string varName)
		{
			return Variables.GetFsmTexture(varName);
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0x9D0C5C", Offset = "0x9D0C5C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmFloat(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmFloat GetFsmFloat(string varName)
		{
			return Variables.GetFsmFloat(varName);
		}

		[Token(Token = "0x6000424")]
		[Address(RVA = "0x9D0C78", Offset = "0x9D0C78", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmInt(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmInt GetFsmInt(string varName)
		{
			return Variables.GetFsmInt(varName);
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0x9D0C94", Offset = "0x9D0C94", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmBool(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmBool GetFsmBool(string varName)
		{
			return Variables.GetFsmBool(varName);
		}

		[Token(Token = "0x6000426")]
		[Address(RVA = "0x9D0DC8", Offset = "0x9D0DC8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmString(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmString GetFsmString(string varName)
		{
			return Variables.GetFsmString(varName);
		}

		[Token(Token = "0x6000427")]
		[Address(RVA = "0x9D0CB0", Offset = "0x9D0CB0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmVector2(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector2 GetFsmVector2(string varName)
		{
			return Variables.GetFsmVector2(varName);
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0x9D0CCC", Offset = "0x9D0CCC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmVector3(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVector3 GetFsmVector3(string varName)
		{
			return Variables.GetFsmVector3(varName);
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0x9D0D04", Offset = "0x9D0D04", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmRect(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmRect GetFsmRect(string varName)
		{
			return Variables.GetFsmRect(varName);
		}

		[Token(Token = "0x600042A")]
		[Address(RVA = "0x9D0D20", Offset = "0x9D0D20", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmQuaternion(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmQuaternion GetFsmQuaternion(string varName)
		{
			return Variables.GetFsmQuaternion(varName);
		}

		[Token(Token = "0x600042B")]
		[Address(RVA = "0x9D0CE8", Offset = "0x9D0CE8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmColor(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmColor GetFsmColor(string varName)
		{
			return Variables.GetFsmColor(varName);
		}

		[Token(Token = "0x600042C")]
		[Address(RVA = "0x9D0D3C", Offset = "0x9D0D3C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmGameObject(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject GetFsmGameObject(string varName)
		{
			return Variables.GetFsmGameObject(varName);
		}

		[Token(Token = "0x600042D")]
		[Address(RVA = "0x9D0D58", Offset = "0x9D0D58", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmArray(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray GetFsmArray(string varName)
		{
			return Variables.GetFsmArray(varName);
		}

		[Token(Token = "0x600042E")]
		[Address(RVA = "0x9D0D74", Offset = "0x9D0D74", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = HutongGames.PlayMaker.FsmVariables::GetFsmEnum(this.variables, varName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmEnum GetFsmEnum(string varName)
		{
			return Variables.GetFsmEnum(varName);
		}

		[Token(Token = "0x600042F")]
		[Address(RVA = "0x9E0874", Offset = "0x9E0874", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EBA8D8]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A76]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.owner, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_00A6;\n\tgoto L_0039;\n\tv152 = *([v64 @ X0_v7+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0039;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v64, v56, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tgoto L_0044;\n\tv210 = *([1EAF940]);\n\tv211 = *([v210 @ X8_v29]);\n\tv212 = \"il2cpp_codegen_initialize_method\"(v211, v56, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv215 = 0 | 1;\n\t*([2021AA7]) = v215;\nL_0044:\n\tgoto L_004D;\n\tv220 = *([v216 @ X0_v10 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tgoto L_004D;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v216, v56, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv224 = PlayMakerFSM;\nL_004D:\n\tv229 = ~v227.<DrawGizmos>k__BackingField;\n\tif (v229) goto L_0061;\n\tv244 = UnityEngine.Component::get_transform(this.owner);\n\tv236 = UnityEngine.Transform::get_position(v244);\n\tUnityEngine.Gizmos::DrawIcon(v236, \"PlaymakerIcon.tiff\");\nL_0061:\n\tv135 = this.editState == 0;\n\tif (v135) goto L_00A6;\n\tHutongGames.PlayMaker.FsmState::set_Fsm(this.editState, this);\n\tv131 = this.editState;\n\tv136 = v131.actionData == 0;\n\tif (v136) goto L_00A6;\n\tv132 = HutongGames.PlayMaker.FsmState::get_Actions(v131);\n\tv289 = v132.Length;\n\tv77 = v132.Length < 1;\n\tif (v77) goto L_00A6;\nL_007F:\n\tv304 = v281 < v289;\n\tv265 = ~v304;\n\tif (v265) goto L_00A8;\n\tv129 = HutongGames.PlayMaker.FsmStateAction::OnDrawActionGizmos(v132[v281 @ X20_v10 (System.Int32)]);\n\tv289 = v132.Length;\n\tv281 = v281 + 1;\n\tv75 = v281 < v132.Length;\n\tif (v75) goto L_007F;\nL_00A6:\n\treturn;\n\tv282 = new System.NullReferenceException();\nL_00A8:\n\tv290 = new System.IndexOutOfRangeException();\n\tthrow v290;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDrawGizmos()
		{
			if (Owner == null)
			{
				return;
			}
			if (PlayMakerFSM.DrawGizmos)
			{
				Transform transform = Owner.transform;
				Vector3 position = transform.position;
				Gizmos.DrawIcon(position, "PlaymakerIcon.tiff");
			}
			if (EditState == null)
			{
				return;
			}
			EditState.Fsm = this;
			FsmState fsmState = EditState;
			if (fsmState.ActionData == null)
			{
				return;
			}
			FsmStateAction[] actions = fsmState.Actions;
			int num = actions.Length;
			if (actions.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				actions[num2].OnDrawActionGizmos();
				num = actions.Length;
				num2++;
				if (num2 >= actions.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000430")]
		[Address(RVA = "0x9E0A1C", Offset = "0x9E0A1C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.editState == 0;\n\tif (v13) goto L_004C;\n\tHutongGames.PlayMaker.FsmState::set_Fsm(this.editState, this);\n\tv77 = this.editState;\n\tv73 = v77.actionData == 0;\n\tif (v73) goto L_004C;\n\tv78 = HutongGames.PlayMaker.FsmState::get_Actions(v77);\n\tv170 = v78.Length;\n\tv27 = v78.Length < 1;\n\tif (v27) goto L_004C;\nL_0026:\n\tv187 = v128 < v170;\n\tv146 = ~v187;\n\tif (v146) goto L_004E;\n\tv76 = HutongGames.PlayMaker.FsmStateAction::OnDrawActionGizmosSelected(v78[v128 @ X20_v6 (System.Int32)]);\n\tv170 = v78.Length;\n\tv128 = v128 + 1;\n\tv25 = v128 < v78.Length;\n\tif (v25) goto L_0026;\nL_004C:\n\treturn;\n\tv155 = new System.NullReferenceException();\nL_004E:\n\tv175 = new System.IndexOutOfRangeException();\n\tthrow v175;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDrawGizmosSelected()
		{
			if (EditState == null)
			{
				return;
			}
			EditState.Fsm = this;
			FsmState fsmState = EditState;
			if (fsmState.ActionData == null)
			{
				return;
			}
			FsmStateAction[] actions = fsmState.Actions;
			int num = actions.Length;
			if (actions.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				actions[num2].OnDrawActionGizmosSelected();
				num = actions.Length;
				num2++;
				if (num2 >= actions.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000431")]
		[Address(RVA = "0x9E0AC4", Offset = "0x9E0AC4", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF3D50]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A77]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<CollisionInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<CollisionName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionEnter(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EC0F68]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A93]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionEnter>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionEnter>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionEnter(Collision collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			CollisionInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			CollisionName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionEnter(collisionInfo) && FsmEvent.CollisionEnter != null)
			{
				Event(EventTarget, FsmEvent.CollisionEnter);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000432")]
		[Address(RVA = "0x9E0C20", Offset = "0x9E0C20", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA57D0]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A78]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<CollisionInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<CollisionName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionStay(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EF0DA8]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A95]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionStay>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionStay>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionStay(Collision collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			CollisionInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			CollisionName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionStay(collisionInfo) && FsmEvent.CollisionStay != null)
			{
				Event(EventTarget, FsmEvent.CollisionStay);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000433")]
		[Address(RVA = "0x9E0D7C", Offset = "0x9E0D7C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB61B8]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A79]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<CollisionInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<CollisionName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionExit(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1ED44D8]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A94]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionExit>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionExit>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionExit(Collision collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			CollisionInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			CollisionName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionExit(collisionInfo) && FsmEvent.CollisionExit != null)
			{
				Event(EventTarget, FsmEvent.CollisionExit);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000434")]
		[Address(RVA = "0x9E0ED8", Offset = "0x9E0ED8", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF8FB8]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7A]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider>k__BackingField = other;\n\tv62 = UnityEngine.Component::get_gameObject(other);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<TriggerName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnTriggerEnter(v68, other);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EC8180]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A90]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<TriggerEnter>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<TriggerEnter>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerEnter(Collider other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider = other;
			GameObject gameObject = other.gameObject;
			string text = gameObject.name;
			TriggerName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerEnter(other) && FsmEvent.TriggerEnter != null)
			{
				Event(EventTarget, FsmEvent.TriggerEnter);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000435")]
		[Address(RVA = "0x9E1034", Offset = "0x9E1034", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB9A50]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7B]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider>k__BackingField = other;\n\tv62 = UnityEngine.Component::get_gameObject(other);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<TriggerName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnTriggerStay(v68, other);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EDF120]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A92]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<TriggerStay>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<TriggerStay>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerStay(Collider other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider = other;
			GameObject gameObject = other.gameObject;
			string text = gameObject.name;
			TriggerName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerStay(other) && FsmEvent.TriggerStay != null)
			{
				Event(EventTarget, FsmEvent.TriggerStay);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000436")]
		[Address(RVA = "0x9E1190", Offset = "0x9E1190", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC0E50]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7C]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider>k__BackingField = other;\n\tv62 = UnityEngine.Component::get_gameObject(other);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<TriggerName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnTriggerExit(v68, other);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EDA308]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A91]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<TriggerExit>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<TriggerExit>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerExit(Collider other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider = other;
			GameObject gameObject = other.gameObject;
			string text = gameObject.name;
			TriggerName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerExit(other) && FsmEvent.TriggerExit != null)
			{
				Event(EventTarget, FsmEvent.TriggerExit);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0x9E12EC", Offset = "0x9E12EC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAD4F8]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7D]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<ParticleCollisionGO>k__BackingField = other;\n\tv60 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv64 = HutongGames.PlayMaker.FsmState::OnParticleCollision(v60, other);\n\tv67 = v64 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_005B;\n\tgoto L_0041;\n\tv110 = *([v71 @ X0_v15+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0041;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v71, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tgoto L_004C;\n\tv125 = *([1ED59B8]);\n\tv126 = *([v125 @ X8_v18]);\n\tv127 = \"il2cpp_codegen_initialize_method\"(v126, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv130 = 0 | 1;\n\t*([2021A9C]) = v130;\nL_004C:\n\tgoto L_0055;\n\tv140 = *([v131 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_0055;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v131, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv143 = HutongGames.PlayMaker.FsmEvent;\nL_0055:\n\tv85 = v88.<ParticleCollision>k__BackingField == 0;\n\tif (v85) goto L_005B;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v88.<ParticleCollision>k__BackingField);\nL_005B:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_006E;\n\tv135 = *([v120 @ X0_v11+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_006E;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v120, v79, v77, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnParticleCollision(GameObject other)
		{
			FsmExecutionStack.PushFsm(this);
			ParticleCollisionGO = other;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnParticleCollision(other) && FsmEvent.ParticleCollision != null)
			{
				Event(EventTarget, FsmEvent.ParticleCollision);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0x9E1424", Offset = "0x9E1424", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED8A90]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7E]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<Collision2DInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision2D::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<Collision2dName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionEnter2D(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EFA718]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A99]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionEnter2D>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionEnter2D>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionEnter2D(Collision2D collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			Collision2DInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			Collision2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionEnter2D(collisionInfo) && FsmEvent.CollisionEnter2D != null)
			{
				Event(EventTarget, FsmEvent.CollisionEnter2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000439")]
		[Address(RVA = "0x9E1580", Offset = "0x9E1580", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EAC208]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A7F]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<Collision2DInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision2D::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<Collision2dName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionStay2D(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1EB03B8]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A9B]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionStay2D>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionStay2D>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionStay2D(Collision2D collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			Collision2DInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			Collision2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionStay2D(collisionInfo) && FsmEvent.CollisionStay2D != null)
			{
				Event(EventTarget, FsmEvent.CollisionStay2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043A")]
		[Address(RVA = "0x9E16DC", Offset = "0x9E16DC", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EB5240]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A80]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<Collision2DInfo>k__BackingField = collisionInfo;\n\tv62 = UnityEngine.Collision2D::get_gameObject(collisionInfo);\n\tv72 = UnityEngine.Object::get_name(v62);\n\tthis.<Collision2dName>k__BackingField = v72;\n\tv68 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv98 = HutongGames.PlayMaker.FsmState::OnCollisionExit2D(v68, collisionInfo);\n\tv100 = v98 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0065;\n\tgoto L_004B;\n\tv121 = *([v104 @ X0_v20+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_004B;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v104, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0056;\n\tv136 = *([1F0D5E8]);\n\tv137 = *([v136 @ X8_v18]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv141 = 0 | 1;\n\t*([2021A9A]) = v141;\nL_0056:\n\tgoto L_005F;\n\tv151 = *([v142 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tgoto L_005F;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v142, v96, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv154 = HutongGames.PlayMaker.FsmEvent;\nL_005F:\n\tv116 = v119.<CollisionExit2D>k__BackingField == 0;\n\tif (v116) goto L_0065;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v119.<CollisionExit2D>k__BackingField);\nL_0065:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0078;\n\tv146 = *([v131 @ X0_v16+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0078;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v131, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnCollisionExit2D(Collision2D collisionInfo)
		{
			FsmExecutionStack.PushFsm(this);
			Collision2DInfo = collisionInfo;
			GameObject gameObject = collisionInfo.gameObject;
			string text = gameObject.name;
			Collision2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnCollisionExit2D(collisionInfo) && FsmEvent.CollisionExit2D != null)
			{
				Event(EventTarget, FsmEvent.CollisionExit2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043B")]
		[Address(RVA = "0x9E1838", Offset = "0x9E1838", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF96D0]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A81]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider2D>k__BackingField = other;\n\tv62 = UnityEngine.Object::get_name(other);\n\tthis.<Trigger2dName>k__BackingField = v62;\n\tv65 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv73 = HutongGames.PlayMaker.FsmState::OnTriggerEnter2D(v65, other);\n\tv97 = v73 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0061;\n\tgoto L_0047;\n\tv118 = *([v101 @ X0_v19+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0047;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v101, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0047:\n\tgoto L_0052;\n\tv133 = *([1EAA8A0]);\n\tv134 = *([v133 @ X8_v18]);\n\tv135 = \"il2cpp_codegen_initialize_method\"(v134, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv138 = 0 | 1;\n\t*([2021A96]) = v138;\nL_0052:\n\tgoto L_005B;\n\tv148 = *([v139 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tgoto L_005B;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v139, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv151 = HutongGames.PlayMaker.FsmEvent;\nL_005B:\n\tv113 = v116.<TriggerEnter2D>k__BackingField == 0;\n\tif (v113) goto L_0061;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v116.<TriggerEnter2D>k__BackingField);\nL_0061:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0074;\n\tv143 = *([v128 @ X0_v15+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0074;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v128, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0074:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerEnter2D(Collider2D other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider2D = other;
			string text = other.name;
			Trigger2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerEnter2D(other) && FsmEvent.TriggerEnter2D != null)
			{
				Event(EventTarget, FsmEvent.TriggerEnter2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043C")]
		[Address(RVA = "0x9E1988", Offset = "0x9E1988", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFA7C0]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A82]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider2D>k__BackingField = other;\n\tv62 = UnityEngine.Object::get_name(other);\n\tthis.<Trigger2dName>k__BackingField = v62;\n\tv65 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv73 = HutongGames.PlayMaker.FsmState::OnTriggerStay2D(v65, other);\n\tv97 = v73 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0061;\n\tgoto L_0047;\n\tv118 = *([v101 @ X0_v19+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0047;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v101, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0047:\n\tgoto L_0052;\n\tv133 = *([1EF18F8]);\n\tv134 = *([v133 @ X8_v18]);\n\tv135 = \"il2cpp_codegen_initialize_method\"(v134, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv138 = 0 | 1;\n\t*([2021A98]) = v138;\nL_0052:\n\tgoto L_005B;\n\tv148 = *([v139 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tgoto L_005B;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v139, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv151 = HutongGames.PlayMaker.FsmEvent;\nL_005B:\n\tv113 = v116.<TriggerStay2D>k__BackingField == 0;\n\tif (v113) goto L_0061;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v116.<TriggerStay2D>k__BackingField);\nL_0061:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0074;\n\tv143 = *([v128 @ X0_v15+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0074;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v128, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0074:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerStay2D(Collider2D other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider2D = other;
			string text = other.name;
			Trigger2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerStay2D(other) && FsmEvent.TriggerStay2D != null)
			{
				Event(EventTarget, FsmEvent.TriggerStay2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043D")]
		[Address(RVA = "0x9E1AD8", Offset = "0x9E1AD8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA5140]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A83]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<TriggerCollider2D>k__BackingField = other;\n\tv62 = UnityEngine.Object::get_name(other);\n\tthis.<Trigger2dName>k__BackingField = v62;\n\tv65 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv73 = HutongGames.PlayMaker.FsmState::OnTriggerExit2D(v65, other);\n\tv97 = v73 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0061;\n\tgoto L_0047;\n\tv118 = *([v101 @ X0_v19+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0047;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v101, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0047:\n\tgoto L_0052;\n\tv133 = *([1EAE0F0]);\n\tv134 = *([v133 @ X8_v18]);\n\tv135 = \"il2cpp_codegen_initialize_method\"(v134, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv138 = 0 | 1;\n\t*([2021A97]) = v138;\nL_0052:\n\tgoto L_005B;\n\tv148 = *([v139 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tgoto L_005B;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v139, v71, v72, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv151 = HutongGames.PlayMaker.FsmEvent;\nL_005B:\n\tv113 = v116.<TriggerExit2D>k__BackingField == 0;\n\tif (v113) goto L_0061;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v116.<TriggerExit2D>k__BackingField);\nL_0061:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0074;\n\tv143 = *([v128 @ X0_v15+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0074;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v128, v81, v79, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0074:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTriggerExit2D(Collider2D other)
		{
			FsmExecutionStack.PushFsm(this);
			TriggerCollider2D = other;
			string text = other.name;
			Trigger2dName = text;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnTriggerExit2D(other) && FsmEvent.TriggerExit2D != null)
			{
				Event(EventTarget, FsmEvent.TriggerExit2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043E")]
		[Address(RVA = "0x9E1C28", Offset = "0x9E1C28", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EEE868]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collider, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A84]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, collider, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<ControllerCollider>k__BackingField = collider;\n\tv60 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv64 = HutongGames.PlayMaker.FsmState::OnControllerColliderHit(v60, collider);\n\tv67 = v64 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_005B;\n\tgoto L_0041;\n\tv110 = *([v71 @ X0_v15+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0041;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v71, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tgoto L_004C;\n\tv125 = *([1EE5DC0]);\n\tv126 = *([v125 @ X8_v18]);\n\tv127 = \"il2cpp_codegen_initialize_method\"(v126, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv130 = 0 | 1;\n\t*([2021A9D]) = v130;\nL_004C:\n\tgoto L_0055;\n\tv140 = *([v131 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_0055;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v131, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv143 = HutongGames.PlayMaker.FsmEvent;\nL_0055:\n\tv85 = v88.<ControllerColliderHit>k__BackingField == 0;\n\tif (v85) goto L_005B;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v88.<ControllerColliderHit>k__BackingField);\nL_005B:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_006E;\n\tv135 = *([v120 @ X0_v11+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_006E;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v120, v79, v77, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnControllerColliderHit(ControllerColliderHit collider)
		{
			FsmExecutionStack.PushFsm(this);
			ControllerCollider = collider;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnControllerColliderHit(collider) && FsmEvent.ControllerColliderHit != null)
			{
				Event(EventTarget, FsmEvent.ControllerColliderHit);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0x9E1D60", Offset = "0x9E1D60", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EDF0E0]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, breakForce, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021A85]) = v45;\nL_001D:\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, breakForce, v36, v37, v38, v39, v40, v41, v42);\nL_0025:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<JointBreakForce>k__BackingField = breakForce;\n\tv62 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv66 = HutongGames.PlayMaker.FsmState::OnJointBreak(v62, breakForce);\n\tv69 = v66 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_005C;\n\tgoto L_0042;\n\tv115 = *([v73 @ X0_v15+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0042;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v73, v65, v30, v31, v32, v33, v34, v35, v64, v36, v37, v38, v39, v40, v41, v42);\nL_0042:\n\tgoto L_004D;\n\tv130 = *([1EF8710]);\n\tv131 = *([v130 @ X8_v18]);\n\tv132 = \"il2cpp_codegen_initialize_method\"(v131, v65, v30, v31, v32, v33, v34, v35, v64, v36, v37, v38, v39, v40, v41, v42);\n\tv135 = 0 | 1;\n\t*([2021A9E]) = v135;\nL_004D:\n\tgoto L_0056;\n\tv145 = *([v136 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tgoto L_0056;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v136, v65, v30, v31, v32, v33, v34, v35, v64, v36, v37, v38, v39, v40, v41, v42);\n\tv148 = HutongGames.PlayMaker.FsmEvent;\nL_0056:\n\tv88 = v90.<JointBreak>k__BackingField == 0;\n\tif (v88) goto L_005C;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v90.<JointBreak>k__BackingField);\nL_005C:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_0070;\n\tv140 = *([v125 @ X0_v11+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0070;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v125, v82, v77, v31, v32, v33, v34, v35, v64, v36, v37, v38, v39, v40, v41, v42);\nL_0070:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnJointBreak(float breakForce)
		{
			FsmExecutionStack.PushFsm(this);
			JointBreakForce = breakForce;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnJointBreak(breakForce) && FsmEvent.JointBreak != null)
			{
				Event(EventTarget, FsmEvent.JointBreak);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0x9E1EA0", Offset = "0x9E1EA0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF1F88]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, brokenJoint, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A86]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, brokenJoint, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0024:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tthis.<BrokenJoint2D>k__BackingField = brokenJoint;\n\tv60 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv64 = HutongGames.PlayMaker.FsmState::OnJointBreak2D(v60, brokenJoint);\n\tv67 = v64 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_005B;\n\tgoto L_0041;\n\tv110 = *([v71 @ X0_v15+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0041;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v71, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tgoto L_004C;\n\tv125 = *([1ECD1D8]);\n\tv126 = *([v125 @ X8_v18]);\n\tv127 = \"il2cpp_codegen_initialize_method\"(v126, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv130 = 0 | 1;\n\t*([2021A9F]) = v130;\nL_004C:\n\tgoto L_0055;\n\tv140 = *([v131 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_0055;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v131, v62, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv143 = HutongGames.PlayMaker.FsmEvent;\nL_0055:\n\tv85 = v88.<JointBreak2D>k__BackingField == 0;\n\tif (v85) goto L_005B;\n\tHutongGames.PlayMaker.Fsm::Event(this, this.<EventTarget>k__BackingField, v88.<JointBreak2D>k__BackingField);\nL_005B:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\n\tgoto L_006E;\n\tv135 = *([v120 @ X0_v11+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_006E;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v120, v79, v77, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_006E:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnJointBreak2D(Joint2D brokenJoint)
		{
			FsmExecutionStack.PushFsm(this);
			BrokenJoint2D = brokenJoint;
			FsmState fsmState = ActiveState;
			if (!fsmState.OnJointBreak2D(brokenJoint) && FsmEvent.JointBreak2D != null)
			{
				Event(EventTarget, FsmEvent.JointBreak2D);
			}
			UpdateStateChanges();
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0x9E1FD8", Offset = "0x9E1FD8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB8C28]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021A87]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv55 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv58 = HutongGames.PlayMaker.FsmState::OnAnimatorMove(v55);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0031;\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\nL_0031:\n\tgoto L_003D;\n\tv83 = *([v64 @ X0_v10+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_003D;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v64, v57, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAnimatorMove()
		{
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (fsmState.OnAnimatorMove())
			{
				UpdateStateChanges();
			}
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0x9E2084", Offset = "0x9E2084", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF53C0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, layerIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A88]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, layerIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tHutongGames.PlayMaker.FsmExecutionStack::PushFsm(this);\n\tv58 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv62 = HutongGames.PlayMaker.FsmState::OnAnimatorIK(v58, layerIndex);\n\tv65 = v62 == 0;\n\tif (v65) goto L_0034;\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this);\nL_0034:\n\tgoto L_0041;\n\tv90 = *([v68 @ X0_v10+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0041;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v68, v60, v61, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0041:\n\tHutongGames.PlayMaker.FsmExecutionStack::PopFsm();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAnimatorIK(int layerIndex)
		{
			FsmExecutionStack.PushFsm(this);
			FsmState fsmState = ActiveState;
			if (fsmState.OnAnimatorIK(layerIndex))
			{
				UpdateStateChanges();
			}
			FsmExecutionStack.PopFsm();
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0x9E2140", Offset = "0x9E2140", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tv12 = v10 == 0;\n\tif (v12) goto L_0018;\n\tv14 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.FsmState::OnGUI(v14);\n\treturn;\nL_0018:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnGUI()
		{
			FsmState fsmState = ActiveState;
			if (fsmState != null)
			{
				FsmState fsmState2 = ActiveState;
				fsmState2.OnGUI();
			}
		}

		[Token(Token = "0x6000444")]
		[Address(RVA = "0x9DDCB4", Offset = "0x9DDCB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.activeStateEntered = 0;\n\tHutongGames.PlayMaker.Fsm::DoBreak(this);\n\treturn;\n")]
		private void DoBreakpoint()
		{
			activeStateEntered = false;
			DoBreak();
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0x9E2430", Offset = "0x9E2430", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F07010]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021A89]) = v45;\nL_001D:\n\tgoto L_0027;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tgoto L_0032;\n\tv64 = *([1F02A70]);\n\tv65 = *([v64 @ X8_v20]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv69 = 0 | 1;\n\t*([2021AA8]) = v69;\nL_0032:\n\tgoto L_003C;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003C;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v70, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv78 = HutongGames.PlayMaker.Fsm;\nL_003C:\n\tv81.<IsErrorBreak>k__BackingField = 1;\n\tgoto L_004A;\n\tv89 = *([1EC8AC8]);\n\tv90 = *([v89 @ X8_v17]);\n\tv91 = \"il2cpp_codegen_initialize_method\"(v90, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv93 = HutongGames.PlayMaker.Fsm;\n\t*([2021AA9]) = v82;\nL_004A:\n\tgoto L_0053;\n\tv98 = *([v92 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tgoto L_0053;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v92, error, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv102 = HutongGames.PlayMaker.Fsm;\nL_0053:\n\tv105.<LastError>k__BackingField = error;\n\tHutongGames.PlayMaker.Fsm::DoBreak(this);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DoBreakError(string error)
		{
			IsErrorBreak = true;
			LastError = error;
			DoBreak();
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0x9E2184", Offset = "0x9E2184", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFC940]);\n\tv23 = *([v22 @ X8_v71]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021A8A]) = v42;\nL_001B:\n\tgoto L_0022;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0022;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0022:\n\tv57 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tgoto L_0035;\n\tv65 = *([v61 @ X8_v7+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0035;\n\tv76 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tgoto L_0040;\n\tv78 = *([1EC6AB8]);\n\tv79 = *([v78 @ X8_v67]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv83 = 0 | 1;\n\t*([2021AAA]) = v83;\nL_0040:\n\tgoto L_0049;\n\tv88 = *([v84 @ X0_v8 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tgoto L_0049;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v84, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv92 = HutongGames.PlayMaker.Fsm;\nL_0049:\n\tv95.<BreakAtFsm>k__BackingField = v57;\n\tv97 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tgoto L_005B;\n\tv105 = *([1EE0AD0]);\n\tv106 = *([v105 @ X8_v63]);\n\tv107 = \"il2cpp_codegen_initialize_method\"(v106, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv110 = 0 | 1;\n\t*([2021AAB]) = v110;\nL_005B:\n\tgoto L_0063;\n\tv115 = *([v111 @ X0_v13 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tgoto L_0063;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v111, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv119 = HutongGames.PlayMaker.Fsm;\nL_0063:\n\tv122.<BreakAtState>k__BackingField = v97;\n\tgoto L_0073;\n\tv129 = *([1ED36A0]);\n\tv130 = *([v129 @ X8_v59]);\n\tv131 = \"il2cpp_codegen_initialize_method\"(v130, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv133 = HutongGames.PlayMaker.Fsm;\n\tv135 = 0 | 1;\n\t*([2021AA4]) = v135;\nL_0073:\n\tgoto L_007D;\n\tv139 = *([v132 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tgoto L_007D;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v132, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv143 = HutongGames.PlayMaker.Fsm;\nL_007D:\n\tv146.<HitBreakpoint>k__BackingField = 1;\n\tgoto L_008B;\n\tv154 = *([1ED5A40]);\n\tv155 = *([v154 @ X8_v56]);\n\tv156 = \"il2cpp_codegen_initialize_method\"(v155, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv158 = HutongGames.PlayMaker.Fsm;\n\t*([2021AAC]) = v147;\nL_008B:\n\tgoto L_0095;\n\tv163 = *([v157 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tgoto L_0095;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v157, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv167 = HutongGames.PlayMaker.Fsm;\nL_0095:\n\tv170.<IsBreak>k__BackingField = 1;\n\tgoto L_00A5;\n\tv179 = *([v174 @ X0_v19+E0]);\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tgoto L_00A5;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v174, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A5:\n\tgoto L_00B0;\n\tv191 = *([1EC48C8]);\n\tv192 = *([v191 @ X8_v51]);\n\tv193 = \"il2cpp_codegen_initialize_method\"(v192, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv196 = 0 | 1;\n\t*([2021AA1]) = v196;\nL_00B0:\n\tgoto L_00B9;\n\tv201 = *([v197 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tgoto L_00B9;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v197, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv205 = HutongGames.PlayMaker.FsmLog;\nL_00B9:\n\tv210 = ~v208.<LoggingEnabled>k__BackingField;\n\tif (v210) goto L_00C5;\n\tv213 = HutongGames.PlayMaker.Fsm::get_MyLog(this);\n\tHutongGames.PlayMaker.FsmLog::LogBreak(v213);\nL_00C5:\n\tgoto L_00CF;\n\tv223 = *([v219 @ X0_v25+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_00CF;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v219, v214, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00CF:\n\tgoto L_00DA;\n\tv236 = *([1EDAA00]);\n\tv237 = *([v236 @ X8_v45]);\n\tv238 = \"il2cpp_codegen_initialize_method\"(v237, v214, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv241 = 0 | 1;\n\t*([2021AAD]) = v241;\nL_00DA:\n\tgoto L_00E2;\n\tv246 = *([v242 @ X0_v28 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tgoto L_00E2;\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v242, v214, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv250 = HutongGames.PlayMaker.Fsm;\nL_00E2:\n\tv253.<StepToStateChange>k__BackingField = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoBreak()
		{
			Fsm executingFsm = FsmExecutionStack.ExecutingFsm;
			BreakAtFsm = executingFsm;
			FsmState executingState = FsmExecutionStack.ExecutingState;
			BreakAtState = executingState;
			HitBreakpoint = true;
			IsBreak = true;
			if (FsmLog.LoggingEnabled)
			{
				FsmLog fsmLog = MyLog;
				fsmLog.LogBreak();
			}
			StepToStateChange = false;
		}

		[Token(Token = "0x6000447")]
		[Address(RVA = "0x9DDEDC", Offset = "0x9DDEDC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EE0EA8]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A8B]) = v40;\nL_0015:\n\tthis.activeStateEntered = 1;\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tgoto L_0031;\n\tv60 = *([1ED36A0]);\n\tv61 = *([v60 @ X8_v31]);\n\tv62 = \"il2cpp_codegen_initialize_method\"(v61, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv65 = 0 | 1;\n\t*([2021AA4]) = v65;\nL_0031:\n\tgoto L_003A;\n\tv70 = *([v66 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv74 = HutongGames.PlayMaker.Fsm;\nL_003A:\n\tv77.<HitBreakpoint>k__BackingField = 0;\n\tgoto L_0049;\n\tv84 = *([1F02A70]);\n\tv85 = *([v84 @ X8_v27]);\n\tv86 = \"il2cpp_codegen_initialize_method\"(v85, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv88 = HutongGames.PlayMaker.Fsm;\n\tv90 = 0 | 1;\n\t*([2021AA8]) = v90;\nL_0049:\n\tgoto L_0052;\n\tv94 = *([v87 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tgoto L_0052;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = HutongGames.PlayMaker.Fsm;\nL_0052:\n\tv101.<IsErrorBreak>k__BackingField = 0;\n\tgoto L_0061;\n\tv108 = *([1ED5A40]);\n\tv109 = *([v108 @ X8_v23]);\n\tv110 = \"il2cpp_codegen_initialize_method\"(v109, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv112 = HutongGames.PlayMaker.Fsm;\n\tv114 = 0 | 1;\n\t*([2021AAC]) = v114;\nL_0061:\n\tgoto L_006A;\n\tv118 = *([v111 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tgoto L_006A;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v111, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv122 = HutongGames.PlayMaker.Fsm;\nL_006A:\n\tv125.<IsBreak>k__BackingField = 0;\n\tv127 = HutongGames.PlayMaker.Fsm::get_ActiveState(this);\n\tHutongGames.PlayMaker.Fsm::EnterState(this, v127);\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Continue()
		{
			activeStateEntered = true;
			HitBreakpoint = false;
			IsErrorBreak = false;
			IsBreak = false;
			FsmState state = ActiveState;
			EnterState(state);
		}

		[Token(Token = "0x6000448")]
		[Address(RVA = "0x9E2538", Offset = "0x9E2538", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC05D0]);\n\tv21 = *([v20 @ X8_v52]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A8C]) = v40;\nL_0018:\n\tv45 = this.subFsmList == 0;\n\tif (v45) goto L_005C;\n\tv51 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::GetEnumerator(this.subFsmList);\nL_0027:\n\tv124 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::MoveNext(&v50 @ stack_-68_v5 (System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>));\n\tv171 = v124 == 0;\n\tif (v171) goto L_0034;\n\tv122 = v104 == 0;\n\tif (v122) goto L_0036;\n\tHutongGames.PlayMaker.Fsm::OnDestroy(v104);\n\tgoto L_0027;\nL_0034:\n\tv218 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::Dispose(&v50 @ stack_-68_v5 (System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>));\n\tgoto L_0055;\nL_0036:\n\tv255 = new System.NullReferenceException();\n\tgoto L_0042;\n\tgoto L_0042;\nL_0042:\n\tv232 = Il2CppMethodInfo != 1;\n\tif (v232) goto L_00E0;\n\tv372 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::MoveNext(v255);\n\tv384 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::MoveNext(v372);\n\tv296 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::Dispose(&v50 @ stack_-68_v5 (System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>));\n\tv393 = ~v372.m_value;\n\tv298 = ~v393;\n\tif (v298) goto L_00E4;\nL_0055:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>::Clear(this.subFsmList);\nL_005C:\n\tgoto L_0064;\n\tv107 = *([v99 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0064;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v99, v87, v24, v25, v26, v27, v28, v29, v83, v31, v32, v33, v34, v35, v36, v37);\n\tv111 = HutongGames.PlayMaker.Fsm;\nL_0064:\n\tv115 = v114.EventData;\n\tv136 = v115.SentByFsm != this;\n\tif (v136) goto L_008D;\n\tv175 = new HutongGames.PlayMaker.FsmEventData();\n\tHutongGames.PlayMaker.FsmEventData::.ctor(v175);\n\tgoto L_0086;\n\tv309 = *([v260 @ X0_v36 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_0086;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v260, v177, v24, v25, v26, v27, v28, v29, v83, v31, v32, v33, v34, v35, v36, v37);\n\tv312 = HutongGames.PlayMaker.Fsm;\nL_0086:\n\tv183.EventData = v175;\nL_008D:\n\tgoto L_009F;\n\tv219 = *([v187 @ X0_v17 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tgoto L_009F;\n\tv264 = \"il2cpp_codegen_runtime_class_init\"(v187, v176, v24, v25, v26, v27, v28, v29, v83, v31, v32, v33, v34, v35, v36, v37);\n\tv223 = PlayMakerGUI;\nL_009F:\n\tv141 = v226.SelectedFSM != this;\n\tif (v141) goto L_00AE;\n\tgoto L_00AC;\n\tv314 = *([v222 @ X0_v18 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_00AC;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v222, v176, v24, v25, v26, v27, v28, v29, v83, v31, v32, v33, v34, v35, v36, v37);\n\tv373 = PlayMakerGUI;\n\tv318 = *([v373 @ X8_v29+B8]);\nL_00AC:\n\tv275.SelectedFSM = 0;\nL_00AE:\n\tv277 = this.myLog == 0;\n\tif (v277) goto L_00B6;\n\tHutongGames.PlayMaker.FsmLog::OnDestroy(this.myLog);\nL_00B6:\n\tgoto L_00BF;\n\tv327 = *([v320 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_00BF;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v320, v159, v24, v25, v26, v27, v28, v29, v83, v31, v32, v33, v34, v35, v36, v37);\n\tv331 = HutongGames.PlayMaker.Fsm;\nL_00BF:\n\tv336 = v334.lastRaycastHit2DInfoLUT == 0;\n\tif (v336) goto L_00D5;\n\tgoto L_00D4;\n\tv138 = *([v330 @ X0_v22 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv385 = v138 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00D4;\n\tv394 = HutongGames.PlayMaker.Fsm;\n\tv395 = *([v394 @ X8_v24 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv165 = v395.lastRaycastHit2DInfoLUT;\nL_00D4:\n\tv381 = System.Collections.Generic.Dictionary`2<HutongGames.PlayMaker.Fsm, UnityEngine.RaycastHit2D>::Remove(v334.lastRaycastHit2DInfoLUT, this);\nL_00D5:\n\tthis.owner = 0;\n\treturn;\n\tv169 = new System.NullReferenceException();\n\tv213 = new System.NullReferenceException();\nL_00E0:\n\tv259 = System.Collections.Generic.List`1<HutongGames.PlayMaker.Fsm>+Enumerator<HutongGames.PlayMaker.Fsm>::MoveNext(v254);\nL_00E4:\n\tthrow System.TypeLoadException;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDestroy()
		{
			if (subFsmList != null)
			{
				List<Fsm>.Enumerator enumerator = subFsmList.GetEnumerator();
				List<Fsm>.Enumerator enumerator2 = default(List<Fsm>.Enumerator);
				Fsm fsm = default(Fsm);
				NullReferenceException ex2 = default(NullReferenceException);
				while (true)
				{
					if (enumerator2.MoveNext())
					{
						if (fsm != null)
						{
							fsm.OnDestroy();
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						if ((IntPtr)0 == (IntPtr)1)
						{
							bool flag = ((List<Fsm>.Enumerator*)ex)->MoveNext();
							bool flag2 = (flag ? ((List<Fsm>.Enumerator*)1) : ((List<Fsm>.Enumerator*)null))->MoveNext();
							enumerator2.Dispose();
							if (!((bool*)(flag ? 1 : 0))->m_value)
							{
								break;
							}
						}
						else
						{
							bool flag3 = ((List<Fsm>.Enumerator*)ex2)->MoveNext();
						}
						throw new TypeLoadException();
					}
					enumerator2.Dispose();
					break;
				}
				subFsmList.Clear();
			}
			FsmEventData eventData = EventData;
			if (eventData.SentByFsm == this)
			{
				FsmEventData eventData2 = new FsmEventData();
				EventData = eventData2;
			}
			if (PlayMakerGUI.SelectedFSM == this)
			{
				PlayMakerGUI.SelectedFSM = null;
			}
			if (myLog != null)
			{
				myLog.OnDestroy();
			}
			if (lastRaycastHit2DInfoLUT != null)
			{
				bool flag4 = lastRaycastHit2DInfoLUT.Remove(this);
			}
			Owner = null;
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0x9E27B4", Offset = "0x9E27B4", Length = "0x12C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tgoto L_0019;\n\tv24 = *([1EBFED0]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([2021A8D]) = v45;\nL_0019:\n\tv49 = new HutongGames.PlayMaker.FsmEventData();\n\tHutongGames.PlayMaker.FsmEventData::.ctor(v49);\n\tv56.EventData = v49;\n\tv57 = UnityEngine.Color::get_yellow();\n\tv61 = HutongGames.PlayMaker.Fsm;\n\tv63 = *([v61 @ X8_v7 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv63.debugLookAtColor = v57;\n\t*([v63 @ X8_v8 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+C]) = v57.g;\n\t*([v63 @ X8_v8 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+10]) = v57.b;\n\t*([v63 @ X8_v8 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+14]) = v57.a;\n\tv64 = UnityEngine.Color::get_red();\n\tv68 = HutongGames.PlayMaker.Fsm;\n\tv70 = *([v68 @ X8_v9 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv70.debugRaycastColor = v64;\n\t*([v70 @ X8_v10 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+1C]) = v64.g;\n\t*([v70 @ X8_v10 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+20]) = v64.b;\n\t*([v70 @ X8_v10 (Il2CppStaticFields<HutongGames.PlayMaker.Fsm>)+24]) = v64.a;\n\t// 60 NewArr v74 @ X0_v7 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 8\n\tv77 = UnityEngine.Color::get_grey();\n\tv81 = v74 == 0;\n\tif (v81) goto L_0118;\n\tv83 = v74.Length == 0;\n\tif (v83) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+20]) = v77;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+24]) = v77.g;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+28]) = v77.b;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+2C]) = v77.a;\n\tv184 = &v17 @ stack_-10_v2 - 0x40;\n\t*([v16 @ X29_v1-40]) = 0;\n\t*([v16 @ X29_v1-38]) = 0;\n\tv187 = 0x10105A8(v184, 0, v84, v29, v30, v31, v32, v33, 0.54509807f, 0.67058825f, 0.9411765f, v77.a, v38, v39, v40, v41);\n\tv309 = v74.Length < 1;\n\tv259 = ~v309;\n\tv252 = v74.Length - 1;\n\tv238 = v252 == 0;\n\tv310 = ~v259;\n\tv203 = v310 | v238;\n\tif (v203) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+30]) = *([v16 @ X29_v1-40]);\n\tv200 = 0;\n\tv295 = 0x10105A8(&v200 @ stack_-60_v3, 0, v84, v29, v30, v31, v32, v33, 0.24313726f, 0.7607843f, 0.6901961f, v77.a, v38, v39, v40, v41);\n\tv365 = v74.Length < 2;\n\tv260 = ~v365;\n\tv253 = v74.Length - 2;\n\tv239 = v253 == 0;\n\tv366 = ~v260;\n\tv204 = v366 | v239;\n\tif (v204) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+40]) = 0;\n\tv198 = 0;\n\tv296 = 0x10105A8(&v198 @ stack_-70_v3, 0, v84, v29, v30, v31, v32, v33, 0.43137255f, 0.7607843f, 0.24313726f, v77.a, v38, v39, v40, v41);\n\tv370 = v74.Length < 3;\n\tv261 = ~v370;\n\tv254 = v74.Length - 3;\n\tv240 = v254 == 0;\n\tv371 = ~v261;\n\tv205 = v371 | v240;\n\tif (v205) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+50]) = 0;\n\tv195 = 0;\n\tv297 = 0x10105A8(&v195 @ stack_-80_v3, 0, v84, v29, v30, v31, v32, v33, 1f, 0.8745098f, 0.1882353f, v77.a, v38, v39, v40, v41);\n\tv375 = v74.Length < 4;\n\tv262 = ~v375;\n\tv255 = v74.Length - 4;\n\tv241 = v255 == 0;\n\tv376 = ~v262;\n\tv206 = v376 | v241;\n\tif (v206) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+60]) = 0;\n\tv193 = 0;\n\tv298 = 0x10105A8(&v193 @ stack_-90_v3, 0, v84, v29, v30, v31, v32, v33, 1f, 0.5529412f, 0.1882353f, v77.a, v38, v39, v40, v41);\n\tv380 = v74.Length < 5;\n\tv263 = ~v380;\n\tv256 = v74.Length - 5;\n\tv242 = v256 == 0;\n\tv381 = ~v263;\n\tv207 = v381 | v242;\n\tif (v207) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+70]) = 0;\n\tv191 = 0;\n\tv299 = 0x10105A8(&v191 @ stack_-A0_v3, 0, v84, v29, v30, v31, v32, v33, 0.7607843f, 0.24313726f, 0.2509804f, v77.a, v38, v39, v40, v41);\n\tv385 = v74.Length < 6;\n\tv264 = ~v385;\n\tv257 = v74.Length - 6;\n\tv243 = v257 == 0;\n\tv386 = ~v264;\n\tv208 = v386 | v243;\n\tif (v208) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+80]) = 0;\n\tv189 = 0;\n\tv300 = 0x10105A8(&v189 @ stack_-B0_v3, 0, v84, v29, v30, v31, v32, v33, 0.54509807f, 0.24313726f, 0.7607843f, v77.a, v38, v39, v40, v41);\n\tv389 = v74.Length < 7;\n\tv265 = ~v389;\n\tv258 = v74.Length - 7;\n\tv244 = v258 == 0;\n\tv390 = ~v265;\n\tv209 = v390 | v244;\n\tif (v209) goto L_0113;\n\t*([v74 @ X0_v7 (UnityEngine.Color[])+90]) = 0;\n\tv392.StateColors = v74;\n\tv357 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v357);\n\tv360.targetSelf = v357;\n\treturn;\nL_0113:\n\tv308 = new System.IndexOutOfRangeException();\n\tthrow v308;\nL_0118:\n\tv177 = new System.NullReferenceException();\n\tMorpeh.Entity::SetComponent(v177, 8);\n\treturn;\n\tX1 = *([X8]);\n\tX0 = 0x9C900C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0x9CE004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX8 = *([X8]);\n\tX0 = 0x9D600C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX1 = *([X8]);\n\tX0 = 0x9CA00C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1182 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		unsafe static Fsm()
		{
			//IL_001b: Expected I, but got O
			//IL_0024: Expected I, but got O
			//IL_0062: Expected I, but got O
			//IL_006b: Expected I, but got O
			//IL_011c: Expected O, but got I
			//IL_015e: Expected O, but got I4
			//IL_01a9: Expected O, but got I4
			//IL_01df: Expected O, but got I4
			//IL_0223: Expected O, but got I4
			//IL_0259: Expected O, but got I4
			//IL_029d: Expected O, but got I4
			//IL_02d3: Expected O, but got I4
			//IL_0317: Expected O, but got I4
			//IL_034d: Expected O, but got I4
			//IL_0391: Expected O, but got I4
			//IL_03c7: Expected O, but got I4
			//IL_040b: Expected O, but got I4
			//IL_0441: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			FsmEventData eventData = new FsmEventData();
			EventData = eventData;
			Color yellow = Color.yellow;
			IntPtr intPtr = (IntPtr)typeof(Fsm);
			IntPtr intPtr2 = (IntPtr)EventData;
			debugLookAtColor = yellow;
			_ = yellow.g;
			_ = yellow.b;
			_ = yellow.a;
			Color red = Color.red;
			IntPtr intPtr3 = (IntPtr)typeof(Fsm);
			IntPtr intPtr4 = (IntPtr)EventData;
			debugRaycastColor = red;
			_ = red.g;
			_ = red.b;
			_ = red.a;
			Color[] array = new Color[8];
			Color grey = Color.grey;
			if (array != null)
			{
				if (array.Length != 0)
				{
					_ = grey.g;
					_ = grey.b;
					_ = grey.a;
					object obj3 = (long)(IntPtr)obj2 - 64L;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-40]");
						_ = 0;
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj6 = array.Length - 2;
						bool flag7 = obj6 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							_ = 0;
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
							bool flag9 = array.Length < 3;
							bool flag10 = !flag9;
							object obj8 = array.Length - 3;
							bool flag11 = obj8 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								_ = 0;
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
								bool flag13 = array.Length < 4;
								bool flag14 = !flag13;
								object obj10 = array.Length - 4;
								bool flag15 = obj10 == null;
								bool flag16 = !flag14;
								if (!(flag16 || flag15))
								{
									_ = 0;
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
									bool flag17 = array.Length < 5;
									bool flag18 = !flag17;
									object obj12 = array.Length - 5;
									bool flag19 = obj12 == null;
									bool flag20 = !flag18;
									if (!(flag20 || flag19))
									{
										_ = 0;
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
										bool flag21 = array.Length < 6;
										bool flag22 = !flag21;
										object obj14 = array.Length - 6;
										bool flag23 = obj14 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											_ = 0;
											object obj15 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
											bool flag25 = array.Length < 7;
											bool flag26 = !flag25;
											object obj16 = array.Length - 7;
											bool flag27 = obj16 == null;
											bool flag28 = !flag26;
											if (!(flag28 || flag27))
											{
												_ = 0;
												StateColors = array;
												FsmEventTarget fsmEventTarget = new FsmEventTarget();
												targetSelf = fsmEventTarget;
												return;
											}
										}
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				int num = 0;
				throw ex;
			}
			NullReferenceException ex2 = new NullReferenceException();
			((Entity)(object)ex2).SetComponent(in *(SetStateGameObjectListComponent*)8);
		}
	}
}
