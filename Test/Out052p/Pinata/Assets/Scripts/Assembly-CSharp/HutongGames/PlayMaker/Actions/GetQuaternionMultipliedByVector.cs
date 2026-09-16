using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B810", Offset = "0x75B810")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B810", Offset = "0x75B810")]
	[Token(Token = "0x20002F0")]
	public class GetQuaternionMultipliedByVector : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1578", Offset = "0x7C1578")]
		[Token(Token = "0x40018FE")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion quaternion;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C15C4", Offset = "0x7C15C4")]
		[Token(Token = "0x40018FF")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector3;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1610", Offset = "0x7C1610")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1610", Offset = "0x7C1610")]
		[Token(Token = "0x4001900")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 result;

		[Token(Token = "0x6000EB0")]
		[Address(RVA = "0xA32DC8", Offset = "0xA32DC8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector)+64]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector)+54]) = 0;\n\tthis.everyFrameOption = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			_ = 0;
			_ = 0;
			_ = 0;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EB1")]
		[Address(RVA = "0xA32DE0", Offset = "0xA32DE0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector::DoQuatMult(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatMult();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EB2")]
		[Address(RVA = "0xA32F04", Offset = "0xA32F04", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector::DoQuatMult(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EB3")]
		[Address(RVA = "0xA32F14", Offset = "0xA32F14", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector::DoQuatMult(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EB4")]
		[Address(RVA = "0xA32F28", Offset = "0xA32F28", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByVector::DoQuatMult(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EB5")]
		[Address(RVA = "0xA32E1C", Offset = "0xA32E1C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EE2738]);\n\tv33 = *([v32 @ X8_v13]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021DFF]) = v52;\nL_001A:\n\tv53 = this.quaternion;\n\tv98 = this.result;\n\tv102 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3);\n\tgoto L_0040;\n\tv133 = *([v129 @ X0_v7+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0040;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v129, v84, v36, v37, v38, v39, v40, v41, v102, v125, v126, v45, v46, v47, v48, v49);\nL_0040:\n\t// 64 MakeStruct v61 @ AGGA32ED0_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v53.value (UnityEngine.Quaternion), v53.value.y (System.Single), v53.value.z (System.Single), v53.value.w (System.Single)\n\tv82 = UnityEngine.Quaternion::op_Multiply(v61, v102);\n\tv98.value = v82;\n\tv98.value.y = v82.y;\n\tv98.value.z = v82.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatMult()
		{
			FsmQuaternion fsmQuaternion = this.quaternion;
			FsmVector3 fsmVector = result;
			Vector3 value = vector3.Value;
			Quaternion quaternion = default(Quaternion);
			quaternion.x = fsmQuaternion.value.x;
			quaternion.y = fsmQuaternion.value.y;
			quaternion.z = fsmQuaternion.value.z;
			quaternion.w = fsmQuaternion.value.w;
			Vector3 vector = (fsmVector.value = quaternion * value);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
		}

		[Token(Token = "0x6000EB6")]
		[Address(RVA = "0xA32F3C", Offset = "0xA32F3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionBaseAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetQuaternionMultipliedByVector()
		{
		}
	}
}
