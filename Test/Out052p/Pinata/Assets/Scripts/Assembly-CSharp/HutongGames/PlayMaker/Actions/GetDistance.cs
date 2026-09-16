using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7561DC", Offset = "0x7561DC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7561DC", Offset = "0x7561DC")]
	[Token(Token = "0x20001E7")]
	public class GetDistance : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0F80", Offset = "0x7B0F80")]
		[Token(Token = "0x400144D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0FCC", Offset = "0x7B0FCC")]
		[Token(Token = "0x400144E")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject target;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1018", Offset = "0x7B1018")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1018", Offset = "0x7B1018")]
		[Token(Token = "0x400144F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1078", Offset = "0x7B1078")]
		[Token(Token = "0x4001450")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000A0B")]
		[Address(RVA = "0xA2AD60", Offset = "0xA2AD60", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.target = 0;\n\tthis.storeResult = 0;\n\tthis.gameObject = 0;\n\tthis.everyFrame = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			target = null;
			storeResult = null;
			gameObject = null;
			everyFrame = true;
		}

		[Token(Token = "0x6000A0C")]
		[Address(RVA = "0xA2AD74", Offset = "0xA2AD74", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDistance::DoGetDistance(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetDistance();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A0D")]
		[Address(RVA = "0xA2AF58", Offset = "0xA2AF58", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDistance::DoGetDistance(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetDistance();
		}

		[Token(Token = "0x6000A0E")]
		[Address(RVA = "0xA2ADB0", Offset = "0xA2ADB0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F08560]);\n\tv33 = *([v32 @ X8_v15]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021DAF]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0031;\n\tv127 = *([v99 @ X8_v5+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0031;\n\tv135 = v99;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v135, v55, v56, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0031:\n\tv134 = UnityEngine.Object::op_Equality(v57, 0);\n\tv137 = v134 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0095;\n\tv217 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tgoto L_004A;\n\tv221 = *([v100 @ X8_v7+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_004A;\n\tv228 = v100;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v228, v216, v78, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_004A:\n\tv120 = UnityEngine.Object::op_Equality(v217, 0);\n\tv230 = v120 == 0;\n\tv213 = ~v230;\n\tif (v213) goto L_0095;\n\tv76 = this.storeResult;\n\tv214 = this.storeResult == 0;\n\tif (v214) goto L_0095;\n\tv88 = UnityEngine.GameObject::get_transform(v57);\n\tv69 = UnityEngine.Transform::get_position(v88);\n\tv90 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tv91 = UnityEngine.GameObject::get_transform(v90);\n\tv232 = UnityEngine.Transform::get_position(v91);\n\tgoto L_0087;\n\tv241 = *([v237 @ X0_v23+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_0087;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v237, v210, v79, v37, v38, v39, v40, v41, v232, v233, v234, v45, v46, v47, v48, v49);\nL_0087:\n\tv207 = UnityEngine.Vector3::Distance(v69, v232);\n\tv76.value = v207;\nL_0095:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetDistance()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			GameObject value = target.Value;
			if (!(value == null))
			{
				FsmFloat fsmFloat = storeResult;
				if (storeResult != null)
				{
					Transform transform = ownerDefaultTarget.transform;
					Vector3 position = transform.position;
					GameObject value2 = target.Value;
					Transform transform2 = value2.transform;
					Vector3 position2 = transform2.position;
					float value3 = Vector3.Distance(position, position2);
					fsmFloat.Value = value3;
				}
			}
		}

		[Token(Token = "0x6000A0F")]
		[Address(RVA = "0xA2AF5C", Offset = "0xA2AF5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetDistance()
		{
		}
	}
}
