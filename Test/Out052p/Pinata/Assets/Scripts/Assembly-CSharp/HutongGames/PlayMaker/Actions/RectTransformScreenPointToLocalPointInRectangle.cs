using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C260", Offset = "0x75C260")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75C260", Offset = "0x75C260")]
	[Token(Token = "0x200030F")]
	public class RectTransformScreenPointToLocalPointInRectangle : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C3E24", Offset = "0x7C3E24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3E24", Offset = "0x7C3E24")]
		[Token(Token = "0x4001998")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3EBC", Offset = "0x7C3EBC")]
		[Token(Token = "0x4001999")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 screenPointVector2;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3EF4", Offset = "0x7C3EF4")]
		[Token(Token = "0x400199A")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 orScreenPointVector3;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3F2C", Offset = "0x7C3F2C")]
		[Token(Token = "0x400199B")]
		[FieldOffset(Offset = "0x68")]
		public bool normalizedScreenPoint;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3F64", Offset = "0x7C3F64")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C3F64", Offset = "0x7C3F64")]
		[Token(Token = "0x400199C")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject camera;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3FEC", Offset = "0x7C3FEC")]
		[Token(Token = "0x400199D")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C4024", Offset = "0x7C4024")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4024", Offset = "0x7C4024")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C4024", Offset = "0x7C4024")]
		[Token(Token = "0x400199E")]
		[FieldOffset(Offset = "0x80")]
		public FsmVector3 localPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4098", Offset = "0x7C4098")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C4098", Offset = "0x7C4098")]
		[Token(Token = "0x400199F")]
		[FieldOffset(Offset = "0x88")]
		public FsmVector2 localPosition2d;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C40E8", Offset = "0x7C40E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C40E8", Offset = "0x7C40E8")]
		[Token(Token = "0x40019A0")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isHit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4138", Offset = "0x7C4138")]
		[Token(Token = "0x40019A1")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent hitEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4170", Offset = "0x7C4170")]
		[Token(Token = "0x40019A2")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent noHitEvent;

		[Token(Token = "0x40019A3")]
		[FieldOffset(Offset = "0xA8")]
		private RectTransform _rt;

		[Token(Token = "0x40019A4")]
		[FieldOffset(Offset = "0xB0")]
		private Camera _camera;

		[Token(Token = "0x6000F5C")]
		[Address(RVA = "0xB21390", Offset = "0xB21390", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EA8840]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225AA]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.screenPointVector2 = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.orScreenPointVector3 = v44;\n\tthis.normalizedScreenPoint = 0;\n\tv52 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.camera = v52;\n\tthis.everyFrame = 0;\n\tthis.noHitEvent = 0;\n\tthis.localPosition = 0;\n\tthis.isHit = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			screenPointVector2 = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			orScreenPointVector3 = fsmVector;
			normalizedScreenPoint = false;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			camera = fsmGameObject;
			everyFrame = false;
			noHitEvent = null;
			localPosition = null;
			isHit = null;
		}

		[Token(Token = "0x6000F5D")]
		[Address(RVA = "0xB2144C", Offset = "0xB2144C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA7590]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225AB]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv87 = *([v71 @ X8_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_002A;\n\tv94 = v71;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v94, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv80 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv96 = v80 == 0;\n\tif (v96) goto L_003A;\n\tv123 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v123;\nL_003A:\n\tv128 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.camera);\n\tv130 = v128 == 0;\n\tif (v130) goto L_0057;\n\tgoto L_004B;\n\tv137 = *([v133 @ X0_v21+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004B;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v50, v48, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004B:\n\tv54 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv152 = UnityEngine.Component::GetComponent(v54);\n\tgoto L_005E;\nL_0057:\n\tv56 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.camera);\n\tv152 = UnityEngine.GameObject::GetComponent(v56);\nL_005E:\n\tthis._camera = v152;\n\tHutongGames.PlayMaker.Actions.RectTransformScreenPointToLocalPointInRectangle::DoCheck(this);\n\tv109 = ~this.everyFrame;\n\tif (v109) goto L_0071;\n\treturn;\nL_0071:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F5E")]
		[Address(RVA = "0xB217B4", Offset = "0xB217B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformScreenPointToLocalPointInRectangle::DoCheck(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCheck();
		}

		[Token(Token = "0x6000F5F")]
		[Address(RVA = "0xB215A4", Offset = "0xB215A4", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0018;\n\tv24 = *([1EC1A10]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225AC]) = v44;\nL_0018:\n\t*([v14 @ X29_v1-18]) = 0;\n\tgoto L_0027;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0027;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0027:\n\tv62 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv64 = v62 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_00BB;\n\tv66 = this.screenPointVector2;\n\tv94 = v66.value.y;\n\tv213 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.orScreenPointVector3);\n\tv231 = v213 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_004B;\n\tv216 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\n\tv237 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\nL_004B:\n\tv246 = ~this.normalizedScreenPoint;\n\tif (v246) goto L_005D;\n\tv248 = UnityEngine.Screen::get_width();\n\tv252 = v240 * v248;\n\tv254 = UnityEngine.Screen::get_height();\n\tv94 = v94 * v254;\nL_005D:\n\tgoto L_0063;\n\tv264 = *([v258 @ X0_v16+E0]);\n\tv265 = v264 == 0;\n\tv266 = ~v265;\n\tgoto L_0063;\n\tv268 = \"il2cpp_codegen_runtime_class_init\"(v258, v241, v61, v29, v30, v31, v32, v33, v249, v234, v146, v37, v38, v39, v40, v41);\nL_0063:\n\tv99 = &v15 @ stack_-10_v2 - 0x18;\n\t// 105 MakeStruct v83 @ AGGB216CC_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v240 @ V8_v6 (UnityEngine.Vector3), v94 @ V9_v7 (System.Single)\n\tv170 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(this._rt, v83, this._camera, v99);\n\tv171 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.localPosition2d);\n\tv274 = v171 == 0;\n\tv275 = ~v274;\n\tif (v275) goto L_0081;\n\tv182 = this.localPosition2d;\n\tv182.value = *([v14 @ X29_v1-18]);\n\tv182.value.y = *([v14 @ X29_v1-14]);\nL_0081:\n\tv280 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.localPosition);\n\tv282 = v280 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_0099;\n\tv133 = this.localPosition;\n\tv126 = 0;\n\tv172 = 0x1586898(&v126 @ stack_-50_v5 (UnityEngine.Vector3), 0, v99, 0, v30, v31, v32, v33, *([v14 @ X29_v1-18]), *([v14 @ X29_v1-14]), 0, v37, v38, v39, v40, v41);\n\tv133.value = 0;\n\tv133.value.z = 0f;\nL_0099:\n\tv106 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isHit);\n\tv290 = v106 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_00A4;\n\tv184 = this.isHit;\n\tv184.value = v170;\nL_00A4:\n\tv295 = v170 == 0;\n\tif (v295) goto L_00AB;\n\tv101 = this.hitEvent;\n\tv296 = this.hitEvent == 0;\n\tv109 = ~v296;\n\tif (v109) goto L_00B2;\n\tgoto L_00BB;\nL_00AB:\n\tv101 = this.noHitEvent;\n\tv110 = this.noHitEvent == 0;\n\tif (v110) goto L_00BB;\nL_00B2:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v101);\nL_00BB:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoCheck()
		{
			//IL_012b: Expected O, but got F4
			//IL_01db: Expected O, but got I
			//IL_01f5: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
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
				num = orScreenPointVector3.Value.y;
				vector = value;
			}
			if (normalizedScreenPoint)
			{
				int width = Screen.width;
				float num2 = vector.x * (float)width;
				int height = Screen.height;
				num *= (float)height;
				vector = (Vector3)num2;
			}
			ref Vector2 localPoint = ref *(Vector2*)((long)(IntPtr)obj2 - 24L);
			Vector2 screenPoint = default(Vector2);
			screenPoint.x = vector.x;
			screenPoint.y = num;
			bool flag3 = RectTransformUtility.ScreenPointToLocalPointInRectangle(_rt, screenPoint, _camera, out localPoint);
			if (!localPosition2d.IsNone)
			{
				FsmVector2 fsmVector2 = localPosition2d;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-18]");
				fsmVector2.value = (Vector2)0;
				ref Vector2 value2 = ref fsmVector2.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-14]");
				value2.y = 0f;
			}
			if (!localPosition.IsNone)
			{
				FsmVector3 fsmVector3 = localPosition;
				Vector3 vector2 = default(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				fsmVector3.value = default(Vector3);
				fsmVector3.value.z = 0f;
			}
			if (!isHit.IsNone)
			{
				FsmBool fsmBool = isHit;
				fsmBool.value = flag3;
			}
			FsmEvent fsmEvent;
			if (flag3)
			{
				fsmEvent = hitEvent;
				if (hitEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = noHitEvent;
				if (noHitEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000F60")]
		[Address(RVA = "0xB217B8", Offset = "0xB217B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformScreenPointToLocalPointInRectangle()
		{
		}
	}
}
