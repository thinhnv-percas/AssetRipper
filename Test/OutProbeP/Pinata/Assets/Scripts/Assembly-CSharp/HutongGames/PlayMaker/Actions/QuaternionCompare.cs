using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B8B0", Offset = "0x75B8B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B8B0", Offset = "0x75B8B0")]
	[Token(Token = "0x20002F3")]
	public class QuaternionCompare : QuaternionBaseAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C17D8", Offset = "0x7C17D8")]
		[Token(Token = "0x4001906")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion Quaternion1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C1824", Offset = "0x7C1824")]
		[Token(Token = "0x4001907")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion Quaternion2;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C1870", Offset = "0x7C1870")]
		[Token(Token = "0x4001908")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool equal;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C18A8", Offset = "0x7C18A8")]
		[Token(Token = "0x4001909")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent equalEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C18E0", Offset = "0x7C18E0")]
		[Token(Token = "0x400190A")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent notEqualEvent;

		[Token(Token = "0x6000EC0")]
		[Address(RVA = "0xB1B9DC", Offset = "0xB1B9DC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBD050]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202257B]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.Quaternion1 = v46;\n\tv52 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.everyFrameOption = 0;\n\tthis.equalEvent = 0;\n\tthis.notEqualEvent = 0;\n\tthis.Quaternion2 = v52;\n\tthis.equal = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmQuaternion fsmQuaternion = new FsmQuaternion();
			fsmQuaternion.useVariable = true;
			Quaternion1 = fsmQuaternion;
			FsmQuaternion fsmQuaternion2 = new FsmQuaternion();
			fsmQuaternion2.useVariable = true;
			everyFrameOption = default(everyFrameOptions);
			equalEvent = null;
			notEqualEvent = null;
			Quaternion2 = fsmQuaternion2;
			equal = null;
		}

		[Token(Token = "0x6000EC1")]
		[Address(RVA = "0xB1BA80", Offset = "0xB1BA80", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionCompare::DoQuatCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EC2")]
		[Address(RVA = "0xB1BBF0", Offset = "0xB1BBF0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionCompare::DoQuatCompare(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatCompare();
			}
		}

		[Token(Token = "0x6000EC3")]
		[Address(RVA = "0xB1BC00", Offset = "0xB1BC00", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionCompare::DoQuatCompare(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatCompare();
			}
		}

		[Token(Token = "0x6000EC4")]
		[Address(RVA = "0xB1BC14", Offset = "0xB1BC14", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionCompare::DoQuatCompare(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatCompare();
			}
		}

		[Token(Token = "0x6000EC5")]
		[Address(RVA = "0xB1BABC", Offset = "0xB1BABC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EB7A90]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202257C]) = v54;\nL_001B:\n\tv55 = this.Quaternion1;\n\tv57 = this.Quaternion2;\n\tgoto L_003E;\n\tv175 = *([v111 @ X0_v6+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_003E;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v111, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_003E:\n\t// 62 MakeStruct v64 @ AGGB1BB64_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v55.value (UnityEngine.Quaternion), v55.value.y (System.Single), v55.value.z (System.Single), v55.value.w (System.Single)\n\t// 63 MakeStruct v61 @ AGGB1BB64_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v57.value (UnityEngine.Quaternion), v57.value.y (System.Single), v57.value.z (System.Single), v57.value.w (System.Single)\n\tv80 = UnityEngine.Quaternion::Dot(v64, v61);\n\tgoto L_004E;\n\tv244 = *([v186 @ X0_v9+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_004E;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v186, methodInfo, v38, v39, v40, v41, v42, v43, v80, v78, v76, v74, v72, v70, v68, v66);\nL_004E:\n\tv107 = this.equal;\n\tv154 = UnityEngine.Mathf::Abs(v80);\n\tv141 = v154 - 0.999999f;\n\tv138 = v141 < 0;\n\tv135 = v141 == 0;\n\tv132 = v154 ^ 0.999999f;\n\tv129 = v154 ^ v141;\n\tv126 = v132 & v129;\n\tv123 = v126 < 0;\n\tv252 = v138 == v123;\n\tv117 = ~v135;\n\tv253 = v252 & v117;\n\tv107.value = v253;\n\tv120 = v154 <= 0.999999f;\n\tif (v120) goto L_006D;\n\tv195 = this.equalEvent;\n\tgoto L_007C;\nL_006D:\n\tv195 = this.notEqualEvent;\nL_007C:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v195);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatCompare()
		{
			//IL_0143: Expected O, but got F4
			//IL_0150: Expected O, but got F4
			FsmQuaternion quaternion = Quaternion1;
			FsmQuaternion quaternion2 = Quaternion2;
			Quaternion a = default(Quaternion);
			a.x = quaternion.value.x;
			a.y = quaternion.value.y;
			a.z = quaternion.value.z;
			a.w = quaternion.value.w;
			Quaternion b = default(Quaternion);
			b.x = quaternion2.value.x;
			b.y = quaternion2.value.y;
			b.z = quaternion2.value.z;
			b.w = quaternion2.value.w;
			float f = Quaternion.Dot(a, b);
			FsmBool fsmBool = equal;
			float num = Mathf.Abs(f);
			float num2 = num - 0.999999f;
			bool flag = num2 < 0f;
			bool flag2 = num2 == 0f;
			object obj = num ^ 0.999999f;
			object obj2 = num ^ num2;
			int num3 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool value = flag4 && flag5;
			fsmBool.value = value;
			FsmEvent fsmEvent = ((!(num > 0.999999f)) ? notEqualEvent : equalEvent);
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000EC6")]
		[Address(RVA = "0xB1BC28", Offset = "0xB1BC28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionCompare()
		{
		}
	}
}
