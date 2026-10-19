using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Sirenix.Utilities;
using UnityEngine;

namespace Unco.Utils
{
	[Serializable]
	[Token(Token = "0x2000021")]
	public class ComponentStateHandler
	{
		[SerializeReference]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x10")]
		private List<ComponentState> m_stateList;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x20")]
		private int _currentStateIndex;

		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x4000083")]
		[field: FieldOffset(Offset = "0x18")]
		public ComponentState CurrentComponentState
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x81C34DC", Offset = "0x81C34DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CurrentComponentState;\n")]
			get;
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x81C34E4", Offset = "0x81C34E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CurrentComponentState = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700000B")]
		public int StateCount
		{
			[Token(Token = "0x6000082")]
			[Address(RVA = "0x81C34EC", Offset = "0x81C34EC", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this.m_stateList;\n")]
			get
			{
				List<ComponentState> stateList = m_stateList;
				return stateList.Count;
			}
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x81C3538", Offset = "0x81C3538", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv88 = v84.Count - 1;\n\tv50 = this._currentStateIndex >= v88;\n\tif (v50) goto L_0050;\n\tv92 = this._currentStateIndex + 1;\n\tthis._currentStateIndex = v92;\n\tv104 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::get_Item(v84, v92);\n\tv79 = Unco.Utils.ComponentState::ShouldInvoke(v104);\n\tv81 = ~v79;\n\tif (v81) goto L_0019;\n\tv142 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::get_Item(this.m_stateList, this._currentStateIndex);\n\tthis.CurrentComponentState = v142;\n\tUnco.Utils.ComponentStateHandler::ActivateState(this, this.CurrentComponentState);\n\treturn;\nL_0050:\n\treturn;\nL_0018:\n\tthis._currentStateIndex = -1;\nL_0019:\n\tv84 = this.m_stateList;\n")]
		public void ActivateNextProperState()
		{
			_currentStateIndex = -1;
			while (true)
			{
				List<ComponentState> stateList = m_stateList;
				int num = stateList.Count - 1;
				if (_currentStateIndex < num)
				{
					ComponentState componentState = stateList[++_currentStateIndex];
					if (componentState.ShouldInvoke())
					{
						ComponentState componentState2 = m_stateList[_currentStateIndex];
						CurrentComponentState = componentState2;
						ActivateState(CurrentComponentState);
						break;
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x81C37A4", Offset = "0x81C37A4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._currentStateIndex = -1;\n\tUnco.Utils.ComponentStateHandler::ActivateNextProperState(this);\n\treturn;\n")]
		public void RefreshStates()
		{
			_currentStateIndex = -1;
			ActivateNextProperState();
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x81C37B0", Offset = "0x81C37B0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv51 = index / v44.Count;\n\tv52 = v51 * v44.Count;\n\tv53 = index - v52;\n\tv55 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::get_Item(v44, v53);\n\tUnco.Utils.ComponentStateHandler::ActivateState(this, v55);\n\treturn;\nL_0018:\n\tv44 = this.m_stateList;\n")]
		public void ActivateState(int index)
		{
			List<ComponentState> stateList = m_stateList;
			int num = index / stateList.Count;
			int num2 = num * stateList.Count;
			int index2 = index - num2;
			ComponentState componentState = stateList[index2];
			ActivateState(componentState);
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x81C3834", Offset = "0x81C3834", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void ActivateCustom()
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x485709C", Offset = "0x485709C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\treturnVal1 = System.Linq.Enumerable::OfType(this.m_stateList);\n\treturn returnVal1;\n\tv24 = 0x220C2B8(methodInfo, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = System.Linq.Enumerable::OfType(this.m_stateList);\n\treturn returnVal2;\n")]
		public IEnumerable<T> AllStatesOfType<T>() where T : ComponentState
		{
			return m_stateList.OfType<T>();
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x4857360", Offset = "0x4857360", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0014:\n\tv58 = Unco.Utils.ComponentStateHandler::GetStateByKey(v41, v38);\n\tgoto L_0029;\nL_0029:\n\treturnVal1 = 0x21C11D0(v58, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public T GetStateAs<T>(string key) where T : ComponentState
		{
			string key2 = default(string);
			ComponentState stateByKey = GetStateByKey(key2);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			T result = default(T);
			return result;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x48570EC", Offset = "0x48570EC", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\nL_0017:\n\tv147 = this.m_stateList;\n\tv45 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tv48 = *([v45 @ X0_v46 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+135]) & 1;\n\tv49 = v48 == 0;\nL_FFFFFFFF:\n\tv62 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\nL_FFFFFFFF:\n\tv163 = this.m_stateList;\n\tif (v49) goto L_0055;\nL_0020:\n\tgoto L_0022;\nL_0022:\n\tv74 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tv77 = *([v74 @ X0_v43 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+135]) & 1;\n\tv78 = v77 == 0;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\nL_FFFFFFFF:\n\tv97 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\nL_FFFFFFFF:\n\tv163 = v147;\n\tif (v78) goto L_0063;\nL_0028:\n\tv94 = *([v87 @ X0_v41 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+B8]);\n\tv139 = *([v94 @ X8_v48 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+8]);\n\tv96 = *([v94 @ X8_v48 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+8]) == 0;\nL_FFFFFFFF:\n\tv163 = v147;\n\tif (v96) goto L_006A;\nL_0033:\n\tv218 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::Find(v147, v139);\n\tgoto L_0048;\n\tv86 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = this.m_stateList;\n\tv53 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tv108 = *([v53 @ X0_v55 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+135]) & 1;\n\tv109 = v108 == 0;\n\tv55 = ~v109;\nL_FFFFFFFF:\n\tv62 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\nL_FFFFFFFF:\n\tv163 = this.m_stateList;\n\tif (v55) goto L_0020;\nL_0055:\n\tv66 = 0x220C238(v62, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = *([v66 @ X0_v31+E4]) == 0;\n\tv69 = ~v84;\nL_FFFFFFFF:\n\tv147 = v163;\n\tif (v69) goto L_0022;\n\tv88 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tv104 = *([v88 @ X0_v29 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+135]) & 1;\n\tv105 = v104 == 0;\n\tv90 = ~v105;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\nL_FFFFFFFF:\n\tv147 = v163;\nL_FFFFFFFF:\n\tv97 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tif (v90) goto L_0028;\nL_0063:\n\tv101 = 0x220C238(v97, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = *([v101 @ X0_v26+B8]);\n\tv139 = *([v116 @ X8_v33+8]);\n\tv130 = *([v116 @ X8_v33+8]) == 0;\n\tv114 = ~v130;\nL_FFFFFFFF:\n\tv147 = v163;\n\tif (v114) goto L_0033;\nL_006A:\n\tv125 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tv128 = *([v125 @ X0_v24 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+135]) & 1;\n\tv129 = v128 == 0;\nL_FFFFFFFF:\n\tv172 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tif (v129) goto L_00A4;\n\tgoto L_007A;\nL_007A:\n\tgoto L_0081;\nL_0081:\n\tv253 = new System.Predicate`1<Unco.Utils.ComponentState>();\n\tSystem.Predicate`1<Unco.Utils.ComponentState>::.ctor(v253, v249.<>9, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv267 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>;\n\tgoto L_0091;\nL_0091:\n\tv268 = *([v267 @ X0_v12 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+B8]);\n\t*([v268 @ X8_v17 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__14`1<T>>)+8]) = v253;\n\tgoto L_00A0;\nL_00A0:\n\tv279 = v163 == 0;\n\tv144 = ~v279;\nL_FFFFFFFF:\n\tv139 = v253;\nL_FFFFFFFF:\n\tv147 = v163;\n\tif (v144) goto L_0033;\n\tv172 = new System.NullReferenceException();\nL_00A4:\n\tv176 = 0x220C238(v172, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv212 = *([v176 @ X0_v5+E4]) == 0;\n\tv191 = ~v212;\n\tif (v191) goto L_007A;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv163 = v163;\n\tgoto L_0081;\nL_0048:\n\treturnVal1 = 0x21C11D0(v218, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public T FindState<T>() where T : ComponentState
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentStateHandler::FindState");
			return default;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x48572EC", Offset = "0x48572EC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0014:\n\tv58 = Unco.Utils.ComponentStateHandler::GetStateByIndex(v41, v38);\n\tgoto L_0029;\nL_0029:\n\treturnVal1 = 0x21C11D0(v58, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public T GetStateAs<T>(int index) where T : ComponentState
		{
			int index2 = default(int);
			ComponentState stateByIndex = GetStateByIndex(index2);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			T result = default(T);
			return result;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x48573D4", Offset = "0x48573D4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000A;\nL_000A:\n\tv15 = this.m_stateList;\n\tv15 = System.Linq.Enumerable::Cast(v15);\n\treturn v15;\n\tv37 = 0x220C2B8(methodInfo, methodInfo, v38, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = this.m_stateList;\n\tv48 = System.Linq.Enumerable::Cast(v48);\n\treturn v48;\n")]
		public IEnumerable<T> GetStatesAs<T>()
		{
			IEnumerable<T> stateList = (IEnumerable<T>)m_stateList;
			return stateList.Cast<T>();
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x485742C", Offset = "0x485742C", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\nL_0017:\n\tv93 = this.m_stateList;\n\tv45 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tv48 = *([v45 @ X0_v38 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+135]) & 1;\n\tv49 = v48 == 0;\nL_FFFFFFFF:\n\tv62 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\nL_FFFFFFFF:\n\tv131 = this.m_stateList;\n\tif (v49) goto L_0039;\nL_0020:\n\tgoto L_0022;\nL_0022:\n\tv74 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tv77 = *([v74 @ X0_v35 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+135]) & 1;\n\tv78 = v77 == 0;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\nL_FFFFFFFF:\n\tv98 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\nL_FFFFFFFF:\n\tv131 = v93;\n\tif (v78) goto L_0047;\nL_0028:\n\tv94 = *([v87 @ X0_v33 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+B8]);\n\tv119 = *([v94 @ X8_v43 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+8]);\n\tv96 = *([v94 @ X8_v43 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+8]) == 0;\n\tv97 = ~v96;\nL_FFFFFFFF:\n\tv130 = v93;\n\tif (v97) goto L_0089;\nL_FFFFFFFF:\n\tv131 = v93;\n\tgoto L_004E;\n\tv86 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv93 = this.m_stateList;\n\tv53 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tv109 = *([v53 @ X0_v47 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+135]) & 1;\n\tv110 = v109 == 0;\n\tv55 = ~v110;\nL_FFFFFFFF:\n\tv62 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\nL_FFFFFFFF:\n\tv131 = this.m_stateList;\n\tif (v55) goto L_0020;\nL_0039:\n\tv66 = 0x220C238(v62, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = *([v66 @ X0_v32+E4]) == 0;\n\tv69 = ~v84;\nL_FFFFFFFF:\n\tv93 = v131;\n\tif (v69) goto L_0022;\n\tv88 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tv105 = *([v88 @ X0_v30 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+135]) & 1;\n\tv106 = v105 == 0;\n\tv90 = ~v106;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\nL_FFFFFFFF:\n\tv93 = v131;\nL_FFFFFFFF:\n\tv98 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tif (v90) goto L_0028;\nL_0047:\n\tv102 = 0x220C238(v98, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv129 = *([v102 @ X0_v27+B8]);\n\tv119 = *([v129 @ X8_v35+8]);\n\tv138 = *([v129 @ X8_v35+8]) == 0;\n\tv126 = ~v138;\nL_FFFFFFFF:\n\tv130 = v131;\n\tif (v126) goto L_0089;\nL_004E:\n\tv144 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tv147 = *([v144 @ X0_v6 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+135]) & 1;\n\tv148 = v147 == 0;\n\tif (v148) goto L_0095;\n\tgoto L_005E;\nL_005E:\n\tgoto L_0065;\nL_0065:\n\tv192 = new System.Func`2<Unco.Utils.ComponentState, System.Boolean>();\n\tSystem.Func`2<Unco.Utils.ComponentState, System.Boolean>::.ctor(v192, v188.<>9, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv206 = Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>;\n\tgoto L_0075;\nL_0075:\n\tv207 = *([v206 @ X0_v15 (Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+B8]);\n\t*([v207 @ X8_v23 (Il2CppStaticFields<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>)+8]) = v192;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = v192;\nL_FFFFFFFF:\n\tv130 = v131;\nL_0089:\n\tv137 = System.Linq.Enumerable::Where(v130, v119);\n\treturnVal1 = System.Linq.Enumerable::Cast(v137);\n\treturn returnVal1;\nL_0095:\n\tv160 = 0x220C238(Il2CppClass<Unco.Utils.ComponentStateHandler+<>c__17`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = *([v160 @ X0_v10+E4]) == 0;\n\tv163 = ~v177;\n\tif (v163) goto L_005E;\n\tgoto L_00A2;\nL_00A2:\n\tgoto L_0065;\n")]
		public IEnumerable<T> GetStatesSafeAs<T>()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentStateHandler::GetStatesSafeAs");
			return default;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x81C3610", Offset = "0x81C3610", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv56 = this.m_stateList == 0;\n\tv153 = 0;\n\tif (v56) goto L_006C;\n\tv146 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::GetEnumerator(this.m_stateList);\n\tv166 = v146._list;\n\tv176 = componentState->klass;\n\tv147 = componentState->klass->vtable[0];\n\tv233 = System.Object::Equals(componentState, v146.Current);\n\tv259 = v233 == 0;\n\tv236 = ~v259;\n\tif (v236) goto L_003C;\n\tv234 = Unco.Utils.ComponentState::DeActivate(v146.Current);\n\tgoto L_003C;\nL_0055:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v166 @ stack_-58_v5 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\nL_005A:\n\tv273 = Unco.Utils.ComponentState::Activate(componentState);\n\tthis.CurrentComponentState = componentState;\nL_0069:\n\treturn;\nL_007A:\n\tv181 = v158 != 1;\n\tv221 = v179;\n\tif (v181) goto L_008A;\n\tv248 = 0x8BF5BC4(v179, v158, v147, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv263 = 0x8BF5BF4(v248, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v166 @ stack_-58_v5 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\n\tv253 = *([v248 @ X0_v13]) == 0;\n\tif (v253) goto L_005A;\n\tv252 = new System.OutOfMemoryException();\n\tv153 = *([v248 @ X0_v13]);\n\tv221 = v252;\n\treturn;\nL_0020:\n\tv166 = 0;\n\tv51 = componentState == 0;\n\tif (v51) goto L_0069;\nL_006C:\n\tv179 = new System.NullReferenceException();\n\tgoto L_007A;\nL_003C:\n\tv242 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v166 @ stack_-58_v5 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\n\tv246 = v242 == 0;\n\tif (v246) goto L_0055;\nL_008A:\n\tv256 = 0x3967C54(&v153 @ stack_-68_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv265 = 0x8BF0368(v221, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = 0x7C03E68(v265, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ActivateState(ComponentState componentState)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentStateHandler::ActivateState");
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x81C3838", Offset = "0x81C3838", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv163 = System.Object::GetType(this);\n\tv231 = System.Reflection.MemberInfo::get_Name(v163);\n\tv233 = System.Int32::ToString(&v107 @ stack_-34_v5 (System.Int32));\n\t// 48 NewArr v61 @ X0_v7 (System.String[]), typeof(System.String[]), 6\n\tv61[0] = \"State with key \";\n\tv61[1] = key;\n\tv61[2] = \" not found in \";\n\tv61[3] = v231;\n\tv61[4] = \". Using fallback at index: \";\n\tv61[5] = v233;\n\tv280 = System.String::Concat(v61);\n\tgoto L_00AF;\nL_0027:\n\tv47 = Unco.Utils.ComponentStateHandler::GetStateByKey(this, key);\n\tv52 = v47 == 0;\n\tv53 = ~v52;\n\tv96 = v47;\n\tif (v53) goto L_00B8;\nL_00B8:\n\tUnco.Utils.ComponentStateHandler::ActivateState(this, v96);\n\treturn;\nL_00AF:\n\tUnityEngine.Debug::LogWarning(v280);\n\tv99 = Unco.Utils.ComponentStateHandler::GetStateAs(this, v107);\n\tv96 = v99;\n")]
		public void ActivateState(string key, int fallback = 0)
		{
			ComponentState stateByKey = GetStateByKey(key);
			bool flag = stateByKey == null;
			bool flag2 = !flag;
			ComponentState componentState = stateByKey;
			if (!flag2)
			{
				Type type = GetType();
				string name = type.Name;
				int index = default(int);
				string text = index.ToString();
				string message = "State with key " + key + " not found in " + name + ". Using fallback at index: " + text;
				Debug.LogWarning(message);
				ComponentState stateAs = GetStateAs<ComponentState>(index);
				componentState = stateAs;
			}
			ActivateState(componentState);
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x81C3A50", Offset = "0x81C3A50", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv61 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::GetEnumerator(this.m_stateList);\n\tv84 = v61._list;\n\tv74 = v61.Current;\n\tv139 = v61.Current == 0;\n\tif (v139) goto L_0056;\n\tv106 = System.String::Equals(v74.StateKey, key);\n\tv108 = v106 == 0;\n\tif (v108) goto L_0038;\nL_FFFFFFFF:\n\tv152 = v61.Current;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv152 = 0;\nL_0056:\n\tv147 = new System.NullReferenceException();\n\tgoto L_0059;\nL_0059:\n\t// 89 Interrupt\nL_FFFFFFFF:\n\tv69 = 0;\nL_0068:\n\tv122 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv135 = v96;\n\tif (v122) goto L_0083;\n\tv126 = 0x8BF5BC4(v96, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv142 = 0x8BF5BF4(v126, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v84 @ stack_-48_v3 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\n\tv165 = *([v126 @ X0_v12]) == 0;\n\tv134 = ~v165;\n\tif (v134) goto L_0080;\n\treturn 0;\nL_0080:\n\tv132 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv69 = *([v126 @ X0_v12]);\nL_FFFFFFFF:\n\tv135 = v132;\n\treturn returnVal2;\nL_001E:\n\tv84 = 0;\n\tv48 = this.m_stateList == 0;\nL_FFFFFFFF:\n\t;\n\tif (v48) goto L_005A;\nL_0038:\n\tv111 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v84 @ stack_-48_v3 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\n\tv124 = v111 == 0;\n\tif (v124) goto L_FFFFFFFF;\nL_004C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v84 @ stack_-48_v3 (System.Collections.Generic.List`1<Unco.Utils.ComponentState>));\n\treturn v152;\nL_0083:\n\tv138 = 0x3967C54(&v69 @ stack_-58 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv144 = 0x8BF0368(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0x7C03E68(v144, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_005A:\n\tv96 = new System.NullReferenceException();\n\tgoto L_0068;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ComponentState GetStateByKey(string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentStateHandler::GetStateByKey");
			return default;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x81C3BD4", Offset = "0x81C3BD4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::get_Item(this.m_stateList, v40);\n\treturn returnVal1;\n")]
		public ComponentState GetStateByIndex(int index)
		{
			int index2 = default(int);
			return m_stateList[index2];
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x81C3C38", Offset = "0x81C3C38", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.List`1<Unco.Utils.ComponentState>::IndexOf(this.m_stateList, v40);\n\treturn returnVal1;\n")]
		public int GetIndexOfState(ComponentState state)
		{
			ComponentState item = default(ComponentState);
			return m_stateList.IndexOf(item);
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x81C3C9C", Offset = "0x81C3C9C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\treturnVal1 = Sirenix.Utilities.LinqExtensions::IsNullOrEmpty(this.m_stateList);\n\treturn returnVal1;\n")]
		public bool IsEmpty()
		{
			return m_stateList.IsNullOrEmpty();
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x81C3CF0", Offset = "0x81C3CF0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._currentStateIndex = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ComponentStateHandler()
		{
			_currentStateIndex = -1;
		}
	}
}
