using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759C48", Offset = "0x759C48")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759C48", Offset = "0x759C48")]
	[Token(Token = "0x200029B")]
	public class CollisionEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9804", Offset = "0x7B9804")]
		[Token(Token = "0x400171B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B983C", Offset = "0x7B983C")]
		[Token(Token = "0x400171C")]
		[FieldOffset(Offset = "0x58")]
		public CollisionType collision;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9874", Offset = "0x7B9874")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9874", Offset = "0x7B9874")]
		[Token(Token = "0x400171D")]
		[FieldOffset(Offset = "0x60")]
		public FsmString collideTag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B98C4", Offset = "0x7B98C4")]
		[Token(Token = "0x400171E")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B98FC", Offset = "0x7B98FC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B98FC", Offset = "0x7B98FC")]
		[Token(Token = "0x400171F")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeCollider;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B994C", Offset = "0x7B994C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B994C", Offset = "0x7B994C")]
		[Token(Token = "0x4001720")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat storeForce;

		[Token(Token = "0x4001721")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerProxyBase cachedProxy;

		[Token(Token = "0x6000CED")]
		[Address(RVA = "0xA8FCE0", Offset = "0xA8FCE0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAEC98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221E9]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.collision = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.storeCollider = 0;\n\tthis.storeForce = 0;\n\tthis.collideTag = v43;\n\tthis.sendEvent = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			collision = default(CollisionType);
			FsmString fsmString = "";
			storeCollider = null;
			storeForce = null;
			collideTag = fsmString;
			sendEvent = null;
		}

		[Token(Token = "0x6000CEE")]
		[Address(RVA = "0xA8FD44", Offset = "0xA8FD44", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC58F8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221EA]) = v38;\nL_0013:\n\tv52 = v36.gameObject;\n\tv40 = v36.gameObject == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0022;\n\tv45 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v45);\n\tv36.gameObject = v45;\nL_0022:\n\tv55 = v52.ownerOption == 0;\n\tif (v55) goto L_002C;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::GetProxyComponent(v36);\n\treturn;\nL_002C:\n\tv61 = v36.collision;\n\tv62 = v36.collision < 4;\n\tv63 = ~v62;\n\tv64 = v36.collision - 4;\n\tv66 = v64 == 0;\n\tv71 = ~v66;\n\tv72 = v63 & v71;\n\tif (v72) goto L_004F;\n\tv74 = 0x1818000 + 0xE48;\n\tv76 = *([v74 @ X9_v2 (System.Int32)+v61 @ X8_v5 (HutongGames.PlayMaker.CollisionType)*4]) + v74;\n\t// 61 IndirectJump v76 @ X8_v7, v45 @ X0_v5 (HutongGames.PlayMaker.FsmOwnerDefault), v45 @ X0_v5 (HutongGames.PlayMaker.FsmOwnerDefault), 0, v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0081;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 71 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionEnter(X0, X1, X2);\n\treturn;\nL_004F:\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0081;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 89 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionStay(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0081;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 101 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleCollisionExit(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0081;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 113 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleControllerColliderHit(X0, X1, X2);\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_0081;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 125 ShiftStack 32\n\tHutongGames.PlayMaker.Fsm::set_HandleParticleCollision(X0, X1, X2);\n\treturn;\nL_0081:\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			CollisionType collisionType = collision;
			bool flag3 = collision < CollisionType.OnParticleCollision;
			bool flag4 = !flag3;
			int num = (int)(collision - 4);
			bool flag5 = num == 0;
			bool flag6 = !flag5;
			if (!(flag4 && flag6))
			{
				int num2 = 25264128 + 3656;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X9_v2 (System.Int32)+v61 @ X8_v5 (HutongGames.PlayMaker.CollisionType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X8_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000CEF")]
		[Address(RVA = "0xA90024", Offset = "0xA90024", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECCB58]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221EB]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_0054;\n\tgoto L_002A;\n\tv80 = *([v71 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002A;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv88 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv109 = v88 == 0;\n\tif (v109) goto L_0031;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::GetProxyComponent(this);\nL_0031:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::AddCallback(this);\n\tv62 = this.gameObject;\n\tv57 = new System.Action();\n\tSystem.Action::.ctor(v57, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::add_OnChange(v62.gameObject, v57);\n\treturn;\nL_0054:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000CF0")]
		[Address(RVA = "0xA902FC", Offset = "0xA902FC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE41F0]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221EC]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_003E;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::RemoveCallback(this);\n\tv60 = this.gameObject;\n\tv55 = new System.Action();\n\tSystem.Action::.ctor(v55, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::remove_OnChange(v60.gameObject, v55);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000CF1")]
		[Address(RVA = "0xA90594", Offset = "0xA90594", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CollisionEvent::RemoveCallback(this);\n\tHutongGames.PlayMaker.Actions.CollisionEvent::GetProxyComponent(this);\n\tHutongGames.PlayMaker.Actions.CollisionEvent::AddCallback(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateCallback()
		{
			RemoveCallback();
			GetProxyComponent();
			AddCallback();
		}

		[Token(Token = "0x6000CF2")]
		[Address(RVA = "0xA8FE7C", Offset = "0xA8FE7C", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE19B0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221ED]) = v38;\nL_0013:\n\tv39 = this.gameObject;\n\tthis.cachedProxy = 0;\n\tv45 = HutongGames.PlayMaker.FsmGameObject::get_Value(v39.gameObject);\n\tgoto L_002D;\n\tv56 = *([v52 @ X8_v6+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002D;\n\tv122 = v52;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v122, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv66 = UnityEngine.Object::op_Equality(v45, 0);\n\tv124 = v66 == 0;\n\tv112 = ~v124;\n\tif (v112) goto L_0098;\n\tv125 = this.collision;\n\tv126 = this.collision < 4;\n\tv102 = ~v126;\n\tv98 = this.collision - 4;\n\tv90 = v98 == 0;\n\tv127 = ~v90;\n\tv70 = v102 & v127;\n\tif (v70) goto L_0098;\n\tv107 = 0x1818000 + 0xE5C;\n\tv116 = *([v107 @ X9_v4 (System.Int32)+v125 @ X8_v8 (HutongGames.PlayMaker.CollisionType)*4]) + v107;\n\t// 67 IndirectJump v116 @ X8_v10, v66 @ X0_v9 (System.Boolean), v66 @ X0_v9 (System.Boolean), 0, 0, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0050;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0050;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0050:\n\tX8 = 0x1EEC000;\n\tX8 = *([1EEC128]);\n\tgoto L_008E;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005F:\n\tX8 = 0x1EB9000;\n\tX8 = *([1EB9C50]);\n\tgoto L_008E;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tX8 = 0x1ED5000;\n\tX8 = *([1ED5B08]);\n\tgoto L_008E;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_007D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX8 = 0x1F04000;\n\tX8 = *([1F04CD8]);\n\tgoto L_008E;\n\tX8 = *([1EA84D0]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_008C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008C:\n\tX8 = 0x1EA3000;\n\tX8 = *([1EA3480]);\nL_008E:\n\tX0 = 0xA9B328(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = X20;\n\tX0 = PlayMakerFSM::GetEventHandlerComponent /* +15 sharing this address */(X0, X1);\n\t*([X19+80]) = X0;\nL_0098:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					CollisionType collisionType = collision;
					bool flag = collision < CollisionType.OnParticleCollision;
					bool flag2 = !flag;
					int num = (int)(collision - 4);
					bool flag3 = num == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						int num2 = 25264128 + 3676;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X9_v4 (System.Int32)+v125 @ X8_v8 (HutongGames.PlayMaker.CollisionType)*4]");
						object obj = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v116 @ X8_v10 (should have been resolved before IL gen)");
						continue;
					}
					break;
				}
				break;
			}
		}

		[Token(Token = "0x6000CF3")]
		[Address(RVA = "0xA90124", Offset = "0xA90124", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE1EF0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221EE]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_002F;\nL_002E:\n\treturn;\nL_002F:\n\tv89 = this.collision;\n\tv95 = this.collision < 4;\n\tv87 = ~v95;\n\tv84 = this.collision - 4;\n\tv78 = v84 == 0;\n\tv96 = ~v78;\n\tv63 = v87 & v96;\n\tif (v63) goto L_002E;\n\tv99 = 0x1818000 + 0xE70;\n\tv113 = *([v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.CollisionType)*4]) + v99;\n\t// 64 IndirectJump v113 @ X8_v9, v58 @ X0_v5 (System.Boolean), v58 @ X0_v5 (System.Boolean), 0, 0, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED8258]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F04728]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ECC810]);\nL_0058:\n\tX2 = *([X8]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tPlayMakerProxyBase+CollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 103 ShiftStack 48\n\tPlayMakerProxyBase::AddCollisionEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1ECE3C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F10E90]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ControllerCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 128 ShiftStack 48\n\tPlayMakerProxyBase::AddControllerCollisionEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1EEE8B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE5368]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ParticleCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 153 ShiftStack 48\n\tPlayMakerProxyBase::AddParticleCollisionEventCallback(X0, X1, X2);\n\treturn;\nL_009C:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddCallback()
		{
			//IL_00c2: Expected O, but got I
			while (!(cachedProxy == null))
			{
				CollisionType collisionType = collision;
				bool flag = collision < CollisionType.OnParticleCollision;
				bool flag2 = !flag;
				int num = (int)(collision - 4);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 3696;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.CollisionType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X8_v9 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000CF4")]
		[Address(RVA = "0xA903BC", Offset = "0xA903BC", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EEAB40]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221EF]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_002F;\nL_002E:\n\treturn;\nL_002F:\n\tv89 = this.collision;\n\tv95 = this.collision < 4;\n\tv87 = ~v95;\n\tv84 = this.collision - 4;\n\tv78 = v84 == 0;\n\tv96 = ~v78;\n\tv63 = v87 & v96;\n\tif (v63) goto L_002E;\n\tv99 = 0x1818000 + 0xE84;\n\tv113 = *([v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.CollisionType)*4]) + v99;\n\t// 64 IndirectJump v113 @ X8_v9, v58 @ X0_v5 (System.Boolean), v58 @ X0_v5 (System.Boolean), 0, 0, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED8258]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F04728]);\n\tgoto L_0058;\n\tX20 = *([X19+80]);\n\tX8 = *([1F0E7B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ECC810]);\nL_0058:\n\tX2 = *([X8]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tPlayMakerProxyBase+CollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 103 ShiftStack 48\n\tPlayMakerProxyBase::RemoveCollisionEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1ECE3C0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F10E90]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ControllerCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 128 ShiftStack 48\n\tPlayMakerProxyBase::RemoveControllerCollisionEventCallback(X0, X1, X2);\n\treturn;\n\tX20 = *([X19+80]);\n\tX8 = *([1EEE8B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EE5368]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tPlayMakerProxyBase+ParticleCollisionEvent::.ctor(X0, X1, X2, X3);\n\tif (TEMP) goto L_009C;\n\tX0 = X20;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX1 = X21;\n\tX2 = 0;\n\tX21 = stack[0];\n\t// 153 ShiftStack 48\n\tPlayMakerProxyBase::RemoveParticleCollisionEventCallback(X0, X1, X2);\n\treturn;\nL_009C:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveCallback()
		{
			//IL_00c2: Expected O, but got I
			while (!(cachedProxy == null))
			{
				CollisionType collisionType = collision;
				bool flag = collision < CollisionType.OnParticleCollision;
				bool flag2 = !flag;
				int num = (int)(collision - 4);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25264128 + 3716;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X9_v2 (System.Int32)+v89 @ X8_v7 (HutongGames.PlayMaker.CollisionType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X8_v9 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000CF5")]
		[Address(RVA = "0xA905C0", Offset = "0xA905C0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = UnityEngine.Collision::get_gameObject(collisionInfo);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, v22);\n\tv52 = this.storeForce;\n\tv34 = UnityEngine.Collision::get_relativeVelocity(collisionInfo);\n\tv42 = 0x158AD58(&v34 @ V0_v2 (UnityEngine.Vector3), 0, 0, v55, v56, v57, v58, v59, v34, v34.y, v34.z, v60, v61, v62, v63, v64);\n\tv52.value = v34;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo(Collision collisionInfo)
		{
			GameObject value = collisionInfo.gameObject;
			storeCollider.Value = value;
			FsmFloat fsmFloat = storeForce;
			Vector3 relativeVelocity = collisionInfo.relativeVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
			fsmFloat.Value = relativeVelocity.x;
		}

		[Token(Token = "0x6000CF6")]
		[Address(RVA = "0xA90654", Offset = "0xA90654", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::CollisionEnter(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionEnter(Collision collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionEnter(collisionInfo);
			}
		}

		[Token(Token = "0x6000CF7")]
		[Address(RVA = "0xA906E4", Offset = "0xA906E4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::CollisionStay(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionStay(Collision collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionStay(collisionInfo);
			}
		}

		[Token(Token = "0x6000CF8")]
		[Address(RVA = "0xA90778", Offset = "0xA90778", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::CollisionExit(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoCollisionExit(Collision collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				CollisionExit(collisionInfo);
			}
		}

		[Token(Token = "0x6000CF9")]
		[Address(RVA = "0xA9080C", Offset = "0xA9080C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::ControllerColliderHit(this, collisionInfo);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoControllerColliderHit(ControllerColliderHit collisionInfo)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				ControllerColliderHit(collisionInfo);
			}
		}

		[Token(Token = "0x6000CFA")]
		[Address(RVA = "0xA908D8", Offset = "0xA908D8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.CollisionEvent::ParticleCollision(this, other);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoParticleCollision(GameObject other)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				ParticleCollision(other);
			}
		}

		[Token(Token = "0x6000CFB")]
		[Address(RVA = "0xA9067C", Offset = "0xA9067C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.collision == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0027;\n\tv20 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv26 = v20 == 0;\n\tif (v26) goto L_0027;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0027:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionEnter(Collision collisionInfo)
		{
			if (collision == CollisionType.OnCollisionEnter && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000CFC")]
		[Address(RVA = "0xA9070C", Offset = "0xA9070C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 1;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionStay(Collision collisionInfo)
		{
			if (collision == CollisionType.OnCollisionStay && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000CFD")]
		[Address(RVA = "0xA907A0", Offset = "0xA907A0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 2;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.CollisionEvent::StoreCollisionInfo(this, collisionInfo);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollisionExit(Collision collisionInfo)
		{
			if (collision == CollisionType.OnCollisionExit && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				StoreCollisionInfo(collisionInfo);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000CFE")]
		[Address(RVA = "0xA90834", Offset = "0xA90834", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this.collision != 3;\n\tif (v26) goto L_003F;\n\tv30 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, collisionInfo);\n\tv33 = v30 == 0;\n\tif (v33) goto L_003F;\n\tv70 = this.storeCollider == 0;\n\tif (v70) goto L_0028;\n\tv82 = UnityEngine.ControllerColliderHit::get_gameObject(collisionInfo);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, v82);\nL_0028:\n\tv64 = this.storeForce;\n\tv64.value = 0f;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ControllerColliderHit(ControllerColliderHit collisionInfo)
		{
			if (collision == CollisionType.OnControllerColliderHit && FsmStateAction.TagMatches(collideTag, collisionInfo))
			{
				if (storeCollider != null)
				{
					GameObject value = collisionInfo.gameObject;
					storeCollider.Value = value;
				}
				FsmFloat fsmFloat = storeForce;
				fsmFloat.Value = 0f;
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000CFF")]
		[Address(RVA = "0xA90900", Offset = "0xA90900", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.collision != 4;\n\tif (v24) goto L_0036;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, other);\n\tv31 = v28 == 0;\n\tif (v31) goto L_0036;\n\tv64 = this.storeCollider == 0;\n\tif (v64) goto L_0021;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, other);\nL_0021:\n\tv58 = this.storeForce;\n\tv58.value = 0f;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ParticleCollision(GameObject other)
		{
			if (collision == CollisionType.OnParticleCollision && FsmStateAction.TagMatches(collideTag, other))
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

		[Token(Token = "0x6000D00")]
		[Address(RVA = "0xA90984", Offset = "0xA90984", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(v12);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			return ActionHelpers.CheckPhysicsSetup(ownerDefaultTarget);
		}

		[Token(Token = "0x6000D01")]
		[Address(RVA = "0xA909B4", Offset = "0xA909B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CollisionEvent()
		{
		}
	}
}
