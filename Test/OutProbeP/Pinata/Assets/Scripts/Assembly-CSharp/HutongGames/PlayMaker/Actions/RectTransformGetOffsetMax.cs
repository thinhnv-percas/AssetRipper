using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BFC0", Offset = "0x75BFC0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BFC0", Offset = "0x75BFC0")]
	[Token(Token = "0x2000308")]
	public class RectTransformGetOffsetMax : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C332C", Offset = "0x7C332C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C332C", Offset = "0x7C332C")]
		[Token(Token = "0x4001972")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C33C4", Offset = "0x7C33C4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C33C4", Offset = "0x7C33C4")]
		[Token(Token = "0x4001973")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 offsetMax;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3414", Offset = "0x7C3414")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3414", Offset = "0x7C3414")]
		[Token(Token = "0x4001974")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3464", Offset = "0x7C3464")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3464", Offset = "0x7C3464")]
		[Token(Token = "0x4001975")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Token(Token = "0x4001976")]
		[FieldOffset(Offset = "0x70")]
		private RectTransform _rt;

		[Token(Token = "0x6000F39")]
		[Address(RVA = "0xB2026C", Offset = "0xB2026C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tthis.x = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			x = null;
		}

		[Token(Token = "0x6000F3A")]
		[Address(RVA = "0xB20298", Offset = "0xB20298", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB5608]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202259E]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformGetOffsetMax::DoGetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F3B")]
		[Address(RVA = "0xB2042C", Offset = "0xB2042C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformGetOffsetMax::DoGetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6000F3C")]
		[Address(RVA = "0xB20374", Offset = "0xB20374", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.offsetMax);\n\tv59 = v15 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_001F;\n\tv70 = this.offsetMax;\n\tv66 = UnityEngine.RectTransform::get_offsetMax(this._rt);\n\tv70.value = v66;\n\tv70.value.y = v66.y;\nL_001F:\n\tv87 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv107 = v87 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0032;\n\tv71 = this.x;\n\tv67 = UnityEngine.RectTransform::get_offsetMax(this._rt);\n\tv71.value = v67;\nL_0032:\n\tv111 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv113 = v111 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_0046;\n\tv82 = this.y;\n\tv68 = UnityEngine.RectTransform::get_offsetMax(this._rt);\n\tv82.value = v68.y;\nL_0046:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValues()
		{
			if (!offsetMax.IsNone)
			{
				FsmVector2 fsmVector = offsetMax;
				Vector2 vector = (fsmVector.value = _rt.offsetMax);
				fsmVector.value.y = vector.y;
			}
			if (!x.IsNone)
			{
				FsmFloat fsmFloat = x;
				fsmFloat.Value = _rt.offsetMax.x;
			}
			if (!y.IsNone)
			{
				FsmFloat fsmFloat2 = y;
				fsmFloat2.Value = _rt.offsetMax.y;
			}
		}

		[Token(Token = "0x6000F3D")]
		[Address(RVA = "0xB20430", Offset = "0xB20430", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformGetOffsetMax()
		{
		}
	}
}
