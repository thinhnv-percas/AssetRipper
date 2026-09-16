using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C2C0", Offset = "0x75C2C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C2C0", Offset = "0x75C2C0")]
	[Token(Token = "0x2000310")]
	public class RectTransformScreenPointToWorldPointInRectangle : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C41A8", Offset = "0x7C41A8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C41A8", Offset = "0x7C41A8")]
		[Token(Token = "0x40019A5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4240", Offset = "0x7C4240")]
		[Token(Token = "0x40019A6")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 screenPointVector2;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4278", Offset = "0x7C4278")]
		[Token(Token = "0x40019A7")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 orScreenPointVector3;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C42B0", Offset = "0x7C42B0")]
		[Token(Token = "0x40019A8")]
		[FieldOffset(Offset = "0x68")]
		public bool normalizedScreenPoint;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C42E8", Offset = "0x7C42E8")]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C42E8", Offset = "0x7C42E8")]
		[Token(Token = "0x40019A9")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject camera;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4370", Offset = "0x7C4370")]
		[Token(Token = "0x40019AA")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7C43A8", Offset = "0x7C43A8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C43A8", Offset = "0x7C43A8")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C43A8", Offset = "0x7C43A8")]
		[Token(Token = "0x40019AB")]
		[FieldOffset(Offset = "0x80")]
		public FsmVector3 worldPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C441C", Offset = "0x7C441C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C441C", Offset = "0x7C441C")]
		[Token(Token = "0x40019AC")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool isHit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C446C", Offset = "0x7C446C")]
		[Token(Token = "0x40019AD")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent hitEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C44A4", Offset = "0x7C44A4")]
		[Token(Token = "0x40019AE")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent noHitEvent;

		[Token(Token = "0x40019AF")]
		[FieldOffset(Offset = "0xA0")]
		private RectTransform _rt;

		[Token(Token = "0x40019B0")]
		[FieldOffset(Offset = "0xA8")]
		private Camera _camera;

		[Token(Token = "0x6000F61")]
		[Address(RVA = "0xB217C0", Offset = "0xB217C0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECA288]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225AD]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.screenPointVector2 = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.orScreenPointVector3 = v44;\n\tthis.normalizedScreenPoint = 0;\n\tv52 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.camera = v52;\n\tthis.everyFrame = 0;\n\tthis.worldPosition = 0;\n\tthis.hitEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			worldPosition = null;
			hitEvent = null;
		}

		[Token(Token = "0x6000F62")]
		[Address(RVA = "0xB21878", Offset = "0xB21878", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAB2D0]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225AE]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv87 = *([v71 @ X8_v7+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_002A;\n\tv94 = v71;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v94, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv80 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv96 = v80 == 0;\n\tif (v96) goto L_003A;\n\tv123 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v123;\nL_003A:\n\tv128 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.camera);\n\tv130 = v128 == 0;\n\tif (v130) goto L_0057;\n\tgoto L_004B;\n\tv137 = *([v133 @ X0_v21+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004B;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v50, v48, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004B:\n\tv54 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv152 = UnityEngine.Component::GetComponent(v54);\n\tgoto L_005E;\nL_0057:\n\tv56 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.camera);\n\tv152 = UnityEngine.GameObject::GetComponent(v56);\nL_005E:\n\tthis._camera = v152;\n\tHutongGames.PlayMaker.Actions.RectTransformScreenPointToWorldPointInRectangle::DoCheck(this);\n\tv109 = ~this.everyFrame;\n\tif (v109) goto L_0071;\n\treturn;\nL_0071:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F63")]
		[Address(RVA = "0xB21B8C", Offset = "0xB21B8C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformScreenPointToWorldPointInRectangle::DoCheck(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCheck();
		}

		[Token(Token = "0x6000F64")]
		[Address(RVA = "0xB219D0", Offset = "0xB219D0", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EA7D00]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225AF]) = v44;\nL_001F:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv64 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv66 = v64 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_009A;\n\tv68 = this.screenPointVector2;\n\tv92 = v68.value.y;\n\tv189 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.orScreenPointVector3);\n\tv203 = v189 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_004C;\n\tv192 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\n\tv209 = HutongGames.PlayMaker.FsmVector3::get_Value(this.orScreenPointVector3);\nL_004C:\n\tv218 = ~this.normalizedScreenPoint;\n\tif (v218) goto L_005E;\n\tv220 = UnityEngine.Screen::get_width();\n\tv224 = v212 * v220;\n\tv226 = UnityEngine.Screen::get_height();\n\tv92 = v92 * v226;\nL_005E:\n\tgoto L_006A;\n\tv236 = *([v230 @ X0_v16+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tgoto L_006A;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v230, v213, v63, v29, v30, v31, v32, v33, v221, v206, v86, v37, v38, v39, v40, v41);\nL_006A:\n\t// 106 MakeStruct v79 @ AGGB21AFC_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v212 @ V8_v6 (UnityEngine.Vector3), v92 @ V9_v7 (System.Single)\n\tv153 = UnityEngine.RectTransformUtility::ScreenPointToWorldPointInRectangle(this._rt, v79, this._camera, &v84 @ stack_-50_v5 (UnityEngine.Vector3));\n\tv160 = this.worldPosition;\n\tv160.value = v84;\n\tv160.value.z = 0f;\n\tv104 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isHit);\n\tv245 = v104 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_0083;\n\tv161 = this.isHit;\n\tv161.value = v153;\nL_0083:\n\tv250 = v153 == 0;\n\tif (v250) goto L_008A;\n\tv99 = this.hitEvent;\n\tv251 = this.hitEvent == 0;\n\tv107 = ~v251;\n\tif (v107) goto L_0091;\n\tgoto L_009A;\nL_008A:\n\tv99 = this.noHitEvent;\n\tv108 = this.noHitEvent == 0;\n\tif (v108) goto L_009A;\nL_0091:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v99);\nL_009A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheck()
		{
			//IL_0123: Expected O, but got F4
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
			Vector2 screenPoint = default(Vector2);
			screenPoint.x = vector.x;
			screenPoint.y = num;
			bool flag3 = RectTransformUtility.ScreenPointToWorldPointInRectangle(_rt, screenPoint, _camera, out var worldPoint);
			FsmVector3 fsmVector2 = worldPosition;
			fsmVector2.value = worldPoint;
			fsmVector2.value.z = 0f;
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

		[Token(Token = "0x6000F65")]
		[Address(RVA = "0xB21B90", Offset = "0xB21B90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformScreenPointToWorldPointInRectangle()
		{
		}
	}
}
