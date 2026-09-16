using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AB6C", Offset = "0x75AB6C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AB6C", Offset = "0x75AB6C")]
	[Token(Token = "0x20002CB")]
	public class MousePick2d : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE8F4", Offset = "0x7BE8F4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE8F4", Offset = "0x7BE8F4")]
		[Token(Token = "0x4001858")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool storeDidPickObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE944", Offset = "0x7BE944")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE944", Offset = "0x7BE944")]
		[Token(Token = "0x4001859")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeGameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE994", Offset = "0x7BE994")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE994", Offset = "0x7BE994")]
		[Token(Token = "0x400185A")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 storePoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE9E4", Offset = "0x7BE9E4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE9E4", Offset = "0x7BE9E4")]
		[Token(Token = "0x400185B")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt[] layerMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEA34", Offset = "0x7BEA34")]
		[Token(Token = "0x400185C")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool invertMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEA6C", Offset = "0x7BEA6C")]
		[Token(Token = "0x400185D")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000DFC")]
		[Address(RVA = "0xA3CE44", Offset = "0xA3CE44", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECFA58]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E5D]) = v38;\nL_0013:\n\tthis.storeGameObject = 0;\n\tthis.storePoint = 0;\n\tthis.storeDidPickObject = 0;\n\t// 26 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v43;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v46;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeGameObject = null;
			storePoint = null;
			storeDidPickObject = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000DFD")]
		[Address(RVA = "0xA3CEB8", Offset = "0xA3CEB8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick2d::DoMousePick2d(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoMousePick2d();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DFE")]
		[Address(RVA = "0xA3D138", Offset = "0xA3D138", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick2d::DoMousePick2d(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMousePick2d();
		}

		[Token(Token = "0x6000DFF")]
		[Address(RVA = "0xA3CEF4", Offset = "0xA3CEF4", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv23 = *([1EFB880]);\n\tv24 = *([v23 @ X8_v16]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E5E]) = v43;\nL_001B:\n\tv49 = UnityEngine.Camera::get_main();\n\tv52 = UnityEngine.Input::get_mousePosition();\n\tv56 = &v57 @ stack_-88;\n\tv61 = UnityEngine.Camera::ScreenPointToRay(v49, v52);\n\tv57 = *([v56 @ X8_v4]);\n\tv91 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv95 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v91);\n\tgoto L_0050;\n\tv168 = *([v164 @ X8_v7+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0050;\n\tv181 = v164;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v181, v92, v94, v28, v29, v30, v31, v32, v52, v53, v54, v36, v37, v38, v39, v40);\nL_0050:\n\tv180 = UnityEngine.Physics2D::GetRayIntersection(&v57 @ stack_-88, Infinityf, v95);\n\tv127 = v180.m_Centroid;\n\tv184 = 0x16415C8(&v127 @ stack_-B0_v1 (UnityEngine.Vector2), 0, 0, v28, v29, v30, v31, v32, v180.m_Normal, v180.m_Centroid, v52.z, v36, v37, v38, v39, v40);\n\tv154 = 0xA3DF68(v184, 0, 0, v28, v29, v30, v31, v32, v180.m_Normal, v180.m_Centroid, v52.z, v36, v37, v38, v39, v40);\n\treturn;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0072;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0072;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0072:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tX8 = *([X19+50]);\n\tif (TEMP) goto L_00CE;\n\tX9 = X0 & 1;\n\t*([X8+38]) = X9;\n\tX20 = *([X19+58]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0094;\n\tX0 = &stack[60];\n\tX1 = 0;\n\tX0 = 0x16415C8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_gameObject(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_00CE;\n\tX0 = X20;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(X0, X1, X2);\n\tX19 = *([X19+60]);\n\tX0 = &stack[60];\n\tX1 = 0;\n\tX0 = 0x16415A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C3;\n\tgoto L_00CE;\nL_0094:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_00CE;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(X0, X1, X2);\n\tX8 = *([1EE1550]);\n\tX19 = *([X19+60]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A7;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A7;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A7:\n\tX0 = 0;\n\tV0 = UnityEngine.Vector3::get_zero(X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX8 = *([1EFD6E0]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00BA;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BA;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BA:\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX0 = 0;\n\t// 190 MakeStruct AGGA3D10C_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector2::op_Implicit(AGGA3D10C_0, X0);\n\tV1 = *([V0+4]);\n\tif (TEMP) goto L_00CE;\nL_00C3:\n\t*([X19+38]) = V0;\n\t*([X19+3C]) = V1;\n\tX29 = stack[C0];\n\tX30 = stack[C8];\n\tX20 = stack[B0];\n\tX19 = stack[B8];\n\tV9 = stack[A0];\n\tV8 = stack[A8];\n\tV10 = stack[90];\n\t// 204 ShiftStack 208\n\treturn;\nL_00CE:\n\t;\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoMousePick2d()
		{
			//IL_0069: Expected O, but got Ref
			Camera main = Camera.main;
			Vector3 mousePosition = Input.mousePosition;
			object obj2 = default(object);
			object obj = obj2;
			Ray ray = main.ScreenPointToRay(mousePosition);
			obj2 = obj;
			bool value = invertMask.Value;
			int num = ActionHelpers.LayerArrayToLayerMask(layerMask, value);
			Vector2 centroid = Physics2D.GetRayIntersection((Ray)(&obj2), float.PositiveInfinity, num).m_Centroid;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A3DF68 (inside HutongGames.PlayMaker.Actions.MoveObject::.ctor +0xC)");
		}

		[Token(Token = "0x6000E00")]
		[Address(RVA = "0xA3D13C", Offset = "0xA3D13C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MousePick2d()
		{
		}
	}
}
