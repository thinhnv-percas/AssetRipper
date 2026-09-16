using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C680", Offset = "0x75C680")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C680", Offset = "0x75C680")]
	[Token(Token = "0x200031A")]
	public class RectTransformSetPivot : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C527C", Offset = "0x7C527C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C527C", Offset = "0x7C527C")]
		[Token(Token = "0x40019E7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5314", Offset = "0x7C5314")]
		[Token(Token = "0x40019E8")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 pivot;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C534C", Offset = "0x7C534C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C534C", Offset = "0x7C534C")]
		[Token(Token = "0x40019E9")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C53A0", Offset = "0x7C53A0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C53A0", Offset = "0x7C53A0")]
		[Token(Token = "0x40019EA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Token(Token = "0x40019EB")]
		[FieldOffset(Offset = "0x70")]
		private RectTransform _rt;

		[Token(Token = "0x6000F93")]
		[Address(RVA = "0xB2369C", Offset = "0xB2369C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFF480]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225C5]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tthis.pivot = 0;\n\tv48 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.x = v48;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.y = v54;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			pivot = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
		}

		[Token(Token = "0x6000F94")]
		[Address(RVA = "0xB23748", Offset = "0xB23748", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECFC80]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225C6]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformSetPivot::DoSetPivotPosition(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			DoSetPivotPosition();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F95")]
		[Address(RVA = "0xB238F0", Offset = "0xB238F0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformSetPivot::DoSetPivotPosition(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoSetPivotPosition();
		}

		[Token(Token = "0x6000F96")]
		[Address(RVA = "0xB23824", Offset = "0xB23824", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.RectTransform::get_pivot(this._rt);\n\tv80 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.pivot);\n\tv84 = v80 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0022;\n\tv71 = this.pivot;\n\tv28 = v71.value;\n\tv24 = v71.value.y;\nL_0022:\n\tv111 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv113 = v111 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_0031;\n\tv116 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0031:\n\tv120 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv122 = v120 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0048;\n\tv125 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0048:\n\t// 72 MakeStruct v87 @ AGGB238E0_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v28 @ V8_v5 (UnityEngine.Vector2), v24 @ V9_v5 (System.Single)\n\tUnityEngine.RectTransform::set_pivot(this._rt, v87);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetPivotPosition()
		{
			//IL_00e1: Expected O, but got F4
			Vector2 vector = _rt.pivot;
			bool isNone = pivot.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = vector.y;
			Vector2 vector2 = vector;
			if (!flag2)
			{
				FsmVector2 fsmVector = pivot;
				vector2 = fsmVector.value;
				num = fsmVector.value.y;
			}
			if (!x.IsNone)
			{
				float value = x.Value;
				vector2 = (Vector2)value;
			}
			if (!y.IsNone)
			{
				float value2 = y.Value;
				num = value2;
			}
			Vector2 vector3 = default(Vector2);
			vector3.x = vector2.x;
			vector3.y = num;
			_rt.pivot = vector3;
		}

		[Token(Token = "0x6000F97")]
		[Address(RVA = "0xB238F4", Offset = "0xB238F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformSetPivot()
		{
		}
	}
}
