using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A57C", Offset = "0x75A57C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A57C", Offset = "0x75A57C")]
	[Token(Token = "0x20002B8")]
	public class Collision2dEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBC08", Offset = "0x7BBC08")]
		[Token(Token = "0x40017AC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBC40", Offset = "0x7BBC40")]
		[Token(Token = "0x40017AD")]
		[FieldOffset(Offset = "0x58")]
		public Collision2DType collision;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBC78", Offset = "0x7BBC78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBC78", Offset = "0x7BBC78")]
		[Token(Token = "0x40017AE")]
		[FieldOffset(Offset = "0x60")]
		public FsmString collideTag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBCC8", Offset = "0x7BBCC8")]
		[Token(Token = "0x40017AF")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBD00", Offset = "0x7BBD00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBD00", Offset = "0x7BBD00")]
		[Token(Token = "0x40017B0")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeCollider;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BBD50", Offset = "0x7BBD50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BBD50", Offset = "0x7BBD50")]
		[Token(Token = "0x40017B1")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat storeForce;

		[Token(Token = "0x40017B2")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerProxyBase cachedProxy;

		[Token(Token = "0x6000D93")]
		[Address(RVA = "0xA8F1CC", Offset = "0xA8F1CC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBFC28]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221E2]) = v38;\nL_0013:\n\tthis.collision = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.storeCollider = 0;\n\tthis.storeForce = 0;\n\tthis.collideTag = v43;\n\tthis.sendEvent = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			collision = default(Collision2DType);
			FsmString fsmString = "";
			storeCollider = null;
			storeForce = null;
			collideTag = fsmString;
			sendEvent = null;
		}

		[Token(Token = "0x6000D94")]
		[Address(RVA = "0xA8F22C", Offset = "0xA8F22C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA6D10]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221E3]) = v38;\nL_0013:\n\tv52 = v36.gameObject;\n\tv40 = v36.gameObject == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0022;\n\tv45 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v45);\n\tv36.gameObject = v45;\nL_0022:\n\tv55 = v52.ownerOption == 0;\n\tif (v55) goto L_002C;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::GetProxyComponent(v36);\n\treturn;\nL_002C:\n\tv61 = v36.collision;\n\tv62 = v36.collision < 3;\n\tv63 = ~v62;\n\tv64 = v36.collision - 3;\n\tv66 = v64 == 0;\n\tv71 = ~v66;\n\tv72 = v63 & v71;\n\tif (v72) goto L_0073;\n\tv74 = 0x1818000 + 0xE08;\n\tv76 = *([v74 @ X9_v2 (System.Int32)+v61 @ X8_v5 (HutongGames.PlayMaker.Collision2DType)*4]) + v74;\n\t// 61 IndirectJump v76 @ X8_v7, v45 @ X0_v5 (HutongGames.PlayMaker.FsmOwnerDefault), v45 @ X0_v5 (HutongGames.PlayMaker.FsmOwnerDefault), 0, v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0075;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 71 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionEnter2D(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0075;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 83 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionStay2D(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0075;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 95 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionExit2D(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0075;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 107 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleParticleCollision(X0, X1, X2);\n\treturn;\nL_0073:\n\treturn;\nL_0075:\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_00e3: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			bool flag = gameObject == null;
			bool flag2 = !flag;
			FsmOwnerDefault fsmOwnerDefault2 = (FsmOwnerDefault)(object)this;
			if (!flag2)
			{
				fsmOwnerDefault = (gameObject = new FsmOwnerDefault());
			}
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GetProxyComponent();
				return;
			}
			Collision2DType collision2DType = collision;
			bool flag3 = collision < Collision2DType.OnParticleCollision;
			bool flag4 = !flag3;
			int num = (int)(collision - 3);
			bool flag5 = num == 0;
			bool flag6 = !flag5;
			if (!(flag4 && flag6))
			{
				int num2 = 25264128 + 3592;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X9_v2 (System.Int32)+v61 @ X8_v5 (HutongGames.PlayMaker.Collision2DType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X8_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000D95")]
		[Address(RVA = "0xA8F4C4", Offset = "0xA8F4C4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE0C10]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221E4]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_0054;\n\tgoto L_002A;\n\tv80 = *([v71 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002A;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv88 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv109 = v88 == 0;\n\tif (v109) goto L_0031;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::GetProxyComponent(this);\nL_0031:\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::AddCallback(this);\n\tv62 = this.gameObject;\n\tv57 = new System.Action();\n\tSystem.Action::.ctor(v57, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::add_OnChange(v62.gameObject, v57);\n\treturn;\nL_0054:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				if (cachedProxy == null)
				{
					GetProxyComponent();
				}
				AddCallback();
				FsmOwnerDefault fsmOwnerDefault2 = gameObject;
				Action value = UpdateCallback;
				fsmOwnerDefault2.GameObject.OnChange += value;
			}
		}

		[Token(Token = "0x6000D96")]
		[Address(RVA = "0xA8F74C", Offset = "0xA8F74C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE62B0]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221E5]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_003E;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::RemoveCallback(this);\n\tv60 = this.gameObject;\n\tv55 = new System.Action();\n\tSystem.Action::.ctor(v55, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::remove_OnChange(v60.gameObject, v55);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				RemoveCallback();
				FsmOwnerDefault fsmOwnerDefault2 = gameObject;
				Action value = UpdateCallback;
				fsmOwnerDefault2.GameObject.OnChange -= value;
			}
		}

		[Token(Token = "0x6000D97")]
		[Address(RVA = "0xA8F994", Offset = "0xA8F994", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::RemoveCallback(this);\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::GetProxyComponent(this);\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::AddCallback(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateCallback()
		{
			RemoveCallback();
			GetProxyComponent();
			AddCallback();
		}

		[Token(Token = "0x6000D98")]
		[Address(RVA = "0xA8F348", Offset = "0xA8F348", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED7B58]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221E6]) = v38;\nL_0013:\n\tv39 = this.gameObject;\n\tthis.cachedProxy = 0;\n\tv45 = HutongGames.PlayMaker.FsmGameObject::get_Value(v39.gameObject);\n\tgoto L_002D;\n\tv56 = *([v52 @ X8_v6+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002D;\n\tv122 = v52;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v122, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv66 = UnityEngine.Object::op_Equality(v45, 0);\n\tv124 = v66 == 0;\n\tv112 = ~v124;\n\tif (v112) goto L_0088;\n\tv125 = this.collision;\n\tv126 = this.collision < 3;\n\tv102 = ~v126;\n\tv98 = this.collision - 3;\n\tv90 = v98 == 0;\n\tv127 = ~v90;\n\tv70 = v102 & v127;\n\tif (v70) goto L_0088;\n\tv107 = 0x1818000 + 0xE18;\n\tv116 = *([v107 @ X9_v4 (System.Int32)+v125 @ X8_v8 (HutongGames.PlayMaker.Collision2DType)*4]) + v107;\n\t// 67 IndirectJump v116 @ X8_v10, v66 @ X0_v9 (System.Boolean), v66 @ X0_v9 (System.Boolean), 0, 0, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0050;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0050;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0050:\n\tX8 = 0x1F03000;\n\tX8 = *([1F03008]);\n\tgoto L_007F;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005F:\n\tX8 = 0x1EF8000;\n\tX8 = *([1EF89F0]);\n\tgoto L_007F;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tX8 = 0x1EC9000;\n\tX8 = *([1EC91F8]);\n\tgoto L_007F;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_007D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX8 = 0x1EA3000;\n\tX8 = *([1EA3480]);\nL_007F:\n\tX1 = *([X8]);\n\tX0 = X20;\n\tX0 = PlayMakerFSM::GetEventHandlerComponent /* +15 sharing this address */(X0, X1);\n\t*([X19+80]) = X0;\nL_0088:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetProxyComponent()
		{
			//IL_00e1: Expected O, but got I
			while (true)
			{
				FsmOwnerDefault fsmOwnerDefault = gameObject;
				cachedProxy = null;
				GameObject value = fsmOwnerDefault.GameObject.Value;
				if (!(value == null))
				{
					Collision2DType collision2DType = collision;
					bool flag = collision < Collision2DType.OnParticleCollision;
					bool flag2 = !flag;
					int num = (int)(collision - 3);
					bool flag3 = num == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						int num2 = 25264128 + 3608;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X9_v4 (System.Int32)+v125 @ X8_v8 (HutongGames.PlayMaker.Collision2DType)*4]");
						object obj = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ X8_v10 (should have been resolved before IL gen)");
						continue;
					}
					break;
				}
				break;
			}
		}

		[Token(Token = "0x6000D99")]
		[Address(RVA = "0xA8F5C4", Offset = "0xA8F5C4", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EBFD20]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221E7]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_002F;\nL_002E:\n\treturn;\nL_002F:\n\tv89 = this.collision;\n\tv95 = this.collision < 3;\n\tv87 = ~v95;\n\tv84 = this.collision - 3;\n\tv78 = v84 == 0;\n\tv96 = ~v78;\n\tv63 = v87 & v96;\n\tif (v63) goto L_002E;\n\tv99 = 0x1818000 + 0xE28;\n\tv113 = *([v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.Collision2DType)*4]) + v99;\n\t// 64 IndirectJump v113 @ X8_v9, v58 @ X0_v5 (System.Boolean), v58 @ X0_v5 (System.Boolean), 0, 0, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA32B8]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE0878]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EC9C50]);\nL_0058:\n\tX2 = *([X8]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tPlayMakerProxyBase+Collision2DEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_0083;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 103 ShiftStack 48\n\tPlayMakerProxyBase::AddCollision2DEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1EEE8B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFAEF0]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ParticleCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_0083;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 128 ShiftStack 48\n\tPlayMakerProxyBase::AddParticleCollisionEventCallback(X0, X1, X2);\n\treturn;\nL_0083:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddCallback()
		{
			//IL_00c2: Expected O, but got I
			while (!(cachedProxy == null))
			{
				Collision2DType collision2DType = collision;
				bool flag = collision < Collision2DType.OnParticleCollision;
				bool flag2 = !flag;
				int num = (int)(collision - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 3624;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.Collision2DType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X8_v9 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000D9A")]
		[Address(RVA = "0xA8F80C", Offset = "0xA8F80C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EEF738]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221E8]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_002F;\nL_002E:\n\treturn;\nL_002F:\n\tv89 = this.collision;\n\tv95 = this.collision < 3;\n\tv87 = ~v95;\n\tv84 = this.collision - 3;\n\tv78 = v84 == 0;\n\tv96 = ~v78;\n\tv63 = v87 & v96;\n\tif (v63) goto L_002E;\n\tv99 = 0x1818000 + 0xE38;\n\tv113 = *([v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.Collision2DType)*4]) + v99;\n\t// 64 IndirectJump v113 @ X8_v9, v58 @ X0_v5 (System.Boolean), v58 @ X0_v5 (System.Boolean), 0, 0, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA32B8]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE0878]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1EFDF80]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EC9C50]);\nL_0058:\n\tX2 = *([X8]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tPlayMakerProxyBase+Collision2DEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_0083;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 103 ShiftStack 48\n\tPlayMakerProxyBase::RemoveCollision2DEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1EEE8B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFAEF0]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ParticleCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_0083;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 128 ShiftStack 48\n\tPlayMakerProxyBase::RemoveParticleCollisionEventCallback(X0, X1, X2);\n\treturn;\nL_0083:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveCallback()
		{
			//IL_00c2: Expected O, but got I
			while (!(cachedProxy == null))
			{
				Collision2DType collision2DType = collision;
				bool flag = collision < Collision2DType.OnParticleCollision;
				bool flag2 = !flag;
				int num = (int)(collision - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 3640;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.Collision2DType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X8_v9 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000D9B")]
		[Address(RVA = "0xA8F9C0", Offset = "0xA8F9C0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.Collision2D::get_gameObject(collisionInfo);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, v21);\n\tv46 = this.storeForce;\n\tv30 = UnityEngine.Collision2D::get_relativeVelocity(collisionInfo);\n\tv38 = 0x1588E30(&v30 @ V0_v2 (UnityEngine.Vector2), 0, 0, v49, v50, v51, v52, v53, v30, v30.y, v54, v55, v56, v57, v58, v59);\n\tv46.value = v30;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo(Collision2D collisionInfo)
		{
			GameObject value = collisionInfo.gameObject;
			storeCollider.Value = value;
			FsmFloat fsmFloat = storeForce;
			Vector2 relativeVelocity = collisionInfo.relativeVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
			fsmFloat.Value = relativeVelocity.x;
		}

		[Token(Token = "0x6000D9C")]
		[Address(RVA = "0xA8FA44", Offset = "0xA8FA44", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::CollisionEnter2D(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionEnter2D(Collision2D collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionEnter2D(collisionInfo);
			}
		}

		[Token(Token = "0x6000D9D")]
		[Address(RVA = "0xA8FAD4", Offset = "0xA8FAD4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::CollisionStay2D(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionStay2D(Collision2D collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionStay2D(collisionInfo);
			}
		}

		[Token(Token = "0x6000D9E")]
		[Address(RVA = "0xA8FB68", Offset = "0xA8FB68", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::CollisionExit2D(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionExit2D(Collision2D collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionExit2D(collisionInfo);
			}
		}

		[Token(Token = "0x6000D9F")]
		[Address(RVA = "0xA8FBFC", Offset = "0xA8FBFC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::ParticleCollision(this, other);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoParticleCollision(GameObject other)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				ParticleCollision(other);
			}
		}

		[Token(Token = "0x6000DA0")]
		[Address(RVA = "0xA8FA6C", Offset = "0xA8FA6C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.collision == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0027;\n\tv20 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv26 = v20 == 0;\n\tif (v26) goto L_0027;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0027:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionEnter2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionEnter2D && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000DA1")]
		[Address(RVA = "0xA8FAFC", Offset = "0xA8FAFC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 1;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionStay2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionStay2D && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000DA2")]
		[Address(RVA = "0xA8FB90", Offset = "0xA8FB90", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 2;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.Collision2dEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionExit2D(Collision2D collisionInfo)
		{
			if (collision == Collision2DType.OnCollisionExit2D && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000DA3")]
		[Address(RVA = "0xA8FC24", Offset = "0xA8FC24", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 3;\n\tif (v24) goto L_0036;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, other);\n\tv31 = v28 == 0;\n\tif (v31) goto L_0036;\n\tv64 = this.storeCollider == 0;\n\tif (v64) goto L_0021;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, other);\nL_0021:\n\tv58 = this.storeForce;\n\tv58.value = 0f;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ParticleCollision(GameObject other)
		{
			if (collision == Collision2DType.OnParticleCollision && FsmStateAction.TagMatches(collideTag, other))
			{
				if (storeCollider != null)
				{
					storeCollider.Value = other;
				}
				FsmFloat fsmFloat = storeForce;
				fsmFloat.Value = 0f;
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000DA4")]
		[Address(RVA = "0xA8FCA8", Offset = "0xA8FCA8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::CheckPhysics2dSetup(v12);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			return ActionHelpers.CheckPhysics2dSetup(ownerDefaultTarget);
		}

		[Token(Token = "0x6000DA5")]
		[Address(RVA = "0xA8FCD8", Offset = "0xA8FCD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Collision2dEvent()
		{
		}
	}
}
