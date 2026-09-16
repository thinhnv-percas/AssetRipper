using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BCC0", Offset = "0x75BCC0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BCC0", Offset = "0x75BCC0")]
	[Token(Token = "0x2000300")]
	public class RectTransformContainsScreenPoint : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C2478", Offset = "0x7C2478")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2478", Offset = "0x7C2478")]
		[Token(Token = "0x400193E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2510", Offset = "0x7C2510")]
		[Token(Token = "0x400193F")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 screenPointVector2;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2548", Offset = "0x7C2548")]
		[Token(Token = "0x4001940")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 orScreenPointVector3;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2580", Offset = "0x7C2580")]
		[Token(Token = "0x4001941")]
		[FieldOffset(Offset = "0x68")]
		public bool normalizedScreenPoint;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C25B8", Offset = "0x7C25B8")]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C25B8", Offset = "0x7C25B8")]
		[Token(Token = "0x4001942")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject camera;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2640", Offset = "0x7C2640")]
		[Token(Token = "0x4001943")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7C2678", Offset = "0x7C2678")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2678", Offset = "0x7C2678")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C2678", Offset = "0x7C2678")]
		[Token(Token = "0x4001944")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool isContained;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C26EC", Offset = "0x7C26EC")]
		[Token(Token = "0x4001945")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent isContainedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2724", Offset = "0x7C2724")]
		[Token(Token = "0x4001946")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent isNotContainedEvent;

		[Token(Token = "0x4001947")]
		[FieldOffset(Offset = "0x98")]
		private RectTransform _rt;

		[Token(Token = "0x4001948")]
		[FieldOffset(Offset = "0xA0")]
		private Camera _camera;

		[Token(Token = "0x6000F12")]
		[Address(RVA = "0xB1EE60", Offset = "0xB1EE60", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDD838]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022591]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.screenPointVector2 = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.orScreenPointVector3 = v42;\n\tthis.normalizedScreenPoint = 0;\n\tthis.camera = 0;\n\tthis.everyFrame = 0;\n\tthis.isContainedEvent = 0;\n\tthis.isNotContainedEvent = 0;\n\tthis.isContained = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			screenPointVector2 = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			orScreenPointVector3 = fsmVector;
			normalizedScreenPoint = false;
			camera = null;
			everyFrame = false;
			isContainedEvent = null;
			isNotContainedEvent = null;
			isContained = null;
		}

		[Token(Token = "0x6000F13")]
		[Address(RVA = "0xB1EEEC", Offset = "0xB1EEEC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE5A08]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022592]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv87 = *([v71 @ X8_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_002A;\n\tv94 = v71;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v94, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv80 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv96 = v80 == 0;\n\tif (v96) goto L_003A;\n\tv123 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v123;\nL_003A:\n\tv128 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.camera);\n\tv130 = v128 == 0;\n\tif (v130) goto L_0057;\n\tgoto L_004B;\n\tv137 = *([v133 @ X0_v21+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004B;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v50, v48, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004B:\n\tv54 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv152 = UnityEngine.Component::GetComponent(v54);\n\tgoto L_005E;\nL_0057:\n\tv56 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.camera);\n\tv152 = UnityEngine.GameObject::GetComponent(v56);\nL_005E:\n\tthis._camera = v152;\n\tHutongGames.PlayMaker.Actions.RectTransformContainsScreenPoint::DoCheck(this);\n\tv109 = ~this.everyFrame;\n\tif (v109) goto L_0071;\n\treturn;\nL_0071:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			Camera component2;
			if (camera.IsNone)
			{
				EventSystem current = EventSystem.current;
				component2 = current.GetComponent<Camera>();
			}
			else
			{
				GameObject value = camera.Value;
				component2 = value.GetComponent<Camera>();
			}
			_camera = component2;
			DoCheck();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F14")]
		[Address(RVA = "0xB1F1E4", Offset = "0xB1F1E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformContainsScreenPoint::DoCheck(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCheck();
		}

		[Token(Token = "0x6000F15")]
		[Address(RVA = "0xB1F044", Offset = "0xB1F044", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EAF9C0]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022593]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0033;\nL_0032:\n\treturn;\nL_0033:\n\tv104 = this.screenPointVector2;\n\tv80 = v104.value.y;\n\tv174 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.orScreenPointVector3);\n\tv186 = v174 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0052;\n\tv177 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\n\tv192 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\nL_0052:\n\tv201 = ~this.normalizedScreenPoint;\n\tif (v201) goto L_0064;\n\tv203 = UnityEngine.Screen::get_width();\n\tv206 = v193 * v203;\n\tv209 = UnityEngine.Screen::get_height();\n\tv80 = v80 * v209;\nL_0064:\n\tgoto L_006F;\n\tv219 = *([v213 @ X0_v14+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tgoto L_006F;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v213, v196, v61, v29, v30, v31, v32, v33, v204, v189, v72, v37, v38, v39, v40, v41);\nL_006F:\n\t// 111 MakeStruct v70 @ AGGB1F174_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v193 @ V8_v4 (UnityEngine.Vector3), v80 @ V9_v5 (System.Single)\n\tv162 = UnityEngine.RectTransformUtility::RectangleContainsScreenPoint(this._rt, v70, this._camera);\n\tv89 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isContained);\n\tv229 = v89 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0082;\n\tv168 = this.isContained;\n\tv168.value = v162;\nL_0082:\n\tv234 = v162 == 0;\n\tif (v234) goto L_0089;\n\tv131 = this.isContainedEvent;\n\tv235 = this.isContainedEvent == 0;\n\tv91 = ~v235;\n\tif (v91) goto L_0098;\n\tgoto L_0032;\nL_0089:\n\tv131 = this.isNotContainedEvent;\n\tv92 = this.isNotContainedEvent == 0;\n\tif (v92) goto L_0032;\nL_0098:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v131);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheck()
		{
			//IL_0119: Expected O, but got F4
			if (_rt == null)
			{
				return;
			}
			FsmVector2 fsmVector = screenPointVector2;
			float num = fsmVector.value.y;
			bool isNone = orScreenPointVector3.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			Vector3 vector = fsmVector.value;
			if (!flag2)
			{
				Vector3 value = orScreenPointVector3.Value;
				Vector3 value2 = orScreenPointVector3.Value;
				vector = value;
				num = value2.y;
			}
			if (normalizedScreenPoint)
			{
				int width = Screen.width;
				float num2 = vector.x * (float)width;
				int height = Screen.height;
				num *= (float)height;
				vector = (Vector3)num2;
			}
			Vector2 screenPoint = default(Vector2);
			screenPoint.x = vector.x;
			screenPoint.y = num;
			bool flag3 = RectTransformUtility.RectangleContainsScreenPoint(_rt, screenPoint, _camera);
			if (!isContained.IsNone)
			{
				FsmBool fsmBool = isContained;
				fsmBool.value = flag3;
			}
			FsmEvent fsmEvent;
			if (flag3)
			{
				fsmEvent = isContainedEvent;
				if (isContainedEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = isNotContainedEvent;
				if (isNotContainedEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000F16")]
		[Address(RVA = "0xB1F1E8", Offset = "0xB1F1E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformContainsScreenPoint()
		{
		}
	}
}
