using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C740", Offset = "0x75C740")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C740", Offset = "0x75C740")]
	[Token(Token = "0x200031C")]
	public class RectTransformWorldToScreenPoint : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C5534", Offset = "0x7C5534")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5534", Offset = "0x7C5534")]
		[Token(Token = "0x40019F1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C55CC", Offset = "0x7C55CC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C55CC", Offset = "0x7C55CC")]
		[Token(Token = "0x40019F2")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault camera;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C5654", Offset = "0x7C5654")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5654", Offset = "0x7C5654")]
		[Token(Token = "0x40019F3")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 screenPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C56A4", Offset = "0x7C56A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C56A4", Offset = "0x7C56A4")]
		[Token(Token = "0x40019F4")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat screenX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C56F4", Offset = "0x7C56F4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C56F4", Offset = "0x7C56F4")]
		[Token(Token = "0x40019F5")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat screenY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5744", Offset = "0x7C5744")]
		[Token(Token = "0x40019F6")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool normalize;

		[Token(Token = "0x40019F7")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform _rt;

		[Token(Token = "0x40019F8")]
		[FieldOffset(Offset = "0x88")]
		private Camera _cam;

		[Token(Token = "0x6000F9D")]
		[Address(RVA = "0xB23B5C", Offset = "0xB23B5C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF3000]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225C9]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv48 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v48);\n\tthis.camera = v48;\n\tv48.ownerOption = 1;\n\tv55 = this.camera;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 1;\n\tv55.gameObject = v57;\n\tthis.everyFrame = 0;\n\tthis.screenX = 0;\n\tthis.screenY = 0;\n\tthis.screenPoint = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			(camera = new FsmOwnerDefault()).OwnerOption = OwnerDefaultOption.SpecifyGameObject;
			FsmOwnerDefault fsmOwnerDefault = camera;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			fsmOwnerDefault.GameObject = fsmGameObject;
			everyFrame = false;
			screenX = null;
			screenY = null;
			screenPoint = null;
		}

		[Token(Token = "0x6000F9E")]
		[Address(RVA = "0xB23C24", Offset = "0xB23C24", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA70E8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225CA]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv89 = *([v65 @ X8_v5+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_002B;\n\tv96 = v65;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v96, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv79 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv98 = v79 == 0;\n\tif (v98) goto L_003C;\n\tv128 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._rt = v128;\nL_003C:\n\tv135 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.camera);\n\tgoto L_004C;\n\tv139 = *([v85 @ X8_v7+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_004C;\n\tv146 = v85;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v146, v133, v134, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004C:\n\tv80 = UnityEngine.Object::op_Inequality(v135, 0);\n\tv148 = v80 == 0;\n\tif (v148) goto L_0059;\n\tv151 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._cam = v151;\nL_0059:\n\tHutongGames.PlayMaker.Actions.RectTransformWorldToScreenPoint::DoWorldToScreenPoint(this);\n\tv114 = ~this.everyFrame;\n\tif (v114) goto L_006C;\n\treturn;\nL_006C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(camera);
			if (ownerDefaultTarget2 != null)
			{
				Camera component2 = ownerDefaultTarget.GetComponent<Camera>();
				_cam = component2;
			}
			DoWorldToScreenPoint();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F9F")]
		[Address(RVA = "0xB23EB8", Offset = "0xB23EB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformWorldToScreenPoint::DoWorldToScreenPoint(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoWorldToScreenPoint();
		}

		[Token(Token = "0x6000FA0")]
		[Address(RVA = "0xB23D70", Offset = "0xB23D70", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EA5D48]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225CB]) = v44;\nL_001B:\n\tv49 = UnityEngine.Transform::get_position(this._rt);\n\tgoto L_0033;\n\tv98 = *([v94 @ X0_v5+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0033;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v94, v48, v28, v29, v30, v31, v32, v33, v49, v88, v89, v37, v38, v39, v40, v41);\nL_0033:\n\tv72 = UnityEngine.RectTransformUtility::WorldToScreenPoint(this._cam, v49);\n\tv133 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv135 = v133 == 0;\n\tif (v135) goto L_0049;\n\tv137 = UnityEngine.Screen::get_width();\n\tv59 = v72 / v137;\n\tv143 = UnityEngine.Screen::get_height();\n\tv62 = v72.y / v143;\nL_0049:\n\tv86 = this.screenPoint;\n\tgoto L_0057;\n\tv152 = *([v146 @ X0_v11+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tgoto L_0057;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v146, v74, v28, v29, v30, v31, v32, v33, v140, v69, v66, v37, v38, v39, v40, v41);\nL_0057:\n\t// 87 MakeStruct v51 @ AGGB23E70_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v59 @ V9_v4 (System.Single), v62 @ V8_v4 (System.Single)\n\tv71 = UnityEngine.Vector2::op_Implicit(v51);\n\tv86.value = v71;\n\tv86.value.y = v71.y;\n\tv86.value.z = v71.z;\n\tv162 = this.screenX;\n\tv162.value = v59;\n\tv128 = this.screenY;\n\tv128.value = v62;\n\treturn;\n\tv77 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoWorldToScreenPoint()
		{
			Vector3 position = _rt.position;
			Vector2 vector = RectTransformUtility.WorldToScreenPoint(_cam, position);
			bool value = normalize.Value;
			bool flag = !value;
			float num = vector.x;
			float num2 = vector.y;
			if (!flag)
			{
				int width = Screen.width;
				num = vector.x / (float)width;
				int height = Screen.height;
				num2 = vector.y / (float)height;
			}
			FsmVector3 fsmVector = screenPoint;
			Vector2 vector2 = default(Vector2);
			vector2.x = num;
			vector2.y = num2;
			Vector3 vector3 = (fsmVector.value = vector2);
			fsmVector.value.y = vector3.y;
			fsmVector.value.z = vector3.z;
			FsmFloat fsmFloat = screenX;
			fsmFloat.Value = num;
			FsmFloat fsmFloat2 = screenY;
			fsmFloat2.Value = num2;
		}

		[Token(Token = "0x6000FA1")]
		[Address(RVA = "0xB23EBC", Offset = "0xB23EBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformWorldToScreenPoint()
		{
		}
	}
}
