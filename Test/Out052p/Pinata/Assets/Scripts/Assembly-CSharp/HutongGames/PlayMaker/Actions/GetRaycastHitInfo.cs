using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759E78", Offset = "0x759E78")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759E78", Offset = "0x759E78")]
	[Token(Token = "0x20002A2")]
	public class GetRaycastHitInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA184", Offset = "0x7BA184")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA184", Offset = "0x7BA184")]
		[Token(Token = "0x400173A")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA1D4", Offset = "0x7BA1D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA1D4", Offset = "0x7BA1D4")]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7BA1D4", Offset = "0x7BA1D4")]
		[Token(Token = "0x400173B")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 point;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA248", Offset = "0x7BA248")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA248", Offset = "0x7BA248")]
		[Token(Token = "0x400173C")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 normal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA298", Offset = "0x7BA298")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA298", Offset = "0x7BA298")]
		[Token(Token = "0x400173D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat distance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA2E8", Offset = "0x7BA2E8")]
		[Token(Token = "0x400173E")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000D1D")]
		[Address(RVA = "0xA338D0", Offset = "0xA338D0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObjectHit = 0;\n\tthis.normal = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObjectHit = null;
			normal = null;
		}

		[Token(Token = "0x6000D1E")]
		[Address(RVA = "0xA338E0", Offset = "0xA338E0", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAD548]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E05]) = v38;\nL_0018:\n\tv44 = this.fsm;\n\tv56 = v44.<RaycastHitInfo>k__BackingField;\n\tv57 = 0x164C7C8(&v56 @ V0_v6 (UnityEngine.RaycastHit), 0, v22, v23, v24, v25, v26, v27, v44.<RaycastHitInfo>k__BackingField, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0038;\n\tv150 = *([v130 @ X8_v9+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0038;\n\tv157 = v130;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v157, v54, v22, v23, v24, v25, v26, v27, v56, v29, v30, v31, v32, v33, v34, v35);\nL_0038:\n\tv96 = UnityEngine.Object::op_Inequality(v57, 0);\n\tv159 = v96 == 0;\n\tif (v159) goto L_0098;\n\tv114 = this.fsm;\n\tv56 = v114.<RaycastHitInfo>k__BackingField;\n\tv143 = 0x164C7C8(&v56 @ V0_v6 (UnityEngine.RaycastHit), 0, 0, v23, v24, v25, v26, v27, v114.<RaycastHitInfo>k__BackingField, v29, v30, v31, v32, v33, v34, v35);\n\tv97 = UnityEngine.Component::get_gameObject(v143);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v97);\n\tv116 = this.fsm;\n\tv125 = this.point;\n\tv85 = v116.<RaycastHitInfo>k__BackingField;\n\tv99 = 0x164C878(&v85 @ V0_v13 (UnityEngine.Vector3), 0, 0, v23, v24, v25, v26, v27, v116.<RaycastHitInfo>k__BackingField, v29, v30, v31, v32, v33, v34, v35);\n\tv125.value = v116.<RaycastHitInfo>k__BackingField;\n\tv125.value.y = v29;\n\tv125.value.z = v30;\n\tv118 = this.fsm;\n\tv126 = this.normal;\n\tv86 = v118.<RaycastHitInfo>k__BackingField;\n\tv100 = 0x164C884(&v86 @ V0_v16 (UnityEngine.Vector3), 0, 0, v23, v24, v25, v26, v27, v118.<RaycastHitInfo>k__BackingField, v29, v30, v31, v32, v33, v34, v35);\n\tv126.value = v118.<RaycastHitInfo>k__BackingField;\n\tv126.value.y = v29;\n\tv126.value.z = v30;\n\tv120 = this.fsm;\n\tv112 = this.distance;\n\tv87 = v120.<RaycastHitInfo>k__BackingField;\n\tv101 = 0x164C890(&v87 @ V0_v19 (System.Single), 0, 0, v23, v24, v25, v26, v27, v120.<RaycastHitInfo>k__BackingField, v29, v30, v31, v32, v33, v34, v35);\n\tv112.value = v120.<RaycastHitInfo>k__BackingField;\nL_0098:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreRaycastInfo()
		{
			//IL_0194: Expected F4, but got O
			//IL_01b5: Expected F4, but got O
			Fsm fsm = Fsm;
			RaycastHit raycastHit = fsm.RaycastHitInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
			Object obj = default(Object);
			if (obj != null)
			{
				Fsm fsm2 = Fsm;
				raycastHit = fsm2.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				gameObjectHit.Value = gameObject;
				Fsm fsm3 = Fsm;
				FsmVector3 fsmVector = point;
				Vector3 vector = (Vector3)fsm3.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
				fsmVector.value = (Vector3)fsm3.RaycastHitInfo;
				float y = default(float);
				fsmVector.value.y = y;
				float z = default(float);
				fsmVector.value.z = z;
				Fsm fsm4 = Fsm;
				FsmVector3 fsmVector2 = normal;
				Vector3 vector2 = (Vector3)fsm4.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				fsmVector2.value = (Vector3)fsm4.RaycastHitInfo;
				fsmVector2.value.y = y;
				fsmVector2.value.z = z;
				Fsm fsm5 = Fsm;
				FsmFloat fsmFloat = distance;
				float num = (float)fsm5.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				fsmFloat.Value = (float)fsm5.RaycastHitInfo;
			}
		}

		[Token(Token = "0x6000D1F")]
		[Address(RVA = "0xA33AE4", Offset = "0xA33AE4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRaycastHitInfo::StoreRaycastInfo(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreRaycastInfo();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D20")]
		[Address(RVA = "0xA33B20", Offset = "0xA33B20", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRaycastHitInfo::StoreRaycastInfo(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			StoreRaycastInfo();
		}

		[Token(Token = "0x6000D21")]
		[Address(RVA = "0xA33B24", Offset = "0xA33B24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRaycastHitInfo()
		{
		}
	}
}
