using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758FD8", Offset = "0x758FD8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758FD8", Offset = "0x758FD8")]
	[Token(Token = "0x2000273")]
	public class StringContains : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B70C0", Offset = "0x7B70C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B70C0", Offset = "0x7B70C0")]
		[Token(Token = "0x400166F")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7120", Offset = "0x7B7120")]
		[Token(Token = "0x4001670")]
		[FieldOffset(Offset = "0x58")]
		public FsmString containsString;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B716C", Offset = "0x7B716C")]
		[Token(Token = "0x4001671")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent trueEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B71A4", Offset = "0x7B71A4")]
		[Token(Token = "0x4001672")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent falseEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B71DC", Offset = "0x7B71DC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B71DC", Offset = "0x7B71DC")]
		[Token(Token = "0x4001673")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B722C", Offset = "0x7B722C")]
		[Token(Token = "0x4001674")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000C38")]
		[Address(RVA = "0x99E7D8", Offset = "0x99E7D8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF8500]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217BC]) = v38;\nL_0013:\n\tthis.stringVariable = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.everyFrame = 0;\n\tthis.containsString = v43;\n\tthis.trueEvent = 0;\n\tthis.falseEvent = 0;\n\tthis.storeResult = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			stringVariable = null;
			FsmString fsmString = "";
			everyFrame = false;
			containsString = fsmString;
			trueEvent = null;
			falseEvent = null;
			storeResult = null;
		}

		[Token(Token = "0x6000C39")]
		[Address(RVA = "0x99E83C", Offset = "0x99E83C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringContains::DoStringContains(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoStringContains();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C3A")]
		[Address(RVA = "0x99E944", Offset = "0x99E944", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringContains::DoStringContains(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoStringContains();
		}

		[Token(Token = "0x6000C3B")]
		[Address(RVA = "0x99E878", Offset = "0x99E878", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.stringVariable);\n\tv54 = v15 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_001D;\n\tv84 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.containsString);\n\tv80 = v84 == 0;\n\tif (v80) goto L_0022;\nL_001D:\n\treturn;\nL_0022:\n\tv68 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tv69 = HutongGames.PlayMaker.FsmString::get_Value(this.containsString);\n\tv85 = System.String::Contains(v68, v69);\n\tv24 = this.storeResult;\n\tv109 = this.storeResult == 0;\n\tif (v109) goto L_0036;\n\tv24.value = v85;\nL_0036:\n\tv112 = v85 == 0;\n\tif (v112) goto L_003D;\n\tv30 = this.trueEvent;\n\tv113 = this.trueEvent == 0;\n\tv81 = ~v113;\n\tif (v81) goto L_0049;\n\tgoto L_001D;\nL_003D:\n\tv30 = this.falseEvent;\n\tv82 = this.falseEvent == 0;\n\tif (v82) goto L_001D;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v30);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStringContains()
		{
			if (stringVariable.IsNone || containsString.IsNone)
			{
				return;
			}
			string value = stringVariable.Value;
			string value2 = containsString.Value;
			bool flag = value.Contains(value2);
			FsmBool fsmBool = storeResult;
			if (storeResult != null)
			{
				fsmBool.value = flag;
			}
			FsmEvent fsmEvent;
			if (flag)
			{
				fsmEvent = trueEvent;
				if (trueEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = falseEvent;
				if (falseEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000C3C")]
		[Address(RVA = "0x99E948", Offset = "0x99E948", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringContains()
		{
		}
	}
}
