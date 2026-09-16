using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BAE0", Offset = "0x75BAE0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BAE0", Offset = "0x75BAE0")]
	[Token(Token = "0x20002FA")]
	public class QuaternionSlerp : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1E8C", Offset = "0x7C1E8C")]
		[Token(Token = "0x400191D")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion fromQuaternion;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1ED8", Offset = "0x7C1ED8")]
		[Token(Token = "0x400191E")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion toQuaternion;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1F24", Offset = "0x7C1F24")]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C1F24", Offset = "0x7C1F24")]
		[Token(Token = "0x400191F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat amount;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1F88", Offset = "0x7C1F88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1F88", Offset = "0x7C1F88")]
		[Token(Token = "0x4001920")]
		[FieldOffset(Offset = "0x68")]
		public FsmQuaternion storeResult;

		[Token(Token = "0x6000EF1")]
		[Address(RVA = "0xB1C800", Offset = "0xB1C800", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC1918]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022585]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromQuaternion = v46;\n\tv52 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.toQuaternion = v52;\n\tv73 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.1f);\n\tthis.amount = v73;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			fromQuaternion = fsmQuaternion;
			FsmQuaternion fsmQuaternion2 = new FsmQuaternion();
			fsmQuaternion2.useVariable = true;
			toQuaternion = fsmQuaternion2;
			FsmFloat fsmFloat = 0.1f;
			amount = fsmFloat;
			storeResult = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EF2")]
		[Address(RVA = "0xB1C8B8", Offset = "0xB1C8B8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionSlerp::DoQuatSlerp(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatSlerp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EF3")]
		[Address(RVA = "0xB1C9FC", Offset = "0xB1C9FC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionSlerp::DoQuatSlerp(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatSlerp();
			}
		}

		[Token(Token = "0x6000EF4")]
		[Address(RVA = "0xB1CA0C", Offset = "0xB1CA0C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionSlerp::DoQuatSlerp(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatSlerp();
			}
		}

		[Token(Token = "0x6000EF5")]
		[Address(RVA = "0xB1CA20", Offset = "0xB1CA20", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionSlerp::DoQuatSlerp(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatSlerp();
			}
		}

		[Token(Token = "0x6000EF6")]
		[Address(RVA = "0xB1C8F4", Offset = "0xB1C8F4", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EC6678]);\n\tv35 = *([v34 @ X8_v13]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022586]) = v54;\nL_001B:\n\tv55 = this.fromQuaternion;\n\tv57 = this.toQuaternion;\n\tv110 = this.storeResult;\n\tv143 = HutongGames.PlayMaker.FsmFloat::get_Value(this.amount);\n\tgoto L_0047;\n\tv190 = *([v146 @ X0_v7+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0047;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v146, v102, v38, v39, v40, v41, v42, v43, v143, v45, v46, v47, v48, v49, v50, v51);\nL_0047:\n\t// 71 MakeStruct v64 @ AGGB1C9C4_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v55.value (UnityEngine.Quaternion), v55.value.y (System.Single), v55.value.z (System.Single), v55.value.w (System.Single)\n\t// 72 MakeStruct v61 @ AGGB1C9C4_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v57.value (UnityEngine.Quaternion), v57.value.y (System.Single), v57.value.z (System.Single), v57.value.w (System.Single)\n\tv104 = UnityEngine.Quaternion::Slerp(v64, v61, v143);\n\tv110.value = v104;\n\tv110.value.y = v104.y;\n\tv110.value.z = v104.z;\n\tv110.value.w = v104.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatSlerp()
		{
			FsmQuaternion fsmQuaternion = fromQuaternion;
			FsmQuaternion fsmQuaternion2 = toQuaternion;
			FsmQuaternion fsmQuaternion3 = storeResult;
			float value = amount.Value;
			Quaternion a = default(Quaternion);
			a.x = fsmQuaternion.value.x;
			a.y = fsmQuaternion.value.y;
			a.z = fsmQuaternion.value.z;
			a.w = fsmQuaternion.value.w;
			Quaternion b = default(Quaternion);
			b.x = fsmQuaternion2.value.x;
			b.y = fsmQuaternion2.value.y;
			b.z = fsmQuaternion2.value.z;
			b.w = fsmQuaternion2.value.w;
			Quaternion quaternion = (fsmQuaternion3.value = Quaternion.Slerp(a, b, value));
			fsmQuaternion3.value.y = quaternion.y;
			fsmQuaternion3.value.z = quaternion.z;
			fsmQuaternion3.value.w = quaternion.w;
		}

		[Token(Token = "0x6000EF7")]
		[Address(RVA = "0xB1CA34", Offset = "0xB1CA34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionSlerp()
		{
		}
	}
}
