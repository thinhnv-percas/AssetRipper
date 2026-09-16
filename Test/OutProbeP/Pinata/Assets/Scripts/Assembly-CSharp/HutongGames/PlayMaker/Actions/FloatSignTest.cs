using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7588F4", Offset = "0x7588F4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7588F4", Offset = "0x7588F4")]
	[Token(Token = "0x2000261")]
	public class FloatSignTest : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5CB0", Offset = "0x7B5CB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5CB0", Offset = "0x7B5CB0")]
		[Token(Token = "0x4001611")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5D10", Offset = "0x7B5D10")]
		[Token(Token = "0x4001612")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent isPositive;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5D48", Offset = "0x7B5D48")]
		[Token(Token = "0x4001613")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent isNegative;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5D80", Offset = "0x7B5D80")]
		[Token(Token = "0x4001614")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BE0")]
		[Address(RVA = "0xB7699C", Offset = "0xB7699C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.everyFrame = 0;\n\tthis.isPositive = 0;\n\tthis.isNegative = 0;\n\tthis.floatValue = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0f;
			everyFrame = false;
			isPositive = null;
			isNegative = null;
			floatValue = fsmFloat;
		}

		[Token(Token = "0x6000BE1")]
		[Address(RVA = "0xB769D0", Offset = "0xB769D0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSignTest::DoSignTest(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSignTest();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BE2")]
		[Address(RVA = "0xB76A70", Offset = "0xB76A70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSignTest::DoSignTest(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSignTest();
		}

		[Token(Token = "0x6000BE3")]
		[Address(RVA = "0xB76A0C", Offset = "0xB76A0C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.floatValue == 0;\n\tif (v13) goto L_002F;\n\tv16 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tv58 = this + 0x60;\n\tv55 = this + 0x58;\n\tv28 = v16 >= 0;\n\tif (v28) goto L_FFFFFFFF;\n\tgoto L_0028;\nL_0028:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v58 @ X8_v2]));\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSignTest()
		{
			//IL_003f: Expected O, but got I
			//IL_004b: Expected O, but got I
			if (floatValue != null)
			{
				float value = floatValue.Value;
				object fsmEvent = (long)(IntPtr)this + 96L;
				object obj = (long)(IntPtr)this + 88L;
				if (!(value < 0f))
				{
					fsmEvent = obj;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000BE4")]
		[Address(RVA = "0xB76A74", Offset = "0xB76A74", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EC1598]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022930]) = v40;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv57 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.isPositive);\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv76 = *([v60 @ X0_v9+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0034;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv68 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.isNegative);\n\tv70 = v68 == 0;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\treturn *([v87 @ X8_v5 (System.String)]);\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(isPositive) && FsmEvent.IsNullOrEmpty(isNegative))
			{
				return "Action sends no events!";
			}
			return "";
		}

		[Token(Token = "0x6000BE5")]
		[Address(RVA = "0xB76B34", Offset = "0xB76B34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatSignTest()
		{
		}
	}
}
