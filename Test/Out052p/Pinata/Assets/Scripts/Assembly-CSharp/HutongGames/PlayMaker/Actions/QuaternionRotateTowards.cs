using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BA90", Offset = "0x75BA90")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BA90", Offset = "0x75BA90")]
	[Token(Token = "0x20002F9")]
	public class QuaternionRotateTowards : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1D48", Offset = "0x7C1D48")]
		[Token(Token = "0x4001919")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion fromQuaternion;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1D94", Offset = "0x7C1D94")]
		[Token(Token = "0x400191A")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion toQuaternion;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1DE0", Offset = "0x7C1DE0")]
		[Token(Token = "0x400191B")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat maxDegreesDelta;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1E2C", Offset = "0x7C1E2C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1E2C", Offset = "0x7C1E2C")]
		[Token(Token = "0x400191C")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion storeResult;

		[Token(Token = "0x6000EEA")]
		[Address(RVA = "0xB1C5C8", Offset = "0xB1C5C8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EA37A0]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022583]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromQuaternion = v46;\n\tv52 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.toQuaternion = v52;\n\tv73 = HutongGames.PlayMaker.FsmFloat::op_Implicit(10f);\n\tthis.maxDegreesDelta = v73;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			fromQuaternion = fsmQuaternion;
			FsmQuaternion fsmQuaternion2 = new FsmQuaternion();
			fsmQuaternion2.useVariable = true;
			toQuaternion = fsmQuaternion2;
			FsmFloat fsmFloat = 10f;
			maxDegreesDelta = fsmFloat;
			storeResult = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EEB")]
		[Address(RVA = "0xB1C67C", Offset = "0xB1C67C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionRotateTowards::DoQuatRotateTowards(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatRotateTowards();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EEC")]
		[Address(RVA = "0xB1C7C0", Offset = "0xB1C7C0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionRotateTowards::DoQuatRotateTowards(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatRotateTowards();
			}
		}

		[Token(Token = "0x6000EED")]
		[Address(RVA = "0xB1C7D0", Offset = "0xB1C7D0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionRotateTowards::DoQuatRotateTowards(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatRotateTowards();
			}
		}

		[Token(Token = "0x6000EEE")]
		[Address(RVA = "0xB1C7E4", Offset = "0xB1C7E4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionRotateTowards::DoQuatRotateTowards(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatRotateTowards();
			}
		}

		[Token(Token = "0x6000EEF")]
		[Address(RVA = "0xB1C6B8", Offset = "0xB1C6B8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EFA1A8]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022584]) = v54;\nL_001B:\n\tv55 = this.fromQuaternion;\n\tv57 = this.toQuaternion;\n\tv110 = this.storeResult;\n\tv143 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxDegreesDelta);\n\tgoto L_0047;\n\tv190 = *([v146 @ X0_v7+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0047;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v146, v102, v38, v39, v40, v41, v42, v43, v143, v45, v46, v47, v48, v49, v50, v51);\nL_0047:\n\t// 71 MakeStruct v64 @ AGGB1C788_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v55.value (UnityEngine.Quaternion), v55.value.y (System.Single), v55.value.z (System.Single), v55.value.w (System.Single)\n\t// 72 MakeStruct v61 @ AGGB1C788_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v57.value (UnityEngine.Quaternion), v57.value.y (System.Single), v57.value.z (System.Single), v57.value.w (System.Single)\n\tv104 = UnityEngine.Quaternion::RotateTowards(v64, v61, v143);\n\tv110.value = v104;\n\tv110.value.y = v104.y;\n\tv110.value.z = v104.z;\n\tv110.value.w = v104.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatRotateTowards()
		{
			FsmQuaternion fsmQuaternion = fromQuaternion;
			FsmQuaternion fsmQuaternion2 = toQuaternion;
			FsmQuaternion fsmQuaternion3 = storeResult;
			float value = maxDegreesDelta.Value;
			Quaternion quaternion = default(Quaternion);
			quaternion.x = fsmQuaternion.value.x;
			quaternion.y = fsmQuaternion.value.y;
			quaternion.z = fsmQuaternion.value.z;
			quaternion.w = fsmQuaternion.value.w;
			Quaternion to = default(Quaternion);
			to.x = fsmQuaternion2.value.x;
			to.y = fsmQuaternion2.value.y;
			to.z = fsmQuaternion2.value.z;
			to.w = fsmQuaternion2.value.w;
			Quaternion quaternion2 = (fsmQuaternion3.value = Quaternion.RotateTowards(quaternion, to, value));
			fsmQuaternion3.value.y = quaternion2.y;
			fsmQuaternion3.value.z = quaternion2.z;
			fsmQuaternion3.value.w = quaternion2.w;
		}

		[Token(Token = "0x6000EF0")]
		[Address(RVA = "0xB1C7F8", Offset = "0xB1C7F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionRotateTowards()
		{
		}
	}
}
