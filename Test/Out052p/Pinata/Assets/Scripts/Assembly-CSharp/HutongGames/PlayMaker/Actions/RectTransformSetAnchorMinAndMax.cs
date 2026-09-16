using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C440", Offset = "0x75C440")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C440", Offset = "0x75C440")]
	[Token(Token = "0x2000314")]
	public class RectTransformSetAnchorMinAndMax : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C490C", Offset = "0x7C490C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C490C", Offset = "0x7C490C")]
		[Token(Token = "0x40019C0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C49A4", Offset = "0x7C49A4")]
		[Token(Token = "0x40019C1")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 anchorMax;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C49DC", Offset = "0x7C49DC")]
		[Token(Token = "0x40019C2")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 anchorMin;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4A14", Offset = "0x7C4A14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4A14", Offset = "0x7C4A14")]
		[Token(Token = "0x40019C3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat xMax;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4A68", Offset = "0x7C4A68")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4A68", Offset = "0x7C4A68")]
		[Token(Token = "0x40019C4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat yMax;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4ABC", Offset = "0x7C4ABC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4ABC", Offset = "0x7C4ABC")]
		[Token(Token = "0x40019C5")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat xMin;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4B10", Offset = "0x7C4B10")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4B10", Offset = "0x7C4B10")]
		[Token(Token = "0x40019C6")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat yMin;

		[Token(Token = "0x40019C7")]
		[FieldOffset(Offset = "0x88")]
		private RectTransform _rt;

		[Token(Token = "0x6000F75")]
		[Address(RVA = "0xB22058", Offset = "0xB22058", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF0098]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225B4]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.anchorMax = 0;\n\tthis.anchorMin = 0;\n\tthis.gameObject = 0;\n\tv48 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.xMax = v48;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.yMax = v54;\n\tv62 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.xMin = v62;\n\tv63 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.yMin = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			anchorMax = null;
			anchorMin = null;
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			xMax = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			yMax = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			xMin = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			yMin = fsmFloat4;
		}

		[Token(Token = "0x6000F76")]
		[Address(RVA = "0xB2214C", Offset = "0xB2214C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFA0E8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225B5]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformSetAnchorMinAndMax::DoSetAnchorMax(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			DoSetAnchorMax();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F77")]
		[Address(RVA = "0xB22388", Offset = "0xB22388", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformSetAnchorMinAndMax::DoSetAnchorMax(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoSetAnchorMax();
		}

		[Token(Token = "0x6000F78")]
		[Address(RVA = "0xB22228", Offset = "0xB22228", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv54 = UnityEngine.RectTransform::get_anchorMin(this._rt);\n\tv128 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.anchorMax);\n\tv160 = v128 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0031;\n\tv116 = this.anchorMax;\n\tv114 = this.anchorMin;\n\tv46 = v116.value;\n\tv42 = v116.value.y;\n\tv38 = v114.value;\n\tv34 = v114.value.y;\nL_0031:\n\tv167 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.xMax);\n\tv169 = v167 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0040;\n\tv172 = HutongGames.PlayMaker.FsmFloat::get_Value(this.xMax);\nL_0040:\n\tv176 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.yMax);\n\tv178 = v176 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_004F;\n\tv181 = HutongGames.PlayMaker.FsmFloat::get_Value(this.yMax);\nL_004F:\n\tv185 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.xMin);\n\tv187 = v185 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_005E;\n\tv190 = HutongGames.PlayMaker.FsmFloat::get_Value(this.xMin);\nL_005E:\n\tv194 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.yMin);\n\tv196 = v194 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_006F;\n\tv199 = HutongGames.PlayMaker.FsmFloat::get_Value(this.yMin);\nL_006F:\n\t// 111 MakeStruct v24 @ AGGB22350_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v46 @ V8_v5 (UnityEngine.Vector2), v42 @ V9_v5 (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(this._rt, v24);\n\t// 127 MakeStruct v132 @ AGGB22378_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v38 @ V10_v5 (UnityEngine.Vector2), v34 @ V11_v5 (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(this._rt, v132);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAnchorMax()
		{
			//IL_0138: Expected O, but got F4
			//IL_01de: Expected O, but got F4
			Vector2 vector = _rt.anchorMax;
			Vector2 vector2 = _rt.anchorMin;
			bool isNone = anchorMax.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float y = vector2.y;
			Vector2 vector3 = vector2;
			float y2 = vector.y;
			Vector2 vector4 = vector;
			if (!flag2)
			{
				FsmVector2 fsmVector = anchorMax;
				FsmVector2 fsmVector2 = anchorMin;
				vector4 = fsmVector.value;
				y2 = fsmVector.value.y;
				vector3 = fsmVector2.value;
				y = fsmVector2.value.y;
			}
			if (!xMax.IsNone)
			{
				float value = xMax.Value;
				vector4 = (Vector2)value;
			}
			if (!yMax.IsNone)
			{
				float value2 = yMax.Value;
				y2 = value2;
			}
			if (!xMin.IsNone)
			{
				float value3 = xMin.Value;
				vector3 = (Vector2)value3;
			}
			if (!yMin.IsNone)
			{
				float value4 = yMin.Value;
				y = value4;
			}
			Vector2 vector5 = default(Vector2);
			vector5.x = vector4.x;
			vector5.y = y2;
			_rt.anchorMax = vector5;
			Vector2 vector6 = default(Vector2);
			vector6.x = vector3.x;
			vector6.y = y;
			_rt.anchorMin = vector6;
		}

		[Token(Token = "0x6000F79")]
		[Address(RVA = "0xB2238C", Offset = "0xB2238C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformSetAnchorMinAndMax()
		{
		}
	}
}
