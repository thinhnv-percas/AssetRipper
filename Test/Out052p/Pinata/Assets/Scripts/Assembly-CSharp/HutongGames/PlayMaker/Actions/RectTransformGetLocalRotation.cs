using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BF60", Offset = "0x75BF60")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BF60", Offset = "0x75BF60")]
	[Token(Token = "0x2000307")]
	public class RectTransformGetLocalRotation : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C31B4", Offset = "0x7C31B4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C31B4", Offset = "0x7C31B4")]
		[Token(Token = "0x400196C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C324C", Offset = "0x7C324C")]
		[Token(Token = "0x400196D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 rotation;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3284", Offset = "0x7C3284")]
		[Token(Token = "0x400196E")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C32BC", Offset = "0x7C32BC")]
		[Token(Token = "0x400196F")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C32F4", Offset = "0x7C32F4")]
		[Token(Token = "0x4001970")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[Token(Token = "0x4001971")]
		[FieldOffset(Offset = "0x78")]
		private RectTransform _rt;

		[Token(Token = "0x6000F34")]
		[Address(RVA = "0xB1FF44", Offset = "0xB1FF44", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EBD858]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202259B]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv48 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.rotation = v48;\n\tv56 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v56);\n\tv56.useVariable = 1;\n\tthis.x = v56;\n\tv65 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v65);\n\tv65.useVariable = 1;\n\tthis.y = v65;\n\tv66 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v66);\n\tv66.useVariable = 1;\n\tthis.z = v66;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F35")]
		[Address(RVA = "0xB2003C", Offset = "0xB2003C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA4F90]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202259C]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformGetLocalRotation::DoGetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F36")]
		[Address(RVA = "0xB20260", Offset = "0xB20260", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformGetLocalRotation::DoGetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6000F37")]
		[Address(RVA = "0xB20118", Offset = "0xB20118", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA9DD8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202259D]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_007F;\n\tv89 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv143 = v89 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0042;\n\tv161 = this.rotation;\n\tv151 = UnityEngine.Transform::get_eulerAngles(this._rt);\n\tv161.value = v151;\n\tv161.value.y = v151.y;\n\tv161.value.z = v151.z;\nL_0042:\n\tv167 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv169 = v167 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0056;\n\tv162 = this.x;\n\tv152 = UnityEngine.Transform::get_eulerAngles(this._rt);\n\tv162.value = v152;\nL_0056:\n\tv173 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv175 = v173 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_006A;\n\tv163 = this.y;\n\tv153 = UnityEngine.Transform::get_eulerAngles(this._rt);\n\tv163.value = v153.y;\nL_006A:\n\tv76 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv180 = v76 == 0;\n\tv79 = ~v180;\n\tif (v79) goto L_007F;\n\tv81 = this.z;\n\tv69 = UnityEngine.Transform::get_eulerAngles(this._rt);\n\tv81.value = v69.z;\nL_007F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValues()
		{
			if (!(_rt == null))
			{
				if (!rotation.IsNone)
				{
					FsmVector3 fsmVector = rotation;
					Vector3 vector = (fsmVector.value = _rt.eulerAngles);
					fsmVector.value.y = vector.y;
					fsmVector.value.z = vector.z;
				}
				if (!x.IsNone)
				{
					FsmFloat fsmFloat = x;
					fsmFloat.Value = _rt.eulerAngles.x;
				}
				if (!y.IsNone)
				{
					FsmFloat fsmFloat2 = y;
					fsmFloat2.Value = _rt.eulerAngles.y;
				}
				if (!z.IsNone)
				{
					FsmFloat fsmFloat3 = z;
					fsmFloat3.Value = _rt.eulerAngles.z;
				}
			}
		}

		[Token(Token = "0x6000F38")]
		[Address(RVA = "0xB20264", Offset = "0xB20264", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformGetLocalRotation()
		{
		}
	}
}
