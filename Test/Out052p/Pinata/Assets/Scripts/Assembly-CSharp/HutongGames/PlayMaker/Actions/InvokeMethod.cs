using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D3A4", Offset = "0x75D3A4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D3A4", Offset = "0x75D3A4")]
	[Token(Token = "0x2000344")]
	public class InvokeMethod : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8D80", Offset = "0x7C8D80")]
		[Token(Token = "0x4001AE3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8DCC", Offset = "0x7C8DCC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8DCC", Offset = "0x7C8DCC")]
		[Token(Token = "0x4001AE4")]
		[FieldOffset(Offset = "0x58")]
		public FsmString behaviour;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8E2C", Offset = "0x7C8E2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8E2C", Offset = "0x7C8E2C")]
		[Token(Token = "0x4001AE5")]
		[FieldOffset(Offset = "0x60")]
		public FsmString methodName;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C8E8C", Offset = "0x7C8E8C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8E8C", Offset = "0x7C8E8C")]
		[Token(Token = "0x4001AE6")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8EE0", Offset = "0x7C8EE0")]
		[Token(Token = "0x4001AE7")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool repeating;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C8F18", Offset = "0x7C8F18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8F18", Offset = "0x7C8F18")]
		[Token(Token = "0x4001AE8")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat repeatDelay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8F6C", Offset = "0x7C8F6C")]
		[Token(Token = "0x4001AE9")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool cancelOnExit;

		[Token(Token = "0x4001AEA")]
		[FieldOffset(Offset = "0x88")]
		private MonoBehaviour component;

		[Token(Token = "0x600105D")]
		[Address(RVA = "0xA38C00", Offset = "0xA38C00", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF7680]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E2E]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.behaviour = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.methodName = v43;\n\tthis.delay = 0;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.repeating = v46;\n\tv49 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.repeatDelay = v49;\n\tv52 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.cancelOnExit = v52;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			behaviour = null;
			FsmString fsmString = "";
			methodName = fsmString;
			delay = null;
			FsmBool fsmBool = false;
			repeating = fsmBool;
			FsmFloat fsmFloat = 1f;
			repeatDelay = fsmFloat;
			FsmBool fsmBool2 = false;
			cancelOnExit = fsmBool2;
		}

		[Token(Token = "0x600105E")]
		[Address(RVA = "0xA38C8C", Offset = "0xA38C8C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.InvokeMethod::DoInvokeMethod(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			DoInvokeMethod(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x600105F")]
		[Address(RVA = "0xA38CD4", Offset = "0xA38CD4", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB3500]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, go, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021E2F]) = v45;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, go, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(go, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\treturn;\nL_0037:\n\tv195 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tgoto L_0048;\n\tv242 = *([v238 @ X8_v8+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_0048;\n\tv252 = v238;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v252, v194, v61, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv251 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v195);\n\tv257 = UnityEngine.GameObject::GetComponent(go, v251);\n\tv274 = v257 == 0;\n\tif (v274) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0076;\n\tv316 = v316_asT == 0;\n\tif (v316) goto L_FFFFFFFF;\n\tgoto L_0076;\nL_0076:\n\tthis.component = v233;\n\tgoto L_0084;\n\tv324 = *([v320 @ X0_v18+E0]);\n\tv325 = v324 == 0;\n\tv326 = ~v325;\n\tgoto L_0084;\n\tv328 = \"il2cpp_codegen_runtime_class_init\"(v320, v253, v256, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0084:\n\tv331 = UnityEngine.Object::op_Equality(v233, 0);\n\tv333 = v331 == 0;\n\tif (v333) goto L_00AE;\n\tv264 = UnityEngine.Object::get_name(go);\n\tv337 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tv344 = System.String::Concat(\"InvokeMethod: \", v264, \" missing behaviour: \", v337);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v344);\n\treturn;\nL_00AE:\n\tv265 = HutongGames.PlayMaker.FsmBool::get_Value(this.repeating);\n\tv266 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv198 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tv347 = v265 == 0;\n\tif (v347) goto L_00E6;\n\tv258 = HutongGames.PlayMaker.FsmFloat::get_Value(this.repeatDelay);\n\tUnityEngine.MonoBehaviour::InvokeRepeating(this.component, v266, v198, v258);\n\treturn;\nL_00E6:\n\tUnityEngine.MonoBehaviour::Invoke(this.component, v266, v198);\n\treturn;\n\tv222 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoInvokeMethod(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			string value = behaviour.Value;
			Type globalType = ReflectionUtils.GetGlobalType(value);
			Component component = go.GetComponent(globalType);
			UnityEngine.Object obj;
			if ((object)component == null)
			{
				obj = null;
			}
			else
			{
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				obj = (((object)monoBehaviour == null) ? null : component);
			}
			this.component = (MonoBehaviour)obj;
			if (obj == null)
			{
				string text = go.name;
				string value2 = behaviour.Value;
				string text2 = "InvokeMethod: " + text + " missing behaviour: " + value2;
				LogWarning(text2);
				return;
			}
			bool value3 = repeating.Value;
			string value4 = methodName.Value;
			float value5 = delay.Value;
			if (value3)
			{
				float value6 = repeatDelay.Value;
				this.component.InvokeRepeating(value4, value5, value6);
			}
			else
			{
				this.component.Invoke(value4, value5);
			}
		}

		[Token(Token = "0x6001060")]
		[Address(RVA = "0xA38F50", Offset = "0xA38F50", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED15E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E30]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.component, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0047;\n\tv65 = HutongGames.PlayMaker.FsmBool::get_Value(this.cancelOnExit);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0047;\n\tv100 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tUnityEngine.MonoBehaviour::CancelInvoke(this.component, v100);\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (!(component == null) && cancelOnExit.Value)
			{
				string value = methodName.Value;
				component.CancelInvoke(value);
			}
		}

		[Token(Token = "0x6001061")]
		[Address(RVA = "0xA39018", Offset = "0xA39018", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InvokeMethod()
		{
		}
	}
}
