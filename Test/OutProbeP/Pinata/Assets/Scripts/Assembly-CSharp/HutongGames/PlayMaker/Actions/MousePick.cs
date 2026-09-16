using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757FB8", Offset = "0x757FB8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x757FB8", Offset = "0x757FB8")]
	[Token(Token = "0x2000245")]
	public class MousePick : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4028", Offset = "0x7B4028")]
		[Token(Token = "0x4001595")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat rayDistance;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4074", Offset = "0x7B4074")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4074", Offset = "0x7B4074")]
		[Token(Token = "0x4001596")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool storeDidPickObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B40C4", Offset = "0x7B40C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B40C4", Offset = "0x7B40C4")]
		[Token(Token = "0x4001597")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject storeGameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4114", Offset = "0x7B4114")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4114", Offset = "0x7B4114")]
		[Token(Token = "0x4001598")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storePoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4164", Offset = "0x7B4164")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4164", Offset = "0x7B4164")]
		[Token(Token = "0x4001599")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 storeNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B41B4", Offset = "0x7B41B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B41B4", Offset = "0x7B41B4")]
		[Token(Token = "0x400159A")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat storeDistance;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4204", Offset = "0x7B4204")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4204", Offset = "0x7B4204")]
		[Token(Token = "0x400159B")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4254", Offset = "0x7B4254")]
		[Token(Token = "0x400159C")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B428C", Offset = "0x7B428C")]
		[Token(Token = "0x400159D")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x6000B62")]
		[Address(RVA = "0xA3CB30", Offset = "0xA3CB30", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA4898]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E5B]) = v38;\nL_0016:\n\tv42 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v42;\n\tthis.storeDistance = 0;\n\tthis.storePoint = 0;\n\tthis.storeDidPickObject = 0;\n\t// 32 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v48;\n\tv51 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v51;\n\tthis.everyFrame = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 100f;
			rayDistance = fsmFloat;
			storeDistance = null;
			storePoint = null;
			storeDidPickObject = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000B63")]
		[Address(RVA = "0xA3CBC0", Offset = "0xA3CBC0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick::DoMousePick(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoMousePick();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B64")]
		[Address(RVA = "0xA3CE08", Offset = "0xA3CE08", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MousePick::DoMousePick(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMousePick();
		}

		[Token(Token = "0x6000B65")]
		[Address(RVA = "0xA3CBFC", Offset = "0xA3CBFC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = *([1F02700]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E5C]) = v40;\nL_001D:\n\tv49 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rayDistance);\n\tv130 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv176 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v130);\n\tv180 = HutongGames.PlayMaker.ActionHelpers::MousePick(v49, v176);\n\tv98 = v180.m_Point;\n\tv183 = 0x164C7C8(&v98 @ stack_-90_v2 (UnityEngine.Vector3), 0, 0, v25, v26, v27, v28, v29, v180.m_Distance, *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]), v180.m_Point, v33, v34, v35, v36, v37);\n\tgoto L_0052;\n\tv191 = *([v187 @ X8_v7+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0052;\n\tv201 = v187;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v201, v182, v175, v25, v26, v27, v28, v29, v107, v63, v66, v33, v34, v35, v36, v37);\nL_0052:\n\tv200 = UnityEngine.Object::op_Inequality(v183, 0);\n\tv123 = this.storeDidPickObject;\n\tv123.value = v200;\n\tv204 = v200 == 0;\n\tif (v204) goto L_0086;\n\tv114 = 0x164C7C8(&v98 @ stack_-90_v2 (UnityEngine.Vector3), 0, 0, v25, v26, v27, v28, v29, v180.m_Distance, *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]), v180.m_Point, v33, v34, v35, v36, v37);\n\tv220 = UnityEngine.Component::get_gameObject(v114);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, v220);\n\tv239 = this.storeDistance;\n\tv221 = 0x164C890(&v98 @ stack_-90_v2 (UnityEngine.Vector3), 0, 0, v25, v26, v27, v28, v29, v180.m_Distance, *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]), v180.m_Point, v33, v34, v35, v36, v37);\n\tv239.value = v180.m_Distance;\n\tv240 = this.storePoint;\n\tv222 = 0x164C878(&v98 @ stack_-90_v2 (UnityEngine.Vector3), 0, 0, v25, v26, v27, v28, v29, v180.m_Distance, *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]), v180.m_Point, v33, v34, v35, v36, v37);\n\tv240.value = v180.m_Distance;\n\tv240.value.y = *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]);\n\tv240.value.z = v180.m_Point;\n\tv260 = this.storeNormal;\n\tv223 = 0x164C884(&v98 @ stack_-90_v2 (UnityEngine.Vector3), 0, 0, v25, v26, v27, v28, v29, v180.m_Distance, *([v180 @ X0_v9 (UnityEngine.RaycastHit)+10]), v180.m_Point, v33, v34, v35, v36, v37);\n\tv263 = this.storeNormal == 0;\n\tv230 = ~v263;\n\tif (v230) goto L_00A9;\n\tgoto L_00B4;\nL_0086:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, 0);\n\tv237 = this.storeDistance;\n\tv237.value = Infinityf;\n\tv241 = this.storePoint;\n\tgoto L_009A;\n\tv252 = *([v247 @ X0_v20+E0]);\n\tv253 = v252 == 0;\n\tv254 = ~v253;\n\tif (v254) goto L_009A;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v247, v218, v211, v25, v26, v27, v28, v29, v107, v63, v66, v33, v34, v35, v36, v37);\nL_009A:\n\tv212 = UnityEngine.Vector3::get_zero();\n\tv241.value = v212;\n\tv241.value.y = v212.y;\n\tv241.value.z = v212.z;\n\tv260 = this.storeNormal;\n\tv158 = UnityEngine.Vector3::get_zero();\n\tv139 = v158.y;\n\tv141 = v158.z;\nL_00A9:\n\tv260.value = v158;\n\tv260.value.y = v139;\n\tv260.value.z = v141;\n\treturn;\nL_00B4:\n\tv112 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMousePick()
		{
			//IL_0153: Expected O, but got F4
			//IL_016d: Expected F4, but got I
			//IL_01ce: Expected F4, but got I
			//IL_01ed: Expected O, but got F4
			float value = rayDistance.Value;
			bool value2 = invertMask.Value;
			int num = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
			RaycastHit raycastHit = ActionHelpers.MousePick(value, num);
			Vector3 point = raycastHit.m_Point;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
			UnityEngine.Object obj = default(UnityEngine.Object);
			bool flag = obj != null;
			FsmBool fsmBool = storeDidPickObject;
			fsmBool.value = flag;
			FsmVector3 fsmVector2;
			float y;
			float z;
			Vector3 value4;
			if (flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeGameObject.Value = gameObject;
				FsmFloat fsmFloat = storeDistance;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				fsmFloat.Value = raycastHit.distance;
				FsmVector3 fsmVector = storePoint;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
				fsmVector.value = (Vector3)raycastHit.distance;
				ref Vector3 value3 = ref fsmVector.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v9 (UnityEngine.RaycastHit)+10]");
				value3.y = 0f;
				fsmVector.value.z = raycastHit.m_Point.x;
				fsmVector2 = storeNormal;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				bool flag2 = storeNormal == null;
				bool flag3 = !flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v9 (UnityEngine.RaycastHit)+10]");
				y = 0f;
				z = raycastHit.m_Point.x;
				value4 = (Vector3)raycastHit.distance;
				if (!flag3)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			else
			{
				storeGameObject.Value = null;
				FsmFloat fsmFloat2 = storeDistance;
				fsmFloat2.Value = float.PositiveInfinity;
				FsmVector3 fsmVector3 = storePoint;
				Vector3 vector = (fsmVector3.value = Vector3.zero);
				fsmVector3.value.y = vector.y;
				fsmVector3.value.z = vector.z;
				fsmVector2 = storeNormal;
				value4 = Vector3.zero;
				y = value4.y;
				z = value4.z;
			}
			fsmVector2.value = value4;
			fsmVector2.value.y = y;
			fsmVector2.value.z = z;
		}

		[Token(Token = "0x6000B66")]
		[Address(RVA = "0xA3CE0C", Offset = "0xA3CE0C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v13;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MousePick()
		{
			FsmFloat fsmFloat = 100f;
			rayDistance = fsmFloat;
		}
	}
}
