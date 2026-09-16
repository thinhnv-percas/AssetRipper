using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BF00", Offset = "0x75BF00")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BF00", Offset = "0x75BF00")]
	[Token(Token = "0x2000306")]
	public class RectTransformGetLocalPosition : BaseUpdateAction
	{
		[Token(Token = "0x2000493")]
		public enum LocalPositionReference
		{
			[Token(Token = "0x400219D")]
			Anchor = 0,
			[Token(Token = "0x400219E")]
			CenterPosition = 1
		}

		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C2F8C", Offset = "0x7C2F8C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2F8C", Offset = "0x7C2F8C")]
		[Token(Token = "0x4001964")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001965")]
		[FieldOffset(Offset = "0x58")]
		public LocalPositionReference reference;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3024", Offset = "0x7C3024")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3024", Offset = "0x7C3024")]
		[Token(Token = "0x4001966")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3074", Offset = "0x7C3074")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3074", Offset = "0x7C3074")]
		[Token(Token = "0x4001967")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 position2d;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C30C4", Offset = "0x7C30C4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C30C4", Offset = "0x7C30C4")]
		[Token(Token = "0x4001968")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3114", Offset = "0x7C3114")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3114", Offset = "0x7C3114")]
		[Token(Token = "0x4001969")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C3164", Offset = "0x7C3164")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C3164", Offset = "0x7C3164")]
		[Token(Token = "0x400196A")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat z;

		[Token(Token = "0x400196B")]
		[FieldOffset(Offset = "0x88")]
		private RectTransform _rt;

		[Token(Token = "0x6000F2F")]
		[Address(RVA = "0xB1FC4C", Offset = "0xB1FC4C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tthis.gameObject = 0;\n\tthis.reference = 0;\n\tthis.z = 0;\n\tthis.position = 0;\n\tthis.x = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			reference = default(LocalPositionReference);
			z = null;
			position = null;
			x = null;
		}

		[Token(Token = "0x6000F30")]
		[Address(RVA = "0xB1FC84", Offset = "0xB1FC84", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED1D78]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022599]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformGetLocalPosition::DoGetValues(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000F31")]
		[Address(RVA = "0xB1FF38", Offset = "0xB1FF38", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformGetLocalPosition::DoGetValues(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6000F32")]
		[Address(RVA = "0xB1FD60", Offset = "0xB1FD60", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1F0AB60]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202259A]) = v44;\nL_001F:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv64 = UnityEngine.Object::op_Equality(this._rt, 0);\n\tv66 = v64 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_00B7;\n\tv147 = UnityEngine.Transform::get_localPosition(this._rt);\n\tv89 = this.reference != 1;\n\tif (v89) goto L_0067;\n\tv182 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv306 = 0x10CD004(&v182 @ V0_v8 (UnityEngine.Rect), 0, 0, v29, v30, v31, v32, v33, v182, v182.m_YMin, v182.m_Width, v182.m_Height, v38, v39, v40, v41);\n\tv296 = v147 + v182;\n\tv299 = UnityEngine.RectTransform::get_rect(this._rt);\n\tv122 = v299.m_Width;\n\tv302 = 0x10CD004(&v299 @ V0_v9 (UnityEngine.Rect), 0, 0, v29, v30, v31, v32, v33, v299, v299.m_YMin, v299.m_Width, v299.m_Height, v38, v39, v40, v41);\n\tv118 = v147.y + v299.m_YMin;\nL_0067:\n\tv277 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv308 = v277 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_0076;\n\tv285 = this.position;\n\tv285.value = v120;\n\tv285.value.y = v118;\n\tv285.value.z = v147.z;\nL_0076:\n\tv313 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position2d);\n\tv316 = v313 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_008C;\n\tv288 = this.position2d;\n\tv272 = 0;\n\tv278 = 0x1588A6C(&v272 @ stack_-38_v5 (UnityEngine.Vector2), 0, 0, v29, v30, v31, v32, v33, v120, v118, v122, v299.m_Height, v38, v39, v40, v41);\n\tv288.value = 0;\n\tv288.value.y = v323;\nL_008C:\n\tv279 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv325 = v279 == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_0099;\n\tv286 = this.x;\n\tv286.value = v120;\nL_0099:\n\tv280 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv329 = v280 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_00A6;\n\tv287 = this.y;\n\tv287.value = v118;\nL_00A6:\n\tv130 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.z);\n\tv333 = v130 == 0;\n\tv133 = ~v333;\n\tif (v133) goto L_00B7;\n\tv135 = this.z;\n\tv135.value = v147.z;\nL_00B7:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValues()
		{
			//IL_0113: Expected O, but got F4
			if (!(_rt == null))
			{
				Vector3 localPosition = _rt.localPosition;
				bool flag = reference != LocalPositionReference.CenterPosition;
				float value = localPosition.y;
				Vector3 value2 = localPosition;
				float num = localPosition.z;
				if (!flag)
				{
					Rect rect = _rt.rect;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD004 (inside UnityEngine.Rect::MinMaxRect +0x68)");
					float num2 = localPosition.x + rect.x;
					Rect rect2 = _rt.rect;
					num = rect2.width;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD004 (inside UnityEngine.Rect::MinMaxRect +0x68)");
					value = localPosition.y + rect2.y;
					value2 = (Vector3)num2;
				}
				if (!position.IsNone)
				{
					FsmVector3 fsmVector = position;
					fsmVector.value = value2;
					fsmVector.value.y = value;
					fsmVector.value.z = localPosition.z;
				}
				if (!position2d.IsNone)
				{
					FsmVector2 fsmVector2 = position2d;
					Vector2 vector = default(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
					fsmVector2.value = default(Vector2);
					float num3 = default(float);
					fsmVector2.value.y = num3;
				}
				if (!x.IsNone)
				{
					FsmFloat fsmFloat = x;
					fsmFloat.Value = value2.x;
				}
				if (!y.IsNone)
				{
					FsmFloat fsmFloat2 = y;
					fsmFloat2.Value = value;
				}
				if (!z.IsNone)
				{
					FsmFloat fsmFloat3 = z;
					fsmFloat3.Value = localPosition.z;
				}
			}
		}

		[Token(Token = "0x6000F33")]
		[Address(RVA = "0xB1FF3C", Offset = "0xB1FF3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformGetLocalPosition()
		{
		}
	}
}
