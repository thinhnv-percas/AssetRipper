using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75C4A0", Offset = "0x75C4A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75C4A0", Offset = "0x75C4A0")]
	[Token(Token = "0x2000315")]
	public class RectTransformSetAnchorRectPosition : BaseUpdateAction
	{
		[Token(Token = "0x2000494")]
		public enum AnchorReference
		{
			[Token(Token = "0x40021A0")]
			TopLeft = 0,
			[Token(Token = "0x40021A1")]
			Top = 1,
			[Token(Token = "0x40021A2")]
			TopRight = 2,
			[Token(Token = "0x40021A3")]
			Right = 3,
			[Token(Token = "0x40021A4")]
			BottomRight = 4,
			[Token(Token = "0x40021A5")]
			Bottom = 5,
			[Token(Token = "0x40021A6")]
			BottomLeft = 6,
			[Token(Token = "0x40021A7")]
			Left = 7,
			[Token(Token = "0x40021A8")]
			Center = 8
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C4B64", Offset = "0x7C4B64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4B64", Offset = "0x7C4B64")]
		[Token(Token = "0x40019C8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4BFC", Offset = "0x7C4BFC")]
		[Token(Token = "0x40019C9")]
		[FieldOffset(Offset = "0x58")]
		public AnchorReference anchorReference;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4C34", Offset = "0x7C4C34")]
		[Token(Token = "0x40019CA")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool normalized;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C4C6C", Offset = "0x7C4C6C")]
		[Token(Token = "0x40019CB")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 anchor;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4CA4", Offset = "0x7C4CA4")]
		[Token(Token = "0x40019CC")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat x;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C4CBC", Offset = "0x7C4CBC")]
		[Token(Token = "0x40019CD")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat y;

		[Token(Token = "0x40019CE")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform _rt;

		[Token(Token = "0x40019CF")]
		[FieldOffset(Offset = "0x88")]
		private Rect _anchorRect;

		[Token(Token = "0x6000F7A")]
		[Address(RVA = "0xB22394", Offset = "0xB22394", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED0D20]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225B6]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::Reset(this);\n\tv48 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.gameObject = 0;\n\tthis.normalized = v48;\n\tthis.anchor = 0;\n\tthis.anchorReference = 6;\n\tv53 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.x = v53;\n\tv58 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v58);\n\tv58.useVariable = 1;\n\tthis.y = v58;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = true;
			gameObject = null;
			normalized = fsmBool;
			anchor = null;
			anchorReference = AnchorReference.BottomLeft;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
		}

		[Token(Token = "0x6000F7B")]
		[Address(RVA = "0xB2245C", Offset = "0xB2245C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA6878]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225B7]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv76 = v60 == 0;\n\tif (v76) goto L_0037;\n\tv103 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._rt = v103;\nL_0037:\n\tHutongGames.PlayMaker.Actions.RectTransformSetAnchorRectPosition::DoSetAnchor(this);\n\tv89 = ~this.everyFrame;\n\tif (v89) goto L_0048;\n\treturn;\nL_0048:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
				_rt = component;
			}
			DoSetAnchor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F7C")]
		[Address(RVA = "0xB22864", Offset = "0xB22864", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformSetAnchorRectPosition::DoSetAnchor(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoSetAnchor();
		}

		[Token(Token = "0x6000F7D")]
		[Address(RVA = "0xB22538", Offset = "0xB22538", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1F0A080]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20225B8]) = v48;\nL_0019:\n\tv50 = this + 0x88;\n\tthis._anchorRect = 0;\n\tthis._anchorRect.m_Width = 0f;\n\tv54 = UnityEngine.RectTransform::get_anchorMin(this._rt);\n\tv103 = 0x10CD08C(v50, 0, v32, v33, v34, v35, v36, v37, v54, v54.y, v40, v41, v42, v43, v44, v45);\n\tv178 = UnityEngine.RectTransform::get_anchorMax(this._rt);\n\tv229 = 0x10CD144(v50, 0, v32, v33, v34, v35, v36, v37, v178, v178.y, v40, v41, v42, v43, v44, v45);\n\tgoto L_003B;\n\tv236 = *([v232 @ X0_v13+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_003B;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v232, v228, v32, v33, v34, v35, v36, v37, v178, v226, v40, v41, v42, v43, v44, v45);\nL_003B:\n\tv71 = UnityEngine.Vector2::get_zero();\n\tv244 = 0x10CD04C(v50, 0, v32, v33, v34, v35, v36, v37, v71, v71.y, v40, v41, v42, v43, v44, v45);\n\tv245 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.anchor);\n\tv247 = v245 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_006B;\n\tv154 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv265 = v154 == 0;\n\tif (v265) goto L_005B;\n\tgoto L_006B;\nL_005B:\n\tv155 = UnityEngine.Screen::get_width();\n\tv257 = UnityEngine.Screen::get_height();\nL_006B:\n\tv266 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv269 = v266 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0089;\n\tv156 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv275 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\n\tv299 = v156 == 0;\n\tv281 = ~v299;\n\tif (v281) goto L_0089;\n\tv278 = UnityEngine.Screen::get_width();\nL_0089:\n\tv214 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv287 = v214 == 0;\n\tv288 = ~v287;\n\tif (v288) goto L_00A4;\n\tv157 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv305 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\n\tv310 = v157 == 0;\n\tv294 = ~v310;\n\tif (v294) goto L_FFFFFFFF;\n\tv313 = UnityEngine.Screen::get_height();\nL_00A4:\n\tv174 = this.anchorReference;\n\tv296 = this.anchorReference < 8;\n\tv130 = ~v296;\n\tv127 = this.anchorReference - 8;\n\tv121 = v127 == 0;\n\tv297 = ~v121;\n\tv106 = v130 & v297;\n\tif (v106) goto L_00ED;\n\tv197 = 0x1819000 + 0x3B4;\n\tv221 = *([v197 @ X9_v2 (System.Int32)+v174 @ X8_v12 (HutongGames.PlayMaker.Actions.RectTransformSetAnchorRectPosition+AnchorReference)*4]) + v197;\n\t// 181 IndirectJump v221 @ X8_v14, v214 @ X0_v26 (System.Boolean), v214 @ X0_v26 (System.Boolean), v211 @ X1_v13, v32 @ X2, v33 @ X3, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v71 @ V0_v6 (UnityEngine.Vector2), v71.y (System.Single), v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_00BC;\n\tV0 = -0.5f;\n\tV0 = V8 + V0;\n\tX0 = X20;\nL_00BC:\n\tX1 = 0;\n\tX0 = 0x10CCFBC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = X22;\n\tV1 = -1f;\n\tgoto L_00DF;\n\tV9 = -1f;\n\tV0 = V8 + V9;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = 0x10CCFBC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = X22;\n\tV0 = V0 + V9;\n\tgoto L_00E7;\n\tV0 = -1f;\n\tV0 = V8 + V0;\n\tX0 = X20;\n\tgoto L_00DB;\n\tV0 = -1f;\n\tgoto L_00D0;\n\tV0 = -0.5f;\nL_00D0:\n\tV0 = V8 + V0;\n\tX0 = X20;\n\tgoto L_00D5;\n\tX0 = X20;\n\tV0 = V8;\nL_00D5:\n\tX1 = 0;\n\tX0 = 0x10CCFBC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = X22;\n\tgoto L_00E7;\n\tX0 = X20;\n\tV0 = V8;\nL_00DB:\n\tX1 = 0;\n\tX0 = 0x10CCFBC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = X22;\n\tV1 = -0.5f;\nL_00DF:\n\tV0 = V0 + V1;\n\tgoto L_00E7;\n\tV10 = -0.5f;\n\tV0 = V8 + V10;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = 0x10CCFBC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V9 + V10;\nL_00E7:\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = 0x10CCFCC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00ED:\n\tv158 = 0x10CD04C(v50, 0, v32, v33, v34, v35, v36, v37, v71, v71.y, v40, v41, v42, v43, v44, v45);\n\t// 242 MakeStruct v133 @ AGGB22820_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v71 @ V0_v6 (UnityEngine.Vector2), v71.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(this._rt, v133);\n\tv159 = 0x10CD0E8(v50, 0, v32, v33, v34, v35, v36, v37, v71, v71.y, v40, v41, v42, v43, v44, v45);\n\t// 262 MakeStruct v190 @ AGGB22854_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v71 @ V0_v6 (UnityEngine.Vector2), v71.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(this._rt, v190);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetAnchor()
		{
			//IL_0309: Expected O, but got I
			//IL_01d0: Expected O, but got I4
			//IL_017a: Expected O, but got F4
			//IL_0264: Expected O, but got I
			//IL_00f9: Expected O, but got I4
			//IL_03a5: Expected O, but got F4
			//IL_03ae: Expected O, but got I4
			//IL_0199: Expected O, but got I4
			object obj = (long)(IntPtr)this + 136L;
			_anchorRect = default(Rect);
			_anchorRect.width = 0f;
			Vector2 anchorMin = _rt.anchorMin;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD08C (inside UnityEngine.Rect::MinMaxRect +0xF0)");
			Vector2 anchorMax = _rt.anchorMax;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD144 (inside UnityEngine.Rect::MinMaxRect +0x1A8)");
			Vector2 vector = Vector2.zero;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD04C (inside UnityEngine.Rect::MinMaxRect +0xB0)");
			if (!anchor.IsNone && !normalized.Value)
			{
				int width = Screen.width;
				int height = Screen.height;
				vector = (Vector2)height;
			}
			if (!x.IsNone)
			{
				bool value = normalized.Value;
				float value2 = x.Value;
				bool flag = !value;
				bool flag2 = !flag;
				vector = (Vector2)value2;
				if (!flag2)
				{
					int width2 = Screen.width;
					vector = (Vector2)width2;
				}
			}
			bool isNone = y.IsNone;
			bool flag3 = !isNone;
			bool flag4 = !flag3;
			object obj2 = 0;
			if (!flag4)
			{
				bool value3 = normalized.Value;
				float num = y.Value;
				if (!value3)
				{
					int height2 = Screen.height;
					num = height2;
				}
				vector = (Vector2)num;
				obj2 = 0;
			}
			AnchorReference anchorReference = this.anchorReference;
			bool flag5 = this.anchorReference < AnchorReference.Center;
			bool flag6 = !flag5;
			int num2 = (int)(this.anchorReference - 8);
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				int num3 = 25268224 + 948;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X9_v2 (System.Int32)+v174 @ X8_v12 (HutongGames.PlayMaker.Actions.RectTransformSetAnchorRectPosition+AnchorReference)*4]");
				object obj3 = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v221 @ X8_v14 (should have been resolved before IL gen)");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD04C (inside UnityEngine.Rect::MinMaxRect +0xB0)");
			Vector2 anchorMin2 = default(Vector2);
			anchorMin2.x = vector.x;
			anchorMin2.y = vector.y;
			_rt.anchorMin = anchorMin2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD0E8 (inside UnityEngine.Rect::MinMaxRect +0x14C)");
			Vector2 anchorMax2 = default(Vector2);
			anchorMax2.x = vector.x;
			anchorMax2.y = vector.y;
			_rt.anchorMax = anchorMax2;
		}

		[Token(Token = "0x6000F7E")]
		[Address(RVA = "0xB22868", Offset = "0xB22868", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseUpdateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformSetAnchorRectPosition()
		{
		}
	}
}
