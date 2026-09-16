using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759578", Offset = "0x759578")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759578", Offset = "0x759578")]
	[Token(Token = "0x2000285")]
	public class FloatInterpolate : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B83C4", Offset = "0x7B83C4")]
		[Token(Token = "0x40016BB")]
		[FieldOffset(Offset = "0x4C")]
		public InterpolationType mode;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B83FC", Offset = "0x7B83FC")]
		[Token(Token = "0x40016BC")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat fromFloat;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8448", Offset = "0x7B8448")]
		[Token(Token = "0x40016BD")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat toFloat;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8494", Offset = "0x7B8494")]
		[Token(Token = "0x40016BE")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat time;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B84E0", Offset = "0x7B84E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B84E0", Offset = "0x7B84E0")]
		[Token(Token = "0x40016BF")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8540", Offset = "0x7B8540")]
		[Token(Token = "0x40016C0")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8578", Offset = "0x7B8578")]
		[Token(Token = "0x40016C1")]
		[FieldOffset(Offset = "0x78")]
		public bool realTime;

		[Token(Token = "0x40016C2")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x40016C3")]
		[FieldOffset(Offset = "0x80")]
		private float currentTime;

		[Token(Token = "0x6000C8B")]
		[Address(RVA = "0xB764A0", Offset = "0xB764A0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.FloatInterpolate)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.FloatInterpolate)+54]) = 0;\n\tthis.mode = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.realTime = 0;\n\tthis.storeResult = 0;\n\tthis.finishEvent = 0;\n\tthis.time = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			_ = 0;
			_ = 0;
			mode = default(InterpolationType);
			FsmFloat fsmFloat = 1f;
			realTime = false;
			storeResult = null;
			finishEvent = null;
			time = fsmFloat;
		}

		[Token(Token = "0x6000C8C")]
		[Address(RVA = "0xB764E0", Offset = "0xB764E0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv14 = this.storeResult;\n\tthis.startTime = v13;\n\tthis.currentTime = 0f;\n\tv15 = this.storeResult == 0;\n\tif (v15) goto L_0021;\n\tv25 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromFloat);\n\tv14.value = v25;\n\treturn;\nL_0021:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmFloat fsmFloat = storeResult;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			if (storeResult != null)
			{
				float value = fromFloat.Value;
				fsmFloat.Value = value;
			}
			else
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C8D")]
		[Address(RVA = "0xB76540", Offset = "0xB76540", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAC1C8]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202292E]) = v44;\nL_0017:\n\tv46 = ~this.realTime;\n\tif (v46) goto L_0020;\n\tv48 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv55 = v48 - this.startTime;\n\tgoto L_0023;\nL_0020:\n\tv51 = UnityEngine.Time::get_deltaTime();\n\tv55 = this.currentTime + v51;\nL_0023:\n\tthis.currentTime = v55;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv115 = v55 / v62;\n\tv94 = this.mode == 1;\n\tif (v94) goto L_005D;\n\tv147 = this.mode == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0085;\n\tv216 = this.storeResult;\n\tv120 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromFloat);\n\tv224 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toFloat);\n\tgoto L_0054;\n\tv251 = *([v235 @ X0_v23+E0]);\n\tv252 = v251 == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_0054;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v235, v223, v28, v29, v30, v31, v32, v33, v224, v56, v36, v37, v38, v39, v40, v41);\nL_0054:\n\tv212 = UnityEngine.Mathf::Lerp(v120, v224, v115);\n\tv264 = this.storeResult == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_007A;\n\tthrow System.NullReferenceException;\nL_005D:\n\tv216 = this.storeResult;\n\tv122 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromFloat);\n\tv222 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toFloat);\n\tgoto L_0077;\n\tv239 = *([v228 @ X0_v14+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0077;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v228, v221, v28, v29, v30, v31, v32, v33, v222, v117, v67, v37, v38, v39, v40, v41);\nL_0077:\n\tv212 = UnityEngine.Mathf::SmoothStep(v122, v222, v115);\nL_007A:\n\tv216.value = v212;\nL_0085:\n\tv65 = v115 >= 1f;\n\tif (v65) goto L_0091;\n\treturn;\nL_0091:\n\tv218 = this.finishEvent == 0;\n\tif (v218) goto L_00A2;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_00A2:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				float deltaTime = Time.deltaTime;
				num = currentTime + deltaTime;
			}
			currentTime = num;
			float value = time.Value;
			float num2 = num / value;
			FsmFloat fsmFloat;
			float value4;
			if (mode != InterpolationType.EaseInOut)
			{
				if (mode != InterpolationType.Linear)
				{
					goto IL_01e6;
				}
				fsmFloat = storeResult;
				float value2 = fromFloat.Value;
				float value3 = toFloat.Value;
				value4 = Mathf.Lerp(value2, value3, num2);
				if (storeResult == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				fsmFloat = storeResult;
				float value5 = fromFloat.Value;
				float value6 = toFloat.Value;
				value4 = Mathf.SmoothStep(value5, value6, num2);
			}
			fsmFloat.Value = value4;
			goto IL_01e6;
			IL_01e6:
			if (!(num2 < 1f))
			{
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
				Finish();
			}
		}

		[Token(Token = "0x6000C8E")]
		[Address(RVA = "0xB766FC", Offset = "0xB766FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatInterpolate()
		{
		}
	}
}
