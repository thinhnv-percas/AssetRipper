using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C500", Offset = "0x75C500")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C500", Offset = "0x75C500")]
	[Token(Token = "0x2000316")]
	public class RectTransformSetLocalPosition : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C4CD4", Offset = "0x7C4CD4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4CD4", Offset = "0x7C4CD4")]
		[Token(Token = "0x40019D0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4D6C", Offset = "0x7C4D6C")]
		[Token(Token = "0x40019D1")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 position2d;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4DA4", Offset = "0x7C4DA4")]
		[Token(Token = "0x40019D2")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4DDC", Offset = "0x7C4DDC")]
		[Token(Token = "0x40019D3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4E14", Offset = "0x7C4E14")]
		[Token(Token = "0x40019D4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4E4C", Offset = "0x7C4E4C")]
		[Token(Token = "0x40019D5")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat z;

		[Token(Token = "0x40019D6")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform _rt;

		[Token(Token = "0x6000F7F")]
		[Address(RVA = "0xB22AD0", Offset = "0xB22AD0", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ECB490]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225BB]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv48 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.position2d = v48;\n\tv56 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v56);\n\tv56.useVariable = 1;\n\tthis.position = v56;\n\tv67 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v67);\n\tv67.useVariable = 1;\n\tthis.x = v67;\n\tv68 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v68);\n\tv68.useVariable = 1;\n\tthis.y = v68;\n\tv69 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v69);\n\tv69.useVariable = 1;\n\tthis.z = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			position2d = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			position = fsmVector2;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			z = fsmFloat3;
		}

		[Token(Token = "0x6000F80")]
		[Address(RVA = "0xB22BF4", Offset = "0xB22BF4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBA040]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225BC]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformSetLocalPosition::DoSetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			DoSetValues();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F81")]
		[Address(RVA = "0xB22E74", Offset = "0xB22E74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformSetLocalPosition::DoSetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoSetValues();
		}

		[Token(Token = "0x6000F82")]
		[Address(RVA = "0xB22CD0", Offset = "0xB22CD0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EB2DA8]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225BD]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\treturn;\nL_0037:\n\tv116 = UnityEngine.Transform::get_localPosition(this._rt);\n\tv179 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv181 = v179 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0054;\n\tv185 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\nL_0054:\n\tv175 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position2d);\n\tv193 = v175 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0062;\n\tv177 = this.position2d;\n\tv131 = v177.value.y;\nL_0062:\n\tv198 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv200 = v198 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0071;\n\tv202 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0071:\n\tv207 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv209 = v207 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0080;\n\tv211 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0080:\n\tv216 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv218 = v216 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_009A;\n\tv220 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_009A:\n\t// 154 MakeStruct v76 @ AGGB22E64_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v140 @ V9_v6 (UnityEngine.Vector3), v131 @ V10_v6 (System.Single), v136 @ V8_v5 (System.Single)\n\tUnityEngine.Transform::set_localPosition(this._rt, v76);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetValues()
		{
			//IL_018e: Expected O, but got F4
			if (!(_rt == null))
			{
				Vector3 localPosition = _rt.localPosition;
				bool isNone = position.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float num = localPosition.y;
				float num2 = localPosition.z;
				Vector3 vector = localPosition;
				if (!flag2)
				{
					Vector3 value = position.Value;
					num = value.y;
					num2 = value.z;
					vector = value;
				}
				if (!position2d.IsNone)
				{
					FsmVector2 fsmVector = position2d;
					num = fsmVector.value.y;
					vector = fsmVector.value;
				}
				if (!x.IsNone)
				{
					float value2 = x.Value;
					vector = (Vector3)value2;
				}
				if (!y.IsNone)
				{
					float value3 = y.Value;
					num = value3;
				}
				if (!z.IsNone)
				{
					float value4 = z.Value;
					num2 = value4;
				}
				Vector3 localPosition2 = default(Vector3);
				localPosition2.x = vector.x;
				localPosition2.y = num;
				localPosition2.z = num2;
				_rt.localPosition = localPosition2;
			}
		}

		[Token(Token = "0x6000F83")]
		[Address(RVA = "0xB22E78", Offset = "0xB22E78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformSetLocalPosition()
		{
		}
	}
}
