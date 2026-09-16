using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755D10", Offset = "0x755D10")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755D10", Offset = "0x755D10")]
	[Token(Token = "0x20001D9")]
	public class AddComponent : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B01A8", Offset = "0x7B01A8")]
		[Token(Token = "0x400141D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B01F4", Offset = "0x7B01F4")]
		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x7B01F4", Offset = "0x7B01F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B01F4", Offset = "0x7B01F4")]
		[Token(Token = "0x400141E")]
		[FieldOffset(Offset = "0x58")]
		public FsmString component;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B0278", Offset = "0x7B0278")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7B0278", Offset = "0x7B0278")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0278", Offset = "0x7B0278")]
		[Token(Token = "0x400141F")]
		[FieldOffset(Offset = "0x60")]
		public FsmObject storeComponent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0314", Offset = "0x7B0314")]
		[Token(Token = "0x4001420")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool removeOnExit;

		[Token(Token = "0x4001421")]
		[FieldOffset(Offset = "0x70")]
		private Component addedComponent;

		[Token(Token = "0x60009D3")]
		[Address(RVA = "0xA12318", Offset = "0xA12318", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.component = 0;\n\tthis.storeComponent = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			component = null;
			storeComponent = null;
			gameObject = null;
		}

		[Token(Token = "0x60009D4")]
		[Address(RVA = "0xA12324", Offset = "0xA12324", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddComponent::DoAddComponent(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddComponent();
			Finish();
		}

		[Token(Token = "0x60009D5")]
		[Address(RVA = "0xA124D0", Offset = "0xA124D0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EB8088]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D12]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmBool::get_Value(this.removeOnExit);\n\tv47 = v44 == 0;\n\tif (v47) goto L_004B;\n\tgoto L_002C;\n\tv91 = *([v51 @ X0_v6+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002C;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv61 = UnityEngine.Object::op_Inequality(this.addedComponent, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_004B;\n\tgoto L_0043;\n\tv104 = *([v99 @ X0_v10+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0043;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v99, v59, v56, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tUnityEngine.Object::Destroy(this.addedComponent);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (removeOnExit.Value && addedComponent != null)
			{
				UnityEngine.Object.Destroy(addedComponent);
			}
		}

		[Token(Token = "0x60009D6")]
		[Address(RVA = "0xA1234C", Offset = "0xA1234C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F0C260]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D13]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv98 = *([v69 @ X8_v5+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002C;\n\tv106 = v69;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v106, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv105 = UnityEngine.Object::op_Equality(v47, 0);\n\tv108 = v105 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0083;\n\tv149 = HutongGames.PlayMaker.FsmString::get_Value(this.component);\n\tgoto L_0046;\n\tv155 = *([v93 @ X8_v9+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0046;\n\tv163 = v93;\n\tv159 = \"il2cpp_codegen_runtime_class_init\"(v163, v148, v57, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0046:\n\tv87 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v149);\n\tv88 = UnityEngine.GameObject::AddComponent(v47, v87);\n\tv94 = this.storeComponent;\n\tthis.addedComponent = v88;\n\tv94.value = v88;\n\tgoto L_0060;\n\tv169 = *([v165 @ X0_v20+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0060;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v165, v85, v83, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tv145 = UnityEngine.Object::op_Equality(this.addedComponent, 0);\n\tv146 = v145 == 0;\n\tif (v146) goto L_0083;\n\tv178 = HutongGames.PlayMaker.FsmString::get_Value(this.component);\n\tv184 = System.String::Concat(\"Can't add component: \", v178);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v184);\n\treturn;\nL_0083:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddComponent()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				string value = component.Value;
				Type globalType = ReflectionUtils.GetGlobalType(value);
				Component value2 = ownerDefaultTarget.AddComponent(globalType);
				FsmObject fsmObject = storeComponent;
				addedComponent = value2;
				fsmObject.Value = value2;
				if (addedComponent == null)
				{
					string value3 = component.Value;
					string text = "Can't add component: " + value3;
					LogError(text);
				}
			}
		}

		[Token(Token = "0x60009D7")]
		[Address(RVA = "0xA1259C", Offset = "0xA1259C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddComponent()
		{
		}
	}
}
