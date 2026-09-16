using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A84C", Offset = "0x75A84C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A84C", Offset = "0x75A84C")]
	[Token(Token = "0x20002C1")]
	public class GetRayCastHit2dInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BD644", Offset = "0x7BD644")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD644", Offset = "0x7BD644")]
		[Token(Token = "0x4001815")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BD694", Offset = "0x7BD694")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD694", Offset = "0x7BD694")]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7BD694", Offset = "0x7BD694")]
		[Token(Token = "0x4001816")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 point;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BD708", Offset = "0x7BD708")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD708", Offset = "0x7BD708")]
		[Token(Token = "0x4001817")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 normal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BD758", Offset = "0x7BD758")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD758", Offset = "0x7BD758")]
		[Token(Token = "0x4001818")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat distance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD7A8", Offset = "0x7BD7A8")]
		[Token(Token = "0x4001819")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000DCB")]
		[Address(RVA = "0xA332F0", Offset = "0xA332F0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObjectHit = 0;\n\tthis.normal = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObjectHit = null;
			normal = null;
		}

		[Token(Token = "0x6000DCC")]
		[Address(RVA = "0xA33300", Offset = "0xA33300", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRayCastHit2dInfo::StoreRaycastInfo(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreRaycastInfo();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DCD")]
		[Address(RVA = "0xA334E8", Offset = "0xA334E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRayCastHit2dInfo::StoreRaycastInfo(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			StoreRaycastInfo();
		}

		[Token(Token = "0x6000DCE")]
		[Address(RVA = "0xA3333C", Offset = "0xA3333C", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EE3D18]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E03]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v26, v27, v28, v29, v30, v31, v46, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv65 = HutongGames.PlayMaker.Fsm::GetLastRaycastHit2DInfo(this.fsm);\n\tv66 = v65.m_Centroid;\n\tv83 = 0x16415C8(&v66 @ stack_-88_v1 (UnityEngine.Vector2), 0, v26, v27, v28, v29, v30, v31, v65.m_Normal, v65.m_Centroid, v34, v35, v36, v37, v38, v39);\n\tgoto L_004D;\n\tv91 = *([v87 @ X8_v11+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_004D;\n\tv102 = v87;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v102, v80, v26, v27, v28, v29, v30, v31, v76, v77, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tv101 = UnityEngine.Object::op_Inequality(v83, 0);\n\tv104 = v101 == 0;\n\tif (v104) goto L_0093;\n\tv108 = 0x16415C8(&v66 @ stack_-88_v1 (UnityEngine.Vector2), 0, 0, v27, v28, v29, v30, v31, v65.m_Normal, v65.m_Centroid, v34, v35, v36, v37, v38, v39);\n\tv172 = UnityEngine.Component::get_gameObject(v108);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v172);\n\tv197 = this.point;\n\tv193 = 0x16415A8(&v66 @ stack_-88_v1 (UnityEngine.Vector2), 0, 0, v27, v28, v29, v30, v31, v65.m_Normal, v65.m_Centroid, v34, v35, v36, v37, v38, v39);\n\tv197.value = v65.m_Normal;\n\tv197.value.y = v65.m_Centroid;\n\tv135 = this.normal;\n\tv201 = 0x16415B0(&v66 @ stack_-88_v1 (UnityEngine.Vector2), 0, 0, v27, v28, v29, v30, v31, v65.m_Normal, v65.m_Centroid, v34, v35, v36, v37, v38, v39);\n\tgoto L_007C;\n\tv208 = *([v204 @ X0_v25+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_007C;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v204, v191, v119, v27, v28, v29, v30, v31, v76, v77, v34, v35, v36, v37, v38, v39);\nL_007C:\n\t// 124 MakeStruct v112 @ AGGA334A0_0_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v65.m_Normal (UnityEngine.Vector2), v65.m_Centroid (UnityEngine.Vector2)\n\tv123 = UnityEngine.Vector2::op_Implicit(v112);\n\tv135.value = v123;\n\tv135.value.y = v123.y;\n\tv135.value.z = v123.z;\n\tv131 = this.distance;\n\tv127 = 0x16415C0(&v66 @ stack_-88_v1 (UnityEngine.Vector2), 0, 0, v27, v28, v29, v30, v31, v123, v123.y, v123.z, v35, v36, v37, v38, v39);\n\tv131.value = v123;\nL_0093:\n\treturn;\n\tv182 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreRaycastInfo()
		{
			RaycastHit2D lastRaycastHit2DInfo = Fsm.GetLastRaycastHit2DInfo(Fsm);
			Vector2 centroid = lastRaycastHit2DInfo.m_Centroid;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
			Object obj = default(Object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				gameObjectHit.Value = gameObject;
				FsmVector2 fsmVector = point;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
				fsmVector.value = lastRaycastHit2DInfo.m_Normal;
				fsmVector.value.y = lastRaycastHit2DInfo.m_Centroid.x;
				FsmVector3 fsmVector2 = normal;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415B0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x88)");
				Vector2 vector = default(Vector2);
				vector.x = lastRaycastHit2DInfo.m_Normal.x;
				vector.y = lastRaycastHit2DInfo.m_Centroid.x;
				Vector3 vector2 = (fsmVector2.value = vector);
				fsmVector2.value.y = vector2.y;
				fsmVector2.value.z = vector2.z;
				FsmFloat fsmFloat = distance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x98)");
				fsmFloat.Value = vector2.x;
			}
		}

		[Token(Token = "0x6000DCF")]
		[Address(RVA = "0xA334EC", Offset = "0xA334EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRayCastHit2dInfo()
		{
		}
	}
}
