using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C200", Offset = "0x75C200")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75C200", Offset = "0x75C200")]
	[Token(Token = "0x200030E")]
	public class RectTransformPixelAdjustRect : BaseUpdateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C3C70", Offset = "0x7C3C70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3C70", Offset = "0x7C3C70")]
		[Token(Token = "0x4001993")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C3D08", Offset = "0x7C3D08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3D08", Offset = "0x7C3D08")]
		[Token(Token = "0x4001994")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject canvas;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C3DA0", Offset = "0x7C3DA0")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C3DA0", Offset = "0x7C3DA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C3DA0", Offset = "0x7C3DA0")]
		[Token(Token = "0x4001995")]
		[FieldOffset(Offset = "0x60")]
		public FsmRect pixelRect;

		[Token(Token = "0x4001996")]
		[FieldOffset(Offset = "0x68")]
		private RectTransform _rt;

		[Token(Token = "0x4001997")]
		[FieldOffset(Offset = "0x70")]
		private Canvas _canvas;

		[Token(Token = "0x6000F57")]
		[Address(RVA = "0xB2104C", Offset = "0xB2104C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED2D90]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225A7]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv44 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.canvas = v44;\n\tthis.pixelRect = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			canvas = fsmGameObject;
			pixelRect = null;
		}

		[Token(Token = "0x6000F58")]
		[Address(RVA = "0xB210D0", Offset = "0xB210D0", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EE2EC8]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225A8]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002D;\n\tv109 = *([v69 @ X8_v5+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_002D;\n\tv116 = v69;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v116, v47, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv92 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv118 = v92 == 0;\n\tif (v118) goto L_003D;\n\tv156 = UnityEngine.GameObject::GetComponent(v49);\n\tthis._rt = v156;\nL_003D:\n\tv162 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.canvas);\n\tgoto L_004D;\n\tv166 = *([v102 @ X8_v7+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_004D;\n\tv173 = v102;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v173, v161, v56, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tv93 = UnityEngine.Object::op_Inequality(v162, 0);\n\tv175 = v93 == 0;\n\tif (v175) goto L_005E;\n\tv183 = UnityEngine.GameObject::GetComponent(v162);\n\tv74 = this + 0x70;\n\tthis._canvas = v183;\n\tgoto L_0064;\nL_005E:\n\tv74 = this + 0x70;\n\tv77 = this._canvas;\nL_0064:\n\tgoto L_006D;\n\tv195 = *([v190 @ X0_v19+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tgoto L_006D;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v190, v186, v83, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006D:\n\tv205 = UnityEngine.Object::op_Equality(v77, 0);\n\tv207 = v205 == 0;\n\tif (v207) goto L_00A3;\n\tgoto L_007E;\n\tv220 = *([v208 @ X0_v26+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_007E;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v208, v203, v204, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_007E:\n\tv94 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv216 = v94 == 0;\n\tif (v216) goto L_00A3;\n\tv233 = UnityEngine.GameObject::GetComponent(v49);\n\tgoto L_0098;\n\tv237 = *([v104 @ X8_v17+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tif (v239) goto L_0098;\n\tv244 = v104;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v244, v232, v84, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0098:\n\tv95 = UnityEngine.Object::op_Inequality(v233, 0);\n\tv217 = v95 == 0;\n\tif (v217) goto L_00A3;\n\tv214 = UnityEngine.UI.Graphic::get_canvas(v233);\n\t*([v74 @ X23_v2]) = v214;\nL_00A3:\n\tHutongGames.PlayMaker.Actions.RectTransformPixelAdjustRect::DoAction(this);\n\tv142 = this.everyFrame == 0;\n\tif (v142) goto L_00BB;\n\treturn;\nL_00BB:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_00e1: Expected O, but got I
			//IL_00be: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			GameObject value = this.canvas.Value;
			Canvas canvas;
			if (value != null)
			{
				Canvas component2 = value.GetComponent<Canvas>();
				object obj = (long)(IntPtr)this + 112L;
				_canvas = component2;
				canvas = component2;
			}
			else
			{
				object obj = (long)(IntPtr)this + 112L;
				canvas = _canvas;
			}
			if (canvas == null && ownerDefaultTarget != null)
			{
				Graphic component3 = ownerDefaultTarget.GetComponent<Graphic>();
				if (component3 != null)
				{
					Canvas canvas2 = component3.canvas;
					object obj = canvas2;
				}
			}
			DoAction();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F59")]
		[Address(RVA = "0xB21384", Offset = "0xB21384", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformPixelAdjustRect::DoAction(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoAction();
		}

		[Token(Token = "0x6000F5A")]
		[Address(RVA = "0xB212F0", Offset = "0xB212F0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EEE468]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20225A9]) = v40;\nL_0016:\n\tv43 = this.pixelRect;\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv60 = UnityEngine.RectTransformUtility::PixelAdjustRect(this._rt, this._canvas);\n\tv43.value = v60;\n\tv43.value.m_YMin = v60.m_YMin;\n\tv43.value.m_Width = v60.m_Width;\n\tv43.value.m_Height = v60.m_Height;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAction()
		{
			FsmRect fsmRect = pixelRect;
			Rect rect = (fsmRect.value = RectTransformUtility.PixelAdjustRect(_rt, _canvas));
			fsmRect.value.y = rect.y;
			fsmRect.value.width = rect.width;
			fsmRect.value.height = rect.height;
		}

		[Token(Token = "0x6000F5B")]
		[Address(RVA = "0xB21388", Offset = "0xB21388", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformPixelAdjustRect()
		{
		}
	}
}
