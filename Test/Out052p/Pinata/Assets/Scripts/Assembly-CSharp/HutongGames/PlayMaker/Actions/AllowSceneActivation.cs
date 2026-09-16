using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C9D0", Offset = "0x75C9D0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C9D0", Offset = "0x75C9D0")]
	[Token(Token = "0x2000324")]
	public class AllowSceneActivation : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C5874", Offset = "0x7C5874")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5874", Offset = "0x7C5874")]
		[Token(Token = "0x4001A07")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt aSynchOperationHashCode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C58D4", Offset = "0x7C58D4")]
		[Token(Token = "0x4001A08")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool allowSceneActivation;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7C590C", Offset = "0x7C590C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C590C", Offset = "0x7C590C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C590C", Offset = "0x7C590C")]
		[Token(Token = "0x4001A09")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat progress;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5980", Offset = "0x7C5980")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C5980", Offset = "0x7C5980")]
		[Token(Token = "0x4001A0A")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isDone;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C59D0", Offset = "0x7C59D0")]
		[Token(Token = "0x4001A0B")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent doneEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5A08", Offset = "0x7C5A08")]
		[Token(Token = "0x4001A0C")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent failureEvent;

		[Token(Token = "0x6000FC3")]
		[Address(RVA = "0xA13C38", Offset = "0xA13C38", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.aSynchOperationHashCode = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.allowSceneActivation = v12;\n\tthis.progress = 0;\n\tthis.doneEvent = 0;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			aSynchOperationHashCode = null;
			FsmBool fsmBool = true;
			allowSceneActivation = fsmBool;
			progress = null;
			doneEvent = null;
		}

		[Token(Token = "0x6000FC4")]
		[Address(RVA = "0xA13C70", Offset = "0xA13C70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AllowSceneActivation::DoAllowSceneActivation(this);\n\treturn;\n")]
		public override void OnEnter()
		{
			DoAllowSceneActivation();
		}

		[Token(Token = "0x6000FC5")]
		[Address(RVA = "0xA13E18", Offset = "0xA13E18", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EBFBD8]);\n\tv21 = *([v20 @ X8_v34]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D29]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.progress);\n\tv106 = v44 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0046;\n\tv65 = this.progress;\n\tgoto L_0032;\n\tv147 = *([v110 @ X0_v41 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\t// 40 ConditionalJump @b57, v149 @ TEMP_v51\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv151 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0032:\n\tv161 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv78 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::get_Item(v57.aSyncOperationLUT, v161);\n\tv114 = UnityEngine.AsyncOperation::get_progress(v78);\n\tv65.value = v114;\nL_0046:\n\tv157 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isDone);\n\tv189 = v157 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0077;\n\tv66 = this.isDone;\n\tgoto L_0060;\n\tv208 = *([v192 @ X0_v29 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\t// 86 ConditionalJump @b59, v210 @ TEMP_v41\n\tv220 = \"il2cpp_codegen_runtime_class_init\"(v192, v156, v54, v25, v26, v27, v28, v29, v47, v31, v32, v33, v34, v35, v36, v37);\n\tv211 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0060:\n\tv167 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv79 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::get_Item(v58.aSyncOperationLUT, v167);\n\tv168 = UnityEngine.AsyncOperation::get_isDone(v79);\n\tv66.value = v168;\nL_0077:\n\tgoto L_0085;\n\tv214 = *([v202 @ X0_v10 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\t// 123 Jump @b60\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v202, v165, v162, v25, v26, v27, v28, v29, v47, v31, v32, v33, v34, v35, v36, v37);\n\tv217 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0085:\n\tv169 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv80 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::get_Item(v59.aSyncOperationLUT, v169);\n\tv134 = UnityEngine.AsyncOperation::get_isDone(v80);\n\tv136 = v134 == 0;\n\tif (v136) goto L_00C6;\n\tgoto L_00A7;\n\tv235 = *([v231 @ X0_v17 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\t// 157 ConditionalJump @b61, v237 @ TEMP_v30\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v231, v131, v52, v25, v26, v27, v28, v29, v47, v31, v32, v33, v34, v35, v36, v37);\n\tv238 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_00A7:\n\tv170 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv246 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::Remove(v60.aSyncOperationLUT, v170);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.doneEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00C6:\n\treturn;\n\tv77 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (!progress.IsNone)
			{
				FsmFloat fsmFloat = progress;
				int value = aSynchOperationHashCode.Value;
				AsyncOperation asyncOperation = LoadSceneAsynch.aSyncOperationLUT.get_Item(value);
				float value2 = asyncOperation.progress;
				fsmFloat.Value = value2;
			}
			if (!isDone.IsNone)
			{
				FsmBool fsmBool = isDone;
				int value3 = aSynchOperationHashCode.Value;
				AsyncOperation asyncOperation2 = LoadSceneAsynch.aSyncOperationLUT.get_Item(value3);
				bool value4 = asyncOperation2.isDone;
				fsmBool.value = value4;
			}
			int value5 = aSynchOperationHashCode.Value;
			AsyncOperation asyncOperation3 = LoadSceneAsynch.aSyncOperationLUT.get_Item(value5);
			if (asyncOperation3.isDone)
			{
				int value6 = aSynchOperationHashCode.Value;
				bool flag = LoadSceneAsynch.aSyncOperationLUT.Remove(value6);
				Fsm.Event(doneEvent);
				Finish();
			}
		}

		[Token(Token = "0x6000FC6")]
		[Address(RVA = "0xA13C74", Offset = "0xA13C74", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EB7510]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D2A]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.aSynchOperationHashCode);\n\tv69 = v44 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0087;\n\tv104 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.allowSceneActivation);\n\tv143 = v104 == 0;\n\tv108 = ~v143;\n\tif (v108) goto L_0087;\n\tgoto L_0035;\n\tv149 = *([v145 @ X0_v14 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0035;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v145, v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv152 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0035:\n\tv110 = v112.aSyncOperationLUT == 0;\n\tif (v110) goto L_0087;\n\tgoto L_0047;\n\tv159 = *([v106 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\t// 62 ConditionalJump @b43, v161 @ TEMP_v37\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v106, v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv168 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\n\tv165 = *([v168 @ X8_v21+B8]);\n\tv166 = *([v165 @ X8_v22]);\nL_0047:\n\tv83 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv105 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::ContainsKey(v112.aSyncOperationLUT, v83);\n\tv109 = v105 == 0;\n\tif (v109) goto L_0087;\n\tgoto L_0065;\n\tv176 = *([v172 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.Actions.LoadSceneAsynch>)+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\t// 91 ConditionalJump @b44, v178 @ TEMP_v35\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v172, v79, v75, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv179 = HutongGames.PlayMaker.Actions.LoadSceneAsynch;\nL_0065:\n\tv84 = HutongGames.PlayMaker.FsmInt::get_Value(this.aSynchOperationHashCode);\n\tv85 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.AsyncOperation>::get_Item(v73.aSyncOperationLUT, v84);\n\tv86 = HutongGames.PlayMaker.FsmBool::get_Value(this.allowSceneActivation);\n\tUnityEngine.AsyncOperation::set_allowSceneActivation(v85, v86);\n\treturn;\nL_0087:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.failureEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAllowSceneActivation()
		{
			if (!aSynchOperationHashCode.IsNone && !allowSceneActivation.IsNone && LoadSceneAsynch.aSyncOperationLUT != null)
			{
				int value = aSynchOperationHashCode.Value;
				if (LoadSceneAsynch.aSyncOperationLUT.ContainsKey(value))
				{
					int value2 = aSynchOperationHashCode.Value;
					AsyncOperation asyncOperation = LoadSceneAsynch.aSyncOperationLUT.get_Item(value2);
					bool value3 = allowSceneActivation.Value;
					asyncOperation.allowSceneActivation = value3;
					return;
				}
			}
			Fsm.Event(failureEvent);
			Finish();
		}

		[Token(Token = "0x6000FC7")]
		[Address(RVA = "0xA1406C", Offset = "0xA1406C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AllowSceneActivation()
		{
		}
	}
}
