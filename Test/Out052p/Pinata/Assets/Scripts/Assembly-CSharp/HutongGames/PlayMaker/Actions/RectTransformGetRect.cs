using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C0E0", Offset = "0x75C0E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75C0E0", Offset = "0x75C0E0")]
	[Token(Token = "0x200030B")]
	public class RectTransformGetRect : BaseUpdateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C37C4", Offset = "0x7C37C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C37C4", Offset = "0x7C37C4")]
		[Token(Token = "0x4001981")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C385C", Offset = "0x7C385C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C385C", Offset = "0x7C385C")]
		[Token(Token = "0x4001982")]
		[FieldOffset(Offset = "0x58")]
		public FsmRect rect;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C38AC", Offset = "0x7C38AC")]
		[Token(Token = "0x4001983")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C38C0", Offset = "0x7C38C0")]
		[Token(Token = "0x4001984")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C38D4", Offset = "0x7C38D4")]
		[Token(Token = "0x4001985")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat width;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C38E8", Offset = "0x7C38E8")]
		[Token(Token = "0x4001986")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat height;

		[Token(Token = "0x4001987")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform _rt;

		[Token(Token = "0x6000F48")]
		[Address(RVA = "0xB207D0", Offset = "0xB207D0", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFF728]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225A1]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tthis.rect = 0;\n\tv48 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.x = v48;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.y = v54;\n\tv62 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.width = v62;\n\tv63 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.height = v63;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			rect = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			width = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			height = fsmFloat4;
		}

		[Token(Token = "0x6000F49")]
		[Address(RVA = "0xB208C0", Offset = "0xB208C0", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBA1D8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225A2]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformGetRect::DoGetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F4A")]
		[Address(RVA = "0xB20B14", Offset = "0xB20B14", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformGetRect::DoGetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6000F4B")]
		[Address(RVA = "0xB2099C", Offset = "0xB2099C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rect);\n\tv107 = v17 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0025;\n\tv144 = this.rect;\n\tv138 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv144.value = v138;\n\tv144.value.m_YMin = v138.m_YMin;\n\tv144.value.m_Width = v138.m_Width;\n\tv144.value.m_Height = v138.m_Height;\nL_0025:\n\tv181 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv213 = v181 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_0041;\n\tv145 = this.x;\n\tv138 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv161 = 0x10CCFB4(&v138 @ V0_v12 (UnityEngine.Rect), 0, v96, v97, v98, v99, v100, v101, v138, v138.m_YMin, v138.m_Width, v138.m_Height, v102, v103, v104, v105);\n\tv145.value = v138;\nL_0041:\n\tv218 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv221 = v218 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_005D;\n\tv146 = this.y;\n\tv138 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv162 = 0x10CCFC4(&v138 @ V0_v12 (UnityEngine.Rect), 0, v96, v97, v98, v99, v100, v101, v138, v138.m_YMin, v138.m_Width, v138.m_Height, v102, v103, v104, v105);\n\tv146.value = v138;\nL_005D:\n\tv226 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.width);\n\tv229 = v226 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0079;\n\tv147 = this.width;\n\tv138 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv163 = 0x10CD178(&v138 @ V0_v12 (UnityEngine.Rect), 0, v96, v97, v98, v99, v100, v101, v138, v138.m_YMin, v138.m_Width, v138.m_Height, v102, v103, v104, v105);\n\tv147.value = v138;\nL_0079:\n\tv234 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv237 = v234 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0096;\n\tv176 = this.height;\n\tv138 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv164 = 0x10CD188(&v138 @ V0_v12 (UnityEngine.Rect), 0, v96, v97, v98, v99, v100, v101, v138, v138.m_YMin, v138.m_Width, v138.m_Height, v102, v103, v104, v105);\n\tv176.value = v138;\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValues()
		{
			if (!this.rect.IsNone)
			{
				FsmRect fsmRect = this.rect;
				Rect rect = (fsmRect.value = _rt.rect);
				fsmRect.value.y = rect.y;
				fsmRect.value.width = rect.width;
				fsmRect.value.height = rect.height;
			}
			if (!x.IsNone)
			{
				FsmFloat fsmFloat = x;
				Rect rect = _rt.rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				fsmFloat.Value = rect.x;
			}
			if (!y.IsNone)
			{
				FsmFloat fsmFloat2 = y;
				Rect rect = _rt.rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				fsmFloat2.Value = rect.x;
			}
			if (!width.IsNone)
			{
				FsmFloat fsmFloat3 = width;
				Rect rect = _rt.rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				fsmFloat3.Value = rect.x;
			}
			if (!height.IsNone)
			{
				FsmFloat fsmFloat4 = height;
				Rect rect = _rt.rect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				fsmFloat4.Value = rect.x;
			}
		}

		[Token(Token = "0x6000F4C")]
		[Address(RVA = "0xB20B18", Offset = "0xB20B18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformGetRect()
		{
		}
	}
}
