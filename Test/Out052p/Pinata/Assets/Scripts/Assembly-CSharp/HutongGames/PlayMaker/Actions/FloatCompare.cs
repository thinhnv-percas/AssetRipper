using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7588A4", Offset = "0x7588A4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7588A4", Offset = "0x7588A4")]
	[Token(Token = "0x2000260")]
	public class FloatCompare : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5AEC", Offset = "0x7B5AEC")]
		[Token(Token = "0x400160A")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat float1;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5B38", Offset = "0x7B5B38")]
		[Token(Token = "0x400160B")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat float2;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5B84", Offset = "0x7B5B84")]
		[Token(Token = "0x400160C")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat tolerance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5BD0", Offset = "0x7B5BD0")]
		[Token(Token = "0x400160D")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent equal;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5C08", Offset = "0x7B5C08")]
		[Token(Token = "0x400160E")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent lessThan;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5C40", Offset = "0x7B5C40")]
		[Token(Token = "0x400160F")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent greaterThan;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5C78", Offset = "0x7B5C78")]
		[Token(Token = "0x4001610")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000BDA")]
		[Address(RVA = "0xB760E0", Offset = "0xB760E0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.float1 = v12;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.float2 = v15;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.everyFrame = 0;\n\tthis.tolerance = v18;\n\tthis.equal = 0;\n\tthis.lessThan = 0;\n\tthis.greaterThan = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0f;
			float1 = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			float2 = fsmFloat2;
			FsmFloat fsmFloat3 = 0f;
			everyFrame = false;
			tolerance = fsmFloat3;
			equal = null;
			lessThan = null;
			greaterThan = null;
		}

		[Token(Token = "0x6000BDB")]
		[Address(RVA = "0xB76134", Offset = "0xB76134", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatCompare::DoCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BDC")]
		[Address(RVA = "0xB762BC", Offset = "0xB762BC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatCompare::DoCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCompare();
		}

		[Token(Token = "0x6000BDD")]
		[Address(RVA = "0xB76170", Offset = "0xB76170", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA8F98]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202292C]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float1);\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float2);\n\tgoto L_0030;\n\tv189 = *([v185 @ X0_v6+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\t// 43 ConditionalJump @b11, v191 @ TEMP_v20\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v185, v107, v26, v27, v28, v29, v30, v31, v100, v33, v34, v35, v36, v37, v38, v39);\nL_0030:\n\tv195 = v46 - v100;\n\tv96 = UnityEngine.Mathf::Abs(v195);\n\tv101 = HutongGames.PlayMaker.FsmFloat::get_Value(this.tolerance);\n\tv196 = v96 < v101;\n\tv89 = ~v196;\n\tv84 = v96 - v101;\n\tv74 = v84 == 0;\n\tv197 = ~v89;\n\tv49 = v197 | v74;\n\tif (v49) goto L_005B;\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float1);\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float2);\n\tv50 = v102 >= v103;\n\tif (v50) goto L_006D;\n\tv170 = this.fsm;\n\tv168 = this.lessThan;\n\tgoto L_0067;\nL_005B:\n\tv170 = this.fsm;\n\tv168 = this.equal;\nL_0067:\n\tHutongGames.PlayMaker.Fsm::Event(v170, v168);\n\treturn;\nL_006D:\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float1);\n\tv105 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float2);\n\tv51 = v104 <= v105;\n\tif (v51) goto L_008D;\n\tv170 = this.fsm;\n\tv168 = this.greaterThan;\n\tgoto L_0067;\nL_008D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCompare()
		{
			float value = float1.Value;
			float value2 = float2.Value;
			float f = value - value2;
			float num = Mathf.Abs(f);
			float value3 = tolerance.Value;
			bool flag = num < value3;
			bool flag2 = !flag;
			float num2 = num - value3;
			bool flag3 = num2 == 0f;
			bool flag4 = !flag2;
			Fsm fsm;
			FsmEvent fsmEvent;
			if (!(flag4 || flag3))
			{
				float value4 = float1.Value;
				float value5 = float2.Value;
				if (value4 < value5)
				{
					fsm = Fsm;
					fsmEvent = lessThan;
				}
				else
				{
					float value6 = float1.Value;
					float value7 = float2.Value;
					if (!(value6 > value7))
					{
						return;
					}
					fsm = Fsm;
					fsmEvent = greaterThan;
				}
			}
			else
			{
				fsm = Fsm;
				fsmEvent = equal;
			}
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000BDE")]
		[Address(RVA = "0xB762C0", Offset = "0xB762C0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EFEA28]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202292D]) = v40;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv57 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.equal);\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv82 = *([v60 @ X0_v9+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0034;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv69 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.lessThan);\n\tv72 = v69 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_0045;\n\tv107 = *([v103 @ X0_v13+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0045;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v103, v66, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv70 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.greaterThan);\n\tv73 = v70 == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\treturn *([v93 @ X8_v5 (System.String)]);\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(equal) && FsmEvent.IsNullOrEmpty(lessThan) && FsmEvent.IsNullOrEmpty(greaterThan))
			{
				return "Action sends no events!";
			}
			return "";
		}

		[Token(Token = "0x6000BDF")]
		[Address(RVA = "0xB763AC", Offset = "0xB763AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatCompare()
		{
		}
	}
}
