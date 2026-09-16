using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C560", Offset = "0x75C560")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C560", Offset = "0x75C560")]
	[Token(Token = "0x2000317")]
	public class RectTransformSetLocalRotation : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C4E84", Offset = "0x7C4E84")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4E84", Offset = "0x7C4E84")]
		[Token(Token = "0x40019D7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4F1C", Offset = "0x7C4F1C")]
		[Token(Token = "0x40019D8")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 rotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4F54", Offset = "0x7C4F54")]
		[Token(Token = "0x40019D9")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4F8C", Offset = "0x7C4F8C")]
		[Token(Token = "0x40019DA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C4FC4", Offset = "0x7C4FC4")]
		[Token(Token = "0x40019DB")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Token(Token = "0x40019DC")]
		[FieldOffset(Offset = "0x78")]
		private RectTransform _rt;

		[Token(Token = "0x6000F84")]
		[Address(RVA = "0xB22E80", Offset = "0xB22E80", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFA448]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225BE]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv48 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.rotation = v48;\n\tv56 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v56);\n\tv56.useVariable = 1;\n\tthis.x = v56;\n\tv65 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v65);\n\tv65.useVariable = 1;\n\tthis.y = v65;\n\tv66 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v66);\n\tv66.useVariable = 1;\n\tthis.z = v66;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			rotation = fsmVector;
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

		[Token(Token = "0x6000F85")]
		[Address(RVA = "0xB22F78", Offset = "0xB22F78", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED6F08]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225BF]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformSetLocalRotation::DoSetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F86")]
		[Address(RVA = "0xB231D0", Offset = "0xB231D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformSetLocalRotation::DoSetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoSetValues();
		}

		[Token(Token = "0x6000F87")]
		[Address(RVA = "0xB23054", Offset = "0xB23054", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EFF138]);\n\tv25 = *([v24 @ X8_v9]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225C0]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\treturn;\nL_0037:\n\tv113 = UnityEngine.Transform::get_eulerAngles(this._rt);\n\tv156 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv158 = v156 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0054;\n\tv162 = HutongGames.PlayMaker.FsmVector3::get_Value(this.rotation);\nL_0054:\n\tv169 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv171 = v169 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0063;\n\tv173 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0063:\n\tv178 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv180 = v178 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_0072;\n\tv182 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_0072:\n\tv187 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv189 = v187 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_008C;\n\tv191 = HutongGames.PlayMaker.FsmFloat::get_Value(this.z);\nL_008C:\n\t// 140 MakeStruct v76 @ AGGB231C8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v127 @ V8_v4 (UnityEngine.Vector3), v130 @ V9_v4 (System.Single), v124 @ V10_v4 (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(this._rt, v76);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetValues()
		{
			//IL_0124: Expected O, but got F4
			if (!(_rt == null))
			{
				Vector3 eulerAngles = _rt.eulerAngles;
				bool isNone = rotation.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float num = eulerAngles.z;
				Vector3 vector = eulerAngles;
				float num2 = eulerAngles.y;
				if (!flag2)
				{
					Vector3 value = rotation.Value;
					num = value.z;
					vector = value;
					num2 = value.y;
				}
				if (!x.IsNone)
				{
					float value2 = x.Value;
					vector = (Vector3)value2;
				}
				if (!y.IsNone)
				{
					float value3 = y.Value;
					num2 = value3;
				}
				if (!z.IsNone)
				{
					float value4 = z.Value;
					num = value4;
				}
				Vector3 eulerAngles2 = default(Vector3);
				eulerAngles2.x = vector.x;
				eulerAngles2.y = num2;
				eulerAngles2.z = num;
				_rt.eulerAngles = eulerAngles2;
			}
		}

		[Token(Token = "0x6000F88")]
		[Address(RVA = "0xB231D4", Offset = "0xB231D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformSetLocalRotation()
		{
		}
	}
}
