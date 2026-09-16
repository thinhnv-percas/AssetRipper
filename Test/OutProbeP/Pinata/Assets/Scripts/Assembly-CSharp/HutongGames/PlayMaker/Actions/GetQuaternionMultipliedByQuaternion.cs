using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B7C0", Offset = "0x75B7C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B7C0", Offset = "0x75B7C0")]
	[Token(Token = "0x20002EF")]
	public class GetQuaternionMultipliedByQuaternion : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1480", Offset = "0x7C1480")]
		[Token(Token = "0x40018FB")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion quaternionA;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C14CC", Offset = "0x7C14CC")]
		[Token(Token = "0x40018FC")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion quaternionB;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1518", Offset = "0x7C1518")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1518", Offset = "0x7C1518")]
		[Token(Token = "0x40018FD")]
		[FieldOffset(Offset = "0x60")]
		public FsmQuaternion result;

		[Token(Token = "0x6000EA9")]
		[Address(RVA = "0xA32C54", Offset = "0xA32C54", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion)+64]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion)+54]) = 0;\n\tthis.everyFrameOption = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			_ = 0;
			_ = 0;
			_ = 0;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EAA")]
		[Address(RVA = "0xA32C6C", Offset = "0xA32C6C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion::DoQuatMult(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatMult();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EAB")]
		[Address(RVA = "0xA32D88", Offset = "0xA32D88", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion::DoQuatMult(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EAC")]
		[Address(RVA = "0xA32D98", Offset = "0xA32D98", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion::DoQuatMult(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EAD")]
		[Address(RVA = "0xA32DAC", Offset = "0xA32DAC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionMultipliedByQuaternion::DoQuatMult(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatMult();
			}
		}

		[Token(Token = "0x6000EAE")]
		[Address(RVA = "0xA32CA8", Offset = "0xA32CA8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EA7288]);\n\tv35 = *([v34 @ X8_v10]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021DFE]) = v54;\nL_001B:\n\tv55 = this.quaternionA;\n\tv57 = this.quaternionB;\n\tv107 = this.result;\n\tgoto L_003F;\n\tv117 = *([v113 @ X0_v5+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_003F;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v113, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_003F:\n\t// 63 MakeStruct v64 @ AGGA32D54_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v55.value (UnityEngine.Quaternion), v55.value.y (System.Single), v55.value.z (System.Single), v55.value.w (System.Single)\n\t// 64 MakeStruct v61 @ AGGA32D54_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v57.value (UnityEngine.Quaternion), v57.value.y (System.Single), v57.value.z (System.Single), v57.value.w (System.Single)\n\tv80 = UnityEngine.Quaternion::op_Multiply(v64, v61);\n\tv107.value = v80;\n\tv107.value.y = v80.y;\n\tv107.value.z = v80.z;\n\tv107.value.w = v80.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatMult()
		{
			FsmQuaternion fsmQuaternion = quaternionA;
			FsmQuaternion fsmQuaternion2 = quaternionB;
			FsmQuaternion fsmQuaternion3 = result;
			Quaternion quaternion = default(Quaternion);
			quaternion.x = fsmQuaternion.value.x;
			quaternion.y = fsmQuaternion.value.y;
			quaternion.z = fsmQuaternion.value.z;
			quaternion.w = fsmQuaternion.value.w;
			Quaternion quaternion2 = default(Quaternion);
			quaternion2.x = fsmQuaternion2.value.x;
			quaternion2.y = fsmQuaternion2.value.y;
			quaternion2.z = fsmQuaternion2.value.z;
			quaternion2.w = fsmQuaternion2.value.w;
			Quaternion quaternion3 = (fsmQuaternion3.value = quaternion * quaternion2);
			fsmQuaternion3.value.y = quaternion3.y;
			fsmQuaternion3.value.z = quaternion3.z;
			fsmQuaternion3.value.w = quaternion3.w;
		}

		[Token(Token = "0x6000EAF")]
		[Address(RVA = "0xA32DC0", Offset = "0xA32DC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionBaseAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetQuaternionMultipliedByQuaternion()
		{
		}
	}
}
