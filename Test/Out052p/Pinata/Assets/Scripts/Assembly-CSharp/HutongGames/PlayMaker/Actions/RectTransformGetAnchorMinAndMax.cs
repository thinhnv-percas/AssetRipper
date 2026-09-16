using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BEA0", Offset = "0x75BEA0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BEA0", Offset = "0x75BEA0")]
	[Token(Token = "0x2000305")]
	public class RectTransformGetAnchorMinAndMax : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C2D34", Offset = "0x7C2D34")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2D34", Offset = "0x7C2D34")]
		[Token(Token = "0x400195C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2DCC", Offset = "0x7C2DCC")]
		[Token(Token = "0x400195D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 anchorMax;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2E04", Offset = "0x7C2E04")]
		[Token(Token = "0x400195E")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 anchorMin;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C2E3C", Offset = "0x7C2E3C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2E3C", Offset = "0x7C2E3C")]
		[Token(Token = "0x400195F")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat xMax;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C2E90", Offset = "0x7C2E90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2E90", Offset = "0x7C2E90")]
		[Token(Token = "0x4001960")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat yMax;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C2EE4", Offset = "0x7C2EE4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2EE4", Offset = "0x7C2EE4")]
		[Token(Token = "0x4001961")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat xMin;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C2F38", Offset = "0x7C2F38")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2F38", Offset = "0x7C2F38")]
		[Token(Token = "0x4001962")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat yMin;

		[Token(Token = "0x4001963")]
		[FieldOffset(Offset = "0x88")]
		private RectTransform _rt;

		[Token(Token = "0x6000F2A")]
		[Address(RVA = "0xB1F81C", Offset = "0xB1F81C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.yMin = 0;\n\tthis.anchorMin = 0;\n\tthis.yMax = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			yMin = null;
			anchorMin = null;
			yMax = null;
			gameObject = null;
		}

		[Token(Token = "0x6000F2B")]
		[Address(RVA = "0xB1F850", Offset = "0xB1F850", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFCC78]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022597]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformGetAnchorMinAndMax::DoGetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			DoGetValues();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F2C")]
		[Address(RVA = "0xB1FA74", Offset = "0xB1FA74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformGetAnchorMinAndMax::DoGetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6000F2D")]
		[Address(RVA = "0xB1F92C", Offset = "0xB1F92C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.anchorMax);\n\tv86 = v15 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_001F;\n\tv103 = this.anchorMax;\n\tv96 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv103.value = v96;\n\tv103.value.y = v96.y;\nL_001F:\n\tv129 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.anchorMin);\n\tv149 = v129 == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0033;\n\tv104 = this.anchorMin;\n\tv97 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv104.value = v97;\n\tv104.value.y = v97.y;\nL_0033:\n\tv153 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.xMax);\n\tv155 = v153 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0046;\n\tv105 = this.xMax;\n\tv98 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv105.value = v98;\nL_0046:\n\tv159 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.yMax);\n\tv161 = v159 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0059;\n\tv106 = this.yMax;\n\tv99 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv106.value = v99.y;\nL_0059:\n\tv165 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.xMin);\n\tv167 = v165 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_006C;\n\tv107 = this.xMin;\n\tv100 = UnityEngine.RectTransform::get_anchorMin(this._rt);\n\tv107.value = v100;\nL_006C:\n\tv171 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.yMin);\n\tv173 = v171 == 0;\n\tv174 = ~v173;\n\tif (v174) goto L_0080;\n\tv124 = this.yMin;\n\tv101 = UnityEngine.RectTransform::get_anchorMin(this._rt);\n\tv124.value = v101.y;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValues()
		{
			if (!anchorMax.IsNone)
			{
				FsmVector2 fsmVector = anchorMax;
				Vector2 vector = (fsmVector.value = _rt.anchorMax);
				fsmVector.value.y = vector.y;
			}
			if (!anchorMin.IsNone)
			{
				FsmVector2 fsmVector2 = anchorMin;
				Vector2 vector2 = (fsmVector2.value = _rt.anchorMax);
				fsmVector2.value.y = vector2.y;
			}
			if (!xMax.IsNone)
			{
				FsmFloat fsmFloat = xMax;
				fsmFloat.Value = _rt.anchorMax.x;
			}
			if (!yMax.IsNone)
			{
				FsmFloat fsmFloat2 = yMax;
				fsmFloat2.Value = _rt.anchorMax.y;
			}
			if (!xMin.IsNone)
			{
				FsmFloat fsmFloat3 = xMin;
				fsmFloat3.Value = _rt.anchorMin.x;
			}
			if (!yMin.IsNone)
			{
				FsmFloat fsmFloat4 = yMin;
				fsmFloat4.Value = _rt.anchorMin.y;
			}
		}

		[Token(Token = "0x6000F2E")]
		[Address(RVA = "0xB1FA78", Offset = "0xB1FA78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformGetAnchorMinAndMax()
		{
		}
	}
}
