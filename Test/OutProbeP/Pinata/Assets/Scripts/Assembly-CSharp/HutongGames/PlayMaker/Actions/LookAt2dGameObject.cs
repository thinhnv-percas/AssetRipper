using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AB1C", Offset = "0x75AB1C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AB1C", Offset = "0x75AB1C")]
	[Token(Token = "0x20002CA")]
	public class LookAt2dGameObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE768", Offset = "0x7BE768")]
		[Token(Token = "0x4001850")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE7B4", Offset = "0x7BE7B4")]
		[Token(Token = "0x4001851")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE7EC", Offset = "0x7BE7EC")]
		[Token(Token = "0x4001852")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat rotationOffset;

		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7BE824", Offset = "0x7BE824")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE824", Offset = "0x7BE824")]
		[Token(Token = "0x4001853")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool debug;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE884", Offset = "0x7BE884")]
		[Token(Token = "0x4001854")]
		[FieldOffset(Offset = "0x70")]
		public FsmColor debugLineColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE8BC", Offset = "0x7BE8BC")]
		[Token(Token = "0x4001855")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001856")]
		[FieldOffset(Offset = "0x80")]
		private GameObject go;

		[Token(Token = "0x4001857")]
		[FieldOffset(Offset = "0x88")]
		private GameObject goTarget;

		[Token(Token = "0x6000DF7")]
		[Address(RVA = "0xA3B6E8", Offset = "0xA3B6E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.targetObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v12;\n\tv14 = UnityEngine.Color::get_green();\n\tv20 = HutongGames.PlayMaker.FsmColor::op_Implicit(v14);\n\tthis.debugLineColor = v20;\n\tthis.everyFrame = 1;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmBool fsmBool = false;
			debug = fsmBool;
			Color green = Color.green;
			FsmColor fsmColor = green;
			debugLineColor = fsmColor;
			everyFrame = true;
		}

		[Token(Token = "0x6000DF8")]
		[Address(RVA = "0xA3B734", Offset = "0xA3B734", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.LookAt2dGameObject::DoLookAt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoLookAt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DF9")]
		[Address(RVA = "0xA3BA70", Offset = "0xA3BA70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.LookAt2dGameObject::DoLookAt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoLookAt();
		}

		[Token(Token = "0x6000DFA")]
		[Address(RVA = "0xA3B770", Offset = "0xA3B770", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EE1B58]);\n\tv35 = *([v34 @ X8_v34]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021E4C]) = v54;\nL_0022:\n\tv61 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tthis.go = v61;\n\tv219 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.targetObject);\n\tthis.goTarget = v219;\n\tgoto L_003B;\n\tv307 = *([v222 @ X0_v11+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_003B;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v222, v218, v60, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_003B:\n\tv315 = UnityEngine.Object::op_Equality(this.go, 0);\n\tv317 = v315 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_010E;\n\tv319 = this.targetObject == 0;\n\tif (v319) goto L_010E;\n\tv137 = UnityEngine.GameObject::get_transform(this.goTarget);\n\tv118 = UnityEngine.Transform::get_position(v137);\n\tv139 = UnityEngine.GameObject::get_transform(this.go);\n\tv118 = UnityEngine.Transform::get_position(v139);\n\tgoto L_0074;\n\tv361 = *([v357 @ X0_v20+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_0074;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v357, v351, v123, v39, v40, v41, v42, v43, v352, v353, v354, v47, v48, v49, v50, v51);\nL_0074:\n\tv118 = UnityEngine.Vector3::op_Subtraction(v118, v118);\n\tv375 = 0x158A620(&v118 @ V0_v4 (UnityEngine.Vector3), 0, 0, v39, v40, v41, v42, v43, v118, v118.y, v118.z, v118, v118.y, v118.z, v50, v51);\n\tgoto L_008D;\n\tv383 = *([v379 @ X0_v25 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_008D;\n\tv387 = \"il2cpp_codegen_runtime_class_init\"(v379, v129, v123, v39, v40, v41, v42, v43, v372, v373, v109, v86, v84, v82, v50, v51);\nL_008D:\n\tv389 = 0x6D29A0(UnityEngine.Mathf, 0, 0, v39, v40, v41, v42, v43, v118.y, v118, v118.z, v118, v118.y, v118.z, v50, v51);\n\tv205 = UnityEngine.GameObject::get_transform(this.go);\n\tv100 = v118.y * 57.29578f;\n\tv392 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rotationOffset);\n\tgoto L_00AB;\n\tv399 = *([v395 @ X0_v31+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\tif (v401) goto L_00AB;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v395, v202, v123, v39, v40, v41, v42, v43, v392, v114, v109, v86, v84, v82, v50, v51);\nL_00AB:\n\tv405 = v100 - v392;\n\tv120 = UnityEngine.Quaternion::Euler(0f, 0f, v405);\n\tUnityEngine.Transform::set_rotation(v205, v120);\n\tv346 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv348 = v346 == 0;\n\tif (v348) goto L_010E;\n\tv143 = UnityEngine.GameObject::get_transform(this.go);\n\tv118 = UnityEngine.Transform::get_position(v143);\n\tv145 = UnityEngine.GameObject::get_transform(this.goTarget);\n\tv118 = UnityEngine.Transform::get_position(v145);\n\tv213 = this.debugLineColor;\n\tgoto L_0100;\n\tv415 = *([v412 @ X0_v41+E0]);\n\tv416 = v415 == 0;\n\tv417 = ~v416;\n\tif (v417) goto L_0100;\n\tv419 = \"il2cpp_codegen_runtime_class_init\"(v412, v203, v123, v39, v40, v41, v42, v43, v198, v196, v194, v87, v84, v82, v50, v51);\nL_0100:\n\tUnityEngine.Debug::DrawLine(v118, v118, v213.value);\nL_010E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoLookAt()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			go = ownerDefaultTarget;
			GameObject value = targetObject.Value;
			goTarget = value;
			if (!(go == null) && targetObject != null)
			{
				Transform transform = goTarget.transform;
				Vector3 position = transform.position;
				Transform transform2 = go.transform;
				position = transform2.position;
				position -= position;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
				Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
				Transform transform3 = go.transform;
				float num = position.y * 57.29578f;
				float value2 = rotationOffset.Value;
				float z = num - value2;
				Quaternion rotation = Quaternion.Euler(0f, 0f, z);
				transform3.rotation = rotation;
				if (debug.Value)
				{
					Transform transform4 = go.transform;
					position = transform4.position;
					Transform transform5 = goTarget.transform;
					position = transform5.position;
					FsmColor fsmColor = debugLineColor;
					Debug.DrawLine(position, position, fsmColor.value);
				}
			}
		}

		[Token(Token = "0x6000DFB")]
		[Address(RVA = "0xA3BA74", Offset = "0xA3BA74", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 1;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LookAt2dGameObject()
		{
			everyFrame = true;
		}
	}
}
